//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdInvoiceBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	发货单确认（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 发货单确认（业务操作类）
    /// </summary>
    class OrdInvoiceBLL
    {
        OrdInvoiceDao dao = null;

        private OrdInvoiceBLL()
        {
            dao = OrdInvoiceDao.GetInstance();
        }

        public static OrdInvoiceBLL GetInstance()
        {
            return new OrdInvoiceBLL();
        }

        private OrdInvoiceBLL(string connectionName)
        {
            dao = OrdInvoiceDao.GetInstance(connectionName);
        }

        public static OrdInvoiceBLL GetInstance(String strConnectionn)
        {
            return new OrdInvoiceBLL(strConnectionn);
        }

        /// <summary>
        /// 获取发货单信息列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdInvoiceFromList()
        {
            try
            {
                return dao.GetOrdInvoiceFromList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取发货单明细信息列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdInvoiceFromItemList(string StrInvoiceFromId)
        {
            try
            {
                return dao.GetOrdInvoiceFromItemList(StrInvoiceFromId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取发货单信息对象
        /// </summary>
        /// <param name="strOrdInvoiceFromId"></param>
        /// <returns></returns>
        public OrdInvoiceFromModel GetOrdInvoiceFromModel(string strOrdInvoiceFromId)
        {
            try
            {
                return dao.GetOrdInvoiceFromModel(strOrdInvoiceFromId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 修改发货单状态 4 作废 ，并设置发货单明细 作废
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdInvoiceFromState(OrdInvoiceFromModel model, string State, LogedInUser logedinUser)
        {
            try
            {
                dao.ModifyOrdInvoiceFromState(model, State, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改发货单明细表状态 （状态：1 未确认 2 已确认 3 作废）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdInvoiceFromItemState(List<OrdInvoiceFromItemModel> Listmodel,string StrInvoiceFromId, string State, LogedInUser logedinUser)
        {
            try
            {
                dao.ModifyOrdInvoiceFromItemState(Listmodel,StrInvoiceFromId, State, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
