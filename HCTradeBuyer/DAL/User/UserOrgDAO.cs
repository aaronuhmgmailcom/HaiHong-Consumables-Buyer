#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/DAL/User/UserOrgDAO.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 8 $
 * $History: UserOrgDAO.cs $
 * 
 * *****************  Version 8  *****************
 * User: Liangxy      Date: 06-10-18   Time: 15:00
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 7  *****************
 * User: Liangxy      Date: 06-09-27   Time: 17:02
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
    public class UserOrgDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrgDAL"/> class.
        /// </summary>
        private UserOrgDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrgDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserOrgDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserOrgDAO GetInstance()
        {
            return new UserOrgDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserOrgDAO GetInstance(string connectionName)
        {
            return new UserOrgDAO(connectionName);
        }

        /// <summary>
        /// Gets the user org by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserOrg GetUserOrgById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(Map_USR_ORG)) as UserOrg;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" AND uo.USER_ID = :ID";
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
                  o.id   AS  id, 
                  o.ORG_NAME   AS  name, 
                  o.ORG_ABBR   AS  abbr,                 
                  o.ORG_PHONE   AS  phone, 
                  o.BUYER_FLAG,
                  o.SENDER_FLAG,
                  o.enable_flag   AS  enable_flag, 
                  o.CREATE_USER_ID   AS  create_user, 
                  o.CREATE_DATE   AS  create_date, 
                  o.MODIFY_USER_ID   AS  last_update_user, 
                  o.MODIFY_DATE   AS  last_update_date  
                FROM HC_USER_ORG    uo,HC_ORG o  WHERE uo.ORG_ID = o.ID ";
        }

        /// <summary>
        /// Maps the GPO_USR_ORG.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object Map_USR_ORG(IDataReader reader, int rowNumber)
        {
            UserOrg _gpo_usr_org = new UserOrg();
            _gpo_usr_org.Id = Convert.ToString(reader["ID"]);

            _gpo_usr_org.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_org.Abbr = Convert.ToString(reader["abbr"]);

            _gpo_usr_org.Phone = Convert.ToString(reader["PHONE"]);
            _gpo_usr_org.IsFactory = Convert.ToString(reader["SENDER_FLAG"]).Equals("1");
            _gpo_usr_org.IsHospital = Convert.ToString(reader["BUYER_FLAG"]).Equals("1");

            _gpo_usr_org.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_org.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_org.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);

            _gpo_usr_org.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _gpo_usr_org.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);

            return _gpo_usr_org;
        }

    }
}
