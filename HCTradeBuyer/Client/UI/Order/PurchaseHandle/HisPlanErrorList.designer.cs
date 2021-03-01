namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    partial class HisPlanErrorList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgvErpSend = new DevExpress.XtraGrid.GridControl();
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
            this.storeRoomNameCmb = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.senderNameLue = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StoreRoomLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.SpecLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ModelLue = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHisSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoomNameCmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senderNameLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreRoomLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelLue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.91402F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.08597F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dgvErpSend);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(620, 346);
            this.panelControl1.TabIndex = 0;
            // 
            // dgvErpSend
            // 
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
            this.dgvErpSend.Size = new System.Drawing.Size(616, 342);
            this.dgvErpSend.TabIndex = 3;
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
            this.MANU_NAME});
            this.dgvHisSend.GridControl = this.dgvErpSend;
            this.dgvHisSend.IndicatorWidth = 30;
            this.dgvHisSend.Name = "dgvHisSend";
            this.dgvHisSend.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvHisSend.OptionsView.ColumnAutoWidth = false;
            this.dgvHisSend.OptionsView.ShowGroupPanel = false;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.Name = "state";
            this.state.OptionsColumn.AllowEdit = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 0;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.Caption = "商品编码";
            this.PRODUCT_CODE.FieldName = "ProductCode";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.OptionsColumn.AllowEdit = false;
            this.PRODUCT_CODE.Visible = true;
            this.PRODUCT_CODE.VisibleIndex = 2;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.Caption = "商品名";
            this.PRODUCT_NAME.FieldName = "ProductName";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.OptionsColumn.AllowEdit = false;
            this.PRODUCT_NAME.Visible = true;
            this.PRODUCT_NAME.VisibleIndex = 3;
            this.PRODUCT_NAME.Width = 150;
            // 
            // COMMON_NAME
            // 
            this.COMMON_NAME.Caption = "通用名称";
            this.COMMON_NAME.FieldName = "InstruName";
            this.COMMON_NAME.Name = "COMMON_NAME";
            this.COMMON_NAME.OptionsColumn.AllowEdit = false;
            this.COMMON_NAME.Visible = true;
            this.COMMON_NAME.VisibleIndex = 1;
            // 
            // BRAND
            // 
            this.BRAND.Caption = "品牌";
            this.BRAND.FieldName = "BRAND";
            this.BRAND.Name = "BRAND";
            this.BRAND.OptionsColumn.AllowEdit = false;
            this.BRAND.Visible = true;
            this.BRAND.VisibleIndex = 4;
            // 
            // Spec
            // 
            this.Spec.Caption = "规格";
            this.Spec.FieldName = "Spec";
            this.Spec.Name = "Spec";
            this.Spec.OptionsColumn.AllowEdit = false;
            this.Spec.Visible = true;
            this.Spec.VisibleIndex = 5;
            this.Spec.Width = 90;
            // 
            // Model
            // 
            this.Model.Caption = "型号";
            this.Model.FieldName = "ModeName";
            this.Model.Name = "Model";
            this.Model.OptionsColumn.AllowEdit = false;
            this.Model.Visible = true;
            this.Model.VisibleIndex = 6;
            this.Model.Width = 90;
            // 
            // PRICE
            // 
            this.PRICE.Caption = "单价";
            this.PRICE.FieldName = "Price";
            this.PRICE.Name = "PRICE";
            this.PRICE.OptionsColumn.AllowEdit = false;
            this.PRICE.Visible = true;
            this.PRICE.VisibleIndex = 7;
            // 
            // RequestQty
            // 
            this.RequestQty.Caption = "采购数量";
            this.RequestQty.FieldName = "RequestQty";
            this.RequestQty.Name = "RequestQty";
            this.RequestQty.OptionsColumn.AllowEdit = false;
            this.RequestQty.Visible = true;
            this.RequestQty.VisibleIndex = 8;
            // 
            // BASE_MEASURE
            // 
            this.BASE_MEASURE.Caption = "配送单位";
            this.BASE_MEASURE.FieldName = "SpecUnit";
            this.BASE_MEASURE.Name = "BASE_MEASURE";
            this.BASE_MEASURE.OptionsColumn.AllowEdit = false;
            this.BASE_MEASURE.Visible = true;
            this.BASE_MEASURE.VisibleIndex = 9;
            this.BASE_MEASURE.Width = 80;
            // 
            // STORE_ROOM_NAME
            // 
            this.STORE_ROOM_NAME.Caption = "库房";
            this.STORE_ROOM_NAME.FieldName = "StockName";
            this.STORE_ROOM_NAME.Name = "STORE_ROOM_NAME";
            this.STORE_ROOM_NAME.OptionsColumn.AllowEdit = false;
            this.STORE_ROOM_NAME.Width = 100;
            // 
            // SenderCode
            // 
            this.SenderCode.Caption = "配送商编码";
            this.SenderCode.FieldName = "SenderCode";
            this.SenderCode.Name = "SenderCode";
            this.SenderCode.OptionsColumn.AllowEdit = false;
            this.SenderCode.Visible = true;
            this.SenderCode.VisibleIndex = 10;
            // 
            // senderName
            // 
            this.senderName.Caption = "配送企业";
            this.senderName.FieldName = "SenderName";
            this.senderName.Name = "senderName";
            this.senderName.OptionsColumn.AllowEdit = false;
            this.senderName.Visible = true;
            this.senderName.VisibleIndex = 11;
            this.senderName.Width = 150;
            // 
            // MANU_NAME
            // 
            this.MANU_NAME.Caption = "生产企业";
            this.MANU_NAME.FieldName = "FactoryName";
            this.MANU_NAME.Name = "MANU_NAME";
            this.MANU_NAME.OptionsColumn.AllowEdit = false;
            this.MANU_NAME.Visible = true;
            this.MANU_NAME.VisibleIndex = 12;
            this.MANU_NAME.Width = 160;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STORE_NAME", "库房", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.StoreRoomLue.DisplayMember = "STORE_NAME";
            this.StoreRoomLue.Name = "StoreRoomLue";
            this.StoreRoomLue.NullText = "选择...";
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SPEC_NAME", "规格", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.SpecLue.DisplayMember = "SPEC_NAME";
            this.SpecLue.Name = "SpecLue";
            this.SpecLue.NullText = "选择...";
            this.SpecLue.ValueMember = "SPEC_ID";
            // 
            // ModelLue
            // 
            this.ModelLue.AutoHeight = false;
            this.ModelLue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModelLue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODEL_NAME", "型号", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ModelLue.DisplayMember = "MODEL_NAME";
            this.ModelLue.Name = "ModelLue";
            this.ModelLue.NullText = "选择...";
            this.ModelLue.ValueMember = "MODEL_ID";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnExcel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 355);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(620, 38);
            this.panelControl2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(526, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(430, 10);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Excel导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // HisPlanErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(626, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HisPlanErrorList";
            this.Text = "导出未匹配数据";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHisSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRoomNameCmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.senderNameLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreRoomLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelLue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.GridControl dgvErpSend;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvHisSend;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn PRODUCT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn PRODUCT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn COMMON_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn BRAND;
        private DevExpress.XtraGrid.Columns.GridColumn Spec;
        private DevExpress.XtraGrid.Columns.GridColumn Model;
        private DevExpress.XtraGrid.Columns.GridColumn PRICE;
        private DevExpress.XtraGrid.Columns.GridColumn RequestQty;
        private DevExpress.XtraGrid.Columns.GridColumn BASE_MEASURE;
        private DevExpress.XtraGrid.Columns.GridColumn STORE_ROOM_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn SenderCode;
        private DevExpress.XtraGrid.Columns.GridColumn senderName;
        private DevExpress.XtraGrid.Columns.GridColumn MANU_NAME;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox storeRoomNameCmb;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit senderNameLue;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit StoreRoomLue;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit SpecLue;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ModelLue;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
