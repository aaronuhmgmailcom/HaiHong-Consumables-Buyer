namespace EmedHisHelper
{
    partial class FormSql
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.m_subtitleLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnBeforeSql = new DevExpress.XtraEditors.SimpleButton();
            this.btnAfterSql = new DevExpress.XtraEditors.SimpleButton();
            this.btnDataView = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveSql = new DevExpress.XtraEditors.SimpleButton();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.btnSqlBuild = new DevExpress.XtraEditors.SimpleButton();
            this.lblDesc = new System.Windows.Forms.Label();
            this.rtbSql = new System.Windows.Forms.RichTextBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btn_last = new DevExpress.XtraEditors.SimpleButton();
            this.btn_next = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.64948F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.35052F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 333);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.m_subtitleLabel);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(551, 57);
            this.panelControl1.TabIndex = 0;
            // 
            // m_subtitleLabel
            // 
            this.m_subtitleLabel.Location = new System.Drawing.Point(56, 34);
            this.m_subtitleLabel.Name = "m_subtitleLabel";
            this.m_subtitleLabel.Size = new System.Drawing.Size(136, 14);
            this.m_subtitleLabel.TabIndex = 1;
            this.m_subtitleLabel.Text = "请用sql生成器自动生成sql";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(30, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "接口SQL配置";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnBeforeSql);
            this.panelControl2.Controls.Add(this.btnAfterSql);
            this.panelControl2.Controls.Add(this.btnDataView);
            this.panelControl2.Controls.Add(this.btnSaveSql);
            this.panelControl2.Controls.Add(this.btnTest);
            this.panelControl2.Controls.Add(this.btnSqlBuild);
            this.panelControl2.Controls.Add(this.lblDesc);
            this.panelControl2.Controls.Add(this.rtbSql);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 66);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(551, 222);
            this.panelControl2.TabIndex = 1;
            // 
            // btnBeforeSql
            // 
            this.btnBeforeSql.Location = new System.Drawing.Point(380, 187);
            this.btnBeforeSql.Name = "btnBeforeSql";
            this.btnBeforeSql.Size = new System.Drawing.Size(75, 23);
            this.btnBeforeSql.TabIndex = 14;
            this.btnBeforeSql.Text = "前置SQL";
            this.btnBeforeSql.Visible = false;
            // 
            // btnAfterSql
            // 
            this.btnAfterSql.Location = new System.Drawing.Point(461, 187);
            this.btnAfterSql.Name = "btnAfterSql";
            this.btnAfterSql.Size = new System.Drawing.Size(75, 23);
            this.btnAfterSql.TabIndex = 13;
            this.btnAfterSql.Text = "后置SQL";
            this.btnAfterSql.Visible = false;
            // 
            // btnDataView
            // 
            this.btnDataView.Location = new System.Drawing.Point(255, 187);
            this.btnDataView.Name = "btnDataView";
            this.btnDataView.Size = new System.Drawing.Size(75, 23);
            this.btnDataView.TabIndex = 12;
            this.btnDataView.Text = "数据预览";
            this.btnDataView.Click += new System.EventHandler(this.btnDataView_Click);
            // 
            // btnSaveSql
            // 
            this.btnSaveSql.Location = new System.Drawing.Point(174, 187);
            this.btnSaveSql.Name = "btnSaveSql";
            this.btnSaveSql.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSql.TabIndex = 11;
            this.btnSaveSql.Text = "保存SQL";
            this.btnSaveSql.Click += new System.EventHandler(this.btnSaveSql_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(93, 187);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "测试SQL";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSqlBuild
            // 
            this.btnSqlBuild.Location = new System.Drawing.Point(12, 187);
            this.btnSqlBuild.Name = "btnSqlBuild";
            this.btnSqlBuild.Size = new System.Drawing.Size(75, 23);
            this.btnSqlBuild.TabIndex = 9;
            this.btnSqlBuild.Text = "SQL生成器";
            this.btnSqlBuild.Click += new System.EventHandler(this.btnSqlBuild_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(12, 5);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(0, 14);
            this.lblDesc.TabIndex = 8;
            // 
            // rtbSql
            // 
            this.rtbSql.Location = new System.Drawing.Point(9, 16);
            this.rtbSql.Name = "rtbSql";
            this.rtbSql.Size = new System.Drawing.Size(527, 165);
            this.rtbSql.TabIndex = 1;
            this.rtbSql.Text = "";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btn_last);
            this.panelControl3.Controls.Add(this.btn_next);
            this.panelControl3.Controls.Add(this.btn_cancel);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 294);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(551, 36);
            this.panelControl3.TabIndex = 2;
            // 
            // btn_last
            // 
            this.btn_last.Location = new System.Drawing.Point(281, 8);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(93, 23);
            this.btn_last.TabIndex = 2;
            this.btn_last.Text = "<　上一步(&B)";
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(380, 8);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 1;
            this.btn_next.Text = "完成(&N) >";
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(461, 8);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FormSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 333);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HIS接口配置工具";
            this.VisibleChanged += new System.EventHandler(this.FormSql_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormSql_KeyPress);
            this.Load += new System.EventHandler(this.FormSql_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl m_subtitleLabel;
        private System.Windows.Forms.RichTextBox rtbSql;
        private DevExpress.XtraEditors.SimpleButton btnBeforeSql;
        private DevExpress.XtraEditors.SimpleButton btnAfterSql;
        private DevExpress.XtraEditors.SimpleButton btnDataView;
        private DevExpress.XtraEditors.SimpleButton btnSaveSql;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.SimpleButton btnSqlBuild;
        private System.Windows.Forms.Label lblDesc;
        private DevExpress.XtraEditors.SimpleButton btn_last;
        private DevExpress.XtraEditors.SimpleButton btn_next;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;

    }
}