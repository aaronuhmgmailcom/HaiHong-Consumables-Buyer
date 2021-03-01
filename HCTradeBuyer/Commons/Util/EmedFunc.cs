using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Emedchina.Commons
{
    /// <summary>
    /// 通用函数类
    /// </summary>
    public class EmedFunc
    {
        /// <summary>
        /// List数据拷贝
        /// </summary>
        /// <param name="inDestination"></param>
        /// <param name="inSource"></param>
        /// <returns></returns>
        public static ArrayList ArrayAppend(ArrayList inDestination, ArrayList inSource)
        {
            for (int num1 = 0; num1 < inSource.Count; num1++)
            {
                inDestination.Add(inSource[num1]);
            }
            return inDestination;
        }
        /// <summary>
        /// 查询段开始日期
        /// </summary>
        /// <param name="inDate"></param>
        /// <returns></returns>
        public static string BeginDate(DateTime inDate)
        {
            return inDate.ToShortDateString();
        }

        /// <summary>
        /// 检查是否存在记录
        /// </summary>
        /// <param name="inData"></param>
        /// <returns></returns>
        public static bool CheckData(DataSet inData)
        {
            bool flag1 = false;
            if (EmedFunc.CheckTable(inData))
            {
                for (int num1 = 0; num1 < inData.Tables.Count; num1++)
                {
                    if (inData.Tables[num1].Rows.Count > 0)
                    {
                        flag1 = true;
                    }
                }
                return flag1;
            }
            return false;
        }
        /// <summary>
        /// 检查dataset内是否存在datatable
        /// </summary>
        /// <param name="inData"></param>
        /// <returns></returns>
        public static bool CheckTable(DataSet inData)
        {
            if (inData != null)
            {
                if (inData.Tables.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 空串转换为null
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string EmptyToNull(string inStr)
        {
            if (inStr == null)
            {
                return "null";
            }
            if (inStr.CompareTo("") == 0)
            {
                return "null";
            }
            try
            {
                return Convert.ToDouble(inStr).ToString();
            }
            catch
            {
                return "null";
            }
        }
        /// <summary>
        /// 空串转换为0
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string EmptyToZero(string inStr)
        {
            if (inStr == null)
            {
                return "0";
            }
            if (inStr.CompareTo("") == 0)
            {
                return "0";
            }
            try
            {
                return Convert.ToDouble(inStr).ToString();
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// 查询段结束日期
        /// </summary>
        /// <param name="inDate"></param>
        /// <returns></returns>
        public static string EndDate(DateTime inDate)
        {
            return (inDate.ToShortDateString() + " 23:59:59");
        }
        /// <summary>
        ///  特定字符转换
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string FilterString(string inStr)
        {
            return inStr.Replace("[", "[[]").Replace("*", "[*]").Replace("/", "[/]").Replace("^", "").Replace("'", "''").Replace("%", "[%]");
        }
        /// <summary>
        /// 获取Dataset总行数
        /// </summary>
        /// <param name="inData"></param>
        /// <returns></returns>
        public static int GetDataSetRow(DataSet inData)
        {
            int num1 = 0;
            for (int num2 = 0; num2 < inData.Tables.Count; num2++)
            {
                num1 += inData.Tables[num2].Rows.Count;
            }
            return num1;
        }
        /// <summary>
        /// 判断字串是否转为日期
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static bool IsDateTime(string inStr)
        {
            try
            {
                Convert.ToDateTime(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断字串能否转为数值
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static bool IsNumber(string inStr)
        {
            try
            {
                Convert.ToDecimal(inStr);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 保存字串到文本文件
        /// </summary>
        /// <param name="inFileName"></param>
        /// <param name="inText"></param>
        /// <returns></returns>
        public static string SaveTextFile(string inFileName, string inText)
        {
            try
            {
                StreamWriter writer1 = new StreamWriter(inFileName, true, Encoding.GetEncoding("GB2312"));
                writer1.WriteLine(inText);
                writer1.Close();
                return null;
            }
            catch (Exception exception1)
            {
                return exception1.Message;
            }
        }

        /// <summary>
        /// 替换sql中的单引号
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string SQLString(string inStr)
        {
            return inStr.Replace("'", "''");
        }
        /// <summary>
        /// 字串转换为日期型
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static DateTime StrToDate(string inStr)
        {
            if (inStr == null)
            {
                return DateTime.Parse("2000-01-01");
            }
            try
            {
                return Convert.ToDateTime(inStr);
            }
            catch
            {
                return DateTime.Parse("2000-01-01");
            }
        }
        /// <summary>
        /// 字串转换为decimal型
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static decimal StrToDecimal(string inStr)
        {
            if (inStr == null)
            {
                return new decimal(0);
            }
            if (inStr.CompareTo("") == 0)
            {
                return new decimal(0);
            }
            try
            {
                return Convert.ToDecimal(inStr);
            }
            catch
            {
                return new decimal(0);
            }
        }
        /// <summary>
        /// 字串转换为double型
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static double StrToDouble(string inStr)
        {
            if (inStr == null)
            {
                return 0;
            }
            if (inStr.CompareTo("") == 0)
            {
                return 0;
            }
            try
            {
                return Convert.ToDouble(inStr);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 字串转换为指定精度double型
        /// </summary>
        /// <param name="inStr"></param>
        /// <param name="inDefault"></param>
        /// <returns></returns>
        public static double StrToDouble(string inStr, double inDefault)
        {
            if (inStr == null)
            {
                return inDefault;
            }
            if (inStr.CompareTo("") == 0)
            {
                return inDefault;
            }
            try
            {
                double num1 = Convert.ToDouble(inStr);
                if (num1 > 0)
                {
                    return num1;
                }
                return inDefault;
            }
            catch
            {
                return inDefault;
            }
        }
        /// <summary>
        /// 字串转换为float型
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static float StrToFloat(string inStr)
        {
            if (inStr == null)
            {
                return 0f;
            }
            if (inStr.CompareTo("") == 0)
            {
                return 0f;
            }
            try
            {
                return (float) Convert.ToDouble(inStr);
            }
            catch
            {
                return 0f;
            }
        }
        /// <summary>
        /// 字串转换为int型
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static int StrToInt(string inStr)
        {
            if (inStr == null)
            {
                return 0;
            }
            if (inStr.CompareTo("") == 0)
            {
                return 0;
            }
            try
            {
                return Convert.ToInt32(inStr);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 字串转换为long型
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static long StrToLong(string inStr)
        {
            if (inStr == null)
            {
                return (long) 0;
            }
            if (inStr.CompareTo("") == 0)
            {
                return (long) 0;
            }
            try
            {
                return Convert.ToInt64(inStr);
            }
            catch
            {
                return (long) 0;
            }
        }
        /// <summary>
        /// 字串转换为OraDate
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string StrToOraDate(string inStr)
        {
            string text1 = "to_date('2000-01-01 00:00:00', 'yyyy-mm-dd HH24:mi:ss')";
            string text2 = inStr;
            if (inStr == null)
            {
                return text1;
            }
            if (inStr.CompareTo("") == 0)
            {
                return text1;
            }
            try
            {
                text2 = Convert.ToDateTime(inStr).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                text2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return ("to_date('" + text2 + "', 'yyyy-mm-dd HH24:mi:ss')");
        }

        public static string StrToReadyDate(string inStr)
        {
            string text1 = "null";
            string text2 = inStr;
            if (inStr == null)
            {
                return text1;
            }
            if (inStr.CompareTo("") == 0)
            {
                return text1;
            }
            try
            {
                DateTime time1 = Convert.ToDateTime(inStr);
                DateTime time2 = Convert.ToDateTime("2000-01-01 00:00:00");
                TimeSpan span1 = time1.Subtract(time2);
                if (span1.Days > 0)
                {
                    text2 = time1.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return text1;
                }
            }
            catch
            {
                text2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return ("to_date('" + text2 + "', 'yyyy-mm-dd HH24:mi:ss')");
        }

        public static string StrToSqlDate(string inStr)
        {
            string text1 = "convert( datetime, '2000-01-01 00:00:00')";
            string text2 = inStr;
            if (inStr == null)
            {
                return text1;
            }
            if (inStr.CompareTo("") == 0)
            {
                return "null";
            }
            try
            {
                text2 = Convert.ToDateTime(inStr).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                text2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return ("convert( datetime, '" + text2 + "')");
        }

        public static string ToDate(string inStr)
        {
            if (inStr == null)
            {
                return "null";
            }
            if (inStr.CompareTo("") == 0)
            {
                return "null";
            }
            return ("'" + inStr + "'");
        }

        public static bool WriteTxt(DataTable inDT, string inTxtName)
        {
            if (inDT.Rows.Count > 0)
            {
                StringBuilder builder1 = new StringBuilder();
                for (int num1 = 0; num1 < (inDT.Columns.Count - 1); num1++)
                {
                    builder1.Append(inDT.Columns[num1].ColumnName + ",");
                }
                builder1.Append(inDT.Columns[inDT.Columns.Count - 1].ColumnName);
                builder1.Append("\n");
                for (int num2 = 0; num2 < inDT.Rows.Count; num2++)
                {
                    for (int num3 = 0; num3 < (inDT.Columns.Count - 1); num3++)
                    {
                        builder1.Append("\"" + inDT.Rows[num2][num3].ToString().Replace('"', '\'') + "\",");
                    }
                    builder1.Append("\"" + inDT.Rows[num2][inDT.Columns.Count - 1].ToString() + "\"");
                    if (num2 < (inDT.Rows.Count - 1))
                    {
                        builder1.Append("\n");
                    }
                }
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(inTxtName)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(inTxtName));
                    }
                    EmedFunc.SaveTextFile(inTxtName, builder1.ToString());
                    return true;
                }
                catch (Exception exception1)
                {
                    EmedFunc.SaveTextFile("ErrorLog.txt", exception1.Message);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 本地个性化配置文件路径 
        /// </summary>
        /// <returns></returns>
        public static string GetLocalPersonCfgPath()
        {
  
            string pconfigPath = "";

            try
            {
                pconfigPath = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory;
            }
            catch (Exception e)
            {
                pconfigPath = AppDomain.CurrentDomain.BaseDirectory;
            }

            return pconfigPath;
        }
    }
}

