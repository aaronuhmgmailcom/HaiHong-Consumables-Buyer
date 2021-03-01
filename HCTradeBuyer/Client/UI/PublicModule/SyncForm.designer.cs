namespace Emedchina.TradeAssistant.Client.UI.PublicModule
{
    partial class SyncForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkUpload = new DevExpress.XtraEditors.CheckEdit();
            this.radioGroupSyncType = new DevExpress.XtraEditors.RadioGroup();
            this.msgLabel = new DevExpress.XtraEditors.LabelControl();
            this.SyncProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.lbrec = new DevExpress.XtraEditors.LabelControl();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.Bt_exit = new DevExpress.XtraEditors.SimpleButton();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.SyncBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.listView1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gridColumnItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRead = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpload.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSyncType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SyncProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkUpload);
            this.groupControl1.Controls.Add(this.radioGroupSyncType);
            this.groupControl1.Location = new System.Drawing.Point(31, 274);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(408, 64);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "同步类型";
            // 
            // chkUpload
            // 
            this.chkUpload.Location = new System.Drawing.Point(287, 32);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Properties.Caption = "上传本地数据";
            this.chkUpload.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkUpload.Size = new System.Drawing.Size(101, 22);
            this.chkUpload.TabIndex = 1;
            // 
            // radioGroupSyncType
            // 
            this.radioGroupSyncType.EditValue = "1";
            this.radioGroupSyncType.Location = new System.Drawing.Point(47, 27);
            this.radioGroupSyncType.Name = "radioGroupSyncType";
            this.radioGroupSyncType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupSyncType.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupSyncType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupSyncType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "全同步"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "增量同步")});
            this.radioGroupSyncType.Size = new System.Drawing.Size(216, 29);
            this.radioGroupSyncType.TabIndex = 0;
            // 
            // msgLabel
            // 
            this.msgLabel.Location = new System.Drawing.Point(31, 350);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(304, 14);
            this.msgLabel.TabIndex = 2;
            this.msgLabel.Text = "正在同步本地数据,这可能需要一段时间，请您耐心等待。";
            // 
            // SyncProgressBar
            // 
            this.SyncProgressBar.Location = new System.Drawing.Point(31, 374);
            this.SyncProgressBar.Name = "SyncProgressBar";
            this.SyncProgressBar.Size = new System.Drawing.Size(408, 25);
            this.SyncProgressBar.TabIndex = 3;
            // 
            // lbrec
            // 
            this.lbrec.Appearance.Options.UseTextOptions = true;
            this.lbrec.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbrec.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbrec.Location = new System.Drawing.Point(221, 352);
            this.lbrec.Name = "lbrec";
            this.lbrec.Size = new System.Drawing.Size(218, 14);
            this.lbrec.TabIndex = 2;
            this.lbrec.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Options.UseTextOptions = true;
            this.lblTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTime.Location = new System.Drawing.Point(36, 405);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 14);
            this.lblTime.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(269, 414);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(82, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "确定";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Bt_exit
            // 
            this.Bt_exit.Location = new System.Drawing.Point(357, 414);
            this.Bt_exit.Name = "Bt_exit";
            this.Bt_exit.Size = new System.Drawing.Size(82, 23);
            this.Bt_exit.TabIndex = 4;
            this.Bt_exit.Text = "关闭";
            this.Bt_exit.Click += new System.EventHandler(this.Bt_exit_Click);
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // SyncBackgroundWorker
            // 
            this.SyncBackgroundWorker.WorkerReportsProgress = true;
            this.SyncBackgroundWorker.WorkerSupportsCancellation = true;
            this.SyncBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SyncBackgroundWorker_DoWork);
            this.SyncBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SyncBackgroundWorker_RunWorkerCompleted);
            this.SyncBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SyncBackgroundWorker_ProgressChanged);
            // 
            // listView1
            // 
            this.listView1.EmbeddedNavigator.Name = "";
            gridLevelNode2.RelationName = "Level1";
            this.listView1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.listView1.Location = new System.Drawing.Point(31, 27);
            this.listView1.MainView = this.gridView1;
            this.listView1.Name = "listView1";
            this.listView1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.listView1.Size = new System.Drawing.Size(408, 241);
            this.listView1.TabIndex = 5;
            this.listView1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnImage,
            this.gridColumnItem,
            this.gridColumnCount,
            this.gridColumnTime,
            this.gridColumnTable,
            this.gridColumnLog,
            this.gridColumnRead});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.listView1;
            this.gridView1.Images = this.imageList1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowVertLines = false;
            // 
            // gridColumnImage
            // 
            this.gridColumnImage.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnImage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnImage.Caption = "image";
            this.gridColumnImage.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumnImage.FieldName = "image";
            this.gridColumnImage.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumnImage.ImageIndex = 7;
            this.gridColumnImage.Name = "gridColumnImage";
            this.gridColumnImage.OptionsColumn.AllowEdit = false;
            this.gridColumnImage.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnImage.OptionsColumn.AllowMove = false;
            this.gridColumnImage.OptionsColumn.AllowSize = false;
            this.gridColumnImage.OptionsColumn.ReadOnly = true;
            this.gridColumnImage.Visible = true;
            this.gridColumnImage.VisibleIndex = 0;
            this.gridColumnImage.Width = 37;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "2", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "3", 3)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "star.ico");
            this.imageList1.Images.SetKeyName(1, "forward.ico");
            this.imageList1.Images.SetKeyName(2, "ok.ico");
            this.imageList1.Images.SetKeyName(3, "delete.ico");
            this.imageList1.Images.SetKeyName(4, "Bitmap Image.ico");
            this.imageList1.Images.SetKeyName(5, "20061121210008149.png");
            this.imageList1.Images.SetKeyName(6, "20061121210009444.png");
            this.imageList1.Images.SetKeyName(7, "refresh.png");
            this.imageList1.Images.SetKeyName(8, "flag.png");
            // 
            // gridColumnItem
            // 
            this.gridColumnItem.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnItem.Caption = "同步项目";
            this.gridColumnItem.FieldName = "item";
            this.gridColumnItem.Name = "gridColumnItem";
            this.gridColumnItem.OptionsColumn.AllowEdit = false;
            this.gridColumnItem.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnItem.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumnItem.OptionsColumn.AllowSize = false;
            this.gridColumnItem.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnItem.OptionsColumn.ReadOnly = true;
            this.gridColumnItem.OptionsFilter.AllowFilter = false;
            this.gridColumnItem.Visible = true;
            this.gridColumnItem.VisibleIndex = 1;
            this.gridColumnItem.Width = 176;
            // 
            // gridColumnCount
            // 
            this.gridColumnCount.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnCount.Caption = "数据量";
            this.gridColumnCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCount.FieldName = "count";
            this.gridColumnCount.Name = "gridColumnCount";
            this.gridColumnCount.OptionsColumn.AllowEdit = false;
            this.gridColumnCount.OptionsColumn.AllowSize = false;
            this.gridColumnCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnCount.OptionsColumn.ReadOnly = true;
            this.gridColumnCount.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnCount.OptionsFilter.AllowFilter = false;
            this.gridColumnCount.Tag = "1";
            this.gridColumnCount.Visible = true;
            this.gridColumnCount.VisibleIndex = 2;
            this.gridColumnCount.Width = 96;
            // 
            // gridColumnTime
            // 
            this.gridColumnTime.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumnTime.Caption = "耗时";
            this.gridColumnTime.FieldName = "time";
            this.gridColumnTime.Name = "gridColumnTime";
            this.gridColumnTime.OptionsColumn.AllowEdit = false;
            this.gridColumnTime.OptionsColumn.AllowSize = false;
            this.gridColumnTime.OptionsColumn.ReadOnly = true;
            this.gridColumnTime.Width = 74;
            // 
            // gridColumnTable
            // 
            this.gridColumnTable.Caption = "表名";
            this.gridColumnTable.Name = "gridColumnTable";
            this.gridColumnTable.OptionsColumn.AllowEdit = false;
            // 
            // gridColumnLog
            // 
            this.gridColumnLog.Caption = "log";
            this.gridColumnLog.FieldName = "log";
            this.gridColumnLog.Name = "gridColumnLog";
            // 
            // gridColumnRead
            // 
            this.gridColumnRead.Caption = "read";
            this.gridColumnRead.FieldName = "read";
            this.gridColumnRead.Name = "gridColumnRead";
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 456);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Bt_exit);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.SyncProgressBar);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lbrec);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.groupControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海虹医疗器械电子商务耗材交易系统--数据同步";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SyncForm_FormClosing);
            this.Load += new System.EventHandler(this.SyncForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkUpload.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSyncType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SyncProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroupSyncType;
        private DevExpress.XtraEditors.LabelControl msgLabel;
        private DevExpress.XtraEditors.ProgressBarControl SyncProgressBar;
        private DevExpress.XtraEditors.LabelControl lbrec;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton Bt_exit;
        private System.Windows.Forms.Timer progressTimer;
        private System.ComponentModel.BackgroundWorker SyncBackgroundWorker;
        private DevExpress.XtraGrid.GridControl listView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLog;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRead;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.CheckEdit chkUpload;

    }
}