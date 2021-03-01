namespace Emedchina.TradeAssistant.Sync.Order
{
    partial class SyncForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncForm));
            this.SyncProgressBar = new System.Windows.Forms.ProgressBar();
            this.SyncBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.csvFlag = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Bt_exit = new System.Windows.Forms.Button();
            this.lbrec = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SyncProgressBar
            // 
            this.SyncProgressBar.Location = new System.Drawing.Point(27, 362);
            this.SyncProgressBar.Name = "SyncProgressBar";
            this.SyncProgressBar.Size = new System.Drawing.Size(385, 26);
            this.SyncProgressBar.TabIndex = 0;
            // 
            // SyncBackgroundWorker
            // 
            this.SyncBackgroundWorker.WorkerReportsProgress = true;
            this.SyncBackgroundWorker.WorkerSupportsCancellation = true;
            this.SyncBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SyncBackgroundWorker_DoWork);
            this.SyncBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SyncBackgroundWorker_RunWorkerCompleted);
            this.SyncBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SyncBackgroundWorker_ProgressChanged);
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.BackColor = System.Drawing.Color.Transparent;
            this.okButton.Location = new System.Drawing.Point(251, 392);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "确定(&O)";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.BackColor = System.Drawing.Color.Transparent;
            this.msgLabel.Location = new System.Drawing.Point(32, 342);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(311, 12);
            this.msgLabel.TabIndex = 2;
            this.msgLabel.Text = "正在同步本地数据,这可能需要一段时间，请您耐心等待。";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Location = new System.Drawing.Point(25, 402);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "    ";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(40, 22);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(59, 16);
            this.rbAll.TabIndex = 4;
            this.rbAll.Text = "全同步";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.Location = new System.Drawing.Point(40, 48);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(71, 16);
            this.rbAdd.TabIndex = 5;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "增量同步";
            this.rbAdd.UseVisualStyleBackColor = true;
            // 
            // csvFlag
            // 
            this.csvFlag.AutoSize = true;
            this.csvFlag.Enabled = false;
            this.csvFlag.Location = new System.Drawing.Point(116, 22);
            this.csvFlag.Name = "csvFlag";
            this.csvFlag.Size = new System.Drawing.Size(126, 16);
            this.csvFlag.TabIndex = 6;
            this.csvFlag.Text = "采用csv方式全同步";
            this.csvFlag.UseVisualStyleBackColor = true;
            this.csvFlag.Visible = false;
            this.csvFlag.CheckedChanged += new System.EventHandler(this.csvFlag_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkUpload);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Controls.Add(this.rbAdd);
            this.groupBox1.Controls.Add(this.csvFlag);
            this.groupBox1.Location = new System.Drawing.Point(27, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "同步类型";
            // 
            // chkUpload
            // 
            this.chkUpload.AutoSize = true;
            this.chkUpload.Checked = true;
            this.chkUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpload.Location = new System.Drawing.Point(116, 48);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(96, 16);
            this.chkUpload.TabIndex = 21;
            this.chkUpload.Text = "上传本地数据";
            this.chkUpload.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(27, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(386, 233);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.jpg");
            this.imageList1.Images.SetKeyName(1, "down.jpg");
            // 
            // Bt_exit
            // 
            this.Bt_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_exit.BackColor = System.Drawing.Color.Transparent;
            this.Bt_exit.Location = new System.Drawing.Point(335, 392);
            this.Bt_exit.Name = "Bt_exit";
            this.Bt_exit.Size = new System.Drawing.Size(75, 23);
            this.Bt_exit.TabIndex = 20;
            this.Bt_exit.Text = "关闭(&E)";
            this.Bt_exit.UseVisualStyleBackColor = false;
            this.Bt_exit.Click += new System.EventHandler(this.Bt_exit_Click);
            // 
            // lbrec
            // 
            this.lbrec.BackColor = System.Drawing.Color.Transparent;
            this.lbrec.Location = new System.Drawing.Point(195, 342);
            this.lbrec.Name = "lbrec";
            this.lbrec.Size = new System.Drawing.Size(218, 12);
            this.lbrec.TabIndex = 22;
            this.lbrec.Text = "    ";
            this.lbrec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbrec.Visible = false;
            // 
            // SyncForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(440, 426);
            this.Controls.Add(this.lbrec);
            this.Controls.Add(this.Bt_exit);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.SyncProgressBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海虹医疗器械电子商务耗材交易系统--数据同步";
            this.Load += new System.EventHandler(this.SyncForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar SyncProgressBar;
        private System.ComponentModel.BackgroundWorker SyncBackgroundWorker;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.CheckBox csvFlag;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Bt_exit;
        private System.Windows.Forms.CheckBox chkUpload;
        private System.Windows.Forms.Label lbrec;
    }
}