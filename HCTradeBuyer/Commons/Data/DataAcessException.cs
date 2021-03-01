#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data/DataAcessException.cs 3     06-06-27 11:08 Sunhl $
 * $Author: Sunhl $
 * $Revision: 3 $
 * $Date: 06-06-27 11:08 $
 * $History: DataAcessException.cs $
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-27   Time: 11:08
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
#endregion

namespace Emedchina.Commons.Data
{
    /// <summary>
    /// 所有的dao框架产生的应用异常都将被包装为此类。
    /// </summary>
    /// <author>Sunhl</author>
    /// <version>$Id: EmedDAOException.cs,v 1.2 2006/02/21 08:57:07 sunhl Exp $</version>
    [Serializable]
    public class DataAcessException : System.Runtime.Remoting.RemotingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        public DataAcessException()
            : base("数据访问框架出现异常.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DataAcessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        /// <param name="info">保存序列化对象数据的对象。</param>
        /// <param name="context">有关异常的源或目标的上下文信息。</param>
        /// <exception cref="T:System.ArgumentNullException">info 参数为 null。 </exception>
        public DataAcessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="InnerException">The inner exception.</param>
        public DataAcessException(string message, Exception InnerException)
            : base(message, InnerException)
        {
        }


    }
}
