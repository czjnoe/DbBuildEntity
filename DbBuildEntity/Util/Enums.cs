/*
*┌──────────────────────────────────────────┐
*│  描述：Enums                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 16:14:48                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Util
{
    public static class Enums
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        public enum DbType
        {
            SqlServer = 1,
            MySQL = 2,
            Oracle = 3
            //SQlite = 4
        }
    }
}
