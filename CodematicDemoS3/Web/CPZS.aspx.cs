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
    public partial class CPZS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "产品展示";
                string CategoryId = "";
                string BrandId = "";
                string page = "";
                if ((Request.Params["Page"] != null) && (Request.Params["Page"].ToString() != ""))
                {
                    page = Request.Params["Page"];
                }
                if ((Request.Params["CategoryId"] != null) && (Request.Params["CategoryId"].ToString() != ""))
                {
                    CategoryId = Request.Params["CategoryId"];

                }
                if ((Request.Params["BrandId"] != null) && (Request.Params["BrandId"].ToString() != ""))
                {
                    BrandId = Request.Params["BrandId"];
                }
                try
                {                    
                    BindData(BrandId, CategoryId, page);
                }
                catch (System.Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
        }


        //所有商品
        public void BindData(string BrandId, string CategoryId, string Page)
        {
            Maticsoft.BLL.Products.Product bllp = new Maticsoft.BLL.Products.Product();
            DataSet ds = new DataSet();
            if ((CategoryId != "") || (BrandId!=""))
            {
                ds = bllp.GetListByCategoryID(9,CategoryId, BrandId);
            }
            else
            {
                ds = bllp.GetAllList();
            }
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ds.Tables[0].DefaultView;
            int record_Count = ds.Tables[0].Rows.Count;
            int page_Size = 9;
            int totalPages = int.Parse(Math.Ceiling((double)record_Count / page_Size).ToString());

            int CurPage;
            if (Page != "")
                CurPage = Convert.ToInt32(Page);
            else
                CurPage = 1;

            objPds.AllowPaging = true;
            objPds.PageSize = page_Size;
            objPds.CurrentPageIndex = CurPage - 1;

            if (!objPds.IsFirstPage)
            {
                this.lnkFirst.NavigateUrl = Request.CurrentExecutionFilePath + "?BrandId=" + BrandId + "&Page=1";
                lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?BrandId=" + BrandId + "&Page=" + Convert.ToString(CurPage - 1);
            }
            if (!objPds.IsLastPage)
            {
                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?BrandId=" + BrandId + "&Page=" + Convert.ToString(CurPage + 1);
                this.lnkLast.NavigateUrl = Request.CurrentExecutionFilePath + "?BrandId=" + BrandId + "&Page=" + totalPages.ToString();
            }
            MyList.DataSource = objPds;
            MyList.DataBind();

            //显示数量
            if (objPds.CurrentPageIndex == 0)
            {
                lnkFirst.Enabled = false;
                lnkPrev.Enabled = false;
                if (totalPages == 1)
                {
                    lnkLast.Enabled = false;
                    lnkNext.Enabled = false;
                }
            }
            else if (objPds.CurrentPageIndex == totalPages - 1)
            {
                lnkLast.Enabled = false;
                lnkNext.Enabled = false;
            }
            this.lblpagesum.Text = totalPages.ToString();
            this.lblCurrentPage.Text = CurPage.ToString();
            this.lblrowscount.Text = record_Count.ToString();


        }



    }
}
