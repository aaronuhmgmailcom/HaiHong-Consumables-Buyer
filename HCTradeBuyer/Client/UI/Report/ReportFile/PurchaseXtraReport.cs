using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class PurchaseXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PurchaseXtraReport()
        {
            InitializeComponent();
        }

        public PurchaseXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel3.Text = hosptailName;
        }



    }
}
