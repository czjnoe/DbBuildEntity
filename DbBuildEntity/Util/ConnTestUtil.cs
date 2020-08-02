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
using DapperExtensions;

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

            var db = DapperFactory.GetConnection((DbBuildEntity.Util.Enums.DbType)connType, connStr);
            if(db.State==System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
