#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/Model/User/UserOrg.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 5 $
 * $History: UserOrg.cs $
 * 
 * *****************  Version 5  *****************
 * User: Liangxy      Date: 06-09-27   Time: 17:02
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/Model/User
 * 
 * *****************  Version 4  *****************
 * User: Panyj        Date: 06-09-11   Time: 15:57
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/Model/User
 * 
 * *****************  Version 3  *****************
 * User: Panyj        Date: 06-09-11   Time: 14:16
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/User
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
    public class UserOrg
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrg"/> class.
        /// </summary>
        public UserOrg()
        {
        }

        #region Fields
        private string _id;
        private string _reg_org_id;
        private string _name;

        private string _sort;
        private string _phone;
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
        private bool isHospital;
        private bool isFactory;
        private string _abbr;


        public bool IsFactory
        {
            get { return isFactory; }
            set { isFactory = value; }
        }

        public bool IsHospital
        {
            get { return isHospital; }
            set { isHospital = value; }
        }
        
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

        public virtual string Reg_org_id
        {
            get
            {
                return _reg_org_id;
            }
            set
            {
                _reg_org_id = value;
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

        public virtual string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
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

        public virtual string Abbr
        {
            get { return _abbr; }
            set { _abbr = value; }
        }

        #endregion

    }
}
