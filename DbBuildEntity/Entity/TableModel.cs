using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Entity
{
    public class TableModel
    {
        public string TableName { get; set; }
        public string Description { get; set; }
    }

    public class TableModels
    {
        public string TableName { get; set; }
        public string Description { get; set; }

        public List<ColumnModel> Columns
        {
            get
            {
                return _Columns;
            }

            set
            {
                _Columns = value;
            }
        }

        private List<ColumnModel> _Columns = new List<ColumnModel>();
    }
}
