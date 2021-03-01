using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 采购供应目录模型
    /// </summary>
    [Serializable]
    public class OrdHitCommMode
    {
        #region Fields

        /// <summary>
        /// 采购目录ID
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
        /// 项目类型
        /// </summary>
        private string project_Type;
        public string Project_Type
        {
            get { return project_Type; }
            set { project_Type = value; }
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
        /// 商品编码
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        /// 品种分类
        /// </summary>
        private string class_Name;
        public string Class_Name
        {
            get { return class_Name; }
            set { class_Name = value; }
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
        /// 配送企业
        /// </summary>
        private string senderName;
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        /// <summary>
        /// 配送企业简称
        /// </summary>
        private string senderNameAbbr;
        public string SenderNameAbbr
        {
            get { return senderNameAbbr; }
            set { senderNameAbbr = value; }
        }

        /// <summary>
        /// 配送单位        /// </summary>
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
        /// 库房名称STORE_ROOM_NAME
        /// </summary>
        private string storeRoomName;
        public string StoreRoomName
        {
            get { return storeRoomName; }
            set { storeRoomName = value; }
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
        /// 单价
        /// </summary>
        private string price;
        public string Price
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
        private string manuNameAbbr;
        public string ManuNameAbbr
        {
            get { return manuNameAbbr; }
            set { manuNameAbbr = value; }
        }

        /// <summary>
        /// 注册证号
        /// </summary>
        private string regNo;
        public string RegNo
        {
            get { return regNo; }
            set { regNo = value; }
        }

        /// <summary>
        /// 截止日期
        /// </summary>
        private string regValidDate;
        public string RegValidDate
        {
            get { return regValidDate; }
            set { regValidDate = value; }
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
        /// 买方ID
        /// </summary>
        private string buyer_Id;
        public string Buyer_Id
        {
            get { return buyer_Id; }
            set { buyer_Id = value; }
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
        /// 有效期
        /// </summary>
        private string valid_Date;
        public string Valid_Date
        {
            get { return valid_Date; }
            set { valid_Date = value; }
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
        /// 批次
        /// </summary>
        private string batch_No;
        public string Batch_No
        {
            get { return batch_No; }
            set { batch_No = value; }
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
        /// 自定义编码
        /// </summary>
        private string productMnemonic;
        public string ProductMnemonic
        {
            get { return productMnemonic; }
            set { productMnemonic = value; }
        }

        /// <summary>
        /// 大包装
        /// </summary>
        private string selfPackage;
        public string SelfPackage
        {
            get { return selfPackage; }
            set { selfPackage = value; }
        }

        /// <summary>
        /// 别名
        /// </summary>
        private string alias;
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        /// <summary>
        /// 别名拼音
        /// </summary>
        private string aliasPinyin;
        public string AliasPinyin
        {
            get { return aliasPinyin; }
            set { aliasPinyin = value; }
        }

        #endregion
    }
}
