#region Header
/*****************************************************************************
 * $Header: /TradeAssistant1.2.root/TradeAssistant/Commons/Data/DataBaseFacade.cs 22    06-09-11 10:22 Sunhl $
 * $Author: Sunhl $
 * $Revision: 22 $
 * $Date: 06-09-11 10:22 $
 * $History: DataBaseFacade.cs $
 * 
 * *****************  Version 22  *****************
 * User: Sunhl        Date: 06-09-11   Time: 10:22
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/Commons/Data
 * 修改bug，事务回滚以后才能关闭连接，否则抛出异常
 * 
 * *****************  Version 21  *****************
 * User: Sunhl        Date: 06-09-08   Time: 10:56
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/Commons/Data
 * 添加了对查询的事务支持
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Emedchina.Commons.Debug;
using IBatisNet.Common.Logging;
#endregion

namespace Emedchina.Commons.Data
{
    #region delegates

    //public delegate void BindParameters(Database db, DbCommand cmd, params object[] paramValues);  该代理通过DataBase中的AddInParameter,AddOutParameter,AddParameter等方法,配置参数(主要是参数的类型和精度等)并绑定参数值.

    /// <summary>
    /// 该代理对象中的所有操作会在一个事务上下文中执行.
    /// </summary>
    /// <returns></returns>
    public delegate object InTransaction();

    /// <summary>
    /// 用于为给定sqlString为IDbDataParameter[]中parameters绑定具体的参数名和参数类型的代理。
    /// </summary>
    /// <remarks>params IDbDataParameter[] parameters是外部已经构造，ConfigureParameters只是对这些外部传入的parameters进行配置</remarks>
    /// <param name="sqlString">sql语句或存储过程，这个参数可能并不一定使用</param>
    /// <param name="parameters">要绑定参数名和参数类型的数据参数数组IDbDataParameter[]。</param>
    public delegate void ConfigureParameters(string sqlString, params IDbDataParameter[] parameters);

    /// <summary>
    /// 读IDataReader的第rowNumber行,并将该行结果映射为object类型的对象返回.
    /// </summary>
    ///  <remark>
    /// 实现类不能调用results的read()方法<see cref="System.Data.IDataReader.Read()"/> .
    /// </remark>
    /// <param name="reader">包含要读取的数据的IDataReader</param>
    /// <param name="rowNumber">当前的行号,某些具体实现可能并不需要该参数,可以忽略或指定一个不受参数影响的类.</param>
    /// <returns>
    /// 类型对象,可以是domain类,也可以是map,list等集合类.
    /// </returns> 
    public delegate object MapRow(IDataReader reader, int rowNumber);

    /// <summary>
    /// 范型化MapRow,将IDataReader中的记录映射为特定的对象类型.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reader"></param>
    /// <param name="rowNumber"></param>
    /// <returns></returns>     
    public delegate T MapRow<T>(IDataReader reader, int rowNumber);

    #endregion

    /// <summary>
    /// 提供了对微软企业库Data Block部分的封装.
    /// 主要封装了通过存储过程和sql执行数据库操作的部分.
    /// 对于没有封装的功能,客户端可以通过public Database RowDatabase方法获取底层的Database对象.
    /// </summary>
    /// <remarks>
    /// 本类没有使用DataBase中的AddInParameter,AddOutParameter,AddParameter等参数绑定方法,而是自己提供了AddParameters受保护方法,客户端需要自己构建相应sql的IDbDataParameter[]数组.
    /// 这样可以避免企业库中只使用DbType而不能使用数据库具体的类型参数构造的局限(例如OracleType.Cursor),同时也为参数缓存创造了条件.
    /// </remarks>
    /// <todo>使用微软企业库修改缓存功能。</todo>
    public class DataBaseFacade
    {
        #region Fields
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _connectionName = string.Empty;
        #endregion

        #region 私有构造函数
        private DataBaseFacade(string connectionName)
        {
            _connectionName = connectionName;
        }

        private DataBaseFacade()
        {
            _connectionName = null;
        }
        #endregion

        #region 获取实例的公共方法
        /// <summary>
        /// 获取默认的数据库连接,在config文件中配置
        /// </summary>
        /// <returns></returns>
        public static DataBaseFacade GetInstance()
        {
            return new DataBaseFacade();
        }

        /// <summary>
        /// 指定一个具体的数据库连接,在config文件中配置
        /// </summary>
        /// <param name="connectionName">配置文件中的连接字符串的name属性</param>
        /// <returns></returns>
        public static DataBaseFacade GetInstance(string connectionName)
        {
            return new DataBaseFacade(connectionName);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 获取Database实例,如果没有指定数据库连接字符串直接返回默认的连接对应的Database。
        /// </summary>
        /// <remarks>返回的Database已经注册了事件处理器，这些事件处理器主要负责记录日志和异常处理。</remarks>
        /// <returns>Database</returns>
        public Database RowDatabase
        {
            get
            {

                Database db = null;
                if (string.IsNullOrEmpty(_connectionName))
                {
                    db = DatabaseFactory.CreateDatabase();
                }
                else
                {
                    db = DatabaseFactory.CreateDatabase(_connectionName);
                }
                DataInstrumentationProvider instrumentation = db.GetInstrumentationEventProvider() as DataInstrumentationProvider;
                //注册事件处理器，这些事件处理器主要负责记录日志和异常处理。
                if (instrumentation != null)
                {
                    instrumentation.connectionFailed += new EventHandler<ConnectionFailedEventArgs>(instrumentation_connectionFailed);
                    instrumentation.commandFailed += new EventHandler<CommandFailedEventArgs>(instrumentation_commandFailed);
                    instrumentation.commandExecuted += new EventHandler<CommandExecutedEventArgs>(instrumentation_commandExecuted);
                }
                else
                {
                    DebugUtils.Debug(_log, "db.GetInstrumentationEventProvider() 返回null,确定是DataInstrumentationProvider类型.");
                }
                return db;
            }
        }
        #endregion

        #region connection and transaction

        /// <summary>
        /// 创建一个对应于所使用的数据库的连接,绑定连接字符串,但连接没有被打开
        /// </summary>
        /// <returns>DbConnection</returns>
        public DbConnection CreateConnection()
        {
            return RowDatabase.CreateConnection();
        }
        /// <summary>
        /// <para>打开一个连接.并且如果打开过程中出现异常，会通过异常框架处理该异常</para>
        /// </summary>
        /// <returns>The opened connection.</returns>
        public DbConnection OpenConnection()
        {
            DbConnection connection = null;
            try
            {
                DataInstrumentationProvider instrumentationProvider = RowDatabase.GetInstrumentationEventProvider() as DataInstrumentationProvider;
                try
                {
                    connection = CreateConnection();
                    connection.Open();
                }
                catch (Exception e)
                {
                    instrumentationProvider.FireConnectionFailedEvent(RowDatabase.ConnectionStringWithoutCredentials, e);
                    throw;
                }

                instrumentationProvider.FireConnectionOpenedEvent();
            }
            catch
            {
                if (connection != null)
                    connection.Close();

                throw;
            }

            return connection;
        }

        /// <summary>
        /// 在打开的连接上开始一个事务.要求连接在外部已经打开。
        /// </summary>
        /// <param name="connection">已经打开的连接。</param>
        /// <returns>DbTransaction</returns>
        public DbTransaction BeginTransaction(DbConnection opendConnection)
        {
            DbTransaction tran = opendConnection.BeginTransaction();
            return tran;
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="opendConnection">The opend connection.</param>
        /// <param name="il">The IsolationLevel.</param>
        /// <returns></returns>
        public DbTransaction BeginTransaction(DbConnection opendConnection, IsolationLevel il)
        {
            DbTransaction tran = opendConnection.BeginTransaction(il);
            return tran;
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="tran">DbTransaction</param>
        public void RollbackTransaction(DbTransaction tran)
        {
            tran.Rollback();
            DataBaseUtils.CloseConnection(tran.Connection);
        }

        /// <summary>
        /// 回滚事务,并且触发异常处理
        /// </summary>
        /// <param name="tran">DbTransaction</param>
        public void RollbackTransaction(DbTransaction tran, Exception e)
        {
            RollbackTransaction(tran);
            bool rethrowIt = ExceptionPolicy.HandleException(e, "Transaction Failed Handle Policy");
            if (rethrowIt)
            {
                throw e;
            }
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="tran">DbTransaction</param>
        public void CommitTransaction(DbTransaction tran)
        {
            tran.Commit();
        }
        #endregion

        #region stored procedures
        /// <summary>
        /// 执行存储过程，返回IDataReader
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        /// <returns>IDataReader</returns>
        public IDataReader SPExecuteReader(string spName, params object[] paramValues)
        {
            //不能使用using释放Command和Connection资源。否则返回的reader将不可用。
            Database db = RowDatabase;
            DbCommand cmd = db.GetStoredProcCommand(spName, paramValues);
            IDataReader reader = db.ExecuteReader(cmd);
            return reader;
        }

        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        /// <returns>DataSet</returns>
        public DataSet SPExecuteDataSet(string spName, params object[] paramValues)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetStoredProcCommand(spName, paramValues))
            {
                DataSet ds = db.ExecuteDataSet(cmd);
                cmd.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// 执行存储过程查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        /// <returns>object 结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object SPExecuteScalar(string spName, params object[] paramValues)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetStoredProcCommand(spName, paramValues))
            {
                object obj = db.ExecuteScalar(cmd);
                cmd.Parameters.Clear();
                return obj;
            }
        }

        /// <summary>
        /// 执行存储过程（Insert,Update,Delete等非查询操作）,受影响的行数。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>受影响的行数，对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</remarks>
        public int SPExecuteNonQuery(string spName, params object[] paramValues)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetStoredProcCommand(spName, paramValues))
            {
                int affected = db.ExecuteNonQuery(cmd);
                cmd.Parameters.Clear();
                return affected;
            }
        }

        /// <summary>
        /// 执行存储过程（Insert,Update,Delete等非查询操作）,受影响的行数。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="tran">The tran.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns></returns>
        /// <remarks>受影响的行数，对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</remarks>
        public int SPExecuteNonQuery(string spName, DbTransaction tran, params object[] paramValues)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetStoredProcCommand(spName, paramValues))
            {
                int affected = db.ExecuteNonQuery(cmd, tran);
                cmd.Parameters.Clear();
                return affected;
            }
        }

        /// <summary>       
        /// 执行存储过程,返回结果集中第一条记录映射为一个具体对象返回。
        /// </summary>
        /// <param name="spName">要执行的存储过程名</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object mapRowDelegate返回的对象</returns>
        public object SPQueryForObject(string spName, MapRow mapRowDelegate, params object[] values)
        {
            object result = null;
            using (IDataReader reader = SPQueryForReader(spName, values))
            {
                if (reader.Read())
                {
                    result = mapRowDelegate(reader, 0);
                }
            }
            return result;
        }

        /// <summary>       
        /// 执行存储过程,将结果集中记录映射为具体对象并返回一个object List。
        /// </summary>
        /// <param name="spName">要执行的存储过程名</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object List</returns>
        public IList SPQueryForList(string spName, MapRow mapRowDelegate, params object[] values)
        {
            IList results = new ArrayList();
            using (IDataReader reader = SPQueryForReader(spName, values))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// 执行存储过程，返回IDataReader
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>
        /// 参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。
        /// 返回的Reader是打开的，使用完以后需要尽早关闭。
        /// </remarks>
        /// <returns>IDataReader</returns>       
        public IDataReader SPQueryForReader(string spName, params object[] paramValues)
        {
            return this.SPExecuteReader(spName, paramValues);
        }

        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        /// <returns>DataSet</returns>
        public DataSet SPQueryForDataSet(string spName, params object[] paramValues)
        {
            return this.SPExecuteDataSet(spName, paramValues);
        }

        /// <summary>
        /// 执行存储过程查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        /// <returns>object 结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object SPQueryForScalar(string spName, params object[] paramValues)
        {
            return this.SPExecuteScalar(spName, paramValues);
        }

        /// <summary>
        /// 执行存储过程（Insert,Update,Delete等非查询操作）,受影响的行数。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <remarks>受影响的行数，对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</remarks>
        public int SPNonQuery(string spName, params object[] paramValues)
        {
            return this.SPExecuteNonQuery(spName, paramValues);
        }

        /// <summary>
        /// 执行存储过程（Insert,Update,Delete等非查询操作）,受影响的行数。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns></returns>
        /// <remarks>受影响的行数，对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</remarks>
        public int SPNonQuery(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteNonQuery(spName, paramValues);
        }
        #endregion

        #region SQL
        /// <summary>
        /// 执行sql语句，返回IDataReader。返回的Reader是打开的，使用完以后需要尽早关闭。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>IDataReader</returns>
        /// <remarks>返回的Reader是打开的，使用完以后需要尽早关闭。</remarks>
        public IDataReader SQLExecuteReader(string sql, params IDbDataParameter[] parameters)
        {
            //不能使用using释放Command和Connection资源。否则返回的reader将不可用。
            Database db = RowDatabase;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            AddParameters(cmd, parameters);
            IDataReader reader = db.ExecuteReader(cmd);
            DebugUtils.Debug(_log, cmd.CommandText);
            return reader;

        }

        /// <summary>
        /// SQLs the execute list.
        /// 通过sql语句和IDbDataParameter数组执行sql，然后按照MapRow返回对象数组放入List中。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList SQLExecuteList(string sqlString, MapRow mapRowDelegate, params IDbDataParameter[] parameters)
        {
            IList results = new ArrayList();
            using (IDataReader reader = SQLExecuteReader(sqlString, parameters))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// SQLs the execute list.
        /// 返回范型化List，通过sql语句和IDbDataParameter数组执行sql，然后按照MapRow<T>返回对象数组放入List中。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList<T> SQLExecuteList<T>(string sqlString, MapRow<T> mapRowDelegate, params IDbDataParameter[] parameters)
        {
            IList<T> results = new List<T>();
            using (IDataReader reader = SQLExecuteReader(sqlString, parameters))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// SQLs the execute object.
        /// 通过sql语句和IDbDataParameter数组执行sql，然后按照MapRow返回对象。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object SQLExecuteObject(string sqlString, MapRow mapRowDelegate, params IDbDataParameter[] parameters)
        {
            object result = null;
            using (IDataReader reader = SQLExecuteReader(sqlString, parameters))
            {
                if (reader.Read())
                {
                    result = mapRowDelegate(reader, 0);
                }
            }
            return result;
        }

        /// <summary>
        /// 执行sql语句，返回DataSet，用户传入需要绑定的参数的值数组，通过BindParameters进行绑定。         
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataSet</returns>
        /// <remarks> </remarks>
        public DataSet SQLExecuteDataSet(string sql, params IDbDataParameter[] parameters)
        {
            using (DbCommand selectCmd = this.BuildSQLCommand(sql, false))
            {
                DebugUtils.Debug(_log, sql);
                AddParameters(selectCmd, parameters);
                DataSet ds = SQLExecuteDataSet(selectCmd);
                selectCmd.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// SQLs the execute data set.
        /// 如果需要返回多个表，请考虑使用RowDataBase中的ExecuteDataSet方法。
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public DataSet SQLExecuteDataSet(DbCommand command)
        {
            DebugUtils.Debug(_log, command.CommandText);
            return RowDatabase.ExecuteDataSet(command);
        }

        /// <summary>
        /// SQLs the execute data table.
        /// 如果需要返回多个表，请考虑使用RowDataBase中的ExecuteDataSet方法。
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns></returns>
        /// <remarks> 出于性能考虑, 如果需要对返回的DataTable进行更新,不建议使用该方法.请自己获取DataAdapter并使用它填充DataSet或DataTable，然后用相同的DataAdapter，处理DataSet或DataTable。</remarks>
        public DataTable SQLExecuteDataTable(string sql, params IDbDataParameter[] selectParameters)
        {
            DebugUtils.Debug(_log, sql);
            return SQLExecuteDataTable(sql, string.Empty, selectParameters);
        }

        /// <summary>
        /// SQLs the execute data table.
        /// 出于性能考虑, 如果需要对返回的DataTable进行更新,不建议使用该方法.请自己获取DataAdapter并使用它填充DataSet或DataTable，然后用相同的DataAdapter，处理DataSet或DataTable。
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns>DataTable</returns>
        /// <remarks></remarks>
        public DataTable SQLExecuteDataTable(string sql, string tableName, params IDbDataParameter[] selectParameters)
        {
            DataTable table;
            if (!string.IsNullOrEmpty(tableName))
            {
                table = new DataTable(tableName);
            }
            else
            {
                table = new DataTable();
            }
            using (DbDataAdapter adapter = GetDataAdapter())
            {
                using (DbCommand selectCmd = this.BuildSQLCommand(sql, false))
                {
                    this.AddParameters(selectCmd, selectParameters);
                    adapter.SelectCommand = selectCmd;
                    try
                    {
                        DateTime startTime = DateTime.Now;
                        adapter.Fill(table);
                        (RowDatabase.GetInstrumentationEventProvider() as DataInstrumentationProvider).FireCommandExecutedEvent(startTime);
                    }
                    catch (Exception e)
                    {
                        (RowDatabase.GetInstrumentationEventProvider() as DataInstrumentationProvider).FireCommandFailedEvent(selectCmd.CommandText, RowDatabase.ConnectionStringWithoutCredentials, e);
                        throw;
                    }
                    finally
                    {
                        adapter.SelectCommand.Parameters.Clear();
                        DebugUtils.Debug(_log, adapter.SelectCommand.CommandText);
                    }
                }
            }

            return table;
        }

        /// <summary>
        /// 执行查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>object 结果集中第一行的第一列或空引用（如果结果集为空）</returns>
        public object SQLExecuteScalar(string sql, params IDbDataParameter[] parameters)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetSqlStringCommand(sql))
            {
                AddParameters(cmd, parameters);
                object obj = db.ExecuteScalar(cmd);
                cmd.Parameters.Clear();
                DebugUtils.Debug(_log, cmd.CommandText);
                return obj;
            }
        }

        /// <summary>
        /// 执行非查询的sql语句，对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>int</returns>
        public int SQLExecuteNonQuery(string sql, params IDbDataParameter[] parameters)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetSqlStringCommand(sql))
            {
                AddParameters(cmd, parameters);
                int affected = db.ExecuteNonQuery(cmd);
                cmd.Parameters.Clear();
                DebugUtils.Debug(_log, cmd.CommandText);
                return affected;
            }
        }
        /// <summary>
        /// 在指定的事务中执行sql语句.
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="transaction">事务上下文</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>int</returns>
        /// <remarks>整个操作在一个事务上下文中执行</remarks>
        public int SQLExecuteNonQuery(string sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetSqlStringCommand(sql))
            {
                AddParameters(cmd, parameters);
                int affected = db.ExecuteNonQuery(cmd, transaction);
                cmd.Parameters.Clear();
                DebugUtils.Debug(_log, cmd.CommandText);
                return affected;
            }
        }
        /// <summary>
        /// 在指定的事务中批量执行sql语句.
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="transaction">事务上下文</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>int</returns>
        /// <remarks>整个操作在一个事务上下文中执行</remarks>
        public bool SQLExecuteNonQuery(string[] sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            Database db = RowDatabase;
            bool flag = true;
            for (int i = 0; i < sql.Length; i++)
            {
                using (DbCommand cmd = db.GetSqlStringCommand(sql[i]))
                {
                    try
                    {
                        AddParameters(cmd, parameters);
                        int affected = db.ExecuteNonQuery(cmd, transaction);
                        cmd.Parameters.Clear();
                        //DebugUtils.Debug(_log, cmd.CommandText);
                        flag = true;
                    }
                    catch (Exception e)
                    {
                        //throw e;
                        DebugUtils.Debug(_log, cmd.CommandText);
                        flag = false;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 在指定的事务中批量执行sql语句.
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="transaction">事务上下文</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>int</returns>
        /// <remarks>整个操作在一个事务上下文中执行</remarks>
        public int SQLExecuteNonQueryEx(string[] sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            Database db = RowDatabase;
            bool flag = true;
            int count = 0;
            for (int i = 0; i < sql.Length; i++)
            {
                using (DbCommand cmd = db.GetSqlStringCommand(sql[i]))
                {
                    try
                    {
                        AddParameters(cmd, parameters);
                        int affected = db.ExecuteNonQuery(cmd, transaction);
                        cmd.Parameters.Clear();
                        //DebugUtils.Debug(_log, cmd.CommandText);
                        flag = true;
                        count++;
                    }
                    catch (Exception e)
                    {
                        //throw e;
                        DebugUtils.Debug(_log, cmd.CommandText);
                        flag = false;
                    }
                }
            }
            return count;
        }
        /// <summary>       
        /// 执行sql语句，返回IDataReader，用户传入需要绑定的参数的值数组，通过configureParametersDelegate进行参数配置。
        /// 返回的Reader是打开的，使用完以后需要尽早关闭。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>IDataReader</returns>
        /// <remarks>返回的Reader是打开的，使用完以后需要尽早关闭。</remarks>
        public IDataReader SQLQueryForReader(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteReader(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>       
        /// 执行sql查询,返回结果集中第一条记录映射为一个具体对象返回。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object mapRowDelegate返回的对象</returns>
        public object SQLQueryForObject(string sqlString, ConfigureParameters configureParametersDelegate, MapRow mapRowDelegate, params object[] values)
        {
            object result = null;
            using (IDataReader reader = SQLQueryForReader(sqlString, configureParametersDelegate, values))
            {
                if (reader.Read())
                {
                    result = mapRowDelegate(reader, 0);
                }
            }
            return result;
        }

        /// <summary>
        /// SQLs the query for object by id.
        /// 通过id获取一个对象，该方法要求sql的绑定参数只有一个，并且是表的id，并且名字必须是ID，而且id必须是DbType.String类型。
        /// 限制比较多。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="id">The id.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <returns></returns>
        public object SQLQueryObjectById(string sqlString, string id, MapRow mapRowDelegate)
        {
            DbParameter idPara = CreateParameter();
            idPara.ParameterName = "ID";
            idPara.DbType = DbType.String;
            idPara.Value = id;
            return SQLExecuteObject(sqlString, mapRowDelegate, idPara);
        }


        /// <summary>       
        /// 执行sql查询,将结果集中记录映射为具体对象并返回一个object List。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object List</returns>
        public IList SQLQueryForList(string sqlString, ConfigureParameters configureParametersDelegate, MapRow mapRowDelegate, params object[] values)
        {
            IList results = new ArrayList();
            using (IDataReader reader = SQLQueryForReader(sqlString, configureParametersDelegate, values))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        //增加了对范型的支持

        /// <summary>
        /// SQLs the query for list.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>

        public IList<T> SQLQueryForList<T>(string sqlString, ConfigureParameters configureParametersDelegate, MapRow<T> mapRowDelegate, params object[] values)
        {
            IList<T> results = new List<T>();
            using (IDataReader reader = SQLQueryForReader(sqlString, configureParametersDelegate, values))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>       
        /// 执行sql查询,返回DataSet。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>DataSet</returns>
        public DataSet SQLQueryForDataSet(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteDataSet(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>
        /// SQLs the query for datatable.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns>DataTable</returns>
        public DataTable SQLQueryForDataTable(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            DataTable table = new DataTable();
            DbDataAdapter adapter = this.GetDataAdapter(sqlString, configureParametersDelegate, values);
            DebugUtils.Debug(_log, sqlString);
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// SQLs the query for data table.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public DataTable SQLQueryForDataTable(string sqlString, string tableName, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            DataTable table = new DataTable(tableName);
            DbDataAdapter adapter = this.GetDataAdapter(sqlString, configureParametersDelegate, values);
            DebugUtils.Debug(_log, sqlString);
            adapter.Fill(table);
            return table;
        }

        /// <summary>       
        /// 执行sql查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object 返回结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object SQLQueryForScalar(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteScalar(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>       
        /// 执行非查询的sql语句，对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。
        /// </summary>
        /// <param name="sqlString">要执行的sql语句</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数数组</param>
        /// <returns>int 对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</returns>
        public int SQLNonQuery(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteNonQuery(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }
        /// <summary>
        /// 在一个事务中执行一个非查询的sql语句。
        /// </summary>
        /// <param name="sqlString">要执行的sql语句</param>
        /// <param name="transaction">事务上下文</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>int 对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</returns>
        public int SQLNonQuery(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteNonQuery(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }
        #endregion

        #region commands and parameters

        /// <summary>
        /// Builds the SQL command.
        /// 新构造的命令对象有Connection，并且Connection的状态由connectionOpened决定
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="connectionOpened">if set to <c>true</c> [connection opened].</param>
        /// <returns></returns>
        public DbCommand BuildSQLCommand(string sqlString, bool connectionOpened)
        {
            DbCommand cmd = this.RowDatabase.GetSqlStringCommand(sqlString);
            if (connectionOpened)
            {
                cmd.Connection = this.OpenConnection();
            }
            else
            {
                cmd.Connection = this.CreateConnection();
            }
            return cmd;
        }
        /// <summary>
        /// Builds the SQL command.新构造的命令对象没有Connection.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        /// <remarks>新构造的命令对象没有Connection</remarks>
        public DbCommand BuildSQLCommand(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            DbCommand cmd = this.RowDatabase.GetSqlStringCommand(sqlString);
            if (configureParametersDelegate == null)
                return cmd;
            IDbDataParameter[] parameters = GetCachedParameters(sqlString, configureParametersDelegate, values);
            AddParameters(cmd, parameters);

            return cmd;
        }

        /// <summary>
        /// Builds the SQL command.
        /// 新构造的命令对象有Connection，并且Connection的状态由connectionOpened决定
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="connectionOpened">if set to <c>true</c> [connection opened].</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        /// <remarks>新构造的命令对象有Connection，并且Connection的状态由connectionOpened决定</remarks>
        public DbCommand BuildSQLCommand(string sqlString, bool connectionOpened, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            DbCommand cmd = this.BuildSQLCommand(sqlString, configureParametersDelegate, values);
            if (connectionOpened)
            {
                cmd.Connection = this.OpenConnection();
            }
            else
            {
                cmd.Connection = this.CreateConnection();
            }
            return cmd;
        }

        /// <summary>
        /// Builds the SP command.with  parameters
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public DbCommand BuildSPCommand(string spName, params object[] values)
        {
            DbCommand cmd = this.RowDatabase.GetStoredProcCommand(spName, values);

            return cmd;
        }

        /// <summary>
        /// Builds the SP command.with no parameters
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        public DbCommand BuildSPCommand(string spName)
        {
            DbCommand cmd = this.RowDatabase.GetStoredProcCommand(spName);

            return cmd;
        }

        /// <summary>
        /// Creates the SQL command.返回没有连接也没有Sql语句的DbCommand
        /// </summary>
        /// <returns>没有连接也没有Sql语句的DbCommand</returns>
        public DbCommand CreateSqlCommand()
        {
            DbCommand cmd = this.RowDatabase.DbProviderFactory.CreateCommand();
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// Creates the SP command.返回没有连接也没有SP命的DbCommand
        /// </summary>
        /// <returns>没有连接也没有SP命的DbCommand</returns>
        public DbCommand CreateSPCommand()
        {
            DbCommand cmd = this.RowDatabase.DbProviderFactory.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        /// <summary>
        /// 子类可以利用该类，方便的构造参数。
        /// 对于QueryForObject中对象关系映射,都是通过MapRow代理实现的.
        /// </summary>
        /// <returns>IDbDataParameter</returns>
        public DbParameter CreateParameter()
        {
            return this.RowDatabase.DbProviderFactory.CreateParameter();
        }

        /// <summary>
        /// 方便子类构造参数数组。
        /// </summary>
        /// <param name="arrayLength">数组长度</param>
        /// <returns>IDbDataParameter[]</returns>
        public DbParameter[] CreateParameterArray(int arrayLength)
        {
            if (arrayLength < 0)
            {
                throw new ArgumentException("创建IDbDataParameter数组的数组长度不能为负.");
            }

            DbParameter[] parameters = new DbParameter[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                parameters[i] = CreateParameter();
            }

            return parameters;
        }

        /// <summary>
        /// 为cmd添加parameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        public void AddParameters(DbCommand cmd, params IDbDataParameter[] parameters)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(parameters);
            foreach (IDbDataParameter para in parameters)
            {
                DebugUtils.Debug(_log, string.Format("DbParameter {0}'s Value is {1}.", para.ParameterName, para.Value));
            }
        }
        #endregion

        #region Utils

        /// <summary>
        /// 如果参数已被缓存则直接返回。
        /// 否则判断传入的sql是否有需要绑定的参数，如果没有,返回空参数数组IDbDataParameter[0]。
        /// 否则创建，绑定，缓存并返回该参数数组。
        /// 参数绑定过程需要子类自己实现。
        /// </summary>
        /// <remarks>
        /// 注意，当一个DAO类中有很多sql，并且这些sql中多余一个要绑定参数，则子类实现时利用该参数就可能不够方便。
        /// 如果那样可以不直接使用该方法，而使用和该类实现相似的方法自己构造并绑定参数。也可以在重写的BindParams方法中进行条件选择。
        /// 另外该方法是否有效，也依赖于this.CountParameterPlaceholders(sqlString, placeHolder, delim)方法是否有效。
        /// placeHolder是参数标志占位符，例如Oracle使用":",SQLServer使用"@"。
        /// delims是分隔符序列，这个序列中的人一个分隔符中，0-1，2-3，4-5，6……个相同的分隔符之间的placeholder不被计算。
        /// 例如一个字符串为"this is my  ? 'delims test?'",placeholder为?,而delimiters为',则'delims test?'中的？不被计数。
        /// </remarks>
        /// <param name="sqlString">一条sql语句,作为缓存的Cache Key</param>
        /// <param name="placeHolder">展位符，也就是命名参数前缀。</param>
        /// <param name="delims">分隔符中的placeHolder将不被计算在内。</param>
        /// <param name="configureParametersDelegate">用于配置参数数组中对应参数的参数名和参数类型等参数属性。</param>
        /// <param name="values">参数值数组</param>
        /// <returns>IDbDataParameter[]</returns>
        public IDbDataParameter[] GetCachedParameters(string sqlString, char placeHolder, string delims, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            int paramCount = this.CountParameters(sqlString, placeHolder, delims);
            //如果没有需要绑定的参数，直接返回new IDbDataParameter[0];
            if (paramCount <= 0)
            {
                //DebugUtils.Debug(_log, string.Format("GetCachedParameters found paramCount <= 0 in sql:{0}", sqlString));
                return new IDbDataParameter[0];
            }
            string cacheKey = GenerateCacheKey(sqlString);

            //如果参数原先没有缓存就为sql创建并绑定参数名和参数类型,然后缓存,随后绑定参数值.
            //如果原先已经缓存,就直接绑定参数值.
            IDbDataParameter[] cachedParams = DataBaseUtils.GetCachedParameters(cacheKey);
            if (cachedParams == null)
            {
                //DebugUtils.Debug(_log, string.Format("GetCachedParameters found paramCount = {0} in sql: '{1}'", paramCount, sqlString));
                //参数原先没有被缓存.
                cachedParams = CreateParameterArray(paramCount);
                //首先绑定参数名和类型,然后缓存
                if (configureParametersDelegate != null)
                {
                    configureParametersDelegate(sqlString, cachedParams);
                }
                DataBaseUtils.CacheParameters(cacheKey, cachedParams);
            }

            if (values == null || values.Length <= 0)
            {
                if (_log.IsWarnEnabled)
                {
                    _log.Warn("GetCachedParameters the bindvalues array 'object[] values' is null 或 length==0.逻辑上这是不正确的.");
                }
            }
            else
            {
                //绑定参数值
                BindValues(cachedParams, values);
            }

            return cachedParams;
        }

        /// <summary>
        /// 如果参数已被缓存则直接返回。
        /// 否则判断传入的sql是否有需要绑定的参数，如果没有,返回空参数数组IDbDataParameter[0]。
        /// 否则创建，绑定，缓存并返回该参数数组。
        /// 参数绑定过程需要子类自己实现。
        /// 参数前缀默认为":",分隔符默认为"'"。
        /// </summary>
        /// <param name="sqlString">一条sql语句,作为缓存的Cache Key</param>
        /// <param name="configureParametersDelegate">用于配置参数数组中对应参数的参数名和参数类型等参数属性。</param>
        /// <param name="values">参数值数组</param>
        /// <returns>IDbDataParameter[]</returns>
        public virtual IDbDataParameter[] GetCachedParameters(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return GetCachedParameters(sqlString, ':', "'", configureParametersDelegate, values);
        }

        /// <summary>
        /// 绑定参数值.默认实现中参数个数和参数值必须相等,并按序号一一对应.
        /// 客户端可以通过重载该方法实现自己的参数值绑定策略.
        /// </summary>
        /// <remarks>一定要保证参数和参数值是按序号一一对应的.也就是在ConfigureParameters代理中配置的参数和这里的参数值必须对应</remarks>
        /// <param name="parameters">参数数组</param>
        /// <param name="values">参数值数组</param>
        public void BindValues(IDbDataParameter[] parameters, object[] values)
        {
            if (parameters == null || values == null || values.Length != parameters.Length)
            {
                if (_log.IsWarnEnabled)
                {
                    _log.Warn("Method GetCachedParameters 参数数组的长度应该和值数组的长度相同。");
                }
                throw new DataAcessException("参数绑定出现错误,参数数组和参数值数组长度应该相同。");
            }
            int i = 0;
            foreach (IDbDataParameter para in parameters)
            {
                if (_log.IsDebugEnabled)
                {
                    _log.Debug(string.Format("index is {0},parameterName is '{1}'  and para.Value = {2}", i, para.ParameterName, values[i]));
                }
                para.Value = values[i];
                ++i;
            }
        }

        /// <summary>
        /// 产生一个缓存的键值,本实现的生成规则是:
        /// 连接字符串 + '-' + 传入的sql字符串,保证同一个连接下sql是唯一的.
        /// </summary>
        /// <param name="sqlString">sql语句字符串</param>
        /// <returns>为sqlString构造一个缓存键</returns>
        public string GenerateCacheKey(string sqlString)
        {
            StringBuilder sb = new StringBuilder(this.RowDatabase.ConnectionStringWithoutCredentials).Append('-').Append(sqlString);
            return sb.ToString();
        }

        #endregion

        //new added
        #region DataAdapter and DataSet

        /// <summary>
        /// Updates the data set.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        /// <param name="updateBehavior">The update behavior.</param>
        /// <returns></returns>
        public int UpdateDataSet(DataSet dataSet, string tableName,
                                            DbCommand insertCommand, DbCommand updateCommand,
                                            DbCommand deleteCommand, UpdateBehavior updateBehavior)
        {
            DebugCommands(insertCommand, updateCommand, deleteCommand);
            return RowDatabase.UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, updateBehavior);
        }

        /// <summary>
        /// Updates the data set.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="insertCommand">The insert command.</param>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="deleteCommand">The delete command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        public int UpdateDataSet(DataSet dataSet, string tableName,
                                            DbCommand insertCommand, DbCommand updateCommand,
                                            DbCommand deleteCommand, DbTransaction transaction)
        {
            DebugCommands(insertCommand, updateCommand, deleteCommand);
            return RowDatabase.UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, transaction);
        }


        private void DebugCommands(DbCommand insertCommand, DbCommand updateCommand,
                                            DbCommand deleteCommand)
        {
            if (insertCommand != null)
                DebugUtils.Debug(_log, string.Format("InsertCommand text is:{0}", insertCommand.CommandText));

            if (updateCommand != null)
                DebugUtils.Debug(_log, string.Format("UpdateCommand text is:{0}", updateCommand.CommandText));

            if (deleteCommand != null)
                DebugUtils.Debug(_log, string.Format("DeleteCommand text is:{0}", deleteCommand.CommandText));
        }

        /// <summary>
        /// Gets the data adapter.返回一个具体数据库的DbDataAdapter。
        /// </summary>
        /// <returns>DbDataAdapter</returns>
        public DbDataAdapter GetDataAdapter()
        {
            return RowDatabase.GetDataAdapter();
        }

        /// <summary>
        /// Gets the data adapter.通过querySql构造SelectCommand命令,并且初始化连接,不过连接没有打开.
        /// </summary>
        /// <param name="querySql">The query SQL.</param>
        /// <returns>DbDataAdapter</returns>
        public DbDataAdapter GetDataAdapter(string querySql)
        {
            DbDataAdapter adapter = GetDataAdapter();
            DebugUtils.Debug(_log, querySql);
            adapter.SelectCommand = RowDatabase.GetSqlStringCommand(querySql);
            adapter.SelectCommand.Connection = CreateConnection();
            return adapter;
        }

        /// <summary>
        /// Gets the data adapter.
        /// </summary>
        /// <param name="querySql">The query SQL.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns></returns>
        public DbDataAdapter GetDataAdapter(string querySql, params IDbDataParameter[] selectParameters)
        {
            DbDataAdapter adapter = GetDataAdapter();
            DebugUtils.Debug(_log, querySql);
            DbCommand selectCmd = RowDatabase.GetSqlStringCommand(querySql);
            selectCmd.Connection = this.CreateConnection();
            this.AddParameters(selectCmd, selectParameters);
            adapter.SelectCommand = selectCmd;
            return adapter;
        }


        /// <summary>
        /// Gets the data adapter.通过querySql和传入的参数值构造SelectCommand命令,并且初始化连接,不过连接没有打开.
        /// </summary>
        /// <param name="querySql">The query SQL.</param>
        /// <param name="configureSelectParametersDelegate">The configure select parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public DbDataAdapter GetDataAdapter(string querySql, ConfigureParameters configureSelectParametersDelegate, params object[] values)
        {
            DbDataAdapter adapter = GetDataAdapter();
            DebugUtils.Debug(_log, querySql);
            adapter.SelectCommand = this.BuildSQLCommand(querySql, false, configureSelectParametersDelegate, values);
            adapter.SelectCommand.Connection = this.CreateConnection();
            return adapter;
        }
        #endregion

        #region private methods
        //private delegate void EventHandler<ConnectionFailedEventArgs> ConnectionFailed(object sender, ConnectionFailedEventArgs e);
        void instrumentation_connectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(string.Format("连接错误,连接字符串为:{0}", e.ConnectionString), e.Exception);
            }

            ExceptionPolicy.HandleException(e.Exception, "ConnectionFailed Log And Wrap Policy");
        }

        void instrumentation_commandFailed(object sender, CommandFailedEventArgs e)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(string.Format("命令执行失败,命令字符串为:{0},连接字符串为:{1}.", e.CommandText, e.ConnectionString), e.Exception);
            }
            ExceptionPolicy.HandleException(e.Exception, "CommandFailed Wrap Policy");
        }

        void instrumentation_commandExecuted(object sender, CommandExecutedEventArgs e)
        {
            //DebugUtils.Debug(_log,e.
        }

        /// <summary>
        /// 判断一条sql语句中的命名参数的个数。
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="placeholder">参数前缀，对于oracle是:，对于sql是@.</param>
        /// <param name="delimiters">delimiters对中出现的placeholder不被计算在内.</param>
        /// <returns>参数个数</returns>
        private int CountParameters(string sqlString, char placeholder, string delimiters)
        {
            return StringUtils.CountPlaceholders(sqlString, placeholder, delimiters);
        }

        #endregion

        #region new added,transaction support
        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns>DataSet</returns>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        public DataSet SPExecuteDataSet(string spName, DbTransaction transaction, params object[] paramValues)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetStoredProcCommand(spName, paramValues))
            {
                DataSet ds = db.ExecuteDataSet(cmd, transaction);
                cmd.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// 执行存储过程，返回IDataReader
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns>IDataReader</returns>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        public IDataReader SPExecuteReader(string spName, DbTransaction transaction, params object[] paramValues)
        {
            //不能使用using释放Command和Connection资源。否则返回的reader将不可用。
            Database db = RowDatabase;
            DbCommand cmd = db.GetStoredProcCommand(spName, paramValues);
            IDataReader reader = db.ExecuteReader(cmd, transaction);
            return reader;
        }

        /// <summary>
        /// 执行存储过程查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns>object 结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        public object SPExecuteScalar(string spName, DbTransaction transaction, params object[] paramValues)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetStoredProcCommand(spName, paramValues))
            {
                object obj = db.ExecuteScalar(cmd, transaction);
                cmd.Parameters.Clear();
                return obj;
            }
        }

        /// <summary>
        /// 执行存储过程，返回DataSet
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns>DataSet</returns>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        public DataSet SPQueryForDataSet(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteDataSet(spName, transaction, paramValues);
        }

        /// <summary>
        /// 执行存储过程，返回IDataReader
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns>IDataReader</returns>
        /// <remarks>
        /// 参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。
        /// 返回的Reader是打开的，使用完以后需要尽早关闭。
        /// </remarks>
        public IDataReader SPQueryForReader(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteReader(spName, transaction, paramValues);
        }

        /// <summary>       
        /// 执行存储过程,将结果集中记录映射为具体对象并返回一个object List。
        /// </summary>
        /// <param name="spName">要执行的存储过程名</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object List</returns>
        public IList SPQueryForList(string spName, DbTransaction transaction, MapRow mapRowDelegate, params object[] values)
        {
            IList results = new ArrayList();
            using (IDataReader reader = SPQueryForReader(spName, transaction, values))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// 执行存储过程,返回结果集中第一条记录映射为一个具体对象返回。
        /// </summary>
        /// <param name="spName">要执行的存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object mapRowDelegate返回的对象</returns>
        public object SPQueryForObject(string spName, DbTransaction transaction, MapRow mapRowDelegate, params object[] values)
        {
            object result = null;
            using (IDataReader reader = SPQueryForReader(spName, transaction, values))
            {
                if (reader.Read())
                {
                    result = mapRowDelegate(reader, 0);
                }
            }
            return result;
        }

        /// <summary>
        /// 执行存储过程查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="spName">存储过程名，如果有包需要:包名+“.”+存储过程名</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">存储过程的参数值，如果没有参数，省略该参数，不要传入null。</param>
        /// <returns>object 结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        /// <remarks>参数值数组中参数值的顺序和类型必须和存储过程中参数的顺序和类型一致。</remarks>
        public object SPQueryForScalar(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteScalar(spName, transaction, paramValues);
        }

        /// <summary>
        /// SQLs the execute data set.
        /// 如果需要返回多个表，请考虑使用RowDataBase中的ExecuteDataSet方法。
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        public DataSet SQLExecuteDataSet(DbCommand command, DbTransaction transaction)
        {
            DebugUtils.Debug(_log, command.CommandText);
            return RowDatabase.ExecuteDataSet(command, transaction);
        }

        /// <summary>
        /// 执行sql语句，返回DataSet，用户传入需要绑定的参数的值数组，通过BindParameters进行绑定。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>DataSet</returns>
        /// <remarks>
        /// </remarks>
        public DataSet SQLExecuteDataSet(string sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            using (DbCommand selectCmd = this.RowDatabase.GetSqlStringCommand(sql))
            {
                DebugUtils.Debug(_log, sql);
                AddParameters(selectCmd, parameters);
                DataSet ds = SQLExecuteDataSet(selectCmd, transaction);
                selectCmd.Parameters.Clear();
                return ds;
            }
        }

        /// <summary>
        /// SQLs the execute data table.
        /// 如果需要返回多个表，请考虑使用RowDataBase中的ExecuteDataSet方法。
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns></returns>
        /// <remarks> 出于性能考虑, 如果需要对返回的DataTable进行更新,不建议使用该方法.请自己获取DataAdapter并使用它填充DataSet或DataTable，然后用相同的DataAdapter，处理DataSet或DataTable。</remarks>
        public DataTable SQLExecuteDataTable(string sql, DbTransaction transaction, params IDbDataParameter[] selectParameters)
        {
            DebugUtils.Debug(_log, sql);
            return SQLExecuteDataTable(sql, transaction, string.Empty, selectParameters);
        }

        /// <summary>
        /// SQLs the execute data table.
        /// 出于性能考虑, 如果需要对返回的DataTable进行更新,不建议使用该方法.请自己获取DataAdapter并使用它填充DataSet或DataTable，然后用相同的DataAdapter，处理DataSet或DataTable。
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns>DataTable</returns>
        /// <remarks></remarks>
        public DataTable SQLExecuteDataTable(string sql, DbTransaction transaction, string tableName, params IDbDataParameter[] selectParameters)
        {
            DataTable table;
            if (!string.IsNullOrEmpty(tableName))
            {
                table = new DataTable(tableName);
            }
            else
            {
                table = new DataTable();
            }
            using (DbDataAdapter adapter = GetDataAdapter())
            {
                using (DbCommand selectCmd = this.BuildSQLCommand(sql, false))
                {
                    selectCmd.Connection = transaction.Connection;
                    selectCmd.Transaction = transaction;
                    this.AddParameters(selectCmd, selectParameters);
                    adapter.SelectCommand = selectCmd;
                    try
                    {
                        DateTime startTime = DateTime.Now;
                        adapter.Fill(table);
                        (RowDatabase.GetInstrumentationEventProvider() as DataInstrumentationProvider).FireCommandExecutedEvent(startTime);
                    }
                    catch (Exception e)
                    {
                        (RowDatabase.GetInstrumentationEventProvider() as DataInstrumentationProvider).FireCommandFailedEvent(selectCmd.CommandText, RowDatabase.ConnectionStringWithoutCredentials, e);
                        throw;
                    }
                    finally
                    {
                        adapter.SelectCommand.Parameters.Clear();
                        DebugUtils.Debug(_log, adapter.SelectCommand.CommandText);
                    }
                }
            }

            return table;
        }

        /// <summary>
        /// SQLs the execute list.
        /// 返回范型化List，通过sql语句和IDbDataParameter数组执行sql，然后按照MapRow<T>返回对象数组放入List中。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList<T> SQLExecuteList<T>(string sqlString, DbTransaction transaction, MapRow<T> mapRowDelegate, params IDbDataParameter[] parameters)
        {
            IList<T> results = new List<T>();
            using (IDataReader reader = SQLExecuteReader(sqlString, transaction, parameters))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// SQLs the execute list.
        /// 通过sql语句和IDbDataParameter数组执行sql，然后按照MapRow返回对象数组放入List中。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList SQLExecuteList(string sqlString, DbTransaction transaction, MapRow mapRowDelegate, params IDbDataParameter[] parameters)
        {
            IList results = new ArrayList();
            using (IDataReader reader = SQLExecuteReader(sqlString, transaction, parameters))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// SQLs the execute object.
        /// 通过sql语句和IDbDataParameter数组执行sql，然后按照MapRow返回对象。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object SQLExecuteObject(string sqlString, DbTransaction transaction, MapRow mapRowDelegate, params IDbDataParameter[] parameters)
        {
            object result = null;
            using (IDataReader reader = SQLExecuteReader(sqlString, transaction, parameters))
            {
                if (reader.Read())
                {
                    result = mapRowDelegate(reader, 0);
                }
            }
            return result;
        }

        /// <summary>
        /// 执行sql语句，返回IDataReader。返回的Reader是打开的，使用完以后需要尽早关闭。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>IDataReader</returns>
        /// <remarks>返回的Reader是打开的，使用完以后需要尽早关闭。</remarks>
        public IDataReader SQLExecuteReader(string sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            //不能使用using释放Command和Connection资源。否则返回的reader将不可用。
            Database db = RowDatabase;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            AddParameters(cmd, parameters);
            IDataReader reader = db.ExecuteReader(cmd, transaction);
            DebugUtils.Debug(_log, cmd.CommandText);
            return reader;
        }

        /// <summary>
        /// 执行查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>object 结果集中第一行的第一列或空引用（如果结果集为空）</returns>
        public object SQLExecuteScalar(string sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            Database db = RowDatabase;
            using (DbCommand cmd = db.GetSqlStringCommand(sql))
            {
                AddParameters(cmd, parameters);
                object obj = db.ExecuteScalar(cmd, transaction);
                cmd.Parameters.Clear();
                DebugUtils.Debug(_log, cmd.CommandText);
                return obj;
            }
        }

        /// <summary>
        /// 执行sql查询,返回DataSet。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>DataSet</returns>
        public DataSet SQLQueryForDataSet(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteDataSet(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>
        /// SQLs the query for datatable.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns>DataTable</returns>
        public DataTable SQLQueryForDataTable(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            DataTable table = new DataTable();
            DbDataAdapter adapter = this.GetDataAdapter(sqlString, configureParametersDelegate, values);
            DebugUtils.Debug(_log, sqlString);
            adapter.SelectCommand.Connection = transaction.Connection;
            adapter.SelectCommand.Transaction = transaction;
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// SQLs the query for data table.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public DataTable SQLQueryForDataTable(string sqlString, DbTransaction transaction, string tableName, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            DataTable table = new DataTable(tableName);
            DbDataAdapter adapter = this.GetDataAdapter(sqlString, configureParametersDelegate, values);
            DebugUtils.Debug(_log, sqlString);
            adapter.SelectCommand.Connection = transaction.Connection;
            adapter.SelectCommand.Transaction = transaction;
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// SQLs the query for list.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns>IList<T></returns>
        public IList<T> SQLQueryForList<T>(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, MapRow<T> mapRowDelegate, params object[] values)
        {
            IList<T> results = new List<T>();
            using (IDataReader reader = SQLQueryForReader(sqlString, transaction, configureParametersDelegate, values))
            {
                for (int i = 0; reader.Read(); ++i)
                {
                    results.Add(mapRowDelegate(reader, i));
                }
            }
            return results;
        }

        /// <summary>
        /// 执行sql查询,返回结果集中第一条记录映射为一个具体对象返回。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="mapRowDelegate">用于关系对象映射</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object mapRowDelegate返回的对象</returns>
        public object SQLQueryForObject(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, MapRow mapRowDelegate, params object[] values)
        {
            object result = null;
            using (IDataReader reader = SQLQueryForReader(sqlString, transaction, configureParametersDelegate, values))
            {
                if (reader.Read())
                {
                    result = mapRowDelegate(reader, 0);
                }
            }
            return result;
        }

        /// <summary>
        /// 执行sql语句，返回IDataReader，用户传入需要绑定的参数的值数组，通过configureParametersDelegate进行参数配置。
        /// 返回的Reader是打开的，使用完以后需要尽早关闭。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>IDataReader</returns>
        /// <remarks>返回的Reader是打开的，使用完以后需要尽早关闭。</remarks>
        public IDataReader SQLQueryForReader(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteReader(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>
        /// 执行sql查询,返回结果集中第一行的第一列或空引用（如果结果集为空）。
        /// </summary>
        /// <param name="sqlString">要执行的sql查询语句</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">用于配置sql语句的命名参数</param>
        /// <param name="values">参数值数组</param>
        /// <returns>object 返回结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        public object SQLQueryForScalar(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteScalar(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>
        /// SQLs the query for object by id.
        /// 通过id获取一个对象，该方法要求sql的绑定参数只有一个，并且是表的id，并且名字必须是ID，而且id必须是DbType.String类型。
        /// 限制比较多。
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="id">The id.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="mapRowDelegate">The map row delegate.</param>
        /// <returns></returns>
        public object SQLQueryObjectById(string sqlString, string id, DbTransaction transaction, MapRow mapRowDelegate)
        {
            DbParameter idPara = CreateParameter();
            idPara.ParameterName = "ID";
            idPara.DbType = DbType.String;
            idPara.Value = id;
            return SQLExecuteObject(sqlString, transaction, mapRowDelegate, idPara);
        }
        #endregion
    }
}
