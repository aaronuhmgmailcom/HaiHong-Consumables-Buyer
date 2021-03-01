#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistantSaler.root/TradeAssistantSaler/Model/Exceptions/LoginException.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">�����(sunhl)</a>
 * $Revision: 2 $
 * $History: LoginException.cs $
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:41
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Model/Exceptions
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
#endregion

namespace Emedchina.TradeAssistant.Model.Exceptions
{
    /// <summary>
    /// �û���¼�쳣.
    /// ����Զ�̴���.
    /// </summary>
    [Serializable]
    public class LoginException : RemotingException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        public LoginException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public LoginException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        /// <param name="info">�������л��������ݵĶ���</param>
        /// <param name="context">�й��쳣��Դ��Ŀ�����������Ϣ��</param>
        /// <exception cref="T:System.ArgumentNullException">info ����Ϊ null�� </exception>
        public LoginException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="InnerException">The inner exception.</param>
        public LoginException(string message, Exception InnerException)
            : base(message, InnerException)
        {
        }

    }
}
