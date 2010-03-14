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
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
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
        /// ����һ������
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
        /// ����һ������
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
        /// ɾ��һ������
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
        /// �õ�һ������ʵ��
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
        /// ��������б�
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



        #endregion  ��Ա����
    }


   



}
