//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	HosptailIDCompareBLL.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-5-21
//	功能描述:	医院编码匹配业务逻辑层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.Client.Common;
using System.Data;
using Emedchina.TradeAssistant.Model.Map;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.DAL.Map.Hospital;

namespace Emedchina.TradeAssistant.Client.BLL.Map.Hospital
{
    /// <summary>
    /// 医院编码对照业务逻辑层
    /// </summary>
    public class HosptailIDCompareBLL
    {

        private HosptailIDCompareDAO dao = null;

        private HosptailIDCompareBLL()
        {
            dao = HosptailIDCompareDAO.GetInstance(Constant.ACESSDB_ALIAS);
        }

        private HosptailIDCompareBLL(string connectionName)
        {
            dao = HosptailIDCompareDAO.GetInstance(connectionName);
        }

        public static HosptailIDCompareBLL GetInstance()
        {
            return new HosptailIDCompareBLL();
        }
        public static HosptailIDCompareBLL GetInstance(string connectionName)
        {
            return new HosptailIDCompareBLL(connectionName);
        }
        /// <summary>
        /// 获取医院编码对照列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetHTComparionTable()
        {
            return dao.GetList(dao.GetListSql());
        }
        /// <summary>
        /// 获取医院编码对照查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetEPCompareQueryTable()
        {
            return dao.GetList(dao.GetCompareListSql());
        }

        /// <summary>
        /// 获取获取交易中心医院列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmedCorpListDs()
        {
            return dao.GetEmedCorpListDs();
        }

        /// <summary>
        /// 增加对照医院
        /// </summary>
        /// <returns></returns>
        public void InsertHisErpCorpMap(Gpo_Hosptail_MapModel input)
        {
            dao.InsertHisErpCorpMap(input);
        }

        public string InsertHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            return dao.InsertHisErpCorpMapSQL(inRow, inUserId, MapOrgId);
        }

        public void cancelmatch(Gpo_Hosptail_MapModel input)
        {
            dao.cancelmatch(input);
        }

        public void UpdateHisErpCorpMap(Gpo_Hosptail_MapModel input)
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
        /// 海虹医院对应HIS医院列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmedCorpMapListDs(string inOrgId)
        {
            return dao.GetEmedCorpMapListDs(inOrgId);
        }

        /// <summary>
        /// 医院对应中心数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet BuildCorpMapList()
        {
            return dao.BuildCorpMapList();
        }


        public int JudgeHIScode(string code, string MapOrgId)
        {
            return dao.JudgeHIScode(code, MapOrgId);
        }
        //add by cjg 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="MapOrdId"></param>
        /// <param name="sID"></param>
        /// <returns></returns>
        public bool JudgeHIScode(string code, string MapOrdId, ref string sID)
        {
            return dao.JudgeHIScode(code,MapOrdId,ref sID);
        }
        public bool IsExistCode(string senderID, string CurrentOrgId)
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
        /// 新增医院编码对照匹配信息SQL
        /// </summary>
        /// <param name="inRow"></param>
        /// <param name="inUserId"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        public string InsertHisEnterpriseMapSQL(DataGridViewRow inRow, string inUserId, string MapOrgId)
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
        /// 更新医院编码对照匹配信息SQL
        /// </summary>
        /// <param name="inRow"></param>
        /// <param name="inUserId"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        public string UpdateHisEnterpriseMapSQL(DataGridViewRow inRow, string code, string inUserId, string MapOrgId)
        {
            string sql;
            try
            {
                sql = dao.UpdateHisEnterpriseMapSQL(inRow, code, inUserId, MapOrgId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sql;
        }
        //add by cjg 
        /// <summary>
        /// 批量增减买方匹配
        /// </summary>
        /// <param name="sArray"></param>
        /// <returns></returns>
        public bool AddHisCorpMapBatch(string[] sArray)
        {
            return dao.AddHisCorpMapBatch(sArray);
        }
        //add bu cjg
        /// <summary>
        /// 获取增加买方匹配sql
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string InsertHisErpCorpMapSQL(Gpo_Hosptail_MapModel input,out string sRecord_ID)
        {
            return dao.InsertHisErpCorpMapSQL(input, out sRecord_ID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sRecord_ID"></param>
        public void cancelmatch(string sRecord_ID)
        {
            dao.cancelmatch(sRecord_ID);
        }
        public bool UpdateCorpMap(string sID, string sOrg_id)
        {
            return dao.UpdateCorpMap(sID,sOrg_id);
        }
    }
}
