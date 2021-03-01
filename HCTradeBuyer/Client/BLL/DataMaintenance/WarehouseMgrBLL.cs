//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	WarehouseMgrBLL.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-28
//	功能描述:	库房信息（业务操作类）
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

namespace Emedchina.TradeAssistant.Client.BLL.DataMaintenance
{
    /// <summary>
    /// 库房信息（业务操作类）
    /// </summary>
    public class WarehouseMgrBLL
    {
        WarehouseMgrDAO dao = null;

        private WarehouseMgrBLL()
        {
            dao = WarehouseMgrDAO.GetInstance();
        }

        public static WarehouseMgrBLL GetInstance()
        {
            return new WarehouseMgrBLL();
        }

        private WarehouseMgrBLL(string connectionName)
        {
            dao = WarehouseMgrDAO.GetInstance(connectionName);
        }

        public static WarehouseMgrBLL GetInstance(String strConnectionn)
        {
            return new WarehouseMgrBLL(strConnectionn);
        }

        /// <summary>
        /// 获取库房信息数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetWarehouseInfoDt(LogedInUser logedinUser)
        {
            try
            {
                return dao.GetWarehouseInfoDt(logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除库房信息数据集
        /// </summary>
        /// <returns></returns>
        public void Delete(string strWarehouseId, LogedInUser logedinUser)
        {
            try
            {
                dao.Delete(strWarehouseId, logedinUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取库房信息对象
        /// </summary>
        /// <param name="Hc_Id"></param>
        /// <returns></returns>
        //public WarehouseModel GetWarehouseInfoModel(string Hc_Id)
        //{
        //    try
        //    {
        //        return dao.GetWarehouseInfoModel(Hc_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 函数库房名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int JudgeCode(string code)
        {
            return dao.JudgeCode(code);
        }

        /// <summary>
        /// 修改函数库房名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int ModiJudgeCode(string code)
        {
            return dao.ModiJudgeCode(code);
        }
        

        /// <summary>
        /// 函数库房state
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int JudgeCanUse(string code)
        {
            return dao.JudgeCanUse(code);
        }


        
        /// <summary>
        /// 增加库房信息
        /// </summary>
        /// <returns></returns>
        public void InsertWarehouseInfo(WarehouseModel input, LogedInUser CurrentUser)
        {
            dao.InsertWarehouseInfo(input,CurrentUser);
        }
        
        /// <summary>
        /// 修改库房信息
        /// </summary>
        /// <returns></returns>
        public void UpdateWarehouseInfo(WarehouseModel input, LogedInUser CurrentUser)
        {
            dao.UpdateWarehouseInfo(input, CurrentUser);
        }
        

    }
}
