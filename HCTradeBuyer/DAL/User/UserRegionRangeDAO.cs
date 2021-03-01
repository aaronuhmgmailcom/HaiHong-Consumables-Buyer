#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserRegionRangeDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 6 $
 * $History: UserRegionRangeDAO.cs $
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistant.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 5  *****************
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
    public class UserRegionRangeDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionRangeDAL"/> class.
        /// </summary>
        private UserRegionRangeDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionRangeDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserRegionRangeDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserRegionRangeDAO GetInstance()
        {
            return new UserRegionRangeDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserRegionRangeDAO GetInstance(string connectionName)
        {
            return new UserRegionRangeDAO(connectionName);
        }

        /// <summary>
        /// Gets the user region range by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserRegionRange GetUserRegionRangeById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(MapGPO_USR_REGION_RANGE)) as UserRegionRange;
        }

        /// <summary>
        /// Gets the user region range by region id.
        /// </summary>
        /// <param name="regionId">The region id.</param>
        /// <returns></returns>
        public UserRegionRange GetUserRegionRangeByRegionId(string regionId)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByRegionIdSql(), regionId, new MapRow(MapGPO_USR_REGION_RANGE)) as UserRegionRange;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  urr.id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select one by region id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByRegionIdSql()
        {
            string _where = @" WHERE  urr.region_id = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return @"SELECT 
                      urr.id   AS  id, 
                      urr.region_id   AS  region_id, 
                      urr.reg_region_id   AS  reg_region_id  
                    FROM GPO_USR_REGION_RANGE    urr  ";
        }

        /// <summary>
        /// Maps the GPO_USR_REGION_RANGE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_REGION_RANGE(IDataReader reader, int rowNumber)
        {
            UserRegionRange _gpo_usr_region_range = new UserRegionRange();
            _gpo_usr_region_range.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_region_range.Region_id = Convert.ToString(reader["REGION_ID"]);
            _gpo_usr_region_range.Reg_region_id = Convert.ToString(reader["REG_REGION_ID"]);
            return _gpo_usr_region_range;
        }

    }
}
