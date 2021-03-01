//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	ProductCodeCompareDAL.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-5-21
//	功能描述:	产品编码匹配业务数据访问层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.Map;
//using Emedchina.TradeAssistant.Client.DAL.Query;

namespace Emedchina.TradeAssistant.Client.DAL.Map.Product
{
    class ProductCodeCompareDAL : SqlDAOBase
    {
        private ProductCodeCompareDAL()
            : base()
        { }

        private ProductCodeCompareDAL(string connectionName)
            : base(connectionName)
        { }

        public static ProductCodeCompareDAL GetInstance()
        {
            return new ProductCodeCompareDAL();
        }

        public static ProductCodeCompareDAL GetInstance(string connectionName)
        {
            return new ProductCodeCompareDAL(connectionName);
        }

        #region 查询产品编码对照列表
        /// <summary>
        /// 查询 产品编码对照列表信息
        /// </summary>
        /// <param name="input">产品编码对照表实体类</param>
        /// <returns></returns>
        public DataTable ProductCodeCompareList(Gpo_Product_MapModel input)
        {
            DataTable dt = new DataTable();

            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter param;

            if (!string.IsNullOrEmpty(input.IsMap))
            {
                //匹配状态      
                param = base.DbFacade.CreateParameter();
                param.ParameterName = "IsMap";
                param.DbType = DbType.String;
                param.Value = input.IsMap;
                parameters.Add(param);
            }

            if (!string.IsNullOrEmpty(input.ProcessFlag))
            {
                //处理状态
                param = base.DbFacade.CreateParameter();
                param.ParameterName = "PROCESS_FLAG";
                param.DbType = DbType.String;
                param.Value = input.ProcessFlag;
                parameters.Add(param);
            }

            if (!string.IsNullOrEmpty(input.MedicaName))
            {
                //药品名称
                param = base.DbFacade.CreateParameter();
                param.ParameterName = "MedicaName";
                param.DbType = DbType.String;
                param.Value = '%' + input.MedicaName + '%';
                parameters.Add(param);
            }

            if (!string.IsNullOrEmpty(input.FactoryName))
            {
                //生产企业
                param = base.DbFacade.CreateParameter();
                param.ParameterName = "FACTORY_NAME";
                param.DbType = DbType.String;
                param.Value = '%' + input.FactoryName + '%';
                parameters.Add(param);
            }

            if (!string.IsNullOrEmpty(input.ProductCode))
            {
                //产品名称
                param = base.DbFacade.CreateParameter();
                param.ParameterName = "PRODUCT_CODE";
                param.DbType = DbType.String;
                param.Value = '%' + input.ProductCode + '%';
                parameters.Add(param);
            }

            try
            {
                dt = DbFacade.SQLExecuteDataTable(GetGpo_Produce_MapListSql(input), parameters.ToArray());
            }
            catch(Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }

        /// <summary>
        /// 获取对接产品对照表SQL
        /// </summary>
        /// <returns></returns>
        private string GetGpo_Produce_MapListSql(Gpo_Product_MapModel input)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append(" SELECT Id, map_orgtype, map_orgid, hit_comm_id,");
            sqlstr.Append("product_id, data_product_id, saler_id, sender_id,");
            sqlstr.Append("enter_id, medical_code, product_code, common_name,");
            sqlstr.Append("product_name,");
            sqlstr.Append("COMMON_NAME + '(' + product_name + ')' As HisProduct_Name, ");
            sqlstr.Append("mode_id, mode_name, medical_spec_id, medical_spec, stand_rate, use_unit_id, use_unit,");
            sqlstr.Append("spec_unit_id, spec_unit, permit_no, factory_code, factory_name, saler_code, saler_name,");
            sqlstr.Append("sender_code, sender_name, category_id, category_name, stock_id, stock_name, package_rate,");
            sqlstr.Append("modify_userid, modify_date, process_flag, sync_state, remark, factory_id,");
            sqlstr.Append("case when IsMap = '1' then '已匹配' else '未匹配' end As Is_Map,");
            sqlstr.Append("case when process_flag = '1' then '已处理'else '未处理' end As Is_Process_flag");
           
            sqlstr.Append(" From GPO_PRODUCT_MAP_VIEW");
            sqlstr.Append(" Where 1=1");
            if (!string.IsNullOrEmpty(input.IsMap))
            {
                if (input.IsMap == "0")
                {
                    sqlstr.Append(" And (IsMap=:IsMap Or IsMap is null)");
                }
                else
                {
                    sqlstr.Append(" And IsMap=:IsMap");
                }
            }

            if (!string.IsNullOrEmpty(input.ProcessFlag))
            {
                if (input.ProcessFlag == "0")
                {
                    sqlstr.Append(" And (PROCESS_FLAG=:PROCESS_FLAG Or PROCESS_FLAG Is null)");
                }
                else
                {
                    sqlstr.Append(" And PROCESS_FLAG=:PROCESS_FLAG");
                }
            }
            if (!string.IsNullOrEmpty(input.MedicaName))
            {
                sqlstr.Append(" AND (COMMON_NAME & PRODUCT_NAME) LIKE :MedicaName");
            }
            if (!string.IsNullOrEmpty(input.FactoryName))
            {
                sqlstr.Append(" And FACTORY_NAME Like :FACTORY_NAME");
            }
            if (!string.IsNullOrEmpty(input.ProductCode))
            {
                sqlstr.Append(" And PRODUCT_CODE Like :PRODUCT_CODE");
            }
            sqlstr.Append(" Order By id");
            return sqlstr.ToString();
        }
        #endregion

