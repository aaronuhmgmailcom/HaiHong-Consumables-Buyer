//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	CommUtilBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	公共操作（数据访问类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.Client.DAL.Comm
{
    /// <summary>
    /// 公共类    /// </summary>
    class CommUtilDao : SqlDAOBase
    {
        private CommUtilDao()
        : base()
        { }

        private CommUtilDao(string connectionName)
        : base(connectionName)
        { }

        public static CommUtilDao GetInstance()
        {
            return new CommUtilDao();
        }

        public static CommUtilDao GetInstance(string connectionName)
        {
            return new CommUtilDao(connectionName);
        }

        /// <summary>
        /// 根据项目类型获取项目信息
        /// </summary>
        /// <param name="ProjectType"></param>
        /// <returns></returns>
        public DataTable GetProjectInfoByProjectType(string ProjectType)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = new DataTable();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select cast(ID As int) As ID,PROJECT_NAME  From HC_ORD_PROJECT Where 1=1");
            
            if (!string.IsNullOrEmpty(ProjectType))
            {            
                strSql.Append(" And PROJECT_TYPE = @ProjectType");

                DbParameter strProjectType = DbFacade.CreateParameter();
                strProjectType.ParameterName = "ProjectType";
                strProjectType.DbType = DbType.String;
                strProjectType.Value = ProjectType;
                parameters.Add(strProjectType);
            }

            strSql.Append(" Order By ID DESC");

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 根据项目ID获取品种分类信息
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public DataTable GetProductClassInfoByProjectID(string ProjectID)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = new DataTable();

            StringBuilder strSql = new StringBuilder();

            strSql.Append("Select ");
            strSql.Append(" cast(ID As int) As ID,CLASS_NAME,PROJECT_ID ");
            strSql.Append(" From HC_PROJECT_PRODUCT_CLASS");
            strSql.Append(" Where 1=1");

            if (!string.IsNullOrEmpty(ProjectID))
            {
                strSql.Append(" And PROJECT_ID = @PROJECT_ID");

                DbParameter strProjectId = DbFacade.CreateParameter();
                strProjectId.ParameterName = "PROJECT_ID";
                strProjectId.DbType = DbType.String;
                strProjectId.Value = ProjectID;
                parameters.Add(strProjectId);
            }

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), parameters.ToArray());

                DataRow dr = dt.NewRow();
                dr["ID"] = "0";
                dr["CLASS_NAME"] = "全部";

                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 取得高位id
        /// </summary>
        /// <returns></returns>
        public int GetHighID()
        {
            int id;
            object obj;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select High_ID from HC_CLIENT_ID");
            try
            {
                obj = base.DbFacade.SQLExecuteScalar(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (obj != null)
            {
                id = Convert.ToInt32(obj);
            }
            else
            {
                id = -1;
            }
            return id;
        }

        /// <summary>
        /// 保存高位id
        /// </summary>
        /// <param name="highId"></param>
        public void SaveHighID(int highId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HC_CLIENT_ID(high_id) values(").Append(highId).Append(")");
            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取配送商信息
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectProdId"></param>
        /// <returns></returns>
        public DataTable GetSenderInfo(string buyerId, string projectId, string projectProdId)
        {
            DataTable dt = new DataTable();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            Cast(SENDER_ID As bigint) As SENDER_ID,
                            SENDER_ABBR,
                            SENDER_NAME,
                            PROJECT_ID,
                            PROJECT_PROD_ID,
                            BUYER_ID
                            From HC_ORD_BUYER_SENDER Where ENABLE_FLAG = '1'");

            if (!string.IsNullOrEmpty(buyerId))
            {
                strSql.AppendFormat(" And BUYER_ID='{0}'", buyerId);
            }
            if (!string.IsNullOrEmpty(projectId))
            {
                strSql.AppendFormat(" And PROJECT_ID='{0}'", projectId);
            }
            if (!string.IsNullOrEmpty(projectProdId))
            {
                strSql.AppendFormat(" And PROJECT_PROD_ID='{0}'", projectProdId);
            }

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取库房信息
        /// </summary>
        /// <param name="OrgId"></param>
        /// <returns></returns>
        public DataTable GetBuyerStoreInfo(string OrgId)
        {
            DataTable dt = new DataTable();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            Cast(ID As bigint) As STORE_ID,
                            STORE_NAME,
                            ORG_ID
                            From HC_BUYER_STORE Where ENABLE_FLAG = '1'");

            if (!string.IsNullOrEmpty(OrgId))
            {
                strSql.AppendFormat(" And ORG_ID='{0}'", OrgId);
            }

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取规格信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSpecInfo()
        {
            DataTable dt = new DataTable();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            ID As SPEC_ID,
                            SPEC_NAME
                            From HC_ORD_PRODUCT_SPEC");

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取型号信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetModelInfo()
        {
            DataTable dt = new DataTable();

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            ID As MODEL_ID,
                            MODEL_NAME
                            From HC_ORD_PRODUCT_MODEL");

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

    }
}
