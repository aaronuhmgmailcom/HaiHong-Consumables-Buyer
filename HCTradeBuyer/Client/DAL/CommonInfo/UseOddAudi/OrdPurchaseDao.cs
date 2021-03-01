//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdPurchaseDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	采购单操作（数据访问层）
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
    /// 采购单操作（数据访问层）
    /// </summary>
    class OrdPurchaseDao : SqlDAOBase
    {
        private OrdPurchaseDao()
        : base()
        { }

        private OrdPurchaseDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdPurchaseDao GetInstance()
        {
            return new OrdPurchaseDao();
        }

        public static OrdPurchaseDao GetInstance(string connectionName)
        {
            return new OrdPurchaseDao(connectionName);
        }

        /// <summary>
        /// 保存采购单主表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdPurchaseModel(OrdPurchaseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_PURCHASE
                            (
                            ID, 
                            BUYER_ID, 
                            CODE, 
                            TYPE, 
                            TOTAL_SUM, 
                            PURCHASE_DATE, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            STATE, 
                            AUDIT_USER_ID, 
                            AUDIT_USER_NAME, 
                            AUDIT_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE, 
                            QUICKSEND_LEVEL, 
                            CREATE_DATE, 
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Id);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Code);
            strSql.AppendFormat("'{0}',", model.Type);
            strSql.AppendFormat("{0},", model.Total_Sum);
            strSql.AppendFormat("'{0}',", model.Purchase_Date);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", model.State);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.Append("'1',");
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
        /// 保存采购单明细表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdPurchaseItemModel(OrdPurchaseItemModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            string strID = base.GetClientId(logedinUser.HighId).ToString();

            strSql.Append(@"Insert Into HC_ORD_PURCHASE_ITEM
                            (
                            ID, 
                            PROJECT_ID, 
                            PURCHASE_ID, 
                            PROJECT_PROD_ID, 
                            DATA_PRODUCT_ID, 
                            BUYER_ID, 
                            SALER_ID, 
                            SALER_NAME, 
                            SALER_NAME_ABBR, 
                            SENDER_ID, 
                            SENDER_NAME, 
                            SENDER_NAME_ABBR, 
                            MANUFACTURE_ID, 
                            MANUFACTURE_NAME, 
                            MANUFACTURE_NAME_ABBR, 
                            COMMON_NAME, 
                            PRODUCT_NAME, 
                            PRODUCT_CODE, 
                            SPEC, 
                            MODEL, 
                            BRAND, 
                            GOODS_NO, 
                            BARCODE, 
                            BASE_MEASURE, 
                            BASE_MEASURE_SPEC, 
                            BASE_MEASURE_MATER, 
                            RETAIL_PRICE, 
                            TRADE_PRICE, 
                            AMOUNT, 
                            OVER_AMOUNT, 
                            OVER_SUM, 
                            IS_QUICKSEND, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            DESCRIPTIONS, 
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("'{0}',", strID);
            strSql.AppendFormat("'{0}',", model.Project_Id);
            strSql.AppendFormat("'{0}',", model.Purchase_Id);
            strSql.AppendFormat("'{0}',", model.Project_Prod_Id);
            strSql.AppendFormat("'{0}',", model.Data_Product_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Saler_Id );
            strSql.AppendFormat("'{0}',", model.Saler_Name);
            strSql.AppendFormat("'{0}',", model.Saler_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Manu_Id);
            strSql.AppendFormat("'{0}',", model.Manu_Name);
            strSql.AppendFormat("'{0}',", model.Manu_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Common_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("'{0}',", model.GoodsNo);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mate);
            strSql.AppendFormat("'{0}',", model.Retail_Price);
            strSql.AppendFormat("'{0}',", model.Trade_Price);
            strSql.AppendFormat("'{0}',", model.Amount);
            strSql.AppendFormat("'{0}',", model.Over_Amount);
            strSql.AppendFormat("'{0}',", model.Over_Sum);
            strSql.AppendFormat("'{0}',", model.Is_Quicksend);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", model.Descriptions);
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

    }
}
