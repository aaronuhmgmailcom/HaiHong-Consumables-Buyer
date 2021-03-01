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
        public bool flag = true;//导出成功标记
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

        #region 加入序号
        /// <summary>
        /// 加入序号
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
        /// 初始化窗体
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
        //导出按钮
        private void btnExcel_Click(object sender, EventArgs e)
        {
            bool flg = false;
            //选择待导入的文件
            string strFileName = string.Empty;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "保存文件为";
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "计划导入失败列表";
            this.saveFileDialog1.Filter = "Excel文档(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strFileName = saveFileDialog1.FileName;
                flg = FileOperation.ExportExcelFile(dt, strFileName);

                if (!flg)
                {
                    MessageBox.Show("excel导出失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flag = true;
                }
                else
                {
                    MessageBox.Show("excel导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flag = false;
                }
            }

        }





    }
}

