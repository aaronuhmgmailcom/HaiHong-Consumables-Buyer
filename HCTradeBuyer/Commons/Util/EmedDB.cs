using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Emedchina.Commons
{

    /// <summary>
    /// 数据库处理辅助类
    /// </summary>
    public sealed class EmedDB
    {
        static EmedDB()
        {
            EmedDB.DBMS = "";
            EmedDB.connStr = "";
            EmedDB.DBErrorMsg = "";
            EmedDB.SQLRowIndex = 0;
            EmedDB.DBErrorSQL = "";
            EmedDB.msg = "";
        }

        private EmedDB()
        {
        }

        public static void CloseDB()
        {
        }

        /// <summary>
        /// 批量执行SQL
        /// </summary>
        /// <param name="inSQL">源SQL</param>
        /// <returns></returns>
        public static bool ExcuteSql(string[] inSQL)
        {
            bool flag1 = true;
            OleDbConnection connection1 = new OleDbConnection(EmedDB.connStr);
            try
            {
                connection1.Open();
                OleDbCommand command1 = new OleDbCommand();
                for (int num1 = 0; num1 < inSQL.Length; num1++)
                {
                    if (inSQL[num1].Trim().CompareTo("") != 0)
                    {
                        command1 = new OleDbCommand(inSQL[num1], connection1);
                        try
                        {
                            command1.ExecuteNonQuery();
                        }
                        catch (Exception exception1)
                        {
                            string text1 = DateTime.Now.ToString() + "\t" + exception1.Message + "\t" + inSQL[num1];
                            EmedDB.SaveErrorToLog(text1, inSQL[num1]);
                            flag1 = false;
                        }
                    }
                }
                command1.Dispose();
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedDB.SaveErrorToLog(exception2.Message, "Some sql exectue has error");
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        /// <summary>
        /// 单条执行SQL
        /// </summary>
        /// <param name="inSQL"></param>
        /// <returns></returns>
        public static bool ExcuteSql(string inSQL)
        {
            bool flag1 = false;
            OleDbConnection connection1 = new OleDbConnection(EmedDB.connStr);
            try
            {
                connection1.Open();
                OleDbCommand command1 = new OleDbCommand(inSQL, connection1);
                try
                {
                    if (command1.ExecuteNonQuery() > -1)
                    {
                        flag1 = true;
                    }
                }
                catch (Exception exception1)
                {
                    string text1 = DateTime.Now.ToString() + "\t" + exception1.Message + "\t" + inSQL;
                    EmedDB.SaveErrorToLog(text1, inSQL);
                    flag1 = false;
                }
                finally
                {
                    command1.Dispose();
                }
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedDB.SaveErrorToLog(exception2.Message, inSQL);
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        /// <summary>
        /// 批量执行SQL
        /// </summary>
        /// <param name="inSQL"></param>
        /// <param name="inConString"></param>
        /// <returns></returns>
        public static bool ExcuteSql(string[] inSQL, string inConString)
        {
            bool flag1 = true;
            OleDbConnection connection1 = new OleDbConnection(inConString);
            try
            {
                connection1.Open();
                OleDbCommand command1 = new OleDbCommand();
                for (int num1 = 0; num1 < inSQL.Length; num1++)
                {
                    if (inSQL[num1].Trim().CompareTo("") != 0)
                    {
                        command1 = new OleDbCommand(inSQL[num1], connection1);
                        try
                        {
                            command1.ExecuteNonQuery();
                        }
                        catch (Exception exception1)
                        {
                            string text1 = DateTime.Now.ToString() + "\t" + exception1.Message + "\t" + inSQL[num1];
                            EmedDB.SaveErrorToLog(text1, inSQL[num1]);
                            flag1 = false;
                        }
                    }
                }
                command1.Dispose();
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedDB.SaveErrorToLog(exception2.Message, "Some sql exectue has error");
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        /// <summary>
        /// 单条执行SQL
        /// </summary>
        /// <param name="inSQL"></param>
        /// <param name="inConString"></param>
        /// <returns></returns>
        public static bool ExcuteSql(string inSQL, string inConString)
        {
            bool flag1 = false;
            OleDbConnection connection1 = new OleDbConnection(inConString);
            try
            {
                connection1.Open();
                OleDbCommand command1 = new OleDbCommand(inSQL, connection1);
                try
                {
                    if (command1.ExecuteNonQuery() > -1)
                    {
                        flag1 = true;
                    }
                }
                catch (Exception exception1)
                {
                    string text1 = DateTime.Now.ToString() + "\t" + exception1.Message + "\t" + inSQL;
                    EmedDB.SaveErrorToLog(text1, inSQL);
                    flag1 = false;
                }
                finally
                {
                    command1.Dispose();
                }
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedDB.SaveErrorToLog(exception2.Message, inSQL);
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        /// <summary>
        /// 通过SQL查询返回数据集
        /// </summary>
        /// <param name="inSelectSQL"></param>
        /// <returns></returns>
        public static DataSet getDataSet(string inSelectSQL)
        {
            OleDbConnection connection1 = new OleDbConnection(EmedDB.connStr);
            DataSet set1 = new DataSet();
            try
            {
                connection1.Open();
                new OleDbDataAdapter(inSelectSQL, connection1).Fill(set1, "uncnet");
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedDB.SaveErrorToLog(exception1.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static DataSet getDataSet(string[] inSelectSQL)
        {
            OleDbConnection connection1 = new OleDbConnection(EmedDB.connStr);
            DataSet set1 = new DataSet();
            EmedDB.SQLRowIndex = 0;
            try
            {
                connection1.Open();
                for (int num1 = 0; num1 < inSelectSQL.Length; num1++)
                {
                    EmedDB.SQLRowIndex = num1;
                    new OleDbDataAdapter(inSelectSQL[num1], connection1).Fill(set1, "uncnet" + num1.ToString());
                }
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedDB.SaveErrorToLog(exception1.Message, inSelectSQL[EmedDB.SQLRowIndex]);
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static DataSet getDataSet(string[] inSelectSQL, string inConString)
        {
            OleDbConnection connection1 = new OleDbConnection(inConString);
            DataSet set1 = new DataSet();
            EmedDB.SQLRowIndex = 0;
            try
            {
                connection1.Open();
                for (int num1 = 0; num1 < inSelectSQL.Length; num1++)
                {
                    EmedDB.SQLRowIndex = num1;
                    new OleDbDataAdapter(inSelectSQL[num1], connection1).Fill(set1, "uncnet" + num1.ToString());
                }
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedDB.SaveErrorToLog(exception1.Message, inSelectSQL[EmedDB.SQLRowIndex]);
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static DataSet getDataSet(string inSelectSQL, string inConString)
        {
            OleDbConnection connection1 = new OleDbConnection(inConString);
            DataSet set1 = new DataSet();
            try
            {
                connection1.Open();
                new OleDbDataAdapter(inSelectSQL, connection1).Fill(set1, "uncnet");
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedDB.SaveErrorToLog(exception1.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static string getScalar(string inSelectSQL)
        {
            if (inSelectSQL.CompareTo("") == 0)
            {
                return null;
            }
            string text1 = null;
            OleDbConnection connection1 = new OleDbConnection(EmedDB.connStr);
            try
            {
                connection1.Open();
                OleDbCommand command1 = new OleDbCommand(inSelectSQL, connection1);
                try
                {
                    object obj1 = command1.ExecuteScalar();
                    if (obj1 == null)
                    {
                        text1 = null;
                    }
                    else
                    {
                        text1 = obj1.ToString();
                    }
                }
                catch (Exception exception1)
                {
                    EmedDB.SaveErrorToLog(exception1.Message, inSelectSQL);
                    text1 = null;
                }
                finally
                {
                    command1.Dispose();
                }
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedDB.SaveErrorToLog(exception2.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return text1;
        }

        public static string getScalar(string inSelectSQL, string inConString)
        {
            if (inSelectSQL.CompareTo("") == 0)
            {
                return null;
            }
            string text1 = null;
            OleDbConnection connection1 = new OleDbConnection(inConString);
            try
            {
                connection1.Open();
                OleDbCommand command1 = new OleDbCommand(inSelectSQL, connection1);
                try
                {
                    object obj1 = command1.ExecuteScalar();
                    if (obj1 == null)
                    {
                        text1 = null;
                    }
                    else
                    {
                        text1 = obj1.ToString();
                    }
                }
                catch (Exception exception1)
                {
                    EmedDB.SaveErrorToLog(exception1.Message, inSelectSQL);
                    text1 = null;
                }
                finally
                {
                    command1.Dispose();
                }
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedDB.SaveErrorToLog(exception2.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return text1;
        }

        public static void Refresh()
        {
        }

        private static void SaveErrorToLog(string inErrorLog, string inSQL)
        {
            string text1 = Application.StartupPath + @"\ErrorLog.txt";
            try
            {
                StreamWriter writer1 = new StreamWriter(text1, true, Encoding.GetEncoding("GB2312"));
                writer1.WriteLine(DateTime.Now.ToString() + ":");
                writer1.WriteLine(inErrorLog);
                writer1.WriteLine(inSQL);
                writer1.Close();
            }
            catch (Exception exception1)
            {
                string text2 = exception1.Message;
            }
        }

        public static bool TestConnection()
        {
            return EmedDB.TestConnection(EmedDB.connStr);
        }

        public static bool TestConnection(string inConntionString)
        {
            bool flag1;
            OleDbConnection connection1 = new OleDbConnection(inConntionString);
            try
            {
                connection1.Open();
                if (connection1.State == ConnectionState.Open)
                {
                    connection1.Close();
                    OleDbConnection.ReleaseObjectPool();
                    GC.Collect();
                    return true;
                }
                flag1 = false;
            }
            catch (Exception exception1)
            {
                EmedDB.SaveErrorToLog(exception1.Message, "TestConnection");
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
            }
            return flag1;
        }

        public static bool Transaction(string[] inSQL)
        {
            if (inSQL.Length < 1)
            {
                return true;
            }
            bool flag1 = false;
            OleDbConnection connection1 = new OleDbConnection(EmedDB.connStr);
            try
            {
                connection1.Open();
                OleDbTransaction transaction1 = connection1.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    for (int num1 = 0; num1 < inSQL.Length; num1++)
                    {
                        EmedDB.SQLRowIndex = num1;
                        EmedDB.DBErrorSQL = inSQL[num1];
                        if (inSQL[num1].CompareTo("") > 0)
                        {
                            OleDbCommand command1 = new OleDbCommand();
                            command1.Connection = connection1;
                            command1.CommandText = inSQL[num1];
                            command1.Transaction = transaction1;
                            command1.ExecuteNonQuery();
                        }
                    }
                    transaction1.Commit();
                    flag1 = true;
                }
                catch (Exception exception1)
                {
                    transaction1.Rollback();
                    flag1 = false;
                    EmedDB.SaveErrorToLog(exception1.Message, EmedDB.DBErrorSQL);
                }
                connection1.Close();
            }
            catch
            {
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OleDbConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        public static bool Transaction(string[] inSQL, string inConString)
        {
            if (inSQL.Length < 1)
            {
                return true;
            }
            bool flag1 = false;
            using (OleDbConnection connection1 = new OleDbConnection(inConString))
            {
                try
                {
                    connection1.Open();
                    OleDbTransaction transaction1 = connection1.BeginTransaction(IsolationLevel.ReadCommitted);
                    
                    try
                    {
                        for (int num1 = 0; num1 < inSQL.Length; num1++)
                        {
                            EmedDB.SQLRowIndex = num1;
                            EmedDB.DBErrorSQL = inSQL[num1];
                            if (inSQL[num1].CompareTo("") > 0)
                            {
                                OleDbCommand command1 = new OleDbCommand();
                                command1.Connection = connection1;
                                command1.CommandText = inSQL[num1];
                                command1.Transaction = transaction1;
                                command1.ExecuteNonQuery();
                            }
                        }
                        transaction1.Commit();
                        flag1 = true;
                    }
                    catch (Exception exception1)
                    {
                        transaction1.Rollback();
                        flag1 = false;
                        EmedDB.SaveErrorToLog(exception1.Message, EmedDB.DBErrorSQL);
                    }
                    connection1.Close();
                }
                catch
                {
                    flag1 = false;
                }
                finally
                {
                    connection1.Dispose();
                    OleDbConnection.ReleaseObjectPool();
                    GC.Collect();
                }
            }
            return flag1;
        }


        public static string ConnectionString
        {
            get
            {
                return EmedDB.connStr;
            }
            set
            {
                EmedDB.connStr = value;
            }
        }

        public static string Msg
        {
            get
            {
                return EmedDB.msg;
            }
            set
            {
                EmedDB.msg = value;
            }
        }


        private static string connStr;
        public static string DBErrorMsg;
        public static string DBErrorSQL;
        public static string DBMS;
        private static string msg;
        public static int SQLRowIndex;
    }
}

