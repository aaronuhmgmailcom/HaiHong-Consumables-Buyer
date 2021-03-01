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
using DevExpress.Utils;

namespace Emedchina.TradeAssistant.Client.UI.TradeManage.DoWithOrder
{
    public partial class DoWithOrder : BaseForm
    {
        private OrderDetailSearchModel searchBean;
        private BuyerOrderModel input;
        private DataSet ds = null;
        private OrderModel orderModel;
        public DoWithOrder()
        {
            InitializeComponent();
        }

        public DoWithOrder(OrderModel buyerOrder, BuyerOrderModel input)
        {
            InitializeComponent();
            input = new BuyerOrderModel();
            input.UserId = base.CurrentUserId;
            input.UserName = base.CurrentUserName;
            input.SalerId = base.CurrentUserRegOrgId;
            input.AreaId = base.CurrentUserSingleRegionId;
            input.HighId = ClientSession.GetInstance().CurrentUser.HighId;
            input.Flag = "1";

            ClearTxt();
            orderModel = buyerOrder;
            input = input;
            input.OrderId = orderModel.Id;
            searchNoArrived();

            if (!buyerOrder.OrderState.Equals("处理中") && !buyerOrder.OrderState.Equals("确认"))
            {
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage3;
                this.xtraTabControl1.TabPages.Remove(this.xtraTabPage2);
                this.xtraTabControl1.TabPages.Remove(this.xtraTabPage1);
            }

            
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
            this.lcTotal.Text = "";
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

            this.lcOrderCode3.Text = orderModel.OrderCode;
            this.lcCreater3.Text = orderModel.CreateUserName.Trim();
            this.lcCreateTime3.Text = orderModel.CreateDate;
            this.lcSaler3.Text = orderModel.SalerName;
            this.lcPurchaseState3.Text = orderModel.OrderState;
            this.lcModifyer3.Text = orderModel.ModifyUserName;
            this.lcModifyTime3.Text = orderModel.ModifyDate;
            this.lcSender3.Text = orderModel.SenderName;
            this.lcTotal3.Text = SetNumFormat(orderModel.Total_sum) + "元"; ;
            this.lcSalerPeople3.Text = orderModel.SalerApproverName;
            this.lcAffirmTiem3.Text = orderModel.SalerApproveDate;
            this.lcBuyerRemark3.Text = orderModel.BuyerRemark;
            this.lcTotalFinish3.Text = SetNumFormat(orderModel.Over_sum) + "元";
            this.lcSalerRemark3.Text = orderModel.SalerRemark;

            //this.rtbRemarkA2.Text = orderModel.BuyerRemark;

            if (searchBean == null)
            {
                searchBean = new OrderDetailSearchModel();
            }
            searchBean.OrderId = this.orderModel.Id;
            searchBean.ProductName = this.txtSearchKey.Text;
            int rows;
            

            //ds = OrderDetailOfflineBLL.GetInstance().GetOrderDetailByOrderDs(searchBean, out rows);
            ds = OrderDetailOfflineBLL.GetInstance().GetOrderDetailByOrderDs(searchBean);


            this.cachedBindingSource.DataSource = ds;
            this.cachedBindingSource.DataMember = "OrderDetailByOrder";

        }


