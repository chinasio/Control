using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LTP.Common;
namespace Maticsoft.BLL.NewsManage
{
    public class News
    {
        private readonly Maticsoft.DAL.NewsManage.News dal = new Maticsoft.DAL.NewsManage.News();
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.News model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.News model)
        {
            dal.Update(model);
        }
        public void UpdateFrequency(int newsid)
        {
            dal.UpdateFrequency(newsid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int NewsId)
        {
            dal.Delete(NewsId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.News GetModel(int NewsId)
        {
            return dal.GetModel(NewsId);
        }
        /// <summary>
        /// 得到一个对象实体,从缓存中
        /// </summary>
        public Maticsoft.Model.NewsManage.News GetModelByCache(int NewsId)
        {
            string CacheKey = "NewsModel-" + NewsId;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(NewsId);
                    if (objModel != null)
                    {
                        int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return (Maticsoft.Model.NewsManage.News)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 得到某类别的新闻
        /// </summary>
        /// <param name="top">返回行数</param>
        /// <param name="ClassId">类别</param>
        /// <param name="Dormancy">发布状态</param>       
        /// <returns></returns>
        public DataSet GetNewsList(int top, int ClassId, bool Dormancy)
        {
            return dal.GetNewsList(top,  ClassId, Dormancy);
        }

        public DataSet GetTopScroll(int top)
        {
            return dal.GetTopScroll(top);
        }


        /// <summary>
        /// 得到相关5条的新闻列表
        /// </summary>   
        public DataSet GetNewsByFocus(string Focus)
        {
            return dal.GetNewsByFocus(Focus); 
        }

        /// <summary>
        /// 得到(某类别的)点击率最高的几条热点新闻
        /// </summary>
        /// <param name="top">返回行数</param>
        /// <param name="ClassId">类别id,-1为无限制</param>	
        /// <returns></returns>
        public DataSet GetNewsTopList(int top, int ClassId)
        {
            return dal.GetNewsTopList(top, ClassId);
        }

  
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetListByPage(PageSize, PageIndex, strWhere);
        }

        #endregion  成员方法



        /// <summary>
        /// 根据广告id列表，删除广告
        /// </summary>
        /// <param name="Idlist"></param>
        public void DeleteList(string Idlist)
        {
            dal.DeleteList(Idlist);
        }
        /// <summary>
        /// 根据广告id列表，发布 广告
        /// </summary>
        /// <param name="Idlist"></param>
        public void ReleaseList(string Idlist)
        {
            dal.ReleaseList(Idlist);
        }
        public void NoReleaseList(string Idlist)
        {
            dal.NoReleaseList(Idlist);
        }

    }
}
