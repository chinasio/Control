using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LTP.Common;
namespace Maticsoft.BLL.NewsManage
{
    
    public class NewsClass
    {

        private readonly Maticsoft.DAL.NewsManage.NewsClass dal = new Maticsoft.DAL.NewsManage.NewsClass();

        #region  成员方法
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(String ClassDesc)
        {
            return dal.Exists(ClassDesc);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ClassId)
        {
            dal.Delete(ClassId);
        }
        public void DeleteByClassId(int ClassId)
        {
            dal.DeleteByClassId(ClassId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModel(int ClassId)
        {
            return dal.GetModel(ClassId);                       
        }
        /// <summary>
        /// 得到一个对象实体,从缓存中
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModelByCache(int ClassId)
        {
            string CacheKey = "NewsClassModel-" + ClassId;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ClassId);
                    if (objModel != null)
                    {
                        int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return (Maticsoft.Model.NewsManage.NewsClass)objModel;
            
            #region 利用企业库的缓存方式

            ////创建一个缓存管理器
            //CacheManager caching = CacheFactory.GetCacheManager();
            ////取出缓存的数据
            //object objModel = caching.GetData(ClassId.ToString());
            //if (objModel == null)
            //{
            //    try
            //    {
            //        objModel = dal.GetModel(ClassId);
            //        if (objModel != null)
            //        {
            //            //添加要进行缓存的数据,
            //            //caching.Add(ClassId.ToString(), objModel);
            //            //添加要进行缓存的数据,缓存时间为10分钟                   
            //            caching.Add(ClassId.ToString(), objModel, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(10)));
            //        }
            //        //清空缓存
            //        //caching.Flush();
            //        //caching.Count;
            //        //从缓存中移出key=1的项
            //        //caching.Remove(ClassId.ToString());
            //    }
            //    catch//(System.Exception ex)
            //    {
            //        //string str=ex.Message;// 记录错误日志
            //    }
            //}
            //return (Maticsoft.Model.NewsManage.NewsClass)objModel; 

            #endregion

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据ClassId得到父类的ClassDesc
        /// </summary>
        public string GetClassDescByClassId(int ClassId)
        {
            return dal.GetClassDescByClassId(ClassId);
        }
        /// <summary>
        /// 根据ParentID得到ClassDesc
        /// </summary>
        public string GetClassDescByParentID(int parentID)
        {
            return dal.GetClassDescByParentID(parentID);
        }
        
        #endregion  成员方法
    }
}
