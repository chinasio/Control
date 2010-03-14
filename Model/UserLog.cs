using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// 用户日志
    /// </summary>
    public class UserLog
    {
        public UserLog()
        { 
        }

        #region Model
        private DateTime _OPTime;
        private string _Url;
        private string _OPInfo;
        private string _UserName;
        private string _UserIP;
        private string _UserType;
        #endregion

        #region properties
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime OPTime
        {
            set { _OPTime = value; }
            get { return _OPTime; }
        }
        /// <summary>
        /// 页面
        /// </summary>
        public string Url
        {
            set { _Url = value; }
            get { return _Url; }
        }
        /// <summary>
        /// 操作
        /// </summary>
        public string OPInfo
        {
            set { _OPInfo = value; }
            get { return _OPInfo; }
        }
        /// <summary>
        /// 用户
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserType
        {
            set { _UserType = value; }
            get { return _UserType; }
        }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP
        {
            set { _UserIP = value; }
            get { return _UserIP; }
        }
        #endregion
    }
}
