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

        //"������"�ԽӵĻ�����Ϣ�������� 2007-8-28 shangfu

        /// <summary>
        /// �趨�������ı��ļ�
        /// </summary>
        /// <returns></returns>
        private string SelectExporFile(string txtFileName)
        {

            string strFile = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel�ļ�(*.xls)|*.xls|�ı��ļ�(*.txt)|*.txt|dbf�ļ�(*.dbf)|*.dbf|�����ļ� (*.*)|*.*";

                this.saveFileDialog1.FileName = txtFileName;
                this.saveFileDialog1.RestoreDirectory = true;


                //this.saveFileDialog1.FileName = "";
                //this.saveFileDialog1.RestoreDirectory = true;

                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    if (this.saveFileDialog1.FileName == "")
                    {
                        MessageBox.Show("�����õ��������ļ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                EmedErrorLog.SaveLog("ѡ�񵼳������ļ�", e);
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
                string expFilePath = SelectExporFile("������Ʒ��Ϣ");
                if (FileOperation.ExportExcelFile(dt, expFilePath))
                {
                    //thread.Abort();
                    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("û�����ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void butExpBuyer_Click(object sender, EventArgs e)
        {
            DataTable dt = ProxyFactory.SalerOrderProxy.GetBuyerInfo(base.CurrentUserRegOrgId);
            if (dt.Rows.Count > 0)
            {
                string expFilePath = SelectExporFile("����ҽԺ��Ϣ");
                if (FileOperation.ExportExcelFile(dt, expFilePath))
                {
                    //thread.Abort();
                    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("û�����ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btnExpEnt_Click(object sender, EventArgs e)
        {
            //DataTable dt = ProxyFactory.SalerOrderProxy.GetEnterpriseInfo(base.CurrentUserRegOrgId);
            DataTable dt = SalerOrderBLL.GetInstance().GetEnterpriseInfo(base.CurrentUserRegOrgId);
            if (dt.Rows.Count > 0)
            {
                string expFilePath = SelectExporFile("������ҵ��Ϣ");
                if (FileOperation.ExportExcelFile(dt, expFilePath))
                {
                    //thread.Abort();
                    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("û�����ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


    }
}