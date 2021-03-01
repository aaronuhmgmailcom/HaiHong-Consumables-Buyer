using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emedchina.Commons.WinForms
{
    partial class PageNavigator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageNavigator));
            this.countItem = new System.Windows.Forms.ToolStripLabel();
            this.l1ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pageInfo = new System.Windows.Forms.ToolStripLabel();
            this.pageSizeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.rowToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.l2ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.emptyLabel = new System.Windows.Forms.ToolStripLabel();
            this.l3ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.moveFirstPageBtn = new System.Windows.Forms.ToolStripButton();
            this.movePreviousPageBtn = new System.Windows.Forms.ToolStripButton();
            this.l4ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.currentPageTxt = new System.Windows.Forms.ToolStripTextBox();
            this.l5ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toPageBtn = new System.Windows.Forms.ToolStripButton();
            this.moveNextPageBtn = new System.Windows.Forms.ToolStripButton();
            this.l6ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.moveLastPageBtn = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // countItem
            // 
            this.countItem.Name = "countItem";
            this.countItem.Size = new System.Drawing.Size(35, 12);
            this.countItem.Text = "/ {0}";
            this.countItem.ToolTipText = "总项数";
            // 
            // l1ToolStripSeparator
            // 
            this.l1ToolStripSeparator.Name = "l1ToolStripSeparator";
            this.l1ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // pageInfo
            // 
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // pageSizeCombo
            // 
            this.pageSizeCombo.AutoSize = false;
            this.pageSizeCombo.Items.AddRange(new object[] {
            "10",
            "20",
            "50"});
            this.pageSizeCombo.Name = "pageSizeCombo";
            this.pageSizeCombo.Size = new System.Drawing.Size(50, 20);
            this.pageSizeCombo.Text = "20";
            this.pageSizeCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pageSizeCombo_KeyDown);
            this.pageSizeCombo.SelectedIndexChanged += new System.EventHandler(this.pageSizeCombo_SelectedIndexChanged);
            // 
            // rowToolStripLabel
            // 
            this.rowToolStripLabel.Name = "rowToolStripLabel";
            this.rowToolStripLabel.Size = new System.Drawing.Size(29, 12);
            this.rowToolStripLabel.Text = "行　";
            // 
            // l2ToolStripSeparator
            // 
            this.l2ToolStripSeparator.Name = "l2ToolStripSeparator";
            this.l2ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // emptyLabel
            // 
            this.emptyLabel.Name = "emptyLabel";
            this.emptyLabel.Size = new System.Drawing.Size(35, 12);
            this.emptyLabel.Text = "     ";
            // 
            // l3ToolStripSeparator
            // 
            this.l3ToolStripSeparator.Name = "l3ToolStripSeparator";
            this.l3ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // moveFirstPageBtn
            // 
            this.moveFirstPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveFirstPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveFirstPageBtn.Image")));
            this.moveFirstPageBtn.Name = "moveFirstPageBtn";
            this.moveFirstPageBtn.RightToLeftAutoMirrorImage = true;
            this.moveFirstPageBtn.Size = new System.Drawing.Size(23, 20);
            this.moveFirstPageBtn.Text = "移到第一条页";
            this.moveFirstPageBtn.Click += new System.EventHandler(this.moveFirstPageBtn_Click);
            // 
            // movePreviousPageBtn
            // 
            this.movePreviousPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.movePreviousPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("movePreviousPageBtn.Image")));
            this.movePreviousPageBtn.Name = "movePreviousPageBtn";
            this.movePreviousPageBtn.RightToLeftAutoMirrorImage = true;
            this.movePreviousPageBtn.Size = new System.Drawing.Size(23, 20);
            this.movePreviousPageBtn.Text = "移到上一页";
            this.movePreviousPageBtn.Click += new System.EventHandler(this.movePreviousPageBtn_Click);
            // 
            // l4ToolStripSeparator
            // 
            this.l4ToolStripSeparator.Name = "l4ToolStripSeparator";
            this.l4ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // currentPageTxt
            // 
            this.currentPageTxt.AccessibleName = "位置";
            this.currentPageTxt.AutoSize = false;
            this.currentPageTxt.Name = "currentPageTxt";
            this.currentPageTxt.Size = new System.Drawing.Size(50, 21);
            this.currentPageTxt.Text = "1";
            this.currentPageTxt.ToolTipText = "当前页";
            this.currentPageTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentPageTxt_KeyDown);
            // 
            // l5ToolStripSeparator
            // 
            this.l5ToolStripSeparator.Name = "l5ToolStripSeparator";
            this.l5ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toPageBtn
            // 
            this.toPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toPageBtn.Name = "toPageBtn";
            this.toPageBtn.Size = new System.Drawing.Size(23, 16);
            this.toPageBtn.Text = "&To";
            this.toPageBtn.ToolTipText = "跳转";
            this.toPageBtn.Click += new System.EventHandler(this.toPageBtn_Click);
            // 
            // moveNextPageBtn
            // 
            this.moveNextPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveNextPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveNextPageBtn.Image")));
            this.moveNextPageBtn.Name = "moveNextPageBtn";
            this.moveNextPageBtn.RightToLeftAutoMirrorImage = true;
            this.moveNextPageBtn.Size = new System.Drawing.Size(23, 20);
            this.moveNextPageBtn.Text = "移到下一页";
            this.moveNextPageBtn.Click += new System.EventHandler(this.moveNextPageBtn_Click);
            // 
            // l6ToolStripSeparator
            // 
            this.l6ToolStripSeparator.Name = "l6ToolStripSeparator";
            this.l6ToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // moveLastPageBtn
            // 
            this.moveLastPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLastPageBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveLastPageBtn.Image")));
            this.moveLastPageBtn.Name = "moveLastPageBtn";
            this.moveLastPageBtn.RightToLeftAutoMirrorImage = true;
            this.moveLastPageBtn.Size = new System.Drawing.Size(23, 20);
            this.moveLastPageBtn.Text = "移到最后一页";
            this.moveLastPageBtn.Click += new System.EventHandler(this.moveLastPageBtn_Click);
            // 
            // PageNavigator
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l1ToolStripSeparator,
            this.pageInfo,
            this.pageSizeCombo,
            this.rowToolStripLabel,
            this.l2ToolStripSeparator,
            this.emptyLabel,
            this.l3ToolStripSeparator,
            this.moveFirstPageBtn,
            this.movePreviousPageBtn,
            this.l4ToolStripSeparator,
            this.currentPageTxt,
            this.countItem,
            this.l5ToolStripSeparator,
            this.toPageBtn,
            this.moveNextPageBtn,
            this.moveLastPageBtn,
            this.l6ToolStripSeparator});
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ToolStripLabel countItem;
        private System.Windows.Forms.ToolStripButton moveFirstPageBtn;
        private System.Windows.Forms.ToolStripButton movePreviousPageBtn;
        private System.Windows.Forms.ToolStripSeparator l4ToolStripSeparator;
        private System.Windows.Forms.ToolStripTextBox currentPageTxt;
        private System.Windows.Forms.ToolStripSeparator l5ToolStripSeparator;
        private System.Windows.Forms.ToolStripButton moveNextPageBtn;
        private System.Windows.Forms.ToolStripButton moveLastPageBtn;
        private System.Windows.Forms.ToolStripSeparator l6ToolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator l1ToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel pageInfo;
        private System.Windows.Forms.ToolStripSeparator l2ToolStripSeparator;
        private System.Windows.Forms.ToolStripComboBox pageSizeCombo;
        private System.Windows.Forms.ToolStripLabel emptyLabel;
        private System.Windows.Forms.ToolStripSeparator l3ToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel rowToolStripLabel;
        private System.Windows.Forms.ToolStripButton toPageBtn;        

        #endregion
    }
}
