namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    partial class SelectExpSendItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectExpSendItem));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRegText = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvErpSend = new System.Windows.Forms.DataGridView();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tableLayoutPanel1);
            this.panelMain.Size = new System.Drawing.Size(503, 276);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Text = "海虹提示";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.5942F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.4058F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 276);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRegText);
            this.panel2.Controls.Add(this.btncancel);
            this.panel2.Controls.Add(this.btnYes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 32);
            this.panel2.TabIndex = 2;
            // 
            // lblRegText
            // 
            this.lblRegText.AutoSize = true;
            this.lblRegText.ForeColor = System.Drawing.Color.Red;
            this.lblRegText.Location = new System.Drawing.Point(4, 10);
            this.lblRegText.Name = "lblRegText";
            this.lblRegText.Size = new System.Drawing.Size(29, 12);
            this.lblRegText.TabIndex = 11;
            this.lblRegText.Text = "提示";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(430, 5);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(65, 23);
            this.btncancel.TabIndex = 10;
            this.btncancel.Text = "取消(&Y)";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(365, 5);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(65, 23);
            this.btnYes.TabIndex = 9;
            this.btnYes.Text = "确定(&Y)";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvErpSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 232);
            this.panel1.TabIndex = 1;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErpSend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvErpSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErpSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.MEDICAL_MODE,
            this.MEDICAL_SPEC,
            this.SPEC_UNIT,
            this.FACTORY_CODE,
            this.FACTORY_NAME,
            this.LOT_NO});
            this.dgvErpSend.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvErpSend.DataSource = this.bindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErpSend.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvErpSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErpSend.Location = new System.Drawing.Point(0, 0);
            this.dgvErpSend.MultiSelect = false;
            this.dgvErpSend.Name = "dgvErpSend";
            this.dgvErpSend.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErpSend.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvErpSend.RowHeadersVisible = false;
            this.dgvErpSend.RowHeadersWidth = 30;
            this.dgvErpSend.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvErpSend.RowTemplate.Height = 23;
            this.dgvErpSend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErpSend.Size = new System.Drawing.Size(497, 232);
            this.dgvErpSend.StandardTab = true;
            this.dgvErpSend.TabIndex = 2;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "产品编码";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "产品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            // 
            // MEDICAL_MODE
            // 
            this.MEDICAL_MODE.DataPropertyName = "MODE_NAME";
            this.MEDICAL_MODE.HeaderText = "剂型名称";
            this.MEDICAL_MODE.Name = "MEDICAL_MODE";
            this.MEDICAL_MODE.ReadOnly = true;
            // 
            // MEDICAL_SPEC
            // 
            this.MEDICAL_SPEC.DataPropertyName = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.HeaderText = "规格名称";
            this.MEDICAL_SPEC.Name = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.ReadOnly = true;
            // 
            // SPEC_UNIT
            // 
            this.SPEC_UNIT.DataPropertyName = "SPEC_UNIT";
            this.SPEC_UNIT.HeaderText = "包装单位";
            this.SPEC_UNIT.Name = "SPEC_UNIT";
            this.SPEC_UNIT.ReadOnly = true;
            // 
            // FACTORY_CODE
            // 
            this.FACTORY_CODE.DataPropertyName = "FACTORY_CODE";
            this.FACTORY_CODE.HeaderText = "生产企业编码";
            this.FACTORY_CODE.Name = "FACTORY_CODE";
            this.FACTORY_CODE.ReadOnly = true;
            this.FACTORY_CODE.Width = 130;
            // 
            // FACTORY_NAME
            // 
            this.FACTORY_NAME.DataPropertyName = "FACTORY_NAME";
            this.FACTORY_NAME.HeaderText = "生产企业名称";
            this.FACTORY_NAME.Name = "FACTORY_NAME";
            this.FACTORY_NAME.ReadOnly = true;
            this.FACTORY_NAME.Width = 130;
            // 
            // LOT_NO
            // 
            this.LOT_NO.DataPropertyName = "PERMIT_NO";
            this.LOT_NO.HeaderText = "批号";
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.ReadOnly = true;
            // 
            // SelectExpSendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 333);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectExpSendItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "交易助手";
            this.panelMain.ResumeLayout(false);
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErpSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvErpSend;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblRegText;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;





    }
}