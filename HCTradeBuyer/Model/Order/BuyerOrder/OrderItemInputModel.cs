/*****************************************************
 * $Header: /TradeAssistant.root/TradeAssistant/Model/Order/BuyerOrder/OrderItemInputModel.cs 8     06-06-28 15:57 Sunhl $
 * $Author: Sunhl $
 * $Revision: 8 $
 * $Date: 06-06-28 15:57 $
 * $History: OrderItemInputModel.cs $
 * 
 * *****************  Version 8  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/Order/BuyerOrder
 * 
 * *****************  Version 7  *****************
 * User: Panyj        Date: 06-06-28   Time: 13:45
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
    /// <summary>
    /// 订单明细输入类
    /// </summary>
    [Serializable]
    public class OrderItemInputModel
    {
        private string orderItemId;

        public string OrderItemId
        {
            get { return orderItemId; }
            set { orderItemId = value; }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int highId;

        public int HighId
        {
            get { return highId; }
            set { highId = value; }
        }

    }
}
