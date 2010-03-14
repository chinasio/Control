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
    public partial class Search : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BiudTree();
                this.dropNewsClass.Items.Insert(0, "--全部--");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strsql = "";
            string strErr = "";
            string newsid = this.txtNewsId.Text.Trim();
            string heading = this.txtHeading.Text.Trim();
            string focus = this.txtFocus.Text.Trim();
            string date1 = this.StartRegTime.Text.Trim().ToString();
            string date2 = this.EndRegTime.Text.Trim().ToString();
            string Frequency1 = this.txtFrequency1.Text.Trim();
            string Frequency2 = this.txtFrequency2.Text.Trim();
            string Dormancy = this.dropDormancy.SelectedValue.ToLower();
            string classid = this.dropNewsClass.SelectedValue;

            #region
            if (newsid != "")
            {
                try
                {
                    int.Parse(newsid);
                }
                catch
                {
                    strErr += "新闻编号格式不正确！";
                }
            }
            if (Frequency1 != "")
            {
                try
                {
                    int.Parse(Frequency1);
                }
                catch
                {
                    strErr += "点击率数格式不正确！\\n";
                }
            }

            if (Frequency2 != "")
            {
                try
                {
                    int.Parse(Frequency2);
                }
                catch
                {
                    strErr += "点击率数格式不正确！\\n";
                }
            }
            #endregion


            if (strErr != "")
            {
                LTP.Common.MessageBox.Show(this, strErr);
                return;
            }
            if (newsid != "")
            {
                strsql += " and (NewsId =" + newsid + ")";
            }
            if (heading != "")
            {
                strsql += " and (Heading like'%" + heading + "%')";
            }
            if (focus != "")
            {
                strsql += " and (Focus like'%" + focus + "%')";
            }
            if (date1 != "")
            {
                strsql += " and (IssueDate >='" + date1 + "')";
            }
            if (date2 != "")
            {
                strsql += " and (IssueDate <='" + date2 + "')";
            }
            if (Frequency1 != "")
            {
                strsql += " and (Frequency >'" + Frequency1 + "')";
            }
            if (Frequency2 != "")
            {
                strsql += " and (Frequency <'" + Frequency2 + "')";
            }

            if (Dormancy != "0")
            {
                strsql += " and (Dormancy ='" + Dormancy + "')";
            }

            if (this.dropNewsClass.SelectedIndex > 0)
            {
                strsql += " and (ClassId =" + classid + ")";
            }

            if (strsql != "")
            {
                Session["strWhereNews"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereNews"] = "";
            }
            Response.Redirect("index.aspx?page=1");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }

}