        private void DoWithOrder_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage2)
            {
                searchArrived();
            }
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage3)
            {
                orderDetailFaTabStripItem_Enter();
            }
          
        }


        /// <summary>
        /// 已到货列表的检索
        /// </summary>
        /// User: yb
        private void searchArrived()
        {
            Commons.UserInfo ui = new Commons.UserInfo();

            

            ui.AreaId = this.CurrentUserSingleRegionId;
            ui.OrgId = this.CurrentUserRegOrgId;
            string id = orderModel.Id;

            this.lcOrderCode2.Text = orderModel.OrderCode;
            this.lcCreater2.Text = orderModel.CreateUserName.Trim();
            this.lcCreateTime2.Text = orderModel.CreateDate;
            this.lcSaler2.Text = orderModel.SalerName;
            this.lcPurchaseState2.Text = orderModel.OrderState;
            this.lcModifyer2.Text = orderModel.ModifyUserName;
            this.lcModifyTime2.Text = orderModel.ModifyDate;
            this.lcSender2.Text = orderModel.SenderName;
            this.lcTotal2.Text = SetNumFormat(orderModel.Total_sum) + "元"; ;
            this.lcSalerPeople2.Text = orderModel.SalerApproverName;
            this.lcAffirmTiem2.Text = orderModel.SalerApproveDate;
            this.lcBuyerRemark2.Text = orderModel.BuyerRemark;
            this.lcTotalFinish2.Text = SetNumFormat(orderModel.Over_sum) + "元";
            this.lcSalerRemark2.Text = orderModel.SalerRemark;

            this.rtbRemarkA2.Text = orderModel.BuyerRemark;


            DataSet ds = null;

            ds = OrderTempOfflineBLL.GetInstance().getArrivedList(ui, "1", id, this.input);
           
            DataTable arrived = new DataTable("ARRIVESALER");
            arrived = ds.Tables[0].Copy();
            if (ClientCache.CachedDS.Tables["ARRIVESALER"] != null)
                ClientCache.CachedDS.Tables.Remove("ARRIVESALER");

            ClientCache.CachedDS.Tables.Add(arrived);
            InitFromCache("ARRIVESALER");

            this.ArrivedbindingSource.DataSource = null;
            this.ArrivedbindingSource.DataSource = base.cachedDataView;
        }

        /// <summary>
        /// 进入订单详细列表Tab页时
        /// $Author:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderDetailFaTabStripItem_Enter()
        {
            doOperate();
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            orderItemFilter();
        }


        #region 明细查询过滤方法
        /// <summary>
        ///明细查询过滤方法
        /// </summary>
        private void orderItemFilter()
        {
            

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            string productname = this.txtSearchKey.Text;
            if (!string.IsNullOrEmpty(productname))
            {
                StrFilter.AppendFormat("  And (PRODUCT_NAME Like '%{0}%' Or COMMERCE_NAME Like '%{0}%' Or CODE Like '%{0}%' Or ABBR_WB Like '%{0}%' Or ABBR_PY Like '%{0}%' Or COMMON_NAME Like '%{0}%') ", productname);
            }


            if (this.ds.Tables["OrderDetailByOrder"].DefaultView != null)
            {
                this.ds.Tables["OrderDetailByOrder"].DefaultView.RowFilter = StrFilter.ToString();
                this.cachedBindingSource.DataSource = null;
                this.cachedBindingSource.DataSource = this.ds.Tables["OrderDetailByOrder"].DefaultView;
             
            }

        }
        #endregion

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (input==null)
            {
                input = new BuyerOrderModel();
                input.UserId = base.CurrentUserId;
                input.UserName = base.CurrentUserName;
                input.SalerId = base.CurrentUserRegOrgId;
                input.AreaId = base.CurrentUserSingleRegionId;
                input.OrderId = orderModel.Id;
                input.Remark = this.rtbRemarkA.Text;
            }



            //离线
            if (BuyerOrderOfflineBLL.GetInstance().SaveRemark(input))
            {
                XtraMessageBox.Show("保存成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClientSession.GetInstance()["remark"] = input.Remark;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage2)
            {
                searchArrived();
            }
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage3)
            {
                orderDetailFaTabStripItem_Enter();
            }
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage1)
            {
                searchNoArrived();
            }
        }

        private void searchNoArrived()
        {
            this.lcOrderCode.Text = orderModel.OrderCode;
            this.lcCreater.Text = orderModel.CreateUserName.Trim();
            this.lcCreateTime.Text = orderModel.CreateDate;
            this.lcSaler.Text = orderModel.SalerName;
            this.lcPurchaseState.Text = orderModel.OrderState;
            this.lcModifyer.Text = orderModel.ModifyUserName;
            this.lcModifyTime.Text = orderModel.ModifyDate;
            this.lcSender.Text = orderModel.SenderName;
            this.lcTotal.Text = SetNumFormat(orderModel.Total_sum) + "元"; ;
            this.lcSalerPeople.Text = orderModel.SalerApproverName;
            this.lcAffirmTiem.Text = orderModel.SalerApproveDate;
            this.lcBuyerRemark.Text = orderModel.BuyerRemark;
            this.lcTotalFinish.Text = SetNumFormat(orderModel.Over_sum) + "元";
            this.lcSalerRemark.Text = orderModel.SalerRemark;

            this.rtbRemarkA.Text = orderModel.BuyerRemark;

            int rows=0;
            DataSet ds = null;

            ds = BuyerOrderOfflineBLL.GetInstance().GetNoArriveList(orderModel, input, out rows);

            

            this.bindingSourceNoArrive.DataSource = null;
            this.bindingSourceNoArrive.DataSource = ds.Tables[0];

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.gridView3.RowCount <= 0) return;
            if(checkEdit1.Checked)
            {
                for (int i = 0; i < this.gridView3.RowCount; i++)
                {
                    DataRow drrow = gridView3.GetDataRow(i);
                    drrow["chk"] = "1";
                    
                }
            }
            else
            {
                for (int i = 0; i < this.gridView3.RowCount; i++)
                {
                    DataRow drrow = gridView3.GetDataRow(i);
                    drrow["chk"] ="0";
                    
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            doOperate();
        }

        private void btnOver_Click(object sender, EventArgs e)
        {
            try
            {
                if (input != null)
                {
                    input.List.Clear();
                }
                else
                {
                   
                    input = new BuyerOrderModel();
                    input.UserId = base.CurrentUserId;
                    input.UserName = base.CurrentUserName;
                    input.SalerId = base.CurrentUserRegOrgId;
                    input.AreaId = base.CurrentUserSingleRegionId;
                    input.OrderId = orderModel.Id;
                    input.Remark = this.rtbRemarkA.Text;
                    
                }
                int rowCount = 0;
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    DataRow row = gridView3.GetDataRow(i);
                    if (row["chk"] != null && row["chk"].ToString()=="1")
                        rowCount++;
                }
                if (rowCount < 1)
                {
                    XtraMessageBox.Show("请选择记录后再进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    DataRow row = gridView3.GetDataRow(i);
                    if (row["chk"] != null && row["chk"].ToString()=="1")
                    {
                        OrderItemModel item = new OrderItemModel();
                        item.StockupId = row["Stockup_Id"].ToString();
                        item.Order_item_id = row["id"].ToString();
                        item.RequestQty = row["Request_Qty"].ToString();
                        item.LotNo = row["Lot_No"].ToString();
                        item.ReceiveQty = row["Receive_Qty"].ToString();

                        item.BuyerId  = row["buyer_Id"].ToString();
                        item.BuyerName = row["buyer_Name"].ToString();
                        item.BuyerNameAbbr = row["buyer_Name_Abbr"].ToString();
                        item.SalerId = row["saler_Id"].ToString();
                        item.SalerName = row["saler_Name"].ToString();
                        item.SalerNameAbbr = row["saler_Name_Abbr"].ToString();
                        item.SenderId = row["sender_Id"].ToString();
                        item.SenderName = row["sender_Name"].ToString();
                        item.SenderNameAbbr = row["sender_Name_Abbr"].ToString();
                        item.ManuId = row["MANUFACTURE_ID"].ToString();
                        item.ManuName = row["MANUFACTURE_NAME"].ToString();
                        item.ManuNameAbbr = row["MANUFACTURE_NAME_ABBR"].ToString();

                        item.ProductName = row["product_Name"].ToString();
                        item.ProductCode = row["product_Code"].ToString(); 
                        item.Spec_id = row["spec_id"].ToString(); 
                        item.Model_id = row["model_id"].ToString(); 
                        item.Spec = row["spec"].ToString(); 
                        item.Model = row["model"].ToString();
                        item.CommonName = row["common_Name"].ToString(); 
                        item.Brand = row["brand"].ToString();
                        item.BaseMeasureSpec = row["base_Measure_Spec"].ToString();
                        item.BaseMeasureMater = row["base_Measure_Mater"].ToString();
                        item.BaseMeasure = row["base_Measure"].ToString();
                        item.Send_measure_ex = row["send_measure_ex"].ToString();
                        item.Send_measure = row["send_measure"].ToString();


                        item.ProductId = row["PROJECT_PROD_ID"].ToString();
                        item.TradePrice = row["trade_Price"].ToString();
                        item.RetailPrice = row["RETAIL_PRICE"].ToString();
                        item.Project_id = row["project_id"].ToString();
                        item.Project_product_id = row["PROJECT_PROD_ID"].ToString();
                        item.Pbno = row["Pbno"].ToString();
                        item.Send_batch_no = row["Send_batch_no"].ToString();
                        item.Store_room_id = row["store_room_id"].ToString();
                        item.Store_room_name = row["store_room_name"].ToString();      
                                    



                                            
                                        
                        input.List.Add(item);
                    }
                }
                //end modify


                BuyerOrderOfflineBLL.GetInstance().CompleteOrderItem(input);

                int rows;
                DataSet ds = null;

                ds = BuyerOrderOfflineBLL.GetInstance().GetNoArriveList(orderModel, input, out rows);

                this.bindingSourceNoArrive.DataSource = null;
                this.bindingSourceNoArrive.DataSource = ds.Tables[0];

                //string temp = string.Empty;
                //string state = string.Empty;

                //temp = BuyerOrderOfflineBLL.GetInstance("ClientDB").GetReceiveTotalByOrder(input);
                //state = BuyerOrderOfflineBLL.GetInstance("ClientDB").GetOrderState(input);

                string overSum = BuyerOrderOfflineDAO.GetInstance().GetOrderOverSum(input.OrderId);
                orderModel.Over_sum = overSum;

                string state = BuyerOrderOfflineDAO.GetInstance().GetOrderState(input.OrderId);
                orderModel.OrderState = state;

                this.lcPurchaseState.Text = orderModel.OrderState;
                this.lcTotalFinish.Text = SetNumFormat(orderModel.Over_sum) + "元";
                //this.orderTitle.lblReceive.Text = temp.Trim() + "(元)";
                //this.orderTitle.lblState.Text = state;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            XtraMessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 作废按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbondon_Click(object sender, EventArgs e)
        {
            preOrderItemCancel();
        }

        /// <summary>
        /// 作废功能前奏
        /// </summary>
        private void preOrderItemCancel()
        {
            DataRow drow = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            if (drow != null)
            {
                string orderItemId = drow["id"].ToString();
                string itemStatus = drow["status"].ToString();

                string message = "作废订单明细?";
                string caption = "操作";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = XtraMessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    doOrderItemCancel(orderItemId);
                }
            }
        }

        /// <summary>
        /// 作废操作
        /// </summary>
        private void doOrderItemCancel(string orderItemId)
        {
            
            OrderItemInputModel input = new OrderItemInputModel();
            input.OrderItemId = orderItemId;
            input.UserId = base.CurrentUserId;
            input.UserName = base.CurrentUserName;
            input.HighId = ClientSession.GetInstance().CurrentUser.HighId;

            string orderId = string.Empty;
           
            orderId = OrderDetailOfflineBLL.GetInstance().doOrderItemCancel(input);
            
            
            doOperate();
        }

      

        private void btnAffirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (input != null)
                {
                    input.List.Clear();
                }
                else
                {

                    input = new BuyerOrderModel();
                    input.UserId = base.CurrentUserId;
                    input.UserName = base.CurrentUserName;
                    input.SalerId = base.CurrentUserRegOrgId;
                    input.AreaId = base.CurrentUserSingleRegionId;
                    input.OrderId = orderModel.Id;
                    input.Remark = this.rtbRemarkA.Text;
                    input.HighId = ClientSession.GetInstance().CurrentUser.HighId; ;
                }

                int rowCount = 0;
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    DataRow row = gridView3.GetDataRow(i);
                    if (row["chk"] != null && row["chk"].ToString() == "1")
                        rowCount++;
                }
                if (rowCount < 1)
                {
                    XtraMessageBox.Show("请选择记录后再进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //if (!checkInput())
                //    return;

                
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    DataRow row = gridView3.GetDataRow(i);
                    if (row["chk"] != null && row["chk"].ToString() == "1")
                    {
                        OrderItemModel item = new OrderItemModel();
                        item.StockupId = row["Stockup_Id"].ToString();
                        item.RequestQty = row["Request_Qty"].ToString();
                        item.LotNo = row["Lot_No"].ToString();
                        item.ReceiveQty = row["Receive_Qty"].ToString();
                        item.Order_item_id = row["id"].ToString();
                        item.ProductId = row["Product_Id"].ToString();
                        //item.Amount = row["amount"].ToString();
                        //item.Discount = dgvNoArrive.Rows[i].Cells["discount"].Value.ToString();
                        //item.InvoiceDate = dgvNoArrive.Rows[i].Cells["invoiceDate"].Value.ToString();
                        //item.InvoiceExpireDate = dgvNoArrive.Rows[i].Cells["invoiceExpireDate"].Value.ToString();
                        //item.InvoiceNo = dgvNoArrive.Rows[i].Cells["invoiceNo"].Value.ToString();
                        //item.ReceiveRemark = dgvNoArrive.Rows[i].Cells["receiveRemark"].Value.ToString();
                        //item.RepositoryId = dgvNoArrive.Rows[i].Cells["repositoryId"].Value.ToString();
                        item.RetailPrice = row["RETAIL_PRICE"].ToString();
                        item.TradePrice = row["trade_Price"].ToString();
                        item.Project_id = row["project_id"].ToString();
                        item.Project_product_id = row["project_prod_id"].ToString();
                        item.Pbno = row["pbno"].ToString();
                        item.Send_batch_no = row["send_batch_no"].ToString();
                        item.Store_room_id = row["store_room_id"].ToString();
                        item.Store_room_name = row["store_room_name"].ToString();


                        item.BuyerId = row["buyer_Id"].ToString();
                        item.BuyerName = row["buyer_Name"].ToString();
                        item.BuyerNameAbbr = row["buyer_Name_Abbr"].ToString();
                        item.SalerId = row["saler_Id"].ToString();
                        item.SalerName = row["saler_Name"].ToString();
                        item.SalerNameAbbr = row["saler_Name_Abbr"].ToString();
                        item.SenderId = row["sender_Id"].ToString();
                        item.SenderName = row["sender_Name"].ToString();
                        item.SenderNameAbbr = row["sender_Name_Abbr"].ToString();
                        item.ManuId = row["MANUFACTURE_ID"].ToString();
                        item.ManuName = row["MANUFACTURE_NAME"].ToString();
                        item.ManuNameAbbr = row["MANUFACTURE_NAME_ABBR"].ToString();

                        item.ProductName = row["product_Name"].ToString();
                        item.ProductCode = row["product_Code"].ToString();
                        item.Spec_id = row["spec_id"].ToString();
                        item.Model_id = row["model_id"].ToString();
                        item.Spec = row["spec"].ToString();
                        item.Model = row["model"].ToString();
                        item.CommonName = row["common_Name"].ToString();
                        item.Brand = row["brand"].ToString();
                        item.BaseMeasureSpec = row["base_Measure_Spec"].ToString();
                        item.BaseMeasureMater = row["base_Measure_Mater"].ToString();
                        item.BaseMeasure = row["base_Measure"].ToString();
                        item.Send_measure_ex = row["send_measure_ex"].ToString();
                        item.Send_measure = row["send_measure"].ToString();


                        item.ProductId = row["PROJECT_PROD_ID"].ToString();
                        
                        item.RetailPrice = row["RETAIL_PRICE"].ToString();
                        item.Project_id = row["project_id"].ToString();
                        item.Project_product_id = row["PROJECT_PROD_ID"].ToString();
                        item.Pbno = row["Pbno"].ToString();
                        item.Send_batch_no = row["Send_batch_no"].ToString();
                        item.Store_room_id = row["store_room_id"].ToString();
                        item.Store_room_name = row["store_room_name"].ToString();      


                        input.List.Add(item);
                    }
                }
                
                    BuyerOrderOfflineBLL.GetInstance().ArrivedConfirm(input);
              
                int rows;
                DataSet ds = null;

                ds = BuyerOrderOfflineBLL.GetInstance().GetNoArriveList(orderModel, input, out rows);
                
                string overSum = BuyerOrderOfflineDAO.GetInstance().GetOrderOverSum(input.OrderId);
                orderModel.Over_sum = overSum;

                string state = BuyerOrderOfflineDAO.GetInstance().GetOrderState(input.OrderId);
                orderModel.OrderState = state;

                this.lcPurchaseState.Text = orderModel.OrderState;

                this.lcTotalFinish.Text = SetNumFormat(orderModel.Over_sum) + "元";

                input.Rows = rows;
                
                this.bindingSourceNoArrive.DataSource = null;
                this.bindingSourceNoArrive.DataSource = ds.Tables[0];

                //string temp = string.Empty;
                //string state = string.Empty;
                
                //    temp = BuyerOrderOfflineBLL.GetInstance("ClientDB").GetReceiveTotalByOrder(input);
                //    state = BuyerOrderOfflineBLL.GetInstance("ClientDB").GetOrderState(input);
             
                //this.orderTitle.lblReceive.Text = temp.Trim() + "(元)";
                //this.orderTitle.lblState.Text = state;

                if (ds.Tables[0].Rows.Count == 0)
                    this.rtbRemarkA.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            XtraMessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gridView6_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gridView5_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void DoWithOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView3.FocusedColumn.FieldName.ToLower() == "sender_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["sender_name"].ToString());
                else if (gridView3.FocusedColumn.FieldName.ToLower() == "manu_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

            }
        }

        private void toolTipLocationControl_ToolTipLocationChanged(string senderName)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = senderName;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gridView6_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView6.GetDataRow(gridView6.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView6.FocusedColumn.FieldName.ToLower() == "sender_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["sender_name"].ToString());
                else if (gridView6.FocusedColumn.FieldName.ToLower() == "manu_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

            }
        }

        private void gridView5_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView5.FocusedColumn.FieldName.ToLower() == "sender_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["sender_name"].ToString());
                else if (gridView5.FocusedColumn.FieldName.ToLower() == "manu_name_abbr")
                    toolTipLocationControl_ToolTipLocationChanged(dr["MANU_NAME"].ToString());

            }
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView3.FocusedColumn.FieldName.ToLower() == "lot_no")
                    dr["chk"] = "1";

            }

        }

        private void gridView3_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView3.FocusedColumn.FieldName.ToLower() == "lot_no")
                    dr["chk"] = "1";

            }
        }

        private void gridView5_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow dr = (DataRow)gridView5.GetDataRow(e.RowHandle);
            if (string.IsNullOrEmpty(dr["order_type"].ToString()))
                return;
            if (dr["order_type"].ToString() == "红票")
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (input != null)
                {
                    input.List.Clear();
                }
                else
                {

                    input = new BuyerOrderModel();
                    input.UserId = base.CurrentUserId;
                    input.UserName = base.CurrentUserName;
                    input.SalerId = base.CurrentUserRegOrgId;
                    input.AreaId = base.CurrentUserSingleRegionId;
                    input.OrderId = orderModel.Id;
                    input.Remark = this.rtbRemarkA.Text;

                }
                int rowCount = 0;
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    DataRow row = gridView3.GetDataRow(i);
                    if (row["chk"] != null && row["chk"].ToString() == "1")
                        rowCount++;
                }
                if (rowCount < 1)
                {
                    XtraMessageBox.Show("请选择记录后再进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    DataRow row = gridView3.GetDataRow(i);
                    if (row["chk"] != null && row["chk"].ToString() == "1")
                    {
                        OrderItemModel item = new OrderItemModel();
                        item.StockupId = row["Stockup_Id"].ToString();
                        item.Order_item_id = row["id"].ToString();
                        item.RequestQty = row["Request_Qty"].ToString();
                        item.LotNo = row["Lot_No"].ToString();
                        item.ReceiveQty = row["Receive_Qty"].ToString();

                        item.BuyerId = row["buyer_Id"].ToString();
                        item.BuyerName = row["buyer_Name"].ToString();
                        item.BuyerNameAbbr = row["buyer_Name_Abbr"].ToString();
                        item.SalerId = row["saler_Id"].ToString();
                        item.SalerName = row["saler_Name"].ToString();
                        item.SalerNameAbbr = row["saler_Name_Abbr"].ToString();
                        item.SenderId = row["sender_Id"].ToString();
                        item.SenderName = row["sender_Name"].ToString();
                        item.SenderNameAbbr = row["sender_Name_Abbr"].ToString();
                        item.ManuId = row["MANUFACTURE_ID"].ToString();
                        item.ManuName = row["MANUFACTURE_NAME"].ToString();
                        item.ManuNameAbbr = row["MANUFACTURE_NAME_ABBR"].ToString();

                        item.ProductName = row["product_Name"].ToString();
                        item.ProductCode = row["product_Code"].ToString();
                        item.Spec_id = row["spec_id"].ToString();
                        item.Model_id = row["model_id"].ToString();
                        item.Spec = row["spec"].ToString();
                        item.Model = row["model"].ToString();
                        item.CommonName = row["common_Name"].ToString();
                        item.Brand = row["brand"].ToString();
                        item.BaseMeasureSpec = row["base_Measure_Spec"].ToString();
                        item.BaseMeasureMater = row["base_Measure_Mater"].ToString();
                        item.BaseMeasure = row["base_Measure"].ToString();
                        item.Send_measure_ex = row["send_measure_ex"].ToString();
                        item.Send_measure = row["send_measure"].ToString();


                        item.ProductId = row["PROJECT_PROD_ID"].ToString();
                        item.TradePrice = row["trade_Price"].ToString();
                        item.RetailPrice = row["RETAIL_PRICE"].ToString();
                        item.Project_id = row["project_id"].ToString();
                        item.Project_product_id = row["PROJECT_PROD_ID"].ToString();
                        item.Pbno = row["Pbno"].ToString();
                        item.Send_batch_no = row["Send_batch_no"].ToString();
                        item.Store_room_id = row["store_room_id"].ToString();
                        item.Store_room_name = row["store_room_name"].ToString();


                        input.List.Add(item);
                    }
                }
                //end modify

                BuyerOrderOfflineBLL.GetInstance().CloseOrderItem(input);

                int rows;
                DataSet ds = null;

                ds = BuyerOrderOfflineBLL.GetInstance().GetNoArriveList(orderModel, input, out rows);

                this.bindingSourceNoArrive.DataSource = null;
                this.bindingSourceNoArrive.DataSource = ds.Tables[0];

                //string overSum = BuyerOrderOfflineDAO.GetInstance().GetOrderOverSum(input.OrderId);
                //orderModel.Over_sum = overSum;

                string state = BuyerOrderOfflineDAO.GetInstance().GetOrderState(input.OrderId);
                orderModel.OrderState = state;

                this.lcPurchaseState.Text = orderModel.OrderState;
                //this.lcTotalFinish.Text = SetNumFormat(orderModel.Over_sum) + "元";
               

            }
            catch (Exception ex)
            {
                throw ex;
            }

            XtraMessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}