//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerOrderBLL.cs
//	创 建 人:	曹杰
//	创建日期:	2007-1-18
//	功能描述:	订单处理业务逻辑层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Emedchina.TradeAssistant.DAL.Order.SalerOrder;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.TradeAssistant.DAL.Common;
using Emedchina.TradeAssistant.Model.Order.DiscountInfo;
using Emedchina.TradeAssistant.DAL.Order.DiscountInfo;


namespace Emedchina.TradeAssistant.BLL.Order.SalerOrder
{
    public class SalerOrderBLL
    {
        private SalerOrderDAO dao = null;

        private SalerOrderBLL()
        {
            dao = SalerOrderDAO.GetInstance();
        }

        private SalerOrderBLL(string connectionName)
        {
            dao = SalerOrderDAO.GetInstance(connectionName);
        }

        public static SalerOrderBLL GetInstance()
        {
            return new SalerOrderBLL();
        }

        public static SalerOrderBLL GetInstance(string connectionName)
        {
            return new SalerOrderBLL(connectionName);
        }

        /// <summary>
        /// 取得订单列表数据
        /// </summary>
        public DataTable getSalerOrderList(SalerOrderListModel model, out int rows)
        {
            return dao.getSalerOrderList(model, out rows);
        }
        

        /// <summary>
        /// 取得订单明细列表数据
        /// </summary>
        public IList GetSalerOrderItemList(string orderId, string userName, string userId, bool flag)
        {
            IDataReader reader =  dao.GetSalerOrderItemList(orderId, userName, userId, flag);
            IList results = new ArrayList();
            while (reader.Read())
            {
                results.Add(MapSalerOrderItem(reader));
                
            }
            reader.Close();
            return results;

        }

        /// <summary>
        /// 取得订单明细列表数据
        /// </summary>
        public IList GetSalerOrderItemList(string orderId)
        {
            IDataReader reader = dao.GetSalerOrderItemList(orderId);
            IList results = new ArrayList();
            while (reader.Read())
            {
                results.Add(MapSalerOrderItem1(reader));

            }
            reader.Close();
            return results;

        }

