using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.SalerReturn
{
    [Serializable]
    public class SalerReturnModel
    {
        //ID
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        //����/���ͱ�ע
        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        //orgID
        private string curOrgId;
        public string CurOrgId
        {
            get { return curOrgId; }
            set { curOrgId = value; }
        }

        //״̬
        private string returnState;
        public string ReturnState
        {
            get { return returnState; }
            set { returnState = value; }
        }

        //��ʼʱ��
        private string startDate;
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        //����ʱ��
        private string endDate;
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        //��ѯ���(1--Ʒ��,2--Ʒ��ƴ��,3--Ʒ�����,4--ҽԺ����)
        private string strType;
        public string StrType
        {
            get { return strType; }
            set { strType = value; }
        }

        //��ѯ�ؼ���
        private string strKeyValue;
        public string StrKeyValue
        {
            get { return strKeyValue; }
            set { strKeyValue = value; }
        }

        //������ɣ�
        private string strReceiveID;
        public string StrReceiveID
        {
            get { return strReceiveID; }
            set { strReceiveID = value; }
        }

        //ʣ�ൽ����
        private double strReceiveQty;
        public double StrReceiveQty
        {
            get { return strReceiveQty; }
            set { strReceiveQty = value; }
        }
    }

    [Serializable]
    public class SalerReturnPrintModel
    {
        //���
        private string serialNm;
        //����
        private string tableType;
        //ID
        private string returnId;
        //ҩƷ��
        private string commonName;
        //��Ʒ��
        private string productName;
        //����
        private string mode;
        //�������
        private string zlcc;
        //����װ
        private string ggbz;                
        //�˻�����
        private string returner;
        //����
        private string lotNo;
        //ҩ��
        private string warehouseName;
        //�˻���
        private string requestQty;
        //�˻�ԭ��
        private string returnReason;
        //�˻�ʱ��
        private string createTime;
        //ȷ��ʱ��
        private string confirmTime;
        //��ע
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string TableType
        {
            get { return tableType; }
            set { tableType = value; }
        }

        public string SerialNm
        {
            get { return serialNm; }
            set { serialNm = value; }
        }
        public string ConfirmTime
        {
            get { return confirmTime; }
            set { confirmTime = value; }
        }

        public string ReturnId
        {
            get { return returnId; }
            set { returnId = value; }
        }

        public string CommonName
        {
            get { return commonName; }
            set { commonName = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Ggbz
        {
            get { return ggbz; }
            set { ggbz = value; }
        }

        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public string Zlcc
        {
            get { return zlcc; }
            set { zlcc = value; }
        }

        public string Returner
        {
            get { return returner; }
            set { returner = value; }
        }

        public string LotNo
        {
            get { return lotNo; }
            set { lotNo = value; }
        }

        public string WarehouseName
        {
            get { return warehouseName; }
            set { warehouseName = value; }
        }

        public string RequestQty
        {
            get { return requestQty; }
            set { requestQty = value; }
        }

        public string ReturnReason
        {
            get { return returnReason; }
            set { returnReason = value; }
        }

        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
    }
}
