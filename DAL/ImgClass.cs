using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL
{
    public class ImgClass
    {
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_ImgClass");
            strSql.Append(" where Name= @Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,100)
				};
            parameters[0].Value = Name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_ImgClass(");
            strSql.Append("Name,IssueDate)");
            strSql.Append(" values (");
            strSql.Append("@Name,@IssueDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,100),
                	new SqlParameter("@IssueDate", SqlDbType.DateTime)
                
            };
            parameters[0].Value = Name;
            parameters[1].Value = DateTime.Now;            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(int ImgClassID,string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_ImgClass set ");
            strSql.Append("Name=@Name");
            strSql.Append(" where ImgClassID=@ImgClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,100)};
            parameters[0].Value = Name;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ImgClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_ImgClass ");
            strSql.Append(" where ImgClassID=@ImgClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgClassID", SqlDbType.Int,4)
				};
            parameters[0].Value = ImgClassID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetName(int ImgClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from T_ImgClass ");
            strSql.Append(" where ImgClassID=@ImgClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgClassID", SqlDbType.Int,4)};
            parameters[0].Value = ImgClassID;
           
            object obj= DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return obj.ToString();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_ImgClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }


   



}
