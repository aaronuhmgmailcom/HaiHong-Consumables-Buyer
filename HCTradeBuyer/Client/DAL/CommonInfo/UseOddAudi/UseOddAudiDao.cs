//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	UseOddAudiDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	使用单审核（数据访问层）
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
    /// 使用单审核（数据访问层）
    /// </summary>
    class UseOddAudiDao : SqlDAOBase
    {
        private UseOddAudiDao()
        : base()
        { }

        private UseOddAudiDao(string connectionName)
        : base(connectionName)
        { }

        public static UseOddAudiDao GetInstance()
        {
            return new UseOddAudiDao();
        }

        public static UseOddAudiDao GetInstance(string connectionName)
        {
            return new UseOddAudiDao(connectionName);
        }

        /// <summary>
        /// 获取库存商品列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdSecondAyplnvList(LogedInUser logedinUser)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select Tab.*,ohc.STORE_ROOM_ID,
                            ohc.STORE_ROOM_NAME,ohc.ID As ordHitCommId From
                            (
                            Select 
                            '0' As Sel,
                            osa.ID,
                            op.id As PROJECT_PROD_ID,
                            op.DATA_PRODUCT_ID,
                            op.CONT_PRODUCT_ID,
                            op.PROJECT_ID,
                            op.COMMERCE_NAME,
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            op.CODE,
                            op.GOODS_NO,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            op.BASE_MEASURE,
                            op.BASE_MEASURE_SPEC,
                            op.BASE_MEASURE_MATER,
                            op.MAX_PRICE,
                            osi.SPEC_ID,
                            osi.MODEL_ID,
                            osi.SPEC,
                            osi.MODEL,
                            isnull(osi.BRAND,'-') As BRAND,
                            osa.CREATE_DATE,
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
                            op.PRICE,
                            '' As FACT_AMOUNT,
                            op.DEFAULT_MEASURE,
                            op.DEFAULT_MEASURE_EX,
                            op.INSTRU_CODE,
                            op.INSTRU_NAME,
                            op.REG_NO,
                            op.REG_VALID_DATE,
                            isnull(osa.BATCH_NO,'-') As BATCH_NO,
                            isNull(convert(varchar,osa.VALID_DATE,23),'-') As VALID_DATE,
                            isnull(osa.PBNO,'-') As PBNO,
                            osa.SEND_BATCH_NO,
                            osa.INSTORE_BATCH_NO,
                            isnull(osi.BARCODE,'-') As BARCODE,
                            osa.NUM,
                            ost.BUYER_ID
                            From HC_ORD_SECOND_AYRLNV osa,HC_ORD_ORD_STOCK_ITEM osi,HC_ORD_ORD_STOCK ost,HC_ORD_PRODUCT op,HC_ORG org1,HC_ORG org2,HC_ORG org3
                            where osa.STOCK_ITEM_ID=osi.Id and op.id=osa.PROJECT_PRODUCT_ID And osa.state <> '0'
                            And osa.SENDER_ID=org1.ID And osa.SALER_ID=org2.ID And op.MANU_ID=org3.ID And ost.id=osi.STOCK_ID And ost.BUYER_ID=@Buyer_ID
                            ) As Tab Left Join HC_ORD_HIT_COMM ohc
                            on Tab.PROJECT_ID=ohc.PROJECT_ID and Tab.PROJECT_PROD_ID=ohc.PROJECT_PROD_ID and Tab.SPEC_ID=ohc.SPEC_ID and Tab.MODEL_ID=ohc.MODEL_ID 
                            ");

            strSql.Append(" Order By Tab.CREATE_DATE Desc");
            
            if (!string.IsNullOrEmpty(logedinUser.UserOrg.Id))
            {
                DbParameter strBuyerId = DbFacade.CreateParameter();
                strBuyerId.ParameterName = "Buyer_ID";
                strBuyerId.DbType = DbType.String;
                strBuyerId.Value = logedinUser.UserOrg.Id;
                parameters.Add(strBuyerId);
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
        /// 获取消耗商品列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetConsumeCommList()
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            '0' As Sel,
                            osau.ID,
                            op.DATA_PRODUCT_ID,
                            op.ID As PROJECT_PRODUCT_ID,
                            osau.PROJECT_ID,
                            op.Code As PRODUCT_CODE,
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            osau.GOODS_NO,
                            osa.SPEC_ID,
                            osa.MODEL_ID,
                            op.DEFAULT_MEASURE,
                            op.DEFAULT_MEASURE_EX,
                            osi.SPEC,
                            osi.MODEL,
                            isnull(osi.BRAND,'-') As BRAND,
                            isnull(osa.BATCH_NO,'-') As BATCH_NO,
                            osau.PRICE,
                            osa.Num,
                            osau.FACT_AMOUNT,
                            op.DEFAULT_MEASURE,
                            isnull(osau.BARCODE,'-') As BARCODE,
                            isnull(osau.PBNO,'-') As PBNO,
							osau.SEND_BATCH_NO,
							osau.INSTORE_BATCH_NO,
                            op.BASE_MEASURE,
                            op.BASE_MEASURE_SPEC,
                            op.BASE_MEASURE_MATER,
                            isNull(convert(varchar,osa.VALID_DATE,23),'-') As VALID_DATE,
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
                            osau.STATUS,
                            osau.STORE_ROOM_ID,
                            osau.STORE_ROOM_NAME,
                            (case osau.STATUS when '1' then '使用' when '2' then '审核通过' end) As StatusName,
                            osau.CREATE_DATE,
                            osi.CREATE_USER_ID As Send_Operator_Id,
                            osi.CREATE_USER_NAME As Send_Operator_Name,
                            osi.CREATE_DATE As Send_Operate_Date
                            From HC_ORG_SECOND_AYRLNV_USE osau,HC_ORD_SECOND_AYRLNV osa,HC_ORD_ORD_STOCK_ITEM osi,
                            HC_ORD_PRODUCT op,HC_ORG org1,HC_ORG org2,HC_ORG org3
                            Where osa.STOCK_ITEM_ID=osi.ID And osa.PROJECT_PRODUCT_ID=osi.PROJECT_PROD_ID 
                            And osa.id = osau.SECOND_ID And osa.PROJECT_PRODUCT_ID=osau.PROJECT_PRODUCT_ID
                            And op.Id=osa.PROJECT_PRODUCT_ID
                            And org1.ID=osa.SENDER_ID And org2.ID=osa.SALER_ID And org3.ID=osi.MANUFACTURE_ID
                            And osau.STATUS <> '0'");

            strSql.Append(" Order By osau.CREATE_DATE DESC");

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
        /// 修改二级库存表信息 状态置为 0 （状态：0	禁用  ,1 正常）
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdSecondAyplnvModel(List<OrdSecondAyrlnvUseModel> Listmodel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdSecondAyrlnvUseModel model in Listmodel)
                    {
                        ModifyOrdSecondAyplnvState(model, "0", logedinUser, transaction);
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
        /// 修改二级库存表状态 （状态：0 禁用 1 正常）
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void ModifyOrdSecondAyplnvState(OrdSecondAyrlnvUseModel model, string State, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update HC_ORD_SECOND_AYRLNV
                                    Set SYNC_STATE='0',STATE='{0}',MODIFY_USER_ID='{1}',MODIFY_USER_NAME='{2}',MODIFY_DATE='{3}'
                                    Where ID='{4}'", State, logedinUser.UserInfo.Id, logedinUser.UserInfo.Name, DateTime.Now.ToString(), model.SecondId);

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
