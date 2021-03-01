using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;

namespace Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder
{
    class OrderDetailOfflineDao : SqlDAOBase
    {
        private OrderDetailOfflineDao()
            : base()
        { }

        private OrderDetailOfflineDao(string connectionName)
            : base(connectionName)
        { }

        public static OrderDetailOfflineDao GetInstance()
        {
            return new OrderDetailOfflineDao();
        }

        public static OrderDetailOfflineDao GetInstance(string connectionName)
        {
            return new OrderDetailOfflineDao(connectionName);
        }

        //按订单，获得分页的订单明细信息
        public DataSet GetOrderDetailListByOrder(string orderId, string productName, out int rows)
        {
            //int pageNum = Int32.Parse(pageParam.PageNum);
            //int pageSize = Int32.Parse(pageParam.PageSize);
//            string sql = @"select h.trade_name,
//           h.medical_name,
//           iif(h.Spec is null,'-',h.spec) & '×' &  iif(h.Stand_Rate Is Null, '-',h.Stand_Rate) & iif(h.Use_Unit Is Null, '',h.Use_Unit) & '/' & iif(h.Spec_Unit Is Null, '',h.Spec_Unit) & Switch(h.Wrap_Name Is Null, '', h.Wrap_Name='空', '',True,'(' & h.Wrap_Name & ')') As Ggbz, 
//           Switch(i.unit_price Is Null,'-',True,Trim(Format(i.unit_price, 'Standard'))) As unit_price,
//           i.record_id,
//           CLng(iif(i.request_qty is null,0,i.request_qty)) as request_qty,
//           i.saler_desc,
//           i.buyer_desc,
//           Switch(i.item_status='1','发送',i.item_status='2',
//                  '已阅读',
//                  i.item_status='3',
//                  '已送货',
//                  i.item_status='5',
//                  '作废',
//                  i.item_status='6',
//                  '缺货',
//                  i.item_status='7',
//                  '完成') as item_status,
//           Switch(i.order_type='0','蓝票',
//                             i.order_type='1','到货',
//                             i.order_type='2','红票') As order_type,
//           h.doseage_form,
//           Switch(h.province_max_price Is Null,'-',True,Trim(Format(h.province_max_price, 'Standard'))) As province_max_price,
//           Switch(h.province_insurance_flag='0',
//                  '非国家基本医疗保险产品',
//                  h.province_insurance_flag='1',
//                  '甲类',
//                  h.province_insurance_flag='2',
//                  '乙类',
//                  h.province_insurance_flag='3',
//                  '民族药') as province_insurance_flag,
//           h.dealer_fullname,
//           format(h.last_order_date,'yyyy-mm-dd') as last_order_date,
//           CLng(iif(h.last_order_qty is null,0,h.last_order_qty)) as last_order_qty,
//           l.name,
//           Switch(i.con_type='1',
//                  '招标',
//                  i.con_type='2',
//                  '竞价',
//                  i.con_type='3',
//                  '询价',
//                  i.con_type='4',
//                  '备案',
//                  i.con_type='7',
//                  '浏览',
//                  i.con_type='9',
//                  '临时',
//                  i.con_type='c',
//                  'GPO直销',
//                  i.con_type='d',
//                  'GPO自主合同') as con_type,
//                          h.medical_id,
//                          h.medical_wubi,
//                          h.medical_pinyin,
//                          h.medical_code,
//                          h.spell_abbr,
//                          
//                          h.name_wb,
//                          CLng(iif(REC.RECEIVE_QTY is null,0,REC.RECEIVE_QTY)) as receive_qty 
//      from ((GPO_ORDER_ITEM AS i INNER JOIN GPO_HIT_COMM AS h ON i.HIT_COMM_ID = h.RECORD_ID) INNER JOIN CONT_LIST AS l ON h.CONTRACT_ID = l.ID) LEFT JOIN GPO_ORDER_RECEIVE AS REC ON i.RECORD_ID = REC.ORDER_ITEM_ID Where
//           i.order_id = :orderId";





              string sql = @"          select 
              i.Id, i.Order_Id, 
             (case when i.trade_Price Is Null then '-' else i.trade_Price end) As 

             trade_Price,

             (case when i.RETAIL_PRICE Is Null then '-' else i.RETAIL_PRICE end) 
             As RETAIL_PRICE,i.SUM AS total,


             i.AMOUNT  As Request_Qty, i.SALER_DESCRIPTIONS as Saler_Desc,

            i.BUYER_DESCRIPTIONS as Buyer_Desc,
             

            i.OVER_AMOUNT as OVER_AMOUNT,
            i.OVER_SUM  as OVER_SUM,


            (case i.STATE when '1' then '发送' when  '2' then '已阅读' when '3' then '作废' when '4' then '已确认' when '5' then '完成' 
              end) As status, 

            (case i.order_type when '0' then '蓝票'
                                         when '1' then '到货'
                                         when '2' then '红票' end) As order_type,
                    

                      
                       h.MANU_ID,
                       h.MANU_NAME,
                       h.MANU_NAME_ABBR,
                       h.PRODUCT_NAME,
                       h.COMMERCE_NAME,
			            h.COMMON_NAME,           
			            h.CODE,
			            h.ABBR_PY,
             
                       h.ABBR_WB,
			            h.BRAND,
			            i.SPEC,
			            i.MODEL,


            (case when i.OVER_AMOUNT is null then 0 else i.OVER_AMOUNT end) as receive_qty 

            from 

            (HC_ORD_ORDER_ITEM AS i INNER JOIN HC_ORD_PRODUCT AS h ON i.PROJECT_PROD_ID = h.ID)

             LEFT JOIN HC_ORD_ORDER_RECEIVE 

            AS REC ON i.ID = REC.ORDER_ITEM_ID  

            where
             i.order_id = @orderId and i.state <> '3'";



            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.Int64;
            orderIdPara.Value = orderId;
            parameters.Add(orderIdPara);

            if (!(string.IsNullOrEmpty(productName)))
            {
                string appender = @"
                 And (h.PRODUCT_NAME Like @productName
                     Or h.COMMERCE_NAME Like @productName
                     Or h.CODE Like @productName
                     Or h.ABBR_WB Like @productName
                     Or h.ABBR_PY Like @productName
                     Or h.COMMON_NAME Like @productName)
                 ";
                sql += appender;

                DbParameter productNamePara = this.DbFacade.CreateParameter();
                productNamePara.ParameterName = "productName";
                productNamePara.DbType = DbType.String;
                productNamePara.Value = ComUtil.GetLike(productName);
                parameters.Add(productNamePara);
            }

            if ((orderId == null))
            {
                throw new System.ArgumentNullException("orderId");
            }

            rows = 0;
            //string pagedSql = base.GetPagedSql(sql, pageNum, pageSize);

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());

