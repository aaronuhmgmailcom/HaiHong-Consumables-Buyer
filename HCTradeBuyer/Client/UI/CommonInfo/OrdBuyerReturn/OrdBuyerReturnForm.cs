//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdBuyerReturnForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	退货管理
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
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdBuyerReturn
{
    /// <summary>
    /// 退货管理
    /// </summary>
    public partial class OrdBuyerReturnForm : BaseForm
    {
        #region 变量定义区
        //可退货商品列表
        private DataTable BuyerReturnDt = null;

        //获取当取用户对象
        LogedInUser CurrentUser = null;
        #endregion

        public OrdBuyerReturnForm()
        {
            InitializeComponent();
        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            //获取可退货商品列表查询数据集
            BuyerReturnDt = OrdBuyerReturnBLL.GetInstance().GetBuyerReturnList();

            BuyerReturnDt.DefaultView.Sort = " ARRIVE_DATE DESC";

            this.bindingSource1.DataSource = BuyerReturnDt.DefaultView;
        }
        #endregion

        #region 查看退货列表事件
        /// <summary>
        /// 查看退货列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewReturnList_Click(object sender, EventArgs e)
        {
            FoundOrdBuyerReturnForm frm = new FoundOrdBuyerReturnForm();
            frm.ShowDialog();

            //if (frm.EditFlag)
            //{
            //    DataBind();
            //}
        }
        #endregion

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFound_Click(object sender, EventArgs e)
        {
            DataBind();
            Filter();
        }
        
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
            //规格型号
            string SpecModel = this.txtSpecModel.Text.Trim();
            //经销企业
            string SalerName = this.txtSalerName.Text.Trim();
            //配送企业
            string SenderName = this.txtSenderName.Text.Trim();
            //品牌
            string Brand = this.txtBrand.Text.Trim();
            //到货日期
            string strStartDate = this.StartDate.Text;  //开始时间
            string strEndDate = this.EndDate.Text;      //结束时间

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
                StrFilter.AppendFormat(" AND Brand LIKE '%{0}%'", Brand);
            }

            //规格型号
            if (!string.IsNullOrEmpty(SpecModel))
            {
                StrFilter.AppendFormat(" AND (Spec LIKE '%{0}%' Or Model LIKE '%{0}%')", SpecModel);
            }

            //配送企业
            if (!string.IsNullOrEmpty(SenderName))
            {
                StrFilter.AppendFormat(" AND (SENDER_NAME LIKE '%{0}%' or SENDER_NAME_ABBR LIKE '%{0}%' or SENDER_NAME_SPELL_ABBR LIKE '%{0}%' or SENDER_NAME_WB LIKE '%{0}%')", SenderName);
            }

            //经销企业
            if (!string.IsNullOrEmpty(SalerName))
            {
                StrFilter.AppendFormat(" AND (SALER_NAME LIKE '%{0}%' or SALER_NAME_ABBR LIKE '%{0}%' or SALER_NAME_SPELL_ABBR LIKE '%{0}%' or SALER_NAME_WB LIKE '%{0}%')", SalerName);
            }

            //开始时间
            if (!string.IsNullOrEmpty(strStartDate))
            {
                StrFilter.AppendFormat(" AND ARRIVE_DATE >= '{0}'", strStartDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(strEndDate))
            {
                StrFilter.AppendFormat(" AND ARRIVE_DATE <= '{0}'", strEndDate + " 23:59:59");
            }

            if (BuyerReturnDt != null)
            {
                if (BuyerReturnDt.DefaultView != null)
                {
                    this.BuyerReturnDt.DefaultView.RowFilter = StrFilter.ToString();
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

        //放入退货单数据验证
        private bool Validata(out string Error)
        {
            Error = string.Empty;
            bool flag = true;

            int selCount = 0;
            DataTable Dt = BuyerReturnDt.DefaultView.ToTable();

            foreach (DataRow dr in Dt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    selCount++;
                    string returnAmount = dr["Return_Amount"].ToString();   //可退数量
                    string returnNum = dr["ReturnNum"].ToString();          //拟退数量
                    if (string.IsNullOrEmpty(returnNum) || Convert.ToDecimal(returnNum) < 1)
                    {
                        Error = "请输入可退数量！";
                        return false;
                    }
                    if (Convert.ToDecimal(returnAmount) < Convert.ToDecimal(returnNum))
                    {
                        Error = "拟退数量不能大于可退数量！";
                        return false;
                    }
                }
            }

            if (selCount == 0)
            {
                Error = "请选择记录后，再进行放入退货列表操作！";
                return false;
            }

            return flag;
        }

        /// <summary>
        /// 放入退货列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIntoReturnList_Click(object sender, EventArgs e)
        {
            //放入退货列表前作好数据验证
            string strError = string.Empty;

            if (!Validata(out strError))
            {
                XtraMessageBox.Show(strError, Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //提示信息
            if (XtraMessageBox.Show("确认放入退货列表吗？", Constant.MsgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            List<OrdBuyerReturnModel> ListOrdBuyerReturnModel = new List<OrdBuyerReturnModel>();

            foreach (DataRow dr in BuyerReturnDt.Rows)
            {
                string strSel = dr["Sel"].ToString();

                if (strSel.Equals("1"))
                {
                    OrdBuyerReturnModel model = GetOrdBuyerReturnModel(dr);

                    ListOrdBuyerReturnModel.Add(model);
                }
            }

            SaveOrdBuyerReturnModelList(ListOrdBuyerReturnModel);

        }

        /// <summary>
        /// 保存至退货单表
        /// </summary>
        /// <param name="ListOrdHitCommModel"></param>
        private void SaveOrdBuyerReturnModelList(List<OrdBuyerReturnModel> ListOrdBuyerReturnModel)
        {
            if (ListOrdBuyerReturnModel.Count == 0)
                return;

            try
            {
                OrdBuyerReturnBLL.GetInstance().SaveOrdBuyerReturnModel(ListOrdBuyerReturnModel, CurrentUser);

                XtraMessageBox.Show("放入退货列表成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("放入退货列表失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 获取插入退货单信息对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private OrdBuyerReturnModel GetOrdBuyerReturnModel(DataRow dr)
        {
            OrdBuyerReturnModel model = new OrdBuyerReturnModel();

            model.Data_Product_Id = dr["DATA_PRODUCT_ID"].ToString();
            model.Project_Id = dr["PROJECT_ID"].ToString();
            model.Product_Name = dr["PRODUCT_NAME"].ToString();//商品名称
            model.Comm_Name = dr["COMMON_NAME"].ToString();
            model.Brand = dr["BRAND"].ToString();
            model.Spec_Id = dr["SPEC_ID"].ToString();
            model.Model_Id = dr["MODEL_ID"].ToString();
            model.Spec = dr["SPEC"].ToString();
            model.Model = dr["MODEL"].ToString();
            model.Price = dr["Price"].ToString();
            model.Receive_Id = dr["ReceiveID"].ToString();
            model.Order_Id = dr["ORDER_ID"].ToString();
            model.Order_Item_Id = dr["ORDER_ITEM_ID"].ToString();
            model.Project_Product_Id = dr["PROJECT_PRODUCT_ID"].ToString();
            model.Saler_Id = dr["SALER_ID"].ToString();
            model.Saler_Name = dr["SALER_NAME"].ToString();
            model.Saler_Name_Abbr = dr["SALER_NAME_ABBR"].ToString();
            model.Sender_Id = dr["SENDER_ID"].ToString();
            model.Sender_Name = dr["SENDER_NAME"].ToString();
            model.Sender_Name_Abbr = dr["SENDER_NAME_ABBR"].ToString();
            model.Manufacture_Id = dr["MANU_ID"].ToString();
            model.Manufacture_Name = dr["MANU_NAME"].ToString();
            model.Manufacture_Name_Abbr = dr["MANU_NAME_ABBR"].ToString();
            model.Product_Code = dr["PRODUCT_CODE"].ToString();
            model.Goods_No = dr["GOODS_NO"].ToString();
            model.Barcode = dr["BARCODE"].ToString();
            model.Pbno = dr["Pbno"].ToString();
            model.Brand = dr["BRAND"].ToString();
            model.Send_Batch_No = dr["SEND_BATCH_NO"].ToString();
            model.Instore_Batch_No = dr["INSTORE_BATCH_NO"].ToString();
            model.Price = dr["Price"].ToString();
            //基础单位
            model.Base_Measure = dr["BASE_MEASURE"].ToString();
            model.Base_Measure_Spec = dr["BASE_MEASURE_SPEC"].ToString();
            model.Base_Measure_Mater = dr["BASE_MEASURE_MATER"].ToString();
            //配送计量单位
            model.Send_Measure = dr["SEND_MEASURE"].ToString();
            model.Send_Measure_Ex = dr["SEND_MEASURE_EX"].ToString();
            model.Amount = dr["ReturnNum"].ToString();
            //退货总金额
            model.Sum = Convert.ToDecimal(model.Price) * Convert.ToDecimal(model.Amount);
            model.State = "1";
            model.Buyer_Descriptions = dr["ReturnRes"].ToString();//退货原因
            //买方ID
            model.Buyer_Id = this.CurrentUser.UserOrg.Id;
            model.Buyer_Name = this.CurrentUser.UserOrg.Name;
            model.Buyer_Name_Abbr = this.CurrentUser.UserOrg.Abbr;
            //发货人ID
            model.Send_Operator_Id = dr["SEND_OPERATOR_ID"].ToString();
            model.Send_Operator_Name = dr["SEND_OPERATOR_NAME"].ToString();
            model.Send_Operate_Date = dr["SEND_OPERATE_DATE"].ToString();
            //收货人ID
            model.Instore_Operator_Id = dr["INSTORE_OPERATOR_ID"].ToString();
            model.Instore_Operator_Name = dr["INSTORE_OPERATOR_NAME"].ToString();
            model.Instore_Operate_Date = dr["INSTORE_OPERATOR_DATE"].ToString();

            return model;
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdBuyerReturnForm_Load(object sender, EventArgs e)
        {
            CurrentUser = base.CurrentUser;
            DataBind();
            //给查询时间赋默认值
            this.StartDate.EditValue = DateTime.Now.AddMonths(-3);
            this.EndDate.EditValue = DateTime.Now;
        }

        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvReturnList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gvReturnList_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    共 " + gvReturnList.RowCount + " 条数据";
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
            foreach (DataRow dr in BuyerReturnDt.Rows)
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

        private void gvReturnList_Click(object sender, EventArgs e)
        {
            DataRow dr = this.gvReturnList.GetDataRow(this.gvReturnList.FocusedRowHandle);
            if (dr != null)
            {
                if (this.gvReturnList.FocusedColumn.FieldName.ToUpper() == "SENDER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SENDER_NAME"].ToString());

                else if (this.gvReturnList.FocusedColumn.FieldName.ToUpper() == "SALER_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["SALER_NAME"].ToString());

                else if (this.gvReturnList.FocusedColumn.FieldName.ToUpper() == "MANU_NAME_ABBR")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

                else
                    toolTipController1.HideHint();
            }
        }
        #endregion

        private void gvReturnList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = this.gvReturnList.GetDataRow(this.gvReturnList.FocusedRowHandle);

            if (dr != null)
            {
                if (this.gvReturnList.FocusedColumn.FieldName.ToUpper() == "SEL")
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
                else if (this.gvReturnList.FocusedColumn.FieldName.ToUpper() == "RETURNNUM")
                {
                    dr["Sel"] = "1";
                    return;
                }
                else if (this.gvReturnList.FocusedColumn.FieldName.ToUpper() == "RETURNRES")
                {
                    dr["Sel"] = "1";
                    return;
                }
            }
        }
        #region 拟退数量不能输入其它字符
        /// <summary>
        /// 拟退数量不能输入其它字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeReturnNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}