using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Model;
using LTP.Common;
namespace Maticsoft.BLL.Products
{
    /// <summary>
    /// 业务逻辑类Brand 的摘要说明。
    /// </summary>
    public class Brand
    {
        private readonly Maticsoft.DAL.Products.Brand dal = new Maticsoft.DAL.Products.Brand();
        
        public Brand()
        { }


        #region  成员方法


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BrandId)
        {
            if (BrandId != "")
            {
                return dal.Exists(BrandId);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.Brand model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.Brand model)
        {
            dal.Update(model);
        }

        public string GetNameNoCache(string BrandId)
        {
            if (BrandId != "")
            {
                return dal.GetName(BrandId);
            }
            else
            {
                return "";
            }
        }
        public string GetName(string BrandId)
        {
            if (BrandId != "")
            {                
                string CacheKey = "BrandName-" + BrandId;
                object objModel = DataCache.GetCache(CacheKey);
                if (objModel == null)
                {
                    try
                    {
                        objModel = dal.GetName(BrandId);
                        if (objModel != null)
                        {
                            int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                            DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                        }
                    }
                    catch
                    { }
                }
                return objModel.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string BrandId)
        {
            if (BrandId != "")
            {
                dal.Delete(BrandId);
            }
        }

        /// <summary>
        /// 得到一个对象实体,从缓存中
        /// </summary>
        public Maticsoft.Model.Brand GetModelByCache(string BrandId)
        {            
            string CacheKey = "BrandModel-" + BrandId;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(BrandId);
                    if (objModel != null)
                    {
                        int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return (Maticsoft.Model.Brand)objModel;
        }
        /// <summary>
        /// 得到一个对象实体，无缓存
        /// </summary>
        public Maticsoft.Model.Brand GetModel(string BrandId)
        {
            return dal.GetModel(BrandId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DataSet GetlistByCategoryId(string CategoryId)
        {
            return dal.GetList("CategoryId='" + CategoryId + "'");
        }

      

        #endregion  成员方法
    }


}
