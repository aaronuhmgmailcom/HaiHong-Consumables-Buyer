using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.UI.PublicModule;
using Emedchina.TradeAssistant.Client.BLL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.UI.Report.ReportForm;
using Emedchina.TradeAssistant.Client.UI.Report.ReportFile;
using Emedchina.TradeAssistant.Client.BLL.Report;
using DevExpress.Utils;

namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class FormPurchaseCkeck : BaseForm
    {

        private UserInfoModel usInfo = new UserInfoModel();
        //�ɹ����б�id
        string purchaseId;
        //����id
        string userId;
        //�ж�ɾ�����޸ĵȲ�����ť��ʾ״̬����Ĳ�����Ҫ�޸�Ϊ purchaseState
        string purchaseState = "";
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();
        //�ɹ������ƺ����ģ��
        private PurchaseSaveModel output;
        //�ɹ����б�
        DataTable purchasedt;

        public FormPurchaseCkeck()
        {
            InitializeComponent();
            //��ȡ��ǰ�û�����
            LogedInUser curUser = base.CurrentUser;
            //����id
            userId = base.CurrentUserOrgId;
            //�û���Ϣ
            purchaseSaveModel.UserID = base.CurrentUserId;
            purchaseSaveModel.UserName = base.CurrentUserName;
           
        }
        #region ��ѯ��ť
        /// <summary>
        /// ��ѯ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
        #region ���òɹ�������������
        /// <shangfu>
        /// ���òɹ�������������
        /// </shangfu>
        private void setFilter()
        {
            //if (DateTime.Compare(this.cmdEndDate.DateTime, this.cmdCreateDate.DateTime) < 0)
            //{
            //    XtraMessageBox.Show("�������ڽ������ڱ�����ڿ�ʼ���ڣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //�ɹ���״̬
            string PurchaseState = this.cmbState.Text.Trim();
            
            //��ʼʱ��
            string createDate = ComUtil.formatDate(this.cmdCreateDate.Text.ToString());
            //����ʱ��
            string endDate = ComUtil.formatDate(this.cmdEndDate.Text.ToString());
            purchasedt.DefaultView.RowFilter = "";
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            //��������
            if (PurchaseState != "" && PurchaseState != null)
            {
                switch (PurchaseState)
                {
                    case "ȫ��":
                        filter.AppendFormat("", "");
                        break;

                    case "׼��":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;

                    case "����":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;
                    case "�ܾ�":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;
                    case "���ͨ��":
                        filter.AppendFormat(" and purchase_state = '{0}'", PurchaseState);
                        break;

                }
            }

            if (createDate != "" && createDate != null)
            {
                filter.AppendFormat(" and create_date1 >= '{0}'", createDate + " 00:00:00");
            }

            if (endDate != "" && endDate != null)
            {
                filter.AppendFormat(" and create_date1 <= '{0}'", endDate + " 23:59:59");
            }

            purchasedt.DefaultView.RowFilter = filter.ToString();
            //����ʱ������
            purchasedt.DefaultView.Sort = " create_date1 desc";
            this.purchaseListBindingSource.DataSource = purchasedt.DefaultView;
            EnabledBt();
        }
        #endregion 

        #region �ж�ɾ�����޸ĵȲ�����ť��ʾ״̬
        /// <summary>
        /// �ж�ɾ�����޸ĵȲ�����ť��ʾ״̬
        /// </summary>
        /// <param name="purchaseId"></param>
        private void EnabledBt()
        {    
            int rowcount = this.gridView3.RowCount;
            if (rowcount > 0)
            {
                purchaseState = GetGridViewColValue(this.gridView3, "purchase_state");
                purchaseId = GetGridViewColValue(this.gridView3, "id");
            }
            if ("����".Equals(purchaseState))
            {
                this.btnCheck.Enabled = true;
               
            }
            else
            {
                this.btnCheck.Enabled = false;

            }

            
        }
        #endregion

       //��˲ɹ���
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseCreate frm = new FormPurchaseCreate("��˲ɹ���", (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "׼��";
            this.FormPurchaseBuild_Load(sender, e);
        }

        #region ��ʼ���ɹ����б���
        /// <summary>
        /// ��ʼ���ɹ����б���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPurchaseBuild_Load(object sender, EventArgs e)
        {
            //�ͻ��˻������
            purchasedt = PurchaseClientDao.GetInstance("ClientDB").getPurchaseCreate(userId);
            //���òɹ���״̬�б��ʼֵ
            this.cmbState.Text = "����";
            this.cmdEndDate.DateTime = DateTime.Now;
            this.cmdCreateDate.DateTime = DateTime.Now.AddMonths(-3);

        }
        #endregion  
        #region ��ȡGrid��ǰѡ�� ĳ���ֶ�ֵ
        /// <summary>
        /// ��ȡGrid��ǰѡ�� ĳ���ֶ�ֵ
        /// </summary>
        /// <param name="view">gridView����</param>
        /// <param name="ColName">�ֶ���</param>
        /// <returns></returns>
        public string GetGridViewColValue(DevExpress.XtraGrid.Views.Base.ColumnView view, string ColName)
        {
            string value = string.Empty;

            if (view.RowCount == 0)
                return value;

            DevExpress.XtraGrid.Columns.GridColumn colvalue = view.Columns.ColumnByFieldName(ColName);
            value = view.GetRowCellValue(view.FocusedRowHandle, colvalue).ToString();

            return value;
        }

        #endregion
       

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    �� " + gridView3.RowCount + " ������";
        }

        private void cmbState_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            setFilter();

        }

        private void cmdCreateDate_EditValueChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            setFilter();
        }

        private void cmdEndDate_EditValueChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            setFilter();
        }

        private void gridView3_RowCountChanged_1(object sender, EventArgs e)
        {
            labelControlCount.Text = "    �� " + gridView3.RowCount + " ������";
        }

        //��gridView���кű仯�ı䰴ť�ɲ���״̬
        private void gridView3_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EnabledBt();
        }
        //�鿴�ɹ�����ϸ
        private void btnPurchaseItem_Click_1(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseItem frm =new FormPurchaseItem("�鿴�ɹ���ϸ", (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "׼��";
            this.FormPurchaseBuild_Load(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            purchasedt = PurchaseClientDao.GetInstance("ClientDB").getPurchaseCreate(userId);
            setFilter();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gridView3.GetDataRow(gridView3.FocusedRowHandle) != null)
            {
                DataTable dt = ReportBLL.GetInstance().GetPurchaseReportData(gridView3.GetDataRow(gridView3.FocusedRowHandle)["id"].ToString().Trim());
                FrmPrint frmPrint = new FrmPrint(new PurchaseXtraReport(base.CurrentUserOrgName + "�ɹ�������"), dt);
                frmPrint.ShowDialog();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ˫���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
                return;

            DataRow dr = this.gridView3.GetDataRow(this.gridView3.FocusedRowHandle);

            //����ʱ������¼�
            if (dr["purchase_state"].ToString().Equals("����"))
            {
                btnSend_Click(null, null);
            }
            else
            {
                this.btnPurchaseItem_Click_1(null, null);
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

        private void gridView3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                 if (gridView3.FocusedColumn.FieldName == "create_date1")
                    toolTipLocationControl_ToolTipLocationChanged(dr["create_date1"].ToString());

            }


        }
    }
}

