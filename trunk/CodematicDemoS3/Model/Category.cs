using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// 产品类别
    /// </summary>
    public class Category
    {


        #region Model
        private string _categoryid;
        private string _name;
        private string _descn;
        
        /// <summary>
        /// 
        /// </summary>
        public string CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descn
        {
            set { _descn = value; }
            get { return _descn; }
        }

       
        #endregion Model
    }
}
