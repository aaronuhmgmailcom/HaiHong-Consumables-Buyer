using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using System.IO;
using System.Xml;
using System.ServiceProcess;
using Emedchina.TradeAssistant.Client.Base;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder;
using Emedchina.TradeAssistant.Model.User;
namespace Emedchina.TradeAssistant.Client.UI.PublicModule
{
    public partial class EndForm : BaseForm
    {
        Form login;
        Form mainForm;

        public EndForm()
        {
            InitializeComponent();
        }

        public EndForm(Form loginForm, Form self)
        {
            InitializeComponent();
            login = loginForm;
            mainForm = self;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbAction.SelectedItem.ToString().Equals("退出"))
            {

                //作自动到货处理
                string autoRdays = string.Empty;
                string ifchecked = string.Empty;
                string XmlPath = ClientConfiguration.LocalPersonConfigPath;
                if (File.Exists(XmlPath))
                {
                    XmlDocument document1 = new XmlDocument();
                    document1.Load(XmlPath);
                    XmlElement element1 = (XmlElement)document1.SelectSingleNode("UserConfig/ConnectLogic");
                    ifchecked = element1.GetAttribute("IfSetAutoReceive").ToLower();
                    if (ifchecked == "true")
                        autoRdays = element1.GetAttribute("AutoReceiveDays").ToString();
                    else
                        autoRdays = "0";

                }
                else
                {
                    autoRdays = "0";
                }
                if (ifchecked == "true")
                    BuyerOrderOfflineDAO.GetInstance().DoAutoReceiveItem(ClientSession.GetInstance().CurrentUser, autoRdays);


                SyncForm frm = new SyncForm();
                frm.ShowDialog();

                login.Close();
                login.Dispose();

              
            }
            else
            {
                login.Refresh();
                login.Show();

                this.Dispose();
                mainForm.Dispose();
            }
            ClientSession.GetInstance().Reset();
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            //this.Text = System.Windows.Forms.Application.ProductName;
            this.cmbAction.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Activate();
        }
    }
}