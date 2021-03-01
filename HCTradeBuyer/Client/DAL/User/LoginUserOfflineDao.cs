using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
//using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.Org;
using Emedchina.TradeAssistant.Model.Exceptions;


namespace Emedchina.TradeAssistant.Client.DAL.User
{
    class LoginUserOfflineDao : SqlDAOBase
    {
        private LoginUserOfflineDao()
        : base()
        { }

        private LoginUserOfflineDao(string connectionName)
        : base(connectionName)
        { }

        public static LoginUserOfflineDao GetInstance()
        {
            return new LoginUserOfflineDao();
        }

        public static LoginUserOfflineDao GetInstance(string connectionName)
        {
            return new LoginUserOfflineDao(connectionName);
        }

     

        #region 取得当前用户菜单 离线
        /// <summary>
        /// 取得当前用户菜单　离线
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetMenuOffline(string userId,string clientType)
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
                sql.Append("                        CLIENT_MENU.URL,CLIENT_MENU.SHORTCUT,CLIENT_MENU.IMAGE_M AS IMAGE1,");
                sql.Append("                        CLIENT_MENU.MODIFY_DATE");
                sql.Append("          FROM (Gpo_Usr_User INNER JOIN gpo_usr_user_module ON");
                sql.Append("                Gpo_Usr_User.id = gpo_usr_user_module.user_id)");
                sql.Append("                INNER JOIN CLIENT_MENU ON gpo_usr_user_module.MODULE_ID = CLIENT_MENU.MODULE_ID ");
                sql.Append("         where Gpo_Usr_User.ID = @userId ");
                sql.Append("         and CLIENT_MENU.enable_flag = '1'");
                //判断是否福建项目
                if ("1".Equals(clientType))
                    sql.Append("         and (instr(CLIENT_MENU.client_id,'F') = 0  or CLIENT_MENU.client_id is null or CLIENT_MENU.client_id = '')");
                sql.Append("        union");
                sql.Append("          SELECT distinct CLIENT_MENU.MODULE_ID,");
                sql.Append("                          CLIENT_MENU.ID,");
                sql.Append("                          CLIENT_MENU.SORT_SN,");
                sql.Append("                          CLIENT_MENU.NAME,");
                sql.Append("                          CLIENT_MENU.FATHER,");
                sql.Append("                          CLIENT_MENU.MODULE_ACTION,");
                sql.Append("                          CLIENT_MENU.WEB_FLAG,");
                sql.Append("                          CLIENT_MENU.URL,CLIENT_MENU.SHORTCUT,CLIENT_MENU.IMAGE_M AS IMAGE1,");
                sql.Append("                          CLIENT_MENU.MODIFY_DATE");
                sql.Append("            from CLIENT_MENU");
                sql.Append("           where (CLIENT_MENU.module_id is null or CLIENT_MENU.father = '0')  ");
                sql.Append("         and CLIENT_MENU.enable_flag = '1'");
                //判断是否福建项目
                if ("1".Equals(clientType))
                    sql.Append("         and (instr(CLIENT_MENU.client_id,'F') = 0  or CLIENT_MENU.client_id is null or CLIENT_MENU.client_id = '')");
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
        #endregion


