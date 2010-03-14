using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.NewsManage
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsClass
    {

        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(String ClassDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_NewsClass");
            strSql.Append(" where ClassDesc= @ClassDesc");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassDesc", SqlDbType.VarChar)
				};
            parameters[0].Value = ClassDesc;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_NewsClass(");
            strSql.Append("ClassDesc,ClassPicture,ParentId)");
            strSql.Append(" values (");
            strSql.Append("@ClassDesc,@ClassPicture,@ParentId)");
            SqlParameter[] parameters = {					
					new SqlParameter("@ClassDesc", SqlDbType.VarChar,50),
					new SqlParameter("@ClassPicture", SqlDbType.VarChar,100),
					new SqlParameter("@ParentId", SqlDbType.Int,4)};

            parameters[0].Value = model.ClassDesc;
            parameters[1].Value = model.ClassPicture;
            parameters[2].Value = model.ParentId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //return model.ClassId;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_NewsClass set ");            
            strSql.Append("ClassDesc=@ClassDesc,");
            strSql.Append("ClassPicture=@ClassPicture,");
            strSql.Append("ParentId=@ParentId");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ClassDesc", SqlDbType.VarChar,50),
					new SqlParameter("@ClassPicture", SqlDbType.VarChar,100),
					new SqlParameter("@ParentId", SqlDbType.Int,4)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.ClassDesc;
            parameters[2].Value = model.ClassPicture;
            parameters[3].Value = model.ParentId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_NewsClass ");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)
				};
            parameters[0].Value = ClassId;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DeleteByClassId(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_NewsClass ");
            strSql.Append(" where ClassId=" + ClassId);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModel(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_NewsClass ");
            strSql.Append(" where ClassId=@ClassId");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4)};
            parameters[0].Value = ClassId;
            Maticsoft.Model.NewsManage.NewsClass model = new Maticsoft.Model.NewsManage.NewsClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ClassId = ClassId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ClassDesc = ds.Tables[0].Rows[0]["ClassDesc"].ToString();
                model.ClassPicture = ds.Tables[0].Rows[0]["ClassPicture"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
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
            strSql.Append("select [ClassId],[ClassDesc],[ClassPicture],[ParentId] ");
            strSql.Append(" FROM T_NewsClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据ClassId得到类的ClassDesc
        /// </summary>
        public string GetClassDescByClassId(int ClassId)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select [ClassDesc] FROM T_NewsClass where ClassId=@ClassId");
            SqlParameter[] paremeters ={ new SqlParameter("@ClassId", SqlDbType.Int, 4) };
            paremeters[0].Value = ClassId;
            DataSet ds = DbHelperSQL.Query(strsql.ToString(), paremeters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["ClassDesc"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 根据ParentID得到父类的ClassDesc
        /// </summary>
        public string GetClassDescByParentID(int parentId)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select [ClassDesc] FROM T_NewsClass where ParentID=@ParentID");
            SqlParameter[] paremeters={new SqlParameter("@ParentID",SqlDbType.Int,4)};
            paremeters[0].Value = parentId;
            DataSet ds = DbHelperSQL.Query(strsql.ToString(), paremeters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["ClassDesc"].ToString();
            }
            else
            {
                return "";
            }
        }

        #endregion  成员方法
    }
}
