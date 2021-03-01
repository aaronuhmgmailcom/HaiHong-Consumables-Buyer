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
    class OrderTempOfflineBLL : SqlDAOBase
    {
        private OrderTempOfflineDao dao = null;

        private OrderTempOfflineBLL()
        {
            dao = OrderTempOfflineDao.GetInstance();
        }

        private OrderTempOfflineBLL(string connectionName)
        {
            dao = OrderTempOfflineDao.GetInstance(connectionName);
        }

        public static OrderTempOfflineBLL GetInstance()
        {
            return new OrderTempOfflineBLL();
        }

        public static OrderTempOfflineBLL GetInstance(string connectionName)
        {
            return new OrderTempOfflineBLL(connectionName);
        }

        //已到货列表的检索
        public DataSet getArrivedList(UserInfo ui, string type, string id, BuyerOrderModel input)
        {
            return dao.getArrivedList(ui, type, id, input);
        }
    }
}
