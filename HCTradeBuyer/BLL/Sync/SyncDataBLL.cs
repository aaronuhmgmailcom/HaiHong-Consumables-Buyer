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
        /// ȡ�õ�������
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetSyncTable(string tableName, LogedInUser CurrentUser)
        {
            DataTable tb = dao.GetSyncTable(tableName, CurrentUser);
            return tb;
        }

        /// <summary>
        /// ȡ�õ�������(ѹ��)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetSyncTableEx(string tableName, LogedInUser CurrentUser)
        {
            DataTable tb = dao.GetSyncTable(tableName, CurrentUser);
            return (byte[])CompressUtil.CompressData(tb);
        }

        /// <summary>
        /// ȡ������ͬ������
        /// </summary>
        /// <returns></returns>
        public byte[] GetSyncData(LogedInUser CurrentUser)
        {
            DataSet ds = dao.GetSyncData(CurrentUser);
            return DataSerialization.SerializeData(ds);
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
            return dao.GetIncrementSyncData(tableName, CurrentUser, syncTime);
        }

        /// <summary>
        /// ȡ������ͬ�������б�����
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="syncTime"></param>
        /// <returns></returns>
        public DataSet GetAllIncrementSyncData(LogedInUser CurrentUser, string[] syncTime)
        {
            return dao.GetAllIncrementSyncData(CurrentUser, syncTime);
        }

        /// <summary>
        /// ȡ��ϵͳ��ǰʱ��
        /// </summary>
        /// <returns></returns>
        public string GetSysDate()
        {
            return dao.GetSysDate();
        }

        /// <summary>
        /// ȡ�ñ���
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableName()
        {
            return dao.GetTableName();
        }


        /// <summary>
        /// ȡ�õ�������,����csv�ļ�
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] DataToFile(string tableName, LogedInUser CurrentUser)
        {
            return dao.DataToFile(tableName, CurrentUser);
        }



        /// <summary>
        /// ȡ�õ�������(ѹ��)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public byte[] GetDataByCsvStream(string tableName, LogedInUser CurrentUser)
        {
            return dao.GetDataByCsvStream(tableName, CurrentUser);
        }

        /// <summary>
        /// ˢ���û�����
        /// </summary>
        public void RefreshUserData()
        {
            dao.RefreshUserData();
        }
    }
}
