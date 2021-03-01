//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	hospCorpMapList.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-5-21
//	功能描述:	
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
//using Emedchina.TradeAssistant.Client.BLL.Map.EnterPrice;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Map;


namespace Emedchina.TradeAssistant.Client.Map.Hospital
{
    public partial class hospCorpMapList : FormBase
    {
        private string FCorpName;
        private DataSet FDs;
        private string FHisCode;
        private string FHisName;
        public bool IsContinueMap;
        private BindingSource emedCorpMapListBinding = new BindingSource();

        public hospCorpMapList()
        {
            InitializeComponent();
        }

        public hospCorpMapList(string inCorpName, string inHisCode, string inHisName, DataSet inDs)
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

        #region 中心对应企业列表数据绑定控件 bindingDsEmedCorpMapList
        /// <summary>
        /// 中心对应企业列表数据绑定控件
        /// </summary>
        private void bindingDsEmedCorpMapList()
        {
            this.dgv_EmedCorpMapList.AutoGenerateColumns = false;
            this.emedCorpMapListBinding.DataSource = this.FDs.Tables[0].DefaultView;
            this.dgv_EmedCorpMapList.DataSource = emedCorpMapListBinding;
            this.sumDsEmedCorpMapListRecordCount();
        }
        #endregion

        #region 中心对应企业列表记录数 sumDsEmedCorpMapListRecordCount
        /// <summary>
        /// 中心对应企业列表记录数
        /// </summary>
        private void sumDsEmedCorpMapListRecordCount()
        {
            if (this.FDs.Tables.Count > 0)
            {
                if (this.FDs.Tables[0].DefaultView.Count > 0)
                {
                    this.lb_nav1.Text = "已匹配的HIS买方列表： " + this.FDs.Tables[0].DefaultView.Count + " 条记录";
                }
                else
                {
                    this.lb_nav1.Text = "已匹配的HIS买方列表：0 条记录";
                }
            }
            else
            {
                this.lb_nav1.Text = "已匹配的HIS买方列表： 0 条记录";
            }
        }
        #endregion
 

    }
}