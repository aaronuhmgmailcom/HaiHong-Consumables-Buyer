using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using Emedchina.TradeAssistant.Client.UI.PublicModule;

namespace Emedchina.TradeAssistant.Client
{
    static class Client
    {
        /// <summary>
        /// 应用程序的主入口点。

        /// </summary>
        [STAThread]
        static void Main()
        {

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //EncryptConfiguration();
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.XtraEditorsLocalizer();
            Application.Run(new LoginFrm());
            //Application.Run(new ParentForm());
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