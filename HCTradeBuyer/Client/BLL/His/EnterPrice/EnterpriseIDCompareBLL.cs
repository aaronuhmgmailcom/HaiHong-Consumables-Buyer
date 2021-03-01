//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	EnterpriseIDCompareBLL.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
//	功能描述:	企业编码匹配业务逻辑层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.Client.Common;
using System.Data;
using Emedchina.TradeAssistant.Model.His;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.DAL.His;

namespace Emedchina.TradeAssistant.Client.BLL.His.EnterPrice
{
    /// <summary>
    /// 企业编码对照业务逻辑层
    /// </summary>
    public class EnterpriseIDCompareBLL
    {

        private EnterpriseIDCompareDAO dao = null;

        private EnterpriseIDCompareBLL()
        {
            dao = EnterpriseIDCompareDAO.GetInstance();
        }

        private EnterpriseIDCompareBLL(string connectionName)
        {
            dao = EnterpriseIDCompareDAO.GetInstance(connectionName);
        }

        public static EnterpriseIDCompareBLL GetInstance()
        {
            return new EnterpriseIDCompareBLL();
        }
        public static EnterpriseIDCompareBLL GetInstance(string connectionName)
        {
            return new EnterpriseIDCompareBLL(connectionName);
        }
        /// <summary>
        /// 获取企业编码对照列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetEPComparionTable()
        {
            return dao.GetList(dao.GetListSql());
        }
        /// <summary>
        /// 获取企业编码对照查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetEPCompareQueryTable()
        {
            return dao.GetList(dao.GetCompareListSql());
        }

        /// <summary>
        /// 获取获取交易中心企业列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmedCorpListDs()
        {
            return dao.GetEmedCorpListDs();
        }

        /// <summary>
        /// 增加对照企业
        /// </summary>
        /// <returns></returns>
        public void InsertHisErpCorpMap(Gpo_EnterPrice_MapModel input)
        {
            dao.InsertHisErpCorpMap(input);
        }

        public string InsertHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            return dao.InsertHisErpCorpMapSQL(inRow, inUserId, MapOrgId);
        }


        public void cancelMatch(Gpo_EnterPrice_MapModel input)
        {
            dao.cancelMatch(input);
        }

        public void UpdateHisErpCorpMap(Gpo_EnterPrice_MapModel input)
        {
            dao.UpdateHisErpCorpMap(input);
        }

        public string UpdateHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            return dao.UpdateHisErpCorpMapSQL(inRow, inUserId, MapOrgId);
        }

        public void DeleteHisErpCorpMap(string mapId)
        {
            dao.DeleteHisErpCorpMap(mapId);
        }
        /// <summary>
        /// 海虹企业对应HIS企业列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmedCorpMapListDs(string inOrgId)
        {
            return dao.GetEmedCorpMapListDs(inOrgId);
        }

        /// <summary>
        /// 企业对应中心数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet BuildCorpMapList()
        {
            return dao.BuildCorpMapList();
        }


        public int JudgeHIScode(string code,string MapOrgId)
        {
            return dao.JudgeHIScode(code, MapOrgId);
        }

        public bool IsExistCode(string senderID,string CurrentOrgId)
        {
            bool flg = false;
            try
            {
                flg = dao.IsExistCode(senderID, CurrentOrgId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flg;
        }

        public bool HisOperation(string[] textArray1)
        {
            bool flg = false;
            try
            {
                flg = dao.HisOperation(textArray1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flg;
        }


        /// <summary>
        /// 新增企业编码对照匹配信息SQL
        /// </summary>
        /// <param name="inRow"></param>
        /// <param name="inUserId"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        public string InsertHisEnterpriseMapSQL(DataGridViewRow inRow, int inUserId, string MapOrgId)
        {
            string sql;
            try
            {
                sql = dao.InsertHisEnterpriseMapSQL(inRow, inUserId, MapOrgId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sql;
        }

          /// <summary>
        /// 更新企业编码对照匹配信息SQL
        /// </summary>
        /// <param name="inRow"></param>
        /// <param name="inUserId"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        public string UpdateHisEnterpriseMapSQL(DataGridViewRow inRow,string code, string inUserId, string MapOrgId)
        {
            string sql;
            try
            {
                sql = dao.UpdateHisEnterpriseMapSQL(inRow,code, inUserId, MapOrgId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sql;
        }

        

    }
}
