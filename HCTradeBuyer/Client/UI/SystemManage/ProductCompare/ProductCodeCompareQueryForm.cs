/*****************************************************************************
创 建 人:	yanbing
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
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.BLL.His.Product;

namespace Emedchina.TradeAssistant.Client.His.Product
{
    public partial class ProductCodeCompareQueryForm : BaseForm
    {
        #region 变量定义区
        public DataTable commDT;
        private DataTable proItemDT;
        private Thread thread;
        string proID;
        string modelID;
        string specID;
        #endregion

        #region 构造函数
        public ProductCodeCompareQueryForm()
        {
            InitializeComponent();
            //线程开始
            //thread = new Thread(new ThreadStart(ShowWaiting));
            //thread.Start();
            //查询
            DataBind();
            this.cbbCompare.Text = "全部数据";
            //线程结束
            //thread.Abort();
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
           
            commDT = ProductCodeCompareBLL.GetInstance().GetGpoHitCommList();
            if (commDT == null)
                return;
            this.bindingSource1.DataSource = commDT.DefaultView;
            InitFromCacheByData(commDT);
            
        }
        #endregion


        #region 选择事件
        private void dgvProItem_CurrentCellChanged(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                proID = dr["PROJECT_PROD_ID"].ToString();
                modelID = dr["MODEL_ID"].ToString();
                specID = dr["SPEC_ID"].ToString();


                proItemDT = ProductCodeCompareBLL.GetInstance().GetGpoMapList(proID, modelID, specID);
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
            string producter = this.tbxproducter.Text;
            string productname = this.tbxproductname.Text;
            string procompare = this.cbbCompare.Text;
            StringBuilder filter = new StringBuilder();
            filter.Append("1=1");
            if (!string.IsNullOrEmpty(productname))
                filter.AppendFormat(" AND (COMMON_NAME LIKE '%{0}%' OR PRODUCT_NAME LIKE '%{0}%' OR COMMERCE_NAME LIKE '%{0}%' or ABBR_PY like '%{0}%' or ABBR_WB like '%{0}%')", productname);
            if (!string.IsNullOrEmpty(producter))
                filter.AppendFormat(" AND (MANU_NAME LIKE '%{0}%' OR MANU_NAME_ABBR LIKE '%{0}%')", producter);//or FACTORY_EASY like '%{0}%' or FACTORY_WUBI LIKE '%{0}%' or FACTORY_PINYIN like '%{0}%'

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
            //this.InitGridTableView(1, pageNavigatorProIDComItem.PageSize);

            //this.pageNavigatorProIDComItem.ItemCount = base.cachedDataView.Count;
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
            gridView3_FocusedRowChanged(null, null);
        }

        private void tbxproductname_TextChanged(object sender, EventArgs e)
        {
            ItemFilter();
        }

        private void tbxproducter_TextChanged(object sender, EventArgs e)
        {
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

     
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                proID = dr["PROJECT_PROD_ID"].ToString();
                modelID = dr["MODEL_ID"].ToString();
                specID = dr["SPEC_ID"].ToString();

                proItemDT = ProductCodeCompareBLL.GetInstance().GetGpoMapList(proID, modelID, specID);
                this.bindingSource2.DataSource = proItemDT.DefaultView;
                this.lblHiscount.Text = proItemDT.DefaultView.Count.ToString() + "条记录";
            }
            else
            {
                this.bindingSource2.DataSource = null;
                this.lblHiscount.Text = "0条记录";
            }
        }

        /// <summary>
        /// esc犍关闭本窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductCodeCompareQueryForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

    }
}