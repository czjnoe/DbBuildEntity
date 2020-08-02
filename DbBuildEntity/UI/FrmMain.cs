using DbBuildEntity.Model;
using DbBuildEntity.Util;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbBuildEntity.UI
{
    public partial class FrmMain : UIForm
    {
        public FrmMain()
        {
            InitializeComponent();
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
                    break;
                case 1:
                    InitTabConnfig();
                    break;
                case 2:
                    break;
            }
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
            var model=GetConfigModel();
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
            if (model.ConnType.IsNullOrEmpty()|| model.ConnString.IsNullOrEmpty()|| model.ConnName.IsNullOrEmpty())
            {
                UIMessageTip.ShowError("没有输入连接字符串、连接名或数据库类型", 1000, true);
                return;
            }
            model.Guid = Guid.NewGuid().ToString();
            jsonUtil.Add(model);
            InitListView();
        }
    }
}
