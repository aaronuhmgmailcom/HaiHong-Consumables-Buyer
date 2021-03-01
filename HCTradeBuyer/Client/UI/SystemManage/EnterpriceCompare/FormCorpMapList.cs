//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	FormCorpMapList.cs    
//	�� �� ��:	yanbing
//	��������:	2007-10-9
//	��������:	
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
using Emedchina.TradeAssistant.Client.BLL.His.EnterPrice;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.His;


namespace Emedchina.TradeAssistant.Client.His.Enterprise
{
    public partial class FormCorpMapList : BaseForm
    {
        private string FCorpName;
        private DataSet FDs;
        private string FHisCode;
        private string FHisName;
        public bool IsContinueMap;
        private BindingSource emedCorpMapListBinding = new BindingSource();

        public FormCorpMapList()
        {
            InitializeComponent();
        }

        public FormCorpMapList(string inCorpName, string inHisCode, string inHisName, DataSet inDs)
        {
            this.FCorpName = "";
            this.FHisCode = "";
            this.FHisName = "";
            this.FDs = null;
            this.IsContinueMap = false;
            this.components = null;
            this.FDs = inDs;
            this.FCorpName = inCorpName;
            this.FHisCode = inHisCode;
            this.FHisName = inHisName;
            this.InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.IsContinueMap = true;
            this.Close();
        }

        private void FormCorpMapList_Load(object sender, EventArgs e)
        {
            this.tb_EmedCorpName.Text = this.FCorpName;
            this.tb_CorpCode.Text = this.FHisCode;
            this.tb_CorpName.Text = this.FHisName;
            this.bindingDsEmedCorpMapList();
        }

        #region ���Ķ�Ӧ��ҵ�б����ݰ󶨿ؼ� bindingDsEmedCorpMapList
        /// <summary>
        /// ���Ķ�Ӧ��ҵ�б����ݰ󶨿ؼ�
        /// </summary>
        private void bindingDsEmedCorpMapList()
        {
            //this.dgv_EmedCorpMapList.AutoGenerateColumns = false;
            this.emedCorpMapListBinding.DataSource = this.FDs.Tables[0].DefaultView;
            this.dgv_EmedCorpMapList.DataSource = emedCorpMapListBinding;
            this.sumDsEmedCorpMapListRecordCount();
        }
        #endregion

        #region ���Ķ�Ӧ��ҵ�б��¼�� sumDsEmedCorpMapListRecordCount
        /// <summary>
        /// ���Ķ�Ӧ��ҵ�б��¼��
        /// </summary>
        private void sumDsEmedCorpMapListRecordCount()
        {
            if (this.FDs.Tables.Count > 0)
            {
                if (this.FDs.Tables[0].DefaultView.Count > 0)
                {
                    this.lb_nav1.Text = "��ƥ���HIS��ҵ�б� " + this.FDs.Tables[0].DefaultView.Count + " ����¼";
                }
                else
                {
                    this.lb_nav1.Text = "��ƥ���HIS��ҵ�б�0 ����¼";
                }
            }
            else
            {
                this.lb_nav1.Text = "��ƥ���HIS��ҵ�б� 0 ����¼";
            }
        }
        #endregion

        private void FormCorpMapList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
 

    }
}