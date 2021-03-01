//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	BulletinInfoDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	公告信息（数据访问类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 公告信息（数据访问类）
    /// </summary>
    class BulletinInfoDao : SqlDAOBase
    {
        private BulletinInfoDao()
        : base()
        { }

        private BulletinInfoDao(string connectionName)
        : base(connectionName)
        { }

        public static BulletinInfoDao GetInstance()
        {
            return new BulletinInfoDao();
        }

        public static BulletinInfoDao GetInstance(string connectionName)
        {
            return new BulletinInfoDao(connectionName);
        }

        /// <summary>
        /// 获取公告信息数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetBulletinInfoDt(LogedInUser logedinUser)
        {
            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            br.ID As ReceiverID,
                            bi.ID,
                            bi.Title,
                            bi.CONTENT,
                            br.IS_READ,
                            (case br.IS_READ when '1' then '未阅读' when '2' then '已阅读' end) As ReadName,
                            bi.ISSUER_ID,
                            bi.ISSUER_NAME,
                            bi.ISSUE_DATE
                            From HC_BULLETIN_INFO bi,HC_BULLETIN_RECEIVER br
                            Where bi.ID=br.BULLETIN_ID And bi.STATE<>'3'");

            if (!string.IsNullOrEmpty(logedinUser.UserOrg.Id))
            {
                strSql.AppendFormat(" And bi.ISSUER_ORG_ID='{0}'", logedinUser.UserOrg.Id);
            }
            strSql.Append(" order by bi.ISSUE_DATE desc ");
            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取公告信息对象
        /// </summary>
        /// <param name="Hc_Id"></param>
        /// <returns></returns>
        public BulletinInfoModel GetBulletinInfoModel(string strBulietin_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"Select 
                            br.id as ReceiverId,
                            bi.ID,
                            bi.Title,
                            bi.CONTENT,
                            br.IS_READ,
                            (case br.IS_READ when '2' then '已阅读' when '1' then '未阅读' end) As ReadName,
                            bi.ISSUER_ID,
                            bi.ISSUER_NAME,
                            bi.ISSUE_DATE 
                            From HC_BULLETIN_INFO bi,HC_BULLETIN_RECEIVER br 
                            Where bi.ID=br.BULLETIN_ID");

            if (!string.IsNullOrEmpty(strBulietin_Id))
            {
                strSql.AppendFormat(" and bi.ID='{0}'", strBulietin_Id);
            }
            else
            {
                return null;
            }

            BulletinInfoModel model = null;

            model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(GetBulletinInfoModel)) as BulletinInfoModel;

            return model;
        }

        /// <summary>
        /// 采购目录信息对象
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private object GetBulletinInfoModel(IDataReader reader, int row)
        {
            BulletinInfoModel model = new BulletinInfoModel();
            model.ReceiverId = Convert.ToString(reader["ReceiverId"]);
            model.Id = Convert.ToString(reader["ID"]);
            model.Title = Convert.ToString(reader["Title"]);
            model.Content = Convert.ToString(reader["Content"]);
            model.IsRead = Convert.ToString(reader["IS_READ"]);
            model.ReadName = Convert.ToString(reader["ReadName"]);
            model.IsSuerId = Convert.ToString(reader["ISSUER_ID"]);
            model.IsSuerName = Convert.ToString(reader["ISSUER_NAME"]);
            model.IsSuerDate = Convert.ToString(reader["ISSUE_DATE"]);

            return model;
        }

        /// <summary>
        /// 修改公告接收用户表已阅读状态
        /// </summary>
        /// <param name="ReceiverId"></param>
        public void ModifyBulletinReceiver(string ReceiverId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update HC_BULLETIN_RECEIVER");
            strSql.Append(" Set ");
            strSql.Append(" SYNC_STATE='0',");
            strSql.Append(" IS_READ='2'");
            strSql.AppendFormat(" Where ID='{0}'", ReceiverId);

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
