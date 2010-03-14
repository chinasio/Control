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
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BiudTree();

                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string id = Request.Params["id"];
                    ShowInfo(int.Parse(id));
                }
                else
                {
                    Response.Redirect("index.aspx");
                    Response.End();                    
                }
            }
        }

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
            //¼ÓÔØÊ÷
            this.dropParent.Items.Add(new ListItem("¶¥¼¶Ä¿Â¼", "0"));
            DataRow[] drs = dt.Select("ParentId= 0");


            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                string parentid = r["ParentId"].ToString();
                //				string permissionid=r["PermissionID"].ToString();
                text = "©ï" + text;
                this.dropParent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "©À";

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
                text = blank + "¡º" + text + "¡»";

                this.dropParent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "©¤";

                BindNode(sonparentid, dt, blank2);
            }
        }

        #endregion

        private void ShowInfo(int id)
        {
            Navigation011.Para_Str = "id=" + id;
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            Maticsoft.Model.NewsManage.NewsClass model = bll.GetModel(id);
            this.lblClassId.Text = model.ClassId.ToString();
            txtClassDesc.Text = model.ClassDesc;
            txtClassPicture.Text = model.ClassPicture;


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int classid = int.Parse(lblClassId.Text);
            string ClassDesc = this.txtClassDesc.Text;
            string ClassPicture = this.txtClassPicture.Text;
            int ParentId = 0;
            if (this.dropParent.SelectedIndex > 0)
            {
                ParentId = int.Parse(this.dropParent.SelectedValue);
            }

            Maticsoft.Model.NewsManage.NewsClass model = new Maticsoft.Model.NewsManage.NewsClass();
            model.ClassId = classid;
            model.ClassDesc = ClassDesc;
            model.ClassPicture = ClassPicture;
            model.ParentId = ParentId;
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            bll.Update(model);
            Response.Redirect("show.aspx?id=" + classid);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }

}

