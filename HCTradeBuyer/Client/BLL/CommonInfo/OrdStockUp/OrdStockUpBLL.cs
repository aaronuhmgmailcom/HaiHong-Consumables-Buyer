//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdStockUpBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单确认（业务操作类）
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
    /// 备货单确认（业务操作类）
    /// </summary>
    class OrdStockUpBLL
    {
        OrdStockUpDao dao = null;

        private OrdStockUpBLL()
        {
            dao = OrdStockUpDao.GetInstance();
        }

        public static OrdStockUpBLL GetInstance()
        {
            return new OrdStockUpBLL();
        }

        private OrdStockUpBLL(string connectionName)
        {
            dao = OrdStockUpDao.GetInstance(connectionName);
        }

        public static OrdStockUpBLL GetInstance(String strConnectionn)
        {
            return new OrdStockUpBLL(strConnectionn);
        }

        /// <summary>
        /// 获取备货单信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStockUpList(LogedInUser logedinUser)
        {
            try
            {
                return dao.GetStockUpList(logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据备货单ID 获取备货单记录对象
        /// </summary>
        /// <param name="stock_Id"></param>
        public OrdStockUpModel GetOrdStockUpModel(string stock_Id)
        {
            try
            {
                return dao.GetOrdStockUpModel(stock_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置备货单状态
        /// </summary>
        /// <param name="stock_Id"></param>
        public void SetOrdStockUpState(string stock_Id, string State, string ItemState)
        {
            try
            {
                dao.SetOrdStockUpState(stock_Id,State,ItemState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
