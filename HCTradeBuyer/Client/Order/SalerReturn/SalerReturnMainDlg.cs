//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	SalerReturnMainDlg.cs   
//	�� �� ��:	��ԭ
//	��������:	2006-12-26
//	��������:	��ҵ�˻�����ҳ���
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.Order.SalerReturn;
using Emedchina.Commons;
using System.Collections;

namespace Emedchina.TradeAssistant.Client.Order.SalerReturn
{
    public partial class SalerReturnMainDlg : MainFormBase
    {
        string[] Class4Plats;
        bool firstInit = true;
        string handlerId;
        string operate;


        public SalerReturnMainDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���ضԻ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalerReturnMainDlg_Load(object sender, EventArgs e)
        {
            //��ʼ���˻�״̬�����б�
            string[] valuesReturnStatus = {"1","2","3","4"};
            string[] textsReturnStatus = { "�Է��ѷ���", "�Է��ѳ���", "��ͬ��", "�Ѿܾ�" };
            InitReturnStatus(this.cmbReturnStatus, valuesReturnStatus, textsReturnStatus);

            //��ʼ��Ʒ�����������б�
            string[] valuesType = { "1", "2", "3", "4" };
            string[] textsType = { "Ʒ��", "Ʒ��ƴ��", "Ʒ�����", "ҽԺ����" };
            InitReturnStatus(this.cmbType, valuesType, textsType);

            dtStartDate.Value = DateTime.Now.AddYears(-1);
            dtEndDate.Value = DateTime.Now;

            handlerId = "order.return";
            operate = "ReturnDeal";

            getClass4PlatsList();

            //��ѯ�����˻����б�
            SearchReturnList();

            firstInit = false;
        }

        /// <summary>
        /// �������б�
        /// </summary>
        private void InitReturnStatus(ComboBox cmb,string[] values,string[] texts)
        {
            if (values.Length != texts.Length)
                return;
            //��ʼ������
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns[0].ColumnName = "value";
            dt.Columns[1].ColumnName = "text";
            for (int i = 0; i < values.Length; i++)
            {
                string[] data = { values[i],texts[i] };
                dt.Rows.Add(data);
            }

            //��
            cmb.DataSource = dt;
            cmb.DisplayMember = "text";
            cmb.ValueMember = "value";
            //ѡ���һ��
            cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// ��֯�������ʵ��
        /// </summary>
        /// <returns></returns>
        private SalerReturnModel GetInput()
        {
            SalerReturnModel mdl = new SalerReturnModel();
            mdl.CurOrgId = this.CurrentUserOrgId;
            mdl.ReturnState = cmbReturnStatus.SelectedValue.ToString();
            mdl.StrType = cmbType.SelectedValue.ToString();
            mdl.StrKeyValue = txtName.Text;
            mdl.StartDate = ComUtil.formatDate(this.dtStartDate.Text.ToString());
            mdl.EndDate = ComUtil.formatDate(this.dtEndDate.Text.ToString());

            return mdl;
        }

        /// <summary>
        /// ��ѯ�����˻����б�
        /// </summary>
        private void SearchReturnList()
        {
            int rows;
            DataTable dt = ProxyFactory.SalerReturnProxy.findDealList(Class4Plats, GetInput(),getPageParam(), out rows);
            this.bindingSourceReturn.DataSource = dt;
            pageNavigator1.ItemCount = rows;
        }

        /// <summary>
        /// ��ѯ4��ƽ̨ID
        /// </summary>
        private void getClass4PlatsList()
        {
            bool flag = true;
            Class4Plats = ProxyFactory.SalerReturnProxy.getClass4PlatsList(handlerId, operate, GetUserInfo(), flag);
        }

        /// <summary>
        /// ȡ�÷�ҳ����
        /// </summary>
        private PagedParameter getPageParam()
        {
            //��ҳ����
            PagedParameter param = new PagedParameter();
            param.PageNum = this.pageNavigator1.CurrentPageIndex.ToString();
            param.PageSize = this.pageNavigator1.PageSize.ToString();

            return param;
        }

        /// <summary>
        /// ��ѯ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //��ѯ�����˻����б�
            SearchReturnList();
        }

        /// <summary>
        /// ��ҳ�¼�
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            //��ѯ�����˻����б�
            SearchReturnList();
        }