        #region 获得产品对照查询的海虹产品列表

        public DataTable GetCommList()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = DbFacade.SQLExecuteDataTable(GetCommListSql());
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }


        private string GetCommListSql()
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append(" select id,");
            sqlstr.Append("map_orgtype,");
            sqlstr.Append("map_orgid,");
            sqlstr.Append("hit_comm_id,");
            sqlstr.Append("product_id,");
            sqlstr.Append("data_product_id,");
            sqlstr.Append("saler_id,");
            sqlstr.Append("sender_id,");
            sqlstr.Append("enter_id,");
            sqlstr.Append("medical_code,");
            sqlstr.Append("product_code,");
            sqlstr.Append("common_name ,");
            sqlstr.Append("product_name ,");
            sqlstr.Append("common_name + '(' + isnull(product_name,'') + ')' As HisProduct_Name,");
            sqlstr.Append("mode_id, mode_name, medical_spec_id, medical_spec, stand_rate,");
            sqlstr.Append("use_unit_id, use_unit, spec_unit_id, spec_unit, permit_no, factory_code,");
            sqlstr.Append("factory_name, saler_code, saler_name, sender_code, sender_name, category_id,");
            sqlstr.Append("category_name, stock_id, stock_name, package_rate, modify_userid, modify_date,");
            sqlstr.Append("process_flag, sync_state, remark, factory_id,IsMap,Process_flag,");
            sqlstr.Append("case when ismap = '1' then '已匹配' else '未匹配' end As Is_Map,");
            sqlstr.Append("case when process_flag = '1' then  '已处理' else '未处理' end As Is_Process_flag");            
            sqlstr.Append(" from gpo_product_map_view");
            sqlstr.Append(" where 1=1");

