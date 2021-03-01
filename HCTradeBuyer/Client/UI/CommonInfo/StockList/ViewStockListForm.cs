//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	ViewStockListForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	查看商品详细信息
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

using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.StockList
{
    /// <summary>
    /// 查看商品详细信息
    /// </summary>
    public partial class ViewStockListForm : BaseForm
    {
        //修改标志
        public bool EditFlag = false;

        //获取当取用户对象
        private LogedInUser CurrentUser = null;

        //采购目录ID
        private string strHitCommID = null;

        private OrdHitCommMode ordHitCommModel = null;

        public ViewStockListForm()
        {
            InitializeComponent();
        }

        public ViewStockListForm(string HitCommID)
        {
            InitializeComponent();
            strHitCommID = HitCommID;
            ordHitCommModel = StockListBLL.GetInstance().GetOrdHitCommModel(HitCommID);
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
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewStockListForm_Load(object sender, EventArgs e)
        {
            //获取当前用户
            CurrentUser = base.CurrentUser;

            //绑定数据
            Init_Cmb();
            if (ordHitCommModel != null)
            {
                IniData(ordHitCommModel);
            }

        }

        /// <summary>
        /// 初始化查看数据
        /// </summary>
        /// <param name="model"></param>
        private void IniData(OrdHitCommMode model)
        {
            this.Lbl_Product_Name.Text = model.Product_Name;
            this.Lbl_Class_Name.Text = model.Class_Name;
            this.Lbl_Spec.Text = model.Spec;
            this.Lbl_Model.Text = model.Model;
            //this.txt_SenderName.Text = model.SenderName;
            this.LueSenderName.EditValue = Convert.ToInt64(model.Sender_Id);
            this.Lbl_Measure.Text = model.Measure;
            this.Lbl_DefaultMeasureEx.Text = model.DefaultMeasureEx.ToString();
            //this.txt_StoreRoomName.Text = model.StoreRoomName;
            this.LueStoreName.EditValue = Convert.ToInt64(model.Store_Room_Id);
            this.Lbl_Price.Text = base.SetNumFormat(model.Price) + "元";
            this.Lbl_SalerName.Text = model.SalerName;
            this.Lbl_ManuName.Text = model.ManuName;
            this.Lbl_RegNo.Text = model.RegNo;
            this.Lbl_Class_Name.Text = model.Class_Name;
            if (!string.IsNullOrEmpty(model.RegValidDate))
            {
                this.Lbl_RegValidDate.Text = Convert.ToDateTime(model.RegValidDate).ToShortDateString();
            }
            //修改自定义编码信息
            this.txtProductMnemonic.Text = model.ProductMnemonic;
            this.txtSelfPackage.Text = model.SelfPackage;
            if (string.IsNullOrEmpty(this.txtSelfPackage.Text))
            {
                this.txtSelfPackage.Text = "1";
            }

            this.txtAlias.Text = model.Alias;
            this.txtAliasPinyin.Text = model.AliasPinyin;
        }
        
        #region 初始化表格下拉框
        /// <summary>
        /// 初始化表格下拉框
        /// </summary>
        private void Init_Cmb()
        {
            //初始化库房下拉框
            InitData_StoneInfo();
            //初始化配送企业下拉框
            InitData_BuyerSender(base.CurrentUserOrgId, this.ordHitCommModel.Project_Id, this.ordHitCommModel.Project_Product_Id);
        }

        /// <summary>
        /// 初始化库房下拉框
        /// </summary>
        private void InitData_StoneInfo()
        {
            DataTable dtStone = CommUtilBLL.GetInstance().GetBuyerStoreInfo(base.CurrentUserOrgId);

            this.LueStoreName.Properties.DataSource = dtStone;
        }

        /// <summary>
        /// 根据买方ID，项目ID，项目产品ID绑定配送商
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectProdId"></param>
        private void InitData_BuyerSender(string buyerId, string projectId, string projectProdId)
        {
            DataTable SenderDt = CommUtilBLL.GetInstance().GetSenderInfo(buyerId, projectId, projectProdId);

            this.LueSenderName.Properties.DataSource = SenderDt;
        }

        #endregion

        #region 保存操作
        /// <summary>
        /// 修改保存操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtProductMnemonic.Text))
            {
                if (DefineCodeBLL.GetInstance().DefineCodeIsAddProductMnemonic(this.txtProductMnemonic.Text, strHitCommID))
                {
                    XtraMessageBox.Show("自定义编码已存在，请重新输入！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtProductMnemonic.Focus();
                    return;
                }
            }

            if (this.LueSenderName.EditValue == null)
            {
                XtraMessageBox.Show("请选择配送商企业！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrdHitCommMode ordHitCommmodel = GetOrdHitCommModel();

            List<DefineInfoModel> defineInfoListmodel = new List<DefineInfoModel>();
            DefineInfoModel defineInfoModel = GetDefineInfoModel();
            defineInfoListmodel.Add(defineInfoModel);
            try
            {
                StockListBLL.GetInstance().PostOrdHitCommInfo(ordHitCommmodel, CurrentUser);
                DefineCodeBLL.GetInstance().OperatorDefineInfoList(defineInfoListmodel, CurrentUser);
                XtraMessageBox.Show("采购目录信息修改成功！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.EditFlag = true;

                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("采购目录信息修改失败！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //获取当前采购目录修改对象
        private OrdHitCommMode GetOrdHitCommModel()
        {
            OrdHitCommMode model = new OrdHitCommMode();

            model.Id = strHitCommID;
            model.Store_Room_Id = this.LueStoreName.EditValue.ToString();
            model.StoreRoomName = this.LueStoreName.Text.ToString();
            model.Sender_Id = this.LueSenderName.EditValue.ToString();
            model.SenderName = this.LueSenderName.Text.ToString();

            return model;
        }

        //获取当前自定义编码修改对象
        private DefineInfoModel GetDefineInfoModel()
        {
            DefineInfoModel model = new DefineInfoModel();

            model.Hit_Comm_Id = strHitCommID;
            model.ProductMnemonic = this.txtProductMnemonic.Text.Trim();
            model.SelfPackage = this.txtSelfPackage.Text.Trim();
            model.Alias = this.txtAlias.Text.Trim();
            model.AliasPinyin = this.txtAliasPinyin.Text.Trim();

            return model;
        }
        #endregion

        #region 回车事件
        private void LueSenderName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.LueStoreName.Focus();
            }
        }

        private void LueStoreName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtProductMnemonic.Focus();
            }
        }

        private void txtProductMnemonic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtSelfPackage.Focus();
            }
        }

        private void txtSelfPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtAlias.Focus();
            }
        }

        private void txtAlias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.txtAliasPinyin.Focus();
            }
        }
        
        private void txtAliasPinyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.BtnSave.Focus();
            }
        }
        #endregion
    }
}