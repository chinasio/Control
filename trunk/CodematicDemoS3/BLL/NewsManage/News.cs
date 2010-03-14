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
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.News model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
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
        /// ɾ��һ������
        /// </summary>
        public void Delete(int NewsId)
        {
            dal.Delete(NewsId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Maticsoft.Model.NewsManage.News GetModel(int NewsId)
        {
            return dal.GetModel(NewsId);
        }
        /// <summary>
        /// �õ�һ������ʵ��,�ӻ�����
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// �õ�ĳ��������
        /// </summary>
        /// <param name="top">��������</param>
        /// <param name="ClassId">���</param>
        /// <param name="Dormancy">����״̬</param>       
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
        /// �õ����5���������б�
        /// </summary>   
        public DataSet GetNewsByFocus(string Focus)
        {
            return dal.GetNewsByFocus(Focus); 
        }

        /// <summary>
        /// �õ�(ĳ����)�������ߵļ����ȵ�����
        /// </summary>
        /// <param name="top">��������</param>
        /// <param name="ClassId">���id,-1Ϊ������</param>	
        /// <returns></returns>
        public DataSet GetNewsTopList(int top, int ClassId)
        {
            return dal.GetNewsTopList(top, ClassId);
        }

  
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetListByPage(PageSize, PageIndex, strWhere);
        }

        #endregion  ��Ա����



        /// <summary>
        /// ���ݹ��id�б�ɾ�����
        /// </summary>
        /// <param name="Idlist"></param>
        public void DeleteList(string Idlist)
        {
            dal.DeleteList(Idlist);
        }
        /// <summary>
        /// ���ݹ��id�б����� ���
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
