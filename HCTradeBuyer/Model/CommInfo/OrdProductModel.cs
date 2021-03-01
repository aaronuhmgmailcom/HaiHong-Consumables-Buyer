using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 项目产品模型
    /// </summary>
    [Serializable]
    public class OrdProductModel
    {
        #region Fields

        /// <summary>
        /// 项目产品ID
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
        /// 项目名称
        /// </summary>
        private string project_Name;
        public string Project_Name
        {
            get { return project_Name; }
            set { project_Name = value; }
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
        /// 合同产品ID
        /// </summary>
        private string cont_Product_Id;
        public string Cont_Product_Id
        {
            get { return cont_Product_Id; }
            set { cont_Product_Id = value; }
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
        /// 项目类型
        /// </summary>
        private string project_Type;
        public string Project_Type
        {
            get { return project_Type; }
            set { project_Type = value; }
        }

        /// <summary>
        /// 商品名
        /// </summary>
        private string commerce_Name;
        public string Commerce_Name
        {
            get { return commerce_Name; }
            set { commerce_Name = value; }
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
        /// 产品名称
        /// </summary>
        private string product_Name;
        public string Product_Name
        {
            get { return product_Name; }
            set { product_Name = value; }
        }

        /// <summary>
        /// 拼音简码
        /// </summary>
        private string abbr_py;
        public string Abbr_py
        {
            get { return abbr_py; }
            set { abbr_py = value; }
        }

        /// <summary>
        /// 五笔简码
        /// </summary>
        private string abbr_wb;
        public string Abbr_wb
        {
            get { return abbr_wb; }
            set { abbr_wb = value; }
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
        /// 配送单位
        /// </summary>
        private string measure;
        public string Measure
        {
            get { return measure; }
            set { measure = value; }
        }

        /// <summary>
        /// 配送转换率
        /// </summary>
        private string defaultMeasureEx;
        public string DefaultMeasureEx
        {
            get { return defaultMeasureEx; }
            set { defaultMeasureEx = value; }
        }

        /// <summary>
        /// 单价
        /// </summary>
        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 最高限价
        /// </summary>
        private string max_Price;
        public string Max_Price
        {
            get { return max_Price; }
            set { max_Price = value; }
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
        /// 商品编码
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 经销企业
        /// </summary>
        private string salerName;
        public string SalerName
        {
            get { return salerName; }
            set { salerName = value; }
        }

        /// <summary>
        /// 经销企业简称
        /// </summary>
        private string salerNameAbbr;
        public string SalerNameAbbr
        {
            get { return salerNameAbbr; }
            set { salerNameAbbr = value; }
        }

        /// <summary>
        /// 生产企业
        /// </summary>
        private string manuName;
        public string ManuName
        {
            get { return manuName; }
            set { manuName = value; }
        }

        /// <summary>
        /// 生产企业简称
        /// </summary>
        private string manuName_Abbr;
        public string ManuName_Abbr
        {
            get { return manuName_Abbr; }
            set { manuName_Abbr = value; }
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
        /// 注册证有效期截止日期
        /// </summary>
        private string reg_Valid_Date;
        public string Reg_Valid_Date
        {
            get { return reg_Valid_Date; }
            set { reg_Valid_Date = value; }
        }

        /// <summary>
        /// 性能与组成
        /// </summary>
        private string performance;
        public string Performance
        {
            get { return performance; }
            set { performance = value; }
        }

        /// <summary>
        /// 产品分类名称
        /// </summary>
        private string class_Name;
        public string Class_Name
        {
            get { return class_Name; }
            set { class_Name = value; }
        }

        /// <summary>
        /// 器械编码
        /// </summary>
        private string instru_Code;
        public string Instru_Code
        {
            get { return instru_Code; }
            set { instru_Code = value; }
        }

        /// <summary>
        /// 器械名称
        /// </summary>
        private string instru_Name;
        public string Instru_Name
        {
            get { return instru_Name; }
            set { instru_Name = value; }
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        private string keyId;
        public string KeyId
        {
            get { return keyId; }
            set { keyId = value; }
        }

        #endregion
    }
}
