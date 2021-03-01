using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Xml;

using Emedchina.Commons.Data;
using Emedchina.Commons.Util;


namespace Emedchina.TradeAssistant.Client.DAL.Sync
{
    class ClientUploadDao
    {
        private DataBaseFacade dbFacade = null;
        private DbConnection con = null;

        private ClientUploadDao()            
        {
            dbFacade = DataBaseFacade.GetInstance();
            con = dbFacade.OpenConnection();
            
        }

        private ClientUploadDao(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                dbFacade = DataBaseFacade.GetInstance();
            else
                dbFacade = DataBaseFacade.GetInstance(connectionName);
            //con = dbFacade.OpenConnection();
            
        }
        public static ClientUploadDao GetInstance()
        {
            return new ClientUploadDao();
        }

        public static ClientUploadDao GetInstance(string connectionName)
        {
            return new ClientUploadDao(connectionName);
        }

        public void CloseConntion()
        {
            if (dbFacade != null)
            {
                //con.Close();
                //con.ConnectionString = "";
                //con = null;
                dbFacade = null;
            }

        }
        /// <summary>
        /// 获取需要同步的所有表数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable table;
            string tableName;

            try
            {
                XmlNodeList node = UtilXml.GetNodeList();
                foreach (XmlNode nd in node)
                {
                    tableName = nd.Attributes[0].Value;
                    table = GetSyncTable(tableName);
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
        /// 获取需要同步的所有表数据(立即发送使用）
        /// </summary>
        /// <returns></returns>
        public DataSet GetSyncDataForSendNow()
        {
            DataSet ds = new DataSet();
            DataTable table;
            string tableName;

            try
            {
                XmlNodeList node = UtilXml.GetNodeList();
                foreach (XmlNode nd in node)
                {
                    tableName = nd.Attributes[0].Value;
                    table = GetSyncTableForSendNow(tableName);
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
        /// 获取单个表单数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetSyncTableForSendNow(string tableName)
        {
            DataTable table = null;
            try
            {
                string sql = UtilXml.GetSyncText(tableName, "sqlstring");
                string sendFlag = UtilXml.GetSyncText(tableName, "SendNow");
                if (!string.IsNullOrEmpty(sql.Trim()) && sendFlag.Equals("1"))
                {
                    table = dbFacade.SQLExecuteDataTable(sql, tableName);
                    string pk = UtilXml.GetSyncText(tableName, "Pk");
                    table.PrimaryKey = new DataColumn[] { table.Columns[pk] };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }

        /// <summary>
        /// 获取单个表单数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetSyncTable(string tableName)
        {
            DataTable table = null;
            try
            {
                string sql = UtilXml.GetSyncText(tableName, "sqlstring");
                if (!string.IsNullOrEmpty(sql.Trim()))
                {
                    table = dbFacade.SQLExecuteDataTable(sql, tableName);
                    string pk = UtilXml.GetSyncText(tableName, "Pk");
                    table.PrimaryKey = new DataColumn[] { table.Columns[pk] };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }

        /// <summary>
        /// 获取删除数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDelData()
        {
            DataTable table = null;
            try
            {
                string sql = "Select Table_Name,PK_NAME,Id,CREATE_USERID From DEL_LOG Where sync_state = '0' order by Del_Level desc";
                table = dbFacade.SQLExecuteDataTable(sql, "DEL_LOG");
            }
            catch (Exception e)
            {
                throw e;
            }
            return table;
        }


    }
}
