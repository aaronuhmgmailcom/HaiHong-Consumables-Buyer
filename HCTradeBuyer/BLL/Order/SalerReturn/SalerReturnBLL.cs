#region Head
//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerReturnBLL.cs    
//	创 建 人:	高原
//	创建日期:	2006-12-26
//	功能描述:	企业退货处理业务逻辑层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.TradeAssistant.DAL.Order.SalerReturn;
using System.Collections;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Order.SalerReturn;
#endregion

namespace Emedchina.TradeAssistant.BLL.Order.SalerReturn
{
    public class SalerReturnBLL
    {
        #region 查询退货单列表
        /// <summary>
        /// 查询退货单列表
        /// </summary>
        /// <param name="plats">受管理的平台集合</param>
        /// <param name="input">页面输入参数</param>
        /// <param name="pageParam">分业参数</param>
        /// <param name="rows">数据行数</param>
        /// <returns></returns>
        public DataTable findDealList(string[] plats, SalerReturnModel input, PagedParameter pageParam, out int rows)
        {
            SalerReturnDAO dao = new SalerReturnDAO();
            DataTable dt = null;
            try
            {
                dt = dao.findDealList(plats, input, pageParam, out rows);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
        #endregion

        #region 更新退货明细表
        /// <summary>
        /// 更新退货明细表
        /// </summary>
        /// <param name="Keys"></param>
        /// <param name="ui"></param>
        /// <param name="status">1--同意/0--拒绝/other--错误</param>
        /// <returns></returns>
        public bool UpdateReturnStatus(SalerReturnModel[] Keys, UserInfo ui, string status)
        {
            SalerReturnDAO dao = new SalerReturnDAO();
            bool flg = false;
            try
            {
                flg = dao.UpdateReturnStatus(Keys, ui, status);
            }
            catch (Exception e)
            {
                throw e;
            }
            return flg;
        }
        #endregion

        #region 查询4级平台ID
        /// <summary>
        /// 查询4级平台ID
        /// </summary>
        /// <param name="handlerId"></param>
        /// <param name="operate"></param>
        /// <param name="ui"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public string[] getClass4PlatsList(string handlerId, string operate, UserInfo ui, bool flag)
        {
            return new SalerReturnDAO().getClass4PlatsList(handlerId, operate, ui, flag);
        }
        #endregion
    }
}
