using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// 产品实体对象类
    /// </summary>
    public class Product
    {

        #region Model
        private string _productid;
        private string _brandid;
        private string _categoryid;
        private string _name;
        private string _descn;
        private string _image="";
        private string _imagesmall = "";
        private decimal _price=0;
        private decimal _vipprice = 0;
        private int _cheapness=0;

        /// <summary>
        /// 
        /// </summary>
        public string ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BrandId
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
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
        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
        public string ImageSmall
        {
            set { _imagesmall = value; }
            get { return _imagesmall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        public decimal VipPrice
        {
            set { _vipprice = value; }
            get { return _vipprice; }
        }
        public int Cheapness
        {
            set { _cheapness = value; }
            get { return _cheapness; }
        }

        #endregion Model
    }
}
