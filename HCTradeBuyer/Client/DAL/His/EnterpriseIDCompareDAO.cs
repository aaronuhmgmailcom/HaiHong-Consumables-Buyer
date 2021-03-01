//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	EnterpriseIDCompareDAO.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
//	功能描述:	企业编码匹配数据访问层
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
    /// 企业编码对照DAL层
    /// </summary>
    class EnterpriseIDCompareDAO : SqlDAOBase
    {

        private EnterpriseIDCompareDAO()
            : base()
        { }

        private EnterpriseIDCompareDAO(string connectionName)
            : base(connectionName)
        { }

        public static EnterpriseIDCompareDAO GetInstance()
        {
            return new EnterpriseIDCompareDAO();
        }

        public static EnterpriseIDCompareDAO GetInstance(string connectionName)
        {
            return new EnterpriseIDCompareDAO(connectionName);
        }
        
        
        /// <summary>
        /// 获得企业编码对照列表SQL
        /// </summary>
        /// <returns></returns>
        public string GetListSql()
        {
            StringBuilder sql = new StringBuilder();
            //sql.Append("SELECT distinct d.*,a.ORG_NAME AS name,a.ORG_EASY AS abbr,a.ORG_PINYIN AS spell_abbr,a.ORG_WUBI AS name_wb");
            //sql.Append(" FROM ( ");
            //sql.Append(" SELECT Switch(a.Process_Flag='0' or a.Process_Flag is null ,'未处理',");
            //sql.Append(" a.Process_Flag='1','已处理') as Process_Flag,a.ID,a.Map_orgid,a.MAP_ORGTYPE,a.ORG_ID,a.DATA_ORG_ID,a.CODE,a.FULL_NAME,");
            //sql.Append(" a.EASY_NAME,a.MODIFY_USERID, a.MODIFY_DATE,a.SYNC_STATE,a.ADDRESS,a.LINKMAN,a.TELPHONE,a.POSTCODE, ");//IIF(a.org_id  = ''
            //sql.Append(" IIF(a.IsMap='0' or a.IsMap is null,'未匹配','已匹配') AS IsMap,a.IsMap as IsMapFlag,a.Process_Flag as pfFlag from HC_CORP_MAP a left join  (");//or  a.org_id is null,'未匹配', '已匹配') as
            //sql.Append(" HC_org d on d.id=a.org_id ");
            //sql.Append(" WHERE a.MAP_ORGTYPE='1' order by a.ORG_ID");

            sql.Append(" SELECT distinct c.*,d.ORG_NAME AS name,d.ORG_ABBR AS abbr, ");
            sql.Append(" d.SPELL_ABBR AS spell_abbr,d.ORG_NAME_WB AS name_wb  FROM ");
            sql.Append(" (  SELECT (case a.Process_Flag when '0' then '未处理' when  null ");
            sql.Append(" then '未处理' when '1' then '已处理' end) as Process_Flag,a.ID,");
            sql.Append(" a.Map_orgid, a.MAP_ORGTYPE,a.ORG_ID,a.HIS_ORG_ID,a.FULL_NAME,  ");
            sql.Append(" a.EASY_NAME,a.MODIFY_USERID, a.MODIFY_DATE,a.SYNC_STATE, ");
            sql.Append(" a.ADDRESS,a.LINKMAN,a.TELPHONE,a.POSTCODE,  ");
            sql.Append(" (case a.IsMap when '0' then '未匹配' when null then '未匹配' ");
            sql.Append(" else '已匹配' end) AS IsMap, a.IsMap as IsMapFlag,a.Process_Flag as ");
            sql.Append(" pfFlag from  HC_CORP_MAP  a)c left join  HC_org d on d.id=c.org_id  ");
            sql.Append(" WHERE c.MAP_ORGTYPE='1' order by c.ORG_ID");
            return sql.ToString();
        }

        /// <summary>
        /// 获得企业编码对照查询 HIS企业对照列表SQL
        /// </summary>
        /// <returns></returns>
        public string GetCompareListSql()
        {
            StringBuilder sb = new StringBuilder();
            //str1s.Append("select sender.*,hisCorp.* from (select sender_orgid as send_orgid,");
            //str1s.Append(" bak_sender_fullname as name, bak_sender_shortname as abbr,bak_sender_pinyin");
            //str1s.Append(" as spell_abbr,bak_sender_wubi as name_wb from ord_hit_comm union select");
            //str1s.Append(" send_orgid, name, abbr, spell_abbr, name_wb from con_list_item_send union select");
            //str1s.Append(" send_orgid, name,abbr, spell_abbr,name_wb from ord_hit_comm_send) as sender");
            //str1s.Append(" left join (select b.org_id, IIF(count(b.id) is null, '0', count(b.id)) as MapSum");
            //str1s.Append(" from his_corp_map b group by b.org_id) as hisCorp on sender.send_orgid =");
            //str1s.Append(" hisCorp.org_id where hisCorp.MapSum >= 1");

            //原sql
            //sb.Append("select distinct c.ORG_NAME AS name,C.ORG_EASY AS abbr,C.ORG_PINYIN AS ");
            //sb.Append(" spell_abbr,C.ORG_WUBI AS name_wb,a.* from (");
            //sb.Append(" select sender.* , hisCorp.* from");
            //sb.Append(" ( select saler_id as send_orgid");
            //sb.Append(" from cont_item");
            //sb.Append(" union select sender_id as send_orgid");
            //sb.Append(" from cont_list_sender");
            //sb.Append(" union select saler_id as send_orgid");
            //sb.Append(" from gpo_comm_sender  ) as sender");

            //sb.Append(" left join ( select b.org_id,");
            //sb.Append(" IIF( count(b.id) is null , '0' , count(b.id) ) as MapSum");
            //sb.Append(" from GPO_CORP_MAP b");
            //sb.Append(" group by b.org_id ) as hisCorp");
            //sb.Append(" on sender.send_orgid = hisCorp.org_id where hisCorp.MapSum >= 1");
            //sb.Append(" ) a left join cont_org c on a.send_orgid=c.org_id"); 

            //现sql
            sb.Append(" select distinct c.ORG_NAME AS name,C.ORG_ABBR AS abbr,");

            sb.Append(" C.SPELL_ABBR AS  spell_abbr,C.ORG_NAME_WB AS name_wb,a.* from ");

            sb.Append(" ( select sender.* , hisCorp.* from ( select sender_id as send_orgid from HC_ORD_BUYER_SENDER ");

            sb.Append("  ) as sender left join ( select b.org_id, ");

            sb.Append(" (case when count(b.id) is null then '0' else count(b.id) end) as MapSum from ");

            sb.Append(" hc_CORP_MAP b group by b.org_id ) as hisCorp on sender.send_orgid ");

            sb.Append(" = hisCorp.org_id where hisCorp.MapSum >= 1 ) a left join hc_org c ");

            sb.Append(" on a.send_orgid=c.id and c.SENDER_FLAG='1' ");

            return sb.ToString();

        }
        /// <summary>
        /// 获得企业编码对照列表
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
        ///  获取获取交易中心企业列表SQL
        /// </summary>
        /// <returns></returns>
        public string GetEmedCorpListDsSQL()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("select sender.*,hisCorp.* from\r\n\t\t\t\t\t");
            //sb.Append("( select sender_orgid as send_orgid, bak_sender_fullname as name, bak_sender_shortname as abbr,");
            //sb.Append("bak_sender_pinyin as spell_abbr, bak_sender_wubi as name_wb\r\n");
            //sb.Append("from ord_hit_comm\r\n");
            //sb.Append("union\r\n");
            //sb.Append("select send_orgid , name, abbr, spell_abbr, name_wb\r\nfrom con_list_item_send\r\n");
            //sb.Append("union\r\n");
            //sb.Append("select send_orgid, name, abbr, spell_abbr, name_wb\r\nfrom ord_hit_comm_send ) as sender \r\n\t\t\t\t\t");
            //sb.Append("left join \r\n\t\t\t\t\t( select b.org_id,\r\n\t\t\t\t\t");
            //sb.Append("IIF( count(b.id) is null , '0' , count(b.id) ) as MapSum \r\n\t\t\t\t\t");
            //sb.Append("from gpo_corp_map b \r\n\t\t\t\t\t");
            //sb.Append(" group by b.org_id ) \r\n\t\t\t\t\t");
            //sb.Append("as hisCorp\r\n\t\t\t\t\t");
            //sb.Append("on sender.send_orgid = hisCorp.org_id ");

            //原SQL
            //sb.Append("select distinct c.ORG_NAME AS name,C.ORG_EASY AS abbr,C.ORG_PINYIN AS ");
            //sb.Append(" spell_abbr,C.ORG_WUBI AS name_wb,a.* from (");
            //sb.Append(" select sender.* , hisCorp.* from");
            //sb.Append(" ( select saler_id as send_orgid");
            //sb.Append(" from cont_item");
            //sb.Append(" union select sender_id as send_orgid");
            //sb.Append(" from cont_list_sender");
            //sb.Append(" union select saler_id as send_orgid");
            //sb.Append(" from gpo_comm_sender  ) as sender");

            //sb.Append(" left join ( select b.org_id,");
            //sb.Append(" IIF( count(b.id) is null , '0' , count(b.id) ) as MapSum");
            //sb.Append(" from GPO_CORP_MAP b");
            //sb.Append(" group by b.org_id ) as hisCorp");
            //sb.Append(" on sender.send_orgid = hisCorp.org_id");
            //sb.Append(" ) a left join cont_org c on a.send_orgid=c.org_id"); 

            //现SQL
            sb.Append("select distinct c.ORG_NAME AS name,C.ORG_ABBR AS abbr,C.SPELL_ABBR ");

            sb.Append(" AS  spell_abbr,C.ORG_NAME_WB AS name_wb,a.* from ( select sender.* , ");

            sb.Append(" hisCorp.* from (  select ");

            sb.Append(" sender_id as send_orgid from HC_ORD_BUYER_SENDER ) as sender left join ");

            sb.Append(" ( select b.org_id, (case when count(b.id) is null then '0' else count(b.id) end) ");

            sb.Append(" as MapSum from hc_CORP_MAP b group by b.org_id ) as hisCorp on ");

            sb.Append(" sender.send_orgid = hisCorp.org_id ) a left join hc_org c on ");

            sb.Append(" a.send_orgid=c.id and c.SENDER_FLAG='1'");

            return sb.ToString();
        }

        /// <summary>
        /// 增加对照企业
        /// </summary>
        /// <returns></returns>
        public void InsertHisErpCorpMap(Gpo_EnterPrice_MapModel input)
        {
            int result ;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result=base.DbFacade.SQLExecuteNonQuery(InsertHisErpCorpMapSQL(input), transaction);
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
        /// 增加对照企业SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string InsertHisErpCorpMapSQL(Gpo_EnterPrice_MapModel input)
        {
            StringBuilder sb = new StringBuilder();
            //string GlobalID = IdUtil.GetGlobalId();

            long GlobalID =this.GetClientId(input.User.HighId);
            sb.Append("insert into hc_corp_map( \r\n\t\t\t\t\t");
            sb.Append("ID,MAP_ORGTYPE,MAP_ORGID,ORG_ID,HIS_ORG_ID,FULL_NAME,EASY_NAME,\r\n");
            sb.Append("MODIFY_USERID,MODIFY_DATE,ISSENDER,SYNC_STATE,Process_Flag,ISMAP) values \r\n");
            sb.Append("('").Append(GlobalID).Append("',");
            sb.Append(" '1',");
            sb.Append("'").Append(input.MapOrgId).Append("',");
            sb.Append("'").Append(input.CorpId).Append("',");
            //sb.Append("'").Append(input.Data_org_id).Append("',");
            sb.Append("'").Append(input.CorpCode).Append("',");
            sb.Append("'").Append(input.CorpName).Append("',");
            sb.Append("'").Append(input.CorpAbbr).Append("',");
            sb.Append("'").Append(input.ModifyUserId).Append("',");
            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append("'1',");
            sb.Append("'0',");
            sb.Append("'").Append(input.Process).Append("',");
            sb.Append("'").Append(input.IsMap).Append("')");


            return sb.ToString();

        }

        public string InsertHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            StringBuilder sb = new StringBuilder();
            string GlobalID = IdUtil.GetGlobalId();

            //string GlobalID = this.GetClientId(input.User.HighId);
            sb.Append("insert into hc_corp_map( ");
            sb.Append("ID,MAP_ORGTYPE,MAP_ORGID,ORG_ID,HIS_ORG_ID,FULL_NAME,EASY_NAME,");
            sb.Append("MODIFY_USERID,MODIFY_DATE,ISSENDER,SYNC_STATE,Process_Flag) values ");
            sb.Append("('").Append(GlobalID).Append("',");
            sb.Append(" '1',");
            sb.Append("'").Append(MapOrgId).Append("',");
            sb.Append("'").Append(inRow["org_id"].ToString()).Append("',");
            sb.Append("'").Append(inRow["sender_code"].ToString()).Append("',");
            sb.Append("'").Append(inRow["sender_name"].ToString()).Append("',");
            sb.Append("'").Append(inRow["sender_name"].ToString()).Append("',");
            sb.Append("'").Append(inUserId).Append("',");
            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append("'1',");
            sb.Append("'0',");
            sb.Append("'").Append(inRow["process_flag"].ToString().Equals("true") ? "1" : "0").Append("')");

            return sb.ToString();

        }

        public string cancelMatchSQL(Gpo_EnterPrice_MapModel input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update hc_corp_map");
            //start modify by gaoyuan 2007.3.12
            sb.AppendFormat(" set ORG_ID='{0}'", input.CorpId);
            //sb.Append(",data_org_id=''");
            //sb.AppendFormat(" set BUYER_ORGID='{0}'", input.MapOrgId);
            //sb.AppendFormat(",ORG_ID='{0}'", input.CorpId);
            //end modify by gaoyuan 2007.3.12
            sb.AppendFormat(",FULL_NAME='{0}'", input.CorpName);
            sb.AppendFormat(",EASY_NAME='{0}'", input.CorpAbbr);
            sb.AppendFormat(",MODIFY_USERID='{0}'", input.ModifyUserId);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(",ISSENDER='1'");
            sb.Append(",SYNC_STATE='0'");
            sb.AppendFormat(",Process_Flag='{0}'", input.Process);
            sb.AppendFormat(",ISMAP='{0}'", input.IsMap);
            sb.AppendFormat(" where HIS_ORG_ID='{0}'", input.CorpCode);
            sb.AppendFormat(" and map_orgid='{0}'", input.MapOrgId);
            return sb.ToString();
        }

        public void cancelMatch(Gpo_EnterPrice_MapModel input)
        {
            int result;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result = base.DbFacade.SQLExecuteNonQuery(cancelMatchSQL(input), transaction);
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

        public void UpdateHisErpCorpMap(Gpo_EnterPrice_MapModel input)
        {
            int result ;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result=base.DbFacade.SQLExecuteNonQuery(UpdateHisErpCorpMapSQL(input),transaction);
                    if (result>0)
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
        public string UpdateHisErpCorpMapSQL(Gpo_EnterPrice_MapModel input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update hc_corp_map");
            //start modify by gaoyuan 2007.3.12
            sb.AppendFormat(" set ORG_ID='{0}'", input.CorpId);
            //sb.AppendFormat(" set BUYER_ORGID='{0}'", input.MapOrgId);
            //sb.AppendFormat(",ORG_ID='{0}'", input.CorpId);
            //end modify by gaoyuan 2007.3.12
            sb.AppendFormat(",FULL_NAME='{0}'", input.CorpName);
            sb.AppendFormat(",EASY_NAME='{0}'", input.CorpAbbr);
            sb.AppendFormat(",MODIFY_USERID='{0}'", input.ModifyUserId);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(",ISSENDER='1'");
            sb.Append(",SYNC_STATE='0'");
            sb.AppendFormat(",Process_Flag='{0}'", input.Process);
            sb.AppendFormat(",ISMAP='{0}'",input.IsMap);
            sb.AppendFormat(" where HIS_ORG_ID='{0}'", input.CorpCode);
            sb.AppendFormat(" and map_orgid='{0}'",input.MapOrgId);
            return sb.ToString();
        }

        public string UpdateHisErpCorpMapSQL(DataRow inRow, string inUserId, string MapOrgId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update hc_corp_map");
            sb.AppendFormat(" set MAP_ORGID='{0}'", MapOrgId);
            sb.AppendFormat(",ORG_ID='{0}'", inRow["org_id"].ToString());
            sb.AppendFormat(",FULL_NAME='{0}'", inRow["sender_name"].ToString());
            sb.AppendFormat(",EASY_NAME='{0}'", inRow["sender_name"].ToString());
            sb.AppendFormat(",MODIFY_USERID='{0}'", inUserId);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(",ISSENDER='1'");
            sb.Append(",SYNC_STATE='0'");
            sb.AppendFormat(",Process_Flag='{0}'", inRow["process_flag"].ToString().Equals("true") ? "1" : "0");
            sb.AppendFormat(" where HIS_ORG_ID='{0}'", inRow["sender_code"].ToString());
            sb.AppendFormat(" and map_orgid='{0}'", MapOrgId);
       
            
            return sb.ToString();
        }

        /// <summary>
        /// 海虹企业对应HIS企业列表
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
        /// 海虹企业对应HIS企业列表SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetHisCorpByOrgId(string inOrgId)
        {
            return ("select * from hc_CORP_MAP where org_id = '" + inOrgId + "'");
        }

        /// <summary>
        /// 企业对应中心数据列表
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
        /// 企业对应中心数据列表SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string BuildCorpMapListSQL()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("select send_orgid,");
            //sb.Append("name,abbr,spell_abbr,name_wb,'' as org_id ,'' as MapSum from ");
            //sb.Append("gpo_comm_sender where 1=0");

            //原sql
            //sb.Append("select c.ORG_NAME AS name,C.ORG_EASY AS abbr,");
            //sb.Append(" C.ORG_PINYIN AS spell_abbr,C.ORG_WUBI AS name_wb,saler_id as send_orgid,'' as org_id ,'' as MapSum ");
            //sb.Append(" from gpo_comm_sender gsc left join cont_org c on gsc.saler_id=c.org_id where 1=0");
            
            sb.Append("select c.ORG_NAME AS name,C.ORG_ABBR AS abbr, C.SPELL_ABBR AS spell_abbr,");

            sb.Append(" C.ORG_NAME_WB AS name_wb,sender_id as send_orgid,'' as org_id ,'' as MapSum  ");

            sb.Append(" from HC_ORD_BUYER_SENDER gsc left join HC_org c on gsc.sender_id=c.id ");

            sb.Append(" where 1=0 AND C.SENDER_FLAG='1'");
            
            return sb.ToString();
        }

        public int JudgeHIScode(string code, string MapOrgId)
        {
            return int.Parse(base.DbFacade.SQLExecuteScalar(judgeEPHISCode(code, MapOrgId)).ToString());
        }
        private string judgeEPHISCode(string code, string MapOrgId)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(HIS_ORG_ID) from hc_CORP_MAP");
            sqlstr.AppendFormat(" where HIS_ORG_ID='{0}'", code);
            sqlstr.AppendFormat(" and Map_orgid='{0}'", MapOrgId);

            return sqlstr.ToString();
        }

        public string DeleteHisErpCorpMapSQL(string mapId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from hc_corp_map");
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
                    string sqlSearch = " select * from hc_corp_map where id = '" + mapId + "'";
                    DataTable dt = base.DbFacade.SQLExecuteDataTable(sqlSearch, transaction);
                    if (dt == null || dt.Rows.Count < 0)
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                        return;
                    }
                    bool insertflg = false;
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    insertflg = base.addDelLog("hc_CORP_MAP", dr["id"].ToString(), "ID", ClientSession.GetInstance().CurrentUser.UserInfo.Id, "1", transaction);
                    //    if (!insertflg)
                    //    {
                    //        base.DbFacade.RollbackTransaction(transaction);
                    //        return;
                    //    }
                    //}

                    rownum = base.DbFacade.SQLExecuteNonQuery(sql, transaction);
                    if (rownum > 0 )//&& insertflg)
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
            string sql = "select id from hc_CORP_MAP where HIS_ORG_ID = '" + senderID + "' and MAP_ORGID='" + CurrentOrgId + "'";
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
        /// 新增企业编码对照匹配信息SQL
        /// </summary>
        /// <param name="inRow"></param>
        /// <param name="inUserId"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        public string InsertHisEnterpriseMapSQL(DataGridViewRow inRow, int inUserId, string MapOrgId)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into hc_corp_map( ");
            sb.Append("ID,MAP_ORGTYPE,Map_ORGID,HIS_ORG_ID,FULL_NAME,EASY_NAME,ADDRESS, POSTCODE,TELPHONE, LINKMAN,");
            sb.Append("ISFACTORY,ISSENDER,ISSALER,");
            sb.Append("Process_Flag,org_id,MODIFY_USERID,MODIFY_DATE,SYNC_STATE,ISMAP) values ");

            sb.Append("('").Append(this.GetClientId(inUserId)).Append("',");
            sb.Append("'1',");
            sb.Append("'").Append(MapOrgId).Append("',");
            //sb.Append("'").Append(inRow.Cells["DATA_ORG_ID"].Value == null ? "" : inRow.Cells["DATA_ORG_ID"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["HIS_ORG_ID"].Value == null ? "" : inRow.Cells["CODE"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["FULL_NAME"].Value== null ? "" :inRow.Cells["FULL_NAME"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["EASY_NAME"].Value== null ? "" :inRow.Cells["EASY_NAME"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ADDRESS"].Value == null ? "":inRow.Cells["ADDRESS"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["POSTCODE"].Value == null ? "" :inRow.Cells["POSTCODE"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["TELPHONE"].Value == null ? "" :inRow.Cells["TELPHONE"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["LINKMAN"].Value == null ? "" : inRow.Cells["LINKMAN"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ISFACTORY"].Value == null ? "" : inRow.Cells["ISFACTORY"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ISSENDER"].Value == null ? "" : inRow.Cells["ISSENDER"].Value.ToString()).Append("',");
            sb.Append("'").Append(inRow.Cells["ISSALER"].Value == null ? "" : inRow.Cells["ISSALER"].Value.ToString()).Append("',");
            sb.Append("0").Append(",");
            sb.Append("'").Append(inRow.Cells["ORG_ID"].Value == null ? "" : inRow.Cells["ORG_ID"].Value.ToString()).Append("',");
            sb.Append("'").Append(inUserId).Append("',");
            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            //start Modify by gaoyuan 2007.3.12
            sb.Append("0").Append(",");
            sb.Append("'").Append(inRow.Cells["ORG_ID"].Value.ToString().Equals("") ? "0" : "1").Append("')");
            //end Modify by gaoyuan 2007.3.12
            //sb.Append("'").Append(inRow["MEDICAL_CODE"].ToString()).Append("',");
            //sb.Append("'").Append(inRow["PRODUCT_CODE"].ToString()).Append("',");
            //sb.Append("'").Append(inRow["process_flag"].ToString().Equals("true") ? "1" : "0").Append("')");

            return sb.ToString();

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
            StringBuilder sb = new StringBuilder();
            sb.Append("update gpo_corp_map set ");

            //sb.Append(" DATA_ORG_ID=").Append("'").Append(inRow.Cells["DATA_ORG_ID"].Value.ToString()).Append("',");
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
            sb.Append(" and HIS_ORG_ID='").Append(code).Append("'");

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
