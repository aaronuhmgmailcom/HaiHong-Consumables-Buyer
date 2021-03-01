using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;

namespace Emedchina.Commons
{
    public class SecretUtil
    {
        public SecretUtil()
        {
        }
        public static string DeSecret(string inStr)
        {
            string text1 = "";
            string text2 = "";
            char[] chArray1 = inStr.ToCharArray();
            int num1 = chArray1.Length;
            for (int num2 = 0; num2 < num1; num2++)
            {
                text2 = chArray1[num2].ToString();
                num2++;
                text2 = chArray1[num2].ToString() + text2;
                text1 = text1 + ((char)((ushort)((int.Parse(text2, NumberStyles.HexNumber) - 7) - (((num1 - num2) + 1) / 2)))).ToString();
            }
            return text1;
        }

        public static string GetSecondPassword()
        {
            string text1 = "1UPCV2ASDHJK9qweyu34rt56zxn7FG8pasdfLZXgBNhkmQWERcvbTYM";
            string text2 = "";
            Random random1 = new Random((int)DateTime.Now.Ticks);
            for (int num2 = 0; num2 < 4; num2++)
            {
                int num1 = random1.Next(0x37);
                text2 = text2 + text1.Substring(num1, 1);
            }
            return text2;
        }

        public static string Secret(string inStr)
        {
            string text1 = "";
            string text2 = "";
            char[] chArray1 = inStr.ToCharArray();
            int num1 = chArray1.Length;
            for (int num2 = 0; num2 < num1; num2++)
            {
                text2 = (((chArray1[num2] + '\a') + num1) - num2).ToString("X2");
                text1 = text1 + text2.Substring(1, 1) + text2.Substring(0, 1);
            }
            return text1;
        }


        /// <summary>
        /// ×Ö·û´®MD5¼ÓÃÜ
        /// </summary>
        public static string MD5Encoding(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
    }
}
