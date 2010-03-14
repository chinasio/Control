using System;
namespace Maticsoft.Web
{
	/// <summary>
	/// ErrorMsg 的摘要说明。
	/// </summary>
	public partial class ErrorMsg : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
//				Exception ex=(Exception)Session["CurrentError"];
				lblMsg.Text="<br>该信息已被系统记录，请稍后重试或与管理员联系。";
//				string errmsg=Session["CurrentError"].ToString();
//				try
//				{					
//					string filename=Server.MapPath("./ErrorMessage.txt");						
//					string strTime=DateTime.Now.ToString();
//					StreamWriter sw=new StreamWriter(filename,true);
//					sw.WriteLine(strTime+"："+errmsg.ToString());
//					sw.Close();
//				}
//				catch(System.Exception exx)
//				{
//					lblMsg.Text=exx.Message+"<br><br>该信息已被系统记录，请稍后重试或与管理员联系。";	
//				}

				Server.ClearError();
				

			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
