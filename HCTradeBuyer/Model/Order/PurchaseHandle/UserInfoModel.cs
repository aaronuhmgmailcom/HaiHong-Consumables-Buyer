#region Header
/*****************************************************************************
 * 刘海超 $
 * $Date: 07-10-12 17:21 $ 
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.PurchaseHandle
{
    [Serializable]
    public class UserInfoModel
    {
        //用户ID
        private string id;
        //用户姓名
        private string name;
        private int highID;
        private string roleId;
        private string regionId;
        private string createUser;
        private string createRegion;
        private string createOrg;
        private string lastUpdateUser;
        private string lastUpdateRegion;
        private string lastUpdateOrg;
        private DateTime createDate;
        private DateTime lastUpdateDate;
        private string orgId;
        private string orgAddr;
        private string orgName;

        public string OrgName
        {
            get { return orgName; }
            set { orgName = value; }
        }

        public int HighID
        {
            get { return highID; }
            set { highID = value; }
        }

        public string OrgAddr
        {
            get { return orgAddr; }
            set { orgAddr = value; }
        }

        public DateTime LastUpdateDate
        {
            get { return lastUpdateDate; }
            set { lastUpdateDate = value; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        public string LastUpdateOrg
        {
            get { return lastUpdateOrg; }
            set { lastUpdateOrg = value; }
        }

        public string LastUpdateRegion
        {
            get { return lastUpdateRegion; }
            set { lastUpdateRegion = value; }
        }

        public string LastUpdateUser
        {
            get { return lastUpdateUser; }
            set { lastUpdateUser = value; }
        }

        public string CreateOrg
        {
            get { return createOrg; }
            set { createOrg = value; }
        }

        public string CreateRegion
        {
            get { return createRegion; }
            set { createRegion = value; }
        }


        public string CreateUser
        {
            get { return createUser; }
            set { createUser = value; }
        }

        public string RegionId
        {
            get { return regionId; }
            set { regionId = value; }
        }


        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        public string OrgId
        {
            get { return orgId; }
            set { orgId = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }

    [Serializable]
    public struct UserInfoStruts
    {

        //用户ID
        public string id;
        //用户姓名
        public string name;
        public string orgId;
        public string roleId;
        public string regionId;
        public string createUser;
        public string createRegion;
        public string createOrg;
        public string lastUpdateUser;
        public DateTime lastUpdateDate;
        public string lastUpdateRegion;
        public string lastUpdateOrg;
        public DateTime createDate;
        public string orgAddr;
        public string orgName;
        public int highID;
    }

}
