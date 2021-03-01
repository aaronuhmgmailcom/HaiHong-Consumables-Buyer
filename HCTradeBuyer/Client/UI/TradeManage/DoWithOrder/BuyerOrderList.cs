using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder;
using Emedchina.TradeAssistant.Client.Common;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;
using DevExpress.Utils;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;


namespace Emedchina.TradeAssistant.Client.UI.TradeManage.DoWithOrder
{
    public partial class BuyerOrderList : BaseForm
    {
        public BuyerOrderList()
        {
            InitializeComponent();
        }

        private bool flag = true;
        private BuyerOrderModel input;


        private void sbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyerOrderList_Load(object sender, EventArgs e)
        {            
            input = new BuyerOrderModel();
            btnSearch_Click(null, null);
            deStartDate.EditValue = DateTime.Now.AddMonths(-1);
            deEndDate.EditValue = DateTime.Now;
            this.cmbOrderStatus.Text = "全部";
            this.cmbType.Text = "全部";
            //this.cmbSearchField.Text = "经销企业";
            //base.SetPoint(gridView3);
        }

        private void deStartDate_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            input.OrderState = cmbOrderStatus.Text.ToString();

            if (!String.IsNullOrEmpty(this.deStartDate.Text.Trim()))
            {
                input.StartDate = this.deStartDate.Text.ToString();
            }
            else
            {
                input.StartDate = "";
            }

            if (!String.IsNullOrEmpty(this.deEndDate.Text.Trim()))
            {
                input.EndDate = this.deEndDate.Text.ToString();
            }
            else
            {
                input.EndDate = "";
            }

            //if (this.cmbSearchField.Text.ToString().Equals("经销企业"))
            //{
            //    input.SearchField = "1";//经销企业
            //}
            //else
            //{
            //    input.SearchField = "2";//配送企业
            //}

            if (!String.IsNullOrEmpty(this.txtSearchKey.Text.Trim()))
            {
                input.SearchKey = this.txtSearchKey.Text.Trim();
            }
            else
            {
                input.SearchKey = "";
            }

            //if (!String.IsNullOrEmpty(this.txtCreater.Text.Trim()))
            //{
            //    input.Creater = this.txtCreater.Text.Trim();
            //}
            //else
            //{
            //    input.Creater = "";
            //}

            //setPageParam(pageNavigatorByOrder);
            int rows;

            DataSet ds = null;

