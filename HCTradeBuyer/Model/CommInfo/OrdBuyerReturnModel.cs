using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 退货单模型
    /// </summary>
    [Serializable]
    public class OrdBuyerReturnModel
    {
        #region Fields

        /// <summary>
        /// 退货单ID
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
        /// 退货单编号
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 到货单ID
        /// </summary>
        private string receive_Id;
        public string Receive_Id
        {
            get { return receive_Id; }
            set { receive_Id = value; }
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
        /// 项目产品ID
        /// </summary>
        private string project_Product_Id;
        public string Project_Product_Id
        {
            get { return project_Product_Id; }
            set { project_Product_Id = value; }
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
        /// 买方名称
        /// </summary>
        private string buyer_Name;
        public string Buyer_Name
        {
            get { return buyer_Name; }
            set { buyer_Name = value; }
        }

        /// <summary>
        /// 买方名称简称
        /// </summary>
        private string buyer_Name_Abbr;
        public string Buyer_Name_Abbr
        {
            get { return buyer_Name_Abbr; }
            set { buyer_Name_Abbr = value; }
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
        /// 经销商名称
        /// </summary>
        private string saler_Name;
        public string Saler_Name
        {
            get { return saler_Name; }
            set { saler_Name = value; }
        }

        /// <summary>
        /// 经销商简称
        /// </summary>
        private string saler_Name_Abbr;
        public string Saler_Name_Abbr
        {
            get { return saler_Name_Abbr; }
            set { saler_Name_Abbr = value; }
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
        /// 配送商名称简称
        /// </summary>
        private string sender_Name_Abbr;
        public string Sender_Name_Abbr
        {
            get { return sender_Name_Abbr; }
            set { sender_Name_Abbr = value; }
        }

        /// <summary>
        /// 生产企业ID
        /// </summary>
        private string manufacture_Id;
        public string Manufacture_Id
        {
            get { return manufacture_Id; }
            set { manufacture_Id = value; }
        }

        /// <summary>
        /// 生产企业
        /// </summary>
        private string manufacture_Name;
        public string Manufacture_Name
        {
            get { return manufacture_Name; }
            set { manufacture_Name = value; }
        }

        /// <summary>
        /// 生产企业简称
        /// </summary>
        private string manufacture_Name_Abbr;
        public string Manufacture_Name_Abbr
        {
            get { return manufacture_Name_Abbr; }
            set { manufacture_Name_Abbr = value; }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        private string commerce_Name;
        public string Commerce_Name
        {
            get { return commerce_Name; }
            set { commerce_Name = value; }
        }

        /// <summary>
        /// 通用名称
        /// </summary>
        private string comm_Name;
        public string Comm_Name
        {
            get { return comm_Name; }
            set { comm_Name = value; }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        private string product_Name;
        public string Product_Name
        {
            get { return product_Name; }
            set { product_Name = value; }
        }

        /// <summary>
        /// 商品编码
        /// </summary>
        private string product_Code;
        public string Product_Code
        {
            get { return product_Code; }
            set { product_Code = value; }
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
        /// 品牌
        /// </summary>
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
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
        /// 规格
        /// </summary>
        private string spec;
        public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }


        /// <summary>
        /// 型号
        /// </summary>
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
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
        /// 退货价格
        /// </summary>
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 退货金额
        /// </summary>
        private decimal sum;
        public decimal Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        /// <summary>
        /// 基础计量单位
        /// </summary>
        private string base_Measure;
        public string Base_Measure
        {
            get { return base_Measure; }
            set { base_Measure = value; }
        }

        /// <summary>
        /// 基础单位规格
        /// </summary>
        private string base_Measure_Spec;
        public string Base_Measure_Spec
        {
            get { return base_Measure_Spec; }
            set { base_Measure_Spec = value; }
        }

        /// <summary>
        /// 基础单位包装材质
        /// </summary>
        private string base_Measure_Mater;
        public string Base_Measure_Mater
        {
            get { return base_Measure_Mater; }
            set { base_Measure_Mater = value; }
        }

        /// <summary>
        /// 配送计量单位
        /// </summary>
        private string send_Measure;
        public string Send_Measure
        {
            get { return send_Measure; }
            set { send_Measure = value; }
        }

        /// <summary>
        /// 配送转换率
        /// </summary>
        private string send_Measure_Ex;
        public string Send_Measure_Ex
        {
            get { return send_Measure_Ex; }
            set { send_Measure_Ex = value; }
        }

        /// <summary>
        /// 退货数量
        /// </summary>
        private string amount;
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
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
        
        /// <summary>
        /// 买方退货原因
        /// </summary>
        private string buyer_Descriptions;
        public string Buyer_Descriptions
        {
            get { return buyer_Descriptions; }
            set { buyer_Descriptions = value; }
        }

        /// <summary>
        /// 卖方回复
        /// </summary>
        private string saler_Descriptions;
        public string Saler_Descriptions
        {
            get { return saler_Descriptions; }
            set { saler_Descriptions = value; }
        }

        /// <summary>
        /// 卖方发货人ID
        /// </summary>
        private string send_Operator_Id;
        public string Send_Operator_Id
        {
            get { return send_Operator_Id; }
            set { send_Operator_Id = value; }
        }

        /// <summary>
        /// 卖方发货人
        /// </summary>
        private string send_Operator_Name;
        public string Send_Operator_Name
        {
            get { return send_Operator_Name; }
            set { send_Operator_Name = value; }
        }

        /// <summary>
        /// 卖方发货人制单时间
        /// </summary>
        private string send_Operate_Date;
        public string Send_Operate_Date
        {
            get { return send_Operate_Date; }
            set { send_Operate_Date = value; }
        }

        /// <summary>
        /// 买方收货人ID
        /// </summary>
        private string instore_Operator_Id;
        public string Instore_Operator_Id
        {
            get { return instore_Operator_Id; }
            set { instore_Operator_Id = value; }
        }

        /// <summary>
        /// 买方发货人
        /// </summary>
        private string instore_Operator_Name;
        public string Instore_Operator_Name
        {
            get { return instore_Operator_Name; }
            set { instore_Operator_Name = value; }
        }

        /// <summary>
        /// 买方发货人制单时间
        /// </summary>
        private string instore_Operate_Date;
        public string Instore_Operate_Date
        {
            get { return instore_Operate_Date; }
            set { instore_Operate_Date = value; }
        }


        #endregion

    }
}
