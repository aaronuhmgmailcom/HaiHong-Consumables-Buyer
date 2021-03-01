using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.DAL.User;
using Emedchina.TradeAssistant.Model.Exceptions;
using Emedchina.TradeAssistant.Model.Org;

namespace Emedchina.TradeAssistant.Client.BLL.User
{
    class LoginUserOfflineBLL : SqlDAOBase
    {
        //登录用户编号
        string loginUserCode = string.Empty;

        LoginUserOfflineDao dao = null;

        private LoginUserOfflineBLL()
        {
            dao = LoginUserOfflineDao.GetInstance();
        }

        public static LoginUserOfflineBLL GetInstance()
        {
            return new LoginUserOfflineBLL();
        }

        private LoginUserOfflineBLL(string connectionName)
        {
            dao = LoginUserOfflineDao.GetInstance(connectionName);
        }

        public static LoginUserOfflineBLL GetInstance(String strConnectionn)
        {
            return new LoginUserOfflineBLL(strConnectionn);
        }


        #region 离线登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LogedInUser Login(string userCode, string password)
        {
            loginUserCode = userCode;
            LogedInUser logedinUser = new LogedInUser();
            UserInfo ui = dao.GetUserInfoByCode(userCode);
            
            logedinUser.UserInfo = ui;
            //如果按用户编码找不到用户，说明输入登陆名不存在

            //string code = GetCode(userCode, isEncrypt);
            CheckUserExist(logedinUser, userCode);

            //检测用户是否被禁止
            CheckUserEnabled(logedinUser);

            //检测用户密码

            //string pwd = GetPassword(password, isEncrypt);
            CheckUserPassword(logedinUser, password);

            //检测用户所属机构是否存在如果机构不存在，抛出逻辑异常	
            UserOrg uo = dao.GetUserOrgById(ui.Id);

            logedinUser.UserOrg = uo;

            CheckUserOrgExist(logedinUser);



            //买方机构信息，用于获取地址等买方信息。

            //CatBuyer buyer = dao.GetCatBuyerByRegBuyerId(uo.Reg_org_id);
            //if (buyer != null)
            //{
            //    logedinUser.BuyerInfo = buyer;
            //}
            //else
            //{
            //    logedinUser.BuyerInfo = new CatBuyer();
            //}
            //logedinUser.BuyerInfo = new CatBuyer();
            ////检测机构是否被禁止
            //CheckUserOrgEnabled(logedinUser);

            ////如果角色不存在，抛出逻辑异常
            //UserRole ur = dao.GetUserRoleById(ui.Role_id);
            //// bool isHospital = userRoleDao.IsHospital(
            //logedinUser.UserRole = ur;
            //CheckUserRoleExist(logedinUser);

            ////检测角色是否被禁止
            //CheckUserRoleEnabled(logedinUser);

            
            //////用户区域信息
            ////UserRegion ure = userRegionDao.GetUserRegionById(ui.Region_id);
            ////logedinUser.UserRegion = ure;

            //////设置此用户所对应的注册区域

            ////UserRegionRange urr = userRegionRangeDao.GetUserRegionRangeByRegionId(ui.Region_id);
            ////if (urr != null)
            ////{
            ////    logedinUser.UserRegionRange = urr;
            ////    logedinUser.SingleRegionId = urr.Reg_region_id;
            ////}

            ////所有检查完后才能取得区域列表 2007-9-12 CJ
            //logedinUser.UserInfo.Area_List = dao.GetUserAreaListString(ui.Id);
            //UserArea ua = dao.GetUserAreaByUserId(logedinUser.UserInfo.Id);
            //if (ua != null)
            //{
            //    logedinUser.UserArea = ua;
            //    logedinUser.SingleRegionId = ua.AreaId;
            //}
            return logedinUser;

        }
        #endregion

        #region 检查用户是否存在

        /// <summary>
        /// Checks whether the user exist.
        /// 如果logedinUser对象中还没有包含UserInfo信息，或包含的UserInfo的Code与userCode不一致，则抛出LoginException(string.Format("{0}用户不存在", userCode))
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        /// <param name="userCode">The user code.</param>
        protected virtual void CheckUserExist(LogedInUser logedinUser, string userCode)
        {
            if (logedinUser.UserInfo == null || logedinUser.UserInfo.Code.Trim() != userCode)
            {
                throw new LoginException(string.Format("{0}用户不存在。", loginUserCode));
            }
        }
        #endregion

        #region 检查用户是否被禁用
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
        #endregion

        #region 检测用户密码

        /// <summary>
        /// Checks the user password.
        /// 如果logedinUser对象中还没有包含UserInfo信息，或包含的UserInfo的password不一致，则抛出LoginException(string.Format("{0}用户密码错误.", userCode));
        /// </summary>
        /// <param name="logedinUser">The logedin user.</param>
        /// <param name="password">The password.</param>
        protected virtual void CheckUserPassword(LogedInUser logedinUser, string password)
        {            
            if (logedinUser.UserInfo == null || password != logedinUser.UserInfo.Password.Trim())
            {
                throw new LoginException(string.Format("{0}用户密码错误.", loginUserCode));
            }
        }
        #endregion

        #region 从离线数据中取得当前用户菜单
        /// <summary>
        /// 取得当前用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetMenuOffline(string userId, string clientType)
        {
            DataTable dt = dao.GetMenuOfflineTest(userId,clientType);
            
            return dt;
        }
        #endregion
     

        #region 检测用户机构是否存在

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
        #endregion

        #region 检查用户机构被禁止
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
        #endregion

        #region 检查用户角色是否存在

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
        #endregion

        #region 检测用户所属角色被禁止
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
        #endregion

        public int GetUserCount(string userCode)
        {
            return dao.GetUserCount(userCode);
        }

       
    }
}
