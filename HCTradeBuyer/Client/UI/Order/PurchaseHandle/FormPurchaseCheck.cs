using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.UI.PublicModule;
using Emedchina.TradeAssistant.Client.BLL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;
using DevExpress.Utils;

namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class FormPurchaseCkeck : BaseForm
    {

        private UserInfoModel usInfo = new UserInfoModel();
        //采购单列表id
        string purchaseId;
        //机构id
        string userId;
        //判断删除、修改等操作按钮显示状态传入的参数需要修改为 purchaseState
        string purchaseState = "";
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();
        //采购单复制后输出模型
        private PurchaseSaveModel output;
        //采购单列表
        DataTable purchasedt;

        public FormPurchaseCkeck()
        {
            InitializeComponent();
            //获取当前用户对象
            LogedInUser curUser = base.CurrentUser;
            //机构id
            userId = base.CurrentUserOrgId;
            //用户信息
            purchaseSaveModel.UserID = base.CurrentUserId;
            purchaseSaveModel.UserName = base.CurrentUserName;
           
        }
        #region 查询按钮
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
        #region 设置采购单过滤器条件
        /// <shangfu>
        /// 设置采购单过滤器条件
        /// </shangfu>
        private void setFilter()
        {
            //if (DateTime.Compare(this.cmdEndDate.DateTime, this.cmdCreateDate.DateTime) < 0)
            //{
            //    XtraMessageBox.Show("创建日期结束日期必须大于开始日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //采购单状态
            string PurchaseState = this.cmbState.Text.Trim();
            
            //开始时间
            string createDate = ComUtil.formatDate(this.cmdCreateDate.Text.ToString());
            //结束时间
            string endDate = ComUtil.formatDate(this.cmdEndDate.Text.ToString());
            purchasedt.DefaultView.RowFilter = "";
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            //过滤条件
            if (PurchaseState != "" && PurchaseState != null)
            {
                switch (PurchaseState)
                {
                    case "全部":
                        filter.AppendFormat("", "");
                        break;

                    case "准备":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;

                    case "送审":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;
                    case "拒绝":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;
                    case "审核通过":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;

                }
            }

            if (createDate != "" && createDate != null)
            {
                filter.AppendFormat(" and create_date1 >= '{0}'", createDate + " 00:00:00");
            }

            if (endDate != "" && endDate != null)
            {
                filter.AppendFormat(" and create_date1 <= '{0}'", endDate + " 23:59:59");
            }

            purchasedt.DefaultView.RowFilter = filter.ToString();
            //按照时间排序
            purchasedt.DefaultView.Sort = " create_date1 desc";
            this.purchaseListBindingSource.DataSource = purchasedt.DefaultView;
            EnabledBt();
        }
        #endregion 

        #region 判断删除、修改等操作按钮显示状态
        /// <summary>
        /// 判断删除、修改等操作按钮显示状态
        /// </summary>
        /// <param name="purchaseId"></param>
        private void EnabledBt()
        {    
            int rowcount = this.gridView3.RowCount;
            if (rowcount > 0)
            {
                purchaseState = GetGridViewColValue(this.gridView3, "purchase_state");
                purchaseId = GetGridViewColValue(this.gridView3, "id");
            }
            if ("送审".Equals(purchaseState))
            {
                this.btnCheck.Enabled = true;
               
            }
            else
            {
                this.btnCheck.Enabled = false;

            }

            
        }
        #endregion

       //审核采购单
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseCreate frm = new FormPurchaseCreate("审核采购单", (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "准备";
            this.FormPurchaseBuild_Load(sender, e);
        }

        #region 初始化采购单列表窗体
        /// <summary>
        /// 初始化采购单列表窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPurchaseBuild_Load(object sender, EventArgs e)
        {
            //客户端缓存操作
            purchasedt = PurchaseClientDao.GetInstance("ClientDB").getPurchaseCreate(userId);
            //设置采购单状态列表初始值
            this.cmbState.Text = "送审";
            this.cmdEndDate.DateTime = DateTime.Now;
            this.cmdCreateDate.DateTime = DateTime.Now.AddMonths(-3);

        }
        #endregion  
        #region 获取Grid当前选择 某个字段值
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

        #endregion
       

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }

        private void cmbState_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            setFilter();

        }

        private void cmdCreateDate_EditValueChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            setFilter();
        }

        private void cmdEndDate_EditValueChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            setFilter();
        }

        private void gridView3_RowCountChanged_1(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }

        //当gridView的行号变化改变按钮可操作状态
        private void gridView3_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EnabledBt();
        }
        //查看采购单明细
        private void btnPurchaseItem_Click_1(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseItem frm =new FormPurchaseItem("查看采购明细", (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "准备";
            this.FormPurchaseBuild_Load(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            purchasedt = PurchaseClientDao.GetInstance("ClientDB").getPurchaseCreate(userId);
            setFilter();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gridView3.GetDataRow(gridView3.FocusedRowHandle) != null)
            {
                DataTable dt = ReportBLL.GetInstance().GetPurchaseReportData(gridView3.GetDataRow(gridView3.FocusedRowHandle)["id"].ToString().Trim());
                FrmPrint frmPrint = new FrmPrint(new PurchaseXtraReport(base.CurrentUserOrgName + "采购单报表"), dt);
                frmPrint.ShowDialog();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);

            //送审时作审核事件
            if (dr["purchase_state"].ToString().Equals("送审"))
            {
                btnSend_Click(null, null);
            }
            else
            {
                this.btnPurchaseItem_Click_1(null, null);
            }
        }


        private void toolTipLocationControl_ToolTipLocationChanged(string senderName)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = senderName;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                 if (gridView3.FocusedColumn.FieldName == "create_date1")
                    toolTipLocationControl_ToolTipLocationChanged(dr["create_date1"].ToString());

            }


        }
    }
}

