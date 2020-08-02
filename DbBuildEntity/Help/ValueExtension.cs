/*
*┌──────────────────────────────────────────┐
*│  描述：ValueExtension                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/7/31 22:02:49                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Model.Help
{
    public static class ValueExtension
    {
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="this"></param>
        /// <param name="digits">小数位数</param>
        /// <returns></returns>
        public static double ToRound(this double @this, int digits)
        {
            return Math.Round(@this, digits, MidpointRounding.AwayFromZero);
        }
    }
}