        /// <summary>
        /// 设置检索结果对象
        /// </summary>
        /// <param name="reader">记录集合</param>
        /// <returns>检索结果对象</returns>
        private SalerOrderItemModel MapSalerOrderItem(IDataReader reader)
        {
            SalerOrderItemModel model = new SalerOrderItemModel();

            model.RecordId = reader["record_id"].ToString();
            model.ProductId = reader["product_id"].ToString();
            model.OrderId = reader["order_id"].ToString();
            model.OrderItemState = reader["item_status"].ToString();
            model.BuyerDesc = reader["buyer_remark"].ToString();
            model.UnitPrice = reader["provide_price"].ToString();
            model.BakMedicalName = reader["medical_name"].ToString();
            model.BakProductName = reader["trade_name"].ToString();
            model.ProductId = reader["product_id"].ToString();
            model.BakFactoryEasy = reader["factory_easy"].ToString();
            model.BakFactoryName = reader["factory_name"].ToString();
            model.RequestQty = reader["request_qty"].ToString();
            model.RepositoryName = reader["warehouse_name"].ToString();
            model.BakProductSpec = reader["ggbz"].ToString();
            model.OrderStateName = reader["status"].ToString();
            model.RepositoryId = reader["repository_id"].ToString();
            model.MaxQty = reader["maxQty"].ToString();

            model.InvoiceTradePrice = model.UnitPrice;
            model.InvoiceRetailPrice = model.UnitPrice;
            model.InvoiceDiscountRate = "100";
            model.InvoiceTotal = Convert.ToString(Convert.ToDouble(model.RequestQty) * Convert.ToDouble(model.UnitPrice));
            model.InvoiceDate = Convert.ToString(DateTime.Now.Date);
            model.InvoiceExpireDate = Convert.ToString(DateTime.Now.Date);

            //model.PlatId = reader["plat_id"].ToString();
            //model.DegreeFlag = reader["degree_flag"].ToString();            
            //model.BuyerOrgid = reader["buyer_orgid"].ToString();
            //model.BakBuyerName = reader["bakBuyerName"].ToString();
            //model.SalerOrgid = reader["saler_orgid"].ToString();
            //model.SenderOrgid = reader["sender_orgid"].ToString();
            //model.AgentOrgid = reader["agent_orgid"].ToString();
            //model.BakMedicalId = reader["bak_medical_id"].ToString();
            //model.BakMedicalMode = reader["bak_medical_mode"].ToString();
            //model.BakProductBidWay = reader["bak_product_bid_way"].ToString();
            //model.BakFactoryId = reader["bak_factory_id"].ToString();
            //model.MetricName = reader["metric_name"].ToString();
            //model.ReceiveQty = reader["receive_qty"].ToString();
            //model.SourceType = reader["source_type"].ToString();
            //model.SourceProjectId = reader["source_project_id"].ToString();
            //model.BakMedicalSpec = reader["bak_medical_spec"].ToString();
            //model.MiddleStandRate = reader["middle_stand_rate"].ToString();
            //start modify by gaoyuan 2007.1.11
            //model.BakMedicalSpec = Convert.ToString((Convert.ToInt32(reader["middle_stand_rate"].ToString()) * Convert.ToInt32(reader["big_middle_rate"].ToString())));
            //model.BigMiddleRate = reader["middle_stand_rate"].ToString() + "/" +Convert.ToString((Convert.ToInt32(reader["middle_stand_rate"].ToString()) * Convert.ToInt32(reader["big_middle_rate"].ToString())));
            //end modify by gaoyuan 2007.1.11
            //model.BakMassAssignment = reader["bak_mass_assignment"].ToString();
            //model.ReadyFlag = string.IsNullOrEmpty(reader["ready_flag"].ToString()) ? "0" : reader["ready_flag"].ToString();
            //model.ReadyQty = reader["ready_qty"].ToString();
            //model.WrapName = dao.getWrapName(reader["product_id"].ToString());
            //model.RequestTotal = reader["request_total"].ToString();

            if (model.OrderItemState.Equals("6"))
            {
                model.CheckBoxShow = "0";
            }

            else
            {
                model.CheckBoxShow = "1";
            }
            return model;
        }


