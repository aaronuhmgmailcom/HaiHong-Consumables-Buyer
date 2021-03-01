//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	Constant.cs      
//	�� �� ��:	������
//	��������:	2006-7-3
//	��������:	ϵͳ��������
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Client.Common
{
    public class Constant
    {
        #region DataTable��
        /// <summary>
        /// Ӧ�ó�����
        /// </summary>
        public static readonly string APPNAME = "��������";
        public static readonly string MsgTitle = "��ʾ��Ϣ";
        #endregion

        #region DataTable��
        /// <summary>
        /// ��������
        /// </summary>
        public static readonly string ORDERTABLE = "ORDER";
        /// <summary>
        /// ������ϸ
        /// </summary>
        public static readonly string ORDERITEMTABLE = "ORDERLIST";
        /// <summary>
        /// ��ʷ��������
        /// </summary>
        public static readonly string ORDERTABLE_H = "ORDER_H";
        /// <summary>
        /// ��ʷ������ϸ
        /// </summary>
        public static readonly string ORDERITEMTABLE_H = "ORDERLIST_H";
        /// <summary>
        /// �ɹ�������
        /// </summary>
        public static readonly string PURCHASETABLE = "gpo_purchase";
        /// <summary>
        /// �ɹ�����ϸ
        /// </summary>
        public static readonly string PURCHASEITEMTABLE = "gpo_purchase_item";
        /// <summary>
        /// �ɹ�Ŀ¼��Ŀ��Դ
        /// </summary>
        public static readonly string PROJECTYPETABLE = "project_type";
        /// <summary>
        /// �ɹ�Ŀ¼��������
        /// </summary>
        public static readonly string GPOCOMMSENDERTABLE = "gpo_comm_sender";
        /// <summary>
        /// �����ɹ�Ŀ¼
        /// </summary>
        public static readonly string HITCOMMTABLE = "ord_hit_comm";
        /// <summary>
        /// �����ɹ�Ŀ¼
        /// </summary>
        public static readonly string CONTITEM = "CONTITEM";
        /// <summary>
        /// ȱ����ѯĿ¼
        /// </summary>
        public static readonly string OOSQUERY = "OOSQUERY";
        /// <summary>
        /// ��Ŀ��ƷĿ¼
        /// </summary>
        public static readonly string ORDPRODUCT = "ORDPRODUCT";
        #endregion



        #region DataTable��ϵ
        /// <summary>
        /// �����������ӱ�Ĺ�ϵ
        /// </summary>
        public static readonly string R_ORDER_ORDERITEM = "Order";

        /// <summary>
        /// ��ʷ�����������ӱ�Ĺ�ϵ
        /// </summary>
        public static readonly string R_ORDER_ORDERITEM_H = "Order_H";

        /// <summary>
        /// �ɹ����������ӱ�Ĺ�ϵ
        /// </summary>
        public static readonly string R_PURCHASE_PURCHASEITEM = "PurchaseAndPurchaseItem";
        /// <summary>
        /// �ɹ��������붩������Ĺ�ϵ
        /// </summary>
        public static readonly string R_PURCHASE_ORDER = "OrderAndPurchase";
        #endregion


        #region ����Դ����
        /// <summary>
        /// ���ؿ�����Դ���� app.config������
        /// </summary>
        public static readonly string ACESSDB_ALIAS = "ClientDB";

        #endregion

    }
}
