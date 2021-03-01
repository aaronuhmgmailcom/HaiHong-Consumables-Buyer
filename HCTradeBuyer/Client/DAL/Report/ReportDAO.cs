using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Emedchina.Commons;
using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.Client.DAL.Report
{
    class ReportDAO :SqlDAOBase
    {
         private ReportDAO()
            : base()
        { }

        private ReportDAO(string connectionName)
            : base(connectionName)
        { }

        public static ReportDAO GetInstance()
        {
            return new ReportDAO();
        }

        public static ReportDAO GetInstance(string connectionName)
        {
            return new ReportDAO(connectionName);
        }        
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        public DataTable GetOrderReportData(string sOrderId)
        {
            StringBuilder sbSql = new StringBuilder();     

            sbSql.Append(" select ho.id,");
            sbSql.Append(" ho.order_code,");
            sbSql.Append(" ho.buyer_name,");
            sbSql.Append(" ho.sender_name,");
            sbSql.Append(" ho.total_sum,");
            sbSql.Append(" ho.over_sum,");
            sbSql.Append(" ho.saler_approver_name,");
            sbSql.Append(" case ho.state when '1' then 'δ�Ķ�' when '2' then '���Ķ�' when '3' then 'ȷ��' when '4' then '������'when '5' then '���' when '6' then '����' end as state,");
            sbSql.Append(" ho.purchase_date,");
            sbSql.Append(" case ho.quicksend_level when '1' then '��ͨ' when '2' then '���ֽ���' when '3' then '����' end as quicksend_level,");
            sbSql.Append(" ho.saler_descriptions,");
            sbSql.Append(" ho.buyer_descriptions,");
            sbSql.Append(" ho.create_date,");
            sbSql.Append(" hi.product_name,");
            sbSql.Append(" hi.buyer_name,");
            sbSql.Append(" hi.manufacture_name,");
            sbSql.Append(" hi.sender_name,");
            sbSql.Append(" hi.retail_price,");
            sbSql.Append(" hi.spec,");
            sbSql.Append(" hi.model,");
            sbSql.Append(" hi.amount ");
            sbSql.Append(" from hc_ord_order ho left join hc_ord_order_item hi on ho.id = hi.order_id ");
            sbSql.AppendFormat(" where ho.id = '{0}'", sOrderId);
            DataTable dt = new DataTable();
            try
            {
                dt = DbFacade.SQLExecuteDataTable(sbSql.ToString());
            }
            catch
            {
                throw;
            }
            return dt;
        }
        /// <summary>
        /// �ɹ���
        /// </summary>
        /// <returns></returns>
        public DataTable GetPurchaseReportData(string sPurchaseId)
        {
            StringBuilder sbSql = new StringBuilder();                                 

            sbSql.Append(" select hi.product_name,");
            sbSql.Append(" hi.common_name,");
            sbSql.Append(" hi.brand,");
            sbSql.Append(" hi.spec,");
            sbSql.Append(" hi.model,");       
            sbSql.Append(" hi.manufacture_name,");
            sbSql.Append(" hi.sender_name,");
            sbSql.Append(" hi.trade_price,");
            sbSql.Append(" hi.amount,");
            sbSql.Append(" hp.code,");
            sbSql.Append(" hp.create_user_name,");
            sbSql.Append(" hp.create_date,");
            sbSql.Append(" hp.total_sum,");
            sbSql.Append(" case hp.state when '1' then '׼��' when '2' then '����' when '3' then '�ܾ�' when '4' then '���ͨ��' end as state,");
            sbSql.Append(" case hp.quicksend_level when '1' then '��ͨ' when '2' then '���ֽ���' when '3' then '����' end as quicksend_level ");
            sbSql.Append(" from hc_ord_purchase hp left join hc_ord_purchase_item hi on hp.id = hi.purchase_id ");
            sbSql.AppendFormat(" where hp.id = '{0}'", sPurchaseId);
            DataTable dt = new DataTable();
            try
            {
                dt = DbFacade.SQLExecuteDataTable(sbSql.ToString());
            }
            catch
            {
                throw;
            }
            return dt;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetInvoiceReportData(string sInvoiceId)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select hf.invoice_code,");
            sbSql.Append("case hf.state when '1' then 'δ����' when '2' then '�ѷ���' when '3' then '�򷽴�����' when '4' then '����' when '5' then '�򷽴������' end as state,");
            sbSql.Append("hf.buyer_name,");
            sbSql.Append("hf.sender_name,");
            sbSql.Append("hf.total_sum,");
            sbSql.Append("hf.over_sum,");
            sbSql.Append("hf.create_user_name,");
            sbSql.Append("hf.buyer_descriptions,");
            sbSql.Append("hf.create_date,");
            sbSql.Append("hi.product_name,");
            sbSql.Append("hi.common_name,");
            sbSql.Append("case hi.state when '1' then 'δȷ��' when '2' then '��ȷ��' when '3' then '����' end as item_state,");
            sbSql.Append("hi.manufacture_name,");
            sbSql.Append("hi.over_amount,");
            sbSql.Append("hi.trade_price,");
            sbSql.Append("hi.spec,");
            sbSql.Append("hi.model,");
            sbSql.Append("hi.amount ");
            sbSql.Append("from hc_ord_invoice_from hf left join hc_ord_invoice_from_item hi on hf.id = hi.invoice_from_id ");
            sbSql.AppendFormat(" where hf.id = '{0}'", sInvoiceId);
            DataTable dt = new DataTable();
            try
            {
                dt = DbFacade.SQLExecuteDataTable(sbSql.ToString());
            }
            catch
            {
                throw;
            }
            return dt;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetStokReportData(string sStockId)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select hs.code,");       
            sbSql.Append("hs.remark,");
            sbSql.Append("hs.sender_name,");
            sbSql.Append("case hs.state when '1' then 'δ����' when '2' then '�ѷ���' when '3' then '����ȷ��' when '4' then '����' when '5' then 'ȷ����' when '6' then '���' end as state,");
            sbSql.Append("hs.create_user_name,");
            sbSql.Append("hs.create_date,");//
            sbSql.Append("hi.product_name,");//
            sbSql.Append("hi.barcode,");
            sbSql.Append("hi.manufacture_name,");//
            sbSql.Append("hi.batch_no,");
            sbSql.Append("hi.valid_date,");
            sbSql.Append("hi.spec,");//
            sbSql.Append("hi.model,");//
            sbSql.Append("hop.price,");
            sbSql.Append("hi.num ");
            sbSql.Append("from hc_ord_ord_stock hs left join hc_ord_ord_stock_item hi on hs.id = hi.stock_id ");
            sbSql.Append(" left join hc_ord_product hop on hi.project_prod_id = hop.id ");
            sbSql.AppendFormat(" where hs.id = '{0}'", sStockId);
            DataTable dt = new DataTable();
            try
            {
                dt = DbFacade.SQLExecuteDataTable(sbSql.ToString());
            }
            catch
            {
                throw;
            }
            return dt;
        }

    }
}