        /// <summary>
        /// 设置检索结果对象
        /// </summary>
        /// <param name="reader">记录集合</param>
        /// <returns>检索结果对象</returns>
        private SalerOrderItemModel MapSalerOrderItem1(IDataReader reader)
        {
            SalerOrderItemModel model = new SalerOrderItemModel();

            model.BuyerDesc = reader["receiveremark"].ToString();
            model.UnitPrice = reader["provide_price"].ToString();
            model.BakMedicalName = reader["medicalname"].ToString();
            model.BakProductName = reader["tradename"].ToString();
            model.BakFactoryEasy = reader["factoryshortname"].ToString();
            model.BakFactoryName = reader["factoryfullname"].ToString();
            model.RequestQty = reader["requestqty"].ToString();
            model.BakProductSpec = reader["ggbz"].ToString();
            model.OrderStateName = reader["itemstatus"].ToString();
            model.OrderType = reader["ordertype"].ToString();

            //model.RecordId = reader["record_id"].ToString();
            //model.ProductId = reader["product_id"].ToString();
            //model.OrderId = reader["order_id"].ToString();
            //model.OrderItemState = reader["item_status"].ToString();
            //model.PlatId = reader["plat_id"].ToString();
            //model.DegreeFlag = reader["degree_flag"].ToString();
            //model.BuyerOrgid = reader["buyer_orgid"].ToString();
            //model.BakBuyerName = reader["bakBuyerName"].ToString();
            //model.SalerOrgid = reader["saler_orgid"].ToString();
            //model.SenderOrgid = reader["sender_orgid"].ToString();
            //model.AgentOrgid = reader["agent_orgid"].ToString();
            //model.BakMedicalId = reader["bak_medical_id"].ToString();
            //model.BakMedicalMode = reader["bak_medical_mode"].ToString();
            //model.ProductId = reader["product_id"].ToString();
            //model.BakProductBidWay = reader["bak_product_bid_way"].ToString();
            //model.BakFactoryId = reader["bak_factory_id"].ToString();
            //model.MetricName = reader["metric_name"].ToString();
            //model.ReceiveQty = reader["receive_qty"].ToString();
            //model.SourceType = reader["source_type"].ToString();
            //model.SourceProjectId = reader["source_project_id"].ToString();
            //model.BakMedicalSpec = reader["bak_medical_spec"].ToString();
            //model.MiddleStandRate = reader["middle_stand_rate"].ToString();
            //start modify by gaoyuan 2007.1.11
            //model.BakMedicalSpec = Convert.ToString((Convert.ToInt32(reader["middle_stand_rate"].ToString()) * Convert.ToInt32(reader["big_middle_rate"].ToString())));
            //model.BigMiddleRate = reader["middle_stand_rate"].ToString() + "/" +Convert.ToString((Convert.ToInt32(reader["middle_stand_rate"].ToString()) * Convert.ToInt32(reader["big_middle_rate"].ToString())));
            //end modify by gaoyuan 2007.1.11
            //model.BakMassAssignment = reader["bak_mass_assignment"].ToString();
            //model.ReadyFlag = string.IsNullOrEmpty(reader["ready_flag"].ToString()) ? "0" : reader["ready_flag"].ToString();
            //model.ReadyQty = reader["ready_qty"].ToString();
            //model.RepositoryName = reader["warehouse_name"].ToString();
            //model.WrapName = dao.getWrapName(reader["product_id"].ToString());
            //model.RequestTotal = reader["request_total"].ToString();
            //model.RepositoryId = reader["repository_id"].ToString();
            //model.MaxQty = reader["maxQty"].ToString();

            return model;
        }

        /// <summary>
        /// 备货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="remark"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ReceiveOrder(IList result, string remark, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            return dao.ReceiveOrder(result, remark, ui);
        }

