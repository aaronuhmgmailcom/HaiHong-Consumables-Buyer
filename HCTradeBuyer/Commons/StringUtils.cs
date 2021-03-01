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
    /// 简单的string 应用类,主要用于计算展位符.
    /// </summary>
    public class StringUtils
    {
        #region CountPlaceholders

        /// <summary>
        /// 用于判断一个字符串中占位符的个数
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
        /// 用于判断一个字符串中占位符的个数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="placeholder"></param>
        /// <param name="delimiters">
        /// 一个字符串序列，0-1，2-3，4-5，……个相同的分隔符之间的placeholder不被计算。
        /// 例如一个字符串为"The big ? 'bad wolf?'",placeholder为?,而delimiters为',则'bad wolf?'中的？不被计数。
        /// 如果分隔符不是成对出现，最后一个单独delimiter后的所有的placeholder也不被计数。
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
        /// 用于判断一个字符串是否为Number类型
        /// </summary>
        /// <param name="inStr">被判断字符串</param>
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
        /// 用于判断一个字符串是否为Int类型
        /// </summary>
        /// <param name="inStr">被判断字符串</param>
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
        /// 字符串转换为整型数据
        /// </summary>
        /// <param name="inStr">目标字符串</param>
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
        /// 将str中单号"'"替换成"''" 处理过滤单引号造成出现异常
        /// </summary>
        /// <param name="inStr">目标字符串</param>
        /// <returns></returns>
        public static String repalceSepStr(String str)
        {

            str = str.Trim();
            if (str == null || str.Equals(""))
                return "";
            else
            {
                str = replace(str, "[", "[[]"); //此句一定要在最前
                str = replace(str, "_", "[_]");
                str = replace(str, "%", "[%]");
                return replace(str, "'", "＇");
            }

        }
        #endregion

        //全角转半角
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
