//======================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	DefineCodeBLL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	自定义编码设置（业务操作类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.TradeAssistant.Client.DAL.CommonInfo;

namespace Emedchina.TradeAssistant.Client.BLL.CommonInfo
{
    /// <summary>
    /// 自定义编码设置（业务操作类）
    /// </summary>
    class DefineCodeBLL
    {
        DefineCodeDao dao = null;

        private DefineCodeBLL()
        {
            dao = DefineCodeDao.GetInstance();
        }

        public static DefineCodeBLL GetInstance()
        {
            return new DefineCodeBLL();
        }

        private DefineCodeBLL(string connectionName)
        {
            dao = DefineCodeDao.GetInstance(connectionName);
        }

        public static DefineCodeBLL GetInstance(String strConnectionn)
        {
            return new DefineCodeBLL(strConnectionn);
        }

        /// <summary>
        /// 获取自义定编码大包装信息列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDefineCodeDt(string ProjectID)
        {
            try
            {
                return dao.GetDefineCodeDt(ProjectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 自定义编码及大包装操作
        /// </summary>
        /// <param name="Listmodel"></param>
        /// <param name="logedinUser"></param>
        public void OperatorDefineInfoList(List<DefineInfoModel> Listmodel, LogedInUser logedinUser)
        {
            try
            {
                dao.OperatorDefineInfoList(Listmodel, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断自定义编码表中 编码是否已存在
        /// </summary>
        /// <param name="strProductMnemonic"></param>
        /// <returns></returns>
        public bool DefineCodeIsAddProductMnemonic(string strProductMnemonic, string strHit_Comm_Id)
        {
            bool flag = false;
            try
            {
                flag = dao.DefineCodeIsAddProductMnemonic(strProductMnemonic, strHit_Comm_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }

    }
}
