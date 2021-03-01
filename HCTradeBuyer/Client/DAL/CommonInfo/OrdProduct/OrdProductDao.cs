//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdProductDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	项目产品表信息（数据访问类）
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
    /// 项目产品表信息（数据访问类）
    /// </summary>
    class OrdProductDao : SqlDAOBase
    {

        private OrdProductDao()
        : base()
        { }

        private OrdProductDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdProductDao GetInstance()
        {
            return new OrdProductDao();
        }

        public static OrdProductDao GetInstance(string connectionName)
        {
            return new OrdProductDao(connectionName);
        }

        /// <summary>
        /// 获取项目产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdProductDt(string strProjectID, LogedInUser logedinUser, string strDataName)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable OrdProDt = null;

            StringBuilder strSql = new StringBuilder();

            //项目产品目录+项目配套子表
            strSql.Append(@"Select
                            isnull(Cast(Pack.PACKAGE_ID as varchar),'') + isnull('【' + Pack.name + '】',' 【非配套产品】') As PackName,
                            (Case when Pack.AMOUNT is Null Or Pack.AMOUNT <=0 Then '-' Else str(cast(Pack.AMOUNT as int)) End) As AMOUNT,
                            Pro.*
                            From
                            (
                            Select 
                            op.ID As PROJECT_PROD_ID,
                            isnull(cast(op.bid_id as varchar),'-') As bid_id,
                            op.PRODUCT_NAME,
                            op.PROJECT_ID,
                            pro.PROJECT_TYPE,
                            (case pro.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name,
                            ppcc.CLASS_ID,
                            op.DATA_PRODUCT_ID,
                            op.COMMERCE_NAME,
                            op.COMMON_NAME,
                            op.CODE As PRODUCTCODE,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            op.PERFORMANCE,
                            isnull(op.SPEC,'-') as SPEC ,
                            isnull(op.MODEL,'-') as MODEL,
                            isnull(op.BRAND,'-') as BRAND,
                            op.BASE_MEASURE,
                            op.DEFAULT_MEASURE,
                            op.Default_Measure_Ex,
                            op.INSTRU_CODE,
                            op.INSTRU_NAME,
                            op.REG_NO,
                            op.REG_VALID_DATE,
                            op.PRICE As PRICE,
                            org1.ORG_NAME As MANU_NAME,
                            org1.ORG_ABBR As MANU_NAME_ABBR,
                            org1.SPELL_ABBR As MANU_NAME_SPELL_ABBR,
                            org1.ORG_NAME_WB As MANU_NAME_WB,
                            org2.ORG_NAME As SALER_NAME,
                            org2.ORG_ABBR As SALER_NAME_ABBR,
                            org2.SPELL_ABBR As SALER_NAME_SPELL_ABBR,
                            org2.ORG_NAME_WB As SALER_NAME_WB,
                            op.GOODS_NO,
                            op.BARCODE,
                            op.BASE_MEASURE_SPEC,
                            op.BASE_MEASURE_MATER,
                            op.MAX_PRICE,
                            op.MANU_ID,
                            op.SALER_ID,
                            op.SENDER_ID,
                            op.SENDER_NAME
                            From 

            (
            select t.*
              from HC_ORD_PRODUCT t
             where exists (select 1
                      from HC_PROJECT_PROD_CLASS_CONTENT a,
                           HC_PROJECT_PROD_CLASS_CONFIG  b
                     where a.class_id = b.class_id
                       and b.ORDER_FLAG = '1'
                       and a.PRODUCT_ID = t.id
                       and b.SALER_ID = t.SALER_ID)
               AND t.project_id = @PROJECT_ID
            )
op,HC_ORD_PROJECT pro,HC_ORG org1,HC_ORG org2,HC_PROJECT_PROD_CLASS_CONTENT ppcc
                            Where op.PROJECT_ID = pro.ID And op.MANU_ID=org1.ID And op.SALER_ID=org2.Id And ppcc.PROJECT_ID=op.PROJECT_ID And ppcc.PRODUCT_ID=op.ID
                            And op.STATE='1' And op.PROJECT_ID=@PROJECT_ID
                            ) Pro Left Join
                            (
                            Select opp.Id,opp.name,oppi.PACKAGE_ID,oppi.PROJECT_PROD_ID,oppi.AMOUNT,opp.PROJECT_ID From HC_ORD_PRODUCT_PACKAGE opp,HC_ORD_PRODUCT_PACKAGE_ITEM oppi
                            Where oppi.PACKAGE_ID=opp.Id And opp.PROJECT_ID=@PROJECT_ID
                            )  Pack On Pro.PROJECT_PROD_ID=Pack.PROJECT_PROD_ID and Pro.PROJECT_ID=Pack.PROJECT_ID
                            ");


            DbParameter strProID = DbFacade.CreateParameter();
            strProID.ParameterName = "PROJECT_ID";
            strProID.DbType = DbType.String;
            strProID.Value = strProjectID;
            parameters.Add(strProID);

            //DbParameter strBuyerID = DbFacade.CreateParameter();
            //strBuyerID.ParameterName = "BUYER_ID";
            //strBuyerID.DbType = DbType.String;
            //strBuyerID.Value = logedinUser.UserOrg.Id;
            //parameters.Add(strBuyerID);

            try
            {
                OrdProDt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), strDataName, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return OrdProDt;
        }

        /// <summary>
        /// 获取项目产品信息列表 暂没用
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdProductList()
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            p.ID,
                            p.PROJECT_ID,
                            (case pro.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name,
                            pro.PROJECT_NAME,
                            p.COMMERCE_NAME,
                            p.COMMON_NAME,
                            p.SPEC,
                            p.MODEL,
                            p.BRAND,
                            p.BASE_MEASURE,
                            p.PRICE,
                            p.CODE,
                            p.MANU_NAME,
                            p.SALER_NAME
                            From HC_ORD_PRODUCT p,HC_ORD_PROJECT pro
                            Where p.PROJECT_ID = pro.ID ");

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
        /// 获取项目产品信息对象
        /// </summary>
        /// <returns></returns>
        public OrdProductModel Get_OrdProductModel(string Project_Product_Id)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            op.REG_NO,
                            op.REG_VALID_DATE,
                            op.SPEC,
                            op.MODEL,
                            op.BRAND,
                            op.MANU_ID,
                            org1.ORG_NAME As MANU_NAME,
                            SALER_ID,
                            org2.ORG_NAME As SALER_NAME,
                            op.PRICE,
                            op.BASE_MEASURE,
                            op.PERFORMANCE,
                            ppc.CLASS_NAME
                            From HC_ORD_PRODUCT op
                            Left join HC_ORG org1 on op.MANU_ID=org1.Id
                            Left join HC_ORG org2 on op.SALER_ID=org2.Id
                            Left join  
                            (
                            Select ppcc.PRODUCT_ID,ppc.CLASS_NAME from HC_PROJECT_PROD_CLASS_CONTENT ppcc,HC_PROJECT_PRODUCT_CLASS ppc
                            Where ppcc.CLASS_ID=ppc.ID
                            ) As ppc on op.ID=ppc.PRODUCT_ID
                            Where 1=1");

            if (!string.IsNullOrEmpty(Project_Product_Id))
            {
                strSql.AppendFormat(" And op.ID='{0}'", Project_Product_Id);
            }
            else
            {
                return null;
            }

            OrdProductModel model = null;

            try
            {
                model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(GetOrdProductModel), parameters.ToArray()) as OrdProductModel;   
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }


        /// <summary>
        /// 获取项目产品对象
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private object GetOrdProductModel(IDataReader reader, int row)
        {
            OrdProductModel model = new OrdProductModel();
            model.Product_Name = Convert.ToString(reader["PRODUCT_NAME"]);
            model.Common_Name = Convert.ToString(reader["COMMON_NAME"]);
            model.Reg_No = Convert.ToString(reader["REG_NO"]);
            model.Reg_Valid_Date = Convert.ToString(reader["REG_VALID_DATE"]);
            model.Spec = Convert.ToString(reader["SPEC"]);
            model.Model = Convert.ToString(reader["MODEL"]);
            model.Brand = Convert.ToString(reader["BRAND"]);
            model.ManuName = Convert.ToString(reader["MANU_NAME"]);
            model.SalerName = Convert.ToString(reader["SALER_NAME"]);
            model.Price = System.Math.Round(Convert.ToDecimal(reader["PRICE"]),2);
            model.Base_Measure = Convert.ToString(reader["BASE_MEASURE"]);
            model.Performance = Convert.ToString(reader["PERFORMANCE"]);
            model.Class_Name = Convert.ToString(reader["CLASS_NAME"]);

            return model;
        }


        /// <summary>
        /// 缺货查询
        /// </summary>
        /// <param name="logedinUser"></param>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public DataTable GetOosProductList(LogedInUser logedinUser, string ProjectID)
        {
            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select
                            op.Id,
                            op.MANU_ID,
                            op.SALER_ID,
                            op.SENDER_ID,
                            pro.ID As PROJECT_ID,
                            pro.PROJECT_TYPE,
                            (case pro.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name,
                            ppcc.CLASS_ID,
                            op.COMMERCE_NAME,
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            op.SPEC,
                            op.MODEL,
                            op.BRAND,
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
                            op.DEFAULT_MEASURE,
                            op.PRICE,
                            op.STATE,
                            obs.IS_OOS,
                            (case op.STATE when '0' then '不可用' when '1' then '可用' end) As StateName 
                            From HC_ORD_PROJECT pro,HC_PROJECT_PROD_CLASS_CONTENT ppcc,HC_ORD_PRODUCT op,HC_ORD_BUYER_SENDER obs,HC_ORG org1,HC_ORG org2,HC_ORG org3
                            Where pro.Id = op.PROJECT_ID And  ppcc.PROJECT_ID=op.PROJECT_ID And ppcc.PRODUCT_ID=op.ID And op.ID=obs.PROJECT_PROD_ID
                            And obs.PROJECT_ID=op.PROJECT_ID And op.MANU_ID=org1.ID And op.SALER_ID=org2.ID And obs.SENDER_ID =org3.Id
                            And op.STATE='1'");

            strSql.AppendFormat(" And obs.buyer_id='{0}'", logedinUser.UserOrg.Id);

            if (!string.IsNullOrEmpty(ProjectID))
            {
                strSql.AppendFormat(" And op.PROJECT_ID='{0}'", ProjectID);
            }

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), "OosQuery");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;

        }

    }
}
