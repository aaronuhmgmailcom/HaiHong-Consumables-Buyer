using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Client.DAL.Report;

namespace Emedchina.TradeAssistant.Client.BLL.Report
{
    class ReportBLL
    {
        private ReportDAO dao = null;

        private ReportBLL()
        {
            dao = ReportDAO.GetInstance();
        }

        private ReportBLL(string connectionName)
        {
            dao = ReportDAO.GetInstance(connectionName);
        }

        public static ReportBLL GetInstance()
        {
            return new ReportBLL();
        }

        public static ReportBLL GetInstance(string connectionName)
        {
            return new ReportBLL(connectionName);
        }


        /// <summary>
        /// 订单
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        public DataTable GetOrderReportData(string sOrderId)
        {
            return dao.GetOrderReportData(sOrderId);
        }
        /// <summary>
        /// 采购单
        /// </summary>
        /// <returns></returns>
        public DataTable GetPurchaseReportData(string sPurchaseId)
        {
            return dao.GetPurchaseReportData(sPurchaseId);
        }
        /// <summary>
        /// 发货
        /// </summary>
        /// <returns></returns>
        public DataTable GetInvoiceReportData(string sInvoiceId)
        {
            return dao.GetInvoiceReportData(sInvoiceId);
        }
        /// <summary>
        /// 备货
        /// </summary>
        /// <returns></returns>
        public DataTable GetStokReportData(string sStockId)
        {
            return dao.GetStokReportData(sStockId);
        }

    }
}
