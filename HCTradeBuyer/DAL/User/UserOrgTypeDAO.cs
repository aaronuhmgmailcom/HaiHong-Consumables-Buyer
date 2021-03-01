#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserOrgTypeDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 5 $
 * $History: UserOrgTypeDAO.cs $
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
    public class UserOrgTypeDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrgTypeDAL"/> class.
        /// </summary>
        private UserOrgTypeDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrgTypeDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserOrgTypeDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserOrgTypeDAO GetInstance()
        {
            return new UserOrgTypeDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserOrgTypeDAO GetInstance(string connectionName)
        {
            return new UserOrgTypeDAO(connectionName);
        }

        /// <summary>
        /// Gets the user org type by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserOrgType GetUserOrgTypeById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_ORG_TYPE)) as UserOrgType;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  uot.type = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return @"SELECT 
                          uot.type   AS  type, 
                          uot.name   AS  name  
                        FROM GPO_USR_ORG_TYPE    uot  ";
        }

        /// <summary>
        /// Maps the GPO_USR_ORG_TYPE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_ORG_TYPE(IDataReader reader, int rowNumber)
        {
            UserOrgType _gpo_usr_org_type = new UserOrgType();
            _gpo_usr_org_type.Type = Convert.ToString(reader["TYPE"]);
            _gpo_usr_org_type.Name = Convert.ToString(reader["NAME"]);
            return _gpo_usr_org_type;
        }


    }
}
