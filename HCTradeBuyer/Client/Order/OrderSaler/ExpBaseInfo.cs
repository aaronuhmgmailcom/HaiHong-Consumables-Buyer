using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.BLL.Order.SalerOrder;

namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    public partial class ExpBaseInfo : MainFormBase
    {
        public ExpBaseInfo()
        {
            InitializeComponent();
        }

        //"进销存"对接的基础信息导出功能 2007-8-28 shangfu

        /// <summary>
        /// 设定导出成文本文件
        /// </summary>
        /// <returns></returns>
        private string SelectExporFile(string txtFileName)
        {

            string strFile = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls|文本文件(*.txt)|*.txt|dbf文件(*.dbf)|*.dbf|所有文件 (*.*)|*.*";

                this.saveFileDialog1.FileName = txtFileName;
                this.saveFileDialog1.RestoreDirectory = true;


                //this.saveFileDialog1.FileName = "";
                //this.saveFileDialog1.RestoreDirectory = true;

                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    if (this.saveFileDialog1.FileName == "")
                    {
                        MessageBox.Show("请设置到货导出文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "";
                    }



                    return this.saveFileDialog1.FileName;


                    //return this.saveFileDialog1.FileName;
                }
                else
                {
                    this.saveFileDialog1.FileName = "";
                }
            }
            catch (Exception e)
            {
                EmedErrorLog.SaveLog("选择导出到货文件", e);
            }
            return this.saveFileDialog1.FileName;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExpProduct_Click(object sender, EventArgs e)
        {
            //DataTable dt = ProxyFactory.SalerOrderProxy.GetProductInfo(base.CurrentUserRegOrgId);
            DataTable dt = SalerOrderBLL.GetInstance().GetProductInfo(base.CurrentUserRegOrgId);
            if (dt.Rows.Count > 0)
            {
                string expFilePath = SelectExporFile("导出产品信息");
                if (FileOperation.ExportExcelFile(dt, expFilePath))
                {
                    //thread.Abort();
                    MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("没有数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void butExpBuyer_Click(object sender, EventArgs e)
        {
            DataTable dt = ProxyFactory.SalerOrderProxy.GetBuyerInfo(base.CurrentUserRegOrgId);
            if (dt.Rows.Count > 0)
            {
                string expFilePath = SelectExporFile("导出医院信息");
                if (FileOperation.ExportExcelFile(dt, expFilePath))
                {
                    //thread.Abort();
                    MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("没有数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btnExpEnt_Click(object sender, EventArgs e)
        {
            //DataTable dt = ProxyFactory.SalerOrderProxy.GetEnterpriseInfo(base.CurrentUserRegOrgId);
            DataTable dt = SalerOrderBLL.GetInstance().GetEnterpriseInfo(base.CurrentUserRegOrgId);
            if (dt.Rows.Count > 0)
            {
                string expFilePath = SelectExporFile("导出企业信息");
                if (FileOperation.ExportExcelFile(dt, expFilePath))
                {
                    //thread.Abort();
                    MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("没有数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


    }
}