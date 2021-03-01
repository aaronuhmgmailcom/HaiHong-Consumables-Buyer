#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/ClientSession.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">�����(sunhl)</a>
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
    /// ClientSession���ڱ���ͻ��˵�¼��ĻỰ��Ϣ���û���Ҫ��ȫ����Ϣ�����Է��ڸ����ڡ�������������Ϣ����
    /// ��¼����û���Ϣ������ҵ����Ҫ���µ����Կ����������ࡣ
    /// �û���¼�ɹ��󣬴ӷ��������ص�LogedInUser��������.
    /// ͨ����̬����GetInstance��ȡ����ĵ���ʵ����
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
                    throw new ApplicationException("û���û���¼��Ϣ,�����ȵ�¼.");
                return user;
            }
            set { user = value; }
        }


        /// <summary>
        /// Gets or sets the <see cref="T:Object"/> with the specified key.
        /// ���ڴ�ȡȫ�ֶ����ȫ����Ϣ.
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
        /// ����ǰsession��null������ձ�����������ݡ�
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
