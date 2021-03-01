//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	PurchaseCommerceForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	采购商品查询
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

using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.DataFound
{
    /// <summary>
    /// 采购商品查询
    /// </summary>
    public partial class PurchaseCommerceForm : BaseForm
    {
        #region 变量定义区
        //公告信息数据集对象
        private DataTable PurchaseItemDt = null;
        #endregion

        #region 构造
        public PurchaseCommerceForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PurchaseCommerceForm_Load(object sender, EventArgs e)
        {
            DataBind();
            //给查询时间赋默认值
            this.StartDate.EditValue = DateTime.Now.AddMonths(-3);
            this.EndDate.EditValue = DateTime.Now;
        }
        #endregion

        #region 关闭事件
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 数据查询绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {           
            //获取采购目录查询数据集
            PurchaseItemDt = PurchaseItemBLL.GetInstance().GetPurchaseItemDt();

            PurchaseItemDt.DefaultView.Sort = " Purchase_Date DESC";

            if (PurchaseItemDt != null)
            {
                this.bindingSource1.DataSource = PurchaseItemDt.DefaultView;
            }
        }
        #endregion

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            this.PurchaseItemDt.DefaultView.RowFilter = "";

            if (this.PurchaseItemDt.DefaultView.Count < 1)
                return;

            string strProductName = this.txtProductName.Text.Trim();    //商品名称
            string strSpec = this.txtSpec.Text.Trim();                  //规格
            string strModel = this.txtModel.Text.Trim();                //型号
            string strManuFacture_Name = this.txtManuName.Text.Trim();  //生产企业
            string strSender_Name = this.txtMeasureCor.Text.Trim();     //配送企业
            string strSaler_Name = this.txtSalerName.Text.Trim();       //经销企业

            string strStartDate = this.StartDate.Text;                  //采购开始时间
            string strEndDate = this.EndDate.Text;                      //采购结束时间

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //商品名称
            if (!string.IsNullOrEmpty(strProductName))
            {
                StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", strProductName);
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
                StrFilter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' or MANU_NAME_ABBR LIKE '%{0}%' or MANU_NAME_SPELL_ABBR LIKE '%{0}%' or MANU_NAME_WB LIKE '%{0}%')", strManuFacture_Name);
            }

            //配送企业
            if (!string.IsNullOrEmpty(strSender_Name))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' or SENDER_NAME_ABBR LIKE '%{0}%' or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' or SENDER_NAME_WB LIKE '%{0}%')", strSender_Name);
            }

            //经销企业
            if (!string.IsNullOrEmpty(strSaler_Name))
            {
                StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' or SALER_NAME_ABBR LIKE '%{0}%' or SALER_NAME_SPELL_ABBR LIKE '%{0}%' or SALER_NAME_WB LIKE '%{0}%')", strSaler_Name);
            }

            ////是否配件
            //if (!string.IsNullOrEmpty(CmbIsFitt.EditValue.ToString()) && !(CmbIsFitt.EditValue.ToString().Equals("全部")))
            //{
            //    StrFilter.AppendFormat(" AND Isfitt = '{0}'", CmbIsFitt.EditValue.ToString());
            //}

            //开始时间
            if (!string.IsNullOrEmpty(strStartDate))
            {
                StrFilter.AppendFormat(" AND PURCHASE_DATE >= '{0}'", strStartDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(strEndDate))
            {
                StrFilter.AppendFormat(" AND PURCHASE_DATE <= '{0}'", strEndDate + " 23:59:59");
            }

            if (PurchaseItemDt.DefaultView != null)
            {
                this.PurchaseItemDt.DefaultView.RowFilter = StrFilter.ToString();
            }
        }
        #endregion

        #region 按条件查询事件
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        #endregion

        #region 查询按钮事件
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare((DateTime)this.EndDate.DateTime, (DateTime)this.StartDate.DateTime) < 0)
            {
                XtraMessageBox.Show("结束时间必须大于开始时间！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Filter();
        }
        #endregion

        #region 加入序号及更改记录数
        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVPurchaseCommerce_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gVPurchaseCommerce_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gVPurchaseCommerce.RowCount + " 条数据";
        }
        #endregion

        #region 打印
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmPrint frmPrint = new FrmPrint(new PurchaseCommeraceXtraReport(base.CurrentUserOrgName + "采购商品查询报表"), ((DataView)this.bindingSource1.DataSource).Table);
            frmPrint.ShowDialog();
        }
        #endregion

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

        private void gVPurchaseCommerce_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVPurchaseCommerce.GetDataRow(this.gVPurchaseCommerce.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVPurchaseCommerce.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVPurchaseCommerce.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVPurchaseCommerce.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else if (this.gVPurchaseCommerce.FocusedColumn.FieldName.ToUpper() == "PURCHASE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["Purchase_Date"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

    }
}