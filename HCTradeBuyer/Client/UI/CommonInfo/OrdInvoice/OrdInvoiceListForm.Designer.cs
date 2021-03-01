namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdInvoice
{
    partial class OrdInvoiceListForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.LueState = new DevExpress.XtraEditors.LookUpEdit();
            this.EndDate = new DevExpress.XtraEditors.DateEdit();
            this.StartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSendedName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtInvoiceCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btnFound = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnBlank = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewReceiveList = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControlCount = new DevExpress.XtraEditors.LabelControl();
            this.GridInvoiceList = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gvInvoiceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_INVOICE_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_SENDED_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_CREATE_USER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_SENDED_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_TOTAL_SUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_OVER_SUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Col_StateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SelChe = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.MeReturnRes = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LueState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendedName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridInvoiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelChe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeReturnRes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 474);
            this.toolTipController1.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.LueState);
            this.panelControl1.Controls.Add(this.EndDate);
            this.panelControl1.Controls.Add(this.StartDate);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.txtSendedName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtInvoiceCode);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.btnFound);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(697, 59);
            this.toolTipController1.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(614, 31);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // LueState
            // 
            this.LueState.Location = new System.Drawing.Point(98, 5);
            this.LueState.Name = "LueState";
            this.LueState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LueState.Size = new System.Drawing.Size(100, 21);
            this.LueState.TabIndex = 98;
            this.LueState.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // EndDate
            // 
            this.EndDate.EditValue = null;
            this.EndDate.Location = new System.Drawing.Point(233, 31);
            this.EndDate.Name = "EndDate";
            this.EndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.EndDate.Size = new System.Drawing.Size(100, 21);
            this.EndDate.TabIndex = 96;
            this.EndDate.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // StartDate
            // 
            this.StartDate.EditValue = null;
            this.StartDate.Location = new System.Drawing.Point(98, 31);
            this.StartDate.Name = "StartDate";
            this.StartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.StartDate.Size = new System.Drawing.Size(100, 21);
            this.StartDate.TabIndex = 97;
            this.StartDate.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(210, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(12, 14);
            this.labelControl5.TabIndex = 94;
            this.labelControl5.Text = "至";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(20, 34);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 14);
            this.labelControl7.TabIndex = 95;
            this.labelControl7.Text = "发送日期从：";
            // 
            // txtSendedName
            // 
            this.txtSendedName.Location = new System.Drawing.Point(420, 6);
            this.txtSendedName.Name = "txtSendedName";
            this.txtSendedName.Size = new System.Drawing.Size(97, 21);
            this.txtSendedName.TabIndex = 93;
            this.txtSendedName.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(354, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 92;
            this.labelControl2.Text = "发货单位：";
            // 
            // txtInvoiceCode
            // 
            this.txtInvoiceCode.Location = new System.Drawing.Point(420, 31);
            this.txtInvoiceCode.Name = "txtInvoiceCode";
            this.txtInvoiceCode.Size = new System.Drawing.Size(98, 21);
            this.txtInvoiceCode.TabIndex = 91;
            this.txtInvoiceCode.TextChanged += new System.EventHandler(this.Found_TextChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(344, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 14);
            this.labelControl6.TabIndex = 90;
            this.labelControl6.Text = "发货单编码：";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(20, 9);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(72, 14);
            this.labelControl11.TabIndex = 90;
            this.labelControl11.Text = "发货单状态：";
            // 
            // btnFound
            // 
            this.btnFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFound.Location = new System.Drawing.Point(533, 31);
            this.btnFound.Name = "btnFound";
            this.btnFound.Size = new System.Drawing.Size(75, 23);
            this.btnFound.TabIndex = 0;
            this.btnFound.Text = "查询(&Q)";
            this.btnFound.Click += new System.EventHandler(this.btnFound_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnBlank);
            this.panelControl2.Controls.Add(this.btnViewReceiveList);
            this.panelControl2.Controls.Add(this.btnViewItem);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 437);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(697, 34);
            this.toolTipController1.SetSuperTip(this.panelControl2, null);
            this.panelControl2.TabIndex = 1;
            // 
            // btnBlank
            // 
            this.btnBlank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlank.Location = new System.Drawing.Point(500, 6);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(92, 23);
            this.btnBlank.TabIndex = 3;
            this.btnBlank.Text = "作废(&B)";
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // btnViewReceiveList
            // 
            this.btnViewReceiveList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewReceiveList.Location = new System.Drawing.Point(402, 6);
            this.btnViewReceiveList.Name = "btnViewReceiveList";
            this.btnViewReceiveList.Size = new System.Drawing.Size(92, 23);
            this.btnViewReceiveList.TabIndex = 2;
            this.btnViewReceiveList.Text = "到货(&T)";
            this.btnViewReceiveList.Click += new System.EventHandler(this.btnViewReceiveList_Click);
            // 
            // btnViewItem
            // 
            this.btnViewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewItem.Location = new System.Drawing.Point(304, 6);
            this.btnViewItem.Name = "btnViewItem";
            this.btnViewItem.Size = new System.Drawing.Size(92, 23);
            this.btnViewItem.TabIndex = 1;
            this.btnViewItem.Text = "查看(&V)";
            this.btnViewItem.Click += new System.EventHandler(this.btnViewItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(596, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControlCount);
            this.groupControl1.Controls.Add(this.GridInvoiceList);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 68);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(697, 363);
            this.toolTipController1.SetSuperTip(this.groupControl1, null);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "发货单列表";
            // 
            // labelControlCount
            // 
            this.labelControlCount.Location = new System.Drawing.Point(92, 3);
            this.labelControlCount.Name = "labelControlCount";
            this.labelControlCount.Size = new System.Drawing.Size(0, 14);
            this.labelControlCount.TabIndex = 5;
            // 
            // GridInvoiceList
            // 
            this.GridInvoiceList.DataSource = this.bindingSource1;
            this.GridInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridInvoiceList.EmbeddedNavigator.Name = "";
            this.GridInvoiceList.Location = new System.Drawing.Point(2, 21);
            this.GridInvoiceList.MainView = this.gvInvoiceList;
            this.GridInvoiceList.Name = "GridInvoiceList";
            this.GridInvoiceList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.SelChe,
            this.MeReturnRes});
            this.GridInvoiceList.Size = new System.Drawing.Size(693, 340);
            this.GridInvoiceList.TabIndex = 4;
            this.GridInvoiceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInvoiceList});
            // 
            // gvInvoiceList
            // 
            this.gvInvoiceList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_ID,
            this.Col_INVOICE_CODE,
            this.Col_SENDED_NAME,
            this.gridColumn2,
            this.Col_CREATE_USER_NAME,
            this.Col_SENDED_DATE,
            this.Col_TOTAL_SUM,
            this.Col_OVER_SUM,
            this.Col_StateName,
            this.gridColumn1});
            this.gvInvoiceList.GridControl = this.GridInvoiceList;
            this.gvInvoiceList.IndicatorWidth = 30;
            this.gvInvoiceList.Name = "gvInvoiceList";
            this.gvInvoiceList.OptionsView.ColumnAutoWidth = false;
            this.gvInvoiceList.OptionsView.ShowGroupPanel = false;
            this.gvInvoiceList.Click += new System.EventHandler(this.gvInvoiceList_Click);
            this.gvInvoiceList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvInvoiceList_CustomDrawRowIndicator);
            this.gvInvoiceList.RowCountChanged += new System.EventHandler(this.gvInvoiceList_RowCountChanged);
            this.gvInvoiceList.DoubleClick += new System.EventHandler(this.btnViewReceiveList_Click);
            // 
            // Col_ID
            // 
            this.Col_ID.Caption = "ID";
            this.Col_ID.FieldName = "ID";
            this.Col_ID.Name = "Col_ID";
            this.Col_ID.OptionsColumn.AllowEdit = false;
            // 
            // Col_INVOICE_CODE
            // 
            this.Col_INVOICE_CODE.Caption = "发货单编码";
            this.Col_INVOICE_CODE.FieldName = "INVOICE_CODE";
            this.Col_INVOICE_CODE.Name = "Col_INVOICE_CODE";
            this.Col_INVOICE_CODE.OptionsColumn.AllowEdit = false;
            this.Col_INVOICE_CODE.Visible = true;
            this.Col_INVOICE_CODE.VisibleIndex = 0;
            this.Col_INVOICE_CODE.Width = 190;
            // 
            // Col_SENDED_NAME
            // 
            this.Col_SENDED_NAME.Caption = "发货单位";
            this.Col_SENDED_NAME.FieldName = "SENDER_NAME";
            this.Col_SENDED_NAME.Name = "Col_SENDED_NAME";
            this.Col_SENDED_NAME.OptionsColumn.AllowEdit = false;
            this.Col_SENDED_NAME.Width = 170;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "发货单位";
            this.gridColumn2.FieldName = "SENDER_NAME_ABBR";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 150;
            // 
            // Col_CREATE_USER_NAME
            // 
            this.Col_CREATE_USER_NAME.Caption = "创建人";
            this.Col_CREATE_USER_NAME.FieldName = "CREATE_USER_NAME";
            this.Col_CREATE_USER_NAME.Name = "Col_CREATE_USER_NAME";
            this.Col_CREATE_USER_NAME.OptionsColumn.AllowEdit = false;
            this.Col_CREATE_USER_NAME.Visible = true;
            this.Col_CREATE_USER_NAME.VisibleIndex = 1;
            this.Col_CREATE_USER_NAME.Width = 100;
            // 
            // Col_SENDED_DATE
            // 
            this.Col_SENDED_DATE.Caption = "发送时间";
            this.Col_SENDED_DATE.FieldName = "SENDED_DATE";
            this.Col_SENDED_DATE.Name = "Col_SENDED_DATE";
            this.Col_SENDED_DATE.OptionsColumn.AllowEdit = false;
            this.Col_SENDED_DATE.Visible = true;
            this.Col_SENDED_DATE.VisibleIndex = 3;
            this.Col_SENDED_DATE.Width = 100;
            // 
            // Col_TOTAL_SUM
            // 
            this.Col_TOTAL_SUM.AppearanceCell.Options.UseTextOptions = true;
            this.Col_TOTAL_SUM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Col_TOTAL_SUM.AppearanceHeader.Options.UseTextOptions = true;
            this.Col_TOTAL_SUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Col_TOTAL_SUM.Caption = "发货金额（元）";
            this.Col_TOTAL_SUM.DisplayFormat.FormatString = "##,##0.00";
            this.Col_TOTAL_SUM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Col_TOTAL_SUM.FieldName = "TOTAL_SUM";
            this.Col_TOTAL_SUM.Name = "Col_TOTAL_SUM";
            this.Col_TOTAL_SUM.OptionsColumn.AllowEdit = false;
            this.Col_TOTAL_SUM.Visible = true;
            this.Col_TOTAL_SUM.VisibleIndex = 4;
            this.Col_TOTAL_SUM.Width = 110;
            // 
            // Col_OVER_SUM
            // 
            this.Col_OVER_SUM.AppearanceCell.Options.UseTextOptions = true;
            this.Col_OVER_SUM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Col_OVER_SUM.AppearanceHeader.Options.UseTextOptions = true;
            this.Col_OVER_SUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Col_OVER_SUM.Caption = "完成金额（元）";
            this.Col_OVER_SUM.DisplayFormat.FormatString = "##,##0.00";
            this.Col_OVER_SUM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Col_OVER_SUM.FieldName = "OVER_SUM";
            this.Col_OVER_SUM.Name = "Col_OVER_SUM";
            this.Col_OVER_SUM.OptionsColumn.AllowEdit = false;
            this.Col_OVER_SUM.Visible = true;
            this.Col_OVER_SUM.VisibleIndex = 5;
            this.Col_OVER_SUM.Width = 110;
            // 
            // Col_StateName
            // 
            this.Col_StateName.Caption = "状态";
            this.Col_StateName.FieldName = "StateName";
            this.Col_StateName.Name = "Col_StateName";
            this.Col_StateName.OptionsColumn.AllowEdit = false;
            this.Col_StateName.Visible = true;
            this.Col_StateName.VisibleIndex = 6;
            this.Col_StateName.Width = 90;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STATE";
            this.gridColumn1.FieldName = "STATE";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // SelChe
            // 
            this.SelChe.AutoHeight = false;
            this.SelChe.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.SelChe.Name = "SelChe";
            this.SelChe.ValueChecked = "1";
            this.SelChe.ValueUnchecked = "0";
            // 
            // MeReturnRes
            // 
            this.MeReturnRes.AutoHeight = false;
            this.MeReturnRes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MeReturnRes.Name = "MeReturnRes";
            // 
            // OrdInvoiceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 474);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OrdInvoiceListForm";
            this.toolTipController1.SetSuperTip(this, null);
            this.Text = "确认发货单";
            this.Load += new System.EventHandler(this.OrdInvoiceListForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LueState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendedName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridInvoiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInvoiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelChe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeReturnRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit EndDate;
        private DevExpress.XtraEditors.DateEdit StartDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtSendedName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtInvoiceCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton btnFound;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnViewReceiveList;
        private DevExpress.XtraEditors.SimpleButton btnViewItem;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GridInvoiceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInvoiceList;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit SelChe;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit MeReturnRes;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnBlank;
        private DevExpress.XtraGrid.Columns.GridColumn Col_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Col_INVOICE_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn Col_SENDED_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn Col_CREATE_USER_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn Col_SENDED_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn Col_TOTAL_SUM;
        private DevExpress.XtraGrid.Columns.GridColumn Col_OVER_SUM;
        private DevExpress.XtraGrid.Columns.GridColumn Col_StateName;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.LookUpEdit LueState;
        private DevExpress.XtraEditors.LabelControl labelControlCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}