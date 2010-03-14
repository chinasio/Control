using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL.NewsManage
{
    public class News
    {

        #region  ��Ա����        
        
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_News(");
            strSql.Append("UserId,Heading,Content,Frequency,IssueDate,Dormancy,ClassId,Focus,Priority,IsTop)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Heading,@Content,@Frequency,@IssueDate,@Dormancy,@ClassId,@Focus,@Priority,@IsTop)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Heading", SqlDbType.VarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Frequency", SqlDbType.Int,4),
					new SqlParameter("@IssueDate", SqlDbType.DateTime),
					new SqlParameter("@Dormancy", SqlDbType.VarChar,10),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Focus", SqlDbType.VarChar,200),
					new SqlParameter("@Priority", SqlDbType.Int,4),
                new SqlParameter("@IsTop", SqlDbType.Int,4)
            
            };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Heading;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Frequency;
            parameters[4].Value = model.IssueDate;
            parameters[5].Value = model.Dormancy;
            parameters[6].Value = model.ClassId;
            parameters[7].Value = model.Focus;
            parameters[8].Value = model.Priority;
            parameters[9].Value = model.IsTop;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ������(���ӱ�������)
        /// </summary>
        public void Add2(Maticsoft.Model.NewsManage.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_News(");
            strSql.Append("UserId,Heading,Content,Frequency,IssueDate,Dormancy,ClassId,Focus,Priority,IsTop)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@Heading,@Content,@Frequency,@IssueDate,@Dormancy,@ClassId,@Focus,@Priority,@IsTop)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Heading", SqlDbType.VarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Frequency", SqlDbType.Int,4),
					new SqlParameter("@IssueDate", SqlDbType.DateTime),
					new SqlParameter("@Dormancy", SqlDbType.VarChar,10),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Focus", SqlDbType.VarChar,200),
					new SqlParameter("@Priority", SqlDbType.Int,4),
                new SqlParameter("@IsTop", SqlDbType.Int,4)
            
            };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Heading;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Frequency;
            parameters[4].Value = model.IssueDate;
            parameters[5].Value = model.Dormancy;
            parameters[6].Value = model.ClassId;
            parameters[7].Value = model.Focus;
            parameters[8].Value = model.Priority;
            parameters[9].Value = model.IsTop;

            List<string> sqla = new List<string>();
            sqla.Add(strSql.ToString());
            StringBuilder strSql2;
            foreach (Maticsoft.Model.NewsManage.NewsReply nr in model.NewsReplys)
            {
                strSql2 = new StringBuilder();
                strSql2.Append("insert into T_NewsReply(");
                strSql2.Append("NewsId,Content,IssueDate)");
                strSql2.Append(" values (");
                strSql2.Append("@NewsId,@Content,@IssueDate)");
                SqlParameter[] parameters2 = {
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@IssueDate", SqlDbType.DateTime)};
                parameters2[0].Value = nr.NewsId;
                parameters2[1].Value = nr.Content;
                parameters2[2].Value = DateTime.Now;

                sqla.Add(strSql2.ToString()); 
            }            
            
            DbHelperSQL.ExecuteSqlTran(sqla);

        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_News set ");           
            strSql.Append("UserId=@UserId,");
            strSql.Append("Heading=@Heading,");
            strSql.Append("Content=@Content,");            
            strSql.Append("IssueDate=@IssueDate,");            
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Dormancy=@Dormancy,");
            strSql.Append("Focus=@Focus,");
            strSql.Append("Priority=@Priority,");
            strSql.Append("IsTop=@IsTop");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Heading", SqlDbType.VarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),                   
					new SqlParameter("@IssueDate", SqlDbType.DateTime),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
                    new SqlParameter("@Dormancy",SqlDbType.VarChar,10),
					new SqlParameter("@Focus", SqlDbType.VarChar,200),
					new SqlParameter("@Priority", SqlDbType.Int,4),
                    new SqlParameter("@IsTop", SqlDbType.Int,4)
            };
            parameters[0].Value = model.NewsId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Heading;
            parameters[3].Value = model.Content;           
            parameters[4].Value = model.IssueDate;            
            parameters[5].Value = model.ClassId;
            parameters[6].Value = model.Dormancy;
            parameters[7].Value = model.Focus;
            parameters[8].Value = model.Priority;
            parameters[9].Value = model.IsTop;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// ɾ��һ������(���ӱ�������)
        /// </summary>
        public void Delete(int NewsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_News ");
            strSql.Append(" where NewsId=" + NewsId);
            
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete T_NewsReply ");
            strSql2.Append(" where NewsId=" + NewsId);

            List<string> sqla = new List<string>();
            sqla.Add(strSql.ToString());
            sqla.Add(strSql2.ToString());
            //DbHelperSQL.ExecuteSql(strSql.ToString());
            DbHelperSQL.ExecuteSqlTran(sqla);
        }
        
        /// <summary>
        /// �õ�һ������ʵ��(���ӱ�������)
        /// </summary>
        public Maticsoft.Model.NewsManage.News GetModel(int NewsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_News ");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
            parameters[0].Value = NewsId;
            Maticsoft.Model.NewsManage.News model = new Maticsoft.Model.NewsManage.News();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.NewsId = NewsId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region �ֶ���Ϣ
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                model.Heading = ds.Tables[0].Rows[0]["Heading"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Frequency"].ToString() != "")
                {
                    model.Frequency = int.Parse(ds.Tables[0].Rows[0]["Frequency"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueDate"].ToString() != "")
                {
                    model.IssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                }
                model.Dormancy = ds.Tables[0].Rows[0]["Dormancy"].ToString();
                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.Focus = ds.Tables[0].Rows[0]["Focus"].ToString();
                if (ds.Tables[0].Rows[0]["Priority"].ToString() != "")
                {
                    model.Priority = int.Parse(ds.Tables[0].Rows[0]["Priority"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                #endregion

                #region  ���Żظ���Ϣ
                StringBuilder strSqlR = new StringBuilder();
                strSqlR.Append("select * from T_NewsReply ");
                strSqlR.Append(" where NewsId=@NewsId");
                SqlParameter[] parametersr = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
                parametersr[0].Value = NewsId;
                DataSet dsR = DbHelperSQL.Query(strSqlR.ToString(), parametersr);

                if ((dsR.Tables.Count>0)&&(dsR.Tables[0].Rows.Count > 0))
                {
                    int i = dsR.Tables[0].Rows.Count;
                    List<Maticsoft.Model.NewsManage.NewsReply> newsReplys = new List<Maticsoft.Model.NewsManage.NewsReply>();
                    for (int n = 0; n < i; n++)
                    {
                        newsReplys[n] = new Maticsoft.Model.NewsManage.NewsReply();
                        if (dsR.Tables[0].Rows[0]["Id"].ToString() != "")
                        {
                            newsReplys[n].Id = int.Parse(dsR.Tables[0].Rows[0]["Id"].ToString());
                        }
                        if (dsR.Tables[0].Rows[0]["NewsId"].ToString() != "")
                        {
                            newsReplys[n].NewsId = int.Parse(dsR.Tables[0].Rows[0]["NewsId"].ToString());
                        }
                        newsReplys[n].Content = dsR.Tables[0].Rows[0]["Content"].ToString();
                        if (dsR.Tables[0].Rows[0]["IssueDate"].ToString() != "")
                        {
                            newsReplys[n].IssueDate = DateTime.Parse(dsR.Tables[0].Rows[0]["IssueDate"].ToString());
                        }
 
                    }
                    model.NewsReplys = newsReplys;                    
                }               

                #endregion
                
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
            strSql.Append("select [NewsId],[UserId],[Heading],[Content],[Frequency],[IssueDate],[Dormancy],[ClassId],[Focus],[Priority],[IsTop] ");
            strSql.Append(" FROM T_News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by NewsId desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetListByPage(int PageSize, int PageIndex, string strWhere)
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
            parameters[0].Value = "T_NewsClass";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPage", parameters, "ds");

        }


        public void UpdateFrequency(int newsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_News set ");
            strSql.Append("Frequency=Frequency+1");
            strSql.Append(" where NewsId=" + newsid);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        #endregion  ��Ա����

        


        #region ��ѯ

        /// <summary>
		/// �õ������б�
		/// </summary>
		/// <param name="top">���ص�������-1Ϊ������</param>
		/// <param name="strWhere">����</param>
		/// <param name="FiledOrder">�����ֶ�</param>
		/// <returns></returns>
		public DataSet GetNewsList(int top,string strWhere,string FiledOrder)
		{
			StringBuilder strSql=new StringBuilder();			
			strSql.Append("select ");
			if(top>0)
			{
				strSql.Append(" top "+top.ToString());
			}
			strSql.Append(" * ");
            strSql.Append(" from T_News ");			
			
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by "+FiledOrder);//IssueDate desc

            return DbHelperSQL.Query(strSql.ToString());
		}
        
        /// <summary>
        /// �õ�ĳ��������
        /// </summary>
        /// <param name="top">��������</param>
        /// <param name="ClassId">���</param>
        /// <param name="Dormancy">����״̬</param>       
        /// <returns></returns>
        public DataSet GetNewsList(int top, int ClassId, bool Dormancy)
        {            
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" (1=1)");
            if (ClassId > 0)
            {
                strSql.Append(" and ClassId=" + ClassId);
            }
            strSql.Append(" and Dormancy='" + Dormancy.ToString().ToLower() + "'");
            return GetNewsList(top, strSql.ToString(), "NewsId desc");
        }

        public DataSet GetTopScroll(int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" (IsTop=1) and Dormancy='false'");
            return GetNewsList(top, strSql.ToString(), "NewsId desc");
        }

        /// <summary>
        /// �õ����5���������б�
        /// </summary>        
        public DataSet GetNewsByFocus(string Focus)
        {
            string NewsClassid = LTP.Common.ConfigHelper.GetConfigString("NewsClassid");            
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" (Dormancy='false')");
            if (Focus != "")
            {
                strSql.Append(" and ((Focus like '%" + Focus + "%') or (Heading like '%" + Focus + "%'))");
            }
            return GetNewsList(5, strSql.ToString(), "NewsId desc");
        }
 
        /// <summary>
        /// �õ�(ĳ����)�������ߵļ����ȵ�����
        /// </summary>
        /// <param name="top">��������</param>
        /// <param name="ClassId">���id,-1Ϊ������</param>	
        /// <returns></returns>
        public DataSet GetNewsTopList(int top, int ClassId)
        {            
            StringBuilder strSql = new StringBuilder();
            if (ClassId > 0)
            {
                strSql.Append(" (ClassId=" + ClassId + ") and ");
            }
            strSql.Append(" (Dormancy='false')");           
            return GetNewsList(top, strSql.ToString(), "Frequency desc");
        }
          

        #endregion

        #region ��淢������
                
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="strWhere"></param>
        public void DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_News ");           
            if (Idlist.Trim() != "")
            {
                strSql.Append(" where  NewsId in (" + Idlist + ")");
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="strWhere"></param>
        public void ReleaseList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_News set Dormancy='false'");
            if (Idlist.Trim() != "")
            {
                strSql.Append(" where  NewsId in (" + Idlist + ")");
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// ����(ȡ������)
        /// </summary>
        /// <param name="strWhere"></param>
        public void NoReleaseList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_News set Dormancy='true'");
            if (Idlist.Trim() != "")
            {
                strSql.Append( " where  NewsId in (" + Idlist + ")");
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
              
        #endregion
    }
}
