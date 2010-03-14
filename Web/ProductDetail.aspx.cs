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
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "产品详细";
                if ((Request.Params["productID"] != null) && (Request.Params["productID"].ToString() != ""))
                {
                    string id = Request.Params["productID"];
                    ShowNews(id);
                }

            }
        }

        private void ShowNews(string productID)//显示新闻
        {
            Maticsoft.BLL.Products.Product bll = new Maticsoft.BLL.Products.Product();
            Maticsoft.Model.Product model = bll.GetModelByCache(productID);

            this.lblProductId.Text = model.ProductId.ToString();
            this.lblName.Text = model.Name;
            lblDescn.Text = model.Descn;
            lblPrice.Text = model.Price.ToString();
            lblvipprice.Text = model.VipPrice.ToString();
            Image1.ImageUrl = "ProductImages/" + model.Image;
            Maticsoft.BLL.Products.Category bllc = new Maticsoft.BLL.Products.Category();
            lblCategoryId.Text = bllc.GetName(model.CategoryId);
            if (model.Cheapness == 1)
            {
                Label1.Text = "是";
            }
            else
            {
                Label1.Text = "否";
            }

        }
    }
}
