#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserRoleModuleDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 5 $
 * $History: UserRoleModuleDAO.cs $
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
    public class UserRoleModuleDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRoleModuleDAL"/> class.
        /// </summary>
        private UserRoleModuleDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRoleModuleDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserRoleModuleDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserRoleModuleDAO GetInstance()
        {
            return new UserRoleModuleDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserRoleModuleDAO GetInstance(string connectionName)
        {
            return new UserRoleModuleDAO(connectionName);
        }

        /// <summary>
        /// Gets the user role module by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserRoleModule GetUserRoleModuleById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_ROLE_MODULE)) as UserRoleModule;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  urm.id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return @"SELECT 
                      urm.id   AS  id, 
                      urm.role_id   AS  role_id, 
                      urm.module_id   AS  module_id  
                    FROM GPO_USR_ROLE_MODULE    urm  ";
        }

        /// <summary>
        /// Maps the GPO_USR_ROLE_MODULE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_ROLE_MODULE(IDataReader reader, int rowNumber)
        {
            UserRoleModule _gpo_usr_role_module = new UserRoleModule();
            _gpo_usr_role_module.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_role_module.Role_id = Convert.ToString(reader["ROLE_ID"]);
            _gpo_usr_role_module.Module_id = Convert.ToString(reader["MODULE_ID"]);
            return _gpo_usr_role_module;
        }
    }
}
