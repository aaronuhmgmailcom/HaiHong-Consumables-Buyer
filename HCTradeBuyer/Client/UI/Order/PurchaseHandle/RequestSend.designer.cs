namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    partial class RequestSend
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtImportFilePath = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgvErpSend = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvHisSend = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRODUCT_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRODUCT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COMMON_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BRAND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Spec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Model = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RequestQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BASE_MEASURE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STORE_ROOM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SenderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.senderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANU_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Model_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PROJECT_PROD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SENDER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Spec_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storeRoomNameCmb = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.senderNameLue = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StoreRoomLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.SpecLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ModelLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHisSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoomNameCmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senderNameLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreRoomLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 527);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnBrowse);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtImportFilePath);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(758, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(248, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "���";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "�ɹ�����";
            // 
            // txtImportFilePath
            // 
            this.txtImportFilePath.Location = new System.Drawing.Point(63, 9);
            this.txtImportFilePath.Name = "txtImportFilePath";
            this.txtImportFilePath.Size = new System.Drawing.Size(179, 21);
            this.txtImportFilePath.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dgvErpSend);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(758, 443);
            this.panelControl2.TabIndex = 1;
            // 
            // dgvErpSend
            // 
            this.dgvErpSend.DataSource = this.bindingSource1;
            this.dgvErpSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErpSend.EmbeddedNavigator.Name = "";
            this.dgvErpSend.Location = new System.Drawing.Point(2, 2);
            this.dgvErpSend.MainView = this.dgvHisSend;
            this.dgvErpSend.Name = "dgvErpSend";
            this.dgvErpSend.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.storeRoomNameCmb,
            this.senderNameLue,
            this.StoreRoomLue,
            this.repositoryItemLookUpEdit1,
            this.SpecLue,
            this.ModelLue,
            this.repositoryItemTextEdit1});
            this.dgvErpSend.Size = new System.Drawing.Size(754, 439);
            this.dgvErpSend.TabIndex = 2;
            this.dgvErpSend.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvHisSend});
            // 
            // dgvHisSend
            // 
            this.dgvHisSend.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.state,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.COMMON_NAME,
            this.BRAND,
            this.Spec,
            this.Model,
            this.PRICE,
            this.RequestQty,
            this.BASE_MEASURE,
            this.STORE_ROOM_NAME,
            this.SenderCode,
            this.senderName,
            this.MANU_NAME,
            this.Model_ID,
            this.PROJECT_PROD_ID,
            this.SENDER_ID,
            this.Spec_Id});
            this.dgvHisSend.GridControl = this.dgvErpSend;
            this.dgvHisSend.IndicatorWidth = 30;
            this.dgvHisSend.Name = "dgvHisSend";
            this.dgvHisSend.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvHisSend.OptionsView.ColumnAutoWidth = false;
            this.dgvHisSend.OptionsView.ShowGroupPanel = false;
            // 
            // state
            // 
            this.state.Caption = "״̬";
            this.state.FieldName = "state";
            this.state.Name = "state";
            this.state.OptionsColumn.AllowEdit = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 0;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.Caption = "��Ʒ����";
            this.PRODUCT_CODE.FieldName = "ProductCode";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.OptionsColumn.AllowEdit = false;
            this.PRODUCT_CODE.Visible = true;
            this.PRODUCT_CODE.VisibleIndex = 2;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.Caption = "��Ʒ��";
            this.PRODUCT_NAME.FieldName = "ProductName";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.OptionsColumn.AllowEdit = false;
            this.PRODUCT_NAME.Visible = true;
            this.PRODUCT_NAME.VisibleIndex = 3;
            this.PRODUCT_NAME.Width = 150;
            // 
            // COMMON_NAME
            // 
            this.COMMON_NAME.Caption = "ͨ������";
            this.COMMON_NAME.FieldName = "InstruName";
            this.COMMON_NAME.Name = "COMMON_NAME";
            this.COMMON_NAME.OptionsColumn.AllowEdit = false;
            this.COMMON_NAME.Visible = true;
            this.COMMON_NAME.VisibleIndex = 1;
            // 
            // BRAND
            // 
            this.BRAND.Caption = "Ʒ��";
            this.BRAND.FieldName = "Brand";
            this.BRAND.Name = "BRAND";
            this.BRAND.OptionsColumn.AllowEdit = false;
            this.BRAND.Visible = true;
            this.BRAND.VisibleIndex = 4;
            // 
            // Spec
            // 
            this.Spec.Caption = "���";
            this.Spec.FieldName = "Spec";
            this.Spec.Name = "Spec";
            this.Spec.OptionsColumn.AllowEdit = false;
            this.Spec.Visible = true;
            this.Spec.VisibleIndex = 5;
            this.Spec.Width = 90;
            // 
            // Model
            // 
            this.Model.Caption = "�ͺ�";
            this.Model.FieldName = "ModeName";
            this.Model.Name = "Model";
            this.Model.OptionsColumn.AllowEdit = false;
            this.Model.Visible = true;
            this.Model.VisibleIndex = 6;
            this.Model.Width = 90;
            // 
            // PRICE
            // 
            this.PRICE.AppearanceCell.Options.UseTextOptions = true;
            this.PRICE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PRICE.AppearanceHeader.Options.UseTextOptions = true;
            this.PRICE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PRICE.Caption = "����";
            this.PRICE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PRICE.FieldName = "Price";
            this.PRICE.Name = "PRICE";
            this.PRICE.OptionsColumn.AllowEdit = false;
            this.PRICE.Visible = true;
            this.PRICE.VisibleIndex = 7;
            // 
            // RequestQty
            // 
            this.RequestQty.AppearanceCell.Options.UseTextOptions = true;
            this.RequestQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RequestQty.AppearanceHeader.Options.UseTextOptions = true;
            this.RequestQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RequestQty.Caption = "�ɹ�����";
            this.RequestQty.DisplayFormat.FormatString = "####0";
            this.RequestQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RequestQty.FieldName = "RequestQty";
            this.RequestQty.Name = "RequestQty";
            this.RequestQty.OptionsColumn.AllowEdit = false;
            this.RequestQty.Tag = "1";
            this.RequestQty.Visible = true;
            this.RequestQty.VisibleIndex = 8;
            // 
            // BASE_MEASURE
            // 
            this.BASE_MEASURE.Caption = "���͵�λ";
            this.BASE_MEASURE.FieldName = "SpecUnit";
            this.BASE_MEASURE.Name = "BASE_MEASURE";
            this.BASE_MEASURE.OptionsColumn.AllowEdit = false;
            this.BASE_MEASURE.Visible = true;
            this.BASE_MEASURE.VisibleIndex = 9;
            this.BASE_MEASURE.Width = 80;
            // 
            // STORE_ROOM_NAME
            // 
            this.STORE_ROOM_NAME.Caption = "�ⷿ";
            this.STORE_ROOM_NAME.FieldName = "StockName";
            this.STORE_ROOM_NAME.Name = "STORE_ROOM_NAME";
            this.STORE_ROOM_NAME.OptionsColumn.AllowEdit = false;
            this.STORE_ROOM_NAME.Width = 100;
            // 
            // SenderCode
            // 
            this.SenderCode.Caption = "�����̱���";
            this.SenderCode.FieldName = "SenderCode";
            this.SenderCode.Name = "SenderCode";
            this.SenderCode.OptionsColumn.AllowEdit = false;
            this.SenderCode.Visible = true;
            this.SenderCode.VisibleIndex = 10;
            // 
            // senderName
            // 
            this.senderName.Caption = "������ҵ";
            this.senderName.FieldName = "SenderName";
            this.senderName.Name = "senderName";
            this.senderName.OptionsColumn.AllowEdit = false;
            this.senderName.Visible = true;
            this.senderName.VisibleIndex = 11;
            this.senderName.Width = 150;
            // 
            // MANU_NAME
            // 
            this.MANU_NAME.Caption = "������ҵ";
            this.MANU_NAME.FieldName = "FactoryName";
            this.MANU_NAME.Name = "MANU_NAME";
            this.MANU_NAME.OptionsColumn.AllowEdit = false;
            this.MANU_NAME.Visible = true;
            this.MANU_NAME.VisibleIndex = 12;
            this.MANU_NAME.Width = 160;
            // 
            // Model_ID
            // 
            this.Model_ID.Caption = "�����ͺ�ID";
            this.Model_ID.Name = "Model_ID";
            this.Model_ID.OptionsColumn.AllowEdit = false;
            // 
            // PROJECT_PROD_ID
            // 
            this.PROJECT_PROD_ID.Caption = "��Ŀ��ƷID";
            this.PROJECT_PROD_ID.Name = "PROJECT_PROD_ID";
            this.PROJECT_PROD_ID.OptionsColumn.AllowEdit = false;
            // 
            // SENDER_ID
            // 
            this.SENDER_ID.Caption = "����������ID";
            this.SENDER_ID.Name = "SENDER_ID";
            this.SENDER_ID.OptionsColumn.AllowEdit = false;
            // 
            // Spec_Id
            // 
            this.Spec_Id.Caption = "������ID";
            this.Spec_Id.Name = "Spec_Id";
            this.Spec_Id.OptionsColumn.AllowEdit = false;
            this.Spec_Id.Width = 100;
            // 
            // storeRoomNameCmb
            // 
            this.storeRoomNameCmb.AutoHeight = false;
            this.storeRoomNameCmb.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeRoomNameCmb.Name = "storeRoomNameCmb";
            // 
            // senderNameLue
            // 
            this.senderNameLue.AutoHeight = false;
            this.senderNameLue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.senderNameLue.DisplayMember = "SENDER_NAME";
            this.senderNameLue.Name = "senderNameLue";
            this.senderNameLue.ValueMember = "Stone_ID";
            this.senderNameLue.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // StoreRoomLue
            // 
            this.StoreRoomLue.AutoHeight = false;
            this.StoreRoomLue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StoreRoomLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STORE_NAME", "�ⷿ", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.StoreRoomLue.DisplayMember = "STORE_NAME";
            this.StoreRoomLue.Name = "StoreRoomLue";
            this.StoreRoomLue.NullText = "ѡ��...";
            this.StoreRoomLue.ValueMember = "STORE_ID";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // SpecLue
            // 
            this.SpecLue.AutoHeight = false;
            this.SpecLue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpecLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPEC_NAME", "���", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.SpecLue.DisplayMember = "SPEC_NAME";
            this.SpecLue.Name = "SpecLue";
            this.SpecLue.NullText = "ѡ��...";
            this.SpecLue.ValueMember = "SPEC_ID";
            // 
            // ModelLue
            // 
            this.ModelLue.AutoHeight = false;
            this.ModelLue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModelLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODEL_NAME", "�ͺ�", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ModelLue.DisplayMember = "MODEL_NAME";
            this.ModelLue.Name = "ModelLue";
            this.ModelLue.NullText = "ѡ��...";
            this.ModelLue.ValueMember = "MODEL_ID";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnImport);
            this.panelControl3.Controls.Add(this.button1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 491);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(758, 33);
            this.panelControl3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(674, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "�ر�";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(593, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "����";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(512, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "����δƥ��";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RequestSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(764, 527);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RequestSend";
            this.Text = "����ɹ��ƻ�";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHisSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoomNameCmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.senderNameLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreRoomLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtImportFilePath;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraGrid.GridControl dgvErpSend;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvHisSend;
        private DevExpress.XtraGrid.Columns.GridColumn PRODUCT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn Spec;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit SpecLue;
        private DevExpress.XtraGrid.Columns.GridColumn Model;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ModelLue;
        private DevExpress.XtraGrid.Columns.GridColumn PRICE;
        private DevExpress.XtraGrid.Columns.GridColumn BASE_MEASURE;
        private DevExpress.XtraGrid.Columns.GridColumn STORE_ROOM_NAME;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit StoreRoomLue;
        private DevExpress.XtraGrid.Columns.GridColumn senderName;
        private DevExpress.XtraGrid.Columns.GridColumn MANU_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn PROJECT_PROD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Spec_Id;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox storeRoomNameCmb;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit senderNameLue;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn SenderCode;
        private DevExpress.XtraGrid.Columns.GridColumn Model_ID;
        private DevExpress.XtraGrid.Columns.GridColumn COMMON_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn BRAND;
        private DevExpress.XtraGrid.Columns.GridColumn SENDER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn PRODUCT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn RequestQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
