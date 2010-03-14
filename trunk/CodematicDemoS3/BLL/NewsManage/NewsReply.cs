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
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsReply model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsReply GetModel(int Id)
        {
            return dal.GetModel(Id);
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

        public DataSet GetList(int top, int Newsid)
        {
            return dal.GetList(top,Newsid);
        }

        public int GetReplyCount(int Newsid)
        {
            return dal.GetReplyCount(Newsid);
        }

        #endregion  成员方法
    }
}
