/*
*┌──────────────────────────────────────────┐
*│  描述：SqlSugarHelp                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/3 23:39:42                        
*└──────────────────────────────────────────┘
*/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DbBuildEntity.Util
{
    public static class SqlSugarHelp
    {
        private static Dictionary<string, ConnectionConfig> configCache = new Dictionary<string, ConnectionConfig>();
        public static SqlSugarClient GetSugarClient(DbType type, string name = "default")
        {
            SqlSugarClient sqlSugarClient = new SqlSugarClient(GetConnectionConfig(name, type));
            return sqlSugarClient;
        }

        public static SqlSugarClient GetSugarClientByConnString(DbType type, string connString = "")
        {
            SqlSugarClient sqlSugarClient = new SqlSugarClient(GetConnectionConfig(connString,type));
            return sqlSugarClient;
        }

        public static SqlSugarClient GetSugarClient(string name = "default")
        {
            SqlSugarClient sqlSugarClient = new SqlSugarClient(GetConnectionConfig(name));
            return sqlSugarClient;
        }

        public static ConnectionConfig GetConnectionConfig(string name)
        {
            if (!configCache.ContainsKey(name))
            {
                ConnectionConfig connectionConfig = new ConnectionConfig()
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString,
                    DbType = DbType.Oracle,
                    IsAutoCloseConnection = true
                };
                configCache.Add(name, connectionConfig);
            }
            return configCache[name];
        }

        public static ICacheService myCache = null;

        public static ConnectionConfig GetConnectionConfig(string connString, DbType type)
        {
            //myCache = new HttpRuntimeCache();//ICacheService   设置.Net自带缓存
            //myCache = new RedisCache("10.1.249.196");//设置redies缓存
            if (!configCache.ContainsKey(connString))
            {
                ConnectionConfig connectionConfig = new ConnectionConfig()
                {
                    ConnectionString = connString,
                    DbType = type,
                    IsAutoCloseConnection = true,
                    ConfigureExternalServices = new ConfigureExternalServices
                    {
                        DataInfoCacheService = myCache
                    }
                };
                configCache.Add(connString, connectionConfig);
            }
            return configCache[connString];
        }

        /// <summary>
        /// 将前台传回来的字符串解析成sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string GetSqlWhereClause(string sql)
        {
            string whereClause = "";
            try
            {
                Dictionary<string, object> dictVl = new Dictionary<string, object>();
                JavaScriptSerializer s = new JavaScriptSerializer();
                Dictionary<string, object> JsonData = (Dictionary<string, object>)s.DeserializeObject(sql);
                foreach (KeyValuePair<string, object> kv in JsonData)
                {
                    dictVl = kv.Value as Dictionary<string, object>;
                    if (!dictVl.ContainsKey("VL") || dictVl["VL"] == null || dictVl["VL"] == DBNull.Value
                        || string.IsNullOrEmpty(dictVl["VL"].ToString()))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(whereClause))
                    {
                        whereClause += " AND ";
                    }
                    whereClause += $" {kv.Key} ";
                    #region 规则是模糊查询还是全字匹配
                    if (dictVl.ContainsKey("GZ"))
                    {
                        switch (dictVl["GZ"].ToString())
                        {
                            case "":
                            case "0":
                                whereClause += $"LIKE '%{dictVl["VL"].ToString()}%'";
                                break;
                            case "1":
                                whereClause += $"= '{dictVl["VL"].ToString()}'";
                                break;
                        }
                    }
                    else
                    {
                        whereClause += $"LIKE '%{dictVl["VL"].ToString()}%'";
                    }
                    #endregion
                }
            }
            catch (Exception er)
            {

            }
            return whereClause;
        }

        /// <summary>
        /// 获取缓存类型
        /// </summary>
        /// <typeparam name="Cache"></typeparam>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Cache GetCache<Cache>(this SqlSugarClient client)
        {
            Cache cache = (Cache)client.CurrentConnectionConfig.ConfigureExternalServices.DataInfoCacheService;
            return cache;
        }
    }
}
