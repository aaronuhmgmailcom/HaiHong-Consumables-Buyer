using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Emedchina.TradeAssistant.DAL.Sync;
using Emedchina.TradeAssistant.DAL.Sync;

namespace Emedchina.TradeAssistant.DAL.Sync
{
    public class UploadBLL
    {

        private UploadDAO dao = null;

        private UploadBLL()
        {
            dao = UploadDAO.GetInstance();
        }

        private UploadBLL(string connectionName)
        {
            dao = UploadDAO.GetInstance(connectionName);
        }

        public static UploadBLL GetInstance()
        {
            return new UploadBLL();
        }

        public static UploadBLL GetInstance(string connectionName)
        {
            return new UploadBLL(connectionName);
        }
        public bool UploadData(DataSet Upds, DataTable delTable, out List<string> InvalidList)
        {
            return dao.UploadData(Upds, delTable, out InvalidList);
        }
    }
}