        #region 获取用户机构信息
        /// <summary>
        /// Gets the user org by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserOrg GetUserOrgById(string id)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByIdSql(), id, new MapRow(Map_USR_ORG)) as UserOrg;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSql()
        {
            string _where = @" AND uo.USER_ID = @ID";
            return string.Concat(getSelectAllSqlOrg(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSqlOrg()
        {
            return
            @"SELECT 
                  o.id   AS  id, 
                  o.ORG_NAME   AS  name, 
                  o.ORG_ABBR   AS  abbr,                 
                  o.ORG_PHONE   AS  phone, 
                  o.BUYER_FLAG,
                  o.SENDER_FLAG,
                  o.enable_flag   AS  enable_flag, 
                  o.CREATE_USER_ID   AS  create_user, 
                  o.CREATE_DATE   AS  create_date, 
                  o.MODIFY_USER_ID   AS  last_update_user, 
                  o.MODIFY_DATE   AS  last_update_date 
                FROM HC_USER_ORG    uo,HC_ORG o  WHERE uo.ORG_ID = o.ID ";
        }

        /// <summary>
        /// Maps the GPO_USR_ORG.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object Map_USR_ORG(IDataReader reader, int rowNumber)
        {
            UserOrg _gpo_usr_org = new UserOrg();
            _gpo_usr_org.Id = Convert.ToString(reader["ID"]);

            _gpo_usr_org.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_org.Abbr = Convert.ToString(reader["abbr"]);

            _gpo_usr_org.Phone = Convert.ToString(reader["PHONE"]);
            _gpo_usr_org.IsFactory = Convert.ToString(reader["SENDER_FLAG"]).Equals("1");
            _gpo_usr_org.IsHospital = Convert.ToString(reader["BUYER_FLAG"]).Equals("1");

            _gpo_usr_org.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_org.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_org.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);

            _gpo_usr_org.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _gpo_usr_org.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);

            return _gpo_usr_org;
        }
        #endregion


        #region　判断是否医院
        /// <summary>
        /// 判断是否医院
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
            else
            {
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

        #region 获取买方机构信息
        /// <summary>
        /// Gets the cat buyer by reg buyer id.
        /// </summary>
        /// <param name="regBuyerId">The reg buyer id.</param>
        /// <returns></returns>
        public CatBuyer GetCatBuyerByRegBuyerId(string regBuyerId)
        {
            string sql = "select cb.* from gpo_reg_buyer grb, cat_buyer cb where cb.id = grb.data_buyer_id and grb.id = '" + regBuyerId + "'";
            return base.DbFacade.SQLQueryObjectById(sql, regBuyerId, new MapRow(MapCAT_BUYER)) as CatBuyer;
        }

        /// <summary>
        /// Maps the CAT_BUYER.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapCAT_BUYER(IDataReader reader, int rowNumber)
        {
            CatBuyer _cat_buyer = new CatBuyer();
            _cat_buyer.Id = Convert.ToString(reader["ID"]);
            _cat_buyer.Plat_id = Convert.ToString(reader["PLAT_ID"]);
            _cat_buyer.Org_type = Convert.ToString(reader["ORG_TYPE"]);
            _cat_buyer.Org_kind = Convert.ToString(reader["ORG_KIND"]);
            _cat_buyer.Grade_no = Convert.ToString(reader["GRADE_NO"]);
            _cat_buyer.Org_presider = Convert.ToString(reader["ORG_PRESIDER"]);
            _cat_buyer.Tax_code = Convert.ToString(reader["TAX_CODE"]);
            _cat_buyer.Org_account_name = Convert.ToString(reader["ORG_ACCOUNT_NAME"]);
            _cat_buyer.Org_bank = Convert.ToString(reader["ORG_BANK"]);
            _cat_buyer.Org_account = Convert.ToString(reader["ORG_ACCOUNT"]);
            _cat_buyer.Org_address = Convert.ToString(reader["ORG_ADDRESS"]);
            _cat_buyer.Post_code = Convert.ToString(reader["POST_CODE"]);
            _cat_buyer.Org_phone = Convert.ToString(reader["ORG_PHONE"]);
            _cat_buyer.Org_faxe = Convert.ToString(reader["ORG_FAXE"]);
            _cat_buyer.Org_url = Convert.ToString(reader["ORG_URL"]);
            _cat_buyer.Province_id = Convert.ToString(reader["PROVINCE_ID"]);
            _cat_buyer.City_id = Convert.ToString(reader["CITY_ID"]);
            _cat_buyer.Org_desc = Convert.ToString(reader["ORG_DESC"]);
            _cat_buyer.Link_person = Convert.ToString(reader["LINK_PERSON"]);
            _cat_buyer.Link_phone = Convert.ToString(reader["LINK_PHONE"]);
            _cat_buyer.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);
            _cat_buyer.Create_plat = Convert.ToString(reader["CREATE_PLAT"]);
            _cat_buyer.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            _cat_buyer.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _cat_buyer.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);
            _cat_buyer.Last_update_plat = Convert.ToString(reader["LAST_UPDATE_PLAT"]);
            _cat_buyer.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            _cat_buyer.Synchronized_date = reader["SYNCHRONIZED_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["SYNCHRONIZED_DATE"]);
            _cat_buyer.Clean_date = reader["CLEAN_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CLEAN_DATE"]);
            _cat_buyer.Description = Convert.ToString(reader["DESCRIPTION"]);
            _cat_buyer.Link_email = Convert.ToString(reader["LINK_EMAIL"]);
            _cat_buyer.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _cat_buyer.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _cat_buyer.County_id = Convert.ToString(reader["COUNTY_ID"]);
            _cat_buyer.Sync_state = Convert.ToString(reader["SYNC_STATE"]);
            _cat_buyer.Buyer_kind = Convert.ToString(reader["BUYER_KIND"]);
            _cat_buyer.Subject_flag = Convert.ToString(reader["SUBJECT_FLAG"]);
            _cat_buyer.Medicare_flag = Convert.ToString(reader["MEDICARE_FLAG"]);
            //_cat_buyer.Bed_number = Convert.ToDecimal(reader["BED_NUMBER"]);
            _cat_buyer.Proprietorship = Convert.ToString(reader["PROPRIETORSHIP"]);
            //_cat_buyer.Outpatient_per_day = Convert.ToDecimal(reader["OUTPATIENT_PER_DAY"]);
            //_cat_buyer.Sum_per_person = Convert.ToDecimal(reader["SUM_PER_PERSON"]);
            //_cat_buyer.Salesum_per_year = Convert.ToDecimal(reader["SALESUM_PER_YEAR"]);
            _cat_buyer.Feature_clinic = Convert.ToString(reader["FEATURE_CLINIC"]);
            //_cat_buyer.Doctor_num = Convert.ToDecimal(reader["DOCTOR_NUM"]);
            //_cat_buyer.Clinic_medical_money = Convert.ToDecimal(reader["CLINIC_MEDICAL_MONEY"]);
            //_cat_buyer.Inpatient_num = Convert.ToDecimal(reader["INPATIENT_NUM"]);
            return _cat_buyer;
        }
        #endregion




        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public Emedchina.TradeAssistant.Model.User.UserInfo GetUserInfoById(string userId)
        {
            return base.DbFacade.SQLQueryObjectById(getSelectOneByIdSqUser(), userId, new MapRow(Map_USR_USER)) as UserInfo;
        }

        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Emedchina.TradeAssistant.Model.User.UserInfo GetUserInfoByCode(string code)
        {
            return DbFacade.SQLQueryObjectById(getSelectOneByCodeSql(), code, new MapRow(Map_USR_USER)) as UserInfo;
        }


        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Emedchina.TradeAssistant.Model.User.UserInfo GetUserInfoByName(string name)
        {
            return base.DbFacade.SQLQueryObjectById(getSelectOneByNameSql(), name, new MapRow(Map_USR_USER)) as UserInfo;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByIdSqUser()
        {
            string _where = @" WHERE  u.id = @ID";
            return string.Concat(getSelectAllSqlUser(), _where);
        }

        /// <summary>
        /// Gets the select one by code SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByCodeSql()
        {
            string _where = @" WHERE  u.mail = @ID";
            return string.Concat(getSelectAllSqlUser(), _where);
        }

        /// <summary>
        /// Gets the select one by name SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectOneByNameSql()
        {
            string _where = @" WHERE  u.mail = @ID";
            return string.Concat(getSelectAllSqlUser(), _where);
        }


        private string getSelectAllSqlUser()
        {
            return
            @"SELECT 
              ID ,
              MAIL,
              NAME,
              PASSWORD,
              ADMIN_LEVEL,
              DESCRIPTION,
              ENABLE_FLAG,
              REMARK,
              CREATE_USER,
              CREATE_NAME,
              CREATE_DATE,
              MODIFY_USER,
              MODIFY_NAME,
              MODIFY_DATE,
              CA_FLAG,
              KEY_FLAG,
              PW_FLAG, 
              LOGIN_DATE
            FROM cen_usr_user u ";

        }


        /// <summary>
        /// Maps the GPO_USR_USER table
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object Map_USR_USER(IDataReader reader, int rowNumber)
        {
            UserInfo _gpo_usr_user = new UserInfo();
            _gpo_usr_user.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_user.Code = Convert.ToString(reader["Mail"]);
            _gpo_usr_user.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_user.Password = Convert.ToString(reader["PASSWORD"]);

            _gpo_usr_user.Describe = Convert.ToString(reader["REMARK"]);
            _gpo_usr_user.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_user.Admin_flag = Convert.ToString(reader["ADMIN_LEVEL"]);

            _gpo_usr_user.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_user.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);

            _gpo_usr_user.Last_update_user = Convert.ToString(reader["MODIFY_USER"]);
            _gpo_usr_user.Last_update_date = reader["MODIFY_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["MODIFY_DATE"]);

            _gpo_usr_user.Login_date = reader["LOGIN_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LOGIN_DATE"]);
            return _gpo_usr_user;
        }



