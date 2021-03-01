//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	HosptailIDCompareQuery.cs    
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
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.Map.Hospital;
using Emedchina.TradeAssistant.Client.Common;


namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    public partial class HosptailIDCompareQuery : FormBase
    {
        DataTable querytable;
        DataTable histable;
        string orgID;
        public HosptailIDCompareQuery()
        {
            InitializeComponent();
            querytable = HosptailIDCompareBLL.GetInstance(Constant.ACESSDB_ALIAS).GetEPCompareQueryTable();
            base.InitFromCacheByData(querytable);
            this.pageNavigatorEPIDComItem.ItemCount = base.cachedDataView.Count;
            this.ItembindingSource.DataSource = base.gridDataView;
            this.cbbCompare.Text = "ȫ������";
        }



        /// <summary>
        /// ��ҽԺ������յ�HIS��Ӧ�б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEPItem_CurrentCellChanged(object sender, EventArgs e)
        {
            orgID = this.dgvEPItem.CurrentCell == null ? "" : this.dgvEPItem.CurrentRow.Cells["buyer_orgid"].Value.ToString();
            histable = HosptailIDCompareBLL.GetInstance().GetHTComparionTable();
            string filter = "1=1 and ORG_ID='" + orgID + "'";
            histable.DefaultView.RowFilter = filter;
            if (histable.DefaultView.Count > 0)
                this.hisbindingSource.DataSource = histable;
            this.lblHiscount.Text = histable.DefaultView.Count.ToString() + "����¼"; 
        }


        /// <summary>
        /// ��ҳ����
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void pageNavigatorProIDComItem_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            this.InitGridTableView(pageNavigatorEPIDComItem.CurrentPageIndex, pageNavigatorEPIDComItem.PageSize);
            this.pageNavigatorEPIDComItem.ItemCount = base.cachedDataView.Count;
        }
        /// <summary>
        /// ����ItemFilter������ҵ��������б�
        /// </summary>
        private void ItemFilter()
        {
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            string EPname = StringUtils.repalceSepStr(this.tbxEPname.Text);
            string compare = this.cbbCompare.Text;
            if (!string.IsNullOrEmpty(EPname))
                filter.AppendFormat(" and (name like '%{0}%' or abbr like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%')", EPname);
            //�����չ�ϵ����
            switch (compare)
            {
                case "һ��һ":
                    filter.Append(" and MapSum = 1"); break;
                case "һ�Զ�":
                    filter.Append(" and MapSum > 1"); break;
            }
            this.cachedDataView.RowFilter = filter.ToString();
            this.InitGridTableView(1, pageNavigatorEPIDComItem.PageSize);
            this.pageNavigatorEPIDComItem.ItemCount = base.cachedDataView.Count;
            if (gridDataView.Count > 0)
            {
                DataRow dr = gridDataView.ToTable().Rows[0];
            }
        }

        private void cbbCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }
        //��ѯ��ťʵ��
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ItemFilter();
        }
        
        private void tbxEPname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ItemFilter();
        }
        /// <summary>
        /// �رհ�ťʵ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxEPname_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void cbbCompare_Click(object sender, EventArgs e)
        {
            this.cbbCompare.DroppedDown = true;
        }
    }
}