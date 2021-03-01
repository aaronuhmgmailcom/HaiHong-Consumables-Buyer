//刘海超 2007-10-15
//功能：采购单维护Model层
#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
#endregion

namespace Emedchina.TradeAssistant.Model.Order.PurchaseHandle
{
    /// <summary>
    /// 采购单维护Model层

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

        private String operaState;              // 维护状态 0:新增 1:修改
        private String userID;				    // 登录用户 ID
        private String userName;			    // 登录用户姓名
        private String userOrgID;			    // 用户机构 ID 
        private String userAreaID;			    // 登录用户注册区域
        private String repositoryBz = "";	    // 药库使用标志	1：使用 0：不使用

        private String purchaseId;				// 采购单ID
        private String purchaseCode;            // 采购单CODE
        private String purchaseName;			// 采购单名称
        private String requestTotal;            // 采购总金额

        private String purchaseAreaId;          // 采购单区域id 
        private String buyerOrgid;              // 采购单买方信息
        private int highID;                  //高位id

        private String buyerFullname;
        private String buyerShortname;
        private String buyerWubi;
        private String buyerPinyin;
        private String createUserid;            // 创建用户信息
        private String createUsername;
        private String createDate;
        private String quicksendlevel;        //紧急程度

        private String modifyDate;              // 修改用户信息
        private String modifyUserid;
        private String modifyUsername;
        private String buyerLinkTel;			// 买方联系电话
        private String purchaseRemark;			// 采购单备注 

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
        private String rowState;                // 记录维护状态 0：新增 1：修改 2：删除

        private String purchaseId;	            // 采购单ID
        private String purchaseItemId;	        // 采购单明细记录ID
        private String hitCommId;		        // 采购目录 ID
        private String projectprodid;           //项目产品id 
        private String specid;                  //规格id
        private String spec;                    //规格
        private String modelid;                  //型号id
        private String model;                  //型号id
        private String storeroomid;		        // 仓库ID
        private String storeroomname;		        // 仓库ID
        private String storeroomaddress;		        // 仓库ID
        private String requestQty;              // 采购数量 
        private String productId;		        // 注册产品ID
        private String salerId;			        //经销企业信息
        private String salerName;
        private String salerAbbr;
        private String senderId;			    // 配送qiye信息
        private String senderName;
        private String senderAbbr;
        private String salerWubi;
        private String salerPinyin;
        private String unitPrice;		        // 单价
        private String modifyUserid;
        private String modifyUsername;
        private String descriptions;
        private int highID;                  //高位id
        private String userOrgID;			    // 用户机构 ID 
        private String retailprice;          //零售价
        private String isquicsend;          //是否紧急
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

