using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Model;
using LTP.Common;
namespace Maticsoft.BLL.Products
{
    public class Product
    {
        private readonly Maticsoft.DAL.Products.Product dal = new Maticsoft.DAL.Products.Product();
        public Product()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProductId)
        {
            return dal.Exists(ProductId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.Product model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.Product model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ProductId)
        {
            dal.Delete(ProductId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Product GetModel(string ProductId)
        {
            return dal.GetModel(ProductId);
        }
        /// <summary>
        /// 得到一个对象实体,从缓存中
        /// </summary>
        public Maticsoft.Model.Product GetModelByCache(string ProductId)
        {
            string CacheKey = "ProductModel-" + ProductId;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ProductId);
                    if (objModel != null)
                    {
                        int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return (Maticsoft.Model.Product)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetList(int top)
        {
            return dal.GetList(top, "Image <> ''", " ID desc");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DataSet GetListByCategoryID(string CategoryID)
        {
            string strWhere = "(1=1) ";
            if (CategoryID != "")
            {
                strWhere += " and CategoryId='" + CategoryID + "' ";
            }          
            return dal.GetList(strWhere);
        }

        public DataSet GetListByCategoryID(int top,string CategoryID)
        {
            string strWhere = "(1=1) ";
            if (CategoryID != "")
            {
                strWhere += " and CategoryId='" + CategoryID + "' ";
            }
            return dal.GetList(top, strWhere, " ID desc");
        }

        public DataSet GetListByCategoryID(int top,string CategoryID, string BrandId)
        {
            string strWhere = "(1=1) ";
            if (CategoryID != "")
            {
                strWhere += " and CategoryId='" + CategoryID + "' ";
            }
            if (BrandId != "")
            {
                strWhere += " and BrandId='" + BrandId + "' ";
            }
            return dal.GetList(top, strWhere, " ID desc");
        }




        public DataSet GetListCheapness(string BrandId, string CategoryID, int top)
        {
            return dal.GetListCheapness(BrandId, CategoryID, top);
        }
        public DataSet GetListNoCheapness(string BrandId, string CategoryID, int top)
        {
            return dal.GetListNoCheapness(BrandId, CategoryID,top);
        }

        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

        public DataSet GetListByCategoryID(int PageSize, int PageIndex, string CategoryID)
        {
            string strWhere="";
            if (CategoryID != "")
            {
                strWhere += " CategoryId='" + CategoryID + "' ";
            }
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

        #endregion  成员方法
    }
}
