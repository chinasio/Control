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
using Microsoft.Web.UI.WebControls;
namespace Maticsoft.Web.Admin.PCategory
{
    public partial class IndexTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                BindTreeView();
                if (this.TreeView1.Nodes.Count == 0)
                {
                    lblTip.Visible = true;                    
                }
            }
        }


        //邦定根节点
        public void BindTreeView()
        {
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            DataTable dt = bll.GetAllList().Tables[0];
            DataRow[] drs = dt.Select("ParentID= " + 0);//　选出所有子节点	

            //菜单状态           
            bool menuExpand = true;

            TreeView1.Nodes.Clear(); // 清空树
            foreach (DataRow r in drs)
            {
                string ClassID = r["CategoryId"].ToString();
                string ClassDesc = "<b>" + r["Name"].ToString() + "</b>";
                string ParentId = r["ParentId"].ToString();
                //string Orders = r["Orders"].ToString();
                //string IsShow = r["IsShow"].ToString();

                //if (IsShow == "false")
                //{
                //    ClassDesc = "";
                //}

                //treeview set
                this.TreeView1.Font.Name = "宋体";
                this.TreeView1.Font.Size = FontUnit.Parse("9");

                Microsoft.Web.UI.WebControls.TreeNode rootnode = new Microsoft.Web.UI.WebControls.TreeNode();
                rootnode.Text = ClassDesc;
                rootnode.NodeData = ClassID;
                //rootnode.NavigateUrl = url;
                //rootnode.Target = framename;
                rootnode.Expanded = menuExpand;
                //rootnode.ImageUrl = imageurl;

                TreeView1.Nodes.Add(rootnode);

                int sonparentid = int.Parse(ClassID);// or =location
                CreateNode(sonparentid, rootnode, dt);
                
            }

        }

        //邦定任意节点
        public void CreateNode(int parentid, Microsoft.Web.UI.WebControls.TreeNode parentnode, DataTable dt)
        {
            
            DataRow[] drs = dt.Select("ParentID= " + parentid);//选出所有子节点			
            foreach (DataRow r in drs)
            {
                string ClassID = r["CategoryId"].ToString();
                string ClassDesc = r["Name"].ToString();
                string ParentId = r["ParentId"].ToString();
                //string Orders = r["Orders"].ToString();
                //string IsShow = r["IsShow"].ToString();


                    Microsoft.Web.UI.WebControls.TreeNode node = new Microsoft.Web.UI.WebControls.TreeNode();
                    node.Text = ClassDesc;
                    node.NodeData = ClassID;
                    //node.NavigateUrl = url;
                    //node.Target = TargetFrame;
                    //node.ImageUrl = imageurl;
                    node.Expanded=true;
                    int sonparentid = int.Parse(ClassID);// or =location

                    if (parentnode == null)
                    {
                        TreeView1.Nodes.Clear();
                        parentnode = new Microsoft.Web.UI.WebControls.TreeNode();
                        TreeView1.Nodes.Add(parentnode);
                    }
                    parentnode.Nodes.Add(node);
                    CreateNode( sonparentid, node, dt);
               

            }//endforeach		

        }		
		
    }
}
