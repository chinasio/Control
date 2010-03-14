using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL
{
    public class UserLog
    {
        public UserLog()
        {
        }

        #region 日志
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="model"></param>
        public void LogAdd(Maticsoft.Model.UserLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_LogUser(");
            strSql.Append("OPTime,Url,OPInfo,UserName,UserType,UserIP)");
            strSql.Append(" values (");
            strSql.Append("@OPTime,@Url,@OPInfo,@UserName,@UserType,@UserIP)");
            SqlParameter[] parameters = {
					new SqlParameter("@OPTime", SqlDbType.DateTime),
					new SqlParameter("@Url", SqlDbType.NVarChar),
					new SqlParameter("@OPInfo", SqlDbType.NVarChar),
                    new SqlParameter("@UserName", SqlDbType.NVarChar),
                    new SqlParameter("@UserType", SqlDbType.NVarChar),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar)};
            parameters[0].Value = DateTime.Now;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.OPInfo;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserType;
            parameters[5].Value = model.UserIP;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[OPTime],[url],[OPInfo],[UserName],[UserType],[UserIp] ");
            strSql.Append(" FROM S_LogUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " Order By [OPTime] Desc ");
            }
            else
            {
                strSql.Append(" Order By [OPTime] Desc ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void LogDelete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_LogUser ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = iID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除某一日期之前的数据
        /// </summary>
        /// <param name="dtDateBefore"></param>
        public void LogDelete(DateTime dtDateBefore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_LogUser ");
            strSql.Append(" where OPTime <= @OPTime");
            SqlParameter[] parameters = {
					new SqlParameter("@OPTime", SqlDbType.DateTime)
				};
            parameters[0].Value = dtDateBefore;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
       
        /// <summary>
        /// 得到要查询的数据的总数
        /// </summary>
        /// <param name="strTable"要查询的表></param>
        /// <param name="strWhere">查询的条件,如果没有条件填1=1</param>
        /// <returns></returns>
        public int GetRecSum(string strTable, string strWhere)
        {
            string strCmd = "select count(*) from " + strTable + "   where  " + strWhere;
            int iResult = Convert.ToInt32(DbHelperSQL.GetSingle(strCmd));
            return iResult;
        }
    }
}
