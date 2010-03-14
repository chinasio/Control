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
    public partial class Modify2 : System.Web.UI.Page
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

            Session["news"] = model;
            lblNewsId.Text = model.NewsId.ToString();
            this.txtHeading.Text = model.Heading;
            this.FreeTextBox1.Text = model.Content;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            int newid = int.Parse(lblNewsId.Text);
            string heading = this.txtHeading.Text.Trim();
            string content = FreeTextBox1.Text;

            if (heading == "")
            {
                strErr += "标题不能为空\\n";

            }
            if (content == "")
            {
                strErr += "内容不能为空\\n";

            }
            if (strErr != "")
            {
                LTP.Common.MessageBox.Show(this, strErr);
                return;
            }

            if (Session["UserInfo"] == null)
                return;
            LTP.Accounts.Bus.User currentUser = (LTP.Accounts.Bus.User)Session["UserInfo"];
            Maticsoft.Model.NewsManage.News news = (Maticsoft.Model.NewsManage.News)Session["news"];
            news.NewsId = newid;
            news.Heading = heading;
            news.Content = content;
            news.Frequency = 0;
            news.IssueDate = DateTime.Now;
            Maticsoft.BLL.NewsManage.News n = new Maticsoft.BLL.NewsManage.News();
            n.Update(news);
            Response.Redirect("show.aspx?id=" + newid);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }

}
