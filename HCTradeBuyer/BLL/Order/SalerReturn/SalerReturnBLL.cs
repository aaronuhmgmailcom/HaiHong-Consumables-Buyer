#region Head
//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	SalerReturnBLL.cs    
//	�� �� ��:	��ԭ
//	��������:	2006-12-26
//	��������:	��ҵ�˻�����ҵ���߼���
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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
        #region ��ѯ�˻����б�
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

        #region �����˻���ϸ��
        /// <summary>
        /// �����˻���ϸ��
        /// </summary>
        /// <param name="Keys"></param>
        /// <param name="ui"></param>
        /// <param name="status">1--ͬ��/0--�ܾ�/other--����</param>
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

        #region ��ѯ4��ƽ̨ID
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
            return new SalerReturnDAO().getClass4PlatsList(handlerId, operate, ui, flag);
        }
        #endregion
    }
}
