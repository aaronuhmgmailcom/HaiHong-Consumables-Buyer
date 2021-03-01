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
        /// ������������ʵ��ʱ�������������ִ�У��ڡ�������ƹ�������(SCM) ������͡���ʼ������ʱ�������ڲ���ϵͳ����ʱ�������Զ������ķ��񣩡�ָ����������ʱ��ȡ�Ĳ�����
        /// </summary>
        /// <param name="args">��������ݵ����ݡ�</param>
        protected override void OnStart(string[] args)
        {
            // TODO: �ڴ˴���Ӵ�������������
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "GPOSalerRemoting.config";
            // EventLog.WriteEntry(String.Format("AssistantService starting. Current path is '{0}',CurrentDomain.BaseDirectory is {1} ", Environment.CurrentDirectory, configPath));

            RemotingConfiguration.Configure(configPath, false);
        }

        /// <summary>
        /// ����������ʵ��ʱ���÷����ڡ�������ƹ�������(SCM) ����ֹͣ������͵�����ʱִ�С�ָ������ֹͣ����ʱ��ȡ�Ĳ�����
        /// </summary>
        protected override void OnStop()
        {
            // TODO: �ڴ˴���Ӵ�����ִ��ֹͣ��������Ĺرղ�����
            //Process.GetProcessById(int.Parse(RemotingConfiguration.ProcessId)).Kill();
        }
    }
}
