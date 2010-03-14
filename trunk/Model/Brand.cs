using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// Æ·ÅÆ
    /// </summary>
    public class Brand
    {

        #region Model
        
        private string _brandid;
        private string _name;
        private string _descn;
        private string _categoryid;

        /// <summary>
        /// 
        /// </summary>
        public string BrandId
        {
            set { _brandid = value; }
            get { return _brandid; }
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

        /// <summary>
        ///
        /// </summary>
        public string CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }

        #endregion Model

    }
}
