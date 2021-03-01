using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
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
    public partial class FormPurchaseBuild : BaseForm
    {

        private UserInfoModel usInfo = new UserInfoModel();
        //�ɹ����б�id
        string purchaseId;

        //�ж�ɾ�����޸ĵȲ�����ť��ʾ״̬����Ĳ�����Ҫ�޸�Ϊ purchaseState
        string purchaseState = "";
        private PurchaseSaveModel purchaseSaveModel = new PurchaseSaveModel();
        //�ɹ������ƺ����ģ��
        private PurchaseSaveModel output;
        //�ɹ����б� 
        DataTable purchasedt;

        public FormPurchaseBuild()
        {
            InitializeComponent();
            //��ȡ��ǰ�û�����
            LogedInUser curUser = base.CurrentUser;
            //�û���Ϣ
            purchaseSaveModel.UserID = base.CurrentUserId;
            purchaseSaveModel.UserName = base.CurrentUserName;
        }

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
            string createDate = this.cmdCreateDate.Text.ToString();
            //����ʱ��
            string endDate = this.cmdEndDate.Text.ToString();
            //����
            string strType = this.cmbType.Text.Trim();

            string type = string.Empty;
            if (strType == "��ͨ�ɹ���")
                type = "1";
            else if (strType == "��������")
                type = "2";
            else if (strType == "ȷ�ϵ���������")
                type = "3";
            else
                type = "";

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

            //����
            if (!string.IsNullOrEmpty(type))
            {
                filter.AppendFormat(" and purchaseType =  '{0}'", type);
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

            if ("���ͨ��".Equals(purchaseState))
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSend.Enabled = false;

                this.MenuEdit.Enabled = false;
                this.MenuDel.Enabled = false;
                this.MenuAudi.Enabled = false;

            }
            else if ("����".Equals(purchaseState))
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = true;
                this.btnSend.Enabled = false;

            }
            else
            {
                if ("׼��".Equals(purchaseState))
                {
                    this.btnSend.Enabled = true;
                    this.MenuAudi.Enabled = true;
                }
                else
                {
                    this.btnSend.Enabled = false;
                    this.MenuAudi.Enabled = false;
                }
                this.btnEdit.Enabled = true;
                this.btnDel.Enabled = true;
                this.MenuEdit.Enabled = true;
                this.MenuDel.Enabled = true;

            }

            //����ɹ�����ĳ�������Ϊ��ʱ������Ĳ�����ť�����ܲ���
            int CuPurcount = this.gridView3.RowCount;
            if (CuPurcount > 0)
            {
                this.btnCopy.Enabled = true;
                this.MenuCopy.Enabled = true;
            }
            else
            {
                this.btnEdit.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSend.Enabled = false;
                this.btnCopy.Enabled = false;

                this.MenuEdit.Enabled = false;
                this.MenuDel.Enabled = false;
                this.MenuAudi.Enabled = false;
                this.MenuCopy.Enabled = false;

            }
        }
        #endregion



        #region �޸Ĳ���
        /// <summary>
        ///  �޸Ĳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseCreate frm = FormPurchaseCreate.GetInstance(this, (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "ȫ��";
            this.FormPurchaseBuild_Load(sender, e);

        }
        #endregion

        #region ��Ӳɹ�������
        /// <summary>
        /// ��Ӳɹ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            FormPurchaseCreate frm = new FormPurchaseCreate("�½��ɹ���", null);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "ȫ��";
            this.FormPurchaseBuild_Load(sender, e);

        }
        #endregion

        #region �ɹ������Ʋ����������꣬����Purchase_Code�ĵط�����Ҫ����
        /// <summary>
        /// �ɹ������Ʋ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                // DataRow drs = (DataRow)purchasedt.DefaultView.Table.DefaultView.RowFilter[this.gridView3.FocusedRowHandle];
                purchaseSaveModel.PurchaseId = GetGridViewColValue(this.gridView3, "id");

                //�ɹ������ƣ����ߣ�
                output = new PurchaseOfflineBLL().CopyPurchaseOffline(purchaseSaveModel);
                if (output.Equals(null))
                {
                    XtraMessageBox.Show("�ɹ�������ʧ�ܣ�û�з������ݣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                XtraMessageBox.Show("�ɹ������Ƴɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                purchasedt = PurchaseClientDao.GetInstance("ClientDB").getPurchaseCreate(base.CurrentUserOrgId);

                //��ԭ���İ���ID�����޸�Ϊ����ʱ������
                purchasedt.DefaultView.Sort = " create_date1 desc";

                setFilter();


            }
            catch (Exception)
            {
                XtraMessageBox.Show("�ɹ�������ʧ�ܣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                throw;
            }


        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool flag;
            flag = new PurchaseOfflineBLL().putCheckPurchaseOffline(purchaseId);
            if (flag)
            {
                XtraMessageBox.Show("����ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                purchasedt = PurchaseClientDao.GetInstance().getPurchaseCreate(base.CurrentUserOrgId);

                //��ԭ���İ���ID�����޸�Ϊ����ʱ������
                purchasedt.DefaultView.Sort = " create_date1 desc";

                setFilter();
            }
            else
            {
                XtraMessageBox.Show("����ʧ�ܣ�û�з������ݣ�", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
            purchasedt = PurchaseClientDao.GetInstance().getPurchaseCreate(base.CurrentUserOrgId);
            //���òɹ���״̬�б��ʼֵ
            this.cmdEndDate.DateTime = DateTime.Now;
            this.cmdCreateDate.DateTime = DateTime.Now.AddMonths(-3);
            this.cmbType.Text = "ȫ��";

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
        //��gridView���кű仯�ı䰴ť�ɲ���״̬
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EnabledBt();
        }

        #region ɾ���ɹ����б��ɹ�����ϸ�б��¼ ��������
        /// <summary>
        /// ɾ���ɹ����б��ɹ�����ϸ�б��¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(purchaseId))
            {
                XtraMessageBox.Show("��ѡ��һ���ɹ�����¼!");
            }
            else
            {
                if (XtraMessageBox.Show("�Ƿ�ȷ��ɾ��������", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //ɾ�����߲ɹ���
                    bool flag = new PurchaseOfflineBLL().PurchaseDeleteLocal(purchaseId, base.CurrentUserOrgId);

                    if (flag == true)
                    {
                        XtraMessageBox.Show("�ɹ���ɾ���ɹ���", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("�ɹ���ɾ��ʧ�ܣ�", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.FormPurchaseBuild_Load(sender, e);
                }
            }
        }
        #endregion

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    �� " + gridView3.RowCount + " ������";
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
        //����ɹ��ƻ�
        private void imputpurchase_Click(object sender, EventArgs e)
        {
            RequestSend frm = new RequestSend();
            frm.ShowDialog(); ;
            frm.Dispose();
            this.cmbState.SelectedItem = "ȫ��";
            this.FormPurchaseBuild_Load(sender, e);
        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dr = purchasedt.DefaultView.Table.DefaultView.ToTable();
            FormPurchaseItem frm = new FormPurchaseItem("�鿴�ɹ���ϸ", (DataRow)dr.Rows[this.gridView3.FocusedRowHandle]);
            frm.ShowDialog();
            frm.Dispose();
            this.cmbState.SelectedItem = "ȫ��";
            this.FormPurchaseBuild_Load(sender, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            purchasedt = PurchaseClientDao.GetInstance().getPurchaseCreate(base.CurrentUserOrgId);
            setFilter();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }






    }
}

