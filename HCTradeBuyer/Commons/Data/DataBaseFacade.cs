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
 * �޸�bug������ع��Ժ���ܹر����ӣ������׳��쳣
 * 
 * *****************  Version 21  *****************
 * User: Sunhl        Date: 06-09-08   Time: 10:56
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/Commons/Data
 * ����˶Բ�ѯ������֧��
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

    //public delegate void BindParameters(Database db, DbCommand cmd, params object[] paramValues);  �ô���ͨ��DataBase�е�AddInParameter,AddOutParameter,AddParameter�ȷ���,���ò���(��Ҫ�ǲ��������ͺ;��ȵ�)���󶨲���ֵ.

    /// <summary>
    /// �ô�������е����в�������һ��������������ִ��.
    /// </summary>
    /// <returns></returns>
    public delegate object InTransaction();

    /// <summary>
    /// ����Ϊ����sqlStringΪIDbDataParameter[]��parameters�󶨾���Ĳ������Ͳ������͵Ĵ���
    /// </summary>
    /// <remarks>params IDbDataParameter[] parameters���ⲿ�Ѿ����죬ConfigureParametersֻ�Ƕ���Щ�ⲿ�����parameters��������</remarks>
    /// <param name="sqlString">sql����洢���̣�����������ܲ���һ��ʹ��</param>
    /// <param name="parameters">Ҫ�󶨲������Ͳ������͵����ݲ�������IDbDataParameter[]��</param>
    public delegate void ConfigureParameters(string sqlString, params IDbDataParameter[] parameters);

    /// <summary>
    /// ��IDataReader�ĵ�rowNumber��,�������н��ӳ��Ϊobject���͵Ķ��󷵻�.
    /// </summary>
    ///  <remark>
    /// ʵ���಻�ܵ���results��read()����<see cref="System.Data.IDataReader.Read()"/> .
    /// </remark>
    /// <param name="reader">����Ҫ��ȡ�����ݵ�IDataReader</param>
    /// <param name="rowNumber">��ǰ���к�,ĳЩ����ʵ�ֿ��ܲ�����Ҫ�ò���,���Ժ��Ի�ָ��һ�����ܲ���Ӱ�����.</param>
    /// <returns>
    /// ���Ͷ���,������domain��,Ҳ������map,list�ȼ�����.
    /// </returns> 
    public delegate object MapRow(IDataReader reader, int rowNumber);

    /// <summary>
    /// ���ͻ�MapRow,��IDataReader�еļ�¼ӳ��Ϊ�ض��Ķ�������.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reader"></param>
    /// <param name="rowNumber"></param>
    /// <returns></returns>     
    public delegate T MapRow<T>(IDataReader reader, int rowNumber);

    #endregion

    /// <summary>
    /// �ṩ�˶�΢����ҵ��Data Block���ֵķ�װ.
    /// ��Ҫ��װ��ͨ���洢���̺�sqlִ�����ݿ�����Ĳ���.
    /// ����û�з�װ�Ĺ���,�ͻ��˿���ͨ��public Database RowDatabase������ȡ�ײ��Database����.
    /// </summary>
    /// <remarks>
    /// ����û��ʹ��DataBase�е�AddInParameter,AddOutParameter,AddParameter�Ȳ����󶨷���,�����Լ��ṩ��AddParameters�ܱ�������,�ͻ�����Ҫ�Լ�������Ӧsql��IDbDataParameter[]����.
    /// �������Ա�����ҵ����ֻʹ��DbType������ʹ�����ݿ��������Ͳ�������ľ���(����OracleType.Cursor),ͬʱҲΪ�������洴��������.
    /// </remarks>
    /// <todo>ʹ��΢����ҵ���޸Ļ��湦�ܡ�</todo>
    public class DataBaseFacade
    {
        #region Fields
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _connectionName = string.Empty;
        #endregion

        #region ˽�й��캯��
        private DataBaseFacade(string connectionName)
        {
            _connectionName = connectionName;
        }

        private DataBaseFacade()
        {
            _connectionName = null;
        }
        #endregion

        #region ��ȡʵ���Ĺ�������
        /// <summary>
        /// ��ȡĬ�ϵ����ݿ�����,��config�ļ�������
        /// </summary>
        /// <returns></returns>
        public static DataBaseFacade GetInstance()
        {
            return new DataBaseFacade();
        }

        /// <summary>
        /// ָ��һ����������ݿ�����,��config�ļ�������
        /// </summary>
        /// <param name="connectionName">�����ļ��е������ַ�����name����</param>
        /// <returns></returns>
        public static DataBaseFacade GetInstance(string connectionName)
        {
            return new DataBaseFacade(connectionName);
        }
        #endregion

        #region ����
        /// <summary>
        /// ��ȡDatabaseʵ��,���û��ָ�����ݿ������ַ���ֱ�ӷ���Ĭ�ϵ����Ӷ�Ӧ��Database��
        /// </summary>
        /// <remarks>���ص�Database�Ѿ�ע�����¼�����������Щ�¼���������Ҫ�����¼��־���쳣����</remarks>
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
                //ע���¼�����������Щ�¼���������Ҫ�����¼��־���쳣����
                if (instrumentation != null)
                {
                    instrumentation.connectionFailed += new EventHandler<ConnectionFailedEventArgs>(instrumentation_connectionFailed);
                    instrumentation.commandFailed += new EventHandler<CommandFailedEventArgs>(instrumentation_commandFailed);
                    instrumentation.commandExecuted += new EventHandler<CommandExecutedEventArgs>(instrumentation_commandExecuted);
                }
                else
                {
                    DebugUtils.Debug(_log, "db.GetInstrumentationEventProvider() ����null,ȷ����DataInstrumentationProvider����.");
                }
                return db;
            }
        }
        #endregion

        #region connection and transaction

        /// <summary>
        /// ����һ����Ӧ����ʹ�õ����ݿ������,�������ַ���,������û�б���
        /// </summary>
        /// <returns>DbConnection</returns>
        public DbConnection CreateConnection()
        {
            return RowDatabase.CreateConnection();
        }
        /// <summary>
        /// <para>��һ������.��������򿪹����г����쳣����ͨ���쳣��ܴ�����쳣</para>
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
        /// �ڴ򿪵������Ͽ�ʼһ������.Ҫ���������ⲿ�Ѿ��򿪡�
        /// </summary>
        /// <param name="connection">�Ѿ��򿪵����ӡ�</param>
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
        /// �ع�����
        /// </summary>
        /// <param name="tran">DbTransaction</param>
        public void RollbackTransaction(DbTransaction tran)
        {
            tran.Rollback();
            DataBaseUtils.CloseConnection(tran.Connection);
        }

        /// <summary>
        /// �ع�����,���Ҵ����쳣����
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
        /// �ύ����
        /// </summary>
        /// <param name="tran">DbTransaction</param>
        public void CommitTransaction(DbTransaction tran)
        {
            tran.Commit();
        }
        #endregion

        #region stored procedures
        /// <summary>
        /// ִ�д洢���̣�����IDataReader
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        /// <returns>IDataReader</returns>
        public IDataReader SPExecuteReader(string spName, params object[] paramValues)
        {
            //����ʹ��using�ͷ�Command��Connection��Դ�����򷵻ص�reader�������á�
            Database db = RowDatabase;
            DbCommand cmd = db.GetStoredProcCommand(spName, paramValues);
            IDataReader reader = db.ExecuteReader(cmd);
            return reader;
        }

        /// <summary>
        /// ִ�д洢���̣�����DataSet
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
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
        /// ִ�д洢���̲�ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        /// <returns>object ������е�һ�еĵ�һ�л�����ã���������Ϊ�գ���</returns>
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
        /// ִ�д洢���̣�Insert,Update,Delete�ȷǲ�ѯ������,��Ӱ���������
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>��Ӱ������������� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��</remarks>
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
        /// ִ�д洢���̣�Insert,Update,Delete�ȷǲ�ѯ������,��Ӱ���������
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="tran">The tran.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns></returns>
        /// <remarks>��Ӱ������������� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��</remarks>
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
        /// ִ�д洢����,���ؽ�����е�һ����¼ӳ��Ϊһ��������󷵻ء�
        /// </summary>
        /// <param name="spName">Ҫִ�еĴ洢������</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>object mapRowDelegate���صĶ���</returns>
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
        /// ִ�д洢����,��������м�¼ӳ��Ϊ������󲢷���һ��object List��
        /// </summary>
        /// <param name="spName">Ҫִ�еĴ洢������</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
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
        /// ִ�д洢���̣�����IDataReader
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>
        /// ����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�
        /// ���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�
        /// </remarks>
        /// <returns>IDataReader</returns>       
        public IDataReader SPQueryForReader(string spName, params object[] paramValues)
        {
            return this.SPExecuteReader(spName, paramValues);
        }

        /// <summary>
        /// ִ�д洢���̣�����DataSet
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        /// <returns>DataSet</returns>
        public DataSet SPQueryForDataSet(string spName, params object[] paramValues)
        {
            return this.SPExecuteDataSet(spName, paramValues);
        }

        /// <summary>
        /// ִ�д洢���̲�ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        /// <returns>object ������е�һ�еĵ�һ�л�����ã���������Ϊ�գ���</returns>
        public object SPQueryForScalar(string spName, params object[] paramValues)
        {
            return this.SPExecuteScalar(spName, paramValues);
        }

        /// <summary>
        /// ִ�д洢���̣�Insert,Update,Delete�ȷǲ�ѯ������,��Ӱ���������
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <remarks>��Ӱ������������� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��</remarks>
        public int SPNonQuery(string spName, params object[] paramValues)
        {
            return this.SPExecuteNonQuery(spName, paramValues);
        }

        /// <summary>
        /// ִ�д洢���̣�Insert,Update,Delete�ȷǲ�ѯ������,��Ӱ���������
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns></returns>
        /// <remarks>��Ӱ������������� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��</remarks>
        public int SPNonQuery(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteNonQuery(spName, paramValues);
        }
        #endregion

        #region SQL
        /// <summary>
        /// ִ��sql��䣬����IDataReader�����ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="parameters">��������</param>
        /// <returns>IDataReader</returns>
        /// <remarks>���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�</remarks>
        public IDataReader SQLExecuteReader(string sql, params IDbDataParameter[] parameters)
        {
            //����ʹ��using�ͷ�Command��Connection��Դ�����򷵻ص�reader�������á�
            Database db = RowDatabase;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            AddParameters(cmd, parameters);
            IDataReader reader = db.ExecuteReader(cmd);
            DebugUtils.Debug(_log, cmd.CommandText);
            return reader;

        }

        /// <summary>
        /// SQLs the execute list.
        /// ͨ��sql����IDbDataParameter����ִ��sql��Ȼ����MapRow���ض����������List�С�
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
        /// ���ط��ͻ�List��ͨ��sql����IDbDataParameter����ִ��sql��Ȼ����MapRow<T>���ض����������List�С�
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
        /// ͨ��sql����IDbDataParameter����ִ��sql��Ȼ����MapRow���ض���
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
        /// ִ��sql��䣬����DataSet���û�������Ҫ�󶨵Ĳ�����ֵ���飬ͨ��BindParameters���а󶨡�         
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="parameters">��������</param>
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
        /// �����Ҫ���ض�����뿼��ʹ��RowDataBase�е�ExecuteDataSet������
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
        /// �����Ҫ���ض�����뿼��ʹ��RowDataBase�е�ExecuteDataSet������
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns></returns>
        /// <remarks> �������ܿ���, �����Ҫ�Է��ص�DataTable���и���,������ʹ�ø÷���.���Լ���ȡDataAdapter��ʹ�������DataSet��DataTable��Ȼ������ͬ��DataAdapter������DataSet��DataTable��</remarks>
        public DataTable SQLExecuteDataTable(string sql, params IDbDataParameter[] selectParameters)
        {
            DebugUtils.Debug(_log, sql);
            return SQLExecuteDataTable(sql, string.Empty, selectParameters);
        }

        /// <summary>
        /// SQLs the execute data table.
        /// �������ܿ���, �����Ҫ�Է��ص�DataTable���и���,������ʹ�ø÷���.���Լ���ȡDataAdapter��ʹ�������DataSet��DataTable��Ȼ������ͬ��DataAdapter������DataSet��DataTable��
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
        /// ִ�в�ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="parameters">��������</param>
        /// <returns>object ������е�һ�еĵ�һ�л�����ã���������Ϊ�գ�</returns>
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
        /// ִ�зǲ�ѯ��sql��䣬���� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="parameters">��������</param>
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
        /// ��ָ����������ִ��sql���.
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="transaction">����������</param>
        /// <param name="parameters">��������</param>
        /// <returns>int</returns>
        /// <remarks>����������һ��������������ִ��</remarks>
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
        /// ��ָ��������������ִ��sql���.
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="transaction">����������</param>
        /// <param name="parameters">��������</param>
        /// <returns>int</returns>
        /// <remarks>����������һ��������������ִ��</remarks>
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
        /// ��ָ��������������ִ��sql���.
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="transaction">����������</param>
        /// <param name="parameters">��������</param>
        /// <returns>int</returns>
        /// <remarks>����������һ��������������ִ��</remarks>
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
        /// ִ��sql��䣬����IDataReader���û�������Ҫ�󶨵Ĳ�����ֵ���飬ͨ��configureParametersDelegate���в������á�
        /// ���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>IDataReader</returns>
        /// <remarks>���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�</remarks>
        public IDataReader SQLQueryForReader(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteReader(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>       
        /// ִ��sql��ѯ,���ؽ�����е�һ����¼ӳ��Ϊһ��������󷵻ء�
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>object mapRowDelegate���صĶ���</returns>
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
        /// ͨ��id��ȡһ�����󣬸÷���Ҫ��sql�İ󶨲���ֻ��һ���������Ǳ��id���������ֱ�����ID������id������DbType.String���͡�
        /// ���ƱȽ϶ࡣ
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
        /// ִ��sql��ѯ,��������м�¼ӳ��Ϊ������󲢷���һ��object List��
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
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

        //�����˶Է��͵�֧��

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
        /// ִ��sql��ѯ,����DataSet��
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
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
        /// ִ��sql��ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>object ���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���</returns>
        public object SQLQueryForScalar(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteScalar(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>       
        /// ִ�зǲ�ѯ��sql��䣬���� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql���</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">��������</param>
        /// <returns>int ���� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��</returns>
        public int SQLNonQuery(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteNonQuery(sqlString, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }
        /// <summary>
        /// ��һ��������ִ��һ���ǲ�ѯ��sql��䡣
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql���</param>
        /// <param name="transaction">����������</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>int ���� UPDATE��INSERT �� DELETE ��䣬����ֵΪ��������Ӱ������������������������͵���䣬����ֵΪ -1��</returns>
        public int SQLNonQuery(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteNonQuery(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }
        #endregion

        #region commands and parameters

        /// <summary>
        /// Builds the SQL command.
        /// �¹�������������Connection������Connection��״̬��connectionOpened����
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
        /// Builds the SQL command.�¹�����������û��Connection.
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        /// <remarks>�¹�����������û��Connection</remarks>
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
        /// �¹�������������Connection������Connection��״̬��connectionOpened����
        /// </summary>
        /// <param name="sqlString">The SQL string.</param>
        /// <param name="connectionOpened">if set to <c>true</c> [connection opened].</param>
        /// <param name="configureParametersDelegate">The configure parameters delegate.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        /// <remarks>�¹�������������Connection������Connection��״̬��connectionOpened����</remarks>
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
        /// Creates the SQL command.����û������Ҳû��Sql����DbCommand
        /// </summary>
        /// <returns>û������Ҳû��Sql����DbCommand</returns>
        public DbCommand CreateSqlCommand()
        {
            DbCommand cmd = this.RowDatabase.DbProviderFactory.CreateCommand();
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// Creates the SP command.����û������Ҳû��SP����DbCommand
        /// </summary>
        /// <returns>û������Ҳû��SP����DbCommand</returns>
        public DbCommand CreateSPCommand()
        {
            DbCommand cmd = this.RowDatabase.DbProviderFactory.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        /// <summary>
        /// ����������ø��࣬����Ĺ��������
        /// ����QueryForObject�ж����ϵӳ��,����ͨ��MapRow����ʵ�ֵ�.
        /// </summary>
        /// <returns>IDbDataParameter</returns>
        public DbParameter CreateParameter()
        {
            return this.RowDatabase.DbProviderFactory.CreateParameter();
        }

        /// <summary>
        /// �������๹��������顣
        /// </summary>
        /// <param name="arrayLength">���鳤��</param>
        /// <returns>IDbDataParameter[]</returns>
        public DbParameter[] CreateParameterArray(int arrayLength)
        {
            if (arrayLength < 0)
            {
                throw new ArgumentException("����IDbDataParameter��������鳤�Ȳ���Ϊ��.");
            }

            DbParameter[] parameters = new DbParameter[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                parameters[i] = CreateParameter();
            }

            return parameters;
        }

        /// <summary>
        /// Ϊcmd���parameters
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
        /// ��������ѱ�������ֱ�ӷ��ء�
        /// �����жϴ����sql�Ƿ�����Ҫ�󶨵Ĳ��������û��,���ؿղ�������IDbDataParameter[0]��
        /// ���򴴽����󶨣����沢���ظò������顣
        /// �����󶨹�����Ҫ�����Լ�ʵ�֡�
        /// </summary>
        /// <remarks>
        /// ע�⣬��һ��DAO�����кܶ�sql��������Щsql�ж���һ��Ҫ�󶨲�����������ʵ��ʱ���øò����Ϳ��ܲ������㡣
        /// ����������Բ�ֱ��ʹ�ø÷�������ʹ�ú͸���ʵ�����Ƶķ����Լ����첢�󶨲�����Ҳ��������д��BindParams�����н�������ѡ��
        /// ����÷����Ƿ���Ч��Ҳ������this.CountParameterPlaceholders(sqlString, placeHolder, delim)�����Ƿ���Ч��
        /// placeHolder�ǲ�����־ռλ��������Oracleʹ��":",SQLServerʹ��"@"��
        /// delims�Ƿָ������У���������е���һ���ָ����У�0-1��2-3��4-5��6��������ͬ�ķָ���֮���placeholder�������㡣
        /// ����һ���ַ���Ϊ"this is my  ? 'delims test?'",placeholderΪ?,��delimitersΪ',��'delims test?'�еģ�����������
        /// </remarks>
        /// <param name="sqlString">һ��sql���,��Ϊ�����Cache Key</param>
        /// <param name="placeHolder">չλ����Ҳ������������ǰ׺��</param>
        /// <param name="delims">�ָ����е�placeHolder�������������ڡ�</param>
        /// <param name="configureParametersDelegate">�������ò��������ж�Ӧ�����Ĳ������Ͳ������͵Ȳ������ԡ�</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>IDbDataParameter[]</returns>
        public IDbDataParameter[] GetCachedParameters(string sqlString, char placeHolder, string delims, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            int paramCount = this.CountParameters(sqlString, placeHolder, delims);
            //���û����Ҫ�󶨵Ĳ�����ֱ�ӷ���new IDbDataParameter[0];
            if (paramCount <= 0)
            {
                //DebugUtils.Debug(_log, string.Format("GetCachedParameters found paramCount <= 0 in sql:{0}", sqlString));
                return new IDbDataParameter[0];
            }
            string cacheKey = GenerateCacheKey(sqlString);

            //�������ԭ��û�л����Ϊsql�������󶨲������Ͳ�������,Ȼ�󻺴�,���󶨲���ֵ.
            //���ԭ���Ѿ�����,��ֱ�Ӱ󶨲���ֵ.
            IDbDataParameter[] cachedParams = DataBaseUtils.GetCachedParameters(cacheKey);
            if (cachedParams == null)
            {
                //DebugUtils.Debug(_log, string.Format("GetCachedParameters found paramCount = {0} in sql: '{1}'", paramCount, sqlString));
                //����ԭ��û�б�����.
                cachedParams = CreateParameterArray(paramCount);
                //���Ȱ󶨲�����������,Ȼ�󻺴�
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
                    _log.Warn("GetCachedParameters the bindvalues array 'object[] values' is null �� length==0.�߼������ǲ���ȷ��.");
                }
            }
            else
            {
                //�󶨲���ֵ
                BindValues(cachedParams, values);
            }

            return cachedParams;
        }

        /// <summary>
        /// ��������ѱ�������ֱ�ӷ��ء�
        /// �����жϴ����sql�Ƿ�����Ҫ�󶨵Ĳ��������û��,���ؿղ�������IDbDataParameter[0]��
        /// ���򴴽����󶨣����沢���ظò������顣
        /// �����󶨹�����Ҫ�����Լ�ʵ�֡�
        /// ����ǰ׺Ĭ��Ϊ":",�ָ���Ĭ��Ϊ"'"��
        /// </summary>
        /// <param name="sqlString">һ��sql���,��Ϊ�����Cache Key</param>
        /// <param name="configureParametersDelegate">�������ò��������ж�Ӧ�����Ĳ������Ͳ������͵Ȳ������ԡ�</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>IDbDataParameter[]</returns>
        public virtual IDbDataParameter[] GetCachedParameters(string sqlString, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return GetCachedParameters(sqlString, ':', "'", configureParametersDelegate, values);
        }

        /// <summary>
        /// �󶨲���ֵ.Ĭ��ʵ���в��������Ͳ���ֵ�������,�������һһ��Ӧ.
        /// �ͻ��˿���ͨ�����ظ÷���ʵ���Լ��Ĳ���ֵ�󶨲���.
        /// </summary>
        /// <remarks>һ��Ҫ��֤�����Ͳ���ֵ�ǰ����һһ��Ӧ��.Ҳ������ConfigureParameters���������õĲ���������Ĳ���ֵ�����Ӧ</remarks>
        /// <param name="parameters">��������</param>
        /// <param name="values">����ֵ����</param>
        public void BindValues(IDbDataParameter[] parameters, object[] values)
        {
            if (parameters == null || values == null || values.Length != parameters.Length)
            {
                if (_log.IsWarnEnabled)
                {
                    _log.Warn("Method GetCachedParameters ��������ĳ���Ӧ�ú�ֵ����ĳ�����ͬ��");
                }
                throw new DataAcessException("�����󶨳��ִ���,��������Ͳ���ֵ���鳤��Ӧ����ͬ��");
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
        /// ����һ������ļ�ֵ,��ʵ�ֵ����ɹ�����:
        /// �����ַ��� + '-' + �����sql�ַ���,��֤ͬһ��������sql��Ψһ��.
        /// </summary>
        /// <param name="sqlString">sql����ַ���</param>
        /// <returns>ΪsqlString����һ�������</returns>
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
        /// Gets the data adapter.����һ���������ݿ��DbDataAdapter��
        /// </summary>
        /// <returns>DbDataAdapter</returns>
        public DbDataAdapter GetDataAdapter()
        {
            return RowDatabase.GetDataAdapter();
        }

        /// <summary>
        /// Gets the data adapter.ͨ��querySql����SelectCommand����,���ҳ�ʼ������,��������û�д�.
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
        /// Gets the data adapter.ͨ��querySql�ʹ���Ĳ���ֵ����SelectCommand����,���ҳ�ʼ������,��������û�д�.
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
                _log.Warn(string.Format("���Ӵ���,�����ַ���Ϊ:{0}", e.ConnectionString), e.Exception);
            }

            ExceptionPolicy.HandleException(e.Exception, "ConnectionFailed Log And Wrap Policy");
        }

        void instrumentation_commandFailed(object sender, CommandFailedEventArgs e)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(string.Format("����ִ��ʧ��,�����ַ���Ϊ:{0},�����ַ���Ϊ:{1}.", e.CommandText, e.ConnectionString), e.Exception);
            }
            ExceptionPolicy.HandleException(e.Exception, "CommandFailed Wrap Policy");
        }

        void instrumentation_commandExecuted(object sender, CommandExecutedEventArgs e)
        {
            //DebugUtils.Debug(_log,e.
        }

        /// <summary>
        /// �ж�һ��sql����е����������ĸ�����
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="placeholder">����ǰ׺������oracle��:������sql��@.</param>
        /// <param name="delimiters">delimiters���г��ֵ�placeholder������������.</param>
        /// <returns>��������</returns>
        private int CountParameters(string sqlString, char placeholder, string delimiters)
        {
            return StringUtils.CountPlaceholders(sqlString, placeholder, delimiters);
        }

        #endregion

        #region new added,transaction support
        /// <summary>
        /// ִ�д洢���̣�����DataSet
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns>DataSet</returns>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
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
        /// ִ�д洢���̣�����IDataReader
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns>IDataReader</returns>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        public IDataReader SPExecuteReader(string spName, DbTransaction transaction, params object[] paramValues)
        {
            //����ʹ��using�ͷ�Command��Connection��Դ�����򷵻ص�reader�������á�
            Database db = RowDatabase;
            DbCommand cmd = db.GetStoredProcCommand(spName, paramValues);
            IDataReader reader = db.ExecuteReader(cmd, transaction);
            return reader;
        }

        /// <summary>
        /// ִ�д洢���̲�ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns>object ������е�һ�еĵ�һ�л�����ã���������Ϊ�գ���</returns>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
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
        /// ִ�д洢���̣�����DataSet
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns>DataSet</returns>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        public DataSet SPQueryForDataSet(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteDataSet(spName, transaction, paramValues);
        }

        /// <summary>
        /// ִ�д洢���̣�����IDataReader
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns>IDataReader</returns>
        /// <remarks>
        /// ����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�
        /// ���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�
        /// </remarks>
        public IDataReader SPQueryForReader(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteReader(spName, transaction, paramValues);
        }

        /// <summary>       
        /// ִ�д洢����,��������м�¼ӳ��Ϊ������󲢷���һ��object List��
        /// </summary>
        /// <param name="spName">Ҫִ�еĴ洢������</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
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
        /// ִ�д洢����,���ؽ�����е�һ����¼ӳ��Ϊһ��������󷵻ء�
        /// </summary>
        /// <param name="spName">Ҫִ�еĴ洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>object mapRowDelegate���صĶ���</returns>
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
        /// ִ�д洢���̲�ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="spName">�洢������������а���Ҫ:����+��.��+�洢������</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="paramValues">�洢���̵Ĳ���ֵ�����û�в�����ʡ�Ըò�������Ҫ����null��</param>
        /// <returns>object ������е�һ�еĵ�һ�л�����ã���������Ϊ�գ���</returns>
        /// <remarks>����ֵ�����в���ֵ��˳������ͱ���ʹ洢�����в�����˳�������һ�¡�</remarks>
        public object SPQueryForScalar(string spName, DbTransaction transaction, params object[] paramValues)
        {
            return this.SPExecuteScalar(spName, transaction, paramValues);
        }

        /// <summary>
        /// SQLs the execute data set.
        /// �����Ҫ���ض�����뿼��ʹ��RowDataBase�е�ExecuteDataSet������
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
        /// ִ��sql��䣬����DataSet���û�������Ҫ�󶨵Ĳ�����ֵ���飬ͨ��BindParameters���а󶨡�
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">��������</param>
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
        /// �����Ҫ���ض�����뿼��ʹ��RowDataBase�е�ExecuteDataSet������
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="selectParameters">The select parameters.</param>
        /// <returns></returns>
        /// <remarks> �������ܿ���, �����Ҫ�Է��ص�DataTable���и���,������ʹ�ø÷���.���Լ���ȡDataAdapter��ʹ�������DataSet��DataTable��Ȼ������ͬ��DataAdapter������DataSet��DataTable��</remarks>
        public DataTable SQLExecuteDataTable(string sql, DbTransaction transaction, params IDbDataParameter[] selectParameters)
        {
            DebugUtils.Debug(_log, sql);
            return SQLExecuteDataTable(sql, transaction, string.Empty, selectParameters);
        }

        /// <summary>
        /// SQLs the execute data table.
        /// �������ܿ���, �����Ҫ�Է��ص�DataTable���и���,������ʹ�ø÷���.���Լ���ȡDataAdapter��ʹ�������DataSet��DataTable��Ȼ������ͬ��DataAdapter������DataSet��DataTable��
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
        /// ���ط��ͻ�List��ͨ��sql����IDbDataParameter����ִ��sql��Ȼ����MapRow<T>���ض����������List�С�
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
        /// ͨ��sql����IDbDataParameter����ִ��sql��Ȼ����MapRow���ض����������List�С�
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
        /// ͨ��sql����IDbDataParameter����ִ��sql��Ȼ����MapRow���ض���
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
        /// ִ��sql��䣬����IDataReader�����ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">��������</param>
        /// <returns>IDataReader</returns>
        /// <remarks>���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�</remarks>
        public IDataReader SQLExecuteReader(string sql, DbTransaction transaction, params IDbDataParameter[] parameters)
        {
            //����ʹ��using�ͷ�Command��Connection��Դ�����򷵻ص�reader�������á�
            Database db = RowDatabase;
            DbCommand cmd = db.GetSqlStringCommand(sql);
            AddParameters(cmd, parameters);
            IDataReader reader = db.ExecuteReader(cmd, transaction);
            DebugUtils.Debug(_log, cmd.CommandText);
            return reader;
        }

        /// <summary>
        /// ִ�в�ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">��������</param>
        /// <returns>object ������е�һ�еĵ�һ�л�����ã���������Ϊ�գ�</returns>
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
        /// ִ��sql��ѯ,����DataSet��
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
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
        /// ִ��sql��ѯ,���ؽ�����е�һ����¼ӳ��Ϊһ��������󷵻ء�
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="mapRowDelegate">���ڹ�ϵ����ӳ��</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>object mapRowDelegate���صĶ���</returns>
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
        /// ִ��sql��䣬����IDataReader���û�������Ҫ�󶨵Ĳ�����ֵ���飬ͨ��configureParametersDelegate���в������á�
        /// ���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>IDataReader</returns>
        /// <remarks>���ص�Reader�Ǵ򿪵ģ�ʹ�����Ժ���Ҫ����رա�</remarks>
        public IDataReader SQLQueryForReader(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteReader(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>
        /// ִ��sql��ѯ,���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���
        /// </summary>
        /// <param name="sqlString">Ҫִ�е�sql��ѯ���</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="configureParametersDelegate">��������sql������������</param>
        /// <param name="values">����ֵ����</param>
        /// <returns>object ���ؽ�����е�һ�еĵ�һ�л�����ã���������Ϊ�գ���</returns>
        public object SQLQueryForScalar(string sqlString, DbTransaction transaction, ConfigureParameters configureParametersDelegate, params object[] values)
        {
            return this.SQLExecuteScalar(sqlString, transaction, this.GetCachedParameters(sqlString, configureParametersDelegate, values));
        }

        /// <summary>
        /// SQLs the query for object by id.
        /// ͨ��id��ȡһ�����󣬸÷���Ҫ��sql�İ󶨲���ֻ��һ���������Ǳ��id���������ֱ�����ID������id������DbType.String���͡�
        /// ���ƱȽ϶ࡣ
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