        /// <summary>
        /// Gets the user role by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public UserRole GetUserRoleById(string id)
        {
            return DbFacade.SQLQueryObjectById(getRoleByIdSql(), id, new MapRow(MapGPO_USR_ROLE)) as UserRole;
        }

        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getRoleByIdSql()
        {
            string _where = @" WHERE  uro.id = @ID";
            return string.Concat(getSelectAllSqlRole(), _where);
        }

        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSqlRole()
        {
            return @"SELECT 
                      uro.id   AS  id, 
                      uro.name   AS  name, 
                      uro.type_name   AS  type_name, 
                      uro.type   AS  type, 
                      uro.sort   AS  sort, 
                      uro.enable_flag   AS  enable_flag, 
                      uro.create_user   AS  create_user, 
                      uro.create_date   AS  create_date, 
                      uro.create_org   AS  create_org, 
                      uro.last_update_user   AS  last_update_user, 
                      uro.last_update_date   AS  last_update_date, 
                      uro.last_update_org   AS  last_update_org  
                    FROM GPO_USR_ROLE    uro ";
        }

        /// <summary>
        /// Maps the GPO_USR_ROLE.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapGPO_USR_ROLE(IDataReader reader, int rowNumber)
        {
            UserRole _gpo_usr_role = new UserRole();
            _gpo_usr_role.Id = Convert.ToString(reader["ID"]);
            _gpo_usr_role.Name = Convert.ToString(reader["NAME"]);
            _gpo_usr_role.Type_name = Convert.ToString(reader["TYPE_NAME"]);
            _gpo_usr_role.Type = Convert.ToString(reader["TYPE"]);
            _gpo_usr_role.Sort = Convert.ToString(reader["SORT"]);
            //_gpo_usr_role.Region_id = Convert.ToString(reader["REGION_ID"]);
            _gpo_usr_role.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            _gpo_usr_role.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _gpo_usr_role.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);
            //_gpo_usr_role.Create_region = Convert.ToString(reader["CREATE_REGION"]);
            _gpo_usr_role.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            _gpo_usr_role.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            _gpo_usr_role.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);
            //_gpo_usr_role.Last_update_region = Convert.ToString(reader["LAST_UPDATE_REGION"]);
            _gpo_usr_role.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            return _gpo_usr_role;
        }


        /// <summary>
        /// Gets the user region range by userid.
        /// </summary>
        /// <param name="userId">The id.</param>
        /// <returns></returns>
        public UserArea GetUserAreaByUserId(string userId)
        {
            return DbFacade.SQLQueryObjectById(getAreaByIdSql(), userId, new MapRow(MapGPO_USR_USER_AREA)) as UserArea;
        }



        /// <summary>
        /// Gets the select one by id SQL.
        /// </summary>
        /// <returns></returns>
        private string getAreaByIdSql()
        {
            string _where = @" WHERE  uua.USER_ID = @ID";
            return string.Concat(getSelectAllSqlArea(), _where);
        }



        /// <summary>
        /// Gets the select all SQL.
        /// </summary>
        /// <returns></returns>
        private string getSelectAllSqlArea()
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

        /// <summary>
        /// 去用户数量

        /// </summary>
        /// <returns></returns>
        public int GetUserCount(string userCode)
        {
            int count;
            object obj = null;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT count(*) FROM cen_usr_user where  mail = '");
            sql.Append(userCode).Append("' ");
            try
            {
                obj = DbFacade.SQLExecuteScalar(sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (obj != null)
                count = (int)obj;
            else
                count = 0;
            return count;
        }


        public DataTable GetMenuOfflineTest(string userId, string clientType)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("select * from hc_client_menu ");

                sql.Append(" ORDER BY SORT_SN");
                

                dt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
    }
}
