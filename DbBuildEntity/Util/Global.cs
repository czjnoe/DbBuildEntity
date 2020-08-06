/*
*┌──────────────────────────────────────────┐
*│  描述：Global                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 18:56:07                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Util
{
    public static class Global
    {
        //public static string AssemblyDirectory
        //{
        //    get
        //    {
        //        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        //        UriBuilder uri = new UriBuilder(codeBase);
        //        string path = Uri.UnescapeDataString(uri.Path);
        //        return Path.GetDirectoryName(path);
        //    }
        //}

        public static string nameSpaceConfigContent =
            "<?xml version=\"1.0\" encoding=\"utf-8\" ?><configuration><appSettings><add key=\"DefaultNameSpace\" value=\"Model\"/></appSettings></configuration>";

        

        public static string assemblyBasePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string configStringFullPath = assemblyBasePath + "\\Config\\ConnString.json";

        public static string appConfigFullPath = assemblyBasePath + "\\app.config";

        public static string templatePath = assemblyBasePath + "\\Template";
        public static string dbTypeFullPath = assemblyBasePath + "\\Config\\dbtype.json";

        public static string nameSpaceConfigFullPath = assemblyBasePath + "\\Config\\NameSpace.config";
    }
}
