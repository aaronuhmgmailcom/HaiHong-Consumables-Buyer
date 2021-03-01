using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;

namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class HisPlanErrorList : Emedchina.TradeAssistant.Client.Base.BaseForm
    {
        private IList<ImputPurchaseModel> m_result;
        public bool flag = true;//�����ɹ����
        DataTable dt = new DataTable();
        public HisPlanErrorList()
        {
            InitializeComponent();
        }
        public HisPlanErrorList(IList<ImputPurchaseModel> result)
        {
            InitializeComponent();
            m_result = result;
            if (m_result != null)
            {
                setRequestSend();
            }
            //
            //this.dgvReason.DataSource = dt;
            //dtMain = dt;
            ////dgvReason.DataSource = dt;
            //frmMain = frm;
        }

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHisReason_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void setRequestSend()
        {
            dt.Columns.Add("RequestQty");
            dt.Columns.Add("SenderName");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ModeName");
            dt.Columns.Add("Spec");
            dt.Columns.Add("MedicalSpec");
            dt.Columns.Add("SpecUnit");
            dt.Columns.Add("state");
            dt.Columns.Add("ProductCode");
            dt.Columns.Add("SenderCode");
            dt.Columns.Add("InstruName");
            dt.Columns.Add("FactoryName");
            dt.Columns.Add("BRAND");

            foreach (ImputPurchaseModel model in m_result)
            {
                DataRow dr = dt.NewRow();
                dr["RequestQty"] = model.Cgsl;
                dr["SenderName"] = model.Psqymc;
                dr["ProductName"] = model.Hcmc;
                dr["ModeName"] = model.Xhmc;
                dr["Spec"] = model.Ggmc;
                dr["SpecUnit"] = model.Bzdw;
                dr["state"] = model.State;
                dr["ProductCode"] = model.Hcbm;
                dr["SenderCode"] = model.Psqybm;
                dr["InstruName"] = model.Hcmc;
                dr["FactoryName"] = model.Scqymc;
                dr["BRAND"] = model.Brand;
                dt.Rows.Add(dr);

            }
            this.dgvErpSend.DataSource = dt;

        }
        //������ť
        private void btnExcel_Click(object sender, EventArgs e)
        {
            bool flg = false;
            //ѡ���������ļ�
            string strFileName = string.Empty;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "�����ļ�Ϊ";
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "�ƻ�����ʧ���б�";
            this.saveFileDialog1.Filter = "Excel�ĵ�(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strFileName = saveFileDialog1.FileName;
                flg = FileOperation.ExportExcelFile(dt, strFileName);

                if (!flg)
                {
                    MessageBox.Show("excel����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("excel�����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flag = false;
                }
            }

        }





    }
}

