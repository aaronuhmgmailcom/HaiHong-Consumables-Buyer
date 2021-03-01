using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Emedchina.TradeAssistant.DAL.Common
{
    public class XmlUtil
    {
        /// <summary>
        /// ���ݱ���ȡ��xml�ļ��ж�Ӧ��Ԫ����Ϣ
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetSyncText(string tableName, string element)
        {
            XmlDocument xmlDoc = new XmlDocument();
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "Sync.xml";
            xmlDoc.Load(filePath);
            XmlNode node = xmlDoc.SelectSingleNode("sync/sql[@table='" + tableName.ToUpper().Trim() + "']/" + element);
            return node.InnerText.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static XmlNodeList GetNodeList()
        {
            XmlDocument xmlDoc = new XmlDocument();
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "Sync.xml";
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectNodes("//sql[@table]");
            return node;
        }
    }
}
