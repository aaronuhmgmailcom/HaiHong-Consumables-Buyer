//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	SalerReturnRemote.cs    
//	�� �� ��:	��ԭ
//	��������:	2006-12-26
//	��������:	��ҵ�˻�����Զ�̷��ʲ�
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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
        /// ��ѯ�˻����б�
        /// </summary>
        /// <param name="plats">�ܹ����ƽ̨����</param>
        /// <param name="input">ҳ���������</param>
        /// <param name="pageParam">��ҵ����</param>
        /// <param name="rows">��������</param>
        /// <returns></returns>
        public DataTable findDealList(string[] plats, SalerReturnModel input, PagedParameter pageParam, out int rows)
        {
            return new SalerReturnBLL().findDealList(plats, input, pageParam, out rows);
        }

        /// <summary>
        /// �����˻���ϸ��
        /// </summary>
        /// <param name="Keys"></param>
        /// <param name="ui"></param>
        /// <param name="status">1--ͬ��/0--�ܾ�/other--����</param>
        /// <returns></returns>
        public bool UpdateReturnStatus(SalerReturnModel[] Keys, UserInfo ui, string status)
        {
            return new SalerReturnBLL().UpdateReturnStatus(Keys, ui, status);
        }

        /// <summary>
        /// ��ѯ4��ƽ̨ID
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
