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
   public class PurchaseOrderModel
    {
        //�ɹ�����ID
        private string purchaseId="0";
        //�ɹ�����Code
        private string purchaseCode = "0";
        //�������
        private string orderId="0";
        //�������
        private string orderCode="0";
        //״̬
        private string orderState="0";
        //���������̶�
        private string degreeFlag;
        //��ID
        private string buyerOrgid="0";
        //�ֿ�ID
        private string repositoryId;
        //�ͻ���ַ
        private string repositoryAddr;
        //�������
        private decimal requestTotal=0;
        //ҽԺ����
        private string bakBuyerName;
        //ҽԺ���
        private string bakBuyerEasy;
        //ҽԺƴ�����
        private string bakBuyerFast;
        //ҽԺ��ʼ��
        private string bakBuyerWubi;
        //��ϵ�绰
        private string buyerLinkTel;
        //����ID
        private string senderId="0";
        //��������
       private string senderName;
        //���ͼ��
       private string senderEasy;
        //����ƴ�����
        private string salerFast;
        // ����ȷ��ʱ��
        private DateTime  salerapproverdate;
        //������ʼ��
        private string salerWubi;
        //����������
        private string createUsername;
        //�����û�ID
        private string createUserid="0";
        //��������
        private DateTime createDate=Convert.ToDateTime(DateTime.Now);
        //�޸���ID
        private string modifyUserid;
        //�޸�����
        private DateTime modifyDate;
        //��������
        private string salerdescriptions;
        //������
        private string buyerdescriptions;
        //����
        private string type;

        public string SalerDescriptions
        {
            get { return salerdescriptions; }
            set { salerdescriptions = value; }
        }
        public string BuyerDescriptions
        {
            get { return buyerdescriptions; }
            set { buyerdescriptions = value; }
        }

        public DateTime ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }

       public DateTime SalerApproverDate
       {
           get { return salerapproverdate; }
           set { salerapproverdate = value; }
       } 

        public string ModifyUserid
        {
            get { return modifyUserid; }
            set { modifyUserid = value; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        } 

        public string CreateUserid
        {
            get { return createUserid; }
            set { createUserid = value; }
        }

        public string CreateUsername
        {
            get { return createUsername; }
            set { createUsername = value; }
        }

        public string SalerWubi
        {
            get { return salerWubi; }
            set { salerWubi = value; }
        }

        public string SalerFast
        {
            get { return salerFast; }
            set { salerFast = value; }
        }

        public string SenderEasy
        {
            get { return senderEasy; }
            set { senderEasy = value; }
        }

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public string SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        public string BuyerLinkTel
        {
            get { return buyerLinkTel; }
            set { buyerLinkTel = value; }
        }

        public string BakBuyerWubi
        {
            get { return bakBuyerWubi; }
            set { bakBuyerWubi = value; }
        }

        public string BakBuyerFast
        {
            get { return bakBuyerFast; }
            set { bakBuyerFast = value; }
        }

        public string BakBuyerEasy
        {
            get { return bakBuyerEasy; }
            set { bakBuyerEasy = value; }
        }

        public string BakBuyerName
        {
            get { return bakBuyerName; }
            set { bakBuyerName = value; }
        }

        public decimal RequestTotal
        {
            get { return requestTotal; }
            set { requestTotal = value; }
        }

        public string RepositoryAddr
        {
            get { return repositoryAddr; }
            set { repositoryAddr = value; }
        }


        public string RepositoryId
        {
            get { return repositoryId; }
            set { repositoryId = value; }
        }

        public string BuyerOrgid
        {
            get { return buyerOrgid; }
            set { buyerOrgid = value; }
        }

        public string DegreeFlag
        {
            get { return degreeFlag; }
            set { degreeFlag = value; }
        }

        public string OrderState
        {
            get { return orderState; }
            set { orderState = value; }
        }

        public string OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }

        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public string PurchaseId
        {
            get { return purchaseId; }
            set { purchaseId = value; }
        }
       public string PurchaseCode
       {
           get { return purchaseCode; }
           set { purchaseCode = value; }
       }
       public string Type
       {
           get { return type; }
           set { type = value; }
       }
    }

    [Serializable]
    public struct PurchaseOrderStruct
    {
        //�ɹ�����ID
        public string purchaseId;
        //�ɹ�����Code
        public string purchaseCode;
        //��������
        public string salerdescriptions;
        //������
        public string buyerdescriptions;
        //����
        public string type;
        //�������
        public string orderId;
        //�������
        public string orderCode;
        //״̬
        public string orderState;
        //���������̶�
        public string degreeFlag;
        //��ID
        public string buyerOrgid;
        //�ֿ�ID
        public string repositoryId;
        //�ͻ���ַ
        public string repositoryAddr;
        //�������
        public decimal requestTotal;
        //ҽԺ����
        public string bakBuyerName;
        //ҽԺ���
        public string bakBuyerEasy;
        //ҽԺƴ�����
        public string bakBuyerFast;
        //ҽԺ��ʼ��
        public string bakBuyerWubi;
        //��ϵ�绰
        public string buyerLinkTel;
        //����ID
        public string senderId;
        //��������
        public string senderName;
        //���ͼ��
        public string senderEasy;
        //����ƴ�����
        public string salerFast;
        //������ʼ��
        public string salerWubi;
        //����������
        public string createUsername;
        //�����û�ID
        public string createUserid;
        //��������
        public DateTime createDate;
        //�޸���ID
        public string modifyUserid;
        //�޸�����
        public DateTime modifyDate;
        // ����ȷ��ʱ��
        public DateTime salerapproverdate;

    }
}
