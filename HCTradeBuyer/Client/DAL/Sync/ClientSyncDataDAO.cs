using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Emedchina.Commons.Data;
using System.Data;
using System.Data.Common;
using Emedchina.Commons;
using System.Data.OleDb;
using System.IO;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.User;
using System.Data.SqlClient;

namespace Emedchina.TradeAssistant.Client.DAL.Sync
{
   public class ClientSyncDataDAO
    {
        private DataBaseFacade dbFacade = null;
        private DbConnection con = null;
        
        private DbConnection conn = null;

        private ClientSyncDataDAO()            
        {
            dbFacade = DataBaseFacade.GetInstance();
            con = dbFacade.OpenConnection();
            conn = dbFacade.OpenConnection();
            
        }

        private ClientSyncDataDAO(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                dbFacade = DataBaseFacade.GetInstance();
            else
                dbFacade = DataBaseFacade.GetInstance(connectionName);
            con = dbFacade.OpenConnection();
            conn = dbFacade.OpenConnection();
            
        }

        public static ClientSyncDataDAO GetInstance()
        {
            return new ClientSyncDataDAO();
        }

        public static ClientSyncDataDAO GetInstance(string connectionName)
        {
            return new ClientSyncDataDAO(connectionName);
        }


        /// <summary>
        /// Gets the db facade.
        /// </summary>
        /// <value>The db facade.</value>
        protected DataBaseFacade DbFacade
        {
            get
            {
                if (dbFacade == null)
                    dbFacade = DataBaseFacade.GetInstance();
                return dbFacade;
            }
        }


        public void CloseConntion()
        {
            if (con != null)
            {
                
                con.Close();
                con.ConnectionString = "";
                con = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.ConnectionString = "";
                conn = null;
            }
            
        }

