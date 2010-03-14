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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FreeTextBox1.AutoConfigure = AutoConfigure.EnableAll;
                this.FreeTextBox1.HelperFilesPath = "HelperScripts";
                //this.FreeTextBox1.ImageGalleryPath="images";
                string UpNewsImageFolder = LTP.Common.ConfigHelper.GetConfigString("UpNewsImageFolder");
                this.FreeTextBox1.ImageGalleryPath = UpNewsImageFolder;

                BiudTree();
                if (Session["news"] != null)
                {
                    Maticsoft.Model.NewsManage.News news = (Maticsoft.Model.NewsManage.News)Session["news"];
                    for (int i = 0; i < this.dropNewsClass.Items.Count; i++)
                    {
                        if (this.dropNewsClass.Items[i].Value == news.ClassId.ToString())
                        {
                            this.dropNewsClass.Items[i].Selected = true;
                        }
                    }
                    this.chkDormancy.Checked = news.Dormancy == "true" ? true : false;
                    this.chkAddContinue.Checked = true;
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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            string heading = this.txtHeading.Text.Trim();
            string focus = this.txtFocus.Text.Trim();
            string content = this.FreeTextBox1.Text.Trim();
            string classid = this.dropNewsClass.SelectedValue;
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
            news.ClassId = int.Parse(classid);
            news.Heading = heading;
            news.Focus = focus;
            news.Content = content;
            if (dormancy)
            {
                news.Dormancy = "False";                
            }
            else 
            {                
                news.Dormancy = "True";
            }
            news.Dormancy = dormancy.ToString();
            //news.Opened = opened;
            news.Frequency = 0;
            news.IssueDate = DateTime.Now;
            //news.ParentId = 0;
            news.Priority = 0;
            news.UserId = currentUser.UserID;
            //news.DepartmentID = int.Parse(currentUser.DepartmentID);
            if (chkIsTop.Checked)
            {
                news.IsTop = 1;
            }
            else
            {
                news.IsTop = 0;
            }

            Maticsoft.BLL.NewsManage.News n = new Maticsoft.BLL.NewsManage.News();
            n.Add(news);

            if (chkAddContinue.Checked)
            {
                Session["news"] = news;
                Response.Redirect("Add.aspx");
            }
            else
            {
                Session["news"] = null;
                Response.Redirect("index.aspx");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtHeading.Text = "";
            this.txtFocus.Text = "";
            this.FreeTextBox1.Text = "";
        }
    }
}
    
