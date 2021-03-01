using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class ReturnXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ReturnXtraReport()
        {
            InitializeComponent();
        }

        public ReturnXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel2.Text = hosptailName;
        }

    }
}
