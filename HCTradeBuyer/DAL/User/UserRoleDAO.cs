#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/DAL/User/UserRoleDAO.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 7 $
 * $History: UserRoleDAO.cs $
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
    public class UserRoleDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRoleDAL"/> class.
        /// </summary>
        private UserRoleDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRoleDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserRoleDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserRoleDAO GetInstance()
        {
            return new UserRoleDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserRoleDAO GetInstance(string connectionName)
        {
            return new UserRoleDAO(connectionName);
        }

        /// <summary>
        /// Gets the user role by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserRole GetUserRoleById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_ROLE)) as UserRole;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  uro.id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return @"SELECT 
                      uro.id   AS  id, 
                      uro.name   AS  name, 
                      uro.type_name   AS  type_name, 
                      uro.type   AS  type, 
                      uro.sort   AS  sort, 
                      uro.enable_flag   AS  enable_flag, 
                      uro.create_user   AS  create_user, 
                      uro.create_date   AS  create_date, 
                      uro.create_org   AS  create_org, 
                      uro.last_update_user   AS  last_update_user, 
                      uro.last_update_date   AS  last_update_date, 
                      uro.last_update_org   AS  last_update_org  
                    FROM GPO_USR_ROLE    uro ";
        }

        /// <summary>
        /// Maps the GPO_USR_ROLE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_ROLE(IDataReader reader, int rowNumber)
        {
            UserRole _gpo_usr_role = new UserRole();
            _gpo_usr_role.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_role.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_role.Type_name = Convert.ToString(reader["TYPE_NAME"]);
            _gpo_usr_role.Type = Convert.ToString(reader["TYPE"]);
            _gpo_usr_role.Sort = Convert.ToString(reader["SORT"]);
            //_gpo_usr_role.Region_id = Convert.ToString(reader["REGION_ID"]);
            _gpo_usr_role.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_role.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_role.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);
            //_gpo_usr_role.Create_region = Convert.ToString(reader["CREATE_REGION"]);
            _gpo_usr_role.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            _gpo_usr_role.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _gpo_usr_role.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);
            //_gpo_usr_role.Last_update_region = Convert.ToString(reader["LAST_UPDATE_REGION"]);
            _gpo_usr_role.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            return _gpo_usr_role;
        }

    }
}
