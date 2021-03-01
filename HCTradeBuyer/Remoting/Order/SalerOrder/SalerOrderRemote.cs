//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	SalerOrderRemote.cs  
//	�� �� ��:	�ܽ�
//	��������:	2007-1-18
//	��������:	��������Remoting�ļ�
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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
        /// ȡ�ö����б�����
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
        /// ȡ�ö�����ϸ�б�����
        /// </summary>
        public IList GetSalerOrderItemList(string orderId, string userName, string userId, bool flag)
        {
            return SalerOrderBLL.GetInstance().GetSalerOrderItemList(orderId,userName,userId,flag);
        }

        /// <summary>
        /// ȡ�ö�����ϸ�б�����
        /// </summary>
        public IList GetSalerOrderItemList(string orderId)
        {
            return SalerOrderBLL.GetInstance().GetSalerOrderItemList(orderId);
        }

        /// <summary>
        /// ����
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
        /// ȱ��
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
        /// ȡ��ȱ��
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
        /// ȷ�Ϸ���
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
        /// �޸ķ�����Ϣ
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
        /// ��������
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
        /// ��ѯ��ȷ������ȷ�����ͻ��б�
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
        /// ȡ�ö�����Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public SalerOrderModel GetOrderTitle(string orderId)
        {
            return SalerOrderBLL.GetInstance().GetOrderTitle(orderId);
        }

        /// <summary>
        /// �ж�ͬһ����ҵ�ı�����Ʊ�Ƿ����ظ� ���ظ�����true
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public bool IsInvoiceExists(IList resultList)
        {
            return SalerOrderBLL.GetInstance().IsInvoiceExists(resultList);
        }

        #region ������"����������Ϣ"����("������"��ҵ�Խӹ���)��shangfu 2007-8-28

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
