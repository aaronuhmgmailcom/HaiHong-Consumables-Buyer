using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Emedchina.Commons.Data;
using System.Data;
using System.Data.Common;
using Emedchina.TradeAssistant.DAL.Common;
using System.IO;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.User;

namespace Emedchina.TradeAssistant.DAL.Sync
{
    public class SyncDataDAO : OracleDAOBase
    {
        private SyncDataDAO()
            : base()
        { }

        private SyncDataDAO(string connectionName)
            : base(connectionName)
        { }

        public static SyncDataDAO GetInstance()
        {
            return new SyncDataDAO();
        }

        public static SyncDataDAO GetInstance(string connectionName)
        {
            return new SyncDataDAO(connectionName);
        }



        /// <summary>
        /// 取得单表数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetSyncTable(string tableName, LogedInUser CurrentUser)
        {
            DataTable table;
            try
            {
                List<DbParameter> parameters = new List<DbParameter>();

                string tbName;
                if (string.IsNullOrEmpty(XmlUtil.GetSyncText(tableName, "timefield")))
                {
                    tbName = "NoIncrement_" + tableName;
                }
                else
                {
                    tbName = tableName;
                }
                string sql = XmlUtil.GetSyncText(tableName, "sqlstring");
                if (sql.IndexOf(":Id") > 0)
                {
                    DbParameter para1 = DbFacade.CreateParameter();
                    para1.ParameterName = "Id";
                    para1.DbType = DbType.String;
                    para1.Value = CurrentUser.UserOrg.Id;
                    parameters.Add(para1);
                    //table = DbFacade.SQLExecuteDataTable(sql, tbName, para);
                }
                else if (sql.IndexOf(":userId") > 0)
                {
                    DbParameter para2 = DbFacade.CreateParameter();
                    para2.ParameterName = "userId";
                    para2.DbType = DbType.String;
                    para2.Value = CurrentUser.UserInfo.Id;
                    parameters.Add(para2);
                    //table = DbFacade.SQLExecuteDataTable(sql, tbName, para);
                }
                else
                {
                    //table = DbFacade.SQLExecuteDataTable(sql, tbName);
                }

                table = DbFacade.SQLExecuteDataTable(sql, tbName, parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }


        /// <summary>
        /// 取得需要同步的所有表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetSyncData(LogedInUser CurrentUser)
        {
            DataSet ds = new DataSet();
            DataTable table;
            string tableName;

            try
            {
                XmlNodeList node = XmlUtil.GetNodeList();
                foreach (XmlNode nd in node)
                {
                    tableName = nd.Attributes[0].Value;
                    table = GetSyncTable(tableName, CurrentUser);
                    ds.Tables.Add(table);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }


        /// <summary>
        /// 取得单表增量数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataTable GetIncrementSyncTable(string tableName, LogedInUser CurrentUser, string syncTime)
        {
            DataTable table;
            try
            {
                StringBuilder sqlWhere = new StringBuilder();
                string sql = XmlUtil.GetSyncText(tableName, "sqlstring");
                string temp = XmlUtil.GetSyncText(tableName, "timefield");
                List<DbParameter> parameters = new List<DbParameter>();
                if (!string.IsNullOrEmpty(temp))
                {
                    string[] timeField = temp.Split(new char[] { ',' });
                    if (timeField.Length == 1)
                    {
                        sqlWhere.Append(" and ").Append(timeField[0]);
                        sqlWhere.Append(" >= to_date(:syncTime,'yyyy-mm-dd hh24:mi:ss') ");
                        //sqlWhere.Append(" >= to_date('").Append(syncTime).Append("# ");

                        DbParameter syncTimePara = DbFacade.CreateParameter();
                        syncTimePara.ParameterName = "syncTime";
                        syncTimePara.DbType = DbType.String;
                        syncTimePara.Value = syncTime;
                        parameters.Add(syncTimePara);
                    }
                    if (timeField.Length == 2)
                    {
                        sqlWhere.Append(" and (").Append(timeField[0]);
                        sqlWhere.Append(" >= to_date(:syncTime1,'yyyy-mm-dd hh24:mi:ss') or ");
                        sqlWhere.Append(timeField[1]).Append(" >= to_date(:syncTime2,'yyyy-mm-dd hh24:mi:ss'))");
                        //sqlWhere.Append(" >= #").Append(syncTime).Append("# or ");
                        //sqlWhere.Append(timeField[1]).Append(" >= #").Append(syncTime).Append("#) ");
                        DbParameter syncTimePara1 = DbFacade.CreateParameter();
                        syncTimePara1.ParameterName = "syncTime1";
                        syncTimePara1.DbType = DbType.String;
                        syncTimePara1.Value = syncTime;
                        parameters.Add(syncTimePara1);
                        DbParameter syncTimePara2 = DbFacade.CreateParameter();
                        syncTimePara2.ParameterName = "syncTime2";
                        syncTimePara2.DbType = DbType.String;
                        syncTimePara2.Value = syncTime;
                        parameters.Add(syncTimePara2);
                    }
                }
                else
                {
                    sqlWhere.Append(" and 1=1 ");
                }

                if (sql.IndexOf(":Id") > 0)
                {
                    
                    DbParameter para1 = DbFacade.CreateParameter();
                    para1.ParameterName = "Id";
                    para1.DbType = DbType.Int64;
                    para1.Value = CurrentUser.UserOrg.Id;
                    parameters.Add(para1);
                    
                    table = DbFacade.SQLExecuteDataTable(sql + sqlWhere.ToString(), tableName, parameters.ToArray());
                }
                else if (sql.ToLower().IndexOf("where") > 0)
                {
                    table = DbFacade.SQLExecuteDataTable(sql + sqlWhere.ToString(), tableName, parameters.ToArray());
                }
                else
                {
                    table = DbFacade.SQLExecuteDataTable(sql + " where " + sqlWhere.Remove(0, 4).ToString(), tableName, parameters.ToArray());
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }


        /// <summary>
        /// 取得单表主键数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataTable GetIncrementSyncTableKey(string tableName, LogedInUser CurrentUser)
        {
            DataTable table;
            try
            {
                StringBuilder sqlWhere = new StringBuilder();
                string sql = XmlUtil.GetSyncText(tableName, "keysql");

                //if (sql.IndexOf(":buyerId") > 0)
                //{
                //    DbParameter para = DbFacade.CreateParameter();
                //    para.ParameterName = "buyerId";
                //    para.DbType = DbType.String;
                //    para.Value = CurrentUser.UserOrg.Reg_org_id;
                //    table = DbFacade.SQLExecuteDataTable(sql, "key_" + tableName, para);
                //}
                //else
                //{
                //    table = DbFacade.SQLExecuteDataTable(sql, "key_" + tableName);
                //}

                List<DbParameter> parameters = new List<DbParameter>();

                if (sql.IndexOf(":Id") > 0)
                {
                    DbParameter para1 = DbFacade.CreateParameter();
                    para1.ParameterName = "Id";
                    para1.DbType = DbType.String;
                    para1.Value = CurrentUser.UserOrg.Reg_org_id;
                    parameters.Add(para1);
                }
                else if (sql.IndexOf(":userId") > 0)
                {
                    DbParameter para2 = DbFacade.CreateParameter();
                    para2.ParameterName = "userId";
                    para2.DbType = DbType.String;
                    para2.Value = CurrentUser.UserInfo.Id;
                    parameters.Add(para2);
                }

                table = DbFacade.SQLExecuteDataTable(sql, "key_" + tableName, parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }


        /// <summary>
        /// 取得单表主键数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataTable GetIncrementSyncTableKey(string tableName, LogedInUser CurrentUser, string syncTime)
        {
            DataTable table = new DataTable();
            try
            {
                StringBuilder sqlWhere = new StringBuilder();
                string sql = XmlUtil.GetSyncText(tableName, "keysql");

                List<DbParameter> parameters = new List<DbParameter>();
                if (!string.IsNullOrEmpty(sql))
                {
                    if (sql.IndexOf(":Id") > 0)
                    {
                        DbParameter para1 = DbFacade.CreateParameter();
                        para1.ParameterName = "Id";
                        para1.DbType = DbType.Int64;
                        para1.Value = CurrentUser.UserOrg.Id;
                        parameters.Add(para1);
                    }
                    //else if (sql.IndexOf(":userId") > 0)
                    //{
                    //    DbParameter para2 = DbFacade.CreateParameter();
                    //    para2.ParameterName = "userId";
                    //    para2.DbType = DbType.String;
                    //    para2.Value = CurrentUser.UserInfo.Id;
                    //    parameters.Add(para2);
                    //}
                    //如果查询log表，增加log时间作为查询条件
                    if (sql.IndexOf(":delDate") > 0)
                    {
                        DbParameter para3 = DbFacade.CreateParameter();
                        para3.ParameterName = "delDate";
                        para3.DbType = DbType.String;
                        para3.Value = syncTime;
                        parameters.Add(para3);
                    }
                    table = DbFacade.SQLExecuteDataTable(sql, "key_" + tableName, parameters.ToArray());
                }
                else
                {
                    string pk = XmlUtil.GetSyncText(tableName, "Pk");
                    table.TableName = "key_" + tableName;
                    table.Columns.Add(pk);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }

        /// <summary>
        /// 取得需要增量同步的单表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetIncrementSyncData(string tableName, LogedInUser CurrentUser, string syncTime)
        {
            DataSet ds = new DataSet();
            DataTable table;

            try
            {
                if (string.IsNullOrEmpty(XmlUtil.GetSyncText(tableName, "timefield")))
                {
                    table = GetSyncTable(tableName, CurrentUser);
                    ds.Tables.Add(table);
                }
                else
                {
                    table = GetIncrementSyncTable(tableName, CurrentUser, syncTime);
                    ds.Tables.Add(table);
                    table = GetIncrementSyncTableKey(tableName, CurrentUser, syncTime);
                    if (table != null)
                        ds.Tables.Add(table);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }


        /// <summary>
        /// 取得需要增量同步的所有表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllIncrementSyncData(LogedInUser CurrentUser, string[] syncTime)
        {
            DataSet ds = new DataSet();
            DataSet ds1;
            string tableName;

            try
            {
                XmlNodeList node = XmlUtil.GetNodeList();
                int i = 0;
                foreach (XmlNode nd in node)
                {

                    tableName = nd.Attributes[0].Value;
                    ds1 = GetIncrementSyncData(tableName, CurrentUser, syncTime[i]);
                    i += 1;
                    for (int n = 0; n < ds1.Tables.Count; n++)
                    {
                        ds.Tables.Add(ds1.Tables[n].Copy());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }


        /// <summary>
        /// 取得系统当前时间
        /// </summary>
        /// <returns></returns>
        public string GetSysDate()
        {
            string syncTime;
            try
            {
                syncTime = DbFacade.SQLExecuteScalar("select sysdate from dual").ToString();

            }
            catch (Exception e)
            {
                throw e;
            }
            return syncTime;
        }

        /// <summary>
        /// 取得所有同步表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableName()
        {

            XmlNodeList node = XmlUtil.GetNodeList();
            List<string> tableNameList = new List<string>();
            foreach (XmlNode nd in node)
            {
                tableNameList.Add(nd.Attributes[0].Value);
            }
            return tableNameList;
        }

        /// <summary>
        /// 取得单表数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IDataReader GetSyncTableReader(string tableName, LogedInUser CurrentUser)
        {
            IDataReader dataReader;
            try
            {
                List<DbParameter> parameters = new List<DbParameter>();

                string tbName;
                if (string.IsNullOrEmpty(XmlUtil.GetSyncText(tableName, "timefield")))
                {
                    tbName = "NoIncrement_" + tableName;
                }
                else
                {
                    tbName = tableName;
                }
                string sql = XmlUtil.GetSyncText(tableName, "sqlstring");
                if (sql.IndexOf(":Id") > 0)
                {
                    DbParameter para1 = DbFacade.CreateParameter();
                    para1.ParameterName = "buyerId";
                    para1.DbType = DbType.AnsiString;
                    para1.Value = CurrentUser.UserOrg.Reg_org_id;
                    parameters.Add(para1);
                    //dataReader = DbFacade.SQLExecuteReader(sql, para);
                }
                else if (sql.IndexOf(":userId") > 0)
                {
                    DbParameter para2 = DbFacade.CreateParameter();
                    para2.ParameterName = "userId";
                    para2.DbType = DbType.AnsiString;
                    para2.Value = CurrentUser.UserInfo.Id;
                    parameters.Add(para2);
                    //dataReader = DbFacade.SQLExecuteReader(sql, para);
                }
                else
                {
                    //dataReader = DbFacade.SQLExecuteReader(sql);
                }
                dataReader = DbFacade.SQLExecuteReader(sql, parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return dataReader;
        }


        /// <summary>
        /// 取得单表数据,生产csv文件
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] DataToFile(string tableName, LogedInUser CurrentUser)
        {
            //DateTime dt = DateTime.Now;

            IDataReader dataReader;
            StringBuilder csvStr = new StringBuilder();
            byte[] data;
            try
            {
                dataReader = GetSyncTableReader(tableName, CurrentUser);
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, tableName + CurrentUser.UserOrg.Reg_org_id + ".csv");

                ////写表头
                //File.WriteAllText(file, CSVUtils.CreateCSVHeader(dataReader, csvStr), Encoding.GetEncoding(936));
                ////写数据
                //while (dataReader.Read())
                //{
                //    //using (StreamWriter sw = File.AppendText(file))
                //    //{
                //    //    sw.Write(CSVUtils.CreateCSVContextLine(dataReader, csvStr));
                //    //}
                //    File.AppendAllText(file, CSVUtils.CreateCSVContextLine(dataReader, csvStr), Encoding.GetEncoding(936));
                //}

                File.WriteAllText(file, CSVUtils.ToCSV(dataReader, true), Encoding.GetEncoding(936));

                //TimeSpan t = DateTime.Now.Subtract(dt);
                //MessageBox.Show(t.TotalSeconds.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CompressUtil.CompressFile(file);
                data = File.ReadAllBytes(file + ".cps");
                File.Delete(file);
                File.Delete(file + ".cps");
            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

        /// <summary>
        /// 取得单表数据(压缩)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetDataByCsvStream(string tableName, LogedInUser CurrentUser)
        {
            //DateTime dt = DateTime.Now;

            IDataReader dataReader;
            StringBuilder csvStr = new StringBuilder();
            byte[] data;
            try
            {
                dataReader = GetSyncTableReader(tableName, CurrentUser);
                data = (byte[])CompressUtil.CompressData(CSVUtils.ToCSV(dataReader, true));
            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

        /// <summary>
        /// 刷新用户数据
        /// </summary>
        public void RefreshUserData()
        {
            string sql = "dbms_refresh.refresh('HCDEV.MV_REFRESH')";
            try
            {
                //DbFacade.SPNonQuery(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
