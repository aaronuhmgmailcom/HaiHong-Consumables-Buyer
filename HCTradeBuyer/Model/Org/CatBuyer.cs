#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /ZjTradeAssistantSaler/Commons/Model/Org/CatBuyer.cs 1     06-08-23 17:16 Panyj $ 
 * $Author: Panyj $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 1 $
 * $Date: 06-08-23 17:16 $
 * $History: CatBuyer.cs $
 * 
 * *****************  Version 1  *****************
 * User: Panyj        Date: 06-08-23   Time: 17:16
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
    public class CatBuyer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CatBuyer"/> class.
        /// </summary>
        public CatBuyer()
        {
        }

        #region Fields
        private string _id;
        private string _plat_id;
        private string _org_type;
        private string _org_kind;
        private string _grade_no;
        private string _org_presider;
        private string _tax_code;
        private string _org_account_name;
        private string _org_bank;
        private string _org_account;
        private string _org_address;
        private string _post_code;
        private string _org_phone;
        private string _org_faxe;
        private string _org_url;
        private string _province_id;
        private string _city_id;
        private string _org_desc;
        private string _link_person;
        private string _link_phone;
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
        private string _link_email;
        private string _create_user;
        private string _enable_flag;
        private string _county_id;
        private string _sync_state;
        private string _buyer_kind;
        private string _subject_flag;
        private string _medicare_flag;
        private decimal _bed_number;
        private string _proprietorship;
        private decimal _outpatient_per_day;
        private decimal _sum_per_person;
        private decimal _salesum_per_year;
        private string _feature_clinic;
        private decimal _doctor_num;
        private decimal _clinic_medical_money;
        private decimal _inpatient_num;
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

        public virtual string Plat_id
        {
            get
            {
                return _plat_id;
            }
            set
            {
                _plat_id = value;
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

        public virtual string Org_kind
        {
            get
            {
                return _org_kind;
            }
            set
            {
                _org_kind = value;
            }
        }

        public virtual string Grade_no
        {
            get
            {
                return _grade_no;
            }
            set
            {
                _grade_no = value;
            }
        }

        public virtual string Org_presider
        {
            get
            {
                return _org_presider;
            }
            set
            {
                _org_presider = value;
            }
        }

        public virtual string Tax_code
        {
            get
            {
                return _tax_code;
            }
            set
            {
                _tax_code = value;
            }
        }

        public virtual string Org_account_name
        {
            get
            {
                return _org_account_name;
            }
            set
            {
                _org_account_name = value;
            }
        }

        public virtual string Org_bank
        {
            get
            {
                return _org_bank;
            }
            set
            {
                _org_bank = value;
            }
        }

        public virtual string Org_account
        {
            get
            {
                return _org_account;
            }
            set
            {
                _org_account = value;
            }
        }

        public virtual string Org_address
        {
            get
            {
                return _org_address;
            }
            set
            {
                _org_address = value;
            }
        }

        public virtual string Post_code
        {
            get
            {
                return _post_code;
            }
            set
            {
                _post_code = value;
            }
        }

        public virtual string Org_phone
        {
            get
            {
                return _org_phone;
            }
            set
            {
                _org_phone = value;
            }
        }

        public virtual string Org_faxe
        {
            get
            {
                return _org_faxe;
            }
            set
            {
                _org_faxe = value;
            }
        }

        public virtual string Org_url
        {
            get
            {
                return _org_url;
            }
            set
            {
                _org_url = value;
            }
        }

        public virtual string Province_id
        {
            get
            {
                return _province_id;
            }
            set
            {
                _province_id = value;
            }
        }

        public virtual string City_id
        {
            get
            {
                return _city_id;
            }
            set
            {
                _city_id = value;
            }
        }

        public virtual string Org_desc
        {
            get
            {
                return _org_desc;
            }
            set
            {
                _org_desc = value;
            }
        }

        public virtual string Link_person
        {
            get
            {
                return _link_person;
            }
            set
            {
                _link_person = value;
            }
        }

        public virtual string Link_phone
        {
            get
            {
                return _link_phone;
            }
            set
            {
                _link_phone = value;
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

        public virtual string Link_email
        {
            get
            {
                return _link_email;
            }
            set
            {
                _link_email = value;
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

        public virtual string County_id
        {
            get
            {
                return _county_id;
            }
            set
            {
                _county_id = value;
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

        public virtual string Buyer_kind
        {
            get
            {
                return _buyer_kind;
            }
            set
            {
                _buyer_kind = value;
            }
        }

        public virtual string Subject_flag
        {
            get
            {
                return _subject_flag;
            }
            set
            {
                _subject_flag = value;
            }
        }

        public virtual string Medicare_flag
        {
            get
            {
                return _medicare_flag;
            }
            set
            {
                _medicare_flag = value;
            }
        }

        public virtual decimal Bed_number
        {
            get
            {
                return _bed_number;
            }
            set
            {
                _bed_number = value;
            }
        }

        public virtual string Proprietorship
        {
            get
            {
                return _proprietorship;
            }
            set
            {
                _proprietorship = value;
            }
        }

        public virtual decimal Outpatient_per_day
        {
            get
            {
                return _outpatient_per_day;
            }
            set
            {
                _outpatient_per_day = value;
            }
        }

        public virtual decimal Sum_per_person
        {
            get
            {
                return _sum_per_person;
            }
            set
            {
                _sum_per_person = value;
            }
        }

        public virtual decimal Salesum_per_year
        {
            get
            {
                return _salesum_per_year;
            }
            set
            {
                _salesum_per_year = value;
            }
        }

        public virtual string Feature_clinic
        {
            get
            {
                return _feature_clinic;
            }
            set
            {
                _feature_clinic = value;
            }
        }

        public virtual decimal Doctor_num
        {
            get
            {
                return _doctor_num;
            }
            set
            {
                _doctor_num = value;
            }
        }

        public virtual decimal Clinic_medical_money
        {
            get
            {
                return _clinic_medical_money;
            }
            set
            {
                _clinic_medical_money = value;
            }
        }

        public virtual decimal Inpatient_num
        {
            get
            {
                return _inpatient_num;
            }
            set
            {
                _inpatient_num = value;
            }
        }

        #endregion
		

    }
}
