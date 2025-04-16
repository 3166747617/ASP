using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopCommon
{
    public static class DBHelper
    {
        //1、构建数据库连接字符串
        //private static string connStr = "server=SC-202308181028;uid=sa;pwd=123;database=WEEBDB1";

        private static string connStr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sqlText, List<SqlParameter> sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))//连接数据库
            {
                if (conn.State != ConnectionState.Open)//判断数据库资源是否被打开过了，如果被打开过了就不需要再次打开，反之就需要再次打开
                {
                    conn.Open();//打开数据库
                }
                SqlCommand cmd = new SqlCommand(sqlText, conn);
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters.ToArray());//把参数丢进来
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 执行操作语句
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static int ExecuteSqlCount(string sqlText, List<SqlParameter> sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlText, conn);//带着事务查询数据
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters.ToArray());//把参数丢进来
                }
                return cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// 执行事务操作
        /// </summary>
        /// <param name="sqlStringList"></param>
        /// <param name="listPars"></param>
        /// <returns></returns>
        public static int ExecuteSqlTran(List<String> sqlStringList, List<SqlParameter> sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))//连接数据库
            {
                if (conn.State != ConnectionState.Open)//判断数据库资源是否被打开过了，如果被打开过了就不需要再次打开，反之就需要再次打开
                {
                    conn.Open();//打开数据库
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        cmd.Transaction = tran;//将事务赋给cmd对象
                        int count = 0;
                        cmd.Parameters.AddRange(sqlParameters.ToArray());//如果Pars[i]=null，会有报错
                        for (int i = 0; i < sqlStringList.Count; i++)
                        {
                            string strsql = sqlStringList[i];
                            if (strsql.Trim().Length > 1)
                            {
                                cmd.CommandText = strsql;
                                count += cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return count;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }

            }
        }
    }
}
