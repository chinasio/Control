using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// ͼƬ
    /// </summary>
    public class Images
    {

        #region Model
        private int _id;
        private int _imgclassid;
        private string _imagename;
        private string _linkurl;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ImgClassID
        {
            set { _imgclassid = value; }
            get { return _imgclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImageName
        {
            set { _imagename = value; }
            get { return _imagename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        #endregion Model
    }
}
