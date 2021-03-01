namespace Emedchina.TradeAssistant.Client.Map.Product
{
    partial class ProIDMatchShowBoxForm
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
            this.lblHiscount = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblRegText = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.dgvProIDCompare = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxProducer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMedicalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMON_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProIDCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblHiscount);
            this.panelMain.Controls.Add(this.lbl1);
            this.panelMain.Controls.Add(this.lblRegText);
            this.panelMain.Controls.Add(this.btnNo);
            this.panelMain.Controls.Add(this.btnYes);
            this.panelMain.Controls.Add(this.dgvProIDCompare);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Size = new System.Drawing.Size(427, 323);
            // 
            // panelfrontfrmtxt
            // 
            this.panelfrontfrmtxt.Size = new System.Drawing.Size(153, 36);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Size = new System.Drawing.Size(148, 12);
            this.labelfrmtxt.Text = "海虹产品一对多匹配提示";
            // 
            // lblHiscount
            // 
            this.lblHiscount.AutoSize = true;
            this.lblHiscount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHiscount.Location = new System.Drawing.Point(199, 85);
            this.lblHiscount.Name = "lblHiscount";
            this.lblHiscount.Size = new System.Drawing.Size(38, 12);
            this.lblHiscount.TabIndex = 20;
            this.lblHiscount.Text = "共0条";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(11, 85);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(182, 12);
            this.lbl1.TabIndex = 19;
            this.lbl1.Text = "该海虹产品已匹配的HIS数据：";
            // 
            // lblRegText
            // 
            this.lblRegText.AutoSize = true;
            this.lblRegText.ForeColor = System.Drawing.Color.Red;
            this.lblRegText.Location = new System.Drawing.Point(43, 267);
            this.lblRegText.Name = "lblRegText";
            this.lblRegText.Size = new System.Drawing.Size(341, 12);
            this.lblRegText.TabIndex = 18;
            this.lblRegText.Text = "该海虹产品已匹配上述HIS数据，是否继续匹配当前的HIS产品？";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(325, 287);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(89, 23);
            this.btnNo.TabIndex = 17;
            this.btnNo.Text = "否(&N)";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(236, 287);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(89, 23);
            this.btnYes.TabIndex = 16;
            this.btnYes.Text = "是(&Y)";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // dgvProIDCompare
            // 
            this.dgvProIDCompare.AllowUserToAddRows = false;
            this.dgvProIDCompare.AllowUserToDeleteRows = false;
            this.dgvProIDCompare.AllowUserToResizeRows = false;
            this.dgvProIDCompare.AutoGenerateColumns = false;
            this.dgvProIDCompare.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProIDCompare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProIDCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProIDCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_CODE,
            this.COMMON_NAME,
            this.MODE_NAME,
            this.MEDICAL_SPEC,
            this.FACTORY_NAME,
            this.PRODUCT_ID});
            this.dgvProIDCompare.DataSource = this.bindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProIDCompare.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProIDCompare.Location = new System.Drawing.Point(11, 104);
            this.dgvProIDCompare.Margin = new System.Windows.Forms.Padding(100);
            this.dgvProIDCompare.MultiSelect = false;
            this.dgvProIDCompare.Name = "dgvProIDCompare";
            this.dgvProIDCompare.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProIDCompare.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProIDCompare.RowHeadersWidth = 30;
            this.dgvProIDCompare.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProIDCompare.RowTemplate.Height = 23;
            this.dgvProIDCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProIDCompare.Size = new System.Drawing.Size(405, 152);
            this.dgvProIDCompare.StandardTab = true;
            this.dgvProIDCompare.TabIndex = 15;
            this.dgvProIDCompare.DoubleClick += new System.EventHandler(this.dgvProIDCompare_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxProducer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxSpec);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxMedicalName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxProductName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 75);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "海虹产品";
            // 
            // tbxProducer
            // 
            this.tbxProducer.Enabled = false;
            this.tbxProducer.Location = new System.Drawing.Point(272, 42);
            this.tbxProducer.Name = "tbxProducer";
            this.tbxProducer.Size = new System.Drawing.Size(112, 21);
            this.tbxProducer.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "生产企业";
            // 
            // tbxSpec
            // 
            this.tbxSpec.Enabled = false;
            this.tbxSpec.Location = new System.Drawing.Point(75, 42);
            this.tbxSpec.Name = "tbxSpec";
            this.tbxSpec.Size = new System.Drawing.Size(112, 21);
            this.tbxSpec.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "规格包装";
            // 
            // tbxMedicalName
            // 
            this.tbxMedicalName.Enabled = false;
            this.tbxMedicalName.Location = new System.Drawing.Point(75, 14);
            this.tbxMedicalName.Name = "tbxMedicalName";
            this.tbxMedicalName.Size = new System.Drawing.Size(112, 21);
            this.tbxMedicalName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "商品名";
            // 
            // tbxProductName
            // 
            this.tbxProductName.Enabled = false;
            this.tbxProductName.Location = new System.Drawing.Point(272, 14);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(112, 21);
            this.tbxProductName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "通用名";
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            this.PRODUCT_CODE.HeaderText = "产品编号";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            // 
            // COMMON_NAME
            // 
            this.COMMON_NAME.DataPropertyName = "COMMON_NAME";
            this.COMMON_NAME.HeaderText = "产品名称";
            this.COMMON_NAME.Name = "COMMON_NAME";
            this.COMMON_NAME.ReadOnly = true;
            // 
            // MODE_NAME
            // 
            this.MODE_NAME.DataPropertyName = "MODE_NAME";
            this.MODE_NAME.HeaderText = "剂型";
            this.MODE_NAME.Name = "MODE_NAME";
            this.MODE_NAME.ReadOnly = true;
            // 
            // MEDICAL_SPEC
            // 
            this.MEDICAL_SPEC.DataPropertyName = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.HeaderText = "规格";
            this.MEDICAL_SPEC.Name = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.ReadOnly = true;
            // 
            // FACTORY_NAME
            // 
            this.FACTORY_NAME.DataPropertyName = "FACTORY_NAME";
            this.FACTORY_NAME.HeaderText = "生产企业";
            this.FACTORY_NAME.Name = "FACTORY_NAME";
            this.FACTORY_NAME.ReadOnly = true;
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.DataPropertyName = "PRODUCT_ID";
            this.PRODUCT_ID.HeaderText = "PRODUCT_ID";
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.ReadOnly = true;
            this.PRODUCT_ID.Visible = false;
            // 
            // ProIDMatchShowBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 380);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProIDMatchShowBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "海虹产品一对多匹配提示";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProIDMatchShowBoxForm_FormClosed);
            this.Load += new System.EventHandler(this.ProIDMatchShowBoxForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProIDCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHiscount;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblRegText;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.DataGridView dgvProIDCompare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxProducer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMedicalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMON_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
    }
}