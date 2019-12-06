using News;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newsBlog
{
    

    public partial class login1 : System.Web.UI.Page
    {
        adminPage adminPage = new adminPage();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string changedPassword = "";
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userPassword.Text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j <= 2; j++)
                {
                    for(int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString($"X{j}"));
                    }
                }
                changedPassword = sb.ToString();
            }

            var userData = sql.Exec($"select newsAdminIdPK, newsAdminID, newsAdminPassword, newsUserType from newsAdmin");
            foreach (DataRow dr in userData.Rows)
            {
                if (userName.Text != "" && userPassword.Text != "" && 
                    userName.Text == dr[1].ToString() && changedPassword == dr[2].ToString())
                {
                    string x = userName.Text;
                    string y = userPassword.Text;
                    adminPage adminPage = new adminPage();
                    Session[adminPage.adminID] = dr[3];
                    Response.Redirect($"adminPage.aspx");
                    //?loggedUserID ={ dr[3]}
                }
                else
                {
                    invalidPsw.InnerText = "Invalid Value";
                }
            }
        }

    }
}