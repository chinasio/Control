using System;
namespace Maticsoft.Model.NewsManage
{
	/// <summary>
	/// �������
	/// </summary>
	public class NewsClass
	{
		private int _classid;
		private string _classdesc;		
		private string _classpicture;	
		private int _parentid;
        //private int _departmentid;


		public NewsClass()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public int ClassId
		{
			get{ return _classid; }
			set{ _classid=value; }
		}
		public string ClassDesc
		{
			get{ return _classdesc; }
			set{ _classdesc=value; }
		}
		
		public string ClassPicture
		{
			get{ return _classpicture; }
			set{ _classpicture=value; }
		}
		
		public int ParentId
		{
			get{ return _parentid; }
			set{ _parentid=value; }
		}
        //public int DepartmentID
        //{
        //    get{ return _departmentid; }
        //    set{ _departmentid=value; }
        //}
	}
}
