using DbBuildEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Interface
{
    public interface IDbDal
    {
        List<ColumnModel> GetColumnList(string TableName);

        List<TableModel> GetTables();
    }
}
