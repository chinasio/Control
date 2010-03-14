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

namespace Maticsoft.Web.Admin.NewsClassManage
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string id = Request.Params["id"];
                if (id == null || id.Trim() == "")
                {
                    Response.Redirect("index.aspx");
                    Response.End();
                }
                else
                {
                    ShowInfo(int.Parse(id));
                }
            }
        }


        private void ShowInfo(int Id)
        {
            Navigation011.Para_Str = "id=" + Id;
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            Maticsoft.Model.NewsManage.NewsClass model = bll.GetModel(Id);
            lblClassId.Text = model.ClassId.ToString();
            lblClassDesc.Text = model.ClassDesc;
            lblClassPicture.Text = model.ClassPicture;
            lblParentId.Text = model.ParentId.ToString();

        }
    }

}
