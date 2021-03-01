

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
    public class UserArea
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionRange"/> class.
        /// </summary>
        public UserArea()
        {
        }

        #region Fields
        private string id;
        private string userId;
        private string areaId;
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		public string AreaId
		{
			get { return areaId; }
			set { areaId = value; }
		}

        #endregion



    }
}
