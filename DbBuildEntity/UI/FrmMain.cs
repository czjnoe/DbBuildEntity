using Dapper;
using DbBuildEntity.Dal;
using DbBuildEntity.Entity;
using DbBuildEntity.Interface;
using DbBuildEntity.Model;
using DbBuildEntity.Util;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DbBuildEntity.UI
{
    public partial class FrmMain : UIForm
    {
        private static List<TemplateModel> templateList = new List<TemplateModel>();
        private Dictionary<string, string> dbTypeDic = new Dictionary<string, string>();
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前选择目录
        /// </summary>
        private string _savePath = string.Empty;
        JsonUtil jsonUtil = null;
        public FrmMain(string savePath)
        {
            InitializeComponent();
            if (savePath.IsNullOrEmpty())
            {
                _savePath = ConfigUtil.GetAppSettingValue("DefaultPath", "", Global.nameSpaceConfigFullPath);
            }
            else
            {
                _savePath = savePath;
            }


            var dTypeList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DbTypeModel>>(File.ReadAllText(Global.dbTypeFullPath));
            dbTypeDic = dTypeList.ToDictionary(key => key.dbtype.ToUpper(), value => value.cstype);

            if (!File.Exists(Global.configStringFullPath))
            {
                FileUtil.Save("", Global.configStringFullPath);
            }
            if (!File.Exists(Global.nameSpaceConfigFullPath))
            {
                FileUtil.Save(Global.nameSpaceConfigContent, Global.nameSpaceConfigFullPath);
            }

            jsonUtil = new JsonUtil();
        }

        /// <summary>
        /// Tab切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.uiTabControl1.SelectedIndex)
            {
                case 0:
                    InitIndex();
                    break;
                case 1:
                    InitTabConnfig();
                    break;
                case 2:
                    break;
            }
        }

        private void InitTemplates()
        {
            var directory = new DirectoryInfo(Global.templatePath);
            templateList = directory.GetFiles("*.tpl").Select(s => new TemplateModel { FullName = s.FullName, Name = Path.GetFileNameWithoutExtension(s.FullName) }).ToList();
            this.cbbTemplate.DisplayMember = "Name";
            this.cbbTemplate.ValueMember = "FullName";
            this.cbbTemplate.DataSource = templateList;
        }

        private void InitIndex()
        {
            var items = jsonUtil.Items;
            this.cbbConfig.DisplayMember = "ConnName";
            this.cbbConfig.ValueMember = "Guid";
            this.cbbConfig.DataSource = items;

            this.tbNameSapce.Text = ConfigUtil.GetAppSettingValue("DefaultNameSpace", configPath: Global.nameSpaceConfigFullPath);
            this.tbSavePath.Text = _savePath;

        }

        private void InitTabConnfig()
        {
            this.tbConnString.Text = string.Empty;
            this.tbConnName.Text = string.Empty;
        }

        private void InitDbType()
        {
            var dbConnTypeDic = EnumUtil.GetEnum<DbBuildEntity.Util.Enums.DbType>();
            List<ComboBoxModel> connTypeList = dbConnTypeDic.Select(s => new ComboBoxModel { DisplayName = s.Key, Value = s.Value.ToString() }).ToList();

            this.cbbConnType.DisplayMember = "DisplayName";
            this.cbbConnType.ValueMember = "Value";
            this.cbbConnType.DataSource = connTypeList;
            InitListView();
        }


        private void InitListView()
        {
            this.lbConnName.Items.Clear();
            this.lbConnName.Items.AddRange(jsonUtil.Items.Select(s => s.ConnName).ToArray());
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnTest_Click(object sender, EventArgs e)
        {
            //var config = new TemplateServiceConfiguration();
            //config.CompilerServiceFactory = new RazorEngine.Roslyn.RoslynCompilerServiceFactory();
            //using (var service = RazorEngineService.Create(config))
            //{
            //    string template = "@Model.Name";
            //    var model0 = new { Name = "Matt" };
            //    string result0 = service.RunCompile(template, "htmlRawTemplate0", null, model0);
            //}

            var model = GetLVSelectConfigModel();
            var connTypeValue = Convert.ToInt32(model.ConnType);

            if (model.ConnString.IsNullOrEmpty() || model.ConnName.IsNullOrEmpty())
            {
                this.ShowWarningDialog("连接字符串或连接名称不可为空");
                return;
            }
            var result = ConnTestUtil.ConnTest(connTypeValue, model.ConnString);
            if (!result)
            {
                UIMessageTip.ShowError("测试失败", 1000, true);
            }
            else
            {
                UIMessageTip.ShowOk("测试成功", 1000, true);
            }
        }

        private ConfigModel GetConfigModel()
        {
            var connTypeValue = cbbConnType.SelectedValue?.ToString();
            var connString = this.tbConnString.Text;
            var connName = this.tbConnName.Text;
            ConfigModel model = new ConfigModel();
            model.ConnType = connTypeValue;
            model.ConnString = connString;
            model.ConnName = connName;
            return model;
        }

        private void btnConnSave_Click(object sender, EventArgs e)
        {
            ConfigModel model = GetLVSelectConfigModel();
            if (model.ConnType.IsNullOrEmpty() || model.ConnString.IsNullOrEmpty() || model.ConnName.IsNullOrEmpty())
            {
                UIMessageTip.ShowError("没有输入连接字符串、连接名或数据库类型", 1000, true);
                return;
            }
            if (model.Guid.IsNullOrEmpty())
            {
                model.Guid = Guid.NewGuid().ToString();
                jsonUtil.Add(model);
            }
            else
            {
                jsonUtil.Edit(model);
            }

            InitListView();
        }

        private void tbNameSapce_TextChanged(object sender, EventArgs e)
        {
            ConfigUtil.SetAppSettingValue("DefaultNameSpace", this.tbNameSapce.Text.Trim(), configPath: Global.nameSpaceConfigFullPath);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitIndex();
            InitTemplates();
            InitDbType();
        }

        private ConfigModel GetLVSelectConfigModel()
        {
            var index = lbConnName.SelectedIndex;
            var connString = this.tbConnString.Text;
            var connName = this.tbConnName.Text;
            if (index > -1)
            {
                var connTypeValue = cbbConnType.SelectedValue?.ToString();

                var configModel = jsonUtil.Items[index];
                configModel.ConnName = connName;
                configModel.ConnString = connString;
                configModel.ConnType = connTypeValue;
                return configModel;
            }
            else
            {
                ConfigModel model = new ConfigModel();
                model.ConnType = cbbConnType.SelectedValue?.ToString();
                model.ConnString = connString;
                model.ConnName = connName;
                return model;
            }
        }

        /// <summary>
        /// ListView 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbConnName_ItemDoubleClick(object sender, EventArgs e)
        {
            var index = lbConnName.SelectedIndex;
            var configModel = jsonUtil.Items[index];
            this.tbConnString.Text = configModel.ConnString;
            this.tbConnName.Text = configModel.ConnName;
            this.cbbConnType.SelectedValue = configModel.ConnType;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.Description = "选择保存目录";
            openFolderDialog.SelectedPath = _savePath;
            //openFolderDialog.RootFolder = Environment.SpecialFolder.Startup;
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _savePath = openFolderDialog.SelectedPath;
                this.tbSavePath.Text = openFolderDialog.SelectedPath;
            }
        }

        private void uiLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(uiLinkLabel1.Text);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuild_Click(object sender, EventArgs e)
        {
            _savePath = this.tbSavePath.Text;
            if (_savePath.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("没有设置导出目录");
                return;
            }

            var templatePath = this.cbbTemplate.SelectedValue?.ToString();
            if (templatePath.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("没有选择模板");
                return;
            }
            var configIndex = this.cbbConfig.SelectedIndex;
            if (configIndex < 0)
            {
                this.ShowWarningDialog("没有选择配置");
                return;
            }
            var configModel = jsonUtil.Items[configIndex];

            var nameSpace = this.tbNameSapce.Text;
            if (nameSpace.IsNullOrWhiteSpace())
            {
                this.ShowWarningDialog("没有添加命名空间");
                return;
            }

            IDbDal dal = null;
            if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.SqlServer).ToString())
            {
                dal = new SqlServerDal();
            }
            else if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.Oracle).ToString())
            {
                dal = new OracleDal();
            }
            else if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.MySQL).ToString())
            {

            }
            else if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.SQlite).ToString())
            {
                dal = new SqliteDal();
            }
            var tables = dal.GetTables(configModel.ConnString);
            int index = 0;

            if (Path.GetFileNameWithoutExtension(templatePath) != "实体枚举模板")
            {
                ShowStatus("提示", "导出实体中......", tables.Count, 0);

                foreach (var table in tables)
                {
                    StatusDescription = "导出实体中(" + index + "%)......";
                    StatusStepIt();

                    var columnsList = dal.GetColumnList(table.TableName, configModel.ConnString);
                    foreach (var column in columnsList)
                    {
                        string value = string.Empty;
                        var dResult = dbTypeDic.TryGetValue(column.TypeName.ToUpper(), out value);
                        if (dResult)
                        {
                            column.TypeName = value;
                        }
                        else
                        {
                            column.TypeName = "object";
                        }
                    }
                    //var buildContent = RazorBuildUtil.GetBuildContent(templatePath, columnsList, table);

                    var buildContent =
                        RazorBuildUtil.GetBuildContentNew(templatePath, table.TableName, columnsList, table, nameSpace);
                    FileUtil.Save(buildContent, Path.Combine(_savePath, $"{table.TableName}.cs"));

                    index++;
                }
            }
            else
            {
                ShowStatus("提示", "加载数据中......", tables.Count, 0);
                List<TableModels> list = new List<TableModels>();
                TableModels model = null;
                foreach (var table in tables)
                {
                    StatusDescription = "加载数据中(" + index + "%)......";
                    StatusStepIt();
                    var columnsList = dal.GetColumnList(table.TableName, configModel.ConnString);
                    model = new TableModels();
                    model.Columns = columnsList;
                    model.TableName = table.TableName;
                    model.Description = table.Description;
                    list.Add(model);

                    index++;
                }

                var buildContent =
                        RazorBuildUtil.GetBuildContent_Enum(templatePath, "TableNames", list, nameSpace, "TableNames");
                FileUtil.Save(buildContent, Path.Combine(_savePath, "TableNames.cs"));
            }

            ConfigUtil.SetAppSettingValue("DefaultPath", _savePath, Global.nameSpaceConfigFullPath);
            UIMessageTip.ShowOk("导出成功", 2000, true);
        }

        /// <summary>
        /// 右键菜单事件 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            var index = lbConnName.SelectedIndex;
            if (index < 0)
            {
                this.ShowWarningDialog("没有选中行");
                return;
            }
            var configModel = jsonUtil.Items[index];
            jsonUtil.Delete(configModel);
            InitListView();
        }
    }
}