            table.TableName = "OrderDetailByOrder";
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;

        }


        //按订单，获得分页的订单明细信息
        public DataSet GetOrderDetailListByOrder(string orderId)
        {
          
            string sql = @"          select 
              i.Id, i.Order_Id, 
             (case when i.trade_Price Is Null then '-' else i.trade_Price end) As 

             trade_Price,

             (case when i.RETAIL_PRICE Is Null then '-' else i.RETAIL_PRICE end) 
             As RETAIL_PRICE,i.SUM AS total,


             i.AMOUNT  As Request_Qty, i.SALER_DESCRIPTIONS as Saler_Desc,

            i.BUYER_DESCRIPTIONS as Buyer_Desc,i.sender_Name,i.sender_Name_Abbr,
             

            i.OVER_AMOUNT as OVER_AMOUNT,
            i.OVER_SUM  as OVER_SUM,


            (case i.STATE when '1' then '发送' when  '2' then '已阅读' when '3' then '作废' when '4' then '已确认' when '5' then '完成' 
              end) As status, 

            (case i.order_type when '0' then '蓝票'
                                         when '1' then '到货'
                                         when '2' then '红票' end) As order_type,
                    

                      
                       h.MANU_ID,
                       h.MANU_NAME,
                       h.MANU_NAME_ABBR,
                       h.PRODUCT_NAME,
                       h.COMMERCE_NAME,
			            h.COMMON_NAME,           
			            h.CODE,
			            h.ABBR_PY,
             
                       h.ABBR_WB,
			            h.BRAND,
			            i.SPEC,
			            i.MODEL,
             (case when i.Send_measure is null then '-' else i.Send_measure end ) as Send_measure,

            (case when i.OVER_AMOUNT is null then 0 else i.OVER_AMOUNT end) as receive_qty 

            from 

            (HC_ORD_ORDER_ITEM AS i INNER JOIN HC_ORD_PRODUCT AS h ON i.PROJECT_PROD_ID = h.ID)

             LEFT JOIN HC_ORD_ORDER 

            AS REC ON i.ORDER_ID = REC.ID  

            where
             REC.ID = @orderId  and i.state <> '3'";



            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.Int64;
            orderIdPara.Value = orderId;
            parameters.Add(orderIdPara);

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());

