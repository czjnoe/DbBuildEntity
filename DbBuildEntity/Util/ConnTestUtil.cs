/*
*┌──────────────────────────────────────────┐
*│  描述：ConnTestUtil                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 19:30:27                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SQLite;

namespace DbBuildEntity.Util
{
   public class ConnTestUtil
    {
        /// <summary>
        /// 测试连接字符串
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static bool ConnTest(int connType, string connStr)
        {
            if ((DbBuildEntity.Util.Enums.DbType) connType == DbBuildEntity.Util.Enums.DbType.SQlite)
            {
                var db = new SQLiteConnection(connStr);
                
                return true;
            }
            else
            {
                var db = DapperFactory.GetConnection((DbBuildEntity.Util.Enums.DbType)connType, connStr);
                try
                {
                    db.Open();
                    if (db.State == System.Data.ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}
