//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	StockListBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	经常采购目录维护（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 经常采购目录维护（业务操作类）
    /// </summary>
    class StockListBLL
    {
        StockListDao dao = null;

        private StockListBLL()
        {
            dao = StockListDao.GetInstance();
        }

        public static StockListBLL GetInstance()
        {
            return new StockListBLL();
        }

        private StockListBLL(string connectionName)
        {
            dao = StockListDao.GetInstance(connectionName);
        }

        public static StockListBLL GetInstance(String strConnectionn)
        {
            return new StockListBLL(strConnectionn);
        }

        /// <summary>
        /// 获取经常采购目录信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStockList(LogedInUser logedinUser, string ProjectID, string strDataName)
        {
            try
            {
                return dao.GetStockList(logedinUser, ProjectID, strDataName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取采购目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public OrdHitCommMode GetOrdHitCommModel(string HitCommID)
        {
            try
            {
                return dao.GetOrdHitCommModel(HitCommID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存采购目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void SaveOrdHitCommListModel(List<OrdHitCommMode> ListModel, LogedInUser logedinUser)
        {
            try
            {
                dao.SaveOrdHitCommListModel(ListModel, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除采购供应目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void DelOrdHitCommModel(string strId)
        {
            try
            {
                dao.DelOrdHitCommModel(strId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存采购目录信息（库房、配送商）
        /// </summary>
        /// <param name="model"></param>
        public void PostOrdHitCommInfo(OrdHitCommMode model, LogedInUser logedinUser)
        {
            try
            {
                dao.PostOrdHitCommInfo(model, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
