using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.Commons;

namespace Emedchina.TradeAssistant.DAL.Plat
{
    public class PlatDao : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        private PlatDao()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private PlatDao(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static PlatDao GetInstance()
        {
            return new PlatDao();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static PlatDao GetInstance(string connectionName)
        {
            return new PlatDao(connectionName);
        }
        public string getSalerCurrentPlatsId(string userId, string platFatherId)
        {
            List<string> mgrPlats = getDefaultMgrPlats(userId, platFatherId);
            string subPlatsIds = "";
            foreach (string platId in mgrPlats)
            {
                List<string> subPlats = findSubPlatId(platId);
                foreach (string subPlatId in subPlats)
                {
                    subPlatsIds += "'" + subPlatId + "',";
                }
            }
            return subPlatsIds.Substring(0,subPlatsIds.Length-1);
        }
        public List<string> getDefaultMgrPlats(string userId, string platFatherId)
        {
            List<string> currPlats = findSubPlatId(platFatherId);
            List<string> userPlats = findPlatsByUserId(userId);
            

            return ComUtil.getIntersection(currPlats,userPlats);
        }
        public List<string> findSubPlatId(string platFatherId)
        {
            string sql = "select id from plt_plat where plat_father = :ID";
            DbParameter idPara = DbFacade.CreateParameter();
            idPara.ParameterName = "ID";
            idPara.DbType = DbType.String;
            idPara.Value = platFatherId;
            List<string> result = null;
            try
            {
                result = (List<string>)DbFacade.SQLExecuteList<string>(sql, new MapRow<string>(MapPlatId), idPara);
            }
            catch (Exception e)
            {
                throw e;
            }


            return result;
        }
        public List<string> findPlatsByUserId(string userId)
        {
            string sql = "select plat_id as id from usr_usr_plat where user_id = :ID";
            DbParameter idPara = DbFacade.CreateParameter();
            idPara.ParameterName = "ID";
            idPara.DbType = DbType.String;
            idPara.Value = userId;
            List<string> result = null;
            try
            {
                result = (List<string>)DbFacade.SQLExecuteList<string>(sql,new MapRow<string>(MapPlatId), idPara);
            }
            catch (Exception e)
            {
                throw e;
            }


            return result;
        }
        /// <summary>
        /// Maps the GPO_USR_USER table
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private string MapPlatId(IDataReader reader, int rowNumber)
        {
            return Convert.ToString(reader["ID"]);
        }

        #region 根据HandlerId和Operate查询角色ID列表
        /// <summary>
        /// 根据HandlerId和Operate查询角色ID列表
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="handlerId"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<string> findRoleListByHandlerIdAndOperate(string operate, string handlerId, bool flag)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct usr_role_function.role_id as ID ");
            sql.Append("from usr_role_function , usr_function , usr_action , usr_module ");
            sql.Append("where usr_module.url like :handlerId ");
            if (!flag)
                sql.Append("and usr_action.action_code = :operate ");
            sql.Append("and usr_function.module_id = usr_module.id ");
            sql.Append("and usr_function.action_id = usr_action.id ");
            sql.Append("and usr_function.parent_id = usr_role_function.parent_id ");

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter param = this.DbFacade.CreateParameter();
            param.ParameterName = "handlerId";
            param.DbType = DbType.String;
            param.Value = handlerId + "%";
            parameters.Add(param);

            if (!flag)
            {
                param = this.DbFacade.CreateParameter();
                param.ParameterName = "operate";
                param.DbType = DbType.String;
                param.Value = operate;
                parameters.Add(param);
            }
            List<string> result = null;
            try
            {
                result = (List<string>)DbFacade.SQLExecuteList<string>(sql.ToString(), new MapRow<string>(MapPlatId), parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        #endregion

        #region 根据UserId和平台ID查询角色ID
        /// <summary>
        /// 根据UserId和平台ID查询角色ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="platId"></param>
        /// <returns></returns>
        public List<string> findRolesByUserIdAndPlatId(string userId, string platId)
        {
            string sql = "select usr_user_role.role_id as ID from usr_user_role , usr_role_plat where usr_user_role.user_id = :user_id and usr_role_plat.plat_id = :plat_id and usr_user_role.role_id = usr_role_plat.role_id ";
            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter param = this.DbFacade.CreateParameter();
            param.ParameterName = "user_id";
            param.DbType = DbType.String;
            param.Value = userId;
            parameters.Add(param);

            param = this.DbFacade.CreateParameter();
            param.ParameterName = "plat_id";
            param.DbType = DbType.String;
            param.Value = platId;
            parameters.Add(param);

            List<string> result = null;
            try
            {
                result = (List<string>)DbFacade.SQLExecuteList<string>(sql, new MapRow<string>(MapPlatId), parameters.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        #endregion

        #region 根绝角色ID查询平台ID
        /// <summary>
        /// 根绝角色ID查询平台ID
        /// </summary>
        /// <param name="roleList"></param>
        /// <returns></returns>
        public List<string> findPlatsByRoleId(List<string> roleList)
        {
            if (roleList.Count == 0)
                return null;
            string sql = "select plat_id as ID from usr_role_plat where role_id = ";
                       
            foreach (string subRoleId in roleList)
            {
                sql += "'" + subRoleId + "'" + " union";
            }
            sql = sql.Substring(0, sql.Length - 5);

            List<string> result = null;
            try
            {
                result = (List<string>)DbFacade.SQLExecuteList<string>(sql, new MapRow<string>(MapPlatId));
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        #endregion

        #region 查询平台ID
        /// <summary>
        /// 查询平台ID
        /// </summary>
        /// <param name="handlerId"></param>
        /// <param name="operate"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<string> getPlats(string handlerId, string operate,UserInfo ui, bool flag)
        {
            List<string> functionRole = findRoleListByHandlerIdAndOperate(operate, handlerId, flag);
            List<string> currentRoles = findRolesByUserIdAndPlatId(ui.UserId,ui.LastLoginPlat);
            List<string> rolePlats = findPlatsByRoleId(ComUtil.getIntersection(functionRole, currentRoles));
            List<string> userPlats = findPlatsByUserId(ui.UserId);

            return ComUtil.getIntersection(rolePlats, userPlats);
        }
        #endregion

        #region 查询平台ID(重载1)
        /// <summary>
        /// 查询平台ID(重载1)
        /// </summary>
        /// <param name="handlerId"></param>
        /// <param name="operate"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<string> getPlats(string userId, string platFatherId)
        {
            return getDefaultMgrPlats(userId, platFatherId);
        }
        #endregion

        #region 查询3级平台ID
        /// <summary>
        /// 查询3级平台ID
        /// </summary>
        /// <param name="handlerId"></param>
        /// <param name="operate"></param>
        /// <param name="ui"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<string> getClass3Plats(string handlerId, string operate, UserInfo ui, bool flag)
        {
            if (ui.PlatClass.Equals("2"))
            {
                return getPlats(ui.UserId, ui.LastLoginPlat);
            }
            else if (ui.PlatClass.Equals("3"))
            {
                return getPlats(handlerId, operate, ui, flag);
            }
            return null;
        }
        #endregion

        #region 得到所有交易场ID
        /// <summary>
        /// 得到所有交易场ID
        /// </summary>
        /// <param name="plat3"></param>
        /// <returns></returns>
        public List<string> findAllExchange(List<string> plat3)
        {
            if (plat3.Count == 0)
                return null;
            string sql = "select id from plt_plat where plat_father = ";

            foreach (string subPlatId in plat3)
            {
                sql += "'" + subPlatId + "'" + " union";
            }
            sql = sql.Substring(0, sql.Length - 5);

            List<string> result = null;
            try
            {
                result = (List<string>)DbFacade.SQLExecuteList<string>(sql, new MapRow<string>(MapPlatId));
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        #endregion

        #region 查询4级平台ID
        /// <summary>
        /// 查询4级平台ID
        /// </summary>
        /// <param name="handlerId"></param>
        /// <param name="operate"></param>
        /// <param name="ui"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<string> getClass4PlatsList(string handlerId, string operate, UserInfo ui, bool flag)
        {
            return findAllExchange(getClass3Plats(handlerId, operate, ui, flag));
        }
        #endregion

    }
}
