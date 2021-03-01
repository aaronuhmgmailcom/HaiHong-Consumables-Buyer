//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerOrderDAO.cs  
//	创 建 人:	曹杰
//	创建日期:	2007-1-18
//	功能描述:	订单处理数据访问层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//======================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using Emedchina.Commons.Data;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.DAL.Common;

namespace Emedchina.TradeAssistant.DAL.Order.SalerOrder
{
    public class SalerOrderDAO : OracleDAOBase
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

        

//        #region 查询订单信息
//        /// <summary>
//        /// 根据orderId查询ord_order表信息
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <returns></returns>
//        private string getSelectOrderSql(string orderId)
//        {
//            string sql = @"select o.order_id,
//                           o.plat_id,
//                           o.bak_buyer_name,
//                           o.buyer_orgid,
//                           o.saler_orgid,
//                           o.sender_orgid,
//                           o.bak_saler_name,
//                           o.bak_sender_name,
//                           o.order_remark,
//                           o.request_total,
//                           o.receive_total,
//                           o.bak_create_username as user_name,
//                           o.create_date,
//                           O.ORDER_STATE,
//                           o.purchase_id,
//                           DECODE(O.ORDER_STATE,'1','未阅读','2','已阅读','3','已确认','4','收货中','6','作废','5','完成') AS ORDER_STATE_NAME,
//                           o.repository_id,
//                           o.order_code
//                      from ord_order o
//                     where o.order_id = '" + orderId + "'";
                           
//            return sql;
//        }

//        /// <summary>
//        /// 根据orderId查询ord_order_non表信息
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <returns></returns>
//        private string getSelectOrderNonSql(string orderId)
//        {
//            string sql = @"select o.order_id,
//                           o.plat_id,
//                           o.bak_buyer_name,
//                           o.buyer_orgid,
//                           o.saler_orgid,
//                           o.sender_orgid,
//                           o.bak_saler_name,
//                           o.bak_sender_name,
//                           o.order_remark,
//                           o.request_total,
//                           o.receive_total,
//                           o.bak_create_username as user_name,
//                           o.create_date,
//                           O.ORDER_STATE,
//                           o.purchase_id,
//                           DECODE(O.ORDER_STATE,'1','未阅读','2','已阅读','3','已确认','4','收货中','6','作废','5','完成') AS ORDER_STATE_NAME,
//                           o.repository_id,
//                           o.order_code
//                      from ord_order_non o
//                     where o.order_id = '" + orderId + "'";
                                                     
//            return sql;
//        }

//        /// <summary>
//        /// 根据type查询订单信息
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <param name="type"></param>
//        /// <returns></returns>
//        private SalerOrderModel GetOrderById(string orderId,string type)
//        {
//            SalerOrderModel model = null;
//            if(type.Equals("1")){
//                //model = base.DbFacade.SQLQueryObjectById(getSelectOrderSql(orderId), orderId, new MapRow(MapOrder)) as SalerOrderModel;
                
//                //DbParameter para = DbFacade.CreateParameter();
//                //para.ParameterName = "ID";
//                //para.DbType = DbType.String;
//                //para.Value = orderId;
//                //DataTable dt = base.DbFacade.SQLExecuteDataTable(getSelectOrderSql(), para);

//                model = base.DbFacade.SQLExecuteObject(getSelectOrderSql(orderId), new MapRow(MapOrder)) as SalerOrderModel;
//            }
//            if (type.Equals("2"))
//                model = base.DbFacade.SQLExecuteObject(getSelectOrderNonSql(orderId), new MapRow(MapOrderNon)) as SalerOrderModel;
//            return model;
//        }
//        #endregion

//        #region 订单实体托管
//        /// <summary>
//        /// 订单实体托管
//        /// </summary>
//        /// <param name="reader">The reader.</param>
//        /// <param name="rowNumber">The row number.</param>
//        /// <returns></returns>
//        private object MapOrder(IDataReader reader,int row)
//        {
//            SalerOrderModel model = new SalerOrderModel();
//            model.Order_id = Convert.ToString(reader["order_id"]);
//            model.Bak_buyer_easy = Convert.ToString(reader["bak_buyer_name"]);
//            model.Buyer_orgid = Convert.ToString(reader["buyer_orgid"]);
//            model.Saler_orgid = Convert.ToString(reader["saler_orgid"]);
//            model.Sender_orgid = Convert.ToString(reader["sender_orgid"]);
//            model.Bak_saler_easy = Convert.ToString(reader["bak_saler_name"]);
//            model.Bak_sender_easy = Convert.ToString(reader["bak_sender_name"]);
//            model.Order_remark = Convert.ToString(reader["order_remark"]);
//            model.Request_total = Convert.ToString(reader["request_total"]);
//            model.Receive_total = Convert.ToString(reader["receive_total"]);

//            model.User_name = Convert.ToString(reader["user_name"]);
//            model.Create_date = Convert.ToString(reader["create_date"]);
//            model.Order_state = Convert.ToString(reader["order_state"]);
//            model.PurchaseCreator = this.getPurchaseCreator(Convert.ToString(reader["purchase_id"]));
//            model.Order_code = Convert.ToString(reader["order_code"]);
//            model.Order_state_name = Convert.ToString(reader["order_state_name"]);
//            model.Repository_id = Convert.ToString(reader["repository_id"]);
//            model.Plat_id = Convert.ToString(reader["plat_id"]);
//            return model;
//        }
//        /// <summary>
//        /// 订单实体托管
//        /// </summary>
//        /// <param name="reader">The reader.</param>
//        /// <param name="rowNumber">The row number.</param>
//        /// <returns></returns>
//        private object MapOrderNon(IDataReader reader, int row)
//        {
//            SalerOrderModel model = new SalerOrderModel();
//            model.Order_id = Convert.ToString(reader["order_id"]);
//            model.Bak_buyer_easy = Convert.ToString(reader["bak_buyer_name"]);
//            model.Buyer_orgid = Convert.ToString(reader["buyer_orgid"]);
//            model.Saler_orgid = Convert.ToString(reader["saler_orgid"]);
//            model.Sender_orgid = Convert.ToString(reader["sender_orgid"]);
//            model.Bak_saler_easy = Convert.ToString(reader["bak_saler_name"]);
//            model.Bak_sender_easy = Convert.ToString(reader["bak_sender_name"]);
//            model.Order_remark = Convert.ToString(reader["order_remark"]);
//            model.Request_total = Convert.ToString(reader["request_total"]);
//            model.Receive_total = Convert.ToString(reader["receive_total"]);

//            model.User_name = Convert.ToString(reader["user_name"]);
//            model.Create_date = Convert.ToString(reader["create_date"]);
//            model.Order_state = Convert.ToString(reader["order_state"]);
//            model.PurchaseCreator = this.getPurchaseNonCreator(Convert.ToString(reader["purchase_id"]));
//            model.Order_code = Convert.ToString(reader["order_code"]);
//            model.Order_state_name = Convert.ToString(reader["order_state_name"]);
//            model.Repository_id = Convert.ToString(reader["repository_id"]);
//            return model;
//        }

        
//        #endregion

//        #region 获得药房信息
//        /// <summary>
//        /// 获得药房信息
//        /// </summary>
//        /// <param name="name">The name.</param>
//        /// <returns></returns>
//        private bool GetWarehouserById(SalerOrderModel model)
//        {
//            SalerOrderModel modeltemp = null;
//            string sql = "select w.link_person,w.link_phone,w.warehouse_address as address from ord_warehouse w where w.warehouse_id = :ID";

//            modeltemp = base.DbFacade.SQLQueryObjectById(sql, model.Repository_id, new MapRow(MapLink)) as SalerOrderModel;
//            if (modeltemp != null)
//            {
//                model.Linkman = modeltemp.Linkman;
//                model.TelePhone = modeltemp.TelePhone;
//                model.Address = modeltemp.Address;
//                return true;
//            }
//            return false;;
//        }
//        #endregion

//        #region 获得买方医院信息
//        /// <summary>
//        /// 获得买方医院信息
//        /// </summary>
//        /// <param name="name">The name.</param>
//        /// <returns></returns>
//        private bool GetCatBuyerById(SalerOrderModel model)
//        {
//            SalerOrderModel modeltemp = null;
//            string sql = "select b.link_person,b.link_phone,b.org_address as address from Cat_Buyer b where b.id = :ID";

//            modeltemp = base.DbFacade.SQLQueryObjectById(sql, model.Buyer_orgid, new MapRow(MapLink)) as SalerOrderModel;
//            if (modeltemp != null)
//            {
//                model.Linkman = modeltemp.Linkman;
//                model.TelePhone = modeltemp.TelePhone;
//                model.Address = modeltemp.Address;
//                return true;
//            }
//            return false; ;
//        }

//        /// <summary>
//        /// 买方医院信息托管
//        /// </summary>
//        /// <param name="reader">The reader.</param>
//        /// <param name="rowNumber">The row number.</param>
//        /// <returns></returns>
//        private object MapLink(IDataReader reader, int row)
//        {
//            SalerOrderModel model = new SalerOrderModel();
//            model.Linkman = Convert.ToString(reader["link_person"]);
//            model.TelePhone = Convert.ToString(reader["link_phone"]);
//            model.Address = Convert.ToString(reader["address"]);
           
//            return model;
//        }
//        #endregion

//        #region 更新订单信息
//        /// <summary>
//        /// 更新订单信息
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="orderId"></param>
//        /// <param name="type"></param>
//        /// <returns></returns>
//        private bool UpdateOrderAndItem(string userId,string orderId,string type)
//        {
//            bool flg = false;
//            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
//            {
//                try
//                {
//                    if (type.Equals("1"))
//                    {
//                        if (UpdateOrderState(userId, "2", "ord_order", orderId, transaction))
//                        {
//                            flg = UpdateOrderItemState(userId, "2", "ord_order_item", orderId, transaction);
//                        }
//                    }
//                    else if (type.Equals("2"))
//                    {
//                        if (UpdateOrderState(userId, "2", "ord_order_non", orderId, transaction))
//                        {
//                            flg = UpdateOrderItemState(userId, "2", "ord_order_item_non", orderId, transaction);
//                        }
//                    }
//                    base.DbFacade.CommitTransaction(transaction);
//                }
//                catch (Exception e)
//                {
//                    flg = false;
//                    base.DbFacade.RollbackTransaction(transaction);
//                }
//            }
//            return flg;
//        }
//        #endregion

//        #region 更新订单明细状态
//        /// <summary>
//        /// 更新订单明细状态
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="orderState"></param>
//        /// <param name="tableName"></param>
//        /// <param name="orderId"></param>
//        /// <param name="transaction"></param>
//        /// <returns></returns>
//        private bool UpdateOrderItemState(string userId, string orderState, string tableName, string orderId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_item_state = '").Append(orderState).Append("'");
//            sql.Append(" where order_id = '").Append(orderId).Append("'");
//            sql.Append(" and order_item_state = '1'");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;

//        }
//        #endregion

//        #region 更新订单状态
//        /// <summary>
//        /// 更新订单状态
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="orderState"></param>
//        /// <param name="tableName"></param>
//        /// <param name="orderId"></param>
//        /// <param name="transaction"></param>
//        /// <returns></returns>
//        private bool UpdateOrderState(string userId, string orderState, string tableName, string orderId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_state = '").Append(orderState).Append("'");
//            sql.Append(" where order_id = '").Append(orderId).Append("'");
//            sql.Append(" and order_state = '1'");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }
//        /// <summary>
//        /// 更新订单状态
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="orderState"></param>
//        /// <param name="tableName"></param>
//        /// <param name="orderId"></param>
//        /// <param name="transaction"></param>
//        /// <returns></returns>
//        private bool UpdateOrderState1(string userId, string orderState, string tableName, string orderId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_state = '").Append(orderState).Append("'");
//            sql.Append(" where order_id = '").Append(orderId).Append("'");

//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }
//        #endregion

//        /// <summary>
//        /// 查询订单明细表信息
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <param name="type"></param>
//        /// <param name="allFlag"></param>
//        /// <returns></returns>
//        private IDataReader getSalerOrderItemList(string orderId)
//        {            

//            StringBuilder sql = new StringBuilder();
//            IDataReader reader = null;
//            try{
//                sql.Append("SELECT ghc.medical_name,goi.order_id,");
//                sql.Append("       ghc.trade_name,");
//                sql.Append("       nvl(ghc.spec, '-') || '×' || nvl(to_char(ghc.stand_rate), '-') ||");
//                sql.Append("       nvl(ghc.use_unit, '') || '/' || nvl(ghc.spec_unit, '') ||");
//                sql.Append("       decode(ghc.wrap_code, '01', '', nvl2(ghc.wrap_name, '(' ||");
//                sql.Append("                     ghc.wrap_name || ')', '')) AS ggbz,");
//                sql.Append("       goi.record_id,");
//                sql.Append("       ghc.product_id,");
//                sql.Append("       goi.repository_id,");
//                sql.Append("       ghc.producer_shortname factory_easy,");
//                sql.Append("       ghc.producer_fullname factory_name,");
//                sql.Append("       ghc.provide_price,");
//                sql.Append("       goi.request_qty,");
//                sql.Append("       gw.warehouse_name,");
//                sql.Append("       gpi.buyer_remark,goi.item_status,");
//                sql.Append("decode(goi.item_status,'2','已阅读','3','已确认','6','缺货','') status ");

//                sql.Append(",(select goi.request_qty*2 - nvl(sum(s.stockup_qty),0) from gpo_order_stockup s where s.order_item_id(+)=goi.record_id) maxQty ");

//                sql.Append("  FROM gpo_order_item    goi,");
//                sql.Append("       gpo_hit_comm      ghc,");
//                sql.Append("       gpo_warehouse     gw,");
//                sql.Append("       gpo_purchase_item gpi");
//                sql.Append(" WHERE goi.hit_comm_id = ghc.record_id");
//                sql.Append("   AND goi.repository_id = gw.id(+)");
//                sql.Append("   AND goi.purchase_item_id = gpi.id");
//                sql.Append("   AND goi.item_status IN ('2','3','6' )");
//                sql.Append("   ");
//                sql.Append("   AND goi.order_id = '").Append(orderId).Append("' ");

//                //DbParameter param = base.DbFacade.CreateParameter();
//                //param.ParameterName = "ORDER_ID";
//                //param.DbType = DbType.String;
//                //param.Value = orderId;                

//                reader = DbFacade.SQLExecuteReader(sql.ToString());
        
//            }
//            catch (Exception e)
//            {
                
//                throw e;
//            }
            
//            return reader;
//        }

//        /// <summary>
//        /// 查询包装信息
//        /// </summary>
//        /// <param name="productId"></param>
//        /// <returns></returns>
//        public string getWrapName(string productId)
//        {
//            string result = null;
//            string sql = "select decode(nvl(w.name_chn,'空'),'空','','('||w.name_chn||')') as wrap_name from CAT_PRODUCT c ,CAT_WRAP w where c.wrap_code = w.CODE and c.id = '" + productId + "'";
//            //DbParameter param = base.DbFacade.CreateParameter();
//            //param.ParameterName = "ID";
//            //param.DbType = DbType.String;
//            //param.Value = productId;
//            try
//            {
//                object o = DbFacade.SQLExecuteScalar(sql);
//                if (o != null)
//                    result = o.ToString();

//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            return result;
//        }

//        #region 查询采购单创建者
//        /// <summary>
//        /// 查询采购单创建者
//        /// </summary>
//        /// <param name="purchaseId"></param>
//        /// <returns></returns>
//        public string getPurchaseCreator(string purchaseId)
//        {
//            string result = null;
//            string sql = "select u.user_name from ord_purchase p,usr_user u where p.create_userid = u.id and p.purchase_id = '" + purchaseId + "'";
//            //DbParameter param = base.DbFacade.CreateParameter();
//            //param.ParameterName = "ID";
//            //param.DbType = DbType.String;
//            //param.Value = purchaseId;
//            try
//            {
//                object o = DbFacade.SQLExecuteScalar(sql);
//                if (o != null)
//                    result = o.ToString();

//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            return result;

//        }

//        public string getPurchaseNonCreator(string purchaseId)
//        {
//            string result = null;
//            string sql = "select u.user_name from ord_purchase_non p,usr_user u where p.create_userid = u.id and p.purchase_id = :ID";
//            DbParameter param = base.DbFacade.CreateParameter();
//            param.ParameterName = "ID";
//            param.DbType = DbType.String;
//            param.Value = purchaseId;
//            try
//            {
//                object o = DbFacade.SQLExecuteScalar(sql, param);
//                if (o != null)
//                    result = o.ToString();

//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//            return result;

//        }
//        #endregion 

//        /// <summary>
//        /// 查询发货批次
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <param name="type"></param>
//        /// <returns></returns>
//        private string getSendLot(string orderId, string type)
//        {
//            string sql = "";
//            if (type.Equals("1"))
//            {
//                sql = "select nvl(max(send_lot),0) +1  count from  ord_order_receive where order_item_id='" + orderId + "'";

//            }
//            else if (type.Equals("2"))
//            {
//                sql = "select nvl(max(send_lot),0) +1  count from  ord_order_receive_non where order_item_id='" + orderId + "'";

//            }
//            object o = DbFacade.SQLExecuteScalar(sql);
//            if (o != null)
//                return o.ToString();
//            else
//                return "1";

//        }
//        /// <summary>
//        /// 更新订单明细状态
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="orderState"></param>
//        /// <param name="tableName"></param>
//        /// <param name="orderItemId"></param>
//        /// <param name="transaction"></param>
//        /// <returns></returns>
//        public bool UpdateOrderItemStateById(string userId, string orderState, string tableName, string orderItemId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" item_status = '").Append(orderState).Append("'");
//            sql.Append(" where RECORD_ID = '").Append(orderItemId).Append("'");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;

//        }

//        /// <summary>
//        /// 获得订单明细数量
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <param name="type"></param>
//        /// <param name="tran"></param>
//        /// <returns></returns>
//        private string getOrderItemCount(string orderId, string type, DbTransaction tran)
//        {
//            string sql = "";
//            if (type.Equals("1"))
//            {
//                sql = "select nvl(count(*), 0) count from ord_order_item where order_id = '" + orderId + "' and order_item_state in ('0', '1', '2', '3', '4')";

//            }
//            else if (type.Equals("2"))
//            {
//                sql = "select nvl(count(*), 0) count from ord_order_item_non where order_id = '" + orderId + "' and order_item_state in ('0', '1', '2', '3', '4')";

//            }
//            object o = DbFacade.SQLExecuteScalar(sql, tran);
//            if (o != null)
//                return o.ToString();
//            else
//                return "";

//        }

//        /// <summary>
//        /// 查询采购单ＩＤ
//        /// </summary>
//        /// <param name="orderId"></param>
//        /// <param name="type"></param>
//        /// <param name="tran"></param>
//        /// <returns></returns>
//        private string getPurchaseId(string orderId, string type, DbTransaction tran)
//        {
//            string sql = "";
//            if (type.Equals("1"))
//            {
//                sql = @"select o.purchase_id
//                        from ord_order o,
//                        (select nvl(count(*), 0) count, o.purchase_id
//                          from ord_order o
//                         where order_state in ('0', '1', '2', '3', '4')
//                         group by purchase_id) p
//                        where o.purchase_id = p.purchase_id
//                        and p.count = 0
//                        and o.order_id = '" + orderId + "'";

//            }
//            else if (type.Equals("2"))
//            {
//                sql = @"select o.purchase_id
//                        from ord_order_non o,
//                        (select nvl(count(*), 0) count, o.purchase_id
//                          from ord_order_non o
//                         where order_state in ('0', '1', '2', '3', '4')
//                         group by purchase_id) p
//                        where o.purchase_id = p.purchase_id
//                        and p.count = 0
//                        and o.order_id = '" + orderId + "'";
//            }
//            object o = DbFacade.SQLExecuteScalar(sql, tran);
//            if (o != null)
//                return o.ToString();
//            else
//                return "";

//        }

//        /// <summary>
//        /// 更新采购单id
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="state"></param>
//        /// <param name="tableName"></param>
//        /// <param name="purchaseId"></param>
//        /// <param name="transaction"></param>
//        /// <returns></returns>
//        public bool UpdatePurchaseById(string userId, string state, string tableName, string purchaseId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" PURCHASE_STATE = '").Append(state).Append("'");
//            sql.Append(" where PURCHASE_ID = '").Append(purchaseId).Append("'");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;

//        }
//        /// <summary>
//        /// 更新
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="orderState"></param>
//        /// <param name="tableName"></param>
//        /// <param name="orderId"></param>
//        /// <param name="transaction"></param>
//        /// <returns></returns>
//        public bool UpdateOrderStateFor7(string userId, string orderState, string tableName, string orderId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_state = '").Append(orderState).Append("'");
//            sql.Append(" where order_id = '").Append(orderId).Append("'");
//            sql.Append(" and order_state = '7'");

//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }
//        public bool UpdateOrderStateForConfirm(string userId, string orderState, string tableName, string orderId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_state = '").Append(orderState).Append("'");
//            sql.Append(" where order_id = '").Append(orderId).Append("'");
//            sql.Append(" and (order_state = '0' or order_state = '1' or order_state = '2')");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }
//        public bool UpdateOrderItemStateByIdForConfirm(string userId, string orderState, string tableName, string orderItemId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_item_state = '").Append(orderState).Append("'");
//            sql.Append(" where RECORD_ID = '").Append(orderItemId).Append("'");
//            sql.Append(" and (order_item_state = '0' or order_item_state = '1' or order_item_state = '2')");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;

//        }

//        private void autoReceive(string orderId, string orderItemId, string receiveId, string platId, string type, string userId, DbTransaction transaction)
//        {
//            bool flag = false;
//            //首先判断是否是福建厦门平台，是的话特殊处理，不管买方是否设置自动到货
//            if (platId.Equals("FR20T0000020000400000109"))
//            {
//                string result = ParamCom.GetInstance().getParamValue("ord_auto_receive", platId, "2");
//                flag = result.Equals("1") ? true : false;
//            }
//            else
//            {
//                flag = ParamCom.GetInstance().autoReceiveForBuyer(receiveId, type);
//            }
//            if (flag)
//            {
//                if (type.Equals("1"))
//                {
//                    // 更新到货明细
//                    UpdateOrderReceiveFroAuto(userId, "ORD_ORDER_RECEIVE", receiveId, transaction);
//                    //更新订单明细
//                    updateOrderItemForAuto(userId, orderItemId, type, transaction);
//                    //更新订单主表
//                    UpdateOrderStateForAuto(userId, type, orderId, transaction);
//                    //更新采购单
//                    string purchase = getPurchaseIdForAuto(orderId, type, transaction);
//                    if (!string.IsNullOrEmpty(purchase))
//                        UpdatePurchaseById(userId, "4", "ord_purchase", purchase, transaction);

//                }
//                else
//                {
//                    // 更新到货明细
//                    UpdateOrderReceiveFroAuto(userId, "ORD_ORDER_RECEIVE_NON", receiveId, transaction);
//                    //更新订单明细
//                    updateOrderItemForAuto(userId, orderItemId, type, transaction);
//                    //更新订单主表
//                    UpdateOrderStateForAuto(userId, type, orderId, transaction);
//                    //更新采购单
//                    string purchase = getPurchaseIdForAuto(orderId, type, transaction);
//                    if (!string.IsNullOrEmpty(purchase))
//                        UpdatePurchaseById(userId, "4", "ord_purchase_non", purchase, transaction);
//                }
//            }

//        }

//        public bool UpdateOrderReceiveFroAuto(string userId, string tableName, string receiveId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            sql.Append("update ").Append(tableName);
//            sql.Append(" set RECEIVE_DATE = sysdate,");
//            sql.Append(" RECEIVE_FLAG  = '1',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" RECEIVE_USERID = '").Append(userId).Append("'");
//            sql.Append(" where ID = '").Append(receiveId).Append("'");

//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }
//        public bool updateOrderItemForAuto(string userId, string orderItemId, string type, DbTransaction transaction)
//        {
//            bool flg = false;
//            bool stateFlag = checkReceiveState(orderItemId, type, transaction);
//            StringBuilder sql = new StringBuilder();
//            int result;
//            if (type.Equals("1"))
//                sql.Append("update ORD_ORDER_ITEM");
//            else
//                sql.Append("update ORD_ORDER_ITEM_NON");
//            sql.Append(" set MODIFY_DATE = sysdate,");
//            if (stateFlag)
//                sql.Append(" ORDER_ITEM_STATE  = '5',");
//            else
//                sql.Append(" ORDER_ITEM_STATE  = '4',");
//            sql.Append(" sync_state = '1',");
//            sql.Append(" MODIFY_USERID = '").Append(userId).Append("'");
//            sql.Append(" where RECORD_ID = '").Append(orderItemId).Append("'");
//            sql.Append(" and (order_item_state = '0' or order_item_state = '1' or order_item_state = '2' or order_item_state = '3' or order_item_state = '4')");


//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }


//        private bool checkReceiveState(string orderItemId, string type, DbTransaction transaction)
//        {
//            int request_qty = 0;
//            int receive_qty = 0;
//            StringBuilder sql = new StringBuilder();
//            if (type.Equals("1"))
//                sql.Append("select sum(receive_qty) receive_qty from ord_order_receive");
//            else
//                sql.Append("select sum(receive_qty) receive_qty from ord_order_receive_non");
//            sql.AppendFormat(" where order_item_id ='{0}'", orderItemId);
//            sql.Append(" and receive_flag = '1'");
//            //DbParameter param = base.DbFacade.CreateParameter();
//            //param.ParameterName = "order_item_id";
//            //param.DbType = DbType.String;
//            //param.Value = orderItemId;
//            object o = DbFacade.SQLExecuteScalar(sql.ToString(), transaction);
//            if (o != null)
//                receive_qty = int.Parse(o.ToString());

//            StringBuilder sql1 = new StringBuilder();
//            if (type.Equals("1"))
//                sql1.Append("select REQUEST_QTY from ORD_ORDER_ITEM");
//            else
//                sql1.Append("select REQUEST_QTY from ORD_ORDER_ITEM_NON");
//            sql1.AppendFormat(" where RECORD_ID ='{0}'", orderItemId);

//            //DbParameter param1 = base.DbFacade.CreateParameter();
//            //param1.ParameterName = "order_item_id";
//            //param1.DbType = DbType.String;
//            //param1.Value = orderItemId;
//            object o1 = DbFacade.SQLExecuteScalar(sql.ToString(), transaction);
//            if (o1 != null)
//                request_qty = int.Parse(o1.ToString());

//            if (receive_qty >= request_qty)
//                return true;
//            else
//                return false;
//        }



//        /// <summary>
//        /// 取得到货总金额
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        private string GetReceiveTotal(string id, DbTransaction transaction, string type)
//        {
//            StringBuilder sql = new StringBuilder();
//            string ret;
//            sql.Append(" select nvl(sum(ooi.unit_price * oor.receive_qty),0) receive_total from ");
//            if (type.Equals("1"))
//            {
//                sql.Append(" (select * from ord_order_receive where receive_flag = '1') oor");
//                sql.AppendFormat(" , (select record_id, unit_price from ord_order_item where order_id = '{0}' ) ooi", id);
//            }
//            else
//            {
//                sql.Append(" (select * from ord_order_receive_non where receive_flag = '1') oor");
//                sql.AppendFormat(" , (select record_id, unit_price from ord_order_item_non where order_id = '{0}' ) ooi", id);

//            }
//            sql.Append(" where ooi.record_id = oor.order_item_id ");

//            //DbParameter idPara = this.DbFacade.CreateParameter();
//            //idPara.ParameterName = "id";
//            //idPara.DbType = DbType.AnsiString;
//            //idPara.Value = id;

//            ret = base.DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString();
//            return ret;
//        }
//        private string getOrderState(string orderId, DbTransaction transaction, string type)
//        {
//            string state = "";
//            StringBuilder sql = new StringBuilder();
//            if (type.Equals("1"))
//                sql.AppendFormat("select nvl(count(*),0) count from ord_order_item where order_id ='{0}'", orderId);
//            else
//                sql.AppendFormat("select nvl(count(*),0) count from ord_order_item_non where order_id ='{0}'", orderId);

//            sql.Append("' and  order_item_state in ('0', '1', '2', '3', '4')");
//            //DbParameter idPara = this.DbFacade.CreateParameter();
//            //idPara.ParameterName = "order_id";
//            //idPara.DbType = DbType.AnsiString;
//            //idPara.Value = orderId;
//            string ret = base.DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString();
//            if (ret.Equals("0"))
//            {
//                sql.Remove(0, sql.Length);
//                if (type.Equals("1"))
//                    sql.AppendFormat("select nvl(count(*),0) count from ord_order_item where order_id = '{0}'", orderId);
//                else
//                    sql.AppendFormat("select nvl(count(*),0) count from ord_order_item_non where order_id = '{0}'", orderId);
//                sql.Append("' and  order_item_state = '7'");
//                //DbParameter idPara1 = this.DbFacade.CreateParameter();
//                //idPara1.ParameterName = "order_id";
//                //idPara1.DbType = DbType.AnsiString;
//                //idPara1.Value = orderId;
//                ret = base.DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString();
//                if (ret.Equals("0"))
//                    state = "5";
//                else
//                    state = "7";
//            }
//            else
//            {
//                state = "4";
//            }
//            return state;
//        }



//        public bool UpdateOrderStateForAuto(string userId, string type, string orderId, DbTransaction transaction)
//        {
//            bool flg = false;
//            StringBuilder sql = new StringBuilder();
//            int result;
//            if (type.Equals("1"))
//                sql.Append("update ORD_ORDER");
//            else
//                sql.Append("update ORD_ORDER_NON");
//            sql.Append(" set modify_date = sysdate,");
//            sql.Append(" modify_userid  = '").Append(userId).Append("',");
//            sql.Append(" RECEIVE_TOTAL  = ").Append(GetReceiveTotal(orderId, transaction, type)).Append(",");

//            sql.Append(" sync_state = '1',");
//            sql.Append(" order_state = '").Append(getOrderState(orderId, transaction, type)).Append("'");
//            sql.Append(" where order_id = '").Append(orderId).Append("'");
//            sql.Append(" and (order_state = '0' or order_state = '1' or order_state = '2' or order_state = '3')");
//            try
//            {
//                result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
//                if (result > 0)
//                {
//                    flg = true;
//                }

//                else
//                {
//                    flg = false;

//                }

//            }
//            catch (Exception e)
//            {
//                flg = false;
//                throw e;
//            }
//            return flg;
//        }

//        private string getPurchaseIdForAuto(string orderId, string type, DbTransaction tran)
//        {
//            string sql = "";
//            if (type.Equals("1"))
//            {
//                sql = @"select o.purchase_id
//                        from ord_order o,
//                        (select nvl(count(*), 0) count, o.purchase_id
//                          from ord_order o
//                         where order_state in ('0', '1', '2', '3', '4','7')
//                         group by purchase_id) p
//                        where o.purchase_id = p.purchase_id
//                        and p.count = 0
//                        and o.order_id = '" + orderId + "'";

//            }
//            else if (type.Equals("2"))
//            {
//                sql = @"select o.purchase_id
//                        from ord_order_non o,
//                        (select nvl(count(*), 0) count, o.purchase_id
//                          from ord_order_non o
//                         where order_state in ('0', '1', '2', '3', '4','7')
//                         group by purchase_id) p
//                        where o.purchase_id = p.purchase_id
//                        and p.count = 0
//                        and o.order_id = '" + orderId + "'";
//            }
//            object o = DbFacade.SQLExecuteScalar(sql, tran);
//            if (o != null)
//                return o.ToString();
//            else
//                return "";

//        }
//        //----------------------------------------------------------------------------------------

