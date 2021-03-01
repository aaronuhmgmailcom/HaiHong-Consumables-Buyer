using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Common;

namespace Emedchina.TradeAssistant.Client
{
    public partial class CustomConfig : Form
    {
        public CustomConfig()
        {
            InitializeComponent();
//            checkBox2.Checked = "1".Equals(ClientConfiguration.SyncPolicy);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            try
            {
                if (this.chbState.Checked)
                {
                    ClientConfiguration.ResumeFlg = "1";
//                    ClientConfiguration.SyncPolicy = "1";
                }
                else
                {
                    ClientConfiguration.ResumeFlg = "0";
//                    ClientConfiguration.SyncPolicy = "0";
                }

                //����������("������"��ҵ�Խӹ���)��shangfu 2007-8-31
                //���Ϊ1���ǽ�����Խӽӿ�    
                if (this.ckbHisState.Checked)
                {
                    UserConfigXml.SetConfigInfo("ClientPlat", "type","1");
                }
                else
                {
                    UserConfigXml.SetConfigInfo("ClientPlat", "type", "0");
                }

                ClientConfiguration.Save();
                MessageBox.Show("����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ʧ�ܣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CustomConfig_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ClientConfiguration.ResumeFlg) && ClientConfiguration.ResumeFlg.Equals("1"))
            {
                this.chbState.Checked = true;
            }
            else
            {
                this.chbState.Checked = false;
            }

            //����������("������"��ҵ�Խӹ���)��shangfu 2007-8-31
            //���Ϊ1���ǽ�����Խӽӿ�    
            string clientPlat = UserConfigXml.GetConfigInfo("ClientPlat", "type");
            if ("1".Equals(clientPlat))
            {
                this.ckbHisState.Checked = true;
            }
            else
            {
                this.ckbHisState.Checked = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}