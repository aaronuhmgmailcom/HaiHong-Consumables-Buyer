//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	FileControl.cs      
//	创 建 人:	梁晓奕
//	创建日期:	2006-6-28
//	功能描述:	读写文件
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace Emedchina.TradeAssistant.Client.Common
{

    public class FileControl
    {
        //文件名
        private static readonly string filename = @"LastClass.txt";
        /// <summary>
        /// 记录用户最后一次操作的窗体
        /// </summary>
        /// <param name="functionName"></param>
        public static void clientLog(string functionName)
        {
            
            //string dateNow = DateTime.Now.ToString();
            //string content = CurrentUserName + "运行" + functionName + "功能模块(" + dateNow + ")";
            StreamWriter sw = null;
            try
            {
                sw = File.CreateText(filename);
                sw.WriteLine(functionName);

            }
            catch (IOException e)
            {
                
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
        /// <summary>
        /// 读取用户最后一次操作的窗体
        /// </summary>
        /// <returns></returns>
        public static string readLog()
        {
            
            //打开文件并显示其内容
            StreamReader reader = null;
            string line = "";

            try
            {
                reader = new StreamReader(filename);
                line = reader.ReadLine();

            }
            catch (IOException e)
            {

            }
            finally
            {
                if(reader!=null)
                reader.Close();
                
            }
            return line;
        }

        /// <summary>
        /// 压缩access库文件
        /// </summary>
        /// <param name="dbFileName"></param>
        public static void CompactAccessDB(string dbFileName)
        {
            try
            {
                string connectionString1 = ConfigurationManager.ConnectionStrings["ClientDB"].ConnectionString;
                connectionString1 = connectionString1.Replace("|DataDirectory|\\", AppDomain.CurrentDomain.BaseDirectory);
                //string connectionString1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbFileName;
                string connectionString2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "temp.mdb";
                object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));
                object[] oParams = new object[] { connectionString1, connectionString2 };

                objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);

                System.IO.File.Delete(dbFileName);
                
                System.IO.File.Move(AppDomain.CurrentDomain.BaseDirectory+"temp.mdb", dbFileName);
                if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory+"temp.mdb"))
                    System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory+"temp.mdb");
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                objJRO = null;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
