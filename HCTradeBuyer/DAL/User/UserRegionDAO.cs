#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserRegionDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 5 $
 * $History: UserRegionDAO.cs $
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
    public class UserRegionDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionDAL"/> class.
        /// </summary>
        private UserRegionDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserRegionDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserRegionDAO GetInstance()
        {
            return new UserRegionDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserRegionDAO GetInstance(string connectionName)
        {
            return new UserRegionDAO(connectionName);
        }

        /// <summary>
        /// Gets the user region by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserRegion GetUserRegionById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_REGION)) as UserRegion;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  ure.id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return @"SELECT 
                      ure.id   AS  id, 
                      ure.region_type   AS  region_type, 
                      ure.region_name   AS  region_name, 
                      ure.remark   AS  remark  
                    FROM GPO_USR_REGION    ure  
                    ";
        }


        private object MapGPO_USR_REGION(IDataReader reader, int rowNumber)
        {
            UserRegion _gpo_usr_region = new UserRegion();
            _gpo_usr_region.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_region.Region_type = Convert.ToString(reader["REGION_TYPE"]);
            _gpo_usr_region.Region_name = Convert.ToString(reader["REGION_NAME"]);
            _gpo_usr_region.Remark = Convert.ToString(reader["REMARK"]);
            return _gpo_usr_region;
        }

    }
}
