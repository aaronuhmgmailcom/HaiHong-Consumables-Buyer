//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdStockUpItemForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单明细查看
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

using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdProduct;
using Emedchina.TradeAssistant.Client.Base;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.StockUp
{
    /// <summary>
    /// 备货单查看
    /// </summary>
    public partial class OrdStockUpItemForm : BaseForm
    {
        //备货单ID
        private string strStockUpID = null;

        //备货单明细DT
        private DataTable StockUpItemDt = null;

        //备货单主表对象
        private OrdStockUpModel ordStockUpModel = null;

        public OrdStockUpItemForm()
        {
            InitializeComponent();
        }

        public OrdStockUpItemForm(string StockUpID)
        {
            strStockUpID = StockUpID;
            InitializeComponent();
            IniData(strStockUpID);
        }

        /// <summary>
        /// 初始化显示信息
        /// </summary>
        /// <param name="strStockUpID"></param>
        private void IniData(string strStockUpID)
        {
            ordStockUpModel = OrdStockUpBLL.GetInstance().GetOrdStockUpModel(strStockUpID);

            if (ordStockUpModel != null)
            {
                this.labCode.Text = ordStockUpModel.Code;
                this.labCreateUserName.Text = ordStockUpModel.Create_User_Name;
                this.labStateName.Text = ordStockUpModel.State_Name;
                this.labSenderName.Text = ordStockUpModel.Sender_Name;
                this.labSendDate.Text = ordStockUpModel.Create_Date;
                this.labStateName.Text = ordStockUpModel.State_Name;
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //获取备货单明细查询数据集
            StockUpItemDt = OrdStockUpItemBLL.GetInstance().GetStockUpItemList(strStockUpID);

            if (StockUpItemDt != null)
            {
                this.bindingSource1.DataSource = StockUpItemDt.DefaultView;
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdStockUpItemForm_Load(object sender, EventArgs e)
        {
            //绑定备货单明细
            DataBind();
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
        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.gVStockUpItem.RowCount == 0)
                return;

            DataRow dr = this.gVStockUpItem.GetDataRow(this.gVStockUpItem.FocusedRowHandle);

            string strProjectProductID = dr["PROJECT_PROD_ID"].ToString();
            string strSpec = dr["SPEC"].ToString();
            string strModel = dr["MODEL"].ToString();

            ViewOrdProductForm frm = new ViewOrdProductForm(strProjectProductID, strSpec, strModel);
            frm.ShowDialog();
        }

        /// <summary>
        /// 获取当前选择ID
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view, string colname)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(colname);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockUpItem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gVStockUpItem_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gVStockUpItem.RowCount + " 条数据";
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

        private void gVStockUpItem_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVStockUpItem.GetDataRow(this.gVStockUpItem.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVStockUpItem.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

    }
}