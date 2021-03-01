using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 备货单明细模型
    /// </summary>
    [Serializable]
    public class OrdStockUpItemModel
    {
        #region Fields

        /// <summary>
        /// 备货单明细ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 备货单ID
        /// </summary>
        private string stock_Id;
        public string Stock_Id
        {
            get { return stock_Id; }
            set { stock_Id = value; }
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
        private string common_Name;
        public string Common_Name
        {
            get { return common_Name; }
            set { common_Name = value; }
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
        /// 生产企业名称
        /// </summary>
        private string manufacture_Name;
        public string Manufacture_Name
        {
            get { return manufacture_Name; }
            set { manufacture_Name = value; }
        }

        /// <summary>
        /// 生产企业名称简称
        /// </summary>
        private string manufacture_Name_Abbr;
        public string Manufacture_Name_Abbr
        {
            get { return manufacture_Name_Abbr; }
            set { manufacture_Name_Abbr = value; }
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
        /// 条码
        /// </summary>
        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        /// <summary>
        /// 条码 用作验证对比
        /// </summary>
        private string barcode_Back;
        public string Barcode_Back
        {
            get { return barcode_Back; }
            set { barcode_Back = value; }
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
        /// 数量
        /// </summary>
        private string num;
        public string Num
        {
            get { return num; }
            set { num = value; }
        }

        /// <summary>
        /// 有效期至
        /// </summary>
        private string valid_Date;
        public string Valid_Date
        {
            get { return valid_Date; }
            set { valid_Date = value; }
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
        /// 交易价格(单价)
        /// </summary>
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
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
        /// 计量单位
        /// </summary>
        private string base_Measure;
        public string Base_Measure
        {
            get { return base_Measure; }
            set { base_Measure = value; }
        }

        /// <summary>
        /// 性能与组成
        /// </summary>
        private string perFormance;
        public string PerFormance
        {
            get { return perFormance; }
            set { perFormance = value; }
        }

        /// <summary>
        /// 注册证号
        /// </summary>
        private string reg_No;
        public string Reg_No
        {
            get { return reg_No; }
            set { reg_No = value; }
        }

        /// <summary>
        /// 注册证有效截止日期
        /// </summary>
        private string reg_Valid_Date;
        public string Reg_Valid_Date
        {
            get { return reg_Valid_Date; }
            set { reg_Valid_Date = value; }
        }

        /// <summary>
        /// 经销企业名称
        /// </summary>
        private string saler_Name;
        public string Saler_Name
        {
            get { return saler_Name; }
            set { saler_Name = value; }
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
        /// 品牌
        /// </summary>
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        /// <summary>
        /// 产品ID
        /// </summary>
        private string data_Product_Id;
        public string Data_Product_Id
        {
            get { return data_Product_Id; }
            set { data_Product_Id = value; }
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

        #endregion
    }
}
