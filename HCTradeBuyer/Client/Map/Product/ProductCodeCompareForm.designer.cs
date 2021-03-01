namespace Emedchina.TradeAssistant.Client.Map.Product
{
    partial class ProductCodeCompareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCodeCompareForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHisCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbProcessFlag = new System.Windows.Forms.ComboBox();
            this.CmbIsMap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxproducter = new System.Windows.Forms.TextBox();
            this.tbxmedicalname = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pageNavigator1 = new Emedchina.Commons.WinForms.PageNavigator();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvProIDCompare = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICAL_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEC_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USE_UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAND_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PACKAGE_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTORY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_Process_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.butexp = new System.Windows.Forms.Button();
            this.butimp = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancleMatch = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSeeCompare = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProIDCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.Search02;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txtHisCode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CmbProcessFlag);
            this.panel1.Controls.Add(this.CmbIsMap);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxproducter);
            this.panel1.Controls.Add(this.tbxmedicalname);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 99);
            this.panel1.TabIndex = 1;
            // 
            // txtHisCode
            // 
            this.txtHisCode.Location = new System.Drawing.Point(334, 56);
            this.txtHisCode.Name = "txtHisCode";
            this.txtHisCode.Size = new System.Drawing.Size(156, 21);
            this.txtHisCode.TabIndex = 19;
            this.txtHisCode.TextChanged += new System.EventHandler(this.txtHisCode_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(251, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 18;
            this.label5.Tag = "9999";
            this.label5.Text = "ERP产品编码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(175, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Tag = "9999";
            this.label4.Text = "处理状态：";
            // 
            // CmbProcessFlag
            // 
            this.CmbProcessFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProcessFlag.FormattingEnabled = true;
            this.CmbProcessFlag.Items.AddRange(new object[] {
            "全部",
            "未处理",
            "已处理"});
            this.CmbProcessFlag.Location = new System.Drawing.Point(240, 19);
            this.CmbProcessFlag.Name = "CmbProcessFlag";
            this.CmbProcessFlag.Size = new System.Drawing.Size(69, 20);
            this.CmbProcessFlag.TabIndex = 16;
            this.CmbProcessFlag.SelectedIndexChanged += new System.EventHandler(this.CmbProcessFlag_SelectedIndexChanged);
            // 
            // CmbIsMap
            // 
            this.CmbIsMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIsMap.FormattingEnabled = true;
            this.CmbIsMap.Location = new System.Drawing.Point(73, 20);
            this.CmbIsMap.Name = "CmbIsMap";
            this.CmbIsMap.Size = new System.Drawing.Size(79, 20);
            this.CmbIsMap.TabIndex = 15;
            this.CmbIsMap.SelectedIndexChanged += new System.EventHandler(this.CmbIsMap_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Tag = "9999";
            this.label3.Text = "匹配状态：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Tag = "9999";
            this.label2.Text = "生产企业：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(332, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Tag = "9999";
            this.label1.Text = "药品名称：";
            // 
            // tbxproducter
            // 
            this.tbxproducter.Location = new System.Drawing.Point(83, 56);
            this.tbxproducter.Name = "tbxproducter";
            this.tbxproducter.Size = new System.Drawing.Size(154, 21);
            this.tbxproducter.TabIndex = 11;
            this.tbxproducter.TextChanged += new System.EventHandler(this.tbxproducter_TextChanged);
            // 
            // tbxmedicalname
            // 
            this.tbxmedicalname.Location = new System.Drawing.Point(397, 17);
            this.tbxmedicalname.Name = "tbxmedicalname";
            this.tbxmedicalname.Size = new System.Drawing.Size(148, 21);
            this.tbxmedicalname.TabIndex = 10;
            this.tbxmedicalname.TextChanged += new System.EventHandler(this.tbxmedicalname_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(658, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Tag = "";
            this.btnSearch.Text = "查询(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pageNavigator1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 26);
            this.panel2.TabIndex = 2;
            // 
            // pageNavigator1
            // 
            this.pageNavigator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pageNavigator1.BackgroundImage")));
            this.pageNavigator1.CurrentPageIndex = 0;
            this.pageNavigator1.ItemCount = 0;
            this.pageNavigator1.Location = new System.Drawing.Point(0, 0);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.Size = new System.Drawing.Size(756, 25);
            this.pageNavigator1.TabIndex = 0;
            this.pageNavigator1.Text = "pageNavigator1";
            this.pageNavigator1.PageIndexOrPageSizeChanged += new Emedchina.Commons.WinForms.PageChangedEventHandler(this.pageNavigator1_PageIndexOrPageSizeChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvProIDCompare);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 125);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(756, 301);
            this.panel5.TabIndex = 8;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProIDCompare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProIDCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProIDCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IsMap,
            this.PRODUCT_CODE,
            this.PRODUCT_NAME,
            this.MODE_NAME,
            this.MEDICAL_SPEC,
            this.SPEC_UNIT,
            this.USE_UNIT,
            this.STAND_RATE,
            this.PACKAGE_RATE,
            this.FACTORY_NAME,
            this.REMARK,
            this.PRODUCT_ID,
            this.Is_Process_flag});
            this.dgvProIDCompare.DataSource = this.bindingSource1;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProIDCompare.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProIDCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProIDCompare.Location = new System.Drawing.Point(0, 0);
            this.dgvProIDCompare.Margin = new System.Windows.Forms.Padding(100);
            this.dgvProIDCompare.MultiSelect = false;
            this.dgvProIDCompare.Name = "dgvProIDCompare";
            this.dgvProIDCompare.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProIDCompare.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProIDCompare.RowHeadersWidth = 30;
            this.dgvProIDCompare.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProIDCompare.RowTemplate.Height = 23;
            this.dgvProIDCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProIDCompare.Size = new System.Drawing.Size(756, 301);
            this.dgvProIDCompare.StandardTab = true;
            this.dgvProIDCompare.TabIndex = 5;
            this.dgvProIDCompare.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProIDCompare_ColumnHeaderMouseClick);
            this.dgvProIDCompare.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProIDCompare_DataError);
            this.dgvProIDCompare.CurrentCellChanged += new System.EventHandler(this.dgvProIDCompare_CurrentCellChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 2;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 2;
            // 
            // IsMap
            // 
            this.IsMap.DataPropertyName = "Is_Map";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IsMap.DefaultCellStyle = dataGridViewCellStyle2;
            this.IsMap.HeaderText = "是否匹配";
            this.IsMap.Name = "IsMap";
            this.IsMap.ReadOnly = true;
            this.IsMap.Width = 60;
            // 
            // PRODUCT_CODE
            // 
            this.PRODUCT_CODE.DataPropertyName = "PRODUCT_CODE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PRODUCT_CODE.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRODUCT_CODE.HeaderText = "ERP产品编码";
            this.PRODUCT_CODE.Name = "PRODUCT_CODE";
            this.PRODUCT_CODE.ReadOnly = true;
            this.PRODUCT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "HisProduct_Name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PRODUCT_NAME.DefaultCellStyle = dataGridViewCellStyle4;
            this.PRODUCT_NAME.HeaderText = "ERP产品名称";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MODE_NAME
            // 
            this.MODE_NAME.DataPropertyName = "MODE_NAME";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MODE_NAME.DefaultCellStyle = dataGridViewCellStyle5;
            this.MODE_NAME.HeaderText = "ERP剂型";
            this.MODE_NAME.Name = "MODE_NAME";
            this.MODE_NAME.ReadOnly = true;
            this.MODE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MEDICAL_SPEC
            // 
            this.MEDICAL_SPEC.DataPropertyName = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.HeaderText = "ERP规格包装";
            this.MEDICAL_SPEC.Name = "MEDICAL_SPEC";
            this.MEDICAL_SPEC.ReadOnly = true;
            this.MEDICAL_SPEC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SPEC_UNIT
            // 
            this.SPEC_UNIT.DataPropertyName = "SPEC_UNIT";
            this.SPEC_UNIT.HeaderText = "ERP包装单位";
            this.SPEC_UNIT.Name = "SPEC_UNIT";
            this.SPEC_UNIT.ReadOnly = true;
            this.SPEC_UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // USE_UNIT
            // 
            this.USE_UNIT.DataPropertyName = "USE_UNIT";
            this.USE_UNIT.HeaderText = "ERP使用单位";
            this.USE_UNIT.Name = "USE_UNIT";
            this.USE_UNIT.ReadOnly = true;
            this.USE_UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // STAND_RATE
            // 
            this.STAND_RATE.DataPropertyName = "STAND_RATE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STAND_RATE.DefaultCellStyle = dataGridViewCellStyle6;
            this.STAND_RATE.HeaderText = "海虹单位转换比";
            this.STAND_RATE.Name = "STAND_RATE";
            this.STAND_RATE.ReadOnly = true;
            this.STAND_RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PACKAGE_RATE
            // 
            this.PACKAGE_RATE.DataPropertyName = "PACKAGE_RATE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PACKAGE_RATE.DefaultCellStyle = dataGridViewCellStyle7;
            this.PACKAGE_RATE.HeaderText = "ERP包装转换比";
            this.PACKAGE_RATE.Name = "PACKAGE_RATE";
            this.PACKAGE_RATE.ReadOnly = true;
            this.PACKAGE_RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FACTORY_NAME
            // 
            this.FACTORY_NAME.DataPropertyName = "FACTORY_NAME";
            this.FACTORY_NAME.HeaderText = "ERP生产企业";
            this.FACTORY_NAME.Name = "FACTORY_NAME";
            this.FACTORY_NAME.ReadOnly = true;
            this.FACTORY_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // REMARK
            // 
            this.REMARK.DataPropertyName = "REMARK";
            this.REMARK.HeaderText = "备注";
            this.REMARK.Name = "REMARK";
            this.REMARK.ReadOnly = true;
            this.REMARK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.DataPropertyName = "PRODUCT_ID";
            this.PRODUCT_ID.HeaderText = "PRODUCT_ID";
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.ReadOnly = true;
            this.PRODUCT_ID.Visible = false;
            // 
            // Is_Process_flag
            // 
            this.Is_Process_flag.DataPropertyName = "Is_Process_flag";
            this.Is_Process_flag.HeaderText = "是否处理";
            this.Is_Process_flag.Name = "Is_Process_flag";
            this.Is_Process_flag.ReadOnly = true;
            this.Is_Process_flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.butexp);
            this.panel3.Controls.Add(this.butimp);
            this.panel3.Controls.Add(this.btnReturn);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnCancleMatch);
            this.panel3.Controls.Add(this.btnModify);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnSeeCompare);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 426);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 36);
            this.panel3.TabIndex = 7;
            // 
            // butexp
            // 
            this.butexp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.butexp.Location = new System.Drawing.Point(30, 6);
            this.butexp.Name = "butexp";
            this.butexp.Size = new System.Drawing.Size(91, 23);
            this.butexp.TabIndex = 20;
            this.butexp.Text = "导入产品表(&L)";
            this.butexp.UseVisualStyleBackColor = true;
            this.butexp.Click += new System.EventHandler(this.butexp_Click);
            // 
            // butimp
            // 
            this.butimp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.butimp.Location = new System.Drawing.Point(123, 6);
            this.butimp.Name = "butimp";
            this.butimp.Size = new System.Drawing.Size(91, 23);
            this.butimp.TabIndex = 19;
            this.butimp.Text = "导出产品表(&E)";
            this.butimp.UseVisualStyleBackColor = true;
            this.butimp.Click += new System.EventHandler(this.butimp_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReturn.Location = new System.Drawing.Point(664, 6);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(89, 23);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "返回(&R)";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(575, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancleMatch
            // 
            this.btnCancleMatch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancleMatch.Location = new System.Drawing.Point(486, 6);
            this.btnCancleMatch.Name = "btnCancleMatch";
            this.btnCancleMatch.Size = new System.Drawing.Size(89, 23);
            this.btnCancleMatch.TabIndex = 16;
            this.btnCancleMatch.Text = "取消匹配(&C)";
            this.btnCancleMatch.UseVisualStyleBackColor = true;
            this.btnCancleMatch.Click += new System.EventHandler(this.btnCancleMatch_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModify.Location = new System.Drawing.Point(397, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(89, 23);
            this.btnModify.TabIndex = 15;
            this.btnModify.Text = "修改(&M)";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(308, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "新增(&N)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSeeCompare
            // 
            this.btnSeeCompare.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSeeCompare.Location = new System.Drawing.Point(219, 6);
            this.btnSeeCompare.Name = "btnSeeCompare";
            this.btnSeeCompare.Size = new System.Drawing.Size(89, 23);
            this.btnSeeCompare.TabIndex = 13;
            this.btnSeeCompare.Text = "查看对照(&V)";
            this.btnSeeCompare.UseVisualStyleBackColor = true;
            this.btnSeeCompare.Click += new System.EventHandler(this.btnSeeCompare_Click);
            // 
            // ProductCodeCompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(756, 462);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "ProductCodeCompareForm";
            this.Text = "产品编码对照";
            this.Load += new System.EventHandler(this.ProductCodeCompareForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProIDCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtHisCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbProcessFlag;
        private System.Windows.Forms.ComboBox CmbIsMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxproducter;
        private System.Windows.Forms.TextBox tbxmedicalname;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private Emedchina.Commons.WinForms.PageNavigator pageNavigator1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvProIDCompare;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button butexp;
        private System.Windows.Forms.Button butimp;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancleMatch;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSeeCompare;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICAL_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEC_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn USE_UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAND_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PACKAGE_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTORY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Is_Process_flag;
    }
}