//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdInvoiceListForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	确认发货单
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

using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;


namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdInvoice
{
    /// <summary>
    /// 确认发货单
    /// </summary>
    public partial class OrdInvoiceListForm : BaseForm
    {
        //定义当前用户对象
        private LogedInUser CurrentUser = null;
         
        //定义发货单列表数据集对象
        private DataTable OrdInvoiceFromDt = null;

        public OrdInvoiceListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdInvoiceListForm_Load(object sender, EventArgs e)
        {
            InitData();
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
            //获取当取用户对象
            CurrentUser = base.CurrentUser;

            //获取发货单列表数据集
            OrdInvoiceFromDt = OrdInvoiceBLL.GetInstance().GetOrdInvoiceFromList();

            this.bindingSource1.DataSource = OrdInvoiceFromDt.DefaultView;
        }

        #region 初始化列表
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitData()
        {
            InitData_State();
        }

        /// <summary>
        /// 初始货发货单状态列表
        /// </summary>
        private void InitData_State()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "Name";

            string[] data1 = { "", "全部" };
            dt.Rows.Add(data1);
            string[] data2 = { "2", "已发出" };
            dt.Rows.Add(data2);
            string[] data3 = { "3", "买方处理中" };
            dt.Rows.Add(data3);
            string[] data4 = { "5", "买方处理完成" };
            dt.Rows.Add(data4);
            //string[] data5 = { "4", "作废" };
            //dt.Rows.Add(data5);
            
            this.LueState.Properties.DataSource = dt;
            this.LueState.Properties.Columns.Clear();
            this.LueState.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "状态名称"));
            this.LueState.Properties.DisplayMember = "Name";
            this.LueState.Properties.ValueMember = "value";
            this.LueState.Properties.NullText = "";

            this.LueState.EditValue = "";
        }

        #endregion

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            if (OrdInvoiceFromDt == null)
            {
                return;
            }

            string strState = string.Empty;
            if (!string.IsNullOrEmpty(this.LueState.EditValue.ToString()))
            {
                strState = this.LueState.EditValue.ToString();                  //发货单状态
            }
            string strSenderName = this.txtSendedName.Text.Trim();              //发货单位
            string strInvoiceCode = this.txtInvoiceCode.Text.Trim();            //发货单编码
            string strStartDate = this.StartDate.Text;                          //开始时间
            string strEndDate = this.EndDate.Text;                              //结束时间

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //发货单状态
            if (!string.IsNullOrEmpty(strState))
            {
                StrFilter.AppendFormat(" AND STATE='{0}'", strState);
            }

            //发货单位
            if (!string.IsNullOrEmpty(strSenderName))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%' Or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' Or SENDER_NAME_WB LIKE '%{0}%')", strSenderName);
            }

            //发货单编码
            if (!string.IsNullOrEmpty(strInvoiceCode))
            {
                StrFilter.AppendFormat(" AND (INVOICE_CODE LIKE '%{0}%')", strInvoiceCode);
            }

            //开始时间
            if (!string.IsNullOrEmpty(strStartDate))
            {
                StrFilter.AppendFormat(" AND SENDED_DATE >= '{0}'", strStartDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(strEndDate))
            {
                StrFilter.AppendFormat(" AND SENDED_DATE <= '{0}'", strEndDate + " 23:59:59");
            }

            if (OrdInvoiceFromDt.DefaultView != null)
            {
                this.OrdInvoiceFromDt.DefaultView.RowFilter = StrFilter.ToString();
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
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvInvoiceList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFound_Click(object sender, EventArgs e)
        {
            Filter();
        }

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
        /// 查看事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewItem_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gvInvoiceList.RowCount == 0)
                return;

            //发货单ID
            string strInvoiceID = GetGridViewColValue(this.gvInvoiceList, "ID");

            OrdInvoiceItemForm frm = new OrdInvoiceItemForm(strInvoiceID, true);
            frm.ShowDialog();
        }

        /// <summary>
        /// 获取Grid当前选择 某个字段值
        /// </summary>
        /// <param name="view">gridView对象</param>
        /// <param name="ColName">字段名</param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view, string ColName)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(ColName);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        /// <summary>
        /// 到货操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewReceiveList_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gvInvoiceList.RowCount == 0)
                return;

            //发货单ID
            string strInvoiceID = GetGridViewColValue(this.gvInvoiceList, "ID");
            //发货单状态
            string strState = GetGridViewColValue(this.gvInvoiceList, "STATE");

            if (strState.Equals("4"))//作废状态
            {
                XtraMessageBox.Show("发货单已作废，不能作到到货操作！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrdInvoiceItemForm frm = new OrdInvoiceItemForm(strInvoiceID, false);
            frm.ShowDialog();
            if (frm.EditFlag)
            {
                DataBind();
                Filter();
            }
        }

        /// <summary>
        /// 作废事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBlank_Click(object sender, EventArgs e)
        {
            //判断是否为空数据集
            if (this.gvInvoiceList.RowCount == 0)
                return;

            //发货单状态
            string strState = GetGridViewColValue(this.gvInvoiceList, "STATE");

            if (strState.Equals("5") || strState.Equals("4"))//作废状态 买方确认完成
            {
                XtraMessageBox.Show("发货单已完成，不能进行作废操作！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            if (XtraMessageBox.Show("确认是否对该发货单作废？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                //发货单ID
                string strInvoiceID = GetGridViewColValue(this.gvInvoiceList, "ID");

                OrdInvoiceFromModel model = new OrdInvoiceFromModel();

                model.Id = strInvoiceID;

                OrdInvoiceBLL.GetInstance().ModifyOrdInvoiceFromState(model, "4", this.CurrentUser);

                RefreshDt(strInvoiceID);

                XtraMessageBox.Show("发货单作废成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("发货单作废失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 刷新数据集
        /// </summary>
        /// <param name="strInvoiceID"></param>
        private void RefreshDt(string strInvoiceID)
        {
            DataColumn[] keys = new DataColumn[1];
            DataColumn myColumn = new DataColumn();

            keys[0] = OrdInvoiceFromDt.Columns[0];
            OrdInvoiceFromDt.PrimaryKey = keys;

            DataRow dr = OrdInvoiceFromDt.Rows.Find(strInvoiceID);

            if (dr != null)
            {
                //dr["STATE"] = "4";
                //dr["StateName"] = "作废";
                OrdInvoiceFromDt.Rows.Remove(dr);
            }
        }

        private void gvInvoiceList_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gvInvoiceList.RowCount + " 条数据";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gvInvoiceList.GetDataRow(gvInvoiceList.FocusedRowHandle) != null)
            {
                DataTable dt = ReportBLL.GetInstance().GetInvoiceReportData(gvInvoiceList.GetDataRow(gvInvoiceList.FocusedRowHandle)["id"].ToString().Trim());
                FrmPrint frmPrint = new FrmPrint(new InvoiceFromXtraReport(base.CurrentUserOrgName + "确认发货单报表"), dt);
                frmPrint.ShowDialog();
            }
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

        private void gvInvoiceList_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvInvoiceList.GetDataRow(this.gvInvoiceList.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gvInvoiceList.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gvInvoiceList.FocusedColumn.FieldName.ToUpper() == "SENDED_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDED_DATE"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

    }
}