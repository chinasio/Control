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
using System.Drawing;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.Admin.PBrand
{
    public partial class Index : System.Web.UI.Page
    {
        //int PermId_Modify = 16;//广告主信息修改
        //int PermId_Delete = 17;//广告主删除
        Maticsoft.BLL.Products.Category bllc = new Maticsoft.BLL.Products.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());

                BindData();
            }
        }

        #region BindData
        private void BindData()
        {
            #region 权限检查
            //if (!Context.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}
            //AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //if (user.HasPermissionID(PermId_Modify))
            //{
            //    gridView.Columns[7].Visible = true;
            //}
            //if (user.HasPermissionID(PermId_Delete))
            //{
            //    gridView.Columns[8].Visible = true;
            //}
            #endregion


            Maticsoft.BLL.Products.Brand bll = new Maticsoft.BLL.Products.Brand();
            string strWhere = "";
            if (Session["strWhereBrand"] != null && Session["strWhereBrand"].ToString() != "")
            {
                strWhere += Session["strWhereBrand"].ToString();
            }
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataView dv = ds.Tables[0].DefaultView;
            gridView.DataSource = dv;
            gridView.DataBind();

            //分页
            int rows_Count = ds.Tables[0].Rows.Count;
            int page_Size = gridView.PageSize;
            int page_Count = gridView.PageCount;
            int page_Current = gridView.PageIndex + 1;

            lblRowsCount.Text = rows_Count.ToString();
            lblPageCount.Text = page_Count.ToString();
            lblCurrentPage.Text = page_Current.ToString();


            #region 显示页导航

            btnFirst.Enabled = true;
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            if (gridView.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (gridView.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (gridView.PageIndex == gridView.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }

            #endregion

        }
        #endregion

        #region 页导航事件
        public void NavigateToPage(object sender, CommandEventArgs e)
        {
            btnFirst.Enabled = true;
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            string pageinfo = e.CommandArgument.ToString();
            switch (pageinfo)
            {
                case "Prev":
                    if (gridView.PageIndex > 0)
                    {
                        gridView.PageIndex -= 1;

                    }
                    break;
                case "Next":
                    if (gridView.PageIndex < (gridView.PageCount - 1))
                    {
                        gridView.PageIndex += 1;

                    }
                    break;
                case "First":
                    gridView.PageIndex = 0;
                    break;
                case "Last":
                    gridView.PageIndex = gridView.PageCount - 1;
                    break;
            }
            if (gridView.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (gridView.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (gridView.PageIndex == gridView.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            BindData();
        }
        #endregion

        #region btn_Search
        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            string SupplierName = this.txtKey.Text.Trim();
            string field = this.DropField.SelectedValue;
            string strsql = "";
            if (SupplierName != "")
            {
                strsql += " and (" + field + " like'%" + SupplierName + "%')";
            }
            if (strsql != "")
            {
                Session["strWhereBrand"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereBrand"] = "";
            }
            BindData();
        }
        #endregion

        #region gridView事件
        protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //页导航
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                TableRow row = e.Row.Controls[0].Controls[0].Controls[0] as TableRow;
                foreach (TableCell cell in row.Cells)
                {
                    Control lb = cell.Controls[0];
                    if (lb is Label)
                    {
                        Label lblpage = (Label)lb;
                        lblpage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e78a29");
                        lblpage.Font.Bold = true;
                        lblpage.Text = "[" + lblpage.Text + "]";
                        //((Label)lb).Font.Size = new FontUnit("40px");
                    }
                    else
                        if (lb is LinkButton)
                        {
                            LinkButton lblpage = (LinkButton)lb;
                            lblpage.Font.Bold = true;
                            lblpage.Text = "[" + lblpage.Text + "]";
                        }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string title = Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString();
                //string bgcolor = Application[Session["Style"].ToString() + "xtable_bgcolor"].ToString();
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='" + title + "';this.style.cursor='hand';");
                //当鼠标移走时还原该行的背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CategoryId = DataBinder.Eval(e.Row.DataItem, "CategoryId").ToString();
                if (CategoryId != "")
                {
                    string name = bllc.GetName(CategoryId);
                    e.Row.Cells[3].Text = name;
                }
                else
                {
                    e.Row.Cells[3].Text = "未知";
                }     
            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (gridView.Rows.Count <= 1)
            //{
            //    e.Cancel = true;
            //}
            int SupplierID = (int)gridView.DataKeys[e.RowIndex].Value;
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {

            Maticsoft.BLL.Products.Brand bll = new Maticsoft.BLL.Products.Brand();
            string strWhere = "";
            if (Session["strWhereBrand"] != null && Session["strWhereBrand"].ToString() != "")
            {
                strWhere += Session["strWhereBrand"].ToString();
            }
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataView dv = ds.Tables[0].DefaultView;
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = "desc";
            }
            else
            {
                if (ViewState["SortDirection"].ToString() == "asc")
                {
                    ViewState["SortDirection"] = "desc";
                }
                else
                {
                    ViewState["SortDirection"] = "asc";
                }
            }
            dv.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();
            gridView.DataSource = dv;
            gridView.DataBind();


        }
        #endregion
    }
}
