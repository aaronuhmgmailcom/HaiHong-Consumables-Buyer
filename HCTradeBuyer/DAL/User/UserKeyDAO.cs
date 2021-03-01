#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserKeyDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 5 $
 * $History: UserKeyDAO.cs $
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
    public class UserKeyDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserKeyDAL"/> class.
        /// </summary>
        private UserKeyDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserKeyDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserKeyDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserKeyDAO GetInstance()
        {
            return new UserKeyDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserKeyDAO GetInstance(string connectionName)
        {
            return new UserKeyDAO(connectionName);
        }

        /// <summary>
        /// Gets the user key.
        /// </summary>
        /// <param name="id">The id.</param>
        public UserKey GetUserKeyById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_USER_KEY)) as UserKey;
        }


        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  uk.user_id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }


        private string getSelectAllSql()
        {
            return @"SELECT 
                          uk.user_id   AS  user_id, 
                          uk.sn   AS  sn, 
                          uk.pin   AS  pin, 
                          uk.create_user   AS  create_user, 
                          uk.create_date   AS  create_date, 
                          uk.create_plat   AS  create_plat, 
                          uk.create_org   AS  create_org, 
                          uk.last_update_user   AS  last_update_user, 
                          uk.last_update_date   AS  last_update_date, 
                          uk.last_update_plat   AS  last_update_plat, 
                          uk.description   AS  description, 
                          uk.last_update_org   AS  last_update_org  
                        FROM GPO_USR_USER_KEY    uk  ";
        }

        /// <summary>
        /// Maps the GPO_USR_USER_KEY.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_USER_KEY(IDataReader reader, int rowNumber)
        {
            UserKey _gpo_usr_user_key = new UserKey();
            _gpo_usr_user_key.User_id = Convert.ToString(reader["USER_ID"]);
            _gpo_usr_user_key.Sn = Convert.ToString(reader["SN"]);
            _gpo_usr_user_key.Pin = Convert.ToString(reader["PIN"]);
            _gpo_usr_user_key.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_user_key.Create_date = Convert.ToDateTime(reader["CREATE_DATE"]);
            _gpo_usr_user_key.Create_plat = Convert.ToString(reader["CREATE_PLAT"]);
            _gpo_usr_user_key.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            _gpo_usr_user_key.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _gpo_usr_user_key.Last_update_date = Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);
            _gpo_usr_user_key.Last_update_plat = Convert.ToString(reader["LAST_UPDATE_PLAT"]);
            _gpo_usr_user_key.Description = Convert.ToString(reader["DESCRIPTION"]);
            _gpo_usr_user_key.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            return _gpo_usr_user_key;
        }


    }
}
