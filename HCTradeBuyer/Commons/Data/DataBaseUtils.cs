#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data/DataBaseUtils.cs 3     06-06-27 11:08 Sunhl $
 * $Author: Sunhl $
 * $Revision: 3 $
 * $Date: 06-06-27 11:08 $
 * $History: DataBaseUtils.cs $
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-27   Time: 11:08
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;

using Emedchina.Commons;

using IBatisNet.Common.Logging;

#endregion

namespace Emedchina.Commons.Data
{
    /// <summary>
    /// 提供了ado.net通用功能的封装,包括连接管理,参数缓存等
    /// 此类是环境无关的，同时提供的静态方法没有进行同步，在多线程环境中使用要小心处理线程问题。
    /// </summary>
    /// <author>Sunhl</author>
    /// <version>$Id: DAOUtils.cs,v 1.2 2006/02/21 08:57:06 sunhl Exp $</version>
    public class DataBaseUtils
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region 参数缓存
        ///参数缓存可以一定程度上减少参数创建的开销。现在的缓存用Hashtable做池，并且没有有效的过期处理。
        ///@todo 增加过期策略，例如lru，fifo等。

        //同步化的Hashtable，作为缓存池。
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 将构造好的命令参数添加入缓存。
        /// </summary>
        /// <param name="cacheKey">键值</param>
        /// <param name="cmdParms">缓存的IDbDataParameter数组</param>
        public static void CacheParameters(string cacheKey, params IDbDataParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// 根据键值取缓存的IDbDataParameters
        /// </summary>
        /// <param name="cacheKey">提供用于缓存的键值</param>
        /// <returns></returns>
        public static IDbDataParameter[] GetCachedParameters(string cacheKey)
        {
            IDbDataParameter[] cachedParms = (IDbDataParameter[])parmCache[cacheKey];

            //如果原先没有缓存，直接返回null
            if (cachedParms == null)
                return null;

            // 参数原先被缓存
            IDbDataParameter[] clonedParms = new IDbDataParameter[cachedParms.Length];

            // 这里通过clone返回缓存中的参数，因为缓存中的参数是同步的，而且可能多次应用。
            //否则有可能出现这种情况，你在多个地方通过缓存多次取了同一缓存的参数，如果不是clone，而且用户自己没有clone，则在一个地方改变，会同时影响到所有使用该参数的地方。
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (IDbDataParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region 连接管理
        /// <summary>
        /// 如果<see cref="IDbConnection"/>的状态不为ConnectionState.Open则试图打开该连接.
        /// 建议使用DataBaseFacade中的OpenConnetion创建并打开连接。
        /// </summary>
        /// <param name="conn"></param>
        /// <exception cref="Emedchina.Commons.Data.DataAcessException">
        /// 如果打开失败,则抛出EmedADOException异常. 
        ///</exception>
        public static void OpenConnetion(IDbConnection conn)
        {
            if (conn != null)
            {
                if (conn.State != ConnectionState.Open)
                {

                    try
                    {
                        conn.Open();
                    }
                    catch (Exception e)
                    {
                        if (_log.IsWarnEnabled)
                        {
                            _log.Warn("Could not open " + conn.GetType().ToString() + " connection", e);
                        }
                        throw new DataAcessException("Could not open " + conn.GetType().ToString() + " connection", e);
                    }
                }
            }
        }


        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <param name="conn">The conn.</param>
        /// <exception cref="Emedchina.Commons.Data.DataAcessException">
        /// 如果打开失败,则抛出EmedADOException异常. 
        /// </exception>
        public static void CloseConnection(IDbConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception e)
                {
                    if (_log.IsWarnEnabled)
                    {
                        _log.Warn("Could not close " + conn.GetType().ToString() + " connection", e);
                    }
                }
            }
        }
        #endregion

        #region reader

        /// <summary>
        /// 关闭DataReader,忽略产生的异常.
        /// 该方法主要用于在finally块中手工关闭DataReader时.
        /// </summary>
        /// <param name="reader">要关闭的reader</param>
        public static void CloseDataReader(IDataReader reader)
        {
            if (reader != null)
            {
                try
                {
                    reader.Close();
                }
                catch (Exception ex)
                {
                    if (_log.IsWarnEnabled)
                    {
                        _log.Warn("Could not close IDataReader", ex);
                    }
                }
            }
        }

        #endregion
    }
}
