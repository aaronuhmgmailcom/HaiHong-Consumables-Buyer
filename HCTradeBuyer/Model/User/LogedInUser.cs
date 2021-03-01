#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/Model/User/LogedInUser.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">�����(sunhl)</a>
 * $Revision: 8 $
 * $History: LogedInUser.cs $
 * 
 * *****************  Version 8  *****************
 * User: Liangxy      Date: 06-09-27   Time: 17:02
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/Model/User
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:49
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/User
 * 
 * *****************  Version 5  *****************
 * User: Sunhl        Date: 06-06-24   Time: 14:28
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/User
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:42
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/User
 * $Date: 06-09-27 17:02 $
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:41
 * Updated in $/TradeAssistant.root/TradeAssistant/Model/User
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.Org;
#endregion

namespace Emedchina.TradeAssistant.Model.User
{
    /// <summary>
    /// LogedInUser�����¼����û���Ϣ.�ö�����һ�����϶��󣬰������û��Ļ�����Ϣ���û������Ļ�����Ϣ��
    /// �û���ɫ���û��������Ϣ��
    /// </summary>
    /// <remarks>�����û���Ϣ�а����û������룬���ڰ�ȫ���ǿ���ȥ�������ֶΣ�������bll�㴦����</remarks>
    [Serializable]
    public class LogedInUser
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LogedInUser"/> class.
        /// </summary>
        public LogedInUser()
        {
        }

        private UserInfo _userInfo;

        /// <summary>
        /// Gets or sets the user info.
        /// �û�������Ϣ��
        /// </summary>
        /// <value>The user info.</value>
        public UserInfo UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }
        private UserOrg _userOrg;

        /// <summary>
        /// Gets or sets the user org.
        /// �û�������Ϣ
        /// </summary>
        /// <value>The user org.</value>
        public UserOrg UserOrg
        {
            get { return _userOrg; }
            set { _userOrg = value; }
        }
        private UserRegion _userRegion;

        /// <summary>
        /// Gets or sets the user region.
        /// �û�����region��
        /// </summary>
        /// <value>The user region.</value>
        public UserRegion UserRegion
        {
            get { return _userRegion; }
            set { _userRegion = value; }
        }
        private UserRegionRange _userRegionRange;

        /// <summary>
        /// Gets or sets the user region range.
        /// �û�����Χ��
        /// </summary>
        /// <value>The user region range.</value>
        public UserRegionRange UserRegionRange
        {
            get { return _userRegionRange; }
            set { _userRegionRange = value; }
        }
        private UserRole _userRole;

        /// <summary>
        /// Gets or sets the user role.
        /// �û���ɫ��
        /// </summary>
        /// <value>The user role.</value>
        public UserRole UserRole
        {
            get { return _userRole; }
            set { _userRole = value; }
        }
        private string _singleRegionId;
        /// <summary>
        /// �û�����Ӧ��ע������
        /// </summary>
        public string SingleRegionId
        {
            get { return _singleRegionId; }
            set { _singleRegionId = value; }
        }

        private CatBuyer _buyerInfo;

        /// <summary>
        /// Gets or sets the buyer info.
        /// </summary>
        /// <value>The buyer info.</value>
        public CatBuyer BuyerInfo
        {
            get { return _buyerInfo; }
            set { _buyerInfo = value; }
        }
        private UserArea _userArea;

        /// <summary>
        /// Gets or sets the userArea info.
        /// </summary>
        /// <value>The userArea info.</value>
        public UserArea UserArea
        {
            get { return _userArea; }
            set { _userArea = value; }
        }

        /// <summary>
        /// �ͻ��˸�λid
        /// </summary>
        private int _highId;

        public int HighId
        {
            get { return _highId; }
            set { _highId = value; }
        }

    }
}
