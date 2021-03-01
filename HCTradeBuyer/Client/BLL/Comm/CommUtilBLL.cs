//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	CommUtilBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	公共操作（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.DAL.Comm;
using Emedchina.Commons;

namespace Emedchina.TradeAssistant.Client.BLL
{
    /// <summary>
    /// 公共类
    /// </summary>
    public class CommUtilBLL
    {
        CommUtilDao dao = null;

        private CommUtilBLL()
        {
            dao = CommUtilDao.GetInstance();
        }

        public static CommUtilBLL GetInstance()
        {
            return new CommUtilBLL();
        }

        private CommUtilBLL(string connectionName)
        {
            dao = CommUtilDao.GetInstance(connectionName);
        }

        public static CommUtilBLL GetInstance(String strConnectionn)
        {
            return new CommUtilBLL(strConnectionn);
        }

        /// <summary>
        /// 根据项目类型获取项目信息
        /// </summary>
        /// <param name="ProjectType"></param>
        /// <returns></returns>
        public DataTable GetProjectInfoByProjectType(string ProjectType)
        {
            DataTable dt = null;

            try
            {
                dt = dao.GetProjectInfoByProjectType(ProjectType);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        
        /// <summary>
        /// 获取库房信息
        /// </summary>
        /// <param name="OrgID"></param>
        /// <returns></returns>
        public DataTable GetBuyerStoreInfo(string OrgID)
        {

            DataTable dt = null;

            try
            {
                dt = dao.GetBuyerStoreInfo(OrgID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取规格信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSpecInfo()
        {
            DataTable dt = null;

            try
            {
                dt = dao.GetSpecInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取型号信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetModelInfo()
        {
            DataTable dt = null;

            try
            {
                dt = dao.GetModelInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 获取配送商信息
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectProdId"></param>
        /// <returns></returns>
        public DataTable GetSenderInfo(string buyerId,string projectId,string projectProdId)
        {
            DataTable dt = null;

            try
            {
                dt = dao.GetSenderInfo(buyerId, projectId, projectProdId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// 根据项目ID获取品种分类信息
        /// </summary>
        /// <param name="ProjectType"></param>
        /// <returns></returns>
        public DataTable GetProductClassInfoByProjectID(string ProjectID)
        {
            DataTable dt = null;

            try
            {
                dt = dao.GetProductClassInfoByProjectID(ProjectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }


        ///// <summary>
        ///// 取得客户端id
        ///// </summary>
        ///// <returns></returns>
        //public Int64 GetClientID()
        //{
        //    int highId;
        //    Int64 clientId;
        //    try
        //    {
        //        highId = dao.GetHighID();
        //        if (highId == -1)
        //        {
        //            highId = Convert.ToInt32(ProxyFactory.UserProxy.GetHighId());
        //            dao.SaveHighID(highId);
        //        }
        //        clientId = dao.GetClientId(highId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return clientId;
        //}

        /// <summary>
        /// 取得高位id
        /// </summary>
        /// <returns></returns>
        public int GetHighID()
        {

            int highId = dao.GetHighID();
            if (highId == -1)
            {
                highId = Convert.ToInt32(ProxyFactory.UserProxy.GetHighId());
                dao.SaveHighID(highId);
            }
            return highId;
        }

    }
}
