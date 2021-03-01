using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Client.BLL.Map.Hospital;

namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    public partial class hospHisCorpCreate : FormBase
    {
        public string flag;
        public string fullname;
        public string easyname;
        public string code;
        public string orgid;
        public string process;

        DataSet dsEmedCorpList1;
        DataSet dsEmedCorpMapList1;
        private BindingSource emedCorpListBinding = new BindingSource();
        private BindingSource emedCorpMapListBinding = new BindingSource();
        private string FCorpMapOrgId = "";
        private int FCorpMapSum;
        public struct SearchInput
        {
            public string searchSendName;

            public string SearchSendName
            {
                get { return searchSendName; }
                set { searchSendName = value; }
            }
        }
        SearchInput searchInput = new SearchInput();

        Gpo_Hosptail_MapModel enterprise = new Gpo_Hosptail_MapModel();
        HosptailIDCompareBLL bll = HosptailIDCompareBLL.GetInstance("ClientDB");
        private bool IsSave = false;
        private bool IsChange = false;

        public hospHisCorpCreate()
        {
            InitializeComponent();
        }

        public hospHisCorpCreate(DataSet dsEmedCorpList)
        {
            InitializeComponent();
            this.dsEmedCorpList1 = dsEmedCorpList;
            this.bindingDsEmedCorpList();
            this.bindingDsEmedCorpMapList();
            this.tb_sendName.Select();
        }

        #region 交易中心企业列表数据绑定到控件 bindingDsEmedCorpList
        /// <summary>
        /// 交易中心企业列表数据绑定到控件
        /// </summary>
        private void bindingDsEmedCorpList()
        {
            this.dgv_EmedCorpList.AutoGenerateColumns = false;
            this.emedCorpListBinding.DataSource = this.dsEmedCorpList1.Tables[0].DefaultView;
            this.dgv_EmedCorpList.DataSource = emedCorpListBinding;
            this.sumDsEmedCorpListRecordCount();
        }
        #endregion

        #region 企业对应中心企业列表数据绑定控件 bindingDsEmedCorpMapList
        /// <summary>
        /// 企业对应中心企业列表数据绑定控件
        /// </summary>
        private void bindingDsEmedCorpMapList()
        {
            this.dgv_EmedCorpMapList.AutoGenerateColumns = false;
            this.dsEmedCorpMapList1 = bll.BuildCorpMapList();
            this.emedCorpMapListBinding.DataSource = this.dsEmedCorpMapList1.Tables[0].DefaultView;
            this.dgv_EmedCorpMapList.DataSource = emedCorpMapListBinding;
            this.sumDsEmedCorpMapListRecordCount();
        }
        #endregion

        #region 设置Filter交易中心企业列表 filterDsOftenPurchaseDir
        /// <summary>
        /// 设置Filter过滤交易中心企业列表
        /// </summary>
        private void filterDsEmedCorpList(SearchInput input)
        {
            StringBuilder sql = new StringBuilder("1=1 ", 64);

            //配送企业
            if (!string.IsNullOrEmpty(input.searchSendName))
            {
                sql.AppendFormat(" and (name like '*{0}*' or abbr like '*{0}*' or spell_abbr like '*{0}*' or name_wb like '*{0}*')", StringUtils.repalceSepStr(input.SearchSendName));

            }   
            if (this.dsEmedCorpList1 != null)
            {
                this.dsEmedCorpList1.Tables[0].DefaultView.RowFilter = sql.ToString();
                this.emedCorpListBinding.DataSource = this.dsEmedCorpList1.Tables[0].DefaultView;
                this.sumDsEmedCorpListRecordCount();
            }

        }
        #endregion

        #region 统计交易中心企业列表记录数 sumDsEmedCorpListRecordCount
        /// <summary>
        /// 统计交易中心企业列表记录数
        /// </summary>
        private void sumDsEmedCorpListRecordCount()
        {
            this.labelRecordcount1.Text = this.dgv_EmedCorpList.Rows.Count + "条记录";
        }
        #endregion

        #region 企业对应中心企业列表记录数 sumDsEmedCorpMapListRecordCount
        /// <summary>
        /// 企业对应中心企业列表
        /// </summary>
        private void sumDsEmedCorpMapListRecordCount()
        {
            if (this.dsEmedCorpMapList1.Tables.Count > 0)
            {
                if (this.dsEmedCorpMapList1.Tables[0].DefaultView.Count > 0)
                {
                    this.labelRecordcount0.Text = this.dsEmedCorpMapList1.Tables[0].DefaultView.Count + " 条";
                }
                else
                {
                    this.labelRecordcount0.Text = " 0 条";
                    this.FCorpMapOrgId = "";
                }
            }
            else
            {
                this.labelRecordcount0.Text = " 0 条";
                this.FCorpMapOrgId = "";
            }
        }
        #endregion

        #region 获取企业数据输入和校验 getCorpInput
        /// <summary>
        /// 获取企业数据输入和校验
        /// </summary>
        private bool getCorpInput()
        {          
            this.enterprise.CorpId = this.FCorpMapOrgId;
            Emedchina.TradeAssistant.Model.User.LogedInUser usr = ClientSession.GetInstance().CurrentUser;
            //转换异常字符
            CharConvert();
            this.enterprise.MapOrgId = usr.UserOrg.Reg_org_id.ToString();
            this.enterprise.CorpCode = tb_CorpCode.Text.Trim();
            this.enterprise.CorpName = tb_CorpName.Text.Trim();
            this.enterprise.CorpAbbr = tb_CorpAbbr.Text.Trim();
            this.enterprise.ModifyUserId = base.CurrentUserId;
            this.enterprise.Process = this.cb_Process.Checked ? "1" : "0";
            if (string.IsNullOrEmpty(this.FCorpMapOrgId))
                enterprise.IsMap = "0";
            else
                enterprise.IsMap = "1";

            if (String.IsNullOrEmpty(this.enterprise.CorpCode))
            {
                EmedMessageBox.ShowWarning("买方编码不允许为空！");
                this.tb_CorpCode.Focus();
                this.tb_CorpCode.SelectAll();
                return false;
            }
            else if (String.IsNullOrEmpty(this.enterprise.CorpName))
            {
                EmedMessageBox.ShowWarning("买方全称不允许为空！");
                this.tb_CorpName.Focus();
                this.tb_CorpName.SelectAll();
                return false;
            }
            else if (String.IsNullOrEmpty(this.enterprise.CorpAbbr))
            {
                EmedMessageBox.ShowWarning("买方简称不允许为空！");
                this.tb_CorpAbbr.Focus();
                this.tb_CorpAbbr.SelectAll();
                return false;
            }
            return true;

        }
        #endregion

        #region 双击选定中心企业列表 DoubleClik
        /// <summary>
        /// 双击选定中心企业列表
        /// </summary>
        private void DoubleClik()
        {
            if (this.dgv_EmedCorpList.CurrentRow != null)
            {
                int num1 = this.dgv_EmedCorpList.CurrentRow.Index;
                this.SelectCorpListRow(num1);
                if (((num1 >= 0) && (this.dsEmedCorpList1.Tables.Count > 0)) && (this.dsEmedCorpList1.Tables[0].DefaultView.Count > 0))
                {
                    string sendOrgId = this.dsEmedCorpList1.Tables[0].DefaultView[num1]["buyer_orgid"].ToString();
                    if (((sendOrgId == "") || (sendOrgId == null)) || (sendOrgId != this.FCorpMapOrgId))
                    {
                        DataSet set1 = this.GetHisCorpListByOrgId(sendOrgId);
                        if ((set1.Tables.Count > 0) && (set1.Tables[0].Rows.Count > 0))
                        {
                            string text2 = this.dsEmedCorpList1.Tables[0].DefaultView[num1]["name"].ToString();
                            string text3 = this.tb_CorpCode.Text.Trim();
                            string text4 = this.tb_CorpName.Text.Trim();
                            hospCorpMapList frm1 = new hospCorpMapList(text2, text3, text4, set1);
                            frm1.ShowDialog();
                            if (!frm1.IsContinueMap)
                            {
                                return;
                            }
                        }
                        this.dsEmedCorpMapList1.Tables[0].Rows.Clear();
                        DataRow row1 = this.dsEmedCorpList1.Tables[0].DefaultView[num1].Row;
                        DataRow row2 = this.dsEmedCorpMapList1.Tables[0].NewRow();
                        row2.ItemArray = row1.ItemArray;
                        this.dsEmedCorpMapList1.Tables[0].Rows.Add(row2);
                        this.dsEmedCorpMapList1.AcceptChanges();
                        this.SelectMapCorpRow(0);
                        this.sumDsEmedCorpMapListRecordCount();
                    }
                }
            }
        }
        #endregion

        #region 海虹企业对应HIS企业列表 GetHisCorpListByOrgId
        /// <summary>
        /// 海虹企业对应HIS企业列表
        /// </summary>
        private DataSet GetHisCorpListByOrgId(string inOrgId)
        {
            return bll.GetEmedCorpMapListDs(inOrgId);
        }
        #endregion

        #region 取消匹配 CancelMap
        /// <summary>
        /// 取消匹配
        /// </summary>
        private void CancelMap()
        {
            if (this.dgv_EmedCorpMapList.CurrentRow != null)
            {
                int num1 = this.dgv_EmedCorpMapList.CurrentRow.Index;
                this.SelectMapCorpRow(num1);
                if (num1 >= 0)
                {
                    this.dsEmedCorpMapList1.Tables[0].Rows.Clear();
                    this.dsEmedCorpMapList1.AcceptChanges();
                    this.SelectMapCorpRow(-1);
                    this.sumDsEmedCorpMapListRecordCount();
                }
            }
        }
        #endregion

        #region 聚焦到中心企业列表 FocusEmedCorpList
        /// <summary>
        /// 聚焦到中心企业列表
        /// </summary>
        /// <param name="e"></param>
        private void FocusEmedCorpList(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.dgv_EmedCorpList.Focus();
            }
        }
        #endregion

        #region 根据Alt+快捷键 设置焦点 FormPurchaseCreate_KeyDown
        /// <summary>
        /// 根据Alt+快捷键 设置焦点
        /// </summary>
        /// <param name="e"></param>
        private void FormPurchaseCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyValue)
                {
                    //1
                    case 49:
                        this.tb_sendName.Focus();
                        this.tb_sendName.SelectAll();
                        break;
                    //2
                    case 50:
                        this.tb_CorpCode.Focus();
                        this.tb_CorpCode.SelectAll();
                        break;
                    //3
                    case 51:
                        this.tb_CorpName.Focus();
                        this.tb_CorpName.SelectAll();
                        break;
                    //4
                    case 52:
                        this.tb_CorpAbbr.Focus();
                        this.tb_CorpAbbr.SelectAll();
                        break;
                    //max form
                    case 13:
                        this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
                        break;
                    default:
                        break;
                }

            }
        }
        #endregion

        #region 保存对照信息 SaveCorpMap
        /// <summary>
        /// 保存对照信息
        /// </summary>
        private void SaveCorpMap()
        {
            if (this.getCorpInput())
            {
                try
                {
                    if (flag == "ADD")
                    {
                        if (bll.JudgeHIScode(this.enterprise.CorpCode,this.enterprise.MapOrgId) < 1)
                        {
                            bll.InsertHisErpCorpMap(this.enterprise);
                            EmedMessageBox.ShowInformation("保存成功！");
                            this.ClearAll();
                            this.IsSave = true;
                            this.bindingDsEmedCorpList();
                            searchInput.SearchSendName = tb_sendName.Text;
                            filterDsEmedCorpList(searchInput);
                        }
                        else
                        {
                            EmedMessageBox.ShowInformation("此买方编码已存在！");
                        }
                    }
                    else if (flag == "MODIFY")
                    {
                        bll.UpdateHisErpCorpMap(this.enterprise);
                        EmedMessageBox.ShowInformation("保存成功！");
                        this.IsSave = true;
                        this.bindingDsEmedCorpList();
                        searchInput.SearchSendName = tb_sendName.Text;
                        filterDsEmedCorpList(searchInput);
                    }
                }
                catch (Exception ex)
                {
                    EmedMessageBox.ShowError("保存时发送错误：" + ex.Message.ToString());
                }
            }
        }
        #endregion

        private void SelectCorpListRow(int _Index)
        {
            if (_Index >= 0)
            {
                int num1 = 0;
                string text1 = this.dsEmedCorpList1.Tables[0].DefaultView[_Index]["MapSum"].ToString();
                try
                {
                    num1 = int.Parse(text1);
                }
                catch
                {
                    num1 = 0;
                }
                this.FCorpMapSum = num1;
            }
            else
            {
                this.FCorpMapSum = 0;
            }
        }

        private void SelectMapCorpRow(int _Index)
        {
            if (_Index >= 0)
            {
                this.FCorpMapOrgId = this.dsEmedCorpMapList1.Tables[0].DefaultView[_Index]["buyer_orgid"].ToString();
            }
            else
            {
                this.FCorpMapOrgId = "";
            }
        }
       
        private void tb_sendName_TextChanged(object sender, EventArgs e)
        {
            searchInput.SearchSendName = tb_sendName.Text;
            filterDsEmedCorpList(searchInput);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveCorpMap();
        }

        private void ClearAll()
        {
            this.tb_CorpCode.Text = "";
            this.tb_CorpName.Text = "";
            this.tb_CorpAbbr.Text = "";
            this.cb_Process.Checked = true;
            this.CancelMap();
            this.sumDsEmedCorpListRecordCount();
        }

        private bool IsNeedSave()
        {
            if (this.IsSave)
            {
                return false;
            }
            if ((this.FCorpMapOrgId != "") && (this.FCorpMapOrgId != null))
            {
                this.IsChange = true;
            }
            return this.IsChange;
        }

        private void dgv_EmedCorpList_DoubleClick(object sender, EventArgs e)
        {
            this.DoubleClik();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            this.DoubleClik(); 
        }

        private void btnCancelMap_Click(object sender, EventArgs e)
        {
            this.CancelMap();
        }

        private void tb_sendName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.FocusEmedCorpList(e);
            }
        }

        private void dgv_EmedCorpMapList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.tb_sendName.Focus();
                this.tb_sendName.SelectAll();
            }
        }

        private void tb_CorpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.tb_CorpName.Focus();
                this.tb_CorpName.SelectAll();
            }
        }

        private void tb_CorpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.tb_CorpAbbr.Focus();
                this.tb_CorpAbbr.SelectAll();
            }
        }

        private void tb_CorpAbbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cb_Process.Focus();
            }
        }

        private void cb_Process_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnSave.Focus();
            }
        }

        private void FormHisCorpCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.IsNeedSave() && EmedMessageBox.ShowYesNo("数据发生改变，是否需要保存？"))
            //{
                //if (!this.getCorpInput())
                //{
                //    e.Cancel = true;
                //}
                //else
                //{
                //    this.SaveCorpMap();
                //}
            //}
        }

        private void FormHisCorpCreate_Load(object sender, EventArgs e)
        {
            if (this.flag == "MODIFY")
            {
                this.labelfrmtxt.Text = "修改买方对照";
                this.tb_CorpCode.Text = this.code;
                this.tb_CorpCode.Enabled = false;
                this.tb_CorpName.Text = this.fullname;
                this.tb_CorpAbbr.Text = this.easyname;
                if (this.process =="已处理")
                {
                    this.cb_Process.Checked = true;
                }
                else
                {
                    this.cb_Process.Checked = false;
                }
                if (!string.IsNullOrEmpty(this.orgid))
                {
                    foreach (DataGridViewRow row in this.dgv_EmedCorpList.Rows)
                    {
                        if (row.Cells["buyer_orgid"].Value.ToString() == this.orgid)
                        {
                            this.dgv_EmedCorpList.CurrentCell = this.dgv_EmedCorpList["buyer_orgid", row.Index];
                            this.dsEmedCorpMapList1.Tables[0].Rows.Clear();
                            DataRow row1 = this.dsEmedCorpList1.Tables[0].DefaultView[row.Index].Row;
                            DataRow row2 = this.dsEmedCorpMapList1.Tables[0].NewRow();
                            row2.ItemArray = row1.ItemArray;
                            this.dsEmedCorpMapList1.Tables[0].Rows.Add(row2);
                            this.dsEmedCorpMapList1.AcceptChanges();
                            this.SelectMapCorpRow(0);
                            this.sumDsEmedCorpMapListRecordCount();
                            break;
                        }
                    }
                }
            }
        }

        //add  by cjg
        /// <summary>
        ///  字符转换
        /// </summary>
        /// <param name="sInput"></param>
        private void CharConvert()
        {
            foreach (Control con in this.groupBox1.Controls)
            {
                if (con is TextBox && !(con.Text.StartsWith("[") && con.Text.EndsWith("]")))
                {
                    con.Text = StringUtils.repalceSepStr(con.Text);
                }
            }
        }
    }
}