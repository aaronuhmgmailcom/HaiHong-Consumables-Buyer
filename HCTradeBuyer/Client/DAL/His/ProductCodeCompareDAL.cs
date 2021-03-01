//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	ProductCodeCompareDAL.cs   
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
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
using Emedchina.TradeAssistant.Model.His;

namespace Emedchina.TradeAssistant.Client.DAL.His
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
                //产品名称
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
            sqlstr.Append(" SELECT Id, map_orgtype, map_orgid, hit_comm_id, product_id, data_product_id, saler_id, sender_id, enter_id, medical_code, product_code, common_name, product_name,COMMON_NAME & '(' & product_name & ')' As HisProduct_Name, mode_id, mode_name, medical_spec_id, medical_spec, stand_rate, use_unit_id, use_unit, spec_unit_id, spec_unit, permit_no, factory_code, factory_name, saler_code, saler_name, sender_code, sender_name, stock_id, stock_name, package_rate, modify_userid, modify_date, process_flag, sync_state, remark, factory_id, IIF(IsMap = '1' , '已匹配', '未匹配') As Is_Map,IIF(process_flag = '1' , '已处理', '未处理') As Is_Process_flag");
            sqlstr.Append(" From GPO_PRODUCT_MAP");
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
            //原GPO系统sql
            //sqlstr.Append(" SELECT Id, map_orgtype, map_orgid, hit_comm_id, ");
            //sqlstr.Append(" product_id, data_product_id, saler_id, sender_id, enter_id, ");
            //sqlstr.Append(" medical_code, product_code, common_name, product_name,COMMON_NAME ");
            //sqlstr.Append(" & '(' & product_name & ')' As HisProduct_Name, mode_id, mode_name,");
            //sqlstr.Append(" medical_spec_id, medical_spec, stand_rate, use_unit_id, use_unit, ");
            //sqlstr.Append(" spec_unit_id, spec_unit, permit_no, factory_code, factory_name, ");
            //sqlstr.Append(" saler_code, saler_name, sender_code, sender_name, category_id, ");
            //sqlstr.Append(" category_name, stock_id, stock_name, package_rate, modify_userid,");
            //sqlstr.Append(" modify_date, process_flag, sync_state, remark, factory_id,IsMap,Process_flag,");
            //sqlstr.Append(" IIF(IsMap = '1' , '已匹配', '未匹配') As Is_Map,IIF(process_flag = '1' , ");
            //sqlstr.Append(" '已处理', '未处理') As Is_Process_flag");
            //sqlstr.Append(" From GPO_PRODUCT_MAP");
            //sqlstr.Append(" Where 1=1");

            sqlstr.Append("SELECT ID, MAP_ORGTYPE, MAP_ORGID, CONVERT(VARCHAR(18),PRODUCT_ID) AS PRODUCT_ID,HH_SPEC_ID,HH_MODE_ID,");
            sqlstr.Append(" HIS_PRODUCT_ID,CONVERT(VARCHAR(18),PROJECT_PROD_ID) AS PROJECT_PROD_ID,(case when  COMMON_NAME is null then '-' when COMMON_NAME='' then '-' else COMMON_NAME end ) as COMMON_NAME,(case when  PRODUCT_NAME is null then '-' when PRODUCT_NAME='' then '-' else PRODUCT_NAME end ) as PRODUCT_NAME,COMMON_NAME  + '(' +");
            sqlstr.Append(" PRODUCT_NAME + ')' AS HISPRODUCT_NAME, COMMERCE_NAME,(case when BRAND is null then '-' when BRAND='' then '-' else BRAND end ) as BRAND,MODE_ID,(case when MODE_NAME is null then '-' when MODE_NAME='' then '-' else MODE_NAME end) as MODE_NAME,");
            sqlstr.Append(" SPEC_ID,(case when  SPEC is null then '-' when SPEC='' then '-' else SPEC end) as SPEC,(case when  BASE_MEASURE is null then '-' when BASE_MEASURE='' then '-' else BASE_MEASURE end) as BASE_MEASURE,(case when BASE_MEASURE_SPEC is null then '-' when BASE_MEASURE_SPEC='' then '-' else BASE_MEASURE_SPEC end) as BASE_MEASURE_SPEC,(case when BASE_MEASURE_MATE is null then '-' when BASE_MEASURE_MATE='' then '-' else BASE_MEASURE_MATE end) as BASE_MEASURE_MATE,");
            sqlstr.Append(" (case when STAND_RATE is null  then '-' else CONVERT(VARCHAR(18),STAND_RATE) end) as STAND_RATE,FACTORY_CODE ,(case when FACTORY_NAME is null then '-'  when FACTORY_NAME='' then '-' else FACTORY_NAME end ) as FACTORY_NAME,SALER_CODE,SALER_NAME,SENDER_CODE,");
            sqlstr.Append(" (case when SENDER_NAME is null  then '-' when SENDER_NAME='' then '-' else SENDER_NAME end) as SENDER_NAME,STOCK_ID,STOCK_NAME,MODIFY_USERID,");
            sqlstr.Append(" MODIFY_DATE,PROCESS_FLAG, SYNC_STATE,(case when REMARK is null then '-' when REMARK='' then '-' else REMARK end ) as REMARK,ISMAP,");
            sqlstr.Append(" PROCESS_FLAG, (CASE ISMAP WHEN '1' THEN '已匹配' ELSE '未匹配' END) AS IS_MAP,");
            sqlstr.Append(" (CASE PROCESS_FLAG WHEN '1' THEN '已处理' ELSE '未处理' END) AS IS_PROCESS_FLAG  ");
     
            sqlstr.Append(" From HC_PRODUCT_MAP Where 1=1");
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

            //原sql
            //sqlstr.Append("Select sender.*, GpoCorp.MapSum From");
            //sqlstr.Append(" (Select pt.name As source,ci.Id As RECORD_ID,ci.PRODUCT_ID,ci.FACTORY_ID,ci.SALER_ID,ci.ORD_SEND_ID, ci.FACTORY_NAME,ci.PROVIDE_PRICE,Co.Org_Id As Sender_Id,co.ORG_NAME,co.ORG_EASY,co.ORG_PINYIN,co.ORG_WUBI,cp.MEDICAL_NAME,cp.MEDICAL_WUBI,cp.MEDICAL_PINYIN,cp.TRADE_NAME,cp.SPELL_ABBR,cp.NAME_WB,ci.DOSEAGE_FORM,cp.QUALITY_NAME,ci.SPEC_UNIT");
            //sqlstr.Append(" ,(ci.SPEC &  '*' &  ci.STAND_RATE  &  ci.USE_UNIT  &  '/'  &  ci.SPEC_UNIT) As unc_spec");
            //sqlstr.Append(" From Cont_Item ci ,CONT_ORG co,CONT_PRODUCT cp,Cont_List cl,PROJECT_TYPE pt");
            //sqlstr.Append(" Where ci.SALER_ID=co.ORG_ID And ci.PROJECT_ID=co.PROJECT_ID And cp.product_id=ci.product_id And cp.PROJECT_ID=ci.PROJECT_ID");
            //sqlstr.Append(" And ci.CONTRACT_ID = cl.Id And cl.type_code=pt.code) sender");
            //sqlstr.Append(" Left Join ");
            //sqlstr.Append(" [select");
            //sqlstr.Append(" b.PRODUCT_ID,  IIF(count(b.id) is null,'0',count(b.id)) as MapSum ");
            //sqlstr.Append(" From GPO_PRODUCT_MAP b  group by b.PRODUCT_ID]. AS GpoCorp ON  sender.PRODUCT_ID =");
            //sqlstr.Append(" GpoCorp.PRODUCT_ID");

            //mapSum有一定问题的sql--- 20071024
            //sqlstr.Append("Select sender.*,sender.data_PRODUCT_ID as PRODUCT_ID, GpoCorp.MapSum From (Select hohc.Id As ");
            //sqlstr.Append(" RECORD_ID,hohc.data_PRODUCT_ID,hohc.COMMON_NAME,hohc.PROJECT_PROD_ID,hohc.MODEL_ID,hohc.SPEC_ID,hohc.SPEC,hohc.MODEL,hohc.MANU_ID as FACTORY_ID,hohc.MANU_NAME,hohc.MANU_NAME_ABBR,hohc.SALER_ID,SALER_NAME,SALER_NAME_ABBR,");
            //sqlstr.Append(" hohc.SENDER_ID, hohc.SENDER_NAME_ABBR,hohc.SENDER_NAME,");
            //sqlstr.Append(" hohc.PRICE");
            //sqlstr.Append(" ,hohc.PRODUCT_NAME,hohc.ABBR_WB,hohc.ABBR_PY,");
            //sqlstr.Append(" hohc.COMMERCE_NAME,hohc.BASE_MEASURE ,BASE_MEASURE_SPEC");
            //sqlstr.Append(" ,BASE_MEASURE_MATER");
            //sqlstr.Append(" From HC_ORD_HIT_COMM hohc) sender Left Join  (select b.PROJECT_PROD_ID, b.spec_id,b.mode_id, ");
            //sqlstr.Append(" (case when count(b.id) is null then '0' else count(b.id) end) ");
            //sqlstr.Append(" as MapSum  From hc_PRODUCT_MAP b  group by");
            //sqlstr.Append(" b.PROJECT_PROD_ID,b.spec_id,b.mode_id) AS GpoCorp ON  sender.PROJECT_PROD_ID = GpoCorp.PROJECT_PROD_ID and sender.spec_id = GpoCorp.spec_id and sender.model_id = GpoCorp.Mode_id");


            sqlstr.Append(" Select sender.*,sender.data_PRODUCT_ID as PRODUCT_ID, GpoCorp.MapSum From ");

            sqlstr.Append(" (Select hohc.Id As  RECORD_ID,hohc.data_PRODUCT_ID,(case when hohc.COMMON_NAME is null then '-' else hohc.COMMON_NAME end) as COMMON_NAME,");

            sqlstr.Append(" hohc.PROJECT_PROD_ID,hohc.MODEL_ID,hohc.SPEC_ID,(case when  hohc.SPEC is null then '-' else hohc.SPEC end ) as SPEC,(case when hohc.MODEL is null then '-' else hohc.MODEL end) as MODEL,");

            sqlstr.Append(" hohc.MANU_ID as FACTORY_ID,(case when hohc.MANU_NAME is null then '-' else hohc.MANU_NAME end) as MANU_NAME,(case when hohc.MANU_NAME_ABBR is null then '-' else hohc.MANU_NAME_ABBR end ) as MANU_NAME_ABBR,hohc.SALER_ID,");

            sqlstr.Append(" SALER_NAME,SALER_NAME_ABBR, hohc.SENDER_ID,(case when hohc.SENDER_NAME_ABBR is null then '-' else  hohc.SENDER_NAME_ABBR end ) as  SENDER_NAME_ABBR,hohc.SENDER_NAME,");

            sqlstr.Append(" hohc.PRICE ,(case when hohc.PRODUCT_NAME is null then '-' else hohc.PRODUCT_NAME end ) as PRODUCT_NAME,hohc.ABBR_WB,hohc.ABBR_PY, hohc.COMMERCE_NAME,");

            sqlstr.Append(" (case when hohc.BASE_MEASURE is null then '-' else hohc.BASE_MEASURE end ) as BASE_MEASURE,(case when BASE_MEASURE_SPEC is null then '-' else BASE_MEASURE_SPEC end ) as BASE_MEASURE_SPEC ,(case when BASE_MEASURE_MATER is null then '-' else BASE_MEASURE_MATER end) as BASE_MEASURE_MATER From HC_ORD_HIT_COMM hohc)"); 

            sqlstr.Append(" sender Left Join  (select b.PROJECT_PROD_ID, b.hh_spec_id,b.hh_mode_id,  ");

            sqlstr.Append(" (case when count(b.id) is null then '0' else count(b.id) end)  as MapSum  ");

            sqlstr.Append(" From hc_PRODUCT_MAP b  group by b.PROJECT_PROD_ID,b.hh_spec_id,b.hh_mode_id) AS ");

            sqlstr.Append(" GpoCorp ON  sender.PROJECT_PROD_ID = GpoCorp.PROJECT_PROD_ID and sender.spec_id = ");

            sqlstr.Append(" GpoCorp.hh_spec_id and sender.model_id = GpoCorp.hh_Mode_id");


            return sqlstr.ToString();
        }

        #endregion


        #region 获得产品对照查询的HIS产品对照列表

        public DataTable GetGpoMapList(string porductID, string modelID, String specID)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = DbFacade.SQLExecuteDataTable(GetGpoMapSql(porductID, modelID, specID));
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
        private string GetGpoMapSql(string porductID ,string modelId,string specId)
        {
            StringBuilder strsql = new StringBuilder();

            strsql.Append("SELECT ID, MAP_ORGTYPE, MAP_ORGID, CONVERT(VARCHAR(18),PRODUCT_ID) AS PRODUCT_ID,HH_SPEC_ID,HH_MODE_ID,");
            strsql.Append(" HIS_PRODUCT_ID,CONVERT(VARCHAR(18),PROJECT_PROD_ID) AS PROJECT_PROD_ID,(case when  COMMON_NAME is null then '-' when COMMON_NAME='' then '-' else COMMON_NAME end ) as COMMON_NAME,(case when  PRODUCT_NAME is null then '-' when PRODUCT_NAME='' then '-' else PRODUCT_NAME end ) as PRODUCT_NAME,COMMON_NAME  + '(' +");
            strsql.Append(" PRODUCT_NAME + ')' AS HISPRODUCT_NAME, COMMERCE_NAME,(case when BRAND is null then '-' when BRAND='' then '-' else BRAND end ) as BRAND,MODE_ID,(case when MODE_NAME is null then '-' when MODE_NAME='' then '-' else MODE_NAME end) as MODE_NAME,");
            strsql.Append(" SPEC_ID,(case when  SPEC is null then '-' when SPEC='' then '-' else SPEC end) as SPEC,(case when  BASE_MEASURE is null then '-' when BASE_MEASURE='' then '-' else BASE_MEASURE end) as BASE_MEASURE,(case when BASE_MEASURE_SPEC is null then '-' when BASE_MEASURE_SPEC='' then '-' else BASE_MEASURE_SPEC end) as BASE_MEASURE_SPEC,(case when BASE_MEASURE_MATE is null then '-' when BASE_MEASURE_MATE='' then '-' else BASE_MEASURE_MATE end) as BASE_MEASURE_MATE,");
            strsql.Append(" (case when STAND_RATE is null  then '-' else CONVERT(VARCHAR(18),STAND_RATE) end) as STAND_RATE,FACTORY_CODE ,(case when FACTORY_NAME is null then '-'  when FACTORY_NAME='' then '-' else FACTORY_NAME end ) as FACTORY_NAME,SALER_CODE,SALER_NAME,SENDER_CODE,");
            strsql.Append(" (case when SENDER_NAME is null  then '-' when SENDER_NAME='' then '-' else SENDER_NAME end) as SENDER_NAME,STOCK_ID,STOCK_NAME,MODIFY_USERID,");
            strsql.Append(" MODIFY_DATE,PROCESS_FLAG, SYNC_STATE,(case when REMARK is null then '-' when REMARK='' then '-' else REMARK end ) as REMARK,ISMAP,");
            strsql.Append(" PROCESS_FLAG, (CASE ISMAP WHEN '1' THEN '已匹配' ELSE '未匹配' END) AS IS_MAP,");
            strsql.Append(" (CASE PROCESS_FLAG WHEN '1' THEN '已处理' ELSE '未处理' END) AS IS_PROCESS_FLAG From hc_PRODUCT_MAP");
            
            strsql.Append(" where PROJECT_PROD_ID = '" + porductID + "' and HH_MODE_ID='" + modelId + "' and HH_SPEC_ID='" + specId + "'");
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
            strsql.Append(" from hc_PRODUCT_MAP where ID = '" + strId + "'");

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
            str1s.Append(" from GPO_PRODUCT_MAP where PRODUCT_CODE = '" + productcode + "'");
            return str1s.ToString();
        }


        protected Gpo_Product_MapModel GetModelByRow(DataRow row)
        {
            //定义采购申请主表实体类
            Gpo_Product_MapModel Model = new Gpo_Product_MapModel();
            if (row == null)
            { return null; }

            Model.ProductCode = ComUtil.getStringValue(row, "HIS_PRODUCT_ID", "");

            Model.HH_Mode_ID = ComUtil.getStringValue(row, "HH_Mode_ID", "");

            Model.HH_Spec_ID = ComUtil.getStringValue(row, "HH_Spec_ID", "");

            Model.Mode_ID = ComUtil.getStringValue(row, "MODE_ID", "");

            Model.Mode_Name = ComUtil.getStringValue(row, "MODE_NAME", "");

            Model.Product_Name = ComUtil.getStringValue(row, "PRODUCT_NAME", "");

            Model.CommonName = ComUtil.getStringValue(row, "COMMON_NAME", "");

            Model.CommerceName = ComUtil.getStringValue(row, "COMMERCE_NAME", "");

            Model.Brand = ComUtil.getStringValue(row, "BRAND", "");

            Model.Base_measure = ComUtil.getStringValue(row, "BASE_MEASURE", "");

            Model.Base_measure_spec = ComUtil.getStringValue(row, "BASE_MEASURE_SPEC", "");

            Model.Base_measure_mate = ComUtil.getStringValue(row, "BASE_MEASURE_MATE", "");

            Model.Stand_Rate = ComUtil.getStringValue(row, "STAND_RATE", "");

            Model.Factory_Name = ComUtil.getStringValue(row, "FACTORY_NAME", "");

            Model.Factory_Code = ComUtil.getStringValue(row, "FACTORY_CODE", "");

            Model.Saler_Name = ComUtil.getStringValue(row, "Saler_Name", "");

            Model.Saler_Code = ComUtil.getStringValue(row, "Saler_Code", "");

            Model.Sender_Name = ComUtil.getStringValue(row, "Sender_Name", "");

            Model.Sender_Code = ComUtil.getStringValue(row, "Sender_Code", "");

            Model.Stock_Id = ComUtil.getStringValue(row, "Stock_Id", "");

            Model.Stock_Name = ComUtil.getStringValue(row, "Stock_Name", "");




            Model.Remark = ComUtil.getStringValue(row, "REMARK", "");

            //Model.Medical_Spec_Id = ComUtil.getStringValue(row, "MEDICAL_SPEC_ID", "");

            //Model.Medical_Spec = ComUtil.getStringValue(row, "MEDICAL_SPEC", "");

            Model.Spec_Unit = ComUtil.getStringValue(row, "SPEC", "");

            Model.Spec_Unit_Id = ComUtil.getStringValue(row, "SPEC_ID", "");

            //Model.Stand_Rate = ComUtil.getStringValue(row, "STAND_RATE", "");

            //Model.Use_Unit = ComUtil.getStringValue(row, "USE_UNIT", "");

            //Model.UseUnitCode = ComUtil.getStringValue(row, "USE_UNIT_ID", "");

            Model.ProcessFlag = ComUtil.getStringValue(row, "PROCESS_FLAG", "");

            return Model;
        }

        //判断产品编码是否重复
        public bool JudgeHisProductCode(string productcode)
        {
            bool flag = false;

            string sqlstr = "select count(1) from hc_PRODUCT_MAP where HIS_PRODUCT_ID='" + productcode + "'";

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

            try
            {

                DbFacade.SQLExecuteNonQuery(CreateProductComprison(input,out strID));
            }
            catch (Exception ex)
            {
                throw ex;
                flag = false;
            }

            return flag;
        }

        //获取新增SQL语句
        public string CreateProductComprison(Gpo_Product_MapModel input,out string strID)
        {
            //string id = base.GetGlobalId();

            long id = this.GetClientId(input.User.HighId);

            strID = id.ToString();

            string buyerid = input.Map_Orgid;
            string productCode = input.ProductCode;
            string productId = input.ProductID;
            string Hh_mode_id = input.HH_Mode_ID;
            string Hh_spec_id = input.HH_Spec_ID;


            string Commonname = input.CommonName;
            string productName = input.Product_Name;
            string commerceName = input.CommerceName;
            string brand = input.Brand;
            string modeid = input.Mode_ID;
            string modeName = input.Mode_Name;
            string specid = input.Spec_Unit_Id;
            string specName = input.Spec_Unit;
            string basemeasure = input.Base_measure;
            string basemeasurespec = input.Base_measure_spec;
            string basemeasuremate = input.Base_measure_mate;
           
            string factorycode = input.Factory_Code;
            string factoryName = input.Factory_Name;
            string salerCode = input.Saler_Code;
            string salerName = input.Saler_Name;
            string senderCode = input.Sender_Code;
            string senderName = input.Sender_Name;
            //string cateID = input.Category_Id;
            //string cateName = input.Category_Name;
            string stockid = input.Stock_Id;
            string stockname = input.Stock_Name;
           
            string code = input.ProductCode;

            string modifyUser = input.User.UserInfo.Id;


            string remark = input.Remark;
         

            int standrate = 1;
            if (!string.IsNullOrEmpty(input.Stand_Rate))
                standrate = int.Parse(input.Stand_Rate);

      
            string read = input.ProcessFlag;

            string ismap = input.IsMap;

            StringBuilder sqlstr = new StringBuilder();

            sqlstr.Append("insert into HC_PRODUCT_MAP (ID,map_orgtype,MAP_ORGID,HIS_PRODUCT_ID,");
            sqlstr.Append(" PROJECT_PROD_ID,PRODUCT_ID,COMMON_NAME ");
            sqlstr.Append(" ,PRODUCT_NAME,COMMERCE_NAME,BRAND,MODE_ID,MODE_NAME,SPEC_ID ");
            sqlstr.Append(" ,SPEC,BASE_MEASURE,BASE_MEASURE_SPEC,BASE_MEASURE_MATE,STAND_RATE");
            sqlstr.Append(" ,FACTORY_CODE,FACTORY_NAME,SALER_CODE,SALER_NAME,SENDER_CODE,SENDER_NAME");
            sqlstr.Append(" ,STOCK_ID,STOCK_NAME,MODIFY_USERID,MODIFY_DATE");
            sqlstr.Append(" ,PROCESS_FLAG,SYNC_STATE,REMARK,ISMAP,Hh_mode_id,Hh_SPEC_id) values");

            sqlstr.AppendFormat("('{0}',1,'{1}','{2}','{3}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}', '{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}')", id, buyerid, productCode, productId, Commonname, productName, commerceName, brand, modeid, modeName, specid, specName, basemeasure, basemeasurespec, basemeasuremate, standrate, factorycode, factoryName, salerCode, salerName, senderCode, senderName, stockid, stockname, modifyUser, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), read, '0', remark, ismap, Hh_mode_id, Hh_spec_id);

            return sqlstr.ToString();
        }

        #region 修改

        //获取修改SQL语句
        private string UpdateComparison(Gpo_Product_MapModel input)
        {
            //string buyerid = input.Map_Orgid;
            //string productid = input.ProductID;
            //string salerid = input.Saler_Id;
            //string senderid = input.Sender_Id;
            //string factoryid = input.Factory_Id;
            //string code = input.ProductCode;
            //string modecode = input.Mode_ID;
            //string modename = input.Mode_Name;
            //string name = input.Product_Name;
            //string Commonname = input.CommonName;

            ////int packagerate = 0;
            ////if (!string.IsNullOrEmpty(input.Package_Rate))
            ////    packagerate = int.Parse(input.Package_Rate);

            ////string producer = input.Product_Name;
            //string producer = input.Factory_Name;
            //string factory_Code = input.Factory_Code;

            //string remark = input.Remark;
            //string speccode = input.Medical_Spec_Id;
            //string specname = input.Medical_Spec;
            //string specunit = input.Spec_Unit;
            //string specunitcode = input.Spec_Unit_Id;

            ////int standrate = 0;
            ////if (!string.IsNullOrEmpty(input.Stand_Rate))
            ////    standrate = int.Parse(input.Stand_Rate);

            //string useunit = input.Use_Unit;
            //string useunitcode = input.UseUnitCode;
            //string read = input.ProcessFlag;
            //string ismap = input.IsMap;

       
            string buyerid = input.Map_Orgid;
            string productCode = input.ProductCode;
            string productId = input.ProductID;
            string Hh_mode_id = input.HH_Mode_ID;
            string Hh_spec_id = input.HH_Spec_ID;


            string Commonname = input.CommonName;
            string productName = input.Product_Name;
            string commerceName = input.CommerceName;
            string brand = input.Brand;
            string modeid = input.Mode_ID;
            string modeName = input.Mode_Name;
            string specid = input.Spec_Unit_Id;
            string specName = input.Spec_Unit;
            string basemeasure = input.Base_measure;
            string basemeasurespec = input.Base_measure_spec;
            string basemeasuremate = input.Base_measure_mate;

            string factorycode = input.Factory_Code;
            string factoryName = input.Factory_Name;
            string salerCode = input.Saler_Code;
            string salerName = input.Saler_Name;
            string senderCode = input.Sender_Code;
            string senderName = input.Sender_Name;
            //string cateID = input.Category_Id;
            //string cateName = input.Category_Name;
            string stockid = input.Stock_Id;
            string stockname = input.Stock_Name;

            string code = input.ProductCode;

            string modifyUser = input.User.UserInfo.Id;


            string remark = input.Remark;


            //int standrate = 1;
            //if (!string.IsNullOrEmpty(input.Stand_Rate))
            //  standrate = int.Parse(input.Stand_Rate);
            string standrate = String.Empty;
            if (!string.IsNullOrEmpty(input.Stand_Rate))
                 standrate = input.Stand_Rate;

            string read = input.ProcessFlag;

            string ismap = input.IsMap;

            StringBuilder sqlstr = new StringBuilder("Update hc_PRODUCT_MAP");
            sqlstr.AppendFormat(" Set PRODUCT_ID={0}", productId);
            sqlstr.AppendFormat(" , PROJECT_PROD_ID={0}", productId);

            sqlstr.AppendFormat(" , HIS_PRODUCT_ID='{0}'", productCode);

            sqlstr.AppendFormat(" , Hh_mode_id={0}", Hh_mode_id);
            sqlstr.AppendFormat(" , Hh_spec_id={0}", Hh_spec_id);


            sqlstr.AppendFormat(",MAP_ORGID='{0}'", buyerid);
            sqlstr.Append(" ,map_orgtype=1");
            sqlstr.AppendFormat(",FACTORY_code='{0}'", factorycode);
            sqlstr.AppendFormat(",FACTORY_NAME='{0}'", factoryName);
            sqlstr.AppendFormat(",SALER_code='{0}'", salerCode);
            sqlstr.AppendFormat(",saler_Name='{0}'", salerName);
            sqlstr.AppendFormat(",SENDER_code='{0}'", senderCode);
            sqlstr.AppendFormat(",SENDER_name='{0}'", senderName);
            //sqlstr.AppendFormat(",CATEGORY_ID='{0}'", cateID);
            //sqlstr.AppendFormat(",CATEGORY_NAME='{0}'", cateName);
            sqlstr.AppendFormat(",STOCK_ID='{0}'", stockid);
            sqlstr.AppendFormat(",STOCK_NAME='{0}'", stockname);

            sqlstr.AppendFormat(",MODE_ID='{0}'", modeid);
            sqlstr.AppendFormat(",MODE_NAME='{0}'", modeName);


            sqlstr.AppendFormat(",PRODUCT_NAME='{0}'", productName);
            sqlstr.AppendFormat(",COMMON_NAME='{0}'", Commonname);
            sqlstr.AppendFormat(",COMMERCE_NAME='{0}'", commerceName);
            sqlstr.AppendFormat(",BRAND='{0}'", brand);
            sqlstr.AppendFormat(",SPEC_ID='{0}'", specid);
            sqlstr.AppendFormat(",SPEC='{0}'", specName);
            sqlstr.AppendFormat(",BASE_MEASURE='{0}'", basemeasure);
            sqlstr.AppendFormat(",BASE_MEASURE_SPEC='{0}'", basemeasurespec);
            sqlstr.AppendFormat(",BASE_MEASURE_MATE='{0}'", basemeasuremate);
            
            sqlstr.AppendFormat(",REMARK='{0}'", remark);
          
           

            if (!string.IsNullOrEmpty(input.Stand_Rate))
                sqlstr.AppendFormat(",STAND_RATE='{0}'", input.Stand_Rate);

          

            sqlstr.Append(",SYNC_STATE= 0");
            sqlstr.AppendFormat(",IsMap='{0}'", ismap);
            sqlstr.AppendFormat(",PROCESS_FLAG='{0}'", read);
            sqlstr.AppendFormat(",modify_date='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sqlstr.AppendFormat(",MODIFY_USERID='{0}'", input.User.UserInfo.Id);
            

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

                StringBuilder sqlstr = new StringBuilder("Update hc_PRODUCT_MAP");
                sqlstr.AppendFormat(" Set PROJECT_PROD_ID=0,SYNC_STATE = 0,IsMap='0' ");
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
            sqlstr.AppendFormat("Delete From hc_PRODUCT_MAP Where id='{0}'", strid);

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    string sqlSearch = " Select * from hc_PRODUCT_MAP where id = '" + strid + "'";
                    DataTable dt = base.DbFacade.SQLExecuteDataTable(sqlSearch, transaction);
                    if (dt == null || dt.Rows.Count < 0)
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                        return;
                    }
                    bool insertflg = false;
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    insertflg = base.addDelLog("Gpo_PRODUCT_MAP", dr["id"].ToString(), "ID", ClientSession.GetInstance().CurrentUser.UserInfo.Id, "1", transaction);
                    //    if (!insertflg)
                    //    {
                    //        base.DbFacade.RollbackTransaction(transaction);
                    //        return;
                    //    }
                    //}

                    rownum = DbFacade.SQLExecuteNonQuery(sqlstr.ToString(), transaction);
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
            sqlstr.Append(" ,(ci.SPEC &  '*' &  ci.STAND_RATE  &  ci.USE_UNIT  &  '/'  &  ci.SPEC_UNIT) As unc_spec,ci.FACTORY_NAME,");
            sqlstr.Append(" GPM.PRODUCT_ID,GPM.PRODUCT_CODE,GPM.PRODUCT_NAME,GPM.COMMON_NAME,GPM.MODE_NAME,");
            sqlstr.Append(" GPM.MEDICAL_SPEC,GPM.SPEC_UNIT,GPM.USE_UNIT,GPM.PACKAGE_RATE,GPM.STAND_RATE,");
            sqlstr.Append(" GPM.FACTORY_NAME,GPM.REMARK,GPM.PROCESS_FLAG");
            sqlstr.Append(" ,IIF(GPM.IsMap = '1','已匹配','未匹配') as IsMap");
            sqlstr.Append(" From Cont_Item ci ,CONT_PRODUCT cp, GPO_PRODUCT_MAP GPM");
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

            string sqlSearch = string.Format(" Select * from hc_PRODUCT_MAP where MAP_ORGID = '{0}' And PRODUCT_CODE = '{1}'", orgid, porductCode);
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
            strsql.Append("(ID,MAP_ORGID,PRODUCT_CODE,MEDICAL_CODE,COMMON_NAME,PRODUCT_NAME,MODE_ID,MODE_NAME,MEDICAL_SPEC_ID,MEDICAL_SPEC,USE_UNIT_ID,USE_UNIT,SPEC_UNIT_ID,SPEC_UNIT,STAND_RATE,FACTORY_CODE,FACTORY_NAME,product_id,data_product_id,MAP_ORGTYPE,PERMIT_NO,SALER_CODE,SALER_NAME,SENDER_CODE,SENDER_NAME,STOCK_ID,STOCK_NAME,PACKAGE_RATE,SYNC_STATE)");
            strsql.Append(" Values");
            strsql.AppendFormat("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}','{18}','1','{19}','{20}','{21}','{22}','{23}','{24}','{25}',{26},'0')",
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
            //sqlstr.AppendFormat(",CATEGORY_ID='{0}'", model.Category_Id);
            //sqlstr.AppendFormat(",CATEGORY_NAME='{0}'", model.Category_Name);
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

    }
}
