namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    partial class SalerOrderList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalerOrderList));
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvSalerOrderList = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyer_orgid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAK_BUYER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REQUEST_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_STATE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pageNavigator1 = new Emedchina.Commons.WinForms.PageNavigator();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbItemState = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnErpSend = new System.Windows.Forms.Button();
            this.btnExpOrder = new System.Windows.Forms.Button();
            this.btnDealWith = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalerOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderListBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvSalerOrderList);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 96);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(792, 409);
            this.panel5.TabIndex = 10;
            // 
            // dgvSalerOrderList
            // 
            this.dgvSalerOrderList.AllowUserToAddRows = false;
            this.dgvSalerOrderList.AllowUserToResizeRows = false;
            this.dgvSalerOrderList.AutoGenerateColumns = false;
            this.dgvSalerOrderList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalerOrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalerOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalerOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.buyer_orgid,
            this.order_code,
            this.BAK_BUYER_NAME,
            this.address,
            this.sendTime,
            this.REQUEST_TOTAL,
            this.ORDER_STATE_NAME,
            this.orderState});
            this.dgvSalerOrderList.DataSource = this.orderListBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalerOrderList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSalerOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalerOrderList.Location = new System.Drawing.Point(0, 0);
            this.dgvSalerOrderList.Margin = new System.Windows.Forms.Padding(100);
            this.dgvSalerOrderList.MultiSelect = false;
            this.dgvSalerOrderList.Name = "dgvSalerOrderList";
            this.dgvSalerOrderList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalerOrderList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSalerOrderList.RowHeadersWidth = 30;
            this.dgvSalerOrderList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSalerOrderList.RowTemplate.Height = 23;
            this.dgvSalerOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalerOrderList.Size = new System.Drawing.Size(792, 409);
            this.dgvSalerOrderList.StandardTab = true;
            this.dgvSalerOrderList.TabIndex = 4;
            this.dgvSalerOrderList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalerOrderList_KeyDown);
            this.dgvSalerOrderList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalerOrderList_RowEnter);
            this.dgvSalerOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalerOrderList_CellDoubleClick);
            this.dgvSalerOrderList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSalerOrderList_DataError);
            // 
            // order_id
            // 
            this.order_id.DataPropertyName = "order_id";
            this.order_id.HeaderText = "order_id";
            this.order_id.Name = "order_id";
            this.order_id.ReadOnly = true;
            this.order_id.Visible = false;
            // 
            // buyer_orgid
            // 
            this.buyer_orgid.DataPropertyName = "buyer_orgid";
            this.buyer_orgid.HeaderText = "buyer_orgid";
            this.buyer_orgid.Name = "buyer_orgid";
            this.buyer_orgid.ReadOnly = true;
            this.buyer_orgid.Visible = false;
            // 
            // order_code
            // 
            this.order_code.DataPropertyName = "order_code";
            this.order_code.HeaderText = "code";
            this.order_code.Name = "order_code";
            this.order_code.ReadOnly = true;
            this.order_code.Visible = false;
            // 
            // BAK_BUYER_NAME
            // 
            this.BAK_BUYER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BAK_BUYER_NAME.DataPropertyName = "BAK_BUYER_NAME";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BAK_BUYER_NAME.DefaultCellStyle = dataGridViewCellStyle2;
            this.BAK_BUYER_NAME.FillWeight = 30F;
            this.BAK_BUYER_NAME.HeaderText = "买方企业";
            this.BAK_BUYER_NAME.Name = "BAK_BUYER_NAME";
            this.BAK_BUYER_NAME.ReadOnly = true;
            this.BAK_BUYER_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // address
            // 
            this.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.address.DataPropertyName = "org_address";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.address.DefaultCellStyle = dataGridViewCellStyle3;
            this.address.FillWeight = 20F;
            this.address.HeaderText = "地址";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sendTime
            // 
            this.sendTime.DataPropertyName = "create_date";
            this.sendTime.HeaderText = "发送时间";
            this.sendTime.Name = "sendTime";
            this.sendTime.ReadOnly = true;
            // 
            // REQUEST_TOTAL
            // 
            this.REQUEST_TOTAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.REQUEST_TOTAL.DataPropertyName = "REQUEST_TOTAL";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.REQUEST_TOTAL.DefaultCellStyle = dataGridViewCellStyle4;
            this.REQUEST_TOTAL.FillWeight = 10F;
            this.REQUEST_TOTAL.HeaderText = "订购金额";
            this.REQUEST_TOTAL.Name = "REQUEST_TOTAL";
            this.REQUEST_TOTAL.ReadOnly = true;
            // 
            // ORDER_STATE_NAME
            // 
            this.ORDER_STATE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ORDER_STATE_NAME.DataPropertyName = "ORDER_STATE_NAME";
            this.ORDER_STATE_NAME.FillWeight = 10F;
            this.ORDER_STATE_NAME.HeaderText = "订单状态";
            this.ORDER_STATE_NAME.Name = "ORDER_STATE_NAME";
            this.ORDER_STATE_NAME.ReadOnly = true;
            // 
            // orderState
            // 
            this.orderState.DataPropertyName = "order_state";
            this.orderState.HeaderText = "orderState";
            this.orderState.Name = "orderState";
            this.orderState.ReadOnly = true;
            this.orderState.Visible = false;
            // 
            // pageNavigator1
            // 
            this.pageNavigator1.CurrentPageIndex = 0;
            this.pageNavigator1.ItemCount = 0;
            this.pageNavigator1.Location = new System.Drawing.Point(0, 0);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.Size = new System.Drawing.Size(792, 25);
            this.pageNavigator1.TabIndex = 0;
            this.pageNavigator1.Text = "pageNavigator1";
            this.pageNavigator1.PageIndexOrPageSizeChanged += new Emedchina.Commons.WinForms.PageChangedEventHandler(this.pageNavigator1_PageIndexOrPageSizeChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pageNavigator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(792, 26);
            this.panel4.TabIndex = 9;
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = " ";
            this.dtEndDate.Location = new System.Drawing.Point(359, 12);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.ShowCheckBox = true;
            this.dtEndDate.Size = new System.Drawing.Size(120, 21);
            this.dtEndDate.TabIndex = 4;
            this.dtEndDate.CloseUp += new System.EventHandler(this.dtEndDate_CloseUp);
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = " ";
            this.dtStartDate.Location = new System.Drawing.Point(219, 12);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.ShowCheckBox = true;
            this.dtStartDate.Size = new System.Drawing.Size(120, 21);
            this.dtStartDate.TabIndex = 3;
            this.dtStartDate.Value = new System.DateTime(2006, 6, 15, 0, 0, 0, 0);
            this.dtStartDate.CloseUp += new System.EventHandler(this.dtStartDate_CloseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "发送日期：";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(598, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 22);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.dtEndDate);
            this.panel1.Controls.Add(this.dtStartDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.cmbItemState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 70);
            this.panel1.TabIndex = 7;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(696, 41);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 22);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 21);
            this.txtName.TabIndex = 8;
            this.txtName.Tag = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "状态：";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "经销企业",
            "生产企业",
            "卖方企业"});
            this.cmbType.Location = new System.Drawing.Point(18, 38);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(80, 20);
            this.cmbType.TabIndex = 7;
            // 
            // cmbItemState
            // 
            this.cmbItemState.AutoCompleteCustomSource.AddRange(new string[] {
            "a,1",
            "b,2"});
            this.cmbItemState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemState.FormattingEnabled = true;
            this.cmbItemState.Items.AddRange(new object[] {
            "全部",
            "发送",
            "已阅读",
            "已确认",
            "作废",
            "缺货",
            "完成"});
            this.cmbItemState.Location = new System.Drawing.Point(66, 12);
            this.cmbItemState.Name = "cmbItemState";
            this.cmbItemState.Size = new System.Drawing.Size(70, 20);
            this.cmbItemState.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnErpSend);
            this.panel2.Controls.Add(this.btnExpOrder);
            this.panel2.Controls.Add(this.btnDealWith);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 505);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 36);
            this.panel2.TabIndex = 8;
            // 
            // btnErpSend
            // 
            this.btnErpSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErpSend.Location = new System.Drawing.Point(502, 9);
            this.btnErpSend.Name = "btnErpSend";
            this.btnErpSend.Size = new System.Drawing.Size(92, 22);
            this.btnErpSend.TabIndex = 14;
            this.btnErpSend.Text = "发货导入";
            this.btnErpSend.UseVisualStyleBackColor = true;
            this.btnErpSend.Click += new System.EventHandler(this.btnErpSend_Click);
            // 
            // btnExpOrder
            // 
            this.btnExpOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpOrder.Location = new System.Drawing.Point(405, 9);
            this.btnExpOrder.Name = "btnExpOrder";
            this.btnExpOrder.Size = new System.Drawing.Size(92, 22);
            this.btnExpOrder.TabIndex = 13;
            this.btnExpOrder.Text = "订单导出";
            this.btnExpOrder.UseVisualStyleBackColor = true;
            this.btnExpOrder.Click += new System.EventHandler(this.btnExpOrder_Click);
            // 
            // btnDealWith
            // 
            this.btnDealWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDealWith.Location = new System.Drawing.Point(599, 9);
            this.btnDealWith.Name = "btnDealWith";
            this.btnDealWith.Size = new System.Drawing.Size(92, 22);
            this.btnDealWith.TabIndex = 12;
            this.btnDealWith.Text = "处理";
            this.btnDealWith.UseVisualStyleBackColor = true;
            this.btnDealWith.Click += new System.EventHandler(this.btnDealWith_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(696, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 22);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SalerOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.Main09;
            this.ClientSize = new System.Drawing.Size(792, 541);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SalerOrderList";
            this.Text = "订单处理 ";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SalerOrderList_PreviewKeyDown);
            this.Load += new System.EventHandler(this.SalerOrderList_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalerOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderListBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvSalerOrderList;
        private Emedchina.Commons.WinForms.PageNavigator pageNavigator1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.BindingSource orderListBindingSource;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbItemState;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDealWith;
        private System.Windows.Forms.Button btnErpSend;
        private System.Windows.Forms.Button btnExpOrder;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyer_orgid;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAK_BUYER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn REQUEST_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_STATE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderState;
    }
}