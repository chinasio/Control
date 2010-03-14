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
using FreeTextBoxControls;

namespace Maticsoft.Web.Admin.NewsManage
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
                string id = Request.Params["id"];
                bll.Delete(int.Parse(id));
                Response.Redirect("index.aspx");
            }
        }
    }
}
