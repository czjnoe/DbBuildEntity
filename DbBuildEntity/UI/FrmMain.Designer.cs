namespace DbBuildEntity.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbbTemplate = new Sunny.UI.UIComboBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.tbNameSapce = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.cbbConfig = new Sunny.UI.UIComboBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btnConnSave = new Sunny.UI.UIButton();
            this.btnConnTest = new Sunny.UI.UIButton();
            this.tbConnString = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cbbConnType = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tbConnName = new Sunny.UI.UITextBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.lbConnName = new Sunny.UI.UIListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiPanel3 = new Sunny.UI.UIPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Controls.Add(this.tabPage3);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 35);
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(886, 445);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.SelectedIndexChanged += new System.EventHandler(this.uiTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbbTemplate);
            this.tabPage1.Controls.Add(this.uiLabel9);
            this.tabPage1.Controls.Add(this.uiButton1);
            this.tabPage1.Controls.Add(this.tbNameSapce);
            this.tabPage1.Controls.Add(this.uiLabel5);
            this.tabPage1.Controls.Add(this.cbbConfig);
            this.tabPage1.Controls.Add(this.uiLabel4);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(886, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "首页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbbTemplate
            // 
            this.cbbTemplate.FillColor = System.Drawing.Color.White;
            this.cbbTemplate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbbTemplate.Location = new System.Drawing.Point(173, 198);
            this.cbbTemplate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbTemplate.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbTemplate.Name = "cbbTemplate";
            this.cbbTemplate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cbbTemplate.Size = new System.Drawing.Size(360, 34);
            this.cbbTemplate.TabIndex = 6;
            this.cbbTemplate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.AutoSize = true;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel9.Location = new System.Drawing.Point(44, 205);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(57, 27);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 5;
            this.uiLabel9.Text = "模板:";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(173, 275);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "生成";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // tbNameSapce
            // 
            this.tbNameSapce.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNameSapce.FillColor = System.Drawing.Color.White;
            this.tbNameSapce.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbNameSapce.Location = new System.Drawing.Point(173, 119);
            this.tbNameSapce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNameSapce.Maximum = 2147483647D;
            this.tbNameSapce.Minimum = -2147483648D;
            this.tbNameSapce.Name = "tbNameSapce";
            this.tbNameSapce.Padding = new System.Windows.Forms.Padding(5);
            this.tbNameSapce.Size = new System.Drawing.Size(360, 34);
            this.tbNameSapce.TabIndex = 3;
            this.tbNameSapce.TextChanged += new System.EventHandler(this.tbNameSapce_TextChanged);
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(44, 119);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(97, 27);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 2;
            this.uiLabel5.Text = "命名空间:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbConfig
            // 
            this.cbbConfig.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbbConfig.FillColor = System.Drawing.Color.White;
            this.cbbConfig.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbbConfig.Location = new System.Drawing.Point(173, 39);
            this.cbbConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbConfig.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbConfig.Name = "cbbConfig";
            this.cbbConfig.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cbbConfig.Size = new System.Drawing.Size(360, 34);
            this.cbbConfig.TabIndex = 1;
            this.cbbConfig.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(44, 39);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(57, 27);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "配置:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.uiPanel2);
            this.tabPage2.Controls.Add(this.uiPanel1);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(886, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.btnConnSave);
            this.uiPanel2.Controls.Add(this.btnConnTest);
            this.uiPanel2.Controls.Add(this.tbConnString);
            this.uiPanel2.Controls.Add(this.uiLabel3);
            this.uiPanel2.Controls.Add(this.cbbConnType);
            this.uiPanel2.Controls.Add(this.uiLabel2);
            this.uiPanel2.Controls.Add(this.uiLabel1);
            this.uiPanel2.Controls.Add(this.tbConnName);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(208, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(678, 405);
            this.uiPanel2.TabIndex = 10;
            this.uiPanel2.Text = null;
            // 
            // btnConnSave
            // 
            this.btnConnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConnSave.Location = new System.Drawing.Point(158, 289);
            this.btnConnSave.Name = "btnConnSave";
            this.btnConnSave.Size = new System.Drawing.Size(100, 35);
            this.btnConnSave.TabIndex = 15;
            this.btnConnSave.Text = "Save";
            this.btnConnSave.Click += new System.EventHandler(this.btnConnSave_Click);
            // 
            // btnConnTest
            // 
            this.btnConnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnTest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnConnTest.Location = new System.Drawing.Point(439, 219);
            this.btnConnTest.Name = "btnConnTest";
            this.btnConnTest.Size = new System.Drawing.Size(100, 35);
            this.btnConnTest.TabIndex = 14;
            this.btnConnTest.Text = "Test";
            this.btnConnTest.Click += new System.EventHandler(this.btnConnTest_Click);
            // 
            // tbConnString
            // 
            this.tbConnString.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConnString.FillColor = System.Drawing.Color.White;
            this.tbConnString.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbConnString.Location = new System.Drawing.Point(158, 134);
            this.tbConnString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConnString.Maximum = 2147483647D;
            this.tbConnString.Minimum = -2147483648D;
            this.tbConnString.Name = "tbConnString";
            this.tbConnString.Padding = new System.Windows.Forms.Padding(5);
            this.tbConnString.Size = new System.Drawing.Size(457, 34);
            this.tbConnString.TabIndex = 13;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(16, 134);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(130, 27);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 12;
            this.uiLabel3.Text = "Conn String:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbConnType
            // 
            this.cbbConnType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbbConnType.FillColor = System.Drawing.Color.White;
            this.cbbConnType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbbConnType.Location = new System.Drawing.Point(158, 43);
            this.cbbConnType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbConnType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbConnType.Name = "cbbConnType";
            this.cbbConnType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cbbConnType.Size = new System.Drawing.Size(256, 34);
            this.cbbConnType.TabIndex = 11;
            this.cbbConnType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(16, 43);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(119, 27);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 10;
            this.uiLabel2.Text = "Conn Type:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(16, 226);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(130, 27);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 9;
            this.uiLabel1.Text = "Conn Name:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbConnName
            // 
            this.tbConnName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbConnName.FillColor = System.Drawing.Color.White;
            this.tbConnName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbConnName.Location = new System.Drawing.Point(158, 218);
            this.tbConnName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConnName.Maximum = 2147483647D;
            this.tbConnName.Minimum = -2147483648D;
            this.tbConnName.Name = "tbConnName";
            this.tbConnName.Padding = new System.Windows.Forms.Padding(5);
            this.tbConnName.Size = new System.Drawing.Size(256, 34);
            this.tbConnName.TabIndex = 8;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.lbConnName);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(208, 405);
            this.uiPanel1.TabIndex = 9;
            this.uiPanel1.Text = null;
            // 
            // lbConnName
            // 
            this.lbConnName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConnName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbConnName.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.lbConnName.Location = new System.Drawing.Point(0, 0);
            this.lbConnName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbConnName.Name = "lbConnName";
            this.lbConnName.Padding = new System.Windows.Forms.Padding(2);
            this.lbConnName.Size = new System.Drawing.Size(208, 405);
            this.lbConnName.TabIndex = 8;
            this.lbConnName.Text = "uiListBox1";
            this.lbConnName.ItemDoubleClick += new System.EventHandler(this.lbConnName_ItemDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uiPanel3);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(886, 405);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.uiGroupBox1);
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel3.Location = new System.Drawing.Point(0, 0);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(886, 405);
            this.uiPanel3.TabIndex = 0;
            this.uiPanel3.Text = null;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiLabel8);
            this.uiGroupBox1.Controls.Add(this.uiLinkLabel1);
            this.uiGroupBox1.Controls.Add(this.uiLabel7);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(886, 147);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "作者";
            // 
            // uiLabel8
            // 
            this.uiLabel8.AutoSize = true;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(166, 53);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(112, 27);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 3;
            this.uiLabel8.Text = "秋雨雁南飞";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLinkLabel1
            // 
            this.uiLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.uiLinkLabel1.AutoSize = true;
            this.uiLinkLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLinkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.uiLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLinkLabel1.Location = new System.Drawing.Point(166, 96);
            this.uiLinkLabel1.Name = "uiLinkLabel1";
            this.uiLinkLabel1.Size = new System.Drawing.Size(400, 27);
            this.uiLinkLabel1.TabIndex = 2;
            this.uiLinkLabel1.TabStop = true;
            this.uiLinkLabel1.Text = "https://github.com/czjnoe/DbBuildEntity";
            this.uiLinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // uiLabel7
            // 
            this.uiLabel7.AutoSize = true;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(44, 96);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(96, 27);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 1;
            this.uiLabel7.Text = "Github：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.AutoSize = true;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(44, 53);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(57, 27);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 0;
            this.uiLabel6.Text = "姓名:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 480);
            this.Controls.Add(this.uiTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.Text = "自动生成实体";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2.PerformLayout();
            this.uiPanel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.uiPanel3.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIButton btnConnSave;
        private Sunny.UI.UIButton btnConnTest;
        private Sunny.UI.UITextBox tbConnString;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox cbbConnType;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox tbConnName;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIListBox lbConnName;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox tbNameSapce;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIComboBox cbbConfig;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIComboBox cbbTemplate;
        private Sunny.UI.UILabel uiLabel9;
    }
}