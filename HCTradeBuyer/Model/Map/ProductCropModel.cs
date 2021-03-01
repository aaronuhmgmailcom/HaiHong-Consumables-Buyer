using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Map
{
   [Serializable]
   public class ProductCropModel
    {
       string orgid;
       public string OrgID
       {
           get { return orgid; }
           set { orgid = value; }
       }
       string modifyuserid;
       public string ModifyUserID
       {
           get { return modifyuserid; }
           set { modifyuserid = value; }
       }
        //开始页索引
        private int start;

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        // 结束页索引
        private int end;

        public int End
        {
            get { return end; }
            set { end = value; }
        }
        int rows;
       public int Rows
       {
           get { return rows; }
           set { rows = value; }
       }
    
        string id;
        public string ID//ID
        {
            get { return id; }
            set { id = value; }
        }
        string productID;

        public string ProductID//海虹产品ID
        {
            get { return productID; }
            set { productID = value; }
        }
        string buyerID;
        public string BuyerID//海虹买方ID
        {
            get { return buyerID; }
            set { buyerID = value; }
        }
        string factoryID;
        public string FactoryID//海虹生产企业ID
        {
            get { return factoryID; }
            set { factoryID = value; }
        }
        string salerID;
        /// <summary>
        /// 海虹经销企业ID
        /// </summary>
        public string SalerID
        {
            get { return salerID; }
            set { salerID = value; }
        }
        string senderID;
        /// <summary>
        /// 海虹配送企业ID
        /// </summary>
        public string SenderID
        {
            get { return senderID; }
            set { senderID = value; }
        }
        string specUnit;
        /// <summary>
        /// 最小包装单位
        /// </summary>
        public string SpecUnit
        {
            get { return specUnit; }
            set { specUnit = value; }
        }
       string cropstate;
        /// <summary>
        ///匹配状态
        /// </summary>
       public string CropState
       {
           get { return this.cropstate; }
           set { this.cropstate = value; }
       }
       
       private string dealstate;
        /// <summary>
       /// 处理状态
        /// </summary>
       public string DealState
       {
           get { return this.dealstate; }
           set { this.dealstate = value; }
       }
        string packageRate;
        /// <summary>
        /// ERP包装转换比
        /// </summary>
        public string PackageRate
        { 
            get 
            {
                if (string.IsNullOrEmpty(packageRate))
                    packageRate = "1";
                return packageRate;
            }
            set { packageRate = value; }
        }
        string modeName;
        /// <summary>
        /// 剂型名称
        /// </summary>
        public string ModeName
        {
            get { return modeName; }
            set { modeName = value; }
        }
        string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        string specUnitCode;
        /// <summary>
        /// 最小包装单位编码
        /// </summary>
        public string SpecUnitCode
        {
            get { return specUnitCode; }
            set { specUnitCode = value; }
        }
        string standRate;
        /// <summary>
        /// 海虹单位转换比
        /// </summary>
        public string StandRate
        {
            get 
            {
                if (string.IsNullOrEmpty(standRate))
                    standRate = "1";
                return standRate;
            }
            set { standRate = value; }
        }
        string modeCode;
        /// <summary>
        /// 剂型编码
        /// </summary>
        public string ModeCode
        {
            get { return modeCode; }
            set { modeCode = value; }
        }
        string producer;
        /// <summary>
        /// 生产企业
        /// </summary>
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }
        string producerCode;
        /// <summary>
        /// 生产企业编码
        /// </summary>
        public string ProducerCode
        {
            get { return producerCode; }
            set { producerCode = value; }
        }
        string useUnit;
        /// <summary>
        /// 最小使用单位
        /// </summary>
        public string UseUnit
        {
            get { return useUnit; }
            set { useUnit = value; }
        }
        string useUnitCode;
        /// <summary>
        /// 最小使用单位编码
        /// </summary>
        public string UseUnitCode
        {
            get { return useUnitCode; }
            set { useUnitCode = value; }
        }
        string specName;
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecName
        {
            get { return specName; }
            set { specName = value; }
        }
        string specCode;
        /// <summary>
        /// 规格编码
        /// </summary>
        public string SpecCode
        {
            get { return specCode; }
            set { specCode = value; }
        }
        string name;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;
        /// <summary>
        /// 产品编码
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        string read;
        /// <summary>
        /// 已阅读
        /// </summary>
        public string Read
        {
            get { return read; }
            set { read = value; }
        }
       string sender;
       /// <summary>
       /// 配送企业
       /// </summary>
       public string Sender
       {
           get { return sender; }
           set { sender = value; }
       }
       string saler;
       /// <summary>
       /// 批发企业
       /// </summary>
       public string Saler
       {
           get { return saler; }
           set { saler = value; }
       }
       string sourcetype;
       /// <summary>
       /// 来源类型
       /// </summary>
       public string SourceType
       {
           get { return sourcetype; }
           set { sourcetype = value; }
       }
       string compare;
       /// <summary>
       /// 对照关系
       /// </summary>
       public string Compare
       {
           get { return compare; }
           set { compare = value; }
       }
    } 
   
}
