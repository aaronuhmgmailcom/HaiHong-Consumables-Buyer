using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

using IBatisNet.Common.Logging;
using Emedchina.Commons.Debug;

namespace Emedchina.Commons.WinForms
{
    /// <summary>
    /// 通过将PageNavigator，DataGridView，和缓存BindingSource组合，自动维护缓存分页。
    /// 通过LoadData()方法触发数据加载到DataGridView中。
    /// 由于缺少灵活性，并且测试不完善，不建议在代码中直接使用。
    /// </summary>
    public partial class BindingSourceBasedPageNavigator : Component
    {

        ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BindingSourceBasedPageNavigator"/> class.
        /// </summary>
        public BindingSourceBasedPageNavigator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BindingSourceBasedPageNavigator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public BindingSourceBasedPageNavigator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        [Browsable(true)]
        public DataGridView OnePageDataGridView
        {
            get { return this.dataGridView; }
            set
            {
                this.dataGridView = value;
                this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            }
        }

        /// <summary>
        /// Gets or sets the cache binding source.
        /// </summary>
        /// <value>The cache binding source.</value>
        [Browsable(true)]
        public BindingSource CachedBindingSource
        {
            get { return this.cachedDataTableBindingSource; }
            set { this.cachedDataTableBindingSource = value; }
        }

        //[Browsable(true)]
        //public BindingSource OnePageBindingSource
        //{
        //    get { return this.gridViewBindingSource; }
        //    set { this.gridViewBindingSource = value; }
        //}

        /// <summary>
        /// Gets or sets the page navigator.
        /// </summary>
        /// <value>The page navigator.</value>
        [Browsable(true)]
        public PageNavigator PageNavigator
        {
            get { return this.pageNavigator; }
            set
            {
                this.pageNavigator = value;
                this.pageNavigator.PageIndexOrPageSizeChanged += new Emedchina.Commons.WinForms.PageChangedEventHandler(this.pageNavigator_PageIndexOrPageSizeChanged);
            }
        }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Browsable(false)]
        public Object DataSource
        {
            get { return this.CachedBindingSource.DataSource; }
            set { this.CachedBindingSource.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the data member.
        /// </summary>
        /// <value>The data member.</value>
        [Browsable(false)]
        public string DataMember
        {
            get { return this.CachedBindingSource.DataMember; }
            set { this.CachedBindingSource.DataMember = value; }
        }

        //private Type objectType;

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            BindingSource openPageBindingSource = new BindingSource();
            //openPageBindingSource.DataSource = typeof(System.Data.DataTable);

            PageNavigator.ItemCount = CachedBindingSource.Count;
            if (PageNavigator.ItemCount <= 0)
            {
                try
                {
                    OnePageDataGridView.DataSource = CachedBindingSource;
                }
                catch (Exception e)
                {
                    Debug.DebugUtils.Debug(_log, e);
                }
                return;
            }

            int lowIndex = PageUtils.GetLowIndexOfPage(PageNavigator.CurrentPageIndex, PageNavigator.PageSize);
            int highIndex = PageUtils.GetHighIndexOfPage(PageNavigator.CurrentPageIndex, PageNavigator.PageSize);
            if (lowIndex <= 1)
                lowIndex = 1;
            if (highIndex >= CachedBindingSource.Count)
                highIndex = CachedBindingSource.Count;

            object o = CachedBindingSource[0];
            if (o is DataRowView)//|| o is DataRow
            {
                DataTable dt = ((DataRowView)o).Row.Table.Clone();
                for (int i = lowIndex; i <= highIndex; i++)
                {
                    DataRowView drv = CachedBindingSource[i - 1] as DataRowView;
                    DataRow dr = dt.NewRow();
                    copyRow(drv.Row, dr);
                    dt.Rows.Add(dr);
                }
                openPageBindingSource.DataSource = dt;
            }
            else
            {
                for (int i = lowIndex; i <= highIndex; i++)
                {
                    object obj = CachedBindingSource[i - 1];
                    openPageBindingSource.Add(obj);
                }
            }

            OnePageDataGridView.DataSource = openPageBindingSource;
        }

        private void copyRow(DataRow srcRow, DataRow destRow)
        {
            int count = srcRow.Table.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                destRow[i] = srcRow[i];
            }
        }

        private void pageNavigator_PageIndexOrPageSizeChanged(object source, PageChangedEventArgs e)
        {
            LoadData();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DebugUtils.Debug(_log, e.Exception);
        }
    }
}