        /// <summary>
        /// 缺货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool OrderLack(IList result,  Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            return dao.OrderLack(result, ui);
        }

        /// <summary>
        /// 取消缺货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool OrderCancelLack(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            return dao.OrderCancelLack(result,ui);
        }

        /// <summary>
        /// 确认发货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ConfirmOrderReceive(IList result,  Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            return dao.ConfirmOrderReceive(result, ui);
        }

        /// <summary>
        /// 修改发货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ModifyOrderReceive(IList result, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            return dao.ModifyOrderReceive(result, ui);
        }

        /// <summary>
        /// 撤消发货
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool DeleteOrderReceive(IList result)
        {
            return dao.DeleteOrderReceive(result);
        }

        
        /// <summary>
        /// 查询待确定和已确定的送货列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pageParam"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public IList selectOrderPrepareItemListJP(InputInfoModel input)
        {
            IDataReader reader = dao.selectOrderPrepareItemListJP(input);
            IList results = new ArrayList();
            while (reader.Read())
            {
                if (input.Received)
                    results.Add(MapOutputInfoArrived(reader));
                else
                    results.Add(MapOutputInfo(reader));
            }
            reader.Close();
            return results;
        }

        /// <summary>
        /// 组织MapOutputInfo实体
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private OutputInfoModel MapOutputInfo(IDataReader reader)
        {
            OutputInfoModel model = new OutputInfoModel();
            model.Saler_id = reader["saler_id"].ToString();
            model.RowNum = reader["rownum"].ToString();
            model.MaxQty = reader["maxQty"].ToString();
            model.R_ID = reader["ID"].ToString();
            model.O_RECORD_ID = reader["order_item_id"].ToString();
            model.O_ORDER_ID = reader["order_id"].ToString();

            model.R_RECEIVE_DATE = reader["ready_date"].ToString();
            model.O_BAK_MEDICAL_NAME = reader["medical_name"].ToString();
            model.O_BAK_PRODUCT_NAME = reader["trade_name"].ToString();
            model.O_BAK_PRODUCT_SPEC = reader["ggbz"].ToString();
            model.O_BAK_FACTORY_NAME = reader["factory_name"].ToString();
            model.O_UNIT_PRICE = reader["provide_price"].ToString();
            model.O_REQUEST_QTY = reader["request_qty"].ToString();
            model.O_RECEIVE_QTY = reader["stockup_qty"].ToString();

            model.LOT_NO = reader["lot_no"].ToString();
            model.RECEIVE_QTY = reader["stockup_qty"].ToString();
            model.Buyer_Remark = reader["buyer_remark"].ToString();
            model.ReceiveFlag = reader["ready_flag"].ToString();
            model.R_invoice_no = reader["invoice_no"].ToString();
            model.R_invoice_total = reader["amount"].ToString();
            model.R_invoice_trade_price = reader["trade_price"].ToString();
            model.R_invoice_retail_price = reader["retail_price"].ToString();
            model.R_invoice_discount_rate = reader["discount"].ToString();
            model.R_invoice_date = reader["invoice_date"].ToString();
            model.R_invoice_expire_date = reader["invoice_expire_date"].ToString();
            model.R_ready_remark = reader["remark"].ToString();
            model.ItemState = reader["item_status"].ToString();
            model.ItemStateName = reader["status"].ToString();
            return model;
        }

        /// <summary>
        /// 组织MapOutputInfoArrived实体
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private OutputInfoModel MapOutputInfoArrived(IDataReader reader)
        {
            OutputInfoModel model = new OutputInfoModel();
            model.RowNum = reader["rownum"].ToString();

            model.R_RECEIVE_DATE = reader["receivedate"].ToString();
            model.O_BAK_MEDICAL_NAME = reader["medicalname"].ToString();
            model.O_BAK_PRODUCT_NAME = reader["tradename"].ToString();
            model.O_BAK_PRODUCT_SPEC = reader["ggbz"].ToString();
            model.O_BAK_FACTORY_NAME = reader["factoryshortname"].ToString();
            model.O_UNIT_PRICE = reader["provideprice"].ToString();
            model.O_REQUEST_QTY = reader["requestqty"].ToString();
            model.O_RECEIVE_QTY = reader["receiveqty"].ToString();

            model.LOT_NO = reader["sendlot"].ToString();
            model.RECEIVE_QTY = reader["receiveqty"].ToString();
            model.Buyer_Remark = reader["buyerremark"].ToString();
            model.R_invoice_no = reader["invoiceno"].ToString();
            model.R_invoice_date = reader["invoicedate"].ToString();

            //model.ReceiveFlag = reader["ready_flag"].ToString();
            //model.R_invoice_total = reader["amount"].ToString();
            //model.R_invoice_trade_price = reader["trade_price"].ToString();
            //model.R_invoice_retail_price = reader["retail_price"].ToString();
            //model.R_invoice_discount_rate = reader["discount"].ToString();
            //model.R_invoice_expire_date = reader["invoice_expire_date"].ToString();
            //model.R_ready_remark = reader["remark"].ToString();
            //model.ItemState = reader["item_status"].ToString();
            //model.ItemStateName = reader["status"].ToString();
            return model;
        }


        /// <summary>
        /// 取得订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public SalerOrderModel GetOrderTitle(string orderId)
        {
            return dao.GetOrderTitle(orderId);
        }

        /// <summary>
        /// 判断同一个企业的备货发票是否有重复 有重复返回true
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public bool IsInvoiceExists(IList resultList)
        {
            return dao.IsInvoiceExists(resultList);
        }
     
    }
}
