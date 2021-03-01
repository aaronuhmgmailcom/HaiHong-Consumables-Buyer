using System;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Windows.Forms;

namespace Emedchina.Commons
{

    public class EmedOdbc
    {
        static EmedOdbc()
        {
            EmedOdbc.DBMS = "";
            EmedOdbc.connStr = "";
            EmedOdbc.DBErrorMsg = "";
            EmedOdbc.SQLRowIndex = 0;
            EmedOdbc.DBErrorSQL = "";
            EmedOdbc.msg = "";
        }

        public static void CloseDB()
        {
        }

        public static bool ExcuteSql(string[] inSQL)
        {
            bool flag1 = true;
            OdbcConnection connection1 = new OdbcConnection(EmedOdbc.connStr);
            try
            {
                connection1.Open();
                OdbcCommand command1 = new OdbcCommand();
                for (int num1 = 0; num1 < inSQL.Length; num1++)
                {
                    if (inSQL[num1].Trim().CompareTo("") != 0)
                    {
                        command1 = new OdbcCommand(inSQL[num1], connection1);
                        try
                        {
                            command1.ExecuteNonQuery();
                        }
                        catch (Exception exception1)
                        {
                            string text1 = DateTime.Now.ToString() + "\t" + exception1.Message + "\t" + inSQL[num1];
                            EmedOdbc.SaveErrorToLog(text1, inSQL[num1]);
                            flag1 = false;
                        }
                    }
                }
                command1.Dispose();
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedOdbc.SaveErrorToLog(exception2.Message, "Some sql exectue has error");
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        public static bool ExcuteSql(string inSQL)
        {
            bool flag1 = false;
            OdbcConnection connection1 = new OdbcConnection(EmedOdbc.connStr);
            try
            {
                connection1.Open();
                OdbcCommand command1 = new OdbcCommand(inSQL, connection1);
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
                    EmedOdbc.SaveErrorToLog(text1, inSQL);
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
                EmedOdbc.SaveErrorToLog(exception2.Message, inSQL);
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        public static bool ExcuteSql(string[] inSQL, string inConString)
        {
            bool flag1 = true;
            OdbcConnection connection1 = new OdbcConnection(inConString);
            try
            {
                connection1.Open();
                OdbcCommand command1 = new OdbcCommand();
                for (int num1 = 0; num1 < inSQL.Length; num1++)
                {
                    if (inSQL[num1].Trim().CompareTo("") != 0)
                    {
                        command1 = new OdbcCommand(inSQL[num1], connection1);
                        try
                        {
                            command1.ExecuteNonQuery();
                        }
                        catch (Exception exception1)
                        {
                            string text1 = DateTime.Now.ToString() + "\t" + exception1.Message + "\t" + inSQL[num1];
                            EmedOdbc.SaveErrorToLog(text1, inSQL[num1]);
                            flag1 = false;
                        }
                    }
                }
                command1.Dispose();
                connection1.Close();
            }
            catch (Exception exception2)
            {
                EmedOdbc.SaveErrorToLog(exception2.Message, "Some sql exectue has error");
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        public static bool ExcuteSql(string inSQL, string inConString)
        {
            bool flag1 = false;
            OdbcConnection connection1 = new OdbcConnection(inConString);
            try
            {
                connection1.Open();
                OdbcCommand command1 = new OdbcCommand(inSQL, connection1);
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
                    EmedOdbc.SaveErrorToLog(text1, inSQL);
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
                EmedOdbc.SaveErrorToLog(exception2.Message, inSQL);
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }

        public static DataSet getDataSet(string inSelectSQL)
        {
            OdbcConnection connection1 = new OdbcConnection(EmedOdbc.connStr);
            DataSet set1 = new DataSet();
            try
            {
                connection1.Open();
                new OdbcDataAdapter(inSelectSQL, connection1).Fill(set1, "uncnet");
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedOdbc.SaveErrorToLog(exception1.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static DataSet getDataSet(string[] inSelectSQL)
        {
            OdbcConnection connection1 = new OdbcConnection(EmedOdbc.connStr);
            DataSet set1 = new DataSet();
            EmedOdbc.SQLRowIndex = 0;
            try
            {
                connection1.Open();
                for (int num1 = 0; num1 < inSelectSQL.Length; num1++)
                {
                    EmedOdbc.SQLRowIndex = num1;
                    new OdbcDataAdapter(inSelectSQL[num1], connection1).Fill(set1, "uncnet" + num1.ToString());
                }
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedOdbc.SaveErrorToLog(exception1.Message, inSelectSQL[EmedOdbc.SQLRowIndex]);
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static DataSet getDataSet(string[] inSelectSQL, string inConString)
        {
            OdbcConnection connection1 = new OdbcConnection(inConString);
            DataSet set1 = new DataSet();
            EmedOdbc.SQLRowIndex = 0;
            try
            {
                connection1.Open();
                for (int num1 = 0; num1 < inSelectSQL.Length; num1++)
                {
                    EmedOdbc.SQLRowIndex = num1;
                    new OdbcDataAdapter(inSelectSQL[num1], connection1).Fill(set1, "uncnet" + num1.ToString());
                }
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedOdbc.SaveErrorToLog(exception1.Message, inSelectSQL[EmedOdbc.SQLRowIndex]);
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return set1;
        }

        public static DataSet getDataSet(string inSelectSQL, string inConString)
        {
            OdbcConnection connection1 = new OdbcConnection(inConString);
            DataSet set1 = new DataSet();
            try
            {
                connection1.Open();
                new OdbcDataAdapter(inSelectSQL, connection1).Fill(set1, "uncnet");
                connection1.Close();
            }
            catch (Exception exception1)
            {
                EmedOdbc.SaveErrorToLog(exception1.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
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
            OdbcConnection connection1 = new OdbcConnection(EmedOdbc.connStr);
            try
            {
                connection1.Open();
                OdbcCommand command1 = new OdbcCommand(inSelectSQL, connection1);
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
                    EmedOdbc.SaveErrorToLog(exception1.Message, inSelectSQL);
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
                EmedOdbc.SaveErrorToLog(exception2.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
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
            OdbcConnection connection1 = new OdbcConnection(inConString);
            try
            {
                connection1.Open();
                OdbcCommand command1 = new OdbcCommand(inSelectSQL, connection1);
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
                    EmedOdbc.SaveErrorToLog(exception1.Message, inSelectSQL);
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
                EmedOdbc.SaveErrorToLog(exception2.Message, inSelectSQL);
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
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
                StreamWriter writer1 = new StreamWriter(text1, true);
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
            return EmedOdbc.TestConnection(EmedOdbc.connStr);
        }

        public static bool TestConnection(string inConntionString)
        {
            bool flag1;
            OdbcConnection connection1 = new OdbcConnection(inConntionString);
            try
            {
                connection1.Open();
                if (connection1.State == ConnectionState.Open)
                {
                    connection1.Close();
                    OdbcConnection.ReleaseObjectPool();
                    GC.Collect();
                    return true;
                }
                flag1 = false;
            }
            catch (Exception exception1)
            {
                EmedOdbc.SaveErrorToLog(exception1.Message, "TestConnection");
                flag1 = false;
            }
            finally
            {
                connection1.Dispose();
                OdbcConnection.ReleaseObjectPool();
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
            OdbcConnection connection1 = new OdbcConnection(EmedOdbc.connStr);
            try
            {
                connection1.Open();
                OdbcTransaction transaction1 = connection1.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    for (int num1 = 0; num1 < inSQL.Length; num1++)
                    {
                        EmedOdbc.SQLRowIndex = num1;
                        EmedOdbc.DBErrorSQL = inSQL[num1];
                        if (inSQL[num1].CompareTo("") > 0)
                        {
                            OdbcCommand command1 = new OdbcCommand();
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
                    EmedOdbc.SaveErrorToLog(exception1.Message, EmedOdbc.DBErrorSQL);
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
                OdbcConnection.ReleaseObjectPool();
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
            OdbcConnection connection1 = new OdbcConnection(inConString);
            try
            {
                connection1.Open();
                OdbcTransaction transaction1 = connection1.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    for (int num1 = 0; num1 < inSQL.Length; num1++)
                    {
                        EmedOdbc.SQLRowIndex = num1;
                        EmedOdbc.DBErrorSQL = inSQL[num1];
                        if (inSQL[num1].CompareTo("") > 0)
                        {
                            OdbcCommand command1 = new OdbcCommand();
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
                    EmedOdbc.SaveErrorToLog(exception1.Message, EmedOdbc.DBErrorSQL);
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
                OdbcConnection.ReleaseObjectPool();
                GC.Collect();
            }
            return flag1;
        }


        public static string ConnectionString
        {
            get
            {
                return EmedOdbc.connStr;
            }
            set
            {
                EmedOdbc.connStr = value;
            }
        }

        public static string Msg
        {
            get
            {
                return EmedOdbc.msg;
            }
            set
            {
                EmedOdbc.msg = value;
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


