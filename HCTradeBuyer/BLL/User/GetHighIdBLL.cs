using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.DAL.Common;

namespace Emedchina.TradeAssistant.BLL.User
{
    public class GetHighIdBLL
    {
        public GetHighIdBLL()
        {
        }
        /// <summary>
        /// 取得客户端高位id
        /// </summary>
        /// <returns></returns>
        public string GetHighID()
        {
            return IdUtil.GetNewId();
        }

    }
}
