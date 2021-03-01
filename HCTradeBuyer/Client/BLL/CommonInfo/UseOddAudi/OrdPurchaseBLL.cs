//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdPurchaseBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	采购单(业务操作类)
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 采购单(业务操作类)
    /// </summary> 
    class OrdPurchaseBLL
    {
        OrdPurchaseDao dao = null;

        private OrdPurchaseBLL()
        {
            dao = OrdPurchaseDao.GetInstance();
        }

        public static OrdPurchaseBLL GetInstance()
        {
            return new OrdPurchaseBLL();
        }

        private OrdPurchaseBLL(string connectionName)
        {
            dao = OrdPurchaseDao.GetInstance(connectionName);
        }

        public static OrdPurchaseBLL GetInstance(String strConnectionn)
        {
            return new OrdPurchaseBLL(strConnectionn);
        }
    }
}
