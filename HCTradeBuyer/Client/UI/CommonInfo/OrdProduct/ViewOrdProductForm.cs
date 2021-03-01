//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	ViewOrdProductForm.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	商品详细信息显示
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

using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo.OrdProduct
{
    /// <summary>
    /// 商品详细信息显示
    /// </summary>
    public partial class ViewOrdProductForm : BaseForm
    {
        #region 变量定义区
        //备货单主表对象
        private OrdProductModel ordProductModel = null;
        #endregion

        #region 构造
        public ViewOrdProductForm()
        {
            InitializeComponent();
        }

        public ViewOrdProductForm(string strProjectProductId, string strSpec, string strModel)
        {
            InitializeComponent();
            IniData(strProjectProductId, strSpec, strModel);
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewOrdProductForm_Load(object sender, EventArgs e)
        {
            btnClose.Focus();
        }        
        #endregion

        #region 初始化显示
        /// <summary>
        /// 初始化显示
        /// </summary>
        /// <param name="strProjectProductId"></param>
        /// <param name="strSpec"></param>
        /// <param name="strModel"></param>
        private void IniData(string strProjectProductId, string strSpec, string strModel)
        {
            //项目产品对象
            ordProductModel = OrdProductBLL.GetInstance().Get_OrdProductModel(strProjectProductId);

            if (ordProductModel != null)
            {
                
                this.LblProductName.Text = ordProductModel.Product_Name;            //产品名称
                this.LblCommonName.Text = ordProductModel.Common_Name;              //通用名称
                this.LblRegNo.Text = ordProductModel.Reg_No;                        //注册号
                if (!string.IsNullOrEmpty(ordProductModel.Reg_Valid_Date))          //产品注册有效期
                {
                    this.LblReg_Valid_Date.Text = Convert.ToDateTime(ordProductModel.Reg_Valid_Date).ToShortDateString();
                }
                this.LblSpec.Text = strSpec;                                        //规格
                this.LblModel.Text = strModel;                                      //型号
                this.LblBrand.Text = ordProductModel.Brand;                         //品牌
                this.LblManu_Name.Text = ordProductModel.ManuName;                  //生产企业
                this.LblSalerName.Text = ordProductModel.SalerName;                 //经销企业
                this.LblPrice.Text = base.SetNumFormat(ordProductModel.Price.ToString()) + "元";//单价
                this.LblBASE_MEASURE.Text = ordProductModel.Base_Measure;           //计量单位
                this.mePerformance.Text = ordProductModel.Performance;              //性能与组成
                this.Lbl_ClassName.Text = ordProductModel.Class_Name;               //品种分类名称

            }
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
    }
}