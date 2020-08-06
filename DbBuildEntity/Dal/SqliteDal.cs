using DbBuildEntity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBuildEntity.Entity;
using DbBuildEntity.Util;
using Dapper;
using DbBuildEntity.Model.Help;
using SQLite;
using DbBuildEntity.Model;

namespace DbBuildEntity.Dal
{
    public class SqliteDal : IDbDal
    {
        
        private static string tablesSql = @"select m.name as TableName,m.tbl_name as Description from sqlite_master m where type='table'";
        private static string columnsSql = @"pragma table_info ('{0}')";
        public List<ColumnModel> GetColumnList(string TableName, string ConnString)
        {
            List<ColumnModel> list = new List<ColumnModel>();
            using (var db = new SQLiteConnection(ConnString))
            {
                var columns=db.Query<SqliteColumnModel>(columnsSql.ToFormat(TableName));
                ColumnModel Model = null;
                foreach (var column in columns)
                {
                    Model = new ColumnModel();
                    Model.ColumnName = column.name;
                    Model.TypeName = column.type;
                    list.Add(Model);
                }
                db.Close();
                db.Dispose();
            }
            return list;
        }

        public List<TableModel> GetTables(string ConnString)
        {
            List<TableModel> list = new List<TableModel>();
            using (var db = new SQLiteConnection(ConnString))
            {
                list = db.Query<TableModel>(tablesSql).ToList();

                db.Dispose();
            }
            return list;
        }
    }
}
