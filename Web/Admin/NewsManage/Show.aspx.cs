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
using System.Drawing;
namespace Maticsoft.Web.Admin.NewsManage
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
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            Maticsoft.Model.NewsManage.News model = bll.GetModel(Id);
            this.lblNewsId.Text = model.NewsId.ToString();
            this.lblHeading.Text = model.Heading;
            this.lblFocus.Text = model.Focus;
            this.lblFrequency.Text = model.Frequency.ToString();
            if (model.Dormancy == "True")
            {
                this.lblDormancy.Text = "·¢²¼";
            }
            else
            {
                this.lblDormancy.Text = "ÐÝÃß";
            }

            lblistop.Text = model.IsTop == 1 ? "ÊÇ" : "·ñ";


            this.lblIssueDate.Text = model.IssueDate.ToString();
            this.lblContent.Text = model.Content;
            Maticsoft.BLL.NewsManage.NewsClass bllc = new Maticsoft.BLL.NewsManage.NewsClass();
            this.lblClass.Text = bllc.GetModel(model.ClassId).ClassDesc;



        }
    }

}
