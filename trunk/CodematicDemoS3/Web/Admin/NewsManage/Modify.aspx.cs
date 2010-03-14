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
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BiudTree();
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

        #region 类别树
        private void BiudTree()
        {
            if (Session["UserInfo"] == null)
            {
                return;
            }

            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            DataTable dt;
            dt = bll.GetList("").Tables[0];
            this.dropNewsClass.Items.Clear();

            //加载树
            DataRow[] drs = dt.Select("ParentId= 0");

            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                string parentid = r["ParentId"].ToString();
                text = "╋" + text;
                this.dropNewsClass.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, dt, blank);

            }
            this.dropNewsClass.DataBind();

        }
        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                text = blank + "『" + text + "』";

                this.dropNewsClass.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";


                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion

        private void ShowInfo(int Id)
        {
            Navigation011.Para_Str = "id=" + Id;
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            Maticsoft.Model.NewsManage.News model = bll.GetModel(Id);

            Session["news"] = model;
            lblNewsId.Text = model.NewsId.ToString();
            for (int i = 0; i < this.dropNewsClass.Items.Count; i++)
            {
                if (this.dropNewsClass.Items[i].Value == model.ClassId.ToString())
                {
                    this.dropNewsClass.Items[i].Selected = true;
                }
            }

            this.txtHeading.Text = model.Heading;
            this.txtFocus.Text = model.Focus;
            if (model.Dormancy.ToString().ToLower() == "true")
            {
                this.chkDormancy.Checked = false;
            }
            else
            {
                this.chkDormancy.Checked = true;
            }

            //			if(news.Opened.ToString().ToLower()=="true")
            //			{
            //				this.radlistOpened.SelectedIndex=1;
            //			}
            //			else
            //			{
            //				this.radlistOpened.SelectedIndex=0;
            //			}

            this.FreeTextBox1.Text = model.Content;


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            int newid = int.Parse(lblNewsId.Text);
            string heading = this.txtHeading.Text.Trim();
            string focus = this.txtFocus.Text.Trim();
            string content = this.FreeTextBox1.Text.Trim();
            string classid = this.dropNewsClass.SelectedValue;
            //bool opened = this.radlistOpened.SelectedValue == "1" ? true : false;
            bool dormancy = this.chkDormancy.Checked;

            if (heading == "")
            {
                strErr += "标题不能为空\\n";

            }
            if (content == "")
            {
                strErr += "内容不能为空\\n";

            }
            if ((this.dropNewsClass.Items.Count == 0) || (classid.Trim() == ""))
            {
                strErr += "没有可以选择的类别！\\n";
            }

            if (strErr != "")
            {
                LTP.Common.MessageBox.Show(this, strErr);
                return;
            }

            if (Session["UserInfo"] == null)
                return;
            LTP.Accounts.Bus.User currentUser = (LTP.Accounts.Bus.User)Session["UserInfo"];
            Maticsoft.Model.NewsManage.News news = new Maticsoft.Model.NewsManage.News();
            news.NewsId = newid;
            news.ClassId = int.Parse(classid);
            news.Heading = heading;
            news.Focus = focus;
            news.Content = content;
            news.Frequency = 0;
            if (dormancy)
            {
                news.Dormancy = "True";
            }
            else
            {
                news.Dormancy = "False";
            }
            news.IssueDate = DateTime.Now;
            news.Priority = 0;
            news.UserId = currentUser.UserID;
            if (chkIsTop.Checked)
            {
                news.IsTop = 1;
            }
            else
            {
                news.IsTop = 0;
            }

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