            ds = OrderOfflineBLL.GetInstance().GetBuyerOrderList(input, out rows);
            base.InitFromCacheByData(ds.Tables[0]);
            bindingSourceByOrder.DataSource = base.cachedDataView;
            Filter();
            
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataRow drow = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (drow != null)
            {

                OrderModel buyerOrder = new OrderModel();
                buyerOrder.OrderCode = drow["order_code"].ToString();
                buyerOrder.CreateUserName = drow["create_User_Name"].ToString();
                buyerOrder.CreateDate = drow["create_date"].ToString();
                buyerOrder.OrderState = drow["Order_State"].ToString();
                buyerOrder.QuicksendLevel = drow["QUICKSEND_LEVEL"].ToString();
                buyerOrder.SenderName = drow["sender_Name"].ToString();
                buyerOrder.Total_sum = drow["Total_sum"].ToString();
                buyerOrder.Over_sum = drow["OVER_SUM"] == null ? "-" : drow["OVER_SUM"].ToString();
                buyerOrder.Id = drow["id"].ToString();
                buyerOrder.ModifyUserName = drow["MODIFY_USER_NAME"].ToString();
                buyerOrder.ModifyDate = drow["MODIFY_DATE"].ToString();
                buyerOrder.BuyerRemark = drow["BUYER_DESCRIPTIONS"].ToString();
                buyerOrder.SalerRemark = drow["SALER_DESCRIPTIONS"].ToString();
                buyerOrder.SalerApproverName = drow["SALER_APPROVER_NAME"].ToString();
                buyerOrder.SalerApproveDate = drow["SALER_APPROVER_DATE"].ToString();
                

                DoWithOrder frm = new DoWithOrder(buyerOrder,input);
                
               

                frm.ShowDialog();
                if (ClientSession.GetInstance()["remark"] != null)
                    drow["BUYER_DESCRIPTIONS"] = ClientSession.GetInstance()["remark"].ToString();

                btnSearch_Click(null,null);
                Filter();
                gridView3_FocusedRowChanged(null, null);
            }
            else
            {
                XtraMessageBox.Show("请选择记录后再进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            string strStatus = this.cmbOrderStatus.Text.Trim();
            string strCode = this.txtCode.Text.Trim();
            string strSearchField = "配送企业";
            string strSearchKey = this.txtSearchKey.Text.Trim();
            string strType = this.cmbType.Text.Trim();

            string strStartDate = this.deStartDate.DateTime.ToShortDateString();
            string strEndDate = this.deEndDate.DateTime.ToShortDateString();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            string orderState = string.Empty;
            if (strStatus=="未阅读")
                orderState = "1";
            else if(strStatus=="已阅读")
                orderState = "2";
            else if(strStatus=="确认")
                orderState = "3";
            else if(strStatus=="处理中")
                orderState = "4";
            else if(strStatus=="完成")
                orderState = "5";
            else if (strStatus == "作废")
                orderState = "6";
            else
                orderState="";

            string type = string.Empty;
            if (strType == "普通订单")
                type = "1";
            else if (strType == "发货流程")
                type = "2";
            else if (strType == "确认单（备货）")
                type = "3";
            else
                type = "";

            //状态
            if (!string.IsNullOrEmpty(orderState))
            {
                StrFilter.AppendFormat(" and state =  '{0}'", orderState);
            }

            //类型
            if (!string.IsNullOrEmpty(type))
            {
                StrFilter.AppendFormat(" and orderType =  '{0}'", type);
            }

            //编码
            if (!string.IsNullOrEmpty(strCode))
            {
                StrFilter.AppendFormat(" AND PURCHASE_CODE LIKE '%{0}%'", strCode);
            }

            //企业
            if (!string.IsNullOrEmpty(strSearchField))
            {
                if(strSearchField=="配送企业")
                    StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' or SENDER_NAME_ABBR LIKE '%{0}%')", strSearchKey);
                else if(strSearchField=="经销企业")
                    StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' or SALER_NAME_ABBR LIKE '%{0}%')", strSearchKey);
            
            }

            //开始时间
            if (!string.IsNullOrEmpty(strStartDate))
            {
                StrFilter.AppendFormat(" AND create_date >= '{0}'", strStartDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(strEndDate))
            {
                StrFilter.AppendFormat(" AND create_date <= '{0}'", strEndDate + " 23:59:59");
            }

            if (cachedDataView != null)
            {
                this.gcOrderList.BeginUpdate();
                this.cachedDataView.RowFilter = StrFilter.ToString();
                this.cachedDataView.Sort = " create_date desc";
                this.gcOrderList.EndUpdate();
            }
            gridView3_FocusedRowChanged(null, null);
        }
        #endregion

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            OutOrderReceive frm = new OutOrderReceive();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gridView3.GetRow(gridView3.FocusedRowHandle) != null)
            {
                DataTable dt = ReportBLL.GetInstance().GetOrderReportData(gridView3.GetDataRow(gridView3.FocusedRowHandle)["id"].ToString().Trim());
                FrmPrint frmPrint = new FrmPrint(new OrderXtraReport(),dt);
                frmPrint.ShowDialog();
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null )
            {
                string state = dr["Order_State"] == null ? "0" : dr["Order_State"].ToString();
                if (state == "处理中" || state == "确认")
                {
                    this.btnDo.Text = "处理";
                }
                else
                {
                    this.btnDo.Text = "查看";
                }
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
                if (gridView3.FocusedColumn.FieldName == "sender_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["sender_name"].ToString());
                else if (gridView3.FocusedColumn.FieldName == "create_date")
                    toolTipLocationControl_ToolTipLocationChanged(dr["create_date"].ToString());
               
            }

           
        }

        private void deEndDate_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void gcOrderList_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            btnView_Click(null,null);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }






    }
}