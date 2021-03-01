using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;

namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class FormPurchaseOrder : Emedchina.TradeAssistant.Client.Base.BaseForm
    {
        //采购单ID
        public string purchaseId;
        //取得DataGridView当前行
        public DataRow dr;

        //供打印采购单明细用的datatable
        public DataTable dtPrint;
        //供打印用户信息
        public UserInfoModel usInfo;
        public FormPurchaseOrder()
        {
            InitializeComponent();
        }

        #region 关闭当前窗体
        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
 

        //#region 初始化订单列表窗体

        ///// <summary>
        ///// 初始化订单列表窗体

        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FormPurchaseOrder_Load(object sender, EventArgs e)
        //{

        //    DataTable dt = PurchaseClientDao.GetInstance("ClientDB").getOrder(purchaseId);
        //    DataView dv = dt.DefaultView;

        //    this.BsOrderList.DataSource = dv;

        //    if (dv.Count > 0)
        //    {
        //        DataRow drs = dv.ToTable().Rows[0];
        //        setItemLable();
        //        string orderIdItem = drs["order_id"].ToString();
        //        this.setFilterItem(orderIdItem);
        //    }

        //    //显示订单列表记录条数
        //    this.lbOrderRecordcount.Text = this.dgvOrderList.Rows.Count.ToString() + "条记录";
        //    //显示订单明细列表记录条数
        //    this.lbItemRecordcount.Text = this.dgvOrderItem.Rows.Count.ToString() + "条记录";

        //}
        // #endregion
        //#region 设置明细列表项的详细说明
        ///// <summary>
        ///// 设置明细列表项的详细说明
        ///// </summary>
        ///// <param name="olm"></param>        
        //private void setItemLable()
        //{
        //    this.lbOrderCode.Text = dr["PURCHASE_CODE"].ToString();
        //    this.lbCreateDate.Text = dr["CREATE_DATE"].ToString();
        //    //格式化数字格式
        //    Double rq_total = Convert.ToDouble(dr["request_total"]);
        //    string Request_total = rq_total.ToString("#,##0.00;(#,##0.00);Zero");

        //    this.lbTotal.Text = Request_total + "(元)";
        //    this.lbState.Text = dr["purchase_state"].ToString();
        //    this.lbCreateName.Text = dr["create_username"].ToString();
        //    this.lbTel.Text = dr["buyer_link_tel1"].ToString();
        //}
        // #endregion
        //#region　设置采购单明细表过滤条件
        ///// <summary>
        ///// 设置订单明细表过滤条件

        ///// </summary>
        ///// <param name="orderId">订单列表ID</param>
        //private void setFilterItem(string orderId)
        //{
        //    //如果订单列表ID为空时返回值就是空。

        //    if (string.IsNullOrEmpty(orderId))
        //    {
        //        BsOrderItem.RemoveFilter();
        //        return;
        //    }

        //    int rows;
        //    Emedchina.Commons.UserInfo ui = new Emedchina.Commons.UserInfo();
        //    ui.AreaId = base.CurrentUserSingleRegionId;
        //    ui.OrgId = base.CurrentUserRegOrgId;

        //    DataTable dt = OrderListClientDao.GetInstance("ClientDB").getOrderListByOrderId(ui, orderId);
        //    DataView dv = dt.DefaultView;

        //    this.BsOrderItem.DataSource = dv;
        //    //this.BsOrderItem.Filter = string.Format(" order_id='{0}'", orderId);
        //}
        // #endregion


    }
}

