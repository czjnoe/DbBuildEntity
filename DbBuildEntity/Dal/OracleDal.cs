using DbBuildEntity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBuildEntity.Entity;
using System.Data;
using DbBuildEntity.Model.Help;
using Dapper;
using DbBuildEntity.Util;

namespace DbBuildEntity.Dal
{
    public class OracleDal : IDbDal
    {
        private static string columnsSql =
            @"select c.COLUMN_NAME AS ColumnName,c.COMMENTS AS Description,(select DATA_TYPE from ALL_TAB_COLUMNS 
 where TABLE_NAME='{0}' AND COLUMN_NAME=C.COLUMN_NAME) AS TypeName from all_col_comments c where TABLE_NAME='{0}'";
        private static string tablesSql =
            @"select TABLE_NAME as TableName，COMMENTS as Description from user_tab_comments where TABLE_TYPE='TABLE'";

        public List<ColumnModel> GetColumnList(string TableName, string ConnString)
        {
            List<ColumnModel> list = new List<ColumnModel>();
            using (var db = DapperFactory.GetConnection(Enums.DbType.SqlServer, ConnString))
            {
                db.Open();
                list = db.Query<ColumnModel>(columnsSql.ToFormat(TableName)).ToList();
                db.Dispose();
            }
            return list;
        }

        public List<TableModel> GetTables(string ConnString)
        {
            List<TableModel> list = new List<TableModel>();
            using (var db = DapperFactory.GetConnection(Enums.DbType.SqlServer, ConnString))
            {
                db.Open();
                list = db.Query<TableModel>(tablesSql).ToList();
                db.Dispose();
            }
            return list;
        }
    }
}
