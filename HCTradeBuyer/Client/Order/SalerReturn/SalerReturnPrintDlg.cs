using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Reporting.WinForms;

namespace Emedchina.TradeAssistant.Client.Order.SalerReturn
{
    public partial class SalerReturnPrintDlg : Form
    {
        public SalerReturnPrintDlg()
        {
            InitializeComponent();
        }

        public SalerReturnPrintDlg(DataTable dt, string title, string userName)
        {
            InitializeComponent();
            ReportParameter[] para = new ReportParameter[2];
            para[0] = new ReportParameter("title", title);
            para[1] = new ReportParameter("user", userName);

            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.LocalReport.DataSources[0].Value = dt;
        }

        private void SalerReturnPrintDlg_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}