using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Emedchina.Commons.Data;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.User;
namespace Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle
{

    public class HitCommAndContClientDao : SqlDAOBase
     {

         private HitCommAndContClientDao() 
             : base()
        { }

        private HitCommAndContClientDao(string connectionName)
            : base(connectionName)
        { }

        public static HitCommAndContClientDao GetInstance()
        {
            return new HitCommAndContClientDao();
        }

        public static HitCommAndContClientDao GetInstance(string connectionName)
        {
            return new HitCommAndContClientDao(connectionName);
        }




            /// <summary>
            /// 获取项目产品信息
            /// </summary>
            /// <returns></returns>
        public DataTable GetHitProductDt(string strProjectID, LogedInUser logedinUser, string strDataName)
            {
                List<DbParameter> parameters = new List<DbParameter>();

                DataTable OrdProDt = null;

                StringBuilder strSql = new StringBuilder();

                //项目产品目录+项目配套子表
                strSql.Append(@"Select
                            isnull(Cast(Pack.PACKAGE_ID as varchar),'') + isnull('【' + Pack.name + '】',' 【非配套产品】') As PackName,
                            (Case when Pack.AMOUNT is Null Or Pack.AMOUNT <=0 Then '-' Else str(cast(Pack.AMOUNT as int)) End) As AMOUNT,
                            Pro.*,
                            Hsdi.PRODUCT_MNEMONIC,
                            (case when Hsdi.SELF_PACKAGE is null then 1 else Hsdi.SELF_PACKAGE end )as SELF_PACKAGE,
                            Hsdi.ALIAS,
                            Hsdi.ALIAS_PINYIN
                            From
                            (
                            (Select 
                            op.id,
                            op.PROJECT_PROD_ID As PROJECT_PROD_ID,
                            op.PRODUCT_NAME,
                            op.PROJECT_ID,
                            pro.PROJECT_TYPE,
                            (case pro.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name,
                            ppcc.CLASS_ID,
                            op.DATA_PRODUCT_ID,
                            op.COMMON_NAME,
                            op.CODE As PRODUCTCODE,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            op.SPEC_ID,
                            op.SPEC,
                            op.MODEL_ID,
                            op.MODEL,
                            op.PERFORMANCE,
                            isnull(op.BRAND,'-') as BRAND,
                            op.BASE_MEASURE,
                            op.DEFAULT_MEASURE,
                            op.Default_Measure_Ex,
                            op.INSTRU_CODE,
                            op.INSTRU_NAME,
                            op.REG_NO,
                            op.REG_VALID_DATE,
                            op.PRICE,
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
                            op.GOODS_NO,
                            op.BARCODE,
                            op.BASE_MEASURE_SPEC,
                            op.BASE_MEASURE_MATER,
                            op.MAX_PRICE,
                            op.MANU_ID,
                            op.SALER_ID,
                            op.SENDER_ID,
                            op.LAST_DATE,
                            isnull(cast(hop.bid_id as varchar),'-') As bid_id
                            From 
                            HC_ORD_HIT_COMM op,HC_ORD_PRODUCT hop,HC_ORD_PROJECT pro,HC_ORG org1,HC_ORG org2,HC_ORG org3,HC_PROJECT_PROD_CLASS_CONTENT ppcc
                            Where op.PROJECT_ID = pro.ID And 
                            op.PROJECT_PROD_ID=hop.Id And pro.Id = hop.PROJECT_ID And  ppcc.PROJECT_ID=hop.PROJECT_ID And ppcc.PRODUCT_ID=hop.ID And
                            op.MANU_ID=org1.ID And op.SALER_ID=org2.Id And op.SENDER_ID=org3.Id And ppcc.PROJECT_ID=op.PROJECT_ID And ppcc.PRODUCT_ID=op.PROJECT_PROD_ID
                            And op.STATE='1' And op.PROJECT_ID=@PROJECT_ID
                            ) Pro Left Join
                            (
                            Select opp.Id,opp.name,oppi.PACKAGE_ID,oppi.PROJECT_PROD_ID,oppi.AMOUNT,opp.PROJECT_ID From HC_ORD_PRODUCT_PACKAGE opp,HC_ORD_PRODUCT_PACKAGE_ITEM oppi
                            Where oppi.PACKAGE_ID=opp.Id And opp.PROJECT_ID=@PROJECT_ID
                            )  Pack On Pro.PROJECT_PROD_ID=Pack.PROJECT_PROD_ID and Pro.PROJECT_ID=Pack.PROJECT_ID)
                           left join HC_SELF_DEFINE_INFO Hsdi on pro.id= Hsdi.HIT_COMM_ID
                            ");

                DbParameter strProID = DbFacade.CreateParameter();
                strProID.ParameterName = "PROJECT_ID";
                strProID.DbType = DbType.String;
                strProID.Value = strProjectID;
                parameters.Add(strProID);

                DbParameter strBuyerID = DbFacade.CreateParameter();
                strBuyerID.ParameterName = "BUYER_ID";
                strBuyerID.DbType = DbType.String;
                strBuyerID.Value = logedinUser.UserOrg.Id;
                parameters.Add(strBuyerID);

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


          


        }
    }