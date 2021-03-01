using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Emedchina.TradeAssistant.Client.UI.Report.ReportForm
{
    public partial class FrmPrint : DevExpress.XtraEditors.XtraForm
    {
        XtraReport report;
        DataTable data;
        public string hospname = string.Empty;
        public FrmPrint()
        {
            InitializeComponent();
        }

        public FrmPrint(XtraReport xTraReport, DataTable ds)
        {
            InitializeComponent();
            report = xTraReport;
            data = ds;
        }


        private void FrmPrint_Load(object sender, EventArgs e)
        {
            printingSystem1.ClearContent();
            report.DataSource = data;
            report.PrintingSystem = printingSystem1;
            report.CreateDocument();



        }

       
    }
}