//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	QueryOrderItem.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-10-8
//	功能描述:	订单信息查询
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
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.TradeManage;
using Emedchina.TradeAssistant.Client.DAL.TradeManage;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;
using DevExpress.Utils;

namespace Emedchina.TradeAssistant.Client.UI.TradeManage
{
    public partial class QueryOrderItem : BaseForm
    {
        private DataTable DtOrderItem;
        public QueryOrderItem()
        {
            InitializeComponent();
        }

        private void QueryOrderItem_Load(object sender, EventArgs e)
        {
            bindingList();
            deStartDate.EditValue = DateTime.Now.AddMonths(-1);
            deEndDate.EditValue = DateTime.Now;
        }

        private void bindingList()
        {
            LogedInUser CurrentUser = ClientSession.GetInstance().CurrentUser;
            DtOrderItem = QueryOrderItemBLL.GetInstance().GetQueryOrderItemInfoDt(CurrentUser);

            base.InitFromCacheByData(DtOrderItem);

            try
            {
                this.bindingSourceOrderItem.DataSource = null;
                this.bindingSourceOrderItem.DataSource = DtOrderItem.DefaultView;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置ItemFilter过滤列表
        /// </summary>
        private void ItemFilter()
        {
            string strCommerce_Name = this.teProductName.Text.Trim();//商品名
            string strSpec = this.teGGBZ.Text.Trim();//规格
            string strModel = this.teLotNo.Text.Trim();//型号
            string strManuFacture_Name = this.tePruducter.Text.Trim();//生产企业
            string strSender_Name = this.teSender.Text.Trim();//配送企业
            string strSaler_Name = this.teSaler.Text.Trim();//经销企业

            string strStartDate = this.deStartDate.DateTime.ToShortDateString();
            string strEndDate = this.deEndDate.DateTime.ToShortDateString();


            StringBuilder StrFilter = new StringBuilder();
            StrFilter.Append("1=1");

            //商品名称
            if (!string.IsNullOrEmpty(strCommerce_Name))
            {
                StrFilter.AppendFormat(" AND (COMMON_NAME LIKE '%{0}%' or PRODUCT_NAME LIKE '%{0}%' or product_Code LIKE '%{0}%' or ABBR_PY LIKE '%{0}%' or ABBR_WB LIKE '%{0}%')", strCommerce_Name);
            }

            //规格
            if (!string.IsNullOrEmpty(strSpec))
            {
                StrFilter.AppendFormat(" AND Spec LIKE '%{0}%'", strSpec);
            }

            //型号
            if (!string.IsNullOrEmpty(strModel))
            {
                StrFilter.AppendFormat(" AND Model LIKE '%{0}%'", strModel);
            }


            //生产企业
            if (!string.IsNullOrEmpty(strManuFacture_Name))
            {
                StrFilter.AppendFormat(" AND (MANUFACTURE_NAME LIKE '%{0}%' or MANUFACTURE_NAME_ABBR LIKE '%{0}%')", strManuFacture_Name);
            }

            //配送企业
            if (!string.IsNullOrEmpty(strSender_Name))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' or SENDER_NAME_ABBR LIKE '%{0}%')", strSender_Name);
            }

            //经销企业
            if (!string.IsNullOrEmpty(strSaler_Name))
            {
                StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' or SALER_NAME_ABBR LIKE '%{0}%')", strSaler_Name);
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


            this.cachedDataView.RowFilter = StrFilter.ToString();
            this.cachedDataView.Sort = " create_date desc";

        }

        private void sbSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare((DateTime)this.deEndDate.DateTime, (DateTime)this.deStartDate.DateTime) < 0)
            {
                XtraMessageBox.Show("结束时间必须大于开始时间！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ItemFilter();
        }

        private void teProductName_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void teGGBZ_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void teLotNo_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void tePruducter_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void teSaler_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void teSender_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void deStartDate_EditValueChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void deEndDate_EditValueChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gridView3.RowCount + " 条数据";
        }

        private void sbPrint_Click(object sender, EventArgs e)
        {
            FrmPrint frmPrint = new FrmPrint(new QueryOrderItemXtraReport(base.CurrentUserOrgName + "订单商品查询报表"), base.cachedDataView.Table);
            frmPrint.ShowDialog();
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
                if (gridView3.FocusedColumn.FieldName.ToLower() == "sender_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["sender_name"].ToString());
                else if (gridView3.FocusedColumn.FieldName.ToLower() == "create_date")
                    toolTipLocationControl_ToolTipLocationChanged(dr["create_date"].ToString());
                else if(gridView3.FocusedColumn.FieldName.ToLower() == "saler_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["saler_name"].ToString());
                else if (gridView3.FocusedColumn.FieldName.ToLower() == "manufacture_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANUFACTURE_NAME"].ToString());

            }


        }

        private void teProductName_EditValueChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }
       

    }
}