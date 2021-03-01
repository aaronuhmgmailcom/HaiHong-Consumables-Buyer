//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	PurchaseItemDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	采购商品查询（业务操作类）
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
using Emedchina.TradeAssistant.Model.CommInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 采购商品查询（业务操作类）
    /// </summary>
    class PurchaseItemDao : SqlDAOBase
    {
        private PurchaseItemDao()
        : base()
        { }

        private PurchaseItemDao(string connectionName)
        : base(connectionName)
        { }

        public static PurchaseItemDao GetInstance()
        {
            return new PurchaseItemDao();
        }

        public static PurchaseItemDao GetInstance(string connectionName)
        {
            return new PurchaseItemDao(connectionName);
        }

        /// <summary>
        /// 获取采购商品列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPurchaseItemDt()
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            Opi.PROJECT_PROD_ID,
                            Opi.Data_Product_Id, 
                            Opi.Purchase_Id, 
                            Op.Code,
                            Opi.PRODUCT_NAME,
                            Opi.COMMON_NAME,
                            hop.ABBR_PY,
                            hop.ABBR_WB, 
                            Opi.SPEC, 
                            Opi.MODEL, 
                            Opi.BRAND,
                            Opi.Store_Room_Id, 
                            isnull(Opi.Store_Room_Name,'-') As Store_Room_Name,
                            Opi.Trade_Price, 
                            Opi.Amount,
                            Opi.Over_Amount,
                            Opi.Over_Sum, 
                            Op.Purchase_Date, 
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
                            (Case Opi.Is_Quicksend When '0' Then '普通' When '1' Then '急需' End) Isquicksend
                            From Hc_Ord_Purchase_Item Opi, Hc_Ord_Purchase Op,HC_ORD_PRODUCT hop,Hc_org org1,Hc_org org2,Hc_org org3
                            Where Opi.Purchase_Id = Op.Id and hop.ID=Opi.PROJECT_PROD_ID and org1.ID=opi.SENDER_ID and org2.ID=opi.SALER_ID and org3.ID=opi.MANUFACTURE_ID
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
    }
}
