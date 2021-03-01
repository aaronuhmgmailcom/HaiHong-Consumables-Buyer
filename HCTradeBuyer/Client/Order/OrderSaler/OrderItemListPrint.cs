using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using System.Collections;
using Microsoft.Reporting.WinForms;

namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    public partial class OrderItemListPrint : Form
    {
        public OrderItemListPrint()
        {
            InitializeComponent();
        }

        public OrderItemListPrint(IList list, string title, string userName, SalerOrderModel model)
        {
            InitializeComponent();
            this.SalerOrderItemModelBindingSource.DataSource = list;
            ReportParameter[] para = new ReportParameter[15];
            para[0] = new ReportParameter("title", title);
            para[1] = new ReportParameter("user", userName);
            para[2] = new ReportParameter("OrderCode", model.Order_code);
            para[3] = new ReportParameter("BuyerName", model.Bak_buyer_easy);
            para[4] = new ReportParameter("OrderMoney", model.Request_total);
            para[5] = new ReportParameter("CreateName", model.User_name);
            para[6] = new ReportParameter("PostCode", model.Post_code);
            para[7] = new ReportParameter("LinkMan", String.IsNullOrEmpty(model.Linkman) ? "" : model.Linkman);
            para[8] = new ReportParameter("ReceiveTotal", model.Receive_total);
            para[9] = new ReportParameter("CreateDate", model.Create_date);
            para[10] = new ReportParameter("WareHouse", model.WareHouse);
            para[11] = new ReportParameter("Tel", String.IsNullOrEmpty(model.TelePhone) ? "" : model.TelePhone);
            para[12] = new ReportParameter("OrderState", model.Order_state_name);
            para[13] = new ReportParameter("BuildOrderName", model.PurchaseCreator);
            para[14] = new ReportParameter("Address", model.Address);

            this.reportViewer1.LocalReport.SetParameters(para);
            
        }

        private void OrderItemListPrint_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}