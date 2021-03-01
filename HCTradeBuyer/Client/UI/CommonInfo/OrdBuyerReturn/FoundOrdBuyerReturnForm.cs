//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	FoundOrdBuyerReturnForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	查询退货商品列表
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
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.StockUp;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdProduct;
using Emedchina.TradeAssistant.Client.Base;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdBuyerReturn
{
    /// <summary>
    /// 查询退货商品列表
    /// </summary>
    public partial class FoundOrdBuyerReturnForm : BaseForm
    {
        #region 变量定义区
        //修改变量
        public bool EditFlag = false;

        //未发送退货商品列表
        private DataTable NoSendReturnCommerceDt = null;

        //已发送退货商品列表
        private DataTable SendReturnCommerceDt = null;

        //退货单对象列表 未发送列表
        List<OrdBuyerReturnModel> ListOrdBuyerReturnModelByNoSend = null;

        #endregion

        #region 构造
        public FoundOrdBuyerReturnForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindNoSend()
        {
            //绑定未发送退货商品列表数据集
            NoSendReturnCommerceDt = OrdBuyerReturnBLL.GetInstance().GetReturnList("1");

            NoSendReturnCommerceDt.DefaultView.Sort = " CREATE_DATE DESC";

            this.bindingSource1.DataSource = NoSendReturnCommerceDt.DefaultView;
        }

        private void DataBindSend()
        {
            //绑定已发送退货商品列表数据集
            SendReturnCommerceDt = OrdBuyerReturnBLL.GetInstance().GetReturnList("2");

            SendReturnCommerceDt.DefaultView.Sort = " CREATE_DATE DESC";

            this.bindingSource2.DataSource = SendReturnCommerceDt.DefaultView;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //未发送商品列表
            DataBindNoSend();

            //已发送商品列表
            DataBindSend();
        }

        #endregion
        
        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundOrdBuyerReturnForm_Load(object sender, EventArgs e)
        {
            ListOrdBuyerReturnModelByNoSend = new List<OrdBuyerReturnModel>();

            DataBind();
        }
        #endregion

        #region 确认发出有关事件
        /// <summary>
        /// 确认发出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAffirmSend_Click(object sender, EventArgs e)
        {
            string strError = string.Empty;
            //确认发出数据验证
            if (!Validata(out strError))
            {
                XtraMessageBox.Show(strError, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //获取退货单对象列表
                ListOrdBuyerReturnModelByNoSend = GetListOrdBuyerReturnModel();

                SaveOrdBuyerReturnModelList(ListOrdBuyerReturnModelByNoSend, "2");
                //刷新数据绑定
                DataBind();
                //修改标志
                EditFlag = true;
                XtraMessageBox.Show("确认发出成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("确认发出失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 修改退货单标志
        /// </summary>
        /// <param name="ListOrdBuyerReturnModelByNoSend"></param>
        /// <param name="State"></param>
        private void SaveOrdBuyerReturnModelList(List<OrdBuyerReturnModel> ListOrdBuyerReturnModelByNoSend, string State)
        {
            if (ListOrdBuyerReturnModelByNoSend.Count == 0)
                return;

            try
            {
                //修改退货单标志
               OrdBuyerReturnBLL.GetInstance().SendOrdBuyerReturnModel(ListOrdBuyerReturnModelByNoSend, State, this.CurrentUser);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 删除退货单有关事件
        /// <summary>
        /// 删除退货单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelReturn_Click(object sender, EventArgs e)
        {
            string strError = string.Empty;
            //确认发出数据验证
            if (!Validata_Del(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            if (XtraMessageBox.Show("确认删除退货单信息吗？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                //获取退货单对象列表
                ListOrdBuyerReturnModelByNoSend = GetListOrdBuyerReturnModel();
                //修改状态标志 3 已撤消
                SaveOrdBuyerReturnModelList(ListOrdBuyerReturnModelByNoSend, "3");

                DataBindNoSend();

                XtraMessageBox.Show("退货单信息删除成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("退货单信息删除失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取退货单对象列表 未发送列表
        /// </summary>
        /// <returns></returns>
        private List<OrdBuyerReturnModel> GetListOrdBuyerReturnModel()
        {
            ListOrdBuyerReturnModelByNoSend.Clear();

            foreach (DataRow dr in NoSendReturnCommerceDt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    OrdBuyerReturnModel model = GetOrdBuyerReturnModel(dr);

                    ListOrdBuyerReturnModelByNoSend.Add(model);
                }
            }

            return ListOrdBuyerReturnModelByNoSend;
        }

        /// <summary>
        /// 获取退货单信息对象(未发送列表)
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdBuyerReturnModel GetOrdBuyerReturnModel(DataRow dr)
        {
            OrdBuyerReturnModel model = new OrdBuyerReturnModel();

            //到货单ID
            model.Receive_Id = dr["ReceiveID"].ToString();
            //退货单ID
            model.Id = dr["ReturnID"].ToString();
            //实退数量
            model.Amount = dr["Amount"].ToString();
            //退货价格
            model.Price = dr["PRICE"].ToString();
            //实退金额
            model.Sum = Convert.ToDecimal(model.Amount) * Convert.ToDecimal(model.Price);
            //退货原因
            model.Buyer_Descriptions = dr["BUYER_DESCRIPTIONS"].ToString();

            return model;
        }
        
        //删除退货数据，数据验证
        private bool Validata_Del(out string Error)
        {
            Error = string.Empty;

            DataTable Dt = this.NoSendReturnCommerceDt.DefaultView.ToTable();
            Dt.DefaultView.RowFilter = " Sel='1'";

            if (Dt.DefaultView.Count == 0)
            {
                Error = "请选择记录后，再进行退货单删除操作！";
                return false;
            }

            return true;
        }

        #endregion

        #region 确认修改退货数量有关事件
        /// <summary>
        /// 确认修改退货数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyAmount_Click(object sender, EventArgs e)
        {
            //数据验证
            string strError = string.Empty;

            if (!Validata_Edit(out strError))
            {
                XtraMessageBox.Show(strError, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //获取退货单对象列表
            ListOrdBuyerReturnModelByNoSend = GetListOrdBuyerReturnModel();

            if (ListOrdBuyerReturnModelByNoSend.Count == 0)
                return;

            try
            {
                OrdBuyerReturnBLL.GetInstance().ModifyAmountOrdBuyerReturnModel(ListOrdBuyerReturnModelByNoSend);

                XtraMessageBox.Show("确认修改退货数量成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("确认修改退货数量失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //确认修改退货数量，数据验证
        private bool Validata_Edit(out string Error)
        {
            Error = string.Empty;

            DataTable Dt = this.NoSendReturnCommerceDt.DefaultView.ToTable();
            Dt.DefaultView.RowFilter = " Sel='1'";

            if (Dt.DefaultView.Count == 0)
            {
                Error = "请选择记录后，再进行退货数量修改操作！";
                return false;
            }

            foreach (DataRow dr in Dt.Rows)
            {
                //实退数量
                string amount = dr["AMOUNT"].ToString();

                if (string.IsNullOrEmpty(amount))
                {
                    Error = "请输入实退数量！";
                    return false;
                }
                else if (Convert.ToDecimal(amount)<1)
                {
                    Error = "实退数量输入错误！";
                    return false;
                }
            }

            return true;
        }

        //确认发出退货数据验证
        private bool Validata(out string Error)
        {
            Error = string.Empty;
            bool flag = true;

            int selCount = 0;
            DataTable Dt = this.NoSendReturnCommerceDt.DefaultView.ToTable();

            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string returnNum = dr["AMOUNT"].ToString();
                    if (string.IsNullOrEmpty(returnNum) || Convert.ToDecimal(returnNum) < 1)
                    {
                        Error = "请输入退货数量！";
                        return false;
                    }
                }
            }

            if (selCount == 0)
            {
                Error = "请选择记录后，再进行退货单发送操作！";
                return false;
            }

            return flag;
        }

        #endregion

        #region 查看商品详细信息
        /// <summary>
        /// 查看商品详细信息 未发送列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {  
            if (this.gvReturnListNoSend.RowCount == 0)
                return;
            DataRow dr = this.gvReturnListNoSend.GetDataRow(this.gvReturnListNoSend.FocusedRowHandle);

            string strProjectProductID = dr["PROJECT_PRODUCT_ID"].ToString();
            string strSpec = dr["SPEC"].ToString();
            string strModel = dr["MODEL"].ToString();

            ViewOrdProductForm frm = new ViewOrdProductForm(strProjectProductID, strSpec, strModel);
            frm.ShowDialog();
        }

        /// <summary>
        /// 查看商品详细信息 已发送列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView2_Click(object sender, EventArgs e)
        {
            //string strProjectProductId = GetGridViewColValue(this.gvReturnListSend, "PROJECT_PRODUCT_ID");
            if (this.gvReturnListSend.RowCount == 0)
                return;

            DataRow dr = this.gvReturnListSend.GetDataRow(this.gvReturnListSend.FocusedRowHandle);

            string strProjectProductID = dr["PROJECT_PRODUCT_ID"].ToString();
            string strSpec = dr["SPEC"].ToString();
            string strModel = dr["MODEL"].ToString();

            ViewOrdProductForm frm = new ViewOrdProductForm(strProjectProductID, strSpec, strModel);
            frm.ShowDialog();
        }
        #endregion

        #region 公共事件
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
        private void gvReturnListNoSend_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void gvReturnListSend_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        #region 查询过滤方法
        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            //通用名称
            string CommonName = this.txtCommonName.Text.Trim();
            //产品名称
            string ProductName = this.txtProductName.Text.Trim();
            //品牌
            string Brand = this.txtBrand.Text.Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //通用名称
            if (!string.IsNullOrEmpty(CommonName))
            {
                StrFilter.AppendFormat(" AND (COMMON_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", CommonName);
            }

            //商品名称
            if (!string.IsNullOrEmpty(ProductName))
            {
                StrFilter.AppendFormat(" AND (PRODUCT_NAME LIKE '%{0}%' Or ABBR_PY LIKE '%{0}%' Or ABBR_WB LIKE '%{0}%')", ProductName);
            }

            //品牌
            if (!string.IsNullOrEmpty(Brand))
            {
                StrFilter.AppendFormat(" AND BRAND LIKE '%{0}%'", Brand);
            }

            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                //未发送商品列表
                if (NoSendReturnCommerceDt != null)
                {
                    if (NoSendReturnCommerceDt.DefaultView != null)
                    {
                        this.NoSendReturnCommerceDt.DefaultView.RowFilter = StrFilter.ToString();
                    }
                }
            }
            else
            {
                //已发送商品列表
                if (SendReturnCommerceDt != null)
                {
                    if (SendReturnCommerceDt.DefaultView != null)
                    {
                        this.SendReturnCommerceDt.DefaultView.RowFilter = StrFilter.ToString();
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
        
        #region 全选事件
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
            foreach (DataRow dr in NoSendReturnCommerceDt.Rows)
            {
                dr["Sel"] = state;
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

        private void gvReturnListNoSend_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvReturnListNoSend.GetDataRow(this.gvReturnListNoSend.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "MANUFACTURE_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANUFACTURE_NAME"].ToString());

                else if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "ARRIVE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["ARRIVE_DATE"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        
        private void gvReturnListSend_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvReturnListSend.GetDataRow(this.gvReturnListSend.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gvReturnListSend.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gvReturnListSend.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gvReturnListSend.FocusedColumn.FieldName.ToUpper() == "MANUFACTURE_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANUFACTURE_NAME"].ToString());

                else if (this.gvReturnListSend.FocusedColumn.FieldName.ToUpper() == "ARRIVE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["ARRIVE_DATE"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }

        #endregion

        #region 修改编辑框内容 自动选择
        private void gvReturnListNoSend_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = this.gvReturnListNoSend.GetDataRow(this.gvReturnListNoSend.FocusedRowHandle);

            if (dr != null)
            {
                if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "SEL")
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
                else if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "AMOUNT")
                {
                    dr["Sel"] = "1";
                    return;
                }
                else if (this.gvReturnListNoSend.FocusedColumn.FieldName.ToUpper() == "BUYER_DESCRIPTIONS")
                {
                    dr["Sel"] = "1";
                    return;
                }
            }
        }
        #endregion

        #region 退货数量不能输入其它字符
        /// <summary>
        /// 退货数量不能输入其它字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnNumTextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
        #endregion
    }
}