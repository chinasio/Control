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

namespace Maticsoft.Web.Admin.PBrand
{
    public partial class Modify : System.Web.UI.Page
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
                    ShowInfo(id);
                }
            }

        }

        private void ShowInfo(string BrandId)
        {
            Maticsoft.BLL.Products.Brand bll = new Maticsoft.BLL.Products.Brand();
            Maticsoft.Model.Brand model = bll.GetModel(BrandId);
            this.lblBrandId.Text = model.BrandId;
            this.txtName.Text = model.Name;
            this.txtDescn.Text = model.Descn;
            this.Label1.Text = model.CategoryId;


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string BrandId = this.lblBrandId.Text;
            string Name = this.txtName.Text;
            string Descn = this.txtDescn.Text;



            Maticsoft.Model.Brand model = new Maticsoft.Model.Brand();
            model.CategoryId = Label1.Text;
            model.BrandId = BrandId;
            model.Name = Name;
            model.Descn = Descn;

            Maticsoft.BLL.Products.Brand bll = new Maticsoft.BLL.Products.Brand();
            bll.Update(model);
            Response.Redirect("index.aspx");

        }
    }
}
