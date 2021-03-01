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
        //������ϸ״̬��ID
        private string id;
        //��¼��
        private string recordId;
        //����״̬
        private string orderItemState;
        //�޸���ID
        private string modifyUserid = "USER00000000000000125402";
        //�޸�������
        private string modifyUsername;
        //�޸�����
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
        //������ϸ״̬��ID
        public string id;
        //��¼��
        public string recordId;
        //����״̬
        public string orderItemState;
        //�޸���ID
        public string modifyUserid;
        //�޸�������
        public string modifyUsername;
        //�޸�����
        public DateTime modifyDate;
    }
}
