//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdSecondAyrlnvUseBLL.cs   
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
    class OrdSecondAyrlnvUseBLL
    {
        OrdSecondAyrlnvUseDao dao = null;

        private OrdSecondAyrlnvUseBLL()
        {
            dao = OrdSecondAyrlnvUseDao.GetInstance();
        }

        public static OrdSecondAyrlnvUseBLL GetInstance()
        {
            return new OrdSecondAyrlnvUseBLL();
        }

        private OrdSecondAyrlnvUseBLL(string connectionName)
        {
            dao = OrdSecondAyrlnvUseDao.GetInstance(connectionName);
        }

        public static OrdSecondAyrlnvUseBLL GetInstance(String strConnectionn)
        {
            return new OrdSecondAyrlnvUseBLL(strConnectionn);
        }

        /// <summary>
        /// 保存二级使用库存对象
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="logedinUser"></param>
        public void SaveOrdSecondAyplnvModel(List<OrdSecondAyrlnvUseModel> Listmodel, LogedInUser logedinUser)
        {
            try
            {
                dao.SaveOrdSecondAyplnvModel(Listmodel,logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改二级使用库存状态 0 删除 1 使用 2 审核通过（加入事务处理）
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        /// <param name="logedinUser"></param>
        public void ModifyOrdSecondAyplnvUseState(List<OrdSecondAyrlnvUseModel> Listmodel, string State, LogedInUser logedinUser)
        {
            try
            {
                dao.ModifyOrdSecondAyplnvUseState(Listmodel, State, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 【发货流程】  操作表有（采购单、采购单明细、订单表、订单明细、备货表、到货表、订单结果表、日志）
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="ordPurchaseModel"></param>
        /// <param name="logedinUser"></param>
        public void OrdInvoiceFrom(List<OrdSecondAyrlnvUseModel> Listmodel, OrdPurchaseModel ordPurchaseModel, OrdOrderModel ordOrderModel, LogedInUser logedinUser)
        {
            try
            {
                dao.OrdInvoiceFrom(Listmodel,ordPurchaseModel,ordOrderModel, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
