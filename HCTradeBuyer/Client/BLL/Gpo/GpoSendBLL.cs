using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Emedchina.Commons;

using Emedchina.TradeAssistant.Client.DAL.Gpo;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Client.DAL.Map.Product;
namespace Emedchina.TradeAssistant.Client.BLL.Gpo
{
    public class GpoSendBLL
    {
        private GpoSendDao dao;
        private GpoSendBLL()            
        {
            dao = GpoSendDao.GetInstance();
        }

        private GpoSendBLL(string connectionName)
        {
            dao = GpoSendDao.GetInstance(connectionName);
        }

        public static GpoSendBLL GetInstance()
        {
            return new GpoSendBLL();
        }

        public static GpoSendBLL GetInstance(string connectionName)
        {
            return new GpoSendBLL(connectionName);
        }        
        
        
        
        /// <summary>
        /// ��ȡҩƷƥ������
        /// </summary>
        /// <param name="erpProductCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public string GetProductMapData(string erpProductCode,string orgId,out object num)
        {
            return dao.GetProductMapData(erpProductCode, orgId, out num);
        }
        /// <summary>
        /// ��ȡҽԺƥ������
        /// </summary>
        /// <param name="erpHisCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public string GetCorpMapData(string erpHisCode, string orgId, out object crpnum)
        {
            return dao.GetCorpMapData(erpHisCode, orgId, out crpnum);
        }
        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <param name="erpProductCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public DataTable GetOrderExpData(string oderId,string orgid,string clientPlat)
        {
            return GpoOrderExpDAO.GetInstance().GetOrderExpData(oderId,orgid,clientPlat);
        }
        /// <summary>
        /// ����ҩƷƥ���
        /// </summary>
        /// <param name="productmapinstance"></param>
        /// <returns></returns>
        public void AddProductMap(ProductCropModel productmapinstance)
        {
            bool flag = ProductCodeCompareDAL.GetInstance().JudgeProductCode(productmapinstance.Code, productmapinstance.SalerID);
            if (!flag)
            {
                ProductCodeCompareDAL.GetInstance().CreateProductComprison(productmapinstance);
            }
            else
            {
                ProductCodeCompareDAL.GetInstance().UpdateComparison(productmapinstance);
            }
        }
        public DataTable GetErpProductByProcode(string erpProductCode, string orgId)
        {
            return ProductCodeCompareDAL.GetInstance().GetErpItemByProcode(erpProductCode, orgId);
        }
        //add by cjg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtImport"></param>
        /// <returns></returns>
        public DataTable GetNotMapData(ref DataTable dtImport, string sOrgID)
        {
            return dao.GetNotMapData(ref dtImport, sOrgID);
        }

         //"�����ɹ�����"�ж�ҵ������("������"��ҵ�Խӹ���)��shangfu 2007-8-29
        public bool GetContItemInfo(string productId, string buyerorgid)
        {
            return GpoOrderExpDAO.GetInstance().GetContItemInfo(productId,buyerorgid);
        }
    }

}
