using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class StockGoodXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public StockGoodXtraReport()
        {
            InitializeComponent();         
        }

        public StockGoodXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel1.Text = hosptailName;
        }

    }
}
