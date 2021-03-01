using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.TradeAssistant.DAL.Sync;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.User;

namespace Emedchina.TradeAssistant.BLL.Sync
{
    public class SyncDataBLL
    {
        private SyncDataDAO dao = null;

        private SyncDataBLL()
        {
            dao = SyncDataDAO.GetInstance();
        }

        private SyncDataBLL(string connectionName)
        {
            dao = SyncDataDAO.GetInstance(connectionName);
        }

        public static SyncDataBLL GetInstance()
        {
            return new SyncDataBLL();
        }

        public static SyncDataBLL GetInstance(string connectionName)
        {
            return new SyncDataBLL(connectionName);
        }

        /// <summary>
        /// 取得单表数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetSyncTable(string tableName, LogedInUser CurrentUser)
        {
            DataTable tb = dao.GetSyncTable(tableName, CurrentUser);
            return tb;
        }

        /// <summary>
        /// 取得单表数据(压缩)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetSyncTableEx(string tableName, LogedInUser CurrentUser)
        {
            DataTable tb = dao.GetSyncTable(tableName, CurrentUser);
            return (byte[])CompressUtil.CompressData(tb);
        }

        /// <summary>
        /// 取得所有同步数据
        /// </summary>
        /// <returns></returns>
        public byte[] GetSyncData(LogedInUser CurrentUser)
        {
            DataSet ds = dao.GetSyncData(CurrentUser);
            return DataSerialization.SerializeData(ds);
        }

        /// <summary>
        /// 取得增量同步的单表数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataSet GetIncrementSyncData(string tableName, LogedInUser CurrentUser, string syncTime)
        {
            return dao.GetIncrementSyncData(tableName, CurrentUser, syncTime);
        }

        /// <summary>
        /// 取得增量同步的所有表数据
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataSet GetAllIncrementSyncData(LogedInUser CurrentUser, string[] syncTime)
        {
            return dao.GetAllIncrementSyncData(CurrentUser, syncTime);
        }

        /// <summary>
        /// 取得系统当前时间
        /// </summary>
        /// <returns></returns>
        public string GetSysDate()
        {
            return dao.GetSysDate();
        }

        /// <summary>
        /// 取得表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableName()
        {
            return dao.GetTableName();
        }


        /// <summary>
        /// 取得单表数据,生产csv文件
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] DataToFile(string tableName, LogedInUser CurrentUser)
        {
            return dao.DataToFile(tableName, CurrentUser);
        }



        /// <summary>
        /// 取得单表数据(压缩)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetDataByCsvStream(string tableName, LogedInUser CurrentUser)
        {
            return dao.GetDataByCsvStream(tableName, CurrentUser);
        }

        /// <summary>
        /// 刷新用户数据
        /// </summary>
        public void RefreshUserData()
        {
            dao.RefreshUserData();
        }
    }
}