        //Start Modify by gaoyuan 20070425 加入事务
        /// <summary>
        /// 全同步单表
        /// </summary>
        /// <param name="tb"></param>
        private int AllSyncTable1(DataTable tb)
        {
            int syncCount = 0;
            StringBuilder sql = new StringBuilder();
            StringBuilder sql1 = new StringBuilder();
            StringBuilder delSql = new StringBuilder();
            int colCount = tb.Columns.Count ;
            string tbName,syncDate;
            if (tb.TableName.Contains("NoIncrement_"))
            {
                tbName = tb.TableName.Substring(12);
            }
            else
            {
                tbName = tb.TableName;
            }
            List<string> sqls = new List<string>();
            delSql.Append("delete from ").Append(tbName);
            sql.Append("insert into ").Append(tbName).Append(" values(");
            using (DbTransaction transaction = DbFacade.BeginTransaction(conn))
            {
                try
                {
                    
                    DbFacade.SQLExecuteNonQuery(delSql.ToString(),transaction);
                    
                    StringBuilder temp = new StringBuilder();   
                    foreach (DataRow dr in tb.Rows)
                    {
                        
                        for (int i = 0; i < colCount; i++ )
                        {
                            if (string.IsNullOrEmpty(dr[i].ToString().Trim()))
                            {
                                temp.Append("null,");
                            }
                            else
                            {
                                temp.Append("'").Append(dr[i].ToString()).Append("',");
                            }
                        }
                        temp.Remove(temp.Length - 1, 1).Append(")");
                        temp.Insert(0, sql);
                        //DbFacade.SQLExecuteNonQuery(temp.ToString(),transaction);
                        sqls.Add(temp.ToString());
                        temp.Remove(0, temp.Length);

                    }
                    syncCount = DbFacade.SQLExecuteNonQueryEx(sqls.ToArray(), transaction);
                    //DataBaseFacade db = DataBaseFacade.GetInstance();
                    //object syncTime = db.SQLExecuteScalar("select sysdate from dual");

                    if (tb.TableName.Contains("NoIncrement_"))
                    {
                        syncDate = "";
                    }
                    else
                    {
                        syncDate = ProxyFactory.SyncDataProxy.GetSysDate();
                    }

                    sql1.Append("update SYNC_TIME set syncDate = '").Append(syncDate);
                    sql1.Append("' where tableName = '").Append(tbName).Append("'");
                    int res = DbFacade.SQLExecuteNonQuery(sql1.ToString(),transaction);
                    if (res < 1)
                    {
                        sql1.Remove(0, sql1.Length);
                        sql1.Append("insert into SYNC_TIME values('").Append(tbName);
                        sql1.Append("','").Append(syncDate).Append("')");
                        DbFacade.SQLExecuteNonQuery(sql1.ToString(),transaction);
                    }
                    DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            return syncCount;
        }
        //End Modify by gaoyuan 20070425 加入事务
              

        /// <summary>
        /// 全同步所有表
        /// </summary>
        private void AllSync1(DataSet ds)
        {
            using (DbTransaction transaction = DbFacade.BeginTransaction(con))
            {
                try
                {

                    DbFacade.SQLExecuteNonQuery("delete from SYNC_TIME");
                    foreach (DataTable tb in ds.Tables)
                    {
                        AllSyncTable1(tb);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        /// <summary>
        /// 取得最近的同步时间点
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        private string GetLastSyncTime(string tableName)
        {
            string syncTime;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select syncDate from SYNC_TIME where tableName = '");
                sql.Append(tableName).Append("'");

                syncTime = DbFacade.SQLExecuteScalar(sql.ToString()).ToString();
                             
            }
            catch (Exception e)
            {
                syncTime = "1900-01-01";
            }
            return syncTime;
        }

        //Start Modify by gaoyuan 20070425 加入事务
        /// <summary>
        /// 增量同步单表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtKey"></param>
        private void IncrementSyncTable1(DataSet ds)
        {
            if (ds.Tables.Count == 1)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    AllSyncTable1(ds.Tables[0]);
                }
            }
            else
            {
                using (DbTransaction transaction = DbFacade.BeginTransaction(con))
                {
                    try
                    {
                        string tableName = ds.Tables[0].TableName;
                        //int keyCount = ds.Tables[1].Columns.Count;
                        //string[] keys = new string[keyCount];
                        StringBuilder sqlWhere = new StringBuilder();
                        StringBuilder sql = new StringBuilder();
                        List<string> sqls = new List<string>();
                        int res;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            // 更新数据
                            sql.Append("update ").Append(tableName).Append(" set ");
                            foreach (DataColumn dc in ds.Tables[0].Columns)
                            {
                                sql.Append(dc.ColumnName).Append("=");
                                if (string.IsNullOrEmpty(dr[dc].ToString().Trim()))
                                {
                                    sql.Append("null,");
                                }
                                else
                                {
                                    sql.Append("'").Append(dr[dc].ToString()).Append("',");
                                }
                            }
                            sql.Remove(sql.Length - 1, 1);
                            sql.Append(" where ");

                            foreach (DataColumn dcn in ds.Tables[1].Columns)
                            {
                                sql.Append(dcn.ColumnName).Append("='").Append(dr[dcn.ColumnName].ToString()).Append("' and ");
                            }
                            sql.Remove(sql.Length - 4, 4);
                            res = DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
                            sql.Remove(0, sql.Length);

                            // 如果没有需要更新的数据,插入数据
                            if (res < 1)
                            {
                                sql.Append("insert into ").Append(tableName).Append(" values(");
                                foreach (DataColumn dc in ds.Tables[0].Columns)
                                {
                                    if (string.IsNullOrEmpty(dr[dc].ToString().Trim()))
                                    {
                                        sql.Append("null,");
                                    }
                                    else
                                    {
                                        sql.Append("'").Append(dr[dc].ToString()).Append("',");
                                    }
                                }
                                sql.Remove(sql.Length - 1, 1).Append(")");
                                DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction);
                                sql.Remove(0, sql.Length);
                            }

                        }
                        //if (ds.Tables[1].Rows.Count > 0)
                        sql.Append("select ");
                        foreach (DataColumn dc in ds.Tables[1].Columns)
                        {
                            sql.Append(dc.ColumnName).Append(" ,");
                        }
                        sql.Remove(sql.Length - 1, 1);
                        sql.Append("from ").Append(ds.Tables[0].TableName);
                        DataTable dtKey = DbFacade.SQLExecuteDataTable(sql.ToString(),transaction);
                        DataColumn[] dcKey = new DataColumn[ds.Tables[1].Columns.Count];
                        int cs = 0;
                        foreach (DataColumn dc in ds.Tables[1].Columns)
                        {
                            dcKey[cs++] = dc;
                        }
                        ds.Tables[1].PrimaryKey = dcKey;
                        DataRow result;
                        object[] keys = new object[ds.Tables[1].Columns.Count];
                        foreach (DataRow dr in dtKey.Rows)
                        {
                            for (int k = 0; k < ds.Tables[1].Columns.Count; k++)
                            {
                                keys[k] = dr[ds.Tables[1].Columns[k].ColumnName].ToString();
                            }
                            result = ds.Tables[1].Rows.Find(keys);
                            if (result == null)
                            {
                                sql.Remove(0, sql.Length);
                                sql.Append("delete from ").Append(ds.Tables[0].TableName).Append(" where ");
                                foreach (DataColumn dc in ds.Tables[1].Columns)
                                {
                                    sql.Append(dc.ColumnName).Append("='").Append(dr[dc.ColumnName].ToString()).Append("' and ");
                                }
                                sql.Remove(sql.Length - 4, 4);
                                DbFacade.SQLExecuteNonQuery(sql.ToString(),transaction);
                            }

                        }
                        StringBuilder sql1 = new StringBuilder();
                        string syncTime = ProxyFactory.SyncDataProxy.GetSysDate();
                        sql1.Append("update SYNC_TIME set syncDate = '").Append(syncTime);
                        sql1.Append("' where tableName = '").Append(tableName).Append("'");
                        DbFacade.SQLExecuteNonQuery(sql1.ToString(),transaction);

                        DbFacade.CommitTransaction(transaction);
                    }
                    catch (Exception e)
                    {
                        DbFacade.RollbackTransaction(transaction);
                        throw e;
                    }
                }
            }

        }
        //End Modify by gaoyuan 20070425 加入事务


        /// <summary>
        /// 增量同步所有表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtKey"></param>
        private void IncrementSyncAll1(DataSet ds)
        {
            DataSet dsTemp = new DataSet();
            try
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    dsTemp.Tables.Add(ds.Tables[i].Copy());
                    if (i + 1 < ds.Tables.Count)
                    {
                        if (ds.Tables[i + 1].TableName.Contains("key_"))
                        {
                            dsTemp.Tables.Add(ds.Tables[++i].Copy());
                        }
                    }
                    IncrementSyncTable1(dsTemp);
                    dsTemp.Tables.Clear();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// 全同步
        /// 采用sql方式更新数据库,速度较慢
        /// </summary>
        /// <param name="buyerId"></param>
        private void AllSyncData1(LogedInUser CurrentUser)
        {
            try
            {
                DataSet ds = DataSerialization.UnSerializeData(ProxyFactory.SyncDataProxy.GetSyncData(CurrentUser));
                AllSync1(ds);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 单表全同步
        /// 采用sql方式更新数据库,速度较慢
        /// </summary>
        /// <param name="buyerId"></param>
        private void AllSyncOneTable1(string tableName, LogedInUser CurrentUser)
        {
            try
            {
                DataTable dt = ProxyFactory.SyncDataProxy.GetSyncTable(tableName,CurrentUser);
                AllSyncTable1(dt);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 增量同步
        /// 采用sql方式更新数据库,速度较慢
        /// </summary>
        /// <param name="buyerId"></param>
        public void AllIncrementSync1(LogedInUser CurrentUser)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select syncDate from SYNC_TIME");
                DataTable dt = DbFacade.SQLExecuteDataTable(sql.ToString());
                string[] syncTime = new string[dt.Rows.Count];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    syncTime[i++] = dr[0].ToString();                    
                }

                DataSet ds = ProxyFactory.SyncDataProxy.GetAllIncrementSyncData(CurrentUser, syncTime);
                IncrementSyncAll1(ds);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 单表增量同步
        /// 采用sql方式更新数据库,速度较慢
        /// </summary>
        /// <param name="buyerId"></param>
        private void IncrementSyncOneTable1(string tableName, LogedInUser CurrentUser)
        {
            try
            {
                string syncTime = GetLastSyncTime(tableName);
                DataSet ds = ProxyFactory.SyncDataProxy.GetIncrementSyncData(tableName,CurrentUser,syncTime);
                IncrementSyncTable1(ds);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        //////////////////////////////////////////




        /// <summary>
        /// 全同步单表
        /// </summary>
        /// <param name="tb"></param>
        private void AllSyncTable(DataTable tb)
        {
            
            string tableName, syncDate;
            if (tb.TableName.Contains("NoIncrement_"))
            {
                tableName = tb.TableName.Substring(12);
            }
            else
            {
                tableName = tb.TableName;
            }
            SqlConnection oldCon = (SqlConnection)DbFacade.OpenConnection();
            using (DbTransaction transaction = DbFacade.BeginTransaction(conn))
            {
                try
                {
                    if (tb.TableName.Contains("NoIncrement_"))
                    {
                        syncDate = "";
                    }
                    else
                    {
                        syncDate = ProxyFactory.SyncDataProxy.GetSysDate();
                    }
                    //删除本地表中数据
                    //StringBuilder delSql = new StringBuilder();
                    //delSql.Append("delete * from ").Append(tableName);
                    //DbFacade.SQLExecuteNonQuery(delSql.ToString());

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("select * from " + tableName, oldCon);
                    SqlCommandBuilder objBuilder;

                    objBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, tableName);
                    if (ds.Tables[tableName].Rows.Count > 0)
                    {
                        //删除本地表中数据
                        foreach (DataRow dr in ds.Tables[tableName].Rows)
                        {
                            dr.Delete();
                        }
                        da.Update(ds, tableName);
                    }

                    DataRow row;
                    foreach (DataRow dr in tb.Rows)
                    {
                        row = ds.Tables[tableName].NewRow();
                        row.ItemArray = dr.ItemArray;
                        ds.Tables[tableName].Rows.Add(row);
                    }
                    //da.InsertCommand = objBuilder.GetInsertCommand();
                    da.Update(ds, tableName);


                    StringBuilder sql1 = new StringBuilder();
                    sql1.Append("update SYNC_TIME set syncDate = '").Append(syncDate);
                    sql1.Append("' where tableName = '").Append(tableName).Append("'");
                    int res = DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
                    if (res < 1)
                    {
                        sql1.Remove(0, sql1.Length);
                        sql1.Append("insert into SYNC_TIME values('").Append(tableName);
                        sql1.Append("','").Append(syncDate).Append("')");
                        DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
                    }
                    DbFacade.CommitTransaction(transaction);
                    oldCon.Close();
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    oldCon.Close();
                    throw e;
                }
            }

            //using (DbTransaction transaction = DbFacade.BeginTransaction(conn))
            //{
            //    try
            //    {
            //        if (tb.TableName.Contains("NoIncrement_"))
            //        {
            //            syncDate = "";
            //        }
            //        else
            //        {
            //            syncDate = ProxyFactory.SyncDataProxy.GetSysDate();
            //        }

            //        DataSet ds = new DataSet();
            //        OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tableName, (OleDbConnection)DbFacade.OpenConnection());
            //        //OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tableName, oldCon);
            //        OleDbCommandBuilder objBuilder;

            //        objBuilder = new OleDbCommandBuilder(da);
            //        da.Fill(ds, tableName);

            //        StringBuilder delSql = new StringBuilder();
            //        delSql.Append("delete * from ").Append(tableName);
            //        DbFacade.SQLExecuteNonQuery(delSql.ToString());
            //        DataRow row;
            //        foreach (DataRow dr in tb.Rows)
            //        {
            //            row = ds.Tables[tableName].NewRow();
            //            row.ItemArray = dr.ItemArray;
            //            ds.Tables[tableName].Rows.Add(row);
            //        }
            //        //da.InsertCommand = objBuilder.GetInsertCommand();
            //        da.Update(ds, tableName);


            //        StringBuilder sql1 = new StringBuilder();
            //        sql1.Append("update SYNC_TIME set syncDate = '").Append(syncDate);
            //        sql1.Append("' where tableName = '").Append(tableName).Append("'");
            //        int res = DbFacade.SQLExecuteNonQuery(sql1.ToString());
            //        //int res = DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
            //        if (res < 1)
            //        {
            //            sql1.Remove(0, sql1.Length);
            //            sql1.Append("insert into SYNC_TIME values('").Append(tableName);
            //            sql1.Append("','").Append(syncDate).Append("')");
            //            //DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
            //        }
            //        DbFacade.SQLExecuteNonQuery(sql1.ToString());
            //        //DbFacade.CommitTransaction(transaction);
            //        //oldCon.Close();
            //    }
            //    catch (Exception e)
            //    {
            //        DbFacade.RollbackTransaction(transaction);
            //        //oldCon.Close();
            //        throw e;
            //    }
            //    //end modify by gaoyuan 20070427
            //}
        }


        /// <summary>
        /// 增量同步单表
        /// </summary>
        /// <param name="tb"></param>
        private void IncrementSyncTable(DataSet ds,string logFlag)
        {
            SqlConnection odCon = (SqlConnection)DbFacade.OpenConnection();
            using (DbTransaction transaction = DbFacade.BeginTransaction(con))
            {
                try
                {
                    if (ds.Tables.Count == 1)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            AllSyncTable(ds.Tables[0]);
                        }
                    }
                    else
                    {
                        string syncTime = ProxyFactory.SyncDataProxy.GetSysDate();

                        string tableName = ds.Tables[0].TableName;

                        DataSet dss = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter("select * from " + tableName, odCon);
                        SqlCommandBuilder objBuilder;
                        DataRow row;
                        objBuilder = new SqlCommandBuilder(da);
                        da.Fill(dss, tableName);

                        DataColumn[] key = new DataColumn[ds.Tables[1].Columns.Count];
                        //DataColumn[] key1 = new DataColumn[ds.Tables[1].Columns.Count];
                        DataColumn[] key2 = new DataColumn[ds.Tables[1].Columns.Count];
                        int c = 0;
                        foreach (DataColumn dc in ds.Tables[1].Columns)
                        {
                            key[c] = dss.Tables[tableName].Columns[dc.ColumnName];
                            //key1[c++] = ds.Tables[0].Columns[dc.ColumnName];
                            key2[c] = ds.Tables[1].Columns[dc.ColumnName];
                            ++c;
                        }
                        dss.Tables[tableName].PrimaryKey = key;
                        //ds.Tables[0].PrimaryKey = key1;
                        object[] keyValue = new object[ds.Tables[1].Columns.Count];
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            for (int k = 0; k < ds.Tables[1].Columns.Count; k++)
                            {
                                keyValue[k] = dr[ds.Tables[1].Columns[k].ColumnName].ToString();
                            }
                            row = dss.Tables[tableName].Rows.Find(keyValue);
                            if (row != null)
                            {
                                //更新
                                row.ItemArray = dr.ItemArray;
                            }
                            else
                            {
                                //新增
                                row = dss.Tables[tableName].NewRow();
                                row.ItemArray = dr.ItemArray;
                                dss.Tables[tableName].Rows.Add(row);
                            }
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ds.Tables[1].PrimaryKey = key2;
                            //删除
                            if (logFlag.Equals("0"))
                            {
                                foreach (DataRow dr in dss.Tables[tableName].Rows)
                                {
                                    for (int k = 0; k < ds.Tables[1].Columns.Count; k++)
                                    {
                                        keyValue[k] = dr[ds.Tables[1].Columns[k].ColumnName].ToString();
                                    }
                                    row = ds.Tables[1].Rows.Find(keyValue);
                                    if (row == null)
                                    {
                                        dr.Delete();
                                    }
                                }
                            }
                            else if (logFlag.Equals("1"))
                            {
                                //利用log作同步
                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    for (int k = 0; k < ds.Tables[1].Columns.Count; k++)
                                    {
                                        keyValue[k] = dr[ds.Tables[1].Columns[k].ColumnName].ToString();
                                    }
                                    row = dss.Tables[tableName].Rows.Find(keyValue);
                                    if (row != null)
                                    {
                                        row.Delete();
                                    }
                                }
                            }
                        }
                        
                        da.Update(dss, tableName);

                        StringBuilder sql1 = new StringBuilder();
                        
                        sql1.Append("update SYNC_TIME set syncDate = '").Append(syncTime);
                        sql1.Append("' where tableName = '").Append(tableName).Append("'");
                        DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
                    }
                    DbFacade.CommitTransaction(transaction);
                    odCon.Close();
                    odCon.ConnectionString = "";
                    odCon = null;
                }
                catch (Exception e)
                {
                    DbFacade.RollbackTransaction(transaction);
                    odCon.Close();
                    odCon.ConnectionString = "";
                    odCon = null;
                    throw e;
                }
            }    
        }

        /// <summary>
        /// 增量同步所有表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtKey"></param>
        private void IncrementSyncAll(DataSet ds)
        {
            DataSet dsTemp = new DataSet();
            try
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    dsTemp.Tables.Add(ds.Tables[i].Copy());
                    if (i + 1 < ds.Tables.Count)
                    {
                        if (ds.Tables[i + 1].TableName.Contains("key_"))
                        {
                            dsTemp.Tables.Add(ds.Tables[++i].Copy());
                        }
                    }
                    IncrementSyncTable(dsTemp,"0");
                    dsTemp.Tables.Clear();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///// <summary>
        ///// 增量同步单表
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="dtKey"></param>
        //private void IncrementSyncAll(DataSet ds,string tablename)
        //{
        //    DataSet dsTemp = new DataSet();
        //    try
        //    {
        //        dsTemp.Tables.Add(ds.Tables[tablename].Copy());
        //        if (i + 1 < ds.Tables.Count)
        //        {
        //            if (ds.Tables[tablename].TableName.Contains("key_"))
        //            {
        //                dsTemp.Tables.Add(ds.Tables[++i].Copy());
        //            }
        //        }
        //        IncrementSyncTable(dsTemp);
        //        dsTemp.Tables.Clear();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        /// <summary>
        /// 增量同步所有表
        /// </summary>
        /// <param name="buyerId"></param>
        public int AllIncrementSync(LogedInUser CurrentUser)
        {
            int count = 0;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select syncDate from SYNC_TIME");
                DataTable dt = DbFacade.SQLExecuteDataTable(sql.ToString());
                if (dt.Rows.Count > 0)
                {
                    string[] syncTime = new string[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        syncTime[i++] = dr[0].ToString();
                    }

                    DataSet ds = ProxyFactory.SyncDataProxy.GetAllIncrementSyncData(CurrentUser, syncTime);
                    count = ds.Tables[0].Rows.Count;
                    IncrementSyncAll(ds);
                }
                //else
                //{
                //    AllSyncData(buyerId);
                //}
                CloseConntion();
            }
            catch (Exception e)
            {
                CloseConntion();
                count = -1;
            }
            return count;
        }

        /// <summary>
        /// 增量同步单个表
        /// </summary>
        /// <param name="buyerId"></param>
        public int AllIncrementOneSync(LogedInUser CurrentUser, string tableName, string logFlag)
        {
            int count = 0;
            int keyCount = 0;
            string syncTime = "";
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select syncDate from SYNC_TIME where tableName = '");
                sql.Append(tableName.ToUpper()).Append("'");

                object o = DbFacade.SQLExecuteScalar(sql.ToString());
                if (o != null)
                    syncTime = o.ToString();
                if (!String.IsNullOrEmpty(syncTime))
                {
                    DataSet ds = ProxyFactory.SyncDataProxy.GetIncrementSyncData(tableName, CurrentUser, syncTime);
                    count = ds.Tables[0].Rows.Count;
                    //IncrementSyncAll(ds);
                    keyCount = ds.Tables[1].Rows.Count;

                    if (count + keyCount > 0)
                        IncrementSyncTable(ds,logFlag);//增量同步单表
                }
                else
                {
                    count = AllSyncOneData(CurrentUser, tableName);
                }
                //CloseConntion();
            }
            catch (Exception e)
            {
                //CloseConntion();
                count = -1;
            }
            return count;
        }

        /// <summary>
        /// 单表增量同步
        /// </summary>
        /// <param name="buyerId"></param>
        public void IncrementSyncOneTable(string tableName, LogedInUser CurrentUser)
        {
            try
            {

                string syncTime = GetLastSyncTime(tableName);
                DataSet ds = ProxyFactory.SyncDataProxy.GetIncrementSyncData(tableName, CurrentUser, syncTime);
                IncrementSyncTable(ds,"0");
                CloseConntion();

            }
            catch (Exception e)
            {
                CloseConntion();
                throw e;
            }
        }


        /// <summary>
        /// 单表全同步
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        public void AllSyncOneTable(string tableName, LogedInUser CurrentUser)
        {
            try{
                DataTable dt = ProxyFactory.SyncDataProxy.GetSyncTable(tableName, CurrentUser);
                AllSyncTable(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 全同步所有表
        /// </summary>
        /// <param name="buyerId"></param>
        public void AllSyncData(LogedInUser CurrentUser)
        {
            try
            {
                DataSet ds = DataSerialization.UnSerializeData(ProxyFactory.SyncDataProxy.GetSyncData(CurrentUser));
                foreach (DataTable dt in ds.Tables)
                {

                    AllSyncTable(dt);

                }
                CloseConntion();
            }
            catch (Exception e)
            {
                CloseConntion();
                throw e;
            }
        }

        /// <summary>
        /// 全同步单个表
        /// </summary>
        /// <param name="buyerId"></param>
        public int AllSyncOneData(LogedInUser CurrentUser, string tableName)
        {
            int count = 0;
            try
            {
                ProxyFactory.SyncDataProxy.RefreshUserData();
                byte[] data = ProxyFactory.SyncDataProxy.GetSyncTableEx(tableName, CurrentUser);
                DataTable dt = (DataTable)CompressUtil.Decompression(data);
                //DataTable dt = ProxyFactory.SyncDataProxy.GetSyncTable(tableName,CurrentUser);

                //count = dt.Rows.Count;
                count = AllSyncTable1(dt);

                //AllSyncTable1(dt);
            }
            catch (Exception e)
            {
                count = -1;
                //CloseConntion();
            }
            //CloseConntion();
            return count;
            /*改之前 备份
                DataSet ds = DataSerialization.UnSerializeData(ProxyFactory.SyncDataProxy.GetSyncData(buyerId));
                foreach (DataTable dt in ds.Tables)
                {

                    AllSyncTable(dt);

                }
                CloseConntion();
             * */
        }


        /// <summary>
        /// 采用csv文件导入方式单表全同步
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        public int AllSyncOneTableFromCsv(string tableName, LogedInUser CurrentUser)
        {
            int count = 0;
            using (DbTransaction transaction = dbFacade.BeginTransaction(con))
            {
                try
                {
                    //DateTime dt = DateTime.Now;

                    string syncDate = ProxyFactory.SyncDataProxy.GetSysDate();
                    //还原被压缩的csv串 2007-7-5 Cj
                    string data = (string)CompressUtil.Decompression(ProxyFactory.SyncDataProxy.GetDataByCsvStream(tableName, CurrentUser));
                    ////byte[] data = ProxyFactory.SyncDataProxy.DataToFile(tableName, CurrentUser);
                    //发布时使用
                    //string apppath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\DB\\";

                    //本地调试使用
                    //string apppath = AppDomain.CurrentDomain.BaseDirectory + "DB\\";
                    string apppath = ClientConfiguration.TmpDBPath;
                    string apptemppath = ClientConfiguration.TmpDBFile;

                    string file = apppath + tableName + ".csv";
                    File.WriteAllText(file, data, Encoding.GetEncoding(936));  //"UTF-8"  , 936

                    ////string file = Path.Combine(apppath, tableName);
                    ////File.WriteAllBytes(file, data);
                    ////CompressUtil.DecompressFile(file, file + ".csv");

                    //DateTime dt1 = DateTime.Now;
                    //TimeSpan t1 = dt1.Subtract(dt);
                    dbFacade.SQLExecuteNonQuery("delete from " + tableName);
                    //dbFacade.SPExecuteNonQuery("p_OpenADShell");
                    StringBuilder sql = new StringBuilder();
                    sql.Append("insert into ");
                    sql.Append(tableName);
                    sql.Append(" Select * From OPENDATASOURCE ('Microsoft.Jet.OLEDB.4.0', 'Data Source=");
                    sql.Append(apppath);
                    sql.Append(";Extended properties=Text')...[").Append(tableName).Append("#csv] ");

                    //string sql = "insert into " + tableName + " select * from OpenRowset('MSDASQL', 'driver={Microsoft Text Driver (*.txt; *.csv)};DefaultDir=" + apppath + ";','select * from " + tableName + ".csv' )";
                    dbFacade.SQLExecuteNonQuery(sql.ToString());
                    //dbFacade.SPExecuteNonQuery("p_CloseADShell");
                    //CSVUtils.ImportFromCsv(tableName, apptemppath, apppath);

                    //TimeSpan t2 = DateTime.Now.Subtract(dt1);
                    //MessageBox.Show("生成csv：" + t1.TotalSeconds.ToString() + "\n导入csv：" + t2.TotalSeconds.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StringBuilder sql1 = new StringBuilder();
                    sql1.Append("update SYNC_TIME set syncDate = '").Append(syncDate);
                    sql1.Append("' where tableName = '").Append(tableName).Append("'");
                    int res = DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
                    if (res < 1)
                    {
                        sql1.Remove(0, sql1.Length);
                        sql1.Append("insert into SYNC_TIME values('").Append(tableName);
                        sql1.Append("','").Append(syncDate).Append("')");
                        DbFacade.SQLExecuteNonQuery(sql1.ToString(), transaction);
                    }
                    File.Delete(file);
                    //File.Delete(file + ".csv");
                    count = getRecordCount(tableName, transaction);
                    dbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    dbFacade.RollbackTransaction(transaction);
                    count = -1;
                }
                return count;
            }
        }

        /// <summary>
        /// 取得记录数
        /// </summary>
        /// <returns></returns>
        private int getRecordCount(string tbName, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from ").Append(tbName);
            int count = int.Parse(DbFacade.SQLExecuteScalar(sql.ToString(), transaction).ToString());
            return count;
        }

        /// <summary>
        /// 全同步（csv方式）
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="dbFileName"></param>
        public int AllSyncFromCsv(LogedInUser CurrentUser, string tableName)
        {
            int count = 0;
            try
            {
                count = AllSyncOneTableFromCsv(tableName, CurrentUser);                    
            }
            catch (Exception e)
            {
                count = -1;
            }
            //CloseConntion();
            return count;

            /* 改之前 备份
            try
            {
                //FileControl.CompactAccessDB(AppDomain.CurrentDomain.BaseDirectory + "DB\\zjtrade.mdb");
                List<string> tableNames = ProxyFactory.SyncDataProxy.GetTableName();
                foreach (string tableName in tableNames)
                {
                    AllSyncOneTableFromCsv(tableName, buyerId, dbFileName);                    
                }
                CloseConntion();
            }
            catch (Exception e)
            {
                throw e;
            }*/
        }

       //public void CopyDB(string oldName, string newName)
       //{
       //    try
       //    {
       //        int i = DbFacade.SPExecuteNonQuery("p_CopyDb", oldName, newName,1,1);
       //    }
       //    catch (Exception e)
       //    {
       //        throw e;
       //    }
       //}


       //public void RenameDB(string oldName, string newName)
       //{
       //    try
       //    {
       //        int i = DbFacade.SPExecuteNonQuery("sp_renamedb", oldName, newName);
       //    }
       //    catch (Exception e)
       //    {
       //        throw e;
       //    }
       //}

       /// <summary>
       /// 开放opendatasource功能
       /// </summary>
       public void OpenADShell()
       {
           try
           {
               dbFacade.SPExecuteNonQuery("p_OpenADShell");
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       /// <summary>
       /// 关闭opendatasource功能
       /// </summary>
       public void CloseADShell()
       {
           try
           {
               dbFacade.SPExecuteNonQuery("p_CloseADShell");
           }
           catch (Exception e)
           {
               throw e;
           }
       }

       /// <summary>
       /// 压缩数据库
       /// </summary>
       /// <param name="dbName"></param>
       public void CompressDB(string dbName)
       {
           try
           {
               dbFacade.SPExecuteNonQuery("p_CompressDB");
           }
           catch (Exception e)
           {
               throw e;
           }
       }
    }
}
