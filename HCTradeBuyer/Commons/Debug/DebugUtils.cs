#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/Debug/DebugUtils.cs 3     06-08-24 11:25 Sunhl $
 * $Author: Sunhl $Revision: 2.0 $
 * $Date: 06-08-24 11:25 $
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Data;
using System.Reflection;

using IBatisNet.Common.Logging;
#endregion

namespace Emedchina.Commons.Debug
{
    /// <summary>
    /// ��Debug��־��ʹ��
    /// ��־��һ��ʹ��ģʽ�ǣ�
    /// <c>
    ///        if (log.IsDebugEnabled)
    ///        {
    ///             log.Debug(message,e);
    ///        }
    /// </c>
    /// ������Ϊ�˼�����־����������log4net������Ҫ��
    /// ���������Ĵ��������Ӧ���߼��лή�ʹ���Ŀɶ��ԡ�ͬʱҲ�����˴�������
    /// �����������·�װ��Ӧ������Ҫ�Լ�Ϊ��Ӧ����򷽷�����ILogʵ��log������log��Ҫ��¼����־message��/��Exceptionͬʱ�ṩ��LoggingUtils��Ӧ����ķ�����
    /// </summary>
    /// <author>Sunhl</author>
    /// <remarks>
    /// ע�⣬�÷������ʺ�����Ҫ������ڵ��ļ������������ͷ������ڵ��������������ڵ��еĵط�������Ҫ����ʹ�á�
    /// </remarks>
    public class DebugUtils
    {
        private static BindingFlags BINDING_FLAGS_SET
                = BindingFlags.Public
                | BindingFlags.SetProperty
                | BindingFlags.Instance
                | BindingFlags.SetField
                ;
        //todo  �������ļ���ȡ��
        private static readonly bool RELEASE = false;

        /// <summary>
        /// ��Debug��־���ܵ�ʵ��
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Debug(ILog log, object message, Exception e)
        {
            if (RELEASE)
                return;
            if (log.IsDebugEnabled)
            {
                log.Debug(message, e);
            }
        }

        /// <summary>
        /// ��Debug��־���ܵ�ʵ��
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        public static void Debug(ILog log, object message)
        {
            if (RELEASE)
                return;
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }


        /// <summary>
        /// ͨ��log���񣬴�ӡһ����������е�������Ϣ��
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="obj">The obj.</param>
        public static void DebugObjectInfo(ILog log, object obj)
        {
            if (RELEASE)
                return;
            if (log.IsDebugEnabled)
            {
                log.Debug(string.Format("properties of the :{0}", obj.GetType()));
                foreach (PropertyInfo info in obj.GetType().GetProperties(BINDING_FLAGS_SET))
                {
                    log.Debug(string.Format("{0}:{1}", info.Name, info.GetValue(obj, null)));
                }
                log.Debug(Environment.NewLine);
            }

        }

        /// <summary>
        /// Debugs the object list.
        /// ͨ��log���񣬴�ӡһ�������б��е����ж����������Ϣ��
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="objs">The objs.</param>
        public static void DebugObjectList(ILog log, IEnumerable objs)
        {
            if (RELEASE)
                return;
            foreach (object o in objs)
            {
                DebugObjectInfo(log, o);
            }

        }

        /// <summary>
        /// ��ӡDataTable�еļ�¼��Ϣ
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="table">The table.</param>
        public static void DebugTableInfo(ILog log, DataTable table)
        {
            if (RELEASE)
                return;
            if (log.IsDebugEnabled)
            {
                DataRow[] currRows = table.Select(null, null, DataViewRowState.CurrentRows);

                if (currRows.Length < 1)
                    log.Debug("No Current Rows Found");
                else
                {
                    foreach (DataColumn myCol in table.Columns)
                        log.Debug(string.Format("\t{0}", myCol.ColumnName));

                    log.Debug("\tRowState");

                    foreach (DataRow myRow in currRows)
                    {
                        foreach (DataColumn myCol in table.Columns)
                            log.Debug(string.Format("\t{0}", myRow[myCol]));

                        log.Debug("\t" + myRow.RowState);
                    }
                }
                log.Debug(Environment.NewLine);
            }
        }

        /// <summary>
        /// ��ӡDataSet�е����ݡ�
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="ds">The ds.</param>
        public static void DebugDataSetInfo(ILog log, DataSet ds)
        {
            if (RELEASE)
                return;
            foreach (DataTable table in ds.Tables)
            {
                DebugTableInfo(log, table);
            }
        }

        /// <summary>
        /// ��IDataReader�����ݴ�ӡ��Console�ϡ�
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="reader">The reader.</param>
        public static void DebugReader(ILog log, IDataReader reader)
        {
            if (RELEASE)
                return;
            if (log.IsDebugEnabled)
            {
                log.Debug(string.Format("Field count is:{0}.", reader.FieldCount));
                log.Debug("contents:");

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //ѭ����IDataReader�ж�ȡ������Ϊkey����ȡ��ֵ��Ϊvalue��
                        log.Debug(string.Format("columnName is:{0}, Value is:{1}.", reader.GetName(i), reader.GetValue(i)));
                    }
                    log.Debug(Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// ��ӡIDictionary�����м���ֵ��System.Console.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="map">The map.</param>
        public static void DebugMap(ILog log, IDictionary map)
        {
            if (RELEASE)
                return;
            if (log.IsDebugEnabled)
            {
                foreach (object key in map.Keys)
                {
                    object value = map[key];
                    log.Debug(string.Format("key={0};value={1}", key, value));
                }
            }
        }
    }
}
