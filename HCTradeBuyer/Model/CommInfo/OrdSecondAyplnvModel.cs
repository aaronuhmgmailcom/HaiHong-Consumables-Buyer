using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 二级库存记录对象
    /// </summary>
    [Serializable]
	public class OrdSecondAyplnvModel
	{
        #region Fields

        /// <summary>
        /// 二级库存ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 备货单明细ID
        /// </summary>
        private string stock_Item_Id;
        public string Stock_Item_Id
        {
            get { return stock_Item_Id; }
            set { stock_Item_Id = value; }
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
        /// 中心产品ID
        /// </summary>
        private string data_Product_Id;
        public string Data_Product_Id
        {
            get { return data_Product_Id; }
            set { data_Product_Id = value; }
        }

        /// <summary>
        /// 买方ID
        /// </summary>
        private string buyer_Id;
        public string Buyer_Id
        {
            get { return buyer_Id; }
            set { buyer_Id = value; }
        }

        /// <summary>
        /// 经销商ID
        /// </summary>
        private string saler_Id;
        public string Saler_Id
        {
            get { return saler_Id; }
            set { saler_Id = value; }
        }

        /// <summary>
        /// 配送商ID
        /// </summary>
        private string sender_Id;
        public string Sender_Id
        {
            get { return sender_Id; }
            set { sender_Id = value; }
        }

        /// <summary>
        /// 配送商名称
        /// </summary>
        private string sender_Name;
        public string Sender_Name
        {
            get { return sender_Name; }
            set { sender_Name = value; }
        }

        /// <summary>
        /// 项目产品ID
        /// </summary>
        private string project_Product_Id;
        public string Project_Product_Id
        {
            get { return project_Product_Id; }
            set { project_Product_Id = value; }
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
        /// 规格ID
        /// </summary>
        private string spec_Id;
        public string Spec_Id
        {
            get { return spec_Id; }
            set { spec_Id = value; }
        }

        /// <summary>
        /// 型号ID
        /// </summary>
        private string model_Id;
        public string Model_Id
        {
            get { return model_Id; }
            set { model_Id = value; }
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
        /// 单价
        /// </summary>
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 批次
        /// </summary>
        private string batch_No;
        public string Batch_No
        {
            get { return batch_No; }
            set { batch_No = value; }
        }

        /// <summary>
        /// 有效期
        /// </summary>
        private string valid_Date;
        public string Valid_Date
        {
            get { return valid_Date; }
            set { valid_Date = value; }
        }

        /// <summary>
        /// 库存数量
        /// </summary>
        private string num;
        public string Num
        {
            get { return num; }
            set { num = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }


        #endregion

    }
}
