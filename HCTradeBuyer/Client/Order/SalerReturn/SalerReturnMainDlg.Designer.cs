namespace Emedchina.TradeAssistant.Client.Order.SalerReturn
{
    partial class SalerReturnMainDlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbReturnStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dgvSalerReturnList = new System.Windows.Forms.DataGridView();
            this.bindingSourceReturn = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefuse = new System.Windows.Forms.Button();
            this.btnAllow = new System.Windows.Forms.Button();
            this.pageNavigator1 = new Emedchina.Commons.WinForms.PageNavigator();
            this.RowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bak_medical_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bak_product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAK_MASS_ASSIGNMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bak_medical_mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bak_product_spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bak_buyer_easy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.return_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyer_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date_display = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirm_date_display = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive_qty_pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalerReturnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReturn)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.Main09;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSalerReturnList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pageNavigator1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(856, 431);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbReturnStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtEndDate);
            this.panel1.Controls.Add(this.dtStartDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 64);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(744, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 23);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbReturnStatus
            // 
            this.cmbReturnStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnStatus.FormattingEnabled = true;
            this.cmbReturnStatus.Location = new System.Drawing.Point(133, 9);
            this.cmbReturnStatus.Name = "cmbReturnStatus";
            this.cmbReturnStatus.Size = new System.Drawing.Size(164, 20);
            this.cmbReturnStatus.TabIndex = 28;
            this.cmbReturnStatus.SelectedIndexChanged += new System.EventHandler(this.cmbReturnStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "退货状态：";
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = " ";
            this.dtEndDate.Location = new System.Drawing.Point(582, 8);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(109, 21);
            this.dtEndDate.TabIndex = 24;
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = " ";
            this.dtStartDate.Location = new System.Drawing.Point(448, 8);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(109, 21);
            this.dtStartDate.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "到";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = " 退货时间：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 21);
            this.txtName.TabIndex = 22;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(47, 36);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(82, 20);
            this.cmbType.TabIndex = 21;
            // 
            // dgvSalerReturnList
            // 
            this.dgvSalerReturnList.AllowUserToAddRows = false;
            this.dgvSalerReturnList.AllowUserToDeleteRows = false;
            this.dgvSalerReturnList.AutoGenerateColumns = false;
            this.dgvSalerReturnList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSalerReturnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalerReturnList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNum,
            this.ID,
            this.bak_medical_name,
            this.bak_product_name,
            this.BAK_MASS_ASSIGNMENT,
            this.bak_medical_mode,
            this.bak_product_spec,
            this.bak_buyer_easy,
            this.lot_no,
            this.warehouse_name,
            this.return_qty,
            this.buyer_remark,
            this.create_date_display,
            this.confirm_date_display,
            this.Remark,
            this.receive_id,
            this.receive_qty_pre});
            this.dgvSalerReturnList.DataSource = this.bindingSourceReturn;
            this.dgvSalerReturnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalerReturnList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSalerReturnList.Location = new System.Drawing.Point(3, 98);
            this.dgvSalerReturnList.Name = "dgvSalerReturnList";
            this.dgvSalerReturnList.RowTemplate.Height = 23;
            this.dgvSalerReturnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalerReturnList.Size = new System.Drawing.Size(850, 290);
            this.dgvSalerReturnList.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnRefuse);
            this.panel2.Controls.Add(this.btnAllow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 34);
            this.panel2.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(755, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(658, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 23);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefuse
            // 
            this.btnRefuse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefuse.Location = new System.Drawing.Point(560, 7);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(92, 23);
            this.btnRefuse.TabIndex = 13;
            this.btnRefuse.Text = "拒绝";
            this.btnRefuse.UseVisualStyleBackColor = true;
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // btnAllow
            // 
            this.btnAllow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllow.Location = new System.Drawing.Point(462, 7);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(92, 23);
            this.btnAllow.TabIndex = 14;
            this.btnAllow.Text = "同意";
            this.btnAllow.UseVisualStyleBackColor = true;
            this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click);
            // 
            // pageNavigator1
            // 
            this.pageNavigator1.CurrentPageIndex = 0;
            this.pageNavigator1.ItemCount = 0;
            this.pageNavigator1.Location = new System.Drawing.Point(0, 70);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.Size = new System.Drawing.Size(856, 25);
            this.pageNavigator1.TabIndex = 4;
            this.pageNavigator1.Text = "pageNavigator1";
            this.pageNavigator1.PageIndexOrPageSizeChanged += new Emedchina.Commons.WinForms.PageChangedEventHandler(this.pageNavigator1_PageIndexOrPageSizeChanged);
            // 
            // RowNum
            // 
            this.RowNum.DataPropertyName = "rownum";
            this.RowNum.HeaderText = "序号";
            this.RowNum.Name = "RowNum";
            this.RowNum.ReadOnly = true;
            this.RowNum.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // bak_medical_name
            // 
            this.bak_medical_name.DataPropertyName = "bak_medical_name";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bak_medical_name.DefaultCellStyle = dataGridViewCellStyle1;
            this.bak_medical_name.HeaderText = "药品名";
            this.bak_medical_name.Name = "bak_medical_name";
            this.bak_medical_name.ReadOnly = true;
            // 
            // bak_product_name
            // 
            this.bak_product_name.DataPropertyName = "bak_product_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bak_product_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.bak_product_name.HeaderText = "商品名";
            this.bak_product_name.Name = "bak_product_name";
            this.bak_product_name.ReadOnly = true;
            // 
            // BAK_MASS_ASSIGNMENT
            // 
            this.BAK_MASS_ASSIGNMENT.DataPropertyName = "BAK_MASS_ASSIGNMENT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BAK_MASS_ASSIGNMENT.DefaultCellStyle = dataGridViewCellStyle3;
            this.BAK_MASS_ASSIGNMENT.HeaderText = "质量层次";
            this.BAK_MASS_ASSIGNMENT.Name = "BAK_MASS_ASSIGNMENT";
            this.BAK_MASS_ASSIGNMENT.Visible = false;
            // 
            // bak_medical_mode
            // 
            this.bak_medical_mode.DataPropertyName = "bak_medical_mode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bak_medical_mode.DefaultCellStyle = dataGridViewCellStyle4;
            this.bak_medical_mode.HeaderText = "剂型";
            this.bak_medical_mode.Name = "bak_medical_mode";
            this.bak_medical_mode.ReadOnly = true;
            // 
            // bak_product_spec
            // 
            this.bak_product_spec.DataPropertyName = "bak_product_spec";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bak_product_spec.DefaultCellStyle = dataGridViewCellStyle5;
            this.bak_product_spec.HeaderText = "规格包装";
            this.bak_product_spec.Name = "bak_product_spec";
            this.bak_product_spec.ReadOnly = true;
            // 
            // bak_buyer_easy
            // 
            this.bak_buyer_easy.DataPropertyName = "bak_buyer_easy";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bak_buyer_easy.DefaultCellStyle = dataGridViewCellStyle6;
            this.bak_buyer_easy.HeaderText = "退货机构";
            this.bak_buyer_easy.Name = "bak_buyer_easy";
            this.bak_buyer_easy.ReadOnly = true;
            // 
            // lot_no
            // 
            this.lot_no.DataPropertyName = "lot_no";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.lot_no.DefaultCellStyle = dataGridViewCellStyle7;
            this.lot_no.HeaderText = "批号";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            // 
            // warehouse_name
            // 
            this.warehouse_name.DataPropertyName = "warehouse_name";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.warehouse_name.DefaultCellStyle = dataGridViewCellStyle8;
            this.warehouse_name.HeaderText = "药库";
            this.warehouse_name.Name = "warehouse_name";
            this.warehouse_name.ReadOnly = true;
            // 
            // return_qty
            // 
            this.return_qty.DataPropertyName = "return_qty";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.return_qty.DefaultCellStyle = dataGridViewCellStyle9;
            this.return_qty.HeaderText = "退货数";
            this.return_qty.Name = "return_qty";
            this.return_qty.ReadOnly = true;
            // 
            // buyer_remark
            // 
            this.buyer_remark.DataPropertyName = "buyer_remark";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.buyer_remark.DefaultCellStyle = dataGridViewCellStyle10;
            this.buyer_remark.HeaderText = "退货原因";
            this.buyer_remark.Name = "buyer_remark";
            this.buyer_remark.ReadOnly = true;
            // 
            // create_date_display
            // 
            this.create_date_display.DataPropertyName = "create_date_display";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.create_date_display.DefaultCellStyle = dataGridViewCellStyle11;
            this.create_date_display.HeaderText = "退货时间";
            this.create_date_display.Name = "create_date_display";
            this.create_date_display.ReadOnly = true;
            // 
            // confirm_date_display
            // 
            this.confirm_date_display.DataPropertyName = "confirm_date_display";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.confirm_date_display.DefaultCellStyle = dataGridViewCellStyle12;
            this.confirm_date_display.HeaderText = "确认时间";
            this.confirm_date_display.Name = "confirm_date_display";
            this.confirm_date_display.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Remark.DefaultCellStyle = dataGridViewCellStyle13;
            this.Remark.HeaderText = "附注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // receive_id
            // 
            this.receive_id.DataPropertyName = "receive_id";
            this.receive_id.HeaderText = "receive_id";
            this.receive_id.Name = "receive_id";
            this.receive_id.Visible = false;
            // 
            // receive_qty_pre
            // 
            this.receive_qty_pre.DataPropertyName = "receive_qty_pre";
            this.receive_qty_pre.HeaderText = "receive_qty_pre";
            this.receive_qty_pre.Name = "receive_qty_pre";
            this.receive_qty_pre.Visible = false;
            // 
            // SalerReturnMainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.Main09;
            this.ClientSize = new System.Drawing.Size(856, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SalerReturnMainDlg";
            this.Text = "退货处理";
            this.Load += new System.EventHandler(this.SalerReturnMainDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalerReturnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReturn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSalerReturnList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefuse;
        private System.Windows.Forms.Button btnAllow;
        private Emedchina.Commons.WinForms.PageNavigator pageNavigator1;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbReturnStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.BindingSource bindingSourceReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bak_medical_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bak_product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAK_MASS_ASSIGNMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn bak_medical_mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn bak_product_spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn bak_buyer_easy;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn return_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyer_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date_display;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirm_date_display;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive_qty_pre;
    }
}