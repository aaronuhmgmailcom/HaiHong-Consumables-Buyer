using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.DataMaintenance
{
    /// <summary>
    /// 库房信息模型
    /// </summary>
    [Serializable]
    public class WarehouseModel
    {
        #region Fields

        /// <summary>
        /// 库房信息ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 机构id
        /// </summary>
        private string orgid;
        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        private string stoneName;
        public string StoneName
        {
            get { return stoneName; }
            set { stoneName = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        private string stone_address;
        public string Stone_address
        {
            get { return stone_address; }
            set { stone_address = value; }
        }

        /// <summary>
        /// 联系人
        /// </summary>
        private string linman;
        public string Linman
        {
            get { return linman; }
            set { linman = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        private string linktel;
        public string Linktel
        {
            get { return linktel; }
            set { linktel = value; }
        }

        /// <summary>
        /// 创建人名称
        /// </summary>
        private string create_user_name;
        public string Create_user_name
        {
            get { return create_user_name; }
            set { create_user_name = value; }
        }

        /// <summary>
        /// 创建人id
        /// </summary>
        private string create_user_id;
        public string Create_user_id
        {
            get { return create_user_id; }
            set { create_user_id = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private string create_date;
        public string Create_date
        {
            get { return create_date; }
            set { create_date = value; }
        }

        /// <summary>
        /// 修改人id
        /// </summary>
        private string modify_user_id;
        public string Modify_user_id
        {
            get { return modify_user_id; }
            set { modify_user_id = value; }
        }

        /// <summary>
        /// 修改人名称
        /// </summary>
        private string modify_user_name;
        public string Modify_user_name
        {
            get { return modify_user_name; }
            set { modify_user_name = value; }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        private string modify_data;
        public string Modify_data
        {
            get { return modify_data; }
            set { modify_data = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private string enalbe_flag;
        public string Enalbe_flag
        {
            get { return enalbe_flag; }
            set { enalbe_flag = value; }
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
        
        #endregion

    }
}
