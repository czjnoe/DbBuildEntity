using DbBuildEntity.Entity;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBuildEntity.Util
{
    public class RazorBuildUtil
    {
        public static string GetBuildContent(string templatePath, List<ColumnModel> Columns, TableModel tableModel)
        {
            var tplContent = File.ReadAllText(templatePath);
            var result = Razor.Parse(tplContent, new
            {
                ClassName = tableModel.TableName,
                Description = tableModel.Description,
                Columns = Columns,
                NameSpace = ConfigUtil.GetAppSettingValue("DefaultNameSpace", "Model", Global.appConfigFullPath),
            });
            return result;
        }
    }
}
