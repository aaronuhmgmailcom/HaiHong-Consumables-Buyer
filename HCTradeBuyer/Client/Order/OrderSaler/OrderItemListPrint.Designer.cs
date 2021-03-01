namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    partial class OrderItemListPrint
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderItemListPrint));
            this.SalerOrderItemModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SalerOrderItemModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SalerOrderItemModelBindingSource
            // 
            this.SalerOrderItemModelBindingSource.DataSource = typeof(Emedchina.TradeAssistant.Model.Order.SalerOrder.SalerOrderItemModel);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Emedchina_TradeAssistantSaler_Model_Order_SalerOrder_SalerOrderItemModel";
            reportDataSource1.Value = this.SalerOrderItemModelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Emedchina.TradeAssistant.Client.Print.ReportOrderItemList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(759, 435);
            this.reportViewer1.TabIndex = 0;
            // 
            // OrderItemListPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 435);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderItemListPrint";
            this.Text = "¥Ú”°";
            this.Load += new System.EventHandler(this.OrderItemListPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalerOrderItemModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SalerOrderItemModelBindingSource;


    }
}