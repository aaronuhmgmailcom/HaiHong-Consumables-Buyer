using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportFile
{
    public partial class QueryOrderItemXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public QueryOrderItemXtraReport()
        {
            InitializeComponent();
        }

        public QueryOrderItemXtraReport(string hosptailName)
        {
            InitializeComponent();
            this.xrLabel1.Text = hosptailName;
        }

    }
}
