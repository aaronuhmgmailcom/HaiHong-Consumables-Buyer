using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

//using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using System.Collections;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Emedchina.Commons.Util;

namespace Emedchina.TradeAssistant.Client.DAL.Sync
{
    class ClientSyncBLL
    {
        /// <summary>
        ///数据同步业务逻辑层
        /// </summary>
        //public int SyncTable(string buyerId, string tablename)
        //{
        //    string syncTime;
        //    int rows;
        //    ClientSyncDataDAO dao = ClientSyncDataDAO.GetInstance(Constant.ACCESSDBALIAS);
        //    syncTime = dao.GetLastSyncTime(tablename, buyerId);
        //    DataSet ds = ProxyFactory.SyncDataProxy.GetIncrementSyncData(tablename, buyerId, syncTime);
        //    rows = Convert.ToInt32(ds.Tables[0].Rows.Count);
        //    dao.IncrementSyncTableEx(ds);

        //    return rows;
        //}
        /// <summary>
        /// 获得同步表的列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetTableParameter()
        {
            ArrayList results = new ArrayList();
            try
            {
                string clientType = UserConfigXml.GetConfigInfo("ClientType", "type");
                XmlNodeList node = UtilXml.GetNodeList();
                foreach (XmlNode nd in node)
                {

                    string temp = UtilXml.GetSyncText(nd.Attributes[0].Value.ToString(), "parameter");
                    temp = nd.Attributes[0].Value.ToString() + "," + temp;
                    results.Add(temp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }
        /// <summary>
        /// 秒数转成XX小时XX分XX秒
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public string SecondToTimeStr(int m)
        {
            string Hour = "", Minute = "", Second = "";
            // decimal xx=Math.Truncate(m/3600);
            string result;
            if (m > 3600)
            {
                Hour = Convert.ToInt16(Math.Truncate(Convert.ToDouble(m / 3600))).ToString() + "小时";
                m = Convert.ToInt16(m - 3600 * Math.Truncate(Convert.ToDouble(m / 3600)));
            }
            if (m < 60)
            {
                Minute = m.ToString() + "秒";
            }
            else if (m < 3600)
            {
                Minute = Convert.ToInt16(Math.Truncate(Convert.ToDouble(m / 60))).ToString() + "分";
                Second = Convert.ToInt16((m - 60 * Math.Truncate(Convert.ToDouble(m / 60)))).ToString() + "秒";
            }

            result = Hour + Minute + Second;
            return result;
        }

    }
}
