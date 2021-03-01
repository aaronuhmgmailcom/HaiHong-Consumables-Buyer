namespace Emedchina.TradeAssistantSaler.GPOSalerService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tradeAssistantServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.tradeAssistantServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // tradeAssistantServiceProcessInstaller
            // 
            this.tradeAssistantServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.tradeAssistantServiceProcessInstaller.Password = null;
            this.tradeAssistantServiceProcessInstaller.Username = null;
            // 
            // tradeAssistantServiceInstaller
            // 
            this.tradeAssistantServiceInstaller.Description = "海虹医药电子商务交易助手服务";
            this.tradeAssistantServiceInstaller.DisplayName = "GPOSaler";
            this.tradeAssistantServiceInstaller.ServiceName = "GPOSaler";
            this.tradeAssistantServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.tradeAssistantServiceProcessInstaller,
            this.tradeAssistantServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller tradeAssistantServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller tradeAssistantServiceInstaller;
    }
}