//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	SecondAyplnvBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	二级库存（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 二级库存（业务操作类）
    /// </summary>
    class SecondAyplnvBLL : SqlDAOBase
    {
        SecondAyplnvDao dao = null;

        private SecondAyplnvBLL()
        {
            dao = SecondAyplnvDao.GetInstance();
        }

        public static SecondAyplnvBLL GetInstance()
        {
            return new SecondAyplnvBLL();
        }

        private SecondAyplnvBLL(string connectionName)
        {
            dao = SecondAyplnvDao.GetInstance(connectionName);
        }

        public static SecondAyplnvBLL GetInstance(String strConnectionn)
        {
            return new SecondAyplnvBLL(strConnectionn);
        }

        /// <summary>
        /// 保存二级库存对象
        /// </summary>
        /// <param name="ListModel"></param>
        /// <returns></returns>
        public void SaveOrdSecondAyplnvModel(List<OrdSecondAyplnvModel> ListModel, LogedInUser logedinUser)
        {
            try
            {
                dao.SaveOrdSecondAyplnvModel(ListModel, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
