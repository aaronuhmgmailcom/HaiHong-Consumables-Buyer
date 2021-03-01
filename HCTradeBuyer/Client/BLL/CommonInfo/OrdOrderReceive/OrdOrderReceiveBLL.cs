//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdOrderReceiveBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	到货单（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 到货单（业务操作类）
    /// </summary>
    class OrdOrderReceiveBLL : SqlDAOBase
    {
        OrdOrderReceiveDao dao = null;

        private OrdOrderReceiveBLL()
        {
            dao = OrdOrderReceiveDao.GetInstance();
        }

        public static OrdOrderReceiveBLL GetInstance()
        {
            return new OrdOrderReceiveBLL();
        }

        private OrdOrderReceiveBLL(string connectionName)
        {
            dao = OrdOrderReceiveDao.GetInstance(connectionName);
        }

        public static OrdOrderReceiveBLL GetInstance(String strConnectionn)
        {
            return new OrdOrderReceiveBLL(strConnectionn);
        }


    }
}
