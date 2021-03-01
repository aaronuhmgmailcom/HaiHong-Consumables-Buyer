#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/StringUtils.cs 3     06-07-14 9:58 Liangxy $
 * $Author: Liangxy $Revision: 2.0 $
 * $Date: 06-07-14 9:58 $
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.Commons
{
    /// <summary>
    /// �򵥵�string Ӧ����,��Ҫ���ڼ���չλ��.
    /// </summary>
    public class StringUtils
    {
        #region CountPlaceholders

        /// <summary>
        /// �����ж�һ���ַ�����ռλ���ĸ���
        /// </summary>
        /// <param name="str"></param>
        /// <param name="placeholder"></param>
        /// <param name="delim"></param>
        /// <returns></returns>
        public static int CountPlaceholders(string str, char placeholder, char delim)
        {
            return CountPlaceholders(str, placeholder, delim.ToString());
        }

        /// <summary>
        /// �����ж�һ���ַ�����ռλ���ĸ���
        /// </summary>
        /// <param name="str"></param>
        /// <param name="placeholder"></param>
        /// <param name="delimiters">
        /// һ���ַ������У�0-1��2-3��4-5����������ͬ�ķָ���֮���placeholder�������㡣
        /// ����һ���ַ���Ϊ"The big ? 'bad wolf?'",placeholderΪ?,��delimitersΪ',��'bad wolf?'�еģ�����������
        /// ����ָ������ǳɶԳ��֣����һ������delimiter������е�placeholderҲ����������
        /// </param>
        /// <returns></returns>
        public static int CountPlaceholders(string str, char placeholder, string delimiters)
        {
            int count = 0;
            bool insideLiteral = false;
            int activeLiteral = -1;
            for (int i = 0; str != null && i < str.Length; i++)
            {
                if (str[i] == placeholder)
                {
                    if (!insideLiteral)
                        count++;
                }
                else
                {
                    if (delimiters.IndexOf(str[i]) > -1)
                    {
                        if (!insideLiteral)
                        {
                            insideLiteral = true;
                            activeLiteral = delimiters.IndexOf(str[i]);
                        }
                        else
                        {
                            if (activeLiteral == delimiters.IndexOf(str[i]))
                            {
                                insideLiteral = false;
                                activeLiteral = -1;
                            }
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// �����ж�һ���ַ����Ƿ�ΪNumber����
        /// </summary>
        /// <param name="inStr">���ж��ַ���</param>
        /// <returns></returns>
        public static bool IsNumber(string inStr)
        {
            bool flag1;
            try
            {
                Convert.ToDecimal(inStr);
                flag1 = true;
            }
            catch
            {
                flag1 = false;
            }
            return flag1;
        }

        /// <summary>
        /// �����ж�һ���ַ����Ƿ�ΪInt����
        /// </summary>
        /// <param name="inStr">���ж��ַ���</param>
        /// <returns></returns>
        public static bool IsInt(string inStr)
        {
            bool flag1;
            try
            {
                Convert.ToInt16(inStr);
                flag1 = true;
            }
            catch
            {
                flag1 = false;
            }
            return flag1;
        }

        /// <summary>
        /// �ַ���ת��Ϊ��������
        /// </summary>
        /// <param name="inStr">Ŀ���ַ���</param>
        /// <returns></returns>
        public static int StrToInt(string inStr)
        {
            int num2;
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
                int num1 = Convert.ToInt32(inStr);
                num2 = num1;
            }
            catch
            {
                num2 = 0;
            }
            return num2;
        }

        public static String replace(String source, String from, String to)
        {

            if ((source == null) || source.Equals("") || (from == null) || (to == null) || from.Equals("") || from.Equals(to))
            {
                return source;
            }

            StringBuilder sb = new StringBuilder(source.Length);
            String s = source;
            int index = s.IndexOf(from);
            int fromLen = from.Length;

            while (index != -1)
            {
                sb.Append(s.Substring(0, index));
                sb.Append(to);
                s = s.Substring(index + fromLen);
                index = s.IndexOf(from);
            }

            return sb.Append(s).ToString();
        }


        /// <summary>
        /// ��str�е���"'"�滻��"''" ������˵�������ɳ����쳣
        /// </summary>
        /// <param name="inStr">Ŀ���ַ���</param>
        /// <returns></returns>
        public static String repalceSepStr(String str)
        {

            str = str.Trim();
            if (str == null || str.Equals(""))
                return "";
            else
            {
                str = replace(str, "[", "[[]"); //�˾�һ��Ҫ����ǰ
                str = replace(str, "_", "[_]");
                str = replace(str, "%", "[%]");
                return replace(str, "'", "��");
            }

        }
        #endregion

        //ȫ��ת���
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }



    }
}
