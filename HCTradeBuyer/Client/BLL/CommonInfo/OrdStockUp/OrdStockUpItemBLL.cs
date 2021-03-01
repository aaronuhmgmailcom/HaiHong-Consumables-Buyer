//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdStockUpItemBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	备货单明细（业务操作类）
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
    /// 备货单明细（业务操作类）
    /// </summary>
    class OrdStockUpItemBLL
    {
        OrdStockUpItemDao dao = null;

        private OrdStockUpItemBLL()
        {
            dao = OrdStockUpItemDao.GetInstance();
        }

        public static OrdStockUpItemBLL GetInstance()
        {
            return new OrdStockUpItemBLL();
        }

        private OrdStockUpItemBLL(string connectionName)
        {
            dao = OrdStockUpItemDao.GetInstance(connectionName);
        }

        public static OrdStockUpItemBLL GetInstance(String strConnectionn)
        {
            return new OrdStockUpItemBLL(strConnectionn);
        }

        /// <summary>
        /// 获取备货单明细信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStockUpItemList(string stock_Id)
        {
            try
            {
                return dao.GetStockUpItemList(stock_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据备货单明细ID 获取备货单明细记录对象
        /// </summary>
        /// <param name="stock_Id"></param>
        public OrdStockUpItemModel GetOrdStockUpItemModel(string stock_Item_Id)
        {
            try
            {
                return dao.GetOrdStockUpItemModel(stock_Item_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 设置备货单明细状态 根据明细ID修改
        /// </summary>
        /// <param name="stock_Item_Id"></param>
        /// <param name="State"></param>
        public bool SetOrdStockUpItemState(string stock_Item_Id, string State, DbTransaction transaction)
        {
            try
            {
                return dao.SetOrdStockUpItemState(stock_Item_Id, State, transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改备货单明细条码
        /// </summary>
        /// <param name="stockItemId"></param>
        public void UpdateBarcodeOrdStockUpItemList(List<OrdStockUpItemModel> ListModel, string strStockUpID)
        {
            try
            {
                dao.UpdateBarcodeOrdStockUpItemList(ListModel, strStockUpID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
