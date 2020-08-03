using DbBuildEntity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DbBuildEntity.Entity;
using DbBuildEntity.Model.Help;
using DbBuildEntity.Util;
using System.Data;

namespace DbBuildEntity.Dal
{
    public class SqlServerDal : IDbDal
    {
        private static string tablesSql =
            @"select s.name as TableName,(case when p.value is not null then p.value else '' end) as Description from (select t.*,CAST(
 case 
    when tbl.is_ms_shipped = 1 then 1
    when (
        select 
            major_id 
        from 
            sys.extended_properties 
        where 
            major_id = tbl.object_id and 
            minor_id = 0 and 
            class = 1 and 
            name = N'microsoft_database_tools_support') 
        is not null then 1
    else 0
end          
             AS bit) AS [IsSystemObject] from sys.tables t) s,left join sys.extended_properties
 p on p.major_id=s.object_id and p.minor_id=0

			 where s.IsSystemObject<>1";

        private static string columnsSql = @"SELECT c.name AS ColumnName, 
                    t.name AS TypeName,p.value AS Description
                    FROM  sys.extended_properties p RIGHT OUTER JOIN
                    sys.sysobjects o INNER JOIN
                    sys.syscolumns c ON o.id = c.id INNER JOIN
                    sys.systypes t ON c.xtype = t.xtype ON 
                    p.major_id = c.id AND 
                    p.minor_id = c.colid
                    WHERE (o.xtype = 'u' OR
                    o.xtype = 'v') AND (t.name <> 'sysname')
                    --and CONVERT(char,p.[value]) <> 'null'
                    AND (o.name = '{0}')
                    ORDER BY 表名,c.colid";

        public SqlServerDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IDbConnection _dbConnection;
       

        public List<ColumnModel> GetColumnList(string TableName)
        {
            List < ColumnModel > list=new List<ColumnModel>();
            {
                _dbConnection.Open();
                 list = _dbConnection.Query<ColumnModel>(columnsSql.ToFormat(TableName)).ToList();
                _dbConnection.Dispose();
            }
            return list;
        }

        public List<TableModel> GetTables()
        {
            List<TableModel> list=new List<TableModel>();
            _dbConnection.Open();
            list = _dbConnection.Query<TableModel>(tablesSql).ToList();
            _dbConnection.Dispose();
            return list;
        }
    }
}