            return sqlstr.ToString();
        }

        #endregion

        #region 获得新增产品编码匹配的采购供应目录列表
        //获得新增产品编码匹配的采购供应目录列表
        public DataTable GetGpoHitCommList()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = DbFacade.SQLExecuteDataTable(GetGpoHitCommListSql());//HitCommAndContClientDao.GetOftenPurchaseListSql()
            }
            catch(Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }

        //获得新增产品编码匹配的采购供应目录列表SQL
        private string GetGpoHitCommListSql()
        {
            //cp.FACTORY_EASY,cp.FACTORY_WUBI,cp.FACTORY_PINYIN,
            StringBuilder sqlstr = new StringBuilder();

            sqlstr.Append("select sender.*, gpocorp.mapsum from");
            sqlstr.Append(" (select pt.name as source,ci.id As record_id,ci.product_id,ci.factory_id,ci.saler_id,ci.ord_send_id, co1.org_name as factory_name,co1.org_easy as factory_easy,co1.org_wubi as factory_wubi,co1.org_pinyin as factory_pinyin,ci.provide_price,co.org_id as sender_id,co.org_name,co.org_easy,co.org_pinyin,co.org_wubi,cp.medical_name,cp.medical_wubi,cp.medical_pinyin,cp.trade_name,cp.spell_abbr,cp.name_wb,ci.doseage_form,cp.quality_name,ci.spec_unit");
            sqlstr.Append(" ,(isnull(ci.spec,'-') +  '*' + cast(isnull( ci.stand_rate,'0') as varchar(10))  +  isnull(ci.use_unit,'' ) +  '/'  +  isnull(ci.spec_unit,'')) As unc_spec");            
            sqlstr.Append(" from cont_item ci ,cont_org co,cont_product cp,cont_list cl,project_type pt ,cont_org co1 ");
            sqlstr.Append(" where ci.saler_id=co.org_id  and ci.project_id=co.project_id and cp.product_id=ci.product_id and cp.project_id=ci.project_id");
            sqlstr.Append(" and ci.contract_id = cl.id and cl.type_code=pt.code  and co1.org_id = ci.factory_id and ci.project_id = co1.project_id ");
            sqlstr.Append("  and  exists  (select 1 from (select min(id) id  from cont_item ");
            sqlstr.Append(" group by product_id) r where r.id = ci.id  )     ) sender");
            sqlstr.Append(" left join ");
            sqlstr.Append(" (select");
            sqlstr.Append(" b.product_id, case when count(b.id) is null then '0' else count(b.id) end  as mapsum ");
            sqlstr.Append(" from gpo_product_map_view b  group by b.product_id) as gpocorp on  sender.product_id =");
            sqlstr.Append(" gpocorp.product_id");

            return sqlstr.ToString();
        }

        #endregion


        #region 获得产品对照查询的HIS产品对照列表

        public DataTable GetGpoMapList(string porductID)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = DbFacade.SQLExecuteDataTable(GetGpoMapSql(porductID));
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }

        /// <summary>
        /// 获得产品对照查询的HIS产品对照列表SQL
        /// </summary>
        /// <param name="commid">海虹产品的PRODUCT_ID</param>
        /// <returns></returns>
        private string GetGpoMapSql(string porductID)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" Select * From GPO_PRODUCT_MAP_VIEW where PRODUCT_ID = '" + porductID + "'");
            return strsql.ToString();
        }

        #endregion

        /// <summary>
        ///获得一条HIS产品记录
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        public Gpo_Product_MapModel GetGpoMapModelById(string strId)
        {                
            StringBuilder strsql = new StringBuilder("SELECT *");
            strsql.Append(" from GPO_PRODUCT_MAP where ID = '" + strId + "'");

            DataTable dt = null;
            Gpo_Product_MapModel product_MapModel = null;
            try
            {
                dt = DbFacade.SQLExecuteDataTable(strsql.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    product_MapModel = GetModelByRow(dt.Rows[0]);
                }
            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
            return product_MapModel;
        }

        /// <summary>
        ///获得一条HIS产品记录
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        public Gpo_Product_MapModel GetGpoMapModel(string productcode)
        {
            DataTable dt = null;
            Gpo_Product_MapModel product_MapModel = null;
            try
            {
                dt = DbFacade.SQLExecuteDataTable(GetHISItemByProductCode(productcode));

                if (dt != null && dt.Rows.Count >0)
                {
                    product_MapModel = GetModelByRow(dt.Rows[0]);
                }
            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
            return product_MapModel;
        }

        /// <summary>
        /// 获得一条HIS产品记录SQL
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        private string GetHISItemByProductCode(string productcode)
        {
            StringBuilder str1s = new StringBuilder("SELECT *");
            str1s.Append(" from GPO_PRODUCT_MAP_VIEW where PRODUCT_CODE = '" + productcode + "'");
            return str1s.ToString();
        }


        protected Gpo_Product_MapModel GetModelByRow(DataRow row)
        {
            //定义采购申请主表实体类
            Gpo_Product_MapModel Model = new Gpo_Product_MapModel();
            if (row == null)
            { return null; }

            Model.ProductCode = ComUtil.getStringValue(row, "PRODUCT_CODE", "");
            Model.Mode_ID = ComUtil.getStringValue(row, "MODE_ID", "");
            Model.Mode_Name = ComUtil.getStringValue(row, "MODE_NAME", "");
            Model.Product_Name = ComUtil.getStringValue(row, "PRODUCT_NAME", "");
            Model.CommonName = ComUtil.getStringValue(row, "COMMON_NAME", "");
            Model.Package_Rate = ComUtil.getStringValue(row, "PACKAGE_RATE", "");
            Model.Factory_Name = ComUtil.getStringValue(row, "FACTORY_NAME", "");
            Model.Remark = ComUtil.getStringValue(row, "REMARK", "");
            Model.Medical_Spec_Id = ComUtil.getStringValue(row, "MEDICAL_SPEC_ID", "");
            Model.Medical_Spec = ComUtil.getStringValue(row, "MEDICAL_SPEC", "");
            Model.Spec_Unit = ComUtil.getStringValue(row, "SPEC_UNIT", "");
            Model.Spec_Unit_Id = ComUtil.getStringValue(row, "SPEC_UNIT_ID", "");
            Model.Stand_Rate = ComUtil.getStringValue(row, "STAND_RATE", "");
            Model.Use_Unit = ComUtil.getStringValue(row, "USE_UNIT", "");
            Model.Factory_Code = ComUtil.getStringValue(row, "FACTORY_CODE", "");
            Model.UseUnitCode = ComUtil.getStringValue(row, "USE_UNIT", "");
            Model.ProcessFlag = ComUtil.getStringValue(row, "PROCESS_FLAG", "");

            return Model;
        }

        //判断产品编码是否重复
        public bool JudgeHisProductCode(string productcode)
        {
            bool flag = false;

            string sqlstr = "select count(1) from GPO_PRODUCT_MAP_VIEW where PRODUCT_CODE='" + productcode + "'";

            try
            {
                int count = Convert.ToInt16(DbFacade.SQLExecuteScalar(sqlstr).ToString());

                if (count > 0)
                {
                    flag = true;        //重复
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        //对接产品对照表 新增记录
        public bool Add_Gpo_Product_Map(Gpo_Product_MapModel input,out string strID)
        {
            bool flag = false;
            using (DbTransaction dbTran = DbFacade.BeginTransaction(DbFacade.OpenConnection()))
            {
                try
                {
                    DbFacade.SQLExecuteNonQuery(CreateProductComprison(input, out strID));
                    flag = true;
                    DbFacade.CommitTransaction(dbTran);
                }
                catch (Exception ex)
                {
                    DbFacade.RollbackTransaction(dbTran);
                    throw ex;                   
                }
            }
            return flag;
        }
        /// <summary>
        /// 批量增加产品匹配
        /// </summary>
        /// <returns></returns>
        public bool Add_Gpo_Product_Map_Batch(string [] sArray)
        {
            using (DbTransaction dbTran = DbFacade.BeginTransaction(DbFacade.OpenConnection()))
            {
                try
                {
                    bool bFlag = DbFacade.SQLExecuteNonQuery(sArray,dbTran);
                    DbFacade.CommitTransaction(dbTran);
                    return bFlag;
                }
                catch                 
                {
                    DbFacade.RollbackTransaction(dbTran);
                    throw;
                }
            }

        }

        //获取新增SQL语句
        public string CreateProductComprison(Gpo_Product_MapModel input,out string strID)
        {
            string id = base.GetGlobalId();
            strID = id.ToString();
            string buyerid = input.Map_Orgid;
            string productid = input.ProductID;
            string salerid = input.Saler_Id;
            string senderid = input.Sender_Id;
            string factoryid = input.Factory_Id;
            string code = input.ProductCode;
            string modecode = input.Mode_ID;
            string modename = input.Mode_Name;
            string name = input.Product_Name ;
            string Commonname = input.CommonName;

            int packagerate = 1;
            if (!string.IsNullOrEmpty(input.Package_Rate))
                packagerate = int.Parse(input.Package_Rate);

            string producer = input.Factory_Name;
            string factory_Code = input.Factory_Code;

            string remark = input.Remark;
            string speccode = input.Medical_Spec_Id;
            string specname = input.Medical_Spec;
            string specunit = input.Spec_Unit;
            string specunitcode = input.Spec_Unit_Id;

            int standrate = 1;
            if (!string.IsNullOrEmpty(input.Stand_Rate))
                standrate = int.Parse(input.Stand_Rate);

            string useunit = input.Use_Unit;
            string useunitcode = input.UseUnitCode;
            string read = input.ProcessFlag;
            string ismap = input.IsMap;

            StringBuilder sqlstr = new StringBuilder();

            sqlstr.AppendFormat("insert into GPO_PRODUCT_MAP (ID,PRODUCT_ID,MAP_ORGID,MAP_ORGTYPE,FACTORY_ID,SALER_ID,SENDER_ID,SPEC_UNIT,PACKAGE_RATE,MODE_NAME,REMARK,SPEC_UNIT_ID,STAND_RATE,MODE_ID,FACTORY_NAME,FACTORY_CODE,USE_UNIT,USE_UNIT_ID,MEDICAL_SPEC,MEDICAL_SPEC_ID,PRODUCT_NAME,PRODUCT_CODE,SYNC_STATE,PROCESS_FLAG,IsMap,COMMON_NAME) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}', '{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')", id, productid, buyerid,'2' ,factoryid, salerid, senderid, specunit, packagerate, modename, remark, specunitcode, standrate, modecode, producer, factory_Code, useunit, useunitcode, specname, speccode, name, code,'0', read, ismap, Commonname);

            return sqlstr.ToString();
        }

        #region 修改

        //获取修改SQL语句
        private string UpdateComparison(Gpo_Product_MapModel input)
        {
            string buyerid = input.Map_Orgid;
            string productid = input.ProductID;
            string salerid = input.Saler_Id;
            string senderid = input.Sender_Id;
            string factoryid = input.Factory_Id;
            string code = input.ProductCode;
            string modecode = input.Mode_ID;
            string modename = input.Mode_Name;
            string name = input.Product_Name;
            string Commonname = input.CommonName;

            //int packagerate = 0;
            //if (!string.IsNullOrEmpty(input.Package_Rate))
            //    packagerate = int.Parse(input.Package_Rate);

            //string producer = input.Product_Name;
            string producer = input.Factory_Name;
            string factory_Code = input.Factory_Code;

            string remark = input.Remark;
            string speccode = input.Medical_Spec_Id;
            string specname = input.Medical_Spec;
            string specunit = input.Spec_Unit;
            string specunitcode = input.Spec_Unit_Id;

            //int standrate = 0;
            //if (!string.IsNullOrEmpty(input.Stand_Rate))
            //    standrate = int.Parse(input.Stand_Rate);

            string useunit = input.Use_Unit;
            string useunitcode = input.UseUnitCode;
            string read = input.ProcessFlag;
            string ismap = input.IsMap;

            StringBuilder sqlstr = new StringBuilder("Update GPO_PRODUCT_MAP");
            sqlstr.AppendFormat(" Set PRODUCT_ID='{0}'", productid);
            sqlstr.AppendFormat(",MAP_ORGID='{0}'", buyerid);
            sqlstr.AppendFormat(",FACTORY_ID='{0}'", factoryid);
            sqlstr.AppendFormat(",SALER_ID='{0}'", salerid);
            sqlstr.AppendFormat(",SENDER_ID='{0}'", senderid);
            sqlstr.AppendFormat(",MODE_ID='{0}'", modecode);
            sqlstr.AppendFormat(",MODE_NAME='{0}'", modename);
            sqlstr.AppendFormat(",PRODUCT_NAME='{0}'", name);
            sqlstr.AppendFormat(",COMMON_NAME='{0}'", Commonname);

            if (!string.IsNullOrEmpty(input.Package_Rate))
                sqlstr.AppendFormat(",PACKAGE_RATE='{0}'", input.Package_Rate);

            sqlstr.AppendFormat(",FACTORY_NAME='{0}'", producer);
            sqlstr.AppendFormat(",REMARK='{0}'", remark);
            sqlstr.AppendFormat(",MEDICAL_SPEC='{0}'", specname);
            sqlstr.AppendFormat(",SPEC_UNIT='{0}'", specunit);

            if (!string.IsNullOrEmpty(input.Stand_Rate))
                sqlstr.AppendFormat(",STAND_RATE='{0}'", input.Stand_Rate);

            sqlstr.AppendFormat(",USE_UNIT='{0}'", useunit);
            sqlstr.Append(",SYNC_STATE= 0");
            sqlstr.AppendFormat(",IsMap='{0}'", ismap);
            sqlstr.AppendFormat(",PROCESS_FLAG='{0}'", read);
            sqlstr.AppendFormat(" where ID='{0}'", input.ID);
            return sqlstr.ToString();
        }


        //对接产品对照表 修改记录
        public bool Edit_Gpo_Product_Map(Gpo_Product_MapModel input)
        {
            bool flag = false;

            try
            {
                DbFacade.SQLExecuteNonQuery(UpdateComparison(input));
            }
            catch (Exception ex)
            {
                throw ex;
                flag = false;
            }

            return flag;
        }

        #endregion


        //取消匹配
        public bool CancelComparion(string strId)
        {
            int rownum;
            bool flag = true;

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {

                StringBuilder sqlstr = new StringBuilder("Update GPO_PRODUCT_MAP");
                sqlstr.AppendFormat(" Set PRODUCT_ID=null,Data_PRODUCT_ID=null,SYNC_STATE = 0,IsMap='0' ");
                sqlstr.AppendFormat(" Where ID='{0}'", strId);

                try
                {
                    rownum = DbFacade.SQLExecuteNonQuery(sqlstr.ToString(), transaction);

                    if (rownum > 0)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        flag = false;
                        base.DbFacade.RollbackTransaction(transaction);
                    }
                }
                catch (Exception ex)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    return flag;
                }
            }

            return flag;
        }

        #region 删除产品对照信息
        //删除
        public void DeleteGpo_Product(string strid)
        {
            int rownum;
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.AppendFormat("Delete From Gpo_PRODUCT_MAP Where id='{0}'", strid);

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    string sqlSearch = " Select * from GPO_PRODUCT_MAP_VIEW where id = '" + strid + "'";
                    DataTable dt = base.DbFacade.SQLExecuteDataTable(sqlSearch, transaction);
                    if (dt == null || dt.Rows.Count < 0)
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                        
                        return;
                    }
                    bool insertflg = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        insertflg = base.addDelLog("Gpo_PRODUCT_MAP", dr["id"].ToString(), "ID", ClientSession.GetInstance().CurrentUser.UserInfo.Id, "1", transaction);
                        if (!insertflg)
                        {
                            base.DbFacade.RollbackTransaction(transaction);
                            return;
                        }
                    }

                    rownum = DbFacade.SQLExecuteNonQuery(sqlstr.ToString(), transaction);
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
        }
        #endregion

        #region 获取导出产品信息数据集
        //获取导出产品信息
        public DataTable GetExportGpoProductMapList()
        {
            DataTable dt = new DataTable();

            StringBuilder sqlstr = new StringBuilder();

            sqlstr.Append("Select ");
            sqlstr.Append(" cp.MEDICAL_NAME,cp.TRADE_NAME,ci.DOSEAGE_FORM");
            sqlstr.Append(" ,(isnull(ci.SPEC,'-') +  '*' + cast( isnull(ci.STAND_RATE,'0') as varchar(10)) + isnull(ci.USE_UNIT,'')  +  '/'  +  isnull(ci.SPEC_UNIT,'' ))As unc_spec,ci.FACTORY_NAME,");
            sqlstr.Append(" GPM.PRODUCT_ID,GPM.PRODUCT_CODE,GPM.PRODUCT_NAME,GPM.COMMON_NAME,GPM.MODE_NAME,");
            sqlstr.Append(" GPM.MEDICAL_SPEC,GPM.SPEC_UNIT,GPM.USE_UNIT,GPM.PACKAGE_RATE,GPM.STAND_RATE,");
            sqlstr.Append(" GPM.FACTORY_NAME,GPM.REMARK,GPM.PROCESS_FLAG");
            sqlstr.Append(" ,case when GPM.IsMap = '1' then '已匹配' else '未匹配' end  as IsMap");
            sqlstr.Append(" From Cont_Item ci ,CONT_PRODUCT cp, GPO_PRODUCT_MAP_VIEW GPM");
            sqlstr.Append(" Where cp.product_id=ci.product_id And cp.PROJECT_ID=ci.PROJECT_ID");
            sqlstr.Append(" And GPM.product_id=ci.product_id");

            try
            {
                dt = DbFacade.SQLExecuteDataTable(sqlstr.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }
        #endregion

        #region 导入产品数据
        //导入产品数据
        public bool Import_Gpo_Product(string orgid, IList<Gpo_Product_MapModel> list)
        {
            bool flag = true;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach(Gpo_Product_MapModel model in list)
                    {
                        string Excelsql;
                        //判断是否重复(MAP_ORGID+PRODUCT_CODE)
                        if (IsRepeat(orgid, model.ProductCode, transaction) == true)
                        {
                            //修改操作
                            Excelsql = UpdateProductComprisonSql(model, orgid);

                        }else
                        {
                            //新增操作
                            Excelsql = InsertProductComprisonSql(model, orgid);
                        }
                        
                        DbFacade.SQLExecuteNonQuery(Excelsql.ToString(), transaction);
                    }
                    //事务提交
                    base.DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    //事务取消
                    base.DbFacade.RollbackTransaction(transaction);
                    flag = false;
                    throw e;
                }
                return flag;
            }
        }

        //判断是否重复
        private bool IsRepeat(string orgid, string porductCode, DbTransaction transaction)
        {
            bool flag = false;

            string sqlSearch = string.Format(" Select * from GPO_PRODUCT_MAP_VIEW where MAP_ORGID = '{0}' And PRODUCT_CODE = '{1}'", orgid, porductCode);
            DataTable dt = base.DbFacade.SQLExecuteDataTable(sqlSearch, transaction);
            if (dt != null && dt.Rows.Count > 0)
            {
                flag = true; 
            }

            return flag;
        }

        //获取新增产品对照表语句
        private string InsertProductComprisonSql(Gpo_Product_MapModel model,string orgid)
        {
            //HIS单位转换比
            string standRate;
            if (string.IsNullOrEmpty(model.Stand_Rate))
                standRate = "1";
            else
                standRate = model.Stand_Rate;

            StringBuilder strsql = new StringBuilder();
            strsql.Append("Insert Into Gpo_Product_Map");
            strsql.Append("(ID,MAP_ORGID,PRODUCT_CODE,MEDICAL_CODE,COMMON_NAME,PRODUCT_NAME,MODE_ID,MODE_NAME,MEDICAL_SPEC_ID,MEDICAL_SPEC,USE_UNIT_ID,USE_UNIT,SPEC_UNIT_ID,SPEC_UNIT,STAND_RATE,FACTORY_CODE,FACTORY_NAME,product_id,data_product_id,MAP_ORGTYPE,PERMIT_NO,SALER_CODE,SALER_NAME,SENDER_CODE,SENDER_NAME,CATEGORY_ID,CATEGORY_NAME,STOCK_ID,STOCK_NAME,PACKAGE_RATE,SYNC_STATE)");
            strsql.Append(" Values");
            strsql.AppendFormat("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}','{18}','1','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}',{28},'0')",
                base.GetGlobalId(),
                orgid,
                model.ProductCode,
                model.MedicalCode,
                model.CommonName,
                model.Product_Name,
                model.Mode_ID,
                model.Mode_Name,
                model.Medical_Spec_Id,
                model.Medical_Spec,
                model.UseUnitCode,
                model.Use_Unit,
                model.Spec_Unit_Id,
                model.Spec_Unit,
                standRate,
                model.Factory_Code,
                model.Factory_Name,
                model.ProductID,
                model.DataProductID,
                model.Permit_No,
                model.Saler_Code,
                model.Saler_Name,
                model.Sender_Code,
                model.Sender_Name,
                model.Category_Id,
                model.Category_Name,
                model.Stock_Id,
                model.Stock_Name,
                model.Package_Rate
                );

            return strsql.ToString();
        }

        //获取修改产品对照表语句
        private string UpdateProductComprisonSql(Gpo_Product_MapModel model, string orgid)
        {
            StringBuilder sqlstr = new StringBuilder("Update GPO_PRODUCT_MAP Set ");
            sqlstr.AppendFormat("MEDICAL_CODE='{0}'", model.MedicalCode);
            sqlstr.AppendFormat(",COMMON_NAME='{0}'", model.CommonName);
            sqlstr.AppendFormat(",PRODUCT_NAME='{0}'", model.Product_Name);
            sqlstr.AppendFormat(",MODE_ID='{0}'", model.Mode_ID);
            sqlstr.AppendFormat(",MODE_NAME='{0}'", model.Mode_Name);
            sqlstr.AppendFormat(",MEDICAL_SPEC_ID='{0}'", model.Medical_Spec_Id);
            sqlstr.AppendFormat(",MEDICAL_SPEC='{0}'", model.Medical_Spec);
            sqlstr.AppendFormat(",USE_UNIT_ID='{0}'", model.UseUnitCode);
            sqlstr.AppendFormat(",USE_UNIT='{0}'", model.Use_Unit);
            sqlstr.AppendFormat(",SPEC_UNIT_ID='{0}'", model.Spec_Unit_Id);
            sqlstr.AppendFormat(",SPEC_UNIT='{0}'", model.Spec_Unit);

            //HIS单位转换比
            string standRate;
            if (string.IsNullOrEmpty(model.Stand_Rate))
                standRate = "1";
            else
                standRate = model.Stand_Rate;

            sqlstr.AppendFormat(",STAND_RATE={0}", standRate);
            sqlstr.AppendFormat(",FACTORY_CODE='{0}'", model.Factory_Code);
            sqlstr.AppendFormat(",FACTORY_NAME='{0}'", model.Factory_Name);
            sqlstr.AppendFormat(",product_id='{0}'", model.ProductID);
            sqlstr.AppendFormat(",data_product_id='{0}'", model.DataProductID);

            sqlstr.AppendFormat(",PERMIT_NO='{0}'", model.Permit_No);
            sqlstr.AppendFormat(",SALER_CODE='{0}'", model.Saler_Code);
            sqlstr.AppendFormat(",SALER_NAME='{0}'", model.Saler_Name);
            sqlstr.AppendFormat(",SENDER_CODE='{0}'", model.Sender_Code);
            sqlstr.AppendFormat(",SENDER_NAME='{0}'", model.Sender_Name);
            sqlstr.AppendFormat(",CATEGORY_ID='{0}'", model.Category_Id);
            sqlstr.AppendFormat(",CATEGORY_NAME='{0}'", model.Category_Name);
            sqlstr.AppendFormat(",STOCK_ID='{0}'", model.Stock_Id);
            sqlstr.AppendFormat(",STOCK_NAME='{0}'", model.Stock_Name);
            sqlstr.AppendFormat(",PACKAGE_RATE={0}", model.Package_Rate);
            sqlstr.Append(",SYNC_STATE='0'");
            sqlstr.AppendFormat(" Where MAP_ORGID='{0}'", orgid);
            sqlstr.AppendFormat(" And PRODUCT_CODE='{0}'", model.ProductCode);

            return sqlstr.ToString();
        }
        #endregion


        public DataTable GetProjectTypeDt()
        {
            DataTable dt = null;
            string sqlstr = "Select * From PROJECT_TYPE";
            try
            {
                dt = DbFacade.SQLExecuteDataTable(sqlstr);

            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
            return dt;
        }
        
        //GetErpItemByProcode
        public DataTable GetErpItemByProcode(string erpProductCode, string orgId)
        {
            DataTable dt = new DataTable();
            StringBuilder str1s = new StringBuilder("select *");
            str1s.Append(" from gpo_product_map where product_code = '" + erpProductCode + "' and  map_orgid ='" + orgId + "' and product_id is not null");
            dt = base.DbFacade.SQLExecuteDataTable(str1s.ToString());
            return dt;
        }

        //CreateProductComprison
        public string CreateProductComprison(ProductCropModel productmapinstance)
        {
            string id = base.GetGlobalId();
            string buyerid = productmapinstance.BuyerID;
            string productid = string.IsNullOrEmpty(productmapinstance.ProductID) ? "" : productmapinstance.ProductID;
            string salerid = productmapinstance.SalerID;
            string senderid = productmapinstance.SenderID;
            string factoryid = productmapinstance.FactoryID;
            string code = productmapinstance.Code;
            string modecode = productmapinstance.ModeCode;
            string modename = productmapinstance.ModeName;
            string name = productmapinstance.Name;
            int packagerate = int.Parse(productmapinstance.PackageRate);
            string producer = productmapinstance.Producer;
            string producercode = productmapinstance.ProducerCode;
            string remark = productmapinstance.Remark;
            string speccode = productmapinstance.SpecCode;
            string specname = productmapinstance.SpecName;
            string specunit = productmapinstance.SpecUnit;
            string specunitcode = productmapinstance.SpecUnitCode;
            int standrate = int.Parse(productmapinstance.StandRate);
            string useunit = productmapinstance.UseUnit;
            string useunitcode = productmapinstance.UseUnitCode;
            string read = productmapinstance.Read;
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.AppendFormat("insert into gpo_PRODUCT_MAP (ID,PRODUCT_ID,map_orgtype,MAP_ORGID,FACTORY_ID,SALER_ID,SENDER_ID,SPEC_UNIT,PACKAGE_RATE,MODE_NAME,REMARK,SPEC_UNIT_ID,STAND_RATE,MODE_ID,FACTORY_NAME,FACTORY_CODE,USE_UNIT,USE_UNIT_ID,MEDICAL_SPEC,MEDICAL_SPEC_ID,PRODUCT_NAME,PRODUCT_CODE,PROCESS_FLAG) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}', '{17}','{18}','{19}','{20}','{21}','{22}')", id, productid, '1', buyerid, factoryid, salerid, senderid, specunit, packagerate, modename, remark, specunitcode, standrate, modecode, producer, producercode, useunit, useunitcode, specname, speccode, name, code, read);
            base.DbFacade.SQLExecuteNonQuery(sqlstr.ToString());
            return id;
        }

        #region 修改产品编码匹配关系
        /// <summary>
        /// 修改产品编码匹配关系
        /// </summary>
        /// <param name="productmapinstance"></param>
        public void UpdateComparison(ProductCropModel productmapinstance)
        {
            string id = productmapinstance.ID;
            string buyerid = productmapinstance.BuyerID;
            string productid = productmapinstance.ProductID;
            string salerid = productmapinstance.SalerID;
            string senderid = productmapinstance.SenderID;
            string factoryid = productmapinstance.FactoryID;
            string code = productmapinstance.Code;
            string modename = productmapinstance.ModeName;
            string name = productmapinstance.Name;
            int packagerate = int.Parse(productmapinstance.PackageRate);
            string producer = productmapinstance.Producer;
            string remark = productmapinstance.Remark;
            string specname = productmapinstance.SpecName;
            string specunit = productmapinstance.SpecUnit;
            int standrate = int.Parse(productmapinstance.StandRate);
            string useunit = productmapinstance.UseUnit;
            string read = productmapinstance.Read;
            StringBuilder sqlstr = new StringBuilder("update GPO_PRODUCT_MAP");
            sqlstr.AppendFormat(" set PRODUCT_ID='{0}'", productid);
            sqlstr.AppendFormat(",MAP_ORGID='{0}'", buyerid);
            sqlstr.AppendFormat(",FACTORY_ID='{0}'", factoryid);
            sqlstr.AppendFormat(",SALER_ID='{0}'", salerid);
            sqlstr.AppendFormat(",SENDER_ID='{0}'", senderid);
            sqlstr.AppendFormat(",MODE_NAME='{0}'", modename);
            sqlstr.AppendFormat(",PRODUCT_NAME='{0}'", name);
            sqlstr.AppendFormat(",PACKAGE_RATE='{0}'", packagerate);
            sqlstr.AppendFormat(",FACTORY_NAME='{0}'", producer);
            sqlstr.AppendFormat(",REMARK='{0}'", remark);
            sqlstr.AppendFormat(",MEDICAL_SPEC='{0}'", specname);
            sqlstr.AppendFormat(",SPEC_UNIT='{0}'", specunit);
            sqlstr.AppendFormat(",STAND_RATE='{0}'", standrate);
            sqlstr.AppendFormat(",USE_UNIT='{0}'", useunit);
            sqlstr.AppendFormat(",PROCESS_FLAG='{0}'", read);
            sqlstr.AppendFormat(" where PRODUCT_CODE='{0}' and MAP_ORGID='{1}' and id='{2}'", code, buyerid, id);
            base.DbFacade.SQLExecuteNonQuery(sqlstr.ToString());
        }
        #endregion


        #region 判断ERP产品是否已添加

        /// <summary>
        /// 判断ERP产品是否已添加
        /// </summary>
        /// <param name="productcode"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public bool JudgeProductCode(string productcode, string orgid)
        {
            bool ismap = false;
            object ob = base.DbFacade.SQLExecuteScalar("select count(product_code) from gpo_product_map where product_code='" + productcode + "' and map_orgid='" + orgid + "'");
            if (ob != null && int.Parse(ob.ToString()) > 0)
            {
                ismap = true;
            }
            return ismap;
        }        
      

        /// <summary>
        /// 判断ERP产品是否已添加并返回记录ID
        /// </summary>
        /// <param name="productcode"></param>
        /// <param name="orgid"></param>
        /// <param name="sRecord_ID"></param>
        /// <returns></returns>
        public bool JudgeProductCode(string productcode, string orgid,ref string sRecord_ID)
        {
            bool bIsMap = false;
            try
            {
                IDataReader ir = base.DbFacade.SQLExecuteReader("select id from gpo_product_map where product_code='" + productcode + "' and map_orgid='" + orgid + "'");
                if (ir.Read())
                {
                    sRecord_ID = ir[0].ToString();
                    bIsMap = true;
                }             
            }
            catch
            {
                throw;               
            }
            return bIsMap;
        }
        #endregion

        /// <summary>
        /// 更新匹配数据
        /// </summary>
        /// <param name="sRecord_ID"></param>
        /// <param name="sProduct_ID"></param>
        public bool UpdateProductMap(string sRecord_ID, string sProduct_ID)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update gpo_product_map set ismap ='1',");
                sb.AppendFormat("product_id = '{0}' where id = '{1}'", sProduct_ID, sRecord_ID);
                int iCount = DbFacade.SQLExecuteNonQuery(sb.ToString());
                if (iCount == 1)
                {
                    return true;
                }
                return false;
            }
            catch
            { 
                throw ;                
            }
        }
    }
}
