using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Maticsoft.BLL
{
    public class UserLog
    {
        private readonly Maticsoft.DAL.UserLog dal = new Maticsoft.DAL.UserLog();
        public UserLog()
        {
        }

        #region 添加日志
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model"></param>
        public void LogUserAdd(Maticsoft.Model.UserLog model)
        {
            dal.LogAdd(model);
        }
        #endregion

      
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int iID)
        {
            dal.LogDelete(iID);
        }
        /// <summary>
        ///删除某一日期之前的数据
        /// </summary>
        public void Delete(DateTime dtDateBefore)
        {
            dal.LogDelete(dtDateBefore);
        }

        public int LogCount(string strWhere)
        {
            return dal.GetRecSum("S_LogUser",strWhere);
        }
    }
}
