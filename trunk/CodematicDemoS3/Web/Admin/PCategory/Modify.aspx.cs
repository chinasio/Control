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
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BiudTree();
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string id = Request.Params["id"];
                    ShowInfo(id);
                }
                else
                {
                    Response.Redirect("index.aspx");
                    Response.End();
                }
            }
        }
        private void ShowInfo(string id)
        {
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            Maticsoft.Model.Category model = bll.GetModel(id);
            this.lblCategoryId.Text = model.CategoryId.ToString();
            txtName.Text = model.Name;
            txtDescn.Text = model.Descn;
            //if (model.ParentId == 0)
            //{
            //    dropParent.SelectedIndex = 0;
            //}
            //else
            //{
            //    for (int m = 0; m < this.dropParent.Items.Count; m++)
            //    {
            //        if (this.dropParent.Items[m].Value == model.ParentId.ToString())
            //        {
            //            this.dropParent.Items[m].Selected = true;
            //        }
            //    }
            //}

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string CategoryId = this.lblCategoryId.Text;
            string Name = this.txtName.Text;
            string Descn = this.txtDescn.Text;

            Maticsoft.Model.Category model = new Maticsoft.Model.Category();
            model.CategoryId = CategoryId;
            model.Name = Name;
            model.Descn = Descn;
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            bll.Update(model);
            Response.Redirect("index.aspx");


        }
    }
}
