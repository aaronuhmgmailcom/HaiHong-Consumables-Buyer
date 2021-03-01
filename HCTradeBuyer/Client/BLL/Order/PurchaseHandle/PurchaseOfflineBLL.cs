
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
    /// ��Ŀ��Ʒ����Ϣ��ҵ������ࣩ
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

        #region ���Ʋɹ���(����) CopyPurchaseOffline
        /// <summary>
        /// ���Ʋɹ���(����)
        /// </summary>
        /// <returns>������,���زɹ���ʵ��</returns>
        public PurchaseSaveModel CopyPurchaseOffline(PurchaseSaveModel input)
        {
            PurchaseOfflineDAO dao = PurchaseOfflineDAO.GetInstance(Constant.ACESSDB_ALIAS);

            return dao.CopyPurchaseOffline(input);
        }
        #endregion
        #region ɾ���ɹ�����ɾ���ɹ�����ϸ(����)
        /// <summary>
        /// ɾ���ɹ�����ɾ���ɹ�����ϸ(����)
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
        #region  ���߱���ɹ���
        /// <summary>
        /// ��������ɹ���
        /// </summary>
        /// <param name="list">�ɹ�������ģ������</param>
        /// <returns>ִ�н��</returns>
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
        #region ���Ͳɹ���������������������(�ο�gpo��Ŀ�ĳ���)������
        /// <summary>
        /// ���Ͳɹ���������������������(�ο�gpo��Ŀ�ĳ���)������
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

        #region ����ɹ���������
        /// <summary>
        ///  ����ɹ���������
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

        #region ����ɹ���������
        /// <summary>
        ///  ����ɹ���������
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
