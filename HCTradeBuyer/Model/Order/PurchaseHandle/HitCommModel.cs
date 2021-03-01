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
    public class HitCommModel
    {
        //最后更新时间
        private DateTime lastOrderDate;
        private decimal lastOrderQty;

        public DateTime LastOrderDate
        {
            get { return lastOrderDate; }
            set { lastOrderDate = value; }
        }
       

        public decimal LastOrderQty
        {
            get { return lastOrderQty; }
            set { lastOrderQty = value; }
        }
    }

    [Serializable]
    public struct HitCommStruct
    {
        //最后更新时间
        public DateTime lastOrderDate;
        public decimal lastOrderQty;
    }
}
