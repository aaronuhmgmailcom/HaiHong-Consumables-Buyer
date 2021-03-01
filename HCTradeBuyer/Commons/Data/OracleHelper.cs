#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data/OracleHelper.cs 6     06-06-27 11:08 Sunhl $
 * $Author: Sunhl $
 * $Revision: 6 $
 * $Date: 06-06-27 11:08 $
 * $History: OracleHelper.cs $
 * 
 * *****************  Version 6  *****************
 * User: Sunhl        Date: 06-06-27   Time: 11:08
 * Updated in $/TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data
 ********************************************************************************/
#endregion

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
    /// 特定于Oracle的帮助类
    /// </summary>
    public class OracleHelper
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
        public static string GetPagedSql(string rawSql, int pageNum, int pageSize)
        {
            int iLow = PageUtils.GetLowIndexOfPage(pageNum, pageSize);//记录号下限
            int iHigh = PageUtils.GetHighIndexOfPage(pageNum, pageSize);//记录号上限
            string sql = string.Format("select * from ( select row_.*, rownum rownum_ from ( {0} ) row_ where rownum <= {1}) where rownum_ >= {2}", rawSql, iHigh, iLow);

            return sql;
        }

        /// <summary>
        /// 获取对应于Oracle的分页查询sql,该sql需要用户自己绑定:highRowNum(该页的最大记录行数)和:lowRowNum(该页的最小记录行数)参数.
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <returns></returns>
        public static string GetPagedSql(string rawSql)
        {
            string sql = string.Format("select * from ( select row_.*, rownum rownum_ from ( {0} ) row_ where rownum <= :highRowNum) where rownum_ >= :lowRowNum", rawSql);

            return sql;
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
            return string.Format("SELECT COUNT(1) FROM ({0}) T", rawSql);
        }
        #endregion

        
    }
}
