using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.UI.PublicModule;

namespace Emedchina.TradeAssistant.Client.UI.SystemManage
{
    public partial class UserConfig : BaseForm
    {
        string XmlPath = ClientConfiguration.LocalPersonConfigPath;
        string oldMenuStyle;
        Form mainFrm;
        Form loginFrm;

        public UserConfig()
        {
            InitializeComponent();
        }

        public UserConfig(Form frm,Form loginForm)
        {
            InitializeComponent();
            mainFrm = frm;
            loginFrm = loginForm;
        }

        private void SystemConfigMgr_Load(object sender, EventArgs e)
        {
            IniXmlConfig();
            oldMenuStyle = ClientConfiguration.MenuStyle;
        }


        private void IniXmlConfig()
        {
            if (File.Exists(XmlPath))
            {
                XmlDocument document1 = new XmlDocument();
                document1.Load(XmlPath);
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ConnectLogic");

                this.ChkIsOfflineLogin.Checked = element1.GetAttribute("IsOfflineLogin").ToLower() == "true";
                this.ChkIfSendImmediately.Checked = element1.GetAttribute("IfSendImmediately").ToLower() == "true";
                this.ChkIfDefineBigPacking.Checked = element1.GetAttribute("IfDefineBigPacking").ToLower() == "true";
                this.ChkIfUseSecondCate.Checked = element1.GetAttribute("IfUseSecondCate").ToLower() == "true";
                this.ChkIfSetAutoReceive.Checked = element1.GetAttribute("IfSetAutoReceive").ToLower() == "true";
                this.ChkSetProEasy.Checked = element1.GetAttribute("IfSetProEasy").ToLower() == "true";
                this.ChkIfCompelSync.Checked = element1.GetAttribute("IfCompelSync").ToLower() == "true";
                //this.ceIfUseDefaultSet.Checked = element1.GetAttribute("IfUseDefaultSet").ToLower() == "true";
                
                this.colorEditListOdd.Color = Color.FromArgb(int.Parse(element1.GetAttribute("OddColor")));
                this.colorEditListEven.Color = Color.FromArgb(int.Parse(element1.GetAttribute("EvenColor")));
                this.cbeDot.Text = element1.GetAttribute("DotSetting").ToString();
                this.autoRdays.Text = element1.GetAttribute("AutoReceiveDays").ToString();

                element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ClientOptions");
                this.chkIfMenuStyle.Checked = element1.GetAttribute("MenuStyle").Equals("0");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                PostXmlConfig();
                XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //MessageBox.Show("保存成功！", "交易助手", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show("操作失败！", "交易助手", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            if (!oldMenuStyle.Equals(ClientConfiguration.MenuStyle))
            {
                //mainFrm.Close();
                //mainFrm.Dispose();
                //if (!ClientConfiguration.MenuStyle.Equals("0"))
                //    new MainForm(loginFrm).Show();
                //else
                //    new ParentForm(loginFrm).Show();
                XtraMessageBox.Show("请重新登录，菜单风格才能生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void PostXmlConfig()
        {
            
            string XmlPath = ClientConfiguration.LocalPersonConfigPath;
            if (File.Exists(XmlPath))
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(XmlPath);
                XmlElement element1 = (XmlElement)Doc.SelectSingleNode("UserConfig/ConnectLogic");

                element1.SetAttribute("IsOfflineLogin", this.ChkIsOfflineLogin.Checked ? "True" : "False");
                element1.SetAttribute("DotSetting", this.cbeDot.Text.ToString());
                element1.SetAttribute("AutoReceiveDays", this.autoRdays.Text.ToString());
                
                element1.SetAttribute("EvenColor", this.colorEditListEven.Color.ToArgb().ToString());
                element1.SetAttribute("OddColor", this.colorEditListOdd.Color.ToArgb().ToString());

                element1.SetAttribute("IfSendImmediately", this.ChkIfSendImmediately.Checked ? "True" : "False");
                element1.SetAttribute("IfDefineBigPacking", this.ChkIfDefineBigPacking.Checked ? "True" : "False");
                element1.SetAttribute("IfUseSecondCate", this.ChkIfUseSecondCate.Checked ? "True" : "False");
                element1.SetAttribute("IfSetAutoReceive", this.ChkIfSetAutoReceive.Checked ? "True" : "False");
                element1.SetAttribute("IfSetProEasy", this.ChkSetProEasy.Checked ? "True" : "False");
                element1.SetAttribute("IfCompelSync", this.ChkIfCompelSync.Checked ? "True" : "False");
                //element1.SetAttribute("IfUseDefaultSet", this.ceIfUseDefaultSet.Checked ? "True" : "False");
                

                //string Bother = this.ChkIsOfflineOther.Checked ? "True" : "False";

                //element1.SetAttribute("IsOfflineAddIntoReturnOrder", Bother);

                element1 = (XmlElement)Doc.SelectSingleNode("UserConfig/LoginLog");
                element1.SetAttribute("LoginedUsersCode", ClientConfiguration.UserCode);
                element1.SetAttribute("LastLoginedUserCode", ClientConfiguration.LastUserCode);

                element1 = (XmlElement)Doc.SelectSingleNode("UserConfig/ClientOptions");
                element1.SetAttribute("MenuStyle", this.chkIfMenuStyle.Checked ? "0":"1");
                Doc.Save(XmlPath);
            }

            ClientConfiguration.Reload();
        }

        private void UserConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }



    }
}