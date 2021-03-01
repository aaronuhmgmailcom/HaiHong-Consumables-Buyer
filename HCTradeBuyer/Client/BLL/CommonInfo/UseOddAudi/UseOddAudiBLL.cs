//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	UseOddAudiBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	二级库存使用(业务操作类)
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
    /// 二级库存使用(业务操作类)
    /// </summary>
    class UseOddAudiBLL : SqlDAOBase
    {
        UseOddAudiDao dao = null;

        private UseOddAudiBLL()
        {
            dao = UseOddAudiDao.GetInstance();
        }

        public static UseOddAudiBLL GetInstance()
        {
            return new UseOddAudiBLL();
        }

        private UseOddAudiBLL(string connectionName)
        {
            dao = UseOddAudiDao.GetInstance(connectionName);
        }

        public static UseOddAudiBLL GetInstance(String strConnectionn)
        {
            return new UseOddAudiBLL(strConnectionn);
        }

        /// <summary>
        /// 获取库存商品列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdSecondAyplnvList(LogedInUser logedinUser)
        {
            try
            {
                return dao.GetOrdSecondAyplnvList(logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取消耗商品列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetConsumeCommList()
        {
            try
            {
                return dao.GetConsumeCommList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改二级库存表信息 状态置为 0 （状态：0	禁用  ,1 正常）
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdSecondAyplnvModel(List<OrdSecondAyrlnvUseModel> Listmodel, LogedInUser logedinUser)
        {
            try
            {
                dao.ModifyOrdSecondAyplnvModel(Listmodel, logedinUser);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
