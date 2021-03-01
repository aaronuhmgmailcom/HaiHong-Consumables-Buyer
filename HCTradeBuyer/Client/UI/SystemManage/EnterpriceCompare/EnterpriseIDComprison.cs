//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	EnterpriseIDComprison.cs    
//	�� �� ��:	yanbing
//	��������:	2007-9-28
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
using Emedchina.TradeAssistant.Client.BLL.His.EnterPrice;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.His;
using DevExpress.XtraEditors;



namespace Emedchina.TradeAssistant.Client.His.Enterprise
{
    public partial class EnterpriseIDComprison : BaseForm
    {
        private DataTable EnterpriseIDCompareDT;
        
        private DataSet dsEmedCorpList0;
        bool isdeleted;
        public EnterpriseIDComprison()
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
            EnterpriseIDCompareDT = EnterpriseIDCompareBLL.GetInstance().GetEPComparionTable();

            base.InitFromCacheByData(EnterpriseIDCompareDT);
            try
            {
                this.EPIDComparebindingSource.DataSource = null;
                this.EPIDComparebindingSource.DataSource = this.cachedDataView;
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
            EnterpriseIDCompareQuery enterpriseIDcomparequery = new EnterpriseIDCompareQuery();
            enterpriseIDcomparequery.ShowDialog();
        }
        ///// <summary>
        ///// ����ItemFilter�����б�
        ///// </summary>
        private void ItemFilter()
        {
            string bakEPname = this.tbxbakEpname.Text;
            string hisEpname = this.tbxhisEPname.Text;
            string pipeitext = this.cbbpipei.Text;
            string state = this.cbbstate.Text;


            string strCode = this.tbxCode.Text.Trim();

            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(bakEPname))
                filter.AppendFormat(" and (name like '%{0}%' or abbr like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%')", bakEPname);
            if (!string.IsNullOrEmpty(hisEpname))
                filter.AppendFormat("and (FULL_NAME like '%{0}%' or EASY_NAME like '%{0}%')", hisEpname);

            if (!string.IsNullOrEmpty(strCode))
                filter.AppendFormat(" and HIS_ORG_ID like '%{0}%' ", strCode);

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
                FormHisCorpCreate frm1 = new FormHisCorpCreate(dsEmedCorpList0);
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
            this.dsEmedCorpList0 = EnterpriseIDCompareBLL.GetInstance().GetEmedCorpListDs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                GetEmedCorpList();
                FormHisCorpCreate frm1 = new FormHisCorpCreate(dsEmedCorpList0);
                frm1.flag = "MODIFY";
                frm1.code = dr["HIS_ORG_ID"].ToString();
                frm1.fullname = dr["FULL_NAME"].ToString();
                frm1.easyname = dr["EASY_NAME"].ToString();
                frm1.orgid = dr["org_id"].ToString();
                frm1.process = dr["PROCESS_FLAG"].ToString();
                frm1.ShowDialog();
                bindingDsEnterPriseMapList();
                ItemFilter();
                //ԭѡ��foreach
                //foreach (DataGridViewRow row in this.dgvEPIDCompare.Rows)
                //{
                //    if (row.Cells["CODE"].Value.ToString() == frm1.code)
                //    {
                //        this.dgvEPIDCompare.CurrentCell = this.dgvEPIDCompare["CODE", row.Index];
                //    }
                //}
                //�޸�Ϊ����
                for (int i = 0; i < this.gridView3.RowCount; i++)
                {
                    DataRow drow = gridView3.GetDataRow(i);
                    if (drow["HIS_ORG_ID"].ToString() == dr["HIS_ORG_ID"].ToString())
                    {
                        this.gridView3.FocusedRowHandle = i;
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
           DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
           if (dr != null)
           {
                if (XtraMessageBox.Show("ȷ��ɾ��HIS��¼��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string mapId =dr["ID"].ToString();
                        EnterpriseIDCompareBLL.GetInstance().DeleteHisErpCorpMap(mapId);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("����ʱ���ʹ���" + ex.Message.ToString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        isdeleted = true;
                        this.bindingDsEnterPriseMapList();
                        XtraMessageBox.Show("ɾ���ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
   

        private void btn_cancelmatch_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (XtraMessageBox.Show("ȷ��ȡ��ƥ���ϵ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LogedInUser curUser = ClientSession.GetInstance().CurrentUser;
                    Gpo_EnterPrice_MapModel enterprise = new Gpo_EnterPrice_MapModel();
                    enterprise.MapOrgId = curUser.UserOrg.Id;
                    enterprise.CorpId = "0";
                    enterprise.CorpName = dr["FULL_NAME"].ToString();
                    enterprise.CorpAbbr = dr["EASY_NAME"].ToString();
                    enterprise.ModifyUserId = base.CurrentUserId;
                    enterprise.Process = "1";
                    enterprise.IsMap = "0";
                    enterprise.CorpCode = dr["HIS_ORG_ID"].ToString();
                    EnterpriseIDCompareBLL.GetInstance().cancelMatch(enterprise);
                    this.bindingDsEnterPriseMapList();
                    ItemFilter();
                    for (int i = 0; i < this.gridView3.RowCount;i++ )
                    {
                        DataRow drow = gridView3.GetDataRow(i);
                        if (drow["HIS_ORG_ID"].ToString() == enterprise.CorpCode)
                        {
                            this.gridView3.FocusedRowHandle = i;
                        }
                    }
                    XtraMessageBox.Show("ƥ���ϵ��ȡ����");
                }
            }
        }

        private void dgvEPIDCompare_CurrentCellChanged(object sender, EventArgs e)
        {
            if (isdeleted == false)
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                if (dr != null)
                {
                    string orgid = dr["org_id"].ToString();
                    if (string.IsNullOrEmpty(orgid) || orgid=="0")
                    {
                        this.btn_cancelmatch.Enabled = false;
                    }
                    else
                    {
                        this.btn_cancelmatch.Enabled = true;
                    }
                }
            }
            else
            {
                isdeleted = false;
            }
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
                        XtraMessageBox.Show("�����õ��������ļ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            //string expFilePath = "";
            //if (this.dgvEPIDCompare.Rows.Count == 0)
            //{
            //    MessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //expFilePath = this.SelectExportFile();
            //if (String.IsNullOrEmpty(expFilePath))
            //{
            //    return;
            //}

            //string[] strarr = { "PROCESS_FLAG", "ID", "Map_orgid", "Map_orgtype", "������ҵID", "������ҵ����ID", "��ҵ����", "��ҵȫ��", "��ҵ���", "modify_userid", "modify_date", "sync_state", "��ַ", "��ϵ��", "��ϵ�绰", "��������", "ismap", "isMapFlag", "pfFlag", "name", "abbr", "spell_abbr", "name_wb" };

            //if (FileOperation.ExportExcelFile(EnterpriseIDCompareDT, expFilePath, strarr))
            //{
            //    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void btuExp_Click(object sender, EventArgs e)
        {
            EntImpHisPlan EntImpForm = new EntImpHisPlan();
            EntImpForm.ShowDialog();
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (isdeleted == false)
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                if (dr != null)
                {
                    string orgid = dr["org_id"].ToString();
                    if (string.IsNullOrEmpty(orgid) || orgid == "0")
                    {
                        this.btn_cancelmatch.Enabled = false;
                    }
                    else
                    {
                        this.btn_cancelmatch.Enabled = true;
                    }
                }
            }
            else
            {
                isdeleted = false;
            }
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    �� " + gridView3.RowCount + " ������";
        }
    }
}