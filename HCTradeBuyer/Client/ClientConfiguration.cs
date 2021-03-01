#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler/ClientConfiguration.cs 5     06-09-04 10:07 Sunhl $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">�����(sunhl)</a>
 * $Revision: 5 $
 * $Date: 06-09-04 10:07 $
 * $History: ClientConfiguration.cs $
 * 
 * *****************  Version 5  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:07
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * �޸���������
 * 
 * *****************  Version 4  *****************
 * User: Liangxy      Date: 06-07-06   Time: 14:34
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 3  *****************
 * User: Liangxy      Date: 06-06-28   Time: 10:55
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-27   Time: 14:58
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 * 
 * *****************  Version 1  *****************
 * User: Sunhl        Date: 06-06-27   Time: 14:12
 * Created in $/TradeAssistantSaler.root/TradeAssistantSaler/TradeAssistantSaler
 ********************************************************************************/
#endregion

#region using
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using System.Xml;
#endregion

namespace Emedchina.TradeAssistant.Client
{


    /// <summary>
    /// ά���ͻ�������,������Settings.settings,�����������޸Ĳ���.
    /// </summary>
    public class ClientConfiguration
    {
        private static Configuration conf;
        //���ز�����·��
        private static String localDBFile;
        //���ز������ļ�·����
        private static String localDBPath;
        //������ʱ��·��
        private static String tmpDBFile;
        //������ʱ���ļ�·����
        private static String tmpDBPath;
        //�û���¼��־���
        private static String loginedUsersCode;
        private static String lastLoginedUserCode;
        private static String lastFormName;
        //���ؿ������ļ�·��
        private static String localPersonConfigPath;

        public static bool IsOffline;
        //�Ƿ����߷���������¼
        public static bool IsOfflineLogin;
        //С��λ��
        public static string DotSetting;
        //���ɫ
        public static string EvenColor;
        public static string OddColor;
        //ǿ��ͬ��
        public static bool IfCompelSync;
        //�˵����
        public static string MenuStyle;
        //�Զ�����װ
        public static bool IfDefineBigPacking;
        //��������
        public static bool IfSendImmediately;
        //Ƥ��
        public static string Skin;

        //�Զ������
        public static bool IfSetProEasy;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClientConfiguration"/> class.
        /// </summary>
        static ClientConfiguration()
        {
            Reload();
        }

        public static void Reload()
        {
            //��ȡ���ؿ��ļ���Ϣ
            try
            {
                localDBPath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\DB\\";
                localDBFile = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\DB\\TradeAssistant.mdf";
                tmpDBPath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\DB\\";
                tmpDBFile = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + "\\DB\\TempTrade.mdf";
                localPersonConfigPath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory + @"\UserConfig.xml";
            }
            catch (Exception e)
            {
                localDBPath = AppDomain.CurrentDomain.BaseDirectory + "DB\\";
                localDBFile = AppDomain.CurrentDomain.BaseDirectory + "DB\\TradeAssistant.mdf";
                tmpDBPath = AppDomain.CurrentDomain.BaseDirectory + "DB\\";
                tmpDBFile = AppDomain.CurrentDomain.BaseDirectory + "DB\\TempTrade.mdf";
                localPersonConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"UserConfig.xml";
            }
            conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //��ʼ���û������ļ�
            InitUserConfig();
        }



