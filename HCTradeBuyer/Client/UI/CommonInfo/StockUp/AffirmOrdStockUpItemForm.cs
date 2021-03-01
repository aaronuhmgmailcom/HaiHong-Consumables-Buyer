//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	AffirmOrdStockUpItemForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单明细 查看、确认
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
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdProduct;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.StockUp
{
    /// <summary>
    /// 备货单明细 查看、确认
    /// </summary>
    public partial class AffirmOrdStockUpItemForm : BaseForm
    {
        //修改标志
        public bool EditFlag = false;

        //备货单ID
        private string strStockUpID = null;

        //备货单明细DT
        private DataTable StockUpItemDt = null;

        //备货单主表对象
        private OrdStockUpModel ordStockUpModel = null;

        //获取当取用户对象
        LogedInUser CurrentUser = null;

        public AffirmOrdStockUpItemForm()
        {
            InitializeComponent();
        }

        public AffirmOrdStockUpItemForm(string StockUpID)
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

            StockUpItemDt.DefaultView.Sort = " CREATE_DATE DESC";

            this.bindingSource1.DataSource = StockUpItemDt.DefaultView;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AffirmOrdStockUpItemForm_Load(object sender, EventArgs e)
        {
            CurrentUser = base.CurrentUser;

            //绑定备货单明细
            DataBind();
        }

        /// <summary>
        /// 商品查看事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.gVStockUpItem.RowCount == 0)
                return;

            //string strProjectProductID = GetGridViewColValue(this.gVStockUpItem, "PROJECT_PROD_ID");
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
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 表格数据验证
        /// </summary>
        /// <returns></returns>
        private bool ValiData_ByGrid(out string Error)
        {
            Error = string.Empty;
            bool flag = true;
            DataTable Dt = StockUpItemDt.DefaultView.ToTable();

            int selCount = 0;
            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string strState = dr["STATE"].ToString();
                    if (strState.Equals("2"))
                    {
                        Error="数据已确认，请重新选择！";
                        return false;
                    }
                    string strBarcodeOld = dr["BARCODE"].ToString();    //修改前条码
                    string strBarcode = dr["barcode_Back"].ToString();  //确认条码
                    if (!strBarcodeOld.Equals(strBarcode))
                    {
                        Error = "条码校验出错，请重新输入！";
                        return false;
                    }
                }
            }
            if (selCount == 0)
            {
                Error = "请选择记录后，再进行备货单确认操作！";
                return false;
            }

            return flag;
        }

        /// <summary>
        /// 备货单确认事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAffirm_Click(object sender, EventArgs e)
        {
            //提示信息
            //if (XtraMessageBox.Show("确认是否备货单确认操作？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    return;

            //进行数据验证
            string strError = string.Empty;
            if (!ValiData_ByGrid(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //保存到二级库存表
                List<OrdSecondAyplnvModel> ListOrdSecondAyplnvModel = new List<OrdSecondAyplnvModel>();

                //获取已选择数据集
                DataTable dt = StockUpItemDt.DefaultView.ToTable();

                foreach (DataRow dr in dt.Rows)
                {
                    string strSel = dr["Sel"].ToString();

                    if (strSel.Equals("1"))
                    {
                        OrdSecondAyplnvModel model = GetOrdSecondAyplnvModel(dr);

                        ListOrdSecondAyplnvModel.Add(model);
                    }
                }
                SaveListOrdSecondAyplnvModelList(ListOrdSecondAyplnvModel);
                //----------------------------------------------------------------------------------

                //2.修改主表及明细表状态----------------------------------------------------
                List<OrdStockUpItemModel> ListOrdStockUpItemModel = new List<OrdStockUpItemModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    string strSel = dr["Sel"].ToString();

                    if (strSel.Equals("1"))
                    {
                        OrdStockUpItemModel model = GetOrdStockUpItemModel(dr);

                        ListOrdStockUpItemModel.Add(model);
                    }
                }

                if (ListOrdStockUpItemModel.Count > 0)
                {
                    OrdStockUpItemBLL.GetInstance().UpdateBarcodeOrdStockUpItemList(ListOrdStockUpItemModel,strStockUpID);
                }
                //----------------------------------------------------------------------------------

                XtraMessageBox.Show("备货单确认成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //备货单确认后刷新数据集
                RefreshData();
                //更新标题
                IniData(strStockUpID);

                EditFlag = true;

                //this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("备货单确认失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //备货单确认后刷新数据集
        private void RefreshData()
        {
            foreach (DataRow dr in StockUpItemDt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    dr["Statename"] = "已确认";
                    dr["STATE"] = "2";
                }
            }
        }

        /// <summary>
        /// 保存到二级库存表
        /// </summary>
        /// <param name="ListOrdHitCommModel"></param>
        private void SaveListOrdSecondAyplnvModelList(List<OrdSecondAyplnvModel> ListOrdSecondAyplnvModel)
        {
            if (ListOrdSecondAyplnvModel.Count == 0)
                return;

            try
            {
                SecondAyplnvBLL.GetInstance().SaveOrdSecondAyplnvModel(ListOrdSecondAyplnvModel,this.CurrentUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取当前二级库存对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdSecondAyplnvModel GetOrdSecondAyplnvModel(DataRow dr)
        {
            OrdSecondAyplnvModel model = new OrdSecondAyplnvModel();

            model.Stock_Item_Id = dr["ID"].ToString();
            model.Project_Id = dr["PROJECT_ID"].ToString();
            model.Project_Product_Id = dr["PROJECT_PROD_ID"].ToString();
            model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            model.Buyer_Id = base.CurrentUserOrgId;

            model.Saler_Id = dr["SALER_ID"].ToString();
            model.Sender_Id = dr["SENDER_ID"].ToString();
            if (!dr["PBNO"].ToString().Equals("-"))
                model.Pbno = dr["PBNO"].ToString();
            model.Send_Batch_No = dr["SEND_BATCH_NO"].ToString();
            model.Instore_Batch_No = dr["INSTORE_BATCH_NO"].ToString();
            model.Sender_Name = dr["SENDER_NAME"].ToString();
            model.Spec_Id = dr["SPEC_ID"].ToString();
            model.Model_Id = dr["MODEL_ID"].ToString();
            model.Barcode = dr["BARCODE"].ToString();
            model.Price = dr["PRICE"].ToString();
            if (!dr["BATCH_NO"].ToString().Equals("-"))
                model.Batch_No = dr["BATCH_NO"].ToString();
            if (!dr["VALID_DATE"].ToString().Equals("-"))
                model.Valid_Date = dr["VALID_DATE"].ToString();
            model.Num = dr["NUM"].ToString();
            model.Remark = dr["REMARK"].ToString();
            model.State = dr["STATE"].ToString(); ;

            return model;
        }
        
        /// <summary>
        /// 获取当前备货单明细对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdStockUpItemModel GetOrdStockUpItemModel(DataRow dr)
        {

            OrdStockUpItemModel model = new OrdStockUpItemModel();

            //model.Barcode = dr["BARCODE"].ToString();
            //model.Barcode_Back = dr["Barcode_Back"].ToString();
            model.Id = dr["ID"].ToString();
            model.Stock_Id = dr["Stock_Id"].ToString();

            //model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            //model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            //model.Store_Room_Name = dr["STORE_ROOM_NAME"].ToString();

            return model;

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

        #region 全选事件
        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkAllSel_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllSel.Checked)
                AllSelect("1");
            else
                AllSelect("0");
        }
        
        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="state"></param>
        private void AllSelect(string state)
        {
            foreach (DataRow dr in StockUpItemDt.Rows)
            {
                dr["Sel"] = state;
            }
        }
        #endregion

        #region 记录数改变事件
        /// <summary>
        /// 记录数改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockUpItem_RowCountChanged(object sender, EventArgs e)
        {
            LblCount.Text = "    共 " + this.gVStockUpItem.RowCount + " 条数据";
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

        #region 编辑时 自动选择框
        /// <summary>
        /// 编辑时 自动选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVStockUpItem_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = this.gVStockUpItem.GetDataRow(this.gVStockUpItem.FocusedRowHandle);

            if (dr != null)
            {
                if (this.gVStockUpItem.FocusedColumn.FieldName.ToUpper() == "SEL")
                {
                    if (dr["Sel"].Equals("1"))
                    {
                        dr["Sel"] = "0";
                    }
                    else
                    {
                        dr["Sel"] = "1";
                    }
                    return;
                }
                else if (this.gVStockUpItem.FocusedColumn.FieldName.ToUpper() == "BARCODE_BACK")
                {
                    dr["Sel"] = "1";
                    return;
                }
                else if (this.gVStockUpItem.FocusedColumn.FieldName.ToUpper() == "REMARK")
                {
                    dr["Sel"] = "1";
                    return;
                }
            }
        }
        #endregion

    }
}