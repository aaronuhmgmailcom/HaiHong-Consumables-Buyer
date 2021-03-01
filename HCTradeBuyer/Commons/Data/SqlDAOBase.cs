using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using IBatisNet.Common.Logging;
using System.Data;
using System.Data.Common;

namespace Emedchina.Commons.Data
{
    /// <summary>
    /// 提供一个访问Sql server数据库基类，封装了数据访问需要的基础结构，包括DataBaseFacade（通过DbFacade属性访问） 和 Database（通过RowDatabase属性访问）。

    /// 同时提供了日志和分页
    /// </summary>
    public abstract class SqlDAOBase
    {
        /// <summary>
        /// ILog对象,子类可以通过该对象记录日志信息.
        /// </summary>
     
        protected static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataBaseFacade dbFacade = null;
        public static readonly String SEQ_ORDER = "ORDR";	//订单系统
        
        public static readonly String SEQ_GPO = "SEQ_GPO_USR";	//序列名 刘海超2007-8-16

        protected SqlDAOBase()
        {
            dbFacade = DataBaseFacade.GetInstance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AccessDAOBase"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.可以为空。</param>
        protected SqlDAOBase(string connectionName)
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

        #region paged sql

        /// <summary>
        /// Gets the count SQL.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        protected virtual string GetCountSql(string rawSql)
        {
            return SqlHelper.GetCountSql(rawSql);
        }

        protected virtual int GetRowCount(string rawSql, params IDbDataParameter[] parameters)
        {
            return Convert.ToInt32(DbFacade.SQLExecuteScalar(GetCountSql(rawSql), parameters));
        }



        /// <summary>
        /// Gets the paged SQL.注意这样获取的sql没有页面的绑定参数，而是直接将最高和最低的记录号拼入sql
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        protected virtual string GetPagedSql(string sRawSql, string sPrimaryKey,string sHighRowNum,string sLowRowNum)
        {
            return SqlHelper.GetPagedSql(sRawSql,sPrimaryKey,sHighRowNum,sLowRowNum);
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
            return this.GetPagedSql(rawSql,pageNum,pageSize);
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
        /// 添加Del_Log表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <param name="pkName"></param>
        /// <param name="userId"></param>
        /// <param name="level"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        protected bool addDelLog(string tableName, string id, string pkName, string userId, string level, DbTransaction tran)
        {
            string sql = "insert into DEL_LOG (Table_Name,Id,Pk_Name,CREATE_USERID,Del_Level,sync_state) values('" + tableName + "'," + id + ",'" + pkName + "'," + userId + ",'" + level + "','0')";
            int i = DbFacade.SQLExecuteNonQuery(sql, tran);
            if (i > 0)
                return true;
            else
                return false;
        }        

        #endregion

        //start add by gaoyuan 20070412 Get ID 、Code for offline

        /// <summary>
        /// 获得采购单离线CODE
        /// </summary>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public string GetGlobalPurchaseCode(DbTransaction tran)
        {
            StringBuilder builder1 = new StringBuilder("CK" + DateTime.Now.Year.ToString());
            builder1.Append(DateTime.Now.Month.ToString("##00"));
            builder1.Append(DateTime.Now.Day.ToString("##00"));
            builder1.Append(GetPurchaseCode(tran));
            return builder1.ToString();
        }

        /// <summary>
        /// 获得订单离线CODE
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        public string GetGlobalOrderCode(DbTransaction tran)
        {
            StringBuilder builder1 = new StringBuilder("CK" + DateTime.Now.Year.ToString());
            builder1.Append(DateTime.Now.Month.ToString("##00"));
            builder1.Append(DateTime.Now.Day.ToString("##00"));
            builder1.Append(GetOrderCode(tran));
            return builder1.ToString();
        }

        private string GetPurchaseCode(DbTransaction tran)
        {
            string text1 = "select iif( max(mid(purchase_code,11,15)) is null, '', max(mid(purchase_code,11,15)) + 1 ) from gpo_purchase where purchase_code like 'CK%'";
            string text2 = DbFacade.SQLExecuteScalar(text1, tran).ToString();
            if ((text2 != null) && (text2 != ""))
            {
                return int.Parse(text2).ToString("000000000000000");
            }
            return "000000000000001";
        }
        private string GetOrderCode(DbTransaction tran)
        {
            string text1 = "select iif( max(mid(order_code,11,15)) is null, '', max(mid(order_code,11,15)) + 1 ) from gpo_order where order_code like 'CK%'";
            string text2 = DbFacade.SQLExecuteScalar(text1, tran).ToString();
            if ((text2 != null) && (text2 != ""))
            {
                return int.Parse(text2).ToString("000000000000000");
            }
            return "000000000000001";
        }

        /// <summary>
        /// 获得离线ID
        /// </summary>
        /// <returns></returns>
        public string GetGlobalId()
        {
            string temp = Guid.NewGuid().ToString().GetHashCode().ToString("X") + Guid.NewGuid().ToString().GetHashCode().ToString("X") + Guid.NewGuid().ToString().GetHashCode().ToString("X") + "zzzzzzzzzzzzzzzz";
            return temp.Substring(0, 24).ToUpper();
        }

        //end add by gaoyuan 20070412 Get ID 、Code for offline
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


        /// <summary>
        /// 耗材系统生成离线CODE
        /// </summary> 
        /// <returns></returns>
        public string GetClientCode(int idHigh)
        {
            StringBuilder builder1 = new StringBuilder("K" + DateTime.Now.Year.ToString());
            builder1.Append(idHigh.ToString("0000000"));
            builder1.Append(DateTime.Now.Month.ToString("##00"));
            builder1.Append(DateTime.Now.Day.ToString("##00"));
            builder1.Append(DateTime.Now.Hour.ToString("##00"));
            builder1.Append(DateTime.Now.Minute.ToString("##00"));
            builder1.Append(DateTime.Now.Second.ToString("##00"));
            builder1.Append(DateTime.Now.Millisecond.ToString("##000"));
            return builder1.ToString();
        }
        /// <summary>
        /// 耗材系统产生客户端id
        /// </summary>
        /// <returns></returns>
        public Int64 GetClientId(int idHigh)
        {
            string temp = Guid.NewGuid().ToString().GetHashCode().ToString("X") + Guid.NewGuid().ToString().GetHashCode().ToString("X");
            Int64 id = Convert.ToInt64(idHigh * Math.Pow(10, 13)) + Convert.ToInt64(Convert.ToUInt64(temp, 16).ToString().Substring(0, 13));
            return id;
        }

    }
}
