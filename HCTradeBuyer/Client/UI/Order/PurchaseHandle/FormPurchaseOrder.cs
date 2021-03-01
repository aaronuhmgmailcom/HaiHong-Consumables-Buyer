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
        //�ɹ���ID
        public string purchaseId;
        //ȡ��DataGridView��ǰ��
        public DataRow dr;

        //����ӡ�ɹ�����ϸ�õ�datatable
        public DataTable dtPrint;
        //����ӡ�û���Ϣ
        public UserInfoModel usInfo;
        public FormPurchaseOrder()
        {
            InitializeComponent();
        }

        #region �رյ�ǰ����
        /// <summary>
        /// �رյ�ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
 

        //#region ��ʼ�������б���

        ///// <summary>
        ///// ��ʼ�������б���

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

        //    //��ʾ�����б��¼����
        //    this.lbOrderRecordcount.Text = this.dgvOrderList.Rows.Count.ToString() + "����¼";
        //    //��ʾ������ϸ�б��¼����
        //    this.lbItemRecordcount.Text = this.dgvOrderItem.Rows.Count.ToString() + "����¼";

        //}
        // #endregion
        //#region ������ϸ�б������ϸ˵��
        ///// <summary>
        ///// ������ϸ�б������ϸ˵��
        ///// </summary>
        ///// <param name="olm"></param>        
        //private void setItemLable()
        //{
        //    this.lbOrderCode.Text = dr["PURCHASE_CODE"].ToString();
        //    this.lbCreateDate.Text = dr["CREATE_DATE"].ToString();
        //    //��ʽ�����ָ�ʽ
        //    Double rq_total = Convert.ToDouble(dr["request_total"]);
        //    string Request_total = rq_total.ToString("#,##0.00;(#,##0.00);Zero");

        //    this.lbTotal.Text = Request_total + "(Ԫ)";
        //    this.lbState.Text = dr["purchase_state"].ToString();
        //    this.lbCreateName.Text = dr["create_username"].ToString();
        //    this.lbTel.Text = dr["buyer_link_tel1"].ToString();
        //}
        // #endregion
        //#region�����òɹ�����ϸ���������
        ///// <summary>
        ///// ���ö�����ϸ���������

        ///// </summary>
        ///// <param name="orderId">�����б�ID</param>
        //private void setFilterItem(string orderId)
        //{
        //    //��������б�IDΪ��ʱ����ֵ���ǿա�

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

