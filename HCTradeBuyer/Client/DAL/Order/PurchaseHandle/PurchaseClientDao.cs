using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Emedchina.Commons.Data;
namespace Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle
{

    public class PurchaseClientDao : SqlDAOBase
     {

         private PurchaseClientDao()
            : base()
        { }

        private PurchaseClientDao(string connectionName)
            : base(connectionName)
        { }

        public static PurchaseClientDao GetInstance()
        {
            return new PurchaseClientDao();
        }

        public static PurchaseClientDao GetInstance(string connectionName)
        {
            return new PurchaseClientDao(connectionName);
        }


            #region 采购单列表检索
            /// <summary>
            /// 采购单表检索
            /// </summary>
            /// <param name="keys">采购单表条件</param>
            /// <param name="param">分页条件</param>
            /// <param name="rows">记录数</param>
            /// <returns>列表结果</returns>
            public DataTable getPurchaseCreate(string orgId)
            {
                DataTable dt = null;
                StringBuilder sql = new StringBuilder();

                sql.Append("select HOP.id,HOP.CODE,HOP.TOTAL_SUM,HOP.CREATE_USER_NAME,HOP.PURCHASE_DATE,HOP.CREATE_DATE as create_date1,HOP.TYPE as purchaseType,case HOP.TYPE when 1 then '普通采购单' when 2 then '发货流程' when 3 then '确认单（备货）' end as type,");
                sql.Append("case HOP.QUICKSEND_LEVEL when '1' then '普通'when '2' then '部分紧急'when '3' then '紧急' end as purchase_QUICKSEND_LEVEL, ");
                sql.Append(" case HOP.STATE when '1' then '准备'when '2' then '送审'when'3' then '拒绝' when '4' then '审核通过'when '5' then '处理中'when '6' then ");
                sql.Append(" '关闭' end AS purchase_state,HOP.MODIFY_DATE, ");
                sql.Append("(case HOP.SYNC_STATE when '0' then '未上传' when '1' then '已上传' end) As SyncState");
                sql.AppendFormat(" from HC_ORD_PURCHASE as HOP where  HOP.BUYER_ID='{0}'", orgId);
                
                try
                {
                    dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };

                }
                catch (Exception e)
                {
                    throw e;
                }

                return dt;
            }
            #endregion
            #region 采购单明细列表检索
            /// <summary>
            /// 采购单表检索
            /// </summary>
            /// <param name="keys">采购单表条件</param>
            /// <param name="param">分页条件</param>
            /// <param name="rows">记录数</param>
            /// <returns>列表结果</returns>
        public DataTable getPurchaseItem(string orgId,string PURCHASE_ID)
            {
                DataTable dt = null;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT cast(HOPI.ID As varchar) As ID,HOPI.PROJECT_ID,HOPI.PURCHASE_ID,HOPI.PROJECT_PROD_ID ,HOPI.DATA_PRODUCT_ID,HOPI.SALER_ID,HOPI.SALER_NAME,HOPI.SALER_NAME_ABBR,HOPI.SPEC_ID,HOPI.MODEL_ID");
                sql.Append(" ,cast(HOPI.SENDER_ID As varchar) As SENDER_ID ,HOPI.SENDER_NAME_ABBR,HOPI.SENDER_NAME,HOPI.MANUFACTURE_ID,HOPI.MANUFACTURE_NAME_ABBR,HOPI.MANUFACTURE_NAME,HOPI.COMMON_NAME,HOPI.PRODUCT_NAME,''as SUM ");
                sql.Append(",HOPI.PRODUCT_CODE,HOPI.SPEC,HOPI.MODEL,isnull(HOPI.BRAND,'-') as BRAND,HOPI.STORE_ROOM_ID,HOPI.STORE_ROOM_NAME,HOPI.STORE_ROOM_ADDRESS,HOPI.BASE_MEASURE,HOPI.BASE_MEASURE_SPEC");
                sql.Append(",HOPI.BASE_MEASURE_MATER,HOPI.SEND_MEASURE,HOPI.SEND_MEASURE_EX ,HOPI.RETAIL_PRICE,HOPI.TRADE_PRICE,cast(HOPI.AMOUNT as int) as AMOUNT ,HOPI.OVER_AMOUNT,'' as RowState");
                sql.Append(",HOPI.OVER_SUM,HOPI.IS_QUICKSEND as purchase_QUICKSEND,HOPI.DESCRIPTIONS,case when hoc.SELF_PACKAGE  is null then 1 else hoc.SELF_PACKAGE end as SELF_PACKAGE ");
                sql.Append(",(case HOPI.IS_QUICKSEND when '0' then '普通' when '1' then '急需' end) QUICKSEND_NAME,Hoc.abbr_py,Hoc.abbr_wb ");
                sql.Append("FROM HC_ORD_PURCHASE_ITEM HOPI left join (select hohc.PROJECT_PROD_ID, hohc.SPEC_ID, hohc.MODEL_ID,hsdi.SELF_PACKAGE,Hohc.abbr_py,Hohc.abbr_wb from HC_ORD_HIT_COMM hohc,HC_SELF_DEFINE_INFO hsdi where hohc.id=hsdi.HIT_COMM_ID ) ");
                sql.AppendFormat(" hoc on HOPI.PROJECT_PROD_ID= hoc.PROJECT_PROD_ID and HOPI.SPEC_ID=hoc.SPEC_ID  and  HOPI.MODEL_ID=hoc.MODEL_ID  where HOPI.BUYER_ID='{0}'", orgId);
                sql.AppendFormat(" and HOPI.PURCHASE_ID='{0}'order by ID desc", PURCHASE_ID);
                try
                {
                    dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

                }
                catch (Exception e)
                {

                    throw e;
                }

                return dt;
            }
         #endregion
            #region 订单列表检索
            /// <summary>
            /// 通过采购单Id检索订单主表
            /// </summary>
            /// <param name="keys">采购单表条件</param>
            /// <param name="param">分页条件</param>
            /// <param name="rows">记录数</param>
            /// <returns>列表结果</returns>
            public DataTable getOrder(string purchaseId)
            {

                DataTable dt = null;
                StringBuilder sql = new StringBuilder(512);
                sql.Append(" SELECT T.id,T.ORDER_CODE,");//订单编码
                sql.Append(" T.SALER_NAME,");
                sql.Append(" T.SENDER_NAME,");
                //sql.Append(" T.CREATE_DATE,");
                sql.Append(" case t.STATE when '1' then '未阅读'when '2' then '已阅读'when'3' then '确认' when '4' then '处理中'when '5' then '完成'when '6' then '作废' end ");
                sql.Append("  AS ORDER_STATE,");

                sql.Append(" T.TOTAL_SUM,");
                sql.Append(" t.OVER_SUM,");
                sql.Append(" case t.QUICKSEND_LEVEL when '1' then '普通'when '2' then '部分紧急' when '3' then '紧急' end  as order_QUICKSEND_LEVEL ");
                sql.Append(" FROM HC_ORD_ORDER T");
                sql.AppendFormat(" WHERE T.PURCHASE_ID = '{0}'", purchaseId);

                

                try
                {
                    dt = base.DbFacade.SQLExecuteDataTable(sql.ToString()); ;

                    dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };

                }
                catch (Exception e)
                {

                    throw e;
                }

                return dt;
            }
            #endregion


        }
    }

