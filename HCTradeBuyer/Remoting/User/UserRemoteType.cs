#region Header
/*****************************************************************************
 *  * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/Remoting/User/UserRemoteType.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 4 $
 * $History: UserRemoteType.cs $
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-08-25   Time: 11:18
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Remoting/User
 * 添加异常捕获
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:36
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Remoting/User
 * $Date: 06-08-25 11:18 $
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Emedchina.TradeAssistant.BLL.User;
using Emedchina.TradeAssistant.Model.User;
#endregion

namespace Emedchina.TradeAssistant.Remoting.User
{
    /// <summary>
    /// 负责用户登录的远程处理类.
    /// </summary>
    public class UserRemoteType : MarshalByRefObject
    {
        /// <summary>
        /// Does the login.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="password">The password.</param>
        /// <param name="isEncrypt">if set to <c>true</c> [is encrypt].</param>
        /// <returns></returns>
        public LogedInUser DoLogin(string userCode, string password, bool isEncrypt)
        {
            LogedInUser user;
            try
            {
                user = LoginBLL.GetInstance().LogIn(userCode, password, isEncrypt);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                EventLog.WriteEntry("UserRemoteType:DoLogin", e.StackTrace);
                throw e;
            }
        }

        /// <summary>
        /// Does the login.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public LogedInUser DoLogin(string userCode, string password)
        {
            return LoginBLL.GetInstance().LogIn(userCode, password, false);
        }

        /// <summary>
        /// 取得高位客户端id
        /// </summary>
        /// <returns></returns>
        public string GetHighId()
        {
            return new GetHighIdBLL().GetHighID();
        }
    }
}
