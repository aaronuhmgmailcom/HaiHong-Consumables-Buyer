//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdSecondAyrlnvUseDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	二级库存使用（数据访问层）
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
    /// 二级库存使用（数据访问层）
    /// </summary>
    class OrdSecondAyrlnvUseDao : SqlDAOBase
    {
        private OrdSecondAyrlnvUseDao()
        : base()
        { }

        private OrdSecondAyrlnvUseDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdSecondAyrlnvUseDao GetInstance()
        {
            return new OrdSecondAyrlnvUseDao();
        }

        public static OrdSecondAyrlnvUseDao GetInstance(string connectionName)
        {
            return new OrdSecondAyrlnvUseDao(connectionName);
        }

        /// <summary>
        /// 保存二级使用库存对象
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="logedinUser"></param>
        public void SaveOrdSecondAyplnvModel(List<OrdSecondAyrlnvUseModel> Listmodel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdSecondAyrlnvUseModel model in Listmodel)
                    {
                        SaveOrdSecondAyplnvUseModel(model, logedinUser, transaction);

                        //当使用数量小于库存数量时：库存数量=库存数量-已使用数量
                        if (model.Stock_Num > model.Fact_Amount)
                        {
                            UpdateOrdSecondAyrlnv_StockNum(model, transaction);
                        }
                        else
                        {
                            //修改二级库存表 状态 置0
                            UseOddAudiDao.GetInstance().ModifyOrdSecondAyplnvState(model, "0", logedinUser, transaction);
                        }
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                }
            }
        }

        /// <summary>
        /// 修改二级库存库存数量
        /// </summary>
        private void UpdateOrdSecondAyrlnv_StockNum(OrdSecondAyrlnvUseModel model, DbTransaction transaction)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();

                strSql.AppendFormat("Update HC_ORD_SECOND_AYRLNV Set SYNC_STATE='0',NUM=NUM-{0} Where ID={1}", model.Fact_Amount, model.SecondId);

                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 保存二级使用库存对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void SaveOrdSecondAyplnvUseModel(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            string strID = base.GetClientId(logedinUser.HighId).ToString();

            strSql.Append(@"Insert Into HC_ORG_SECOND_AYRLNV_USE(
                            ID, 
                            SECOND_ID, 
                            DATA_PRODUCT_ID, 
                            PROJECT_ID, 
                            PROJECT_PRODUCT_ID, 
                            GOODS_NO, 
                            BARCODE, 
                            PBNO,
                            SEND_BATCH_NO,
                            INSTORE_BATCH_NO,
                            STORE_ROOM_ID,
                            STORE_ROOM_NAME,
                            ARRIVE_DATE, 
                            PRICE, 
                            FACT_AMOUNT, 
                            FACT_SUM, 
                            STATUS, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE,
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE,
                            DESCRIPTIONS,
                            BUYER_ID,
                            SENDER_ID,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", strID);
            strSql.AppendFormat("{0},", model.SecondId);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("{0},", model.Store_Room_Id);
            strSql.AppendFormat("'{0}',", model.Store_Room_Name);
            strSql.AppendFormat("'{0}',", model.Arrive_Date);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum.ToString());
            strSql.AppendFormat("'{0}',", model.Status);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", model.Descriptions);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("{0},", model.Sender_Id);
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
        /// 修改二级使用库存状态 0 删除 1 使用 2 审核通过
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdSecondAyplnvUseState(List<OrdSecondAyrlnvUseModel> Listmodel, string State, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdSecondAyrlnvUseModel model in Listmodel)
                    {
                        ModifyOrdSecondAyplnvUseState(model, State, logedinUser, transaction);
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
        /// 修改二级使用库存状态 0 删除 1 使用 2 审核通过
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void ModifyOrdSecondAyplnvUseState(OrdSecondAyrlnvUseModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORG_SECOND_AYRLNV_USE
                                    Set SYNC_STATE='0',STATUS='{0}',MODIFY_USER_ID='{1}',MODIFY_USER_NAME='{2}',MODIFY_DATE='{3}'
                                    Where ID={4}", State, logedinUser.UserInfo.Id, logedinUser.UserInfo.Name, DateTime.Now.ToString(), model.Id);

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 作发货流程（发货单确认、使用单审核中使用）
        /// <summary>
        /// 【发货流程】  操作表有（采购单、采购单明细、订单表、订单明细、备货表、到货表、订单结果表、日志）
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="ordPurchaseModel"></param>
        /// <param name="logedinUser"></param>
        public void OrdInvoiceFrom(List<OrdSecondAyrlnvUseModel> Listmodel, OrdPurchaseModel ordPurchaseModel, OrdOrderModel ordOrderModel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    //保存到采购单表------------------------------------------------------
                    //生成采购单ID
                    ordPurchaseModel.Id = base.GetClientId(logedinUser.HighId).ToString();
                    //生成采购单编号
                    ordPurchaseModel.Code = base.GetClientCode(logedinUser.HighId).ToString();

                    OrdPurchaseDao.GetInstance().SaveOrdPurchaseModel(ordPurchaseModel, logedinUser, transaction);
                    //--------------------------------------------------------------------

                    //定义订单金额
                    decimal total_Num = 0;

                    //保存到采购单明细、订单明细表、到货单、订单备货表、订单结果表--------
                    foreach (OrdSecondAyrlnvUseModel model in Listmodel)
                    {
                        model.Purchase_Id = ordPurchaseModel.Id;    //采购单ID
                        //生成采购单明细ID
                        model.Purchase_Item_Id = base.GetClientId(logedinUser.HighId).ToString();
                        //保存到【采购单明细表】
                        SaveOrdPurchaseItemModel(model, logedinUser, transaction);

                        //保存到【订单表】--拆单操作--
                        total_Num += model.Fact_Sum;
                        if (model.Start_Sender_Flag)//该配送商下的明细是否开始，是则作生成订单操作
                        {

                            //保存到订单表-----------------------------------------------------------------------
                            //生成订单ID
                            ordOrderModel.Id = base.GetClientId(logedinUser.HighId).ToString();
                            //订单编号
                            ordOrderModel.Code = base.GetClientCode(logedinUser.HighId).ToString();
                            ordOrderModel.Purchase_Id = ordPurchaseModel.Id;
                            ordOrderModel.Purchase_Code = ordPurchaseModel.Code;
                            ordOrderModel.Sender_Id = model.Sender_Id;
                            ordOrderModel.Sender_Name = model.Sender_Name;
                            ordOrderModel.Sender_Name_Abbr = model.Sender_Name_Abbr;

                            OrdOrderDao.GetInstance().SaveOrdOrderModel(ordOrderModel, logedinUser, transaction);
                        }
                        if (model.Over_Sender_Flag)
                        {
                            ordOrderModel.Total_Sum = total_Num;
                            ordOrderModel.Over_Sum = total_Num;
                            //更新金额
                            OrdOrderDao.GetInstance().EditSumOrdOrderModel(ordOrderModel, transaction);
                            total_Num = 0;          //生成一订单，总金额清0

                            //保存到【订单表日志表】
                            OrdOrderDao.GetInstance().SaveOrdOrderModel_LOG(ordOrderModel, logedinUser, transaction);
                        }
                        //----------------------------------------------------------------------------------
                        //保存到【订单明细表】
                        model.Order_Id = ordOrderModel.Id;                                      //订单ID
                        model.Order_Item_Id = base.GetClientId(logedinUser.HighId).ToString();  //生成订单明细ID
                        SaveOrdOrderItemModel(model, logedinUser, transaction);
                        
                        //保存到【订单明细日志表】
                        SaveOrdOrderItemModel_LOG(model,logedinUser, transaction);
                        
                        //保存到【订单备货表】
                        model.Stockup_Id = base.GetClientId(logedinUser.HighId).ToString();     //订单备货ID
                        SaveOrdOrderStockUpModel(model, logedinUser, transaction);

                        //保存到【订单备货日志表】
                        SaveOrdOrderStockUpModel_LOG(model, logedinUser, transaction);

                        //保存到【到货单】
                        model.Receive_Id = base.GetClientId(logedinUser.HighId).ToString();     //到货单ID
                        model.Receive_Code = base.GetClientCode(logedinUser.HighId).ToString(); //到货单编码
                        model.Receive_Type = ordOrderModel.Type;//发货类型
                        SaveOrdOrderReceiveModel(model, logedinUser, transaction);

                        //保存到【到货单日志】
                        SaveOrdOrderReceiveModel_LOG(model, logedinUser, transaction);

                        //保存到【订单结果表】
                        SaveOrdOrderResultModel(model, logedinUser, transaction);
                    }
                    //--------------------------------------------------------------------

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

        #region 保存采购单明细表

        /// <summary>
        /// 保存采购单明细表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdPurchaseItemModel(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

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
					        SPEC_ID,
					        MODEL_ID,
                            SEND_MEASURE,
                            SEND_MEASURE_EX,
                            SPEC, 
                            MODEL, 
                            BRAND, 
                            GOODS_NO, 
                            BARCODE, 
                            STORE_ROOM_ID,
                            STORE_ROOM_NAME,
                            BASE_MEASURE, 
                            BASE_MEASURE_SPEC, 
                            BASE_MEASURE_MATER, 
                            RETAIL_PRICE, 
                            TRADE_PRICE, 
                            AMOUNT, 
                            SUM,
                            OVER_AMOUNT, 
                            OVER_SUM, 
                            IS_QUICKSEND, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE, 
                            DESCRIPTIONS, 
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Purchase_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Purchase_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("{0},", model.Saler_Id);
            strSql.AppendFormat("'{0}',", model.Saler_Name);
            strSql.AppendFormat("'{0}',", model.Saler_Name_Abbr);
            strSql.AppendFormat("{0},", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("{0},", model.Manu_Id);
            strSql.AppendFormat("'{0}',", model.Manu_Name);
            strSql.AppendFormat("'{0}',", model.Manu_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Common_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Spec_Id);
            strSql.AppendFormat("'{0}',", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Send_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Measure_Ex);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Store_Room_Id);
            strSql.AppendFormat("'{0}',", model.Store_Room_Name);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mate);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.Append("'0',");
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToShortDateString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToShortDateString());
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

#endregion

        #region 保存订单明细表、订单明细日志表
        /// <summary>
        /// 保存订单明细表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderItemModel(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_ORDER_ITEM
                            (
                            ID, 
                            PROJECT_ID, 
                            ORDER_ID, 
                            PURCHASE_ID, 
                            PURCHASE_ITEM_ID,
                            DATA_PRODUCT_ID, 
                            PROJECT_PROD_ID, 
                            BUYER_ID, 
                            BUYER_NAME, 
                            BUYER_NAME_ABBR, 
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
                            SPEC_ID,
                            MODEL_ID,
                            SEND_MEASURE,
                            SEND_MEASURE_EX,
                            SPEC, 
                            MODEL, 
                            BRAND, 
                            GOODS_NO, 
                            BARCODE, 
                            STORE_ROOM_ID,
                            STORE_ROOM_NAME,
                            BASE_MEASURE_SPEC, 
                            BASE_MEASURE_MATER, 
                            BASE_MEASURE, 
                            RETAIL_PRICE, 
                            TRADE_PRICE, 
                            SUM, 
                            AMOUNT, 
                            OVER_AMOUNT, 
                            OVER_SUM, 
                            IS_QUICKSEND, 
                            ORDER_TYPE, 
                            STATE, 
                            BUYER_DESCRIPTIONS, 
                            SALER_DESCRIPTIONS, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME,
                            MODIFY_DATE, 
                            ORIGINAL_ITEM_ID,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Purchase_Id);
            strSql.AppendFormat("{0},", model.Purchase_Item_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
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
            strSql.AppendFormat("{0},", model.Manu_Id);
            strSql.AppendFormat("'{0}',", model.Manu_Name);
            strSql.AppendFormat("'{0}',", model.Manu_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Common_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Spec_Id);
            strSql.AppendFormat("'{0}',", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Send_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Measure_Ex);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Store_Room_Id);
            strSql.AppendFormat("'{0}',", model.Store_Room_Name);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mate);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.Append("'0',");//是否紧急
            strSql.Append("'1',");//订单类型
            strSql.Append("'5',");//订单明细状态
            strSql.AppendFormat("'{0}',", "");
            strSql.AppendFormat("'{0}',", "");
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", model.Order_Item_Id);//源订单明细ID  
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
        /// 保存订单明细表（日志）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderItemModel_LOG(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_ORDER_ITEM_LOG
                            (
                            ID, 
                            PROJECT_ID, 
                            ORDER_ID, 
                            PURCHASE_ID, 
                            PURCHASE_ITEM_ID,
                            DATA_PRODUCT_ID, 
                            PROJECT_PROD_ID, 
                            BUYER_ID, 
                            BUYER_NAME, 
                            BUYER_NAME_ABBR, 
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
                            SPEC_ID,
                            MODEL_ID,
                            SEND_MEASURE,
                            SEND_MEASURE_EX,
                            SPEC, 
                            MODEL, 
                            BRAND, 
                            GOODS_NO, 
                            BARCODE, 
                            STORE_ROOM_ID,
                            STORE_ROOM_NAME,
                            BASE_MEASURE_SPEC, 
                            BASE_MEASURE_MATER, 
                            BASE_MEASURE, 
                            RETAIL_PRICE, 
                            TRADE_PRICE, 
                            SUM, 
                            AMOUNT, 
                            OVER_AMOUNT, 
                            OVER_SUM, 
                            IS_QUICKSEND, 
                            ORDER_TYPE, 
                            STATE, 
                            BUYER_DESCRIPTIONS, 
                            SALER_DESCRIPTIONS, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME,
                            MODIFY_DATE, 
                            ORIGINAL_ITEM_ID,
                            SYNC_STATE,
                            OPERATOR_USER_ID,
                            OPERATOR_USER_NAME,
                            OPERATOR_DATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Purchase_Id);
            strSql.AppendFormat("{0},", model.Purchase_Item_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
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
            strSql.AppendFormat("{0},", model.Manu_Id);
            strSql.AppendFormat("'{0}',", model.Manu_Name);
            strSql.AppendFormat("'{0}',", model.Manu_Name_Abbr);
            strSql.AppendFormat("'{0}',", model.Common_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Spec_Id);
            strSql.AppendFormat("'{0}',", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Send_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Measure_Ex);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Store_Room_Id);
            strSql.AppendFormat("'{0}',", model.Store_Room_Name);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mate);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.Append("'0',");//是否紧急
            strSql.Append("'1',");//订单类型
            strSql.Append("'5',");//订单明细状态
            strSql.AppendFormat("'{0}',", "");
            strSql.AppendFormat("'{0}',", "");
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", model.Order_Item_Id);//源订单明细ID  
            strSql.Append("'0',");
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
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
        #endregion

        #region 保存到货单表 及到货单日志表
        /// <summary>
        /// 保存到货单表 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderReceiveModel(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_ORDER_RECEIVE
                            (
                            ID, 
                            DATA_PRODUCT_ID, 
                            PROJECT_ID, 
                            STOCKUP_ID,
                            TYPE, 
                            CODE, 
                            PROJECT_PRODUCT_ID, 
                            ORDER_ID, 
                            ORDER_ITEM_ID, 
                            GOODS_NO, 
                            BARCODE, 
                            PBNO, 
                            SEND_BATCH_NO, 
                            INSTORE_BATCH_NO, 
                            ARRIVAL_ADDRESS, 
                            ARRIVE_DATE, 
                            PRICE, 
                            FACT_AMOUNT, 
                            FACT_SUM, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE,
                            DESCRIPTIONS, 
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Receive_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Stockup_Id);
            strSql.AppendFormat("{0},", model.Receive_Type);//到货类型
            strSql.AppendFormat("'{0}',", model.Receive_Code);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("'{0}',", model.Arrival_Address);
            strSql.AppendFormat("'{0}',", model.Arrive_Date);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
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

        /// <summary>
        /// 保存到货单表 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderReceiveModel_LOG(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_ORDER_RECEIVE_LOG
                            (
                            ID, 
                            DATA_PRODUCT_ID, 
                            PROJECT_ID, 
                            STOCKUP_ID,
                            TYPE, 
                            CODE, 
                            PROJECT_PRODUCT_ID, 
                            ORDER_ID, 
                            ORDER_ITEM_ID, 
                            GOODS_NO, 
                            BARCODE, 
                            PBNO, 
                            SEND_BATCH_NO, 
                            INSTORE_BATCH_NO, 
                            ARRIVAL_ADDRESS, 
                            ARRIVE_DATE, 
                            PRICE, 
                            FACT_AMOUNT, 
                            FACT_SUM, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE,
                            DESCRIPTIONS, 
                            OPERATOR_USER_ID,
                            OPERATOR_USER_NAME,
                            OPERATOR_DATE,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Receive_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Stockup_Id);
            strSql.AppendFormat("{0},", model.Receive_Type);//到货类型
            strSql.AppendFormat("'{0}',", model.Receive_Code);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("'{0}',", model.Arrival_Address);
            strSql.AppendFormat("'{0}',", model.Arrive_Date);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", model.Descriptions);
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

        #region 保存订单结果表
        /// <summary>
        /// 保存订单结果表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderResultModel(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            string strID = base.GetClientId(logedinUser.HighId).ToString();

            strSql.Append(@"Insert Into HC_ORD_ORDER_RESULT
                            (
                            ID, 
                            DATA_PRODUCT_ID, 
                            PROJECT_ID, 
                            PROJECT_PRODUCT_ID, 
                            ORDER_ID, 
                            ORDER_ITEM_ID, 
                            RECEIVE_ID, 
                            RESULT_TYPE, 
                            TYPE, 
                            CODE, 
                            BUYER_ID, 
                            BUYER_NAME, 
                            BUYER_NAME_ABBR, 
                            SALER_ID, 
                            SALER_NAME, 
                            SALER_NAME_ABBR, 
                            SENDER_ID, 
                            SENDER_NAME, 
                            SENDER_NAME_ABBR, 
                            MANUFACTURE_ID, 
                            MANUFACTURE_NAME, 
                            MANUFACTURE_NAME_ABBR, 
                            PRODUCT_NAME, 
                            PRODUCT_CODE, 
                            SPEC_ID,
                            MODEL_ID,
                            SEND_MEASURE,
                            SEND_MEASURE_EX,
                            SPEC, 
                            MODEL, 
                            COMMON_NAME, 
                            BRAND, 
                            GOODS_NO, 
                            BARCODE, 
                            STORE_ROOM_ID,
                            STORE_ROOM_NAME,
                            PBNO, 
                            BASE_MEASURE_SPEC, 
                            BASE_MEASURE_MATER, 
                            BASE_MEASURE, 
                            SEND_BATCH_NO, 
                            INSTORE_BATCH_NO, 
                            ARRIVAL_ADDRESS, 
                            ARRIVE_DATE, 
                            PRICE, 
                            FACT_AMOUNT, 
                            FACT_SUM, 
                            STATE, 
                            SEND_OPERATOR_ID, 
                            SEND_OPERATOR_NAME, 
                            SEND_OPERATOR_DATE, 
                            INSTORE_OPERATOR_ID, 
                            INSTORE_OPERATOR_NAME, 
                            INSTORE_OPERATOR_DATE, 
                            BACK_AMOUNT, 
                            BACK_SUM, 
                            DESCRIPTIONS,
                            CREATE_USER_ID,
                            CREATE_USER_NAME,
                            CREATE_DATE,
                            MODIFY_USER_ID,
                            MODIFY_USER_NAME,
                            MODIFY_DATE,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", strID);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Receive_Id);
            strSql.Append("'3',");//结果类型
            strSql.AppendFormat("'{0}',", model.Receive_Type);//到货类型
            strSql.AppendFormat("'{0}',", model.Receive_Code);
            strSql.AppendFormat("{0},", model.Buyer_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Name);
            strSql.AppendFormat("'{0}',", model.Buyer_Name_Abbr);
            strSql.AppendFormat("{0},", model.Saler_Id);
            strSql.AppendFormat("'{0}',", model.Saler_Name);
            strSql.AppendFormat("'{0}',", model.Saler_Name_Abbr);
            strSql.AppendFormat("{0},", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Sender_Name_Abbr);
            strSql.AppendFormat("{0},", model.Manu_Id);
            strSql.AppendFormat("'{0}',", model.Manu_Name);
            strSql.AppendFormat("'{0}',", model.Manu_Name_Abbr);;
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Product_Code);
            strSql.AppendFormat("'{0}',", model.Spec_Id);
            strSql.AppendFormat("'{0}',", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Send_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Measure_Ex);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Common_Name);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Store_Room_Id);
            strSql.AppendFormat("'{0}',", model.Store_Room_Name);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mate);
            strSql.AppendFormat("'{0}',", model.Base_Measure);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("'{0}',", model.Arrival_Address);
            strSql.AppendFormat("'{0}',", model.Arrive_Date);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.AppendFormat("{0},", model.Fact_Sum);
            strSql.AppendFormat("'1',");//到货单状态
            strSql.AppendFormat("{0},", model.Send_Operator_Id);
            strSql.AppendFormat("'{0}',", model.Send_Operator_Name);
            strSql.AppendFormat("'{0}',", model.Send_Operate_Date);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.Append("0,");
            strSql.Append("0,");
            strSql.AppendFormat("'{0}',", model.Descriptions);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
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

        #region 保存订单备货表、订单备货表日志
        /// <summary>
        /// 保存订单备货表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderStockUpModel(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            string strID = base.GetClientId(logedinUser.HighId).ToString();

            strSql.Append(@"Insert Into HC_ORD_ORDER_STOCKUP
                            (
                            ID, 
                            DATA_PRODUCT_ID, 
                            PROJECT_ID, 
                            ORDER_ID, 
                            ORDER_ITEM_ID, 
                            PROJECT_PROD_ID, 
                            STOCKUP_QTY, 
                            READY_FLAG, 
                            GOODS_NO, 
                            BARCODE, 
                            PBNO, 
                            SEND_BATCH_NO, 
                            INSTORE_BATCH_NO, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE,
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");

            strSql.AppendFormat("{0},", model.Stockup_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.Append("'1',");//备货状态
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
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

        /// <summary>
        /// 保存订单备货表（日志）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <param name="transaction"></param>
        public void SaveOrdOrderStockUpModel_LOG(OrdSecondAyrlnvUseModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            string strID = base.GetClientId(logedinUser.HighId).ToString();

            strSql.Append(@"Insert Into HC_ORD_ORDER_STOCKUP_LOG
                            (
                            ID, 
                            DATA_PRODUCT_ID, 
                            PROJECT_ID, 
                            ORDER_ID, 
                            ORDER_ITEM_ID, 
                            PROJECT_PROD_ID, 
                            STOCKUP_QTY, 
                            READY_FLAG, 
                            GOODS_NO, 
                            BARCODE, 
                            PBNO, 
                            SEND_BATCH_NO, 
                            INSTORE_BATCH_NO, 
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

            strSql.AppendFormat("{0},", model.Stockup_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Order_Id);
            strSql.AppendFormat("{0},", model.Order_Item_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Fact_Amount);
            strSql.Append("'1',");//备货状态
            strSql.AppendFormat("'{0}',", model.Goods_No);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.Append("'0',");
            strSql.AppendFormat("{0},", logedinUser.UserInfo.Id);
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
        #endregion

    }
}
