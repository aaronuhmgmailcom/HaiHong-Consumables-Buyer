using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting;

namespace Emedchina.TradeAssistantSaler.GPOSalerService
{
    partial class GPOSalerService : ServiceBase
    {
        public GPOSalerService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当在派生类中实现时，在下列情况下执行：在“服务控制管理器”(SCM) 向服务发送“开始”命令时，或者在操作系统启动时（对于自动启动的服务）。指定服务启动时采取的操作。
        /// </summary>
        /// <param name="args">启动命令传递的数据。</param>
        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "GPOSalerRemoting.config";
            // EventLog.WriteEntry(String.Format("AssistantService starting. Current path is '{0}',CurrentDomain.BaseDirectory is {1} ", Environment.CurrentDirectory, configPath));

            RemotingConfiguration.Configure(configPath, false);
        }

        /// <summary>
        /// 在派生类中实现时，该方法于“服务控制管理器”(SCM) 将“停止”命令发送到服务时执行。指定服务停止运行时采取的操作。
        /// </summary>
        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            //Process.GetProcessById(int.Parse(RemotingConfiguration.ProcessId)).Kill();
        }
    }
}
