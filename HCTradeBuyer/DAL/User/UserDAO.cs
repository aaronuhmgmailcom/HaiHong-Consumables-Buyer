#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/DAL/User/UserDAO.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 7 $
 * $History: UserDAO.cs $
 * 
 * *****************  Version 7  *****************
 * User: Liangxy      Date: 06-10-18   Time: 15:00
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 5  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistant.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-24   Time: 10:41
 * Updated in $/TradeAssistant.root/TradeAssistant/DAL/User
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model;
using Emedchina.TradeAssistant.Model.User;
#endregion

namespace Emedchina.TradeAssistant.DAL.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        private UserDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserDAO GetInstance()
        {
            return new UserDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserDAO GetInstance(string connectionName)
        {
            return new UserDAO(connectionName);
        }

        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(string userId)
        {
            return base.DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), userId, new MapRow(Map_USR_USER)) as UserInfo;
        }

        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public UserInfo GetUserInfoByCode(string code)
        {
            return base.DbFacade.SQLQueryObjectById(getSelectOneByCodeSql(), code, new MapRow(Map_USR_USER)) as UserInfo;
        }

        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public UserInfo GetUserInfoByName(string name)
        {
            return base.DbFacade.SQLQueryObjectById(getSelectOneByNameSql(), name, new MapRow(Map_USR_USER)) as UserInfo;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  u.id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select one by code SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByCodeSql()
        {
            string _where = @" WHERE  u.mail = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select one by name SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByNameSql()
        {
            string _where = @" WHERE  u.name = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }


        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return
            @"SELECT 
              ID ,
              MAIL,
              NAME,
              PASSWORD,
              ADMIN_LEVEL,
              DESCRIPTION,
              ENABLE_FLAG,
              REMARK,
              CREATE_USER,
              CREATE_NAME,
              CREATE_DATE,
              MODIFY_USER,
              MODIFY_NAME,
              MODIFY_DATE,
              CA_FLAG,
              KEY_FLAG,
              PW_FLAG, 
              LOGIN_DATE
            FROM cen_usr_user u ";

        }


        /// <summary>
        /// Maps the GPO_USR_USER table
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object Map_USR_USER(IDataReader reader, int rowNumber)
        {
            UserInfo _gpo_usr_user = new UserInfo();
            _gpo_usr_user.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_user.Code = Convert.ToString(reader["Mail"]);
            _gpo_usr_user.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_user.Password = Convert.ToString(reader["PASSWORD"]);
            //_gpo_usr_user.Role_id = Convert.ToString(reader["ROLE_ID"]);
            //_gpo_usr_user.Org_id = Convert.ToString(reader["ORG_ID"]);
            //_gpo_usr_user.Tel = Convert.ToString(reader["TEL"]);
            //_gpo_usr_user.Mobile = Convert.ToString(reader["MOBILE"]);
            //_gpo_usr_user.Email = Convert.ToString(reader["EMAIL"]);
            _gpo_usr_user.Describe = Convert.ToString(reader["REMARK"]);
            _gpo_usr_user.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_user.Admin_flag = Convert.ToString(reader["ADMIN_LEVEL"]);
//            _gpo_usr_user.Region_id = Convert.ToString(reader["REGION_ID"]);
            _gpo_usr_user.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_user.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);
//            _gpo_usr_user.Create_region = Convert.ToString(reader["CREATE_REGION"]);
            //_gpo_usr_user.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            _gpo_usr_user.Last_update_user = Convert.ToString(reader["MODIFY_USER"]);
            _gpo_usr_user.Last_update_date = reader["MODIFY_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["MODIFY_DATE"]);
//            _gpo_usr_user.Last_update_region = Convert.ToString(reader["LAST_UPDATE_REGION"]);
            //_gpo_usr_user.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            //_gpo_usr_user.Headship = Convert.ToString(reader["HEADSHIP"]);
            _gpo_usr_user.Login_date = reader["LOGIN_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LOGIN_DATE"]);
            return _gpo_usr_user;
        }
    }
}
