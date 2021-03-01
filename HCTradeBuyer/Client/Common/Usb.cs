/*****************************************************************************
 * 作者: tangsj
 * 日期: 07-05-30
 * 说明: 读取key序列号的类
 * 维护历史: 
 * 
 * test label 1
 * 
 * test label 2
 * 
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using EMEDEPASSLib;


namespace Emedchina.TradeAssistant.Client.Common
{
    public class Usb
    {

        /// <summary>
        /// 新的各版本兼容的key序列号读取方法，具体读取逻辑封装到了控件中，并且控件会先判断key的版本
        /// </summary>
        /// <returns></returns>

        public static string GetSerialNumber()
        {

            string serialNumber = "";
            //未测试控件在未安装驱动时的处理，是否抛异常。也有可能没必要捕捉异常，以后时间富裕时再优化
            try
            {
                EMEDEPASSLib.EpassClass ec = new EMEDEPASSLib.EpassClass();
                serialNumber = (string)ec.getKeySn();
            }
            catch (Exception e)
            {

                MessageBox.Show("请检查是否安装了电子钥匙对应的驱动程序！");
            }
            return serialNumber;

        }
        /// <summary>
        /// 验证pin码
        /// </summary>
        /// <returns></returns>

        public static bool isCorrectUserPin(string userBin)
        {

            bool flag = false;

            try
            {
                EMEDEPASSLib.EpassClass ec = new EMEDEPASSLib.EpassClass();

                flag = (bool)ec.isCorrectUserPin(userBin);

            }
            catch (Exception e)
            {

                MessageBox.Show("请检查是否安装了电子钥匙对应的驱动程序！");
            }
            return flag;

        }

    }
}

