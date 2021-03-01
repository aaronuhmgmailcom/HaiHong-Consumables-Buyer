using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 订单模型
    /// </summary>
    [Serializable]
    public class OrdOrderModel
    {
        #region Fields

        /// <summary>
        /// 订单ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        /// 订单编码
        /// </summary>
        private string order_Code;
        public string Order_Code
        {
            get { return order_Code; }
            set { order_Code = value; }
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
        /// 采购单编号
        /// </summary>
        private string purchase_Code;
        public string Purchase_Code
        {
            get { return purchase_Code; }
            set { purchase_Code = value; }
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
        /// 交易总金额
        /// </summary>
        private decimal total_Sum;
        public decimal Total_Sum
        {
            get { return total_Sum; }
            set { total_Sum = value; }
        }

        /// <summary>
        /// 完成金额
        /// </summary>
        private decimal over_Sum;
        public decimal Over_Sum
        {
            get { return over_Sum; }
            set { over_Sum = value; }
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 采购日期
        /// </summary>
        private string purchase_Date;
        public string Purchase_Date
        {
            get { return purchase_Date; }
            set { purchase_Date = value; }
        }

        /// <summary>
        /// 紧急程度
        /// </summary>
        private string quicksend_Level;
        public string Quicksend_Level
        {
            get { return quicksend_Level; }
            set { quicksend_Level = value; }
        }

        /// <summary>
        /// 卖方描述
        /// </summary>
        private string saler_Descriptions;
        public string Saler_Descriptions
        {
            get { return saler_Descriptions; }
            set { saler_Descriptions = value; }
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

        #endregion

    }
}
