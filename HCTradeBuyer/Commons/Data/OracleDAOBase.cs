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
    /// �ṩһ�����࣬��װ�����ݷ�����Ҫ�Ļ����ṹ������DataBaseFacade��ͨ��DbFacade���Է��ʣ� �� Database��ͨ��RowDatabase���Է��ʣ���
    /// ͬʱ�ṩ����־�ͷ�ҳ��ͨ�����л�ȡid�Ȼ������ܵ�֧�֡�
    /// </summary>
    public abstract class OracleDAOBase
    {
        public static readonly String SEQ_ORDER = "ORDR";	//����ϵͳ
        public static readonly String SEQ_GPO = "SEQ_GPO_USR";	//������
        /// <summary>
        /// ILog����,�������ͨ���ö����¼��־��Ϣ.
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
        /// <param name="connectionName">Name of the connection.����Ϊ�ա�</param>
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
        /// ͨ�����л�ȡId
        /// </summary>
        /// <returns>���в�������Id</returns>
        protected virtual string GenId()
        {
            String id = string.Empty;

            String sql = OracleHelper.GenIdFromSequece("TRADE000", "s_id");

            return DbFacade.SQLQueryForScalar(sql, null) as string;
        }

        /// <summary>
        /// ͨ�����л�ȡId
        /// </summary>
        /// <returns>���в�������Id</returns>
        protected virtual string GenId(string prefix, string sequece)
        {
            String id = string.Empty;

            String sql = OracleHelper.GenIdFromSequece(prefix, sequece);

            return DbFacade.SQLQueryForScalar(sql, null) as string;
        }
        #endregion

        #region paged sql
        /// <summary>
        /// Gets the paged SQL.ע��������ȡ��sqlû��ҳ��İ󶨲���������ֱ�ӽ���ߺ���͵ļ�¼��ƴ��sql
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
        /// Gets the paged SQL.ע��������ȡ��sqlû��ҳ��İ󶨲���������ֱ�ӽ���ߺ���͵ļ�¼��ƴ��sql.
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
        /// ��ȡ��Ӧ��Oracle�ķ�ҳ��ѯsql,��sql��Ҫ�û��Լ���:highRowNum(��ҳ������¼����)��:lowRowNum(��ҳ����С��¼����)����.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        protected virtual string GetPagedSql(string rawSql)
        {
            return OracleHelper.GetPagedSql(rawSql);
        }

        /// <summary>
        /// Gets the low index of page.
        /// iLow = (pageNum - 1) * pageSize + 1;//��¼������
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
        /// iHigh = pageNum * pageSize;//��¼������
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
        /// ��ȡ����ϵͳ������
        /// </summary>
        /// <returns></returns>
        protected String GetOrderId()
        {
            return GetNewId(SEQ_ORDER);
        }
        /// <summary>
        /// ��ȡĬ�����е�ID
        /// </summary>
        /// <param name="type">����ǰ׺</param>
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
        /// ��ȡָ�����е�ID
        /// </summary>
        /// <param name="type">����ǰ׺</param>
        /// <param name="seq">������</param>
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
