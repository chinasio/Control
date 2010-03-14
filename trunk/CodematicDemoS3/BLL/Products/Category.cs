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

        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
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
        /// ����һ������
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
        /// ����һ������
        /// </summary>
        public void Update(Maticsoft.Model.Category model)
        {
            dal.Update(model);
        }
        
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string CategoryId)
        {
            if (CategoryId != "")
            {
                dal.Delete(CategoryId);
            }
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�޻���
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
        /// �õ�һ������ʵ��,�ӻ�����
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
       

    
        #endregion  ��Ա����
    }
}
