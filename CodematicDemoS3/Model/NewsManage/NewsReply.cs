using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model.NewsManage
{
    /// <summary>
    /// ÐÂÎÅ»Ø¸´
    /// </summary>
    public class NewsReply
    {
        public NewsReply()
        { }
        #region Model
        private int _id;
        private int _newsid;
        private string _content;
        private DateTime _issuedate;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime IssueDate
        {
            set { _issuedate = value; }
            get { return _issuedate; }
        }
        #endregion Model

    }
}
