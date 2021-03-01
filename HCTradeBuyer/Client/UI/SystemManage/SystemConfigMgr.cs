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

namespace Emedchina.TradeAssistant.Client.UI.SystemManage
{
    public partial class SystemConfigMgr : BaseForm
    {
        string XmlPath = ClientConfiguration.LocalPersonConfigPath + @"\UserConfig.xml";

        public SystemConfigMgr()
        {
            InitializeComponent();
        }

        private void SystemConfigMgr_Load(object sender, EventArgs e)
        {
            this.txtIp.Text = ClientConfiguration.RemoteMachine;
            this.txtPort.Text = ClientConfiguration.RemotePort;
            this.txtTradeWeb.Text = ClientConfiguration.WebUrl;
            this.txtUpdateWeb.Text = ClientConfiguration.UPDATEURL;

            IniXmlConfig();
            if (ClientSession.GetInstance().IsLogin)
            {
                txtIp.Properties.ReadOnly = true;
                txtPort.Properties.ReadOnly = true;
            }
            else
            {
                txtIp.Properties.ReadOnly = false;
                txtPort.Properties.ReadOnly = false;
            }

            if (string.IsNullOrEmpty(ClientConfiguration.Skin))
                this.LookAndFeel.SetSkinStyle("Money Twins");
            else
                this.LookAndFeel.SetSkinStyle(ClientConfiguration.Skin);
        }


        private void IniXmlConfig()
        {
            if (File.Exists(XmlPath))
            {
                XmlDocument document1 = new XmlDocument();
                document1.Load(XmlPath);
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ConnectLogic");
                
                //this.ChkIsOfflineLogin.Checked = element1.GetAttribute("IsOfflineLogin").ToLower() == "true";
                //this.ChkIfSendImmediately.Checked = element1.GetAttribute("IfSendImmediately").ToLower() == "true";
                //this.ChkIfDefineBigPacking.Checked = element1.GetAttribute("IfDefineBigPacking").ToLower() == "true";
                //this.ChkIfUseSecondCate.Checked = element1.GetAttribute("IfUseSecondCate").ToLower() == "true";
                //this.ChkIfSetAutoReceive.Checked = element1.GetAttribute("IfSetAutoReceive").ToLower() == "true";
                //this.ChkSetProEasy.Checked = element1.GetAttribute("IfSetProEasy").ToLower() == "true";
                //this.ChkIfCompelSync.Checked = element1.GetAttribute("IfCompelSync").ToLower() == "true";



                //this.cbeDot.SelectedItem = element1.GetAttribute("DotSetting").ToString();


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ClientConfiguration.RemoteMachine = this.txtIp.Text.ToString();
                ClientConfiguration.RemotePort = this.txtPort.Text.ToString();
                ClientConfiguration.WebUrl = this.txtTradeWeb.Text.ToString();
                ClientConfiguration.UPDATEURL = this.txtUpdateWeb.Text.ToString();
                Properties.Settings.Default.Save();
                ClientConfiguration.Save();

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
            this.Close();
        }

        private void PostXmlConfig()
        {
            string XmlPath = ClientConfiguration.LocalPersonConfigPath + @"\UserConfig.xml";
            if (File.Exists(XmlPath))
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(XmlPath);
                XmlElement element1 = (XmlElement)Doc.SelectSingleNode("UserConfig/ConnectLogic");

                //element1.SetAttribute("IsOfflineLogin", this.ChkIsOfflineLogin.Checked ? "True" : "False");
                //element1.SetAttribute("DotSetting", this.cbeDot.SelectedItem.ToString());

                //element1.SetAttribute("IfSendImmediately", this.ChkIfSendImmediately.Checked ? "True" : "False");
                //element1.SetAttribute("IfDefineBigPacking", this.ChkIfDefineBigPacking.Checked ? "True" : "False");
                //element1.SetAttribute("IfUseSecondCate", this.ChkIfUseSecondCate.Checked ? "True" : "False");
                //element1.SetAttribute("IfSetAutoReceive", this.ChkIfSetAutoReceive.Checked ? "True" : "False");
                //element1.SetAttribute("IfSetProEasy", this.ChkSetProEasy.Checked ? "True" : "False");
                //element1.SetAttribute("IfCompelSync", this.ChkIfCompelSync.Checked ? "True" : "False");
                


                //string Bother = this.ChkIsOfflineOther.Checked ? "True" : "False";

                //element1.SetAttribute("IsOfflineAddIntoReturnOrder", Bother);

                element1 = (XmlElement)Doc.SelectSingleNode("UserConfig/LoginLog");
                element1.SetAttribute("LoginedUsersCode", ClientConfiguration.UserCode);
                element1.SetAttribute("LastLoginedUserCode", ClientConfiguration.LastUserCode);
                Doc.Save(XmlPath);
            }

            ClientConfiguration.Reload();
        }

        private void SystemConfigMgr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }



    }
}