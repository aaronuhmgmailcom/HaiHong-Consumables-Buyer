/*****************************************************************************
创 建 人:	罗澜涛
创建日期:	2007-5-21
功能描述:	产品编码对照查询
 ********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Map.Product;
using Emedchina.TradeAssistant.Client.BLL.Map.Product;

namespace Emedchina.TradeAssistant.Client.Map.Product
{
    public partial class ProductCodeCompareQueryForm : FormBase
    {
        #region 变量定义区
        public DataTable commDT;
        private DataTable proItemDT;
        private Thread thread;
        string proID;
        #endregion

        #region 构造函数
        public ProductCodeCompareQueryForm()
        {
            InitializeComponent();
            //线程开始
            thread = new Thread(new ThreadStart(ShowWaiting));
            thread.Start();
            //查询
            DataBind();
            this.cbbCompare.Text = "全部数据";
            //线程结束
            thread.Abort();
        }
        #endregion

        #region 显示等待窗体
        private void ShowWaiting()
        {
            LoadDataWaiting frm = new LoadDataWaiting("");
            frm.ShowDialog();
        }
        #endregion

        #region 页面加载
        private void ProductCodeCompareQueryForm_Load(object sender, EventArgs e)
        {
            //DataBind();
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 绑定数据
        private void DataBind()
        {
            int index, size;
            index = pageNavigatorProIDComItem.CurrentPageIndex;
            size = this.pageNavigatorProIDComItem.PageSize;

            commDT = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList();
            if (commDT == null)
                return;
            this.bindingSource1.DataSource = commDT.DefaultView;
            InitFromCacheByData(commDT, index, size);
            this.bindingSource1.DataSource = base.gridDataView;
            this.pageNavigatorProIDComItem.ItemCount = base.cachedDataView.Count;

        }
        #endregion

        #region 翻页事件
        private void pageNavigatorProIDComItem_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            DataBind();
        }
        #endregion

        #region 选择事件
        private void dgvProItem_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvProItem.CurrentRow != null)
            {
                proID = this.dgvProItem.CurrentCell == null ? "" : this.dgvProItem.CurrentRow.Cells["PRODUCT_ID"].Value.ToString();
                proItemDT = ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoMapList(proID);
                this.bindingSource2.DataSource = proItemDT.DefaultView;
                this.lblHiscount.Text = proItemDT.DefaultView.Count.ToString() + "条记录";
            }
            else
            {
                this.bindingSource2.DataSource = null;
                this.lblHiscount.Text = "0条记录";
            }
        }
        #endregion

        #region 查询按钮事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //过滤数据
            ItemFilter();
        }
        #endregion

        #region 过滤数据显示
        /// <summary>
        /// 设置过滤产品编码数据显示
        /// </summary>
        private void ItemFilter()
        {
            string producter = StringUtils.repalceSepStr(this.tbxproducter.Text);
            string productname = StringUtils.repalceSepStr(this.tbxproductname.Text);
            string procompare = this.cbbCompare.Text;
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(productname))
                filter.AppendFormat(" and (medical_name like '%{0}%' or medical_wubi like '%{0}%' or medical_pinyin like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%' or trade_name like '%{0}%')", productname.ToUpper());
            if (!string.IsNullOrEmpty(producter))
                filter.AppendFormat(" and (factory_name like '%{0}%' or factory_easy like '%{0}%' or factory_wubi like '%{0}%' or factory_pinyin like '%{0}%')", producter);

            // 按对照关系过滤
            switch (procompare)
            {
                case "一对一":
                    filter.Append(" and MapSum = 1"); break;
                case "一对多":
                    filter.Append(" and MapSum > 1"); break;
            }
            if (this.cachedDataView == null)
                return;
            this.cachedDataView.RowFilter = filter.ToString();
            this.InitGridTableView(1, pageNavigatorProIDComItem.PageSize);

            this.pageNavigatorProIDComItem.ItemCount = base.cachedDataView.Count;
            if (gridDataView.Count > 0)
            {
                DataRow dr = gridDataView.ToTable().Rows[0];
            }
        }
        #endregion

        #region 输入过滤数据
        private void cbbCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void tbxproductname_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            ItemFilter();
        }

        private void tbxproducter_TextChanged(object sender, EventArgs e)
        {
            CheckInputCom(sender);
            ItemFilter();
        }
        #endregion

        #region 回车事件
        private void tbxproductname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxproducter.Focus();
            }
        }

        private void tbxproducter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbCompare.Focus();
            }
        }
        #endregion

    }
}