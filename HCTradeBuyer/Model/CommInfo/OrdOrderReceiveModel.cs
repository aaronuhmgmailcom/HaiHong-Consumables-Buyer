using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 到货单模型
    /// </summary>
    [Serializable]
    public class OrdOrderReceiveModel
    {
        /// <summary>
        /// 到货单ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 项目ID
        /// </summary>
        private string project_Id;
        public string Project_Id
        {
            get { return project_Id; }
            set { project_Id = value; }
        }

        /// <summary>
        /// 项目产品ID
        /// </summary>
        private string project_Prod_Id;
        public string Project_Prod_Id
        {
            get { return project_Prod_Id; }
            set { project_Prod_Id = value; }
        }

        /// <summary>
        /// 中心产品ID
        /// </summary>
        private string data_Product_Id;
        public string Data_Product_Id
        {
            get { return data_Product_Id; }
            set { data_Product_Id = value; }
        }

        /// <summary>
        /// 到货类型
        /// </summary>
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 到货单编码
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 订单ID
        /// </summary>
        private string order_Id;
        public string Order_Id
        {
            get { return order_Id; }
            set { order_Id = value; }
        }

        /// <summary>
        /// 订单明细ID
        /// </summary>
        private string order_Item_Id;
        public string Order_Item_Id
        {
            get { return order_Item_Id; }
            set { order_Item_Id = value; }
        }

        /// <summary>
        /// 发票ID
        /// </summary>
        private string invoice_Id;
        public string Invoice_Id
        {
            get { return invoice_Id; }
            set { invoice_Id = value; }
        }

        /// <summary>
        /// 货号
        /// </summary>
        private string goods_No;
        public string Goods_No
        {
            get { return goods_No; }
            set { goods_No = value; }
        }

        /// <summary>
        /// 条码
        /// </summary>
        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        /// <summary>
        /// 商品的生产批次
        /// </summary>
        private string pbno;
        public string Pbno
        {
            get { return pbno; }
            set { pbno = value; }
        }

        /// <summary>
        /// 发货商品批次
        /// </summary>
        private string send_Batch_No;
        public string Send_Batch_No
        {
            get { return send_Batch_No; }
            set { send_Batch_No = value; }
        }

        /// <summary>
        /// 入库商品批次
        /// </summary>
        private string instore_Batch_No;
        public string Instore_Batch_No
        {
            get { return instore_Batch_No; }
            set { instore_Batch_No = value; }
        }

        /// <summary>
        /// 到货地址
        /// </summary>
        private string arrival_Address;
        public string Arrival_Address
        {
            get { return arrival_Address; }
            set { arrival_Address = value; }
        }

        /// <summary>
        /// 到货时间
        /// </summary>
        private string arrive_Date;
        public string Arrive_Date
        {
            get { return arrive_Date; }
            set { arrive_Date = value; }
        }

        /// <summary>
        /// 到货价格(单价)
        /// </summary>
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 实际到货数量
        /// </summary>
        private string fact_Amount;
        public string Fact_Amount
        {
            get { return fact_Amount; }
            set { fact_Amount = value; }
        }

        /// <summary>
        /// 实际到货金额
        /// </summary>
        private decimal fact_Sum;
        public decimal Fact_Sum
        {
            get { return fact_Sum; }
            set { fact_Sum = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        private string descriptions;
        public string Descriptions
        {
            get { return descriptions; }
            set { descriptions = value; }
        }

    }
}
