using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{    
    /// <summary>
    /// 备货单主表模型
    /// </summary>
    [Serializable]
    public class OrdStockUpModel
    {
        #region Fields

        /// <summary>
        /// 备货单ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 备货单编码
        /// </summary>
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        /// 配送商名称简称
        /// </summary>
        private string sender_Name_Abbr;
        public string Sender_Name_Abbr
        {
            get { return sender_Name_Abbr; }
            set { sender_Name_Abbr = value; }
        }

        /// <summary>
        /// 发送时间
        /// </summary>
        private string create_Date;
        public string Create_Date
        {
            get { return create_Date; }
            set { create_Date = value; }
        }

        /// <summary>
        /// 单据状态
        /// </summary>
        private string state_Name;
        public string State_Name
        {
            get { return state_Name; }
            set { state_Name = value; }
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

        #endregion
    }
}