            table.TableName = "OrderDetailByOrder";
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;

        }

        /// <summary>
        /// 订单详细列表，如果按订单到货
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailListByOrder(string orderId, string productName)
        {
            string sql = @"select h.trade_name,
           h.medical_name,
           iif(h.Spec is null,'-',h.spec) & '×' &  iif(h.Stand_Rate Is Null, '-',h.Stand_Rate) & iif(h.Use_Unit Is Null, '',h.Use_Unit) & '/' & iif(h.Spec_Unit Is Null, '',h.Spec_Unit) & Switch(h.Wrap_Name Is Null, '', h.Wrap_Name='空', '',True,'(' & h.Wrap_Name & ')') As Ggbz, 
           Switch(i.unit_price Is Null,'-',True,Trim(Format(i.unit_price, 'Standard'))) As unit_price,
           i.record_id,
           CLng(iif(i.request_qty is null,0,i.request_qty)) as request_qty,
           i.saler_desc,
           i.buyer_desc,
           Switch(i.item_status='1','发送',i.item_status='2',
                  '已阅读',
                  i.item_status='3',
                  '已送货',
                  i.item_status='5',
                  '作废',
                  i.item_status='6',
                  '缺货',
                  i.item_status='7',
                  '完成') as item_status,
           Switch(i.order_type='0','蓝票',
                             i.order_type='1','到货',
                             i.order_type='2','红票') As order_type,
           h.doseage_form,
           Switch(h.province_max_price Is Null,'-',True,Trim(Format(h.province_max_price, 'Standard'))) As province_max_price,
           Switch(h.province_insurance_flag='0',
                  '非国家基本医疗保险产品',
                  h.province_insurance_flag='1',
                  '甲类',
                  h.province_insurance_flag='2',
                  '乙类',
                  h.province_insurance_flag='3',
                  '民族药') as province_insurance_flag,
           h.dealer_fullname,
           h.last_order_date,
           CLng(iif(h.last_order_qty is null,0,h.last_order_qty)) as last_order_qty,
           l.name,
           Switch(i.con_type='1',
                  '招标',
                  i.con_type='2',
                  '竞价',
                  i.con_type='3',
                  '询价',
                  i.con_type='4',
                  '备案',
                  i.con_type='7',
                  '浏览',
                  i.con_type='9',
                  '临时',
                  i.con_type='c',
                  'GPO直销',
                  i.con_type='d',
                  'GPO自主合同') as con_type,
                          h.medical_id,
                          h.medical_wubi,
                          h.medical_pinyin,
                          h.medical_code,
                          h.spell_abbr,
                          h.name_wb
      from gpo_order_item i, gpo_hit_comm h, cont_list l
      where i.hit_comm_id = h.record_id and h.contract_id = l.id and
       i.order_id = :orderId";

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.String;
            orderIdPara.Value = orderId;
            parameters.Add(orderIdPara);

            if (!(string.IsNullOrEmpty(productName)))
            {
                string appender = @"
                 And (h.medical_name Like :productName
                     Or h.medical_id Like :productName
                     Or h.medical_wubi Like :productName
                     Or h.medical_pinyin Like :productName
                     Or h.medical_code Like :productName
                     Or h.trade_name Like :productName
                     Or h.spell_abbr Like :productName
                     Or h.name_wb Like :productName)
                 ";
                sql += appender;

                DbParameter productNamePara = this.DbFacade.CreateParameter();
                productNamePara.ParameterName = "productName";
                productNamePara.DbType = DbType.String;
                productNamePara.Value = ComUtil.GetLike(productName);
                parameters.Add(productNamePara);
            }

            if ((orderId == null))
            {
                throw new System.ArgumentNullException("orderId");
            }

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql, parameters.ToArray());
            table.TableName = "OrderDetailByOrder";
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
            //rows = ds.Tables[0].Rows.Count;
        }

        //按企业，获得分页的订单明细信息
        public DataSet GetOrderDetailList(OrderDetailSearchModel input, string salerId, string buyerId, string areaId, string productName, PagedParameter pageParam, out int rows)
        {
            int pageNum = Int32.Parse(pageParam.PageNum);
            int pageSize = Int32.Parse(pageParam.PageSize);
            string sql = @"select h.trade_name, 
               h.medical_name, 
               iif(h.Spec is null,'-',h.spec) & '×' &  iif(h.Stand_Rate Is Null, '-',h.Stand_Rate) & iif(h.Use_Unit Is Null, '',h.Use_Unit) & '/' & iif(h.Spec_Unit Is Null, '',h.Spec_Unit) & Switch(h.Wrap_Name Is Null, '', h.Wrap_Name='空', '',True,'(' & h.Wrap_Name & ')') As Ggbz, 
               Switch(i.unit_price Is Null,'-',True,Trim(Format(i.unit_price, 'Standard'))) As unit_price,
               i.record_id, 
               CLng(iif(i.request_qty is null,0,i.request_qty)) as request_qty,
               i.saler_desc, 
               Switch(i.item_status='1','发送',i.item_status='2',
                  '已阅读',
                  i.item_status='3',
                  '已送货',
                  i.item_status='5',
                  '作废',
                  i.item_status='6',
                  '缺货',
                  i.item_status='7',
                  '完成') as item_status, 
               Switch(i.order_type='0','蓝票',
                             i.order_type='1','到货',
                             i.order_type='2','红票') As order_type,
               h.doseage_form,
               h.province_max_price, 
               Switch(h.province_insurance_flag='0',
                  '非国家基本医疗保险产品',
                  h.province_insurance_flag='1',
                  '甲类',
                  h.province_insurance_flag='2',
                  '乙类',
                  h.province_insurance_flag='3',
                  '民族药') as province_insurance_flag, 
               h.dealer_fullname, 
               l.name,
               h.last_order_date,
               CLng(iif(h.last_order_qty is null,0,h.last_order_qty)) as last_order_qty,
               Switch(i.con_type='1',
                  '招标',
                  i.con_type='2',
                  '竞价',
                  i.con_type='3',
                  '询价',
                  i.con_type='4',
                  '备案',
                  i.con_type='7',
                  '浏览',
                  i.con_type='9',
                  '临时',
                  i.con_type='c',
                  'GPO直销',
                  i.con_type='d',
                  'GPO自主合同') as con_type,
                      h.medical_id,
                      h.medical_wubi,
                      h.medical_pinyin,
                      h.medical_code,
                      h.spell_abbr,
                      h.name_wb
          from gpo_order_item i, gpo_hit_comm h, gpo_order o, cont_list l
         where i.hit_comm_id = h.record_id
           and h.contract_id = l.id
            and o.order_id = i.order_id
            
            and o.saler_id = :salerId
            and i.buyer_orgid = :buyerId
            and o.area_id = :areaId";
            //modify by yanbing 2007-07-10
            //and o.order_state = '2'


            if (!String.IsNullOrEmpty(input.OrderState))
            {
                sql = sql + "  and o.order_state =:order_state";
            }

            //查询条件:发送时间开始
            if (!String.IsNullOrEmpty(input.StartDate))
            {
                sql = sql + string.Format(" and o.create_date>CDate('{0}')", input.StartDate);
            }

            //查询条件:发送时间结束
            if (!String.IsNullOrEmpty(input.EndDate))
            {
                sql = sql + string.Format(" and o.create_date<=CDate('{0}')", input.EndDate);
            }
            //end modify

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter salerIdPara = this.DbFacade.CreateParameter();
            salerIdPara.ParameterName = "salerId";
            salerIdPara.DbType = DbType.String;
            salerIdPara.Value = salerId;
            parameters.Add(salerIdPara);

            DbParameter buyerIdPara = this.DbFacade.CreateParameter();
            buyerIdPara.ParameterName = "buyerId";
            buyerIdPara.DbType = DbType.String;
            buyerIdPara.Value = buyerId;
            parameters.Add(buyerIdPara);

            DbParameter areaIdPara = this.DbFacade.CreateParameter();
            areaIdPara.ParameterName = "areaId";
            areaIdPara.DbType = DbType.String;
            areaIdPara.Value = areaId;
            parameters.Add(areaIdPara);

            //modify by yanbing 2007-07-11
            if (!String.IsNullOrEmpty(input.OrderState))
            {
                DbParameter orderStatePara = this.DbFacade.CreateParameter();
                orderStatePara.ParameterName = "order_state";
                orderStatePara.DbType = DbType.String;
                orderStatePara.Value = input.OrderState;
                parameters.Add(orderStatePara);
            }

            //查询条件:创建人
            if (!String.IsNullOrEmpty(input.Creater))
            {
                sql = sql + " and UCase(o.create_username) like :creater";
                DbParameter createrPara = this.DbFacade.CreateParameter();
                createrPara.ParameterName = "creater";
                createrPara.DbType = DbType.String;
                createrPara.Value = ComUtil.GetLike(input.Creater.ToUpper());
                parameters.Add(createrPara);

            }

            //查询条件：1卖方企业或2订单号
            if ("1".Equals(input.SearchField))
            {
                if (!String.IsNullOrEmpty(input.SearchKey))
                {
                    sql = sql + " and UCase(o.saler_name & o.saler_easy & o.saler_wubi & o.saler_fast) like :org ";
                    DbParameter orgPara = this.DbFacade.CreateParameter();
                    orgPara.ParameterName = "org";
                    orgPara.DbType = DbType.String;
                    orgPara.Value = ComUtil.GetLike(input.SearchKey.ToUpper());
                    parameters.Add(orgPara);
                }
            }
            if ("2".Equals(input.SearchField))
            {
                if (!String.IsNullOrEmpty(input.SearchKey))
                {
                    sql = sql + " and UCase(o.order_code) like :code ";
                    DbParameter codePara = this.DbFacade.CreateParameter();
                    codePara.ParameterName = "code";
                    codePara.DbType = DbType.String;
                    codePara.Value = ComUtil.GetLike(input.SearchKey.ToUpper());
                    parameters.Add(codePara);
                }
            }
            //end modify

            int count = 3;
            if (!((productName == null) || (productName == "")))
            {
                string appender = @"
                 And (h.medical_name Like :productName
                     Or h.medical_id Like :productName
                     Or h.medical_wubi Like :productName
                     Or h.medical_pinyin Like :productName
                     Or h.medical_code Like :productName
                     Or h.trade_name Like :productName
                     Or h.spell_abbr Like :productName
                     Or h.name_wb Like :productName)
                 ";
                sql += appender;
                count = 4;

                DbParameter productNamePara = this.DbFacade.CreateParameter();
                productNamePara.ParameterName = "productName";
                productNamePara.DbType = DbType.String;
                productNamePara.Value = ComUtil.GetLike(productName);
                parameters.Add(productNamePara);
            }


            if ((salerId == null))
            {
                throw new System.ArgumentNullException("salerId");
            }

            if ((buyerId == null))
            {
                throw new System.ArgumentNullException("buyerId");
            }

            if ((areaId == null))
            {
                parameters[2].Value = System.DBNull.Value;
            }

            rows = base.GetRowCount(sql, parameters.ToArray());
            //string pagedSql = base.GetPagedSql(sql, pageNum, pageSize);

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());

            table.TableName = "OrderDetail";
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
        }

        /// <summary>
        /// 订单详细列表，如果按企业到货
        /// </summary>
        /// <param name="salerId"></param>
        /// <param name="buyerId"></param>
        /// <param name="areaId"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailList(string salerId, string buyerId, string areaId, string productName)
        {
            string sql = @"select h.trade_name, 
               h.medical_name, 
               iif(h.Spec is null,'-',h.spec) & '×' &  iif(h.Stand_Rate Is Null, '-',h.Stand_Rate) & iif(h.Use_Unit Is Null, '',h.Use_Unit) & '/' & iif(h.Spec_Unit Is Null, '',h.Spec_Unit) & Switch(h.Wrap_Name Is Null, '', h.Wrap_Name='空', '',True,'(' & h.Wrap_Name & ')') As Ggbz,  
               Switch(i.unit_price Is Null,'-',True,Trim(Format(i.unit_price, 'Standard'))) As unit_price,
               i.record_id, 
               CLng(iif(i.request_qty is null,0,i.request_qty)) as request_qty,
               i.saler_desc, 
               Switch(i.item_status='1','发送',i.item_status='2',
                  '已阅读',
                  i.item_status='3',
                  '已送货',
                  i.item_status='5',
                  '作废',
                  i.item_status='6',
                  '缺货',
                  i.item_status='7',
                  '完成') as item_status,
               Switch(i.order_type='0','蓝票',
                             i.order_type='1','到货',
                             i.order_type='2','红票') As order_type,
               h.doseage_form,
               Switch(h.province_max_price Is Null,'-',True,Trim(Format(h.province_max_price, 'Standard'))) As province_max_price,
               Switch(h.province_insurance_flag='0',
                  '非国家基本医疗保险产品',
                  h.province_insurance_flag='1',
                  '甲类',
                  h.province_insurance_flag='2',
                  '乙类',
                  h.province_insurance_flag='3',
                  '民族药') as province_insurance_flag,
               h.dealer_fullname, 
               l.name,
               h.last_order_date,
               CLng(iif(h.last_order_qty is null,0,h.last_order_qty)) as last_order_qty,
               Switch(i.con_type='1',
                  '招标',
                  i.con_type='2',
                  '竞价',
                  i.con_type='3',
                  '询价',
                  i.con_type='4',
                  '备案',
                  i.con_type='7',
                  '浏览',
                  i.con_type='9',
                  '临时',
                  i.con_type='c',
                  'GPO直销',
                  i.con_type='d',
                  'GPO自主合同') as con_type,
                      h.medical_id,
                      h.medical_wubi,
                      h.medical_pinyin,
                      h.medical_code,
                      h.spell_abbr,
                      h.name_wb
          from gpo_order_item i, gpo_hit_comm h, gpo_order o, cont_list l
         where i.hit_comm_id = h.record_id
           and h.contract_id = l.id
            and o.order_id = i.order_id
            and o.saler_id = :salerId
            and i.buyer_orgid = :buyerId
            and o.area_id = :areaId
         ";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter salerIdPara = this.DbFacade.CreateParameter();
            salerIdPara.ParameterName = "salerId";
            salerIdPara.DbType = DbType.String;
            salerIdPara.Value = salerId;
            parameters.Add(salerIdPara);

            DbParameter buyerIdPara = this.DbFacade.CreateParameter();
            buyerIdPara.ParameterName = "buyerId";
            buyerIdPara.DbType = DbType.String;
            buyerIdPara.Value = buyerId;
            parameters.Add(buyerIdPara);

            DbParameter areaIdPara = this.DbFacade.CreateParameter();
            areaIdPara.ParameterName = "areaId";
            areaIdPara.DbType = DbType.String;
            areaIdPara.Value = areaId;
            parameters.Add(areaIdPara);

            int count = 3;
            if (!((productName == null) || (productName == "")))
            {
                string appender = @"
                 And (h.medical_name Like :productName
                     Or h.medical_id Like :productName
                     Or h.medical_wubi Like :productName
                     Or h.medical_pinyin Like :productName
                     Or h.medical_code Like :productName
                     Or h.trade_name Like :productName
                     Or h.spell_abbr Like :productName
                     Or h.name_wb Like :productName)
                 ";
                sql += appender;

                DbParameter productNamePara = this.DbFacade.CreateParameter();
                productNamePara.ParameterName = "productName";
                productNamePara.DbType = DbType.String;
                productNamePara.Value = ComUtil.GetLike(productName);
                parameters.Add(productNamePara);
            }

            if ((salerId == null))
            {
                throw new System.ArgumentNullException("salerId");
            }

            if ((buyerId == null))
            {
                throw new System.ArgumentNullException("buyerId");
            }

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());
            table.TableName = "OrderDetail";
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;
        }

        #region 订单明细作废
        /// <summary>
        /// 订单明细作废--业务逻辑方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns>订单主表ID</returns>
        public string doOrderItemCancel(OrderItemInputModel input)
        {
            string orderItemId = input.OrderItemId;
            string userId = input.UserId;
            string userName = input.UserName;

            //(1)把原订单明细表的item_status设为5作废（order_type设为0蓝票），往订单状态表中插入一条记录
            ///先取出记录作为备份。
            DataTable gpoOrderItemTable = RetrieveByPK(orderItemId);
            string orderId = "";
            foreach (DataRow row in gpoOrderItemTable.Rows)
            {
                orderId = row["ORDER_ID"].ToString();
            }
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    UpdateOrderItem(orderItemId, "5", "0", userId);
                    //往订单状态表中插入一条记录
                    //AddGpoItemStatus(orderItemId, "5", userId, userName);
                    //(2)往订单明细表中增加一条与原订单明细相同的信息（订购量为原来的负值，order_type设为2 红冲）创建时间为原订单明细的时间，
                    long newItemId = CopyGpoOrderItem(orderItemId,input.HighId);
                    //往订单状态表中插入一条记录
                    //AddGpoItemStatus(newItemId, "2", userId, userName);

                    //更新订单主表的状态
                    UpdateOrderState(orderId, userId);
                    //更新订单主表的订购金额
                    UpdateRequestTotalByOrder(orderId, userId);
                    DbFacade.CommitTransaction(transaction);

                }
                catch
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw;
                }
            }
            //返回orderId
            return orderId;
        }

        /// <summary>
        /// 更新订单明细表
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <param name="itemStatus"></param>
        /// <param name="orderType"></param>
        /// <param name="userId"></param>
        public int UpdateOrderItem(string orderItemId, string itemStatus, string orderType, string userId)
        {
            string sql = @"UPDATE HC_ORD_ORDER_ITEM
                   SET state      = @itemStatus,
                       ORDER_TYPE       = @orderType,
                       MODIFY_USER_ID    = @userId,
                       MODIFY_DATE      = getdate(),Sync_State='0'
                   WHERE (ID = @orderItemId)";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter itemStatusPara = this.DbFacade.CreateParameter();
            itemStatusPara.ParameterName = "itemStatus";
            itemStatusPara.DbType = DbType.String;
            itemStatusPara.Value = itemStatus;
            parameters.Add(itemStatusPara);

            DbParameter orderTypePara = this.DbFacade.CreateParameter();
            orderTypePara.ParameterName = "orderType";
            orderTypePara.DbType = DbType.String;
            orderTypePara.Value = orderType;
            parameters.Add(orderTypePara);

            DbParameter userIdPara = this.DbFacade.CreateParameter();
            userIdPara.ParameterName = "userId";
            userIdPara.DbType = DbType.Int64;
            userIdPara.Value = userId;
            parameters.Add(userIdPara);

            DbParameter orderItemIdPara = this.DbFacade.CreateParameter();
            orderItemIdPara.ParameterName = "orderItemId";
            orderItemIdPara.DbType = DbType.Int64;
            orderItemIdPara.Value = orderItemId;
            parameters.Add(orderItemIdPara);

            int returnVal = base.DbFacade.SQLExecuteNonQuery(sql, parameters.ToArray());
            return returnVal;
        }

        /// <summary>
        /// 新增订单明细状态表
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="RECORD_ID"></param>
        /// <param name="ORDER_ITEM_STATE"></param>
        /// <param name="MODIFY_USERID"></param>
        /// <param name="MODIFY_USERNAME"></param>
        public int AddGpoItemStatus(string RECORD_ID, string ORDER_ITEM_STATE, string MODIFY_USERID, string MODIFY_USERNAME)
        {
            string sql = @" 
                    INSERT INTO GPO_ITEM_STATUS
                      (ID,
                       RECORD_ID,
                       ORDER_ITEM_STATE,
                       MODIFY_USERID,
                       MODIFY_USERNAME,
                       MODIFY_DATE,
                       SYNC_STATE)
                    VALUES
                      (:id,
                       :RECORD_ID,
                       :ORDER_ITEM_STATE,
                       :MODIFY_USERID,
                       :MODIFY_USERNAME,
                       now(),'0')";

            string id = this.GetGlobalId();

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.String;
            idPara.Value = id;
            parameters.Add(idPara);

            DbParameter RECORD_IDPara = this.DbFacade.CreateParameter();
            RECORD_IDPara.ParameterName = "RECORD_ID";
            RECORD_IDPara.DbType = DbType.String;
            RECORD_IDPara.Value = RECORD_ID;
            parameters.Add(RECORD_IDPara);

            DbParameter ORDER_ITEM_STATEPara = this.DbFacade.CreateParameter();
            ORDER_ITEM_STATEPara.ParameterName = "ORDER_ITEM_STATE";
            ORDER_ITEM_STATEPara.DbType = DbType.String;
            ORDER_ITEM_STATEPara.Value = ORDER_ITEM_STATE;
            parameters.Add(ORDER_ITEM_STATEPara);

            DbParameter MODIFY_USERIDPara = this.DbFacade.CreateParameter();
            MODIFY_USERIDPara.ParameterName = "MODIFY_USERID";
            MODIFY_USERIDPara.DbType = DbType.String;
            MODIFY_USERIDPara.Value = MODIFY_USERID;
            parameters.Add(MODIFY_USERIDPara);

            DbParameter MODIFY_USERNAMEPara = this.DbFacade.CreateParameter();
            MODIFY_USERNAMEPara.ParameterName = "MODIFY_USERNAME";
            MODIFY_USERNAMEPara.DbType = DbType.String;
            MODIFY_USERNAMEPara.Value = MODIFY_USERNAME;
            parameters.Add(MODIFY_USERNAMEPara);

            int returnVal = base.DbFacade.SQLExecuteNonQuery(sql, parameters.ToArray());
            return returnVal;

        }

        /// <summary>
        /// 当订单明细表的订单状态变化之后调用该方法更新订单主表的订单状态
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="modifyUserId"></param>
        public void UpdateOrderState(String orderId, String modifyUserId)
        {
            // 得到订单明细的最大值
            string sql1 = "select max(i.state) from HC_ORD_ORDER_ITEM i where i.order_id=@orderId";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.Int64;
            orderIdPara.Value = orderId;
            parameters.Add(orderIdPara);

            int maxState = Int32.Parse((base.DbFacade.SQLExecuteScalar(sql1, parameters.ToArray())).ToString());

            // 得到订单明细的最小值
            string sql2 = "select min(i.state) from HC_ORD_ORDER_ITEM i where i.order_id=@orderId";
            int minState = Int32.Parse((base.DbFacade.SQLExecuteScalar(sql2, parameters.ToArray())).ToString());

            //得到订单明细状态为6缺货的记录总数
            //string sql3 = "select count(*) from HC_ORD_ORDER_ITEM i where i.order_id=@orderId and i.state = '6'";
            //int oosNum = Int32.Parse((base.DbFacade.SQLExecuteScalar(sql3, parameters.ToArray())).ToString());

            // 如果maxState=1发送，那么订单主表的订单状态为0准备
            if (maxState == 1)
            {
                UpdateOrderState(orderId, "0", modifyUserId);
            }
            // 如果maxState=2已阅读，那么订单主表的订单状态为1已阅读
            else if (maxState == 2)
            {
                UpdateOrderState(orderId, "3", modifyUserId);
            }
            // 如果minState>=5,并且oosNum=0,那么订单主表的订单状态为3完成
            else if (minState >= 4)
            {
                UpdateOrderState(orderId, "5", modifyUserId);
            }
            // 剩下的情况，订单主表的订单状态为2交易中
            else
            {
                UpdateOrderState(orderId, "4", modifyUserId);
            }
        }

        /// <summary>
        /// 改变订单主表的订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderState"></param>
        /// <param name="modifyUserId"></param>

        public void UpdateOrderState(String orderId, String orderState, String modifyUserId)
        {
            String sql = @" update HC_ORD_ORDER o set o.order_state=@orderState,
                      o.modify_user_id = @modifyUserId, o.modify_date = getdate(),o.sync_state='0' 
                      where o.order_id=@orderId";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter orderStatePara = this.DbFacade.CreateParameter();
            orderStatePara.ParameterName = "orderState";
            orderStatePara.DbType = DbType.String;
            orderStatePara.Value = orderState;
            parameters.Add(orderStatePara);

            DbParameter modifyUserIdPara = this.DbFacade.CreateParameter();
            modifyUserIdPara.ParameterName = "modifyUserId";
            modifyUserIdPara.DbType = DbType.Int64;
            modifyUserIdPara.Value = modifyUserId;
            parameters.Add(modifyUserIdPara);

            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.Int64;
            orderIdPara.Value = orderId;
            parameters.Add(orderIdPara);

            int returnVal = base.DbFacade.SQLExecuteNonQuery(sql, parameters.ToArray());
        }


        /// <summary>
        /// 根据订单id刷新订单主表的订购金额（因为有订单作废的情况）
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="modifyUserId"></param>
        public void UpdateRequestTotalByOrder(string orderId, string modifyUserId)
        {
            //String sql = @"select sum(i.request_qty * i.unit_price) as price from gpo_order_item i where i.order_id =:orderId";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.String;
            orderIdPara.Value = orderId;
            parameters.Add(orderIdPara);

            String sql = @"select  
                           (case when (sum(TRADE_PRICE * AMOUNT)) is null then 0 else sum(TRADE_PRICE * AMOUNT) end ) as total  
                           from HC_ORD_ORDER_ITEM  
                           where  order_id =@orderId";

            double total = double.Parse(base.DbFacade.SQLExecuteScalar(sql, parameters.ToArray()).ToString());

            sql = @"update HC_ORD_ORDER o
               set o.request_total = @total,
                   o.modify_userid =@modifyUserId,
                   o.modify_date   = getdate(),o.sync_state='0'
             where o.order_id = @orderId";

            DbParameter totalPara = this.DbFacade.CreateParameter();
            totalPara.ParameterName = "total";
            totalPara.DbType = DbType.Double;
            totalPara.Value = total;
            parameters.Add(totalPara);

            DbParameter modifyUserIdPara = this.DbFacade.CreateParameter();
            modifyUserIdPara.ParameterName = "modifyUserId";
            modifyUserIdPara.DbType = DbType.Int64;
            modifyUserIdPara.Value = modifyUserId;
            parameters.Add(modifyUserIdPara);

            int returnVal = base.DbFacade.SQLExecuteNonQuery(sql, parameters.ToArray());
        }

        /// <summary>
        /// 往订单明细表中增加一条与原订单明细相同的信息（订购量为原来的负值，order_type设为2 红冲）创建时间为原订单明细的时间
        /// </summary>
        /// <returns></returns>
        public long CopyGpoOrderItem(string orderItemId,int highId)
        {
            string sql = @"	insert into HC_ORD_ORDER_ITEM
		          (record_id,
		           purchase_item_id,
		           hit_comm_id,
		           order_id,
		           area_id,
		           buyer_orgid,
		           unit_price,
		           ready_flag,
		           request_qty,
		           con_id,
		           con_item_id,
		           project_id,
		           con_type,
		           repository_id,
		           repository_addr,
		           buyer_desc,
		           saler_desc,
		           degree_flag,
		           remark,
		           original_item_id,
		           parent_item_id,
		           item_status,
		           max_price,
		           ORDER_TYPE,
		           create_date,
		           modify_userid,
		           modify_date,
                   Sync_State)
		          select :newItemId,
		                 purchase_item_id,
		                 hit_comm_id,
		                 order_id,
		                 area_id,
		                 buyer_orgid,
		                 unit_price,
		                 ready_flag,
		                 -request_qty,
		                 con_id,
		                 con_item_id,
		                 project_id,
		                 con_type,
		                 repository_id,
		                 repository_addr,
		                 buyer_desc,
		                 saler_desc,
		                 degree_flag,
		                 remark,
		                 original_item_id,
		                 :orderItemId,
		                 item_status,
		                 max_price,
		                 '2',
		                 create_date,
		                 modify_userid,
		                 modify_date,'0'
		            from gpo_order_item i
		           where i.record_id =:orderItemId";


            long newItemId = this.GetClientId(highId);

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter newItemIdPara = this.DbFacade.CreateParameter();
            newItemIdPara.ParameterName = "newItemId";
            newItemIdPara.DbType = DbType.Int64;
            newItemIdPara.Value = newItemId;
            parameters.Add(newItemIdPara);

            DbParameter orderItemIdPara = this.DbFacade.CreateParameter();
            orderItemIdPara.ParameterName = "orderItemId";
            orderItemIdPara.DbType = DbType.Int64;
            orderItemIdPara.Value = orderItemId;
            parameters.Add(orderItemIdPara);

            int returnVal = base.DbFacade.SQLExecuteNonQuery(sql, parameters.ToArray());
            return newItemId;
        }

        /// <summary>
        /// 取得订单明细表的一条记录。
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public DataTable RetrieveByPK(string orderItemId)
        {
            string sql = @"SELECT ID,ORDER_ID
                           
                      FROM HC_ORD_ORDER_ITEM
                     WHERE ID = @orderItemId";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter orderItemIdPara = this.DbFacade.CreateParameter();
            orderItemIdPara.ParameterName = "orderItemId";
            orderItemIdPara.DbType = DbType.Int64;
            orderItemIdPara.Value = orderItemId;
            parameters.Add(orderItemIdPara);

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql, parameters.ToArray());
            table.TableName = "HC_ORD_ORDER_ITEM";
            DataSet ds = new DataSet();
            ds.Tables.Add(table);

            return table;
        }

        #endregion


    }
}
