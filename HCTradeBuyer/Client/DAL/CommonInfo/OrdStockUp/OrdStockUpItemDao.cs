//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdStockUpItemDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单明细（数据访问类）
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

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 备货单明细（数据访问类）
    /// </summary>
    class OrdStockUpItemDao : SqlDAOBase
    {
        private OrdStockUpItemDao()
        : base()
        { }

        private OrdStockUpItemDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdStockUpItemDao GetInstance()
        {
            return new OrdStockUpItemDao();
        }

        public static OrdStockUpItemDao GetInstance(string connectionName)
        {
            return new OrdStockUpItemDao(connectionName);
        }

        /// <summary>
        /// 获取备货单明细信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStockUpItemList(string stock_Id)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            '0' As Sel,
                            osi.ID,
                            oos.ID As Stock_Id,
                            osi.PROJECT_ID,
                            osi.PROJECT_PROD_ID,
                            op.SALER_ID,
                            op.SALER_NAME,
                            osi.MANUFACTURE_ID As MANU_ID,
                            osi.MANUFACTURE_NAME As MANU_NAME,
                            osi.MANUFACTURE_NAME_ABBR As MANU_NAME_ABBR,
                            oos.SENDER_ID,
                            oos.SENDER_NAME,
                            oos.SENDER_NAME_ABBR,
                            osi.SPEC,
                            osi.MODEL,
                            osi.BARCODE,
                            '' As barcode_Back,
                            isNull(osi.BATCH_NO,'-') As BATCH_NO,
                            osi.NUM,
                            isNull(convert(varchar,osi.VALID_DATE,23),'-') As VALID_DATE,
                            osi.REMARK,
                            op.price,
                            op.DATA_PRODUCT_ID,
                            op.CONT_PRODUCT_ID,
                            op.BASE_MEASURE,
                            op.COMMON_NAME,
                            op.PRODUCT_NAME,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            osi.BRAND,
                            op.CODE,
                            osi.GOODS_NO,
                            op.BASE_MEASURE_SPEC,
                            op.BASE_MEASURE_MATER,
                            op.MAX_PRICE,
                            osi.SPEC_ID,
                            osi.MODEL_ID,
                            osi.STATE,
                            isNull(osi.PBNO,'-') As PBNO,
                            osi.SEND_BATCH_NO,
                            osi.INSTORE_BATCH_NO,
                            osi.CREATE_DATE,
                            (case osi.STATE when '1' then '未确认' when '2' then '已确认' when '3' then '完成' when '4' then '作废' end) As StateName
                            From HC_ORD_ORD_STOCK_ITEM osi,HC_ORD_PRODUCT op,HC_ORD_ORD_STOCK oos
                            Where osi.PROJECT_PROD_ID=op.ID and osi.PROJECT_ID=op.PROJECT_ID
                            And osi.STOCK_ID = oos.ID And osi.DATA_PRODUCT_ID=op.DATA_PRODUCT_ID
                            ");

            if (!string.IsNullOrEmpty(stock_Id))
            {
                strSql.Append(" And Osi.STOCK_ID=@STOCK_ID");
                DbParameter strStockId = DbFacade.CreateParameter();
                strStockId.ParameterName = "STOCK_ID";
                strStockId.DbType = DbType.String;
                strStockId.Value = stock_Id;
                parameters.Add(strStockId);
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

        #region 获取备货单记录对象 根据备货单ID

        /// <summary>
        /// 根据备货单明细ID 获取备货单明细记录对象
        /// </summary>
        /// <param name="stock_Item_Id"></param>
        public OrdStockUpItemModel GetOrdStockUpItemModel(string stock_Item_Id)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            osi.ID,
                            osi.COMMERCE_NAME,
                            osi.PRODUCT_NAME,
                            op.COMMON_NAME,
                            osi.BRAND,
                            osi.MANUFACTURE_ID,
                            osi.MANUFACTURE_NAME,
                            osi.MANUFACTURE_NAME_ABBR,
                            osi.SPEC,
                            osi.MODEL,
                            osi.BARCODE,
                            osi.BATCH_NO,
                            osi.NUM,
                            osi.VALID_DATE,
                            osi.REMARK,
                            op.price,
                            op.REG_NO,
                            op.REG_VALID_DATE,
                            op.SALER_ID,
                            op.SALER_NAME,
                            op.SALER_NAME_ABBR,
                            op.BASE_MEASURE,
                            op.PERFORMANCE,
                            (case osi.STATE when '1' then '未确认' when '2' then '已确认' when '3' then '完成' when '4' then '作废' end) As StateName
                            From HC_ORD_ORD_STOCK_ITEM As osi,HC_ORD_PRODUCT As op
                            Where osi.DATA_PRODUCT_ID=op.DATA_PRODUCT_ID and osi.PROJECT_ID=op.PROJECT_ID");

            if (!string.IsNullOrEmpty(stock_Item_Id))
            {
                strSql.Append(" And osi.ID=:stock_Item_Id");
                DbParameter strStock_Item_Id = DbFacade.CreateParameter();
                strStock_Item_Id.ParameterName = "stock_Item_Id";
                strStock_Item_Id.DbType = DbType.String;
                strStock_Item_Id.Value = stock_Item_Id;
                parameters.Add(strStock_Item_Id);
            }
            else
            {
                return null;
            }

            OrdStockUpItemModel model = null;

            model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(StockUpItemModel), parameters.ToArray()) as OrdStockUpItemModel;

            return model;
        }

        /// <summary>
        /// 采购备货单信息对象
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object StockUpItemModel(IDataReader reader, int row)
        {
            OrdStockUpItemModel model = new OrdStockUpItemModel();

            model.Id = Convert.ToString(reader["ID"]);
            model.Commerce_Name = Convert.ToString(reader["COMMERCE_NAME"]);
            model.Product_Name = Convert.ToString(reader["PRODUCT_NAME"]);
            model.Brand = Convert.ToString(reader["BRAND"]);
            model.Manufacture_Name = Convert.ToString(reader["MANUFACTURE_NAME"]);
            model.Spec = Convert.ToString(reader["SPEC"]);
            model.Model = Convert.ToString(reader["MODEL"]);
            model.Barcode = Convert.ToString(reader["BARCODE"]);
            model.Batch_No = Convert.ToString(reader["BATCH_NO"]);
            model.Num = Convert.ToString(reader["NUM"]);
            model.Valid_Date = Convert.ToString(reader["VALID_DATE"]);
            model.Remark = Convert.ToString(reader["REMARK"]);
            model.Price = Convert.ToString(reader["price"]);
            model.Reg_No = Convert.ToString(reader["REG_NO"]);
            model.Reg_Valid_Date = Convert.ToString(reader["REG_VALID_DATE"]);
            model.Saler_Name = Convert.ToString(reader["SALER_NAME"]);
            model.Base_Measure = Convert.ToString(reader["BASE_MEASURE"]);

            return model;
        }

        #endregion


        /// <summary>
        /// 设置备货单明细状态
        /// </summary>
        /// <param name="stock_Item_Id"></param>
        /// <param name="State"></param>
        public bool SetOrdStockUpItemState(string stock_Item_Id, string State, DbTransaction transaction)
        {
            bool flag = false;
            int result = 0;

            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update HC_ORD_ORD_STOCK_ITEM ");
            strSql.Append("Set ");
            strSql.Append(" SYNC_STATE='0',");
            strSql.AppendFormat("STATE='{0}'", State);
            strSql.AppendFormat(" Where ID='{0}'", stock_Item_Id);

            try
            {
                result = base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
                if (result > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// 设置备货单主表状态
        /// </summary>
        /// <param name="stock_Id"></param>
        /// <param name="State"></param>
        public void SetOrdStockUpStateByStockId(string stock_Id, string State, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update HC_ORD_ORD_STOCK ");
            strSql.Append("Set ");
            strSql.Append(" SYNC_STATE='0',");
            strSql.AppendFormat("STATE='{0}'", State);
            strSql.AppendFormat(" Where ID='{0}'", stock_Id);

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
        /// 设置备货单明细状态 根据备货单ID修改
        /// </summary>
        /// <param name="stock_Id"></param>
        /// <param name="State"></param>
        public void SetOrdStockUpItemStateByStockId(string stock_Id, string State, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update HC_ORD_ORD_STOCK_ITEM ");
            strSql.Append("Set ");
            strSql.Append(" SYNC_STATE='0',");
            strSql.AppendFormat("STATE='{0}'", State);
            strSql.AppendFormat(" Where STOCK_ID='{0}'", stock_Id);

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
        /// 修改备货单明细条码及主表明细表状态
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="strStockUpID"></param>
        public void UpdateBarcodeOrdStockUpItemList(List<OrdStockUpItemModel> Listmodel,string strStockUpID)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdStockUpItemModel model in Listmodel)
                    {
                        //修改明细状态 2 “已确定”
                        SetOrdStockUpItemState(model.Id, "2", transaction);
                    }
                    //判断备货单明细中 是否还没全部已确认。否( 主表 6完成 明细 3完成)   是 (主表 5确认中) 
                    if (IsAllAffirmByItem(strStockUpID, transaction))
                    {
                        SetOrdStockUpStateByStockId(strStockUpID, "5", transaction);
                    }
                    else
                    {
                        SetOrdStockUpStateByStockId(strStockUpID, "6", transaction);
                        SetOrdStockUpItemStateByStockId(strStockUpID, "3", transaction);
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
        /// 修改备货单明细条码
        /// </summary>
        /// <param name="ordStockUpItemModel"></param>
        public void UpdateBarcodeOrdStockUpItem(OrdStockUpItemModel ordStockUpItemModel, DbTransaction transaction)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update HC_ORD_ORD_STOCK_ITEM ");
            strSql.Append("Set ");
            strSql.Append(" SYNC_STATE='0',");
            strSql.AppendFormat("BARCODE='{0}'", ordStockUpItemModel.Barcode_Back);

            strSql.AppendFormat(" Where ID='{0}'", ordStockUpItemModel.Id);

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
        /// 判断备货单明细中是否都已确认
        /// </summary>
        /// <param name="strStockUpID"></param>
        /// <returns></returns>
        public bool IsAllAffirmByItem(string strStockUpID, DbTransaction transaction)
        {
            bool flag = false;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                Count(1) 
                                From HC_ORD_ORD_STOCK_ITEM 
                                Where STATE Not In('2','4') And STOCK_ID={0}", strStockUpID);

            try
            {
                int Count = Convert.ToInt16(DbFacade.SQLExecuteScalar(strSql.ToString(), transaction).ToString());
                if (Count > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;

        }

    }
}
