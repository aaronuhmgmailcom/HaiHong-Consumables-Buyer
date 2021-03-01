using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Emedchina.Commons;
using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.Client.DAL.Gpo
{
    public class GpoOrderExpDAO : SqlDAOBase
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        private GpoOrderExpDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private GpoOrderExpDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static GpoOrderExpDAO GetInstance()
        {
            return new GpoOrderExpDAO();
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static GpoOrderExpDAO GetInstance(string connectionName)
        {
            return new GpoOrderExpDAO(connectionName);
        }
        /// <summary>
        /// 获取订单导出数据
        /// </summary>
        /// <param name="erpProductCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public DataTable GetOrderExpData(string sOderId,string orgid,string clientPlat)
        {
            DataTable dt = null;
            StringBuilder sql = new StringBuilder();
            //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-29
            if ("1".Equals(clientPlat))
            {
                 sql.Append("  select goi.order_id as orderid,");
                 sql.Append("  ghc.product_id,");
                 sql.Append("  goi.record_id as recordid,");
                 sql.Append("  ghc.buyer_id as buyerorgid,");
                 sql.Append("  ghc.buyer_fullname as buyername,");
                 sql.Append("  ghc.buyer_shortname as buyereasy,");
                 sql.Append("  ghc.medical_code as medicalid,");
                 sql.Append("  ghc.medical_name as productname,");
                 sql.Append("  ghc.product_id as productid,");
                 sql.Append("  ghc.medical_name as commonname,");
                 sql.Append("  '' as medicalmodeid,");
                 sql.Append("  ghc.doseage_form as medicalmode,");
                 sql.Append(" '' as medicalspecid,");

                 //sql.Append(" isnull(ghc.spec, '-') + '×' +");
                 //sql.Append("  isnull(convert(varchar(20), ghc.stand_rate), '-') + ");
                 //sql.Append("  isnull(ghc.use_unit, '') + '/' + isnull(ghc.spec_unit, '')"); 
                 //sql.Append("  case ghc.wrap_code");
                 //sql.Append("    when '01' then");
                 //sql.Append("     '' ");
                 //sql.Append("    else");
                 //sql.Append("     (case ghc.wrap_name");
                 //sql.Append("    when null then");
                 //sql.Append("     '' ");
                 //sql.Append("    else");
                 //sql.Append("     '(' + ghc.wrap_name + ')'");
                 //sql.Append("  end) as medicalspec,");

                 sql.Append("  ghc.spec as medicalspec,");
                 sql.Append(" '' as metricnameid,");
                 sql.Append("  ghc.use_unit as metricname,");
                 sql.Append("  ghc.spec_unit as specunitname,");
                 sql.Append("  '' as fatoryid,");
                 sql.Append("  ghc.producer_fullname as factoryname,");
                 sql.Append("  ghc.stand_rate as stand_rate,");
                 sql.Append("  goi.request_qty as requestqty,");
                 sql.Append("  goi.create_date as createdate,");
                 sql.Append("  goi.unit_price as price,");
                 sql.Append("  goi.modify_date as modifydate,");
                 sql.Append("  goi.degree_flag as degree,");
                 sql.Append("  goi.unit_price * goi.request_qty as requesttotal,");
                 sql.Append("  goi.remark as Remark");
                 sql.Append(" from gpo_purchase_item gpi,");
                 sql.Append("  gpo_order         gor,");
                 sql.Append("  gpo_order_item    goi,");
                 sql.Append("  gpo_hit_comm      ghc");
                 sql.Append(" where gpi.id = goi.purchase_item_id");
                 sql.Append(" and gor.order_id = goi.order_id");
                 sql.Append(" and goi.hit_comm_id = ghc.record_id");
                 sql.Append(" and ghc.saler_id = '").Append(orgid).Append("'");
                 sql.Append(" and gor.order_id = '").Append(sOderId).Append("'");
            }
            else
            {
                sql.Append(" select goi.order_id as orderid,");
                sql.Append(" ghc.product_id ,");
                sql.Append(" goi.record_id as recordid,");//ddmxbm
                sql.Append(" gcm.code as buyerorgid,");//yybm
                sql.Append(" gcm.full_name as buyername,");//yymc
                sql.Append(" gcm.easy_name as buyereasy,");//yyjc

                sql.Append(" gpm.medical_code as medicalid,");
                sql.Append(" gpm.product_name as productname,");
                sql.Append(" gpm.product_code as productid,");//cpbh
                sql.Append(" gpm.common_name as commonname,");//cpmc
                sql.Append(" gpm.mode_id as medicalmodeid,");
                sql.Append(" gpm.mode_name as medicalmode,");//jxmc
                sql.Append(" gpm.medical_spec_id as medicalspecid,");
                sql.Append(" gpm.medical_spec as medicalspec,");//ggbzmc
                sql.Append(" gpm.use_unit_id as metricnameid,");
                sql.Append(" gpm.use_unit as metricname,");
                sql.Append(" gpm.spec_unit as specunitname,");//bzdw
                sql.Append(" gpm.factory_code as fatoryid,");//scqybm
                sql.Append(" gpm.factory_name as factoryname,");//scqymc
                sql.Append(" gpm.stand_rate as stand_rate,");//bzzhb

                sql.Append(" goi.request_qty as requestqty,");//dgsl
                sql.Append(" goi.create_date as createdate,");//dgrq
                sql.Append(" goi.unit_price as price,"); //dgj           
                sql.Append(" goi.modify_date as modifydate,");
                sql.Append(" goi.degree_flag as degree,");
                sql.Append(" goi.unit_price*goi.request_qty as requesttotal,");//dgje
                sql.Append(" goi.remark as Remark ");//yybz         
                sql.Append(" from gpo_order_item goi left outer join gpo_order go");
                sql.Append(" on goi.order_id = go.order_id collate Chinese_PRC_CI_AI_WS ");
                sql.Append(" left outer join gpo_hit_comm ghc ");
                sql.Append(" on ghc.record_id = goi.hit_comm_id collate Chinese_PRC_CI_AI_WS ");
                sql.Append(" left outer join (SELECT ORG_ID, max(CODE) as CODE, max(FULL_NAME) as FULL_NAME, max(EASY_NAME) as EASY_NAME FROM  GPO_CORP_MAP  group by ORG_ID) gcm ");
                sql.Append(" on go.buyer_orgid = gcm.org_id collate Chinese_PRC_CI_AI_WS ");
                sql.Append(" left outer join ");
                sql.Append(" (select product_id,max(medical_code) as medical_code, max(common_name) as common_name,max(product_code) as product_code, ");
                sql.Append(" max(product_name) as product_name, max(mode_id) as mode_id, max(mode_name) as mode_name, max(medical_spec_id) as medical_spec_id,");
                sql.Append(" max(medical_spec) as medical_spec, max(use_unit_id) as use_unit_id, max(use_unit) as use_unit,");
                sql.Append(" max(spec_unit) as spec_unit, max(factory_code) as factory_code, max(factory_name) as factory_name,");
                sql.Append(" max(stand_rate) as stand_rate from ");
                sql.Append(" gpo_product_map group by product_id)  gpm ");
                sql.Append(" on ghc.product_id = gpm.product_id collate Chinese_PRC_CI_AI_WS ");
                sql.AppendFormat(" where goi.order_id = '{0}'", sOderId);

            }
            

            try
            {
                dt = DbFacade.SQLExecuteDataTable(sql.ToString());                
            }
            catch (Exception e)
            {
                //throw e;
            }

            return dt;
        }


        //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-29
        public bool GetContItemInfo(string productId, string buyerorgid)
        {
            bool flag = false;
            StringBuilder sql = new StringBuilder();
            sql.Append("select ci.id from cont_item ci where ci.product_id='").Append(productId).Append("'").Append(" and ci.saler_id='").Append(buyerorgid).Append("'");

            try
            {
                DataTable dt = DbFacade.SQLExecuteDataTable(sql.ToString());
                if (dt.Rows.Count > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                //throw e;
            }

            return flag;
        }

    }
}
