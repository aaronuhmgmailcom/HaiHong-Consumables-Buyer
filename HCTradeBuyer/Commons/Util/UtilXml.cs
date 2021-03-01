using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Emedchina.Commons.Util
{
    public class UtilXml
    {
        /// <summary>
        /// 获取同步配置节点信息
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

        /// <summary>
        /// 根据表名取得xml文件中对应的元素信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetSyncText(string tableName, string element)
        {
            XmlDocument xmlDoc = new XmlDocument();
            String filePath = AppDomain.CurrentDomain.BaseDirectory + "Sync.xml";
            xmlDoc.Load(filePath);
            XmlNode node = xmlDoc.SelectSingleNode("sync/sql[@table='" + tableName.ToUpper() + "']/" + element);
            return node.InnerText.Trim();
        }

        #region 获得节点对象
        /// <summary>
        /// 获得节点对象
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="strNodePath">节点路径</param>
        /// <returns>节点对象，当节点不存在返回null</returns>
        public static XmlNode GetNodeObject(string strFileName, string strNodePath)
        {
            XmlNode xn = null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                string strFilePath = AppDomain.CurrentDomain.BaseDirectory + strFileName;
                xmlDoc.Load(strFilePath);

                xn = xmlDoc.SelectSingleNode(strNodePath);
                XmlElement e = (XmlElement)xn;
                //判断是否存在指定节点
                if (e == null)
                {
                    //如果不存在返回null
                    xn = null;
                }
            }
            catch
            {
                throw;
            }

            //返回
            return xn;
        }
        #endregion

        #region 获得节点属性值
        /// <summary>
        /// 获得节点属性值
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="strAttrName"></param>
        /// <returns></returns>
        public static string GetNodeValue(XmlNode xn, string strAttrName)
        {
            string strNodeValue = null;
            try
            {
                //如果传入节点为null,返回null
                if (xn == null)
                {
                    return null;
                }
                XmlElement xe = (XmlElement)xn;
                strNodeValue = xe.GetAttribute(strAttrName);
            }
            catch
            {
                throw;
            }

            return strNodeValue;
        }
        #endregion

    }
}
