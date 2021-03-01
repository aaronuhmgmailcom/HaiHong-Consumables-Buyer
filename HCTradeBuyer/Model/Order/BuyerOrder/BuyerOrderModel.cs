using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.BuyerOrder
{
    [Serializable]
    public class BuyerOrderModel
    {
        // 开始页索引
        private int start;

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        // 结束页索引
        private int end;

        public int End
        {
            get { return end; }
            set { end = value; }
        }

        // 记录总数
        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        // 总行数
        private int totalRows;

        public int TotalRows
        {
            get { return totalRows; }
            set { totalRows = value; }
        }
        // 买方ID
        private String orgId;

        public String OrgId
        {
            get { return orgId; }
            set { orgId = value; }
        }

        // 卖方ｉｄ
        private String salerId;

        public String SalerId
        {
            get { return salerId; }
            set { salerId = value; }
        }


        // 登录用户区域ID
        private String areaId;

        public String AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }


        //区分按订单到货和按企业到货标志
        private String flag;

        public String Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        //品名
        private String productName;

        public String ProductName
        {
            get { return productName; }
            set { productName = value; }
        }


        // 订单ｉｄ
        private String orderId;

        public String OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        // 备注
        private String remark;

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        // 备货表ｉｄ
        private String stockupId;

        public String StockupId
        {
            get { return stockupId; }
            set { stockupId = value; }
        }

        // 订单明细id
        private String orderRecordId;

        public String OrderRecordId
        {
            get { return orderRecordId; }
            set { orderRecordId = value; }
        }

        // project id
        private String projectId;

        public String ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }


        // 用户ｉｄ
        private String userId;

        public String UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        // 用户highｉｄ
        private int highId;

        public int HighId
        {
            get { return highId; }
            set { highId = value; }
        }


        // 用户名
        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        // 订单明细状态
        private String itemState;

        public String ItemState
        {
            get { return itemState; }
            set { itemState = value; }
        }


        // 订单状态
        private String orderState;

        public String OrderState
        {
            get { return orderState; }
            set { orderState = value; }
        }

        private List<OrderItemModel> list = new List<OrderItemModel>();

        public List<OrderItemModel> List
        {
            get { return list; }
            set { list = value; }
        }


        //订单类型
        private String orderType;

        public String OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        //订购量
        private String requestQty;

        public String RequestQty
        {
            get { return requestQty; }
            set { requestQty = value; }
        }


        // 发送开始时间
        private String startDate;

        public String StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        // 发送结束时间
        private String endDate;

        public String EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        // 查询字段
        private String searchField;

        public String SearchField
        {
            get { return searchField; }
            set { searchField = value; }
        }
        //查询关键字
        private String searchKey;

        public String SearchKey
        {
            get { return searchKey; }
            set { searchKey = value; }
        }
        // 创建人
        private String creater;

        public String Creater
        {
            get { return creater; }
            set { creater = value; }
        }



    }

    [Serializable]
    public class OrderModel
    {
        private String orderCode;
        public String OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }

        private String createUserName;
        public String CreateUserName
        {
            get { return createUserName; }
            set { createUserName = value; }
        }

        private String createDate;
        public String CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        private String orderState;
        public String OrderState
        {
            get { return orderState; }
            set { orderState = value; }
        }

        private String quicksendLevel;
        public String QuicksendLevel
        {
            get { return quicksendLevel; }
            set { quicksendLevel = value; }
        }

        private String salerName;
        public String SalerName
        {
            get { return salerName; }
            set { salerName = value; }
        }

        private String senderName;
        public String SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        private String total_sum;
        public String Total_sum
        {
            get { return total_sum; }
            set { total_sum = value; }
        }

        private String over_sum;
        public String Over_sum
        {
            get { return over_sum; }
            set { over_sum = value; }
        }

        private String modifyUserName;
        public String ModifyUserName
        {
            get { return modifyUserName; }
            set { modifyUserName = value; }
        }

        private String modifyDate;
        public String ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }

        private String buyerRemark;
        public String BuyerRemark
        {
            get { return buyerRemark; }
            set { buyerRemark = value; }
        }

        private String salerRemark;
        public String SalerRemark
        {
            get { return salerRemark; }
            set { salerRemark = value; }
        }

        private String salerApproverName;
        public String SalerApproverName
        {
            get { return salerApproverName; }
            set { salerApproverName = value; }
        }

        private String salerApproveDate;
        public String SalerApproveDate
        {
            get { return salerApproveDate; }
            set { salerApproveDate = value; }
        }

        private String id;
        public String Id
        {
            get { return id; }
            set { id = value; }
        }
    }

    [Serializable]
    public class OrderItemModel
    {
        // 备货id
        private String stockupId;

        public String StockupId
        {
            get { return stockupId; }
            set { stockupId = value; }
        }

        // 到货id
        private Int64 receiveId;

        public Int64 ReceiveId
        {
            get { return receiveId; }
            set { receiveId = value; }
        }

        // 批号
        private String lotNo;

        public String LotNo
        {
            get { return lotNo; }
            set { lotNo = value; }
        }

        // 确认到货量
        private String receiveQty;

        public String ReceiveQty
        {
            get { return receiveQty; }
            set { receiveQty = value; }
        }

        // 订购量
        private String requestQty;

        public String RequestQty
        {
            get { return requestQty; }
            set { requestQty = value; }
        }

        // 产品ｉｄ
        private String productId;

        public String ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        // 订单ｉｄ
        private String orderId;

        public String OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        // 发票号
        private String invoiceNo;

        public String InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        //发票金额
        private String amount;

        public String Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        // 批发价
        private String tradePrice;

        public String TradePrice
        {
            get { return tradePrice; }
            set { tradePrice = value; }
        }

        // 零售价
        private String retailPrice;

        public String RetailPrice
        {
            get { return retailPrice; }
            set { retailPrice = value; }
        }

        // 扣率
        private String discount;

        public String Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        // 开票日期
        private String invoiceDate;

        public String InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }

        // 有效期
        private String invoiceExpireDate;

        public String InvoiceExpireDate
        {
            get { return invoiceExpireDate; }
            set { invoiceExpireDate = value; }
        }

        // 备注
        private String receiveRemark;

        public String ReceiveRemark
        {
            get { return receiveRemark; }
            set { receiveRemark = value; }
        }

        // 仓库ID
        private String repositoryId;

        public String RepositoryId
        {
            get { return repositoryId; }
            set { repositoryId = value; }
        }

        private String project_id;

        public String Project_id
        {
            get { return project_id; }
            set { project_id = value; }
        }


        private String project_product_id;
        public String Project_product_id
        {
            get { return project_product_id; }
            set { project_product_id = value; }
        }

        private String pbno;
        public String Pbno
        {
            get { return pbno; }
            set { pbno = value; }
        }

        private String send_batch_no;
        public String Send_batch_no
        {
            get { return send_batch_no; }
            set { send_batch_no = value; }
        }

        private String store_room_id;
        public String Store_room_id
        {
            get { return store_room_id; }
            set { store_room_id = value; }
        }

        private String store_room_name;
        public String Store_room_name
        {
            get { return store_room_name; }
            set { store_room_name = value; }
        }

        private String order_item_id;
        public String Order_item_id
        {
            get { return order_item_id; }
            set { order_item_id = value; }
        }

        private String buyerId;
        public String BuyerId
        {
            get { return buyerId; }
            set { buyerId = value; }
        }

        private String buyerName;
        public String BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }
              
        private String buyerNameAbbr;
        public String BuyerNameAbbr
        {
            get { return buyerNameAbbr; }
            set { buyerNameAbbr = value; }
        }   

        private String salerId;
        public String SalerId
        {
            get { return salerId; }
            set { salerId = value; }
        }   

        private String salerName;
        public String SalerName
        {
            get { return salerName; }
            set { salerName = value; }
        }           
            
        private String salerNameAbbr;
        public String SalerNameAbbr
        {
            get { return salerNameAbbr; }
            set { salerNameAbbr = value; }
        }  
        
        private String senderId;
        public String SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }    
            
        private String senderName;
        public String SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }   
        
        private String senderNameAbbr;
        public String SenderNameAbbr
        {
            get { return senderNameAbbr; }
            set { senderNameAbbr = value; }
        }  

        private String manuId;
        public String ManuId
        {
            get { return manuId; }
            set { manuId = value; }
        }      
                
        private String manuName;
        public String ManuName
        {
            get { return manuName; }
            set { manuName = value; }
        }

        private String manuNameAbbr;
        public String ManuNameAbbr
        {
            get { return manuNameAbbr; }
            set { manuNameAbbr = value; }
        }      

        private String productName;
        public String ProductName
        {
            get { return productName; }
            set { productName = value; }
        }   

        private String productCode;
        public String ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }   

        private String spec_id;
        public String Spec_id
        {
            get { return spec_id; }
            set { spec_id = value; }
        }   
                        
        private String model_id;
        public String Model_id
        {
            get { return model_id; }
            set { model_id = value; }
        }   
    
        private String spec;
        public String Spec
        {
            get { return spec; }
            set { spec = value; }
        }   

        private String model;
        public String Model
        {
            get { return model; }
            set { model = value; }
        }   

        private String commonName;
        public String CommonName
        {
            get { return commonName; }
            set { commonName = value; }
        }   

        private String brand;
        public String Brand
        {
            get { return brand; }
            set { brand = value; }
        }   

        private String baseMeasureSpec;
        public String BaseMeasureSpec
        {
            get { return baseMeasureSpec; }
            set { baseMeasureSpec = value; }
        }   
    
        private String baseMeasureMater;
        public String BaseMeasureMater
        {
            get { return baseMeasureMater; }
            set { baseMeasureMater = value; }
        }   

        private String baseMeasure;
        public String BaseMeasure
        {
            get { return baseMeasure; }
            set { baseMeasure = value; }
        }

        private String send_measure_ex;
        public String Send_measure_ex
        {
            get { return send_measure_ex; }
            set { send_measure_ex = value; }
        }

        private String send_measure;
        public String Send_measure
        {
            get { return send_measure; }
            set { send_measure = value; }
        }
     

    }
}
