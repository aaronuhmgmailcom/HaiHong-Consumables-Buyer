//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	Constant.cs      
//	创 建 人:	梁晓奕
//	创建日期:	2006-7-3
//	功能描述:	系统常量定义
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Client.Common
{
    public class Constant
    {
        #region DataTable名
        /// <summary>
        /// 应用程序名
        /// </summary>
        public static readonly string APPNAME = "交易助手";
        public static readonly string MsgTitle = "提示信息";
        #endregion

        #region DataTable名
        /// <summary>
        /// 订单主表
        /// </summary>
        public static readonly string ORDERTABLE = "ORDER";
        /// <summary>
        /// 订单明细
        /// </summary>
        public static readonly string ORDERITEMTABLE = "ORDERLIST";
        /// <summary>
        /// 历史订单主表
        /// </summary>
        public static readonly string ORDERTABLE_H = "ORDER_H";
        /// <summary>
        /// 历史订单明细
        /// </summary>
        public static readonly string ORDERITEMTABLE_H = "ORDERLIST_H";
        /// <summary>
        /// 采购单主表
        /// </summary>
        public static readonly string PURCHASETABLE = "gpo_purchase";
        /// <summary>
        /// 采购单明细
        /// </summary>
        public static readonly string PURCHASEITEMTABLE = "gpo_purchase_item";
        /// <summary>
        /// 采购目录项目来源
        /// </summary>
        public static readonly string PROJECTYPETABLE = "project_type";
        /// <summary>
        /// 采购目录卖方机构
        /// </summary>
        public static readonly string GPOCOMMSENDERTABLE = "gpo_comm_sender";
        /// <summary>
        /// 经常采购目录
        /// </summary>
        public static readonly string HITCOMMTABLE = "ord_hit_comm";
        /// <summary>
        /// 经常采购目录
        /// </summary>
        public static readonly string CONTITEM = "CONTITEM";
        /// <summary>
        /// 缺货查询目录
        /// </summary>
        public static readonly string OOSQUERY = "OOSQUERY";
        /// <summary>
        /// 项目产品目录
        /// </summary>
        public static readonly string ORDPRODUCT = "ORDPRODUCT";
        #endregion



        #region DataTable关系
        /// <summary>
        /// 订单主表与子表的关系
        /// </summary>
        public static readonly string R_ORDER_ORDERITEM = "Order";

        /// <summary>
        /// 历史订单主表与子表的关系
        /// </summary>
        public static readonly string R_ORDER_ORDERITEM_H = "Order_H";

        /// <summary>
        /// 采购单主表与子表的关系
        /// </summary>
        public static readonly string R_PURCHASE_PURCHASEITEM = "PurchaseAndPurchaseItem";
        /// <summary>
        /// 采购单主表与订单主表的关系
        /// </summary>
        public static readonly string R_PURCHASE_ORDER = "OrderAndPurchase";
        #endregion


        #region 数据源别名
        /// <summary>
        /// 本地库数据源别名 app.config中配置
        /// </summary>
        public static readonly string ACESSDB_ALIAS = "ClientDB";

        #endregion

    }
}
