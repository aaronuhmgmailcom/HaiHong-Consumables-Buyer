using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Map
{
   [Serializable]
   public class ProductCropModel
    {
       string orgid;
       public string OrgID
       {
           get { return orgid; }
           set { orgid = value; }
       }
       string modifyuserid;
       public string ModifyUserID
       {
           get { return modifyuserid; }
           set { modifyuserid = value; }
       }
        //��ʼҳ����
        private int start;

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        // ����ҳ����
        private int end;

        public int End
        {
            get { return end; }
            set { end = value; }
        }
        int rows;
       public int Rows
       {
           get { return rows; }
           set { rows = value; }
       }
    
        string id;
        public string ID//ID
        {
            get { return id; }
            set { id = value; }
        }
        string productID;

        public string ProductID//�����ƷID
        {
            get { return productID; }
            set { productID = value; }
        }
        string buyerID;
        public string BuyerID//������ID
        {
            get { return buyerID; }
            set { buyerID = value; }
        }
        string factoryID;
        public string FactoryID//����������ҵID
        {
            get { return factoryID; }
            set { factoryID = value; }
        }
        string salerID;
        /// <summary>
        /// ���羭����ҵID
        /// </summary>
        public string SalerID
        {
            get { return salerID; }
            set { salerID = value; }
        }
        string senderID;
        /// <summary>
        /// ����������ҵID
        /// </summary>
        public string SenderID
        {
            get { return senderID; }
            set { senderID = value; }
        }
        string specUnit;
        /// <summary>
        /// ��С��װ��λ
        /// </summary>
        public string SpecUnit
        {
            get { return specUnit; }
            set { specUnit = value; }
        }
       string cropstate;
        /// <summary>
        ///ƥ��״̬
        /// </summary>
       public string CropState
       {
           get { return this.cropstate; }
           set { this.cropstate = value; }
       }
       
       private string dealstate;
        /// <summary>
       /// ����״̬
        /// </summary>
       public string DealState
       {
           get { return this.dealstate; }
           set { this.dealstate = value; }
       }
        string packageRate;
        /// <summary>
        /// ERP��װת����
        /// </summary>
        public string PackageRate
        { 
            get 
            {
                if (string.IsNullOrEmpty(packageRate))
                    packageRate = "1";
                return packageRate;
            }
            set { packageRate = value; }
        }
        string modeName;
        /// <summary>
        /// ��������
        /// </summary>
        public string ModeName
        {
            get { return modeName; }
            set { modeName = value; }
        }
        string remark;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        string specUnitCode;
        /// <summary>
        /// ��С��װ��λ����
        /// </summary>
        public string SpecUnitCode
        {
            get { return specUnitCode; }
            set { specUnitCode = value; }
        }
        string standRate;
        /// <summary>
        /// ���絥λת����
        /// </summary>
        public string StandRate
        {
            get 
            {
                if (string.IsNullOrEmpty(standRate))
                    standRate = "1";
                return standRate;
            }
            set { standRate = value; }
        }
        string modeCode;
        /// <summary>
        /// ���ͱ���
        /// </summary>
        public string ModeCode
        {
            get { return modeCode; }
            set { modeCode = value; }
        }
        string producer;
        /// <summary>
        /// ������ҵ
        /// </summary>
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }
        string producerCode;
        /// <summary>
        /// ������ҵ����
        /// </summary>
        public string ProducerCode
        {
            get { return producerCode; }
            set { producerCode = value; }
        }
        string useUnit;
        /// <summary>
        /// ��Сʹ�õ�λ
        /// </summary>
        public string UseUnit
        {
            get { return useUnit; }
            set { useUnit = value; }
        }
        string useUnitCode;
        /// <summary>
        /// ��Сʹ�õ�λ����
        /// </summary>
        public string UseUnitCode
        {
            get { return useUnitCode; }
            set { useUnitCode = value; }
        }
        string specName;
        /// <summary>
        /// �������
        /// </summary>
        public string SpecName
        {
            get { return specName; }
            set { specName = value; }
        }
        string specCode;
        /// <summary>
        /// ������
        /// </summary>
        public string SpecCode
        {
            get { return specCode; }
            set { specCode = value; }
        }
        string name;
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        string read;
        /// <summary>
        /// ���Ķ�
        /// </summary>
        public string Read
        {
            get { return read; }
            set { read = value; }
        }
       string sender;
       /// <summary>
       /// ������ҵ
       /// </summary>
       public string Sender
       {
           get { return sender; }
           set { sender = value; }
       }
       string saler;
       /// <summary>
       /// ������ҵ
       /// </summary>
       public string Saler
       {
           get { return saler; }
           set { saler = value; }
       }
       string sourcetype;
       /// <summary>
       /// ��Դ����
       /// </summary>
       public string SourceType
       {
           get { return sourcetype; }
           set { sourcetype = value; }
       }
       string compare;
       /// <summary>
       /// ���չ�ϵ
       /// </summary>
       public string Compare
       {
           get { return compare; }
           set { compare = value; }
       }
    } 
   
}
