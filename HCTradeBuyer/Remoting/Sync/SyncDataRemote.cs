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
        /// ȡ�õ�������
        /// </summary>
        public DataTable GetSyncTable(string tableName,LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetSyncTable(tableName,CurrentUser);
        }

        /// <summary>
        /// ȡ�õ�������(ѹ��)
        /// </summary>
        public byte[] GetSyncTableEx(string tableName, LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetSyncTableEx(tableName, CurrentUser);
        }

        /// <summary>
        /// ȡ�����б�����
        /// </summary>
        public byte[] GetSyncData(LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetSyncData(CurrentUser);
        }

        /// <summary>
        /// ȡ������ͬ���ĵ�������
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
        /// ȡ������ͬ�������б�����
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataSet GetAllIncrementSyncData(LogedInUser CurrentUser, string[] syncTime)
        {
            return SyncDataBLL.GetInstance().GetAllIncrementSyncData(CurrentUser, syncTime);
        }

        /// <summary>
        /// ȡ��ϵͳ��ǰʱ��
        /// </summary>
        /// <returns></returns>
        public string GetSysDate()
        {
            return SyncDataBLL.GetInstance().GetSysDate();
        }

        /// <summary>
        /// ȡ�ñ���
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableName()
        {
            return SyncDataBLL.GetInstance().GetTableName();
        }


        /// <summary>
        /// ȡ�õ�������,����csv�ļ�
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] DataToFile(string tableName,LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().DataToFile(tableName,CurrentUser);
        }


        /// <summary>
        /// ȡ�õ�������(ѹ��)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetDataByCsvStream(string tableName, LogedInUser CurrentUser)
        {
            return SyncDataBLL.GetInstance().GetDataByCsvStream(tableName, CurrentUser);
        }

        /// <summary>
        /// ˢ���û�����
        /// </summary>
        public void RefreshUserData()
        {
            SyncDataBLL.GetInstance().RefreshUserData();
        }
    }
}
