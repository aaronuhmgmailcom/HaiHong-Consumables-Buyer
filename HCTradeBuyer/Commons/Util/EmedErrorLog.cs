using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Emedchina.Commons
{
    /// <summary>
    /// 错误日志类
    /// </summary>
    public class EmedErrorLog
    {
        public static void SaveLog(string inHeader, Exception inException)
        {
            StringBuilder builder1 = new StringBuilder(DateTime.Now.ToString() + "\r\n");
            if (inHeader != null)
            {
                builder1.Append(inHeader + "\r\n");
            }
            builder1.Append("异常信息: " + inException.Message.ToString() + "\r\n");
            builder1.Append("引发异常的对象: " + inException.Source.ToString() + "\r\n");
            builder1.Append("引发异常的方法: " + inException.TargetSite.ToString() + "\r\n");
            builder1.Append("异常位置: " + inException.StackTrace.ToString() + "\r\n");
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
