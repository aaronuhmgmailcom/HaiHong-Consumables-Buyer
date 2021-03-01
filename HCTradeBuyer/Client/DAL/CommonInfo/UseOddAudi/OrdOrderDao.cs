//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdOrderDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	订单操作（数据访问层）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 订单操作（数据访问层）
    /// </summary>
    class OrdOrderDao : SqlDAOBase
    {
        private OrdOrderDao()
        : base()
        { }

        private OrdOrderDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdOrderDao GetInstance()
        {
            return new OrdOrderDao();
        }

        public static OrdOrderDao GetInstance(string connectionName)
        {
            return new OrdOrderDao(connectionName);
        }

        /// <summary>
        /// 更新订单主表 金额数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        public void EditSumOrdOrderModel(OrdOrderModel model, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("Update HC_ORD_ORDER Set SYNC_STATE='0',TOTAL_SUM={0},OVER_SUM={0} Where ID={1}", model.Total_Sum, model.Id);

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存订单主表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderModel(OrdOrderModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_ORDER
                            (
                            ID, 
                            ORDER_CODE, 
                            PURCHASE_ID,
                            PURCHASE_CODE,
                            BUYER_ID, 
                            BUYER_NAME, 
                            BUYER_NAME_ABBR, 
                            SENDER_ID, 
                            SENDER_NAME, 
                            SENDER_NAME_ABBR, 
                            TOTAL_SUM, 
                            OVER_SUM, 
                            STATE, 
                            TYPE, 
                            PURCHASE_DATE, 
                            QUICKSEND_LEVEL, 
                            SALER_DESCRIPTIONS, 
                            BUYER_DESCRIPTIONS, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE, 
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Id);
            strSql.AppendFormat("'{0}',", model.Code);
            strSql.AppendFormat("{0},", model.Purchase_Id);
            strSql.AppendFormat("'{0}',", model.Purchase_Code);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Name);
            strSql.AppendFormat("'{0}',", model.Buyer_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("{0},", model.Total_Sum);
            strSql.AppendFormat("{0},", model.Over_Sum);
            strSql.AppendFormat("'{0}',", model.State);
            strSql.AppendFormat("'{0}',", model.Type);
            strSql.AppendFormat("'{0}',", model.Purchase_Date);
            strSql.AppendFormat("'{0}',", model.Quicksend_Level);
            strSql.AppendFormat("'{0}',", model.Saler_Descriptions);
            strSql.AppendFormat("'{0}',", model.Buyer_Descriptions);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.Append("'0'");
            strSql.Append(")");

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存订单主表（日志）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderModel_LOG(OrdOrderModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_ORDER_LOG
                            (
                            ID, 
                            ORDER_CODE, 
                            PURCHASE_ID,
                            PURCHASE_CODE,
                            BUYER_ID, 
                            BUYER_NAME, 
                            BUYER_NAME_ABBR, 
                            SENDER_ID, 
                            SENDER_NAME, 
                            SENDER_NAME_ABBR, 
                            TOTAL_SUM, 
                            OVER_SUM, 
                            STATE, 
                            TYPE, 
                            PURCHASE_DATE, 
                            QUICKSEND_LEVEL, 
                            SALER_DESCRIPTIONS, 
                            BUYER_DESCRIPTIONS, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE, 
                            SYNC_STATE,
                            OPERATOR_USER_ID,
                            OPERATOR_USER_NAME,
                            OPERATOR_DATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Id);
            strSql.AppendFormat("'{0}',", model.Code);
            strSql.AppendFormat("{0},", model.Purchase_Id);
            strSql.AppendFormat("'{0}',", model.Purchase_Code);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Name);
            strSql.AppendFormat("'{0}',", model.Buyer_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("{0},", model.Total_Sum);
            strSql.AppendFormat("{0},", model.Over_Sum);
            strSql.AppendFormat("'{0}',", model.State);
            strSql.AppendFormat("'{0}',", model.Type);
            strSql.AppendFormat("'{0}',", model.Purchase_Date);
            strSql.AppendFormat("'{0}',", model.Quicksend_Level);
            strSql.AppendFormat("'{0}',", model.Saler_Descriptions);
            strSql.AppendFormat("'{0}',", model.Buyer_Descriptions);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.Append("'0',");
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}'", DateTime.Now.ToString());
            strSql.Append(")");

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
