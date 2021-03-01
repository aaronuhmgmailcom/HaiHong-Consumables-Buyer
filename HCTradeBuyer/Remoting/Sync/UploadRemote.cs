using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.TradeAssistant.DAL.Sync;

namespace Emedchina.TradeAssistant.Remoting.Sync
{
    public class UploadRemote : MarshalByRefObject
    {
        //上传数据
        public bool UploadData(DataSet Upds, DataTable delTable, out List<string> InvalidList)
        {
            bool flag = false;
            InvalidList = null;
            try
            {
                flag = UploadBLL.GetInstance().UploadData(Upds, delTable, out InvalidList);
            }
            catch (Exception e)
            {
                flag = false;
            }
            return flag;

        }
    }
}
