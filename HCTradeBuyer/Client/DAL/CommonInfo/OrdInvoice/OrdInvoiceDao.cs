//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdInvoiceDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	发货单确认（数据访问类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 发货单确认（数据访问类）
    /// </summary>
    class OrdInvoiceDao : SqlDAOBase
    {
        private OrdInvoiceDao()
        : base()
        { }

        private OrdInvoiceDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdInvoiceDao GetInstance()
        {
            return new OrdInvoiceDao();
        }

        public static OrdInvoiceDao GetInstance(string connectionName)
        {
            return new OrdInvoiceDao(connectionName);
        }

        /// <summary>
        /// 获取发货单信息列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdInvoiceFromList()
        {
            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            oif.ID,
                            oif.INVOICE_CODE,
                            org.ORG_NAME As SENDER_NAME,
                            org.ORG_ABBR As SENDER_NAME_ABBR,
                            org.SPELL_ABBR As SENDER_NAME_SPELL_ABBR,
                            org.ORG_NAME_WB As SENDER_NAME_WB,
                            oif.CREATE_USER_NAME,
                            oif.CREATE_DATE,
                            oif.TOTAL_SUM,
                            oif.OVER_SUM,
                            oif.SENDED_DATE,
                            oif.STATE,
                            (Case oif.State When '1'  Then '未发送' When '2' Then '已发送' When '3' Then '买方处理中' When '4' Then '作废' When '5' Then '买方处理完成' End) As StateName
                            From HC_ORD_INVOICE_FROM oif
                            Left join HC_ORG org
                            on oif.SENDER_ID=org.Id 
                            where oif.State Not In('1','4')
                            ");

            strSql.Append(" Order By oif.SENDED_DATE Desc");

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
        /// 获取发货单明细信息列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdInvoiceFromItemList(string StrInvoiceFromId)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select Tab.*,ohc.STORE_ROOM_ID,
                            ohc.STORE_ROOM_NAME,ohc.ID As ordHitCommId From
                            (
                            Select
                            '0' As Sel,
                            oifi.Id,
                            oifi.DATA_PRODUCT_ID,
                            oifi.PROJECT_ID,
                            oifi.INVOICE_FROM_ID,
                            oifi.PROJECT_PROD_ID As PROJECT_PRODUCT_ID,
                            oifi.BUYER_ID,
                            op.CONT_PRODUCT_ID,
                            op.Code As PRODUCT_CODE,
                            op.COMMERCE_NAME,
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            op.MAX_PRICE,
                            op.DEFAULT_MEASURE,
                            op.DEFAULT_MEASURE_EX,
                            op.INSTRU_CODE,
                            op.INSTRU_NAME,
                            op.REG_NO,
                            op.REG_VALID_DATE,
                            oifi.GOODS_NO,
                            oifi.SPEC_ID,
                            oifi.MODEL_ID,
                            oifi.SEND_MEASURE,
                            oifi.SEND_MEASURE_EX,
                            isnull(oifi.PBNO,'-') As PBNO,
                            oifi.SEND_BATCH_NO,
                            oifi.INSTORE_BATCH_NO,
                            isnull(oifi.INSTORE_BATCH_NO,'-') As INSTORE_BATCH_NO_ITEM,
                            oifi.SPEC,
                            oifi.MODEL,
                            oifi.BRAND,
                            oifi.BARCODE,
                            oifi.SALER_ID,
                            org1.ORG_NAME As SALER_NAME,
                            org1.ORG_ABBR As SALER_NAME_ABBR,
                            oif.SENDER_ID,
                            org2.ORG_NAME As SENDER_NAME,
                            org2.ORG_ABBR As SENDER_NAME_ABBR,
                            oifi.MANUFACTURE_ID As MANU_ID,
                            org3.ORG_NAME As MANU_NAME,
                            org3.ORG_ABBR As MANU_NAME_ABBR,
                            oifi.BASE_MEASURE,
                            oifi.BASE_MEASURE_SPEC,
                            oifi.BASE_MEASURE_MATER,
                            oifi.RETAIL_PRICE,
                            oifi.TRADE_PRICE As PRICE,
                            oifi.AMOUNT,
                            oifi.Sum,
                            cast(oifi.AMOUNT as bigint) As OVERAMOUNT,
                            oifi.OVER_AMOUNT,
                            oifi.OVER_SUM,
                            oifi.BATCH_NO,
                            isNull(convert(varchar,oifi.VALID_DATE,23),'-') As VALID_DATE,
                            oifi.State,
                            (Case oifi.State When '1'  Then '未确认' When '2' Then '已确认' When '3' Then '作废'  End) As StateName,
                            oif.CREATE_USER_ID As Send_Operator_Id,
                            oif.CREATE_USER_NAME As Send_Operator_Name,
                            oif.CREATE_DATE As Send_Operate_Date
                            From HC_ORD_INVOICE_FROM oif,HC_ORD_INVOICE_FROM_ITEM oifi,HC_ORD_PRODUCT op,HC_ORG org1,HC_ORG org2,HC_ORG org3
                            Where oif.Id=@INVOICE_FROM_ID And oif.Id=oifi.INVOICE_FROM_ID And oifi.PROJECT_PROD_ID=op.ID And org1.Id=oifi.SALER_ID And org2.Id=oif.SENDER_ID And org3.Id=oifi.MANUFACTURE_ID
                            )As Tab Left Join HC_ORD_HIT_COMM ohc
                            on Tab.PROJECT_ID=ohc.PROJECT_ID and Tab.PROJECT_PRODUCT_ID=ohc.PROJECT_PROD_ID and Tab.SPEC_ID=ohc.SPEC_ID and Tab.MODEL_ID=ohc.MODEL_ID 
                            ");           

            if (!string.IsNullOrEmpty(StrInvoiceFromId))
            {
                DbParameter paInvoiceFromId = DbFacade.CreateParameter();
                paInvoiceFromId.ParameterName = "INVOICE_FROM_ID";
                paInvoiceFromId.DbType = DbType.String;
                paInvoiceFromId.Value = StrInvoiceFromId;
                parameters.Add(paInvoiceFromId);
            }

            strSql.Append(" Order By Tab.Send_Operate_Date Desc");

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(),parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }


        /// <summary>
        /// 获取发货单信息对象
        /// </summary>
        /// <param name="strOrdInvoiceFromId"></param>
        /// <returns></returns>
        public OrdInvoiceFromModel GetOrdInvoiceFromModel(string strOrdInvoiceFromId)
        {

            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            oif.Id,
                            oif.INVOICE_CODE,
                            org.ORG_NAME As SENDED_NAME,
                            org.ORG_ABBR As SENDED_ABBR,
                            oif.CREATE_USER_NAME,
                            oif.CREATE_DATE,
                            oif.TOTAL_SUM,
                            oif.OVER_SUM,
                            oif.SENDED_DATE,
                            oif.STATE,
                            oif.CREATE_USER_NAME,
                            oif.CREATE_DATE,
                            oif.MODIFY_USER_NAME,
                            oif.MODIFY_DATE,
                            oif.BUYER_DESCRIPTIONS,
                            oif.SALER_DESCRIPTIONS,
                            (Case oif.State When '1'  Then '未发送' When '2' Then '已发送' When '3' Then '买方处理中' When '4' Then '作废' When '5' Then '买方处理完成' End) As StateName
                            From HC_ORD_INVOICE_FROM oif,HC_ORG org
                            Where oif.SENDER_ID=org.Id");


            if (!string.IsNullOrEmpty(strOrdInvoiceFromId))
            {
                strSql.Append(" And oif.Id=@INVOICE_FROM_ID");
                DbParameter paInvoiceFromId = DbFacade.CreateParameter();
                paInvoiceFromId.ParameterName = "INVOICE_FROM_ID";
                paInvoiceFromId.DbType = DbType.String;
                paInvoiceFromId.Value = strOrdInvoiceFromId;
                parameters.Add(paInvoiceFromId);
            }
            else
            {
                return null;
            }

            OrdInvoiceFromModel model = null;

            try
            {
                model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(GetOrdInvoiceFromModel), parameters.ToArray()) as OrdInvoiceFromModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }


        /// <summary>
        /// 获取订单表对象
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private object GetOrdInvoiceFromModel(IDataReader reader, int row)
        {
            OrdInvoiceFromModel model = new OrdInvoiceFromModel();
            model.Invoice_Code = Convert.ToString(reader["INVOICE_CODE"]);
            model.Sender_Name = Convert.ToString(reader["SENDED_NAME"]);
            model.Sended_Date = Convert.ToString(reader["SENDED_DATE"]);
            model.Create_User_Name = Convert.ToString(reader["CREATE_USER_NAME"]);
            model.Create_Date = Convert.ToString(reader["CREATE_DATE"]);
            model.Modify_User_Name = Convert.ToString(reader["MODIFY_USER_NAME"]);
            model.Modify_Date = Convert.ToString(reader["MODIFY_DATE"]);
            model.StateName = Convert.ToString(reader["StateName"]);
            model.Total_Sum = Convert.ToString(reader["TOTAL_SUM"]);
            model.Over_Sum = Convert.ToString(reader["OVER_SUM"]);
            model.Buyer_Descriptions = Convert.ToString(reader["BUYER_DESCRIPTIONS"]);
            model.Saler_Descriptions = Convert.ToString(reader["SALER_DESCRIPTIONS"]);

            return model;
        }

        #region 修改发货单状态
        /// <summary>
        /// 修改发货单状态 4 作废 ，并设置发货单明细 作废
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdInvoiceFromState(OrdInvoiceFromModel model,string State, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    //主表状态
                    ModifyOrdInvoiceFromState(model, State, logedinUser, transaction);

                    //明细表状态
                    ModifyOrdInvoiceFromItemState_ByInvoice_From_Id(model, State, logedinUser, transaction);

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                }
            }
        }

        /// <summary>
        /// 修改发货单表状态 （状态：1 未发送 2 已发送 3 买方处理中 4 作废 5 买方处理完成）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void ModifyOrdInvoiceFromState(OrdInvoiceFromModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_INVOICE_FROM
                                    Set SYNC_STATE='0',STATE='{0}',MODIFY_USER_ID='{1}',MODIFY_USER_NAME='{2}',MODIFY_DATE='{3}'
                                    Where ID='{4}'", State, logedinUser.UserInfo.Id, logedinUser.UserInfo.Name, DateTime.Now.ToShortDateString(), model.Id);


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
        /// 根据发货单ID修改发货单明细表状态 （状态：1 未确认 2 已确认 3 作废）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void ModifyOrdInvoiceFromItemState_ByInvoice_From_Id(OrdInvoiceFromModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_INVOICE_FROM_ITEM
                                    Set SYNC_STATE='0',STATE='{0}',MODIFY_USER_ID='{1}',MODIFY_USER_NAME='{2}',MODIFY_DATE='{3}'
                                    Where INVOICE_FROM_ID='{4}'", '3', logedinUser.UserInfo.Id, logedinUser.UserInfo.Name, DateTime.Now.ToShortDateString(), model.Id);


            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 修改发货单明细状态
        /// <summary>
        /// 修改发货单明细状态
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdInvoiceFromItemState(List<OrdInvoiceFromItemModel> Listmodel,string StrInvoiceFromId, string State, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    decimal overSum = 0;
                    foreach (OrdInvoiceFromItemModel model in Listmodel)
                    {
                        ModifyOrdInvoiceFromItemState(model, State, logedinUser, transaction);
                        overSum += model.Over_Sum;
                    }

                    //修改发货单主表 状态  到货金额
                    string strInvoiceFromState = "3";//
                    if (!IsAffirmInvoiceFromItemState(StrInvoiceFromId, transaction))
                        strInvoiceFromState = "5";

                    ModifyOrdInvoiceFromStateOverSum(StrInvoiceFromId, overSum, strInvoiceFromState, logedinUser, transaction);
                    //-------------------------------------------------------------------------------------------

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                }
            }
        }

        /// <summary>
        /// 修改发货单明细表状态 （状态：1 未确认 2 已确认 3 作废）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void ModifyOrdInvoiceFromItemState(OrdInvoiceFromItemModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_INVOICE_FROM_ITEM
                                    Set SYNC_STATE='0',
                                    STATE='{0}',
                                    OVER_AMOUNT={1},
                                    OVER_SUM={2},
                                    MODIFY_USER_ID='{3}',
                                    MODIFY_USER_NAME='{4}',
                                    MODIFY_DATE='{5}'", 
                                    State, model.Over_Amount, model.Over_Sum, logedinUser.UserInfo.Id, logedinUser.UserInfo.Name, DateTime.Now.ToShortDateString());
            if (!string.IsNullOrEmpty(model.Instore_Batch_No))
            {
                strSql.AppendFormat(",INSTORE_BATCH_NO='{0}'", model.Instore_Batch_No);
            }
            strSql.AppendFormat(" Where ID='{0}'",model.Id);
                                    


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
        /// 修改发货单主表 状态、完成金额
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void ModifyOrdInvoiceFromStateOverSum(string StrInvoiceFromId,decimal overSum, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_INVOICE_FROM
                                    Set SYNC_STATE='0',
                                    OVER_SUM = OVER_SUM + {0},
                                    STATE='{1}',
                                    MODIFY_USER_ID='{2}',
                                    MODIFY_USER_NAME='{3}',
                                    MODIFY_DATE='{4}'
                                    Where ID='{5}'",
                                   overSum,
                                   State, 
                                   logedinUser.UserInfo.Id, 
                                   logedinUser.UserInfo.Name, 
                                   DateTime.Now.ToShortDateString(),
                                   StrInvoiceFromId);


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
        /// 判断该明细所有记录是否已确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsAffirmInvoiceFromItemState(string StrInvoiceFromId, DbTransaction transaction)
        {
            bool flag = false;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                Count(1) 
                                From HC_ORD_INVOICE_FROM_ITEM 
                                Where INVOICE_FROM_ID={0} And State='1'", StrInvoiceFromId);

            try
            {
                int Count = Convert.ToInt16(DbFacade.SQLExecuteScalar(strSql.ToString(), transaction).ToString());
                if (Count > 0)
                {
                    //已添加
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;

        }


        #endregion

    }
}
