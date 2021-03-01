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
    /// �ṩ��ado.netͨ�ù��ܵķ�װ,�������ӹ���,���������
    /// �����ǻ����޹صģ�ͬʱ�ṩ�ľ�̬����û�н���ͬ�����ڶ��̻߳�����ʹ��ҪС�Ĵ����߳����⡣
    /// </summary>
    /// <author>Sunhl</author>
    /// <version>$Id: DAOUtils.cs,v 1.2 2006/02/21 08:57:06 sunhl Exp $</version>
    public class DataBaseUtils
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region ��������
        ///�����������һ���̶��ϼ��ٲ��������Ŀ��������ڵĻ�����Hashtable���أ�����û����Ч�Ĺ��ڴ���
        ///@todo ���ӹ��ڲ��ԣ�����lru��fifo�ȡ�

        //ͬ������Hashtable����Ϊ����ء�
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// ������õ������������뻺�档
        /// </summary>
        /// <param name="cacheKey">��ֵ</param>
        /// <param name="cmdParms">�����IDbDataParameter����</param>
        public static void CacheParameters(string cacheKey, params IDbDataParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// ���ݼ�ֵȡ�����IDbDataParameters
        /// </summary>
        /// <param name="cacheKey">�ṩ���ڻ���ļ�ֵ</param>
        /// <returns></returns>
        public static IDbDataParameter[] GetCachedParameters(string cacheKey)
        {
            IDbDataParameter[] cachedParms = (IDbDataParameter[])parmCache[cacheKey];

            //���ԭ��û�л��棬ֱ�ӷ���null
            if (cachedParms == null)
                return null;

            // ����ԭ�ȱ�����
            IDbDataParameter[] clonedParms = new IDbDataParameter[cachedParms.Length];

            // ����ͨ��clone���ػ����еĲ�������Ϊ�����еĲ�����ͬ���ģ����ҿ��ܶ��Ӧ�á�
            //�����п��ܳ���������������ڶ���ط�ͨ��������ȡ��ͬһ����Ĳ������������clone�������û��Լ�û��clone������һ���ط��ı䣬��ͬʱӰ�쵽����ʹ�øò����ĵط���
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (IDbDataParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region ���ӹ���
        /// <summary>
        /// ���<see cref="IDbConnection"/>��״̬��ΪConnectionState.Open����ͼ�򿪸�����.
        /// ����ʹ��DataBaseFacade�е�OpenConnetion�����������ӡ�
        /// </summary>
        /// <param name="conn"></param>
        /// <exception cref="Emedchina.Commons.Data.DataAcessException">
        /// �����ʧ��,���׳�EmedADOException�쳣. 
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
        /// �����ʧ��,���׳�EmedADOException�쳣. 
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
        /// �ر�DataReader,���Բ������쳣.
        /// �÷�����Ҫ������finally�����ֹ��ر�DataReaderʱ.
        /// </summary>
        /// <param name="reader">Ҫ�رյ�reader</param>
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
