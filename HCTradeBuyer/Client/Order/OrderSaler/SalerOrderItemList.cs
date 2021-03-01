using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.BLL.Order.SalerOrder;
using Emedchina.TradeAssistant.Client.Common;

namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    public partial class SalerOrderItemList : FormBase
    {
        private string m_orderid = null;
        private string m_type = null;
        private bool m_flag;
        private bool IsOfflineOrderList = true ;//�Ƿ����ߴ���
        private SalerOrderItemModel m_model;
        private SalerOrderModel m_Ordermodel;
        private SalerOrderModel model;

        private bool m_DealFlg;
        bool isEdit = true;
        private SalerOrderList frm;
        private OutputInfoModel mdl;
        private IList  iSendlist;

        public SalerOrderItemList()
        {
            InitializeComponent();
            
        }
        public SalerOrderItemList(string orderId, string type, IList ilist)
        {
            InitializeComponent();
            IsOfflineOrderList = ClientConfiguration.IsOffline;
            m_orderid = orderId;
            this.iSendlist = ilist;         
            m_type = type;    
            
        }
        public SalerOrderItemList(string orderId, string state, SalerOrderList frm1)
        {
            InitializeComponent();
            IsOfflineOrderList = ClientConfiguration.IsOffline;
            m_orderid = orderId;
            m_flag = state.Equals("0");
            frm = frm1;
        }

        public SalerOrderItemList(string orderId, bool flg, SalerOrderList frm1)
        {
            InitializeComponent();
            IsOfflineOrderList = ClientConfiguration.IsOffline;
            m_orderid = orderId;
            m_DealFlg = flg;
            frm = frm1;

        }

        private void tabCtlOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fillInvoice = "false";
                //this.tabCtlOrderItem.SelectedTab.ForeColor = Color.Orange;

                if (this.tabCtlOrderItem.SelectedTab == this.tabOrderItem)
                {
                    //������ϸ�б�ҳ
                    this.txtRemark.Enabled = false;
                    searchOrderItemTab();
                }
                else if (this.tabCtlOrderItem.SelectedTab == this.tabNoSend)
                {
                    //���ͻ��б�ҳ
                    this.txtRemark.Enabled = true;
                    this.chbAll.Checked = false;
                    searchOrderItem();
                }
                else if (this.tabCtlOrderItem.SelectedTab == this.tabAffirm)
                {
                    //��ȷ��/��ȷ���ͻ��б�ҳ
                    this.txtRemark.Enabled = false;
                    selectOrderPrepareItemList("show", fillInvoice);
                }
                else if (this.tabCtlOrderItem.SelectedTab == this.tabArrive)
                {
                    //�ѵ����б�ҳ
                    this.txtRemark.Enabled = false;
                    selectOrderPrepareItemList("confirmed", fillInvoice);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SalerOrderItemList_Load(object sender, EventArgs e)
        {
                       
            
            //������ɡ�ʱ
            if (m_DealFlg)
            {
                tabCtlOrderItem.SelectTab(tabOrderItem);
                tabCtlOrderItem.TabPages.Remove(tabNoSend);
                tabCtlOrderItem.TabPages.Remove(tabAffirm);
                tabCtlOrderItem.TabPages.Remove(tabArrive);
            }
            else//���ǡ���ɡ�ʱ
            {
                tabCtlOrderItem.Visible = true;
                tabCtlOrderItem.Dock = DockStyle.Fill;
                tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[2].Height = 0;
                tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel1.RowStyles[1].Height = 1;
                searchOrderItem();

                //searchOrderItem();                
                
                dgvReturnNoSend.Select();
                if (dgvReturnNoSend.Rows.Count > 0)
                    dgvReturnNoSend.CurrentCell = dgvReturnNoSend.Rows[0].Cells["bakMedicalNameDataGridViewTextBoxColumn"];
                //txtReceiveNow.Focus();
            }
            //��ѯ������Ϣ������2007-8-8

            if (IsOfflineOrderList)
            {
                model = SalerOrderBLL.GetInstance().GetOrderTitle(m_orderid);
            }
            else
            {
                model = ProxyFactory.SalerOrderProxy.GetOrderTitle(m_orderid);
            }
            InitMain(model);
            m_Ordermodel = model;

	            
        }
 
        /// <summary>
        /// ȡ�ô��ͻ��б�����
        /// </summary>
        private void searchOrderItem()
        {
            IList ilist;      
            //�ж��Ƿ���δƥ�������

            //"�����ɹ�����"�ж�ҵ������("������"��ҵ�Խӹ���)��shangfu 2007-8-24
            //���Ϊ1���ǽ�����Խӽӿ�     

            string clientPlat = UserConfigXml.GetConfigInfo("ClientPlat", "type");

            bool impFlag = clientPlat.Equals("1");
            

            if (IsOfflineOrderList)
            {
                ilist = SalerOrderBLL.GetInstance().GetSalerOrderItemList(m_orderid, this.CurrentUserName, this.CurrentUserId, m_flag);
            }
            else
            {
                ilist = ProxyFactory.SalerOrderProxy.GetSalerOrderItemList(m_orderid, this.CurrentUserName, this.CurrentUserId, m_flag);
            }
            if (iSendlist != null && iSendlist.Count > 0)
            {
                foreach (SalerOrderItemModel modelsend in iSendlist)
                {
                    string sProduct_id = modelsend.ProductId.Trim();
                    string itemId = modelsend.RecordId.Trim();
                    foreach (SalerOrderItemModel model in ilist)
                    {
                        if (model.ProductId == sProduct_id && model.RecordId.Equals(itemId) || impFlag && model.RecordId.Equals(itemId)) 
                        {
                            model.LotNo = modelsend.LotNo;
                            model.ReceiveQty1 = modelsend.ReceiveQty1;
                            model.InvoiceNo = modelsend.InvoiceNo;
                            model.InvoiceDate = modelsend.InvoiceDate;
                            model.InvoiceTotal = modelsend.InvoiceTotal;
                            model.InvoiceExpireDate = modelsend.InvoiceExpireDate;
                            model.AppNum = modelsend.AppNum;
                            model.InvoiceTradePrice = modelsend.InvoiceTradePrice;
                            model.InvoiceRetailPrice = modelsend.InvoiceRetailPrice;
                            model.InvoiceDiscountRate = modelsend.InvoiceDiscountRate;
                            model.ReadyRemark = modelsend.ReadyRemark;
                            model.IsChecked = modelsend.IsChecked;
                            model.ImpFlag = true;
                        }
                    }
                }
            }
            this.OrderItembindingSource.DataSource = ilist;
            

            checkBoxShow();
            if (ilist.Count > 0)
            {
                this.dgvReturnNoSend.Select();
                //this.dgvReturnNoSend..Refresh();
                //this.dgvReturnNoSend.Rows[0].Selected = true;
                
            }
        }

        /// <summary>
        /// ѡ�񶩵���ϸ�б�ҳ��ȡ���б�����
        /// </summary>
        private void searchOrderItemTab()
        {
            IList list;
            if (IsOfflineOrderList)
            {
                list = SalerOrderBLL.GetInstance().GetSalerOrderItemList(m_orderid);
            }
            else
            {
                list = ProxyFactory.SalerOrderProxy.GetSalerOrderItemList(m_orderid);
            }
            
            this.OrderItemListbindingSource.DataSource = list;
            changeColor();
            if (list.Count > 0)
            {
                this.dgvOrderItem.Select();
                this.dgvOrderItem.Rows[0].Selected = true;
            }

        }

        /// <summary>
        /// �Ӻ�ɫ
        /// </summary>
        private void changeColor()
        {
            foreach (DataGridViewRow row in this.dgvOrderItem.Rows)
            {
                double requestQty = double.Parse(row.Cells["requestQtyDataGridViewTextBoxColumn2"].Value.ToString());
                if (requestQty < 0)
                {
                    row.Cells["requestQtyDataGridViewTextBoxColumn2"].Style.ForeColor = Color.Red;
                    row.Cells["orderTypeDataGridViewTextBoxColumn"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void InitMain(SalerOrderModel model)
        {
            this.lblAddress.Text = model.Address;
            this.lblBuildOrderName.Text = model.User_name;
            this.lblBuyerName.Text = model.Bak_buyer_easy;
            this.lblCreateDate.Text = model.Create_date;
            this.lblCreateName.Text = model.User_name;
            this.lblOrderCode.Text = model.Order_code;
            this.lblOrderMoney.Text = model.Request_total;
            this.lblOrderState.Text = model.Order_state_name;
            this.lblWareHouse.Text = model.WareHouse;
            this.lblPostCode.Text = model.Post_code;
            this.lblTel.Text = model.TelePhone;
            this.lblReceiveTotal.Text = model.Receive_total;
            this.txtRemark.Text = model.Order_remark;
            this.lblLinkMan.Text = model.Linkman;
        }

        private void dtpInvoiceAllDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvReturnNoSend_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            IList returnList = (IList)this.OrderItembindingSource.DataSource;
            m_model = returnList[e.RowIndex] as SalerOrderItemModel;
            this.txtUnitPrice.Text = m_model.UnitPrice != null ? m_model.UnitPrice : ""; ;
            //if (dgvReturnNoSend.Rows[e.RowIndex].Cells["keys"].EditedFormattedValue.Equals(true))
                setInvoiceInfo();
            //else
            //    ClearInvoiceInfo();

            if (m_model.OrderItemState.Equals("2"))
            {
                this.btnOos.Enabled = true;
                //this.txtSalerDesc.Enabled = true;
            }
            else
            {
                this.btnOos.Enabled = false;
                //this.txtSalerDesc.Enabled = false;
            }
            if (m_model.OrderItemState.Equals("6"))
            {
                this.btnCancelOos.Enabled = true;
            }
            else
            {
                this.btnCancelOos.Enabled = false;
            }
            //if (true)
            //{
                
            //}
            //txtReceiveNow.Focus();
            txtReceiveNow.ReadOnly = false;
            //dgvReturnNoSend.Select();
            //dgvReturnNoSend.CurrentCell = dgvReturnNoSend.Rows[e.RowIndex].Cells["keys"];
                      
        }

        private void setInvoiceInfo()
        {
            if (string.IsNullOrEmpty(m_model.LotNo) && !m_model.ImpFlag)
                m_model.LotNo = "N/A";
            this.txtLotNo.Text = m_model.LotNo;
            this.txtReceiveNow.TextChanged -= new System.EventHandler(this.txtReceiveNow_TextChanged);
            if (string.IsNullOrEmpty(m_model.ReceiveQty1))
            {
                this.txtReceiveNow.Text = m_model.RequestQty;
            }
            else
            {
                this.txtReceiveNow.Text = m_model.ReceiveQty1;
            }
            m_model.ReceiveQty1 = this.txtReceiveNow.Text;
            //this.txtUnitPrice.Text = m_model.UnitPrice;
            
            this.txtInvoiceNo.Text = m_model.InvoiceNo;

            //if (string.IsNullOrEmpty(m_model.InvoiceTotal))
            //{                
            //    this.txtInvoiceMoney.Text = Convert.ToString((Convert.ToDouble(m_model.UnitPrice) * Convert.ToInt32(m_model.ReceiveQty1))); 
            //}
            //else
            //{
            //    this.txtInvoiceMoney.Text = m_model.InvoiceTotal;
            //}
            this.txtInvoiceMoney.Text = m_model.InvoiceTotal;

            this.txtReceiveRemark.Text = m_model.ReadyRemark;

            //if (string.IsNullOrEmpty(m_model.InvoiceRetailPrice))
            //    m_model.InvoiceRetailPrice = m_model.UnitPrice.ToString();

            this.txtRetailPrice.Text = m_model.InvoiceRetailPrice == null ? string.Empty : m_model.InvoiceRetailPrice.ToString();
            
                
            //if (string.IsNullOrEmpty(m_model.InvoiceTradePrice))
            //    m_model.InvoiceTradePrice = m_model.UnitPrice.ToString();
            this.txtTradePrice.Text = m_model.InvoiceTradePrice == null ? string.Empty : m_model.InvoiceTradePrice.ToString();


            if (string.IsNullOrEmpty(m_model.InvoiceExpireDate))
                dtpEffectDate.Checked = false;
            else
            {
               
                this.dtpEffectDate.Value = Convert.ToDateTime(m_model.InvoiceExpireDate.ToString());
                m_model.InvoiceExpireDate = ComUtil.formatDate(dtpEffectDate.Value.Date.ToString());
                dtpEffectDate.Checked = true;
            }

            if (string.IsNullOrEmpty(m_model.InvoiceDate))
                dtpInvoiceDate.Checked = false;
            else
            {
                this.dtpInvoiceDate.Value = Convert.ToDateTime(m_model.InvoiceDate.ToString());
                m_model.InvoiceDate = ComUtil.formatDate(dtpInvoiceDate.Value.Date.ToString());
                dtpInvoiceDate.Checked = true;
            }
            
                
            //if (string.IsNullOrEmpty(m_model.InvoiceDiscountRate))
            //    m_model.InvoiceDiscountRate = "100";
            this.txtDiscount.Text = m_model.InvoiceDiscountRate == null ? string.Empty : m_model.InvoiceDiscountRate.ToString();
            this.txtReceiveNow.TextChanged += new System.EventHandler(this.txtReceiveNow_TextChanged);
        }

        private void txtReceiveNow_TextChanged(object sender, EventArgs e)
        {
            int result;
            m_model.ReceiveQty1 = this.txtReceiveNow.Text;
            if (string.IsNullOrEmpty(m_model.ReceiveQty1) || !int.TryParse(m_model.ReceiveQty1, out result))
            {
                this.txtInvoiceMoney.Text = "";
                this.txtReceiveNow.Text = "";
            }
            else
            {
                m_model.InvoiceTotal = Convert.ToString((Convert.ToDouble(m_model.UnitPrice) * Convert.ToInt32(m_model.ReceiveQty1)));
                this.txtInvoiceMoney.Text = m_model.InvoiceTotal;
            }
        }

        private void txtLotNo_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            m_model.LotNo = txtLotNo.Text;
        }

        
        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            m_model.InvoiceNo = txtInvoiceNo.Text;
        }

        private void txtInvoiceMoney_TextChanged(object sender, EventArgs e)
        {
            double result;
            m_model.InvoiceTotal = txtInvoiceMoney.Text;
            if (!double.TryParse(m_model.InvoiceTotal, out result))
            {
                txtInvoiceMoney.Text = "";                   
            }
            
        }

        private void txtTradePrice_TextChanged(object sender, EventArgs e)
        {
            double result;
            m_model.InvoiceTradePrice = txtTradePrice.Text;
            if (!double.TryParse(m_model.InvoiceTradePrice, out result))
            {
                txtTradePrice.Text = "";
            }

        }

        private void txtRetailPrice_TextChanged(object sender, EventArgs e)
        {
            m_model.InvoiceRetailPrice = txtRetailPrice.Text;
            double result;
            if (!double.TryParse(m_model.InvoiceRetailPrice, out result))
            {
                txtRetailPrice.Text = "";
            }
        }

       

        private void dtpInvoiceDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInvoiceDate.Checked)
                m_model.InvoiceDate = ComUtil.formatDate(dtpInvoiceDate.Value.Date.ToString());
            else
                m_model.InvoiceDate = string.Empty;
        }

        private void dtpEffectDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEffectDate.Checked)
                m_model.InvoiceExpireDate = ComUtil.formatDate(dtpEffectDate.Value.Date.ToString());
            else
                m_model.InvoiceExpireDate = string.Empty;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtReceiveRemark_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            m_model.ReadyRemark = txtReceiveRemark.Text;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            m_model.InvoiceDiscountRate = txtDiscount.Text;
            double result;
            if (!double.TryParse(m_model.InvoiceDiscountRate, out result))
            {
                txtDiscount.Text = "";
            }
        }

        /// <summary>
        /// ������д��Ʊ�źͷ�Ʊ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�޸ĸö������еķ�Ʊ���ڣ�", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            IList resultList = (IList)this.OrderItembindingSource.DataSource;
            foreach (SalerOrderItemModel model in resultList)
            {
                //model.InvoiceNo = this.txtInvoiceNo.Text;
                model.InvoiceDate = ComUtil.formatDate(dtpInvoiceDate.Value.Date.ToString());
            }
            setInvoiceInfo();
        }

        /// <summary>
        /// ׼���ͻ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkChoose())
                {
                    MessageBox.Show("��ѡ��Ҫ�����Ķ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (MessageBox.Show("ȷ��������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                IList resultList = (IList)this.OrderItembindingSource.DataSource;
                if (!checkInput(resultList))
                    return;
                string remark = StringUtils.repalceSepStr(this.txtRemark.Text);
                bool flg;
                if (IsOfflineOrderList)
                {
                    flg = SalerOrderBLL.GetInstance().ReceiveOrder(resultList, remark, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                else
                {
                    flg = ProxyFactory.SalerOrderProxy.ReceiveOrder(resultList, remark, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                if (flg)
                {
                    MessageBox.Show("�ͻ��ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                SalerOrderItemList_Load(sender, e);
                this.tabCtlOrderItem.SelectedTab = this.tabAffirm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtReceiveNow_Validating(object sender, CancelEventArgs e)
        {
            int result;
            if (!int.TryParse(this.txtReceiveNow.Text,out result))
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="resultList"></param>
        /// <returns></returns>
        private bool checkInput(IList resultList)
        {
            double result;
            foreach (SalerOrderItemModel model in resultList)
            {
                if (model.IsChecked)
                {
                    //if (string.IsNullOrEmpty(model.LotNo))
                    //{
                    //    MessageBox.Show("���Ų���Ϊ�գ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}
                    //if (string.IsNullOrEmpty(model.InvoiceNo))
                    //{
                    //    MessageBox.Show("��Ʊ�źŲ���Ϊ�գ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}
                    //if (string.IsNullOrEmpty(model.InvoiceDate))
                    //{
                    //    MessageBox.Show("��Ʊ���ڲ���Ϊ�գ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}
                    if (!checkPlus(model.ReceiveQty1))
                    {
                        MessageBox.Show("���鷢������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (int.Parse(model.MaxQty) < int.Parse(model.ReceiveQty1))
                    {
                        MessageBox.Show("�ۼ��ͻ����ѳ�����������2����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.InvoiceTotal) && !checkDouble(model.InvoiceTotal))
                    {
                        MessageBox.Show("���鷢Ʊ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.InvoiceTradePrice) && !checkDouble(model.InvoiceTradePrice))
                    {
                        MessageBox.Show("���������ۣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.InvoiceRetailPrice) && !checkDouble(model.InvoiceRetailPrice))
                    {
                        MessageBox.Show("�������ۼۣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.InvoiceDiscountRate) && (!double.TryParse(model.InvoiceDiscountRate, out result) || result <= 0 || result > 100))
                    {
                        MessageBox.Show("������ʣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }
        private bool checkPlus(string value)
        {
            int result;
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out result) || result <= 0)
                return false;
            return true;
        }
        private bool checkDouble(string value)
        {
            double result;
            if (string.IsNullOrEmpty(value) || !double.TryParse(value, out result) || result <= 0)
                return false;
            return true;
        }

        /// <summary>
        /// ȱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvReturnNoSend.SelectedRows.Count < 1)
                {
                    MessageBox.Show("��ѡ��Ҫ�����Ķ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (MessageBox.Show("�Ƿ����Ҫ��ȱ������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }

                IList resultList = new ArrayList();
                resultList.Add(m_model);
                bool flg;
                if (IsOfflineOrderList)
                {
                    flg = SalerOrderBLL.GetInstance().OrderLack(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                else
                {
                 flg = ProxyFactory.SalerOrderProxy.OrderLack(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                if (flg)
                {
                    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                SalerOrderItemList_Load(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ȡ��ȱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelOos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvReturnNoSend.SelectedRows.Count < 1)
                {
                    MessageBox.Show("��ѡ��Ҫ�����Ķ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (MessageBox.Show("�Ƿ����Ҫ��ȡ��ȱ������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }

                IList resultList = new ArrayList();
                resultList.Add(m_model);
                bool flg;
                if (IsOfflineOrderList)
                {
                    flg = SalerOrderBLL.GetInstance().OrderCancelLack(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                else
                {
                    flg = ProxyFactory.SalerOrderProxy.OrderCancelLack(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                if (flg)
                {
                    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                SalerOrderItemList_Load(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            IList resultList = (IList)this.OrderItembindingSource.DataSource;
            if (chbAll.Checked)
            {
                foreach (DataGridViewRow dgvr in dgvReturnNoSend.Rows)
                {
                    if (!dgvr.Cells["keys"].ReadOnly)
                    {
                        dgvr.Cells["keys"].Value = true;
                        dgvr.Cells["keys"].Selected = true;
                    }
                    else
                    {
                        dgvr.Cells["keys"].Selected = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgvr in dgvReturnNoSend.Rows)
                {
                    if (!dgvr.Cells["keys"].ReadOnly)
                    {
                        dgvr.Cells["keys"].Value = false;
                        dgvr.Cells["keys"].Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// ����checkboxΪֻ������������ɫ
        /// </summary>
        private void checkBoxShow()
        {
            foreach (DataGridViewRow dgvr in dgvReturnNoSend.Rows)
            {
                if (dgvr.Cells["CheckBoxShowCell"].Value !=null && dgvr.Cells["CheckBoxShowCell"].Value.ToString().Equals("0"))
                {

                    dgvr.Cells["keys"].ReadOnly = true;

                    dgvr.Cells["keys"].Style.BackColor = Color.DarkRed;
                    dgvr.Cells["keys"].Style.SelectionBackColor = Color.Orange;
                
                }
            }
        }

        /// <summary>
        /// �ر�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private bool checkChoose()
        {
            foreach (DataGridViewRow dgvr in dgvReturnNoSend.Rows)
            {
                if (dgvr.Cells["keys"].EditedFormattedValue.Equals(true))
                {
                    return true;
                }
            }
            return false;
        }

        //add start
        /// <summary>
        /// ��֯�������ʵ��
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private InputInfoModel GetInputInfo(string state, string fillInvoice)
        {
            InputInfoModel input = new InputInfoModel();
            //�Ƿ�ʹ��ҩ����1 Ϊʹ�ã�0 Ϊδʹ��
            input.RepositoryBz = "";
            //��ǰƽ̨���û���Ϣ
            //input.PlatId = this.CurrentUserPlatId;
            input.UserOrgId = this.CurrentUserOrgId;
            input.UserId = this.CurrentUserId;

            //��ѯ��־λ            
            input.Idx = true;
            //����
            input.OrderId = m_orderid;
            //����״̬
            input.Received = state.Equals("confirmed") ? true : false;
            //��Ʊ
            input.FillInvoice = fillInvoice;

            return input;
        }

        /// <summary>
        /// ��ʼ����ȷ��/��ȷ���ͻ��б���ѵ����б�����
        /// </summary>
        /// <param name="state"></param>
        /// <param name="fillInvoice"></param>
        private void selectOrderPrepareItemList(string state, string fillInvoice)
        {
            IList list;
            if (IsOfflineOrderList)
            {
                list = SalerOrderBLL.GetInstance().selectOrderPrepareItemListJP(GetInputInfo(state, fillInvoice));
            }
            else
            {
                list = ProxyFactory.SalerOrderProxy.selectOrderPrepareItemListJP(GetInputInfo(state, fillInvoice));
            }

            if (state.Equals("show"))
            {
                this.OrderItemShowbindingSource.DataSource = list;                
                InitCheckBox();
                if (list.Count > 0)
                {
                    dgvConfirmItemList.Select();
                    dgvConfirmItemList.Rows[0].Selected = true;
                    dgvConfirmItemList.CurrentCell = dgvConfirmItemList.Rows[0].Cells[0];
                }

            }
            else if (state.Equals("confirmed"))
            {
                this.OrderItemShowbindingSource.DataSource = list;
                dgvConfirmList.Select();
            }
            
        }

        /// <summary>
        /// ��ʼ��CHECKBOX״̬
        /// </summary>
        private void InitCheckBox()
        {

            IList returnList = (IList)this.OrderItemShowbindingSource.DataSource;

            for (int i = 0; i < returnList.Count; i++)
            {
                mdl = returnList[i] as OutputInfoModel;

                dgvConfirmItemList.Rows[i].Cells["CheckControl"].ReadOnly = (mdl.ReceiveFlag.Equals("1") || mdl.ItemState.Equals("5")) ? true : false;
                if (dgvConfirmItemList.Rows[i].Cells["CheckControl"].ReadOnly)
                {
                    dgvConfirmItemList.Rows[i].Cells["CheckControl"].Style.BackColor = Color.DarkRed;
                    dgvConfirmItemList.Rows[i].Cells["CheckControl"].Style.SelectionBackColor = Color.Orange;
                }
            }

        }

        /// <summary>
        /// ��ʼ����ѡ��¼�����Ϣ
        /// </summary>
        private void InitSelectRecordInfo()
        {
            string invoiceMoney = mdl.R_invoice_total;
            //this.txtRECEIVE_QTY1.TextChanged -= new System.EventHandler(this.txtRECEIVE_QTY1_TextChanged);
            txtRECEIVE_QTY1.Text = mdl.RECEIVE_QTY;
            txtLOT_NO1.Text = mdl.LOT_NO;

            txtUNIT_PRICE1.Text = mdl.O_UNIT_PRICE;
            txtInvoiceCode1.Text = mdl.R_invoice_no;
            txtInvoiceMoney1.Text = invoiceMoney;
            txtTradePrice1.Text = mdl.R_invoice_trade_price;
            txtRetailPrice1.Text = mdl.R_invoice_retail_price;
            txtDiscount1.Text = mdl.R_invoice_discount_rate;
            if (!string.IsNullOrEmpty(mdl.R_invoice_date))
            {
                dtpInvoice_date1.Checked = true;
                dtpInvoice_date1.Value = Convert.ToDateTime(mdl.R_invoice_date);
                mdl.R_invoice_date = ComUtil.formatDate(dtpInvoice_date1.Value.Date.ToString());
            }
            else
            {
                dtpInvoice_date1.Checked = false;
            }
            if (!string.IsNullOrEmpty(mdl.R_invoice_expire_date))
            {
                dtpEffectDate1.Checked = true;
                dtpEffectDate1.Value = Convert.ToDateTime(mdl.R_invoice_expire_date);
                mdl.R_invoice_expire_date = ComUtil.formatDate(dtpEffectDate1.Value.Date.ToString());
            }
            else
            {
                dtpEffectDate1.Checked = false;
            }
                   
            txtReceiveRemark1.Text = mdl.R_ready_remark;
            this.txtRECEIVE_QTY1.TextChanged += new System.EventHandler(this.txtRECEIVE_QTY1_TextChanged);
        }

        private void dgvConfirmItemList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            IList returnList = (IList)this.OrderItemShowbindingSource.DataSource;
            mdl = returnList[e.RowIndex] as OutputInfoModel;
            InitSelectRecordInfo();
        }

        /// <summary>
        /// ȷ�Ϸ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkChooseForConfirm())
                {
                    MessageBox.Show("��ѡ��Ҫ�����Ķ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (MessageBox.Show("ȷ��������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                IList resultList = (IList)this.OrderItemShowbindingSource.DataSource;
                if (!checkInputForConfirm(resultList))
                    return;
                //string remark = this.txtRemark.Text;
                if (IsInvoice( resultList))
                {
                    MessageBox.Show("��Ʊ���ظ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                bool flg;
                if (IsOfflineOrderList)
                {
                    flg = SalerOrderBLL.GetInstance().ConfirmOrderReceive(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                else
                {
                     flg = ProxyFactory.SalerOrderProxy.ConfirmOrderReceive(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                if (flg)
                {
                    MessageBox.Show("ȷ�ϳɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                selectOrderPrepareItemList("show", "false");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //��ѯ������Ϣ������2007-8-8
            if (IsOfflineOrderList)
            {
                model = SalerOrderBLL.GetInstance().GetOrderTitle(m_orderid);
            }
            else
            {
                model = ProxyFactory.SalerOrderProxy.GetOrderTitle(m_orderid);
            }
            InitMain(model);
            m_Ordermodel = model;
        }
        //�жϷ�Ʊ�Ƿ��ظ� ������2007-8-16
        private bool IsInvoice(IList resultList)
        {
             if (IsOfflineOrderList)
             {
                 if(SalerOrderBLL.GetInstance().IsInvoiceExists(resultList))
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
               
             }
               else
             {
                 if(ProxyFactory.SalerOrderProxy.IsInvoiceExists(resultList))
                     {
                     return true;
                     }
                    else
                   {
                     return false;
                   }
              }

        }

        private void txtRECEIVE_QTY1_TextChanged(object sender, EventArgs e)
        {
            int result;
            mdl.RECEIVE_QTY = this.txtRECEIVE_QTY1.Text;
            if (string.IsNullOrEmpty(mdl.RECEIVE_QTY) || !int.TryParse(mdl.RECEIVE_QTY, out result))
            {
                this.txtInvoiceMoney1.Text = "";
                this.txtRECEIVE_QTY1.Text = "";
            }
            else
            {
                mdl.R_invoice_total = Convert.ToString((Convert.ToDouble(mdl.O_UNIT_PRICE) * Convert.ToInt32(mdl.RECEIVE_QTY)));
                this.txtInvoiceMoney1.Text = mdl.R_invoice_total;
            }
        }

        private void txtLOT_NO1_TextChanged(object sender, EventArgs e)
        {
            mdl.LOT_NO = txtLOT_NO1.Text.Trim();
        }

        //private void txtAPP_NUM1_TextChanged(object sender, EventArgs e)
        //{
        //    mdl.APP_NUM = txtAPP_NUM1.Text;
        //}

        private void txtInvoiceCode1_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            mdl.R_invoice_no = txtInvoiceCode1.Text.Trim();
        }

        private void txtInvoiceMoney1_TextChanged(object sender, EventArgs e)
        {
            mdl.R_invoice_total = txtInvoiceMoney1.Text.Trim();
            double result;
            if (!double.TryParse(mdl.R_invoice_total, out result))
            {
                txtInvoiceMoney1.Text = "";
            }
            
        }

        private void txtTradePrice1_TextChanged(object sender, EventArgs e)
        {
            mdl.R_invoice_trade_price = txtTradePrice1.Text.Trim();
            double result;
            if (!double.TryParse(mdl.R_invoice_trade_price, out result))
            {
                txtTradePrice1.Text = "";
            }
        }

        private void txtRetailPrice1_TextChanged(object sender, EventArgs e)
        {
            mdl.R_invoice_retail_price = txtRetailPrice1.Text.Trim();
            double result;
            if (!double.TryParse(mdl.R_invoice_retail_price, out result))
            {
                txtRetailPrice1.Text = "";
            }
        }

        private void txtDiscount1_TextChanged(object sender, EventArgs e)
        {
            mdl.R_invoice_discount_rate = txtDiscount1.Text.Trim();
            double result;
            if (!double.TryParse(mdl.R_invoice_discount_rate, out result))
            {
                txtDiscount1.Text = "";
            }
        }

        private void txtReceiveRemark1_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            mdl.R_ready_remark = txtReceiveRemark1.Text.Trim();
        }

        private void dtpInvoice_date1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInvoice_date1.Checked)
                mdl.R_invoice_date = ComUtil.formatDate(dtpInvoice_date1.Value.Date.ToString());
            else
                mdl.R_invoice_date = "";
        }

        private void dtpEffectDate1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEffectDate1.Checked)
                mdl.R_invoice_expire_date = ComUtil.formatDate(dtpEffectDate1.Value.Date.ToString());
            else
                mdl.R_invoice_expire_date = "";
        }

        private bool checkChooseForConfirm()
        {
            foreach (DataGridViewRow dgvr in this.dgvConfirmItemList.Rows)
            {
                if (dgvr.Cells["CheckControl"].EditedFormattedValue.Equals(true))
                {
                    return true;
                }
            }
            return false;
        }
        private bool checkInputForConfirm(IList resultList)
        {
            double result;
            ArrayList list = new ArrayList();
            foreach (OutputInfoModel model in resultList)
            {
                if (model.IsCheck)
                {
                    //if (string.IsNullOrEmpty(model.LOT_NO))
                    //{
                    //    MessageBox.Show("���Ų���Ϊ�գ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}
                    if (!string.IsNullOrEmpty(model.R_invoice_no))
                    {
                        //MessageBox.Show("��Ʊ�Ų���Ϊ�գ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //return false;
                        list.Add(model.R_invoice_no);
                    }
                    
                    //if (string.IsNullOrEmpty(model.R_invoice_date))
                    //{
                    //    MessageBox.Show("��Ʊ���ڲ���Ϊ�գ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}
                    if (!checkPlus(model.RECEIVE_QTY))
                    {
                        MessageBox.Show("���鷢������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (int.Parse(model.MaxQty) < int.Parse(model.RECEIVE_QTY))
                    {
                        MessageBox.Show("�ۼ��ͻ����ѳ�����������2����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.R_invoice_total) && !checkDouble(model.R_invoice_total))
                    {
                        MessageBox.Show("���鷢Ʊ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (!string.IsNullOrEmpty(model.R_invoice_trade_price) && !checkDouble(model.R_invoice_trade_price))
                    {
                        MessageBox.Show("���������ۣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.R_invoice_retail_price) && !checkDouble(model.R_invoice_retail_price))
                    {
                        MessageBox.Show("�������ۼۣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!string.IsNullOrEmpty(model.R_invoice_discount_rate) && (!double.TryParse(model.R_invoice_discount_rate, out result) || result <= 0 || result > 100))
                    {
                        MessageBox.Show("������ʣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            for (int i = 0; i < list.Count - 1;i++ )
            {
                string no = list[i].ToString();
                if (list.IndexOf(no,i + 1) > -1)
                {
                    MessageBox.Show("��Ʊ���ظ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �޸ķ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify1_Click(object sender, EventArgs e)
        {

            if (!checkChooseForConfirm())
            {
                MessageBox.Show("��ѡ��Ҫ�����Ķ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (MessageBox.Show("ȷ���޸���", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            IList resultList = (IList)this.OrderItemShowbindingSource.DataSource;
            if (!checkInputForConfirm(resultList))
                return;

            try
            {
                  bool flg;
                  if (IsOfflineOrderList)
                  {
                      flg = SalerOrderBLL.GetInstance().ModifyOrderReceive(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                  }
                  else
                  {
                       flg = ProxyFactory.SalerOrderProxy.ModifyOrderReceive(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                  }
                if (flg)
                {
                    MessageBox.Show("�޸ĳɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.selectOrderPrepareItemList("show", "true");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (!checkChooseForConfirm())
            {
                MessageBox.Show("��ѡ��Ҫ�����Ķ�����", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (MessageBox.Show("ȷ��������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            IList resultList = (IList)this.OrderItemShowbindingSource.DataSource;
            try
            {
                bool flg;
                if (IsOfflineOrderList)
                {
                    flg = SalerOrderBLL.GetInstance().DeleteOrderReceive(resultList, ClientSession.GetInstance().CurrentUser.UserInfo);
                }
                else
                {
                    flg = ProxyFactory.SalerOrderProxy.DeleteOrderReceive(resultList);
                }
                if (flg)
                {
                    MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                selectOrderPrepareItemList("show", "false");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chbAllConfim_CheckedChanged(object sender, EventArgs e)
        {
            //IList resultList = (IList)this.OrderItembindingSource.DataSource;
            if (chbAllConfim.Checked)
            {
                foreach (DataGridViewRow dgvr in this.dgvConfirmItemList.Rows)
                {
                    if (!dgvr.Cells["CheckControl"].ReadOnly)
                    {
                        dgvr.Cells["CheckControl"].Value = true;
                        dgvr.Cells["CheckControl"].Selected = true;
                    }
                    else
                    {
                        dgvr.Cells["CheckControl"].Selected = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgvr in dgvConfirmItemList.Rows)
                {
                    if (!dgvr.Cells["CheckControl"].ReadOnly)
                    {
                        dgvr.Cells["CheckControl"].Value = false;
                        dgvr.Cells["CheckControl"].Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// ��ӡ��ȷ��/��ȷ���б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintShow1_Click(object sender, EventArgs e)
        {
            try
            {
                IList list = (IList)OrderItemShowbindingSource.DataSource;
                OrderConfirmedPrint frm = new OrderConfirmedPrint(list, "��ȷ��/��ȷ���б�", this.CurrentUserName, m_Ordermodel);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ӡ���ͻ��б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintConfirmed_Click(object sender, EventArgs e)
        {
            try
            {
                IList list = (IList)OrderItemShowbindingSource.DataSource;
                OrderConfirmedPrint frm = new OrderConfirmedPrint(list, "���ͻ��б�", this.CurrentUserName, m_Ordermodel);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ӡ���ͻ��б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                IList list = (IList)dgvReturnNoSend.DataSource;
                OrderNoConfirmPrint frm = new OrderNoConfirmPrint(list, "���ͻ��б�", this.CurrentUserName, m_Ordermodel);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ӡ������ϸ�б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintOrderItem_Click(object sender, EventArgs e)
        {
            try
            {
                IList list = (IList)dgvOrderItem.DataSource;
                OrderItemListPrint frm = new OrderItemListPrint(list, "������ϸ�б� ", this.CurrentUserName, m_Ordermodel);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvConfirmList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCloseShow1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseConfirmed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseOrderItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSalerDesc_TextChanged(object sender, EventArgs e)
        {
            //m_model.SalerDesc = txtSalerDesc.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// dgvReturnNoSend�ո��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReturnNoSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvReturnNoSend.SelectedRows.Count == 0)
            {
                return;
            }
            //KeyOperation(e);
        }        

        /// <summary>
        /// �����¼�����
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool KeyOperation(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (DataGridViewRow row in dgvReturnNoSend.SelectedRows)
                {
                    if (row.Cells["keys"].ReadOnly != true)
                    {
                        row.Cells["keys"].Value = (bool)row.Cells["keys"].Value == false ? true : false;
                    }
                }
                return true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                dgvReturnNoSend.Select();
                int indexpre = dgvReturnNoSend.SelectedRows[0].Index;
                if (indexpre != 0)
                {
                    dgvReturnNoSend.CurrentCell = dgvReturnNoSend.Rows[indexpre - 1].Cells["bakMedicalNameDataGridViewTextBoxColumn"];
                }
                return true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                dgvReturnNoSend.Select();
                int indexpre = dgvReturnNoSend.SelectedRows[0].Index;
                if (indexpre != dgvReturnNoSend.Rows.Count - 1)
                {
                    dgvReturnNoSend.CurrentCell = dgvReturnNoSend.Rows[indexpre + 1].Cells["bakMedicalNameDataGridViewTextBoxColumn"];
                }
                return true;
            }
            return false;
        }

        private void txtReceiveNow_KeyDown(object sender, KeyEventArgs e)
        {
            txtReceiveNow.ReadOnly = true;
            txtReceiveNow.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLotNo.Select();
                }
                else
                {
                    txtReceiveNow.ReadOnly = false;
                }
            }
        }

        private void txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            txtLotNo.ReadOnly = true;
            txtLotNo.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.txtInvoiceNo.Select();
                }
                else
                {
                    txtLotNo.ReadOnly = false;
                }
            }
        }


        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            txtInvoiceNo.ReadOnly = true;
            txtInvoiceNo.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceMoney.Select();
                }
                else
                {
                    txtInvoiceNo.ReadOnly = false;
                }
            }
        }

        private void txtInvoiceMoney_KeyDown(object sender, KeyEventArgs e)
        {
            txtInvoiceMoney.ReadOnly = true;            
            txtInvoiceMoney.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTradePrice.Select();
                }
                else
                {
                    txtInvoiceMoney.ReadOnly = false;
                }
            }
        }

        private void txtTradePrice_KeyDown(object sender, KeyEventArgs e)
        {
            txtTradePrice.ReadOnly = true;
            txtTradePrice.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRetailPrice.Select();
                }
                else
                {
                    txtTradePrice.ReadOnly = false;
                }
            }
        }

        private void txtRetailPrice_KeyDown(object sender, KeyEventArgs e)
        {
            txtRetailPrice.ReadOnly = true;
            txtRetailPrice.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDiscount.Select();
                }
                else
                {
                    txtRetailPrice.ReadOnly = false;
                }
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            txtDiscount.ReadOnly = true;
            txtDiscount.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpInvoiceDate.Select();
                }
                else
                {
                    txtDiscount.ReadOnly = false;
                }
            }
        }

        private void dtpInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            //dtpInvoiceDate.ReadOnly = true;
            //txtDiscount.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpEffectDate.Select();
                }
                else
                {
                    //txtDiscount.ReadOnly = false;
                }
            }
        }

        private void dtpEffectDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.txtReceiveRemark.Select();
                }
                else
                {
                    //txtDiscount.ReadOnly = false;
                }
            }
        }


        private void txtReceiveRemark_KeyDown(object sender, KeyEventArgs e)
        {
            txtReceiveRemark.ReadOnly = true;
            txtReceiveRemark.BackColor = Color.White;
            if (!KeyOperation(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReceiveNow.Select();
                }
                else
                {
                    txtReceiveRemark.ReadOnly = false;
                }
            }
        }

        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
            //{
            //    dgvReturnNoSend.SelectedRows[0].Cells["keys"].Value = true;
            //    //dgvReturnNoSend.SelectedRows[0].Cells["keys"].Value = (bool)dgvReturnNoSend.SelectedRows[0].Cells["keys"].Value == false ? true : false;
            //}
        }

        private void dgvReturnNoSend_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvReturnNoSend.CommitEdit(DataGridViewDataErrorContexts.Display);
        }

        private void dgvConfirmItemList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvConfirmItemList.CommitEdit(DataGridViewDataErrorContexts.Display);
        }

        private void SalerOrderItemList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(frm!= null)
                frm.GetSalerOrderList();
        }


        private void dgvReturnNoSend_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    IList returnList = (IList)this.OrderItembindingSource.DataSource;
            //    m_model = returnList[e.RowIndex] as SalerOrderItemModel;
            //    if (dgvReturnNoSend.Rows[e.RowIndex].Cells["keys"].EditedFormattedValue.Equals(true))
            //        setInvoiceInfo();
            //    else
            //        ClearInvoiceInfo();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearInvoiceInfo()
        {
            //m_model.LotNo = string.Empty;
            //this.txtLotNo.Text = m_model.LotNo.ToString();

            //this.txtReceiveNow.Text = string.Empty;            
            //m_model.ReceiveQty1 = this.txtReceiveNow.Text;

            //this.txtInvoiceNo.Text = string.Empty;
            //m_model.InvoiceNo = this.txtInvoiceNo.Text;

            //this.txtInvoiceMoney.Text = string.Empty;
            //m_model.InvoiceTotal = this.txtInvoiceMoney.Text;

            //this.txtReceiveRemark.Text = string.Empty;
            //m_model.ReadyRemark = this.txtReceiveRemark.Text;

            //this.txtRetailPrice.Text = string.Empty;
            //m_model.InvoiceRetailPrice = this.txtRetailPrice.Text;

            //this.txtTradePrice.Text = string.Empty;
            //m_model.InvoiceTradePrice = this.txtTradePrice.Text;

            
            //dtpEffectDate.Checked = false;
            //m_model.InvoiceExpireDate = string.Empty;            
            
            //dtpInvoiceDate.Checked = false;
            //m_model.InvoiceDate = string.Empty;

            //this.txtDiscount.Text = string.Empty;
            //m_model.InvoiceDiscountRate = this.txtDiscount.Text;
        }

        private void txtRECEIVE_QTY1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLOT_NO1.Select();
            }
        }

        private void txtLOT_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInvoiceCode1.Select();
            }
        }

        private void txtInvoiceCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInvoiceMoney1.Select();
            }
        }

        private void txtInvoiceMoney1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTradePrice1.Select();
            }
        }

        private void txtTradePrice1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRetailPrice1.Select();
            }
        }

        private void txtRetailPrice1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiscount1.Select();
            }
        }

        private void txtDiscount1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpInvoice_date1.Select();
            }
        }

        private void dtpInvoice_date1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpEffectDate1.Select();
            }
        }

        private void dtpEffectDate1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReceiveRemark1.Select();
            }
        }

        private void txtReceiveRemark1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRECEIVE_QTY1.Select();
            }
        }
        public IList GetOrderItem()
        {
            return (IList)this.OrderItembindingSource.DataSource;
        }

        
    }


}