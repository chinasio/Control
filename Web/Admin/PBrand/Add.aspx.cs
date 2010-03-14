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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCate();
            }

        }
        private void BindCate()
        {
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            this.DropCategory.DataSource = bll.GetAllList();
            this.DropCategory.DataTextField = "Name";
            DropCategory.DataValueField = "CategoryId";
            DropCategory.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string BrandId = this.txtBrandId.Text;
            string Name = this.txtName.Text;
            string Descn = this.txtDescn.Text;
            string CategoryId = DropCategory.SelectedValue;


            Maticsoft.Model.Brand model = new Maticsoft.Model.Brand();
            model.BrandId = BrandId;
            model.Name = Name;
            model.Descn = Descn;
            model.CategoryId = CategoryId;
            Maticsoft.BLL.Products.Brand bll = new Maticsoft.BLL.Products.Brand();
            if (bll.Exists(BrandId))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "±‡∫≈“—æ≠¥Ê‘⁄£°";
            }
            else
            {
                bll.Add(model);
                if (chkAddContinue.Checked)
                {
                    Response.Redirect("Add.aspx");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }

        }
    }
}
