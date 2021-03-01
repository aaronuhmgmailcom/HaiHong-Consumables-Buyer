//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	HosptailIDComprison.cs    
//	�� �� ��:	yanbing
//	��������:	2007-5-21
//	��������:	
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.Map.Hospital;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Map;




namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    public partial class HosptailIDComprison : MainFormBase
    {
        private DataTable HosptailIDCompareDT;
        
        private DataSet dsEmedCorpList0;
        bool isdeleted;
        public HosptailIDComprison()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ҳ�����ʱ��������ʾ�ؼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterpriseIDComprison_Load(object sender, EventArgs e)
        {
            bindingDsEnterPriseMapList();
            this.cbbpipei.Text = "ȫ��";
            this.cbbstate.Text = "ȫ��";
        }

        private void bindingDsEnterPriseMapList()
        {
            HosptailIDCompareDT = HosptailIDCompareBLL.GetInstance().GetHTComparionTable();
            base.InitFromCacheByData(HosptailIDCompareDT);
            this.pageNavigator1.ItemCount = base.cachedDataView.Count;
            try
            {
                this.EPIDComparebindingSource.DataSource = null;
                this.EPIDComparebindingSource.DataSource = base.gridDataView;
            }
            catch (Exception)
            {
                throw;
            }
            
            ItemFilter();
        }
        ///// <summary>
        ///// ���ղ�ѯ��ťʵ��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void btnSeeCompare_Click(object sender, EventArgs e)
        {
            HosptailIDCompareQuery enterpriseIDcomparequery = new HosptailIDCompareQuery();
            enterpriseIDcomparequery.ShowDialog();
        }
        ///// <summary>
        ///// ����ItemFilter�����б�
        ///// </summary>
        private void ItemFilter()
        {
            string bakEPname = StringUtils.repalceSepStr(this.tbxbakEpname.Text);
            string hisEpname = StringUtils.repalceSepStr(this.tbxhisEPname.Text);
            string pipeitext = this.cbbpipei.Text;
            string state = this.cbbstate.Text;
            string strCode = StringUtils.repalceSepStr(this.tbxCode.Text.Trim());

            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(bakEPname))
                filter.AppendFormat(" and (name like '%{0}%' or abbr like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%')", bakEPname);
            if (!string.IsNullOrEmpty(hisEpname))
                filter.AppendFormat("and (FULL_NAME like '%{0}%' or EASY_NAME like '%{0}%')", hisEpname);

            if (!string.IsNullOrEmpty(strCode))
                filter.AppendFormat(" and CODE like '%{0}%' ", strCode);

            switch (pipeitext)
            {
                case "δƥ��":
                    filter.Append(" and (IsMap = 'δƥ��' or IsMap is null)"); break;
                case "��ƥ��":
                    filter.Append(" and IsMap = '��ƥ��'"); break;
            }
            switch (state)
            {
                case "�Ѵ���":
                    filter.Append(" and PROCESS_FLAG = '�Ѵ���'"); break;
                case "δ����":
                    filter.Append(" and PROCESS_FLAG='δ����'"); break;
            }
            this.cachedDataView.RowFilter = filter.ToString();
            this.InitGridTableView(this.pageNavigator1.CurrentPageIndex, pageNavigator1.PageSize);
            this.pageNavigator1.ItemCount = base.cachedDataView.Count;
            if (gridDataView.Count > 0)
            {
                DataRow dr = gridDataView.ToTable().Rows[0];
            }
        }

        private void cbbpipei_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void cbbstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void tbxbakEpname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                ItemFilter();
        }

        private void tbxhisEPname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ItemFilter();
        }
        ///// <summary>
        ///// ��ҳ����
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="e"></param>
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            this.InitGridTableView(pageNavigator1.CurrentPageIndex, pageNavigator1.PageSize);
            this.pageNavigator1.ItemCount = base.cachedDataView.Count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.bindingDsEnterPriseMapList();
        }

        private void tbxbakEpname_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void tbxhisEPname_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                GetEmedCorpList();
                hospHisCorpCreate frm1 = new hospHisCorpCreate(dsEmedCorpList0);
                frm1.flag = "ADD";
                frm1.ShowDialog();
                bindingDsEnterPriseMapList();
                ItemFilter();

        }
        ///// <summary>
        ///// ��ȡ����������ҵ�б�
        ///// </summary>
        private void GetEmedCorpList()
        {
            this.dsEmedCorpList0 = HosptailIDCompareBLL.GetInstance("ClientDB").GetEmedCorpListDs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvEPIDCompare.CurrentRow != null)
            {
                GetEmedCorpList();
                hospHisCorpCreate frm1 = new hospHisCorpCreate(dsEmedCorpList0);
                frm1.flag = "MODIFY";
                frm1.code = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["CODE"].Value.ToString();
                frm1.fullname = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["FULL_NAME"].Value.ToString();
                frm1.easyname = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["EASY_NAME"].Value.ToString();
                frm1.orgid = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["org_id"].Value.ToString();
                frm1.process = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["PROCESS_FLAG"].Value.ToString();
                frm1.ShowDialog();
                bindingDsEnterPriseMapList();
                ItemFilter();
                foreach (DataGridViewRow row in this.dgvEPIDCompare.Rows)
                {
                    if (row.Cells["CODE"].Value.ToString() == frm1.code)
                    {
                        this.dgvEPIDCompare.CurrentCell = this.dgvEPIDCompare["CODE", row.Index];
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgvEPIDCompare.CurrentRow != null)
            {
                if (MessageBox.Show("ȷ��ɾ��HIS��¼��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        string mapId = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["ID"].Value.ToString();
                        HosptailIDCompareBLL.GetInstance("ClientDB").DeleteHisErpCorpMap(mapId);
                    }
                    catch (Exception ex)
                    {
                        EmedMessageBox.ShowError("����ʱ���ʹ���" + ex.Message.ToString());
                    }
                    finally
                    {
                        isdeleted = true;
                        this.bindingDsEnterPriseMapList();
                        MessageBox.Show("ɾ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
   

        private void btn_cancelmatch_Click(object sender, EventArgs e)
        {
            if (this.dgvEPIDCompare.CurrentRow != null)
            {
                if (MessageBox.Show("ȷ��ȡ��ƥ���ϵ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    LogedInUser curUser = ClientSession.GetInstance().CurrentUser;
                    Gpo_Hosptail_MapModel enterprise = new Gpo_Hosptail_MapModel();
                    enterprise.MapOrgId = base.CurrentUserRegOrgId;
                    enterprise.CorpId = "";
                    enterprise.CorpName = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["FULL_NAME"].Value.ToString();
                    enterprise.CorpAbbr = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["EASY_NAME"].Value.ToString();
                    enterprise.ModifyUserId = base.CurrentUserId;
                    enterprise.Process = "1";
                    enterprise.IsMap = "0";
                    enterprise.CorpCode = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["CODE"].Value.ToString();
                    HosptailIDCompareBLL.GetInstance("ClientDB").cancelmatch(enterprise);
                    this.bindingDsEnterPriseMapList();
                    ItemFilter();
                    foreach (DataGridViewRow row in this.dgvEPIDCompare.Rows)
                    {
                        if (row.Cells["CODE"].Value.ToString() == enterprise.CorpCode)
                        {
                            this.dgvEPIDCompare.CurrentCell = this.dgvEPIDCompare["CODE", row.Index];
                        }
                    }
                    EmedMessageBox.ShowInformation("ƥ���ϵ��ȡ����");
                }
            }
        }

        private void dgvEPIDCompare_CurrentCellChanged(object sender, EventArgs e)
        {
            if (isdeleted == false)
            {
                string orgid = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["org_id"].Value.ToString();
                if (string.IsNullOrEmpty(orgid))
                {
                    this.btn_cancelmatch.Enabled = false;
                }
                else
                {
                    this.btn_cancelmatch.Enabled = true;
                }
            }
            else
            {
                isdeleted = false;
            }
        }

        private void cbbpipei_Click(object sender, EventArgs e)
        {
            this.cbbpipei.DroppedDown = true;
        }

        private void cbbstate_Click(object sender, EventArgs e)
        {
            this.cbbstate.DroppedDown = true;
        }

        private void tbxCode_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }


        /// <summary>
        /// �趨�����ļ�
        /// </summary>
        /// <returns></returns>
        private string SelectExportFile()
        {
            string tmpPath = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel�ļ�(*.xls)|*.xls|dbf�ļ�(*.dbf)|*.dbf|�ı��ļ�(*.txt)|*.txt|�����ļ� (*.*)|*.*";
                this.saveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                this.saveFileDialog1.RestoreDirectory = true;
                this.saveFileDialog1.FileName = "";
                
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.saveFileDialog1.FileName == "")
                    {
                        MessageBox.Show("�����õ��������ļ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "";
                    }
                    return this.saveFileDialog1.FileName;
                }
            }
            catch (Exception e)
            {
                EmedErrorLog.SaveLog("ѡ�񵼳������ļ�", e);
                tmpPath = "";
            }
            return tmpPath;

        }


        private void butimp_Click(object sender, EventArgs e)
        {
            string expFilePath = "";
            if (this.dgvEPIDCompare.Rows.Count == 0)
            {
                MessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            expFilePath = this.SelectExportFile();
            if (String.IsNullOrEmpty(expFilePath))
            {
                return;
            }

            string[] strarr = { "��id", "������", "�򷽼��", "ƴ�����", "�����", "������", "ID", "�Խӻ�������ID", "��������", "������ID", "����������ID", "�򷽱���", "��ȫ��", "�򷽼��", "�޸���id", "�޸�����", "�Ƿ�ͬ��", "��ַ", "��ϵ��", "��ϵ�绰", "��������", "�Ƿ�ƥ��", "ƥ���־", "�����־" };

            if (FileOperation.ExportExcelFile(HosptailIDCompareDT, expFilePath, strarr))
            {
                MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btuExp_Click(object sender, EventArgs e)
        {
            HospImpHisPlan EntImpForm = new HospImpHisPlan();
            EntImpForm.ShowDialog();
        }
    }
}