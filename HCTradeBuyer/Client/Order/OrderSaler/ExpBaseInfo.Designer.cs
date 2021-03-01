namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    partial class ExpBaseInfo
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExpProduct = new System.Windows.Forms.Button();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.btnExpEnt = new System.Windows.Forms.Button();
            this.butExpBuyer = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbServer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExpProduct
            // 
            this.btnExpProduct.Location = new System.Drawing.Point(16, 20);
            this.btnExpProduct.Name = "btnExpProduct";
            this.btnExpProduct.Size = new System.Drawing.Size(94, 23);
            this.btnExpProduct.TabIndex = 0;
            this.btnExpProduct.Text = "导出产品信息";
            this.btnExpProduct.UseVisualStyleBackColor = true;
            this.btnExpProduct.Click += new System.EventHandler(this.btnExpProduct_Click);
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.btnExpEnt);
            this.gbServer.Controls.Add(this.butExpBuyer);
            this.gbServer.Controls.Add(this.btnExpProduct);
            this.gbServer.Location = new System.Drawing.Point(13, 13);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(324, 48);
            this.gbServer.TabIndex = 0;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "导出基础信息功能";
            // 
            // btnExpEnt
            // 
            this.btnExpEnt.Location = new System.Drawing.Point(224, 20);
            this.btnExpEnt.Name = "btnExpEnt";
            this.btnExpEnt.Size = new System.Drawing.Size(94, 23);
            this.btnExpEnt.TabIndex = 7;
            this.btnExpEnt.Text = "导出企业信息";
            this.btnExpEnt.UseVisualStyleBackColor = true;
            this.btnExpEnt.Click += new System.EventHandler(this.btnExpEnt_Click);
            // 
            // butExpBuyer
            // 
            this.butExpBuyer.Location = new System.Drawing.Point(116, 20);
            this.butExpBuyer.Name = "butExpBuyer";
            this.butExpBuyer.Size = new System.Drawing.Size(94, 23);
            this.butExpBuyer.TabIndex = 6;
            this.butExpBuyer.Text = "导出医院信息";
            this.butExpBuyer.UseVisualStyleBackColor = true;
            this.butExpBuyer.Click += new System.EventHandler(this.butExpBuyer_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.gbServer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.13979F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.86021F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(358, 117);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 32);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(247, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ExpBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 117);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExpBaseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出基础信息";
            this.gbServer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExpProduct;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.Button btnExpEnt;
        private System.Windows.Forms.Button butExpBuyer;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
    }
}