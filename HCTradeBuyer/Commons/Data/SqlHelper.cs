
#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
#endregion

namespace Emedchina.Commons.Data
{
    /// <summary>
    /// 特定于Sql的帮助类
    /// </summary>
    public class SqlHelper
    {

        #region gen id from sequence
        /// <summary>
        /// Gens the id from sequece.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        public static string GenIdFromSequece(string prefix, string sequence)
        {
            return string.Format("select '{0}'||lpad({1}.nextval,16,'0') from dual", prefix, sequence);
        }
        #endregion

        #region paged select
        /// <summary>
        /// 获取对应于Oracle的分页查询sql
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        //public static string GetPagedSql(string rawSql, int pageNum, int pageSize)
        //{
        //    int iLow = PageUtils.GetLowIndexOfPage(pageNum, pageSize);//记录号下限
        //    int iHigh = PageUtils.GetHighIndexOfPage(pageNum, pageSize);//记录号上限
        //    string sql = string.Format("select * from ( select row_.*, rownum rownum_ from ( {0} ) row_ where rownum <= {1}) where rownum_ >= {2}", rawSql, iHigh, iLow);

        //    return sql;
        //}

        /// <summary>
        /// 获取对应于Oracle的分页查询sql,该sql需要用户自己绑定:highRowNum(该页的最大记录行数)和:lowRowNum(该页的最小记录行数)参数.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        public static string GetPagedSql(string sRawSql, string sPrimaryKey,string sHighRowNum,string sLowRowNum)
        {
            sRawSql = sRawSql.Insert(6," ROW_NUMBER() over ( order by " +sPrimaryKey +"   ) as rownum, ");
            string sql = string.Format("select * from ({0} ) t  where t.rownum <= '{1}') and t.rownum >= '{2}'", sRawSql, sHighRowNum, sLowRowNum);

            return sRawSql;
        }

        #endregion

        #region count sql
        /// <summary>
        /// Gets the count SQL.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        public static string GetCountSql(string rawSql)
        {          
            rawSql = rawSql.Insert(6, " top 100 percent ");
            return string.Format("select count(1) from ({0}) t", rawSql);
        }
        #endregion


    }
}
