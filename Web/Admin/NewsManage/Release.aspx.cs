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
    public partial class Release : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grid.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                grid.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                Confirm.Attributes.Add("onclick", "return confirm('删除该广告将随同删除相应的显示记录和网址关联信息！\\n你是否确定删除这些记录？');");
                int pageIndex = 1;
                if (Request.Params["page"] != null && Request.Params["page"].ToString() != "")
                {
                    Session["pageNewsr"] = Convert.ToInt32(Request.Params["page"]);
                    pageIndex = Convert.ToInt32(Request.Params["page"]);
                }
                else
                {
                    if (Session["pageNewsr"] != null && Session["pageNewsr"].ToString() != "")
                    {
                        pageIndex = Convert.ToInt32(Session["pageNewsr"]);
                    }
                    else
                    {
                        pageIndex = 1;
                        Session["pageNewsr"] = 1;
                    }
                }

                dataBind(pageIndex);
            }
        }
        private void dataBind(int pageIndex)
        {
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (!user.HasPermissionID(PermId_Add))
            //{
            //    this.Page011.Page_Add = "";
            //}
            //if (!user.HasPermissionID(PermId_Search))
            //{
            //    this.Page011.Page_Search = "";
            //}
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    grid.Columns[6].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    grid.Columns[7].Visible = true;
            //}

            pageIndex--;
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            string strWhere = "";
            if (Session["strWhereNewsRelea"] != null && Session["strWhereNewsRelea"].ToString() != "")
            {
                strWhere = Session["strWhereNewsRelea"].ToString();
            }
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            grid.DataSource = ds.Tables[0].DefaultView;
            int record_Count = ds.Tables[0].Rows.Count;
            int page_Size = grid.PageSize;
            int totalPages = int.Parse(Math.Ceiling((double)record_Count / page_Size).ToString());
            if (totalPages > 0)
            {
                if ((pageIndex + 1) > totalPages)
                    pageIndex = totalPages - 1;
            }
            else
            {
                pageIndex = 0;
            }
            grid.CurrentPageIndex = pageIndex;
            grid.DataBind();
            int page_Count = grid.PageCount;
            int page_Current = pageIndex + 1;

            Page011.Record_Count = record_Count;
            Page011.Page_Count = page_Count;
            Page021.Page_Count = page_Count;

            Page011.Page_Size = page_Size;
            Page021.Page_Size = page_Size;
            Page011.Page_Current = page_Current;
            Page021.Page_Current = page_Current;
        }
        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            string strsql = "";
            string adname = this.txtKey.Text.Trim();
            string field = this.DropField.SelectedValue;
            if (adname != "")
            {
                strsql += " and (" + field + " like'%" + adname + "%')";
            }
            if (strsql != "")
            {
                Session["strWhereNewsRelea"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereNewsRelea"] = "";
            }
            Response.Redirect("release.aspx?page=1");
        }
        protected void btn_Relese_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            string idlist = GetSelIDlist();
            bll.ReleaseList(idlist);
            Response.Redirect("Release.aspx");

        }
        protected void btn_NoRelease_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            string idlist = GetSelIDlist();
            bll.NoReleaseList(idlist);
            Response.Redirect("Release.aspx");

        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            string idlist = GetSelIDlist();
            bll.DeleteList(idlist);
            Response.Redirect("Release.aspx");
        }
        private string GetSelIDlist()
        {
            string dgIDs = "";
            bool BxsChkd = false;
            foreach (DataGridItem item in grid.Items)
            {
                CheckBox deleteChkBxItem = (CheckBox)item.FindControl("SelectThis");
                if (deleteChkBxItem.Checked)
                {
                    BxsChkd = true;
                    dgIDs += item.Cells[1].Text + ",";
                }
            }
            if (BxsChkd)
            {
                dgIDs = dgIDs.Substring(0, dgIDs.LastIndexOf(","));
            }
            return dgIDs;
        }
        protected void grid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string Dormancy = (string)DataBinder.Eval(e.Item.DataItem, "Dormancy");
                int ClassId = (int)DataBinder.Eval(e.Item.DataItem, "ClassId");
                if (Dormancy.ToLower() == "true")
                {
                    e.Item.Cells[4].Text = "<span style=\" color:Red\">休眠</span>";
                }
                else
                {
                    e.Item.Cells[4].Text = "<span style=\" color:Green\">发布</span>";
                }
               
                Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
                Maticsoft.Model.NewsManage.NewsClass mod = bll.GetModelByCache(ClassId);
                if (mod != null)
                {
                    e.Item.Cells[5].Text = mod.ClassDesc;
                }
                else
                {
                    e.Item.Cells[5].Text = "未知类别";
                }
            }
        }
    }
}
