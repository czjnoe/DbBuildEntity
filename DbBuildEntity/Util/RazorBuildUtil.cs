using DbBuildEntity.Entity;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
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
        [Obsolete]
        public static string GetBuildContent(string templatePath, List<ColumnModel> Columns, TableModel tableModel)
        {
            var tplContent = File.ReadAllText(templatePath);
            var result = Razor.Parse(tplContent, new
            {
                ClassName = tableModel.TableName,
                Description = tableModel.Description,
                Columns = Columns,
                NameSpace = "Models",
                i1 = 1,
                i2 = 1,
                i3 = 1
            }, "sss");
            return result;
        }

        public static string GetBuildContentNew(string templatePath, string templateName, List<ColumnModel> Columns, TableModel tableModel,string nameSpace)
        {
            var config = new TemplateServiceConfiguration();
            config.CompilerServiceFactory = new RazorEngine.Roslyn.RoslynCompilerServiceFactory();
            string result = string.Empty;
            var tplContent = File.ReadAllText(templatePath);
            using (var service = RazorEngineService.Create(config))
            {
                var model = new
                {
                    ClassName = tableModel.TableName,
                    Description = tableModel.Description,
                    Columns = Columns,
                    NameSpace = nameSpace,
                };
                result = service.RunCompile(tplContent, templateName, null, model);
            }
            return result;
        }

        public static string GetBuildContent_Enum(string templatePath, string templateName, List<TableModels> tables, string nameSpace,string className)
        {
            var config = new TemplateServiceConfiguration();
            config.CompilerServiceFactory = new RazorEngine.Roslyn.RoslynCompilerServiceFactory();
            string result = string.Empty;
            var tplContent = File.ReadAllText(templatePath);
            using (var service = RazorEngineService.Create(config))
            {
                var model = new
                {
                    ClassName = className,
                    Tables = tables,
                    TableNames= tables.Select(s=>s.TableName).ToList(),
                    NameSpace = nameSpace,
                };
                result = service.RunCompile(tplContent, templateName, null, model);
            }
            return result;
        }
    }
}
