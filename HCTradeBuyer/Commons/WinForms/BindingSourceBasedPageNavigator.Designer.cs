namespace Emedchina.Commons.WinForms
{
    partial class BindingSourceBasedPageNavigator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cachedDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pageNavigator = new Emedchina.Commons.WinForms.PageNavigator();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cachedDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            // 
            // pageNavigator
            // 
            this.pageNavigator.CurrentPageIndex = 0;
            this.pageNavigator.ItemCount = 0;
            this.pageNavigator.Location = new System.Drawing.Point(0, 0);
            this.pageNavigator.Name = "pageNavigator";
            this.pageNavigator.Size = new System.Drawing.Size(100, 25);
            this.pageNavigator.SortFields = null;
            this.pageNavigator.SortMethod = null;
            this.pageNavigator.TabIndex = 0;
            this.pageNavigator.Text = "pageNavigator";
            this.pageNavigator.PageIndexOrPageSizeChanged += new Emedchina.Commons.WinForms.PageChangedEventHandler(this.pageNavigator_PageIndexOrPageSizeChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(240, 150);
            this.dataGridView.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.cachedDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();

        }

        #endregion

        private PageNavigator pageNavigator;
        private System.Windows.Forms.BindingSource cachedDataTableBindingSource;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}
