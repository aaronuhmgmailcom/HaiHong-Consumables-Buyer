//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	QueryOrderItemBLL.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-28
//	功能描述:	订单商品信息（业务操作类）
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.DataMaintenance;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;
using Emedchina.TradeAssistant.Client.DAL.DataMaintenance;
using Emedchina.TradeAssistant.Client.DAL.TradeManage;

namespace Emedchina.TradeAssistant.Client.BLL.TradeManage
{
    /// <summary>
    /// 库房信息（业务操作类）
    /// </summary>
    public class QueryOrderItemBLL
    {
        QueryOrderItemDAO dao = null;

        private QueryOrderItemBLL()
        {
            dao = QueryOrderItemDAO.GetInstance();
        }

        public static QueryOrderItemBLL GetInstance()
        {
            return new QueryOrderItemBLL();
        }

        private QueryOrderItemBLL(string connectionName)
        {
            dao = QueryOrderItemDAO.GetInstance(connectionName);
        }

        public static QueryOrderItemBLL GetInstance(String strConnectionn)
        {
            return new QueryOrderItemBLL(strConnectionn);
        }

        /// <summary>
        /// 获取订单商品信息数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetQueryOrderItemInfoDt(LogedInUser logedinUser)
        {
            try
            {
                return dao.GetQueryOrderItemInfoDt(logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
