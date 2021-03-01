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
    /// 简化Debug日志的使用
    /// 日志的一般使用模式是：
    /// <c>
    ///        if (log.IsDebugEnabled)
    ///        {
    ///             log.Debug(message,e);
    ///        }
    /// </c>
    /// 这样是为了减少日志开销，对于log4net尤其重要。
    /// 不过这样的代码参杂在应用逻辑中会降低代码的可读性。同时也增加了代码量。
    /// 所以做了如下封装。应用中需要自己为相应的类或方法构造ILog实例log，并将log和要记录的日志message和/或Exception同时提供给LoggingUtils对应级别的方法。
    /// </summary>
    /// <author>Sunhl</author>
    /// <remarks>
    /// 注意，该方法不适合在需要输出所在的文件名，方法名和方法所在的类名及方法所在的行的地方，所以要谨慎使用。
    /// </remarks>
    public class DebugUtils
    {
        private static BindingFlags BINDING_FLAGS_SET
                = BindingFlags.Public
                | BindingFlags.SetProperty
                | BindingFlags.Instance
                | BindingFlags.SetField
                ;
        //todo  从配置文件读取。
        private static readonly bool RELEASE = false;

        /// <summary>
        /// 简化Debug日志功能的实现
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
        /// 简化Debug日志功能的实现
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
        /// 通过log服务，打印一个对象的所有的属性信息。
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
        /// 通过log服务，打印一个对象列表中的所有对象的属性信息。
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
        /// 打印DataTable中的记录信息
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
        /// 打印DataSet中的内容。
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
        /// 将IDataReader的内容打印到Console上。
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
                        //循环从IDataReader中读取列名作为key，读取列值作为value。
                        log.Debug(string.Format("columnName is:{0}, Value is:{1}.", reader.GetName(i), reader.GetValue(i)));
                    }
                    log.Debug(Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// 打印IDictionary的所有键和值到System.Console.
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
