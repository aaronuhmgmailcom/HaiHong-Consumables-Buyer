using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Model.User;
using System.Windows.Forms;
namespace Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder
{
    class BuyerOrderOfflineDAO : SqlDAOBase
    {
        private BuyerOrderOfflineDAO()
            : base()
        { }

        private BuyerOrderOfflineDAO(string connectionName)
            : base(connectionName)
        { }

        public static BuyerOrderOfflineDAO GetInstance()
        {
            return new BuyerOrderOfflineDAO();
        }

        public static BuyerOrderOfflineDAO GetInstance(string connectionName)
        {
            return new BuyerOrderOfflineDAO(connectionName);
        }

        /// <summary>
        /// 取得发票号数据
        /// </summary>
        public List<string> GetInvoiceNoList(BuyerOrderModel input)
        {
            List<string> invoiceNo = new List<string>();
            DataTable dt = SearchInvoiceNo(input);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                invoiceNo.Add(dt.Rows[i]["invoice_no"].ToString());
            }
            return invoiceNo;
        }

        /// <summary>
        /// 查询发票号
        /// </summary>
        public DataTable SearchInvoiceNo(BuyerOrderModel input)
        {
            DataTable dt = null;
            String sql = @"select distinct r.invoice_no
                          from gpo_order_receive r, gpo_order o
                         where r.order_id = o.order_id
                         and o.saler_id=:salerId
                         and r.invoice_no is not null";
            try
            {

                List<DbParameter> parameters = new List<DbParameter>();
                DbParameter salerIdPara = this.DbFacade.CreateParameter();
                salerIdPara.ParameterName = "salerId";
                salerIdPara.DbType = DbType.String;
                salerIdPara.Value = input.SalerId;
                parameters.Add(salerIdPara);

                dt = base.DbFacade.SQLExecuteDataTable(sql, parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        /// <summary>
        /// 取得未到货列表数据
        /// </summary>
        public DataSet GetNoArriveList(OrderModel input,BuyerOrderModel orderInput ,out int rows)
        {
            String tableName = "";
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            try
            {
                //原sql
                //sql.Append("Select h.Trade_Name, ");
                //sql.Append(" h.Medical_Name,h.Medical_Wubi,h.Medical_Pinyin,h.Spell_Abbr,h.Name_Wb,");
                //sql.Append(" iif(h.Spec is null,'-',h.spec) & '×' &  iif(h.Stand_Rate Is Null, '-',h.Stand_Rate) & iif(h.Use_Unit Is Null, '',h.Use_Unit) & '/' & iif(h.Spec_Unit Is Null, '',h.Spec_Unit) & Switch(h.Wrap_Name Is Null, '', h.Wrap_Name='空', '',True,'(' & h.Wrap_Name & ')') As Ggbz,");
                //sql.Append(" Switch(i.Unit_Price Is Null,'-', True,Trim(Format(i.Unit_Price, 'Standard'))) As Unit_Price,Cint(i.Request_Qty) As Request_Qty, i.Saler_Desc,i.Buyer_Desc, '已送货' As Status, h.Doseage_Form,");
                //sql.Append(" Switch(h.Province_Max_Price Is Null,'-',True,Trim(Format(h.Province_Max_Price, 'Standard'))) As Province_Max_Price,");
                //sql.Append(" Switch(h.Province_Insurance_Flag='0','非国家基本医疗保险产品',h.Province_Insurance_Flag='1', '甲类', h.Province_Insurance_Flag='2', '乙类', h.Province_Insurance_Flag='3', '民族药') As Province_Insurance_Flag,");
                //sql.Append(" h.Dealer_Fullname,");//经销企业
                //sql.Append(" l.Name,");           //合同名称
                //sql.Append(" h.Last_Order_Date,");//最后制单日期
                //sql.Append(" CInt(h.Last_Order_Qty) as Last_Order_Qty,"); //最后制单数量
                //sql.Append(" i.Record_Id,");
                //sql.Append(" i.Order_Id,");
                //sql.Append(" h.Product_Id,");
                //sql.Append(" s.Id As Stockup_Id,");
                //sql.Append(" i.Repository_Id,");
                //sql.Append(" Switch(i.Con_Type='1', '招标', i.Con_Type='2', '竞价', i.Con_Type='3', '询价', i.Con_Type='4', '备案', i.Con_Type='7', '浏览', i.Con_Type='9', '临时', i.Con_Type='c','GPO直销', i.Con_Type='d', 'GPO自主合同') as Con_Type,");
                //sql.Append(" s.Invoice_No,");
                //sql.Append(" format(s.amount,'Standard') As amount,");
                //sql.Append(" format(s.Trade_Price,'Standard') as trade_price,");
                //sql.Append(" format(s.Retail_Price,'Standard') as retail_price,");
                //sql.Append(" format(s.Discount, 'Standard') As Discount,");
                //sql.Append(" format(s.invoice_date, 'yyyy-mm-dd') as Invoice_Date,");
                //sql.Append(" format(s.Invoice_Expire_Date, 'yyyy-mm-dd') as Invoice_Expire_Date,");
                //sql.Append(" s.Remark As Stockup_Reamrk, ");
                //sql.Append(" s.Lot_No,");
                //sql.Append(" CInt(s.Stockup_Qty) As Receive_Qty");
                //sql.Append(" From Gpo_Order_Item i,");
                //sql.Append(" Gpo_Hit_Comm h,");
                //sql.Append(" Cont_List l,");

               
                //sql.Append(" gpo_order_stockup s ");
                //sql.Append(" where i.hit_comm_id = h.record_id");
                //sql.Append("   and h.contract_id = l.id");
                //sql.Append("   and s.order_item_id = i.record_id");


                sql.Append(" Select 0 as chk,h.id as Product_Id,h.MANU_NAME,h.MANU_NAME_ABBR, h.COMMERCE_NAME as ");
                sql.Append(" Trade_Name,h.product_name ,h.CODE, h.common_name,h.ABBR_PY,h.ABBR_WB,");

                sql.Append(" i.model AS HModel,(case when i.Spec is null then '-' else i.spec end) as HSpec ,");
                sql.Append(" i.Id, i.Order_Id, ");
                sql.Append(" (case when i.trade_Price Is Null then '-' else i.trade_Price end) As ");

                sql.Append(" trade_Price,");

                sql.Append("  i.buyer_Id,i.buyer_Name,i.buyer_Name_Abbr,i.saler_Id,i.saler_Name,i.saler_Name_Abbr,i.sender_Id ");
                sql.Append("  ,i.sender_Name,i.sender_Name_Abbr,i.MANUFACTURE_ID,i.MANUFACTURE_NAME,i.MANUFACTURE_NAME_ABBR ");
                sql.Append("    ,i.product_Name,i.product_Code,i.spec_id,i.model_id,i.spec,i.model,i.common_Name ");
                sql.Append("    ,i.brand,i.base_Measure_Spec,i.base_Measure_Mater,i.base_Measure,(case when i.Send_measure is null then '-' else i.Send_measure end ) as Send_measure,i.send_measure_ex, ");

                sql.Append(" (case i.STATE when '1' then '发送' when  '2' then '已阅读' when '3' then '作废' when '4' then '已确认' when '5' then '完成'   end) As status, ");
                sql.Append(" (case when i.RETAIL_PRICE Is Null then '-' else i.RETAIL_PRICE end) ");
                sql.Append(" As RETAIL_PRICE,i.SUM AS total,");
                sql.Append(" cast(i.AMOUNT as int) As Request_Qty, i.SALER_DESCRIPTIONS as Saler_Desc,");
                sql.Append(" i.BUYER_DESCRIPTIONS as Buyer_Desc, '已送货' As Status,");
                sql.Append(" cast(i.OVER_AMOUNT as int) as OVER_AMOUNT,");
                sql.Append(" cast(i.OVER_SUM as int) as OVER_SUM,");

                sql.Append(" s.Id As Stockup_Id, i.STORE_ROOM_ID, ");

                sql.Append(" s.PBNO , s.SEND_BATCH_NO,s.INSTORE_BATCH_NO ,'' as Lot_No, ");

                sql.Append(" s.project_id,i.PROJECT_PROD_ID,STORE_ROOM_ID,STORE_ROOM_name,   ");

                sql.Append(" cast(s.Stockup_Qty as int) As Receive_Qty ");

                sql.Append(" From HC_ORD_ORDER_ITEM i, ");

                sql.Append(" HC_ORD_PRODUCT h , HC_ORD_ORDER_STOCKUP s  where i.PROJECT_PROD_ID = ");

                sql.Append(" h.id  and s.order_item_id = i.id  ");

               
                List<DbParameter> parameters = new List<DbParameter>();

                sql.Append("  and i.Order_Id = @orderId ");
                DbParameter IdPara = base.DbFacade.CreateParameter();
                IdPara.ParameterName = "orderId";
                IdPara.DbType = DbType.Int64;
                IdPara.Value = Convert.ToInt64(input.Id);
                parameters.Add(IdPara);
                tableName = "NoArriveByOrder";
                

                sql.Append("   and i.state = '4' ");//--已确认
                sql.Append("   and s.READY_FLAG = '1' ");//--已确认

                rows = 0;

                DataTable tb = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());

                ds.Tables.Add(tb);

            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }

        public void DoAutoReceiveItem(LogedInUser user,string days)
        {
            BuyerOrderModel input=new BuyerOrderModel();
            DataSet ds;
            ds = GetAutoReceiveList(days);
            try
            {
                

                input = new BuyerOrderModel();
                input.UserId = user.UserInfo.Id;
                input.UserName = user.UserInfo.Name;
                input.SalerId = user.UserOrg.Id;
                input.AreaId = user.UserInfo.Region_id;
                //?input.OrderId = orderModel.Id;
                
                input.HighId = ClientSession.GetInstance().CurrentUser.HighId; ;
            

                int rowCount = 0;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    OrderItemModel item = new OrderItemModel();
                    item.StockupId = row["Stockup_Id"].ToString();
                    item.RequestQty = row["Request_Qty"].ToString();
                    item.LotNo = row["Lot_No"].ToString();
                    item.ReceiveQty = row["Receive_Qty"].ToString();
                    item.Order_item_id = row["id"].ToString();
                    item.ProductId = row["Product_Id"].ToString();
                    item.OrderId = row["Order_Id"].ToString();

                    item.RetailPrice = row["RETAIL_PRICE"].ToString();
                    item.TradePrice = row["trade_Price"].ToString();
                    item.Project_id = row["project_id"].ToString();
                    item.Project_product_id = row["project_prod_id"].ToString();
                    item.Pbno = row["pbno"].ToString();
                    item.Send_batch_no = row["send_batch_no"].ToString();
                    item.Store_room_id = row["store_room_id"].ToString();
                    item.Store_room_name = row["store_room_name"].ToString();


                    item.BuyerId = row["buyer_Id"].ToString();
                    item.BuyerName = row["buyer_Name"].ToString();
                    item.BuyerNameAbbr = row["buyer_Name_Abbr"].ToString();
                    item.SalerId = row["saler_Id"].ToString();
                    item.SalerName = row["saler_Name"].ToString();
                    item.SalerNameAbbr = row["saler_Name_Abbr"].ToString();
                    item.SenderId = row["sender_Id"].ToString();
                    item.SenderName = row["sender_Name"].ToString();
                    item.SenderNameAbbr = row["sender_Name_Abbr"].ToString();
                    item.ManuId = row["MANUFACTURE_ID"].ToString();
                    item.ManuName = row["MANUFACTURE_NAME"].ToString();
                    item.ManuNameAbbr = row["MANUFACTURE_NAME_ABBR"].ToString();

                    item.ProductName = row["product_Name"].ToString();
                    item.ProductCode = row["product_Code"].ToString();
                    item.Spec_id = row["spec_id"].ToString();
                    item.Model_id = row["model_id"].ToString();
                    item.Spec = row["spec"].ToString();
                    item.Model = row["model"].ToString();
                    item.CommonName = row["common_Name"].ToString();
                    item.Brand = row["brand"].ToString();
                    item.BaseMeasureSpec = row["base_Measure_Spec"].ToString();
                    item.BaseMeasureMater = row["base_Measure_Mater"].ToString();
                    item.BaseMeasure = row["base_Measure"].ToString();
                    item.Send_measure_ex = row["send_measure_ex"].ToString();
                    item.Send_measure = row["send_measure"].ToString();


                    item.ProductId = row["PROJECT_PROD_ID"].ToString();

                    item.RetailPrice = row["RETAIL_PRICE"].ToString();
                    item.Project_id = row["project_id"].ToString();
                    item.Project_product_id = row["PROJECT_PROD_ID"].ToString();
                    item.Pbno = row["Pbno"].ToString();
                    item.Send_batch_no = row["Send_batch_no"].ToString();
                    item.Store_room_id = row["store_room_id"].ToString();
                    item.Store_room_name = row["store_room_name"].ToString();


                    input.List.Add(item);

                }

                ArrivedAllConfirm(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
   
        }
        //自动到货，做全部到货
        public void ArrivedAllConfirm(BuyerOrderModel input)
        {
            //要插入到到货表的订单明细id
            String receiveItemId = "";
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    for (int i = 0; i < input.List.Count; i++)
                    {
                        OrderItemModel item = input.List[i];
                        String orderItemId = item.Order_item_id;
                        input.OrderRecordId = orderItemId;
                        //全部到货
                        if (!SearchOrderState(input).Equals("5"))
                        {
                            input.ItemState = "5";
                            input.OrderType = "1";
                            UpdateOrderItemData(input, transaction);
                            receiveItemId = orderItemId;
                        }
                        
                        input.OrderRecordId = receiveItemId;
                        AddGpoOrderReceive(input, item, transaction);
                        AddOrderResult(input, item, transaction);

                        UpdateOrderState(input, item.OrderId, transaction);
                    }
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
           
        }

        /// <summary>
        /// 取得自动到货列表数据
        /// </summary>
        public DataSet GetAutoReceiveList(string days)
        {
            String tableName = "";
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append(" Select 0 as chk,h.id as Product_Id,h.MANU_NAME,h.MANU_NAME_ABBR, h.COMMERCE_NAME as ");
                sql.Append(" Trade_Name,h.product_name ,h.CODE, h.common_name,h.ABBR_PY,h.ABBR_WB,");

                sql.Append(" h.model,(case when h.Spec is null then '-' else h.spec end) as Spec ,");
                sql.Append(" i.Id, i.Order_Id, ");
                sql.Append(" (case when i.trade_Price Is Null then '-' else i.trade_Price end) As ");

                sql.Append(" trade_Price,");

                sql.Append("  i.buyer_Id,i.buyer_Name,i.buyer_Name_Abbr,i.saler_Id,i.saler_Name,i.saler_Name_Abbr,i.sender_Id ");
                sql.Append("  ,i.sender_Name,i.sender_Name_Abbr,i.MANUFACTURE_ID,i.MANUFACTURE_NAME,i.MANUFACTURE_NAME_ABBR ");
                sql.Append("    ,i.product_Name,i.product_Code,i.spec_id,i.model_id,i.spec,i.model,i.common_Name ");
                sql.Append("    ,i.brand,i.base_Measure_Spec,i.base_Measure_Mater,i.base_Measure,i.Send_measure,i.send_measure_ex, ");

                sql.Append(" (case i.STATE when '1' then '发送' when  '2' then '已阅读' when '3' then '作废' when '4' then '已确认' when '5' then '完成'   end) As status, ");
                sql.Append(" (case when i.RETAIL_PRICE Is Null then '-' else i.RETAIL_PRICE end) ");
                sql.Append(" As RETAIL_PRICE,i.SUM AS total,");
                sql.Append(" cast(i.AMOUNT as int) As Request_Qty, i.SALER_DESCRIPTIONS as Saler_Desc,");
                sql.Append(" i.BUYER_DESCRIPTIONS as Buyer_Desc, '已送货' As Status,");
                sql.Append(" cast(i.OVER_AMOUNT as int) as OVER_AMOUNT,");
                sql.Append(" cast(i.OVER_SUM as int) as OVER_SUM,");

                sql.Append(" s.Id As Stockup_Id, i.STORE_ROOM_ID, ");

                sql.Append(" s.PBNO , s.SEND_BATCH_NO,s.INSTORE_BATCH_NO ,'LotNo' as Lot_No, ");

                sql.Append(" s.project_id,i.PROJECT_PROD_ID,STORE_ROOM_ID,STORE_ROOM_name,   ");

                sql.Append(" cast(s.Stockup_Qty as int) As Receive_Qty ");

                sql.Append(" From HC_ORD_ORDER_ITEM i, ");

                sql.Append(" HC_ORD_PRODUCT h , HC_ORD_ORDER_STOCKUP s  where i.PROJECT_PROD_ID = ");

                sql.Append(" h.id  and s.order_item_id = i.id  ");


                List<DbParameter> parameters = new List<DbParameter>();


                sql.Append("   and i.state = '3' ");//--已确认
                sql.Append("   and s.READY_FLAG = '1' ");//--已确认
                days = "-" + days;
                if (!string.IsNullOrEmpty(days))
                {
                    sql.Append(" and s.create_date < '" + DateTime.Now.AddDays(double.Parse(days)) + "'");
                }
                else
                {
                    sql.Append(" and 1=2");
                }

                DataTable tb = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());

                ds.Tables.Add(tb);

            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }


        /// <summary>
        /// 查询发票号
        /// </summary>
        public DataTable SearchInvoiceNoByOrderId(BuyerOrderModel input)
        {

            DataTable dt = null;
            String sql = @"select distinct r.invoice_no
                          from gpo_order_receive r, gpo_order o
                         where r.order_id = o.order_id
                         and o.saler_id=(select saler_id from gpo_order where order_id = :order_id)
                         and r.invoice_no is not null";
            try
            {
                DbParameter Para = this.DbFacade.CreateParameter();
                Para.ParameterName = "order_id";
                Para.DbType = DbType.String;
                Para.Value = input.OrderId;

                dt = base.DbFacade.SQLExecuteDataTable(sql, Para);
            }
            catch (Exception e)
            {

                throw e;
            }
            return dt;
        }

        /// <summary>
        /// 取到货金额
        /// </summary>
        public String GetReceiveTotalByOrder(BuyerOrderModel input)
        {

            StringBuilder sql = new StringBuilder();
            String temp = string.Empty;
            try
            {
                //shejg 2007-05-22 修改：原来没有对取出来的数据求和，造成有多笔数据时，用户界面显示不正确。增加sum()
                sql.Append("select format(sum(i.unit_price * r.receive_qty),'Standard') as receive_total");
                sql.Append("  from gpo_order_item i, gpo_order_receive r");
                sql.Append(" where i.record_id = r.order_item_id");
                sql.Append("   and i.order_id = :id");

                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.String;
                idPara.Value = input.OrderId;

                DataTable table = base.DbFacade.SQLExecuteDataTable(sql.ToString(), idPara);
                if (table.Rows.Count > 0)
                    temp = table.Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            return temp;
        }

        /// <summary>
        /// 取订单状态
        /// </summary>
        public string GetOrderState(BuyerOrderModel input)
        {

            StringBuilder sql = new StringBuilder();
            string state;
            try
            {
                sql.Append("select Switch(o.order_state='0','发送',o.order_state='1','已阅读',o.order_state='2','交易中',o.order_state='3','完成') As order_state");
                sql.Append(" from gpo_order o");
                sql.Append(" where o.order_id = :id");
                //sql.Append(input.OrderId).Append("' ");

                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.String;
                idPara.Value = input.OrderId;

                state = base.DbFacade.SQLExecuteScalar(sql.ToString(), idPara).ToString();

            }
            catch (Exception e)
            {
                throw e;
            }
            return state;
        }

        /// <summary>
        /// 保存备注
        /// </summary>
        public bool SaveRemark(BuyerOrderModel input)
        {
            String sql;
            bool result = false;
            sql = "update hc_ord_order set BUYER_DESCRIPTIONS = @remark, modify_user_id = @userId, Sync_State = '0', modify_date = getdate() where id = @orderId";
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    List<DbParameter> parameters = new List<DbParameter>();
                    DbParameter remarkPara = this.DbFacade.CreateParameter();
                    remarkPara.ParameterName = "remark";
                    remarkPara.DbType = DbType.String;
                    remarkPara.Value = input.Remark;
                    parameters.Add(remarkPara);

                    DbParameter userIdPara = this.DbFacade.CreateParameter();
                    userIdPara.ParameterName = "userId";
                    userIdPara.DbType = DbType.String;
                    userIdPara.Value = input.UserId;
                    parameters.Add(userIdPara);

                    DbParameter orderIdPara = this.DbFacade.CreateParameter();
                    orderIdPara.ParameterName = "orderId";
                    orderIdPara.DbType = DbType.String;
                    orderIdPara.Value = input.OrderId;
                    parameters.Add(orderIdPara);

                    base.DbFacade.SQLExecuteNonQuery(sql, parameters.ToArray());
                    result = true;
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            return result;
        }

        /// <summary>
        /// 订单明细完成
        /// </summary>
        public void CompleteOrderItem(BuyerOrderModel input)
        {
            List<String> al = new List<String>();
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    for (int i = 0; i < input.List.Count; i++)
                    {
                        OrderItemModel item = input.List[i];
                        //从备货表中得到订单明细id(直接取orderItemId,此方法取消)
                        //String orderItemId = GetOrderItemIdByStock(item.StockupId, transaction);

                        String orderItemId = item.Order_item_id;
                        //(1)把订单明细表的state设为5完成
                        UpdateItemStatus(orderItemId,item, transaction);
                        //增加订单明细日志表20071105
                        AddOrderItemLog(orderItemId, transaction);
                        //(2)订单到货表插入数据
                        AddGpoOrderReceive(input, item, transaction);
                        //(3)订单结果表插入数据
                        AddOrderResult(input, item, transaction);

                        al.Add(orderItemId);
                        //往订单状态表中插入一条记录
                        //AddGpoItemStatus(input, orderItemId, "7", transaction);
                    }

                    //更新订单主表的状态
                    //1.如果按订单到货，更新该订单主表的订单状态
                    
                        UpdateOrderState(input, input.OrderId, transaction);
                        string overSum = GetOrderOverSum(input.OrderId, transaction);
                        UpdateOrderSum(overSum, input.OrderId, transaction);
                        //增加订单日志表20071105
                        AddOrderLog(input, transaction);
                    
                    //2.如果按企业到货，更新所涉及的所有订单主表的订单状态
                    //else if ("2".Equals(input.Flag))
                    //{
                    //    DataTable orderIds = GetOrderIds(input, (String[])al.ToArray(), transaction);
                    //    foreach (DataRow dr in orderIds.Rows)
                    //    {
                    //        UpdateOrderState(input, dr[0].ToString(), transaction);
                    //    }
                    //}
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }


        /// <summary>
        /// 关闭订单
        /// </summary>
        public void CloseOrderItem(BuyerOrderModel input)
        {
            List<String> al = new List<String>();
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    for (int i = 0; i < input.List.Count; i++)
                    {
                        OrderItemModel item = input.List[i];
                      
                        String orderItemId = item.Order_item_id;
                        //(1)把订单明细表的state设为5完成
                        UpdateCloseItemStatus(orderItemId, item, transaction);
                        //增加订单明细日志表20071105
                        AddOrderItemLog(orderItemId, transaction);
                        //(2)订单结果表插入数据
                        AddOrderResult(input, item, transaction);
                        al.Add(orderItemId);
                    }

                    //更新订单主表的状态
                    UpdateOrderState(input, input.OrderId, transaction);
                    //增加订单日志表20071105
                    AddOrderLog(input, transaction);

                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        /// <summary>
        /// 从备货表中得到订单明细id
        /// </summary>
        public String GetOrderItemIdByStock(String stockupId, DbTransaction transaction)
        {

            String sql = "select order_item_id from HC_ORD_ORDER_STOCKUP where id=@id ";
            String temp;
            try
            {
                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = stockupId;

                DataTable table = base.DbFacade.SQLExecuteDataTable(sql, transaction, idPara);
                temp = table.Rows[0][0].ToString();
            }
            catch (Exception e)
            {

                throw e;
            }
            return temp;
        }

        /// <summary>
        ///  根据订单明细id返回订单id(去掉重复记录)
        /// </summary>
        public DataTable GetOrderIds(BuyerOrderModel input, String[] orderItemId, DbTransaction transaction)
        {

            StringBuilder sql = new StringBuilder("select distinct order_id from gpo_order_item where record_id in ( ");
            DataTable dt;
            try
            {
                for (int i = 0; i < orderItemId.Length; i++)
                {
                    sql.Append("'").Append(orderItemId[i]).Append("'");
                    if (i != orderItemId.Length - 1)
                    {
                        sql.Append(",");
                    }
                }
                sql.Append(")");
                dt = this.DbFacade.SQLQueryForDataTable(sql.ToString(), transaction, "OrderIds", null);
            }
            catch (Exception e)
            {

                throw e;
            }
            return dt;
        }

        /// <summary>
        /// 改变订单主表的订单金额
        /// </summary>
        public bool UpdateOrderSum(string sum, String orderId, DbTransaction transaction)
        {
            bool result = false;
            String sql = "update HC_ORD_ORDER  set OVER_SUM= @sum,Sync_State = '0' where id=@id ";
            try
            {

                List<DbParameter> parameters = new List<DbParameter>();

                DbParameter userIdPara = this.DbFacade.CreateParameter();
                userIdPara.ParameterName = "sum";
                userIdPara.DbType = DbType.String;
                userIdPara.Value = sum;
                parameters.Add(userIdPara);

                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = orderId;
                parameters.Add(idPara);

                base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
                result = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return result;
        }

        /// <summary>
        /// 改变订单主表的订单状态
        /// </summary>
        public bool UpdateOrderState(BuyerOrderModel input, String orderId, String status, DbTransaction transaction)
        {
            bool result = false;
            String sql = "update HC_ORD_ORDER  set state= @state, modify_user_id = @userId,modify_date = getdate(),Sync_State = '0' where id=@id ";
            try
            {

                List<DbParameter> parameters = new List<DbParameter>();
                DbParameter statePara = this.DbFacade.CreateParameter();
                statePara.ParameterName = "state";
                statePara.DbType = DbType.String;
                statePara.Value = status;
                parameters.Add(statePara);

                DbParameter userIdPara = this.DbFacade.CreateParameter();
                userIdPara.ParameterName = "userId";
                userIdPara.DbType = DbType.Int64;
                userIdPara.Value = input.UserId;
                parameters.Add(userIdPara);

                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = orderId;
                parameters.Add(idPara);

                base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
                result = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return result;
        }

        /// <summary>
        /// 把订单明细表的state设为5完成,订单类型为1,到货
        /// </summary>
        public bool UpdateItemStatus(String id, OrderItemModel model,DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_ITEM set OVER_AMOUNT=@OVER_AMOUNT,OVER_SUM=TRADE_PRICE * @OVER_AMOUNT ,Sync_State = '0',state = '5',ORDER_TYPE = '1' where id=@id ";

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.String;
            idPara.Value = id;
            parameters.Add(idPara);

            DbParameter userIdPara = this.DbFacade.CreateParameter();
            userIdPara.ParameterName = "OVER_AMOUNT";
            userIdPara.DbType = DbType.Int64;
            userIdPara.Value = model.ReceiveQty;
            parameters.Add(userIdPara);


            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;


            return result;
        }

        /// <summary>
        /// 把订单明细表的state设为5完成,关闭订单
        /// </summary>
        public bool UpdateCloseItemStatus(String id, OrderItemModel model, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_ITEM set  Sync_State = '0',state = '5' where id=@id ";

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.String;
            idPara.Value = id;
            parameters.Add(idPara);

            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;

            return result;
        }

        /// <summary>
        /// 往订单状态表中插入一条记录
        /// </summary>
        public bool AddGpoItemStatus(BuyerOrderModel input, String itemId, String state, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;
            sql.Append("insert into gpo_item_status");
            sql.Append("(id,Sync_State,record_id,order_item_state,modify_userid,modify_username,modify_date)values(");
            sql.Append(":id,'0',:recordId,:orderItemState,:userId,:userName,now())");

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.String;
            idPara.Value = base.GetGlobalId();
            parameters.Add(idPara);

            DbParameter recordIdPara = this.DbFacade.CreateParameter();
            recordIdPara.ParameterName = "recordId";
            recordIdPara.DbType = DbType.String;
            recordIdPara.Value = itemId;
            parameters.Add(recordIdPara);

            DbParameter statePara = this.DbFacade.CreateParameter();
            statePara.ParameterName = "orderItemState";
            statePara.DbType = DbType.String;
            statePara.Value = state;
            parameters.Add(statePara);

            DbParameter userIdPara = this.DbFacade.CreateParameter();
            userIdPara.ParameterName = "userId";
            userIdPara.DbType = DbType.String;
            userIdPara.Value = input.UserId;
            parameters.Add(userIdPara);

            DbParameter userNamePara = this.DbFacade.CreateParameter();
            userNamePara.ParameterName = "userName";
            userNamePara.DbType = DbType.String;
            userNamePara.Value = input.UserName;
            parameters.Add(userNamePara);

            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());
            result = true;

            return result;
        }


        /// <summary>
        /// 往订单日志表中插入一条记录20071105
        /// </summary>
        public bool AddOrderLog(BuyerOrderModel input,  DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;
            sql.Append("insert into HC_ORD_ORDER_LOG");
            sql.Append("(id ");
            sql.Append(",ORDER_CODE,PURCHASE_ID,");   
            sql.Append("BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,");
            //sql.Append("SALER_ID,SALER_NAME,SALER_NAME_ABBR,");
            sql.Append("SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,");
            //sql.Append("MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR,");
            sql.Append("TOTAL_SUM,OVER_SUM,SALER_APPROVER_ID,");
            sql.Append("SALER_APPROVER_NAME,SALER_APPROVER_DATE,");
            sql.Append("STATE,TYPE,PURCHASE_DATE,QUICKSEND_LEVEL,");
            sql.Append("SALER_DESCRIPTIONS,BUYER_DESCRIPTIONS,");
            sql.Append("CREATE_USER_NAME,CREATE_DATE,CREATE_USER_ID,");
            sql.Append("MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,");
            sql.Append("OPERATOR_USER_ID,OPERATOR_USER_NAME,OPERATOR_DATE,sync_state");
                
            sql.Append(")select");
            sql.Append(" id,");
            //sql.Append(" @PROJECTID,");
            sql.Append(" ORDER_CODE,");
            sql.Append(" PURCHASE_ID,");
            sql.Append(" BUYER_ID,");
            sql.Append(" BUYER_NAME,");
            sql.Append(" BUYER_NAME_ABBR,");
            sql.Append(" SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,");
            //sql.Append("SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,");
            sql.Append("TOTAL_SUM,OVER_SUM,SALER_APPROVER_ID,");
            sql.Append("SALER_APPROVER_NAME,SALER_APPROVER_DATE,");
            sql.Append("STATE,TYPE,PURCHASE_DATE,QUICKSEND_LEVEL,");
            sql.Append("SALER_DESCRIPTIONS,BUYER_DESCRIPTIONS,");
            sql.Append("CREATE_USER_NAME,CREATE_DATE,CREATE_USER_ID,");
            sql.Append("MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,0 from HC_ORD_ORDER where id=@id");


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter newIdPara = this.DbFacade.CreateParameter();
            newIdPara.ParameterName = "id";
            newIdPara.DbType = DbType.Int64;
            newIdPara.Value = input.OrderId;
            parameters.Add(newIdPara);

            //DbParameter userNamePara = this.DbFacade.CreateParameter();
            //userNamePara.ParameterName = "PROJECTID";
            //userNamePara.DbType = DbType.Int64;
            //userNamePara.Value = input.ProjectId;
            //parameters.Add(userNamePara);

            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());
            result = true;

            return result;
        }

        /// <summary>
        /// 往订单明细日志表中插入一条记录20071105
        /// </summary>
        public bool AddOrderItemLog(string OrderItemID, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;
            sql.Append("insert into HC_ORD_ORDER_ITEM_LOG");
            sql.Append("(id ");
            sql.Append(",PROJECT_ID,ORDER_ID,");
            sql.Append("PURCHASE_ID,PURCHASE_ITEM_ID,DATA_PRODUCT_ID,PROJECT_PROD_ID,");
            sql.Append("BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,");
            sql.Append("SALER_ID,SALER_NAME,SALER_NAME_ABBR,");
            sql.Append("SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,");
            sql.Append("MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR,");

            sql.Append("COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE,");
            sql.Append("SPEC_ID,MODEL_ID,SPEC,MODEL,");
            sql.Append("BRAND,GOODS_NO,BARCODE,STORE_ROOM_ID,");
            sql.Append("STORE_ROOM_NAME,STORE_ROOM_ADDRESS,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,");
            sql.Append("BASE_MEASURE,SEND_MEASURE,SEND_MEASURE_EX,RETAIL_PRICE,");
            sql.Append("TRADE_PRICE,SUM,AMOUNT,OVER_AMOUNT,");
            sql.Append("OVER_SUM,IS_QUICKSEND,ORDER_TYPE,STATE,");
            sql.Append("BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,");
            sql.Append("BALANCE_WUBI,BUYER_DESCRIPTIONS,SALER_DESCRIPTIONS,CREATE_USER_ID,");
            sql.Append("CREATE_USER_NAME,CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,");
            sql.Append("MODIFY_DATE,OPERATOR_USER_ID,OPERATOR_USER_NAME,OPERATOR_DATE,");
            sql.Append("ORIGINAL_ITEM_ID,PARENT_ITEM_ID,SYNC_STATE");

            sql.Append(")select");
            sql.Append(" id");

            sql.Append(",PROJECT_ID,ORDER_ID,");
            sql.Append(" ");
            sql.Append("PURCHASE_ID,PURCHASE_ITEM_ID,DATA_PRODUCT_ID,PROJECT_PROD_ID,");
            sql.Append(" BUYER_ID,");
            sql.Append(" BUYER_NAME,");
            sql.Append(" BUYER_NAME_ABBR,");
            sql.Append("SALER_ID,SALER_NAME,SALER_NAME_ABBR,");
            sql.Append(" SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,");
            sql.Append("MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR,");
            sql.Append("COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE,");
            sql.Append("SPEC_ID,MODEL_ID,SPEC,MODEL,");
            sql.Append("BRAND,GOODS_NO,BARCODE,STORE_ROOM_ID,");
            sql.Append("STORE_ROOM_NAME,STORE_ROOM_ADDRESS,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,");
            sql.Append("BASE_MEASURE,SEND_MEASURE,SEND_MEASURE_EX,RETAIL_PRICE,");
            sql.Append("TRADE_PRICE,SUM,AMOUNT,OVER_AMOUNT,");
            sql.Append("OVER_SUM,IS_QUICKSEND,ORDER_TYPE,STATE,");
            sql.Append("BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,");
            sql.Append("BALANCE_WUBI,BUYER_DESCRIPTIONS,SALER_DESCRIPTIONS,CREATE_USER_ID,");
            sql.Append("CREATE_USER_NAME,CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,");
            sql.Append("MODIFY_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,");

            sql.Append("ORIGINAL_ITEM_ID,PARENT_ITEM_ID,0 from HC_ORD_ORDER_ITEM where id=@id");


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter newIdPara = this.DbFacade.CreateParameter();
            newIdPara.ParameterName = "id";
            newIdPara.DbType = DbType.Int64;
            newIdPara.Value = OrderItemID;
            parameters.Add(newIdPara);


            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());
            result = true;

            return result;
        }

        
        /// <summary>
        /// 往备货单日志表中插入一条记录20071105
        /// </summary>
        public bool AddOrderStockUpLog(string id, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;
            sql.Append("insert into HC_ORD_ORDER_STOCKUP_LOG");
            sql.Append("(id ");
            sql.Append(",DATA_PRODUCT_ID,PROJECT_ID,ORDER_ID");
            sql.Append(",ORDER_ITEM_ID,PROJECT_PROD_ID,STOCKUP_QTY");
            sql.Append(",READY_FLAG,GOODS_NO,BARCODE");
            sql.Append(",PBNO,SEND_BATCH_NO,INSTORE_BATCH_NO");
            sql.Append(",CREATE_USER_ID,CREATE_USER_NAME,CREATE_DATE");
            sql.Append(",MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE");


            sql.Append(",OPERATOR_USER_ID,OPERATOR_USER_NAME,OPERATOR_DATE,SYNC_STATE");

            sql.Append(")select");
            sql.Append(" id");

            sql.Append(",DATA_PRODUCT_ID,PROJECT_ID,ORDER_ID");
            sql.Append(",ORDER_ITEM_ID,PROJECT_PROD_ID,STOCKUP_QTY");
            sql.Append(",READY_FLAG,GOODS_NO,BARCODE");
            sql.Append(",PBNO,SEND_BATCH_NO,INSTORE_BATCH_NO");
            sql.Append(",CREATE_USER_ID,CREATE_USER_NAME,CREATE_DATE");
            sql.Append(",MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE");


            sql.Append(",MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,");

            sql.Append("0 from HC_ORD_ORDER_STOCKUP where id=@id");


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter newIdPara = this.DbFacade.CreateParameter();
            newIdPara.ParameterName = "id";
            newIdPara.DbType = DbType.Int64;
            newIdPara.Value = id;
            parameters.Add(newIdPara);


            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());
            result = true;

            return result;
        }
        

        /// <summary>
        /// 当订单明细表的订单状态变化之后调用该方法更新订单主表的订单状态
        /// </summary>
        public void UpdateOrderState(BuyerOrderModel input, String orderId, DbTransaction transaction)
        {
            int maxState = int.Parse(GetOrderItemMaxStatus(orderId, transaction));
            int minState = int.Parse(GetOrderItemMinStatus(orderId, transaction));
            //int oosNum = int.Parse(GetOrderItemCount(orderId));
            try
            {
                //如果maxState=1发送，那么订单主表的订单状态为1未阅读
                if (maxState == 1)
                {
                    UpdateOrderState(input, orderId, "1", transaction);
                }
                // 如果maxState=2已阅读，那么订单主表的订单状态为2已阅读
                else if (maxState == 2)
                {
                    UpdateOrderState(input, orderId, "2", transaction);
                }
                // 如果minState>=5,那么订单主表的订单状态为5完成
                else if (minState >= 5)
                {
                    UpdateOrderState(input, orderId, "5", transaction);
                }
                // 剩下的情况，订单主表的订单状态为4交易中
                else
                {
                    UpdateOrderState(input, orderId, "4", transaction);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        /// <summary>
        /// 订单关闭-将订单表设置为完成
        /// </summary>
        public void UpdateCloseOrderState(BuyerOrderModel input, String orderId, DbTransaction transaction)
        {
            try
            {
                //订单主表的订单状态为5完成
                UpdateOrderState(input, orderId, "5", transaction);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        ///  得到订单明细的状态最大值
        /// </summary>
        public String GetOrderItemMaxStatus(String id,DbTransaction transaction)
        {

            String sql = "select max(STATE) as num from HC_ORD_ORDER_ITEM  where order_id=@id ";


            DbParameter idPara = base.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = id;

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql, transaction, idPara);

            String temp = table.Rows[0][0].ToString();
            return temp;
        }


        /// <summary>
        ///  得到订单明细的状态最小值
        /// </summary>
        public String GetOrderItemMinStatus(String id, DbTransaction transaction)
        {

            String sql = "select min(STATE) from HC_ORD_ORDER_ITEM  where order_id=@id ";


            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.String;
            idPara.Value = id;

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql, transaction, idPara);
            String temp = table.Rows[0][0].ToString();
            return temp;
        }

        ///  得到订单明细状态为6缺货的记录总数
        /// </summary>
        public String GetOrderItemCount(String id)
        {

            String sql = "select count(*) from HC_ORD_ORDER_ITEM i where i.order_id=:id and  i.item_status = '6' ";


            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.String;
            idPara.Value = id;

            DataTable table = base.DbFacade.SQLExecuteDataTable(sql, idPara);
            String temp = table.Rows[0][0].ToString();
            return temp;
        }


        #region 到货确认
        /// <summary>
        /// 到货确认
        /// </summary>
        public void ArrivedConfirm(BuyerOrderModel input)
        {
            //要插入到到货表的订单明细id
            String receiveItemId = "";
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    for (int i = 0; i < input.List.Count; i++)
                    {
                        OrderItemModel item = input.List[i];
                        //从备货表中得到订单明细id
                        //String orderItemId = GetOrderItemIdByStock(item.StockupId, transaction);
                        String orderItemId = item.Order_item_id;

                        input.OrderRecordId = orderItemId;
                        //input.ProjectId = item.Project_id; 
                        //订购量
                        double requestQty = double.Parse(GetOrderItemRequestQty(orderItemId, transaction));
                        //到货量
                        double receiveQty = double.Parse(item.ReceiveQty);

                        //1.如果到货量大于等于订购量
                        if (requestQty <= receiveQty)
                        {
                            if (!SearchOrderState(input).Equals("5"))
                            {
                                input.ItemState = "5";
                                input.OrderType = "1";
                                UpdateOrderItemData3(input, receiveQty,transaction);
                                receiveItemId = orderItemId;
                                //AddGpoItemStatus(input, orderItemId, "4", transaction);
                                //增加订单明细日志表20071105
                                AddOrderItemLog(input.OrderRecordId, transaction);
                            }
                        }
                        //2、如果到货量小于定购量
                        if (requestQty > receiveQty)
                        {
                            //(1)把原订单明细表的state设为5完成（order_type设为0兰票），
                            input.ItemState = "5";
                            input.OrderType = "0";
                            UpdateOrderItemData(input, transaction);

                            //增加订单明细日志表20071105
                            AddOrderItemLog(input.OrderRecordId, transaction);
                            //AddGpoItemStatus(input, orderItemId, "7", transaction);

                            //(2)往订单明细表中增加一条与原订单明细相同的信息（订购量为原来的负值，order_type设为2红冲）创建时间为原订单明细的时间
                            String newItemId1 = CopyGpoOrderItem(orderItemId,input.HighId, transaction);
                            
                            DataRow dr = GetOrderItemRow(orderItemId, transaction);
                            String state = dr["state"].ToString();
                            input.RequestQty = "-" + item.RequestQty;
                            input.OrderType = "2";
                            UpdateOrderItemData1(input, newItemId1, transaction);
                            //增加订单明细日志表20071105
                            AddOrderItemLog(newItemId1, transaction);
                            //往订单状态表中插入一条记录
                            //AddGpoItemStatus(input, newItemId1, state, transaction);

                            //(3)往订单明细表中增加一条定购量=页面传入的到货量，其他信息为原订单明细信息的记录。（order_type设为1到货）创建时间为原订单明细的时间
                            String newItemId2 = CopyGpoOrderItem(orderItemId,input.HighId, transaction);
                            dr = GetOrderItemRow(orderItemId, transaction);
                            state = dr["state"].ToString();
                            input.RequestQty = item.ReceiveQty;
                            input.OrderType = "1";
                            UpdateOrderItemData1(input, newItemId2, transaction);
                            //增加订单明细日志表20071105
                            AddOrderItemLog(newItemId2, transaction);
                            //往订单状态表中插入一条记录
                            //AddGpoItemStatus(input, newItemId1, state, transaction);
                            receiveItemId = newItemId2;

                            //(4)往订单明细表增加一条定购量=原定购量－到货量，其他信息为原订单明细信息的记录。（order_type设为0兰票）创建时间为当前时间
                            String newItemId3 = CopyGpoOrderItem(orderItemId,input.HighId, transaction);
                            dr = GetOrderItemRow(orderItemId, transaction);
                            //state = dr["item_status"].ToString();
                            input.RequestQty = (requestQty - receiveQty).ToString();
                            input.OrderType = "0";
                            input.ItemState = "1";
                            UpdateOrderItemData2(input, newItemId3, transaction);
                            //增加订单明细日志表20071105
                            AddOrderItemLog(newItemId3, transaction);
                            //往订单状态表中插入一条记录
                            //AddGpoItemStatus(input, newItemId1, "1", transaction);

                            //(5)修改备货表的订单明细id为(order_type为1到货)的订单明细id
                            UpdateItemIdGpoOrderStockup(receiveItemId, item.StockupId, transaction);
                            //增加备货日志表20071105
                            AddOrderStockUpLog(item.StockupId, transaction);

                            //(6)把备货表中的订单明细id=初始订单明细id改为新生成兰票的订单明细id
                            if (UpdateItemId(orderItemId, newItemId3, transaction))
                            {
                                //  4 确认状态
                                input.ItemState = "4";
                                input.OrderType = "0";
                                string backOrderItemId = input.OrderRecordId;
                                input.OrderRecordId = newItemId3;
                                UpdateOrderItemData(input, transaction);
                                input.OrderRecordId = backOrderItemId;
                            }

                        }
                        //如果到货量小于等于订购量,往到货表新增一条到货记录
                        //if (requestQty >= receiveQty)
                        //{
                        input.OrderRecordId = receiveItemId;

                        AddGpoOrderReceive(input, item, transaction);
                        
                        //订单结果表插入数据
                        AddOrderResult(input, item, transaction);
//------------------------//DbFacade.CommitTransaction(transaction);
                        //}
                    }
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    //更新订单主表的状态
                    //1.如果按订单到货，更新该订单主表的订单状态
                    //if ("1".Equals(input.Flag))
                    {
                        UpdateOrderState(input, input.OrderId, transaction);
                        string overSum = GetOrderOverSum(input.OrderId,transaction);
                        UpdateOrderSum(overSum, input.OrderId, transaction);
                        //增加订单日志表20071105
                        AddOrderLog(input, transaction);
                    }
                   
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        /// <summary>
        /// 更新订单明细表
        /// </summary>
        public bool UpdateOrderItemData3(BuyerOrderModel input,double receiveQty, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_ITEM set STATE= @state, OVER_AMOUNT=@requestQty,OVER_SUM=@requestQty * TRADE_PRICE,modify_user_id = @userId,modify_date = getdate(),sync_state='0',order_type=@type where id=@id ";


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter statePara = this.DbFacade.CreateParameter();
            statePara.ParameterName = "state";
            statePara.DbType = DbType.String;
            statePara.Value = input.ItemState;
            parameters.Add(statePara);

            DbParameter userIdPara = this.DbFacade.CreateParameter();
            userIdPara.ParameterName = "userId";
            userIdPara.DbType = DbType.Int64;
            userIdPara.Value = input.UserId;
            parameters.Add(userIdPara);

            DbParameter typePara = this.DbFacade.CreateParameter();
            typePara.ParameterName = "type";
            typePara.DbType = DbType.String;
            typePara.Value = input.OrderType;
            parameters.Add(typePara);

            DbParameter requestQtyPara = this.DbFacade.CreateParameter();
            requestQtyPara.ParameterName = "requestQty";
            requestQtyPara.DbType = DbType.String;
            requestQtyPara.Value = receiveQty;
            parameters.Add(requestQtyPara);

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = input.OrderRecordId;
            parameters.Add(idPara);

            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;


            return result;
        }


        /// <summary>
        /// 更新订单明细表
        /// </summary>
        public bool UpdateOrderItemData(BuyerOrderModel input, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_ITEM set STATE= @state, modify_user_id = @userId,modify_date = getdate(),sync_state='0',order_type=@type where id=@id ";


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter statePara = this.DbFacade.CreateParameter();
            statePara.ParameterName = "state";
            statePara.DbType = DbType.String;
            statePara.Value = input.ItemState;
            parameters.Add(statePara);

            DbParameter userIdPara = this.DbFacade.CreateParameter();
            userIdPara.ParameterName = "userId";
            userIdPara.DbType = DbType.Int64;
            userIdPara.Value = input.UserId;
            parameters.Add(userIdPara);

            DbParameter typePara = this.DbFacade.CreateParameter();
            typePara.ParameterName = "type";
            typePara.DbType = DbType.String;
            typePara.Value = input.OrderType;
            parameters.Add(typePara);

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = input.OrderRecordId;
            parameters.Add(idPara);

            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;


            return result;
        }

        /// <summary>
        /// 往订单结果表新增一条记录
        /// </summary>
        public bool AddOrderResult(BuyerOrderModel input, OrderItemModel item, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;

            sql.Append("insert into HC_ORD_ORDER_RESULT");
            sql.Append("(id,data_product_id,project_id,project_product_id,order_id,order_item_id,");
            sql.Append(" RECEIVE_ID,RESULT_TYPE,type,code,INVOICE_ID,BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,");
            sql.Append(" SALER_ID,SALER_NAME,SALER_NAME_ABBR,SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,");
            sql.Append(" MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR,PRODUCT_NAME,PRODUCT_CODE,");
            sql.Append(" SPEC_ID,MODEL_ID,SPEC,MODEL,COMMON_NAME,BRAND,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,BASE_MEASURE,");

            sql.Append(" STATE,SEND_MEASURE,SEND_MEASURE_EX,send_batch_no,instore_batch_no,store_room_id,store_room_name,arrive_date,price,fact_amount,fact_sum,");
            sql.Append(" pbno,sync_state,create_user_id,create_date");
            sql.Append(",MODIFY_USER_id,MODIFY_USER_name,modify_date,create_user_name");


            sql.Append(")values(@id,@productId,@project_id,@project_product_id,@orderId,@orderItemId,");
            sql.Append(" @receiveId,'1','1',@code,'0',@buyerId,@buyerName,@buyerNameAbbr,");
            sql.Append(" @salerId,@salerName,@salerNameAbbr,@senderId,@senderName,@senderNameAbbr,");
            sql.Append(" @manuId,@manuName,@manuNameAbbr,@productName,@productCode,");
            sql.Append(" @spec_id,@model_id,@spec,@model,@commonName,@brand,@baseMeasureSpec,@baseMeasureMater,@baseMeasure,");
            sql.Append(" '1',@send_measure,@send_measure_ex,@send_batch_no,@lotNo,@store_room_id,@store_room_name,getdate(),@tradePrice,@receiveQty,@factSum,");


            sql.Append(" @pbno,0,@receiveUserid,getdate()");
            sql.Append(",@modifyUser,@modifyUserName,getdate(),@create_user_name)");

            //以下为备注字段
            //receiveId buyerId buyerName buyerNameAbbr salerId salerName
            //            salerNameAbbr senderId senderName senderNameAbbr manuId manuName
            //manuNameAbbr  SEND_MEASURE productName productCode spec_id model_id
            //    spec model commonName  brand baseMeasureSpec baseMeasureMater
            //    baseMeasure
            //            send_measure_ex

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = base.GetClientId(input.HighId);
            parameters.Add(idPara);

            DbParameter idParaProid = this.DbFacade.CreateParameter();
            idParaProid.ParameterName = "project_id";
            idParaProid.DbType = DbType.Int64;
            idParaProid.Value = item.Project_id;
            parameters.Add(idParaProid);

            DbParameter receivePareId = this.DbFacade.CreateParameter();
            receivePareId.ParameterName = "receiveId";
            receivePareId.DbType = DbType.Int64;
            receivePareId.Value = item.ReceiveId;
            parameters.Add(receivePareId);

            DbParameter idParaCode = this.DbFacade.CreateParameter();
            idParaCode.ParameterName = "code";
            idParaCode.DbType = DbType.String;
            idParaCode.Value = base.GetClientCode(input.HighId);
            parameters.Add(idParaCode);

            DbParameter PareBuyerID = this.DbFacade.CreateParameter();
            PareBuyerID.ParameterName = "buyerId";
            PareBuyerID.DbType = DbType.Int64;
            PareBuyerID.Value = item.BuyerId;
            parameters.Add(PareBuyerID);

            DbParameter PareBuyerName = this.DbFacade.CreateParameter();
            PareBuyerName.ParameterName = "buyerName";
            PareBuyerName.DbType = DbType.String;
            PareBuyerName.Value = item.BuyerName;
            parameters.Add(PareBuyerName);

            DbParameter PareBuyerNameAbbr = this.DbFacade.CreateParameter();
            PareBuyerNameAbbr.ParameterName = "buyerNameAbbr";
            PareBuyerNameAbbr.DbType = DbType.String;
            PareBuyerNameAbbr.Value = item.BuyerNameAbbr;
            parameters.Add(PareBuyerNameAbbr);

            DbParameter PareSalerId = this.DbFacade.CreateParameter();
            PareSalerId.ParameterName = "salerId";
            PareSalerId.DbType = DbType.Int64;
            PareSalerId.Value = item.SalerId;
            parameters.Add(PareSalerId);

            DbParameter PareSalerName = this.DbFacade.CreateParameter();
            PareSalerName.ParameterName = "salerName";
            PareSalerName.DbType = DbType.String;
            PareSalerName.Value = item.SalerName;
            parameters.Add(PareSalerName);

            DbParameter PareSalerNameAbbr = this.DbFacade.CreateParameter();
            PareSalerNameAbbr.ParameterName = "salerNameAbbr";
            PareSalerNameAbbr.DbType = DbType.String;
            PareSalerNameAbbr.Value = item.SalerNameAbbr;
            parameters.Add(PareSalerNameAbbr);

            DbParameter PareSenderId = this.DbFacade.CreateParameter();
            PareSenderId.ParameterName = "senderId";
            PareSenderId.DbType = DbType.Int64;
            PareSenderId.Value = item.SenderId;
            parameters.Add(PareSenderId);

            DbParameter PareSenderName = this.DbFacade.CreateParameter();
            PareSenderName.ParameterName = "senderName";
            PareSenderName.DbType = DbType.String;
            PareSenderName.Value = item.SenderName;
            parameters.Add(PareSenderName);

            DbParameter PareSenderNameAbbr = this.DbFacade.CreateParameter();
            PareSenderNameAbbr.ParameterName = "senderNameAbbr";
            PareSenderNameAbbr.DbType = DbType.String;
            PareSenderNameAbbr.Value = item.SenderNameAbbr;
            parameters.Add(PareSenderNameAbbr);

            DbParameter PareManuId = this.DbFacade.CreateParameter();
            PareManuId.ParameterName = "manuId";
            PareManuId.DbType = DbType.Int64;
            PareManuId.Value = item.ManuId;
            parameters.Add(PareManuId);

            DbParameter PareManuName = this.DbFacade.CreateParameter();
            PareManuName.ParameterName = "manuName";
            PareManuName.DbType = DbType.String;
            PareManuName.Value = item.ManuName;
            parameters.Add(PareManuName);

            DbParameter PareManuNameAbbr = this.DbFacade.CreateParameter();
            PareManuNameAbbr.ParameterName = "manuNameAbbr";
            PareManuNameAbbr.DbType = DbType.String;
            PareManuNameAbbr.Value = item.ManuNameAbbr;
            parameters.Add(PareManuNameAbbr);

            DbParameter PareProductName = this.DbFacade.CreateParameter();
            PareProductName.ParameterName = "productName";
            PareProductName.DbType = DbType.String;
            PareProductName.Value = item.ProductName;
            parameters.Add(PareProductName);

            DbParameter PareProductCode = this.DbFacade.CreateParameter();
            PareProductCode.ParameterName = "productCode";
            PareProductCode.DbType = DbType.String;
            PareProductCode.Value = item.ProductCode;
            parameters.Add(PareProductCode);

            DbParameter PareSpecId = this.DbFacade.CreateParameter();
            PareSpecId.ParameterName = "spec_id";
            PareSpecId.DbType = DbType.Int64;
            PareSpecId.Value = item.Spec_id;
            parameters.Add(PareSpecId);

            DbParameter PareModelId = this.DbFacade.CreateParameter();
            PareModelId.ParameterName = "model_id";
            PareModelId.DbType = DbType.Int64;
            PareModelId.Value = item.Model_id;
            parameters.Add(PareModelId);

            DbParameter PareSpec = this.DbFacade.CreateParameter();
            PareSpec.ParameterName = "spec";
            PareSpec.DbType = DbType.String;
            PareSpec.Value = item.Spec;
            parameters.Add(PareSpec);

            DbParameter PareModel = this.DbFacade.CreateParameter();
            PareModel.ParameterName = "model";
            PareModel.DbType = DbType.String;
            PareModel.Value = item.Model;
            parameters.Add(PareModel);

            DbParameter PareCommonName = this.DbFacade.CreateParameter();
            PareCommonName.ParameterName = "commonName";
            PareCommonName.DbType = DbType.String;
            PareCommonName.Value = item.CommonName;
            parameters.Add(PareCommonName);

            DbParameter PareBrand = this.DbFacade.CreateParameter();
            PareBrand.ParameterName = "brand";
            PareBrand.DbType = DbType.String;
            PareBrand.Value = item.Brand;
            parameters.Add(PareBrand);

            DbParameter PareBaseMS = this.DbFacade.CreateParameter();
            PareBaseMS.ParameterName = "baseMeasureSpec";
            PareBaseMS.DbType = DbType.String;
            PareBaseMS.Value = item.BaseMeasureSpec;
            parameters.Add(PareBaseMS);

            DbParameter PareBaseMM = this.DbFacade.CreateParameter();
            PareBaseMM.ParameterName = "baseMeasureMater";
            PareBaseMM.DbType = DbType.String;
            PareBaseMM.Value = item.BaseMeasureMater;
            parameters.Add(PareBaseMM);

            DbParameter PareBaseM = this.DbFacade.CreateParameter();
            PareBaseM.ParameterName = "baseMeasure";
            PareBaseM.DbType = DbType.String;
            PareBaseM.Value = item.BaseMeasure;
            parameters.Add(PareBaseM);

            DbParameter PareSendM = this.DbFacade.CreateParameter();
            PareSendM.ParameterName = "send_measure";
            PareSendM.DbType = DbType.String;
            PareSendM.Value = item.Send_measure;
            parameters.Add(PareSendM);

            DbParameter PareSendME = this.DbFacade.CreateParameter();
            PareSendME.ParameterName = "send_measure_ex";
            PareSendME.DbType = DbType.String;
            PareSendME.Value = item.Send_measure_ex;
            parameters.Add(PareSendME);


            DbParameter idParaProjProdId = this.DbFacade.CreateParameter();
            idParaProjProdId.ParameterName = "project_product_id";
            idParaProjProdId.DbType = DbType.Int64;
            idParaProjProdId.Value = item.Project_product_id;
            parameters.Add(idParaProjProdId);

            DbParameter idParapbno = this.DbFacade.CreateParameter();
            idParapbno.ParameterName = "pbno";
            idParapbno.DbType = DbType.String;
            idParapbno.Value = item.Pbno;
            parameters.Add(idParapbno);

            DbParameter idParaSendbNo = this.DbFacade.CreateParameter();
            idParaSendbNo.ParameterName = "send_batch_no";
            idParaSendbNo.DbType = DbType.String;
            idParaSendbNo.Value = item.Send_batch_no;
            parameters.Add(idParaSendbNo);

            DbParameter idParaSRI = this.DbFacade.CreateParameter();
            idParaSRI.ParameterName = "store_room_id";
            idParaSRI.DbType = DbType.String;
            idParaSRI.Value = item.Store_room_id;
            parameters.Add(idParaSRI);

            DbParameter idParaSRN = this.DbFacade.CreateParameter();
            idParaSRN.ParameterName = "store_room_name";
            idParaSRN.DbType = DbType.String;
            idParaSRN.Value = item.Store_room_name;
            parameters.Add(idParaSRN);

            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.Int64;
            if (!String.IsNullOrEmpty(item.OrderId))
            {
                orderIdPara.Value = item.OrderId;
            }
            else
            {
                orderIdPara.Value = input.OrderId;
            }
            parameters.Add(orderIdPara);

            DbParameter orderItemIdPara = this.DbFacade.CreateParameter();
            orderItemIdPara.ParameterName = "orderItemId";
            orderItemIdPara.DbType = DbType.Int64;
            orderItemIdPara.Value = item.Order_item_id;
            parameters.Add(orderItemIdPara);

            DbParameter productIdPara = this.DbFacade.CreateParameter();
            productIdPara.ParameterName = "productId";
            productIdPara.DbType = DbType.Int64;
            productIdPara.Value = item.ProductId;
            parameters.Add(productIdPara);

         
            DbParameter lotNoPara = this.DbFacade.CreateParameter();
            lotNoPara.ParameterName = "lotNo";
            lotNoPara.DbType = DbType.String;
            lotNoPara.Value = item.LotNo;
            parameters.Add(lotNoPara);

            DbParameter receiveUseridPara = this.DbFacade.CreateParameter();
            receiveUseridPara.ParameterName = "receiveUserid";
            receiveUseridPara.DbType = DbType.Int64;
            receiveUseridPara.Value = input.UserId;
            parameters.Add(receiveUseridPara);

            DbParameter tradePricePara = this.DbFacade.CreateParameter();
            tradePricePara.ParameterName = "tradePrice";
            tradePricePara.DbType = DbType.Decimal;
            tradePricePara.Value = String.IsNullOrEmpty(item.TradePrice.Trim()) ? Convert.DBNull : double.Parse(item.TradePrice);
            parameters.Add(tradePricePara);

            DbParameter retailPricePara = this.DbFacade.CreateParameter();
            retailPricePara.ParameterName = "retailPrice";
            retailPricePara.DbType = DbType.Decimal;
            retailPricePara.Value = String.IsNullOrEmpty(item.RetailPrice.Trim()) ? Convert.DBNull : double.Parse(item.RetailPrice);
            parameters.Add(retailPricePara);

            DbParameter receiveQtyPara = this.DbFacade.CreateParameter();
            receiveQtyPara.ParameterName = "receiveQty";
            receiveQtyPara.DbType = DbType.String;
            receiveQtyPara.Value = item.ReceiveQty;
            parameters.Add(receiveQtyPara);

            DbParameter factSumPara = this.DbFacade.CreateParameter();
            factSumPara.ParameterName = "factSum";
            factSumPara.DbType = DbType.String;
            factSumPara.Value = int.Parse(item.ReceiveQty) * double.Parse(item.TradePrice);
            parameters.Add(factSumPara);

            DbParameter modifyUser = this.DbFacade.CreateParameter();
            modifyUser.ParameterName = "modifyUser";
            modifyUser.DbType = DbType.String;
            modifyUser.Value = input.UserId;
            parameters.Add(modifyUser);

            DbParameter modifyUserName = this.DbFacade.CreateParameter();
            modifyUserName.ParameterName = "modifyUserName";
            modifyUserName.DbType = DbType.String;
            modifyUserName.Value = input.UserName;
            parameters.Add(modifyUserName);

            DbParameter create_user_name = this.DbFacade.CreateParameter();
            create_user_name.ParameterName = "create_user_name";
            create_user_name.DbType = DbType.String;
            create_user_name.Value = input.UserName;
            parameters.Add(create_user_name);



            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());
            result = true;


            return result;
        }



        /// <summary>
        /// 如果到货量小于等于订购量,往到货表新增一条到货记录
        /// </summary>
        public bool AddGpoOrderReceive(BuyerOrderModel input, OrderItemModel item, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;
            //shejg 2007-05-22 修改：增加写入 MODIFY_USER字段内容
            sql.Append("insert into HC_ORD_ORDER_RECEIVE");
            sql.Append("(id,project_id,type,code,project_product_id,pbno,send_batch_no,store_room_id,store_room_name,ARRIVE_DATE,sync_state,order_id,order_item_id,data_product_id,INSTORE_BATCH_NO,create_user_id,create_date");
            sql.Append(",price,FACT_AMOUNT,FACT_SUM,MODIFY_USER_id,MODIFY_USER_name,modify_date,create_user_name,INVOICE_ID,RETURN_AMOUNT,RETURN_SUM,STOCKUP_ID");
            sql.Append(")values(@id,@project_id,'1',@code,@project_product_id,@pbno,@send_batch_no,@store_room_id,@store_room_name,getdate(),'0',@orderId,@orderItemId,@productId,@lotNo,@receiveUserid,getdate()");
            sql.Append(",@tradePrice,@receiveQty,@FactSum,@modifyUser,@modifyUserName,getdate(),@create_user_name,0,0,0,@stockupId)");


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = base.GetClientId(input.HighId).ToString();
            item.ReceiveId =  Int64.Parse(idPara.Value.ToString());
            parameters.Add(idPara);

            DbParameter idParaProid = this.DbFacade.CreateParameter();
            idParaProid.ParameterName = "project_id";
            idParaProid.DbType = DbType.Int64;
            idParaProid.Value = item.Project_id;
            parameters.Add(idParaProid);

            DbParameter idParaCode = this.DbFacade.CreateParameter();
            idParaCode.ParameterName = "code";
            idParaCode.DbType = DbType.String;
            idParaCode.Value = base.GetClientCode(input.HighId);
            parameters.Add(idParaCode);

            DbParameter idParaProjProdId = this.DbFacade.CreateParameter();
            idParaProjProdId.ParameterName = "project_product_id";
            idParaProjProdId.DbType = DbType.Int64;
            idParaProjProdId.Value = item.Project_product_id;
            parameters.Add(idParaProjProdId);

            DbParameter idParapbno = this.DbFacade.CreateParameter();
            idParapbno.ParameterName = "pbno";
            idParapbno.DbType = DbType.String;
            idParapbno.Value = item.Pbno;
            parameters.Add(idParapbno);

            DbParameter idParaSendbNo = this.DbFacade.CreateParameter();
            idParaSendbNo.ParameterName = "send_batch_no";
            idParaSendbNo.DbType = DbType.String;
            idParaSendbNo.Value = item.Send_batch_no;
            parameters.Add(idParaSendbNo);

            DbParameter idParaSRI = this.DbFacade.CreateParameter();
            idParaSRI.ParameterName = "store_room_id";
            idParaSRI.DbType = DbType.String;
            idParaSRI.Value = item.Store_room_id;
            parameters.Add(idParaSRI);

            DbParameter idParaSRN = this.DbFacade.CreateParameter();
            idParaSRN.ParameterName = "store_room_name";
            idParaSRN.DbType = DbType.String;
            idParaSRN.Value = item.Store_room_name;
            parameters.Add(idParaSRN);

       
            
            DbParameter orderIdPara = this.DbFacade.CreateParameter();
            orderIdPara.ParameterName = "orderId";
            orderIdPara.DbType = DbType.Int64;
            if (!String.IsNullOrEmpty(item.OrderId))
            {
                orderIdPara.Value = item.OrderId;
            }
            else
            {
                orderIdPara.Value = input.OrderId;
            }
            parameters.Add(orderIdPara);

            DbParameter orderItemIdPara = this.DbFacade.CreateParameter();
            orderItemIdPara.ParameterName = "orderItemId";
            orderItemIdPara.DbType = DbType.Int64;
            orderItemIdPara.Value = item.Order_item_id;
            parameters.Add(orderItemIdPara);

            DbParameter productIdPara = this.DbFacade.CreateParameter();
            productIdPara.ParameterName = "productId";
            productIdPara.DbType = DbType.Int64;
            productIdPara.Value = item.ProductId;
            parameters.Add(productIdPara);


            DbParameter lotNoPara = this.DbFacade.CreateParameter();
            lotNoPara.ParameterName = "lotNo";
            lotNoPara.DbType = DbType.String;
            lotNoPara.Value = item.LotNo;
            parameters.Add(lotNoPara);

            DbParameter receiveUseridPara = this.DbFacade.CreateParameter();
            receiveUseridPara.ParameterName = "receiveUserid";
            receiveUseridPara.DbType = DbType.Int64;
            receiveUseridPara.Value = input.UserId;
            parameters.Add(receiveUseridPara);
            

            DbParameter tradePricePara = this.DbFacade.CreateParameter();
            tradePricePara.ParameterName = "tradePrice";
            tradePricePara.DbType = DbType.Decimal;
            tradePricePara.Value = String.IsNullOrEmpty(item.TradePrice.Trim()) ? Convert.DBNull : double.Parse(item.TradePrice);
            parameters.Add(tradePricePara);

            //DbParameter retailPricePara = this.DbFacade.CreateParameter();
            //retailPricePara.ParameterName = "retailPrice";
            //retailPricePara.DbType = DbType.Decimal;
            //retailPricePara.Value = String.IsNullOrEmpty(item.RetailPrice.Trim()) ? Convert.DBNull : double.Parse(item.RetailPrice);
            //parameters.Add(retailPricePara);



            DbParameter receiveQtyPara = this.DbFacade.CreateParameter();
            receiveQtyPara.ParameterName = "receiveQty";
            receiveQtyPara.DbType = DbType.String;
            receiveQtyPara.Value = item.ReceiveQty;
            parameters.Add(receiveQtyPara);

            DbParameter factSumPara = this.DbFacade.CreateParameter();
            factSumPara.ParameterName = "FactSum";
            factSumPara.DbType = DbType.String;
            factSumPara.Value = int.Parse(item.ReceiveQty) * double.Parse(item.TradePrice);
            parameters.Add(factSumPara);
            
            //shejg 2007-05-22 修改：增加参数，写入 MODIFY_USER
            DbParameter modifyUser = this.DbFacade.CreateParameter();
            modifyUser.ParameterName = "modifyUser";
            modifyUser.DbType = DbType.String;
            modifyUser.Value = input.UserId;
            parameters.Add(modifyUser);

            DbParameter modifyUserName = this.DbFacade.CreateParameter();
            modifyUserName.ParameterName = "modifyUserName";
            modifyUserName.DbType = DbType.String;
            modifyUserName.Value = input.UserName;
            parameters.Add(modifyUserName);

            DbParameter create_user_name = this.DbFacade.CreateParameter();
            create_user_name.ParameterName = "create_user_name";
            create_user_name.DbType = DbType.String;
            create_user_name.Value = input.UserName;
            parameters.Add(create_user_name);

            DbParameter stockupId = this.DbFacade.CreateParameter();
            stockupId.ParameterName = "stockupId";
            stockupId.DbType = DbType.Int64;
            stockupId.Value = item.StockupId;
            parameters.Add(stockupId);
            

            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());

            //增加到货单日志表20071105
            AddOrderReceiveLog(item.ReceiveId, transaction);

            result = true;


            return result;
        }

        /// <summary>
        /// 往到货单日志表中插入一条记录20071105
        /// </summary>
        public bool AddOrderReceiveLog(long ReceiveId, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            bool result = false;
            sql.Append("insert into HC_ORD_ORDER_RECEIVE_LOG");
            sql.Append("(id ");

            sql.Append(",DATA_PRODUCT_ID,PROJECT_ID,");
            sql.Append("TYPE,CODE,PROJECT_PRODUCT_ID,ORDER_ID,");
            sql.Append("ORDER_ITEM_ID,INVOICE_ID,GOODS_NO,");
            sql.Append("BARCODE,PBNO,SEND_BATCH_NO,");
            sql.Append("INSTORE_BATCH_NO,STORE_ROOM_ID,STORE_ROOM_NAME,");
            sql.Append("ARRIVAL_ADDRESS,ARRIVE_DATE,PRICE,");
            sql.Append("FACT_AMOUNT,FACT_SUM,CREATE_USER_ID,");
            sql.Append("CREATE_USER_NAME,CREATE_DATE,MODIFY_USER_ID,");
            sql.Append("MODIFY_USER_NAME,MODIFY_DATE,DESCRIPTIONS,");
            sql.Append("OPERATOR_USER_ID,OPERATOR_USER_NAME,OPERATOR_DATE,STOCKUP_ID,sync_state");

            sql.Append(")select");
            sql.Append(" id,");
            sql.Append("DATA_PRODUCT_ID,PROJECT_ID,");
            sql.Append("TYPE,CODE,PROJECT_PRODUCT_ID,ORDER_ID,");
            sql.Append("ORDER_ITEM_ID,INVOICE_ID,GOODS_NO,");
            sql.Append("BARCODE,PBNO,SEND_BATCH_NO,");
            sql.Append("INSTORE_BATCH_NO,STORE_ROOM_ID,STORE_ROOM_NAME,");
            sql.Append("ARRIVAL_ADDRESS,ARRIVE_DATE,PRICE,");
            sql.Append("FACT_AMOUNT,FACT_SUM,CREATE_USER_ID,");
            sql.Append("CREATE_USER_NAME,CREATE_DATE,MODIFY_USER_ID,");
            sql.Append("MODIFY_USER_NAME,MODIFY_DATE,DESCRIPTIONS,");
            sql.Append("MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,STOCKUP_ID,0");

            sql.Append(" from HC_ORD_ORDER_RECEIVE where id=@id");


            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter newIdPara = this.DbFacade.CreateParameter();
            newIdPara.ParameterName = "id";
            newIdPara.DbType = DbType.Int64;
            newIdPara.Value = ReceiveId;
            parameters.Add(newIdPara);


            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());
            result = true;

            return result;
        }



        /// <summary>
        /// 修改备货表的订单明细id为(order_type为1到货)的订单明细id
        /// </summary>
        public bool UpdateItemIdGpoOrderStockup(String itemId, String id, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_STOCKUP set sync_state='0', order_item_id = @itemId where id=@id ";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter itemIdPara = this.DbFacade.CreateParameter();
            itemIdPara.ParameterName = "itemId";
            itemIdPara.DbType = DbType.Int64;
            itemIdPara.Value = itemId;
            parameters.Add(itemIdPara);

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = id;
            parameters.Add(idPara);

            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;

            return result;
        }


        
        /// <summary>
        /// 从订单表中取得完成金额
        /// </summary>
        public string GetOrderOverSum(String orderId, DbTransaction transaction)
        {
            string sql = "select sum(over_sum) from dbo.HC_ORD_ORDER_ITEM where order_id=@id and state='5' and order_type='1' ";
            string overSum;
            try
            {
                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = orderId;

                overSum = base.DbFacade.SQLExecuteScalar(sql, transaction, idPara).ToString();

            }
            catch (Exception e)
            {

                throw e;
            }
            return overSum;
        }

        /// <summary>
        /// 从订单表中取得完成金额
        /// </summary>
        public string GetOrderOverSum(String orderId )
        {
            string sql = "select sum(over_sum) from dbo.HC_ORD_ORDER_ITEM where order_id=@id and state='5' and order_type='1' ";
            string overSum;
            try
            {
                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = orderId;

                overSum = base.DbFacade.SQLExecuteScalar(sql, idPara).ToString();

            }
            catch (Exception e)
            {

                throw e;
            }
            return overSum;
        }

        /// <summary>
        /// 从订单表中取得完成金额
        /// </summary>
        public string GetOrderState(String orderId)
        {
            string sql = "select (case o.STATE when '1' then '未阅读' when '2' then '已阅读' when '3' then '确认' when '4' then '处理中' when '5' then '完成' when '6' then '作废' end) As status from dbo.HC_ORD_ORDER o where id=@id  ";
            string state;
            try
            {
                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = orderId;

                state = base.DbFacade.SQLExecuteScalar(sql, idPara).ToString();

            }
            catch (Exception e)
            {

                throw e;
            }
            return state;
        }

        /// <summary>
        /// 从订单明细表中取得订购量
        /// </summary>
        public string GetOrderItemRequestQty(String orderItemId, DbTransaction transaction)
        {

            string sql = "select (AMOUNT) As request_qty from HC_ORD_ORDER_ITEM where id=@id ";
            string request_qty;
            try
            {
                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = orderItemId;

                request_qty = base.DbFacade.SQLExecuteScalar(sql, transaction, idPara).ToString();

            }
            catch (Exception e)
            {

                throw e;
            }
            return request_qty;
        }

        /// <summary>
        /// 查询订单明细状态
        /// </summary>
        public string SearchOrderState(BuyerOrderModel input)
        {

            String sql = "select STATE from HC_ORD_ORDER_ITEM where id=@id ";
            string state = "";
            try
            {

                DbParameter idPara = this.DbFacade.CreateParameter();
                idPara.ParameterName = "id";
                idPara.DbType = DbType.Int64;
                idPara.Value = input.OrderRecordId;

                state = base.DbFacade.SQLExecuteScalar(sql, idPara).ToString();

            }
            catch (Exception e)
            {

                throw e;
            }
            return state;
        }

        /// <summary>
        /// 更新订单明细表
        /// </summary>
        public bool UpdateOrderItemData1(BuyerOrderModel input, String newItemId, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_ITEM set AMOUNT = @requestQty,OVER_AMOUNT=@requestQty,OVER_SUM=@requestQty * TRADE_PRICE, parent_item_id = @parentItemId,order_type=@type,modify_user_id = @modify_user_id,modify_date = getdate(),sync_state='0' where id=@id ";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter requestQtyPara = this.DbFacade.CreateParameter();
            requestQtyPara.ParameterName = "requestQty";
            requestQtyPara.DbType = DbType.String;
            requestQtyPara.Value = input.RequestQty;
            parameters.Add(requestQtyPara);

            DbParameter parentItemIdPara = this.DbFacade.CreateParameter();
            parentItemIdPara.ParameterName = "parentItemId";
            parentItemIdPara.DbType = DbType.Int64;
            parentItemIdPara.Value = input.OrderRecordId;
            parameters.Add(parentItemIdPara);

            DbParameter typePara = this.DbFacade.CreateParameter();
            typePara.ParameterName = "type";
            typePara.DbType = DbType.String;
            typePara.Value = input.OrderType;
            parameters.Add(typePara);

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = newItemId;
            parameters.Add(idPara);

            DbParameter usridPara = this.DbFacade.CreateParameter();
            usridPara.ParameterName = "modify_user_id";
            usridPara.DbType = DbType.Int64;
            usridPara.Value = input.UserId;
            parameters.Add(usridPara);

            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;

            return result;
        }


        /// <summary>
        /// 更新订单明细表
        /// </summary>
        public bool UpdateOrderItemData2(BuyerOrderModel input, String newItemId, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_ITEM set AMOUNT = @requestQty, parent_item_id = @parentItemId,order_type=@type,modify_user_id = @userId,modify_date = getdate(),state=@status,create_date=getdate(),sync_state='0' where id=@id ";


            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter requestQtyPara = this.DbFacade.CreateParameter();
            requestQtyPara.ParameterName = "requestQty";
            requestQtyPara.DbType = DbType.String;
            requestQtyPara.Value = input.RequestQty;
            parameters.Add(requestQtyPara);

            DbParameter parentItemIdPara = this.DbFacade.CreateParameter();
            parentItemIdPara.ParameterName = "parentItemId";
            parentItemIdPara.DbType = DbType.Int64;
            parentItemIdPara.Value = input.OrderRecordId;
            parameters.Add(parentItemIdPara);

            DbParameter typePara = this.DbFacade.CreateParameter();
            typePara.ParameterName = "type";
            typePara.DbType = DbType.String;
            typePara.Value = input.OrderType;
            parameters.Add(typePara);

            DbParameter statusPara = this.DbFacade.CreateParameter();
            statusPara.ParameterName = "status";
            statusPara.DbType = DbType.String;
            statusPara.Value = input.ItemState;
            parameters.Add(statusPara);

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = newItemId;
            parameters.Add(idPara);

            DbParameter usridPara = this.DbFacade.CreateParameter();
            usridPara.ParameterName = "userId";
            usridPara.DbType = DbType.Int64;
            usridPara.Value = input.UserId;
            parameters.Add(usridPara);
            


            base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            result = true;

            return result;
        }

        /// <summary>
        ///  往HC_ORD_ORDER_ITEM表中插入一条记录，
        ///  该记录的内容除了record_id不同外，其他字段与id=orderItemId的这条记录相同
        /// </summary>
        public String CopyGpoOrderItem(String id,int highid ,DbTransaction transaction)
        {

            String newId;
            StringBuilder sql = new StringBuilder();

            sql.Append("insert into HC_ORD_ORDER_ITEM");
            sql.Append("  (id,");
            sql.Append(" PROJECT_ID,");
            sql.Append(" ORDER_ID,");
            sql.Append(" PURCHASE_ID,");
            sql.Append(" DATA_PRODUCT_ID,");
            sql.Append(" PROJECT_PROD_ID,");
            sql.Append(" BUYER_ID,");
            sql.Append(" BUYER_NAME,");
            sql.Append(" BUYER_NAME_ABBR,");
            sql.Append(" SALER_ID,");
            sql.Append(" SALER_NAME,");
            sql.Append(" SALER_NAME_ABBR,");
            sql.Append(" SENDER_ID,");
            sql.Append(" SENDER_NAME,");
            sql.Append(" SENDER_NAME_ABBR,");
            sql.Append(" MANUFACTURE_ID,");
            sql.Append(" MANUFACTURE_NAME,");
            sql.Append(" MANUFACTURE_NAME_ABBR,");
            sql.Append(" COMMON_NAME,");
            sql.Append(" PRODUCT_NAME,");
            sql.Append(" PRODUCT_CODE,");
            sql.Append(" SPEC_ID,");
            sql.Append(" MODEL_ID,");
            sql.Append(" SPEC,");
            sql.Append(" MODEL,");
            sql.Append(" BRAND,");
            sql.Append(" GOODS_NO,");
            sql.Append(" BARCODE,");
            sql.Append(" STORE_ROOM_ID,");
            sql.Append(" STORE_ROOM_NAME,");
            sql.Append(" STORE_ROOM_ADDRESS,");
            sql.Append(" BASE_MEASURE_SPEC,");
            sql.Append(" BASE_MEASURE_MATER,");
            sql.Append(" BASE_MEASURE,");
            sql.Append(" SEND_MEASURE,");
            sql.Append(" SEND_MEASURE_EX,");
            sql.Append(" RETAIL_PRICE,");
            sql.Append(" TRADE_PRICE,");
            sql.Append(" SUM,");
            sql.Append(" AMOUNT,");
            sql.Append(" OVER_AMOUNT,");
            sql.Append(" OVER_SUM,");
            sql.Append(" IS_QUICKSEND,");
            sql.Append(" ORDER_TYPE,");
            sql.Append(" STATE,");
            sql.Append(" BALANCE_ID,");
            sql.Append(" BALANCE_NAME,");
            sql.Append(" BALANCE_EASY,");
            sql.Append(" BALANCE_FAST,");
            sql.Append(" BALANCE_WUBI,");
            sql.Append(" BUYER_DESCRIPTIONS,");
            sql.Append(" SALER_DESCRIPTIONS,");
            sql.Append(" CREATE_USER_ID,");
            sql.Append(" CREATE_USER_NAME,");
            sql.Append("   create_date,");
            sql.Append("   modify_user_id,");
            sql.Append("   MODIFY_USER_NAME,");
            sql.Append("   SYNC_STATE,");
            sql.Append("   PURCHASE_ITEM_ID,");
            sql.Append(" ORIGINAL_ITEM_ID,");
            sql.Append(" PARENT_ITEM_ID,");
            sql.Append("   modify_date)");
            sql.Append("  select @newItemID,");
            sql.Append(" PROJECT_ID,");
            sql.Append(" ORDER_ID,");
            sql.Append(" PURCHASE_ID,");
            sql.Append(" DATA_PRODUCT_ID,");
            sql.Append(" PROJECT_PROD_ID,");
            sql.Append(" BUYER_ID,");
            sql.Append(" BUYER_NAME,");
            sql.Append(" BUYER_NAME_ABBR,");
            sql.Append(" SALER_ID,");
            sql.Append(" SALER_NAME,");
            sql.Append(" SALER_NAME_ABBR,");
            sql.Append(" SENDER_ID,");
            sql.Append(" SENDER_NAME,");
            sql.Append(" SENDER_NAME_ABBR,");
            sql.Append(" MANUFACTURE_ID,");
            sql.Append(" MANUFACTURE_NAME,");
            sql.Append(" MANUFACTURE_NAME_ABBR,");
            sql.Append(" COMMON_NAME,");
            sql.Append(" PRODUCT_NAME,");
            sql.Append(" PRODUCT_CODE,");
            sql.Append(" SPEC_ID,");
            sql.Append(" MODEL_ID,");
            sql.Append(" SPEC,");
            sql.Append(" MODEL,");
            sql.Append(" BRAND,");
            sql.Append(" GOODS_NO,");
            sql.Append(" BARCODE,");
            sql.Append(" STORE_ROOM_ID,");
            sql.Append(" STORE_ROOM_NAME,");
            sql.Append(" STORE_ROOM_ADDRESS,");
            sql.Append(" BASE_MEASURE_SPEC,");
            sql.Append(" BASE_MEASURE_MATER,");
            sql.Append(" BASE_MEASURE,");
            sql.Append(" SEND_MEASURE,");
            sql.Append(" SEND_MEASURE_EX,");
            sql.Append(" RETAIL_PRICE,");
            sql.Append(" TRADE_PRICE,");
            sql.Append(" SUM,");
            sql.Append(" AMOUNT,");
            sql.Append(" OVER_AMOUNT,");
            sql.Append(" OVER_SUM,");
            sql.Append(" IS_QUICKSEND,");
            sql.Append(" ORDER_TYPE,");
            sql.Append(" STATE,");
            sql.Append(" BALANCE_ID,");
            sql.Append(" BALANCE_NAME,");
            sql.Append(" BALANCE_EASY,");
            sql.Append(" BALANCE_FAST,");
            sql.Append(" BALANCE_WUBI,");
            sql.Append(" BUYER_DESCRIPTIONS,");
            sql.Append(" SALER_DESCRIPTIONS,");
            sql.Append(" CREATE_USER_ID,");
            sql.Append(" CREATE_USER_NAME,");
            sql.Append("   create_date,");
            sql.Append("   modify_user_id,");
            sql.Append("   MODIFY_USER_NAME,");
            sql.Append("   '0',");
            sql.Append("    PURCHASE_ITEM_ID,");
            sql.Append("  @id,");
            sql.Append("  @id,");
            sql.Append("   modify_date");


            sql.Append("    from HC_ORD_ORDER_ITEM i");
            sql.Append("   where i.id = @id");

            List<DbParameter> parameters = new List<DbParameter>();
            newId = this.GetClientId(highid).ToString();
            DbParameter newIdPara = this.DbFacade.CreateParameter();
            newIdPara.ParameterName = "newItemID";
            newIdPara.DbType = DbType.Int64;
            newIdPara.Value = newId;
            parameters.Add(newIdPara);

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = id;
            parameters.Add(idPara);

            base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, parameters.ToArray());


            return newId;
        }

        /// <summary>
        ///  根据订单明细id查询
        /// </summary>
        public DataRow GetOrderItemRow(String id, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder("select * from HC_ORD_ORDER_ITEM where id = @id ");
            DataRow dr;

            DbParameter idPara = this.DbFacade.CreateParameter();
            idPara.ParameterName = "id";
            idPara.DbType = DbType.Int64;
            idPara.Value = id;

            DataTable dt = this.DbFacade.SQLExecuteDataTable(sql.ToString(), transaction, idPara);
            dr = dt.Rows[0];

            return dr;
        }

        /// <summary>
        /// 把备货表中的订单明细id=初始订单明细id改为新生成兰票的订单明细id
        /// </summary>
        public bool UpdateItemId(String id1, String id2, DbTransaction transaction)
        {

            bool result = false;
            String sql = "update HC_ORD_ORDER_STOCKUP set order_item_id = @itemId1,sync_state='0' where order_item_id = @itemId2 ";

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter itemId1Para = this.DbFacade.CreateParameter();
            itemId1Para.ParameterName = "itemId1";
            itemId1Para.DbType = DbType.Int64;
            itemId1Para.Value = id2;
            parameters.Add(itemId1Para);

            DbParameter itemId2Para = this.DbFacade.CreateParameter();
            itemId2Para.ParameterName = "itemId2";
            itemId2Para.DbType = DbType.Int64;
            itemId2Para.Value = id1;
            parameters.Add(itemId2Para);

            int i = base.DbFacade.SQLExecuteNonQuery(sql, transaction, parameters.ToArray());
            if (i > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        #endregion

    }
}
