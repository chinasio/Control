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

        #region  ��Ա����
        
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(String ClassDesc)
        {
            return dal.Exists(ClassDesc);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
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
        /// �õ�һ������ʵ��
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModel(int ClassId)
        {
            return dal.GetModel(ClassId);                       
        }
        /// <summary>
        /// �õ�һ������ʵ��,�ӻ�����
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
            
            #region ������ҵ��Ļ��淽ʽ

            ////����һ�����������
            //CacheManager caching = CacheFactory.GetCacheManager();
            ////ȡ�����������
            //object objModel = caching.GetData(ClassId.ToString());
            //if (objModel == null)
            //{
            //    try
            //    {
            //        objModel = dal.GetModel(ClassId);
            //        if (objModel != null)
            //        {
            //            //���Ҫ���л��������,
            //            //caching.Add(ClassId.ToString(), objModel);
            //            //���Ҫ���л��������,����ʱ��Ϊ10����                   
            //            caching.Add(ClassId.ToString(), objModel, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(10)));
            //        }
            //        //��ջ���
            //        //caching.Flush();
            //        //caching.Count;
            //        //�ӻ������Ƴ�key=1����
            //        //caching.Remove(ClassId.ToString());
            //    }
            //    catch//(System.Exception ex)
            //    {
            //        //string str=ex.Message;// ��¼������־
            //    }
            //}
            //return (Maticsoft.Model.NewsManage.NewsClass)objModel; 

            #endregion

        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ����ClassId�õ������ClassDesc
        /// </summary>
        public string GetClassDescByClassId(int ClassId)
        {
            return dal.GetClassDescByClassId(ClassId);
        }
        /// <summary>
        /// ����ParentID�õ�ClassDesc
        /// </summary>
        public string GetClassDescByParentID(int parentID)
        {
            return dal.GetClassDescByParentID(parentID);
        }
        
        #endregion  ��Ա����
    }
}
