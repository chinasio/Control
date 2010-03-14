using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Maticsoft.BLL
{
    public class ImgClass
    {
        private static readonly Maticsoft.DAL.ImgClass dal = new Maticsoft.DAL.ImgClass();



        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Name)
        {
            return dal.Exists(Name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(string Name)
        {
            dal.Add(Name);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(int ImgClassID, string Name)
        {
            dal.Update(ImgClassID, Name);
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
        public string GetName(int ID)
        {
            return dal.GetName(ID);
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

        

        #endregion  成员方法


    }

}
