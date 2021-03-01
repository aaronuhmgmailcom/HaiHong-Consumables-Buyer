namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    partial class FormPackage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPackage));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPackage = new DevExpress.XtraEditors.TextEdit();
            this.BtnAffirm = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "组套数量：";
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(96, 22);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Properties.Mask.EditMask = "n0";
            this.txtPackage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPackage.Size = new System.Drawing.Size(140, 21);
            this.txtPackage.TabIndex = 0;
            this.txtPackage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPackage_KeyDown);
            // 
            // BtnAffirm
            // 
            this.BtnAffirm.Location = new System.Drawing.Point(64, 53);
            this.BtnAffirm.Name = "BtnAffirm";
            this.BtnAffirm.Size = new System.Drawing.Size(75, 23);
            this.BtnAffirm.TabIndex = 1;
            this.BtnAffirm.Text = "确认(&A)";
            this.BtnAffirm.Click += new System.EventHandler(this.BtnAffirm_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(161, 53);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "取消(&C)";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FormPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(289, 90);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAffirm);
            this.Controls.Add(this.txtPackage);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 115);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(295, 115);
            this.Name = "FormPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请输入组套数量";
            this.Load += new System.EventHandler(this.FormPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPackage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPackage;
        private DevExpress.XtraEditors.SimpleButton BtnAffirm;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
    }
}