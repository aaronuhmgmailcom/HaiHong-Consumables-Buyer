//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	HosptailIDCompareDAO.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
//	功能描述:	医院编码匹配数据访问层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons.Data;
using System.Data;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.Commons;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Emedchina.TradeAssistant.Client.DAL.His
{
    /// <summary>
    /// 医院编码对照DAL层
    /// </summary>
    class HosptailIDCompareDAO : SqlDAOBase
    {

        private HosptailIDCompareDAO()
            : base()
        { }

        private HosptailIDCompareDAO(string connectionName)
            : base(connectionName)
        { }

        public static HosptailIDCompareDAO GetInstance()
        {
            return new HosptailIDCompareDAO();
        }

        public static HosptailIDCompareDAO GetInstance(string connectionName)
        {
            return new HosptailIDCompareDAO(connectionName);
        }


        /// <summary>
        /// 获得医院编码对照列表SQL
        /// </summary>
        /// <returns></returns>
        public string GetListSql()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT distinct b.id as buyer_orgid,b.NAME AS name,b.abbr AS abbr,b.spell_abbr ");
            sql.Append(" AS spell_abbr,b.name_wb AS name_wb,Switch(a.Process_Flag='0' or a.Process_Flag is null ,'未处理', a.Process_Flag='1','已处理') as Process_Flag,");
            sql.Append(" a.ID,a.Map_orgid,a.MAP_ORGTYPE,a.ORG_ID,a.DATA_ORG_ID,a.CODE,a.FULL_NAME, a.EASY_NAME,");
            sql.Append(" a.MODIFY_USERID, a.MODIFY_DATE,a.SYNC_STATE,a.ADDRESS,a.LINKMAN,a.TELPHONE,a.POSTCODE, ");
            sql.Append(" IIF(a.IsMap='0' or a.IsMap is null,'未匹配','已匹配') AS IsMap,a.IsMap as IsMapFlag,");
            sql.Append(" a.Process_Flag as pfFlag from GPO_CORP_MAP  a ");
            sql.Append(" left join  ( select *  from gpo_reg_buyer) b  on a.ORG_ID = b.id   where a.map_orgtype='2'  order by a.ORG_ID");
            return sql.ToString();
        }

        /// <summary>
        /// 获得医院编码对照查询 HIS医院对照列表SQL
        /// </summary>
        /// <returns></returns>
        public string GetCompareListSql()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" select buyer.NAME AS name,buyer.abbr AS abbr,buyer.spell_abbr AS  ");
            sb.Append(" spell_abbr,buyer.name_wb AS name_wb,buyer.id as buyer_orgid, hisCorp.* from ");
            sb.Append(" ( select * from gpo_reg_buyer) as buyer left join ( select b.org_id, IIF( count(b.id) ");
            sb.Append(" is null , '0' , count(b.id) ) as MapSum from GPO_CORP_MAP b group by b.org_id ) ");
            sb.Append(" as hisCorp on buyer.id = hisCorp.org_id where hisCorp.MapSum >= 1 ");

            return sb.ToString();

        }
        /// <summary>
        /// 获得医院编码对照列表
        /// </summary>
        /// <param name="SqlStr"></param>
        /// <returns></returns>
        public DataTable GetList(string SqlStr)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(SqlStr);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        /// <summary>
        /// 获取获取交易中心企业列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmedCorpListDs()
        {
            DataSet ds = new DataSet();

            try
            {
                DataTable dt = base.DbFacade.SQLExecuteDataTable(GetEmedCorpListDsSQL(), "emed_corp_list");
                ds.Tables.Add(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }

        /// <summary>
        ///  获取获取交易中心医院列表SQL
        /// </summary>
        /// <returns></returns>
        public string GetEmedCorpListDsSQL()
        {
            StringBuilder sb = new StringBuilder();
  
            sb.Append(" select distinct buyer.NAME AS name,buyer.abbr AS abbr,");
            sb.Append(" buyer.spell_abbr AS  spell_abbr,buyer.name_wb AS name_wb ,buyer.id as buyer_orgid, ");
            sb.Append(" hisCorp.* from ( select * from gpo_reg_buyer) as buyer left join ");
            sb.Append(" ( select b.org_id, IIF( count(b.id) is null , '0' , count(b.id) ) as MapSum");
            sb.Append(" from GPO_CORP_MAP b group by b.org_id ) as hisCorp on buyer.id = hisCorp.org_id ");

            return sb.ToString();
        }

        /// <summary>
        /// 增加对照医院
        /// </summary>
        /// <returns></returns>
        public void InsertHisErpCorpMap(Gpo_Hosptail_MapModel input)
        {
            int result ;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {

                try
                {
                    result=base.DbFacade.SQLExecuteNonQuery(InsertHisErpCorpMapSQL(input));
                    if (result > 0)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                    }
                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        /// <summary>
        /// 增加对照医院SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string InsertHisErpCorpMapSQL(Gpo_Hosptail_MapModel input)
        {
            StringBuilder sb = new StringBuilder();
            string GlobalID = IdUtil.GetGlobalId();
            sb.Append("insert into gpo_corp_map( \r\n\t\t\t\t\t");
            sb.Append("ID,MAP_ORGTYPE,MAP_ORGID,ORG_ID,CODE,FULL_NAME,EASY_NAME,\r\n");
            sb.Append("MODIFY_USERID,MODIFY_DATE,SYNC_STATE,Process_Flag,ISMAP) values \r\n");
            sb.Append("('").Append(GlobalID).Append("',");
            sb.Append(" '2',");
            sb.Append("'").Append(input.MapOrgId).Append("',");
            sb.Append("'").Append(input.CorpId).Append("',");
            sb.Append("'").Append(input.CorpCode).Append("',");
            sb.Append("'").Append(input.CorpName).Append("',");
            sb.Append("'").Append(input.CorpAbbr).Append("',");
            sb.Append("'").Append(input.ModifyUserId).Append("',");
            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append("'0',");
            sb.Append("'").Append(input.Process).Append("',");
            sb.Append("'").Append(input.IsMap).Append("')");


            return sb.ToString();

        }

        public string InsertHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            StringBuilder sb = new StringBuilder();
            string GlobalID = IdUtil.GetGlobalId();
            sb.Append("insert into gpo_corp_map( ");
            sb.Append("ID,MAP_ORGTYPE,MAP_ORGID,ORG_ID,CODE,FULL_NAME,EASY_NAME,");
            sb.Append("MODIFY_USERID,MODIFY_DATE,SYNC_STATE,Process_Flag) values ");
            sb.Append("('").Append(GlobalID).Append("',");
            sb.Append(" '2',");
            sb.Append("'").Append(MapOrgId).Append("',");
            sb.Append("'").Append(inRow["org_id"].ToString()).Append("',");
            sb.Append("'").Append(inRow["sender_code"].ToString()).Append("',");
            sb.Append("'").Append(inRow["sender_name"].ToString()).Append("',");
            sb.Append("'").Append(inRow["sender_name"].ToString()).Append("',");
            sb.Append("'").Append(inUserId).Append("',");
            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append("'0',");
            sb.Append("'").Append(inRow["process_flag"].ToString().Equals("true") ? "1" : "0").Append("')");

            return sb.ToString();

        }

        public string cancelmatchSQL(Gpo_Hosptail_MapModel input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update GPO_corp_map");
            //start modify by gaoyuan 2007.3.12
            sb.AppendFormat(" set ORG_ID='{0}'", input.CorpId);
            sb.Append(",data_org_id=''");
            //sb.AppendFormat(" set BUYER_ORGID='{0}'", input.MapOrgId);
            //sb.AppendFormat(",ORG_ID='{0}'", input.CorpId);
            //end modify by gaoyuan 2007.3.12
            sb.AppendFormat(",FULL_NAME='{0}'", input.CorpName);
            sb.AppendFormat(",EASY_NAME='{0}'", input.CorpAbbr);
            sb.AppendFormat(",MODIFY_USERID='{0}'", input.ModifyUserId);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(",SYNC_STATE='0'");
            sb.AppendFormat(",Process_Flag='{0}'", input.Process);
            sb.AppendFormat(",ISMAP='{0}'", input.IsMap);
            sb.AppendFormat(" where CODE='{0}'", input.CorpCode);
            sb.AppendFormat(" and map_orgid='{0}'", input.MapOrgId);

            return sb.ToString();
        }

        public void cancelmatch(Gpo_Hosptail_MapModel input)
        {
            int result;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result = base.DbFacade.SQLExecuteNonQuery(cancelmatchSQL(input));
                    if (result > 0)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                    }
                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        public void UpdateHisErpCorpMap(Gpo_Hosptail_MapModel input)
        {
            int result ;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result=base.DbFacade.SQLExecuteNonQuery(UpdateHisErpCorpMapSQL(input));
                    if (result > 0)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                    }
                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }
        public string UpdateHisErpCorpMapSQL(Gpo_Hosptail_MapModel input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update GPO_corp_map");
            //start modify by gaoyuan 2007.3.12
            sb.AppendFormat(" set ORG_ID='{0}'", input.CorpId);
            //sb.AppendFormat(" set BUYER_ORGID='{0}'", input.MapOrgId);
            //sb.AppendFormat(",ORG_ID='{0}'", input.CorpId);
            //end modify by gaoyuan 2007.3.12
            sb.AppendFormat(",FULL_NAME='{0}'", input.CorpName);
            sb.AppendFormat(",EASY_NAME='{0}'", input.CorpAbbr);
            sb.AppendFormat(",MODIFY_USERID='{0}'", input.ModifyUserId);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(",SYNC_STATE='0'");
            sb.AppendFormat(",Process_Flag='{0}'", input.Process);
            sb.AppendFormat(",ISMAP='{0}'", input.IsMap);
            sb.AppendFormat(" where CODE='{0}'", input.CorpCode);
            sb.AppendFormat(" and map_orgid='{0}'", input.MapOrgId);
            
            return sb.ToString();
        }

        public string UpdateHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update GPO_corp_map");
            sb.AppendFormat(" set MAP_ORGID='{0}'", MapOrgId);
            sb.AppendFormat(",ORG_ID='{0}'", inRow["org_id"].ToString());
            sb.AppendFormat(",FULL_NAME='{0}'", inRow["sender_name"].ToString());
            sb.AppendFormat(",EASY_NAME='{0}'", inRow["sender_name"].ToString());
            sb.AppendFormat(",MODIFY_USERID='{0}'", inUserId);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(",SYNC_STATE='0'");
            sb.AppendFormat(",Process_Flag='{0}'", inRow["process_flag"].ToString().Equals("true") ? "1" : "0");
            sb.AppendFormat(" where CODE='{0}'", inRow["sender_code"].ToString());
            sb.AppendFormat(" and map_orgid='{0}'", MapOrgId);
            
            return sb.ToString();
        }

        /// <summary>
        /// 海虹医院对应HIS医院列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetEmedCorpMapListDs(string inOrgId)
        {
            DataSet ds = new DataSet();

            try
            {
                DataTable dt = base.DbFacade.SQLExecuteDataTable(GetHisCorpByOrgId(inOrgId), "emed_corp_map_list");
                ds.Tables.Add(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }

        /// <summary>
        /// 海虹医院对应HIS医院列表SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetHisCorpByOrgId(string inOrgId)
        {
            return ("select * from GPO_CORP_MAP where org_id = '" + inOrgId + "'");
        }

        /// <summary>
        /// 医院对应中心数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet BuildCorpMapList()
        {
            DataSet ds = new DataSet();

            try
            {
                DataTable dt = base.DbFacade.SQLExecuteDataTable(BuildCorpMapListSQL(), "emed_corp_map_list");
                ds.Tables.Add(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds;
        }

        /// <summary>
        /// 医院对应中心数据列表SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string BuildCorpMapListSQL()
        {
            StringBuilder sb = new StringBuilder();


            //sb.Append("select c.ORG_NAME AS name,C.ORG_EASY AS abbr,");
            //sb.Append(" C.ORG_PINYIN AS spell_abbr,C.ORG_WUBI AS name_wb,saler_id as send_orgid,'' as org_id ,'' as MapSum ");
            //sb.Append(" from gpo_comm_sender gsc left join cont_org c on gsc.saler_id=c.org_id where 1=0");
            
            sb.Append(" select grb.NAME AS name,grb.abbr AS abbr, grb.spell_abbr AS spell_abbr,");
            sb.Append(" grb.name_wb AS name_wb,id as buyer_orgid,'' as org_id ,'' as MapSum  ");
            sb.Append(" from gpo_reg_buyer grb  where 1=0");
            return sb.ToString();
        }

        public int JudgeHIScode(string code, string MapOrgId)
        {
            return int.Parse(base.DbFacade.SQLExecuteScalar(judgeEPHISCode(code, MapOrgId)).ToString());
        }
        private string judgeEPHISCode(string code, string MapOrgId)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(CODE) from gpo_CORP_MAP");
            sqlstr.AppendFormat(" where CODE='{0}'", code);
            sqlstr.AppendFormat(" and Map_orgid='{0}'", MapOrgId);

            return sqlstr.ToString();
        }

        public string DeleteHisErpCorpMapSQL(string mapId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from gpo_corp_map");
            sb.AppendFormat(" where id='{0}'", mapId);
            return sb.ToString();
        }

        public void DeleteHisErpCorpMap(string mapId)
        {
            //start add by gaoyuan 2007.3.12
            int rownum;
            string sql = DeleteHisErpCorpMapSQL(mapId);

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    string sqlSearch = " select * from gpo_corp_map where id = '" + mapId + "'";
                    DataTable dt = base.DbFacade.SQLExecuteDataTable(sqlSearch, transaction);
                    if (dt == null || dt.Rows.Count < 0)
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                        return;
                    }
                    bool insertflg = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        insertflg = base.addDelLog("gpo_CORP_MAP", dr["id"].ToString(), "ID", ClientSession.GetInstance().CurrentUser.UserInfo.Id, "1", transaction);
                        if (!insertflg)
                        {
                            base.DbFacade.RollbackTransaction(transaction);
                            return;
                        }
                    }

                    rownum = base.DbFacade.SQLExecuteNonQuery(sql, transaction);
                    if (rownum > 0 && insertflg)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                    }
                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            //end add by gaoyuan 2007.3.12
        }

        public bool IsExistCode(string senderID, string CurrentOrgId)
        {
            bool flg = false;
            DataSet ds = null;
            string sql = "select id from gpo_CORP_MAP where code = '" + senderID + "' and MAP_ORGID='" + CurrentOrgId + "'";
            try
            {
                ds = base.DbFacade.SQLExecuteDataSet(sql);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    flg = false;
                }
                else
                {
                    flg = true;
                }
            }
            catch
            {
                throw;
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

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into gpo_corp_map( ");
            sb.Append("ID,MAP_ORGTYPE,Map_ORGID,DATA_ORG_ID,CODE,FULL_NAME,EASY_NAME,ADDRESS, POSTCODE,TELPHONE, LINKMAN,");
            sb.Append("ISFACTORY,ISSENDER,ISSALER,");
            sb.Append("Process_Flag,org_id,MODIFY_USERID,MODIFY_DATE,SYNC_STATE,ISMAP) values ");

            sb.Append("('").Append(IdUtil.GetGlobalId()).Append("',");
            sb.Append("'2',");
            sb.Append("'").Append(MapOrgId).Append("',");
            sb.Append("'").Append(inRow.Cells["DATA_ORG_ID"].Value == null ? "" : inRow.Cells["DATA_ORG_ID"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["CODE"].Value == null ? "" : inRow.Cells["CODE"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["FULL_NAME"].Value == null ? "" : inRow.Cells["FULL_NAME"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["EASY_NAME"].Value == null ? "" : inRow.Cells["EASY_NAME"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ADDRESS"].Value == null ? "" : inRow.Cells["ADDRESS"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["POSTCODE"].Value == null ? "" : inRow.Cells["POSTCODE"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["TELPHONE"].Value == null ? "" : inRow.Cells["TELPHONE"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["LINKMAN"].Value == null ? "" : inRow.Cells["LINKMAN"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ISFACTORY"].Value == null ? "" : inRow.Cells["ISFACTORY"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ISSENDER"].Value == null ? "" : inRow.Cells["ISSENDER"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ISSALER"].Value == null ? "" : inRow.Cells["ISSALER"].Value.ToString()).Append("',");
            sb.Append("0").Append(",");
            sb.Append("'").Append(inRow.Cells["ORG_ID"].Value == null ? "" : inRow.Cells["ORG_ID"].Value.ToString()).Append("',");
            sb.Append("'").Append(inUserId).Append("',");
            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append("0").Append(",");
            sb.Append("'").Append(inRow.Cells["ORG_ID"].Value.ToString().Equals("") ? "0" : "1").Append("')");
           
            return sb.ToString();

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
            StringBuilder sb = new StringBuilder();
            sb.Append("update gpo_corp_map set ");
            sb.Append(" DATA_ORG_ID=").Append("'").Append(inRow.Cells["DATA_ORG_ID"].Value.ToString()).Append("',");
            sb.Append(" FULL_NAME=").Append("'").Append(inRow.Cells["FULL_NAME"].Value.ToString()).Append("',");
            sb.Append(" EASY_NAME=").Append("'").Append(inRow.Cells["EASY_NAME"].Value.ToString()).Append("',");
            sb.Append(" ADDRESS=").Append("'").Append(inRow.Cells["ADDRESS"].Value.ToString()).Append("',");
            sb.Append(" POSTCODE=").Append("'").Append(inRow.Cells["POSTCODE"].Value.ToString()).Append("',");
            sb.Append(" TELPHONE=").Append("'").Append(inRow.Cells["TELPHONE"].Value.ToString()).Append("',");
            sb.Append(" LINKMAN=").Append("'").Append(inRow.Cells["LINKMAN"].Value.ToString()).Append("',");
            sb.Append(" ORG_ID=").Append("'").Append(inRow.Cells["ORG_ID"].Value.ToString()).Append("',");
            sb.Append(" MODIFY_USERID='").Append(inUserId).Append("',");
            sb.Append(" MODIFY_DATE='").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append(" SYNC_STATE='0',");
            sb.Append(" ISMAP='").Append(inRow.Cells["ORG_ID"].Value.ToString().Equals("") ? "0" : "1").Append("'");


            sb.Append(" where map_orgid='").Append(MapOrgId).Append("'");
            sb.Append(" and code='").Append(code).Append("'");

            return sb.ToString();

        }


        /// <summary>
        /// 获取导出信息id
        /// </summary>
        /// <returns></returns>
        public DataTable GetEnterPrise(string sql)
        {

            DataTable dt = new DataTable();

            OleDbConnection myConn = new OleDbConnection(ClientConfiguration.ConnectionString);

            myConn.Open();

            //打开数据链接，得到一个数据集
            OleDbDataAdapter myCommand = new OleDbDataAdapter(sql, myConn);

            //得到自己的DataSet对象
            myCommand.Fill(dt);
            //关闭此数据链接
            myConn.Close();

            //DataTable dt = null;
            //try
            //{
            //    dt = dbFacade.SQLExecuteDataTable(sql);
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}

            return dt;
        }


        public bool HisOperation(string[] textArray1)
        {
            bool flg = false;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    flg = base.DbFacade.SQLExecuteNonQuery(textArray1, transaction);
                    if (flg)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        flg = false;
                        base.DbFacade.RollbackTransaction(transaction);
                    }
                }
                catch
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw;
                }

            }
            return flg;
        }
    }
}
