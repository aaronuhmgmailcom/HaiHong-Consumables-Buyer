//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	ComUtil.cs   
//	创 建 人:	梁晓奕
//	创建日期:	2006-6-13
//	功能描述:	共通方法集合
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Emedchina.Commons
{
    public class ComUtil
    {
        // 日期的缺省格式,在ToString和DateFormatInfo中都使用了这个字符串
        private static readonly string DateFormat = "yyyy-MM-dd";
        private static readonly string DateTimeFormat = "yyyy-MM-dd hh:mm";

        public static string formatDate(string dateTime)
        {
            if (dateTime.Trim().Equals(""))
                return "";
            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.ShortDatePattern = DateFormat;
            DateTime date = DateTime.Parse(dateTime, format);
            return date.ToString(DateFormat);
        }

        public static string formatDateTime(string dateTime)
        {
            if (dateTime.Trim().Equals(""))
                return "";
            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.ShortDatePattern = DateTimeFormat;
            DateTime date = DateTime.Parse(dateTime, format);
            return date.ToString(DateTimeFormat);
        }

        public static DateTime ParseDate(string dateTime)
        {

            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.ShortDatePattern = DateFormat;
            DateTime date = DateTime.Parse(dateTime, format);
            return date;
        }
        public static string addMonth(string dateTime, int addmonth)
        {

            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.ShortDatePattern = DateFormat;
            DateTime date = DateTime.Parse(dateTime, format);
            return date.AddMonths(addmonth).ToString(DateFormat);

        }
        public static string addDay(string dateTime, int addDays)
        {
            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.ShortDatePattern = DateFormat;
            DateTime date = DateTime.Parse(dateTime, format);
            return date.AddDays(addDays).ToString(DateFormat);
        }
        public static string getSysDate()
        {
            return DateTime.Now.ToString(DateFormat);
        }

        public static string getMonthAndDay(string dateTime)
        {
            string day = dateTime.Substring(8, 2);

            return day;

        }
        public static List<string> getIntersection(List<string> lista, List<string> listb)
        {
            List<string> listc = new List<string>();
            foreach (string a in lista)
            {
                foreach (string b in listb)
                {
                    if (a.Equals(b))
                    {
                        listc.Add(a.ToString());
                        break;
                    }
                }
            }
            return listc;
        }

        #region 字符串字段
        /// <summary>
        /// 获取数据行中的指定字段的值，按照字符串处理
        /// </summary>
        /// <param name="row">DataRow，行数据</param>
        /// <param name="sFieldName">字段名称</param>
        /// <param name="sDefaultValue">如果返回值=DBNull.Value，则返回的默认字符串值</param>
        /// <returns>字符串</returns>
        public static string getStringValue(DataRow row, string sFieldName, string sDefaultValue)
        {
            if (!row.Table.Columns.Contains(sFieldName))
                return sDefaultValue;

            string sValue = (row[sFieldName] != DBNull.Value) ? row[sFieldName].ToString() : sDefaultValue;
            return sValue.Trim();
        }
        #endregion

        #region 对话框
        /// <summary>
        /// 对话框
        /// </summary>
        /// <param name="message">对话框内容</param>
        public static void MsgBox(string message)
        {
            MessageBox.Show(message, "交易助手", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion

        /// <summary>
        /// 取得ｌｉｋｅ子串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetLike(string str)
        {
            return string.Format("%{0}%", str);
        }
    }
}
