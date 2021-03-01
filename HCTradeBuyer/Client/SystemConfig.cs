using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emedchina.TradeAssistant.Client
{
    public partial class SystemConfig : Form
    {
        public SystemConfig()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SystemConfig_Load(object sender, EventArgs e)
        {
            this.txtIp.Text = ClientConfiguration.RemoteMachine;
            this.txtPort.Text = ClientConfiguration.RemotePort;
            this.txtTradeWeb.Text = ClientConfiguration.WebUrl;
            this.txtUpdateWeb.Text = ClientConfiguration.UPDATEURL;
            //this.txtWeb.Text = Properties.Settings.Default.WebSite;
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
                MessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void setTxtReadOnly()
        {
            this.txtIp.ReadOnly = true;
            this.txtPort.ReadOnly = true;
        }
    }
}