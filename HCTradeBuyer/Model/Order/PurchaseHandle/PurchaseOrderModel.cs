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
        //采购单表ID
        private string purchaseId="0";
        //采购单表Code
        private string purchaseCode = "0";
        //订单序号
        private string orderId="0";
        //订单编号
        private string orderCode="0";
        //状态
        private string orderState="0";
        //订单紧急程度
        private string degreeFlag;
        //买方ID
        private string buyerOrgid="0";
        //仓库ID
        private string repositoryId;
        //送货地址
        private string repositoryAddr;
        //订单金额
        private decimal requestTotal=0;
        //医院名称
        private string bakBuyerName;
        //医院简称
        private string bakBuyerEasy;
        //医院拼音简称
        private string bakBuyerFast;
        //医院五笔简称
        private string bakBuyerWubi;
        //联系电话
        private string buyerLinkTel;
        //配送ID
        private string senderId="0";
        //配送名称
       private string senderName;
        //配送简称
       private string senderEasy;
        //配送拼音简称
        private string salerFast;
        // 配送确认时间
        private DateTime  salerapproverdate;
        //卖方五笔简称
        private string salerWubi;
        //创建人名称
        private string createUsername;
        //创建用户ID
        private string createUserid="0";
        //创建日期
        private DateTime createDate=Convert.ToDateTime(DateTime.Now);
        //修改人ID
        private string modifyUserid;
        //修改日期
        private DateTime modifyDate;
        //卖方描述
        private string salerdescriptions;
        //买方描述
        private string buyerdescriptions;
        //类型
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
        //采购单表ID
        public string purchaseId;
        //采购单表Code
        public string purchaseCode;
        //卖方描述
        public string salerdescriptions;
        //买方描述
        public string buyerdescriptions;
        //类型
        public string type;
        //订单序号
        public string orderId;
        //订单编号
        public string orderCode;
        //状态
        public string orderState;
        //订单紧急程度
        public string degreeFlag;
        //买方ID
        public string buyerOrgid;
        //仓库ID
        public string repositoryId;
        //送货地址
        public string repositoryAddr;
        //订单金额
        public decimal requestTotal;
        //医院名称
        public string bakBuyerName;
        //医院简称
        public string bakBuyerEasy;
        //医院拼音简称
        public string bakBuyerFast;
        //医院五笔简称
        public string bakBuyerWubi;
        //联系电话
        public string buyerLinkTel;
        //配送ID
        public string senderId;
        //配送名称
        public string senderName;
        //配送简称
        public string senderEasy;
        //卖方拼音简称
        public string salerFast;
        //卖方五笔简称
        public string salerWubi;
        //创建人名称
        public string createUsername;
        //创建用户ID
        public string createUserid;
        //创建日期
        public DateTime createDate;
        //修改人ID
        public string modifyUserid;
        //修改日期
        public DateTime modifyDate;
        // 卖方确认时间
        public DateTime salerapproverdate;

    }
}
