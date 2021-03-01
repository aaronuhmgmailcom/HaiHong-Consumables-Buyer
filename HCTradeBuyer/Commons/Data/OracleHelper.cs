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
    /// �ض���Oracle�İ�����
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
        /// ��ȡ��Ӧ��Oracle�ķ�ҳ��ѯsql
        /// </summary>
        /// <param name="rawSql">The raw SQL.</param>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public static string GetPagedSql(string rawSql, int pageNum, int pageSize)
        {
            int iLow = PageUtils.GetLowIndexOfPage(pageNum, pageSize);//��¼������
            int iHigh = PageUtils.GetHighIndexOfPage(pageNum, pageSize);//��¼������
            string sql = string.Format("select * from ( select row_.*, rownum rownum_ from ( {0} ) row_ where rownum <= {1}) where rownum_ >= {2}", rawSql, iHigh, iLow);

            return sql;
        }

        /// <summary>
        /// ��ȡ��Ӧ��Oracle�ķ�ҳ��ѯsql,��sql��Ҫ�û��Լ���:highRowNum(��ҳ������¼����)��:lowRowNum(��ҳ����С��¼����)����.
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
