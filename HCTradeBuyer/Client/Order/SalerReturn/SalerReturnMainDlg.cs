//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerReturnMainDlg.cs   
//	创 建 人:	高原
//	创建日期:	2006-12-26
//	功能描述:	企业退货处理页面层
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
using Emedchina.TradeAssistant.Model.Order.SalerReturn;
using Emedchina.Commons;
using System.Collections;

namespace Emedchina.TradeAssistant.Client.Order.SalerReturn
{
    public partial class SalerReturnMainDlg : MainFormBase
    {
        string[] Class4Plats;
        bool firstInit = true;
        string handlerId;
        string operate;


        public SalerReturnMainDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalerReturnMainDlg_Load(object sender, EventArgs e)
        {
            //初始化退货状态下拉列表
            string[] valuesReturnStatus = {"1","2","3","4"};
            string[] textsReturnStatus = { "对方已发出", "对方已撤销", "已同意", "已拒绝" };
            InitReturnStatus(this.cmbReturnStatus, valuesReturnStatus, textsReturnStatus);

            //初始化品名类型下拉列表
            string[] valuesType = { "1", "2", "3", "4" };
            string[] textsType = { "品名", "品名拼音", "品名五笔", "医院名称" };
            InitReturnStatus(this.cmbType, valuesType, textsType);

            dtStartDate.Value = DateTime.Now.AddYears(-1);
            dtEndDate.Value = DateTime.Now;

            handlerId = "order.return";
            operate = "ReturnDeal";

            getClass4PlatsList();

            //查询并绑定退货单列表
            SearchReturnList();

            firstInit = false;
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void InitReturnStatus(ComboBox cmb,string[] values,string[] texts)
        {
            if (values.Length != texts.Length)
                return;
            //初始化数据
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            for (int i = 0; i < values.Length; i++)
            {
                string[] data = { values[i],texts[i] };
                dt.Rows.Add(data);
            }

            //绑定
            cmb.DataSource = dt;
            cmb.DisplayMember = "text";
            cmb.ValueMember = "value";
            //选择第一项
            cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// 组织输入参数实体
        /// </summary>
        /// <returns></returns>
        private SalerReturnModel GetInput()
        {
            SalerReturnModel mdl = new SalerReturnModel();
            mdl.CurOrgId = this.CurrentUserOrgId;
            mdl.ReturnState = cmbReturnStatus.SelectedValue.ToString();
            mdl.StrType = cmbType.SelectedValue.ToString();
            mdl.StrKeyValue = txtName.Text;
            mdl.StartDate = ComUtil.formatDate(this.dtStartDate.Text.ToString());
            mdl.EndDate = ComUtil.formatDate(this.dtEndDate.Text.ToString());

            return mdl;
        }

        /// <summary>
        /// 查询并绑定退货单列表
        /// </summary>
        private void SearchReturnList()
        {
            int rows;
            DataTable dt = ProxyFactory.SalerReturnProxy.findDealList(Class4Plats, GetInput(),getPageParam(), out rows);
            this.bindingSourceReturn.DataSource = dt;
            pageNavigator1.ItemCount = rows;
        }

        /// <summary>
        /// 查询4级平台ID
        /// </summary>
        private void getClass4PlatsList()
        {
            bool flag = true;
            Class4Plats = ProxyFactory.SalerReturnProxy.getClass4PlatsList(handlerId, operate, GetUserInfo(), flag);
        }

        /// <summary>
        /// 取得分页条件
        /// </summary>
        private PagedParameter getPageParam()
        {
            //分页条件
            PagedParameter param = new PagedParameter();
            param.PageNum = this.pageNavigator1.CurrentPageIndex.ToString();
            param.PageSize = this.pageNavigator1.PageSize.ToString();

            return param;
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //查询并绑定退货单列表
            SearchReturnList();
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            //查询并绑定退货单列表
            SearchReturnList();
        }

        /// <summary>
        /// 退货状态变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbReturnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化页面
            if (firstInit)
            {
                dgvSalerReturnList.Columns["Remark"].ReadOnly = false;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                return;
            }
            //下拉列表变更
            if (cmbReturnStatus.SelectedValue.ToString().Equals("1"))
            {
                dgvSalerReturnList.Columns["Remark"].ReadOnly = false;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                btnAllow.Visible = true;
                btnRefuse.Visible = true;
            }
            else
            {
                dgvSalerReturnList.Columns["Remark"].ReadOnly = true;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                btnAllow.Visible = false;
                btnRefuse.Visible = false;
            }
            SearchReturnList();
        }

        /// <summary>
        /// 同意按钮　　1--同意/0--拒绝/other--错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllow_Click(object sender, EventArgs e)
        {
            if (dgvSalerReturnList.SelectedRows.Count == 0)
            {
                MessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool flgSuccess = true;
            SalerReturnModel[] RetrunModel = GetReturnModel(out flgSuccess);
            if (!flgSuccess)
            {
                return;
            }
            if (MessageBox.Show("是否同意退货？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            bool flg = ProxyFactory.SalerReturnProxy.UpdateReturnStatus(RetrunModel, GetUserInfo(), "1");
            if (flg)
            {
                MessageBox.Show("操作成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //查询并绑定退货单列表
                SearchReturnList();
            }
            else
            {
                MessageBox.Show("操作失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
        }

        /// <summary>
        /// 组织所选择的数据
        /// </summary>
        /// <returns></returns>
        private SalerReturnModel[] GetReturnModel(out bool flgSuccess)
        {
            flgSuccess = true;
            SalerReturnModel[] salerReturnModel = new SalerReturnModel[dgvSalerReturnList.SelectedRows.Count];
            for (int i = 0; i < dgvSalerReturnList.SelectedRows.Count; i++)
            {
                SalerReturnModel mdl = new SalerReturnModel();
                mdl.Id = dgvSalerReturnList.Rows[i].Cells["ID"].Value.ToString();
                mdl.Remark = dgvSalerReturnList.Rows[i].Cells["Remark"].Value.ToString();
                mdl.StrReceiveID = dgvSalerReturnList.Rows[i].Cells["receive_id"].Value.ToString();
                mdl.StrReceiveQty = Convert.ToDouble(dgvSalerReturnList.Rows[i].Cells["receive_qty_pre"].Value.ToString()) - Convert.ToDouble(dgvSalerReturnList.Rows[i].Cells["return_qty"].Value.ToString());
                mdl.StrReceiveQty = mdl.StrReceiveQty < 0 ? 0 : mdl.StrReceiveQty;
                if (mdl.Remark.Length > 100)
                {
                    MessageBox.Show("附注内容不得大于100！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.SetStyle(ControlStyles.Selectable, true);
                    dgvSalerReturnList.Select();
                    dgvSalerReturnList.Rows[i].Cells["Remark"].Selected = true;
                    dgvSalerReturnList.CurrentCell = dgvSalerReturnList.Rows[i].Cells["Remark"];
                    flgSuccess = false;
                    break;
                }
                salerReturnModel[i] = mdl;
            }

            return salerReturnModel;
        }

        /// <summary>
        /// 组织当前用户信息
        /// </summary>
        /// <returns></returns>
        private UserInfo GetUserInfo()
        {
            UserInfo ui = new UserInfo();
            //当前用户ID
            ui.UserId = this.CurrentUserId;
            //最后登陆平台ID
            //ui.LastLoginPlat = this.LastLoginPlat;
            //平台类型
            //ui.PlatClass = this.PlatClass;
            return ui;
        }

        /// <summary>
        /// 名称变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //查询并绑定退货单列表
            SearchReturnList();
        }

        /// <summary>
        /// 拒绝按钮　1--同意/0--拒绝/other--错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefuse_Click(object sender, EventArgs e)
        {
            if (dgvSalerReturnList.SelectedRows.Count == 0)
            {
                MessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool flgSuccess = true;
            SalerReturnModel[] RetrunModel = GetReturnModel(out flgSuccess);
            if (!flgSuccess)
            {
                return;
            }
            if (MessageBox.Show("是否拒绝退货？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            bool flg = ProxyFactory.SalerReturnProxy.UpdateReturnStatus(RetrunModel, GetUserInfo(), "0");
            if (flg)
            {
                MessageBox.Show("操作成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //查询并绑定退货单列表
                SearchReturnList();
            }
            else
            {
                MessageBox.Show("操作失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bindingSourceReturn.DataSource;
            SalerReturnPrintDlg frm = new SalerReturnPrintDlg(dt, cmbReturnStatus.Text + "纪录", this.CurrentUserName);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}