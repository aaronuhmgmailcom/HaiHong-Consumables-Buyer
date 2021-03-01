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
   public class PurchaseOrderItemModel
    {
       //������ID
        private string orderId="0";
        //��¼��
        private string recordId="0";
        //�ɹ���ID
        private string purchaseId = "0";
        //�ɹ�����ϸID
        private string purchaseItemId="0";
        //���Ĳ�ƷID
        private string dataproductId="0";
        //��Ŀ��ƷID
        private string projectprodId="0";
        //�����ɹ�Ŀ¼ID
        private string hitCommId="0";
        //����ID
        private string areaId="0";
        //ҽ�ƻ���ID
        private string buyerOrgid="0";
        //ҽԺ����
        private string bakBuyerName;
        //ҽԺ���
        private string bakBuyerEasy;
        //����
        private decimal unitPrice=0;
        //���׽��
        private decimal sum = 0;
        //����״̬
        private string readyFlag;
        //�ɹ���
        private decimal requestQty=0;
        //��ͬID
        private string conId;
        //��ͬ��ϸID
        private string conItemId;
        //��Ŀ��ʶ
        private string projectId;
        //��ͬ����
        private string conType;
        //�ֿ�ID
        private string repositoryId;
       //�ֿ�����
        private string storeroomname;
        //�ͻ���ַ
        private string repositoryAddr;
        //�򷽱�ע
        private string buyerDesc;
        //������ע
        private string salerDesc;
        //���������̶�
        private string degreeFlag;
        //��ע
        private string remark;
        //Դ������ϸID
        private string originalItemId;
        //��������ϸID
        private string parentItemId;
        //��ϸ״̬
        private string itemStatus;
        //ʡ������ۼ�
        private decimal maxPrice;
        //��������
        private string orderType="0";
        //����������
         private string createusername;
        //��������
        private DateTime createDate=Convert.ToDateTime(DateTime.Now);
        //�޸���ID
        private string modifyUserid;
        //�޸�����
        private DateTime modifyDate;
        //������ID
        private string salerId;
        //������
        private string salername;
        //�����̼��
        private string salernameeasy;
        //������ID
        private string senderId;
        //������
        private string sendername;
        //�����̼��
        private string sendernameeasy;
        //������ҵID
        private string manufactureId;
        //������ҵ
        private string manufacturename;
        //������ҵ���
        private string manufacturenameeasy;
        //ͨ������
       private string commonname;
       //��Ʒ����
       private string productname;
       //��Ʒ����
       private string productcode;
       //���ID
       private string specid;
       //�ͺ�ID
       private string modelid;
       //���
       private string spec;
       //�ͺ�
       private string model;
       //Ʒ��
       private string  brand;
       //����
       private string  goodsno;
       //����
       private string  barcode;
       //������λ���
       private string basemeasuerspec;
        //����������λ
       private string basemeasure;
        //���ͼ�����λ
       private string sendmeasure;
        //����ת����
       private string sendmeasureex;
        //������λ��װ����
       private string basemeasuremater;
       //������ҵID
       private string balanceid;
       //������ҵ����
       private string balancename;
       //������ҵ���
       private string balanceeasy;
       //������ҵƴ�����
       private string balancefast;
       //������ҵ��ʼ��
       private string balancewubi;
       //�д��װ
       private decimal package = 0;
       public decimal Package
       {
           get { return package; }
           set { package = value; }
       } 
       public string Balanceid
       {
           get { return balanceid; }
           set { balanceid = value; }
       }
       public string Balancename
       {
           get { return balancename; }
           set { balancename = value; }
       }
       public string Balanceeasy
       {
           get { return balanceeasy; }
           set { balanceeasy = value; }
       }
       public string Balancefast
       {
           get { return balancefast; }
           set { balancefast = value; }
       }
       public string Balancewubi
       {
           get { return balancewubi; }
           set { balancewubi = value; }
       }

       public string Basemeasuerspec
        {
            get { return basemeasuerspec; }
            set { basemeasuerspec = value; }
        }
       public string Basemeasure
        {
            get { return basemeasure; }
            set { basemeasure = value; }
        }
       public string Sendmeasure
        {
            get { return sendmeasure; }
            set { sendmeasure = value; }
        }
       public string Sendmeasureex
        {
            get { return sendmeasureex; }
            set { sendmeasureex = value; }
        }
       public string Basemeasuremater
        {
            get { return basemeasuremater; }
            set { basemeasuremater = value; }
        }
       public string    CommonName
        {
            get { return commonname; }
            set { commonname = value; }
        }
       public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
       private string abbr_Py;
       public string Abbr_Py
       {
           get { return abbr_Py; }
           set { abbr_Py = value; }
       }
       private string abbr_Wb;
       public string Abbr_Wb
       {
           get { return abbr_Wb; }
           set { abbr_Wb = value; }
       }
       public string ProductCode
        {
            get { return productcode; }
            set { productcode = value; }
        }
       public string SpecId
        {
            get { return specid; }
            set { specid = value; }
        }
       public string ModelId
        {
            get { return modelid; }
            set { modelid = value; }
        }
       public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
       public string Model
        {
            get { return model; }
            set { model = value; }
        }
       public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
       public string Goodsno
        {
            get { return goodsno; }
            set { goodsno = value; }
        }
       public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public DateTime ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
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

        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        public decimal MaxPrice
        {
            get { return maxPrice; }
            set { maxPrice = value; }
        } 

        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; }
        }

        public string ParentItemId
        {
            get { return parentItemId; }
            set { parentItemId = value; }
        }

        public string OriginalItemId
        {
            get { return originalItemId; }
            set { originalItemId = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string DegreeFlag
        {
            get { return degreeFlag; }
            set { degreeFlag = value; }
        }


        public string SalerDesc
        {
            get { return salerDesc; }
            set { salerDesc = value; }
        }

        public string BuyerDesc
        {
            get { return buyerDesc; }
            set { buyerDesc = value; }
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

        public string ConType
        {
            get { return conType; }
            set { conType = value; }
        }

        public string ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public string ConItemId
        {
            get { return conItemId; }
            set { conItemId = value; }
        }

        public string ConId
        {
            get { return conId; }
            set { conId = value; }
        }

        public decimal RequestQty
        {
            get { return requestQty; }
            set { requestQty = value; }
        } 

        public string ReadyFlag
        {
            get { return readyFlag; }
            set { readyFlag = value; }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

       public decimal Sum
       {
           get { return sum; }
           set { sum = value; }
       } 

        public string BuyerOrgid
        {
            get { return buyerOrgid; }
            set { buyerOrgid = value; }
        }

        public string AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        public string HitCommId
        {
            get { return hitCommId; }
            set { hitCommId = value; }
        }

       public string PurchaseId
       {
           get { return purchaseId; }
           set { purchaseId = value; }
       }

        public string PurchaseItemId
        {
            get { return purchaseItemId; }
            set { purchaseItemId = value; }
        }

        public string RecordId
        {
            get { return recordId; }
            set { recordId = value; }
        }

        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
       public string DataproductId
       {
           get { return dataproductId; }
           set { dataproductId = value; }
       }
       public string ProjectprodId
       {
           get { return projectprodId; }
           set { projectprodId = value; }
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
       public string SalerId
       {
           get { return salerId; }
           set { salerId = value; }
       }
       public string SalerName
       {
           get { return salername; }
           set { salername = value; }
       }
       public string SalerNameEasy
       {
           get { return salernameeasy; }
           set { salernameeasy = value; }
       }
       public string SenderId
       {
           get { return senderId; }
           set { senderId = value; }
       }
       public string SenderName
       {
           get { return sendername; }
           set { sendername = value; }
       }
       public string SenderNameEasy
       {
           get { return sendernameeasy; }
           set { sendernameeasy = value; }
       }
       
       public string ManufactureId
       {
           get { return manufactureId; }
           set { manufactureId = value; }
       }
       public string ManufactureName
       {
           get { return manufacturename; }
           set { manufacturename = value; }
       }
       public string ManufactureNameEasy  
       {
           get { return manufacturenameeasy; }
           set { manufacturenameeasy = value; }
       }
       public string Storeroomname
       {
           get { return storeroomname; }
           set { storeroomname = value; }
       }
       
         public string Createusername
       {
           get { return createusername ; }
           set { createusername = value; }
       }
       //����
       private int amount = 0;
       public int Amount
       {
           get { return amount; }
           set { amount = value; }
       } 
    }

    [Serializable]
    public struct PurchaseOrderItemStruct
    {
        //������ID
        public string orderId;
        //��¼��
        public string recordId;
        //�ɹ���ID
        public string purchaseId;
        //�ɹ�����ϸID
        public string purchaseItemId;
        //�����ɹ�Ŀ¼ID
        public string hitCommId;
        //����ID
        public string areaId;
        //ҽ�ƻ���ID
        public string buyerOrgid;
        //ҽԺ����
        public string bakBuyerName;
        //ҽԺ���
        public string bakBuyerEasy;
        //����
        public decimal unitPrice;
        //����״̬
        public string readyFlag;
        //�ɹ���
        public decimal requestQty;
        //��ͬID
        public string conId;
        //��ͬ��ϸID
        public string conItemId;
        //��Ŀ��ʶ
        public string projectId;
        //��ͬ����
        public string conType;
        //�ֿ�ID
        public string repositoryId;
        //�ͻ���ַ
        public string repositoryAddr;
        //�򷽱�ע
        public string buyerDesc;
        //������ע
        public string salerDesc;
        //���������̶�
        public string degreeFlag;
        //��ע
        public string remark;
        //Դ������ϸID
        public string originalItemId;
        //��������ϸID
        public string parentItemId;
        //��ϸ״̬
        public string itemStatus;
        //ʡ������ۼ�
        public decimal maxPrice;
        //���׽��
        public decimal sum;
        //��������
        public string orderType;
        //��������
        public DateTime createDate;
        //�޸���ID
        public string modifyUserid;
        //�޸�����
        public DateTime modifyDate;
        //���Ĳ�ƷID
        public string dataproductId ;
        //��Ŀ��ƷID
        public string projectprodId ;
        //������ID
        public string salerId;
        //������
        public string salername;
        //�����̼��
        public string salernameeasy;
        //������ID
        public string senderId;
        //������
        public string sendername;
        //�����̼��
        public string sendernameeasy;
        //������ҵID
        public string manufactureId;
        //������ҵ
        public string manufacturename;
        //������ҵ���
        public string manufacturenameeasy;
        //ͨ������
        public string commonname;
        //��Ʒ����
        public string productname;
        //��Ʒ����
        public string productcode;
        //���ID
        public string specid;
        //�ͺ�ID
        public string modelid;
        //���
        public string spec;
        //�ͺ�
        public string model;
        //Ʒ��
        public string brand;
        //����
        public string goodsno;
        //����
        public string barcode;
        //������λ���
        public string basemeasuerspec;
        //����������λ
        public string basemeasure;
        //���ͼ�����λ
        public string sendmeasure;
        //����ת����
        public string sendmeasureex;
        //������λ��װ����
        public string basemeasuremater;
        //������ҵID
        public string balanceid;
        //������ҵ����
        public string balancename;
        //������ҵ���
        public string balanceeasy;
        //������ҵƴ�����
        public string balancefast;
        //������ҵ��ʼ��
        public string balancewubi;
        //�ֿ�����
        public string storeroomname;
        //����������
        public string createusername;
    }

}
