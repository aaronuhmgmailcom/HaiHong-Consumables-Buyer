using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.DAL.Order.SalerOrder;
using System.Data;

namespace Emedchina.TradeAssistant.BLL.Order.SalerOrder
{
    public class ExpBaseInfoBLL
    {
        private ExpBaseInfoDAO dao = null;

        private ExpBaseInfoBLL()
        {
            dao = ExpBaseInfoDAO.GetInstance();
        }

        private ExpBaseInfoBLL(string connectionName)
        {
            dao = ExpBaseInfoDAO.GetInstance(connectionName);
        }

        public static ExpBaseInfoBLL GetInstance()
        {
            return new ExpBaseInfoBLL();
        }

        public static ExpBaseInfoBLL GetInstance(string connectionName)
        {
            return new ExpBaseInfoBLL(connectionName);
        }


        public DataTable GetProductInfo(string buyerorgid)
        {
            return dao.GetProductInfo(buyerorgid);
        }


        public DataTable GetBuyerInfo(string buyerOrgid)
        {
            return dao.GetBuyerInfo(buyerOrgid);
        }

        public DataTable GetEnterpriseInfo(string buyerOrgid)
        {
            return dao.GetEnterpriseInfo(buyerOrgid);
        }


    }
}
