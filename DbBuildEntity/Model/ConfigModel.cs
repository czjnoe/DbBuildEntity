/*
*┌──────────────────────────────────────────┐
*│  描述：ConfigModel                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 18:50:53                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Model
{
   public class ConfigModel
    {
        public string Guid { get; set; }
        public string ConnName { get; set; }
        public string ConnString { get; set; }
        public string ConnType { get; set; }
    }
}
