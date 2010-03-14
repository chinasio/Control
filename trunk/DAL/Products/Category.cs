using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL.Products
{
    /// <summary>
    /// ���
    /// </summary>
    public class Category
    {
        
           #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Category");
            strSql.Append(" where CategoryId= @CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.VarChar)
				};
            parameters[0].Value = CategoryId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into P_Category(");
            strSql.Append("CategoryId,Name,Descn)");
            strSql.Append(" values (");
            strSql.Append("@CategoryId,@Name,@Descn)");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.VarChar,20),
					new SqlParameter("@Name", SqlDbType.VarChar,80),
					new SqlParameter("@Descn", SqlDbType.VarChar,255)
					};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Descn;
           

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Maticsoft.Model.Category model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Category set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Descn=@Descn ");           
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,80),
					new SqlParameter("@Descn", SqlDbType.VarChar,255),
                    new SqlParameter("@CategoryId", SqlDbType.VarChar,20)
					};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Descn;
            parameters[2].Value = model.CategoryId;
           

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public string GetName(string CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from P_Category ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.VarChar)
				};
            parameters[0].Value = CategoryId;
            object obj= DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool ExistsPro(string CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Product");
            strSql.Append(" where CategoryId= @CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.VarChar)
				};
            parameters[0].Value = CategoryId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete P_Category ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.VarChar)
				};
            parameters[0].Value = CategoryId;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Maticsoft.Model.Category GetModel(string CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from P_Category ");
            strSql.Append(" where CategoryId=@CategoryId");
            SqlParameter[] parameters = {
					new SqlParameter("@CategoryId", SqlDbType.VarChar)};
            parameters[0].Value = CategoryId;
            Maticsoft.Model.Category model = new Maticsoft.Model.Category();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.CategoryId = CategoryId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Descn = ds.Tables[0].Rows[0]["Descn"].ToString();               
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM P_Category ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

      

        #endregion  ��Ա����
    }
}
