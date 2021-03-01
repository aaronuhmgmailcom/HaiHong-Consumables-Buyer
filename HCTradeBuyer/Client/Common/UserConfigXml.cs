using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Emedchina.TradeAssistant.Client.Common
{
    public class UserConfigXml
    {
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

        /// <summary>
        /// 取得xml文件路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetXMLFile(string fileName)
        {
            string strFile;
            try
            {
                strFile = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\" + fileName;
            }
            catch (Exception e)
            {
                strFile = AppDomain.CurrentDomain.BaseDirectory + fileName;
            }

            return strFile;
        }


        /// <summary>
        /// 取得功能配置信息
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="element">属性名</param>
        /// <returns></returns>
        public static string GetConfigInfo(string nodeName, string element)
        {
            string info;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                String filePath = GetXMLFile("UserConfig.xml");
                xmlDoc.Load(filePath);
                XmlElement element1 = (XmlElement)xmlDoc.SelectSingleNode("UserConfig/" + nodeName);
                info = element1.GetAttribute(element).Trim().ToUpper();
            }
            catch
            {
                MessageBox.Show("配置信息读取失败！", "文件操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return info;
        }

        /// <summary>
        /// 保存功能配置信息
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="element">属性名</param>
        /// <returns></returns>
        public static void SetConfigInfo(string nodeName, string element, string value)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                String filePath = GetXMLFile("UserConfig.xml");
                xmlDoc.Load(filePath);
                XmlElement element1 = (XmlElement)xmlDoc.SelectSingleNode("UserConfig/" + nodeName);
                element1.SetAttribute(element, value);
                xmlDoc.Save(filePath);
            }
            catch
            {
                MessageBox.Show("配置信息保存失败！", "文件操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
