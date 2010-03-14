using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Maticsoft.BLL
{
    public class Images
    {
        private static readonly Maticsoft.DAL.Images dal = new Maticsoft.DAL.Images();

        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.Images model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.Images model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Images GetModel(int ID)
        {
            return dal.GetModel(ID);
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
        public DataSet GetList(int ImgClassID)
        {
            return dal.GetList(" ImgClassID=" + ImgClassID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

        #endregion  成员方法

    }
}
