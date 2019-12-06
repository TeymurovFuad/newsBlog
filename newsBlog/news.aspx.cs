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
    public partial class news : System.Web.UI.Page
    {
        string orderStatus = "newsIdPK";
        string listItemText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillContent();
                fillCategory();
                categoriesas();
            }
        }

        public void fillCategory()
        {
            var category = sql.Exec($"select * from newscategory");
            var sb = new StringBuilder();
            foreach (DataRow dr in category.Rows)
            {
                categories.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
        }

        private void fillContent()
        {
            var dt = sql.Exec($"select newsTittle, newsContent, [newsCategory ], newsImg, newsImgName, newsIdPK, newsCreatedTime " +
                                $"from news where newsStatus = '1' and newsTittle like '%{listItemText}%'");
            var sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append($"<li class='last'>" +
                            $"<span class='topLeft'>25</span>" +
                            $"<a href='news.aspx?id={dr[5]}'>" +
                                $"<img src='HTML/images/{dr[3]}' title='{dr[4]}'/></a>" +
                            $"<span class='bottomRight'>{dr[6]}</span>" +
                         $"</li>");
            }
            newsImgCont.InnerHtml = sb.ToString();
            listItemText = categories.SelectedItem.Text.ToString();
            return;
        }

        protected void categoriesas()
        {
            listItemText = categories.SelectedItem.Text.ToString();
            fillContent();
        }

        protected void categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            listItemText = categories.SelectedItem.Text.ToString();
            fillContent();
        }
    }
}