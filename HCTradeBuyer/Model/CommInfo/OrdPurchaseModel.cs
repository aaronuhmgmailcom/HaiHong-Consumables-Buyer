using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 采购单模型
    /// </summary>
    [Serializable]
    public class OrdPurchaseModel
    {
        #region Fields

        /// <summary>
        /// 采购单ID
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
        /// 买方ID
        /// </summary>
        private string buyer_Id;
        public string Buyer_Id
        {
            get { return buyer_Id; }
            set { buyer_Id = value; }
        }

        /// <summary>
        /// 采购单编号
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// 采购单类型
        /// </summary>
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 采购单金额
        /// </summary>
        private decimal total_Sum;
        public decimal Total_Sum
        {
            get { return total_Sum; }
            set { total_Sum = value; }
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
        /// 创建人ID
        /// </summary>
        private string create_User_Id;
        public string Create_User_Id
        {
            get { return create_User_Id; }
            set { create_User_Id = value; }
        }

        /// <summary>
        /// 创建人名称
        /// </summary>
        private string create_User_Name;
        public string Create_User_Name
        {
            get { return create_User_Name; }
            set { create_User_Name = value; }
        }

        /// <summary>
        /// 采购单状态
        /// </summary>
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// 审批人ID
        /// </summary>
        private string aduid_User_Id;
        public string Aduid_User_Id
        {
            get { return aduid_User_Id; }
            set { aduid_User_Id = value; }
        }

        /// <summary>
        /// 审批人
        /// </summary>
        private string audit_User_Name;
        public string Audit_User_Name
        {
            get { return audit_User_Name; }
            set { audit_User_Name = value; }
        }

        /// <summary>
        /// 审批时间
        /// </summary>
        private string audit_Date;
        public string Audit_Date
        {
            get { return audit_Date; }
            set { audit_Date = value; }
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

        #endregion
    }
}
