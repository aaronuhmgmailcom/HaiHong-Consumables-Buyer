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
    public class PurchaseCreateModel
    {
        //�ɹ������
        private string purchaseCode;
        //������
        private string createUsername;
        //����ʱ��
        private string createDate;
        //�ƻ��ɹ����
        private string requestTotal;
        //����ʱ��
        private string endDate;
        //��ϵ�绰
        private string linkTel;
        //�ɹ���״̬
        private string purchaseState;
        //�ɹ���ID
        private string purchaseId;
        //���������
        private string approveUsername;
        //�����ID
        private string approveUserid;
        //�������
        private DateTime approveDate;
        
        public DateTime ApproveDate
        {
            get { return approveDate; }
            set { approveDate = value; }
        }

        public string ApproveUserid
        {
            get { return approveUserid; }
            set { approveUserid = value; }
        }

        public string ApproveUsername
        {
            get { return approveUsername; }
            set { approveUsername = value; }
        }

        public string PurchaseId
        {
            get { return purchaseId; }
            set { purchaseId = value; }
        }

        public string PurchaseState
        {
            get { return purchaseState; }
            set { purchaseState = value; }
        }

        public string LinkTel
        {
            get { return linkTel; }
            set { linkTel = value; }
        }

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string RequestTotal
        {
            get { return requestTotal; }
            set { requestTotal = value; }
        }

        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        public string CreateUsername
        {
            get { return createUsername; }
            set { createUsername = value; }
        }
        public string PurchaseCode
        {
            get { return purchaseCode; }
            set { purchaseCode = value; }
        }
       
    }

    [Serializable]
    public struct PurchaseCreateStruct
    {
        //�ɹ������
        public string purchaseCode;
        //������
        public string createUsername;
        //����ʱ��
        public string createDate;
        //�ƻ��ɹ����
        public string requestTotal;
        //����ʱ��
        public string endDate;
        //��ϵ�绰
        public string linkTel;
        //�ɹ���״̬
        public string purchaseState;
        //���������
        public string approveUsername;
        //�����ID
        public string approveUserid;
        //�������
        public DateTime approveDate;

    }
}
