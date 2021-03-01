//������ 2007-10-15
//���ܣ��ɹ���ά��Model��
#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
#endregion

namespace Emedchina.TradeAssistant.Model.Order.PurchaseHandle
{
    /// <summary>
    /// �ɹ���ά��Model��

    /// </summary>
    [Serializable]
    public class PurchaseSaveModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Order"/> class.
        /// </summary>
        public PurchaseSaveModel()
        {
        }

        private String operaState;              // ά��״̬ 0:���� 1:�޸�
        private String userID;				    // ��¼�û� ID
        private String userName;			    // ��¼�û�����
        private String userOrgID;			    // �û����� ID 
        private String userAreaID;			    // ��¼�û�ע������
        private String repositoryBz = "";	    // ҩ��ʹ�ñ�־	1��ʹ�� 0����ʹ��

        private String purchaseId;				// �ɹ���ID
        private String purchaseCode;            // �ɹ���CODE
        private String purchaseName;			// �ɹ�������
        private String requestTotal;            // �ɹ��ܽ��

        private String purchaseAreaId;          // �ɹ�������id 
        private String buyerOrgid;              // �ɹ�������Ϣ
        private int highID;                  //��λid

        private String buyerFullname;
        private String buyerShortname;
        private String buyerWubi;
        private String buyerPinyin;
        private String createUserid;            // �����û���Ϣ
        private String createUsername;
        private String createDate;
        private String quicksendlevel;        //�����̶�

        private String modifyDate;              // �޸��û���Ϣ
        private String modifyUserid;
        private String modifyUsername;
        private String buyerLinkTel;			// ����ϵ�绰
        private String purchaseRemark;			// �ɹ�����ע 

        private List<PurchaseItemSaveModel> list = new List<PurchaseItemSaveModel>();

        public List<PurchaseItemSaveModel> List
        {
            get { return list; }
            set { list = value; }
        }

        public int HighID
        {
            get { return highID; }
            set { highID = value; }
        }

        public String QuicksendLevel
        {
            get { return quicksendlevel; }
            set { quicksendlevel = value; }
        }

        public String OperaState
        {
            get { return operaState; }
            set { operaState = value; }
        }

        public String ModifyUsername
        {
            get { return modifyUsername; }
            set { modifyUsername = value; }
        }

        public String ModifyUserid
        {
            get { return modifyUserid; }
            set { modifyUserid = value; }
        } 

