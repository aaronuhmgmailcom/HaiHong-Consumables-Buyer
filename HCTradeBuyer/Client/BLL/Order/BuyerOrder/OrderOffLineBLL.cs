using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;

namespace Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder
{
    public class OrderOfflineBLL : SqlDAOBase
    {
        private OrderOfflineDAO dao = null;

        private OrderOfflineBLL()
        {
            dao = OrderOfflineDAO.GetInstance();
        }

        private OrderOfflineBLL(string connectionName)
        {
            dao = OrderOfflineDAO.GetInstance(connectionName);
        }

        public static OrderOfflineBLL GetInstance()
        {
            return new OrderOfflineBLL();
        }

        public static OrderOfflineBLL GetInstance(string connectionName)
        {
            return new OrderOfflineBLL(connectionName);
        }

        /// <summary>
        /// 取得按订单到货列表数据
        /// </summary>
        public DataSet GetBuyerOrderList(BuyerOrderModel input, out int rows)
        {
            return dao.GetBuyerOrderList(input, out rows);
        }
        /// <summary>
        /// 取得按企业到货列表数据
        /// </summary>
        public DataSet GetBuyerOrderByOrgList(BuyerOrderModel input, out int rows)
        {
            return dao.GetBuyerOrderByOrgList(input, out rows);
        }

      

    }
}
