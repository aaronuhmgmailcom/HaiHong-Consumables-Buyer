using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.Common;
using Emedchina.Commons.Data;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.DAL.Common;

namespace Emedchina.TradeAssistant.Client.DAL.Order.SalerOrder
{
    public class SalerOrderDAO :SqlDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        private SalerOrderDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private SalerOrderDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static SalerOrderDAO GetInstance()
        {
            return new SalerOrderDAO();
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static SalerOrderDAO GetInstance(string connectionName)
        {
            return new SalerOrderDAO(connectionName);
        }

        
        /// <summary>
        /// 获取未匹配医院列表
        /// </summary>
        /// <param name="sOrderID"></param>
        /// <param name="sOrgID"></param>
        /// <returns></returns>
        public DataTable GetNotMapCorp(string sOrderID, string sOrgID)
        {
            try
            {
                DataTable dt = new DataTable();
                StringBuilder sql = new StringBuilder();         
                sql.Append(" select b.* from (select a.buyer_orgid ");
                sql.Append(" from (select distinct buyer_orgid ");
                sql.Append(" from gpo_order_item  ");
                sql.AppendFormat(" where order_id = '{0}') a ", sOrderID);
                sql.Append("where not exists (select 1 from gpo_corp_map gcm where a.buyer_orgid = gcm.org_id  collate Chinese_PRC_CI_AI_WS and  ");
                sql.AppendFormat("  map_orgid = '{0}' and org_id is not null)) o,gpo_reg_buyer b ", sOrgID);
                sql.Append(" where o.buyer_orgid=b.id  collate Chinese_PRC_CI_AI_WS ");
                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());

                return dt;
             
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 获取未匹配产品列表
        /// </summary>
        /// <param name="sOrderID"></param>
        /// <param name="sOrgID"></param>
        /// <returns></returns>
        public DataTable GetNotMapProd(string sOrderID, string sOrgID)
        {
            try
            {
                DataTable dt = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select goi.*, ghc.product_id, ");
                sql.Append("ghc.medical_name,");
                sql.Append("ghc.medical_pinyin,");
                sql.Append("ghc.medical_wubi,");
                sql.Append("ghc.trade_name,");
                sql.Append("ghc.spell_abbr,");
                sql.Append("ghc.name_wb,");
                sql.Append("ghc.doseage_form,");
                sql.Append("isnull(ghc.spec,'-') + '×' + cast(isnull(ghc.stand_rate,'0') as varchar(10)) +'/'+isnull(ghc.use_unit,'-') as ypgg,");//规格
                sql.Append("ghc.spec_unit,");
                sql.Append("ghc.stand_rate,");
                sql.Append("ghc.quality_name,");
                sql.Append("ghc.producer_fullname,");
                sql.Append("ghc.producer_shortname,");
                sql.Append("ghc.producer_wubi,");
                sql.Append("ghc.producer_pinyin");
                sql.Append(" from gpo_order_item goi left");
                sql.Append(" outer join gpo_hit_comm ghc on goi.hit_comm_id = ghc.record_id collate Chinese_PRC_CI_AI_WS ");             
                sql.AppendFormat(" where goi.order_id = '{0}'", sOrderID);
                sql.Append(" and not exists (select 1 from gpo_product_map gpm ");              
                sql.Append(" where gpm.product_id = ghc.product_id collate Chinese_PRC_CI_AI_WS ");
                sql.AppendFormat(" and gpm.map_orgid ='{0}' )  ", sOrgID);
                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable getSalerOrderList(string sOrgID)
        {
            StringBuilder sql = new StringBuilder();
            List<DbParameter> parameters = new List<DbParameter>();
            DataTable dt = null;
            sql.Append("select a.order_id,");
            sql.Append("       a.buyer_orgid,");         
            sql.Append("       a.order_code,");
            sql.Append("       a.bak_buyer_name,");
            sql.Append("       a.bak_buyer_easy,");
            sql.Append("       a.bak_buyer_fast,");
            sql.Append("       a.area_id,");
            sql.Append("       a.bak_buyer_wubi,");
            sql.Append("       a.create_date,");
            sql.Append("       convert(varchar(20),cast(a.request_total as money),1) request_total,");
            sql.Append("       a.order_state,");
            sql.Append("       b.address as org_address,");
            sql.Append("       case a.order_state");
            sql.Append("       when       '0'");
            sql.Append("       then       '发送'");
            sql.Append("       when       '1'");
            sql.Append("       then       '已阅读'");
            sql.Append("       when       '2'");
            sql.Append("       then       '交易中'");
            sql.Append("       when       '3'");
            sql.Append("       then       '完成'");
            sql.Append("       end        order_state_name ");
            sql.Append("  from GPO_ORDER a, gpo_reg_buyer b");
            sql.AppendFormat("  where saler_id = '{0}'", sOrgID);
            sql.Append("   and a.buyer_orgid = b.id ");
            sql.Append(" collate Chinese_PRC_CI_AI_WS ");


            sql.Append(" order by create_date desc ");
            try
            {
                dt = DbFacade.SQLExecuteDataTable(sql.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;

        }
        public bool isfactory(string UserId)
        {
            bool flg = false;
            StringBuilder sqlTemp = new StringBuilder();
             sqlTemp.Append("select 1 from gpo_usr_user_area  a  where a.USER_ID='").Append(UserId);
                sqlTemp.Append("' and  a.AREA_ID='MRBR00000000000000092258'");
                DataTable dtt = DbFacade.SQLExecuteDataTable(sqlTemp.ToString());
                if (dtt.Rows.Count == 0)
                {
                    flg = true;
                }
                return flg;
        }

        /// <summary>
        /// 取得订单的相关信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        //public SalerOrderModel GetOrderTitle(string orderId)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    SalerOrderModel model = null;
        //    try
        //    {
        //        sql.Append("select go.order_code as ordercode, go.order_remark as orderremark,go.bak_buyer_name as buyername,go.bak_buyer_easy as buyereasy,go.saler_name as salername, go.saler_easy as salereasy,")
        //        .Append("grb.LINK_PERSON as link_person, grb.LINK_PHONE as link_phone, grb.ADDRESS as address, grb.POST_CODE as post_code,")
        //        .Append("gp.create_date as creatdate,to_char(go.request_total,'999,999,999,990.00') as requesttotal,go.order_state as order_state,(select to_char(nvl(sum(unit_price * receive_qty),0), '999,999,999,990.00')")
        //        .Append(" from GPO_ORDER_ITEM goi, GPO_ORDER_RECEIVE gor")
        //        .Append(" where goi.record_id = gor.order_item_id")
        //        .Append(" and goi.order_id = go.order_id) receive_total,go.order_id,")
        //        .Append(" gp.create_username as username,gp.approve_username  as approveusername,decode(go.ORDER_STATE,'0','发送','1','已阅读','2','交易中','3','完成') as orderstate,gpohouse.WAREHOUSE_NAME as warehousename from GPO_ORDER go, GPO_PURCHASE gp,GPO_WAREHOUSE gpohouse, GPO_REG_BUYER grb")
        //        .Append("  where go.purchase_id = gp.id and gpohouse.ID(+)=go.REPOSITORY_ID  and go.order_id ='" + orderId + "' and go.BUYER_ORGID = grb.ID");


        //        model = DbFacade.SQLExecuteObject(sql.ToString(), new MapRow(MapOrderTitle)) as SalerOrderModel;

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return model;
        //}

        /// <summary>
        /// 查询订单明细表信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="type"></param>
        /// <param name="allFlag"></param>
        /// <returns></returns>
        //public IDataReader GetSalerOrderItemList(string orderId, string userName, string userId, bool flag)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    IDataReader reader = null;
        //    using (DbTransaction transaction = DbFacade.BeginTransaction(DbFacade.OpenConnection()))
        //    {
        //        try
        //        {
        //            if (flag)
        //            {
        //                DataTable dt = this.GetIdList(orderId, transaction);
        //                this.DoUpdateGOIStatus(orderId, userId, transaction);
        //                this.DoInsertStatusInfo(dt, userName, userId, "2", transaction);
        //                this.UpdateOrderState(orderId, userId, transaction);
        //            }


        //            sql.Append("SELECT ghc.medical_name,goi.order_id,");
        //            sql.Append("       ghc.trade_name,");
        //            sql.Append("       isnull(ghc.spec, '-') + '×' + isnull(convert(datetime,ghc.stand_rate), '-') +");
        //            sql.Append("       isnull(ghc.use_unit, '') + '/' + isnull(ghc.spec_unit, '') +");
        //            sql.Append("       decode(ghc.wrap_code, '01', '', nvl2(ghc.wrap_name, '(' +");
        //            sql.Append("                     ghc.wrap_name || ')', '')) AS ggbz,");
        //            sql.Append("       goi.record_id,");
        //            sql.Append("       ghc.product_id,");
        //            sql.Append("       goi.repository_id,");
        //            sql.Append("       ghc.producer_shortname factory_easy,");
        //            sql.Append("       ghc.producer_fullname factory_name,");
        //            sql.Append("       ghc.provide_price,");
        //            sql.Append("       goi.request_qty,");
        //            sql.Append("       gw.warehouse_name,");
        //            sql.Append("       gpi.buyer_remark,goi.item_status,");
        //            sql.Append("case goi.item_status when '2' then '已阅读' when '3' then '已确认' when '6' then '缺货' end  status ");

        //            sql.Append(",(select goi.request_qty*2 - isnull(sum(s.stockup_qty),0) from gpo_order_stockup s where s.order_item_id(+)=goi.record_id) maxQty ");

        //            sql.Append("  FROM gpo_order_item    goi,");
        //            sql.Append("       gpo_hit_comm      ghc,");
        //            sql.Append("       gpo_warehouse     gw,");
        //            sql.Append("       gpo_purchase_item gpi");
        //            sql.Append(" WHERE goi.hit_comm_id = ghc.record_id");
        //            sql.Append("   AND goi.repository_id = gw.id(+)");
        //            sql.Append("   AND goi.purchase_item_id = gpi.id");
        //            sql.Append("   AND goi.item_status IN ('2','3','6' )");
        //            sql.Append("   ");
        //            sql.Append("   AND goi.order_id = '").Append(orderId).Append("' ");

        //            //DbParameter param = base.DbFacade.CreateParameter();
        //            //param.ParameterName = "ORDER_ID";
        //            //param.DbType = DbType.String;
        //            //param.Value = orderId;                

        //            reader = DbFacade.SQLExecuteReader(sql.ToString(), transaction);
        //            DbFacade.CommitTransaction(transaction);
        //        }
        //        catch (Exception e)
        //        {
        //            DbFacade.RollbackTransaction(transaction);
        //            throw e;
        //        }
        //    }
        //    return reader;

        //}
        //刘海超 2007-8-8
        /// <summary>
        /// 订单实体托管
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapOrderTitle(IDataReader reader, int row)
        {
            SalerOrderModel model = new SalerOrderModel();
            model.Order_code = Convert.ToString(reader["ordercode"]);
            model.Order_id = Convert.ToString(reader["order_id"]);
            model.Bak_buyer_easy = Convert.ToString(reader["buyereasy"]);
            model.Address = Convert.ToString(reader["Address"]);

            model.Bak_saler_easy = Convert.ToString(reader["salereasy"]);

            model.Order_remark = Convert.ToString(reader["orderremark"]);
            model.Request_total = Convert.ToString(reader["requesttotal"]).Trim();
            model.Receive_total = Convert.ToString(reader["receive_total"]).Trim();

            model.User_name = Convert.ToString(reader["username"]);
            model.Create_date = Convert.ToString(reader["creatdate"]);
            model.Order_state = Convert.ToString(reader["order_state"]);
            model.PurchaseCreator = Convert.ToString(reader["username"]);

            model.Order_state_name = Convert.ToString(reader["orderstate"]);
            model.Post_code = Convert.ToString(reader["post_code"]);
            model.WareHouse = Convert.ToString(reader["warehousename"]);
            model.Linkman = Convert.ToString(reader["link_person"]);
            model.TelePhone = Convert.ToString(reader["link_phone"]);



            return model;
        }
        //}
        //刘海超 2007-8-8
        /// <summary>
        /// 取得订单的相关信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public SalerOrderModel GetOrderTitle(string orderId)
        {
            StringBuilder sql = new StringBuilder();
            SalerOrderModel model = null;
            try
            {
                sql.Append("select go.order_code as ordercode, go.order_remark as orderremark,go.bak_buyer_name as buyername,go.bak_buyer_easy as buyereasy,go.saler_name as salername, go.saler_easy as salereasy,")
                .Append("grb.LINK_PERSON as link_person, grb.LINK_PHONE as link_phone, grb.ADDRESS as address, grb.POST_CODE as post_code,")
                  
                .Append("gp.create_date as creatdate,convert(varchar(20),cast(go.request_total as money ),1) as requesttotal,go.order_state as order_state,(select convert(varchar(20),cast(isnull(sum(unit_price * receive_qty),0) as money),1)")
                .Append(" from GPO_ORDER_ITEM goi, GPO_ORDER_RECEIVE gor")
                .Append(" where goi.record_id = gor.order_item_id")
                .Append(" and goi.order_id = go.order_id) receive_total,go.order_id,")
                    
                .Append(" gp.create_username as username,gp.approve_username  as approveusername,case go.ORDER_STATE when '0' then '发送' when '1' then '已阅读' when '2' then '交易中' when '3' then '完成' end orderstate,gpohouse.WAREHOUSE_NAME as warehousename from  GPO_PURCHASE gp,GPO_ORDER go  left join GPO_WAREHOUSE gpohouse on go.REPOSITORY_ID=gpohouse.ID , GPO_REG_BUYER grb")
                .Append("  where go.purchase_id = gp.id collate Chinese_PRC_CI_AI_WS  and go.order_id ='" + orderId + "' and go.BUYER_ORGID = grb.ID collate Chinese_PRC_CI_AI_WS");


                model = DbFacade.SQLExecuteObject(sql.ToString(), new MapRow(MapOrderTitle)) as SalerOrderModel;

            }
            catch (Exception e)
            {
                throw e;
            }
            return model;
        }
        /// <summary>
        /// 查询订单明细表信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="type"></param>
        /// <param name="allFlag"></param>
        /// <returns></returns>
        public IDataReader GetSalerOrderItemList(string orderId)
        {
            StringBuilder sql = new StringBuilder();
            IDataReader reader = null;
            try
            {

                sql.Append("  select b.medical_name as medicalname,b.trade_name as tradename, b.doseage_form as doseage_form,");
                sql.Append("  d.order_type,isnull(b.spec, '-') + '×' + isnull(convert(varchar(20),b.stand_rate), '-') +isnull(b.use_unit, '') + '/' + isnull(b.spec_unit, '') +case b.wrap_name when null then '' when '空'  then '' else '(' + b.wrap_name + ')' end ggbz, ");
                sql.Append("  b.PRODUCER_FULLNAME as factoryfullname,b.PRODUCER_SHORTNAME factoryshortname,D.UNIT_PRICE as provide_price,");
                sql.Append("  convert(decimal(8,0),d.request_qty) as requestqty,d.buyer_desc as receiveremark, case d.item_status when '1' then '发送' ");
                sql.Append("  when '2' then '已阅读' when '3' then '已确认' when  '4' then '到货中' ");
                sql.Append("  when  '5' then '作废'  when '6' then '缺货' when '7' then '完成'  else 'k' end  itemstatus   ,");
                sql.Append("  case d.order_type when '0' then '蓝票' when '1' then '到货' when '2' then '红票' end ordertype  from GPO_HIT_COMM b, GPO_ORDER_ITEM d ");
                sql.Append("  where d.hit_comm_id = b.record_id and d.ORDER_ID='").Append(orderId).Append("'");
                reader = DbFacade.SQLExecuteReader(sql.ToString());

            }
            catch (Exception e)
            {
                throw e;
            }
            return reader;
        }
        /// <summary>
        /// 查询订单明细表信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="type"></param>
        /// <param name="allFlag"></param>
        /// <returns></returns>
        public DataTable GetSalerOrderItemList(string orderId, string userName, string userId, bool flag)
        {
            StringBuilder sql = new StringBuilder();
            DataTable reader = null;
            using (DbTransaction transaction = DbFacade.BeginTransaction(DbFacade.OpenConnection()))
            {
                try
                {
                    if (flag)
                    {
                        DataTable dt = this.GetIdList(orderId, transaction);
                        this.DoUpdateGOIStatus(orderId, userId, transaction);
                        this.DoInsertStatusInfo(dt, userName, userId, "2", transaction);
                        this.UpdateOrderState(orderId, userId, transaction);
                    }

                    sql.Append("SELECT ghc.medical_name,goi.order_id,");
                    sql.Append("       ghc.trade_name,");
                    sql.Append("       isnull(ghc.spec, '-') + '×' + isnull(convert(varchar(20),ghc.stand_rate), '-') +");
                    sql.Append("       isnull(ghc.use_unit, '') + '/' + isnull(ghc.spec_unit, '') +");
                    sql.Append("       case ghc.wrap_code when '01' then '' else (case ghc.wrap_name when null then '' else '(' + ghc.wrap_name + ')' end) end ggbz,");

                    sql.Append("       goi.record_id,");
                    sql.Append("       ghc.product_id,");
                    sql.Append("       goi.repository_id,");
                    sql.Append("       ghc.producer_shortname factory_easy,");
                    sql.Append("       ghc.producer_fullname factory_name,");
                    sql.Append("       ghc.provide_price,");
                    sql.Append("       convert(decimal(8,0),goi.request_qty) as request_qty,");
                    sql.Append("       gw.warehouse_name,");
                    sql.Append("       gpi.buyer_remark,goi.item_status,");
                    sql.Append("case goi.item_status when '2' then'已阅读' when '3' then '已确认' when '6' then '缺货' else '' end status ");

                    sql.Append(", convert(decimal(8,0),g.maxQty ) as maxQty");

                    sql.Append("  FROM gpo_order_item    goi left join gpo_warehouse     gw on  goi.repository_id = gw.id,");
                    sql.Append("       gpo_hit_comm      ghc,(select goi.hit_comm_id,goi.record_id,(goi.request_qty * 2 - isnull(sum(s.stockup_qty), 0))as maxQty from gpo_order_stockup s right join gpo_order_item goi on s.order_item_id = goi.record_id  GROUP BY goi.hit_comm_id,goi.request_qty,goi.record_id) g,");
                    sql.Append("       gpo_purchase_item gpi");
                    sql.Append(" WHERE goi.hit_comm_id = ghc.record_id");
                    sql.Append("  and goi.hit_comm_id=g.hit_comm_id");
                    sql.Append("   and goi.record_id=g.record_id");
                    sql.Append("   AND goi.purchase_item_id = gpi.id");
                    sql.Append("   AND goi.item_status IN ('2','3','6' )");

                    sql.Append("   AND goi.order_id = '").Append(orderId).Append("' ");
                     reader = DbFacade.SQLExecuteDataTable(sql.ToString(), transaction);
                    //reader = DbFacade.SQLExecuteReader(sql.ToString(), transaction);
                  
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            return reader;

        }

        #region 查询待确定和已确定的送货列表
        /// <summary>
        /// 查询待确定和已确定的送货列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pageParam"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public IDataReader selectOrderPrepareItemListJP(InputInfoModel input)
        {
            StringBuilder sb = new StringBuilder();
            IDataReader reader = null;

            if (input.Received)
            {
                // 已到货且启用药库
                if (input.RepositoryBz.Equals("1"))
                {
                    sb.Append("select top 100 percent  o.*, r.receive_qty receiveQty, ");
                    sb.Append(" o.BAK_MEDICAL_NAME O_BAK_MEDICAL_NAME, ");
                    sb.Append(" o.BAK_PRODUCT_NAME O_BAK_PRODUCT_NAME, ");
                    sb.Append(" o.BAK_PRODUCT_SPEC O_BAK_PRODUCT_SPEC, ");
                    sb.Append(" o.BAK_FACTORY_NAME O_BAK_FACTORY_NAME, ");
                    sb.Append(" o.UNIT_PRICE O_UNIT_PRICE, ");
                    sb.Append(" o.REQUEST_QTY O_REQUEST_QTY, ");
                    sb.Append(" o.RECEIVE_QTY O_RECEIVE_QTY, ");
                    sb.Append(" r.app_num r_app_num, ");
                    sb.Append(" r.lot_no r_lot_no, ");
                    sb.Append(" r.receive_qty r_receive_qty, ");
                    sb.Append(" case o.REMARK when '' then '-' when null then '-' else o.REMARK end O_REMARK, ");

                    sb.Append(" r.invoice_no r_invoice_no, ");
                    sb.Append(" isnull(r.invoice_total, '') r_invoice_total, ");
                    sb.Append(" isnull(r.invoice_trade_price, '') r_invoice_trade_price, ");
                    sb.Append(" isnull(r.invoice_retail_price, '') r_invoice_retail_price, ");
                    sb.Append(" r.invoice_discount_rate r_invoice_discount_rate, ");
                    sb.Append(" CONVERT(varchar(20),r.invoice_date,1111) r_invoice_date, ");
                    sb.Append(" CONVERT(varchar(20),r.invoice_expire_date, 111) r_invoice_expire_date, ");
                    sb.Append(" r.ready_remark r_ready_remark, ");
                    sb.Append(" r.id r_ID, ");
                    sb.Append(" o.RECORD_ID O_RECORD_ID, ");
                    sb.Append(" o.ORDER_ID O_ORDER_ID, ");
                    sb.Append(" o.PLAT_ID O_PLAT_ID, ");

                    sb.Append("r.app_num, "); // added by Jiang Ping, 2005-3-16
                    sb.Append("r.id, r.lot_no, nvl(r.receive_flag, '0') receiveFlag, ");
                    sb.Append("w.warehouse_name, r.invoice_date, r.invoice_no, r.ready_remark, ");
                    sb.Append("r.invoice_total, r.invoice_trade_price, r.invoice_retail_price, r.invoice_discount_rate, ");
                    sb.Append("r.invoice_expire_date, CONVERT(varchar(20),r.receive_date,120) as receive_date ,CONVERT(varchar(20),r.receive_date,120) as R_RECEIVE_DATE ");

                    if (input.Idx)
                        sb.Append("FROM ord_order_item o left join  ord_warehouse w  o.repository_id = w.warehouse_id, ord_order_receive r ");/////////
                    else
                        sb.Append("FROM ord_order_item_non o, ord_order_receive_non r, ord_warehouse w ");

                    sb.Append("WHERE o.record_id = r.reder_item_id ");
                    sb.Append("and r.receive_flag = '1' ");
                    //sb.Append("and o.order_id = :order_id ");
                    sb.AppendFormat(" and o.order_id = '{0}' ", input.OrderId);
                    sb.Append("and o.repository_id = w.warehouse_id(+) ");
                }
                // 已到货未启用药库
                else
                {
                    sb.Append("select top 100 percent a.receive_date as receivedate,");
                    sb.Append("       b.medical_name as medicalname,");
                    sb.Append("       b.trade_name as tradename,");
                    sb.Append("       b.doseage_form as doseageform,");
                    sb.Append("       isnull(b.spec, '-') + '×' + isnull(convert(varchar(20),b.stand_rate), '-') +");
                    sb.Append("       isnull(b.use_unit, '') + '/' + isnull(b.spec_unit, '') +");
                    sb.Append("       case b.wrap_name when null then '' when '空' then '' else '(' + b.wrap_name + ')' end ggbz,");
                    sb.Append("       b.PRODUCER_FULLNAME as factoryfullname,");
                    sb.Append("       b.PRODUCER_SHORTNAME as factoryshortname,");
                    sb.Append("       b.provide_price as provideprice,");
                    sb.Append("       convert(decimal(8,0),c.REQUEST_QTY) as requestqty,");
                    sb.Append("       a.TRADE_QTY as tradeqty,");
                    sb.Append("       a.LOT_NO as sendlot,");
                    sb.Append("       convert(decimal(8,0),a.receive_qty) as receiveqty,");
                    sb.Append("       a.INVOICE_NO as invoiceno,");
                    sb.Append("       CONVERT(varchar(20),a.invoice_date,111) as invoicedate,");
                    sb.Append("       c.buyer_desc as buyerremark");
                    sb.Append("  from GPO_ORDER_RECEIVE a, GPO_HIT_COMM b, GPO_ORDER_ITEM c");
                    sb.Append(" where a.order_item_id = c.record_id");
                    sb.Append("   and b.record_id = c.hit_comm_id");

                    sb.AppendFormat(" and a.order_id = '{0}' ", input.OrderId);
                }

                if (string.IsNullOrEmpty(input.SortField))
                {
                    input.SortField = "receivedate";
                    input.SortMethod = "desc";
                }
            }
            else
            {
                if (input.RepositoryBz.Equals("1"))
                {
                    sb.Append("SELECT o.*, r.id, r.receive_qty receiveQty, r.ready_date, ");
                    sb.Append(" o.BAK_MEDICAL_NAME O_BAK_MEDICAL_NAME, ");
                    sb.Append(" o.BAK_PRODUCT_NAME O_BAK_PRODUCT_NAME, ");
                    sb.Append(" o.BAK_PRODUCT_SPEC O_BAK_PRODUCT_SPEC, ");
                    sb.Append(" o.BAK_FACTORY_NAME O_BAK_FACTORY_NAME, ");
                    sb.Append(" o.UNIT_PRICE O_UNIT_PRICE, ");
                    sb.Append(" o.REQUEST_QTY O_REQUEST_QTY, ");
                    sb.Append(" o.RECEIVE_QTY O_RECEIVE_QTY, ");
                    sb.Append(" r.app_num r_app_num, ");
                    sb.Append(" r.lot_no r_lot_no, ");
                    sb.Append(" r.receive_qty r_receive_qty, ");
                    sb.Append(" case o.REMARK when '' then '-' when null then '-' else o.REMARK end O_REMARK, ");

                    sb.Append(" r.invoice_no r_invoice_no, ");
                    sb.Append(" isnull(r.invoice_total, '') r_invoice_total, ");
                    sb.Append(" isnull(r.invoice_trade_price, '') r_invoice_trade_price, ");
                    sb.Append(" isnull(r.invoice_retail_price, '') r_invoice_retail_price, ");
                    sb.Append(" r.invoice_discount_rate r_invoice_discount_rate, ");
                    sb.Append(" CONVERT(varchar(20),r.invoice_date, 111) r_invoice_date, ");
                    sb.Append(" CONVERT(varchar(20),r.invoice_expire_date,111) r_invoice_expire_date, ");
                    sb.Append(" r.ready_remark r_ready_remark, ");
                    sb.Append(" r.id r_ID, ");
                    sb.Append(" o.RECORD_ID O_RECORD_ID, ");
                    sb.Append(" o.ORDER_ID O_ORDER_ID, ");
                    sb.Append(" o.PLAT_ID O_PLAT_ID, ");

                    sb.Append("r.app_num, ");
                    sb.Append("r.lot_no, nvl(r.receive_flag, '0') receiveFlag, r.ready_remark, ");
                    sb.Append("w.warehouse_name, r.invoice_date, r.invoice_no, r.invoice_expire_date, ");
                    sb.Append("r.invoice_total, r.invoice_trade_price, r.invoice_retail_price, r.invoice_discount_rate, ");
                    sb.Append("CONVERT(varchar(20),r.receive_date,120) as receive_date,CONVERT(varchar(20),r.receive_date,111) as R_RECEIVE_DATE ");

                    if (input.Idx)
                        sb.Append("FROM ord_order_item o, ord_order_receive r, ord_warehouse w ");
                    else
                        sb.Append("FROM ord_order_item_non o, ord_order_receive_non r, ord_warehouse w ");

                    sb.Append("WHERE o.record_id = r.reder_item_id ");
                    if (input.FillInvoice != null && input.FillInvoice.Equals("true"))
                    {
                        // 如果是只填写发票，则不用判断订单到货的标志
                    }
                    else
                    {
                        sb.Append("and (r.receive_flag = '0' or r.receive_flag = '9' or r.receive_flag is null) ");
                    }
                    //sb.Append("and o.order_id = :order_id ");
                    sb.AppendFormat(" and o.order_id = '{0}' ", input.OrderId);
                    sb.Append("and o.repository_id = w.warehouse_id(+) ");
                }
                else
                {
                    sb.Append(" select top 100 percent goi.item_status,case goi.item_status when '2' then '已阅读' when '3' then '已确认' when '4' then '到货中' when '5' then '作废' when '6' then '缺货' end status,");
                    sb.Append("        gos.id,gos.order_id,gos.order_item_id,");
                    sb.Append("        ghc.medical_name,");
                    sb.Append("        ghc.trade_name,");
                    sb.Append("        isnull(ghc.spec, '-') + '×' + isnull(convert(varchar(20),ghc.stand_rate), '-') +");
                    sb.Append("        isnull(ghc.use_unit, '') + '/' + isnull(ghc.SPEC_UNIT, '') +");
                    sb.Append("        case ghc.wrap_code when ");
                    sb.Append("               '01' then");
                    sb.Append("               '' else");
                    sb.Append("               (case ghc.wrap_name  when null then '' else '(' + ghc.wrap_name + ')' end) end ggbz,");
                    sb.Append("        ghc.PRODUCER_SHORTNAME factory_easy,");
                    sb.Append("        ghc.PRODUCER_FULLNAME factory_name,");
                    sb.Append("        ghc.provide_price,");
                    sb.Append("        convert(decimal(8,0),goi.request_qty) as request_qty,");
                    sb.Append("        gpi.buyer_remark,");

                    sb.Append("        gos.lot_no,");
                    sb.Append("        convert(decimal(8,0),gos.stockup_qty) as stockup_qty,");
                    sb.Append("        gos.invoice_no,");
                    sb.Append("        CONVERT(varchar(20),gos.invoice_date,111) invoice_date,");
                    sb.Append("        gos.ready_date,");
                    sb.Append("        CONVERT(varchar(20),gos.invoice_expire_date,111) invoice_expire_date,");
                    sb.Append("        gos.amount,");
                    sb.Append("        gos.trade_price,");
                    sb.Append("        gos.retail_price,");
                    sb.Append("        gos.discount,");
                    sb.Append("        gos.remark,");
                    sb.Append("        gos.ready_flag,");
                    //sb.Append("        (select goi.request_qty * 2 - sum(st.stockup_qty)");
                    //sb.Append("           from gpo_order_stockup st");
                    //sb.Append("          where st.order_item_id = gos.order_item_id");
                    sb.Append("          convert(decimal(8,0),g.maxQty) as maxQty,ghc.saler_id");
                    sb.Append("   from GPO_ORDER_STOCKUP gos,(select goi.hit_comm_id,goi.record_id,(goi.request_qty*2 - isnull(sum(s.stockup_qty), 0))as maxQty from gpo_order_stockup s right join gpo_order_item goi on s.order_item_id = goi.record_id   GROUP BY goi.hit_comm_id,goi.request_qty,goi.record_id) g,");
                    sb.Append("        GPO_HIT_COMM      ghc,");
                    sb.Append("        GPO_ORDER_ITEM    goi,");
                    sb.Append("        GPO_PURCHASE_ITEM gpi");
                    sb.Append("  where goi.hit_comm_id = ghc.record_id");
                    sb.Append("  and goi.hit_comm_id=g.hit_comm_id");
                    sb.Append("   and goi.record_id=g.record_id");
                    sb.Append("    and goi.purchase_item_id = gpi.id");
                    sb.Append("    and goi.record_id = gos.order_item_id");
                    sb.Append("    and goi.order_id = '").Append(input.OrderId).Append("'");
                    sb.Append("    and goi.item_status != '7'");
                }
                if (string.IsNullOrEmpty(input.SortField))
                {
                    input.SortField = "ready_date";
                    input.SortMethod = "desc";
                }
            }
            sb.Append(" order by ");
            sb.Append(input.SortField);
            sb.Append(" ");
            sb.Append(input.SortMethod);

            StringBuilder sql = new StringBuilder();
            sql.Append(" select ROW_NUMBER() over(order by ");
            sql.Append(input.SortField);
            sql.Append("  )  as rownum,x.* from (");
            sql.Append(sb.ToString());
            sql.Append(") x");



            try
            {
                reader = DbFacade.SQLExecuteReader(sql.ToString());
            }
            catch (Exception e)
            {

                throw e;
            }

            return reader;
        }
        #endregion
        //刘海超 2007-8-16
        /// <summary>
        /// 到货处理
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="remark"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ReceiveOrder(IList result, string remark, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            string orderId = "";
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (SalerOrderItemModel model in result)
                    {
                        if (!model.IsChecked)
                            continue;
                        if (string.IsNullOrEmpty(orderId))
                            orderId = model.OrderId;
                        if (!SaveOrderReceive(transaction, model, ui))
                        {
                            DbFacade.RollbackTransaction(transaction);
                            break;
                        }

                    }


                    StringBuilder sql = new StringBuilder();
                    sql.Append("update gpo_order set order_remark ='").Append(remark).Append("',MODIFY_USERID = '").Append(ui.Id).Append("',MODIFY_DATE = getdate(),SYNC_STATE='0' where order_id = '").Append(orderId).Append("'");
                    DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);

                    DbFacade.CommitTransaction(transaction);

                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            return true;
        }

        /// <summary>
        /// 新增订单到货表信息
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        private bool SaveOrderReceive(DbTransaction transaction, SalerOrderItemModel model, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO Gpo_Order_Stockup( ID,");
            sql.Append(" ORDER_ID,");
            sql.Append(" ORDER_ITEM_ID,");
            sql.Append(" PRODUCT_ID,");
            sql.Append(" LOT_NO,STOCKUP_QTY,");

            sql.Append(" READY_USERID,");
            sql.Append(" READY_DATE,");

            sql.Append(" INVOICE_NO,");
            sql.Append(" INVOICE_DATE,");
            sql.Append(" INVOICE_EXPIRE_DATE,");
            sql.Append(" AMOUNT,");
            sql.Append(" TRADE_PRICE,");
            sql.Append(" RETAIL_PRICE,");
            sql.Append(" DISCOUNT,");

            sql.Append(" REPOSITORY_ID,");

            sql.Append(" REMARK,");
            sql.Append(" READY_FLAG,MODIFY_USER,MODIFY_DATE,SYNC_STATE) VALUES(");
            sql.AppendFormat("'{0}',", this.GetGlobalId());
            sql.AppendFormat("'{0}',", model.OrderId);
            sql.AppendFormat("'{0}',", model.RecordId);
            sql.AppendFormat("'{0}',", model.ProductId);
            sql.AppendFormat("'{0}',", model.LotNo);
            sql.AppendFormat("{0},", model.ReceiveQty1);

            sql.AppendFormat("'{0}',", ui.Id);
            sql.Append("getdate(),");
            sql.AppendFormat("'{0}',", model.InvoiceNo);
            if (!string.IsNullOrEmpty(model.InvoiceDate))
                sql.AppendFormat("CONVERT(varchar(20),'{0}',111),", model.InvoiceDate);
            else
                sql.Append("null,");
            if (!string.IsNullOrEmpty(model.InvoiceExpireDate))
                sql.AppendFormat("CONVERT(varchar(20),'{0}',111),", model.InvoiceExpireDate);
            else
                sql.Append("null,");
            if (string.IsNullOrEmpty(model.InvoiceTotal))
                sql.Append("null,");
            else
                sql.Append(model.InvoiceTotal).Append(",");

            if (string.IsNullOrEmpty(model.InvoiceTradePrice))
            {
                sql.Append("null,");
            }
            else
            {
                sql.Append(model.InvoiceTradePrice).Append(",");
            }
            if (string.IsNullOrEmpty(model.InvoiceRetailPrice))
            {
                sql.Append("null,");
            }
            else
            {
                sql.Append(model.InvoiceRetailPrice).Append(",");
            }
            if (string.IsNullOrEmpty(model.InvoiceDiscountRate))
            {
                sql.Append("null,");
            }
            else
            {
                sql.Append(model.InvoiceDiscountRate).Append(",");
            }

            sql.AppendFormat("'{0}',", model.RepositoryId);
            sql.AppendFormat("'{0}',", model.ReadyRemark);
            sql.AppendFormat("'{0}',", "0");
            sql.AppendFormat("'{0}',", ui.Id);
            sql.Append("getdate(),'0')");

            int result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            if (result > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 取得订单明细id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private DataTable GetIdList(string orderId, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select record_id from gpo_order_item where item_status = '1' and order_id = '");
            sql.Append(orderId).Append("' ");

            DataTable dt = DbFacade.SQLExecuteDataTable(sql.ToString(), transaction);
            return dt;
        }
        /// <summary>
        /// 更新订单明细状态为已阅读
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="userId"></param>
        private void DoUpdateGOIStatus(string orderId, string userId, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update gpo_order_item set item_status = '2',MODIFY_DATE=getdate(),SYNC_STATE='0',MODIFY_USERID='").Append(userId).Append("' ");
            sql.Append(" where item_status = '1' and order_id = '");
            sql.Append(orderId).Append("' ");

            DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);

        }



        /// <summary>
        /// 更新订单明细状态（重载１）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="tableName"></param>
        /// <param name="orderItemId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateOrderItemStateByIdGPO(string userId, string orderState, string tableName, string orderItemId, DbTransaction transaction)
        {
            bool flg = false;
            StringBuilder sql = new StringBuilder();
            int result;
            sql.Append("update ").Append(tableName);
            sql.Append(" set modify_date = getdate(),");
            sql.Append(" modify_userid  = '").Append(userId).Append("',");
            sql.Append(" Item_Status = '").Append(orderState).Append("',SYNC_STATE='0' ");

            sql.Append(" where RECORD_ID = '").Append(orderItemId).Append("'");
            try
            {
                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
                if (result > 0)
                {
                    flg = true;
                }

                else
                {
                    flg = false;

                }

            }
            catch (Exception e)
            {
                flg = false;
                throw e;
            }
            return flg;

        }



        /// <summary>
        /// 缺货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool OrderLack(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            string orderId = null;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (SalerOrderItemModel model in result)
                    {
                        if (string.IsNullOrEmpty(orderId))
                            orderId = model.OrderId;
                        UpdateOrderItemStateByIdGPO(ui.Id, "6", "GPO_ORDER_ITEM", model.RecordId, transaction);
                        this.DoInsertStatusInfo(model.RecordId, ui.Name, ui.Id, "6", transaction);


                    }
                    this.UpdateOrderState(orderId, ui.Id, transaction);
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }

            }
            return true;
        }



        /// <summary>
        /// 取消缺货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool OrderCancelLack(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            string orderId = null;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (SalerOrderItemModel model in result)
                    {
                        if (string.IsNullOrEmpty(orderId))
                            orderId = model.OrderId;
                        UpdateOrderItemStateByIdGPO(ui.Id, "2", "GPO_ORDER_ITEM", model.RecordId, transaction);
                        this.DoInsertStatusInfo(model.RecordId, ui.Name, ui.Id, "2", transaction);

                    }
                    this.UpdateOrderState(orderId, ui.Id, transaction);
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }

            }
            return true;
        }
        /// <summary>
        /// 插入订单明细状态表信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        private void DoInsertStatusInfo(DataTable dt, string userName, string userId, string state, DbTransaction transaction)
        {
            foreach (DataRow dr in dt.Rows)
            {
                DoInsertStatusInfo(dr[0].ToString(), userName, userId, state, transaction);
            }
        }

        /// <summary>
        /// 插入订单明细状态表信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        private void DoInsertStatusInfo(string recordId, string userName, string userId, string state, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Gpo_Item_Status values('");
            sql.Append(this.GetGlobalId()).Append("','").Append(recordId).Append("','").Append(state).Append("','").Append(userId).Append("','").Append(userName).Append("',getdate(),'0')");
            DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);

        }
         /// <summary>
        /// 当订单明细表的订单状态变化之后调用该方法更新订单主表的订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        private void UpdateOrderState(string orderId, string userId,DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select max(i.item_status) from gpo_order_item i where i.order_id='").Append(orderId).Append("'");
            int maxState = int.Parse(DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString());
            sql.Remove(0, sql.Length);

