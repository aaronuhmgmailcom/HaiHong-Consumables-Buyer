namespace Emedchina.TradeAssistant.Client.Order.SalerReturn
{
    partial class SalerReturnPrintDlg
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalerReturnPrintDlg));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SalerReturnjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salerReturnPrint1 = new Emedchina.TradeAssistant.Client.Properties.DataSources.SalerReturnPrint();
            ((System.ComponentModel.ISupportInitialize)(this.SalerReturnjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salerReturnPrint1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SalerReturnPrint_dtSalerReturnPrint";
            reportDataSource1.Value = this.SalerReturnjBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Emedchina.TradeAssistant.Client.Print.ReportSalerReturn.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(784, 507);
            this.reportViewer1.TabIndex = 0;
            // 
            // SalerReturnjBindingSource
            // 
            this.SalerReturnjBindingSource.DataMember = "dtSalerReturnPrint";
            this.SalerReturnjBindingSource.DataSource = this.salerReturnPrint1;
            // 
            // salerReturnPrint1
            // 
            this.salerReturnPrint1.DataSetName = "SalerReturnPrint";
            this.salerReturnPrint1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SalerReturnPrintDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 507);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalerReturnPrintDlg";
            this.Text = "打印";
            this.Load += new System.EventHandler(this.SalerReturnPrintDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalerReturnjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salerReturnPrint1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SalerReturnjBindingSource;
        private Emedchina.TradeAssistant.Client.Properties.DataSources.SalerReturnPrint salerReturnPrint1;
    }
}