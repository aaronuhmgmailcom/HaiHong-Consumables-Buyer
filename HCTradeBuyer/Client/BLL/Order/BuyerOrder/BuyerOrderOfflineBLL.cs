using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;
using Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder;

namespace Emedchina.TradeAssistant.Client.BLL.Order.BuyerOrder
{
    class BuyerOrderOfflineBLL : SqlDAOBase
    {
        private BuyerOrderOfflineDAO dao = null;

        private BuyerOrderOfflineBLL()
        {
            dao = BuyerOrderOfflineDAO.GetInstance();
        }

        private BuyerOrderOfflineBLL(string connectionName)
        {
            dao = BuyerOrderOfflineDAO.GetInstance(connectionName);
        }

        public static BuyerOrderOfflineBLL GetInstance()
        {
            return new BuyerOrderOfflineBLL();
        }

        public static BuyerOrderOfflineBLL GetInstance(string connectionName)
        {
            return new BuyerOrderOfflineBLL(connectionName);
        }

        /// <summary>
        /// 取得发票号数据
        /// </summary>
        public List<string> GetInvoiceNoList(BuyerOrderModel input)
        {
            return dao.GetInvoiceNoList(input);
        }

        /// <summary>
        /// 获取未到货列表数据
        /// </summary>
        public DataSet GetNoArriveList(OrderModel input,BuyerOrderModel orderInput , out int rows)
        {
            return dao.GetNoArriveList(input, orderInput, out rows);
        }

        /// <summary>
        /// 取得发票号数据
        /// </summary>
        public List<string> GetInvoiceNoListByOrderId(BuyerOrderModel input)
        {
            List<string> invoiceNo = new List<string>();
            DataTable dt = dao.SearchInvoiceNoByOrderId(input);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                invoiceNo.Add(dt.Rows[i]["invoice_no"].ToString());
            }
            return invoiceNo;
        }

        /// <summary>
        /// 取到货金额
        /// </summary>
        public String GetReceiveTotalByOrder(BuyerOrderModel input)
        {
            return dao.GetReceiveTotalByOrder(input);
        }

        /// <summary>
        /// 到货确认
        /// </summary>
        public void ArrivedConfirm(BuyerOrderModel input)
        {
            dao.ArrivedConfirm(input);
        }
        /// <summary>
        /// 取订单状态
        /// </summary>
        public string GetOrderState(BuyerOrderModel input)
        {
            return dao.GetOrderState(input);
        }
        /// <summary>
        /// 保存备注
        /// </summary>
        public bool SaveRemark(BuyerOrderModel input)
        {
            
            return dao.SaveRemark(input);
        }

        /// <summary>
        /// 订单明细完成
        /// </summary>
        public void CompleteOrderItem(BuyerOrderModel input)
        {
            dao.CompleteOrderItem(input);
        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        public void CloseOrderItem(BuyerOrderModel input)
        {
            dao.CloseOrderItem(input);
        }
    }
}
