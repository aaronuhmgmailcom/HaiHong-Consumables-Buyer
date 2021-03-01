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
            XmlNode node = xmlDoc.SelectSingleNode("sync/sql[@table='" + tableName.ToUpper() + "']/" + element);
            return node.InnerText.Trim();
        }

        /// <summary>
        /// ȡ��xml�ļ�·��
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
        /// ȡ�ù���������Ϣ
        /// </summary>
        /// <param name="nodeName">�ڵ���</param>
        /// <param name="element">������</param>
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
                MessageBox.Show("������Ϣ��ȡʧ�ܣ�", "�ļ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return info;
        }

        /// <summary>
        /// ���湦��������Ϣ
        /// </summary>
        /// <param name="nodeName">�ڵ���</param>
        /// <param name="element">������</param>
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
                MessageBox.Show("������Ϣ����ʧ�ܣ�", "�ļ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }



        #region ��ýڵ����
        /// <summary>
        /// ��ýڵ����
        /// </summary>
        /// <param name="strFilePath">�ļ�·��</param>
        /// <param name="strNodePath">�ڵ�·��</param>
        /// <returns>�ڵ���󣬵��ڵ㲻���ڷ���null</returns>
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
                //�ж��Ƿ����ָ���ڵ�
                if (e == null)
                {
                    //��������ڷ���null
                    xn = null;
                }
            }
            catch
            {
                throw;
            }

            //����
            return xn;
        }
        #endregion

        #region ��ýڵ�����ֵ
        /// <summary>
        /// ��ýڵ�����ֵ
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="strAttrName"></param>
        /// <returns></returns>
        public static string GetNodeValue(XmlNode xn, string strAttrName)
        {
            string strNodeValue = null;
            try
            {
                //�������ڵ�Ϊnull,����null
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
