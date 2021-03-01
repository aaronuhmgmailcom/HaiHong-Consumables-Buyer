#region Header
/*****************************************************************************
 * $Author: Sunhl $Revision: 1.0 $
 * $Date: 06-06-28 15:57 $ 
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.PurchaseHandle
{
    [Serializable]
    public class ItemStatusModel
    {
        //订单明细状态表ID
        private string id;
        //记录号
        private string recordId;
        //订单状态
        private string orderItemState;
        //修改人ID
        private string modifyUserid = "USER00000000000000125402";
        //修改人名称
        private string modifyUsername;
        //修改日期
        private DateTime modifyDate;

        public DateTime ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }

        public string ModifyUsername
        {
            get { return modifyUsername; }
            set { modifyUsername = value; }
        }

        public string ModifyUserid
        {
            get { return modifyUserid; }
            set { modifyUserid = value; }
        }

        public string OrderItemState
        {
            get { return orderItemState; }
            set { orderItemState = value; }
        }

        public string RecordId
        {
            get { return recordId; }
            set { recordId = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }

    [Serializable]
    public struct ItemStatusStruct
    {
        //订单明细状态表ID
        public string id;
        //记录号
        public string recordId;
        //订单状态
        public string orderItemState;
        //修改人ID
        public string modifyUserid;
        //修改人名称
        public string modifyUsername;
        //修改日期
        public DateTime modifyDate;
    }
}
