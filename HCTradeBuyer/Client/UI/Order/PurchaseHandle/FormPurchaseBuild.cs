using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
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
    public partial class FormPurchaseBuild : BaseForm
    {

        private UserInfoModel usInfo = new UserInfoModel();
        //采购单列表id
        string purchaseId;

        //判断删除、修改等操作按钮显示状态传入的参数需要修改为 purchaseState
        string purchaseState = "";
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();
        //采购单复制后输出模型
        private PurchaseSaveModel output;
        //采购单列表 
        DataTable purchasedt;

        public FormPurchaseBuild()
        {
            InitializeComponent();
            //获取当前用户对象
            LogedInUser curUser = base.CurrentUser;
            //用户信息
            purchaseSaveModel.UserID = base.CurrentUserId;
            purchaseSaveModel.UserName = base.CurrentUserName;
        }

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
            string createDate = this.cmdCreateDate.Text.ToString();
            //结束时间
            string endDate = this.cmdEndDate.Text.ToString();
            //类型
            string strType = this.cmbType.Text.Trim();

            string type = string.Empty;
            if (strType == "普通采购单")
                type = "1";
            else if (strType == "发货流程")
                type = "2";
            else if (strType == "确认单（备货）")
                type = "3";
            else
                type = "";

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

            //类型
            if (!string.IsNullOrEmpty(type))
            {
                filter.AppendFormat(" and purchaseType =  '{0}'", type);
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

            if ("审核通过".Equals(purchaseState))
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSend.Enabled = false;

                this.MenuEdit.Enabled = false;
                this.MenuDel.Enabled = false;
                this.MenuAudi.Enabled = false;

            }
            else if ("送审".Equals(purchaseState))
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = true;
                this.btnSend.Enabled = false;

            }
            else
            {
                if ("准备".Equals(purchaseState))
                {
                    this.btnSend.Enabled = true;
                    this.MenuAudi.Enabled = true;
                }
                else
                {
                    this.btnSend.Enabled = false;
                    this.MenuAudi.Enabled = false;
                }
                this.btnEdit.Enabled = true;
                this.btnDel.Enabled = true;
                this.MenuEdit.Enabled = true;
                this.MenuDel.Enabled = true;

            }

            //如果采购单表某种情况下为空时，下面的操作按钮将不能操作
            int CuPurcount = this.gridView3.RowCount;
            if (CuPurcount > 0)
            {
                this.btnCopy.Enabled = true;
                this.MenuCopy.Enabled = true;
            }
            else
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSend.Enabled = false;
                this.btnCopy.Enabled = false;

                this.MenuEdit.Enabled = false;
                this.MenuDel.Enabled = false;
                this.MenuAudi.Enabled = false;
                this.MenuCopy.Enabled = false;

            }
        }
        #endregion



        #region 修改操作
        /// <summary>
        ///  修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseCreate frm = FormPurchaseCreate.GetInstance(this, (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "全部";
            this.FormPurchaseBuild_Load(sender, e);

        }
        #endregion

        #region 添加采购单操作
        /// <summary>
        /// 添加采购单操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            FormPurchaseCreate frm = new FormPurchaseCreate("新建采购单", null);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "全部";
            this.FormPurchaseBuild_Load(sender, e);

        }
        #endregion

        #region 采购单复制操作　　改完，生成Purchase_Code的地方还需要测试
        /// <summary>
        /// 采购单复制操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                // DataRow drs = (DataRow)purchasedt.DefaultView.Table.DefaultView.RowFilter[this.gridView3.FocusedRowHandle];
                purchaseSaveModel.PurchaseId = GetGridViewColValue(this.gridView3, "id");

                //采购单复制（离线）
                output = new PurchaseOfflineBLL().CopyPurchaseOffline(purchaseSaveModel);
                if (output.Equals(null))
                {
                    XtraMessageBox.Show("采购单复制失败！没有返回数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                XtraMessageBox.Show("采购单复制成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                purchasedt = PurchaseClientDao.GetInstance("ClientDB").getPurchaseCreate(base.CurrentUserOrgId);

                //将原来的按照ID排序，修改为按照时间排序
                purchasedt.DefaultView.Sort = " create_date1 desc";

                setFilter();


            }
            catch (Exception)
            {
                XtraMessageBox.Show("采购单复制失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                throw;
            }


        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = new PurchaseOfflineBLL().putCheckPurchaseOffline(purchaseId);
            if (flag)
            {
                XtraMessageBox.Show("送审成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                purchasedt = PurchaseClientDao.GetInstance().getPurchaseCreate(base.CurrentUserOrgId);

                //将原来的按照ID排序，修改为按照时间排序
                purchasedt.DefaultView.Sort = " create_date1 desc";

                setFilter();
            }
            else
            {
                XtraMessageBox.Show("送审失败！没有返回数据！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
            purchasedt = PurchaseClientDao.GetInstance().getPurchaseCreate(base.CurrentUserOrgId);
            //设置采购单状态列表初始值
            this.cmdEndDate.DateTime = DateTime.Now;
            this.cmdCreateDate.DateTime = DateTime.Now.AddMonths(-3);
            this.cmbType.Text = "全部";

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
        //当gridView的行号变化改变按钮可操作状态
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EnabledBt();
        }

        #region 删除采购单列表、采购单明细列表记录 　　改完
        /// <summary>
        /// 删除采购单列表、采购单明细列表记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(purchaseId))
            {
                XtraMessageBox.Show("请选择一条采购单记录!");
            }
            else
            {
                if (XtraMessageBox.Show("是否确认删除操作？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //删除离线采购单
                    bool flag = new PurchaseOfflineBLL().PurchaseDeleteLocal(purchaseId, base.CurrentUserOrgId);

                    if (flag == true)
                    {
                        XtraMessageBox.Show("采购单删除成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("采购单删除失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.FormPurchaseBuild_Load(sender, e);
                }
            }
        }
        #endregion

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
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
        //导入采购计划
        private void imputpurchase_Click(object sender, EventArgs e)
        {
            RequestSend frm = new RequestSend();
            frm.ShowDialog(); ;
            frm.Dispose();
            this.cmbState.SelectedItem = "全部";
            this.FormPurchaseBuild_Load(sender, e);
        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseItem frm = new FormPurchaseItem("查看采购明细", (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "全部";
            this.FormPurchaseBuild_Load(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            purchasedt = PurchaseClientDao.GetInstance().getPurchaseCreate(base.CurrentUserOrgId);
            setFilter();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }






    }
}

