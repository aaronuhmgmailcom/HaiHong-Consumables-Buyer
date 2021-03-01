using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.Gpo;

namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    public partial class SelectExpSendItem : FormBase
    {
        DataTable dt;
        public DataRow row ;
        public SelectExpSendItem()
        {
            InitializeComponent();
        }
        public SelectExpSendItem(string procode)
        {
            InitializeComponent();
            //dt=ProxyFactory.ErpSendRemote.GetErpProductByProcode(procode, base.CurrentUserOrgId);
            dt =  GpoSendBLL.GetInstance().GetErpProductByProcode(procode,base.CurrentUserOrgId);
            this.bindingSource1.DataSource = dt.DefaultView;
            lblRegText.Text ="产品编码 "+ procode+" 对应了以上"+dgvErpSend.RowCount.ToString()+"条产品数据，请选择！";
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            if (dgvErpSend.CurrentRow != null)
                row = ((DataRowView)dgvErpSend.CurrentRow.DataBoundItem).Row;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    

    }
}