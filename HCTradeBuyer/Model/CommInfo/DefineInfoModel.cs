using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 自定义编码及大包装模型
    /// </summary>
    [Serializable]
    public class DefineInfoModel
    {
        #region Fields

        /// <summary>
        /// 经常采购目录ID
        /// </summary>
        private string hit_Comm_Id;
        public string Hit_Comm_Id
        {
            get { return hit_Comm_Id; }
            set { hit_Comm_Id = value; }
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

        /// <summary>
        /// 商品名称
        /// </summary>
        private string commerceName;
        public string CommerceName
        {
            get { return commerceName; }
            set { commerceName = value; }
        }

        /// <summary>
        /// 通用名
        /// </summary>
        private string commonName;
        public string CommonName
        {
            get { return commonName; }
            set { commonName = value; }
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
        /// 生产企业
        /// </summary>
        private string manuName;
        public string ManuName
        {
            get { return manuName; }
            set { manuName = value; }
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

        #endregion

    }
}
