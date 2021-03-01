using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 发货单明细记录模型
    /// </summary>
    [Serializable]
    public class OrdInvoiceFromItemModel
    {
        #region Fields

        /// <summary>
        /// 发货单明细ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
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
        /// 项目ID
        /// </summary>
        private string project_Id;
        public string Project_Id
        {
            get { return project_Id; }
            set { project_Id = value; }
        }

        /// <summary>
        /// 发货单id
        /// </summary>
        private string invoice_From_Id;
        public string Invoice_From_Id
        {
            get { return invoice_From_Id; }
            set { invoice_From_Id = value; }
        }

        /// <summary>
        /// 采购完成数量
        /// </summary>
        private string over_Amount;
        public string Over_Amount
        {
            get { return over_Amount; }
            set { over_Amount = value; }
        }

        /// <summary>
        /// 单价
        /// </summary>
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 采购完成金额
        /// </summary>
        private decimal over_Sum;
        public decimal Over_Sum
        {
            get { return over_Sum; }
            set { over_Sum = value; }
        }

        /// <summary>
        /// 发货单明细状态
        /// </summary>
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// 买方描述
        /// </summary>
        private string buyer_Descriptions;
        public string Buyer_Descriptions
        {
            get { return buyer_Descriptions; }
            set { buyer_Descriptions = value; }
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
        
        #endregion

    }
}
