using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceProcess;

namespace Emedchina.TradeAssistantSaler.GPOSalerService
{
    static class Program
    {
        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // ͬһ�����п������ж���û�������Ҫ��
            // ��һ��������ӵ��˽����У������������
            // ������һ������������磬
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new GPOSalerService() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}