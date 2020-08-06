/*
*┌──────────────────────────────────────────┐
*│  描述：DapperFactory                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 19:26:54                        
*└──────────────────────────────────────────┘
*/
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbType = SqlSugar.DbType;

namespace DbBuildEntity.Util
{
  public  class DapperFactory
    {
        public static IDbConnection GetConnection(DbBuildEntity.Util.Enums.DbType type, string connStr)
        {
            IDbConnection dbConnection = null;
            if (type == DbBuildEntity.Util.Enums.DbType.MySQL)
            {
                dbConnection = new MySqlConnection(connStr);
            }
            else if (type == DbBuildEntity.Util.Enums.DbType.Oracle)
            {
                dbConnection = new OracleConnection(connStr);
            }
            else if (type == DbBuildEntity.Util.Enums.DbType.SqlServer)
            {
                dbConnection = new SqlConnection(connStr);
            }
            else if (type == DbBuildEntity.Util.Enums.DbType.SQlite)
            {
                //var db= SqlSugarHelp.GetSugarClient(DbType.Sqlite,
                //@"data_source=C:\Sqlite\db\test.db;Pooling=true;FailIfMissing=false;Max Pool Size=10");
                var dbConnection2 = new SQLiteConnection(@"C:\Sqlite\db\test.db");
                dbConnection =(IDbConnection)(new SQLiteConnection(connStr)) ;
            }
            return dbConnection;
        }
    }
}
