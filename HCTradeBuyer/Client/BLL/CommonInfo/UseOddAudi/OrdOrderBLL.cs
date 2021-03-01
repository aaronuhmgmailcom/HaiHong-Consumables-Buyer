//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdOrderBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	订单(业务操作类)
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
    /// 订单(业务操作类)
    /// </summary>
    class OrdOrderBLL
    {
        OrdOrderDao dao = null;

        private OrdOrderBLL()
        {
            dao = OrdOrderDao.GetInstance();
        }

        public static OrdOrderBLL GetInstance()
        {
            return new OrdOrderBLL();
        }

        private OrdOrderBLL(string connectionName)
        {
            dao = OrdOrderDao.GetInstance(connectionName);
        }

        public static OrdOrderBLL GetInstance(String strConnectionn)
        {
            return new OrdOrderBLL(strConnectionn);
        }


    }
}
