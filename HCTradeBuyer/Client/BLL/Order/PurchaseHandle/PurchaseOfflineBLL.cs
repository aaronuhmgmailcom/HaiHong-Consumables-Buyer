
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
namespace Emedchina.TradeAssistant.Client.BLL.Order.PurchaseHandle
{
    /// <summary>
    /// 项目产品表信息（业务操作类）
    /// </summary>
    public class PurchaseOfflineBLL
    {
        PurchaseOfflineDAO dao = null;

        public PurchaseOfflineBLL()
        {
            dao = PurchaseOfflineDAO.GetInstance();
        }

        public static PurchaseOfflineBLL GetInstance()
        {
            return new PurchaseOfflineBLL();
        }

       public PurchaseOfflineBLL(string connectionName)
        {
            dao = PurchaseOfflineDAO.GetInstance(connectionName);
        }

        public static PurchaseOfflineBLL GetInstance(String strConnectionn)
        {
            return new PurchaseOfflineBLL(strConnectionn);
        }

        #region 复制采购单(离线) CopyPurchaseOffline
        /// <summary>
        /// 复制采购单(离线)
        /// </summary>
        /// <returns>处理结果,返回采购单实体</returns>
        public PurchaseSaveModel CopyPurchaseOffline(PurchaseSaveModel input)
        {
            PurchaseOfflineDAO dao = PurchaseOfflineDAO.GetInstance(Constant.ACESSDB_ALIAS);

            return dao.CopyPurchaseOffline(input);
        }
        #endregion
        #region 删除采购单及删除采购单明细(离线)
        /// <summary>
        /// 删除采购单及删除采购单明细(离线)
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool PurchaseDeleteLocal(string purchaseId, string userId)
        {
            bool flag = true;

            try
            {
                flag = dao.PurchaseDeleteLocal(purchaseId, userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }
        #endregion
        #region  离线保存采购单
        /// <summary>
        /// 批量保存采购单
        /// </summary>
        /// <param name="list">采购单保存模型数组</param>
        /// <returns>执行结果</returns>
        public PurchaseSaveModel SavePurchaseOffline(PurchaseSaveModel input, string userid)
        {
            PurchaseSaveModel model = null;
            try
            {
                model = dao.SavePurchaseOffline(input, userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        #endregion
        #region 发送采购单，审批并发出，即拆单(参考gpo项目的程序)　离线
        /// <summary>
        /// 发送采购单，审批并发出，即拆单(参考gpo项目的程序)　离线
        /// </summary>
        /// <returns></returns>
        public string getCheckPurchaseOffline(string purchaseId, UserInfoModel usInfo)
        {
            string mes;
            PurchaseOfflineDAO dao = PurchaseOfflineDAO.GetInstance(Constant.ACESSDB_ALIAS);
            try
            {
                mes = dao.getCheckPurchaseOffline(purchaseId, usInfo);
            }
            catch (Exception e)
            {
                throw e;
            }
            return mes;
        }
        #endregion

        #region 送审采购单　离线
        /// <summary>
        ///  送审采购单　离线
        /// </summary>
        /// <returns></returns>
        public bool putCheckPurchaseOffline(string purchaseId)
        {
            bool flag;
            try
            {
                flag = dao.putCheckPurchaseOffline(purchaseId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
        #endregion

        #region 送审采购单　离线
        /// <summary>
        ///  送审采购单　离线
        /// </summary>
        /// <returns></returns>
        public bool Checkno(string purchaseId)
        {
            bool mes;
            PurchaseOfflineDAO dao = PurchaseOfflineDAO.GetInstance(Constant.ACESSDB_ALIAS);
            try
            {
                mes = dao.Checkno(purchaseId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return mes;
        }
        #endregion



       
    }
}
