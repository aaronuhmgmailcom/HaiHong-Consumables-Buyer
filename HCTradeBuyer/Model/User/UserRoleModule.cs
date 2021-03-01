#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/Model/User/UserRoleModule.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $History: UserRoleModule.cs $
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:41
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/User
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
#endregion

namespace Emedchina.TradeAssistant.Model.User
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserRoleModule
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRoleModule"/> class.
        /// </summary>
        public UserRoleModule()
        {
        }


        #region Fields
        private string _id;
        private string _role_id;
        private string _module_id;
        #endregion

        #region Properties
        public virtual string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public virtual string Role_id
        {
            get
            {
                return _role_id;
            }
            set
            {
                _role_id = value;
            }
        }

        public virtual string Module_id
        {
            get
            {
                return _module_id;
            }
            set
            {
                _module_id = value;
            }
        }

        #endregion
		
    }
}
