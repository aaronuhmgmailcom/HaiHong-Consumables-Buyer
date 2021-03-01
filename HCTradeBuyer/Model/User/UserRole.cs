#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/Model/User/UserRole.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $History: UserRole.cs $
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
    public class UserRole
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRole"/> class.
        /// </summary>
        public UserRole()
        {
        }

        #region Fields
        private string _id;
        private string _name;
        private string _type_name;
        private string _type;
        private string _sort;
        private string _region_id;
        private string _enable_flag;
        private string _create_user;
        private DateTime? _create_date;
        private string _create_region;
        private string _create_org;
        private string _last_update_user;
        private DateTime? _last_update_date;
        private string _last_update_region;
        private string _last_update_org;
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

        public virtual string Type_name
        {
            get
            {
                return _type_name;
            }
            set
            {
                _type_name = value;
            }
        }

        public virtual string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public virtual string Sort
        {
            get
            {
                return _sort;
            }
            set
            {
                _sort = value;
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

        #endregion		
    }
}
