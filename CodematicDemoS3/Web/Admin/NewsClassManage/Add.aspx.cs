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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //邦定类别的树菜单
                BiudTree();                
                if (Session["newsclass"] != null)
                {
                    Maticsoft.Model.NewsManage.NewsClass model = (Maticsoft.Model.NewsManage.NewsClass)Session["newsclass"];
                    for (int m = 0; m < this.dropParent.Items.Count; m++)
                    {
                        if (this.dropParent.Items[m].Value == model.ParentId.ToString())
                        {
                            this.dropParent.Items[m].Selected = true;
                        }
                    }
                    this.chkAddContinue.Checked = true;
                }
            }
        }

        #region BiudPermTree
        //private void BiudPermTree()
        //{
        //    DataTable tabcategory = PowerWeb.Web.Accounts.CS.Bus.AccountsTool.GetAllCategories().Tables[0];
        //    int rc = tabcategory.Rows.Count;
        //    for (int n = 0; n < rc; n++)
        //    {
        //        string CategoryID = tabcategory.Rows[n]["CategoryID"].ToString();
        //        string CategoryName = tabcategory.Rows[n]["Description"].ToString();
        //        CategoryName = "╋" + CategoryName;
        //        this.listPermission.Items.Add(new ListItem(CategoryName, CategoryID));

        //        DataTable tabforums = PowerWeb.Web.Accounts.CS.Bus.AccountsTool.GetPermissionsByCategory(int.Parse(CategoryID)).Tables[0];
        //        int fc = tabforums.Rows.Count;
        //        for (int m = 0; m < fc; m++)
        //        {
        //            string ForumID = tabforums.Rows[m]["PermissionID"].ToString();
        //            string ForumName = tabforums.Rows[m]["Description"].ToString();
        //            ForumName = "  ├『" + ForumName + "』";
        //            this.listPermission.Items.Add(new ListItem(ForumName, ForumID));
        //        }
        //    }
        //    this.listPermission.DataBind();
        //    this.listPermission.Items.Insert(0, new ListItem("--请选择--", "-1"));
        //}

        #endregion

        #region BiudTree
        private void BiudTree()
        {
            //			if(Session["UserInfo"]==null)
            //			{
            //				return ;
            //			}
            //			MoviePrincipal user=new MoviePrincipal(Context.User.Identity.Name);
            //			PowerWeb.Web.Accounts.CS.Bus.User currentUser=(PowerWeb.Web.Accounts.CS.Bus.User)Session["UserInfo"];00
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            DataTable dt;
            //			if(user.HasPermissionID(newsmanageid))
            //			{
            //				dt=nc.GetNewsClassList("").Tables[0];
            //			}
            //			else
            //			{
            //				dt=nc.GetNewsClassList(int.Parse(currentUser.DepartmentID)).Tables[0];
            dt = bll.GetList("").Tables[0];
            //			}

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
                //string permissionid=r["PermissionID"].ToString();
                text = blank + "『" + text + "』";

                this.dropParent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";

                BindNode(sonparentid, dt, blank2);
            }
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //string strErr = "";
            string ClassDesc = this.txtClassDesc.Text;
            string ClassPicture = this.txtClassPicture.Text;
            int ParentId = 0;
            if (this.dropParent.SelectedIndex > 0)
            {
                ParentId = int.Parse(this.dropParent.SelectedValue);
            }


            Maticsoft.Model.NewsManage.NewsClass model = new Maticsoft.Model.NewsManage.NewsClass();
            model.ClassDesc = ClassDesc;
            model.ClassPicture = ClassPicture;
            model.ParentId = ParentId;
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            bll.Add(model);

            if (chkAddContinue.Checked)
            {
                Session["newsclass"] = model;
                Response.Redirect("Add.aspx");
            }
            else
            {
                Session["newsclass"] = null;
                Response.Redirect("index.aspx");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtClassDesc.Text = "";
            this.txtClassPicture.Text = "";


        }
    }
}
