using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Common
{
    public class CommonFunction : OracleDAOBase
    {
        /// <summary>
        /// È¡µÃlike×Ó´®
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetLike(string str)
        {
            return string.Format("%{0}%", str);
        }
    }    
}
