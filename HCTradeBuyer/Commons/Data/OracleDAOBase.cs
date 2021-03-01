#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler1.2.root/TradeAssistantSaler/Commons/Data/OracleDAOBase.cs 10    06-09-13 11:07 Sunhl $
 * $Author: Sunhl $
 * $Revision: 10 $
 * $Date: 06-09-13 11:07 $
 * $History: OracleDAOBase.cs $
 * 
 * *****************  Version 10  *****************
 * User: Sunhl        Date: 06-09-13   Time: 11:07
 * Updated in $/TradeAssistantSaler1.2.root/TradeAssistantSaler/Commons/Data
 * GetHigtIndexOfPage->GetHighIndexOfPage
 * 
 * *****************  Version 8  *****************
 * User: Sunhl        Date: 06-06-27   Time: 11:08
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Emedchina.Commons;
using IBatisNet.Common.Logging;
#endregion


namespace Emedchina.Commons.Data
{
    /// <summary>
    /// 提供一个基类，封装了数据访问需要的基础结构，包括DataBaseFacade（通过DbFacade属性访问） 和 Database（通过RowDatabase属性访问）。
    /// 同时提供了日志和分页，通过序列获取id等基础功能的支持。
    /// </summary>
    public abstract class OracleDAOBase
    {
        public static readonly String SEQ_ORDER = "ORDR";	//订单系统
        public static readonly String SEQ_GPO = "SEQ_GPO_USR";	//序列名
        /// <summary>
        /// ILog对象,子类可以通过该对象记录日志信息.
        /// </summary>
        protected static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataBaseFacade dbFacade = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OracleDAOBase"/> class.
        /// </summary>
        protected OracleDAOBase()
        {
            dbFacade = DataBaseFacade.GetInstance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OracleDAOBase"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.可以为空。</param>
        protected OracleDAOBase(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                dbFacade = DataBaseFacade.GetInstance();
            else
                dbFacade = DataBaseFacade.GetInstance(connectionName);
        }

        /// <summary>
        /// Gets the db facade.
        /// </summary>
        /// <value>The db facade.</value>
        protected DataBaseFacade DbFacade
        {
            get
            {
                if (dbFacade == null)
                    dbFacade = DataBaseFacade.GetInstance();
                return dbFacade;
            }
        }

        /// <summary>
        /// Gets the row database.
        /// </summary>
        /// <value>The row database.</value>
        protected Database RowDatabase
        {
            get { return DbFacade.RowDatabase; }
        }

        #region ID gen
        /// <summary>
        /// 通过序列获取Id
        /// </summary>
        /// <returns>序列产生的新Id</returns>
        protected virtual string GenId()
        {
            String id = string.Empty;

            String sql = OracleHelper.GenIdFromSequece("TRADE000", "s_id");

            return DbFacade.SQLQueryForScalar(sql, null) as string;
        }

        /// <summary>
        /// 通过序列获取Id
        /// </summary>
        /// <returns>序列产生的新Id</returns>
        protected virtual string GenId(string prefix, string sequece)
        {
            String id = string.Empty;

            String sql = OracleHelper.GenIdFromSequece(prefix, sequece);

            return DbFacade.SQLQueryForScalar(sql, null) as string;
        }
        #endregion

        #region paged sql
        /// <summary>
        /// Gets the paged SQL.注意这样获取的sql没有页面的绑定参数，而是直接将最高和最低的记录号拼入sql
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        protected virtual string GetPagedSql(string rawSql, int pageNum, int pageSize)
        {
            return OracleHelper.GetPagedSql(rawSql, pageNum, pageSize);
        }

        /// <summary>
        /// Gets the paged SQL.注意这样获取的sql没有页面的绑定参数，而是直接将最高和最低的记录号拼入sql.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        protected virtual string GetPagedSql(string rawSql, string pageNum, string pageSize)
        {
            return this.GetPagedSql(rawSql, Convert.ToInt32(pageNum), Convert.ToInt32(pageSize));
        }

        /// <summary>
        /// 获取对应于Oracle的分页查询sql,该sql需要用户自己绑定:highRowNum(该页的最大记录行数)和:lowRowNum(该页的最小记录行数)参数.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        protected virtual string GetPagedSql(string rawSql)
        {
            return OracleHelper.GetPagedSql(rawSql);
        }

        /// <summary>
        /// Gets the low index of page.
        /// iLow = (pageNum - 1) * pageSize + 1;//记录号下限
        /// </summary>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        /// <see cref="OracleHelper.GetLowIndexOfPage"/>
        protected virtual int GetLowIndexOfPage(int pageNum, int pageSize)
        {
            return PageUtils.GetLowIndexOfPage(pageNum, pageSize);
        }

        /// <summary>
        /// Gets the higt index of page.
        /// iHigh = pageNum * pageSize;//记录号上限
        /// </summary>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        /// <see cref="OracleHelper.GetHighIndexOfPage"/>
        protected virtual int GetHighIndexOfPage(int pageNum, int pageSize)
        {
            return PageUtils.GetHighIndexOfPage(pageNum, pageSize);
        }

        /// <summary>
        /// Gets the count SQL.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        protected virtual string GetCountSql(string rawSql)
        {
            return OracleHelper.GetCountSql(rawSql);
        }

        protected virtual int GetRowCount(string rawSql, params IDbDataParameter[] parameters)
        {
            return Convert.ToInt32(DbFacade.SQLExecuteScalar(GetCountSql(rawSql), parameters));
        }
        #endregion
        /// <summary>
        /// 获取订单系统的序列
        /// </summary>
        /// <returns></returns>
        protected String GetOrderId()
        {
            return GetNewId(SEQ_ORDER);
        }
        /// <summary>
        /// 获取默认序列的ID
        /// </summary>
        /// <param name="type">序列前缀</param>
        /// <returns></returns>
        protected String GetNewId(String type)
        {
            string sql = "SELECT :TYPE||LPAD(s_id.NEXTVAL, 20, '0') AS ID FROM DUAL ";
            DbParameter paramType = DbFacade.CreateParameter();
            paramType.ParameterName = "TYPE";
            paramType.DbType = DbType.String;
            paramType.Value = "DEMO";
            return DbFacade.SQLExecuteScalar(sql, paramType).ToString();

        }
        /// <summary>
        /// 获取指定序列的ID
        /// </summary>
        /// <param name="type">序列前缀</param>
        /// <param name="seq">序列名</param>
        /// <returns></returns>
        protected String GetNewId(String type, string seq)
        {
            string sql = "SELECT :TYPE||LPAD(" + seq + ".NEXTVAL, 20, '0') AS ID FROM DUAL ";
            DbParameter paramType = DbFacade.CreateParameter();
            paramType.ParameterName = "TYPE";
            paramType.DbType = DbType.String;
            paramType.Value = type;
            return DbFacade.SQLExecuteScalar(sql, paramType).ToString();
        }
    }
}
