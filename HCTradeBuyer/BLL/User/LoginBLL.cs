#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/BLL/User/LoginBLL.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">�����(sunhl)</a>
 * $Revision: 10 $
 * $Date: 06-09-27 17:02 $
 * $History: LoginBLL.cs $
 * 
 * *****************  Version 10  *****************
 * User: Liangxy      Date: 06-09-27   Time: 17:02
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/BLL/User
 * 
 * *****************  Version 9  *****************
 * User: Panyj        Date: 06-09-11   Time: 15:57
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/BLL/User
 * 
 * *****************  Version 8  *****************
 * User: Panyj        Date: 06-09-11   Time: 14:16
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 * 
 * *****************  Version 7  *****************
 * User: Sunhl        Date: 06-08-25   Time: 11:19
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 * ����쳣����
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-29   Time: 14:50
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 * �����Ӧ��CatBuyer��Ϣ������,ֱ��new һ��CatBuyer����LogedInUser
 * 
 * *****************  Version 5  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:56
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:49
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 * 
 * *****************  Version 3  *****************
 * User: Sunhl        Date: 06-06-24   Time: 14:28
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.Org;
using Emedchina.TradeAssistant.Model.Exceptions;
using Emedchina.TradeAssistant.DAL.User;

using IBatisNet.Common.Logging;
using Emedchina.TradeAssistant.Model.User;
using System.Data;
using Emedchina.TradeAssistant.DAL.Common;
#endregion

namespace Emedchina.TradeAssistant.BLL.User
{
    /// <summary>
    /// �����û���¼�߼�
    /// </summary>
    public class LoginBLL
    {
        //ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        string loginUserCode = string.Empty;

        UserDAO userDao;
        UserOrgDAO userOrgDao;
        UserRoleDAO userRoleDao;
        UserRegionDAO userRegionDao;
        UserRegionRangeDAO userRegionRangeDao;