        /// <summary>
        /// �˻�״̬�仯�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbReturnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��ʼ��ҳ��
            if (firstInit)
            {
                dgvSalerReturnList.Columns["Remark"].ReadOnly = false;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                return;
            }
            //�����б���
            if (cmbReturnStatus.SelectedValue.ToString().Equals("1"))
            {
                dgvSalerReturnList.Columns["Remark"].ReadOnly = false;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                btnAllow.Visible = true;
                btnRefuse.Visible = true;
            }
            else
            {
                dgvSalerReturnList.Columns["Remark"].ReadOnly = true;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
                dgvSalerReturnList.Columns["Remark"].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                btnAllow.Visible = false;
                btnRefuse.Visible = false;
            }
            SearchReturnList();
        }

        /// <summary>
        /// ͬ�ⰴť����1--ͬ��/0--�ܾ�/other--����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllow_Click(object sender, EventArgs e)
        {
            if (dgvSalerReturnList.SelectedRows.Count == 0)
            {
                MessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool flgSuccess = true;
            SalerReturnModel[] RetrunModel = GetReturnModel(out flgSuccess);
            if (!flgSuccess)
            {
                return;
            }
            if (MessageBox.Show("�Ƿ�ͬ���˻���", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            bool flg = ProxyFactory.SalerReturnProxy.UpdateReturnStatus(RetrunModel, GetUserInfo(), "1");
            if (flg)
            {
                MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //��ѯ�����˻����б�
                SearchReturnList();
            }
            else
            {
                MessageBox.Show("����ʧ�ܣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
        }

        /// <summary>
        /// ��֯��ѡ�������
        /// </summary>
        /// <returns></returns>
        private SalerReturnModel[] GetReturnModel(out bool flgSuccess)
        {
            flgSuccess = true;
            SalerReturnModel[] salerReturnModel = new SalerReturnModel[dgvSalerReturnList.SelectedRows.Count];
            for (int i = 0; i < dgvSalerReturnList.SelectedRows.Count; i++)
            {
                SalerReturnModel mdl = new SalerReturnModel();
                mdl.Id = dgvSalerReturnList.Rows[i].Cells["ID"].Value.ToString();
                mdl.Remark = dgvSalerReturnList.Rows[i].Cells["Remark"].Value.ToString();
                mdl.StrReceiveID = dgvSalerReturnList.Rows[i].Cells["receive_id"].Value.ToString();
                mdl.StrReceiveQty = Convert.ToDouble(dgvSalerReturnList.Rows[i].Cells["receive_qty_pre"].Value.ToString()) - Convert.ToDouble(dgvSalerReturnList.Rows[i].Cells["return_qty"].Value.ToString());
                mdl.StrReceiveQty = mdl.StrReceiveQty < 0 ? 0 : mdl.StrReceiveQty;
                if (mdl.Remark.Length > 100)
                {
                    MessageBox.Show("��ע���ݲ��ô���100��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.SetStyle(ControlStyles.Selectable, true);
                    dgvSalerReturnList.Select();
                    dgvSalerReturnList.Rows[i].Cells["Remark"].Selected = true;
                    dgvSalerReturnList.CurrentCell = dgvSalerReturnList.Rows[i].Cells["Remark"];
                    flgSuccess = false;
                    break;
                }
                salerReturnModel[i] = mdl;
            }

            return salerReturnModel;
        }

        /// <summary>
        /// ��֯��ǰ�û���Ϣ
        /// </summary>
        /// <returns></returns>
        private UserInfo GetUserInfo()
        {
            UserInfo ui = new UserInfo();
            //��ǰ�û�ID
            ui.UserId = this.CurrentUserId;
            //����½ƽ̨ID
            //ui.LastLoginPlat = this.LastLoginPlat;
            //ƽ̨����
            //ui.PlatClass = this.PlatClass;
            return ui;
        }

        /// <summary>
        /// ���Ʊ仯�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //��ѯ�����˻����б�
            SearchReturnList();
        }

        /// <summary>
        /// �ܾ���ť��1--ͬ��/0--�ܾ�/other--����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefuse_Click(object sender, EventArgs e)
        {
            if (dgvSalerReturnList.SelectedRows.Count == 0)
            {
                MessageBox.Show("�޿ɲ�����¼��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool flgSuccess = true;
            SalerReturnModel[] RetrunModel = GetReturnModel(out flgSuccess);
            if (!flgSuccess)
            {
                return;
            }
            if (MessageBox.Show("�Ƿ�ܾ��˻���", "��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            bool flg = ProxyFactory.SalerReturnProxy.UpdateReturnStatus(RetrunModel, GetUserInfo(), "0");
            if (flg)
            {
                MessageBox.Show("�����ɹ���", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //��ѯ�����˻����б�
                SearchReturnList();
            }
            else
            {
                MessageBox.Show("����ʧ�ܣ�", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        /// <summary>
        /// ��ӡ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bindingSourceReturn.DataSource;
            SalerReturnPrintDlg frm = new SalerReturnPrintDlg(dt, cmbReturnStatus.Text + "��¼", this.CurrentUserName);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}