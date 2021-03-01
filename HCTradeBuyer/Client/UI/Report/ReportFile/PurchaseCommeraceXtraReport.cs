using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class PurchaseCommeraceXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PurchaseCommeraceXtraReport()
        {
            InitializeComponent();
        }

        public PurchaseCommeraceXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel1.Text = hosptailName;
        }


    }
}
