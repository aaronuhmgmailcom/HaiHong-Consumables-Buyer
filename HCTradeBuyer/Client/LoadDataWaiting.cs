using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons.Data;

using System.Threading;
using System.Collections;
using Emedchina.TradeAssistant.Client.Base;

namespace Emedchina.TradeAssistant.Client
{
    public partial class LoadDataWaiting : BaseForm
    {
        public LoadDataWaiting(string MessageText)
        {
            InitializeComponent();
            messageText=MessageText;
        }

        private string messageText;


        private void LoadDataWaiting_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(messageText))
            {
                labelControlInfo.Text = messageText + labelControlInfo;
            }

        }



    }
}