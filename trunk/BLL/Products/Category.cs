using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.Model;
using LTP.Common;
namespace Maticsoft.BLL.Products
{
    public class Category
    {
        private readonly Maticsoft.DAL.Products.Category dal = new Maticsoft.DAL.Products.Category();
        public Category()
        { }

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CategoryId)
        {
            if (CategoryId != "")
            {
                return dal.Exists(CategoryId);
            }
            else
            {
                return true;
            }
        }
        public bool ExistsPro(string CategoryId)
        {
            if (CategoryId != "")
            {
                return dal.Exists(CategoryId);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.Category model)
        {
            dal.Add(model);
        }
        public string GetNameNoCache(string CategoryId)
        {
            if (CategoryId != "")
            {
                return dal.GetName(CategoryId);
            }
            else
            {
                return "";
            }
        }
        public string GetName(string CategoryId)
        {
            if (CategoryId != "")
            {
                string CacheKey = "CategoryName-" + CategoryId;
                object objModel = DataCache.GetCache(CacheKey);
                if (objModel == null)
                {
                    try
                    {
                        objModel = dal.GetName(CategoryId);
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
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.Category model)
        {
            dal.Update(model);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string CategoryId)
        {
            if (CategoryId != "")
            {
                dal.Delete(CategoryId);
            }
        }

        /// <summary>
        /// 得到一个对象实体，无缓存
        /// </summary>
        public Maticsoft.Model.Category GetModel(string CategoryId)
        {
            if (CategoryId != "")
            {
                return dal.GetModel(CategoryId);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体,从缓存中
        /// </summary>
        public Maticsoft.Model.Category GetModelByCache(string CategoryId)
        {
            string CacheKey = "CategoryModel-" + CategoryId;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CategoryId);
                    if (objModel != null)
                    {
                        int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return (Maticsoft.Model.Category)objModel;
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
       

    
        #endregion  成员方法
    }
}
