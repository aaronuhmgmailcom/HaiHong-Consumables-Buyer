using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons;
using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.Client.DAL.UserInfomation
{
    public class PassMgrDAO :SqlDAOBase
    {
        private PassMgrDAO()
            : base()
        { }

        private PassMgrDAO(string connectionName)
            : base(connectionName)
        { }

        public static PassMgrDAO GetInstance()
        {
            return new PassMgrDAO();
        }

        public static PassMgrDAO GetInstance(string connectionName)
        {
            return new PassMgrDAO(connectionName);
        }

           #region 取得用户信息
        /// <summary>
        /// 取得一条用户信息
        /// </summary>       
        public DataTable GetLocalsysUserInfo(string strId)
        {
            try
            {
                //生成全部sql
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ID,NAME,MAIL,PASSWORD,DESCRIPTION FROM CEN_USR_USER");
                strSql.Append(" WHERE ( ID = '" + strId + "') ");
                return base.DbFacade.SQLExecuteDataTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region 更新用户密码
        /// <summary>
        /// 更新用户密码
        /// </summary>       
        public int UpdateLocalsysUserInfo(
            string strId,
            string sNewpass,
            string sModifyUserID,
            string sModifyUserName)
        {
            try
            {
                //生成全部sql
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE CEN_USR_USER SET ");
                strSql.Append(" PASSWORD ='" + sNewpass + "',");
                strSql.Append(" MODIFY_USER='" + sModifyUserID + "',");
                strSql.Append(" MODIFY_NAME='" + sModifyUserName + "',");
                strSql.Append(" SYNC_STATE='0',");
                strSql.Append(" MODIFY_DATE=GETDATE() ");
                strSql.Append(" WHERE ( ID = '" + strId + "') ");
                
                return base.DbFacade.SQLExecuteNonQuery(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        
    }

    
}