        #region gpo客户端用
        #region 检索订单信息
        /// <summary>
        /// 检索订单信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable getSalerOrderList(SalerOrderListModel model, out int rows)
        {
            StringBuilder sql = new StringBuilder();
            List<DbParameter> parameters = new List<DbParameter>();
            DataTable dt = null;
            sql.Append("select a.order_id,");
            sql.Append("       a.order_code,");
            sql.Append("       a.bak_buyer_name,");
            sql.Append("       a.bak_buyer_easy,");
            sql.Append("       a.create_date,");
            sql.Append("       to_char(a.request_total,'999,999,999,990.00') request_total,");
            sql.Append("       a.order_state,");
            sql.Append("       c.org_address,");
            sql.Append("       decode(a.order_state,");
            sql.Append("              '0',");
            sql.Append("              '发送',");
            sql.Append("              '1',");
            sql.Append("              '已阅读',");
            sql.Append("              '2',");
            sql.Append("              '交易中',");
            sql.Append("              '3',");
            sql.Append("              '完成',");
            sql.Append("              '') ORDER_STATE_NAME ");
            sql.Append("  from GPO_ORDER a, gpo_reg_buyer b, cat_buyer c");
            sql.Append("  where saler_id = '").Append(model.OrgId).Append("' ");
            sql.Append("   and a.buyer_orgid = b.id ");
            sql.Append("   and b.data_buyer_id = c.id ");


            if (!string.IsNullOrEmpty(model.Order_state))
            {
                if (model.Order_state.Equals("-1"))
                {
                    sql.Append("and order_state <> '3' ");
                }
                else
                {
                    sql.Append("and order_state = '").Append(model.Order_state).Append("' ");
                }
            }

            if (!string.IsNullOrEmpty(model.StartDate))
            {
                //start modify by gaoyuan  2007.1.8 
                //param = base.DbFacade.CreateParameter();
                //sql.Append(" AND O.CREATE_DATE >= TO_DATE(:START_DATE, 'YYYY-MM-DD')");
                //param.ParameterName = "START_DATE";
                //param.DbType = DbType.String;
                //param.Value = model.StartDate;
                //parameters.Add(param);
                sql.AppendFormat(" AND a.CREATE_DATE >= TO_DATE('{0}', 'YYYY-MM-DD')", model.StartDate);

            }
            if (!string.IsNullOrEmpty(model.EndDate))
            {
                //start modify by gaoyuan  2007.1.8
                //param = base.DbFacade.CreateParameter();
                //sql.Append(" AND O.CREATE_DATE <= TO_DATE(:END_DATE, 'YYYY-MM-DD') + 1");
                //param.ParameterName = "END_DATE";
                //param.DbType = DbType.String;
                //param.Value = model.EndDate;
                //parameters.Add(param);
                sql.AppendFormat(" AND a.CREATE_DATE <= TO_DATE('{0}', 'YYYY-MM-DD') + 1", model.EndDate);

            }
            if (!string.IsNullOrEmpty(model.BuyerName))
            {
                //param = base.DbFacade.CreateParameter();
                //start modify by gaoyuan  2007.1.8                 
                //sql.Append(" and (O.BUYER_NAME||O.BAK_BUYER_EASY||O.BAK_BUYER_FAST||O.BAK_BUYER_WUBI LIKE :BUYER_NAME");

                //param.ParameterName = "BUYER_NAME";
                //param.DbType = DbType.String;
                //param.Value = "%" + model.BuyerName + "%";
                //parameters.Add(param);
                sql.AppendFormat(" and a.BAK_BUYER_NAME||a.BAK_BUYER_EASY||a.BAK_BUYER_FAST||a.BAK_BUYER_WUBI LIKE '%{0}%'", model.BuyerName.ToUpper());
            }
            if (!string.IsNullOrEmpty(model.OrderCode))
            {
                //start modify by gaoyuan  2007.1.8 
                //param = base.DbFacade.CreateParameter();
                //sql.Append(" AND O.ORDER_CODE  LIKE :ORDER_CODE");
                //param.ParameterName = "ORDER_CODE";
                //param.DbType = DbType.String;
                //param.Value = "%" + model.OrderCode + "%";
                //parameters.Add(param);
                sql.AppendFormat(" AND a.ORDER_CODE  LIKE '%{0}%'", model.OrderCode);

            }

            if (!model.IsFactory)
            {
                sql.Append(" and a.area_id in (").Append(model.AreaList).Append(")");
            }
            else
            {
                StringBuilder sqlTemp = new StringBuilder();
                sqlTemp.Append("select 1 from gpo_usr_user_area  a  where a.USER_ID='").Append(model.UserId);
                sqlTemp.Append("' and  a.AREA_ID='MRBR00000000000000092258'");
                DataTable dtt = DbFacade.SQLExecuteDataTable(sqlTemp.ToString());
                if (dtt.Rows.Count == 0)
                {
                    sql.Append(" and a.area_id in (").Append(model.AreaList).Append(")");
                }
            }
            sql.Append(" order by create_date desc ");
            try
            {

                rows = base.GetRowCount(sql.ToString());
                //该sql需要用户自己绑定:highRowNum(该页的最大记录行数)和:lowRowNum(该页的最小记录行数)参数.
                DbParameter highIndexPara = DbFacade.CreateParameter();
                highIndexPara.ParameterName = "highRowNum";
                highIndexPara.DbType = DbType.Int32;
                highIndexPara.Value = PageUtils.GetHighIndexOfPage(model.PageNum, model.PageSize);
                parameters.Add(highIndexPara);

                DbParameter lowIndexPara = DbFacade.CreateParameter();
                lowIndexPara.ParameterName = "lowRowNum";
                lowIndexPara.DbType = DbType.Int32;
                lowIndexPara.Value = PageUtils.GetLowIndexOfPage(model.PageNum, model.PageSize);
                parameters.Add(lowIndexPara);

                dt = DbFacade.SQLExecuteDataTable(GetPagedSql(sql.ToString()), parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;

        }
        #endregion


        /// <summary>
        /// 查询订单明细表信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="type"></param>
        /// <param name="allFlag"></param>
        /// <returns></returns>
        public IDataReader GetSalerOrderItemList(string orderId,string userName,string userId,bool flag)
        {
            StringBuilder sql = new StringBuilder();
            IDataReader reader = null;
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
                    sql.Append("       nvl(ghc.spec, '-') || '×' || nvl(to_char(ghc.stand_rate), '-') ||");
                    sql.Append("       nvl(ghc.use_unit, '') || '/' || nvl(ghc.spec_unit, '') ||");
                    sql.Append("       decode(ghc.wrap_code, '01', '', nvl2(ghc.wrap_name, '(' ||");
                    sql.Append("                     ghc.wrap_name || ')', '')) AS ggbz,");
                    sql.Append("       goi.record_id,");
                    sql.Append("       ghc.product_id,");
                    sql.Append("       goi.repository_id,");
                    sql.Append("       ghc.producer_shortname factory_easy,");
                    sql.Append("       ghc.producer_fullname factory_name,");
                    sql.Append("       ghc.provide_price,");
                    sql.Append("       goi.request_qty,");
                    sql.Append("       gw.warehouse_name,");
                    sql.Append("       gpi.buyer_remark,goi.item_status,");
                    sql.Append("decode(goi.item_status,'2','已阅读','3','已确认','6','缺货','') status ");

                    sql.Append(",(select goi.request_qty*2 - nvl(sum(s.stockup_qty),0) from gpo_order_stockup s where s.order_item_id(+)=goi.record_id) maxQty ");

                    sql.Append("  FROM gpo_order_item    goi,");
                    sql.Append("       gpo_hit_comm      ghc,");
                    sql.Append("       gpo_warehouse     gw,");
                    sql.Append("       gpo_purchase_item gpi");
                    sql.Append(" WHERE goi.hit_comm_id = ghc.record_id");
                    sql.Append("   AND goi.repository_id = gw.id(+)");
                    sql.Append("   AND goi.purchase_item_id = gpi.id");
                    sql.Append("   AND goi.item_status IN ('2','3','6' )");
                    sql.Append("   ");
                    sql.Append("   AND goi.order_id = '").Append(orderId).Append("' ");

                    //DbParameter param = base.DbFacade.CreateParameter();
                    //param.ParameterName = "ORDER_ID";
                    //param.DbType = DbType.String;
                    //param.Value = orderId;                

                    reader = DbFacade.SQLExecuteReader(sql.ToString(), transaction);
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
            try{
                sql.Append("  select b.medical_name as medicalname,b.trade_name as tradename, b.doseage_form as doseage_form,");
                sql.Append("  d.order_type,nvl(b.spec, '-') || '×' || nvl(to_char(b.stand_rate), '-') ||nvl(b.use_unit, '') || '/' || nvl(b.spec_unit, '') ||decode(b.wrap_name, null, '', '(' || b.wrap_name || ')','空', '') as ggbz, ");
                sql.Append("  b.PRODUCER_FULLNAME as factoryfullname,b.PRODUCER_SHORTNAME factoryshortname,D.UNIT_PRICE as provide_price,");
                sql.Append("  d.request_qty as requestqty,d.buyer_desc as receiveremark, case when d.item_status='1' then '发送' ");
                sql.Append("  when  d.item_status='2' then '已阅读' when d.item_status='3' then '已确认' when  d.item_status='4' then '到货中' ");
                sql.Append("  when  d.item_status='5' then '作废'  when  d.item_status='6' then '缺货' 　when  d.item_status='7' then '完成'  else 'k' end as itemstatus   ,");
                sql.Append("  decode(d.order_type, '0', '蓝票','1', '到货','2', '红票') AS ordertype  from GPO_HIT_COMM b, GPO_ORDER_ITEM d ");
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
                        if(string.IsNullOrEmpty(orderId))
                            orderId = model.OrderId;
                        if (!SaveOrderReceive(transaction, model, ui))
                        {
                            DbFacade.RollbackTransaction(transaction);
                            break;
                        }

                    }

                    
                    StringBuilder  sql = new StringBuilder ();
                    sql.Append( "update gpo_order set order_remark ='").Append(remark).Append("',MODIFY_USERID = '").Append(ui.Id).Append("',MODIFY_DATE = sysdate where order_id = '").Append(orderId).Append("'");
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
        private bool SaveOrderReceive(DbTransaction transaction,SalerOrderItemModel model, Emedchina.TradeAssistant.Model.User.UserInfo ui)
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
            sql.Append(" READY_FLAG,MODIFY_USER,MODIFY_DATE) VALUES(");
            sql.AppendFormat("'{0}',", this.GetNewId(OracleDAOBase.SEQ_ORDER, OracleDAOBase.SEQ_GPO));
            sql.AppendFormat("'{0}',", model.OrderId);
            sql.AppendFormat("'{0}',", model.RecordId);
            sql.AppendFormat("'{0}',", model.ProductId);
            sql.AppendFormat("'{0}',", model.LotNo);
            sql.AppendFormat("{0},", model.ReceiveQty1);

            sql.AppendFormat("'{0}',", ui.Id);
            sql.Append("sysdate,");
            sql.AppendFormat("'{0}',", model.InvoiceNo);
            sql.AppendFormat("to_date('{0}','YYYY-MM-DD'),", model.InvoiceDate);
            sql.AppendFormat("to_date('{0}','YYYY-MM-DD'),", model.InvoiceExpireDate);
            sql.AppendFormat("'{0}',", model.InvoiceTotal);
            sql.AppendFormat("'{0}',", model.InvoiceTradePrice);
            sql.AppendFormat("'{0}',", model.InvoiceRetailPrice);
            sql.AppendFormat("'{0}',", model.InvoiceDiscountRate);
            sql.AppendFormat("'{0}',", model.RepositoryId);
            sql.AppendFormat("'{0}',", model.ReadyRemark);
            sql.AppendFormat("'{0}',", "0");
            sql.AppendFormat("'{0}',", ui.Id);
            sql.Append("sysdate)");

            int result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            if (result > 0)
                return true;
            else
                return false;

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
            sql.Append(" set modify_date = sysdate,");
            sql.Append(" modify_userid  = '").Append(userId).Append("',");
            sql.Append(" Item_Status = '").Append(orderState).Append("' ");

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
            string orderId =null;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (SalerOrderItemModel model in result)
                    {
                        if (string.IsNullOrEmpty(orderId))
                            orderId = model.OrderId;
                        UpdateOrderItemStateByIdGPO(ui.Id, "6", "gpo_order_item", model.RecordId, transaction);
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
                        UpdateOrderItemStateByIdGPO(ui.Id, "2", "gpo_order_item", model.RecordId, transaction);
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
                    sb.Append("SELECT o.*, r.receive_qty receiveQty, ");
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
                    sb.Append(" DECODE(o.REMARK,'','-',null,'-',o.REMARK) AS O_REMARK, ");

                    sb.Append(" r.invoice_no r_invoice_no, ");
                    sb.Append(" nvl(r.invoice_total, '') r_invoice_total, ");
                    sb.Append(" nvl(r.invoice_trade_price, '') r_invoice_trade_price, ");
                    sb.Append(" nvl(r.invoice_retail_price, '') r_invoice_retail_price, ");
                    sb.Append(" r.invoice_discount_rate r_invoice_discount_rate, ");
                    sb.Append(" to_char(r.invoice_date, 'yyyy-mm-dd') r_invoice_date, ");
                    sb.Append(" to_char(r.invoice_expire_date, 'yyyy-mm-dd') r_invoice_expire_date, ");
                    sb.Append(" r.ready_remark r_ready_remark, ");
                    sb.Append(" r.id r_ID, ");
                    sb.Append(" o.RECORD_ID O_RECORD_ID, ");
                    sb.Append(" o.ORDER_ID O_ORDER_ID, ");
                    sb.Append(" o.PLAT_ID O_PLAT_ID, ");

                    sb.Append("r.app_num, "); // added by Jiang Ping, 2005-3-16
                    sb.Append("r.id, r.lot_no, nvl(r.receive_flag, '0') receiveFlag, ");
                    sb.Append("w.warehouse_name, r.invoice_date, r.invoice_no, r.ready_remark, ");
                    sb
                            .Append("r.invoice_total, r.invoice_trade_price, r.invoice_retail_price, r.invoice_discount_rate, ");
                    sb.Append("r.invoice_expire_date, to_char(r.receive_date,'yyyy-mm-dd hh24:mi:ss') as receive_date ,to_char(r.receive_date,'yyyy-mm-dd hh24:mi:ss') as R_RECEIVE_DATE ");

                    if (input.Idx)
                        sb.Append("FROM ord_order_item o, ord_order_receive r, ord_warehouse w ");
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
                    sb.Append("select a.receive_date as receivedate,");
                    sb.Append("       b.medical_name as medicalname,");
                    sb.Append("       b.trade_name as tradename,");
                    sb.Append("       b.doseage_form as doseageform,");
                    sb.Append("       nvl(b.spec, '-') || '×' || nvl(to_char(b.stand_rate), '-') ||");
                    sb.Append("       nvl(b.use_unit, '') || '/' || nvl(b.spec_unit, '') ||");
                    sb.Append("       decode(b.wrap_name, null, '', '(' || b.wrap_name || ')', '空', '') as ggbz,");
                    sb.Append("       b.PRODUCER_FULLNAME as factoryfullname,");
                    sb.Append("       b.PRODUCER_SHORTNAME as factoryshortname,");
                    sb.Append("       b.provide_price as provideprice,");
                    sb.Append("       c.REQUEST_QTY as requestqty,");
                    sb.Append("       a.TRADE_QTY as tradeqty,");
                    sb.Append("       a.LOT_NO as sendlot,");
                    sb.Append("       a.receive_qty as receiveqty,");
                    sb.Append("       a.INVOICE_NO as invoiceno,");
                    sb.Append("       to_char(a.invoice_date, 'yyyy-mm-dd') as invoicedate,");
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
                    sb.Append(" DECODE(o.REMARK,'','-',null,'-',o.REMARK) AS O_REMARK, ");

                    sb.Append(" r.invoice_no r_invoice_no, ");
                    sb.Append(" nvl(r.invoice_total, '') r_invoice_total, ");
                    sb.Append(" nvl(r.invoice_trade_price, '') r_invoice_trade_price, ");
                    sb.Append(" nvl(r.invoice_retail_price, '') r_invoice_retail_price, ");
                    sb.Append(" r.invoice_discount_rate r_invoice_discount_rate, ");
                    sb.Append(" to_char(r.invoice_date, 'yyyy-mm-dd') r_invoice_date, ");
                    sb.Append(" to_char(r.invoice_expire_date, 'yyyy-mm-dd') r_invoice_expire_date, ");
                    sb.Append(" r.ready_remark r_ready_remark, ");
                    sb.Append(" r.id r_ID, ");
                    sb.Append(" o.RECORD_ID O_RECORD_ID, ");
                    sb.Append(" o.ORDER_ID O_ORDER_ID, ");
                    sb.Append(" o.PLAT_ID O_PLAT_ID, ");

                    sb.Append("r.app_num, ");
                    sb.Append("r.lot_no, nvl(r.receive_flag, '0') receiveFlag, r.ready_remark, ");
                    sb.Append("w.warehouse_name, r.invoice_date, r.invoice_no, r.invoice_expire_date, ");
                    sb.Append("r.invoice_total, r.invoice_trade_price, r.invoice_retail_price, r.invoice_discount_rate, ");
                    sb.Append("to_char(r.receive_date, 'yyyy-mm-dd hh24:mi:ss') as receive_date,to_char(r.receive_date,'yyyy-mm-dd hh24:mi:ss') as R_RECEIVE_DATE ");

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
                    sb.Append(" select goi.item_status,decode(goi.item_status,'2','已阅读','3','已确认','4','到货中','5','作废','6','缺货') status,");
                    sb.Append("        gos.id,gos.order_id,gos.order_item_id,");
                    sb.Append("        ghc.medical_name,");
                    sb.Append("        ghc.trade_name,");
                    sb.Append("        nvl(ghc.spec, '-') || '×' || nvl(to_char(ghc.stand_rate), '-') ||");
                    sb.Append("        nvl(ghc.use_unit, '') || '/' || nvl(ghc.SPEC_UNIT, '') ||");
                    sb.Append("        decode(ghc.wrap_code,");
                    sb.Append("               '01',");
                    sb.Append("               '',");
                    sb.Append("               nvl2(ghc.wrap_name, '(' || ghc.wrap_name || ')', '')) as ggbz,");
                    sb.Append("        ghc.PRODUCER_SHORTNAME factory_easy,");
                    sb.Append("        ghc.PRODUCER_FULLNAME factory_name,");
                    sb.Append("        ghc.provide_price,");
                    sb.Append("        goi.request_qty,");
                    sb.Append("        gpi.buyer_remark,");
                    
                    sb.Append("        gos.lot_no,");
                    sb.Append("        gos.stockup_qty,");
                    sb.Append("        gos.invoice_no,");
                    sb.Append("        to_char(gos.invoice_date, 'yyyy-mm-dd') invoice_date,");
                    sb.Append("        gos.ready_date,");
                    sb.Append("        to_char(gos.invoice_expire_date, 'yyyy-mm-dd') invoice_expire_date,");
                    sb.Append("        gos.amount,");
                    sb.Append("        gos.trade_price,");
                    sb.Append("        gos.retail_price,");
                    sb.Append("        gos.discount,");
                    sb.Append("        gos.remark,");
                    sb.Append("        gos.ready_flag,");

                    //最大送货数计算方法修改 cj 2007-8-15
                    //sb.Append("        (select goi.request_qty * 2 - sum(st.stockup_qty)");                    
                    //sb.Append("           from gpo_order_stockup st");
                    //sb.Append("          where st.order_item_id = gos.order_item_id and ");
                    //sb.Append("          group by st.order_item_id) maxQty,");
                    sb.Append("        goi.request_qty * 2 - sty.sendQty maxQty,");

                    sb.Append("         ghc.saler_id");
                    sb.Append("   from GPO_ORDER_STOCKUP gos,");
                    sb.Append("        GPO_HIT_COMM      ghc,");
                    sb.Append("        GPO_ORDER_ITEM    goi,");
                    sb.Append("        GPO_PURCHASE_ITEM gpi,");
                    //最大送货数计算方法修改 cj 2007-8-15
                    sb.Append("        (select order_item_id ,sum(stockup_qty) as sendQty from gpo_order_stockup where ready_flag = '1' group by order_item_id) sty ");
                    
                    sb.Append("  where goi.hit_comm_id = ghc.record_id");
                    sb.Append("    and goi.purchase_item_id = gpi.id");
                    sb.Append("    and goi.record_id = gos.order_item_id");
                    sb.Append("    and goi.order_id = '").Append(input.OrderId).Append("'");
                    sb.Append("    and goi.item_status != '7'");
                    //最大送货数计算方法修改 cj 2007-8-15
                    sb.Append(" and sty.order_item_id(+) = gos.order_item_id");
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
            sql.Append(" select rownum,x.* from (");
            sql.Append(sb.ToString());
            sql.Append(") x");

            //List<DbParameter> parameters = new List<DbParameter>();
            //DbParameter param = base.DbFacade.CreateParameter();
            //param.ParameterName = "order_id";
            //param.DbType = DbType.String;
            //param.Value = input.OrderId;
            //parameters.Add(param);

            try
            {
                //rows = base.GetRowCount(sql.ToString(), parameters.ToArray());
                //该sql需要用户自己绑定:highRowNum(该页的最大记录行数)和:lowRowNum(该页的最小记录行数)参数.
                //DbParameter highIndexPara = DbFacade.CreateParameter();
                //highIndexPara.ParameterName = "highRowNum";
                //highIndexPara.DbType = DbType.Int32;
                //highIndexPara.Value = PageUtils.GetHighIndexOfPage(int.Parse(pageParam.PageNum), int.Parse(pageParam.PageSize));
                //parameters.Add(highIndexPara);

                //DbParameter lowIndexPara = DbFacade.CreateParameter();
                //lowIndexPara.ParameterName = "lowRowNum";
                //lowIndexPara.DbType = DbType.Int32;
                //lowIndexPara.Value = PageUtils.GetLowIndexOfPage(int.Parse(pageParam.PageNum), int.Parse(pageParam.PageSize));
                //parameters.Add(lowIndexPara);

                reader = DbFacade.SQLExecuteReader(sql.ToString());
            }
            catch (Exception e)
            {

                throw e;
            }

            return reader;
        }
        #endregion


        /// <summary>
        /// 修改备货表
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private bool UpdateOrderReceive(DbTransaction transaction, OutputInfoModel model, Emedchina.TradeAssistant.Model.User.UserInfo ui,bool flag)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" update Gpo_Order_Stockup ");            
            
            sql.AppendFormat(" set LOT_NO = '{0}',", model.LOT_NO);
            sql.AppendFormat(" STOCKUP_QTY = {0},", model.RECEIVE_QTY);
            
            sql.AppendFormat(" INVOICE_NO = '{0}',", model.R_invoice_no);
            sql.AppendFormat(" INVOICE_DATE = to_date('{0}','YYYY-MM-DD'),", model.R_invoice_date);
            sql.AppendFormat(" INVOICE_EXPIRE_DATE = to_date('{0}','YYYY-MM-DD'),", model.R_invoice_expire_date);
            sql.AppendFormat(" AMOUNT = '{0}',", model.R_invoice_total);
            sql.AppendFormat(" TRADE_PRICE = '{0}',", model.R_invoice_trade_price);
            sql.AppendFormat(" RETAIL_PRICE = '{0}',",model.R_invoice_retail_price);
            sql.AppendFormat(" DISCOUNT = '{0}',",model.R_invoice_discount_rate);

            if (flag)
            {
                sql.Append(" READY_FLAG = '1',");
            }
            else
            {
                sql.Append(" READY_DATE = sysdate,");
                sql.AppendFormat(" READY_USERID = '{0}',", ui.Id);
            }
            sql.AppendFormat(" MODIFY_USER = '{0}',", ui.Id);
            sql.AppendFormat(" MODIFY_DATE = sysdate,");
            sql.AppendFormat(" REMARK = '{0}'", model.R_ready_remark);
            sql.AppendFormat(" where ID = '{0}'",model.R_ID);

            int result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            if (result > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 删除备货表信息
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteOrderReceive(DbTransaction transaction,string id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" delete from Gpo_Order_Stockup");
            sql.AppendFormat(" where ID = '{0}'", id);

            int result = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            if (result > 0)
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
        public bool ConfirmOrderReceive(IList result,  Emedchina.TradeAssistant.Model.User.UserInfo ui)
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
        /// 删除送货信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool DeleteOrderReceive(IList result)
        {

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {

                    foreach (OutputInfoModel model in result)
                    {
                        if (!model.IsCheck)
                            continue;
                        DeleteOrderReceive(transaction, model.R_ID);

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
                .Append("gp.create_date as creatdate,to_char(go.request_total,'999,999,999,990.00') as requesttotal,go.order_state as order_state,(select to_char(nvl(sum(unit_price * receive_qty),0), '999,999,999,990.00')")
                .Append(" from GPO_ORDER_ITEM goi, GPO_ORDER_RECEIVE gor")
                .Append(" where goi.record_id = gor.order_item_id")
                .Append(" and goi.order_id = go.order_id) receive_total,go.order_id,")
                .Append(" gp.create_username as username,gp.approve_username  as approveusername,decode(go.ORDER_STATE,'0','发送','1','已阅读','2','交易中','3','完成') as orderstate,gpohouse.WAREHOUSE_NAME as warehousename from GPO_ORDER go, GPO_PURCHASE gp,GPO_WAREHOUSE gpohouse, GPO_REG_BUYER grb")
                .Append("  where go.purchase_id = gp.id and gpohouse.ID(+)=go.REPOSITORY_ID  and go.order_id ='" + orderId + "' and go.BUYER_ORGID = grb.ID");


                model = DbFacade.SQLExecuteObject(sql.ToString(), new MapRow(MapOrderTitle)) as SalerOrderModel;
        
            }
            catch (Exception e)
            {
                throw e;
            }
            return model;
        }


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

            //model.Buyer_orgid = Convert.ToString(reader["buyer_orgid"]);
            //model.Saler_orgid = Convert.ToString(reader["saler_orgid"]);
            //model.Sender_orgid = Convert.ToString(reader["sender_orgid"]);
            //model.Bak_sender_easy = Convert.ToString(reader["bak_sender_name"]);
            //model.Order_code = Convert.ToString(reader["order_code"]);

            return model;
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
            sql.Append("update gpo_order_item set item_status = '2',MODIFY_DATE=sysdate,MODIFY_USERID='").Append(userId).Append("' ");
            sql.Append(" where item_status = '1' and order_id = '");
            sql.Append(orderId).Append("' ");

            DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
            
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
                //sql.Append("insert into Gpo_Item_Status values('");
                //sql.Append(this.GetNewId(OracleDAOBase.SEQ_ORDER, OracleDAOBase.SEQ_GPO)).Append("','").Append(dr[0].ToString()).Append("','").Append(state).Append("','").Append(userId).Append("','").Append(userName).Append("',sysdate");
                //DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
                //sql.Remove(0, sql.Length);
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
            sql.Append(this.GetNewId(OracleDAOBase.SEQ_ORDER, OracleDAOBase.SEQ_GPO)).Append("','").Append(recordId).Append("','").Append(state).Append("','").Append(userId).Append("','").Append(userName).Append("',sysdate)");
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
	        sql.Append(" update gpo_order o set o.order_state='")
			        .Append(orderState).Append("'");
	        sql.Append(", o.modify_userid = '").Append(modifyUserId).Append(
			        "', o.modify_date = sysdate ");
	        sql.Append(" where o.order_id='").Append(orderId).Append("'");
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
        #endregion



    
    }
}
