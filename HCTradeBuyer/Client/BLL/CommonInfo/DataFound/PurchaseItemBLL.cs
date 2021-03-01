//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	PurchaseItemBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	采购商品查询（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 采购商品查询（业务操作类）
    /// </summary>
    class PurchaseItemBLL
    {
        PurchaseItemDao dao = null;

        private PurchaseItemBLL()
        {
            dao = PurchaseItemDao.GetInstance();
        }

        public static PurchaseItemBLL GetInstance()
        {
            return new PurchaseItemBLL();
        }

        private PurchaseItemBLL(string connectionName)
        {
            dao = PurchaseItemDao.GetInstance(connectionName);
        }

        public static PurchaseItemBLL GetInstance(String strConnectionn)
        {
            return new PurchaseItemBLL(strConnectionn);
        }

        /// <summary>
        /// 获取采购商品列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPurchaseItemDt()
        {
            try
            {
                return dao.GetPurchaseItemDt();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
