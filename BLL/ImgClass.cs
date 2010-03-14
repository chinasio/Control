using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Maticsoft.BLL
{
    public class ImgClass
    {
        private static readonly Maticsoft.DAL.ImgClass dal = new Maticsoft.DAL.ImgClass();



        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string Name)
        {
            return dal.Exists(Name);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(string Name)
        {
            dal.Add(Name);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(int ImgClassID, string Name)
        {
            dal.Update(ImgClassID, Name);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public string GetName(int ID)
        {
            return dal.GetName(ID);
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
