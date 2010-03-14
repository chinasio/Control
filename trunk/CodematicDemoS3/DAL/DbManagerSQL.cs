using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace LiTianPing.SQLServerDAL
{
	/// <summary>
	/// Copyright (C) 2004-2008 LiTianPing
	/// All rights reserved
	/// ���ݷ��ʻ�����
	/// �û������޸������Լ���Ŀ����Ҫ��
	/// </summary>
	public abstract class DbManagerSQL
	{
		//���ݿ������ַ���(web.config������)
		//<add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />		
		protected static string connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
		public DbManagerSQL()
		{			
		}
		
		#region  ִ�м�SQL���

		/// <summary>
		/// ִ��SQL��䣬����Ӱ��ļ�¼��
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public static int ExecuteSql(string SQLString)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{				
				using (SqlCommand cmd = new SqlCommand(SQLString,connection))
				{
					try
					{		
						connection.Open();
						int rows=cmd.ExecuteNonQuery();
						return rows;
					}
					catch(System.Data.SqlClient.SqlException E)
					{					
						connection.Close();
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
		/// <summary>
		/// ִ�ж���SQL��䣬ʵ�����ݿ�����
		/// </summary>
		/// <param name="SQLStringList">����SQL���</param>		
		public static void ExecuteSqlTran(ArrayList SQLStringList)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection=conn;				
				SqlTransaction tx=conn.BeginTransaction();			
				cmd.Transaction=tx;				
				try
				{   		
					for(int n=0;n<SQLStringList.Count;n++)
					{
						string strsql=SQLStringList[n].ToString();
						if (strsql.Trim().Length>1)
						{
							cmd.CommandText=strsql;
							cmd.ExecuteNonQuery();
						}
					}										
					tx.Commit();					
				}
				catch(System.Data.SqlClient.SqlException E)
				{		
					tx.Rollback();
					throw new Exception(E.Message);
				}
			}
		}
		/// <summary>
		/// ִ�д�һ���洢���̲����ĵ�SQL��䡣
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public static int ExecuteSql(string SQLString,string content)
		{				
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(SQLString,connection);		
				System.Data.SqlClient.SqlParameter  myParameter = new System.Data.SqlClient.SqlParameter ( "@content", SqlDbType.NText);
				myParameter.Value = content ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.SqlClient.SqlException E)
				{				
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}	
			}
		}		
		/// <summary>
		/// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
		/// </summary>
		/// <param name="strSQL">SQL���</param>
		/// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public static int ExecuteSqlInsertImg(string strSQL,byte[] fs)
		{		
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(strSQL,connection);	
				System.Data.SqlClient.SqlParameter  myParameter = new System.Data.SqlClient.SqlParameter ( "@fs", SqlDbType.Image);
				myParameter.Value = fs ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.SqlClient.SqlException E)
				{				
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}				
			}
		}
		
		/// <summary>
		/// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
		/// </summary>
		/// <param name="SQLString">�����ѯ������</param>
		/// <returns>��ѯ�����object��</returns>
		public static object GetSingle(string SQLString)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using(SqlCommand cmd = new SqlCommand(SQLString,connection))
				{
					try
					{
						connection.Open();
						object obj = cmd.ExecuteScalar();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.SqlClient.SqlException e)
					{						
						connection.Close();
						throw new Exception(e.Message);
					}	
				}
			}
		}
		/// <summary>
		/// ִ�в�ѯ��䣬����SqlDataReader
		/// </summary>
		/// <param name="strSQL">��ѯ���</param>
		/// <returns>SqlDataReader</returns>
		public static SqlDataReader ExecuteReader(string strSQL)
		{
			SqlConnection connection = new SqlConnection(connectionString);			
			SqlCommand cmd = new SqlCommand(strSQL,connection);				
			try
			{
				connection.Open();	
				SqlDataReader myReader = cmd.ExecuteReader();
				return myReader;
			}
			catch(System.Data.SqlClient.SqlException e)
			{								
				throw new Exception(e.Message);
			}		
			finally
			{
				cmd.Dispose();
				connection.Close();
			}	
			
		}		
		/// <summary>
		/// ִ�в�ѯ��䣬����DataSet
		/// </summary>
		/// <param name="SQLString">��ѯ���</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				DataSet ds = new DataSet();
				try
				{
					connection.Open();
					SqlDataAdapter command = new SqlDataAdapter(SQLString,connection);				
					command.Fill(ds,"ds");
				}
				catch(System.Data.SqlClient.SqlException ex)
				{				
					throw new Exception(ex.Message);
				}			
				return ds;
			}			
		}


		#endregion

		#region ִ�д�������SQL���

		/// <summary>
		/// ִ��SQL��䣬����Ӱ��ļ�¼��
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
		public static int ExecuteSql(string SQLString,params SqlParameter[] cmdParms)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{				
				using (SqlCommand cmd = new SqlCommand())
				{
					try
					{		
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						int rows=cmd.ExecuteNonQuery();
						cmd.Parameters.Clear();
						return rows;
					}
					catch(System.Data.SqlClient.SqlException E)
					{				
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
			
		/// <summary>
		/// ִ�ж���SQL��䣬ʵ�����ݿ�����
		/// </summary>
		/// <param name="SQLStringList">SQL���Ĺ�ϣ��keyΪsql��䣬value�Ǹ�����SqlParameter[]��</param>
		public static void ExecuteSqlTran(Hashtable SQLStringList)
		{			
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					SqlCommand cmd = new SqlCommand();
					try 
					{
						//ѭ��
						foreach (DictionaryEntry myDE in SQLStringList)
						{	
							string 	cmdText=myDE.Key.ToString();
							SqlParameter[] cmdParms=(SqlParameter[])myDE.Value;
							PrepareCommand(cmd,conn,trans,cmdText, cmdParms);
							int val = cmd.ExecuteNonQuery();
							cmd.Parameters.Clear();

							trans.Commit();
						}					
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}				
			}
		}
	
				
		/// <summary>
		/// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
		/// </summary>
		/// <param name="SQLString">�����ѯ������</param>
		/// <returns>��ѯ�����object��</returns>
		public static object GetSingle(string SQLString,params SqlParameter[] cmdParms)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					try
					{
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						object obj = cmd.ExecuteScalar();
						cmd.Parameters.Clear();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.SqlClient.SqlException e)
					{				
						throw new Exception(e.Message);
					}					
				}
			}
		}
		
		/// <summary>
		/// ִ�в�ѯ��䣬����SqlDataReader
		/// </summary>
		/// <param name="strSQL">��ѯ���</param>
		/// <returns>SqlDataReader</returns>
		public static SqlDataReader ExecuteReader(string SQLString,params SqlParameter[] cmdParms)
		{		
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();				
			try
			{
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
				SqlDataReader myReader = cmd.ExecuteReader();
				cmd.Parameters.Clear();
				return myReader;
			}
			catch(System.Data.SqlClient.SqlException e)
			{								
				throw new Exception(e.Message);
			}		
			finally
			{
				cmd.Dispose();
				connection.Close();
			}	
			
		}		
		
		/// <summary>
		/// ִ�в�ѯ��䣬����DataSet
		/// </summary>
		/// <param name="SQLString">��ѯ���</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString,params SqlParameter[] cmdParms)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
				using( SqlDataAdapter da = new SqlDataAdapter(cmd) )
				{
					DataSet ds = new DataSet();	
					try
					{												
						da.Fill(ds,"ds");
						cmd.Parameters.Clear();
					}
					catch(System.Data.SqlClient.SqlException ex)
					{				
						throw new Exception(ex.Message);
					}			
					return ds;
				}				
			}			
		}


		private static void PrepareCommand(SqlCommand cmd,SqlConnection conn,SqlTransaction trans, string cmdText, SqlParameter[] cmdParms) 
		{
			if (conn.State != ConnectionState.Open)
				conn.Open();
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			if (trans != null)
				cmd.Transaction = trans;
			cmd.CommandType = CommandType.Text;//cmdType;
			if (cmdParms != null) 
			{
				foreach (SqlParameter parm in cmdParms)
					cmd.Parameters.Add(parm);
			}
		}

		#endregion

		#region �洢���̲���

		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <returns>SqlDataReader</returns>
		public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlDataReader returnReader;
				connection.Open();
				SqlCommand command = BuildQueryCommand( connection,storedProcName, parameters );
				command.CommandType = CommandType.StoredProcedure;
				returnReader = command.ExecuteReader();				
				return returnReader;
			}
		}
		
		
		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <param name="tableName">DataSet����еı���</param>
		/// <returns>DataSet</returns>
		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				DataSet dataSet = new DataSet();
				connection.Open();
				SqlDataAdapter sqlDA = new SqlDataAdapter();
				sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters );
				sqlDA.Fill( dataSet, tableName );
				connection.Close();
				return dataSet;
			}
		}

		
		/// <summary>
		/// ���� SqlCommand ����(��������һ���������������һ������ֵ)
		/// </summary>
		/// <param name="connection">���ݿ�����</param>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <returns>SqlCommand</returns>
		private static SqlCommand BuildQueryCommand(SqlConnection connection,string storedProcName, IDataParameter[] parameters)
		{			
			SqlCommand command = new SqlCommand( storedProcName, connection );
			command.CommandType = CommandType.StoredProcedure;
			foreach (SqlParameter parameter in parameters)
			{
				command.Parameters.Add( parameter );
			}
			return command;			
		}
		
		/// <summary>
		/// ִ�д洢���̣�����Ӱ�������		
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <param name="rowsAffected">Ӱ�������</param>
		/// <returns></returns>
		public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected )
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				int result;
				connection.Open();
				SqlCommand command = BuildIntCommand(connection,storedProcName, parameters );
				rowsAffected = command.ExecuteNonQuery();
				result = (int)command.Parameters["ReturnValue"].Value;
				//Connection.Close();
				return result;
			}
		}
		
		/// <summary>
		/// ���� SqlCommand ����ʵ��(��������һ������ֵ)	
		/// </summary>
		/// <param name="storedProcName">�洢������</param>
		/// <param name="parameters">�洢���̲���</param>
		/// <returns>SqlCommand ����ʵ��</returns>
		private static SqlCommand BuildIntCommand(SqlConnection connection,string storedProcName, IDataParameter[] parameters)
		{
			SqlCommand command = BuildQueryCommand(connection,storedProcName, parameters );
			command.Parameters.Add( new SqlParameter ( "ReturnValue",
				SqlDbType.Int,4,ParameterDirection.ReturnValue,
				false,0,0,string.Empty,DataRowVersion.Default,null ));
			return command;
		}
		#endregion	

	}
}
