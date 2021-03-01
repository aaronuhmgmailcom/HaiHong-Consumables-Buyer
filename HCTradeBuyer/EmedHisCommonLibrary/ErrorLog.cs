using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Emedchina.TradeAsst.EmedHisCommonLibrary
{

    public class ErrorLog
    {
        public static void SaveLog(string inHeader, Exception inException)
        {
            StringBuilder builder1 = new StringBuilder(DateTime.Now.ToString() + "\r\n");
            if (inHeader != null)
            {
                builder1.Append(inHeader + "\r\n");
            }
            builder1.Append("�쳣��Ϣ: " + inException.Message.ToString() + "\r\n");
            builder1.Append("�����쳣�Ķ���: " + inException.Source.ToString() + "\r\n");
            builder1.Append("�����쳣�ķ���: " + inException.TargetSite.ToString() + "\r\n");
            builder1.Append("�쳣λ��: " + inException.StackTrace.ToString() + "\r\n");
            builder1.Append("\r\n");
            string text1 = Application.StartupPath + @"\ErrorLog.txt";
            if (!File.Exists(text1))
            {
                File.Open(text1, FileMode.OpenOrCreate).Close();
            }
            try
            {
                StreamWriter writer1 = new StreamWriter(text1, true, Encoding.GetEncoding("GB2312"));
                writer1.WriteLine(builder1.ToString());
                writer1.Close();
            }
            catch
            {
            }
        }

    }
}

