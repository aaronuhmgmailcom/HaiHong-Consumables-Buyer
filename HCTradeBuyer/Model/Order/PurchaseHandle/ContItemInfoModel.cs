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
   public class ContItemInfoModel
    {

        private string conItemId;
        private DateTime lastOrderDate;
        private decimal lastOrderQty;

        public decimal LastOrderQty
        {
            get { return lastOrderQty; }
            set { lastOrderQty = value; }
        }

        public DateTime LastOrderDate
        {
            get { return lastOrderDate; }
            set { lastOrderDate = value; }
        }

        public string ConItemId
        {
            get { return conItemId; }
            set { conItemId = value; }
        }
    }

    [Serializable]
    public struct ContItemInfoStruct
    {
        public string conItemId;
        public DateTime lastOrderDate;
        public decimal lastOrderQty;
    }
}
