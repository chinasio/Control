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
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCategory();
            }
        }
        private void ShowCategory()
        {
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            this.DataList1.DataSource = bll.GetAllList();
            this.DataList1.DataBind();

        }
    }
}
