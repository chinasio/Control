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

namespace Maticsoft.Web.Admin.Product
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
                    ShowInfo(id);
                }
            }
        }
        private void ShowInfo(string Id)
        {            
            Maticsoft.BLL.Products.Product bll = new Maticsoft.BLL.Products.Product();
            Maticsoft.Model.Product model = bll.GetModel(Id);
            //Maticsoft.BLL.Products.Brand bllb = new Maticsoft.BLL.Products.Brand();
            Maticsoft.BLL.Products.Category bllc = new Maticsoft.BLL.Products.Category();
            
            this.lblProductId.Text = model.ProductId.ToString();
            this.lblName.Text = model.Name;
            lblDescn.Text = model.Descn;
            lblPrice.Text = model.Price.ToString();
            lblvipprice.Text = model.VipPrice.ToString();
            lblImage.Text = model.Image;
            //lblBrandId.Text = bllb.GetName(model.BrandId);
            lblCategoryId.Text = bllc.GetName(model.CategoryId);
            if (model.Cheapness == 1)
            {
                Label1.Text = "ÊÇ";
            }
            else
            {
                Label1.Text = "·ñ";
            }


        }


    }
}