            sql.Append("select min(i.item_status) from gpo_order_item i where i.order_id='").Append(orderId).Append("'");
            int minState = int.Parse(DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString());
            sql.Remove(0, sql.Length);

            sql.Append("select count(*) from gpo_order_item i where i.order_id='").Append(orderId).Append("' and i.item_status = '6' ");
            int oosNum = int.Parse(DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString());
            sql.Remove(0, sql.Length);

            // 如果maxState=1发送，那么订单主表的订单状态为0准备
		    if (maxState == 1) {
                UpdateOrderState(orderId, "0", userId, transaction);
		    }
		    // 如果maxState=2已阅读，那么订单主表的订单状态为1已阅读
		    else if (maxState == 2) {
                UpdateOrderState(orderId, "1", userId, transaction);
		    }
		    // 如果minState>=5,并且oosNum=0,那么订单主表的订单状态为3完成
		    else if (minState >= 5 && oosNum ==0) {
                UpdateOrderState(orderId, "3", userId, transaction);
		    }
		    // 剩下的情况，订单主表的订单状态为2交易中
		    else {
                UpdateOrderState(orderId, "2", userId, transaction);
		    }
        }

        /// <summary>
        /// 改变订单主表的订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderState"></param>
        /// <param name="modifyUserId"></param>
        private void UpdateOrderState(String orderId,String orderState, String modifyUserId,DbTransaction transaction) 
        {
	        StringBuilder sql = new StringBuilder();
	        sql.Append(" update gpo_order  set order_state='")
			        .Append(orderState).Append("'");
	        sql.Append(", modify_userid = '").Append(modifyUserId).Append(
                    "', modify_date = getdate(),SYNC_STATE='0' ");
	        sql.Append(" where order_id='").Append(orderId).Append("'");
            DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
        }

