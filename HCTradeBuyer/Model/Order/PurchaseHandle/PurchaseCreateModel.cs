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
        //采购单编号
        private string purchaseCode;
        //创建人
        private string createUsername;
        //创建时间
        private string createDate;
        //计划采购金额
        private string requestTotal;
        //结束时间
        private string endDate;
        //联系电话
        private string linkTel;
        //采购单状态
        private string purchaseState;
        //采购单ID
        private string purchaseId;
        //审核人名称
        private string approveUsername;
        //审核人ID
        private string approveUserid;
        //审核日期
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
        //采购单编号
        public string purchaseCode;
        //创建人
        public string createUsername;
        //创建时间
        public string createDate;
        //计划采购金额
        public string requestTotal;
        //结束时间
        public string endDate;
        //联系电话
        public string linkTel;
        //采购单状态
        public string purchaseState;
        //审核人名称
        public string approveUsername;
        //审核人ID
        public string approveUserid;
        //审核日期
        public DateTime approveDate;

    }
}
