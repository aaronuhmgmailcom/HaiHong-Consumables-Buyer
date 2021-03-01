#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/Model/User/UserKey.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $History: UserKey.cs $
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
    public class UserKey
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserKey"/> class.
        /// </summary>
        public UserKey()
        {
        }

        #region Fields
        private string _user_id;
        private string _sn;
        private string _pin;
        private string _create_user;
        private DateTime? _create_date;
        private string _create_plat;
        private string _create_org;
        private string _last_update_user;
        private DateTime? _last_update_date;
        private string _last_update_plat;
        private string _description;
        private string _last_update_org;
        #endregion

        #region Properties
        public virtual string User_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                _user_id = value;
            }
        }

        public virtual string Sn
        {
            get
            {
                return _sn;
            }
            set
            {
                _sn = value;
            }
        }

        public virtual string Pin
        {
            get
            {
                return _pin;
            }
            set
            {
                _pin = value;
            }
        }

        public virtual string Create_user
        {
            get
            {
                return _create_user;
            }
            set
            {
                _create_user = value;
            }
        }

        public virtual DateTime? Create_date
        {
            get
            {
                return _create_date;
            }
            set
            {
                _create_date = value;
            }
        }

        public virtual string Create_plat
        {
            get
            {
                return _create_plat;
            }
            set
            {
                _create_plat = value;
            }
        }

        public virtual string Create_org
        {
            get
            {
                return _create_org;
            }
            set
            {
                _create_org = value;
            }
        }

        public virtual string Last_update_user
        {
            get
            {
                return _last_update_user;
            }
            set
            {
                _last_update_user = value;
            }
        }

        public virtual DateTime? Last_update_date
        {
            get
            {
                return _last_update_date;
            }
            set
            {
                _last_update_date = value;
            }
        }

        public virtual string Last_update_plat
        {
            get
            {
                return _last_update_plat;
            }
            set
            {
                _last_update_plat = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public virtual string Last_update_org
        {
            get
            {
                return _last_update_org;
            }
            set
            {
                _last_update_org = value;
            }
        }

        #endregion
    }
}
