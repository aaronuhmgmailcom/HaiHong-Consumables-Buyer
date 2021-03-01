#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /ZjTradeAssistantSaler/Commons/Model/Org/CatOrg.cs 1     06-08-23 17:17 Panyj $ 
 * $Author: Panyj $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 1 $
 * $Date: 06-08-23 17:17 $
 * $History: CatOrg.cs $
 * 
 * *****************  Version 1  *****************
 * User: Panyj        Date: 06-08-23   Time: 17:17
 * Created in $/ZjTradeAssistantSaler/Commons/Model/Org
 * 
 * *****************  Version 2  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:49
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Model/Org
 * 
 * *****************  Version 1  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:07
 * Created in $/TradeAssistantSaler.root/TradeAssistantSaler/Model/Org
 ********************************************************************************/
#endregion

#region using
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Emedchina.TradeAssistant.Model.Org
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CatOrg 
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CatOrg"/> class.
        /// </summary>
        public CatOrg()
        {
        }

        #region Fields
        private string _id;
        private string _member_flag;
        private decimal _user_num;
        private string _enable_flag;
        private string _org_type;
        private string _name;
        private string _code;
        private string _abbr;
        private string _spell_abbr;
        private string _name_wb;
        private string _create_user;
        private DateTime? _create_date;
        private string _create_plat;
        private string _create_org;
        private string _last_update_user;
        private DateTime? _last_update_date;
        private string _last_update_plat;
        private string _last_update_org;
        private DateTime? _synchronized_date;
        private DateTime? _clean_date;
        private string _description;
        private string _inherit_flag;
        private string _member_no;
        private string _default_plat;
        private string _sync_state;
        private string _create_username;
        private string _last_update_username;
        private string _organize_code;
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

        public virtual string Member_flag
        {
            get
            {
                return _member_flag;
            }
            set
            {
                _member_flag = value;
            }
        }

        public virtual decimal User_num
        {
            get
            {
                return _user_num;
            }
            set
            {
                _user_num = value;
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

        public virtual string Org_type
        {
            get
            {
                return _org_type;
            }
            set
            {
                _org_type = value;
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

        public virtual string Abbr
        {
            get
            {
                return _abbr;
            }
            set
            {
                _abbr = value;
            }
        }

        public virtual string Spell_abbr
        {
            get
            {
                return _spell_abbr;
            }
            set
            {
                _spell_abbr = value;
            }
        }

        public virtual string Name_wb
        {
            get
            {
                return _name_wb;
            }
            set
            {
                _name_wb = value;
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

        public virtual DateTime? Synchronized_date
        {
            get
            {
                return _synchronized_date;
            }
            set
            {
                _synchronized_date = value;
            }
        }

        public virtual DateTime? Clean_date
        {
            get
            {
                return _clean_date;
            }
            set
            {
                _clean_date = value;
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

        public virtual string Inherit_flag
        {
            get
            {
                return _inherit_flag;
            }
            set
            {
                _inherit_flag = value;
            }
        }

        public virtual string Member_no
        {
            get
            {
                return _member_no;
            }
            set
            {
                _member_no = value;
            }
        }

        public virtual string Default_plat
        {
            get
            {
                return _default_plat;
            }
            set
            {
                _default_plat = value;
            }
        }

        public virtual string Sync_state
        {
            get
            {
                return _sync_state;
            }
            set
            {
                _sync_state = value;
            }
        }

        public virtual string Create_username
        {
            get
            {
                return _create_username;
            }
            set
            {
                _create_username = value;
            }
        }

        public virtual string Last_update_username
        {
            get
            {
                return _last_update_username;
            }
            set
            {
                _last_update_username = value;
            }
        }

        public virtual string Organize_code
        {
            get
            {
                return _organize_code;
            }
            set
            {
                _organize_code = value;
            }
        }

        #endregion

    }
}
