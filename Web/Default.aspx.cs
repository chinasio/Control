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
using System.Text;
namespace Maticsoft.Web
{
    public partial class Default : System.Web.UI.Page
    {
        public string strImglist="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "动软中国-Maticsoft";
                ShowProImg();
                ShowNews();
            }
        }
        /// <summary>
        /// 显示产品图片
        /// </summary>
        private void ShowProImg()
        {
            Maticsoft.BLL.Products.Product bll = new Maticsoft.BLL.Products.Product();
            DataSet ds = bll.GetListByCategoryID(15,"");
            
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ds.Tables[0].DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = 4;
            objPds.CurrentPageIndex = 0;
            DataList2.DataSource = objPds;
            DataList2.DataBind();
            StringBuilder strImg = new StringBuilder();
            if (ds.Tables.Count > 0)
            {
                int rowcout=ds.Tables[0].Rows.Count;
                if (rowcout > 0)
                {
                    for (int n = 0; n < rowcout; n++)
                    {
                        string Name=ds.Tables[0].Rows[n]["Name"].ToString();
                        string Image = ds.Tables[0].Rows[n]["Image"].ToString();
                        strImg.Append("<IMG height=130 alt=\"" + Name + "\" src=\"ProductImages/" + Image + "\" width=150 border=0 /> ");
                    }
                }
            }
            strImglist = strImg.ToString();
        }
        /// <summary>
        /// 显示新闻
        /// </summary>
        private void ShowNews()
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            this.DataList1.DataSource = bll.GetTopScroll(4);//
            this.DataList1.DataBind();

        }
        protected string FormatString(string str)
        {
            if (str.Length > 16)
            {
                str = str.Substring(0, 15) + "...";
            }
            return str;
        }

    }
}
