//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdInvoiceItemForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	发货单明细管理
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

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdInvoice
{
    /// <summary>
    /// 发货单明细管理
    /// </summary>
    public partial class OrdInvoiceItemForm : BaseForm
    {
        #region 变量定义区
        //修改状态
        public bool EditFlag = false;

        //获取当取用户对象
        LogedInUser CurrentUser = null;

        //采购单对象
        private OrdPurchaseModel ordPurchaseModel = null;

        //订单对象
        private OrdOrderModel ordOrderModel = null;

        //定义发货单明细列表数据集对象
        private DataTable OrdInvoiceFromItemDt = null;

        //定义未到货数据集对象
        private DataTable NoSend_OrdInvoiceFromItemDt = null;

        //定义已到货数据集对象
        private DataTable Send_OrdInvoiceFromItemDt = null;

        //定义发货流程使用类对象
        List<OrdSecondAyrlnvUseModel> ListOrdSecondAyrlnvUseModel = null;

        //定义发货单明细列表对象
        List<OrdInvoiceFromItemModel> ListOrdInvoiceFromItemModel = null;

        //定义全局变量 发货单ID
        private string StrInvoiceFromId;

        //库房默认ID
        private int storeId;
        #endregion

        #region 构造
        public OrdInvoiceItemForm()
        {
            InitializeComponent();
        }

        public OrdInvoiceItemForm(string StrInvoiceFromId,bool viewflag)
        {
            InitializeComponent();
            //清空文本
            ClearText();
            this.StrInvoiceFromId = StrInvoiceFromId;
            IniData(StrInvoiceFromId);

            //获取当取用户对象
            CurrentUser = base.CurrentUser;
            InitGrid_Cmb();

            //查看状态
            DataBind(StrInvoiceFromId);

            if (!viewflag)
            {
                //到货操作
                DataBind_SendList();
                this.xtraTabControl1.SelectedTabPageIndex = 0;
            }
            else
            {
                //隐藏未到货、已到货列表
                this.xtpNoSend.PageVisible = false;
                this.xtpSend.PageVisible = false;
                this.xtraTabControl1.SelectedTabPageIndex = 2;
            }
        }
        #endregion

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdInvoiceItemForm_Load(object sender, EventArgs e)
        {

            ListOrdInvoiceFromItemModel = new List<OrdInvoiceFromItemModel>();

            ListOrdSecondAyrlnvUseModel = new List<OrdSecondAyrlnvUseModel>();
        }

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

            if (dtStone != null)
            {
                this.StoreRoomLue.DataSource = dtStone.DefaultView;

                storeId = Convert.ToInt32(dtStone.Rows[0]["STORE_ID"].ToString().Trim());
            }
        }

        #endregion

        /// <summary>
        /// 清空文本
        /// </summary>
        private void ClearText()
        {
            this.lbl_Invoice_Code.Text = string.Empty;
            this.lbl_Create_Name.Text = string.Empty;
            this.lbl_Create_Date.Text = string.Empty;
            this.lbl_Modify_Date.Text = string.Empty;
            this.lbl_Modify_Name.Text = string.Empty;
            this.lbl_Sender_Name.Text = string.Empty;
            this.lbl_StateName.Text = string.Empty;
            this.lbl_Total_Sum.Text = string.Empty;
            this.lbl_Over_Sum.Text = string.Empty;
            this.lbl_buyer_Remark.Text = string.Empty;
            this.lbl_saler_Remark.Text = string.Empty;
        }

        #region 初始化标题信息
        /// <summary>
        /// 初始化订单标题信息
        /// </summary>
        /// <param name="StrInvoiceFromId"></param>
        private void IniData(string StrInvoiceFromId)
        {
            OrdInvoiceFromModel ordInvoiceFromModel = OrdInvoiceBLL.GetInstance().GetOrdInvoiceFromModel(StrInvoiceFromId);

            if (ordInvoiceFromModel != null)
            {
                this.lbl_Invoice_Code.Text = ordInvoiceFromModel.Invoice_Code;
                this.lbl_Create_Name.Text = ordInvoiceFromModel.Create_User_Name;
                this.lbl_Create_Date.Text = ordInvoiceFromModel.Create_Date;
                this.lbl_Modify_Name.Text = ordInvoiceFromModel.Modify_User_Name;
                this.lbl_Modify_Date.Text = ordInvoiceFromModel.Modify_Date;
                this.lbl_Sender_Name.Text = ordInvoiceFromModel.Sender_Name;
                this.lbl_StateName.Text = ordInvoiceFromModel.StateName;
                this.lbl_Total_Sum.Text = base.SetNumFormat(ordInvoiceFromModel.Total_Sum);
                this.lbl_Over_Sum.Text = base.SetNumFormat(ordInvoiceFromModel.Over_Sum);
                this.lbl_buyer_Remark.Text = ordInvoiceFromModel.Buyer_Descriptions;
                this.lbl_saler_Remark.Text = ordInvoiceFromModel.Saler_Descriptions;
            }

        }
        #endregion

        #region 明细数据绑定
        /// <summary>
        /// 数据绑定发货单明细
        /// </summary>
        private void DataBind(string StrInvoiceFromId)
        {
            //获取发货单明细列表数据集
            OrdInvoiceFromItemDt = OrdInvoiceBLL.GetInstance().GetOrdInvoiceFromItemList(StrInvoiceFromId);
            //排序
            OrdInvoiceFromItemDt.DefaultView.Sort = " Send_Operate_Date DESC";

            if (OrdInvoiceFromItemDt != null)
            {
                this.BsInvoiceItem.DataSource = OrdInvoiceFromItemDt.DefaultView;
            }
        }

        /// <summary>
        /// 数据绑定发货单 未到货、已到货数据
        /// </summary>
        private void DataBind_SendList()
        {
            //判断是否为空数据集
            if (this.OrdInvoiceFromItemDt.DefaultView.Count == 0)
                return;

            //未到货
            this.OrdInvoiceFromItemDt.DefaultView.RowFilter = " STATE IN('1')";
            this.NoSend_OrdInvoiceFromItemDt = OrdInvoiceFromItemDt.DefaultView.ToTable();

            foreach (DataRow dr in this.NoSend_OrdInvoiceFromItemDt.Rows)
            {
                if (string.IsNullOrEmpty(dr["STORE_ROOM_ID"].ToString()))
                {
                    dr["STORE_ROOM_ID"] = storeId;
                }
            }

            //已到货
            this.OrdInvoiceFromItemDt.DefaultView.RowFilter = " STATE IN('2')";
            this.Send_OrdInvoiceFromItemDt = OrdInvoiceFromItemDt.DefaultView.ToTable();
            //绑定
            this.BsNoSend.DataSource = this.NoSend_OrdInvoiceFromItemDt.DefaultView;
            this.BsSend.DataSource = this.Send_OrdInvoiceFromItemDt.DefaultView;

            this.OrdInvoiceFromItemDt.DefaultView.RowFilter = "";
        }
        #endregion

        #region 加入GRID中序号
        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvInvoiceItem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gVNoSendList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gVSendList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        #region 到货操作

        //到货数据验证
        private bool Validata(out string Error)
        {
            Error = string.Empty;
            bool flag = true;

            int selCount = 0;
            foreach (DataRow dr in NoSend_OrdInvoiceFromItemDt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string Amount = dr["AMOUNT"].ToString();            //订购数量
                    string overAmount = dr["OVERAMOUNT"].ToString();   //到货数量
                    if (string.IsNullOrEmpty(overAmount) || Convert.ToDecimal(overAmount)<1)
                    {
                        Error = "请输入到货数量！";
                        return false;
                    }
                    else if (string.IsNullOrEmpty(dr["STORE_ROOM_ID"].ToString()))
                    {
                        Error = "请选择库房！";
                        return false;
                    }
                    else if (Convert.ToDecimal(Amount) < Convert.ToDecimal(overAmount))
                    {
                        Error = "到货数量不能大于订购数量！";
                        return false;
                    }
                }
            }

            if (selCount == 0)
            {
                Error = "请选择记录后，再进行到货操作！";
                return false;
            }

            return flag;
        }

        #region 添加到采购供应目录中
        private void AddHitComm()
        {
            //当采购供应目录不存在该产品时，作新增操作
            List<OrdHitCommMode> ListOrdHitCommModel = new List<OrdHitCommMode>();

            DataTable Dt = NoSend_OrdInvoiceFromItemDt.DefaultView.ToTable();

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
            model.Project_Product_Id = dr["PROJECT_PRODUCT_ID"].ToString();
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
            model.Brand = dr["BRAND"].ToString();
            model.Price = dr["PRICE"].ToString();
            model.Code = dr["PRODUCT_CODE"].ToString();
            model.GoodsNo = dr["GOODS_NO"].ToString();
            model.Barcode = dr["BARCODE"].ToString();
            model.Base_Measure_Spec = dr["BASE_MEASURE_SPEC"].ToString();
            model.Base_Measure_Mater = dr["BASE_MEASURE_MATER"].ToString();
            model.Max_Price = dr["MAX_PRICE"].ToString();
            model.Manu_Id = dr["MANU_ID"].ToString();
            model.Saler_Id = dr["SALER_ID"].ToString();
            model.Sender_Id = dr["SENDER_ID"].ToString();
            model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            model.Batch_No = dr["BATCH_NO"].ToString();
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
            //产品注册信息
            model.RegNo = dr["REG_NO"].ToString();
            model.RegValidDate = dr["REG_VALID_DATE"].ToString();
            //库房ID
            model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            model.StoreRoomName = dr["STORE_ROOM_NAME"].ToString();

            return model;
        }
        #endregion

        /// <summary>
        /// 到货事件操作 1、修改明细表中状态 到货数量、入库批次 2、做采购单 订单 备货 到货流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            string strError = string.Empty;

            if (!Validata(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            //if (XtraMessageBox.Show("确认是否作到货操作？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    return;

            try
            {
                //0、添加到采购供应目录中
                AddHitComm();

                //1、修改明细表中状态 到货数量、入库批次
                ListOrdInvoiceFromItemModel = GetListOrdInvoiceFromItemModel();

                OrdInvoiceBLL.GetInstance().ModifyOrdInvoiceFromItemState(ListOrdInvoiceFromItemModel,StrInvoiceFromId, "2", CurrentUser);

                //2、走发货流程
                ListOrdSecondAyrlnvUseModel = GetListOrdSecondAyrlnvUseModelToAudi();

                OrdSecondAyrlnvUseBLL.GetInstance().OrdInvoiceFrom(ListOrdSecondAyrlnvUseModel, ordPurchaseModel, ordOrderModel, CurrentUser);

                //刷新数据
                DataBind(StrInvoiceFromId);
                DataBind_SendList();

                XtraMessageBox.Show("到货操作成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //刷新标头显示数据
                IniData(StrInvoiceFromId);

                EditFlag = true;//设置已修改状态
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("到货操作失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 获取发货单明细对象列表
        /// </summary>
        /// <returns></returns>
        private List<OrdInvoiceFromItemModel> GetListOrdInvoiceFromItemModel()
        {
            ListOrdInvoiceFromItemModel.Clear();

            DataTable Dt = NoSend_OrdInvoiceFromItemDt.DefaultView.ToTable();

            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    OrdInvoiceFromItemModel model = GetOrdInvoiceFromItemModel(dr);

                    ListOrdInvoiceFromItemModel.Add(model);
                }
            }

            return ListOrdInvoiceFromItemModel;
        }

        /// <summary>
        /// 获取发货单明细对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdInvoiceFromItemModel GetOrdInvoiceFromItemModel(DataRow dr)
        {
            OrdInvoiceFromItemModel model = new OrdInvoiceFromItemModel();

            model.Id = dr["ID"].ToString();
            //model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            model.Instore_Batch_No = dr["INSTORE_BATCH_NO"].ToString();
            model.Price = dr["PRICE"].ToString();
            model.Over_Amount = dr["OVERAMOUNT"].ToString();
            model.Over_Sum = Convert.ToDecimal(model.Over_Amount) * Convert.ToDecimal(model.Price);

            return model;
        }

        //更新DT(配送商的明细是否结束、用作拆单操作)
        private DataTable RefreshDt(DataTable dt)
        {
            DataRow drLast = null;

            dt.DefaultView.RowFilter = " Sel='1'";

            DataTable DtTemp = dt.DefaultView.ToTable();
            DtTemp.Columns.Add("StartFlag");
            DtTemp.Columns.Add("EndFlag");
            DtTemp.AcceptChanges();

            foreach (DataRow dr in DtTemp.Rows)
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

            DtTemp.Rows[DtTemp.Rows.Count - 1]["EndFlag"] = "1";
            return DtTemp;
        }

        /// <summary>
        /// 获取发货流程 使用列表
        /// </summary>
        /// <returns></returns>
        private List<OrdSecondAyrlnvUseModel> GetListOrdSecondAyrlnvUseModelToAudi()
        {
            if (ListOrdSecondAyrlnvUseModel != null)
                ListOrdSecondAyrlnvUseModel.Clear();

            decimal total_Num = 0;

            DataTable dttemp = NoSend_OrdInvoiceFromItemDt.DefaultView.ToTable();

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

            //采购单对象
            ordPurchaseModel = null;
            ordPurchaseModel = new OrdPurchaseModel();
            ordPurchaseModel.Buyer_Id = CurrentUser.UserOrg.Id;                 //买方ID
            ordPurchaseModel.Type = "2";                                        //采购单类型：发货流程
            ordPurchaseModel.Purchase_Date = DateTime.Now.ToString();           //采购日期
            ordPurchaseModel.Total_Sum = total_Num;                             //采购单金额
            ordPurchaseModel.State = "4";                                       //采购单状态：发送状态

            //订单对象
            ordOrderModel = null;
            ordOrderModel = new OrdOrderModel();
            ordOrderModel.Buyer_Id = CurrentUser.UserOrg.Id;                    //买方ID
            ordOrderModel.Buyer_Name = CurrentUser.UserOrg.Name;                //买方名称
            ordOrderModel.Buyer_Name_Abbr = CurrentUser.UserOrg.Abbr;           //买方简称
            ordOrderModel.State = "5";                                          //订单状态：完成
            ordOrderModel.Type = "2";                                           //订单    ：发货类型
            ordOrderModel.Purchase_Date = ordPurchaseModel.Purchase_Date;       //采购日期
            ordOrderModel.Quicksend_Level = "1";                                //紧急程度  1为“普通”

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

            //model.Id = dr["ID"].ToString();
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
            model.Brand = dr["BRAND"].ToString();
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

            model.Barcode = dr["BARCODE"].ToString();
            model.Arrive_Date = DateTime.Now.ToShortDateString();//dr["CREATE_DATE"].ToString();
            model.Price = dr["PRICE"].ToString();//单价
            //实际到货数量
            model.Fact_Amount = Convert.ToDecimal(dr["OVERAMOUNT"].ToString());
            //实际到货金额
            model.Fact_Sum = Convert.ToDecimal(model.Fact_Amount) * Convert.ToDecimal(model.Price);

            //基础计量单位
            model.Base_Measure = dr["BASE_MEASURE"].ToString();
            //基础单位规格
            model.Base_Measure_Spec = dr["BASE_MEASURE_SPEC"].ToString();
            //基础单位包装材质
            model.Base_Measure_Mate = dr["BASE_MEASURE_MATER"].ToString();

            //配送计量单位
            model.Send_Measure = dr["SEND_MEASURE"].ToString();
            //配送转换率
            model.Send_Measure_Ex = dr["SEND_MEASURE_EX"].ToString();

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

            model.Start_Sender_Flag = dr["StartFlag"].ToString() == "1" ? true : false;
            model.Over_Sender_Flag = dr["EndFlag"].ToString() == "1" ? true : false;
            //状态
            //model.Status = dr["STATUS"].ToString();
            //库房ID
            model.Store_Room_Id = dr["STORE_ROOM_ID"].ToString();
            model.Store_Room_Name = dr["STORE_ROOM_NAME"].ToString();

            return model;
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

        #region 查看商品信息
        /// <summary>
        /// 查看商品详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewItem_Click(object sender, EventArgs e)
        {
            DataRow dr = null;

            string strDataProductId = string.Empty;

            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0://未到货
                    if (this.gVNoSendList.RowCount == 0)
                        return;

                    dr = this.gVNoSendList.GetDataRow(this.gVNoSendList.FocusedRowHandle);
                    break;
                case 1://已到货
                    if (this.gVSendList.RowCount == 0)
                        return;

                    dr = this.gVSendList.GetDataRow(this.gVSendList.FocusedRowHandle);
                    break;
                case 2://明细表
                    if (this.gvInvoiceItem.RowCount == 0)
                        return;

                    dr = this.gvInvoiceItem.GetDataRow(this.gvInvoiceItem.FocusedRowHandle);
                    break;
            }

            string strProjectProductID = dr["PROJECT_PRODUCT_ID"].ToString();
            string strSpec = dr["SPEC"].ToString();
            string strModel = dr["MODEL"].ToString();

            ViewOrdProductForm frm = new ViewOrdProductForm(strProjectProductID, strSpec, strModel);
            frm.ShowDialog();
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

        /// <summary>
        /// 全选
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

        #region 全选事件
        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="state"></param>
        private void AllSelect(string state)
        {
            foreach (DataRow dr in NoSend_OrdInvoiceFromItemDt.Rows)
            {
                dr["Sel"] = state;
            }
        }
        #endregion

        /// <summary>
        /// 表格中库房选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreRoomLue_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gVNoSendList.RowCount == 0)
                return;

            DevExpress.XtraEditors.LookUpEdit LueText = (DevExpress.XtraEditors.LookUpEdit)sender;

            DataRow dr = this.gVNoSendList.GetDataRow(this.gVNoSendList.FocusedRowHandle);

            if (dr != null)
            {
                dr["STORE_ROOM_NAME"] = LueText.Text;
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

        private void gVNoSendList_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVNoSendList.GetDataRow(this.gVNoSendList.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVNoSendList.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        
        private void gVSendList_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gVSendList.GetDataRow(this.gVSendList.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gVSendList.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }

        private void gvInvoiceItem_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvInvoiceItem.GetDataRow(this.gvInvoiceItem.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gvInvoiceItem.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

        #region 选中选择列时，改变选择框
        private void gVNoSendList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = this.gVNoSendList.GetDataRow(this.gVNoSendList.FocusedRowHandle);

            if (dr != null)
            {
                if (this.gVNoSendList.FocusedColumn.FieldName.ToUpper() == "SEL")
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
                else if (this.gVNoSendList.FocusedColumn.FieldName.ToUpper() == "OVERAMOUNT")
                {
                    dr["Sel"] = "1";
                    return;
                }
                else if (this.gVNoSendList.FocusedColumn.FieldName.ToUpper() == "INSTORE_BATCH_NO")
                {
                    dr["Sel"] = "1";
                    return;
                }
                else if (this.gVNoSendList.FocusedColumn.FieldName.ToUpper() == "STORE_ROOM_ID")
                {
                    dr["Sel"] = "1";
                    return;
                }
            }
        }
        #endregion

        #region 控制到货数量不能输入其它字符
        private void TeOverAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}