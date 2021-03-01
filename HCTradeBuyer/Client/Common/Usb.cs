/*****************************************************************************
 * ����: tangsj
 * ����: 07-05-30
 * ˵��: ��ȡkey���кŵ���
 * ά����ʷ: 
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
        /// �µĸ��汾���ݵ�key���кŶ�ȡ�����������ȡ�߼���װ���˿ؼ��У����ҿؼ������ж�key�İ汾
        /// </summary>
        /// <returns></returns>

        public static string GetSerialNumber()
        {

            string serialNumber = "";
            //δ���Կؼ���δ��װ����ʱ�Ĵ����Ƿ����쳣��Ҳ�п���û��Ҫ��׽�쳣���Ժ�ʱ�主ԣʱ���Ż�
            try
            {
                EMEDEPASSLib.EpassClass ec = new EMEDEPASSLib.EpassClass();
                serialNumber = (string)ec.getKeySn();
            }
            catch (Exception e)
            {

                MessageBox.Show("�����Ƿ�װ�˵���Կ�׶�Ӧ����������");
            }
            return serialNumber;

        }
        /// <summary>
        /// ��֤pin��
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

                MessageBox.Show("�����Ƿ�װ�˵���Կ�׶�Ӧ����������");
            }
            return flag;

        }

    }
}

