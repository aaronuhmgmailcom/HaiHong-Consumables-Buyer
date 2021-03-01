namespace Emedchina.TradeAssistant.Client
{
    partial class LoginFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.userNameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.passwordErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageCommon = new DevExpress.XtraTab.XtraTabPage();
            this.userNameTextBox = new DevExpress.XtraEditors.TextEdit();
            this.cmbUser = new DevExpress.XtraEditors.ComboBoxEdit();
            this.passwordTextBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfig = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageKey = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButtonLogin = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonConfig = new DevExpress.XtraEditors.SimpleButton();
            this.textEditUser = new DevExpress.XtraEditors.TextEdit();
            this.textEditPin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblVerson = new System.Windows.Forms.Label();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.errorProviderUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPin = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerLogin = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userNameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordErrorProvider)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextBox.Properties)).BeginInit();
            this.xtraTabPageKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPin)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameErrorProvider
            // 
            this.userNameErrorProvider.ContainerControl = this;
            // 
            // passwordErrorProvider
            // 
            this.passwordErrorProvider.ContainerControl = this;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "Help.chm";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.lg;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.xtraTabControl1);
            this.mainPanel.Controls.Add(this.lblVerson);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider1.SetHelpNavigator(this.mainPanel, System.Windows.Forms.HelpNavigator.Index);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.helpProvider1.SetShowHelp(this.mainPanel, true);
            this.mainPanel.Size = new System.Drawing.Size(703, 398);
            this.mainPanel.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(376, 193);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageCommon;
            this.xtraTabControl1.Size = new System.Drawing.Size(319, 196);
            this.xtraTabControl1.TabIndex = 13;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageCommon,
            this.xtraTabPageKey});
            this.xtraTabControl1.Text = "登录";
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPageCommon
            // 
            this.xtraTabPageCommon.Controls.Add(this.userNameTextBox);
            this.xtraTabPageCommon.Controls.Add(this.cmbUser);
            this.xtraTabPageCommon.Controls.Add(this.passwordTextBox);
            this.xtraTabPageCommon.Controls.Add(this.labelControl2);
            this.xtraTabPageCommon.Controls.Add(this.btnLogin);
            this.xtraTabPageCommon.Controls.Add(this.labelControl1);
            this.xtraTabPageCommon.Controls.Add(this.btnCancel);
            this.xtraTabPageCommon.Controls.Add(this.btnConfig);
            this.xtraTabPageCommon.Name = "xtraTabPageCommon";
            this.xtraTabPageCommon.Size = new System.Drawing.Size(310, 165);
            this.xtraTabPageCommon.Text = "普通登录";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(107, 34);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(147, 21);
            this.userNameTextBox.TabIndex = 12;
            // 
            // cmbUser
            // 
            this.cmbUser.Location = new System.Drawing.Point(107, 34);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUser.Size = new System.Drawing.Size(145, 21);
            this.cmbUser.TabIndex = 7;
            this.cmbUser.Visible = false;
            this.cmbUser.Leave += new System.EventHandler(this.cmbUser_Leave);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.EditValue = "";
            this.passwordTextBox.Location = new System.Drawing.Point(107, 77);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Properties.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(147, 21);
            this.passwordTextBox.TabIndex = 8;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(43, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "密  码：";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(34, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(43, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "用户名：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(215, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.cancleBtn_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(125, 131);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 9;
            this.btnConfig.Text = "配置";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // xtraTabPageKey
            // 
            this.xtraTabPageKey.Controls.Add(this.simpleButtonLogin);
            this.xtraTabPageKey.Controls.Add(this.simpleButtonCancel);
            this.xtraTabPageKey.Controls.Add(this.simpleButtonConfig);
            this.xtraTabPageKey.Controls.Add(this.textEditUser);
            this.xtraTabPageKey.Controls.Add(this.textEditPin);
            this.xtraTabPageKey.Controls.Add(this.labelControl3);
            this.xtraTabPageKey.Controls.Add(this.labelControl4);
            this.xtraTabPageKey.Name = "xtraTabPageKey";
            this.xtraTabPageKey.Size = new System.Drawing.Size(310, 165);
            this.xtraTabPageKey.Text = "ｋｅｙ登录";
            // 
            // simpleButtonLogin
            // 
            this.simpleButtonLogin.Location = new System.Drawing.Point(34, 131);
            this.simpleButtonLogin.Name = "simpleButtonLogin";
            this.simpleButtonLogin.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonLogin.TabIndex = 18;
            this.simpleButtonLogin.Text = "登录";
            this.simpleButtonLogin.Click += new System.EventHandler(this.simpleButtonLogin_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(215, 131);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 17;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.cancleBtn_Click);
            // 
            // simpleButtonConfig
            // 
            this.simpleButtonConfig.Location = new System.Drawing.Point(125, 131);
            this.simpleButtonConfig.Name = "simpleButtonConfig";
            this.simpleButtonConfig.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonConfig.TabIndex = 16;
            this.simpleButtonConfig.Text = "配置";
            this.simpleButtonConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // textEditUser
            // 
            this.textEditUser.Location = new System.Drawing.Point(107, 34);
            this.textEditUser.Name = "textEditUser";
            this.textEditUser.Properties.ReadOnly = true;
            this.textEditUser.Size = new System.Drawing.Size(147, 21);
            this.textEditUser.TabIndex = 15;
            // 
            // textEditPin
            // 
            this.textEditPin.EditValue = "";
            this.textEditPin.Location = new System.Drawing.Point(107, 77);
            this.textEditPin.Name = "textEditPin";
            this.textEditPin.Properties.PasswordChar = '*';
            this.textEditPin.Size = new System.Drawing.Size(147, 21);
            this.textEditPin.TabIndex = 14;
            this.textEditPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEditPin_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(43, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "PIN码：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(43, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "用户名：";
            // 
            // lblVerson
            // 
            this.lblVerson.AutoSize = true;
            this.lblVerson.BackColor = System.Drawing.Color.Transparent;
            this.lblVerson.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblVerson.Location = new System.Drawing.Point(419, 93);
            this.lblVerson.Name = "lblVerson";
            this.lblVerson.Size = new System.Drawing.Size(38, 14);
            this.lblVerson.TabIndex = 6;
            this.lblVerson.Text = "label1";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            // 
            // errorProviderUser
            // 
            this.errorProviderUser.ContainerControl = this;
            // 
            // errorProviderPin
            // 
            this.errorProviderPin.ContainerControl = this;
            // 
            // timerLogin
            // 
            this.timerLogin.Interval = 3000;
            this.timerLogin.Tick += new System.EventHandler(this.timerLogin_Tick);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 398);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.helpProvider1.SetHelpString(this, "");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Money Twins";
            this.MaximizeBox = false;
            this.Name = "LoginFrm";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海虹医疗器械电子商务耗材交易系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginFrm_FormClosing);
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userNameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordErrorProvider)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageCommon.ResumeLayout(false);
            this.xtraTabPageCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextBox.Properties)).EndInit();
            this.xtraTabPageKey.ResumeLayout(false);
            this.xtraTabPageKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider userNameErrorProvider;
        private System.Windows.Forms.ErrorProvider passwordErrorProvider;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblVerson;
        private DevExpress.XtraEditors.TextEdit passwordTextBox;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConfig;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit userNameTextBox;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCommon;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageKey;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLogin;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonConfig;
        private DevExpress.XtraEditors.TextEdit textEditUser;
        private DevExpress.XtraEditors.TextEdit textEditPin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ErrorProvider errorProviderUser;
        private System.Windows.Forms.ErrorProvider errorProviderPin;
        private System.Windows.Forms.Timer timerLogin;

    }
}