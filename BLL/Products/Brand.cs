using System;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Model;
using LTP.Common;
namespace Maticsoft.BLL.Products
{
    /// <summary>
    /// ҵ���߼���Brand ��ժҪ˵����
    /// </summary>
    public class Brand
    {
        private readonly Maticsoft.DAL.Products.Brand dal = new Maticsoft.DAL.Products.Brand();
        
        public Brand()
        { }


        #region  ��Ա����


        /// <summary>
        /// �Ƿ���ڸü�¼
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
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.Brand model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
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
        /// ɾ��һ������
        /// </summary>
        public void Delete(string BrandId)
        {
            if (BrandId != "")
            {
                dal.Delete(BrandId);
            }
        }

        /// <summary>
        /// �õ�һ������ʵ��,�ӻ�����
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
        /// �õ�һ������ʵ�壬�޻���
        /// </summary>
        public Maticsoft.Model.Brand GetModel(string BrandId)
        {
            return dal.GetModel(BrandId);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public DataSet GetlistByCategoryId(string CategoryId)
        {
            return dal.GetList("CategoryId='" + CategoryId + "'");
        }

      

        #endregion  ��Ա����
    }


}
