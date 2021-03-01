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
    public class PurchaseItemModel
    {
        //�ɹ�����ID
        private string purchaseId;
        //�ɹ�����ϸ��״̬
        private string orderFlag;

        public string OrderFlag
        {
            get { return orderFlag; }
            set { orderFlag = value; }
        }

        public string PurchaseId
        {
            get { return purchaseId; }
            set { purchaseId = value; }
        }
    }

    [Serializable]
    public struct PurchaseItemStruct
    {
        //�ɹ�����ID
        public string purchaseId;
        //�ɹ�����ϸ��״̬
        public string orderFlag;
    }
}
