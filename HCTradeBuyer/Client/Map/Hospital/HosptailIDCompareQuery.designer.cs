namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    partial class HosptailIDCompareQuery
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelNav = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbCompare = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxEPname = new System.Windows.Forms.TextBox();
            this.panelPurchase = new System.Windows.Forms.Panel();
            this.dgvEPItem = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spell_abbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_wb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyer_orgid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItembindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pageNavigatorEPIDComItem = new Emedchina.Commons.WinForms.PageNavigator();
            this.panelOrderItem = new System.Windows.Forms.Panel();
            this.dgvEPHisItem = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FULL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EASY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelBtm = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblHiscount = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelfrontfrmtxt.SuspendLayout();
            this.panelNav.SuspendLayout();
            this.panelPurchase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItembindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelOrderItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPHisItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisbindingSource)).BeginInit();
            this.panelBtm.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelOrderItem);
            this.panelMain.Controls.Add(this.panelPurchase);
            this.panelMain.Controls.Add(this.panelNav);
            this.panelMain.Size = new System.Drawing.Size(607, 579);
            // 
            // panelfrontfrmtxt
            // 
            this.panelfrontfrmtxt.Size = new System.Drawing.Size(115, 36);
            // 
            // labelfrmtxt
            // 
            this.labelfrmtxt.Location = new System.Drawing.Point(3, 14);
            this.labelfrmtxt.Size = new System.Drawing.Size(109, 12);
            this.labelfrmtxt.Text = "买方编码对照查询";
            // 
            // panelNav
            // 
            this.panelNav.Controls.Add(this.label3);
            this.panelNav.Controls.Add(this.cbbCompare);
            this.panelNav.Controls.Add(this.btnSearch);
            this.panelNav.Controls.Add(this.label1);
            this.panelNav.Controls.Add(this.tbxEPname);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(607, 29);
            this.panelNav.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "对照关系：";
            // 
            // cbbCompare
            // 
            this.cbbCompare.AutoCompleteCustomSource.AddRange(new string[] {
            "全部数据",
            "一对多",
            "一对一"});
            this.cbbCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCompare.Items.AddRange(new object[] {
            "全部数据",
            "一对多",
            "一对一"});
            this.cbbCompare.Location = new System.Drawing.Point(298, 5);
            this.cbbCompare.Name = "cbbCompare";
            this.cbbCompare.Size = new System.Drawing.Size(124, 20);
            this.cbbCompare.TabIndex = 11;
            this.cbbCompare.SelectedIndexChanged += new System.EventHandler(this.cbbCompare_SelectedIndexChanged);
            this.cbbCompare.Click += new System.EventHandler(this.cbbCompare_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(496, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 22);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "买方机构：";
            // 
            // tbxEPname
            // 
            this.tbxEPname.Location = new System.Drawing.Point(92, 5);
            this.tbxEPname.Name = "tbxEPname";
            this.tbxEPname.Size = new System.Drawing.Size(124, 21);
            this.tbxEPname.TabIndex = 0;
            this.tbxEPname.TextChanged += new System.EventHandler(this.tbxEPname_TextChanged);
            this.tbxEPname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxEPname_KeyDown);
            // 
            // panelPurchase
            // 
            this.panelPurchase.Controls.Add(this.dgvEPItem);
            this.panelPurchase.Controls.Add(this.panel1);
            this.panelPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPurchase.Location = new System.Drawing.Point(0, 29);
            this.panelPurchase.Name = "panelPurchase";
            this.panelPurchase.Size = new System.Drawing.Size(607, 340);
            this.panelPurchase.TabIndex = 2;
            // 
            // dgvEPItem
            // 
            this.dgvEPItem.AllowUserToAddRows = false;
            this.dgvEPItem.AllowUserToDeleteRows = false;
            this.dgvEPItem.AutoGenerateColumns = false;
            this.dgvEPItem.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEPItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvEPItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEPItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.abbr,
            this.spell_abbr,
            this.name_wb,
            this.buyer_orgid});
            this.dgvEPItem.DataSource = this.ItembindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEPItem.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvEPItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEPItem.Location = new System.Drawing.Point(0, 26);
            this.dgvEPItem.MultiSelect = false;
            this.dgvEPItem.Name = "dgvEPItem";
            this.dgvEPItem.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEPItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvEPItem.RowHeadersVisible = false;
            this.dgvEPItem.RowTemplate.Height = 23;
            this.dgvEPItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEPItem.Size = new System.Drawing.Size(607, 314);
            this.dgvEPItem.TabIndex = 12;
            this.dgvEPItem.Tag = "1";
            this.dgvEPItem.CurrentCellChanged += new System.EventHandler(this.dgvEPItem_CurrentCellChanged);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle8;
            this.name.HeaderText = "海虹买方全称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 110;
            // 
            // abbr
            // 
            this.abbr.DataPropertyName = "abbr";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.abbr.DefaultCellStyle = dataGridViewCellStyle9;
            this.abbr.HeaderText = "海虹买方简称";
            this.abbr.Name = "abbr";
            this.abbr.ReadOnly = true;
            this.abbr.Width = 110;
            // 
            // spell_abbr
            // 
            this.spell_abbr.DataPropertyName = "spell_abbr";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.spell_abbr.DefaultCellStyle = dataGridViewCellStyle10;
            this.spell_abbr.HeaderText = "拼音简码";
            this.spell_abbr.Name = "spell_abbr";
            this.spell_abbr.ReadOnly = true;
            // 
            // name_wb
            // 
            this.name_wb.DataPropertyName = "name_wb";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name_wb.DefaultCellStyle = dataGridViewCellStyle11;
            this.name_wb.HeaderText = "五笔简码";
            this.name_wb.Name = "name_wb";
            this.name_wb.ReadOnly = true;
            // 
            // buyer_orgid
            // 
            this.buyer_orgid.DataPropertyName = "buyer_orgid";
            this.buyer_orgid.HeaderText = "buyer_orgid";
            this.buyer_orgid.Name = "buyer_orgid";
            this.buyer_orgid.ReadOnly = true;
            this.buyer_orgid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pageNavigatorEPIDComItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 26);
            this.panel1.TabIndex = 11;
            // 
            // pageNavigatorEPIDComItem
            // 
            this.pageNavigatorEPIDComItem.CurrentPageIndex = 0;
            this.pageNavigatorEPIDComItem.ItemCount = 0;
            this.pageNavigatorEPIDComItem.Location = new System.Drawing.Point(0, 0);
            this.pageNavigatorEPIDComItem.Name = "pageNavigatorEPIDComItem";
            this.pageNavigatorEPIDComItem.Size = new System.Drawing.Size(605, 25);
            this.pageNavigatorEPIDComItem.TabIndex = 11;
            this.pageNavigatorEPIDComItem.Text = "pageNavigator1";
            this.pageNavigatorEPIDComItem.PageIndexOrPageSizeChanged += new Emedchina.Commons.WinForms.PageChangedEventHandler(this.pageNavigatorProIDComItem_PageIndexOrPageSizeChanged);
            // 
            // panelOrderItem
            // 
            this.panelOrderItem.Controls.Add(this.dgvEPHisItem);
            this.panelOrderItem.Controls.Add(this.panelBtm);
            this.panelOrderItem.Controls.Add(this.panel4);
            this.panelOrderItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrderItem.Location = new System.Drawing.Point(0, 369);
            this.panelOrderItem.Name = "panelOrderItem";
            this.panelOrderItem.Size = new System.Drawing.Size(607, 210);
            this.panelOrderItem.TabIndex = 3;
            // 
            // dgvEPHisItem
            // 
            this.dgvEPHisItem.AllowUserToAddRows = false;
            this.dgvEPHisItem.AllowUserToDeleteRows = false;
            this.dgvEPHisItem.AutoGenerateColumns = false;
            this.dgvEPHisItem.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEPHisItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEPHisItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEPHisItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.FULL_NAME,
            this.EASY_NAME});
            this.dgvEPHisItem.DataSource = this.hisbindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEPHisItem.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEPHisItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEPHisItem.Location = new System.Drawing.Point(0, 19);
            this.dgvEPHisItem.Name = "dgvEPHisItem";
            this.dgvEPHisItem.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEPHisItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEPHisItem.RowHeadersVisible = false;
            this.dgvEPHisItem.RowTemplate.Height = 23;
            this.dgvEPHisItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEPHisItem.Size = new System.Drawing.Size(607, 146);
            this.dgvEPHisItem.TabIndex = 14;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CODE.DefaultCellStyle = dataGridViewCellStyle2;
            this.CODE.HeaderText = "ERP买方编码";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            // 
            // FULL_NAME
            // 
            this.FULL_NAME.DataPropertyName = "FULL_NAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FULL_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.FULL_NAME.HeaderText = "买方全称";
            this.FULL_NAME.Name = "FULL_NAME";
            this.FULL_NAME.ReadOnly = true;
            // 
            // EASY_NAME
            // 
            this.EASY_NAME.DataPropertyName = "EASY_NAME";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EASY_NAME.DefaultCellStyle = dataGridViewCellStyle4;
            this.EASY_NAME.HeaderText = "买方简称";
            this.EASY_NAME.Name = "EASY_NAME";
            this.EASY_NAME.ReadOnly = true;
            // 
            // panelBtm
            // 
            this.panelBtm.Controls.Add(this.btnClose);
            this.panelBtm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtm.Location = new System.Drawing.Point(0, 165);
            this.panelBtm.Name = "panelBtm";
            this.panelBtm.Size = new System.Drawing.Size(607, 45);
            this.panelBtm.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(513, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblHiscount);
            this.panel4.Controls.Add(this.lbl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(607, 19);
            this.panel4.TabIndex = 11;
            // 
            // lblHiscount
            // 
            this.lblHiscount.AutoSize = true;
            this.lblHiscount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHiscount.Location = new System.Drawing.Point(108, 3);
            this.lblHiscount.Name = "lblHiscount";
            this.lblHiscount.Size = new System.Drawing.Size(51, 12);
            this.lblHiscount.TabIndex = 11;
            this.lblHiscount.Text = "0条记录";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(11, 3);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(96, 12);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "海虹买方列表：";
            // 
            // HosptailIDCompareQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 636);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "HosptailIDCompareQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海虹医药电子商务交易助手";
            this.panelMain.ResumeLayout(false);
            this.panelfrontfrmtxt.ResumeLayout(false);
            this.panelfrontfrmtxt.PerformLayout();
            this.panelNav.ResumeLayout(false);
            this.panelNav.PerformLayout();
            this.panelPurchase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItembindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelOrderItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPHisItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisbindingSource)).EndInit();
            this.panelBtm.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel panelPurchase;
        private System.Windows.Forms.Panel panelOrderItem;
        private System.Windows.Forms.Panel panelBtm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblHiscount;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEPHisItem;
        private Emedchina.Commons.WinForms.PageNavigator pageNavigatorEPIDComItem;
        private System.Windows.Forms.TextBox tbxEPname;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource ItembindingSource;
       
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbCompare;

        private System.Windows.Forms.DataGridView dgvEPItem;
        private System.Windows.Forms.BindingSource hisbindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn abbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn spell_abbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_wb;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyer_orgid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FULL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn EASY_NAME;
    }
}