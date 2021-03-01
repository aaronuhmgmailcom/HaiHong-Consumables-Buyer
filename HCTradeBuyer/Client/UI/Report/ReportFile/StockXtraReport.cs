using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class StockXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public StockXtraReport()
        {
            InitializeComponent();
        }

        public StockXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel8.Text = hosptailName;
        }


    }
}
