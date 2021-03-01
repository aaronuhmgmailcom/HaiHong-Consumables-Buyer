//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerReturnRemote.cs    
//	创 建 人:	高原
//	创建日期:	2006-12-26
//	功能描述:	企业退货处理远程访问层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.TradeAssistant.BLL.Order.SalerReturn;
using System.Collections;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.Order.SalerReturn;

namespace Emedchina.TradeAssistant.Remoting.Order.SalerReturn
{
    public class SalerReturnRemote : MarshalByRefObject
    {
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
            return new SalerReturnBLL().findDealList(plats, input, pageParam, out rows);
        }

        /// <summary>
        /// 更新退货明细表
        /// </summary>
        /// <param name="Keys"></param>
        /// <param name="ui"></param>
        /// <param name="status">1--同意/0--拒绝/other--错误</param>
        /// <returns></returns>
        public bool UpdateReturnStatus(SalerReturnModel[] Keys, UserInfo ui, string status)
        {
            return new SalerReturnBLL().UpdateReturnStatus(Keys, ui, status);
        }

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
            return new SalerReturnBLL().getClass4PlatsList(handlerId, operate, ui, flag);
        }
    }
}
