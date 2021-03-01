//=====================================================================================
//	Copyright (c)  Emedchina
//
//	�� �� ��:	AfficheInfoForm.cs   
//	�� �� ��:	������
//	��������:	2007-10
//	��������:	������Ϣ�鿴
//	�� �� ��: 
//	�޸�����:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.CommonInfo;
using Emedchina.TradeAssistant.Client.UI.CommonInfo.AfficheInfo;

namespace Emedchina.TradeAssistant.Client.UI.CommonInfo
{
    /// <summary>
    /// ������Ϣ�鿴
    /// </summary>
    public partial class AfficheInfoForm : BaseForm
    {
        //��ȡ��ȡ�û�����
        LogedInUser CurrentUser = null;

        //������Ϣ���ݼ�����
        private DataTable ArricheInfoDt = null;

        public AfficheInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ҳ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfficheInfoForm_Load(object sender, EventArgs e)
        {
            //��ȡ��ȡ�û�����
            CurrentUser = base.CurrentUser;

            //��ʼ�������б�
            InitData();

            //��ʼ����ѯ
            AfficheInfoBind();
            Filter();
            this.txtTitle.Focus();
        }

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ���ݰ󶨹�����Ϣ
        /// </summary>ss
        private void AfficheInfoBind()
        {
            ArricheInfoDt = BulletinInfoBLL.GetInstance().GetBulletinInfoDt(CurrentUser);

            if (ArricheInfoDt != null)
            {
                this.bindingSource1.DataSource = ArricheInfoDt.DefaultView;
            }
        }

        /// <summary>
        /// ��ѯ���˷���
        /// </summary>
        private void Filter()
        {
            //�������
            string strTitle = this.txtTitle.Text.ToString().Trim();
            //����״̬ ��2���Ķ� 1δ�Ķ���
            string strIsRead = this.LueState.EditValue.ToString().Trim();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append("1=1");

            //�������
            if (!string.IsNullOrEmpty(strTitle))
            {
                StrFilter.AppendFormat(" AND Title LIKE '%{0}%'", strTitle);
            }

            //״̬
            if (!string.IsNullOrEmpty(strIsRead))
            {
                StrFilter.AppendFormat(" AND IS_READ='{0}'", strIsRead);
            }

            if (ArricheInfoDt != null)
            {
                if (ArricheInfoDt.DefaultView != null)
                {
                    this.ArricheInfoDt.DefaultView.RowFilter = StrFilter.ToString();
                }
            }

        }

        #region ��������ѯ�¼�
        private void Found_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        #endregion

        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void InitData()
        {
            InitData_State();
        }

        /// <summary>
        /// ��ʼ��״̬
        /// </summary>
        private void InitData_State()
        {
            //��״̬
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "Name";

            string[] data0 = { "", "ȫ��" };
            dt.Rows.Add(data0);
            string[] data1 = { "2", "���Ķ�" };
            dt.Rows.Add(data1);
            string[] data2 = { "1", "δ�Ķ�" };
            dt.Rows.Add(data2);

            this.LueState.Properties.DataSource = dt;
            this.LueState.Properties.Columns.Clear();
            this.LueState.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "��������"));
            this.LueState.Properties.DisplayMember = "Name";
            this.LueState.Properties.ValueMember = "value";
            this.LueState.Properties.NullText = "";

            this.LueState.EditValue = "1";
        }

        /// <summary>
        /// �鿴��ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�Ϊ�����ݼ�
            if (this.gviewAfficheInfo.RowCount == 0)
                return;

            //�ɹ�Ŀ¼ID
            string strBulletionID = GetGridViewColValue(this.gviewAfficheInfo,"ID");
            ViewAfficheInfoForm frm = new ViewAfficheInfoForm(strBulletionID);
            frm.ShowDialog();

            string strReceiverID = GetGridViewColValue(this.gviewAfficheInfo, "ReceiverID");
            RefreshDt(strReceiverID);
        }

        /// <summary>
        /// ˢ�����ݼ�
        /// </summary>
        /// <param name="strReceiverID"></param>
        private void RefreshDt(string strReceiverID)
        {
            DataColumn[] keys = new DataColumn[1];
            DataColumn myColumn = new DataColumn();

            keys[0] = ArricheInfoDt.Columns[0];
            ArricheInfoDt.PrimaryKey = keys;

            DataRow dr = ArricheInfoDt.Rows.Find(strReceiverID);

            if (dr != null)
            {
                dr["IS_READ"] = "2";
                dr["ReadName"] = "���Ķ�";
            }
        }

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

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gviewAfficheInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
            e.Info.ImageIndex = -1;
        }

        private void gviewAfficheInfo_RowCountChanged(object sender, EventArgs e)
        {
            labelControlCount.Text = "    �� " + gviewAfficheInfo.RowCount + " ������";
        }

        #region ��ʾTip
        private void gviewAfficheInfo_Click(object sender, EventArgs e)
        {
            DataRow dr = gviewAfficheInfo.GetDataRow(gviewAfficheInfo.FocusedRowHandle);
            if (dr != null)
            {
                if (gviewAfficheInfo.FocusedColumn.FieldName == "ISSUE_DATE")
                    toolTipLocationControl_ToolTipLocationChanged(dr["ISSUE_DATE"].ToString());
                
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
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AfficheInfoBind();
            Filter();
        }

    }
}