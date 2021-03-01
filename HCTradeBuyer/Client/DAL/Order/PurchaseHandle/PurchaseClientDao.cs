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


            #region �ɹ����б����
            /// <summary>
            /// �ɹ��������
            /// </summary>
            /// <param name="keys">�ɹ���������</param>
            /// <param name="param">��ҳ����</param>
            /// <param name="rows">��¼��</param>
            /// <returns>�б���</returns>
            public DataTable getPurchaseCreate(string orgId)
            {
                DataTable dt = null;
                StringBuilder sql = new StringBuilder();

                sql.Append("select HOP.id,HOP.CODE,HOP.TOTAL_SUM,HOP.CREATE_USER_NAME,HOP.PURCHASE_DATE,HOP.CREATE_DATE as create_date1,HOP.TYPE as purchaseType,case HOP.TYPE when 1 then '��ͨ�ɹ���' when 2 then '��������' when 3 then 'ȷ�ϵ���������' end as type,");
                sql.Append("case HOP.QUICKSEND_LEVEL when '1' then '��ͨ'when '2' then '���ֽ���'when '3' then '����' end as purchase_QUICKSEND_LEVEL, ");
                sql.Append(" case HOP.STATE when '1' then '׼��'when '2' then '����'when'3' then '�ܾ�' when '4' then '���ͨ��'when '5' then '������'when '6' then ");
                sql.Append(" '�ر�' end AS purchase_state,HOP.MODIFY_DATE, ");
                sql.Append("(case HOP.SYNC_STATE when '0' then 'δ�ϴ�' when '1' then '���ϴ�' end) As SyncState");
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
            #region �ɹ�����ϸ�б����
            /// <summary>
            /// �ɹ��������
            /// </summary>
            /// <param name="keys">�ɹ���������</param>
            /// <param name="param">��ҳ����</param>
            /// <param name="rows">��¼��</param>
            /// <returns>�б���</returns>
        public DataTable getPurchaseItem(string orgId,string PURCHASE_ID)
            {
                DataTable dt = null;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT cast(HOPI.ID As varchar) As ID,HOPI.PROJECT_ID,HOPI.PURCHASE_ID,HOPI.PROJECT_PROD_ID ,HOPI.DATA_PRODUCT_ID,HOPI.SALER_ID,HOPI.SALER_NAME,HOPI.SALER_NAME_ABBR,HOPI.SPEC_ID,HOPI.MODEL_ID");
                sql.Append(" ,cast(HOPI.SENDER_ID As varchar) As SENDER_ID ,HOPI.SENDER_NAME_ABBR,HOPI.SENDER_NAME,HOPI.MANUFACTURE_ID,HOPI.MANUFACTURE_NAME_ABBR,HOPI.MANUFACTURE_NAME,HOPI.COMMON_NAME,HOPI.PRODUCT_NAME,''as SUM ");
                sql.Append(",HOPI.PRODUCT_CODE,HOPI.SPEC,HOPI.MODEL,isnull(HOPI.BRAND,'-') as BRAND,HOPI.STORE_ROOM_ID,HOPI.STORE_ROOM_NAME,HOPI.STORE_ROOM_ADDRESS,HOPI.BASE_MEASURE,HOPI.BASE_MEASURE_SPEC");
                sql.Append(",HOPI.BASE_MEASURE_MATER,HOPI.SEND_MEASURE,HOPI.SEND_MEASURE_EX ,HOPI.RETAIL_PRICE,HOPI.TRADE_PRICE,cast(HOPI.AMOUNT as int) as AMOUNT ,HOPI.OVER_AMOUNT,'' as RowState");
                sql.Append(",HOPI.OVER_SUM,HOPI.IS_QUICKSEND as purchase_QUICKSEND,HOPI.DESCRIPTIONS,case when hoc.SELF_PACKAGE  is null then 1 else hoc.SELF_PACKAGE end as SELF_PACKAGE ");
                sql.Append(",(case HOPI.IS_QUICKSEND when '0' then '��ͨ' when '1' then '����' end) QUICKSEND_NAME,Hoc.abbr_py,Hoc.abbr_wb ");
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
            #region �����б����
            /// <summary>
            /// ͨ���ɹ���Id������������
            /// </summary>
            /// <param name="keys">�ɹ���������</param>
            /// <param name="param">��ҳ����</param>
            /// <param name="rows">��¼��</param>
            /// <returns>�б���</returns>
            public DataTable getOrder(string purchaseId)
            {

                DataTable dt = null;
                StringBuilder sql = new StringBuilder(512);
                sql.Append(" SELECT T.id,T.ORDER_CODE,");//��������
                sql.Append(" T.SALER_NAME,");
                sql.Append(" T.SENDER_NAME,");
                //sql.Append(" T.CREATE_DATE,");
                sql.Append(" case t.STATE when '1' then 'δ�Ķ�'when '2' then '���Ķ�'when'3' then 'ȷ��' when '4' then '������'when '5' then '���'when '6' then '����' end ");
                sql.Append("  AS ORDER_STATE,");

                sql.Append(" T.TOTAL_SUM,");
                sql.Append(" t.OVER_SUM,");
                sql.Append(" case t.QUICKSEND_LEVEL when '1' then '��ͨ'when '2' then '���ֽ���' when '3' then '����' end  as order_QUICKSEND_LEVEL ");
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

