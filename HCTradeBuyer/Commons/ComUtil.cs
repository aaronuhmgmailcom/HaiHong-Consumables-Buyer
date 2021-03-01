//======================================================================================
//	Copyright (c)  Emedchina
//
//	�� �� ��:	ComUtil.cs   
//	�� �� ��:	������
//	��������:	2006-6-13
//	��������:	��ͨ��������
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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
        // ���ڵ�ȱʡ��ʽ,��ToString��DateFormatInfo�ж�ʹ��������ַ���
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

        #region �ַ����ֶ�
        /// <summary>
        /// ��ȡ�������е�ָ���ֶε�ֵ�������ַ�������
        /// </summary>
        /// <param name="row">DataRow��������</param>
        /// <param name="sFieldName">�ֶ�����</param>
        /// <param name="sDefaultValue">�������ֵ=DBNull.Value���򷵻ص�Ĭ���ַ���ֵ</param>
        /// <returns>�ַ���</returns>
        public static string getStringValue(DataRow row, string sFieldName, string sDefaultValue)
        {
            if (!row.Table.Columns.Contains(sFieldName))
                return sDefaultValue;

            string sValue = (row[sFieldName] != DBNull.Value) ? row[sFieldName].ToString() : sDefaultValue;
            return sValue.Trim();
        }
        #endregion

        #region �Ի���
        /// <summary>
        /// �Ի���
        /// </summary>
        /// <param name="message">�Ի�������</param>
        public static void MsgBox(string message)
        {
            MessageBox.Show(message, "��������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion

        /// <summary>
        /// ȡ�ã�����Ӵ�
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetLike(string str)
        {
            return string.Format("%{0}%", str);
        }
    }
}
