using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Maticsoft.BLL.NewsManage
{
    public class NewsReply
    {
        private readonly Maticsoft.DAL.NewsManage.NewsReply dal = new Maticsoft.DAL.NewsManage.NewsReply();
        public NewsReply()
        { }
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsReply model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int Id)
        {
            dal.Delete(Id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsReply GetModel(int Id)
        {
            return dal.GetModel(Id);
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

        public DataSet GetList(int top, int Newsid)
        {
            return dal.GetList(top,Newsid);
        }

        public int GetReplyCount(int Newsid)
        {
            return dal.GetReplyCount(Newsid);
        }

        #endregion  ��Ա����
    }
}
