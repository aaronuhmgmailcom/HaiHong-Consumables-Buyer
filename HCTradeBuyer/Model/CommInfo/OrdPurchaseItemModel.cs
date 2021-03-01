using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 采购单明细模型
    /// </summary>
    [Serializable]
    public class OrdPurchaseItemModel
    {
        #region Fields

        /// <summary>
        /// 采购单明细ID
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
        /// 采购单ID
        /// </summary>
        private string purchase_Id;
        public string Purchase_Id
        {
            get { return purchase_Id; }
            set { purchase_Id = value; }
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
        /// 买方ID
        /// </summary>
        private string buyer_Id;
        public string Buyer_Id
        {
            get { return buyer_Id; }
            set { buyer_Id = value; }
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
        /// 通用名
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
        /// 商品编码
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
        /// 货号
        /// </summary>
        private string goodsNo;
        public string GoodsNo
        {
            get { return goodsNo; }
            set { goodsNo = value; }
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
        /// 零售价格(单价)
        /// </summary>
        private string retail_Price;
        public string Retail_Price
        {
            get { return retail_Price; }
            set { retail_Price = value; }
        }

        /// <summary>
        /// 交易价格(单价)
        /// </summary>
        private string trade_Price;
        public string Trade_Price
        {
            get { return trade_Price; }
            set { trade_Price = value; }
        }

        /// <summary>
        /// 采购数量
        /// </summary>
        private string amount;
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// 采购单金额
        /// </summary>
        private string sum;
        public string Sum
        {
            get { return sum; }
            set { sum = value; }
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
        /// 采购完成金额
        /// </summary>
        private string over_Sum;
        public string Over_Sum
        {
            get { return over_Sum; }
            set { over_Sum = value; }
        }

        /// <summary>
        /// 是否急需
        /// </summary>
        private string is_Quicksend;
        public string Is_Quicksend
        {
            get { return is_Quicksend; }
            set { is_Quicksend = value; }
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

        #endregion

    }
}
