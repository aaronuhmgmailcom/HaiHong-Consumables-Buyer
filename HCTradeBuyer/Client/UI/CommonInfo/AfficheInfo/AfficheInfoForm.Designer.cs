namespace Emedchina.TradeAssistant.Client.UI.CommonInfo
{
    partial class AfficheInfoForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvAfficheInfo = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gviewAfficheInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_Title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_ReadName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_Issuer_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_Issue_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_IS_READ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_ReceiverId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.LueState = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControlCount = new DevExpress.XtraEditors.LabelControl();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAfficheInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewAfficheInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LueState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gvAfficheInfo;
            this.gridView4.Name = "gridView4";
            // 
            // gvAfficheInfo
            // 
            this.gvAfficheInfo.DataSource = this.bindingSource1;
            this.gvAfficheInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAfficheInfo.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.gridView4;
            gridLevelNode1.RelationName = "Level1";
            this.gvAfficheInfo.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gvAfficheInfo.Location = new System.Drawing.Point(2, 21);
            this.gvAfficheInfo.MainView = this.gviewAfficheInfo;
            this.gvAfficheInfo.Name = "gvAfficheInfo";
            this.gvAfficheInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gvAfficheInfo.Size = new System.Drawing.Size(742, 373);
            this.gvAfficheInfo.TabIndex = 8;
            this.gvAfficheInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewAfficheInfo,
            this.gridView1,
            this.gridView2,
            this.gridView4});
            // 
            // gviewAfficheInfo
            // 
            this.gviewAfficheInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_ID,
            this.Col_Title,
            this.Col_ReadName,
            this.Col_Issuer_Name,
            this.Col_Issue_Date,
            this.Col_IS_READ,
            this.Col_ReceiverId,
            this.gridColumn8});
            this.gviewAfficheInfo.CustomizationFormBounds = new System.Drawing.Rectangle(508, 436, 208, 177);
            this.gviewAfficheInfo.GridControl = this.gvAfficheInfo;
            this.gviewAfficheInfo.IndicatorWidth = 30;
            this.gviewAfficheInfo.Name = "gviewAfficheInfo";
            this.gviewAfficheInfo.OptionsView.ColumnAutoWidth = false;
            this.gviewAfficheInfo.OptionsView.ShowGroupPanel = false;
            this.gviewAfficheInfo.Click += new System.EventHandler(this.gviewAfficheInfo_Click);
            this.gviewAfficheInfo.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gviewAfficheInfo_CustomDrawRowIndicator);
            this.gviewAfficheInfo.RowCountChanged += new System.EventHandler(this.gviewAfficheInfo_RowCountChanged);
            this.gviewAfficheInfo.DoubleClick += new System.EventHandler(this.btnView_Click);
            // 
            // Col_ID
            // 
            this.Col_ID.Caption = "ID";
            this.Col_ID.FieldName = "ID";
            this.Col_ID.Name = "Col_ID";
            this.Col_ID.OptionsColumn.AllowEdit = false;
            // 
            // Col_Title
            // 
            this.Col_Title.Caption = "公告标题";
            this.Col_Title.FieldName = "Title";
            this.Col_Title.MinWidth = 100;
            this.Col_Title.Name = "Col_Title";
            this.Col_Title.OptionsColumn.AllowEdit = false;
            this.Col_Title.Visible = true;
            this.Col_Title.VisibleIndex = 0;
            this.Col_Title.Width = 300;
            // 
            // Col_ReadName
            // 
            this.Col_ReadName.Caption = "状态";
            this.Col_ReadName.FieldName = "ReadName";
            this.Col_ReadName.Name = "Col_ReadName";
            this.Col_ReadName.OptionsColumn.AllowEdit = false;
            this.Col_ReadName.Visible = true;
            this.Col_ReadName.VisibleIndex = 1;
            this.Col_ReadName.Width = 100;
            // 
            // Col_Issuer_Name
            // 
            this.Col_Issuer_Name.Caption = "发信人";
            this.Col_Issuer_Name.FieldName = "ISSUER_NAME";
            this.Col_Issuer_Name.Name = "Col_Issuer_Name";
            this.Col_Issuer_Name.OptionsColumn.AllowEdit = false;
            this.Col_Issuer_Name.Visible = true;
            this.Col_Issuer_Name.VisibleIndex = 2;
            this.Col_Issuer_Name.Width = 120;
            // 
            // Col_Issue_Date
            // 
            this.Col_Issue_Date.Caption = "发信时间";
            this.Col_Issue_Date.FieldName = "ISSUE_DATE";
            this.Col_Issue_Date.Name = "Col_Issue_Date";
            this.Col_Issue_Date.OptionsColumn.AllowEdit = false;
            this.Col_Issue_Date.Visible = true;
            this.Col_Issue_Date.VisibleIndex = 3;
            this.Col_Issue_Date.Width = 130;
            // 
            // Col_IS_READ
            // 
            this.Col_IS_READ.Caption = "状态";
            this.Col_IS_READ.FieldName = "IS_READ";
            this.Col_IS_READ.Name = "Col_IS_READ";
            this.Col_IS_READ.OptionsColumn.AllowEdit = false;
            // 
            // Col_ReceiverId
            // 
            this.Col_ReceiverId.Caption = "接收信息用户表ID";
            this.Col_ReceiverId.FieldName = "ReceiverId";
            this.Col_ReceiverId.Name = "Col_ReceiverId";
            this.Col_ReceiverId.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ReceiverID";
            this.gridColumn8.FieldName = "ReceiverID";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn7});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(508, 436, 208, 177);
            this.gridView1.GridControl = this.gvAfficheInfo;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "订单编号";
            this.gridColumn1.FieldName = "order_code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 115;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "卖方企业";
            this.gridColumn2.FieldName = "saler_name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "发送时间";
            this.gridColumn3.FieldName = "create_date";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.Caption = "订购金额(元)";
            this.gridColumn4.FieldName = "Request_Total";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 82;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "创建人";
            this.gridColumn6.FieldName = "Create_Username";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 48;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "订单状态";
            this.gridColumn5.FieldName = "Order_State";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 60;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "订单编号";
            this.gridColumn7.FieldName = "order_code";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gvAfficheInfo;
            this.gridView2.Name = "gridView2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlBottom, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 483);
            this.toolTipController1.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.simpleButton1);
            this.pnlTop.Controls.Add(this.LueState);
            this.pnlTop.Controls.Add(this.labelControl2);
            this.pnlTop.Controls.Add(this.txtTitle);
            this.pnlTop.Controls.Add(this.labelControl1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(746, 34);
            this.toolTipController1.SetSuperTip(this.pnlTop, null);
            this.pnlTop.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(666, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "查询(&Q)";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // LueState
            // 
            this.LueState.Location = new System.Drawing.Point(243, 8);
            this.LueState.Name = "LueState";
            this.LueState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LueState.Size = new System.Drawing.Size(100, 21);
            this.LueState.TabIndex = 8;
            this.LueState.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(201, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "状态：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(86, 8);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 21);
            this.txtTitle.TabIndex = 6;
            this.txtTitle.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "公告标题：";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(3, 445);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(746, 35);
            this.toolTipController1.SetSuperTip(this.pnlBottom, null);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(585, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "查看(&V)";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(666, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControlCount);
            this.groupControl1.Controls.Add(this.gvAfficheInfo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 43);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(746, 396);
            this.toolTipController1.SetSuperTip(this.groupControl1, null);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "公告列表";
            // 
            // labelControlCount
            // 
            this.labelControlCount.Location = new System.Drawing.Point(71, 3);
            this.labelControlCount.Name = "labelControlCount";
            this.labelControlCount.Size = new System.Drawing.Size(0, 14);
            this.labelControlCount.TabIndex = 9;
            // 
            // AfficheInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 483);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AfficheInfoForm";
            this.toolTipController1.SetSuperTip(this, null);
            this.Text = "公告信息";
            this.Load += new System.EventHandler(this.AfficheInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAfficheInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewAfficheInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LueState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LookUpEdit LueState;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gvAfficheInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewAfficheInfo;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Title;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ReadName;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Issuer_Name;
        private DevExpress.XtraGrid.Columns.GridColumn Col_Issue_Date;
        private DevExpress.XtraGrid.Columns.GridColumn Col_IS_READ;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ReceiverId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.LabelControl labelControlCount;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;


    }
}