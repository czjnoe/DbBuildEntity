using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Util
{
   public class FileUtil
    {
        public static bool Save(string content,string path)
        {
            StreamWriter sw = null;
            try
            {
                using (sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                sw.Dispose();
                return false;
            }
            return true;
        }
    }
}
