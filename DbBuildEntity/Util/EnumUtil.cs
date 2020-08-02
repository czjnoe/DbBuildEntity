/*
*┌──────────────────────────────────────────┐
*│  描述：EnumUtil                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 18:11:22                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Util
{
    public static class EnumUtil
    {
        public static Dictionary<string, int> GetEnum<T>()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                dic.Add(e.ToString(), Convert.ToInt32(e));
            }
            return dic;
        }
    }
}
