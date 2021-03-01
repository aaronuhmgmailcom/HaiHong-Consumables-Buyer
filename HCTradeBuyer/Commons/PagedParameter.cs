#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/PagedParameter.cs 2     06-06-29 9:35 Liangxy $
 * $Author: Liangxy $Revision: 1.1 $
 * $Date: 06-06-29 9:35 $
 ********************************************************************************/
#endregion

#region usingusing System;
using System.Collections.Generic;
using System.Text;
using System;

#endregion

namespace Emedchina.Commons
{

    [Serializable]
    public class PagedParameter
    {
        private string _pageNum;
        private string _pageSize;
        private string _sort;
        private string _sortMethod;



        public string PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public string PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public string Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        public string SortMethod
        {
            get { return _sortMethod; }
            set { _sortMethod = value; }
        }
    }
}
