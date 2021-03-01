#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler/ProxyFactory.cs 14    06-09-14 16:42 Caojie $ 
 * $Author: Caojie $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 14 $
 * $History: ProxyFactory.cs $
 * 
 * *****************  Version 14  *****************
 * User: Caojie       Date: 06-09-14   Time: 16:42
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 12  *****************
 * User: Sunhl        Date: 06-09-04   Time: 15:53
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 11  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:07
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 修改增量缓存
 * 
 * *****************  Version 10  *****************
 * User: Sunhl        Date: 06-08-25   Time: 11:11
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 9  *****************
 * User: Liangxy      Date: 06-07-13   Time: 14:40
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 8  *****************
 * User: Sunhl        Date: 06-06-29   Time: 13:54
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 修改用户登录部分为使用远程对象
 * 
 * *****************  Version 7  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-27   Time: 14:50
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 5  *****************
 * User: Sunhl        Date: 06-06-27   Time: 14:12
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-24   Time: 14:47
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:37
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Configuration;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

using Emedchina.TradeAssistant.Remoting.User;
using Emedchina.TradeAssistant.Model;
using Emedchina.TradeAssistant.Remoting.Sync;

#endregion

namespace Emedchina.TradeAssistant.Client
{
    /// <summary>
    /// 代理工厂类
    /// </summary>
    class ProxyFactory
    {

        private static readonly StringDictionary URLCACHE = new StringDictionary();
        private static readonly string PROTOCOL = "tcp";

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ProxyFactory()
        {
            //RemotingConfiguration.Configure("TradeAssistantSaler.exe.config", false);
            //BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            //provider.TypeFilterLevel = TypeFilterLevel.Full;
            //IDictionary props = new Hashtable();
            //props["port"] = MachinePort;

            //ChannelServices.RegisterChannel(new TcpChannel(props, null, provider), false);
            //ChannelServices.RegisterChannel(new TcpChannel(props, null, provider), false);
            RemotingConfiguration.Configure("Client.exe.config", false);
        }

        /// <summary>
        /// Creates the proxy.
        /// </summary>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyName">Name of the proxy.</param>
        /// <returns></returns>
        public static Object CreateProxy(Type proxyType, string proxyName)
        {
            string url = GetCachedUrl(proxyName);
            return Activator.GetObject(proxyType, url);
        }

        #region private
        /// <summary>
        /// Gets the name of the machine.
        /// </summary>
        /// <value>The name of the machine.</value>
        private static string MachineName
        {
            get
            {
                string machine = ClientConfiguration.RemoteMachine;
                if (string.IsNullOrEmpty(machine))
                    return "localhost";
                else
                    return machine;
            }
        }

        /// <summary>
        /// Gets the machine port.
        /// </summary>
        /// <value>The machine port.</value>
        private static string MachinePort
        {
            get
            {
                string port = ClientConfiguration.RemotePort;
                if (string.IsNullOrEmpty(port))
                    return "8088";
                else
                    return port;
            }
        }

        /// <summary>
        /// Gets the cached URL.
        /// </summary>
        /// <param name="proxyName">Name of the proxy.</param>
        /// <returns></returns>
        private static string GetCachedUrl(string proxyName)
        {
            //string url = URLCACHE[proxyName];
            //if (string.IsNullOrEmpty(url))
            //{
            //    url = string.Format("{0}://{1}:{2}/{3}", PROTOCOL, MachineName, MachinePort, proxyName);
            //    URLCACHE[proxyName] = url;
            //}
            string url = string.Format("{0}://{1}:{2}/{3}", PROTOCOL, MachineName, MachinePort, proxyName);
            return url;
        }
        #endregion

        #region useful
        /// <summary>
        /// Resets this instance.
        /// </summary>
        public static void Reset()
        {
            URLCACHE.Clear();
        }
        #endregion

        #region Remoting Proxy Create

        /// <summary>
        /// Gets the user proxy.
        /// </summary>
        /// <value>The user proxy.</value>
        public static UserRemoteType UserProxy
        {
            get
            {
                return CreateProxy(typeof(UserRemoteType), "UserRemoteType.rem") as UserRemoteType;
                //return new UserRemoteType();
            }
        }


        /// <summary>
        /// Gets the UploadRemote proxy.
        /// </summary>
        /// <value>The UploadRemote proxy.</value>
        public static UploadRemote UploadRemote
        {
            get
            {
                return CreateProxy(typeof(UploadRemote), "UploadRemote.rem") as UploadRemote;
            }
        }


        /// <summary>
        /// Gets the purchase save proxy.
        /// </summary>
        /// <value>The purchase save proxy.</value>
        public static SyncDataRemote SyncDataProxy
        {
            get
            {
                return CreateProxy(typeof(SyncDataRemote), "SyncDataRemote.rem") as SyncDataRemote;
            }
        }
        #endregion

    }
}
