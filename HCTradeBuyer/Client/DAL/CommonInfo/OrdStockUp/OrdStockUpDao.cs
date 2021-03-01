//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdStockUpDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单确认（数据访问类）
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
    /// 备货单确认（数据访问类）
    /// </summary>
    class OrdStockUpDao : SqlDAOBase
    {
        private OrdStockUpDao()
        : base()
        { }

        private OrdStockUpDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdStockUpDao GetInstance()
        {
            return new OrdStockUpDao();
        }

        public static OrdStockUpDao GetInstance(string connectionName)
        {
            return new OrdStockUpDao(connectionName);
        }

        /// <summary>
        /// 获取备货单列表信息
        /// </summary>
        /// <param name="logedinUser"></param>
        /// <returns></returns>
        public DataTable GetStockUpList(LogedInUser logedinUser)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            hoos.ID,
                            hoos.CODE,
                            hoos.BUYER_ID,
                            org1.ID As SENDER_ID,
                            org1.ORG_NAME As SENDER_NAME,
                            org1.ORG_ABBR As SENDER_NAME_ABBR,
                            org1.SPELL_ABBR As SENDER_NAME_SPELL_ABBR,
                            org1.ORG_NAME_WB As SENDER_NAME_WB,
                            hoos.CREATE_USER_NAME,
                            hoos.CREATE_DATE,
                            hoos.STATE,
                            (case hoos.STATE when '1' then '未发出' when '2' then '已发出' when '3' then '买方已确认' when '4' then '作废' when '5' then '确认中' when '6' then '完成' end) As StateName
                            From HC_ORD_ORD_STOCK hoos,Hc_org org1
                            Where org1.ID=hoos.SENDER_ID And hoos.STATE<>'1'");

            if (!string.IsNullOrEmpty(logedinUser.UserOrg.Id))
            {
                strSql.Append(" And hoos.BUYER_ID=@Buyer_ID");
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
        /// 设置备货单状态
        /// </summary>
        /// <param name="stock_Id"></param>
        public void SetOrdStockUpState(string stock_Id,string State,string ItemState)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update HC_ORD_ORD_STOCK ");
            strSql.Append("Set ");
            strSql.Append(" SYNC_STATE='0',");
            strSql.AppendFormat("STATE='{0}'", State);
            strSql.AppendFormat(" Where ID='{0}'", stock_Id);
            
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);

                    //修改明细中状态
                    if (!string.IsNullOrEmpty(ItemState))
                    {
                        OrdStockUpItemDao.GetInstance().SetOrdStockUpItemStateByStockId(stock_Id, ItemState, transaction);
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

        #region 获取备货单记录对象 根据备货单ID

        /// <summary>
        /// 根据备货单ID 获取备货单记录对象
        /// </summary>
        /// <param name="stock_Id"></param>
        public OrdStockUpModel GetOrdStockUpModel(string stock_Id)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            hoos.ID,
                            hoos.CODE,
                            hoos.BUYER_ID,
                            hoos.SENDER_ID,
                            hoos.SENDER_NAME,
                            hoos.SENDER_NAME_ABBR,
                            hoos.CREATE_USER_NAME,
                            hoos.CREATE_DATE,
                            (case hoos.STATE when '1' then '未发送' when '2' then '已发送' when '3' then '买方已确认' when '4' then '作废' when '5' then '确认中' when '6' then '完成' end) As StateName
                            From HC_ORD_ORD_STOCK As hoos
                            Where 1=1");

            if (!string.IsNullOrEmpty(stock_Id))
            {
                strSql.Append(" And hoos.ID=@stock_Id");
                DbParameter strStock_Id = DbFacade.CreateParameter();
                strStock_Id.ParameterName = "stock_Id";
                strStock_Id.DbType = DbType.String;
                strStock_Id.Value = stock_Id;
                parameters.Add(strStock_Id);
            }
            else
            {
                return null;
            }

            OrdStockUpModel model = null;

            model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(StockUpModel), parameters.ToArray()) as OrdStockUpModel;

            return model;
        }

        /// <summary>
        /// 采购备货单信息对象
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="row">The row number.</param>
        /// <returns></returns>
        private object StockUpModel(IDataReader reader, int row)
        {
            OrdStockUpModel model = new OrdStockUpModel();

            model.Id = Convert.ToString(reader["ID"]);
            model.Code = Convert.ToString(reader["CODE"]);
            model.Sender_Id = Convert.ToString(reader["SENDER_ID"]);
            model.Sender_Name = Convert.ToString(reader["SENDER_NAME"]);
            model.Sender_Name_Abbr = Convert.ToString(reader["SENDER_NAME_ABBR"]);
            model.Create_Date = Convert.ToString(reader["CREATE_DATE"]);
            model.State_Name = Convert.ToString(reader["StateName"]);
            model.Create_User_Name = Convert.ToString(reader["CREATE_USER_NAME"]);

            return model;
        }

        #endregion

    }
}
