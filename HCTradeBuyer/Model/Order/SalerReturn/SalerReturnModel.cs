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

        //经销/配送备注
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

        //状态
        private string returnState;
        public string ReturnState
        {
            get { return returnState; }
            set { returnState = value; }
        }

        //开始时间
        private string startDate;
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        //结束时间
        private string endDate;
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        //查询类别(1--品名,2--品名拼音,3--品名五笔,4--医院名称)
        private string strType;
        public string StrType
        {
            get { return strType; }
            set { strType = value; }
        }

        //查询关键字
        private string strKeyValue;
        public string StrKeyValue
        {
            get { return strKeyValue; }
            set { strKeyValue = value; }
        }

        //到货表ＩＤ
        private string strReceiveID;
        public string StrReceiveID
        {
            get { return strReceiveID; }
            set { strReceiveID = value; }
        }

        //剩余到货量
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
        //序号
        private string serialNm;
        //表名
        private string tableType;
        //ID
        private string returnId;
        //药品名
        private string commonName;
        //商品名
        private string productName;
        //剂型
        private string mode;
        //质量层次
        private string zlcc;
        //规格包装
        private string ggbz;                
        //退货机构
        private string returner;
        //批号
        private string lotNo;
        //药库
        private string warehouseName;
        //退货数
        private string requestQty;
        //退货原因
        private string returnReason;
        //退货时间
        private string createTime;
        //确认时间
        private string confirmTime;
        //附注
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