        UserOrgRoleDAO userOrgRoleDAO;
        UserAreaDAO userAreaDAO;
        UserSystemDAO userSystemDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginBLL"/> class.
        /// </summary>
        private LoginBLL()
        {
            userDao = UserDAO.GetInstance();
            userRoleDao = UserRoleDAO.GetInstance();
            userOrgDao = UserOrgDAO.GetInstance();
            userRegionDao = UserRegionDAO.GetInstance();
            userRegionRangeDao = UserRegionRangeDAO.GetInstance();

            userOrgRoleDAO = UserOrgRoleDAO.GetInstance();
            userAreaDAO = UserAreaDAO.GetInstance();
            userSystemDao = UserSystemDAO.GetInstance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoginBLL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private LoginBLL(string connectionName)
        {
            userDao = UserDAO.GetInstance(connectionName);
            userOrgDao = UserOrgDAO.GetInstance(connectionName);
            userRoleDao = UserRoleDAO.GetInstance(connectionName);
            userRegionDao = UserRegionDAO.GetInstance(connectionName);
            userRegionRangeDao = UserRegionRangeDAO.GetInstance(connectionName);

            userOrgRoleDAO = UserOrgRoleDAO.GetInstance(connectionName);
            userSystemDao = UserSystemDAO.GetInstance(connectionName);
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static LoginBLL GetInstance()
        {
            return new LoginBLL();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static LoginBLL GetInstance(string connectionName)
        {
            return new LoginBLL(connectionName);
        }

        /// <summary>
        /// �û���¼,Ĭ�ϲ�����.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public LogedInUser LogIn(string userCode, string password)
        {
            LogedInUser user;
            try
            {
                user = LogIn(userCode, password, false);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }

        /// <summary>
        /// �û���¼.
        /// �û�����������������ķ���,isEncrypt��־�Ƿ��Ѿ�����.
        /// ��ǰ�汾û��ʵ�ּӽ���.isEncrypt���򵥵ĺ���.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="password">The password.</param>
        /// <param name="isEncrypt">if set to <c>true</c> [is encrypt].</param>
        /// <returns></returns>
        public LogedInUser LogIn(string userCode, string password, bool isEncrypt)
        {
            loginUserCode = userCode;
            LogedInUser logedinUser = new LogedInUser();

            UserInfo ui = userDao.GetUserInfoByCode(userCode);
            logedinUser.UserInfo = ui;
            
            //������û������Ҳ����û���˵�������½��������
            string code = GetCode(userCode, isEncrypt);
            CheckUserExist(logedinUser, userCode);

           
            //����û��Ƿ񱻽�ֹ
            CheckUserEnabled(logedinUser);

            //����û�����
            string pwd = GetPassword(password, isEncrypt);
            CheckUserPassword(logedinUser, pwd);

            //����û����������Ƿ����������������ڣ��׳��߼��쳣	
            UserOrg uo = userOrgDao.GetUserOrgById(ui.Id);

            logedinUser.UserOrg = uo;

            CheckUserOrgExist(logedinUser);



            //�򷽻�����Ϣ�����ڻ�ȡ��ַ������Ϣ��
            //CatBuyer buyer = buyerDao.GetCatBuyerByRegBuyerId(uo.Reg_org_id);
            //if (buyer != null)
            //{
            //    logedinUser.BuyerInfo = buyer;
            //}
            //else
            //{
            //    logedinUser.BuyerInfo = new CatBuyer();
            //}

            //�������Ƿ񱻽�ֹ
            //CheckUserOrgEnabled(logedinUser);

            //�����ɫ�����ڣ��׳��߼��쳣
            //UserRole ur = userRoleDao.GetUserRoleById(ui.Role_id);
            //// bool isHospital = userRoleDao.IsHospital(
            //logedinUser.UserRole = ur;
            //CheckUserRoleExist(logedinUser);

            ////����ɫ�Ƿ񱻽�ֹ
            //CheckUserRoleEnabled(logedinUser);

            ////�û�������Ϣ
            //UserRegion ure = userRegionDao.GetUserRegionById(ui.Region_id);
            //logedinUser.UserRegion = ure;

            ////���ô��û�����Ӧ��ע������
            //UserRegionRange urr = userRegionRangeDao.GetUserRegionRangeByRegionId(ui.Region_id);
            //if (urr != null)
            //{
            //    logedinUser.UserRegionRange = urr;
            //    logedinUser.SingleRegionId = urr.Reg_region_id;
            //}

            ////���м��������ȡ�������б� 2007-9-12 CJ
            //logedinUser.UserInfo.Area_List = userAreaDAO.GetUserAreaListString(ui.Id);

            //UserArea ua = userAreaDAO.GetUserAreaByUserId(logedinUser.UserInfo.Id);
            //if (ua != null)
            //{
            //    logedinUser.UserArea = ua;
            //    logedinUser.SingleRegionId = ua.AreaId;
            //}
            return logedinUser;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="isEncrypt">if set to <c>true</c> [is encrypt].</param>
        /// <returns></returns>
        protected virtual string GetPassword(string password, bool isEncrypt)
        {
            return password;
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="isEncrypt">if set to <c>true</c> [is encrypt].</param>
        /// <returns></returns>
        protected virtual string GetCode(string userCode, bool isEncrypt)
        {
            return userCode;
        }

        /// <summary>
        /// Checks whether the user exist.
        /// ���logedinUser�����л�û�а���UserInfo��Ϣ���������UserInfo��Code��userCode��һ�£����׳�LoginException(string.Format("{0}�û�������", userCode))
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        /// <param name="userCode">The user code.</param>
        protected virtual void CheckUserExist(LogedInUser logedinUser, string userCode)
        {
            if (logedinUser.UserInfo == null || logedinUser.UserInfo.Code != userCode)
            {
                throw new LoginException(string.Format("{0}�û������ڡ�", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user enabled.
        /// ���logedinUser�����л�û�а���UserInfo��Ϣ���������UserInfo�Ѿ�����ֹ�����׳�LoginException(string.Format("{0}�û�����ֹ.", userCode))
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserEnabled(LogedInUser logedinUser)
        {
            if (logedinUser.UserInfo == null || "0" == logedinUser.UserInfo.Enable_flag)
            {
                throw new LoginException(string.Format("{0}�û�����ֹ.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user password.
        /// ���logedinUser�����л�û�а���UserInfo��Ϣ���������UserInfo��password��һ�£����׳�LoginException(string.Format("{0}�û��������.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        /// <param name="password">The password.</param>
        protected virtual void CheckUserPassword(LogedInUser logedinUser, string password)
        {
            if (logedinUser.UserInfo == null || password != logedinUser.UserInfo.Password)
            {
                throw new LoginException(string.Format("{0}�û��������.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user org exist.
        /// ���logedinUser�����л�û�а���UserOrg��Ϣ�����׳�LoginException(string.Format("{0}�û�����������.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserOrgExist(LogedInUser logedinUser)
        {
            if (logedinUser.UserOrg == null)
            {
                throw new LoginException(string.Format("{0}�û�����������.", loginUserCode));
            }
        }


        /// <summary>
        /// Checks the user org enabled.
        /// ���logedinUser�����е�UserOrg��Ϣ��Enable_flag==0�����׳�LoginException(string.Format("{0}�û���������ֹ.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserOrgEnabled(LogedInUser logedinUser)
        {
            if (logedinUser.UserOrg.Enable_flag == "0")
            {
                throw new LoginException(string.Format("{0}�û���������ֹ.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user role exist.
        /// ���logedinUser�����л�û�а���UserRole��Ϣ�����׳�LoginException(string.Format("{0}�û�������ɫ������.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserRoleExist(LogedInUser logedinUser)
        {
            if (logedinUser.UserRole == null)
            {
                throw new LoginException(string.Format("{0}�û�������ɫ������.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user role enabled.
        /// ���logedinUser�����а�����UserRole����ֹ�����׳�LoginException(string.Format("{0}�û�������ɫ����ֹ.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserRoleEnabled(LogedInUser logedinUser)
        {
            if (logedinUser.UserRole.Enable_flag == "0")
            {
                throw new LoginException(string.Format("{0}�û�������ɫ����ֹ.", loginUserCode));
            }
        }



        /// <summary>
        /// ȡ�õ�ǰ�û��˵�
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetMenu(string userId, string clientType)
        {
            return userSystemDao.GetMenu(userId, clientType);
        }


    }
}
