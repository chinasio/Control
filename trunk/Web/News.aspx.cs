using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Maticsoft.Web
{
    public partial class News : System.Web.UI.Page
    {
        public string strHeading = "";
        public string strDate = "";
        public string strContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "新闻";
                if ((Request.Params["id"] != null) && (Request.Params["id"].ToString() != ""))
                {
                    string id = Request.Params["id"];
                    ShowNews(int.Parse(id));
                }

            }
        }

        private void ShowNews(int NewsId)//显示新闻
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            Maticsoft.Model.NewsManage.News model = bll.GetModelByCache(NewsId);

            strHeading = model.Heading;
            strDate = model.IssueDate.ToString();
            strContent = model.Content;


        }
    }
}
