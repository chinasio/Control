using System;
namespace Maticsoft.Web
{
	/// <summary>
	/// ErrorMsg ��ժҪ˵����
	/// </summary>
	public partial class ErrorMsg : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
//				Exception ex=(Exception)Session["CurrentError"];
				lblMsg.Text="<br>����Ϣ�ѱ�ϵͳ��¼�����Ժ����Ի������Ա��ϵ��";
//				string errmsg=Session["CurrentError"].ToString();
//				try
//				{					
//					string filename=Server.MapPath("./ErrorMessage.txt");						
//					string strTime=DateTime.Now.ToString();
//					StreamWriter sw=new StreamWriter(filename,true);
//					sw.WriteLine(strTime+"��"+errmsg.ToString());
//					sw.Close();
//				}
//				catch(System.Exception exx)
//				{
//					lblMsg.Text=exx.Message+"<br><br>����Ϣ�ѱ�ϵͳ��¼�����Ժ����Ի������Ա��ϵ��";	
//				}

				Server.ClearError();
				

			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
