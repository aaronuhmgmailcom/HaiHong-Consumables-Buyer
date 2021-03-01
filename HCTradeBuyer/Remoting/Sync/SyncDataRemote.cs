using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.TradeAssistant.BLL.Sync;
using Emedchina.TradeAssistant.Model.User;

namespace Emedchina.TradeAssistant.Remoting.Sync
{
    public class SyncDataRemote : MarshalByRefObject
    {
        /// <summary>
        /// 取得单表数据
        /// </summary>
        public DataTable GetSyncTable(string tableName,LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetSyncTable(tableName,CurrentUser);
        }

        /// <summary>
        /// 取得单表数据(压缩)
        /// </summary>
        public byte[] GetSyncTableEx(string tableName, LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetSyncTableEx(tableName, CurrentUser);
        }

        /// <summary>
        /// 取得所有表数据
        /// </summary>
        public byte[] GetSyncData(LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetSyncData(CurrentUser);
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
            return SyncDataBLL.GetInstance().GetIncrementSyncData(tableName, CurrentUser, syncTime);
        }

        /// <summary>
        /// 取得增量同步的所有表数据
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataSet GetAllIncrementSyncData(LogedInUser CurrentUser, string[] syncTime)
        {
            return SyncDataBLL.GetInstance().GetAllIncrementSyncData(CurrentUser, syncTime);
        }

        /// <summary>
        /// 取得系统当前时间
        /// </summary>
        /// <returns></returns>
        public string GetSysDate()
        {
            return SyncDataBLL.GetInstance().GetSysDate();
        }

        /// <summary>
        /// 取得表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableName()
        {
            return SyncDataBLL.GetInstance().GetTableName();
        }


        /// <summary>
        /// 取得单表数据,生产csv文件
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] DataToFile(string tableName,LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().DataToFile(tableName,CurrentUser);
        }


        /// <summary>
        /// 取得单表数据(压缩)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetDataByCsvStream(string tableName, LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetDataByCsvStream(tableName, CurrentUser);
        }

        /// <summary>
        /// 刷新用户数据
        /// </summary>
        public void RefreshUserData()
        {
            SyncDataBLL.GetInstance().RefreshUserData();
        }
    }
}
