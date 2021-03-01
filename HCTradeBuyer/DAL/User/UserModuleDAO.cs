#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserModuleDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 5 $
 * $History: UserModuleDAO.cs $
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
    public class UserModuleDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserModuleDAL"/> class.
        /// </summary>
        private UserModuleDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserModuleDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserModuleDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserModuleDAO GetInstance()
        {
            return new UserModuleDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserModuleDAO GetInstance(string connectionName)
        {
            return new UserModuleDAO(connectionName);
        }

        /// <summary>
        /// Gets the user key by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserModule GetUserKeyById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_MODULE)) as UserModule;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  um.id = :ID";
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
                          um.id   AS  id, 
                          um.code   AS  code, 
                          um.name   AS  name, 
                          um.module_level   AS  module_level, 
                          um.father_id   AS  father_id, 
                          um.url   AS  url, 
                          um.sort   AS  sort, 
                          um.icon   AS  icon, 
                          um.link_type   AS  link_type, 
                          um.region_id   AS  region_id, 
                          um.enable_flag   AS  enable_flag, 
                          um.create_user   AS  create_user, 
                          um.create_date   AS  create_date, 
                          um.create_region   AS  create_region, 
                          um.create_org   AS  create_org, 
                          um.last_update_user   AS  last_update_user, 
                          um.last_update_date   AS  last_update_date, 
                          um.last_update_region   AS  last_update_region, 
                          um.last_update_org   AS  last_update_org, 
                          um.remark   AS  remark  
                        FROM GPO_USR_MODULE    um  ";
        }

        /// <summary>
        /// Maps the GP o_ US r_ MODULE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_MODULE(IDataReader reader, int rowNumber)
        {
            UserModule _gpo_usr_module = new UserModule();
            _gpo_usr_module.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_module.Code = Convert.ToString(reader["CODE"]);
            _gpo_usr_module.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_module.Module_level = Convert.ToString(reader["MODULE_LEVEL"]);
            _gpo_usr_module.Father_id = Convert.ToString(reader["FATHER_ID"]);
            _gpo_usr_module.Url = Convert.ToString(reader["URL"]);
            _gpo_usr_module.Sort = Convert.ToString(reader["SORT"]);
            _gpo_usr_module.Icon = Convert.ToString(reader["ICON"]);
            _gpo_usr_module.Link_type = Convert.ToString(reader["LINK_TYPE"]);
            _gpo_usr_module.Region_id = Convert.ToString(reader["REGION_ID"]);
            _gpo_usr_module.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_module.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_module.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);
            _gpo_usr_module.Create_region = Convert.ToString(reader["CREATE_REGION"]);
            _gpo_usr_module.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            _gpo_usr_module.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _gpo_usr_module.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);
            _gpo_usr_module.Last_update_region = Convert.ToString(reader["LAST_UPDATE_REGION"]);
            _gpo_usr_module.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            _gpo_usr_module.Remark = Convert.ToString(reader["REMARK"]);
            return _gpo_usr_module;
        }

    }
}
