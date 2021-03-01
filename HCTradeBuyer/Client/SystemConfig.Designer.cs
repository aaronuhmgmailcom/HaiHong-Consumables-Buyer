namespace Emedchina.TradeAssistant.Client
{
    partial class SystemConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemConfig));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.WebＣonfigure = new System.Windows.Forms.GroupBox();
            this.txtUpdateWeb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTradeWeb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbServer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.WebＣonfigure.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.gbServer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.WebＣonfigure, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.txtPort);
            this.gbServer.Controls.Add(this.lblPort);
            this.gbServer.Controls.Add(this.txtIp);
            this.gbServer.Controls.Add(this.lblIp);
            resources.ApplyResources(this.gbServer, "gbServer");
            this.gbServer.Name = "gbServer";
            this.gbServer.TabStop = false;
            // 
            // txtPort
            // 
            resources.ApplyResources(this.txtPort, "txtPort");
            this.txtPort.Name = "txtPort";
            // 
            // lblPort
            // 
            resources.ApplyResources(this.lblPort, "lblPort");
            this.lblPort.Name = "lblPort";
            // 
            // txtIp
            // 
            resources.ApplyResources(this.txtIp, "txtIp");
            this.txtIp.Name = "txtIp";
            // 
            // lblIp
            // 
            resources.ApplyResources(this.lblIp, "lblIp");
            this.lblIp.Name = "lblIp";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WebＣonfigure
            // 
            this.WebＣonfigure.Controls.Add(this.txtUpdateWeb);
            this.WebＣonfigure.Controls.Add(this.label2);
            this.WebＣonfigure.Controls.Add(this.txtTradeWeb);
            this.WebＣonfigure.Controls.Add(this.label1);
            resources.ApplyResources(this.WebＣonfigure, "WebＣonfigure");
            this.WebＣonfigure.Name = "WebＣonfigure";
            this.WebＣonfigure.TabStop = false;
            // 
            // txtUpdateWeb
            // 
            resources.ApplyResources(this.txtUpdateWeb, "txtUpdateWeb");
            this.txtUpdateWeb.Name = "txtUpdateWeb";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtTradeWeb
            // 
            resources.ApplyResources(this.txtTradeWeb, "txtTradeWeb");
            this.txtTradeWeb.Name = "txtTradeWeb";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // SystemConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Emedchina.TradeAssistant.Client.Properties.Resources.Main09;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "SystemConfig";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SystemConfig_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.WebＣonfigure.ResumeLayout(false);
            this.WebＣonfigure.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox WebＣonfigure;
        private System.Windows.Forms.TextBox txtUpdateWeb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTradeWeb;
        private System.Windows.Forms.Label label1;

    }
}