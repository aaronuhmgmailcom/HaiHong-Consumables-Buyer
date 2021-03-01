#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/DAL/User/UserOrgRoleDAO.cs $ 
 * $Author: Panyj $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 7 $
 * $History: UserOrgRoleDAO.cs $
 * 
 * *****************  Version 7  *****************
 * User: Panyj        Date: 06-09-11   Time: 15:57
 * Updated in $/TradeAssistant1.2.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 7  *****************
 * User: Panyj        Date: 06-09-11   Time: 15:43
 * Updated in $/TradeAssistant.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 6  *****************
 * User: Panyj        Date: 06-09-11   Time: 14:16
 * Updated in $/TradeAssistant.root/TradeAssistant/DAL/User
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
    public class UserOrgRoleDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrgRoleDAL"/> class.
        /// </summary>
        private UserOrgRoleDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserOrgRoleDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserOrgRoleDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserOrgRoleDAO GetInstance()
        {
            return new UserOrgRoleDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserOrgRoleDAO GetInstance(string connectionName)
        {
            return new UserOrgRoleDAO(connectionName);
        }

        /// <summary>
        /// Gets the user org role by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserOrgRole GetUserOrgRoleById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_ORG_ROLE)) as UserOrgRole;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  uor.id = :ID";
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
                      uor.id   AS  id, 
                      uor.org_id   AS  org_id, 
                      uor.role_id   AS  role_id  
                    FROM GPO_USR_ORG_ROLE    uor  ";
        }

        /// <summary>
        /// Maps the GPO_USR_ORG_ROLE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_ORG_ROLE(IDataReader reader, int rowNumber)
        {
            UserOrgRole _gpo_usr_org_role = new UserOrgRole();
            _gpo_usr_org_role.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_org_role.Org_id = Convert.ToString(reader["ORG_ID"]);
            _gpo_usr_org_role.Role_id = Convert.ToString(reader["ROLE_ID"]);
            return _gpo_usr_org_role;
        }


        #region　判断买方是医院还是供应站
        /// <summary>
        /// 判断买方是医院还是供应站
        /// </summary>
        /// panyj 2006-9-11
        /// <param name="orgId"></param>
        /// <returns>true：医院；false：供应站
        /// </returns>
        public bool isHospital(string orgId)
        {
            int c = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("select  count (1) cnt ");//定购总量
            sql.Append(" from gpo_provider_buyer,gpo_usr_org ");
            sql.Append(" where gpo_usr_org.reg_org_id =gpo_provider_buyer.request_id and  gpo_usr_org.id = '").Append(orgId).Append("'");
            object result = DbFacade.SQLExecuteScalar(sql.ToString());
            c = Convert.ToInt32(result);
            if (c > 0)
            {
                return true;
            }
            else {
                return false;
            }
            
        }
        #endregion


        #region　判断是否生产企业
        /// <summary>
        /// 判断是否生产企业
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns>
        /// </returns>
        public bool IsFactory(string orgId)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("select  factory_flag ");
            sql.Append(" from Gpo_Reg_Org ");
            sql.Append(" where id = '").Append(orgId).Append("'");
            object result = DbFacade.SQLExecuteScalar(sql.ToString());
            
            if ("1".Equals(result))
                return true;
            else
                return false;

        }
        #endregion
    }
}
