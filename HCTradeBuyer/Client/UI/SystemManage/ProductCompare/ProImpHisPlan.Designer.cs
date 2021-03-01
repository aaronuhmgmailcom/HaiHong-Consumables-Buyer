namespace Emedchina.TradeAssistant.Client.His.Product
{
    partial class ProImpHisPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.txtImportFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.clmKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMON_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_SPEC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USE_UNIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USE_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC_UNIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAND_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERMIT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENDER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENDER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PACKAGE_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel3);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Size = new System.Drawing.Size(724, 412);
            // 
            // panelfrontfrmtxt
            // 
            this.panelfrontfrmtxt.Size = new System.Drawing.Size(75, 36);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Size = new System.Drawing.Size(70, 12);
            this.labelfrmtxt.Text = "导入产品表";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.txtImportFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(404, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 16;
            this.btnView.Text = "浏览(&B)...";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtImportFilePath
            // 
            this.txtImportFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFilePath.Enabled = false;
            this.txtImportFilePath.Location = new System.Drawing.Point(177, 10);
            this.txtImportFilePath.Name = "txtImportFilePath";
            this.txtImportFilePath.Size = new System.Drawing.Size(221, 21);
            this.txtImportFilePath.TabIndex = 15;
            this.txtImportFilePath.Tag = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "请选择导产品表文件(Excel)：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 51);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(635, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(556, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 18;
            this.btnImport.Text = "导入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(27, 17);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 17;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 323);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmKey,
            this.PRODUCT_CODE,
            this.MEDICAL_CODE,
            this.PRODUCT_NAME,
            this.COMMON_NAME,
            this.MODE_ID,
            this.MODE_NAME,
            this.MEDICAL_SPEC_ID,
            this.MEDICAL_SPEC,
            this.USE_UNIT_ID,
            this.USE_UNIT,
            this.SPEC_UNIT_ID,
            this.SPEC_UNIT,
            this.STAND_RATE,
            this.FACTORY_CODE,
            this.FACTORY_NAME,
            this.product_id,
            this.data_product_id,
            this.PERMIT_NO,
            this.SALER_CODE,
            this.SALER_NAME,
            this.SENDER_CODE,
            this.SENDER_NAME,
            this.STOCK_ID,
            this.STOCK_NAME,
            this.PACKAGE_RATE});
            this.dataGridView.DataSource = this.bindingSource1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(724, 323);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.Tag = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // clmKey
            // 
            this.clmKey.Frozen = true;
            this.clmKey.HeaderText = "选择";
            this.clmKey.Name = "clmKey";
            this.clmKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmKey.Width = 54;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "HIS产品ID码";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.Width = 96;
            // 
            // MEDICAL_CODE
            // 
            this.MEDICAL_CODE.DataPropertyName = "MEDICAL_CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MEDICAL_CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.MEDICAL_CODE.HeaderText = "HIS产品编码";
            this.MEDICAL_CODE.Name = "MEDICAL_CODE";
            this.MEDICAL_CODE.Width = 96;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "商品名";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.Width = 66;
            // 
            // COMMON_NAME
            // 
            this.COMMON_NAME.DataPropertyName = "COMMON_NAME";
            this.COMMON_NAME.HeaderText = "通用名";
            this.COMMON_NAME.Name = "COMMON_NAME";
            this.COMMON_NAME.Width = 66;
            // 
            // MODE_ID
            // 
            this.MODE_ID.DataPropertyName = "MODE_ID";
            this.MODE_ID.HeaderText = "剂型ID";
            this.MODE_ID.Name = "MODE_ID";
            this.MODE_ID.Width = 66;
            // 
            // MODE_NAME
            // 
            this.MODE_NAME.DataPropertyName = "MODE_NAME";
            this.MODE_NAME.HeaderText = "剂型名称";
            this.MODE_NAME.Name = "MODE_NAME";
            this.MODE_NAME.Width = 78;
            // 
            // MEDICAL_SPEC_ID
            // 
            this.MEDICAL_SPEC_ID.DataPropertyName = "MEDICAL_SPEC_ID";
            this.MEDICAL_SPEC_ID.HeaderText = "规格ID";
            this.MEDICAL_SPEC_ID.Name = "MEDICAL_SPEC_ID";
            this.MEDICAL_SPEC_ID.Width = 66;
            // 
            // MEDICAL_SPEC
            // 
            this.MEDICAL_SPEC.DataPropertyName = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.HeaderText = "规格包装";
            this.MEDICAL_SPEC.Name = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.Width = 78;
            // 
            // USE_UNIT_ID
            // 
            this.USE_UNIT_ID.DataPropertyName = "USE_UNIT_ID";
            this.USE_UNIT_ID.HeaderText = "最小使用单位ID";
            this.USE_UNIT_ID.Name = "USE_UNIT_ID";
            this.USE_UNIT_ID.Width = 83;
            // 
            // USE_UNIT
            // 
            this.USE_UNIT.DataPropertyName = "USE_UNIT";
            this.USE_UNIT.HeaderText = "最小使用单位";
            this.USE_UNIT.Name = "USE_UNIT";
            this.USE_UNIT.Width = 72;
            // 
            // SPEC_UNIT_ID
            // 
            this.SPEC_UNIT_ID.DataPropertyName = "SPEC_UNIT_ID";
            this.SPEC_UNIT_ID.HeaderText = "最小包装单位ID";
            this.SPEC_UNIT_ID.Name = "SPEC_UNIT_ID";
            this.SPEC_UNIT_ID.Width = 83;
            // 
            // SPEC_UNIT
            // 
            this.SPEC_UNIT.DataPropertyName = "SPEC_UNIT";
            this.SPEC_UNIT.HeaderText = "包装单位";
            this.SPEC_UNIT.Name = "SPEC_UNIT";
            this.SPEC_UNIT.Width = 61;
            // 
            // STAND_RATE
            // 
            this.STAND_RATE.DataPropertyName = "STAND_RATE";
            this.STAND_RATE.HeaderText = "HIS单位转换比";
            this.STAND_RATE.Name = "STAND_RATE";
            this.STAND_RATE.Width = 78;
            // 
            // FACTORY_CODE
            // 
            this.FACTORY_CODE.DataPropertyName = "FACTORY_CODE";
            this.FACTORY_CODE.HeaderText = "生产企业编码";
            this.FACTORY_CODE.Name = "FACTORY_CODE";
            this.FACTORY_CODE.Width = 72;
            // 
            // FACTORY_NAME
            // 
            this.FACTORY_NAME.DataPropertyName = "FACTORY_NAME";
            this.FACTORY_NAME.HeaderText = "生产企业名称";
            this.FACTORY_NAME.Name = "FACTORY_NAME";
            this.FACTORY_NAME.Width = 72;
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.HeaderText = "海虹产品ID";
            this.product_id.Name = "product_id";
            this.product_id.Width = 72;
            // 
            // data_product_id
            // 
            this.data_product_id.DataPropertyName = "data_product_id";
            this.data_product_id.HeaderText = "海虹数据产品ID";
            this.data_product_id.Name = "data_product_id";
            this.data_product_id.Width = 83;
            // 
            // PERMIT_NO
            // 
            this.PERMIT_NO.DataPropertyName = "PERMIT_NO";
            this.PERMIT_NO.HeaderText = "批号";
            this.PERMIT_NO.Name = "PERMIT_NO";
            this.PERMIT_NO.Width = 51;
            // 
            // SALER_CODE
            // 
            this.SALER_CODE.DataPropertyName = "SALER_CODE";
            this.SALER_CODE.HeaderText = "经销企业ID";
            this.SALER_CODE.Name = "SALER_CODE";
            this.SALER_CODE.Width = 72;
            // 
            // SALER_NAME
            // 
            this.SALER_NAME.DataPropertyName = "SALER_NAME";
            this.SALER_NAME.HeaderText = "经销企业名称";
            this.SALER_NAME.Name = "SALER_NAME";
            this.SALER_NAME.Width = 72;
            // 
            // SENDER_CODE
            // 
            this.SENDER_CODE.DataPropertyName = "SENDER_CODE";
            this.SENDER_CODE.HeaderText = "配送企业ID";
            this.SENDER_CODE.Name = "SENDER_CODE";
            this.SENDER_CODE.Width = 72;
            // 
            // SENDER_NAME
            // 
            this.SENDER_NAME.DataPropertyName = "SENDER_NAME";
            this.SENDER_NAME.HeaderText = "配送企业名称";
            this.SENDER_NAME.Name = "SENDER_NAME";
            this.SENDER_NAME.Width = 72;
            // 
            // STOCK_ID
            // 
            this.STOCK_ID.DataPropertyName = "STOCK_ID";
            this.STOCK_ID.HeaderText = "库房ID";
            this.STOCK_ID.Name = "STOCK_ID";
            this.STOCK_ID.Width = 61;
            // 
            // STOCK_NAME
            // 
            this.STOCK_NAME.DataPropertyName = "STOCK_NAME";
            this.STOCK_NAME.HeaderText = "库房名称";
            this.STOCK_NAME.Name = "STOCK_NAME";
            this.STOCK_NAME.Width = 61;
            // 
            // PACKAGE_RATE
            // 
            this.PACKAGE_RATE.DataPropertyName = "PACKAGE_RATE";
            this.PACKAGE_RATE.HeaderText = "包装转换比";
            this.PACKAGE_RATE.Name = "PACKAGE_RATE";
            this.PACKAGE_RATE.Width = 72;
            // 
            // ProImpHisPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 469);
            this.MinimizeBox = false;
            this.Name = "ProImpHisPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入产品表";
            this.panelMain.ResumeLayout(false);
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtImportFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMON_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_SPEC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn USE_UNIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USE_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC_UNIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAND_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERMIT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENDER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENDER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PACKAGE_RATE;
    }
}