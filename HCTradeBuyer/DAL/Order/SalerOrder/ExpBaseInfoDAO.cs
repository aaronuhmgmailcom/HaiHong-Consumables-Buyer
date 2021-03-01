using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons.Data;
using System.Data;

namespace Emedchina.TradeAssistant.DAL.Order.SalerOrder
{
    public class ExpBaseInfoDAO : OracleDAOBase
    {
        private ExpBaseInfoDAO()
            : base()
        { }

        private ExpBaseInfoDAO(string connectionName)
            : base(connectionName)
        { }

        public static ExpBaseInfoDAO GetInstance()
        {
            return new ExpBaseInfoDAO();
        }

        public static ExpBaseInfoDAO GetInstance(string connectionName)
        {
            return new ExpBaseInfoDAO(connectionName);
        }

        public DataTable GetProductInfo(string buyerorgid)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            
           sql.Append(" SELECT distinct cp.PRODUCT_ID     as cpid,");
           sql.Append("               cp.medical_code     as cpbm,");
           sql.Append("               cp.MEDICAL_NAME     as cptym,");
           sql.Append("               cp.TRADE_NAME       as cpspm,");
           sql.Append("               cp.doseage_form     as jxmc,");
           sql.Append("               cp.SPEC             as ggbz,");
           sql.Append("               cp.use_unit         as zxsydw,");
           sql.Append("               cp.stand_rate       as zhb,");
           sql.Append("               cp.spec_unit        as bzdw,");
           sql.Append("               cp.permit_number    as pzwh,");
           sql.Append("               cp.factory_name     as scqymc,");
           sql.Append("               cp.factory_id       as scqybm,");
           sql.Append("               null                as gjj,");
           sql.Append("               null                as lsj,");
           sql.Append("               cp.LAST_UPDATE_DATE as zhxgsj");
           sql.Append(" from cont_item ci, CONT_PRODUCT cp");
           sql.Append(" where ci.product_id = cp.product_id");
           sql.Append("  and ci.saler_id ='").Append(buyerorgid).Append("'");          
            

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }


        public DataTable GetBuyerInfo(string buyerOrgid)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append(" select co.id as yybm,");
            sql.Append(" co.name as yymc,");
            sql.Append(" co.abbr as yyjc,");
            sql.Append(" co.spell_abbr as jcpy,");
            sql.Append(" co.name_wb as jcwb,");
            sql.Append(" cb.org_address as yydz,");
            sql.Append(" cb.link_person as lxr,");
            sql.Append(" cb.org_phone as lxdh,");
            sql.Append(" cb.post_code as yzbm,");
            sql.Append(" cb.last_update_date as zhxgsj");
            sql.Append(" From GPO_REG_BUYER grb,");
            sql.Append(" cat_org       co,");
            sql.Append(" cat_buyer     cb,");
            sql.Append(" cont_list     cl");
            sql.Append(" WHERE co.id = grb.data_buyer_id ");
            sql.Append("   and grb.data_buyer_id = cb.id ");
            sql.Append("   and grb.id = cl.a_id ");
            sql.Append("   and cl.b_id = '").Append(buyerOrgid).Append("'");

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable GetEnterpriseInfo(string buyerOrgid)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            
            sql.Append(" select guo.reg_org_id as qybm,");
            sql.Append(" guo.name as qymc,");
            sql.Append(" '' as qyjc,");
            sql.Append(" '' as jcpy,");
            sql.Append(" '' as jcwb,");
            sql.Append(" '' as qydz,");
            sql.Append(" '' as qydh,");
            sql.Append(" '' as yzbm,");
            sql.Append(" guo.last_update_date as zhxgsj");
            sql.Append("  from GPO_USR_ORG guo");
            sql.Append(" where guo.reg_org_id ='").Append(buyerOrgid).Append("'");                   

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }
    }
}
