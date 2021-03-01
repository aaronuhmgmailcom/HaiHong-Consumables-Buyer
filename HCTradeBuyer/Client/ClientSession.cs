#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/ClientSession.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 4 $
 * $History: ClientSession.cs $
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-24   Time: 16:11
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-24   Time: 15:22
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:38
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.BLL.User;
using Emedchina.TradeAssistant.Model.User;
#endregion

namespace Emedchina.TradeAssistant.Client
{
    /// <summary>
    /// ClientSession用于保存客户端登录后的会话信息，用户需要的全局信息都可以放在该类内。保存的最常见的信息包括
    /// 登录后的用户信息，根据业务需要，新的属性可以添加入该类。
    /// 用户登录成功后，从服务器返回的LogedInUser对象会放入.
    /// 通过静态方法GetInstance获取该类的单例实例。
    /// </summary>
    public class ClientSession
    {
        private static ClientSession _session = null;
        private static Hashtable sessionEntries = new Hashtable();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClientSession"/> class.
        /// </summary>
        private ClientSession()
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ClientSession GetInstance()
        {
            if (_session == null)
                _session = new ClientSession();
            return _session;
        }

        LogedInUser user = null;

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>The current user.</value>
        public LogedInUser CurrentUser
        {
            get
            {
                if (user == null)
                    throw new ApplicationException("没有用户登录信息,请首先登录.");
                return user;
            }
            set { user = value; }
        }


        /// <summary>
        /// Gets or sets the <see cref="T:Object"/> with the specified key.
        /// 用于存取全局对象和全局信息.
        /// </summary>
        /// <value></value>
        public Object this[Object key]
        {
            get { return sessionEntries[key]; }
            set { sessionEntries[key] = value; }
        }

        /// <summary>
        /// Logs the out.
        /// </summary>
        public void LogOut()
        {
            Reset();
        }

        /// <summary>
        /// Resets this instance.
        /// 将当前session置null，并清空保存的所有内容。
        /// </summary>
        public void Reset()
        {
            sessionEntries.Clear();
            CurrentUser = null;
            _session = null;
        }

        private bool isLogin;

        public bool IsLogin
        {
            get { return isLogin; }
            set { isLogin = value; }
        }
    }
}
