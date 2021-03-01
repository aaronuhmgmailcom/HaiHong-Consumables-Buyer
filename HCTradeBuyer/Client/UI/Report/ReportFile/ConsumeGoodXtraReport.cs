using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class ConsumeGoodXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ConsumeGoodXtraReport()
        {
            InitializeComponent();
        }

        public ConsumeGoodXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel1.Text = hosptailName;
        }
    }
}
