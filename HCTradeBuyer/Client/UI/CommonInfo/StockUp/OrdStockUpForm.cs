//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdStockUpForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单确认
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.BLL.Report;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.StockUp
{
    /// <summary>
    /// 备货单确认
    /// </summary>
    public partial class OrdStockUpForm : BaseForm
    {
        //备货单列表信息
        private DataTable OrdStockUpDt = null;

        //获取当取用户对象
        private LogedInUser CurrentUser = null;

        public OrdStockUpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdStockUpForm_Load(object sender, EventArgs e)
        {
            CurrentUser = base.CurrentUser;
            DataBind();
            //给查询时间赋默认值
            this.StartDate.EditValue = DateTime.Now.AddMonths(-3);
            this.EndDate.EditValue = DateTime.Now;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //获取采购目录查询数据集
            OrdStockUpDt = OrdStockUpBLL.GetInstance().GetStockUpList(CurrentUser);
            //排序
            OrdStockUpDt.DefaultView.Sort = " CREATE_DATE DESC";

            this.bindingSource1.DataSource = OrdStockUpDt.DefaultView;
        }

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            string strStateName = this.cmbStateName.Text.Trim();                //备货单状态
            string strSenderName = this.txtSenderName.Text.Trim();              //配送机构
            string strCode = this.txtCode.Text.Trim();                          //备货单编号
            string strStartDate = this.StartDate.Text;  //开始时间
            string strEndDate = this.EndDate.Text;      //结束时间

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //备货单状态
            if (!string.IsNullOrEmpty(strStateName) && !strStateName.Equals("全部"))
            {
                StrFilter.AppendFormat(" AND StateName='{0}'", strStateName);
            }

            //配送机构
            if (!string.IsNullOrEmpty(strSenderName))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%' Or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' Or SENDER_NAME_WB LIKE '%{0}%')", strSenderName);
            }

            //备货单编号
            if (!string.IsNullOrEmpty(strCode))
            {
                StrFilter.AppendFormat(" AND (CODE LIKE '%{0}%')", strCode);
            }

            //开始时间
            if (!string.IsNullOrEmpty(strStartDate))
            {
                StrFilter.AppendFormat(" AND CREATE_DATE >= '{0}'", strStartDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(strEndDate))
            {
                StrFilter.AppendFormat(" AND CREATE_DATE <= '{0}'", strEndDate + " 23:59:59");
            }

            if (OrdStockUpDt != null)
            {
                if (OrdStockUpDt.DefaultView != null)
                {
                    this.OrdStockUpDt.DefaultView.RowFilter = StrFilter.ToString();
                }
            }
        }
        #endregion

        #region 按条件查询事件
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        #endregion

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            DataBind();
            Filter();
        }

        /// <summary>
        /// 查看明细事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gVStockUp.RowCount == 0)
                return;

            string strStockUpID = GetGridViewColValue(this.gVStockUp,"ID");
            OrdStockUpItemForm frm = new OrdStockUpItemForm(strStockUpID);
            frm.ShowDialog();
        }

        /// <summary>
        /// 获取当前选择ID
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view,string ColName)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(ColName);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        /// <summary>
        /// 作废事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gVStockUp.RowCount == 0)
                return;

            //备货单状态
            string strState = GetGridViewColValue(this.gVStockUp, "STATE");

            if (strState.Equals("4") || strState.Equals("6"))
            {
                XtraMessageBox.Show("备货确认已经完成，不能进行作废操作！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            if (XtraMessageBox.Show("确认是否作废？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string strStockUpID = GetGridViewColValue(this.gVStockUp,"ID");
            //设置作废
            try
            {
                OrdStockUpBLL.GetInstance().SetOrdStockUpState(strStockUpID, "4", "4");
                RefreshDt(strStockUpID);
                XtraMessageBox.Show("备货单作废成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("备货单作废失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 刷新数据集
        /// </summary>
        /// <param name="strStockUpID"></param>
        private void RefreshDt(string strStockUpID)
        {
            DataColumn[] keys = new DataColumn[1];
            DataColumn myColumn = new DataColumn();

            keys[0] = OrdStockUpDt.Columns[0];
            OrdStockUpDt.PrimaryKey = keys;

            DataRow dr = OrdStockUpDt.Rows.Find(strStockUpID);

            if (dr != null)
            {
                dr["STATE"] = "4";
                dr["StateName"] = "作废";
            }
        }

        /// <summary>
        /// 确认事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAffirm_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gVStockUp.RowCount == 0)
                return;

            //备货单状态
            string strState = GetGridViewColValue(this.gVStockUp, "STATE");

            if (strState.Equals("4") || strState.Equals("6"))
            {
                XtraMessageBox.Show("备货确认已经完成，不能进行确认操作！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string strStockUpID = GetGridViewColValue(this.gVStockUp,"ID");
            AffirmOrdStockUpItemForm frm = new AffirmOrdStockUpItemForm(strStockUpID);
            frm.ShowDialog();

            if (frm.EditFlag)
            {
                DataBind();
            }
        }

        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockUp_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gVStockUp.GetDataRow(gVStockUp.FocusedRowHandle) != null)
            {
                DataTable dt = ReportBLL.GetInstance().GetStokReportData(gVStockUp.GetDataRow(gVStockUp.FocusedRowHandle)["id"].ToString().Trim());
                FrmPrint frmPrint = new FrmPrint(new StockXtraReport(base.CurrentUserOrgName + "备货单报表"), dt);
                frmPrint.Show();
            }
        }

        private void gVStockUp_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gVStockUp.RowCount + " 条数据";
        }

        #region 显示Title
        private void toolTipLocationControl_ToolTipLocationChanged(string HintValue)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = HintValue;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gVStockUp_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVStockUp.GetDataRow(this.gVStockUp.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVStockUp.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVStockUp.FocusedColumn.FieldName.ToUpper() == "CREATE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["CREATE_DATE"].ToString());
                else
                    toolTipController1.HideHint();
            }
        }
        #endregion


    }
}