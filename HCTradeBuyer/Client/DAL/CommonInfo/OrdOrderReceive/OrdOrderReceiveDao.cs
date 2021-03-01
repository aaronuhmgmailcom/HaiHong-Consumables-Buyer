//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdOrderReceiveDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	到货单（数据访问类）
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
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 到货单（数据访问类）
    /// </summary>
    class OrdOrderReceiveDao : SqlDAOBase
    {
        private OrdOrderReceiveDao()
        : base()
        { }

        private OrdOrderReceiveDao(string connectionName)
        : base(connectionName)
        { }

        public static OrdOrderReceiveDao GetInstance()
        {
            return new OrdOrderReceiveDao();
        }

        public static OrdOrderReceiveDao GetInstance(string connectionName)
        {
            return new OrdOrderReceiveDao(connectionName);
        }
    }
}
