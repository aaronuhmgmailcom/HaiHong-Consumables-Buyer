//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	EnterpriseIDCompareQuery.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-10-21
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
using Emedchina.TradeAssistant.Client.BLL.His.EnterPrice;
using Emedchina.TradeAssistant.Client.Common;

namespace Emedchina.TradeAssistant.Client.His.Enterprise
{
    public partial class EnterpriseIDCompareQuery : BaseForm
    {
        DataTable querytable;
        DataTable histable;
        string orgID;
        public EnterpriseIDCompareQuery()
        {
            InitializeComponent();
            querytable = EnterpriseIDCompareBLL.GetInstance().GetEPCompareQueryTable();
            base.InitFromCacheByData(querytable);
            this.ItembindingSource.DataSource = base.cachedDataView;
            this.cbbCompare.Text = "全部数据";
        }
   
        
        /// <summary>
        /// 设置ItemFilter过滤企业编码对照列表
        /// </summary>
        private void ItemFilter()
        {
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            string EPname = this.tbxEPname.Text;
            string compare = this.cbbCompare.Text;
            if (!string.IsNullOrEmpty(EPname))
                filter.AppendFormat(" and (name like '%{0}%' or abbr like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%')", EPname);
            //按对照关系过滤
            switch (compare)
            {
                case "一对一":
                    filter.Append(" and MapSum = 1"); break;
                case "一对多":
                    filter.Append(" and MapSum > 1"); break;
            }
            this.cachedDataView.RowFilter = filter.ToString();
          
            if (cachedDataView.Count > 0)
            {
                DataRow dr = gridDataView.ToTable().Rows[0];
            }
            gridView5_FocusedRowChanged(null,null);
        }

        private void cbbCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }
        //查询按钮实现
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ItemFilter();
        }
        
        private void tbxEPname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ItemFilter();
        }
        /// <summary>
        /// 关闭按钮实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxEPname_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        /// <summary>
        /// 列表中焦点行change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            if (dr != null)
            {
                orgID = dr["send_orgid"].ToString();
                histable = EnterpriseIDCompareBLL.GetInstance().GetEPComparionTable();
                string filter = "1=1 and ORG_ID='" + orgID + "'";
                histable.DefaultView.RowFilter = filter;
                if (histable.DefaultView.Count > 0)
                    this.hisbindingSource.DataSource = histable;
                this.lblHiscount.Text = histable.DefaultView.Count.ToString() + "条记录";
            }
        }

        /// <summary>
        /// esc键关闭本窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterpriseIDCompareQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}