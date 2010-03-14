using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL
{
    public class Images
    {

        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.Images model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Images(");
            strSql.Append("ImgClassID,ImageName,LinkUrl)");
            strSql.Append(" values (");
            strSql.Append("@ImgClassID,@ImageName,@LinkUrl)");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgClassID", SqlDbType.Int,4),
					new SqlParameter("@ImageName", SqlDbType.VarChar,100),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ImgClassID;
            parameters[1].Value = model.ImageName;
            parameters[2].Value = model.LinkUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.Images model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Images set ");
            strSql.Append("ImgClassID=@ImgClassID,");
            strSql.Append("ImageName=@ImageName,");
            strSql.Append("LinkUrl=@LinkUrl");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgClassID", SqlDbType.Int,4),
					new SqlParameter("@ImageName", SqlDbType.VarChar,100),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ImgClassID;
            parameters[1].Value = model.ImageName;
            parameters[2].Value = model.LinkUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Images ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Images GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Images ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Maticsoft.Model.Images model = new Maticsoft.Model.Images();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ImgClassID"].ToString() != "")
                {
                    model.ImgClassID = int.Parse(ds.Tables[0].Rows[0]["ImgClassID"].ToString());
                }
                model.ImageName = ds.Tables[0].Rows[0]["ImageName"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
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
            strSql.Append("select [ID],[ImgClassID],[ImageName],[LinkUrl] ");
            strSql.Append(" FROM T_Images ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "T_Images";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        #endregion  成员方法



    }
}
