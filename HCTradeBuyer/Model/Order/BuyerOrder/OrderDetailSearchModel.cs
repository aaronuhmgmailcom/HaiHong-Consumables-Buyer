/*****************************************************
 * $Header: /TradeAssistant.root/TradeAssistant/Model/Order/BuyerOrder/OrderDetailSearchModel.cs 7     06-06-28 15:57 Sunhl $
 * $Author: Sunhl $
 * $Revision: 7 $
 * $Date: 06-06-28 15:57 $
 * $History: OrderDetailSearchModel.cs $
 * 
 * *****************  Version 7  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/Order/BuyerOrder
 * 
 * *****************  Version 6  *****************
 * User: Panyj        Date: 06-06-28   Time: 13:43
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/Order/BuyerOrder
 ****************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.BuyerOrder
{
    [Serializable]
    public class OrderDetailSearchModel
    {
        private string orderQty;

        /// <summary>
        /// 订单数量
        /// </summary>
        public string OrderQty
        {
            get { return orderQty; }
            set { orderQty = value; }
        }
        private string orderMoney;
        /// <summary>
        /// 订单金额
        /// </summary>
        public string OrderMoney
        {
            get { return orderMoney; }
            set { orderMoney = value; }
        }
        private string salerName;
        /// <summary>
        /// 卖方名称
        /// </summary>

        public string SalerName
        {
            get { return salerName; }
            set { salerName = value; }
        }
        private string productName;
        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string salerId;
        /// <summary>
        /// 卖方Id
        /// </summary>
        public string SalerId
        {
            get { return salerId; }
            set { salerId = value; }
        }
        private string buyerId;
        /// <summary>
        /// 买方Id
        /// </summary>
        public string BuyerId
        {
            get { return buyerId; }
            set { buyerId = value; }
        }
        private string areaId;
        /// <summary>
        /// 区域Id
        /// </summary>
        public string AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        private string orderId;
        /// <summary>
        /// 订单Id
        /// </summary>
        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        //add by yanbing 2007-07-11
        private string orderState;
        /// <summary>
        /// 订单orderState
        /// </summary>
        public string OrderState
        {
            get { return orderState; }
            set { orderState = value; }
        }

        // 发送开始时间
        private String startDate;

        public String StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        // 发送结束时间
        private String endDate;

        public String EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        // 查询字段
        private String searchField;

        public String SearchField
        {
            get { return searchField; }
            set { searchField = value; }
        }
        //查询关键字
        private String searchKey;

        public String SearchKey
        {
            get { return searchKey; }
            set { searchKey = value; }
        }
        // 创建人
        private String creater;

        public String Creater
        {
            get { return creater; }
            set { creater = value; }
        }
        //end add

    }
}
