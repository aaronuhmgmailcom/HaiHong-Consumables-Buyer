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
    class OrderDetailOfflineBLL : SqlDAOBase
    {
        private OrderDetailOfflineDao dao = null;

        private OrderDetailOfflineBLL()
        {
            dao = OrderDetailOfflineDao.GetInstance();
        }

        private OrderDetailOfflineBLL(string connectionName)
        {
            dao = OrderDetailOfflineDao.GetInstance(connectionName);
        }

        public static OrderDetailOfflineBLL GetInstance()
        {
            return new OrderDetailOfflineBLL();
        }

        public static OrderDetailOfflineBLL GetInstance(string connectionName)
        {
            return new OrderDetailOfflineBLL(connectionName);
        }

        /// <summary>
        /// 按订单，获得分页的订单明细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderDetailByOrderDs(OrderDetailSearchModel input, out int rows)
        {
            string orderId = input.OrderId;
            string productName = input.ProductName;

            return dao.GetOrderDetailListByOrder(orderId, productName, out rows);
        }

        public DataSet GetOrderDetailByOrderDs(OrderDetailSearchModel input)
        {
            string orderId = input.OrderId;
            string productName = input.ProductName;

            return dao.GetOrderDetailListByOrder(orderId);
        }

        /// <summary>
        /// 按订单，显示订单详细列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailListByOrder(OrderDetailSearchModel input, PagedParameter param)
        {
            string orderId = input.OrderId;
            string productName = input.ProductName;
            DataSet ds = GetOrderDetailListByOrder(orderId, productName);
            return ds;
        }

        /// <summary>
        /// 订单详细列表，如果按订单到货
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailListByOrder(string orderId, string productName)
        {
            return dao.GetOrderDetailListByOrder(orderId, productName);
        }


        /// <summary>
        /// 按企业，获得分页的订单明细信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailDs(OrderDetailSearchModel input, PagedParameter param, out int rows)
        {
            string salerId = input.SalerId;
            string buyerId = input.BuyerId;
            string areaId = input.AreaId;
            string productName = input.ProductName;
            DataSet ds = dao.GetOrderDetailList(input, salerId, buyerId, areaId, productName, param, out rows);
            return ds;
        }

        /// <summary>
        /// 按企业，获得分页的订单明细信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailDs(OrderDetailSearchModel input, PagedParameter param)
        {
            string salerId = input.SalerId;
            string buyerId = input.BuyerId;
            string areaId = input.AreaId;
            string productName = input.ProductName;
            DataSet ds = dao.GetOrderDetailList(salerId, buyerId, areaId, productName);
            return ds;
        }


        /// <summary>
        /// 订单明细作废--业务逻辑方法
        /// 获取单条订单，用于更新缓存。
        /// </summary>
        /// <param name="input"></param>
        public string doOrderItemCancel(OrderItemInputModel input)
        {
            string orderId = dao.doOrderItemCancel(input);
            return orderId;
        }

    }
}
