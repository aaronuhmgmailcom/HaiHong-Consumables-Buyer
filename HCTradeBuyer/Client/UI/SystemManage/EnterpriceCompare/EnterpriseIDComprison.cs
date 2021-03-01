//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	EnterpriseIDComprison.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-28
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
        ///// 对照查询按钮实现
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void btnSeeCompare_Click(object sender, EventArgs e)
        {
            EnterpriseIDCompareQuery enterpriseIDcomparequery = new EnterpriseIDCompareQuery();
            enterpriseIDcomparequery.ShowDialog();
        }
        ///// <summary>
        ///// 设置ItemFilter过滤列表
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
        ///// 获取交易中心企业列表
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
                //原选定foreach
                //foreach (DataGridViewRow row in this.dgvEPIDCompare.Rows)
                //{
                //    if (row.Cells["CODE"].Value.ToString() == frm1.code)
                //    {
                //        this.dgvEPIDCompare.CurrentCell = this.dgvEPIDCompare["CODE", row.Index];
                //    }
                //}
                //修改为如下
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
                if (XtraMessageBox.Show("确认删除HIS记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string mapId =dr["ID"].ToString();
                        EnterpriseIDCompareBLL.GetInstance().DeleteHisErpCorpMap(mapId);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("保存时发送错误：" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        isdeleted = true;
                        this.bindingDsEnterPriseMapList();
                        XtraMessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
   

        private void btn_cancelmatch_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (XtraMessageBox.Show("确认取消匹配关系？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    XtraMessageBox.Show("匹配关系已取消！");
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
                        XtraMessageBox.Show("请设置到货导出文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            //string expFilePath = "";
            //if (this.dgvEPIDCompare.Rows.Count == 0)
            //{
            //    MessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //expFilePath = this.SelectExportFile();
            //if (String.IsNullOrEmpty(expFilePath))
            //{
            //    return;
            //}

            //string[] strarr = { "PROCESS_FLAG", "ID", "Map_orgid", "Map_orgtype", "海虹企业ID", "海虹企业数据ID", "企业编码", "企业全称", "企业简称", "modify_userid", "modify_date", "sync_state", "地址", "联系人", "联系电话", "邮政编码", "ismap", "isMapFlag", "pfFlag", "name", "abbr", "spell_abbr", "name_wb" };

            //if (FileOperation.ExportExcelFile(EnterpriseIDCompareDT, expFilePath, strarr))
            //{
            //    MessageBox.Show("导出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }
    }
}