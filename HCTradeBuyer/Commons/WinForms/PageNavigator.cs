using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emedchina.Commons.WinForms
{
    /// <summary>
    /// 
    /// </summary>
    [DefaultEvent("PageIndexOrPageSizeChanged")]
    [Description("Page Navigator")]
    public partial class PageNavigator : ToolStrip
    {
        public PageNavigator()
        {
            InitializeComponent();
        }

        private static readonly string PAGEINFOTEXT = "  第{0}/{1}页  共{2}条记录   每页";
        private static readonly string ALLPAGEINFOTEXT = "/ {0}";
        private static readonly int DEFAULTPAGESIZE = 20;
        private static readonly int FIRSTPAGEINDEX = 1;

        private int pageSize = DEFAULTPAGESIZE;
        private int currentPageIndex = 1;
        private int itemCount = 0;

        private string _sortFields=string.Empty;

        /// <summary>
        /// Gets or sets the sort fields.
        /// </summary>
        /// <value>The sort fields.</value>
        [Category("Page")]
        [DefaultValue("")]
        [Description("排序字段")]
        public string SortFields
        {
            get { return _sortFields; }
            set { _sortFields = value; }
        }

        private string _sortMethod="ASC";

        /// <summary>
        /// Gets or sets the sort method.
        /// </summary>
        /// <value>The sort method.</value>
        [Category("Page")]
        [DefaultValue("ASC")]
        [Description("排序方式ASC,DESC")]
        public string SortMethod
        {
            get { return _sortMethod; }
            set { _sortMethod = value; }
        }


        //客户端设置
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        [Category("Page")]
        [DefaultValue(20)]
        [Description("一页的行数")]
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// Gets or sets the index of the current page.
        /// </summary>
        /// <value>The index of the current page.</value>
        [Browsable(false)]
        virtual public int CurrentPageIndex
        {
            get
            {
                if (ItemCount == 0) { return 0; }
                else return currentPageIndex;
            }
            set
            {
                if (value > PageCount) currentPageIndex = PageCount;
                else if (value < FIRSTPAGEINDEX) currentPageIndex = FIRSTPAGEINDEX;
                else currentPageIndex = value;
            }
        }

        /// <summary>
        /// Gets the page count.
        /// </summary>
        /// <value>The page count.</value>
        [Browsable(false)]
        public int PageCount
        {
            get
            {
                if (ItemCount == 0) { return 0; }
                else { return (ItemCount - 1) / pageSize + 1; }
            }
        }
        /// <summary>
        /// 总记录数，使用该控件的窗体为其赋值
        /// </summary>
        [Browsable(false)]
        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                if (itemCount == value && itemCount != 0)
                {
                    return;
                }
                else
                {
                    itemCount = value;
                    SetPagedInfo();
                }
            }
        }

        /// <summary>
        /// Gets the index of the next page.
        /// </summary>
        /// <value>The index of the next page.</value>
        [Browsable(false)]
        public int NextPageIndex
        {
            get { return currentPageIndex < PageCount ? currentPageIndex + 1 : currentPageIndex; }
        }

        /// <summary>
        /// Gets the index of the previews page.
        /// </summary>
        /// <value>The index of the previews page.</value>
        [Browsable(false)]
        public int PreviewsPageIndex
        {
            get { return currentPageIndex <= FIRSTPAGEINDEX ? FIRSTPAGEINDEX : currentPageIndex - 1; }
        }

        /// <summary>
        /// Resets the size of the page.
        /// </summary>
        public virtual void ResetPageSize()
        {
            PageSize = DEFAULTPAGESIZE;
        }

        /// <summary>
        /// Changes the size of the page index or page.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        public void ChangePageIndexOrPageSize(int index, int size)
        {
            if (index == CurrentPageIndex && size == PageSize)
            {
                return;
            }
            else
            {
                this.CurrentPageIndex = index;
                this.PageSize = size;
                OnPageIndexOrPageSizeChanged(new PageChangedEventArgs(CurrentPageIndex, PageSize));
                SetPagedInfo();
            }
        }

        /// <summary>
        /// Sets the paged info.
        /// "  第{0}/{1}页  共{2}条记录   每页";
        /// </summary>
        protected virtual void SetPagedInfo()
        {
            this.pageInfo.Text = string.Format(PAGEINFOTEXT, CurrentPageIndex, PageCount, ItemCount);
            this.countItem.Text = string.Format(ALLPAGEINFOTEXT, PageCount);
            this.currentPageTxt.Text = CurrentPageIndex.ToString();
        }

        public event PageChangedEventHandler PageIndexOrPageSizeChanged;

        /// <summary>
        /// Raises the <see cref="E:PageIndexOrPageSizeChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:Emedchina.Commons.WinForms.PageChangedEventArgs"/> instance containing the event data.</param>
        virtual protected void OnPageIndexOrPageSizeChanged(PageChangedEventArgs e)
        {
            if (PageIndexOrPageSizeChanged != null)
                PageIndexOrPageSizeChanged(this, e);
        }

        /// <summary>
        /// Handles the Click event of the moveLastPageBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void moveLastPageBtn_Click(object sender, EventArgs e)
        {
            ChangePageIndexOrPageSize(PageCount, PageSize);
        }

        /// <summary>
        /// Handles the Click event of the moveNextPageBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void moveNextPageBtn_Click(object sender, EventArgs e)
        {
            ChangePageIndexOrPageSize(NextPageIndex, PageSize);
        }

        /// <summary>
        /// Handles the Click event of the toPageBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void toPageBtn_Click(object sender, EventArgs e)
        {
            ChangePageIndexOrPageSize(NewPageIndex, PageSize);
        }


        /// <summary>
        /// Gets the new index of the page.
        /// </summary>
        /// <value>The new index of the page.</value>
        /// <returns></returns>
        protected virtual int NewPageIndex
        {
            get
            {
                string newPage = this.currentPageTxt.Text;
                try
                {
                    int pageIndex = Convert.ToInt32(newPage);
                    return pageIndex;
                }
                catch
                {
                    return CurrentPageIndex;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the movePreviousPageBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void movePreviousPageBtn_Click(object sender, EventArgs e)
        {
            ChangePageIndexOrPageSize(PreviewsPageIndex, PageSize);
        }

        /// <summary>
        /// Handles the Click event of the moveFirstPageBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void moveFirstPageBtn_Click(object sender, EventArgs e)
        {
            ChangePageIndexOrPageSize(FIRSTPAGEINDEX, PageSize);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the pageSizeCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void pageSizeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePageIndexOrPageSize(CurrentPageIndex, NewPageSize);
        }

        /// <summary>
        /// Gets the new size of the page.
        /// </summary>
        /// <value>The new size of the page.</value>
        protected virtual int NewPageSize
        {
            get
            {
                string newSize = this.pageSizeCombo.Text;
                try
                {
                    int pageSize = Convert.ToInt32(newSize);
                    return pageSize;
                }
                catch
                {
                    return DEFAULTPAGESIZE;
                }
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the currentPageTxt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void currentPageTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangePageIndexOrPageSize(NewPageIndex, PageSize);
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the pageSizeCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void pageSizeCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangePageIndexOrPageSize(CurrentPageIndex, NewPageSize);
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class PageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PageChangedEventArgs"/> class.
        /// </summary>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        public PageChangedEventArgs(int currentPageIndex, int currentPageSize)
        {
            _currentPageIndex = currentPageIndex;
            _currentPageSize = currentPageSize;
        }

        private int _currentPageIndex;

        /// <summary>
        /// Gets the index of the current page.
        /// </summary>
        /// <value>The index of the current page.</value>
        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            //set { currentPageIndex = value; }
        }
        private int _currentPageSize;

        /// <summary>
        /// Gets the size of the current page.
        /// </summary>
        /// <value>The size of the current page.</value>
        public int CurrentPageSize
        {
            get { return _currentPageSize; }
            //set { currentPageSize = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public delegate void PageChangedEventHandler(object source, PageChangedEventArgs e);
}
