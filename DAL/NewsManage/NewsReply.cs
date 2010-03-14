using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL.NewsManage
{
    public class NewsReply
    {

        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_NewsReply(");
            strSql.Append("NewsId,Content,IssueDate)");
            strSql.Append(" values (");
            strSql.Append("@NewsId,@Content,@IssueDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@IssueDate", SqlDbType.DateTime)};
            parameters[0].Value = model.NewsId;
            parameters[1].Value = model.Content;
            parameters[2].Value = DateTime.Now ;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_NewsReply ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
				};
            parameters[0].Value = Id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsReply GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_NewsReply ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            Maticsoft.Model.NewsManage.NewsReply model = new Maticsoft.Model.NewsManage.NewsReply();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Id = Id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(ds.Tables[0].Rows[0]["NewsId"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["IssueDate"].ToString() != "")
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
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
            strSql.Append("select [Id],[NewsId],[Content],[IssueDate] ");
            strSql.Append(" FROM T_NewsReply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(int top,int Newsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" [Id],[NewsId],[Content],[IssueDate] ");
            strSql.Append(" FROM T_NewsReply ");
            if (Newsid>0)
            {
                strSql.Append(" where NewsId=" + Newsid);
            }
            strSql.Append(" order by Id desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetReplyCount(int Newsid)
        {
            string strsql = "select max(1) from T_NewsReply where NewsId=" + Newsid;           
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
       
        #endregion  成员方法
    }
}
