/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/Server/Program.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 3 $
 * $Date: 06-06-28 15:57 $
 * $History: Program.cs $
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Server
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-27   Time: 14:58
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Server
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Configuration;

namespace Emedchina.TradeAssistant.Server
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //EncryptConfiguration();
            RemotingConfiguration.Configure("HCServer.exe.config", false);
            System.Console.ReadLine();
        }
        static void EncryptConfiguration()
        {
            // 使用什么类型的加密

            string provider = "RsaProtectedConfigurationProvider";

            Configuration config = null;

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 加密连接字符串

            ConfigurationSection section = config.ConnectionStrings;
            //ConfigurationSectionCollection sections = config.Sections;

            if ((section.SectionInformation.IsProtected == false) &&

                (section.ElementInformation.IsLocked == false))
            {
                section.SectionInformation.ProtectSection(provider);

                section.SectionInformation.ForceSave = true;
            }

            config.Save(ConfigurationSaveMode.Full);
        }
    }
}
