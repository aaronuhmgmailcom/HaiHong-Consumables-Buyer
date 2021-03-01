using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Common
{
    public class IdUtil : OracleDAOBase
    {

        public static readonly String SEQ_HC = "SEQ_HC_TRADE_HIGH_ID";
        private static IdUtil idUtil;
        public static IdUtil GetInstance()
        {
            if (idUtil == null)
            {
                return new IdUtil();
            }
            else
            {
                return idUtil;
            }
        }


        public static String GetNewId()
        {
            StringBuilder sql = new StringBuilder();
            string id = "";
            sql.Append(" SELECT ");
            sql.Append(SEQ_HC);
            sql.Append(".NEXTVAL ");
            sql.Append("AS ID FROM DUAL");
            try
            {
                id = GetInstance().DbFacade.SQLExecuteScalar(sql.ToString()).ToString();
            }
            catch (DataAcessException e)
            {

            }
            return id;
            

        }
    }

}
