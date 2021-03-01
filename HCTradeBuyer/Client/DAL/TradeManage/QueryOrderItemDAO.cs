//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	QueryOrderItemDAO.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-28
//	功能描述:	订单商品信息（数据访问类）
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.DataMaintenance;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.Commons;

namespace Emedchina.TradeAssistant.Client.DAL.TradeManage
{
    /// <summary>
    /// 订单商品信息（数据访问类）
    /// </summary>
    class QueryOrderItemDAO : SqlDAOBase
    {
        private QueryOrderItemDAO()
            : base()
        { }

        private QueryOrderItemDAO(string connectionName)
            : base(connectionName)
        { }

        public static QueryOrderItemDAO GetInstance()
        {
            return new QueryOrderItemDAO();
        }

        public static QueryOrderItemDAO GetInstance(string connectionName)
        {
            return new QueryOrderItemDAO(connectionName);
        }

        /// <summary>
        /// 获取订单商品信息数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetQueryOrderItemInfoDt(LogedInUser logedinUser)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            //strSql.Append(" select ID,STONE_NAME,STONE_ADDRESS,LINMAN,CREATE_USER_NAME,CREATE_USER_ID");
            //strSql.Append(" CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,ORG_ID ");
            //strSql.Append(" sync_state from HC_BUYER_STORE where 1=1");

            strSql.Append(" Select tab.* From ( Select  opi.DATA_PRODUCT_ID, opi.ID AS ORDER_ITEM_ID, op.order_CODE as CODE, ");

            strSql.Append(" opi.COMMON_NAME,opi.PRODUCT_NAME ,opi.SPEC, opi.MODEL, opi.BRAND, opi.STORE_ROOM_ID,p.code as product_Code,p.ABBR_PY,p.ABBR_WB, ");

            strSql.Append(" (case when opi.STORE_ROOM_NAME is null then '-' else opi.STORE_ROOM_NAME end) as STORE_ROOM_NAME, opi.TRADE_PRICE, opi.SUM As totalPrice, opi.AMOUNT, ");

            strSql.Append(" (case when opi.OVER_AMOUNT is null then '-' else ");

            strSql.Append(" opi.OVER_AMOUNT end) as OVER_AMOUNT, (case when  ");

            strSql.Append(" opi.OVER_SUM is null then '-' else opi.OVER_SUM end) as OVER_SUM, ");

            strSql.Append(" op.CREATE_DATE, opi.SALER_ID, opi.SALER_NAME, opi.SALER_NAME_ABBR,op.ORDER_CODE ,");

            strSql.Append(" opi.SENDER_ID, opi.SENDER_NAME, opi.SENDER_NAME_ABBR, opi.MANUFACTURE_ID,");

            strSql.Append(" (case op.state when '1' then '发送' when '2' then '已阅读' when '3' then '作废' when '4' then '已确认' when '5' then '完成' end) as state,");

            strSql.Append(" opi.MANUFACTURE_NAME, opi.MANUFACTURE_NAME_ABBR, (case opi.IS_QUICKSEND ");

            strSql.Append(" when '0' then '普通' when '1' then '急需' end) IsQuickSend  From ");

            strSql.Append(" HC_ORD_order_ITEM opi,HC_ORD_order op,HC_ORD_PRODUCT p  where opi.order_ID=op.ID and opi.PROJECT_PROD_ID=p.id)");

            strSql.Append(" as tab  ");



            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }


        /// <summary>
        /// 采购目录信息对象
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object GetBulletinInfoModel(IDataReader reader, int row)
        {
            BulletinInfoModel model = new BulletinInfoModel();
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








    }
}
