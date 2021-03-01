using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class OOSQueryXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public string hospname = string.Empty;
        public OOSQueryXtraReport()
        {
            InitializeComponent();
        }

        public OOSQueryXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel1.Text = hosptailName;
        }
    }
}
