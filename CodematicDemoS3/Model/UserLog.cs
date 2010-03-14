using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// �û���־
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
        /// ʱ��
        /// </summary>
        public DateTime OPTime
        {
            set { _OPTime = value; }
            get { return _OPTime; }
        }
        /// <summary>
        /// ҳ��
        /// </summary>
        public string Url
        {
            set { _Url = value; }
            get { return _Url; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string OPInfo
        {
            set { _OPInfo = value; }
            get { return _OPInfo; }
        }
        /// <summary>
        /// �û�
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        /// <summary>
        /// �û�IP
        /// </summary>
        public string UserType
        {
            set { _UserType = value; }
            get { return _UserType; }
        }
        /// <summary>
        /// �û�IP
        /// </summary>
        public string UserIP
        {
            set { _UserIP = value; }
            get { return _UserIP; }
        }
        #endregion
    }
}
