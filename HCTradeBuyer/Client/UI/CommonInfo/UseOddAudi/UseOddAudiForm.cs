//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	UseOddAudiForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	使用单审核
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
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdProduct;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.UseOddAudi
{
    /// <summary>
    /// 使用单审核
    /// </summary>
    public partial class UseOddAudiForm : BaseForm
    {
        #region 变量定义区
        //采购单对象
        private OrdPurchaseModel ordPurchaseModel = null;

        //订单对象
        private OrdOrderModel ordOrderModel = null;

        //库存商品列表数据集
        private DataTable OrdSecondAyplnvDt = null;

        //消耗商品列表数据集
        private DataTable ConsumeCommDt = null;

        //二级库存使用表对象列表
        List<OrdSecondAyrlnvUseModel> ListOrdSecondAyrlnvUseModel = null;

        //获取当取用户对象
        LogedInUser CurrentUser = null;

        //库房默认ID
        private int storeId;

        #endregion

        #region 构造
        public UseOddAudiForm()
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
        private void UseOddAudiForm_Load(object sender, EventArgs e)
        {
            CurrentUser = base.CurrentUser;

            //绑定表格中下拉框（库房）
            InitGrid_Cmb();

            //绑定库存商品列表数据集
            DataBindAyplnv();
            
            //绑定消耗商品列表数据集
            DataBindConsume();

            ListOrdSecondAyrlnvUseModel = new List<OrdSecondAyrlnvUseModel>();

            ordPurchaseModel = new OrdPurchaseModel();

            ordOrderModel = new OrdOrderModel();

 
        }
        #endregion

        #region 商品数据绑定
        //绑定库存商品列表数据集
        private void DataBindAyplnv()
        {
            OrdSecondAyplnvDt = UseOddAudiBLL.GetInstance().GetOrdSecondAyplnvList(this.CurrentUser);

            foreach (DataRow dr in this.OrdSecondAyplnvDt.Rows)
            {
                if (string.IsNullOrEmpty(dr["STORE_ROOM_ID"].ToString()))
                {
                    dr["STORE_ROOM_ID"] = storeId;
                }
            }

            this.bindingSource1.DataSource = OrdSecondAyplnvDt.DefaultView;
        }

        //绑定消耗商品列表数据集
        private void DataBindConsume()
        {
            ConsumeCommDt = UseOddAudiBLL.GetInstance().GetConsumeCommList();
            this.bindingSource2.DataSource = ConsumeCommDt.DefaultView;
        }
        #endregion

        #region 初始化表格下拉框

        /// <summary>
        /// 初始化表格下拉框
        /// </summary>
        private void InitGrid_Cmb()
        {
            //初始化库房下拉框
            InitData_StoneInfo();
        }

        /// <summary>
        /// 初始化库房下拉框
        /// </summary>
        private void InitData_StoneInfo()
        {
            DataTable dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(CurrentUser.UserOrg.Id);

            //排序
            //dtStone.DefaultView.Sort = " STORE_NAME ASC";

            if (dtStone != null)
            {
                this.StoreRoomLue.DataSource = dtStone.DefaultView;

                storeId = Convert.ToInt32(dtStone.Rows[0]["STORE_ID"].ToString().Trim());
            }
        }

        #endregion

        #region 加入序号
        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVOrdSecondAyplnv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gVConsumeComm_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }
        #endregion

        #region 页面改变事件
        /// <summary>
        /// 页面改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //if (xtraTabControl2.SelectedTabPageIndex == 0)
            //{
            //    //绑定库存商品列表数据集
            //    DataBindAyplnv();
            //}
            //else
            //{
            //    //绑定消耗商品列表数据集
            //    DataBindConsume();
            //}
        }
        #endregion

        #region 使用事件方法
        /// <summary>
        /// 二级库存使用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUse_Click(object sender, EventArgs e)
        {
            if (OrdSecondAyplnvDt.DefaultView.Count == 0)
                return;

            //进行数据验证
            string strError = string.Empty;
            if (!ValiData_ByGrid(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            if (XtraMessageBox.Show("确认是否使用？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                //添加至采购目录
                AddHitComm();

                //保存二级库存使用操作
                ListOrdSecondAyrlnvUseModel = GetListOrdSecondAyrlnvUseModel();
                SaveOrdSecondAyrlnvUseModelList(ListOrdSecondAyrlnvUseModel);

                //刷新库存商品列表数据集
                DataBindAyplnv();

                //绑定消耗商品列表数据集
                DataBindConsume();

                XtraMessageBox.Show("二级库存使用成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("二级库存使用失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 表格数据验证
        /// </summary>
        /// <returns></returns>
        private bool ValiData_ByGrid(out string Error)
        {
            Error = string.Empty;
            bool flag = true;
            DataTable Dt = OrdSecondAyplnvDt.DefaultView.ToTable();

            int selCount = 0;
            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string factAmount = dr["FACT_AMOUNT"].ToString();   //使用数量
                    string num = dr["NUM"].ToString();                  //库存数量
                    if (string.IsNullOrEmpty(factAmount))
                    {
                        Error = "请输入欲使用数量！";
                        return false;
                    }
                    else if (Convert.ToDecimal(factAmount) <=0)
                    {
                        Error = "欲使用数量不能为0，请重新输入！";
                        return false;
                    }
                    else if (string.IsNullOrEmpty(dr["STORE_ROOM_ID"].ToString()))
                    {
                        Error = "请选择库房！";
                        return false;
                    }
                    else if (Convert.ToDecimal(num) < Convert.ToDecimal(factAmount))
                    {
                        Error = "欲使用数量不能大于库存数量！";
                        return false;
                    }
                }
            }
            if (selCount == 0)
            {
                Error = "请选择记录后，再进行二级库存使用操作！";
                return false;
            }

            return flag;
        }

        #region 添加到采购供应目录中
        private void AddHitComm()
        {
            //当采购供应目录不存在该产品时，作新增操作
            List<OrdHitCommMode> ListOrdHitCommModel = new List<OrdHitCommMode>();

            DataTable Dt = OrdSecondAyplnvDt.DefaultView.ToTable();

            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    //当该产品不在采购目录表中存在 作增加操作
                    if (string.IsNullOrEmpty(dr["ordHitCommId"].ToString()))
                    {
                        OrdHitCommMode model = GetOrdHitCommModel(dr);
                        ListOrdHitCommModel.Add(model);
                    }
                }
            }

            //当采购供应目录不存在该产品时，作新增操作
            if (ListOrdHitCommModel.Count > 0)
            {
                StockListBLL.GetInstance().SaveOrdHitCommListModel(ListOrdHitCommModel, this.CurrentUser);
            }
        }

        /// <summary>
        /// 获取当前采购供应目录对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdHitCommMode GetOrdHitCommModel(DataRow dr)
        {
            OrdHitCommMode model = new OrdHitCommMode();

            model.Project_Id = dr["PROJECT_ID"].ToString();
            model.Project_Product_Id = dr["PROJECT_PROD_ID"].ToString();
            model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            model.Cont_Product_Id = dr["CONT_PRODUCT_ID"].ToString();
            model.Spec_Id = dr["SPEC_ID"].ToString();
            model.Model_Id = dr["MODEL_ID"].ToString();
            model.Spec = dr["SPEC"].ToString();
            model.Model = dr["MODEL"].ToString();
            model.Measure = dr["BASE_MEASURE"].ToString();
            model.ManuName = dr["MANU_NAME"].ToString();
            model.SalerName = dr["SALER_NAME"].ToString();
            model.Commerce_Name = dr["COMMERCE_NAME"].ToString();
            model.Common_Name = dr["COMMON_NAME"].ToString();
            model.Product_Name = dr["PRODUCT_NAME"].ToString();
            model.Abbr_py = dr["ABBR_PY"].ToString();
            model.Abbr_wb = dr["ABBR_WB"].ToString();
            if (!dr["BRAND"].ToString().Equals("-"))
                model.Brand = dr["BRAND"].ToString();
            model.Price = dr["PRICE"].ToString();
            model.Code = dr["CODE"].ToString();
            model.GoodsNo = dr["GOODS_NO"].ToString();
            if (!dr["BARCODE"].ToString().Equals("-"))
                model.Barcode = dr["BARCODE"].ToString();
            model.Base_Measure_Spec = dr["BASE_MEASURE_SPEC"].ToString();
            model.Base_Measure_Mater = dr["BASE_MEASURE_MATER"].ToString();
            model.Max_Price = dr["MAX_PRICE"].ToString();
            model.Manu_Id = dr["MANU_ID"].ToString();
            model.Saler_Id = dr["SALER_ID"].ToString();
            model.Sender_Id = dr["SENDER_ID"].ToString();

            //model.Valid_Date = dr["VALID_DATE"].ToString();
            if (!dr["BATCH_NO"].ToString().Equals("-"))
                model.Batch_No = dr["BATCH_NO"].ToString();
            //model.Num = dr["NUM"].ToString();
            model.State = "1";
            if (!dr["PBNO"].ToString().Equals("-"))
                model.Pbno = dr["PBNO"].ToString();
            model.Send_Batch_No = dr["SEND_BATCH_NO"].ToString();
            model.Instore_Batch_No = dr["INSTORE_BATCH_NO"].ToString();

            model.ManuNameAbbr = dr["MANU_NAME_ABBR"].ToString();
            model.Buyer_Id = dr["BUYER_ID"].ToString();
            model.SalerNameAbbr = dr["SALER_NAME_ABBR"].ToString();
            model.Measure = dr["DEFAULT_MEASURE"].ToString();
            model.DefaultMeasureEx = dr["DEFAULT_MEASURE_EX"].ToString();
            model.Instru_Code = dr["INSTRU_CODE"].ToString();
            model.Instru_Name = dr["INSTRU_NAME"].ToString();
            model.RegNo = dr["REG_NO"].ToString();
            model.RegValidDate = dr["REG_VALID_DATE"].ToString();
            //库房ID
            model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            model.StoreRoomName = dr["STORE_ROOM_NAME"].ToString();

            return model;
        }
        #endregion

        /// <summary>
        /// 保存到二级库存使用表中
        /// </summary>
        /// <param name="ListOrdSecondAyrlnvUseModel"></param>
        private void SaveOrdSecondAyrlnvUseModelList(List<OrdSecondAyrlnvUseModel> ListOrdSecondAyrlnvUseModel)
        {
            if (ListOrdSecondAyrlnvUseModel.Count == 0)
                return;

            try
            {
                OrdSecondAyrlnvUseBLL.GetInstance().SaveOrdSecondAyplnvModel(ListOrdSecondAyrlnvUseModel, CurrentUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 获取二级库存使用单对象列表
        /// </summary>
        /// <returns></returns>
        private List<OrdSecondAyrlnvUseModel> GetListOrdSecondAyrlnvUseModel()
        {
            ListOrdSecondAyrlnvUseModel.Clear();

            DataTable dt = OrdSecondAyplnvDt.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    string strError = string.Empty;

                    OrdSecondAyrlnvUseModel model = GetOrdSecondAyrlnvUseModel(dr);

                    ListOrdSecondAyrlnvUseModel.Add(model);
                }
            }
            
            return ListOrdSecondAyrlnvUseModel;
        }

        /// <summary>
        /// 获取二级库存使用单对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdSecondAyrlnvUseModel GetOrdSecondAyrlnvUseModel(DataRow dr)
        {
            OrdSecondAyrlnvUseModel model = new OrdSecondAyrlnvUseModel();

            //二级库存ID
            model.SecondId = dr["ID"].ToString();
            model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            model.Project_Id = dr["PROJECT_ID"].ToString();
            model.Project_Product_Id = dr["PROJECT_PROD_ID"].ToString();
            model.Goods_No = dr["GOODS_NO"].ToString();
            model.Barcode = dr["BARCODE"].ToString();
            if (string.IsNullOrEmpty(model.Barcode))
                model.Barcode = " ";
            if (!dr["PBNO"].ToString().Equals("-"))
                model.Pbno = dr["PBNO"].ToString();
            model.Send_Batch_No = dr["SEND_BATCH_NO"].ToString();
            model.Instore_Batch_No = dr["INSTORE_BATCH_NO"].ToString();
            model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            model.Store_Room_Name = dr["STORE_ROOM_NAME"].ToString();
            model.Arrive_Date = dr["CREATE_DATE"].ToString();
            model.Price = dr["PRICE"].ToString();
            model.Fact_Amount = Convert.ToInt16(dr["FACT_AMOUNT"].ToString());
            model.Fact_Sum = Convert.ToDecimal(model.Fact_Amount) * Convert.ToDecimal(model.Price);
            model.Status = "1";//使用标记
            model.Buyer_Id = this.CurrentUser.UserOrg.Id;
            model.Sender_Id = dr["SENDER_ID"].ToString();
            model.Descriptions = "";
            //库存数量
            model.Stock_Num = Convert.ToDecimal(dr["NUM"].ToString());

            return model;
        }

        #endregion

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            //商品名称
            string strProductName = this.txtProductName.Text.Trim();
            //规格
            string strSpec = this.txtSpec.Text.Trim();
            //型号
            string strModel = this.txtModel.Text.Trim();
            //条码
            string strBarcode = this.txtBarcode.Text.Trim();
            //生产企业 经销企业 配送企业
            string strName = this.txtName.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //商品名称
            if (!string.IsNullOrEmpty(strProductName))
            {
                StrFilter.AppendFormat(" AND PRODUCT_NAME LIKE '%{0}%'", strProductName);
            }

            //规格
            if (!string.IsNullOrEmpty(strSpec))
            {
                StrFilter.AppendFormat(" AND SPEC LIKE '%{0}%'", strSpec);
            }

            //型号
            if (!string.IsNullOrEmpty(strModel))
            {
                StrFilter.AppendFormat(" AND MODEL LIKE '%{0}%'", strModel);
            }

            //条码
            if (!string.IsNullOrEmpty(strBarcode))
            {
                StrFilter.AppendFormat(" AND BARCODE LIKE '%{0}%'", strBarcode);
            }

            //生产企业 经销企业 配送企业
            if (!string.IsNullOrEmpty(strName))
            {
                switch (cmbName.SelectedIndex)
                {
                    case 0:
                        StrFilter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' Or MANU_NAME_ABBR LIKE '%{0}%' Or MANU_NAME_SPELL_ABBR LIKE '%{0}%' Or MANU_NAME_WB LIKE '%{0}%')", strName);
                        break;
                    case 1:
                        StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' Or SALER_NAME_ABBR LIKE '%{0}%' Or SALER_NAME_SPELL_ABBR LIKE '%{0}%' Or SALER_NAME_WB LIKE '%{0}%')", strName);
                        break;
                    case 2:
                        StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' Or SENDER_NAME_ABBR LIKE '%{0}%' Or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' Or SENDER_NAME_WB LIKE '%{0}%')", strName);
                        break;
                }
            }

            if (xtraTabControl2.SelectedTabPageIndex == 0)
            {
                if (OrdSecondAyplnvDt != null)
                {
                    if (OrdSecondAyplnvDt.DefaultView != null)
                    {
                        this.OrdSecondAyplnvDt.DefaultView.RowFilter = StrFilter.ToString();
                    }
                }
            }
            else
            {
                if (ConsumeCommDt != null)
                {
                    if (ConsumeCommDt.DefaultView != null)
                    {
                        this.ConsumeCommDt.DefaultView.RowFilter = StrFilter.ToString();
                    }
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

        #region 查看商品信息

        /// <summary>
        /// 查看详细信息 消耗商品列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView2_Click(object sender, EventArgs e)
        {
            if (this.gVConsumeComm.RowCount == 0)
                return;

            //string strProjectProductId = GetGridViewColValue(this.gVConsumeComm, "PROJECT_PRODUCT_ID");

            DataRow dr = this.gVConsumeComm.GetDataRow(this.gVConsumeComm.FocusedRowHandle);
            string strProjectProductID = dr["PROJECT_PRODUCT_ID"].ToString();
            string strSpec = dr["SPEC"].ToString();
            string strModel = dr["MODEL"].ToString();

            ViewOrdProductForm frm = new ViewOrdProductForm(strProjectProductID, strSpec, strModel);
            frm.ShowDialog();
        }

        /// <summary>
        /// 查看详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView1_Click(object sender, EventArgs e)
        {
            if (this.gVOrdSecondAyplnv.RowCount == 0)
                return;

            //string strProjectProductId = GetGridViewColValue(this.gVOrdSecondAyplnv, "PROJECT_PROD_ID");

            DataRow dr = this.gVOrdSecondAyplnv.GetDataRow(this.gVOrdSecondAyplnv.FocusedRowHandle);

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

        #endregion

        #region 审核通过

        //审核数据验证
        private bool Validate_Audi(out string Error)
        {
            Error = string.Empty;
            bool flag = true;

            DataTable Dt = this.ConsumeCommDt.DefaultView.ToTable();

            int selCount = 0;
            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string status = dr["STATUS"].ToString();   //审核标志
                    if (status.Equals("2"))
                    {
                        Error = "审核已通过，不能进行审核！";
                        return false;
                    }
                }
            }
            if (selCount == 0)
            {
                Error = "请选择记录后，再进行审核操作！";
                return false;
            }

            return flag;

        }

        /// <summary>
        /// 审核通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAudi_Click(object sender, EventArgs e)
        {
            if (ConsumeCommDt.DefaultView.Count == 0)
                return;

            string strError = string.Empty;
            if (!Validate_Audi(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //获取二级库存使用单对象列表
            ListOrdSecondAyrlnvUseModel = GetListOrdSecondAyrlnvUseModelToAudi();

            if (ListOrdSecondAyrlnvUseModel.Count == 0)
                return;

            try
            {
                //备货流程
                OrdSecondAyrlnvUseBLL.GetInstance().OrdInvoiceFrom(ListOrdSecondAyrlnvUseModel, ordPurchaseModel, ordOrderModel, CurrentUser);

                //更改审核状态
                OrdSecondAyrlnvUseBLL.GetInstance().ModifyOrdSecondAyplnvUseState(ListOrdSecondAyrlnvUseModel, "2", CurrentUser);

                //刷新数据集
                DataBindConsume();

                XtraMessageBox.Show("二级库存使用审核通过！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("二级库存使用审核通过失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //更新DT(配送商的明细是否结束、用作拆单操作)
        private DataTable RefreshDt(DataTable dt)
        {
            dt.Columns.Add("StartFlag");
            dt.Columns.Add("EndFlag");
            dt.AcceptChanges();

            DataRow drLast = null;

            foreach (DataRow dr in dt.Rows)
            {
                if (drLast == null)
                {
                    drLast = dr;
                    dr["StartFlag"] = "1";
                    continue;
                }
                if (drLast["SENDER_ID"].ToString() != dr["SENDER_ID"].ToString())
                {
                    drLast["EndFlag"] = "1";
                    dr["StartFlag"] = "1";
                    drLast = dr;
                }
                else
                    drLast = dr;
            }
            
            dt.Rows[dt.Rows.Count - 1]["EndFlag"] = "1";
            return dt;
        }

        /// <summary>
        /// 获取二级库存使用单对象列表
        /// </summary>
        /// <returns></returns>
        private List<OrdSecondAyrlnvUseModel> GetListOrdSecondAyrlnvUseModelToAudi()
        {
            ListOrdSecondAyrlnvUseModel.Clear();

            decimal total_Num = 0;

            DataTable dttemp = ConsumeCommDt.DefaultView.ToTable();

            dttemp.DefaultView.RowFilter = "Sel='1'";

            DataTable dt = dttemp.DefaultView.ToTable();

            dt = RefreshDt(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    OrdSecondAyrlnvUseModel model = GetOrdSecondAyrlnvUseModelToAudi(dr);

                    total_Num += model.Fact_Sum;

                    ListOrdSecondAyrlnvUseModel.Add(model);
                }
            }

            ordPurchaseModel = null;
            ordPurchaseModel = new OrdPurchaseModel();
            ordPurchaseModel.Buyer_Id = CurrentUser.UserOrg.Id;
            ordPurchaseModel.Type = "3";
            ordPurchaseModel.Purchase_Date = DateTime.Now.ToShortDateString();
            ordPurchaseModel.Total_Sum = total_Num;
            ordPurchaseModel.State = "4";//采购单状态  发送状态

            ordOrderModel = null;
            ordOrderModel = new OrdOrderModel();
            ordOrderModel.Buyer_Id = CurrentUser.UserOrg.Id;
            ordOrderModel.Buyer_Name = CurrentUser.UserOrg.Name;
            ordOrderModel.Buyer_Name_Abbr = CurrentUser.UserOrg.Abbr;
            //ordOrderModel.Total_Sum = total_Num;
            //ordOrderModel.Over_Sum = total_Num;
            ordOrderModel.State = "5";
            ordOrderModel.Type = "3";//备货类型
            ordOrderModel.Purchase_Date = ordPurchaseModel.Purchase_Date;
            ordOrderModel.Quicksend_Level = "1";

            return ListOrdSecondAyrlnvUseModel;
        }

        /// <summary>
        /// 获取二级库存使用单对象  用于操作 采购单表、采购明细表、订单表、订单明细表
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdSecondAyrlnvUseModel GetOrdSecondAyrlnvUseModelToAudi(DataRow dr)
        {
            OrdSecondAyrlnvUseModel model = new OrdSecondAyrlnvUseModel();

            model.Id = dr["ID"].ToString();
            model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            model.Project_Id = dr["PROJECT_ID"].ToString();
            model.Project_Product_Id = dr["PROJECT_PRODUCT_ID"].ToString();
            model.Common_Name = dr["COMMON_NAME"].ToString();
            model.Product_Name = dr["PRODUCT_NAME"].ToString();
            model.Product_Code = dr["PRODUCT_CODE"].ToString();
            model.Goods_No = dr["GOODS_NO"].ToString();
            model.Spec_Id = dr["SPEC_ID"].ToString();
            model.Model_Id = dr["MODEL_ID"].ToString();
            model.Spec = dr["SPEC"].ToString();
            model.Model = dr["MODEL"].ToString();
            if (!dr["BRAND"].ToString().Equals("-"))
                model.Brand = dr["BRAND"].ToString();
            if (!dr["BATCH_NO"].ToString().Equals("-"))
                model.Batch_No = dr["BATCH_NO"].ToString();
            model.Saler_Id = dr["SALER_ID"].ToString();
            model.Saler_Name = dr["SALER_NAME"].ToString();
            model.Saler_Name_Abbr = dr["SALER_NAME_ABBR"].ToString();
            model.Sender_Id = dr["SENDER_ID"].ToString();
            model.Sender_Name = dr["SENDER_NAME"].ToString();
            model.Sender_Name_Abbr = dr["SENDER_NAME_ABBR"].ToString();
            model.Manu_Id = dr["MANU_ID"].ToString();
            model.Manu_Name = dr["MANU_NAME"].ToString();
            model.Manu_Name_Abbr = dr["MANU_NAME_ABBR"].ToString();

            if (!dr["BARCODE"].ToString().Equals("-"))
                model.Barcode = dr["BARCODE"].ToString();
            model.Arrive_Date = dr["CREATE_DATE"].ToString();
            model.Price = dr["PRICE"].ToString();//单价
            //实际到货数量
            model.Fact_Amount = Convert.ToDecimal(dr["FACT_AMOUNT"].ToString());
            //实际到货金额
            model.Fact_Sum = Convert.ToDecimal(model.Fact_Amount) * Convert.ToDecimal(model.Price);

            //基础计量单位
            model.Base_Measure = dr["BASE_MEASURE"].ToString();
            //基础单位规格
            model.Base_Measure_Spec = dr["BASE_MEASURE_SPEC"].ToString();
            //基础单位包装材质
            model.Base_Measure_Mate = dr["BASE_MEASURE_MATER"].ToString();

            //配送计量单位
            model.Send_Measure = dr["DEFAULT_MEASURE"].ToString();
            //配送转换率
            model.Send_Measure_Ex = dr["DEFAULT_MEASURE_EX"].ToString();

            //卖方发货人ID
            model.Send_Operator_Id = dr["Send_Operator_Id"].ToString();
            model.Send_Operator_Name = dr["Send_Operator_Name"].ToString();
            model.Send_Operate_Date = dr["Send_Operate_Date"].ToString();

            //买方ID
            model.Buyer_Id = CurrentUser.UserOrg.Id;
            model.Buyer_Name = CurrentUser.UserOrg.Name;
            model.Buyer_Name_Abbr = CurrentUser.UserOrg.Abbr;

            if (!dr["PBNO"].ToString().Equals("-"))
                model.Pbno = dr["PBNO"].ToString();
            model.Send_Batch_No = dr["SEND_BATCH_NO"].ToString();
            model.Instore_Batch_No = dr["INSTORE_BATCH_NO"].ToString();

            model.Start_Sender_Flag = dr["StartFlag"].ToString() == "1" ? true :false;
            model.Over_Sender_Flag = dr["EndFlag"].ToString() == "1" ? true : false;
            //状态
            model.Status = dr["STATUS"].ToString();
            //库房ID
            model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            model.Store_Room_Name = dr["STORE_ROOM_NAME"].ToString();

            return model;
        }

        #endregion

        #region 消耗商品信息删除

        //审核数据验证
        private bool Validate_Del(out string Error)
        {
            Error = string.Empty;
            bool flag = true;

            DataTable Dt = this.ConsumeCommDt.DefaultView.ToTable();

            int selCount = 0;
            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string status = dr["STATUS"].ToString();   //审核标志
                    if (status.Equals("2"))
                    {
                        Error = "审核已通过，不能进行删除！";
                        return false;
                    }
                }
            }
            if (selCount == 0)
            {
                Error = "你没有选择任何记录！";
                return false;
            }

            return flag;

        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (ConsumeCommDt.DefaultView.Count == 0)
                return;

            string strError = string.Empty;
            if (!Validate_Del(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            if (XtraMessageBox.Show("确认删除消耗商品信息吗？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ListOrdSecondAyrlnvUseModel = GetListOrdSecondAyrlnvUseModelByToDel();           
            
            if (ListOrdSecondAyrlnvUseModel.Count == 0)
                return;

            try
            {
                OrdSecondAyrlnvUseBLL.GetInstance().ModifyOrdSecondAyplnvUseState(ListOrdSecondAyrlnvUseModel, "0", CurrentUser);

                //刷新消耗商品列表数据集
                DataBindConsume();

                XtraMessageBox.Show("消耗商品信息删除成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("消耗商品信息删除失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
                
        /// <summary>
        /// 获取二级库存使用单对象列表  删除使用
        /// </summary>
        /// <returns></returns>
        private List<OrdSecondAyrlnvUseModel> GetListOrdSecondAyrlnvUseModelByToDel()
        {
            ListOrdSecondAyrlnvUseModel.Clear();

            DataTable dt = ConsumeCommDt.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    OrdSecondAyrlnvUseModel model = GetOrdSecondAyrlnvUseModelToDel(dr);

                    ListOrdSecondAyrlnvUseModel.Add(model);
                }
            }

            return ListOrdSecondAyrlnvUseModel;
        }

        /// <summary>
        /// 获取二级库存使用表对象 删除使用
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdSecondAyrlnvUseModel GetOrdSecondAyrlnvUseModelToDel(DataRow dr)
        {
            OrdSecondAyrlnvUseModel model = new OrdSecondAyrlnvUseModel();

            //二级库存使用表ID
            model.Id = dr["ID"].ToString();

            return model;
        }

        #endregion

        #region 全选事件
        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkAllSel_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllSel.Checked)
                AllSelect1("1");
            else
                AllSelect1("0");
        }

        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="state"></param>
        private void AllSelect1(string state)
        {            
            foreach (DataRow dr in OrdSecondAyplnvDt.Rows)
            {
                dr["Sel"] = state;
            }
        }

        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="state"></param>
        private void AllSelect2(string state)
        {
            foreach (DataRow dr in ConsumeCommDt.Rows)
            {
                dr["Sel"] = state;
            }
        }

        private void ChkSel2_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSel2.Checked)
                AllSelect2("1");
            else
                AllSelect2("0");
        }
        #endregion

        #region 打印事件
        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmPrint frmPrint;
            //库存商品
            if (xtraTabControl2.SelectedTabPage == xtraTabPage1)
            {
                frmPrint = new FrmPrint(new StockGoodXtraReport(base.CurrentUserOrgName + "库存商品报表"), ((DataView)bindingSource1.DataSource).Table);
            }
            else
            {
                frmPrint = new FrmPrint(new ConsumeGoodXtraReport(base.CurrentUserOrgName + "消耗品报表"), ((DataView)bindingSource2.DataSource).Table);
            }
            frmPrint.ShowDialog();
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFound_Click(object sender, EventArgs e)
        {
            //绑定库存商品列表数据集
            DataBindAyplnv();
        }
        #endregion

        #region 商品数据绑定
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

        #region 库房选择改变事件
        /// <summary>
        /// 库房选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreRoomLue_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gVOrdSecondAyplnv.RowCount == 0)
                return;

            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gVOrdSecondAyplnv.GetDataRow(this.gVOrdSecondAyplnv.FocusedRowHandle);

            if (dr != null)
            {
                dr["STORE_ROOM_NAME"] = LueText.Text.ToString();
            }
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

        private void gVOrdSecondAyplnv_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVOrdSecondAyplnv.GetDataRow(this.gVOrdSecondAyplnv.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "CREATE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["CREATE_DATE"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        
        private void gVConsumeComm_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVConsumeComm.GetDataRow(this.gVConsumeComm.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVConsumeComm.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gVConsumeComm.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gVConsumeComm.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else if (this.gVConsumeComm.FocusedColumn.FieldName.ToUpper() == "CREATE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["CREATE_DATE"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }        
        #endregion

        #region 选中选择列时，改变选择框
        private void gVOrdSecondAyplnv_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = this.gVOrdSecondAyplnv.GetDataRow(this.gVOrdSecondAyplnv.FocusedRowHandle);

            if (dr != null)
            {
                if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "SEL")
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
                else if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "FACT_AMOUNT")
                {
                    dr["Sel"] = "1";
                    return;
                }
                else if (this.gVOrdSecondAyplnv.FocusedColumn.FieldName.ToUpper() == "STORE_ROOM_ID")
                {
                    dr["Sel"] = "1";
                    return;
                }
            }
        }

        private void gVConsumeComm_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = this.gVConsumeComm.GetDataRow(this.gVConsumeComm.FocusedRowHandle);

            if (dr != null)
            {
                if (this.gVConsumeComm.FocusedColumn.FieldName.ToUpper() == "SEL")
                {
                    if (dr["Sel"].Equals("1"))
                    {
                        dr["Sel"] = "0";
                    }
                    else
                    {
                        dr["Sel"] = "1";
                    }
                }
            }
        }
        #endregion

        #region 控制到货数量不能输入其它字符
        private void UseTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}