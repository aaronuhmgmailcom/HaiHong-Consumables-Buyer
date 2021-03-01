namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    partial class GpoSend
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GpoSend));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvErpSend = new System.Windows.Forms.DataGridView();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUYER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUYER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIVE_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_EXPIRE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_TRADE_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_RETAIL_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.READY_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_DISCOUNT_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERMIT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmedProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImportFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbmess = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.btnAddProductMap = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tableLayoutPanel1);
            this.panelMain.Size = new System.Drawing.Size(763, 484);
            // 
            // panelfrontfrmtxt
            // 
            this.panelfrontfrmtxt.Size = new System.Drawing.Size(70, 36);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Size = new System.Drawing.Size(65, 12);
            this.labelfrmtxt.Text = "ERP发货单";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.Main09;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvErpSend, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 484);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvErpSend
            // 
            this.dgvErpSend.AllowUserToAddRows = false;
            this.dgvErpSend.AllowUserToDeleteRows = false;
            this.dgvErpSend.AllowUserToResizeRows = false;
            this.dgvErpSend.AutoGenerateColumns = false;
            this.dgvErpSend.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErpSend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvErpSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErpSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.state,
            this.BUYER_CODE,
            this.BUYER_NAME,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.MEDICAL_MODE,
            this.MEDICAL_SPEC,
            this.SPEC_UNIT,
            this.FACTORY_CODE,
            this.FACTORY_NAME,
            this.LOT_NO,
            this.RECEIVE_QTY,
            this.INVOICE_NO,
            this.INVOICE_DATE,
            this.INVOICE_TOTAL,
            this.INVOICE_EXPIRE_DATE,
            this.INVOICE_TRADE_PRICE,
            this.INVOICE_RETAIL_PRICE,
            this.READY_REMARK,
            this.INVOICE_DISCOUNT_RATE,
            this.PERMIT_NO,
            this.Type,
            this.EmedProductCode,
            this.ordItemId});
            this.dgvErpSend.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvErpSend.DataSource = this.bindingSource1;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErpSend.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvErpSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErpSend.GridColor = System.Drawing.Color.Gray;
            this.dgvErpSend.Location = new System.Drawing.Point(3, 33);
            this.dgvErpSend.MultiSelect = false;
            this.dgvErpSend.Name = "dgvErpSend";
            this.dgvErpSend.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErpSend.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvErpSend.RowHeadersVisible = false;
            this.dgvErpSend.RowHeadersWidth = 30;
            this.dgvErpSend.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvErpSend.RowTemplate.Height = 23;
            this.dgvErpSend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErpSend.Size = new System.Drawing.Size(757, 418);
            this.dgvErpSend.TabIndex = 1;
            this.dgvErpSend.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvErpSend_RowsAdded);
            this.dgvErpSend.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvErpSend_CellMouseClick);
            this.dgvErpSend.CurrentCellChanged += new System.EventHandler(this.dgvErpSend_CurrentCellChanged);
            // 
            // state
            // 
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BUYER_CODE
            // 
            this.BUYER_CODE.DataPropertyName = "BUYER_CODE";
            this.BUYER_CODE.HeaderText = "买方编码";
            this.BUYER_CODE.Name = "BUYER_CODE";
            this.BUYER_CODE.ReadOnly = true;
            this.BUYER_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BUYER_NAME
            // 
            this.BUYER_NAME.DataPropertyName = "BUYER_NAME";
            this.BUYER_NAME.HeaderText = "买方名称";
            this.BUYER_NAME.Name = "BUYER_NAME";
            this.BUYER_NAME.ReadOnly = true;
            this.BUYER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "产品编码";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "产品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MEDICAL_MODE
            // 
            this.MEDICAL_MODE.DataPropertyName = "MEDICAL_MODE";
            this.MEDICAL_MODE.HeaderText = "剂型名称";
            this.MEDICAL_MODE.Name = "MEDICAL_MODE";
            this.MEDICAL_MODE.ReadOnly = true;
            this.MEDICAL_MODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MEDICAL_SPEC
            // 
            this.MEDICAL_SPEC.DataPropertyName = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.HeaderText = "规格名称";
            this.MEDICAL_SPEC.Name = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.ReadOnly = true;
            this.MEDICAL_SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SPEC_UNIT
            // 
            this.SPEC_UNIT.DataPropertyName = "SPEC_UNIT";
            this.SPEC_UNIT.HeaderText = "包装单位";
            this.SPEC_UNIT.Name = "SPEC_UNIT";
            this.SPEC_UNIT.ReadOnly = true;
            this.SPEC_UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FACTORY_CODE
            // 
            this.FACTORY_CODE.DataPropertyName = "FACTORY_CODE";
            this.FACTORY_CODE.HeaderText = "生产企业编码";
            this.FACTORY_CODE.Name = "FACTORY_CODE";
            this.FACTORY_CODE.ReadOnly = true;
            this.FACTORY_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FACTORY_NAME
            // 
            this.FACTORY_NAME.DataPropertyName = "FACTORY_NAME";
            this.FACTORY_NAME.HeaderText = "生产企业名称";
            this.FACTORY_NAME.Name = "FACTORY_NAME";
            this.FACTORY_NAME.ReadOnly = true;
            this.FACTORY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LOT_NO
            // 
            this.LOT_NO.DataPropertyName = "LOT_NO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.LOT_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.LOT_NO.HeaderText = "批号";
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.ReadOnly = true;
            this.LOT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RECEIVE_QTY
            // 
            this.RECEIVE_QTY.DataPropertyName = "RECEIVE_QTY";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RECEIVE_QTY.DefaultCellStyle = dataGridViewCellStyle3;
            this.RECEIVE_QTY.HeaderText = "发货数量";
            this.RECEIVE_QTY.Name = "RECEIVE_QTY";
            this.RECEIVE_QTY.ReadOnly = true;
            this.RECEIVE_QTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.INVOICE_NO.DefaultCellStyle = dataGridViewCellStyle4;
            this.INVOICE_NO.HeaderText = "发票号";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            this.INVOICE_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_DATE
            // 
            this.INVOICE_DATE.DataPropertyName = "INVOICE_DATE";
            this.INVOICE_DATE.HeaderText = "发票日期";
            this.INVOICE_DATE.Name = "INVOICE_DATE";
            this.INVOICE_DATE.ReadOnly = true;
            this.INVOICE_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_TOTAL
            // 
            this.INVOICE_TOTAL.DataPropertyName = "INVOICE_TOTAL";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.INVOICE_TOTAL.DefaultCellStyle = dataGridViewCellStyle5;
            this.INVOICE_TOTAL.HeaderText = "发票金额";
            this.INVOICE_TOTAL.Name = "INVOICE_TOTAL";
            this.INVOICE_TOTAL.ReadOnly = true;
            this.INVOICE_TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_EXPIRE_DATE
            // 
            this.INVOICE_EXPIRE_DATE.DataPropertyName = "INVOICE_EXPIRE_DATE";
            this.INVOICE_EXPIRE_DATE.HeaderText = "药品有效期";
            this.INVOICE_EXPIRE_DATE.Name = "INVOICE_EXPIRE_DATE";
            this.INVOICE_EXPIRE_DATE.ReadOnly = true;
            this.INVOICE_EXPIRE_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_TRADE_PRICE
            // 
            this.INVOICE_TRADE_PRICE.DataPropertyName = "INVOICE_TRADE_PRICE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.INVOICE_TRADE_PRICE.DefaultCellStyle = dataGridViewCellStyle6;
            this.INVOICE_TRADE_PRICE.HeaderText = "批发价";
            this.INVOICE_TRADE_PRICE.Name = "INVOICE_TRADE_PRICE";
            this.INVOICE_TRADE_PRICE.ReadOnly = true;
            this.INVOICE_TRADE_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_RETAIL_PRICE
            // 
            this.INVOICE_RETAIL_PRICE.DataPropertyName = "INVOICE_RETAIL_PRICE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.INVOICE_RETAIL_PRICE.DefaultCellStyle = dataGridViewCellStyle7;
            this.INVOICE_RETAIL_PRICE.HeaderText = "零售价";
            this.INVOICE_RETAIL_PRICE.Name = "INVOICE_RETAIL_PRICE";
            this.INVOICE_RETAIL_PRICE.ReadOnly = true;
            this.INVOICE_RETAIL_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // READY_REMARK
            // 
            this.READY_REMARK.DataPropertyName = "READY_REMARK";
            this.READY_REMARK.HeaderText = "发货备注";
            this.READY_REMARK.Name = "READY_REMARK";
            this.READY_REMARK.ReadOnly = true;
            this.READY_REMARK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INVOICE_DISCOUNT_RATE
            // 
            this.INVOICE_DISCOUNT_RATE.DataPropertyName = "INVOICE_DISCOUNT_RATE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.INVOICE_DISCOUNT_RATE.DefaultCellStyle = dataGridViewCellStyle8;
            this.INVOICE_DISCOUNT_RATE.HeaderText = "扣率";
            this.INVOICE_DISCOUNT_RATE.Name = "INVOICE_DISCOUNT_RATE";
            this.INVOICE_DISCOUNT_RATE.ReadOnly = true;
            this.INVOICE_DISCOUNT_RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PERMIT_NO
            // 
            this.PERMIT_NO.DataPropertyName = "PERMIT_NO";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.PERMIT_NO.DefaultCellStyle = dataGridViewCellStyle9;
            this.PERMIT_NO.HeaderText = "批准文号";
            this.PERMIT_NO.Name = "PERMIT_NO";
            this.PERMIT_NO.ReadOnly = true;
            this.PERMIT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
            // 
            // EmedProductCode
            // 
            this.EmedProductCode.HeaderText = "EmedProductCode";
            this.EmedProductCode.Name = "EmedProductCode";
            this.EmedProductCode.ReadOnly = true;
            this.EmedProductCode.Visible = false;
            // 
            // ordItemId
            // 
            this.ordItemId.DataPropertyName = "ORD_ITEM_ID";
            this.ordItemId.HeaderText = "订单明细id";
            this.ordItemId.Name = "ordItemId";
            this.ordItemId.ReadOnly = true;
            this.ordItemId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtImportFilePath);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 30);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "ERP发货单";
            // 
            // txtImportFilePath
            // 
            this.txtImportFilePath.Enabled = false;
            this.txtImportFilePath.Location = new System.Drawing.Point(86, 5);
            this.txtImportFilePath.Name = "txtImportFilePath";
            this.txtImportFilePath.Size = new System.Drawing.Size(192, 21);
            this.txtImportFilePath.TabIndex = 31;
            this.txtImportFilePath.Tag = "1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(282, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 32;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbmess);
            this.panel2.Controls.Add(this.btnselect);
            this.panel2.Controls.Add(this.btnAddProductMap);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 454);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 30);
            this.panel2.TabIndex = 2;
            // 
            // lbmess
            // 
            this.lbmess.AutoSize = true;
            this.lbmess.ForeColor = System.Drawing.Color.Red;
            this.lbmess.Location = new System.Drawing.Point(46, 9);
            this.lbmess.Name = "lbmess";
            this.lbmess.Size = new System.Drawing.Size(17, 12);
            this.lbmess.TabIndex = 4;
            this.lbmess.Text = "＊";
            this.lbmess.Visible = false;
            // 
            // btnselect
            // 
            this.btnselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnselect.Location = new System.Drawing.Point(529, 3);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 3;
            this.btnselect.Text = "查看";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Visible = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // btnAddProductMap
            // 
            this.btnAddProductMap.Enabled = false;
            this.btnAddProductMap.Location = new System.Drawing.Point(374, 4);
            this.btnAddProductMap.Name = "btnAddProductMap";
            this.btnAddProductMap.Size = new System.Drawing.Size(118, 23);
            this.btnAddProductMap.TabIndex = 2;
            this.btnAddProductMap.Text = "加入药品匹配";
            this.btnAddProductMap.UseVisualStyleBackColor = true;
            this.btnAddProductMap.Visible = false;
            this.btnAddProductMap.Click += new System.EventHandler(this.btnAddProductMap_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(685, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImport.Location = new System.Drawing.Point(607, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GpoSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 541);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GpoSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP发货单";
            this.Load += new System.EventHandler(this.ErpSend_Load);
            this.panelMain.ResumeLayout(false);
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImportFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvErpSend;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAddProductMap;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label lbmess;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUYER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUYER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIVE_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_EXPIRE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_TRADE_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_RETAIL_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn READY_REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_DISCOUNT_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERMIT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmedProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordItemId;
    }
}