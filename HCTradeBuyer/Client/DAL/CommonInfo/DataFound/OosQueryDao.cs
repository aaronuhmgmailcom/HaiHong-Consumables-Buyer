//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OosQueryDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	缺货查询（业务操作类）
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
    /// 缺货查询（数据访问类）
    /// </summary>
    class OosQueryDao : SqlDAOBase
    {
        private OosQueryDao()
        : base()
        { }

        private OosQueryDao(string connectionName)
        : base(connectionName)
        { }

        public static OosQueryDao GetInstance()
        {
            return new OosQueryDao();
        }

        public static OosQueryDao GetInstance(string connectionName)
        {
            return new OosQueryDao(connectionName);
        }

        /// <summary>
        /// 获取商品缺货信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOosProductInfo(LogedInUser logedinUser, string ProjectID)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select Ohc.*,
                            Sdi.PRODUCT_MNEMONIC,
                            Sdi.SELF_PACKAGE,
                            Sdi.ALIAS,
                            Sdi.ALIAS_PINYIN
                            From
                            (
                            Select
                            ohc.ID,
                            ohc.MANU_ID,
                            ohc.SALER_ID,
                            ohc.SENDER_ID,
                            pro.ID As PROJECT_ID,
                            pro.PROJECT_TYPE,
                            (case pro.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name,
                            op.ID As PROJECT_PRODUCT_ID,
                            op.DATA_PRODUCT_ID,
                            ppcc.CLASS_ID,
                            op.COMMERCE_NAME,
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            ohc.SPEC,
                            ohc.MODEL,
                            ohc.BRAND,
                            org1.ORG_NAME As MANU_NAME,
                            org1.ORG_ABBR As MANU_NAME_ABBR,
                            org1.SPELL_ABBR As MANU_NAME_SPELL_ABBR,
                            org1.ORG_NAME_WB As MANU_NAME_WB,
                            org2.ORG_NAME As SALER_NAME,
                            org2.ORG_ABBR As SALER_NAME_ABBR,
                            org2.SPELL_ABBR As SALER_NAME_SPELL_ABBR,
                            org2.ORG_NAME_WB As SALER_NAME_WB,
                            org3.ORG_NAME As SENDER_NAME,
                            org3.ORG_ABBR As SENDER_NAME_ABBR,
                            org3.SPELL_ABBR As SENDER_NAME_SPELL_ABBR,
                            org3.ORG_NAME_WB As SENDER_NAME_WB,
                            ohc.DEFAULT_MEASURE,
                            ohc.PRICE,
                            op.STATE,
                            obs.IS_OOS,
                            (case op.STATE when '0' then '不可用' when '1' then '可用' end) As StateName 
                            From HC_ORD_HIT_COMM ohc,HC_ORD_PROJECT pro,HC_PROJECT_PROD_CLASS_CONTENT ppcc,HC_ORD_PRODUCT op,HC_ORD_BUYER_SENDER obs,HC_ORG org1,HC_ORG org2,HC_ORG org3
                            Where ohc.PROJECT_PROD_ID=op.Id And pro.Id = op.PROJECT_ID And  ppcc.PROJECT_ID=op.PROJECT_ID And ppcc.PRODUCT_ID=op.ID And op.ID=obs.PROJECT_PROD_ID
                            And obs.PROJECT_ID=op.PROJECT_ID And ohc.MANU_ID=org1.ID And ohc.SALER_ID=org2.ID And ohc.SENDER_ID =org3.Id
                            And op.STATE='1' And obs.buyer_id=@BUYER_ID And op.PROJECT_ID=@PROJECT_ID And IS_OOS='0'
                            )As ohc
                            Left Join HC_SELF_DEFINE_INFO Sdi on Ohc.ID=sdi.HIT_COMM_ID
                            ");

            DbParameter strBuyerID = DbFacade.CreateParameter();
            strBuyerID.ParameterName = "BUYER_ID";
            strBuyerID.DbType = DbType.String;
            strBuyerID.Value = logedinUser.UserOrg.Id;
            parameters.Add(strBuyerID);

            DbParameter strProjectID = DbFacade.CreateParameter();
            strProjectID.ParameterName = "PROJECT_ID";
            strProjectID.DbType = DbType.String;
            strProjectID.Value = ProjectID;
            parameters.Add(strProjectID);

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), "OOSQUERY" ,parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
