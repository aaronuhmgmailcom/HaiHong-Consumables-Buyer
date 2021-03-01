using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder;
using Emedchina.TradeAssistant.Client.Common;
using DevExpress.XtraEditors;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;
using Emedchina.TradeAssistant.Client.BLL.Order.BuyerOrder;

namespace Emedchina.TradeAssistant.Client.UI.TradeManage.DoWithOrder
{
    public partial class ViewBuyerOrder : BaseForm
    {

        private OrderDetailSearchModel searchBean;
        private BuyerOrderModel input;
        public ViewBuyerOrder()
        {
            InitializeComponent();
        }

        public ViewBuyerOrder(OrderModel buyerOrder)
        {
            InitializeComponent();
            input = new BuyerOrderModel();
            input.UserId = base.CurrentUserId;
            input.UserName = base.CurrentUserName;
            input.SalerId = base.CurrentUserRegOrgId;
            input.AreaId = base.CurrentUserSingleRegionId;
            
            input.Flag = "1";

            ClearTxt();
            this.lcOrderCode.Text = buyerOrder.OrderCode;
            this.lcCreater.Text = buyerOrder.CreateUserName.Trim();
            this.lcCreateTime.Text = buyerOrder.CreateDate;
            this.lcSaler.Text = buyerOrder.SalerName;
            this.lcPurchaseState.Text = buyerOrder.OrderState;
            this.lcModifyer.Text = buyerOrder.ModifyUserName;
            this.lcModifyTime.Text = buyerOrder.ModifyDate;
            this.lcSender.Text = buyerOrder.SenderName;
            this.lcTotal.Text = buyerOrder.Total_sum + "(元)"; ;
            this.lcSalerPeople.Text = buyerOrder.SalerApproverName;
            this.lcAffirmTiem.Text = buyerOrder.SalerApproveDate;
            this.lcBuyerRemark.Text = buyerOrder.BuyerRemark;
            this.lcTotalFinish.Text = buyerOrder.Over_sum + "(元)"; 
            this.lcSalerRemark.Text = buyerOrder.SalerRemark;


           

            
        }


        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void lcBuyerRemark_Click(object sender, EventArgs e)
        {

        }

        private void ClearTxt()
        {
            this.lcOrderCode.Text = "";
            this.lcCreater.Text = "";
            this.lcCreateTime.Text = "";
            this.lcSaler.Text = "";
            this.lcPurchaseState.Text = "";
            this.lcModifyer.Text = "";
            this.lcModifyTime.Text = "";
            this.lcSender.Text = "";
            this.lcTotal.Text = "" ;
            this.lcSalerPeople.Text = "";
            this.lcAffirmTiem.Text = "";
            this.lcBuyerRemark.Text = "";
            this.lcTotalFinish.Text = "";
            this.lcSalerRemark.Text = "";

        }

        /// <summary>
        /// 查询显示列表操作
        /// </summary>
        public void doOperate()
        {
           


            if (searchBean == null)
            {
                searchBean = new OrderDetailSearchModel();
            }
           
            searchBean.ProductName = "";
            
           
            int rows;
            // DataSet ds = remote.GetOrderDetailListByOrder(searchBean, param, out rows);

            DataSet ds = null;
            
            ds = OrderDetailOfflineBLL.GetInstance().GetOrderDetailByOrderDs(searchBean, out rows);
            
            

           
            this.cachedBindingSource.DataSource = ds;
            this.cachedBindingSource.DataMember = "OrderDetailByOrder";
            
            
            

        }


    }
}