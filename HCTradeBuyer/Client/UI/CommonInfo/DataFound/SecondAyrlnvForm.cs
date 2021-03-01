using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.DataFound
{
    /// <summary>
    /// 二级库存统计
    /// </summary>
    public partial class SecondAyrlnvForm : DevExpress.XtraEditors.XtraForm
    {
        public SecondAyrlnvForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}