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
        /// ȡ�ÿͻ��˸�λid
        /// </summary>
        /// <returns></returns>
        public string GetHighID()
        {
            return IdUtil.GetNewId();
        }

    }
}
