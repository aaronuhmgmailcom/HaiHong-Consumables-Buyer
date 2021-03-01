//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdBuyerReturnDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	退货管理（数据访问类）
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
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.CommInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 退货管理（数据访问类）
    /// </summary>
    class OrdBuyerReturnDao : SqlDAOBase
    {
        private OrdBuyerReturnDao()
        : base()
        { }

        private OrdBuyerReturnDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdBuyerReturnDao GetInstance()
        {
            return new OrdBuyerReturnDao();
        }

        public static OrdBuyerReturnDao GetInstance(string connectionName)
        {
            return new OrdBuyerReturnDao(connectionName);
        }

        /// <summary>
        /// 获取可退货商品列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetBuyerReturnList()
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            '0' As Sel,
                            oor.ID As ReceiveID,
                            oos.ORDER_ID,
                            oos.ORDER_ITEM_ID,
                            oor.Code,
                            oor.Pbno,
                            oor.FACT_AMOUNT-isnull(oor.RETURN_AMOUNT,0) As Return_Amount,
                            oor.DATA_PRODUCT_ID,
                            oor.PROJECT_PRODUCT_ID,
                            op.PROJECT_ID,
                            op.PRODUCT_NAME,
                            op.COMMERCE_NAME,
                            op.COMMON_NAME,
                            op.Code As PRODUCT_CODE,
                            isnull(op.BRAND,'-') As BRAND,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            oor.BARCODE,
                            ooi.SPEC_ID,
                            ooi.MODEL_ID,
                            ooi.SPEC,
                            ooi.MODEL,
                            op.Price,
                            oor.GOODS_NO,
                            oor.SEND_BATCH_NO,
                            isnull(oor.INSTORE_BATCH_NO,'-') As INSTORE_BATCH_NO,
                            ooi.BASE_MEASURE,
                            ooi.BASE_MEASURE_SPEC,
                            ooi.BASE_MEASURE_MATER,
                            ooi.SEND_MEASURE,
                            ooi.SEND_MEASURE_EX,
                            org1.ID As SENDER_ID,
                            org1.ORG_NAME As SENDER_NAME,
                            org1.ORG_ABBR As SENDER_NAME_ABBR,
                            org1.SPELL_ABBR As SENDER_NAME_SPELL_ABBR,
                            org1.ORG_NAME_WB As SENDER_NAME_WB,
                            org2.ID As SALER_ID,
                            org2.ORG_NAME As SALER_NAME,
                            org2.ORG_ABBR As SALER_NAME_ABBR,
                            org2.SPELL_ABBR As SALER_NAME_SPELL_ABBR,
                            org2.ORG_NAME_WB As SALER_NAME_WB,
                            org3.ID As MANU_ID,
                            org3.ORG_NAME As MANU_NAME,
                            org3.ORG_ABBR As MANU_NAME_ABBR,
                            org3.SPELL_ABBR As MANU_NAME_SPELL_ABBR,
                            org3.ORG_NAME_WB As MANU_NAME_WB,
                            oor.ARRIVE_DATE,
                            '' as ReturnNum,
                            '' as ReturnRes,
                            oor.CREATE_USER_ID As INSTORE_OPERATOR_ID,
                            oor.CREATE_USER_NAME As INSTORE_OPERATOR_NAME,
                            oor.CREATE_DATE As INSTORE_OPERATOR_DATE,
                            oos.CREATE_USER_ID As SEND_OPERATOR_ID,
                            oos.CREATE_USER_NAME As SEND_OPERATOR_NAME,
                            oos.CREATE_DATE As SEND_OPERATE_DATE
                            From HC_ORD_ORDER_RECEIVE oor,HC_ORD_PRODUCT op,HC_ORG org1,HC_ORG org2,HC_ORG org3,HC_ORD_ORDER_ITEM ooi,HC_ORD_ORDER_STOCKUP oos
                            Where op.id=oor.PROJECT_PRODUCT_ID and ooi.SENDER_ID=org1.ID and ooi.SALER_ID=org2.ID and ooi.MANUFACTURE_ID=org3.ID
                            And oor.ORDER_ITEM_ID=ooi.ID and oor.STOCKUP_ID=oos.Id
                            ");

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
        /// 获取退货商品列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetReturnList(string State)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            '0' As Sel,
                            obr.Id As ReturnID,
                            obr.DATA_PRODUCT_ID,
                            obr.PROJECT_PRODUCT_ID,
                            obr.PRODUCT_NAME,
                            obr.COMMON_NAME,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            obr.PRODUCT_CODE,
                            obr.GOODS_NO,
                            obr.BARCODE,
                            obr.PBNO,
                            isnull(obr.BRAND,'-') As BRAND,
                            obr.SPEC,
                            obr.MODEL,
                            isnull(obr.INSTORE_BATCH_NO,'-') As INSTORE_BATCH_NO,
                            obr.SEND_MEASURE,
                            obr.SEND_MEASURE_EX,
                            obr.MANUFACTURE_NAME,
                            obr.MANUFACTURE_NAME_ABBR,
                            obr.SALER_NAME,
                            obr.SALER_NAME_ABBR,
                            obr.SENDER_NAME,
                            obr.SENDER_NAME_ABBR,
                            obr.PRICE,
                            obr.AMOUNT,
                            obr.BUYER_DESCRIPTIONS,
                            obr.CREATE_DATE,
                            oor.ID As ReceiveID,
                            oor.ARRIVE_DATE,
                            (Case obr.State When '1' Then '未发送' When '2' Then '已发送' When '3' Then '已撤销' When '4' Then '对方确认' When '5' Then '对方拒绝' End) As StateName
                            From HC_ORD_BUYER_RETURN obr,HC_ORD_ORDER_RECEIVE oor,HC_ORD_PRODUCT op
                            ");
            strSql.Append(" Where obr.RECEIVE_ID=oor.Id And op.id=obr.PROJECT_PRODUCT_ID");
            
            if (State.Equals("2"))//查询已发送的退货单
            {
                strSql.AppendFormat(" And obr.STATE In('2','4','5')");
            }
            else
            {
                strSql.AppendFormat(" And obr.STATE='{0}'", State);
            }

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
        /// 保存退货单记录对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void SaveOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdBuyerReturnModel model in Listmodel)
                    {
                        //退货单ID 
                        model.Id = base.GetClientId(logedinUser.HighId).ToString();
                        //退货单编号
                        model.Code = base.GetClientCode(logedinUser.HighId).ToString();
                        //保存退货单
                        SaveOrdBuyerReturnModel(model, logedinUser, transaction);
                        //保存退货单日志
                        SaveOrdBuyerReturnModel_LOG(model, logedinUser, transaction);
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        #region 保存退货单记录、退货单日志
        /// <summary>
        /// 保存退货单记录对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void SaveOrdBuyerReturnModel(OrdBuyerReturnModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_BUYER_RETURN(
                            id, 
                            data_product_id, 
                            project_id, 
                            code, 
                            RECEIVE_ID,
                            ORD_ID,
                            ORD_ITEM_ID,
                            project_product_id, 
                            buyer_id, 
                            buyer_name, 
                            buyer_name_abbr, 
                            saler_id, 
                            saler_name, 
                            saler_name_abbr, 
                            sender_id, 
                            sender_name, 
                            sender_name_abbr, 
                            manufacture_id, 
                            manufacture_name, 
                            manufacture_name_abbr, 
                            COMMON_NAME, 
                            product_name, 
                            product_code, 
                            goods_no, 
                            barcode, 
                            pbno, 
                            brand, 
                            spec_id, 
                            model_id, 
                            spec, 
                            model, 
                            send_batch_no, 
                            instore_batch_no, 
                            price, 
                            sum, 
                            BASE_MEASURE,
                            BASE_MEASURE_SPEC,
                            BASE_MEASURE_MATER,
                            SEND_MEASURE,
                            SEND_MEASURE_EX,
                            amount, 
                            state, 
                            send_operator_id, 
                            send_operator_name, 
                            send_operator_date, 
                            instore_operator_id, 
                            instore_operator_name, 
                            instore_operator_date, 
                            buyer_descriptions, 
                            create_user_id, 
                            create_user_name, 
                            create_date, 
                            modify_user_id, 
                            modify_user_name, 
                            modify_date, 
                            saler_descriptions,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("'{0}',", model.Code);
            strSql.AppendFormat("{0},", model.Receive_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Name);
            strSql.AppendFormat("'{0}',", model.Buyer_Name_Abbr);
            strSql.AppendFormat("{0},", model.Saler_Id);
            strSql.AppendFormat("'{0}',", model.Saler_Name);
            strSql.AppendFormat("'{0}',", model.Saler_Name_Abbr);
            strSql.AppendFormat("{0},", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("{0},", model.Manufacture_Id);
            strSql.AppendFormat("'{0}',", model.Manufacture_Name);
            strSql.AppendFormat("'{0}',", model.Manufacture_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Comm_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("{0},", model.Spec_Id);
            strSql.AppendFormat("{0},", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Sum);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mater);
            strSql.AppendFormat("'{0}',", model.Send_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Measure_Ex);
            strSql.AppendFormat("{0},", model.Amount);
            strSql.AppendFormat("'{0}',", model.State);
            strSql.AppendFormat("{0},", model.Send_Operator_Id);
            strSql.AppendFormat("'{0}',", model.Send_Operator_Name);
            strSql.AppendFormat("'{0}',", model.Send_Operate_Date);
            strSql.AppendFormat("{0},", model.Instore_Operator_Id);
            strSql.AppendFormat("'{0}',", model.Instore_Operator_Name);
            strSql.AppendFormat("'{0}',", model.Instore_Operate_Date);
            strSql.AppendFormat("'{0}',", model.Buyer_Descriptions);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", model.Saler_Descriptions);
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
        /// 保存退货单记录对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void SaveOrdBuyerReturnModel_LOG(OrdBuyerReturnModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_BUYER_RETURN_LOG(
                            id, 
                            data_product_id, 
                            project_id, 
                            code, 
                            RECEIVE_ID,
                            ORD_ID,
                            ORD_ITEM_ID,
                            project_product_id, 
                            buyer_id, 
                            buyer_name, 
                            buyer_name_abbr, 
                            saler_id, 
                            saler_name, 
                            saler_name_abbr, 
                            sender_id, 
                            sender_name, 
                            sender_name_abbr, 
                            manufacture_id, 
                            manufacture_name, 
                            manufacture_name_abbr, 
                            COMMON_NAME, 
                            product_name, 
                            product_code, 
                            goods_no, 
                            barcode, 
                            pbno, 
                            brand, 
                            spec_id, 
                            model_id, 
                            spec, 
                            model, 
                            send_batch_no, 
                            instore_batch_no, 
                            price, 
                            sum, 
                            BASE_MEASURE,
                            BASE_MEASURE_SPEC,
                            BASE_MEASURE_MATER,
                            SEND_MEASURE,
                            SEND_MEASURE_EX,
                            amount, 
                            state, 
                            send_operator_id, 
                            send_operator_name, 
                            send_operator_date, 
                            instore_operator_id, 
                            instore_operator_name, 
                            instore_operator_date, 
                            buyer_descriptions, 
                            create_user_id, 
                            create_user_name, 
                            create_date, 
                            modify_user_id, 
                            modify_user_name, 
                            modify_date, 
                            saler_descriptions,
                            OPERATOR_USER_ID,
                            OPERATOR_USER_NAME,
                            OPERATOR_DATE,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("'{0}',", model.Code);
            strSql.AppendFormat("{0},", model.Receive_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Name);
            strSql.AppendFormat("'{0}',", model.Buyer_Name_Abbr);
            strSql.AppendFormat("{0},", model.Saler_Id);
            strSql.AppendFormat("'{0}',", model.Saler_Name);
            strSql.AppendFormat("'{0}',", model.Saler_Name_Abbr);
            strSql.AppendFormat("{0},", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("{0},", model.Manufacture_Id);
            strSql.AppendFormat("'{0}',", model.Manufacture_Name);
            strSql.AppendFormat("'{0}',", model.Manufacture_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Comm_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("{0},", model.Spec_Id);
            strSql.AppendFormat("{0},", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Sum);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mater);
            strSql.AppendFormat("'{0}',", model.Send_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Measure_Ex);
            strSql.AppendFormat("{0},", model.Amount);
            strSql.AppendFormat("'{0}',", model.State);
            strSql.AppendFormat("{0},", model.Send_Operator_Id);
            strSql.AppendFormat("'{0}',", model.Send_Operator_Name);
            strSql.AppendFormat("'{0}',", model.Send_Operate_Date);
            strSql.AppendFormat("{0},", model.Instore_Operator_Id);
            strSql.AppendFormat("'{0}',", model.Instore_Operator_Name);
            strSql.AppendFormat("'{0}',", model.Instore_Operate_Date);
            strSql.AppendFormat("'{0}',", model.Buyer_Descriptions);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", model.Saler_Descriptions);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
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
        #endregion

        #region 修改退货单记录状态
        /// <summary>
        /// 修改退货单记录状态 '1' 未发送 '2' 已发送 '3' 已撤销 '4' 对方确认 '5' 对方拒绝
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        public void ModifyStateOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel, string State, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdBuyerReturnModel model in Listmodel)
                    {
                        ModifyStateOrdBuyerReturnModel(model, State,logedinUser, transaction);
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception ex)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 修改退货单记录    状态 '1' 未发送 '2' 已发送 '3' 已撤销 '4' 对方确认 '5' 对方拒绝
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void ModifyStateOrdBuyerReturnModel(OrdBuyerReturnModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_BUYER_RETURN 
                                   Set SYNC_STATE='0',
                                   State='{0}',
                                   AMOUNT={1},
                                   BUYER_DESCRIPTIONS='{2}',
                                   MODIFY_USER_ID={3},
                                   MODIFY_USER_NAME='{4}',
                                   MODIFY_DATE='{5}'
                                   Where Id='{6}'", 
                                   State, 
                                   model.Amount, 
                                   model.Buyer_Descriptions, 
                                   logedinUser.UserInfo.Id,
                                   logedinUser.UserInfo.Name,
                                   DateTime.Now.ToShortDateString(),
                                   model.Id);

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
        /// 修改退货单日志表记录    状态 '1' 未发送 '2' 已发送 '3' 已撤销 '4' 对方确认 '5' 对方拒绝
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void ModifyStateOrdBuyerReturnModel_LOG(OrdBuyerReturnModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_BUYER_RETURN_LOG 
                                   Set SYNC_STATE='0',
                                   State='{0}',
                                   AMOUNT={1},
                                   BUYER_DESCRIPTIONS='{2}',
                                   MODIFY_USER_ID={3},
                                   MODIFY_USER_NAME='{4}',
                                   MODIFY_DATE='{5}'
                                   Where Id='{6}'", 
                                   State, 
                                   model.Amount, 
                                   model.Buyer_Descriptions,
                                   logedinUser.UserInfo.Id,
                                   logedinUser.UserInfo.Name,
                                   DateTime.Now.ToString(),
                                   model.Id);

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

        #region 修改实退数量
        /// <summary>
        /// 修改实退数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void ModifyAmountOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdBuyerReturnModel model in Listmodel)
                    {
                        ModifyAmountOrdBuyerReturnModel(model, transaction);
                        ModifyAmountOrdBuyerReturnModel_LOG(model, transaction);
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        /// <summary>
        /// 修改实退数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        public void ModifyAmountOrdBuyerReturnModel(OrdBuyerReturnModel model, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("Update HC_ORD_BUYER_RETURN Set SYNC_STATE='0',AMOUNT={0},SUM={1} Where Id='{1}'", model.Amount,model.Sum,model.Id);

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
        /// 修改实退数量 日志表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        public void ModifyAmountOrdBuyerReturnModel_LOG(OrdBuyerReturnModel model, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("Update HC_ORD_BUYER_RETURN_LOG Set SYNC_STATE='0',AMOUNT={0},SUM={1} Where Id='{1}'", model.Amount, model.Sum, model.Id);

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

        #region 修改到货表数量
        /// <summary>
        /// 修改[到货表]中实退到货数量、实退到货金额
        /// </summary>
        /// <param name="Listmodel"></param>
        public void ModifyAmountOrdBuyerReturnModelToOrderReceive(List<OrdBuyerReturnModel> Listmodel)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdBuyerReturnModel model in Listmodel)
                    {
                        ModifyAmountOrdBuyerReturnModelToOrderReceive(model, transaction);
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception ex)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 修改[到货表]中实退到货数量、实退到货金额
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        public void ModifyAmountOrdBuyerReturnModelToOrderReceive(OrdBuyerReturnModel model, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("Update HC_ORD_ORDER_RECEIVE Set SYNC_STATE='0',RETURN_AMOUNT=isnull(RETURN_AMOUNT,0)+{0},RETURN_SUM=RETURN_SUM+{1} Where Id='{2}'", model.Amount, model.Sum, model.Receive_Id);

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

        #region 修改退货单标志 2 已发出 3 已撤销
        /// <summary>
        /// 修改退货单标志
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        public void SendOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel, string State, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdBuyerReturnModel model in Listmodel)
                    {
                        //修改退货单表中状态标记 '2'已发出 '3' 已撤销
                        ModifyStateOrdBuyerReturnModel(model, "2",logedinUser, transaction);
                        ModifyStateOrdBuyerReturnModel_LOG(model, "2",logedinUser, transaction);
                        //修改到货单表中已退数量、金额  由于流程变动，暂不修改到货单表
                        //ModifyAmountOrdBuyerReturnModelToOrderReceive(model, transaction);
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception ex)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw ex;
                }
            }
        }
        #endregion

    }
}
