#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/Model/User/UserInfo.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $History: UserInfo.cs $
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
    public class UserInfo
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:User"/> class.
        /// </summary>
        public UserInfo()
        {
        }

        #region Fields
        private string _id;
        private string _code;
        private string _name;
        private string _password;
        private string _role_id;
        private string _org_id;
        private string _tel;
        private string _mobile;
        private string _email;
        private string _describe;
        private string _enable_flag;
        private string _admin_flag;
        private string _region_id;
        private string _create_user;
        private DateTime? _create_date;
        private string _create_region;
        private string _create_org;
        private string _last_update_user;
        private DateTime? _last_update_date;
        private string _last_update_region;
        private string _last_update_org;
        private string _headship;
        private string _area_list;
        private DateTime? _login_date;
        #endregion

        #region Properties
        

public virtual string Area_List
        {
            get
            {
                return _area_list;
            }
            set
            {
                _area_list = value;
            }
        }

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

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public virtual string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public virtual string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
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

        public virtual string Org_id
        {
            get
            {
                return _org_id;
            }
            set
            {
                _org_id = value;
            }
        }

        public virtual string Tel
        {
            get
            {
                return _tel;
            }
            set
            {
                _tel = value;
            }
        }

        public virtual string Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
            }
        }

        public virtual string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public virtual string Describe
        {
            get
            {
                return _describe;
            }
            set
            {
                _describe = value;
            }
        }

        public virtual string Enable_flag
        {
            get
            {
                return _enable_flag;
            }
            set
            {
                _enable_flag = value;
            }
        }

        public virtual string Admin_flag
        {
            get
            {
                return _admin_flag;
            }
            set
            {
                _admin_flag = value;
            }
        }

        public virtual string Region_id
        {
            get
            {
                return _region_id;
            }
            set
            {
                _region_id = value;
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

        public virtual string Create_region
        {
            get
            {
                return _create_region;
            }
            set
            {
                _create_region = value;
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

        public virtual string Last_update_region
        {
            get
            {
                return _last_update_region;
            }
            set
            {
                _last_update_region = value;
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

        public virtual string Headship
        {
            get
            {
                return _headship;
            }
            set
            {
                _headship = value;
            }
        }

        public virtual DateTime? Login_date
        {
            get { return _login_date; }
            set { _login_date = value; }
        }

        #endregion

    }

}
