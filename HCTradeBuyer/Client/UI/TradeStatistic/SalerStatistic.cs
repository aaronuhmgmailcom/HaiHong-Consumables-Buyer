using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder;
using Emedchina.TradeAssistant.Client.Common;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;

namespace Emedchina.TradeAssistant.Client.UI.TradeStatistic
{
    public partial class SalerStatistic : BaseForm
    {
        public SalerStatistic()
        {
            InitializeComponent();
        }

        private void SalerStatistic_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}