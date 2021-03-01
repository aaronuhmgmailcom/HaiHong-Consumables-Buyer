namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    partial class hospCorpMapList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl_top = new System.Windows.Forms.Panel();
            this.tb_CorpName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_CorpCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_EmedCorpName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pl_ctl = new System.Windows.Forms.Panel();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.pl_dgv = new System.Windows.Forms.Panel();
            this.dgv_EmedCorpMapList = new System.Windows.Forms.DataGridView();
            this.pl_nav = new System.Windows.Forms.Panel();
            this.lb_nav1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            this.pl_top.SuspendLayout();
            this.pl_ctl.SuspendLayout();
            this.pl_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmedCorpMapList)).BeginInit();
            this.pl_nav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.pl_dgv);
            this.panelMain.Controls.Add(this.pl_ctl);
            this.panelMain.Controls.Add(this.pl_top);
            this.panelMain.Size = new System.Drawing.Size(469, 273);
            // 
            // panelfrontfrmtxt
            // 
            this.panelfrontfrmtxt.Size = new System.Drawing.Size(154, 36);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Location = new System.Drawing.Point(3, 14);
            this.labelfrmtxt.Size = new System.Drawing.Size(148, 12);
            this.labelfrmtxt.Text = "海虹买方一对多匹配提示";
            // 
            // pl_top
            // 
            this.pl_top.Controls.Add(this.tb_CorpName);
            this.pl_top.Controls.Add(this.label3);
            this.pl_top.Controls.Add(this.tb_CorpCode);
            this.pl_top.Controls.Add(this.label2);
            this.pl_top.Controls.Add(this.tb_EmedCorpName);
            this.pl_top.Controls.Add(this.label1);
            this.pl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_top.Location = new System.Drawing.Point(0, 0);
            this.pl_top.Name = "pl_top";
            this.pl_top.Size = new System.Drawing.Size(469, 87);
            this.pl_top.TabIndex = 0;
            // 
            // tb_CorpName
            // 
            this.tb_CorpName.Enabled = false;
            this.tb_CorpName.Location = new System.Drawing.Point(175, 58);
            this.tb_CorpName.Name = "tb_CorpName";
            this.tb_CorpName.Size = new System.Drawing.Size(262, 21);
            this.tb_CorpName.TabIndex = 5;
            this.tb_CorpName.Tag = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "当前要匹配的ERP买方名称：";
            // 
            // tb_CorpCode
            // 
            this.tb_CorpCode.Enabled = false;
            this.tb_CorpCode.Location = new System.Drawing.Point(175, 34);
            this.tb_CorpCode.Name = "tb_CorpCode";
            this.tb_CorpCode.Size = new System.Drawing.Size(262, 21);
            this.tb_CorpCode.TabIndex = 3;
            this.tb_CorpCode.Tag = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前要匹配的ERP买方编码：";
            // 
            // tb_EmedCorpName
            // 
            this.tb_EmedCorpName.Enabled = false;
            this.tb_EmedCorpName.Location = new System.Drawing.Point(175, 6);
            this.tb_EmedCorpName.Name = "tb_EmedCorpName";
            this.tb_EmedCorpName.Size = new System.Drawing.Size(262, 21);
            this.tb_EmedCorpName.TabIndex = 1;
            this.tb_EmedCorpName.Tag = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "海虹买方名称：";
            // 
            // pl_ctl
            // 
            this.pl_ctl.Controls.Add(this.btnNo);
            this.pl_ctl.Controls.Add(this.btnYes);
            this.pl_ctl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pl_ctl.Location = new System.Drawing.Point(0, 228);
            this.pl_ctl.Name = "pl_ctl";
            this.pl_ctl.Size = new System.Drawing.Size(469, 45);
            this.pl_ctl.TabIndex = 2;
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(384, 11);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(78, 23);
            this.btnNo.TabIndex = 23;
            this.btnNo.Text = "否(&F)";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(298, 11);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(78, 23);
            this.btnYes.TabIndex = 22;
            this.btnYes.Text = "是(&T)";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // pl_dgv
            // 
            this.pl_dgv.Controls.Add(this.dgv_EmedCorpMapList);
            this.pl_dgv.Controls.Add(this.pl_nav);
            this.pl_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_dgv.Location = new System.Drawing.Point(0, 87);
            this.pl_dgv.Name = "pl_dgv";
            this.pl_dgv.Size = new System.Drawing.Size(469, 141);
            this.pl_dgv.TabIndex = 3;
            // 
            // dgv_EmedCorpMapList
            // 
            this.dgv_EmedCorpMapList.AllowUserToAddRows = false;
            this.dgv_EmedCorpMapList.AllowUserToDeleteRows = false;
            this.dgv_EmedCorpMapList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EmedCorpMapList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_EmedCorpMapList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmedCorpMapList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_EmedCorpMapList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_EmedCorpMapList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_EmedCorpMapList.Location = new System.Drawing.Point(0, 27);
            this.dgv_EmedCorpMapList.MultiSelect = false;
            this.dgv_EmedCorpMapList.Name = "dgv_EmedCorpMapList";
            this.dgv_EmedCorpMapList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EmedCorpMapList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_EmedCorpMapList.RowTemplate.Height = 23;
            this.dgv_EmedCorpMapList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmedCorpMapList.Size = new System.Drawing.Size(469, 114);
            this.dgv_EmedCorpMapList.TabIndex = 4;
            // 
            // pl_nav
            // 
            this.pl_nav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_nav.Controls.Add(this.lb_nav1);
            this.pl_nav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_nav.Location = new System.Drawing.Point(0, 0);
            this.pl_nav.Name = "pl_nav";
            this.pl_nav.Size = new System.Drawing.Size(469, 27);
            this.pl_nav.TabIndex = 0;
            // 
            // lb_nav1
            // 
            this.lb_nav1.AutoSize = true;
            this.lb_nav1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_nav1.Location = new System.Drawing.Point(7, 6);
            this.lb_nav1.Name = "lb_nav1";
            this.lb_nav1.Size = new System.Drawing.Size(143, 12);
            this.lb_nav1.TabIndex = 7;
            this.lb_nav1.Text = "已匹配的ERP买方列表：";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CODE";
            this.Column1.HeaderText = "买方编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FULL_NAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "买方全称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "EASY_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "买方简称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // hospCorpMapList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 330);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "hospCorpMapList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "海虹医院一对多匹配提示";
            this.Load += new System.EventHandler(this.FormCorpMapList_Load);
            this.panelMain.ResumeLayout(false);
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            this.pl_top.ResumeLayout(false);
            this.pl_top.PerformLayout();
            this.pl_ctl.ResumeLayout(false);
            this.pl_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmedCorpMapList)).EndInit();
            this.pl_nav.ResumeLayout(false);
            this.pl_nav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_dgv;
        private System.Windows.Forms.Panel pl_ctl;
        private System.Windows.Forms.Panel pl_top;
        private System.Windows.Forms.DataGridView dgv_EmedCorpMapList;
        private System.Windows.Forms.Panel pl_nav;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_EmedCorpName;
        private System.Windows.Forms.TextBox tb_CorpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_CorpCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_nav1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}