        /// <summary>
        /// ��ʼ���û������ļ�
        /// </summary>
        /// <returns></returns>
        public static void InitUserConfig()
        {
            try
            {
                string XmlPath = ClientConfiguration.LocalPersonConfigPath ;
                if (File.Exists(XmlPath))
                {
                    XmlDocument document1 = new XmlDocument();
                    document1.Load(XmlPath);
                    XmlElement element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ConnectLogic");
                    //���ߵ�¼
                    IsOfflineLogin = element1.GetAttribute("IsOfflineLogin").ToLower() == "true";
                    IsOffline = element1.GetAttribute("IsOffline").ToLower() == "true";
                    DotSetting = element1.GetAttribute("DotSetting");
                    EvenColor = element1.GetAttribute("EvenColor");
                    OddColor = element1.GetAttribute("OddColor");
                    IfCompelSync = element1.GetAttribute("IfCompelSync").ToLower() == "true";
                    IfDefineBigPacking = element1.GetAttribute("IfDefineBigPacking").ToLower() == "true";
                    IfSendImmediately = element1.GetAttribute("IfSendImmediately").ToLower() == "true";
                    IfSetProEasy = element1.GetAttribute("IfSetProEasy").ToLower() == "true";

                    element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ClientOptions");
                    MenuStyle = element1.GetAttribute("MenuStyle");
                    Skin = element1.GetAttribute("Skin");

                    element1 = (XmlElement)document1.SelectSingleNode("UserConfig/LoginLog");
                    loginedUsersCode = element1.GetAttribute("LoginedUsersCode");
                    lastLoginedUserCode = element1.GetAttribute("LastLoginedUserCode");
                    lastFormName = element1.GetAttribute("LastFormName");
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Saves this instance.save the ConfigurationSaveMode.Modified.
        /// </summary>
        public static void Save()
        {
            Save(ConfigurationSaveMode.Modified);
        }

        /// <summary>
        /// Saves the specified save mode.
        /// </summary>
        /// <param name="saveMode">The save mode.</param>
        public static void Save(ConfigurationSaveMode saveMode)
        {
            conf.Save(saveMode);
        }

        /// <summary>
        /// Gets the client config.
        /// </summary>
        /// <value>The client config.</value>
        public static Configuration ClientConfig
        {
            get { return conf; }
        }

        ///// <summary>
        ///// Reloads this configuration.
        ///// </summary>
        //public static void Reload()
        //{
        //    conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //}


        ///// <summary>
        ///// Saves this instance.save the ConfigurationSaveMode.Modified.
        ///// </summary>
        //public static void Save()
        //{
        //    Save(ConfigurationSaveMode.Modified);
        //}

        ///// <summary>
        ///// Saves the specified save mode.
        ///// </summary>
        ///// <param name="saveMode">The save mode.</param>
        //public static void Save(ConfigurationSaveMode saveMode)
        //{
        //    conf.Save(saveMode);
        //}

        /// <summary>
        /// Gets or sets ������ʱ���ļ�
        /// </summary>
        public static string TmpDBFile
        {
            get { return tmpDBFile; }
            set { tmpDBFile = value; }
        }
        /// <summary>
        /// Gets or sets ������ʱ���ļ�·��
        /// </summary>
        public static string TmpDBPath
        {
            get { return tmpDBPath; }
            set { tmpDBPath = value; }
        }

        /// <summary>
        /// Gets or sets ���ؿ��ļ�
        /// </summary>
        public static string LocalDBFile
        {
            get { return localDBFile; }
            set { localDBFile = value; }
        }
        /// <summary>
        /// Gets or sets ���ؿ��ļ�·��
        /// </summary>
        public static string LocalDBPath
        {
            get { return localDBPath; }
            set { localDBPath = value; }
        }


        /// <summary>
        /// Gets or sets the machine.
        /// </summary>
        /// <value>The machine.</value>
        public static string RemoteMachine
        {
            get { return conf.AppSettings.Settings["REMOTEMACHINE"].Value; }
            set { conf.AppSettings.Settings["REMOTEMACHINE"].Value = value; }
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        public static string RemotePort
        {
            get { return conf.AppSettings.Settings["REMOTEPORT"].Value; }
            set { conf.AppSettings.Settings["REMOTEPORT"].Value = value; }
        }        

        public static string UPDATEURL
        {
            get { return conf.AppSettings.Settings["UPDATEURL"].Value; }
            set { conf.AppSettings.Settings["UPDATEURL"].Value = value; }
        }
        /// <summary>
        /// Gets or sets the WebUrl.
        /// </summary>
        /// <value>The WebUrl.</value>
        public static string WebUrl
        {
            get { return conf.AppSettings.Settings["WEBURL"].Value; }
            set { conf.AppSettings.Settings["WEBURL"].Value = value; }
        }
        /// <summary>
        /// Gets or sets the ResumeFlg.
        /// </summary>
        /// <value>The ResumeFlg.</value>
        public static string ResumeFlg
        {
            get { return conf.AppSettings.Settings["RESUMEFLG"].Value; }
            set { conf.AppSettings.Settings["RESUMEFLG"].Value = value; }
        }

        /// <summary>
        /// Gets or sets the sync policy.
        /// </summary>
        /// <value>The sync policy.</value>
        public static string SyncPolicy
        {
            get { return conf.AppSettings.Settings["SYNCPOLICY"].Value; }
            set { conf.AppSettings.Settings["SYNCPOLICY"].Value = value; }
        }
        /// <summary>
        /// Gets or sets the sync policy.
        /// </summary>
        /// <value>The sync policy.</value>
        public static string HisPath
        {
            get { return conf.AppSettings.Settings["HISPATH"].Value; }
            set { conf.AppSettings.Settings["HISPATH"].Value = value; }
        }
        /// <summary>
        /// Gets or sets the HISPATHEX
        /// </summary>
        public static string HisPathEx
        {
            get { return conf.AppSettings.Settings["HISPATHEX"].Value; }
            set { conf.AppSettings.Settings["HISPATHEX"].Value = value; }
        }
        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        /// <value>ConnectionString.</value>
        public static string ConnectionString
        {
            get { return conf.ConnectionStrings.ConnectionStrings["His"].ConnectionString; }
            set { conf.ConnectionStrings.ConnectionStrings["His"].ConnectionString = value; }
        }
        /// <summary>
        /// Gets or sets the HisEx ConnectionString.
        /// </summary>
        /// <value>ConnectionString.</value>
        public static string ConnectionStringEx
        {
            get { return conf.ConnectionStrings.ConnectionStrings["HisEx"].ConnectionString; }
            set { conf.ConnectionStrings.ConnectionStrings["HisEx"].ConnectionString = value; }
        }

        public static string UserCode
        {
            get { return loginedUsersCode; }
            set { loginedUsersCode = value; }
        }

        public static string LastUserCode
        {
            get { return lastLoginedUserCode; }
            set { lastLoginedUserCode = value; }
        }

        /// <summary>
        /// Gets or sets ���ظ��Ի������ļ�·��
        /// </summary>
        public static string LocalPersonConfigPath
        {
            get { return localPersonConfigPath; }
            set { localPersonConfigPath = value; }
        }
    }
}
