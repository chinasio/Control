using System;
using System.Collections.Generic;
namespace Maticsoft.Model.NewsManage
{
    /// <summary>
    /// 新闻类
    /// </summary>
	[Serializable]
	public class News
	{
		private int _newsid;
		private int _userid;
		private string _heading;
		private string _content;
		private int _frequency;
		private DateTime _issueDate;
        private string _dormancy;
		private int _classid;
		private string _focus;
		private int _priority;
        private int _istop=1;
        private List<NewsReply> _newsreplys;

		public News()
		{			
		}

		public int NewsId
		{
			get{ return _newsid; }
			set{ _newsid=value; }
		}
        /// <summary>
        /// 是否是页眉滚动新闻
        /// </summary>
        public int IsTop
        {
            get { return _istop; }
            set { _istop = value; }
        }
		public int UserId
		{
			get{ return _userid; }
			set{ _userid=value; }
		}
		public string Heading
		{
			get{ return _heading; }
			set{ _heading=value; }
		}
		public string Content
		{
			get{ return _content; }
			set{ _content=value; }
		}
		public int Frequency
		{
			get{ return _frequency; }
			set{ _frequency=value; }
		}
		public DateTime IssueDate
		{
			get{ return _issueDate; }
			set{ _issueDate=value; }
		}
		public string Dormancy
		{
			get{ return _dormancy; }
			set{ _dormancy=value; }
		}
		public int ClassId
		{
			get{ return _classid; }
			set{ _classid=value; }
		}
		public string Focus
		{
			get{ return _focus; }
			set{ _focus=value; }
		}
		public int Priority
		{
			get{ return _priority; }
			set{ _priority=value; }
		}

        public List<NewsReply> NewsReplys
        {
            get { return _newsreplys; }
            set { _newsreplys = value; }
        }
	

	}
}
