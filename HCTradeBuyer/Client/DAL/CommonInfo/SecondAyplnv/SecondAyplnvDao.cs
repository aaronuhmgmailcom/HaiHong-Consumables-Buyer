//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	SecondAyplnvDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	二级库存（数据访问类）
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
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 二级库存（数据访问类）
    /// </summary>
    class SecondAyplnvDao : SqlDAOBase
    {
        private SecondAyplnvDao()
        : base()
        { }

        private SecondAyplnvDao(string connectionName)
        : base(connectionName)
        { }

        public static SecondAyplnvDao GetInstance()
        {
            return new SecondAyplnvDao();
        }

        public static SecondAyplnvDao GetInstance(string connectionName)
        {
            return new SecondAyplnvDao(connectionName);
        }

        /// <summary>
        /// 保存二级库存对象列表
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void SaveOrdSecondAyplnvModel(List<OrdSecondAyplnvModel> Listmodel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdSecondAyplnvModel model in Listmodel)
                    {
                        SaveOrdSecondAyplnvModel(model, logedinUser, transaction);
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
        /// 保存二级库存对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void SaveOrdSecondAyplnvModel(OrdSecondAyplnvModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            string strID = base.GetClientId(logedinUser.HighId).ToString();

            strSql.Append(@"Insert Into HC_ORD_SECOND_AYRLNV(
                            ID, 
                            DATA_PRODUCT_ID, 
                            STOCK_ITEM_ID,
                            PROJECT_ID, 
                            BUYER_ID, 
                            SALER_ID, 
                            SENDER_ID, 
                            SENDER_NAME,
                            PBNO,
                            SEND_BATCH_NO,
                            INSTORE_BATCH_NO, 
                            PROJECT_PRODUCT_ID, 
                            SPEC_ID, 
                            MODEL_ID, 
                            BARCODE, 
                            PRICE, 
                            BATCH_NO, 
                            VALID_DATE, 
                            NUM, 
                            REMARK, 
                            STATE, 
                            CREATE_USER_ID, 
                            CREATE_USER_NAME, 
                            CREATE_DATE, 
                            MODIFY_USER_ID, 
                            MODIFY_USER_NAME, 
                            MODIFY_DATE, 
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("'{0}',", strID);
            strSql.AppendFormat("'{0}',", model.Data_Product_Id);
            strSql.AppendFormat("'{0}',", model.Stock_Item_Id);
            strSql.AppendFormat("'{0}',", model.Project_Id);
            strSql.AppendFormat("'{0}',", model.Buyer_Id);//买方ID
            strSql.AppendFormat("'{0}',", model.Saler_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Name);
            strSql.AppendFormat("'{0}',", model.Pbno);
            strSql.AppendFormat("'{0}',", model.Send_Batch_No);
            strSql.AppendFormat("'{0}',", model.Instore_Batch_No);
            strSql.AppendFormat("'{0}',", model.Project_Product_Id);
            strSql.AppendFormat("'{0}',", model.Spec_Id);
            strSql.AppendFormat("'{0}',", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("{0},", model.Price);
            strSql.AppendFormat("'{0}',", model.Batch_No);
            strSql.AppendFormat("'{0}',", model.Valid_Date);
            strSql.AppendFormat("{0},", model.Num);
            strSql.AppendFormat("'{0}',", model.Remark);
            strSql.AppendFormat("'{0}',", "1");
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
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
