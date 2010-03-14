using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL.Products
{
    /// <summary>
    /// 品牌
    /// </summary>
    public class Brand
    {

        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from P_Brand");
            strSql.Append(" where BrandId= @BrandId");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandId", SqlDbType.VarChar)
				};
            parameters[0].Value = BrandId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into P_Brand(");
            strSql.Append("BrandId,Name,Descn,CategoryId)");
            strSql.Append(" values (");
            strSql.Append("@BrandId,@Name,@Descn,@CategoryId)");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandId", SqlDbType.VarChar,20),
					new SqlParameter("@Name", SqlDbType.VarChar,80),
					new SqlParameter("@Descn", SqlDbType.VarChar,255),
                    new SqlParameter("@CategoryId", SqlDbType.VarChar,20)};
            parameters[0].Value = model.BrandId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Descn;
            parameters[3].Value = model.CategoryId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update P_Brand set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Descn=@Descn,");
            strSql.Append("CategoryId=@CategoryId");
            strSql.Append(" where BrandId=@BrandId");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,80),
					new SqlParameter("@Descn", SqlDbType.VarChar,255),
                    new SqlParameter("@BrandId", SqlDbType.VarChar,20),
                    new SqlParameter("@CategoryId", SqlDbType.VarChar,20)
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Descn;
            parameters[2].Value = model.BrandId;
            parameters[3].Value = model.CategoryId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete P_Brand ");
            strSql.Append(" where BrandId=@BrandId");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandId", SqlDbType.VarChar)
				};
            parameters[0].Value = BrandId;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public string GetName(string BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from P_Brand ");
            strSql.Append(" where BrandId=@BrandId");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandId", SqlDbType.VarChar)
				};
            parameters[0].Value = BrandId;
            object obj= DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            { 
                return obj.ToString();
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Brand GetModel(string BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from P_Brand ");
            strSql.Append(" where BrandId=@BrandId");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandId", SqlDbType.VarChar)};
            parameters[0].Value = BrandId;
            Maticsoft.Model.Brand model = new Maticsoft.Model.Brand();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.BrandId = BrandId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Descn = ds.Tables[0].Rows[0]["Descn"].ToString();
                model.CategoryId = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM P_Brand ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

       

        #endregion  成员方法

    }
}
