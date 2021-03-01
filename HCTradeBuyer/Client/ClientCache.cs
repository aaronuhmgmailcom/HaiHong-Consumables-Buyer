#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/ClientCache.cs 4     06-09-04 10:07 Sunhl $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 4 $
 * $Date: 06-09-04 10:07 $
 * $History: ClientCache.cs $
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:07
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 修改增量缓存
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-29   Time: 14:27
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 为了避免开发中可能通过直接对CachedDS赋值而清掉其他人的共享缓存,去掉了写
 * 属性.
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Emedchina.TradeAssistant.Client
{
    /// <summary>
    /// 客户端缓存
    /// </summary>
    class ClientCache
    {
        public static readonly string CACHEDDATASETNAME = "CachedDataSet";

        private static DataSet cachedDS;

        /// <summary>
        /// Gets or sets the cached DS.
        /// </summary>
        /// <value>The cached DS.</value>
        public static DataSet CachedDS
        {
            get
            {
                if (cachedDS == null)
                {
                    cachedDS = new DataSet(CACHEDDATASETNAME);
                }
                return cachedDS;
            }
            //set
            //{
            //    cachedDS = value;
            //    cachedDS.DataSetName = CACHEDDATASETNAME;
            //}
        }

        /// <summary>
        /// Gets the serialize file.
        /// </summary>
        /// <value>The serialize file.</value>
        public static string SerializeFile
        {
            get
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ClientSession.GetInstance().CurrentUser.UserInfo.Id + ".ser");
            }
        }

    }
}
