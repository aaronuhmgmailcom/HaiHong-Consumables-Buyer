//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerOrderRemote.cs  
//	创 建 人:	曹杰
//	创建日期:	2007-1-18
//	功能描述:	订单处理Remoting文件
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.TradeAssistant.BLL.Order.SalerOrder;

namespace Emedchina.TradeAssistant.Remoting.Order.SalerOrder
{
    public class SalerOrderRemote : MarshalByRefObject
    {
        /// <summary>
        /// 取得订单列表数据
        /// </summary>
        public DataTable getSalerOrderList(SalerOrderListModel model, out int rows)
        {
            return SalerOrderBLL.GetInstance().getSalerOrderList(model, out rows);
        }
        /// <summary>
        /// Gets the SalerOrderModel
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        //public SalerOrderModel GetOrderById(string orderId, string userId)
        //{
        //    //return SalerOrderBLL.GetInstance().GetOrderById(orderId, userId);
        //}
        /// <summary>
        /// 取得订单明细列表数据
        /// </summary>
        public IList GetSalerOrderItemList(string orderId, string userName, string userId, bool flag)
        {
            return SalerOrderBLL.GetInstance().GetSalerOrderItemList(orderId,userName,userId,flag);
        }

        /// <summary>
        /// 取得订单明细列表数据
        /// </summary>
        public IList GetSalerOrderItemList(string orderId)
        {
            return SalerOrderBLL.GetInstance().GetSalerOrderItemList(orderId);
        }

        /// <summary>
        /// 备货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="remark"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ReceiveOrder(IList result, string remark, Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            try
            {
                return SalerOrderBLL.GetInstance().ReceiveOrder(result, remark, ui);
            }
            catch (Exception x)
            {
                throw x;
                return false;
            }
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
            
            try
            {
                return SalerOrderBLL.GetInstance().OrderLack(result, ui);
            }
            catch (Exception x)
            {
                throw x;
                return false;
            }
        }
        /// <summary>
        /// 取消缺货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool OrderCancelLack(IList result,  Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {
            
            try
            {
                return SalerOrderBLL.GetInstance().OrderCancelLack(result, ui);
            }
            catch (Exception x)
            {
                throw x;
                return false;
            }
        }
        /// <summary>
        /// 确认发货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ConfirmOrderReceive(IList result,  Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {

            try
            {
                return SalerOrderBLL.GetInstance().ConfirmOrderReceive(result,ui);
            }
            catch (Exception x)
            {
                throw x;
                return false;
            }
        }
        /// <summary>
        /// 修改发货信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool ModifyOrderReceive(IList result,  Emedchina.TradeAssistant.Model.User.UserInfo ui)
        {

            try
            {
                return SalerOrderBLL.GetInstance().ModifyOrderReceive(result, ui);
            }
            catch (Exception x)
            {
                throw x;
                return false;
            }
        }
        /// <summary>
        /// 撤消发货
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool DeleteOrderReceive(IList result)
        {

            try
            {
                return SalerOrderBLL.GetInstance().DeleteOrderReceive(result);
            }
            catch (Exception x)
            {
                throw x;
                return false;
            }
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
            return SalerOrderBLL.GetInstance().selectOrderPrepareItemListJP(input);
        }


        /// <summary>
        /// 取得订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public SalerOrderModel GetOrderTitle(string orderId)
        {
            return SalerOrderBLL.GetInstance().GetOrderTitle(orderId);
        }

        /// <summary>
        /// 判断同一个企业的备货发票是否有重复 有重复返回true
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public bool IsInvoiceExists(IList resultList)
        {
            return SalerOrderBLL.GetInstance().IsInvoiceExists(resultList);
        }

        #region 新增加"导出基础信息"功能("进销存"企业对接功能)，shangfu 2007-8-28

        public DataTable GetProductInfo(string buyerorgid)
        {
            return ExpBaseInfoBLL.GetInstance().GetProductInfo(buyerorgid);
        }


        public DataTable GetBuyerInfo(string buyerOrgid)
        {
            return ExpBaseInfoBLL.GetInstance().GetBuyerInfo(buyerOrgid);
        }

        public DataTable GetEnterpriseInfo(string buyerOrgid)
        {
            return ExpBaseInfoBLL.GetInstance().GetEnterpriseInfo(buyerOrgid);
        }

        #endregion

    }
}
