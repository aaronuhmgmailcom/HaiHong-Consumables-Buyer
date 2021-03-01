using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Emedchina.TradeAssistant.Client.Common;

namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class FormPackage : DevExpress.XtraEditors.XtraForm
    {
        //订购数量
        public string strPackageAmount;

        public FormPackage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAffirm_Click(object sender, EventArgs e)
        {
            strPackageAmount = this.txtPackage.Text;
            if (string.IsNullOrEmpty(strPackageAmount))
            {
                XtraMessageBox.Show("订购数量不能为空，请重新输入！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPackage.Focus();
                return;
            }
            if (Convert.ToInt32(strPackageAmount) < 1)
            {
                XtraMessageBox.Show("订购数量输入错误，请重新输入！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPackage.Focus();
                return;
            }
            this.Close();
        }

        /// <summary>
        /// 页面初始货事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPackage_Load(object sender, EventArgs e)
        {
            this.txtPackage.Text = "1";
            this.txtPackage.Focus();
        }

        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.BtnAffirm.Focus();
            }
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            strPackageAmount = "";
            this.Close();
        }
    }
}