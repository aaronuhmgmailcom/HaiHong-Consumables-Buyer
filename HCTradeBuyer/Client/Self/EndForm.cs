using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Self;
using Emedchina.TradeAssistant.Sync.Order;


namespace Emedchina.TradeAssistant.Client.Base
{
    public partial class EndForm : FormBase
    {
        LoginForm login;
        FormSelf mainForm;

        public EndForm()
        {
            InitializeComponent();
        }

        public EndForm(LoginForm loginForm, FormSelf self)
        {
            InitializeComponent();
            login = loginForm;
            mainForm = self;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbAction.SelectedItem.ToString().Equals("ÍË³ö"))
            {
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
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            this.Text = System.Windows.Forms.Application.ProductName;
            this.cmbAction.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Activate();
        }
    }
}