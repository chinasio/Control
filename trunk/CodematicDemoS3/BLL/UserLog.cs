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

        #region �����־
        /// <summary>
        /// �����־
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int iID)
        {
            dal.LogDelete(iID);
        }
        /// <summary>
        ///ɾ��ĳһ����֮ǰ������
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
