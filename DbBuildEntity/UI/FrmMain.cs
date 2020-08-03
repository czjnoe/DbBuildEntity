using DbBuildEntity.Dal;
using DbBuildEntity.Interface;
using DbBuildEntity.Model;
using DbBuildEntity.Util;
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
        private List<string> templateList = new List<string>();
        private Dictionary<string, string> dbTypeDic = new Dictionary<string, string>();
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前选择目录
        /// </summary>
        private string _savePath = string.Empty;
        public FrmMain(string savePath)
        {
            InitializeComponent();
            _savePath = savePath;

            var dTypeList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DbTypeModel>>(File.ReadAllText(Global.dbTypeFullPath));
            dbTypeDic = dTypeList.ToDictionary(key => key.dbtype, value => value.cstype);
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
            var directory = new DirectoryInfo("");
            templateList = directory.GetFiles(Global.templatePath).Select(s => s.FullName).ToList();
        }

        private void InitIndex()
        {
            var items = jsonUtil.Items;
            this.cbbConfig.DisplayMember = "ConnName";
            this.cbbConfig.ValueMember = "Guid";
            this.cbbConfig.DataSource = items;

            this.tbNameSapce.Text = ConfigUtil.GetAppSettingValue("DefaultNameSpace", configPath: Global.appConfigFullPath);


        }

        private void InitTabConnfig()
        {
            this.tbConnString.Text = string.Empty;
            this.tbConnName.Text = string.Empty;

            var dbTypeDic = EnumUtil.GetEnum<DbBuildEntity.Util.Enums.DbType>();
            List<ComboBoxModel> connTypeList = dbTypeDic.Select(s => new ComboBoxModel { DisplayName = s.Key, Value = s.Value.ToString() }).ToList();

            this.cbbConnType.DisplayMember = "DisplayName";
            this.cbbConnType.ValueMember = "Value";
            this.cbbConnType.DataSource = connTypeList;
            InitListView();
        }
        JsonUtil jsonUtil = new JsonUtil();
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
            var model = GetConfigModel();
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
        }

        private ConfigModel GetConfigModel()
        {
            var connTypeValue = cbbConnType.SelectedValue.ToString();
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
            ConfigModel model = GetConfigModel();
            if (model.ConnType.IsNullOrEmpty() || model.ConnString.IsNullOrEmpty() || model.ConnName.IsNullOrEmpty())
            {
                UIMessageTip.ShowError("没有输入连接字符串、连接名或数据库类型", 1000, true);
                return;
            }
            model.Guid = Guid.NewGuid().ToString();
            jsonUtil.Add(model);
            InitListView();
        }

        private void tbNameSapce_TextChanged(object sender, EventArgs e)
        {
            ConfigUtil.SetAppSettingValue("DefaultNameSpace", this.tbNameSapce.Text.Trim(), configPath: Global.appConfigFullPath);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitIndex();
            InitTemplates();
        }

        /// <summary>
        /// ListView 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbConnName_ItemDoubleClick(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var index = Convert.ToInt32(this.cbbTemplate.SelectedValue);
            var templatePath = templateList[index];
            var configIndex = this.cbbConfig.SelectedIndex;
            var configModel = jsonUtil.Items[configIndex];

            IDbDal dal = null;
            if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.SqlServer).ToString())
            {
                dal = new SqlServerDal(DapperFactory.GetConnection(Enums.DbType.SqlServer, configModel.ConnString));
            }
            else if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.Oracle).ToString())
            {
                dal = new OracleDal(DapperFactory.GetConnection(Enums.DbType.SqlServer, configModel.ConnString));
            }
            else if (configModel.ConnType == ((int)DbBuildEntity.Util.Enums.DbType.MySQL).ToString())
            {

            }

            var tables = dal.GetTables();
            foreach (var table in tables)
            {
                var columnsList = dal.GetColumnList(table.TableName);
                foreach (var column in columnsList)
                {
                    string value = string.Empty;
                    var dResult=dbTypeDic.TryGetValue(column.TypeName, out value);
                    if (dResult)
                    {
                        column.TypeName = value;
                    }
                    else
                    {
                        column.TypeName = "object";
                    }
                }
                var buildContent = RazorBuildUtil.GetBuildContent(templatePath, columnsList, table);
                FileUtil.Save(buildContent, _savePath);
            }


        }
    }
}
