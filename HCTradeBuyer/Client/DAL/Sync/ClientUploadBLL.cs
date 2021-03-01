using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.Common;

namespace Emedchina.TradeAssistant.Client.DAL.Sync
{
    class ClientUploadBLL
    {
        /// <summary>
        /// 上传数据操作
        /// </summary>
        /// <param name="InvalidList"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public bool UploadData(bool sendFlag, out List<string> InvalidList, out int rows)
        {
            DataSet Upds;
            //定义上传操作类
            ClientUploadDao UploadDao = ClientUploadDao.GetInstance(Constant.ACESSDB_ALIAS);
            //获取需要同步的表单数据(本地)
            if (sendFlag)
                Upds = UploadDao.GetSyncDataForSendNow();
            else
                Upds = UploadDao.GetSyncData();
            //获取需要删除的表单数据(本地)
            DataTable delTable = UploadDao.GetDelData();

            
            //定义所有表单数据总记录数
            int i = 0;
            rows = 0;
            InvalidList = null;
            foreach (DataTable dt in Upds.Tables)
            {
                i += dt.Rows.Count;
            }
            if (i > 0 || delTable.Rows.Count > 0)
            {
                rows = i + delTable.Rows.Count;
                //在服务上执行数据操作（更新、删除）
                return ProxyFactory.UploadRemote.UploadData(Upds, delTable, out InvalidList);
            }
            UploadDao.CloseConntion();
            UploadDao = null;
            return true;
        }


    }
}
