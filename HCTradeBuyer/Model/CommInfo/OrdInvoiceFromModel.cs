using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 发货单记录模型
    /// </summary>
    [Serializable]
    public class OrdInvoiceFromModel
    {
        #region Fields

        /// <summary>
        /// 发货单ID
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
        /// 发货单编号
        /// </summary>
        private string invoice_Code;
        public string Invoice_Code
        {
            get { return invoice_Code; }
            set { invoice_Code = value; }
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
        /// 交易总金额
        /// </summary>
        private string total_Sum;
        public string Total_Sum
        {
            get { return total_Sum; }
            set { total_Sum = value; }
        }

        /// <summary>
        /// 完成金额
        /// </summary>
        private string over_Sum;
        public string Over_Sum
        {
            get { return over_Sum; }
            set { over_Sum = value; }
        }

        /// <summary>
        /// 发送时间
        /// </summary>
        private string sended_Date;
        public string Sended_Date
        {
            get { return sended_Date; }
            set { sended_Date = value; }
        }

        /// <summary>
        /// 单据状态
        /// </summary>
        private string stateName;
        public string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        private string create_User_Name;
        public string Create_User_Name
        {
            get { return create_User_Name; }
            set { create_User_Name = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private string create_Date;
        public string Create_Date
        {
            get { return create_Date; }
            set { create_Date = value; }
        }

        /// <summary>
        /// 修改人
        /// </summary>
        private string modify_User_Name;
        public string Modify_User_Name
        {
            get { return modify_User_Name; }
            set { modify_User_Name = value; }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        private string modify_Date;
        public string Modify_Date
        {
            get { return modify_Date; }
            set { modify_Date = value; }
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

        /// <summary>
        /// 卖方描述
        /// </summary>
        private string saler_Descriptions;
        public string Saler_Descriptions
        {
            get { return saler_Descriptions; }
            set { saler_Descriptions = value; }
        }

        #endregion
    }
}
