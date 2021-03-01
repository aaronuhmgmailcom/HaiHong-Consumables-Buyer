//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OosQueryBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	缺货查询（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 缺货查询（业务操作类）
    /// </summary>
    class OosQueryBLL
    {
        OosQueryDao dao = null;

        private OosQueryBLL()
        {
            dao = OosQueryDao.GetInstance();
        }

        public static OosQueryBLL GetInstance()
        {
            return new OosQueryBLL();
        }

        private OosQueryBLL(string connectionName)
        {
            dao = OosQueryDao.GetInstance(connectionName);
        }

        public static OosQueryBLL GetInstance(String strConnectionn)
        {
            return new OosQueryBLL(strConnectionn);
        }

        /// <summary>
        /// 获取商品缺货信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOosProductInfo(LogedInUser logedinUser, string ProjectID)
        {
            try
            {
                return dao.GetOosProductInfo(logedinUser, ProjectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