        public String ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }

        public String CreateUserid
        {
            get { return createUserid; }
            set { createUserid = value; }
        }
        public String CreateUsername
        {
            get { return createUsername; }
            set { createUsername = value; }
        }
        public String CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

		public String BuyerOrgid
		{
			get { return buyerOrgid; }
			set { buyerOrgid = value; }
		}

		public String BuyerFullname
		{
			get { return buyerFullname; }
			set { buyerFullname = value; }
		}

		public String BuyerShortname
		{
			get { return buyerShortname; }
			set { buyerShortname = value; }
		}

		public String BuyerWubi
		{
			get { return buyerWubi; }
			set { buyerWubi = value; }
		}

		public String BuyerPinyin
		{
			get { return buyerPinyin; }
			set { buyerPinyin = value; }
		}

        public String PurchaseAreaId
        {
            get { return purchaseAreaId; }
            set { purchaseAreaId = value; }
        }

        public String RepositoryBz
        {
            get { return repositoryBz; }
            set { repositoryBz = value; }
        }

        public String BuyerLinkTel
        {
            get { return buyerLinkTel; }
            set { buyerLinkTel = value; }
        }

        public String UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public String UserOrgID
        {
            get { return userOrgID; }
            set { userOrgID = value; }
        }

        public String UserAreaID
        {
            get { return userAreaID; }
            set { userAreaID = value; }
        }

        public String PurchaseId
		{
			get { return purchaseId; }
			set { purchaseId = value; }
		}

        public String PurchaseCode
        {
            get { return purchaseCode; }
            set { purchaseCode = value; }
        }

		public String PurchaseName
		{
			get { return purchaseName; }
			set { purchaseName = value; }
		}

        public String RequestTotal
        {
            get { return requestTotal; }
            set { requestTotal = value; }
        }

		public String PurchaseRemark
		{
			get { return purchaseRemark; }
			set { purchaseRemark = value; }
		}

        private String state;
        public String State
        {
            get { return state; }
            set { state = value; }
        }
    }

    [Serializable]
    public class PurchaseItemSaveModel
    {
        private String rowState;                // ��¼ά��״̬ 0������ 1���޸� 2��ɾ��

        private String purchaseId;	            // �ɹ���ID
        private String purchaseItemId;	        // �ɹ�����ϸ��¼ID
        private String hitCommId;		        // �ɹ�Ŀ¼ ID
        private String projectprodid;           //��Ŀ��Ʒid 
        private String specid;                  //���id
        private String spec;                    //���
        private String modelid;                  //�ͺ�id
        private String model;                  //�ͺ�id
        private String storeroomid;		        // �ֿ�ID
        private String storeroomname;		        // �ֿ�ID
        private String storeroomaddress;		        // �ֿ�ID
        private String requestQty;              // �ɹ����� 
        private String productId;		        // ע���ƷID
        private String salerId;			        //������ҵ��Ϣ
        private String salerName;
        private String salerAbbr;
        private String senderId;			    // ����qiye��Ϣ
        private String senderName;
        private String senderAbbr;
        private String salerWubi;
        private String salerPinyin;
        private String unitPrice;		        // ����
        private String modifyUserid;
        private String modifyUsername;
        private String descriptions;
        private int highID;                  //��λid
        private String userOrgID;			    // �û����� ID 
        private String retailprice;          //���ۼ�
        private String isquicsend;          //�Ƿ����
        private String createid;
        private String createname;

        public string Createid
        {
            get { return createid; }
            set { createid = value; }
        }
        public string Createname
        {
            get { return createname; }
            set { createname = value; }
        }

        public string Retailprice
        {
            get { return retailprice; }
            set { retailprice = value; }
        }
        public string Isquicsend
        {
            get { return isquicsend; }
            set { isquicsend = value; }
        }

        public string UserOrgID
        {
            get { return userOrgID; }
            set { userOrgID = value; }
        }
        
        public int HighID
        {
            get { return highID; }
            set { highID = value; }
        }

        public String Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        public String ModifyUsername
        {
            get { return modifyUsername; }
            set { modifyUsername = value; }
        }
        public String Model
        {
            get { return model; }
            set { model = value; }
        }

        public String Storeroomname
        {
            get { return storeroomname; }
            set { storeroomname = value; }
        }

        public String Storeroomaddress
        {
            get { return storeroomaddress; }
            set { storeroomaddress = value; }
        }

        public String SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        public String SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        public String SenderAbbr
        {
            get { return senderAbbr; }
            set { senderAbbr = value; }
        }


        public String SpecId
        {
            get { return specid; }
            set { specid = value; }
        }

        public String ModelId
        {
            get { return modelid; }
            set { modelid = value; }
        }


        public String Projectprodid
        {
            get { return projectprodid; }
            set { projectprodid = value; }
        }

        public String Descriptions
		{
            get { return descriptions; }
            set { descriptions = value; }
		}


        public String ModifyUserid
        {
            get { return modifyUserid; }
            set { modifyUserid = value; }
        }

        public String RowState
        {
            get { return rowState; }
            set { rowState = value; }
        }

        public String PurchaseId
        {
            get { return purchaseId; }
            set { purchaseId = value; }
        }

        public String HitCommId
        {
            get { return hitCommId; }
            set { hitCommId = value; }
        }
       
        
        public String SalerId
        {
            get { return salerId; }
            set { salerId = value; }
        }
        public String ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public String Storeroomid
        {
            get { return storeroomid; }
            set { storeroomid = value; }
        }
        public String UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public String PurchaseItemId
        {
            get { return purchaseItemId; }
            set { purchaseItemId = value; }
        }
        public String SalerName
        {
            get { return salerName; }
            set { salerName = value; }
        }

        public String SalerAbbr
        {
            get { return salerAbbr; }
            set { salerAbbr = value; }
        }

        public String SalerWubi
        {
            get { return salerWubi; }
            set { salerWubi = value; }
        }

        public String SalerPinyin
        {
            get { return salerPinyin; }
            set { salerPinyin = value; }
        }

        public String RequestQty
        {
            get { return requestQty; }
            set { requestQty = value; }
        }


    }


}

