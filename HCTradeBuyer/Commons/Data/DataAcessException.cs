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
    /// ���е�dao��ܲ�����Ӧ���쳣��������װΪ���ࡣ
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
            : base("���ݷ��ʿ�ܳ����쳣.")
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
        /// <param name="info">�������л��������ݵĶ���</param>
        /// <param name="context">�й��쳣��Դ��Ŀ�����������Ϣ��</param>
        /// <exception cref="T:System.ArgumentNullException">info ����Ϊ null�� </exception>
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
