#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/BLL/User/LoginBLL.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
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
 * 添加异常捕获
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-29   Time: 14:50
 * Updated in $/TradeAssistant.root/TradeAssistant/BLL/User
 * 如果相应的CatBuyer信息不存在,直接new 一个CatBuyer赋给LogedInUser
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
    /// 负责用户登录逻辑
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
        /// 用户登录,默认不加密.
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
        /// 用户登录.
        /// 用户名和密码可能以密文发送,isEncrypt标志是否已经加密.
        /// 当前版本没有实现加解密.isEncrypt被简单的忽略.
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
            
            //如果按用户编码找不到用户，说明输入登陆名不存在
            string code = GetCode(userCode, isEncrypt);
            CheckUserExist(logedinUser, userCode);

           
            //检测用户是否被禁止
            CheckUserEnabled(logedinUser);

            //检测用户密码
            string pwd = GetPassword(password, isEncrypt);
            CheckUserPassword(logedinUser, pwd);

            //检测用户所属机构是否存在如果机构不存在，抛出逻辑异常	
            UserOrg uo = userOrgDao.GetUserOrgById(ui.Id);

            logedinUser.UserOrg = uo;

            CheckUserOrgExist(logedinUser);



            //买方机构信息，用于获取地址等买方信息。
            //CatBuyer buyer = buyerDao.GetCatBuyerByRegBuyerId(uo.Reg_org_id);
            //if (buyer != null)
            //{
            //    logedinUser.BuyerInfo = buyer;
            //}
            //else
            //{
            //    logedinUser.BuyerInfo = new CatBuyer();
            //}

            //检测机构是否被禁止
            //CheckUserOrgEnabled(logedinUser);

            //如果角色不存在，抛出逻辑异常
            //UserRole ur = userRoleDao.GetUserRoleById(ui.Role_id);
            //// bool isHospital = userRoleDao.IsHospital(
            //logedinUser.UserRole = ur;
            //CheckUserRoleExist(logedinUser);

            ////检测角色是否被禁止
            //CheckUserRoleEnabled(logedinUser);

            ////用户区域信息
            //UserRegion ure = userRegionDao.GetUserRegionById(ui.Region_id);
            //logedinUser.UserRegion = ure;

            ////设置此用户所对应的注册区域
            //UserRegionRange urr = userRegionRangeDao.GetUserRegionRangeByRegionId(ui.Region_id);
            //if (urr != null)
            //{
            //    logedinUser.UserRegionRange = urr;
            //    logedinUser.SingleRegionId = urr.Reg_region_id;
            //}

            ////所有检查完后才能取得区域列表 2007-9-12 CJ
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
        /// 如果logedinUser对象中还没有包含UserInfo信息，或包含的UserInfo的Code与userCode不一致，则抛出LoginException(string.Format("{0}用户不存在", userCode))
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        /// <param name="userCode">The user code.</param>
        protected virtual void CheckUserExist(LogedInUser logedinUser, string userCode)
        {
            if (logedinUser.UserInfo == null || logedinUser.UserInfo.Code != userCode)
            {
                throw new LoginException(string.Format("{0}用户不存在。", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user enabled.
        /// 如果logedinUser对象中还没有包含UserInfo信息，或包含的UserInfo已经被禁止，则抛出LoginException(string.Format("{0}用户被禁止.", userCode))
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserEnabled(LogedInUser logedinUser)
        {
            if (logedinUser.UserInfo == null || "0" == logedinUser.UserInfo.Enable_flag)
            {
                throw new LoginException(string.Format("{0}用户被禁止.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user password.
        /// 如果logedinUser对象中还没有包含UserInfo信息，或包含的UserInfo的password不一致，则抛出LoginException(string.Format("{0}用户密码错误.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        /// <param name="password">The password.</param>
        protected virtual void CheckUserPassword(LogedInUser logedinUser, string password)
        {
            if (logedinUser.UserInfo == null || password != logedinUser.UserInfo.Password)
            {
                throw new LoginException(string.Format("{0}用户密码错误.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user org exist.
        /// 如果logedinUser对象中还没有包含UserOrg信息，则抛出LoginException(string.Format("{0}用户机构不存在.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserOrgExist(LogedInUser logedinUser)
        {
            if (logedinUser.UserOrg == null)
            {
                throw new LoginException(string.Format("{0}用户机构不存在.", loginUserCode));
            }
        }


        /// <summary>
        /// Checks the user org enabled.
        /// 如果logedinUser对象中的UserOrg信息的Enable_flag==0，则抛出LoginException(string.Format("{0}用户机构被禁止.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserOrgEnabled(LogedInUser logedinUser)
        {
            if (logedinUser.UserOrg.Enable_flag == "0")
            {
                throw new LoginException(string.Format("{0}用户机构被禁止.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user role exist.
        /// 如果logedinUser对象中还没有包含UserRole信息，则抛出LoginException(string.Format("{0}用户所属角色不存在.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserRoleExist(LogedInUser logedinUser)
        {
            if (logedinUser.UserRole == null)
            {
                throw new LoginException(string.Format("{0}用户所属角色不存在.", loginUserCode));
            }
        }

        /// <summary>
        /// Checks the user role enabled.
        /// 如果logedinUser对象中包含的UserRole被禁止，则抛出LoginException(string.Format("{0}用户所属角色被禁止.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        protected virtual void CheckUserRoleEnabled(LogedInUser logedinUser)
        {
            if (logedinUser.UserRole.Enable_flag == "0")
            {
                throw new LoginException(string.Format("{0}用户所属角色被禁止.", loginUserCode));
            }
        }



        /// <summary>
        /// 取得当前用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetMenu(string userId, string clientType)
        {
            return userSystemDao.GetMenu(userId, clientType);
        }


    }
}
