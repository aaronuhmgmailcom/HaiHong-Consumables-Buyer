#region Header
/*****************************************************************************
 * $Author: <a href="mailto:sunhl@staff.emedchina.net">�����(sunhl)</a>
 * $Revision: 1.0 $
 * $Date: 2006-6-20 $
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Emedchina.Commons
{
    /// <summary>
    /// ��ҳ��صķ���
    /// </summary>
    public class PageUtils
    {
        /// <summary>
        /// Gets the low index of page.
        /// iLow = (pageNum - 1) * pageSize + 1;//��¼������
        /// </summary>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public static int GetLowIndexOfPage(int pageNum, int pageSize)
        {
            if (pageNum <= 0)
                pageNum = 1;
            int iLow = (pageNum - 1) * pageSize + 1;//��¼������
            return iLow;
        }

        /// <summary>
        /// Gets the high index of page.
        /// iHigh = pageNum * pageSize;//��¼������
        /// </summary>
        /// <param name="pageNum">The page num.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public static int GetHighIndexOfPage(int pageNum, int pageSize)
        {
            if (pageNum <= 0)
                pageNum = 1;
            int iHigh = pageNum * pageSize;//��¼������
            return iHigh;
        }
    }
}
