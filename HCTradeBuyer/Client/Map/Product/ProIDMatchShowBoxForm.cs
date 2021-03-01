/*****************************************************************************
创 建 人:	罗澜涛
创建日期:	2007-5-21
功能描述:	海虹产品一对多匹配提示
 ********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Client.Base;

namespace Emedchina.TradeAssistant.Client.Map.Product
{
    public partial class ProIDMatchShowBoxForm : FormBase
    {

        #region 变量定义区
        public ContProductModel productmapitem;
        public bool IsAdd;
        public bool IsContinueMap;
        #endregion

        #region 构造函数
        public ProIDMatchShowBoxForm()
        {
            InitializeComponent();
        }

        public ProIDMatchShowBoxForm(ContProductModel contProductModel)
        {
            InitializeComponent();
            this.IsContinueMap = false;
            this.tbxMedicalName.Text = contProductModel.MedicalName;
            this.tbxProducer.Text = contProductModel.FactoryName;
            this.tbxProductName.Text = contProductModel.TradeName;
            this.tbxSpec.Text = contProductModel.UncSpec;

            this.bindingSource1.DataSource = contProductModel.MatchHisDT;
            this.lblHiscount.Text = "共" + this.dgvProIDCompare.Rows.Count + "条";
        }
        #endregion

        #region 确定事件
        private void dgvProIDCompare_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region 确定按钮事件
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.IsContinueMap = true;
            this.Close();
        }
        #endregion

        #region 确定按钮事件
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion

        #region 页面加载
        private void ProIDMatchShowBoxForm_Load(object sender, EventArgs e)
        {
            if (!this.IsAdd)
            {   //修改
                this.dgvProIDCompare.DoubleClick += new EventHandler(dgvProIDCompare_DoubleClick);
            }
        }
        #endregion

        #region 关闭按钮事件
        private void ProIDMatchShowBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.IsAdd)
            {   //修改
                //string productcode = this.dgvProIDCompare.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString();
                //productmapitem = ProductCodeCompareBLL.GetInstance(Constant.ACCESSDBALIAS).GetProductMapItemInstance(productcode);
            }
        }
        #endregion

    }
}