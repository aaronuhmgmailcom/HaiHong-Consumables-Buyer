#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Archive: /TradeAssistant.root/TradeAssistant/DAL/User/UserSystemDAO.cs $ 
 * $Author: Sunhl $ <a href="mailto:sunhongliang@hotmail.com">孙洪亮(sunhl)</a>
 * $Revision: 4 $
 * $History: UserSystemDAO.cs $
 * 
 * *****************  Version 4  *****************
 * User: Sunhl        Date: 06-06-28   Time: 15:57
 * Updated in $/TradeAssistant.root/TradeAssistant/DAL/User
 * 
 * *****************  Version 3  *****************
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
using System.Data.Common;
#endregion

namespace Emedchina.TradeAssistant.DAL.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSystemDAO : OracleDAOBase
    {
        private UserSystemDAO()
            : base()
        { }

        private UserSystemDAO(string connectionName)
            : base(connectionName)
        { }

        public static UserSystemDAO GetInstance()
        {
            return new UserSystemDAO();
        }

        public static UserSystemDAO GetInstance(string connectionName)
        {
            return new UserSystemDAO(connectionName);
        }



        /// <summary>
        /// 取得当前用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetMenu(string userId, string clientType)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("select *");
                sql.Append("  from (SELECT distinct CLIENT_MENU.MODULE_ID,");
                sql.Append("                        CLIENT_MENU.ID,");
                sql.Append("                        CLIENT_MENU.SORT_SN,");
                sql.Append("                        CLIENT_MENU.NAME,");
                sql.Append("                        CLIENT_MENU.FATHER,");
                sql.Append("                        CLIENT_MENU.MODULE_ACTION,");
                sql.Append("                        CLIENT_MENU.WEB_FLAG,");
                sql.Append("                        CLIENT_MENU.URL,CLIENT_MENU.SHORTCUT,CLIENT_MENU.IMAGE AS IMAGE1,");
                sql.Append("                        CLIENT_MENU.MODIFY_DATE");
                sql.Append("          FROM (Gpo_Usr_User INNER JOIN gpo_usr_user_module ON");
                sql.Append("                Gpo_Usr_User.id = gpo_usr_user_module.user_id)");
                sql.Append("                INNER JOIN CLIENT_MENU ON gpo_usr_user_module.MODULE_ID = CLIENT_MENU.MODULE_ID ");
                sql.Append("         where Gpo_Usr_User.ID = :userId ");
                sql.Append("         and CLIENT_MENU.enable_flag = '1' AND (instr(CLIENT_MENU.CLIENT_ID,'H') = 0 AND instr(CLIENT_MENU.CLIENT_ID,'W')= 0 ");
                //判断是否福建项目
                if ("1".Equals(clientType))
                    sql.Append("         and instr(CLIENT_MENU.client_id,'F') = 0");
                sql.Append("         OR CLIENT_MENU.CLIENT_ID IS NULL)");

                sql.Append("        union");
                sql.Append("          SELECT distinct CLIENT_MENU.MODULE_ID,");
                sql.Append("                          CLIENT_MENU.ID,");
                sql.Append("                          CLIENT_MENU.SORT_SN,");
                sql.Append("                          CLIENT_MENU.NAME,");
                sql.Append("                          CLIENT_MENU.FATHER,");
                sql.Append("                          CLIENT_MENU.MODULE_ACTION,");
                sql.Append("                          CLIENT_MENU.WEB_FLAG,");
                sql.Append("                          CLIENT_MENU.URL,CLIENT_MENU.SHORTCUT,CLIENT_MENU.IMAGE AS IMAGE1,");
                sql.Append("                          CLIENT_MENU.MODIFY_DATE");
                sql.Append("            from CLIENT_MENU");
                sql.Append("           where (CLIENT_MENU.module_id is null or CLIENT_MENU.father = '0')  ");
                sql.Append("         and CLIENT_MENU.enable_flag = '1' AND (instr(CLIENT_MENU.CLIENT_ID,'H') = 0 AND instr(CLIENT_MENU.CLIENT_ID,'W')= 0");
                //判断是否福建项目
                if ("1".Equals(clientType))
                    sql.Append("         and instr(CLIENT_MENU.client_id,'F') = 0");
                sql.Append("         OR CLIENT_MENU.CLIENT_ID IS NULL)");
                sql.Append("        ) nt");
                sql.Append(" ORDER BY nt.SORT_SN");

                DbParameter idPara = DbFacade.CreateParameter();
                idPara.ParameterName = "userId";
                idPara.DbType = DbType.AnsiString;
                idPara.Value = userId;

                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString(), idPara);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
    }
}
