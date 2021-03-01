#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /ZjTradeAssistant/DAL/Org/OrgDAO.cs 1     06-08-23 17:17 Panyj $ 
 * $Author: Panyj $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 1 $
 * $Date: 06-08-23 17:17 $
 * $History: OrgDAO.cs $
 * 
 * *****************  Version 1  *****************
 * User: Panyj        Date: 06-08-23   Time: 17:17
 * Created in $/ZjTradeAssistant/DAL/Org
 * 
 * *****************  Version 1  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:49
 * Created in $/TradeAssistant.root/TradeAssistant/DAL/Org
 ********************************************************************************/
#endregion

#region using
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model;
using Emedchina.TradeAssistant.Model.Org;
#endregion

namespace Emedchina.TradeAssistant.DAL.Org
{
    /// <summary>
    /// 
    /// </summary>   
    public class OrgDAO : OracleDAOBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrgDAO"/> class.
        /// </summary>
        private OrgDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OrgDAO"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private OrgDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static OrgDAO GetInstance()
        {
            return new OrgDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static OrgDAO GetInstance(string connectionName)
        {
            return new OrgDAO(connectionName);
        }

    }
}
