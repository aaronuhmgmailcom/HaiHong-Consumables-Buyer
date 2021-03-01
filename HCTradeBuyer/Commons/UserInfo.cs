//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	UserInfo.cs      
//	�� �� ��:	������
//	��������:	2006-6-22
//	��������:	�û���Ϣ
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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

        //����½ƽ̨id
        private string lastLoginPlat;
        public string LastLoginPlat
        {
            get { return lastLoginPlat; }
            set { lastLoginPlat = value; }
        }

        //��ǰƽ̨����
        private string platClass;
        public string PlatClass
        {
            get { return platClass; }
            set { platClass = value; }
        }
    }
}
