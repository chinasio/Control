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

namespace Maticsoft.Web.Admin.PCategory
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string CategoryId = this.txtCategoryId.Text;
            string Name = this.txtName.Text;
            string Descn = this.txtDescn.Text;



            Maticsoft.Model.Category model = new Maticsoft.Model.Category();
            model.CategoryId = CategoryId;
            model.Name = Name;
            model.Descn = Descn;
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            if (bll.Exists(CategoryId))
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
