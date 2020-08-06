using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Model
{
   public class SqliteColumnModel
    {
        public int cid { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int notnull { get; set; }
        public int pk { get; set; }
        public object dflt_value { get; set; }
    }
}
