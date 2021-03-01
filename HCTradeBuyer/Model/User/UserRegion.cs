#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/Model/User/UserRegion.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $History: UserRegion.cs $
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
    public class UserRegion
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegion"/> class.
        /// </summary>
        public UserRegion()
        {
        }

        #region Fields
        private string _id;
        private string _region_type;
        private string _region_name;
        private string _remark;
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

        public virtual string Region_type
        {
            get
            {
                return _region_type;
            }
            set
            {
                _region_type = value;
            }
        }

        public virtual string Region_name
        {
            get
            {
                return _region_name;
            }
            set
            {
                _region_name = value;
            }
        }

        public virtual string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
            }
        }

        #endregion
    }
}
