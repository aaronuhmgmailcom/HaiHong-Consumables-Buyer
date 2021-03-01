using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.SalerOrder
{
    [Serializable]
    public class SalerOrderListModel
    {
        private string orgId;
        private string platId;
        private string order_state;
        private string order_type;
        private string startDate;
        private string endDate;
        private string buyerName;
        private string orderCode;
        private string medical_name;
        private int pageNum;
        private int pageSize;
        private bool isFactory;
        private string areaList;
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string AreaList
        {
            get { return areaList; }
            set { areaList = value; }
        }

        public bool IsFactory
        {
            get { return isFactory; }
            set { isFactory = value; }
        }
        # region orgId
        public string OrgId
        {
            get { return orgId; }
            set { orgId = value; }
        }
        #endregion

        # region platId
        public string PlatId
        {
            get { return platId; }
            set { platId = value; }
        }
        #endregion

        # region order_state
        public string Order_state
        {
            get { return order_state; }
            set { order_state = value; }
        }
        #endregion

        # region order_type
        public string Order_type
        {
            get { return order_type; }
            set { order_type = value; }
        }
        #endregion

        # region startDate
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        #endregion

        # region endDate
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        #endregion

        # region buyerName
        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }
        #endregion

        # region orderCode
        public string OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }
        #endregion

        # region medical_name
        public string Medical_name
        {
            get { return medical_name; }
            set { medical_name = value; }
        }
        #endregion

        # region pageNum
        public int PageNum
        {
            get { return pageNum; }
            set { pageNum = value; }
        }
        #endregion

        # region pageSize
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        #endregion

    }

    [Serializable]
    public class SalerOrderModel
    {
        private string order_id;
        private string buyer_orgid;
        private string bak_buyer_easy;
        private string saler_orgid;
        private string sender_orgid;
        private string bak_saler_easy;
        private string bak_sender_easy;
        private string order_remark;
        private string request_total;
        private string receive_total;
        private string user_name;
        private string create_date;
        private string order_state;
        private string purchaseCreator;
        private string order_code;
        private string linkman;
        private string telePhone;
        private string address;
        private string order_state_name;
        private string plat_id;
        private string isDiscountBatch;//是否使用规模折扣
        private string isDiscountPayment;//是否使用回款折扣
        private string isDiscountPayatonce;//是否使用现款折扣
        private string isDiscountThirtyday;//是否使用30天付款折扣
        private string post_code;
        private string wareHouse;

        public string Post_code
        {
            get { return post_code; }
            set { post_code = value; }
        }
        

        public string WareHouse
        {
            get { return wareHouse; }
            set { wareHouse = value; }
        }
		

		

        private string repository_id;
        # region order_id
        public string Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }
        #endregion

        # region buyer_orgid
        public string Buyer_orgid
        {
            get { return buyer_orgid; }
            set { buyer_orgid = value; }
        }
        #endregion

        # region bak_buyer_easy
        public string Bak_buyer_easy
        {
            get { return bak_buyer_easy; }
            set { bak_buyer_easy = value; }
        }
        #endregion

        # region saler_orgid
        public string Saler_orgid
        {
            get { return saler_orgid; }
            set { saler_orgid = value; }
        }
        #endregion

        # region sender_orgid
        public string Sender_orgid
        {
            get { return sender_orgid; }
            set { sender_orgid = value; }
        }
        #endregion

        # region bak_saler_easy
        public string Bak_saler_easy
        {
            get { return bak_saler_easy; }
            set { bak_saler_easy = value; }
        }
        #endregion

        # region bak_sender_easy
        public string Bak_sender_easy
        {
            get { return bak_sender_easy; }
            set { bak_sender_easy = value; }
        }
        #endregion

        # region order_remark
        public string Order_remark
        {
            get { return order_remark; }
            set { order_remark = value; }
        }
        #endregion

        # region request_total
        public string Request_total
        {
            get { return request_total; }
            set { request_total = value; }
        }
        #endregion

        # region receive_total
        public string Receive_total
        {
            get { return receive_total; }
            set { receive_total = value; }
        }
        #endregion

        # region user_name
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        #endregion

        # region create_date
        public string Create_date
        {
            get { return create_date; }
            set { create_date = value; }
        }
        #endregion

        # region order_state
        public string Order_state
        {
            get { return order_state; }
            set { order_state = value; }
        }
        #endregion

        # region purchaseCreator
        public string PurchaseCreator
        {
            get { return purchaseCreator; }
            set { purchaseCreator = value; }
        }
        #endregion

        # region order_code
        public string Order_code
        {
            get { return order_code; }
            set { order_code = value; }
        }
        #endregion

        # region linkman
        public string Linkman
        {
            get { return linkman; }
            set { linkman = value; }
        }
        #endregion

        # region telePhone
        public string TelePhone
        {
            get { return telePhone; }
            set { telePhone = value; }
        }
        #endregion

        # region address
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion

        # region order_state_name
        public string Order_state_name
        {
            get { return order_state_name; }
            set { order_state_name = value; }
        }
        #endregion

        # region repository_id
        public string Repository_id
        {
            get { return repository_id; }
            set { repository_id = value; }
        }
        #endregion
        # region plat_id
        public string Plat_id
        {
            get { return plat_id; }
            set { plat_id = value; }
        }
        #endregion

        # region isDiscountBatch
        public string IsDiscountBatch
        {
            get { return isDiscountBatch; }
            set { isDiscountBatch = value; }
        }
        #endregion

        # region isDiscountPayment
        public string IsDiscountPayment
        {
            get { return isDiscountPayment; }
            set { isDiscountPayment = value; }
        }
        #endregion

        # region isDiscountPayatonce
        public string IsDiscountPayatonce
        {
            get { return isDiscountPayatonce; }
            set { isDiscountPayatonce = value; }
        }
        #endregion

        # region isDiscountThirtyday
        public string IsDiscountThirtyday
        {
            get { return isDiscountThirtyday; }
            set { isDiscountThirtyday = value; }
        }
        #endregion
    }

    [Serializable]
    public class SalerOrderItemModel
    {
        private bool isChecked;
		


        private string appNum;

        private string requestTotal;

        private string wrapName ;

        private string sourceTypeName ;

        private string createDate;

        private string bakFactoryEasy ;

        private string invoiceExpireDate;

        private string invoiceNo ;

        private string invoiceTotal ;

        private string invoiceTradePrice ;

        private string invoiceRetailPrice ;

        private string invoiceDiscountRate ;

        private string invoiceDate ;

        private string invoiceEffectDate ;

        private string readyRemark ;

        private string orderCode ;

        private string remark ;

        private string buyerDesc ;

        private string prefixBuyerDesc ;

        private string salerDesc ;

        private string receiveQty1 ;

        private string lotNo ;

        private string receiveFlag ;

        private string id ;

        private string recordId ;

        private string orderId ;

        private string productId ;

        private string orderItemState ;

        private string platId ;

        private string buyerOrgid ;

        private string bakBuyerName ;

        private string salerOrgid ;

        private string senderOrgid ;

        private string agentOrgid ;

        private string unitPrice ;

        private string bakMedicalId ;

        private string bakMedicalName ;

        private string bakMedicalMode ;

        private string bakProductName ;

        private string bakProductSpec ;

        private string bakProductBidWay ;

        private string bakFactoryId ;

        private string bakFactoryName ;

        private string metricName ;

        private string requestQty ;

        private string receiveQty ;

        private string repositoryId ;

        private string repositoryName ;

        private string sourceType ;

        private string sourceProjectId ;

        private string bakMedicalSpec ;

        private string middleStandRate ;

        private string bigMiddleRate ;

        private string bakMassAssignment ;

        private string readyFlag ;

        private string readyQty ;

        private string degreeFlag ;

        private string emergencyType ;// 临床类别(3.0浙江改造用)

        /**
         * 以订单发出时开始计算(浙江3.0改造用)， 如果emergencyType=0,并且已经过48小时，那么isInfectShow=1
         * 如果emergencyType=1,并且已经过24小时，那么isInfectShow=1 如果emergencyType=2,并且已经过4小时，那么isInfectShow=1
         * 否则isInfectShow=0,默认也为0
         */
        private string isInfectShow ;

        private string readyDate; // 备货时间

        private string receiveDate; // 确认时间

        private string lateFlag; // 是否影响临床用药

        private string checkBoxShow;

		


        // 以下四个变量为折扣对应的值 
        // 规模折扣
        private string discountBatchValue ;

        // 回款折扣
        private string discountPaymentValue ;

        // 现款折扣
        private string discountPayatonceValue ;

        // 付款折扣
        private string discountThirtydayValue ;

        private string orderStateName;

        private string maxQty;

        private string orderType;

        private bool impFlag = false;

        public bool ImpFlag
        {
            get { return impFlag; }
            set { impFlag = value; }
        }

        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        public string MaxQty
        {
            get { return maxQty; }
            set { maxQty = value; }
        }

		public string OrderStateName
		{
			get { return orderStateName; }
			set { orderStateName = value; }
		}

        # region isChecked
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }
        #endregion
		public string AppNum
		{
			get { return appNum; }
			set { appNum = value; }
		}

		public string RequestTotal
		{
			get { return requestTotal; }
			set { requestTotal = value; }
		}

		public string WrapName
		{
			get { return wrapName; }
			set { wrapName = value; }
		}

		public string SourceTypeName
		{
			get { return sourceTypeName; }
			set { sourceTypeName = value; }
		}

		public string CreateDate
		{
			get { return createDate; }
			set { createDate = value; }
		}

		public string BakFactoryEasy
		{
			get { return bakFactoryEasy; }
			set { bakFactoryEasy = value; }
		}

		public string InvoiceExpireDate
		{
			get { return invoiceExpireDate; }
			set { invoiceExpireDate = value; }
		}

		public string InvoiceNo
		{
			get { return invoiceNo; }
			set { invoiceNo = value; }
		}

		public string InvoiceTotal
		{
			get { return invoiceTotal; }
			set { invoiceTotal = value; }
		}

		public string InvoiceTradePrice
		{
			get { return invoiceTradePrice; }
			set { invoiceTradePrice = value; }
		}

		public string InvoiceRetailPrice
		{
			get { return invoiceRetailPrice; }
			set { invoiceRetailPrice = value; }
		}

		public string InvoiceDiscountRate
		{
			get { return invoiceDiscountRate; }
			set { invoiceDiscountRate = value; }
		}

		public string InvoiceDate
		{
			get { return invoiceDate; }
			set { invoiceDate = value; }
		}

		public string InvoiceEffectDate
		{
			get { return invoiceEffectDate; }
			set { invoiceEffectDate = value; }
		}

		public string ReadyRemark
		{
			get { return readyRemark; }
			set { readyRemark = value; }
		}

		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}

		public string Remark
		{
			get { return remark; }
			set { remark = value; }
		}

		public string BuyerDesc
		{
			get { return buyerDesc; }
			set { buyerDesc = value; }
		}

		public string PrefixBuyerDesc
		{
			get { return prefixBuyerDesc; }
			set { prefixBuyerDesc = value; }
		}

		public string SalerDesc
		{
			get { return salerDesc; }
			set { salerDesc = value; }
		}

		public string ReceiveQty1
		{
			get { return receiveQty1; }
			set { receiveQty1 = value; }
		}

		public string LotNo
		{
			get { return lotNo; }
			set { lotNo = value; }
		}

		public string ReceiveFlag
		{
			get { return receiveFlag; }
			set { receiveFlag = value; }
		}

		public string Id
		{
			get { return id; }
			set { id = value; }
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

		public string ProductId
		{
			get { return productId; }
			set { productId = value; }
		}

		public string OrderItemState
		{
			get { return orderItemState; }
			set { orderItemState = value; }
		}

		public string PlatId
		{
			get { return platId; }
			set { platId = value; }
		}

		public string BuyerOrgid
		{
			get { return buyerOrgid; }
			set { buyerOrgid = value; }
		}

		public string BakBuyerName
		{
			get { return bakBuyerName; }
			set { bakBuyerName = value; }
		}

		public string SalerOrgid
		{
			get { return salerOrgid; }
			set { salerOrgid = value; }
		}

		public string SenderOrgid
		{
			get { return senderOrgid; }
			set { senderOrgid = value; }
		}

		public string AgentOrgid
		{
			get { return agentOrgid; }
			set { agentOrgid = value; }
		}

		public string UnitPrice
		{
			get { return unitPrice; }
			set { unitPrice = value; }
		}

		public string BakMedicalId
		{
			get { return bakMedicalId; }
			set { bakMedicalId = value; }
		}

		public string BakMedicalName
		{
			get { return bakMedicalName; }
			set { bakMedicalName = value; }
		}

		public string BakMedicalMode
		{
			get { return bakMedicalMode; }
			set { bakMedicalMode = value; }
		}

		public string BakProductName
		{
			get { return bakProductName; }
			set { bakProductName = value; }
		}

		public string BakProductSpec
		{
			get { return bakProductSpec; }
			set { bakProductSpec = value; }
		}

		public string BakProductBidWay
		{
			get { return bakProductBidWay; }
			set { bakProductBidWay = value; }
		}

		public string BakFactoryId
		{
			get { return bakFactoryId; }
			set { bakFactoryId = value; }
		}

		public string BakFactoryName
		{
			get { return bakFactoryName; }
			set { bakFactoryName = value; }
		}

		public string MetricName
		{
			get { return metricName; }
			set { metricName = value; }
		}

		public string RequestQty
		{
			get { return requestQty; }
			set { requestQty = value; }
		}

		public string ReceiveQty
		{
			get { return receiveQty; }
			set { receiveQty = value; }
		}

		public string RepositoryId
		{
			get { return repositoryId; }
			set { repositoryId = value; }
		}

		public string RepositoryName
		{
			get { return repositoryName; }
			set { repositoryName = value; }
		}

		public string SourceType
		{
			get { return sourceType; }
			set { sourceType = value; }
		}

		public string SourceProjectId
		{
			get { return sourceProjectId; }
			set { sourceProjectId = value; }
		}

		public string BakMedicalSpec
		{
			get { return bakMedicalSpec; }
			set { bakMedicalSpec = value; }
		}

		public string MiddleStandRate
		{
			get { return middleStandRate; }
			set { middleStandRate = value; }
		}

		public string BigMiddleRate
		{
			get { return bigMiddleRate; }
			set { bigMiddleRate = value; }
		}

		public string BakMassAssignment
		{
			get { return bakMassAssignment; }
			set { bakMassAssignment = value; }
		}

		public string ReadyFlag
		{
			get { return readyFlag; }
			set { readyFlag = value; }
		}

		public string ReadyQty
		{
			get { return readyQty; }
			set { readyQty = value; }
		}

		public string DegreeFlag
		{
			get { return degreeFlag; }
			set { degreeFlag = value; }
		}

		public string EmergencyType
		{
			get { return emergencyType; }
			set { emergencyType = value; }
		}

		public string IsInfectShow
		{
			get { return isInfectShow; }
			set { isInfectShow = value; }
		}

		public string ReadyDate
		{
			get { return readyDate; }
			set { readyDate = value; }
		}

		public string ReceiveDate
		{
			get { return receiveDate; }
			set { receiveDate = value; }
		}

		public string LateFlag
		{
			get { return lateFlag; }
			set { lateFlag = value; }
		}

		public string DiscountBatchValue
		{
			get { return discountBatchValue; }
			set { discountBatchValue = value; }
		}

		public string DiscountPaymentValue
		{
			get { return discountPaymentValue; }
			set { discountPaymentValue = value; }
		}

		public string DiscountPayatonceValue
		{
			get { return discountPayatonceValue; }
			set { discountPayatonceValue = value; }
		}

		public string DiscountThirtydayValue
		{
			get { return discountThirtydayValue; }
			set { discountThirtydayValue = value; }
		}

        public string CheckBoxShow
        {
            get { return checkBoxShow; }
            set { checkBoxShow = value; }
        }        
    }

    //add start
    [Serializable]
    public class InputInfoModel
    {
        //使用药库标志，1 为使用，0 为未使用
        private string repositoryBz;
        public string RepositoryBz
        {
            get { return repositoryBz; }
            set { repositoryBz = value; }
        }

        //平台id
        private string platId;
        public string PlatId
        {
            get { return platId; }
            set { platId = value; }
        }

        //userOrgID
        private string userOrgId;
        public string UserOrgId
        {
            get { return userOrgId; }
            set { userOrgId = value; }
        }

        //userID
        private string userId;
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        //标志位
        private bool idx;
        public bool Idx
        {
            get { return idx; }
            set { idx = value; }
        }

        //订单ID
        private string orderId;
        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        //接受状态
        private bool received;
        public bool Received
        {
            get { return received; }
            set { received = value; }
        }

        //排序字段
        private string sortField;
        public string SortField
        {
            get { return sortField; }
            set { sortField = value; }
        }

        //排序方法
        private string sortMethod;
        public string SortMethod
        {
            get { return sortMethod; }
            set { sortMethod = value; }
        }

        //发票
        private string fillInvoice;
        public string FillInvoice
        {
            get { return fillInvoice; }
            set { fillInvoice = value; }
        }

    }

    [Serializable]
    public class OutputInfoModel
    {
        private string itemStateName;

        public string ItemStateName
        {
            get { return itemStateName; }
            set { itemStateName = value; }
        }

        private string itemState;

        public string ItemState
        {
            get { return itemState; }
            set { itemState = value; }
        }

        private string maxQty;

        public string MaxQty
        {
            get { return maxQty; }
            set { maxQty = value; }
        }
        private bool isCheck;
		public bool IsCheck
		{
			get { return isCheck; }
			set { isCheck = value; }
		}

        private string r_ID;
        public string R_ID
        {
            get { return r_ID; }
            set { r_ID = value; }
        }

        private string o_RECORD_ID;
        public string O_RECORD_ID
        {
            get { return o_RECORD_ID; }
            set { o_RECORD_ID = value; }
        }

        private string o_ORDER_ID;
        public string O_ORDER_ID
        {
            get { return o_ORDER_ID; }
            set { o_ORDER_ID = value; }
        }

        private string o_PLAT_ID;
        public string O_PLAT_ID
        {
            get { return o_PLAT_ID; }
            set { o_PLAT_ID = value; }
        }

        private string rowNum;
        public string RowNum
        {
            get { return rowNum; }
            set { rowNum = value; }
        }

        private string r_RECEIVE_DATE;
        public string R_RECEIVE_DATE
        {
            get { return r_RECEIVE_DATE; }
            set { r_RECEIVE_DATE = value; }
        }

        private string o_BAK_MEDICAL_NAME;
        public string O_BAK_MEDICAL_NAME
        {
            get { return o_BAK_MEDICAL_NAME; }
            set { o_BAK_MEDICAL_NAME = value; }
        }

        private string o_BAK_PRODUCT_NAME;
        public string O_BAK_PRODUCT_NAME
        {
            get { return o_BAK_PRODUCT_NAME; }
            set { o_BAK_PRODUCT_NAME = value; }
        }

        private string o_BAK_PRODUCT_SPEC;
        public string O_BAK_PRODUCT_SPEC
        {
            get { return o_BAK_PRODUCT_SPEC; }
            set { o_BAK_PRODUCT_SPEC = value; }
        }

        private string o_BAK_FACTORY_NAME;
        public string O_BAK_FACTORY_NAME
        {
            get { return o_BAK_FACTORY_NAME; }
            set { o_BAK_FACTORY_NAME = value; }
        }

        private string o_UNIT_PRICE;
        public string O_UNIT_PRICE
        {
            get { return o_UNIT_PRICE; }
            set { o_UNIT_PRICE = value; }
        }

        private string o_REQUEST_QTY;
        public string O_REQUEST_QTY
        {
            get { return o_REQUEST_QTY; }
            set { o_REQUEST_QTY = value; }
        }

        private string o_RECEIVE_QTY;
        public string O_RECEIVE_QTY
        {
            get { return o_RECEIVE_QTY; }
            set { o_RECEIVE_QTY = value; }
        }

        private string aPP_NUM;
        public string APP_NUM
        {
            get { return aPP_NUM; }
            set { aPP_NUM = value; }
        }

        private string lOT_NO;
        public string LOT_NO
        {
            get { return lOT_NO; }
            set { lOT_NO = value; }
        }

        private string rECEIVE_QTY;
        public string RECEIVE_QTY
        {
            get { return rECEIVE_QTY; }
            set { rECEIVE_QTY = value; }
        }

        private string buyer_Remark;
        public string Buyer_Remark
        {
            get { return buyer_Remark; }
            set { buyer_Remark = value; }
        }

        private string receiveFlag;
        public string ReceiveFlag
        {
            get { return receiveFlag; }
            set { receiveFlag = value; }
        }

        private string r_invoice_no;
        public string R_invoice_no
        {
            get { return r_invoice_no; }
            set { r_invoice_no = value; }
        }

        private string r_invoice_total;
        public string R_invoice_total
        {
            get { return r_invoice_total; }
            set { r_invoice_total = value; }
        }

        private string r_invoice_trade_price;
        public string R_invoice_trade_price
        {
            get { return r_invoice_trade_price; }
            set { r_invoice_trade_price = value; }
        }

        private string r_invoice_retail_price;
        public string R_invoice_retail_price
        {
            get { return r_invoice_retail_price; }
            set { r_invoice_retail_price = value; }
        }

        private string r_invoice_discount_rate;
        public string R_invoice_discount_rate
        {
            get { return r_invoice_discount_rate; }
            set { r_invoice_discount_rate = value; }
        }

        private string r_invoice_date;
        public string R_invoice_date
        {
            get { return r_invoice_date; }
            set { r_invoice_date = value; }
        }

        private string r_invoice_expire_date;
        public string R_invoice_expire_date
        {
            get { return r_invoice_expire_date; }
            set { r_invoice_expire_date = value; }
        }

        private string r_ready_remark;
        public string R_ready_remark
        {
            get { return r_ready_remark; }
            set { r_ready_remark = value; }
        }
        private string saler_id;

        public string Saler_id
        {
            get { return saler_id; }
            set { saler_id = value; }
        }
    }
    //add end
}
