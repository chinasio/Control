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

namespace Maticsoft.Web.Admin.NewsClassManage
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //邦定类别的树菜单
                BiudTree();
                //				BindDept();
            }

        }
        #region
        private void BiudTree()
        {

            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            DataTable dt;
            dt = bll.GetList("").Tables[0];
            this.dropParent.Items.Clear();
            //加载树
            this.dropParent.Items.Add(new ListItem("顶级目录", "0"));
            DataRow[] drs = dt.Select("ParentId= 0");


            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                string parentid = r["ParentId"].ToString();
                //				string permissionid=r["PermissionID"].ToString();
                text = "╋" + text;
                this.dropParent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, dt, blank);

            }
            this.dropParent.DataBind();

        }
        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                text = blank + "『" + text + "』";

                this.dropParent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }

        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string strsql = "";
            if (this.txtClassid.Text.Trim() != "")
            {
                strsql += " and (Classid='" + this.txtClassid.Text.Trim() + "')";
            }

            if (this.txtClassDesc.Text.Trim() != "")
            {
                strsql += " and (ClassDesc='%" + this.txtClassDesc.Text.Trim() + "%')";
            }
            if (this.dropParent.SelectedIndex > 0)
            {
                strsql += " and (ParentId=" + this.dropParent.SelectedValue + ")";
            }
            else
            {
                strsql += " and (ParentId=0)";
            }


            if (strsql != "")
            {
                Session["strWhereNewsClass"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereNewsClass"] = "";
            }
            Response.Redirect("index.aspx?page=1");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtClassid.Text = "";
            this.txtClassDesc.Text = "";
        }
    }

}
