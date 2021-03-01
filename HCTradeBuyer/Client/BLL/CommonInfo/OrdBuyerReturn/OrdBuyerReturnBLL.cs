//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdBuyerReturnBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	退货管理（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 退货管理（业务操作类）
    /// </summary>
    class OrdBuyerReturnBLL
    {
        OrdBuyerReturnDao dao = null;

        private OrdBuyerReturnBLL()
        {
            dao = OrdBuyerReturnDao.GetInstance();
        } 

        public static OrdBuyerReturnBLL GetInstance()
        {
            return new OrdBuyerReturnBLL();
        }

        private OrdBuyerReturnBLL(string connectionName)
        {
            dao = OrdBuyerReturnDao.GetInstance(connectionName);
        }

        public static OrdBuyerReturnBLL GetInstance(String strConnectionn)
        {
            return new OrdBuyerReturnBLL(strConnectionn);
        }

        /// <summary>
        /// 获取可退货商品列表
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public DataTable GetBuyerReturnList()
        {
            try
            {
                return dao.GetBuyerReturnList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存退货单记录对象
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        public void SaveOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel, LogedInUser logedinUser)
        {
            try
            {
                dao.SaveOrdBuyerReturnModel(Listmodel, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取退货商品列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetReturnList(string State)
        {
            try
            {
                return dao.GetReturnList(State);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改退货单记录状态 '1' 未发送 '2' 已发送 '3' 已撤销 '4' 对方确认 '5' 对方拒绝
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        public void ModifyStateOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel, string State, LogedInUser logedinUser)
        {
            try
            {
                dao.ModifyStateOrdBuyerReturnModel(Listmodel, State, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改实退数量
        /// </summary>
        /// <param name="Listmodel"></param>
        public void ModifyAmountOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel)
        {
            try
            {
                dao.ModifyAmountOrdBuyerReturnModel(Listmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改退货单标志
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="State"></param>
        public void SendOrdBuyerReturnModel(List<OrdBuyerReturnModel> Listmodel, string State, LogedInUser logedinUser)
        {
            try
            {
                dao.SendOrdBuyerReturnModel(Listmodel, State, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
