//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	UserInfo.cs      
//	创 建 人:	梁晓奕
//	创建日期:	2006-6-22
//	功能描述:	用户信息
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.Commons
{
    [Serializable]
    public class UserInfo
    {
        private string userId;
        private string userName;
        private string orgId;
        private string areaId;
       
        public UserInfo()
        {
            orgId = "TESTBUYER000000000000457";
            areaId = "TESTAREA0000000000000026";
        }
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		public string OrgId
		{
			get { return orgId; }
			set { orgId = value; }
		}

		public string AreaId
		{
			get { return areaId; }
			set { areaId = value; }
		}

        //最后登陆平台id
        private string lastLoginPlat;
        public string LastLoginPlat
        {
            get { return lastLoginPlat; }
            set { lastLoginPlat = value; }
        }

        //当前平台级别
        private string platClass;
        public string PlatClass
        {
            get { return platClass; }
            set { platClass = value; }
        }
    }
}
