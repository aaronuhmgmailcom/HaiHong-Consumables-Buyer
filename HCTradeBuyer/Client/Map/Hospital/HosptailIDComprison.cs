//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	HosptailIDComprison.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-5-21
//	功能描述:	
//	修 改 人: 
//	修改日期:
//	主要修改内容:
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
        /// 页面加载时绑定数据显示控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterpriseIDComprison_Load(object sender, EventArgs e)
        {
            bindingDsEnterPriseMapList();
            this.cbbpipei.Text = "全部";
            this.cbbstate.Text = "全部";
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
        ///// 对照查询按钮实现
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void btnSeeCompare_Click(object sender, EventArgs e)
        {
            HosptailIDCompareQuery enterpriseIDcomparequery = new HosptailIDCompareQuery();
            enterpriseIDcomparequery.ShowDialog();
        }
        ///// <summary>
        ///// 设置ItemFilter过滤列表
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
                case "未匹配":
                    filter.Append(" and (IsMap = '未匹配' or IsMap is null)"); break;
                case "已匹配":
                    filter.Append(" and IsMap = '已匹配'"); break;
            }
            switch (state)
            {
                case "已处理":
                    filter.Append(" and PROCESS_FLAG = '已处理'"); break;
                case "未处理":
                    filter.Append(" and PROCESS_FLAG='未处理'"); break;
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
        ///// 分页操作
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
        ///// 获取交易中心企业列表
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
                if (MessageBox.Show("确认删除HIS记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        string mapId = this.dgvEPIDCompare.CurrentCell == null ? "" : this.dgvEPIDCompare.CurrentRow.Cells["ID"].Value.ToString();
                        HosptailIDCompareBLL.GetInstance("ClientDB").DeleteHisErpCorpMap(mapId);
                    }
                    catch (Exception ex)
                    {
                        EmedMessageBox.ShowError("保存时发送错误：" + ex.Message.ToString());
                    }
                    finally
                    {
                        isdeleted = true;
                        this.bindingDsEnterPriseMapList();
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
   

        private void btn_cancelmatch_Click(object sender, EventArgs e)
        {
            if (this.dgvEPIDCompare.CurrentRow != null)
            {
                if (MessageBox.Show("确认取消匹配关系？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                    EmedMessageBox.ShowInformation("匹配关系已取消！");
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
        /// 设定导出文件
        /// </summary>
        /// <returns></returns>
        private string SelectExportFile()
        {
            string tmpPath = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls|dbf文件(*.dbf)|*.dbf|文本文件(*.txt)|*.txt|所有文件 (*.*)|*.*";
                this.saveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                this.saveFileDialog1.RestoreDirectory = true;
                this.saveFileDialog1.FileName = "";
                
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.saveFileDialog1.FileName == "")
                    {
                        MessageBox.Show("请设置到货导出文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "";
                    }
                    return this.saveFileDialog1.FileName;
                }
            }
            catch (Exception e)
            {
                EmedErrorLog.SaveLog("选择导出到货文件", e);
                tmpPath = "";
            }
            return tmpPath;

        }


        private void butimp_Click(object sender, EventArgs e)
        {
            string expFilePath = "";
            if (this.dgvEPIDCompare.Rows.Count == 0)
            {
                MessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            expFilePath = this.SelectExportFile();
            if (String.IsNullOrEmpty(expFilePath))
            {
                return;
            }

            string[] strarr = { "买方id", "买方名称", "买方简称", "拼音简称", "买方五笔", "处理标记", "ID", "对接机构海虹ID", "机构类型", "海虹买方ID", "海虹买方数据ID", "买方编码", "买方全称", "买方简称", "修改人id", "修改日期", "是否同步", "地址", "联系人", "联系电话", "邮政编码", "是否匹配", "匹配标志", "处理标志" };

            if (FileOperation.ExportExcelFile(HosptailIDCompareDT, expFilePath, strarr))
            {
                MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btuExp_Click(object sender, EventArgs e)
        {
            HospImpHisPlan EntImpForm = new HospImpHisPlan();
            EntImpForm.ShowDialog();
        }
    }
}