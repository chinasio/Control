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

namespace Maticsoft.Web
{
    /// <summary>
    /// ��˾����
    /// </summary>
    public partial class GSXW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Page.Title = "����";

                if ((Request.Params["cid"] != null) && (Request.Params["cid"].ToString() != ""))
                {
                    ViewState["cid"] = Request.Params["cid"];

                }
                ShowNews();
            }
        }

        private void ShowNews()//��ʾ����
        {
            int cid = -1;
            if ((ViewState["cid"] != null) && (ViewState["cid"].ToString() != ""))
            {
                cid = int.Parse(ViewState["cid"].ToString());

            }

            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            DataSet ds = bll.GetNewsList(-1, cid, false);//
            gridView.DataSource = ds;
            gridView.DataBind();

            //��ҳ
            int rows_Count = ds.Tables[0].Rows.Count;
            int page_Size = gridView.PageSize;
            int page_Count = gridView.PageCount;
            int page_Current = gridView.PageIndex + 1;

            lblRowsCount.Text = rows_Count.ToString();
            lblPageCount.Text = page_Count.ToString();
            lblCurrentPage.Text = page_Current.ToString();


            #region ��ʾҳ����

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
        protected string FormatString(string str)
        {
            if (str.Length > 26)
            {
                str = str.Substring(0, 25) + "...";
            }
            return str;
        }

        #region ҳ�����¼�
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
            ShowNews();
        }
        #endregion

        #region gridView�¼�
        protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //ҳ����
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string title = Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString();
            //    //string bgcolor = Application[Session["Style"].ToString() + "xtable_bgcolor"].ToString();
            //    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='" + title + "';this.style.cursor='hand';");
            //    //���������ʱ��ԭ���еı���ɫ
            //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            //}

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            ShowNews();
        }


        #endregion
    }
}
