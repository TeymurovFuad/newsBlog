using News;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsBlog
{
    public partial class adminPage : System.Web.UI.Page
    {
        public string adminID;
        int offsetX = 0;
        int fetchNextX = 5;
        DataTable newsTable = sql.Exec($"select * from news");
        DataTable newsCategory = sql.Exec($"select * from newsCategory");
        DataTable newsAdmin = sql.Exec($"select * from newsAdmin");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillCategory();
                fillArticles();
                fillUsers();
                ifAdmin();
                //newCategory.Text = Session[adminID].ToString();
            }
        }

        public void fillCategory()
        {
            var category = sql.Exec($"select * from newscategory");
            var sb = new StringBuilder();
            foreach (DataRow dr in category.Rows)
            {
                categorySelection.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
        }
        public void fillArticles()
        {
            var articles = sql.Exec($"select newsTittle, newsStatus, newsAdminID, newsIdPK from news " +
                $"left join newsAdmin " +
                $"on newsAdminIdPK = newsCreatedAdminID " +
                $"order by newsIdPK OFFSET {offsetX} ROWS FETCH NEXT {fetchNextX} ROWS ONLY");
            var sb = new StringBuilder();
            foreach (DataRow dr in articles.Rows)
            {
                sb.Append($"" +
                    $"<tr>" +
                        $"<td><h3>{dr[0]}</h3></td>" +
                        $"<td>{dr[1]}</td>" +
                        $"<td>{dr["newsAdminID"]}</td>" +
                        $"<td><a href='?articleID={dr[3]}' class='ico del'>Delete</a> | <a href='?articleID={dr[3]}' class='ico edit'>Edit</a></td>" +
                    $"</tr>");
            }
            existingNews.InnerHtml = sb.ToString();
        }

        public void fillUsers()
        {
            var usersTable = sql.Exec($"select newsAdminID, newsAdminPassword, newsUserType, newsAdminIdPK from newsAdmin");
            var sb = new StringBuilder();
            foreach (DataRow dr in usersTable.Rows)
            {
                sb.Append($"" +
                    $"<tr>" +
                        $"<td><h3>{dr[0]}</h3></td>" +
                        $"<td>{dr[1]}</td>" +
                        $"<td>{dr[2]}</td>" +
                        $"<td>" +
                            $"<a href='?userID={dr[3]}&userName={dr[0]}&userPassword={dr[1]}' class='ico del'>Delete</a> | " +
                            $"<a href='?userID={dr[3]}&userName={dr[0]}&userPassword={dr[1]}' class='ico edit'>Edit</a>" +
                        $"</td>" +
                    $"</tr>");
            }
            existingUsers.InnerHtml = sb.ToString();
        }
        protected void enteredUserType()
        {
            adminID = Request.QueryString["loggedUserID"];
        }
        protected void ifAdmin()
        {
            adminID = Session[adminID].ToString();
            if (adminID.ToString() != "2")
            {
                hide.Visible = false;
                hide2.Visible = false;
                passwordBox.Visible = false;
                hideNewsID.Visible = false;
            }
        }

        protected void SubmitContent_Click(object sender, EventArgs e)
        {
            if (adminID != "2")
            {
                if (imgName.Text == "")
                {
                    imgName.Attributes.CssStyle.Add("border-color", "red");
                    imgName.Text = "Please insert image name";
                }
                else
                {
                    var selectedCategory = categorySelection.SelectedValue.ToString();
                    var extension = Path.GetExtension(uploadImg.FileName);
                    string imageName = imgName.Text + categorySelection.SelectedValue + "y" + DateTime.Now.Year +
                        "m" + DateTime.Now.Month + "d" + DateTime.Now.Day + "h" + DateTime.Now.Hour + 
                        "m" + DateTime.Now.Minute + "s" + DateTime.Now.Second + "ms" + DateTime.Now.Millisecond + extension;
                    uploadImg.SaveAs(Server.MapPath("HTML/images/" + imageName));
                    var category = categorySelection.SelectedValue.ToString();
                    sql.Exec($"insert into news (newsContent, newsTittle, [newsCategory ], " +
                            $"newsImg, newsImgName, newsCreatedTime, newsCreatedAdmin, newsStatus) " +
                            $"values (N'{contentBody.Text}', N'{contentTittle.Text}', " +
                            $"'{selectedCategory}', N'{imageName}', N'{imgName.Text}', getdate(), '{adminID}', '0')");    
                    contentBody.Text = "";
                    contentTittle.Text = "";
                    imgName.Text = "";
                };
            }
            else
            {
                sql.Exec($"update news set newsContent = '{contentTittle.Text}', " +
                                    $"newsTittle = '{contentBody.Text}', newsStatus = '1' where newsIdPK = '{newsID.Text}'");
            }
        }


        protected void submitNewCategory_Click(object sender, EventArgs e)
        {
            var category = sql.Exec($"select * from newsCategory where newsCategoryType = N'{newCategory.Text}'");
                if (category.Rows.Count > 0 || newCategory.Text == "" 
                                            || newCategory.Text == "This category alredy exists"
                                            )
                {
                    newCategory.Attributes.CssStyle.Add("border-color", "red");
                    newCategory.Text = "This category alredy exists";
                }
                else
                {
                    sql.Exec($"insert into newsCategory (newsCategoryType) values (N'{newCategory.Text}')");
                    newCategory.Text = "";
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            contentTittle.Text = "";
            contentBody.Text = "";
        }

        protected void previous_Click(object sender, EventArgs e)
        {
            //var offset = sql.Exec($"select * from news order by newsIdPK OFFSET {offsetX} ROWS FETCH NEXT {fetchNextX} ROWS ONLY");
            var x = newsTable.Rows.Count / 5;
            x--;
            if (x == 0)
            {
                previous.Attributes.CssStyle.Add("pointer-events", "none");
            }
             next.Attributes.CssStyle.Add("pointer-events", "initial");
        }

        protected void next_Click(object sender, EventArgs e)
        {
            var offset = sql.Exec($"select * from news order by newsIdPK OFFSET {offsetX} ROWS FETCH NEXT {fetchNextX} ROWS ONLY");
            var count = offset.Rows.Count;
            previous.Attributes.CssStyle.Add("pointer-events", "initial");
            if ((count % 5).Equals(null) || newsTable.Rows.Count <= 5)
            {
                next.Attributes.CssStyle.Add("pointer-events", "none");
            }
            else
            {
                sql.Exec($"select * from news order by newsIdPK OFFSET {offsetX} ROWS FETCH NEXT {fetchNextX} ROWS ONLY");
                offsetX += 5;
                fetchNextX += 5;
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var changedPassword = oldPasswordHolder.Text;
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(oldPasswordHolder.Text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j <= 2; j++)
                {
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString($"X{j}"));
                    }
                }
                newPasswordHolder.Text = sb.ToString();
            }
        }

        protected void reset2_Click(object sender, EventArgs e)
        {
            oldPasswordHolder.Text = "";
            newPasswordHolder.Text = "";
        }

        protected void submitUserChange_Click(object sender, EventArgs e)
        {
            var name = Request.QueryString["userName"];
            var password = Request.QueryString["userPassword"];
            userLoginName.Text = name;
            oldPasswordHolder.Text = password;


        }

        protected void addNewPassword_Click(object sender, EventArgs e)
        {
            if(newPasswordHolder.Text != "")
            {
                sql.Exec($"update newsAdmin set newsAdminPassword = '{newPasswordHolder.Text}' " +
                         $"where newsAdminID = '{userLoginName.Text}'");
            }
            else
            {
                addNewPassword.Style.Add("border-color","red");
            }
        }

        protected void changeNews_Click(object sender, EventArgs e)
        {
            var contentID = Request.QueryString["articleID"];
            var newsDataGet = sql.Exec($"select newsContent, newsTittle, newsIdPK from news where newsIdPK = '{contentID}'");
            contentTittle.Text = newsDataGet.Rows[0][0].ToString();
            contentBody.Text = newsDataGet.Rows[0][1].ToString();
            newsID.Text = newsDataGet.Rows[0][2].ToString();
        }
    }
}