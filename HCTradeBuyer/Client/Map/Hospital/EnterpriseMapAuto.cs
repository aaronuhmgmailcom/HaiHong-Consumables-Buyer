/***************************
创 建 人:	陈建钢

创建日期:	2007-8-23
功能描述:	产品自动匹配
 **************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using System.Collections;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.Commons;
using Emedchina.Commons.WinForms;
using Emedchina.TradeAssistant.Client.BLL.Map.Hospital;

namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    public partial class EnterpriseMapAuto : FormBase
    {
        private DataTable dtNotMap = new DataTable();   //未匹配买方表
        private Hashtable hashMap = new Hashtable();    //匹配买方表
        private Hashtable hashSave = new Hashtable();   //已保存买方表
        private bool bSave = false;                     //保存标志    
        public EnterpriseMapAuto()
        {
            InitializeComponent();
        }
        public EnterpriseMapAuto(DataTable dt)
        {
            InitializeComponent();
            dtNotMap = dt;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnquerry_Click(object sender, EventArgs e)
        {
            string sHospName = this.tb_sendName.Text.Trim();       
            string sIsMap = this.cmbMapStutas.Text.Trim();
            StringBuilder sFilter = new StringBuilder();
            sFilter.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(sHospName))
            {
                sFilter.AppendFormat(" and (buyer_name like '%{0}%' or buyer_easy like '%{0}%' )", sHospName);
            }           
            if (!string.IsNullOrEmpty(sIsMap) && sIsMap != "全部")
            {
                sFilter.AppendFormat(" and ismap = '{0}'", sIsMap);
            }
            dtNotMap.DefaultView.RowFilter = sFilter.ToString();
        }
        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMap_Click(object sender, EventArgs e)
        {
            if (dgvERPCroplist.CurrentRow != null && dgvEmedCorpList.CurrentRow != null && dgvERPCroplist.CurrentRow.Cells["IsMap"].Value.ToString() == "未匹配")
            {
                Gpo_Hosptail_MapModel model = new Gpo_Hosptail_MapModel();
                model.CorpId = dgvEmedCorpList.CurrentRow.Cells["buyer_orgid"].Value.ToString().Trim();
                model.MapOrgId = ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id;
                model.CorpCode = dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value.ToString().Trim();
                model.CorpName = dgvERPCroplist.CurrentRow.Cells["buyer_name"].Value.ToString().Trim();
                model.CorpAbbr = dgvERPCroplist.CurrentRow.Cells["buyer_easy"].Value.ToString().Trim();
                model.IsMap = "1";
                if (!hashMap.ContainsKey(model.CorpCode))
                {
                    hashMap.Add(model.CorpCode, model);
                    dtNotMap.Select("buyer_code ='" + dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value + "'")[0]["IsMap"] = "已匹配";
                    bSave = false;
                }
            }        
        }
        /// <summary>
        /// 取消匹配 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelMap_Click(object sender, EventArgs e)
        {     
            if (dgvERPCroplist.CurrentRow != null && dgvEmedCorpList.CurrentRow != null && dgvERPCroplist.CurrentRow.Cells["IsMap"].Value.ToString() == "已匹配")
            {
                if (hashMap.Contains(dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value))
                {
                    hashMap.Remove(dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value);
                }
                //如果已保存过
                if (hashSave.ContainsKey(dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value))
                {
                    HosptailIDCompareBLL.GetInstance().cancelmatch(hashSave[dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value].ToString());
                    hashSave.Remove(dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value);
                    dgvERPCroplist_RowEnter(sender, new DataGridViewCellEventArgs(0,0));
                }
                dtNotMap.Select("buyer_code ='" + dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value + "'")[0]["IsMap"] = "未匹配";
                bSave = false;
            }           
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {      
            if (!bSave)
            {
                ArrayList arrayExec = new ArrayList();
                foreach (Gpo_Hosptail_MapModel model in hashMap.Values)
                {
                    string sRecord_ID = string.Empty;
                    if(HosptailIDCompareBLL.GetInstance().JudgeHIScode(model.CorpCode,model.MapOrgId,ref sRecord_ID))
                    {
                        try
                        {
                            HosptailIDCompareBLL.GetInstance().UpdateCorpMap(sRecord_ID, model.CorpId);
                        }
                        catch(Exception me)
                        {
                            MessageBox.Show(me.Message);
                        }
                    }
                    else
                    {                     
                        arrayExec.Add(HosptailIDCompareBLL.GetInstance().InsertHisErpCorpMapSQL(model, out sRecord_ID));                    
                    }       
                    if(!hashSave.ContainsKey(model.CorpCode))
                        hashSave.Add(model.CorpCode, sRecord_ID);                    
                }
                try
                {
                    string[] sExecs = new string[arrayExec.Count];
                    arrayExec.CopyTo(sExecs);
                    if (HosptailIDCompareBLL.GetInstance().AddHisCorpMapBatch(sExecs))
                    {
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hashMap.Clear();
                        HideSaveData();
                        bSave = true;
                    }
                }
                catch
                {
                    MessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.labNoMap.Text = dgvERPCroplist.Rows.Count.ToString() + "条记录";
            }
        }
        /// <summary>
        /// 隐藏已保存数据
        /// </summary>
        private void HideSaveData()
        {
            StringBuilder sFilter = new StringBuilder();
            sFilter.Append("1=1");
            foreach (string buyer_code in hashSave.Keys)
            {
                foreach (DataGridViewRow drvr in dgvERPCroplist.Rows)
                {
                    if (drvr.Cells["buyer_code"].Value.ToString().Trim() == buyer_code.Trim())
                    {
                        sFilter.AppendFormat(" and buyer_code <> '{0}'", buyer_code.Trim());
                    }
                }
            }
            sFilter.Append(" and IsMap = '未匹配'");
            dtNotMap.DefaultView.RowFilter = sFilter.ToString();
            cmbMapStutas.Text = "未匹配";
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterpriseMapAuto_Load(object sender, EventArgs e)
        {     
            InitFromCacheByData(HosptailIDCompareBLL.GetInstance("ClientDB").GetEmedCorpListDs().Tables[0]);
            this.EmedbindingSource.DataSource = base.gridDataView;
            this.pageNavigator1.ItemCount = base.cachedDataView.Count;
            this.ERPbindingSource.DataSource =dtNotMap.DefaultView;
            this.cmbMapStutas.Text = "全部";
        }
    
        /// <summary>
        /// 买方名称变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCorpName_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        /// <summary>
        /// 翻页 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, PageChangedEventArgs e)
        {
            InitGridTableView(pageNavigator1.CurrentPageIndex, pageNavigator1.PageSize);
            EmedbindingSource.DataSource = base.gridDataView;
            pageNavigator1.ItemCount = base.cachedDataView.Count;
        }
        /// <summary>
        /// 设置过滤条件
        /// </summary>
        private void Filter()
        {
            string sCorpName = StringUtils.repalceSepStr(txtCorpName.Text.Trim());
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(sCorpName))
            {                
                sb.AppendFormat("and (name like '%{0}%' or abbr like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%' )", txtCorpName.Text.Trim());                
            }                 
            base.cachedDataView.RowFilter = sb.ToString();
            InitFromCacheByData(cachedDataView.Table);
            EmedbindingSource.DataSource = base.gridDataView;
            pageNavigator1.ItemCount = base.cachedDataView.Count;
            
        }
        /// <summary>
        /// 删除匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvERPCroplist.CurrentRow != null && hashSave.ContainsKey(dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value))
            {
                if (MessageBox.Show("确实要删除吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    HosptailIDCompareBLL.GetInstance().DeleteHisErpCorpMap(hashSave[dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value].ToString());
                    string sCode = dgvERPCroplist.CurrentRow.Cells["buyer_code"].Value.ToString();
                    dtNotMap.DefaultView.RowFilter = " buyer_code <> '" + sCode + "'";
                    dtNotMap.Select("buyer_code = '" + sCode + "'")[0]["IsMap"] = "未匹配";
                    bSave = false;
                    this.cmbMapStutas.Text = "未匹配";
                }
                
            }
        }
        /// <summary>
        /// 选中行改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvERPCroplist_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvERPCroplist.Rows[e.RowIndex] != null && hashSave.ContainsKey(dgvERPCroplist.Rows[e.RowIndex].Cells["buyer_code"].Value) && dgvERPCroplist.Rows[e.RowIndex].Cells["IsMap"].Value.ToString() == "已匹配")
            {
                btnDel.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
            }
        }
    }
}