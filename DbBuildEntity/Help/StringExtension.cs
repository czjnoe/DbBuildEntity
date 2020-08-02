/*
*┌──────────────────────────────────────────┐
*│  描述：StringExtension                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/7/31 20:45:17                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Model.Help
{
  public static  class StringExtension
    {
        public static string ToFormat(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }
    }
}
