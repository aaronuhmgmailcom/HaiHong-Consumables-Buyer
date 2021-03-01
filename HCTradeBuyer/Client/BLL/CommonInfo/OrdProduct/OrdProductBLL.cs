//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	OrdProductBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	项目产品表信息（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 项目产品表信息（业务操作类）
    /// </summary>
    class OrdProductBLL
    {
        OrdProductDao dao = null;

        private OrdProductBLL()
        {
            dao = OrdProductDao.GetInstance();
        }

        public static OrdProductBLL GetInstance()
        {
            return new OrdProductBLL();
        }

        private OrdProductBLL(string connectionName)
        {
            dao = OrdProductDao.GetInstance(connectionName);
        }

        public static OrdProductBLL GetInstance(String strConnectionn)
        {
            return new OrdProductBLL(strConnectionn);
        }

        /// <summary>
        /// 获取项目产品信息列表 暂无用
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdProductList()
        {
            try
            {
                return dao.GetOrdProductList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取项目产品信息(使用地方：新建常采购供应目录)
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrdProductDt(string strProjectID, LogedInUser logedinUser,string strDataName)
        {
            try
            {
                return dao.GetOrdProductDt(strProjectID, logedinUser, strDataName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取项目产品信息对象
        /// </summary>
        /// <param name="Data_Product_Id"></param>
        /// <returns></returns>
        public OrdProductModel Get_OrdProductModel(string Project_Product_Id)
        {
            try
            {
                return dao.Get_OrdProductModel(Project_Product_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 缺货查询
        /// </summary>
        /// <param name="logedinUser"></param>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public DataTable GetOosProductList(LogedInUser logedinUser, string ProjectID)
        {
            try
            {
                return dao.GetOosProductList(logedinUser, ProjectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
