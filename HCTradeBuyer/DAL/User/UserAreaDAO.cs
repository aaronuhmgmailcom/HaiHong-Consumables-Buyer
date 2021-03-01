#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant1.2.root/TradeAssistant/DAL/User/UserAreaDAO.cs $ 
 * $Author: Liangxy $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 1 $
 * $History: UserAreaDAO.cs $
 * 
 * *****************  Version 1  *****************
 * User: Liangxy      Date: 06-09-27   Time: 17:02
 * Created in $/TradeAssistant1.2.root/TradeAssistant/DAL/User
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
using Emedchina.TradeAssistant.Model.User;
#endregion

namespace Emedchina.TradeAssistant.DAL.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAreaDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionRangeDAL"/> class.
        /// </summary>
        private UserAreaDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserRegionRangeDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private UserAreaDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static UserAreaDAO GetInstance()
        {
            return new UserAreaDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static UserAreaDAO GetInstance(string connectionName)
        {
            return new UserAreaDAO(connectionName);
        }

        /// <summary>
        /// Gets the user region range by userid.
        /// </summary>
        /// <param name="userId">The id.</param>
        /// <returns></returns>
        public UserArea GetUserAreaByUserId(string userId)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), userId, new MapRow(MapGPO_USR_USER_AREA)) as UserArea;
        }

        

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" WHERE  uua.USER_ID = :ID";
            return string.Concat(getSelectAllSql(), _where);
        }

        

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSql()
        {
            return @"SELECT 
                      uua.id   AS  id, 
                      uua.USER_ID   AS  USER_ID, 
                      uua.AREA_ID   AS  AREA_ID  
                    FROM GPO_USR_USER_AREA    uua  ";
        }

        /// <summary>
        /// Maps the GPO_USR_REGION_RANGE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_USER_AREA(IDataReader reader, int rowNumber)
        {
            UserArea user_area = new UserArea();
            user_area.Id = Convert.ToString(reader["ID"]);
            user_area.AreaId = Convert.ToString(reader["AREA_ID"]);
            user_area.UserId = Convert.ToString(reader["USER_ID"]);
            return user_area;
        }

        /// <summary>
        /// 取得当前用户的区域列表字符串
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
        public string GetUserAreaListString(string strUserID)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder ids = new StringBuilder();
            sql.Append("SELECT T.AREA_ID FROM GPO_USR_USER_AREA T WHERE T.USER_ID = '").Append(strUserID);
            sql.Append("' AND EXISTS (SELECT 'X' FROM GPO_REG_AREA A WHERE A.ID = T.AREA_ID)");
            DataTable dt = DbFacade.SQLExecuteDataTable(sql.ToString());
            
            foreach (DataRow dr in dt.Rows)
            {
                ids.Append("'").Append(dr[0].ToString()).Append("',");
            }
            if (ids.Length > 0)
            {
                ids.Remove(ids.Length - 1, 1);
            }
            return ids.ToString();
        }

    }
}
