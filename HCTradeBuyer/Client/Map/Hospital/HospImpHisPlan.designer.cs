namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    partial class HospImpHisPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl_btm = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.clmKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ORG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FULL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EASY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELPHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINKMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISFACTORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSENDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSALER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMapFLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_ORG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pl_dgvNav = new System.Windows.Forms.Panel();
            this.lb_DgvCaptionText = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            this.pl_btm.SuspendLayout();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.pl_dgvNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel);
            this.panelMain.Controls.Add(this.pl_btm);
            this.panelMain.Size = new System.Drawing.Size(830, 428);
            // 
            // panelfrontfrmtxt
            // 
            this.panelfrontfrmtxt.Size = new System.Drawing.Size(94, 36);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Location = new System.Drawing.Point(8, 14);
            this.labelfrmtxt.Size = new System.Drawing.Size(83, 12);
            this.labelfrmtxt.Text = "买方编码对照";
            // 
            // pl_btm
            // 
            this.pl_btm.Controls.Add(this.chkAll);
            this.pl_btm.Controls.Add(this.btnClose);
            this.pl_btm.Controls.Add(this.btnImport);
            this.pl_btm.Controls.Add(this.btnView);
            this.pl_btm.Controls.Add(this.txtFile);
            this.pl_btm.Controls.Add(this.label1);
            this.pl_btm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pl_btm.Location = new System.Drawing.Point(0, 390);
            this.pl_btm.Name = "pl_btm";
            this.pl_btm.Size = new System.Drawing.Size(830, 38);
            this.pl_btm.TabIndex = 1;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(167, 15);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 13;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(752, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(673, 11);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "导入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(594, 11);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "浏览(&B)...";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(367, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(221, 21);
            this.txtFile.TabIndex = 1;
            this.txtFile.Tag = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "买方编码文件:";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.pl_dgvNav);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(830, 390);
            this.panel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 367);
            this.panel1.TabIndex = 4;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmKey,
            this.ORG_ID,
            this.CODE,
            this.FULL_NAME,
            this.EASY_NAME,
            this.ADDRESS,
            this.POSTCODE,
            this.TELPHONE,
            this.LINKMAN,
            this.ISFACTORY,
            this.ISSENDER,
            this.ISSALER,
            this.isMapFLAG,
            this.DATA_ORG_ID});
            this.dataGridView.DataSource = this.bindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(830, 367);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.Tag = "";
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // clmKey
            // 
            this.clmKey.HeaderText = "选择";
            this.clmKey.Name = "clmKey";
            this.clmKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmKey.Width = 54;
            // 
            // ORG_ID
            // 
            this.ORG_ID.DataPropertyName = "ORG_ID";
            this.ORG_ID.HeaderText = "买方ID";
            this.ORG_ID.Name = "ORG_ID";
            this.ORG_ID.Width = 66;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.CODE.HeaderText = "买方编码";
            this.CODE.Name = "CODE";
            this.CODE.Width = 78;
            // 
            // FULL_NAME
            // 
            this.FULL_NAME.DataPropertyName = "FULL_NAME";
            this.FULL_NAME.HeaderText = "买方全称";
            this.FULL_NAME.Name = "FULL_NAME";
            this.FULL_NAME.Width = 78;
            // 
            // EASY_NAME
            // 
            this.EASY_NAME.DataPropertyName = "EASY_NAME";
            this.EASY_NAME.HeaderText = "买方简称";
            this.EASY_NAME.Name = "EASY_NAME";
            this.EASY_NAME.Width = 78;
            // 
            // ADDRESS
            // 
            this.ADDRESS.DataPropertyName = "ADDRESS";
            this.ADDRESS.HeaderText = "买方地址";
            this.ADDRESS.Name = "ADDRESS";
            this.ADDRESS.Width = 78;
            // 
            // POSTCODE
            // 
            this.POSTCODE.DataPropertyName = "POSTCODE";
            this.POSTCODE.HeaderText = "邮政编码";
            this.POSTCODE.Name = "POSTCODE";
            this.POSTCODE.Width = 78;
            // 
            // TELPHONE
            // 
            this.TELPHONE.DataPropertyName = "TELPHONE";
            this.TELPHONE.HeaderText = "联系电话";
            this.TELPHONE.Name = "TELPHONE";
            this.TELPHONE.Width = 78;
            // 
            // LINKMAN
            // 
            this.LINKMAN.DataPropertyName = "LINKMAN";
            this.LINKMAN.HeaderText = "联系人";
            this.LINKMAN.Name = "LINKMAN";
            this.LINKMAN.Width = 66;
            // 
            // ISFACTORY
            // 
            this.ISFACTORY.DataPropertyName = "ISFACTORY";
            this.ISFACTORY.HeaderText = "是否生产企业";
            this.ISFACTORY.Name = "ISFACTORY";
            this.ISFACTORY.Visible = false;
            this.ISFACTORY.Width = 102;
            // 
            // ISSENDER
            // 
            this.ISSENDER.DataPropertyName = "ISSENDER";
            this.ISSENDER.HeaderText = "是否配送企业";
            this.ISSENDER.Name = "ISSENDER";
            this.ISSENDER.Visible = false;
            this.ISSENDER.Width = 102;
            // 
            // ISSALER
            // 
            this.ISSALER.DataPropertyName = "ISSALER";
            this.ISSALER.HeaderText = "是否经销企业";
            this.ISSALER.Name = "ISSALER";
            this.ISSALER.Visible = false;
            this.ISSALER.Width = 102;
            // 
            // isMapFLAG
            // 
            this.isMapFLAG.DataPropertyName = "isMapFLAG";
            this.isMapFLAG.HeaderText = "isMapFLAG";
            this.isMapFLAG.Name = "isMapFLAG";
            this.isMapFLAG.Visible = false;
            this.isMapFLAG.Width = 84;
            // 
            // DATA_ORG_ID
            // 
            this.DATA_ORG_ID.DataPropertyName = "DATA_ORG_ID";
            this.DATA_ORG_ID.HeaderText = "DATA_ORG_ID";
            this.DATA_ORG_ID.Name = "DATA_ORG_ID";
            this.DATA_ORG_ID.Visible = false;
            this.DATA_ORG_ID.Width = 96;
            // 
            // pl_dgvNav
            // 
            this.pl_dgvNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_dgvNav.Controls.Add(this.lb_DgvCaptionText);
            this.pl_dgvNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_dgvNav.Location = new System.Drawing.Point(0, 0);
            this.pl_dgvNav.Name = "pl_dgvNav";
            this.pl_dgvNav.Size = new System.Drawing.Size(830, 23);
            this.pl_dgvNav.TabIndex = 3;
            // 
            // lb_DgvCaptionText
            // 
            this.lb_DgvCaptionText.AutoSize = true;
            this.lb_DgvCaptionText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DgvCaptionText.Location = new System.Drawing.Point(3, 6);
            this.lb_DgvCaptionText.Name = "lb_DgvCaptionText";
            this.lb_DgvCaptionText.Size = new System.Drawing.Size(0, 12);
            this.lb_DgvCaptionText.TabIndex = 0;
            // 
            // HospImpHisPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 475);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "HospImpHisPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入买方编码对照列表";
            this.panelMain.ResumeLayout(false);
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            this.pl_btm.ResumeLayout(false);
            this.pl_btm.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.pl_dgvNav.ResumeLayout(false);
            this.pl_dgvNav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_btm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel pl_dgvNav;
        private System.Windows.Forms.Label lb_DgvCaptionText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORG_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FULL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn EASY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELPHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINKMAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISFACTORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSENDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSALER;
        private System.Windows.Forms.DataGridViewTextBoxColumn isMapFLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_ORG_ID;

    }
}