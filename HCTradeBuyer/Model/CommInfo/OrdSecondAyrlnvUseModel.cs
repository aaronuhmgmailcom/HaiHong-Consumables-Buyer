using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 二级库使用表记录对象
    /// </summary>
    [Serializable]
    public class OrdSecondAyrlnvUseModel
    {
        #region Fields

        /// <summary>
        /// 二级库存使用ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 二级库ID
        /// </summary>
        private string secondId;
        public string SecondId
        {
            get { return secondId; }
            set { secondId = value; }
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
        /// 项目产品ID
        /// </summary>
        private string project_Product_Id;
        public string Project_Product_Id
        {
            get { return project_Product_Id; }
            set { project_Product_Id = value; }
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
        private decimal fact_Amount;
        public decimal Fact_Amount
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
        /// 状态
        /// </summary>
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
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

        /// <summary>
        /// 通用名称
        /// </summary>
        private string common_Name;
        public string Common_Name
        {
            get { return common_Name; }
            set { common_Name = value; }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        private string product_Name;
        public string Product_Name
        {
            get { return product_Name; }
            set { product_Name = value; }
        }
                
        /// <summary>
        /// 商品编号
        /// </summary>
        private string product_Code;
        public string Product_Code
        {
            get { return product_Code; }
            set { product_Code = value; }
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
        /// 品牌
        /// </summary>
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
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
        /// 生产企业ID
        /// </summary>
        private string manu_Id;
        public string Manu_Id
        {
            get { return manu_Id; }
            set { manu_Id = value; }
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
        /// 生产企业名称
        /// </summary>
        private string manu_Name;
        public string Manu_Name
        {
            get { return manu_Name; }
            set { manu_Name = value; }
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
        /// 配送商名称
        /// </summary>
        private string sender_Name;
        public string Sender_Name
        {
            get { return sender_Name; }
            set { sender_Name = value; }
        }

        /// <summary>
        /// 生产企业简称
        /// </summary>
        private string manu_Name_Abbr;
        public string Manu_Name_Abbr
        {
            get { return manu_Name_Abbr; }
            set { manu_Name_Abbr = value; }
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
        /// 配送商简称
        /// </summary>
        private string sender_Name_Abbr;
        public string Sender_Name_Abbr
        {
            get { return sender_Name_Abbr; }
            set { sender_Name_Abbr = value; }
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
        /// 买方简称
        /// </summary>
        private string buyer_Name_Abbr;
        public string Buyer_Name_Abbr
        {
            get { return buyer_Name_Abbr; }
            set { buyer_Name_Abbr = value; }
        }

        /// <summary>
        /// 采购单ID
        /// </summary>
        private string purchase_Id;
        public string Purchase_Id
        {
            get { return purchase_Id; }
            set { purchase_Id = value; }
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
        private string base_Measure_Mate;
        public string Base_Measure_Mate
        {
            get { return base_Measure_Mate; }
            set { base_Measure_Mate = value; }
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
        /// 订单备货ID
        /// </summary>
        private string stockup_Id;
        public string Stockup_Id
        {
            get { return stockup_Id; }
            set { stockup_Id = value; }
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
        /// 到货单编号
        /// </summary>
        private string receive_Code;
        public string Receive_Code
        {
            get { return receive_Code; }
            set { receive_Code = value; }
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
        /// 到货类型
        /// </summary>
        private string receive_Type;
        public string Receive_Type
        {
            get { return receive_Type; }
            set { receive_Type = value; }
        }

        /// <summary>
        /// 库房ID
        /// </summary>
        private string store_Room_Id;
        public string Store_Room_Id
        {
            get { return store_Room_Id; }
            set { store_Room_Id = value; }
        }

        /// <summary>
        /// 库房名称
        /// </summary>
        private string store_Room_Name;
        public string Store_Room_Name
        {
            get { return store_Room_Name; }
            set { store_Room_Name = value; }
        }

        /// <summary>
        /// 结束 SENDER_ID
        /// </summary>
        private bool over_Sender_Flag;
        public bool Over_Sender_Flag
        {
            get { return over_Sender_Flag; }
            set { over_Sender_Flag = value; }
        }

        /// <summary>
        /// 开始 SENDER_ID
        /// </summary>
        private bool start_Sender_Flag;
        public bool Start_Sender_Flag
        {
            get { return start_Sender_Flag; }
            set { start_Sender_Flag = value; }
        }

        /// <summary>
        /// 库存数量
        /// </summary>
        private decimal stock_Num;
        public decimal Stock_Num
        {
            get { return stock_Num; }
            set { stock_Num = value; }
        }

        /// <summary>
        /// 采购单明细ID
        /// </summary>
        private string purchase_Item_Id;
        public string Purchase_Item_Id
        {
            get { return purchase_Item_Id; }
            set { purchase_Item_Id = value; }
        }

        /// <summary>
        /// 源订单明细ID
        /// </summary>
        private string original_Item_Id;
        public string Original_Item_Id
        {
            get { return original_Item_Id; }
            set { original_Item_Id = value; }
        }

        #endregion


    }
}
