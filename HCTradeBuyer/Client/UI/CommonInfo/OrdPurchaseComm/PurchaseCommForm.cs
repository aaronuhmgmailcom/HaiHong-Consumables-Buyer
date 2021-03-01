using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdPurchaseComm
{
    public partial class PurchaseCommForm : DevExpress.XtraEditors.XtraForm
    {
        public PurchaseCommForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 新增可采购供应目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddPurchaseComm frm = new AddPurchaseComm();
            frm.ShowDialog();
        }
    }
}