using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class InvoiceFromXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceFromXtraReport()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        public InvoiceFromXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel13.Text = hosptailName;
        }

    }
}
