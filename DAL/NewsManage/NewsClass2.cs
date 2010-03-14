using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Maticsoft.DAL.NewsManage
{
    /// <summary>
    /// 直接采用企业库 Data Access Application Block 2.0
    /// </summary>
    public class NewsClass2
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

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ClassDesc", DbType.String, ClassDesc);
            object  obj=db.ExecuteScalar(dbCommand);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
           
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ClassDesc", DbType.String, model.ClassDesc);
            db.AddInParameter(dbCommand, "ClassPicture", DbType.String, model.ClassPicture);
            db.AddInParameter(dbCommand, "ParentId", DbType.Int16, model.ParentId);
            db.ExecuteNonQuery(dbCommand);
            //db.GetParameterValue(dbCommand,"ClassId");
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
                        
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ClassId", DbType.Int16, model.ClassId);
            db.AddInParameter(dbCommand, "ClassDesc", DbType.String, model.ClassDesc);
            db.AddInParameter(dbCommand, "ClassPicture", DbType.String, model.ClassPicture);
            db.AddInParameter(dbCommand, "ParentId", DbType.Int16, model.ParentId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_NewsClass ");
            strSql.Append(" where ClassId=@ClassId");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ClassId", DbType.Int16, ClassId);           
            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModel(int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_NewsClass ");
            strSql.Append(" where ClassId=@ClassId");

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ClassId", DbType.Int16, ClassId);
            DataSet ds=db.ExecuteDataSet(dbCommand);

            Maticsoft.Model.NewsManage.NewsClass model = new Maticsoft.Model.NewsManage.NewsClass(); 
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
            Database db = DatabaseFactory.CreateDatabase();//DatabaseFactory.CreateDatabase("AdDesktopConnectionString");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.Int16, "T_NewsClass");
            db.AddInParameter(dbCommand, "fldName", DbType.Int16, "ID");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int16, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int16, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Int16, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Int16, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.Int16, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion  成员方法
    }
}
