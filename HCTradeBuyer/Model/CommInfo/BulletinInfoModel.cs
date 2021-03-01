using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.CommInfo
{
    /// <summary>
    /// 公告信息模型
    /// </summary>
    [Serializable]
    public class BulletinInfoModel
    {
        #region Fields

        /// <summary>
        /// 公告信息ID
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 公告信息接收表ID
        /// </summary>
        private string receiverId;
        public string ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        /// <summary>
        /// 公告标题
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 公告内容
        /// </summary>
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// 阅读状态
        /// </summary>
        private string isRead;
        public string IsRead
        {
            get { return isRead; }
            set { isRead = value; }
        }

        /// <summary>
        /// 状态名称
        /// </summary>
        private string readName;
        public string ReadName
        {
            get { return readName; }
            set { readName = value; }
        }

        /// <summary>
        /// 发布用户ID
        /// </summary>
        private string isSuerId;
        public string IsSuerId
        {
            get { return isSuerId; }
            set { isSuerId = value; }
        }

        /// <summary>
        /// 发布用户名称
        /// </summary>
        private string isSuerName;
        public string IsSuerName
        {
            get { return isSuerName; }
            set { isSuerName = value; }
        }

        /// <summary>
        /// 发布用户名称
        /// </summary>
        private string isSuerDate;
        public string IsSuerDate
        {
            get { return isSuerDate; }
            set { isSuerDate = value; }
        }

        #endregion

    }
}
