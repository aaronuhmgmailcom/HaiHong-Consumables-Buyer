

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.Commons
{
    /// <summary>
    /// 生成ID辅助类
    /// </summary>
    public class IdUtil
    {
        public static string GetGlobalCode()
        {
            StringBuilder builder1 = new StringBuilder("CK" + DateTime.Now.Year.ToString());
            builder1.Append(DateTime.Now.Month.ToString("##00"));
            builder1.Append(DateTime.Now.Day.ToString("##00"));
            builder1.Append(IdUtil.GetPurchaseCode());
            return builder1.ToString();
        }

        public static string GetGlobalId()
        {
            //string text1 = EmedMD5.GetMD5String(Guid.NewGuid().ToString());
            //string text2 = "00000000000000000000000000000000000000000000000";
            //text2 = text2 + text1.Substring(0, 8).GetHashCode().ToString("X");
            //text2 = text2 + text1.Substring(8, 8).GetHashCode().ToString("X");
            //text2 = text2 + text1.Substring(0x10, 8).GetHashCode().ToString("X");
            //return text2.Substring(text2.Length - 0x18);

            string temp = Guid.NewGuid().ToString().GetHashCode().ToString("X") + Guid.NewGuid().ToString().GetHashCode().ToString("X") + Guid.NewGuid().ToString().GetHashCode().ToString("X") + "zzzzzzzzzzzzzzzz";
            return temp.Substring(0, 24).ToUpper();
        }

        private static string GetPurchaseCode()
        {
            string text1 = "select iif( max(mid(purchase_code,10,8)) is null, '00000001', max(mid(purchase_code,10,8)) + 1 ) from gpo_purchase";
            string text2 = EmedDB.getScalar(text1);
            if ((text2 != null) && (text2 != ""))
            {
                return int.Parse(text2).ToString("00000000");
            }
            return "00000001";
        }


        /// <summary>
        /// 产生客户端低位id
        /// </summary>
        /// <returns></returns>
        //public static Int64 GetClientId(int idHigh)
        //{
        //    string temp = Guid.NewGuid().ToString().GetHashCode().ToString("X") + Guid.NewGuid().ToString().GetHashCode().ToString("X");
        //    Int64 id = Convert.ToInt64(idHigh * Math.Pow(10, 13)) + Convert.ToInt64(Convert.ToUInt64(temp, 16).ToString().Substring(0, 13));
        //    return id;
        //}
    }
}