        /// <summary>
        /// 判断同一个企业的备货发票是否有重复 有重复返回true
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public bool IsInvoiceExists(IList resultList)
        {
            string result = "";
            string invoiceNo = "";
            string salerId = "";
            StringBuilder sql = new StringBuilder();
            try
            {
                
                foreach (OutputInfoModel model in resultList)
                {
                    if (!model.IsCheck)
                        continue;
                    salerId = model.Saler_id;
                    if (!string.IsNullOrEmpty(model.R_invoice_no))
                        invoiceNo += ",'" + model.R_invoice_no + "'";

                }
                sql.Append("select count(*) from gpo_order_stockup r ,gpo_order o");
                sql.Append("   where r.order_id = o.order_id");
                sql.Append("   and r.ready_flag = '1'");//已确认
                sql.Append("   and o.saler_id='").Append(salerId).Append("'");
                sql.Append("    and r.invoice_no in (''");
                sql.Append(invoiceNo).Append(")");

                result = DbFacade.SQLExecuteScalar(sql.ToString()).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (result.Equals("0"))          
                return false;
            else
                return true;

        }

        /// <summary>
        /// 修改备货信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ModifyOrderReceive(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {

                    foreach (OutputInfoModel model in result)
                    {

                        if (!model.IsCheck)
                            continue;
                        UpdateOrderReceive(transaction, model, ui, false);

                    }


                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }

            }
            return true;
        }
        /// <summary>
        /// 修改备货表
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private bool UpdateOrderReceive(DbTransaction transaction, OutputInfoModel model, Emedchina.TradeAssistant.Model.User.UserInfo ui, bool flag)
        {
            StringBuilder sql = new StringBuilder();
            
            sql.Append(" update Gpo_Order_Stockup ");

            sql.AppendFormat(" set LOT_NO = '{0}',", model.LOT_NO);
            sql.AppendFormat(" STOCKUP_QTY = {0},", model.RECEIVE_QTY);

            sql.AppendFormat(" INVOICE_NO = '{0}',", model.R_invoice_no);
            if (!string.IsNullOrEmpty(model.R_invoice_date))
                sql.AppendFormat(" INVOICE_DATE = CONVERT(varchar(20),'{0}',111),", model.R_invoice_date);
            else
                sql.Append(" INVOICE_DATE = null,");

            if (!string.IsNullOrEmpty(model.R_invoice_expire_date))
                sql.AppendFormat(" INVOICE_EXPIRE_DATE = CONVERT(varchar(20),'{0}',111),", model.R_invoice_expire_date);
            else
                sql.Append(" INVOICE_EXPIRE_DATE = null,");

            sql.AppendFormat(" AMOUNT = {0},", model.R_invoice_total== "" ?"0" :model.R_invoice_total);
            sql.AppendFormat(" TRADE_PRICE = {0},", model.R_invoice_trade_price == "" ?"0" : model.R_invoice_trade_price);
            sql.AppendFormat(" RETAIL_PRICE = {0},", model.R_invoice_retail_price== "" ?"0" :model.R_invoice_retail_price);
            sql.AppendFormat(" DISCOUNT = {0},", model.R_invoice_discount_rate== "" ?"0" :model.R_invoice_discount_rate);

            if (flag)
            {
                sql.Append(" READY_FLAG = '1',");
            }
            else
            {
                sql.Append(" READY_DATE = getdate(),SYNC_STATE='0',");
                sql.AppendFormat(" READY_USERID = '{0}',", ui.Id);
            }
            sql.AppendFormat(" MODIFY_USER = '{0}',", ui.Id);
            sql.AppendFormat(" MODIFY_DATE = getdate(),");
            sql.AppendFormat(" REMARK = '{0}'", model.R_ready_remark);
            sql.AppendFormat(" where ID = '{0}'", model.R_ID);

            int result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            if (result > 0)
                return true;
            else
                return false;

        }
        /// <summary>
        /// 删除送货信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool DeleteOrderReceive(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {

                    foreach (OutputInfoModel model in result)
                    {
                        if (!model.IsCheck)
                            continue;
                        DeleteOrderReceive(transaction, model.R_ID,ui);

                    }


                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }

            }
            return true;
        }
        /// <summary>
        /// 删除备货表信息
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteOrderReceive(DbTransaction transaction, string id, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" delete from Gpo_Order_Stockup");
            sql.AppendFormat(" where ID = '{0}'", id);
            //新增DEL_LOG
            string sqlLog = "select ID from Gpo_Order_Stockup  where purchase_id = '" + id + "'";
            

            bool insertflg = false;

            insertflg = base.addDelLog("Gpo_Order_Stockup", id, "ID", ui.Id, "1", transaction);

            int result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            if (result > 0 && insertflg)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 确认到货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ConfirmOrderReceive(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            string orderId = "";
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {

                    foreach (OutputInfoModel model in result)
                    {
                        if (!model.IsCheck)
                            continue;
                        if (string.IsNullOrEmpty(orderId))
                        {
                            orderId = model.O_ORDER_ID;
                        }
                        //更新备货表
                        UpdateOrderReceive(transaction, model, ui, true);
                        // 修改订单明细表状态
                        UpdateOrderItemStateByIdGPO(ui.Id, "3", "gpo_order_item", model.O_RECORD_ID, transaction);
                        // 插入订单明细状态表信息
                        this.DoInsertStatusInfo(model.O_RECORD_ID, ui.Name, ui.Id, "3", transaction);


                    }
                    // 更新订单主表的订单状态
                    this.UpdateOrderState(orderId, ui.Id, transaction);
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }

            }
            return true;
        }


        //"导入订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-28            
        public bool GetOrderItem(string orderItemid)
        {
            bool flag = false;
            StringBuilder sql = new StringBuilder();
            sql.Append("select goi.record_id from gpo_order_item goi where goi.record_id = '").Append(orderItemid).Append("'");
            //sql.Append(" and goi.buyer_orgid='").Append(buyerorgId).Append("'");
            try
            {
                DataTable dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
                if (dt.Rows.Count > 0)
                {
                    flag = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        #region "进销存"对接功能 2007-9-4
        //导出产品信息
        public DataTable GetProductInfo(string buyerorgid)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT distinct cp.PRODUCT_ID     as cpid,");
            sql.Append("               cp.medical_code     as cpbm,");
            sql.Append("               cp.MEDICAL_NAME     as cptym,");
            sql.Append("               cp.TRADE_NAME       as cpspm,");
            sql.Append("               ci.doseage_form     as jxmc,");
            sql.Append("               ci.SPEC             as ggbz,");
            sql.Append("               ci.use_unit         as zxsydw,");
            sql.Append("               ci.stand_rate       as zhb,");
            sql.Append("               ci.spec_unit        as bzdw,");
            sql.Append("               ''                  as pzwh,");
            sql.Append("               ci.factory_name     as scqymc,");
            sql.Append("               ci.factory_id       as scqybm,");
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

        //导出企业信息
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

        #endregion

    }
}
