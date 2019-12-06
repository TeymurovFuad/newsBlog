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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillContent();
        }

        private void fillContent()
        {
            var content = sql.Exec($"select top(5) newsTittle, newsContent, newsImg, newsCreatedTime, newsImgName, newsIdPK from news where newsStatus = '1'");
            var sb = new StringBuilder();
            foreach (DataRow dr in content.Rows)
            {
                sb.Append($"<li>" +
                                $"<img src='HTML/images/{dr[2]}' alt='{dr[4]}'/><p><strong ><a href='news.aspx?imgID={dr[5]}'>{dr[0]}</a></strong>{dr[1]}</ p >" +
                            $"</ li >");
            }
            latestnews.InnerHtml = sb.ToString();
        }
    }
}