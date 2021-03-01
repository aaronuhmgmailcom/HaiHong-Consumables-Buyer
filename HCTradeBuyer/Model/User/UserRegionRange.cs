#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/Model/User/UserRegionRange.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $History: UserRegionRange.cs $
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
    public class UserRegionRange
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionRange"/> class.
        /// </summary>
        public UserRegionRange()
        {
        }

        #region Fields
        private string _id;
        private string _region_id;
        private string _reg_region_id;
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

        public virtual string Reg_region_id
        {
            get
            {
                return _reg_region_id;
            }
            set
            {
                _reg_region_id = value;
            }
        }

        #endregion

    }
}
