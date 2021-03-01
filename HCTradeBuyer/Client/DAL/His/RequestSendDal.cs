using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons.Data;
using System.Data;
using System.Data.Common;
using Emedchina.Commons;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Emedchina.TradeAssistant.Client.DAL.His
{
    public class RequestSendDal : SqlDAOBase
    {
        private RequestSendDal()
            : base()
        { }

        private RequestSendDal(string connectionName)
            : base(connectionName)
        { }

        public static RequestSendDal GetInstance()
        {
            return new RequestSendDal();
        }

        public static RequestSendDal GetInstance(string connectionName)
        {
            return new RequestSendDal(connectionName);
        }
        /// <summary>
        /// 获取到货导出信息id
        /// </summary>
        /// <returns></returns>
        public DataTable GetRequestSend(string sql)
        {

            DataTable dt = new DataTable();

            OleDbConnection myConn = new OleDbConnection(ClientConfiguration.ConnectionString);

            myConn.Open();
            try
            {
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
            }
            catch (Exception e)
            {

                throw e;
            }

            return dt;
        }

        /// <summary>
        /// 获取产品匹配数据
        /// </summary>
        /// <param name="erpProductCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public DataTable GetProductMapData(string erpProductCode, string orgId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select p.PROJECT_PROD_ID,p.HH_SPEC_ID as SPEC_ID,p.HH_MODE_ID as MODE_ID,hoc.BRAND,hoc.MANU_NAME,hoc.MANU_NAME_ABBR,hoc.COMMON_NAME,hoc.PRODUCT_NAME,hoc.PRICE,(case when hoc.SELF_PACKAGE is null then 1 else hoc.SELF_PACKAGE end )as SELF_PACKAGE   from HC_PRODUCT_MAP p   ");
            sql.Append("left join (select hohc.PROJECT_PROD_ID, hohc.SPEC_ID, hohc.MODEL_ID,hsdi.SELF_PACKAGE,hohc.BRAND,hohc.COMMON_NAME,hohc.PRODUCT_NAME,hohc.PRICE,hohc.MANU_NAME,hohc.MANU_NAME_ABBR  from HC_ORD_HIT_COMM hohc left join HC_SELF_DEFINE_INFO hsdi on hohc.id=hsdi.HIT_COMM_ID )");
            sql.Append(" hoc on p.PROJECT_PROD_ID= hoc.PROJECT_PROD_ID and p.HH_SPEC_ID=hoc.SPEC_ID  and  p.HH_MODE_ID=hoc.MODEL_ID where p.MAP_ORGID=").Append(orgId).Append(" and p.HIS_PRODUCT_ID = '").Append(erpProductCode).Append("'");
            DataTable result = null;
            try
            {

                result = base.DbFacade.SQLExecuteDataTable(sql.ToString());

            }
            catch (Exception e)
            {
                //throw e;
            }

            return result;
        }

        /// <summary>
        /// 获取医院匹配数据
        /// </summary>
        /// <param name="erpHisCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public string GetCorpMapData(string erpHisCode, string orgId)
        {
            //string sql = "select ORG_ID from ERP_CORP_MAP p where p.saler_orgid=:orgId and p.CODE = :code and p.PROCESS_FLAG = '1'";
            string sql = "select ORG_ID from GPO_CORP_MAP p where p.MAP_ORGID=:orgId and p.CODE = :code and p.MAP_ORGTYPE = '2'";
            string result = null;


            DbParameter paramBuyer = base.DbFacade.CreateParameter();
            paramBuyer.ParameterName = "orgId";
            paramBuyer.DbType = DbType.String;
            paramBuyer.Value = orgId;
            DbParameter paramPlat = base.DbFacade.CreateParameter();
            paramPlat.ParameterName = "code";
            paramPlat.DbType = DbType.String;
            paramPlat.Value = erpHisCode;

            try
            {

                object o = DbFacade.SQLExecuteDataTable(sql.ToString(), paramBuyer, paramPlat);
                if (o != null)
                    result = o.ToString();
            }
            catch (Exception e)
            {
                //throw e;
            }
            return result;
        }
        //添加人：刘海超
        //时间：2007年10月28日
        //原因：his采购计划导入
        /// <summary>
        /// 获取供应站匹配数据
        /// </summary>
        /// <param name="erpHisCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>

        public DataTable GetIPMapData(string buyerid, string erpHisCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select distinct ORG_ID  ,FULL_NAME,EASY_NAME from HC_CORP_MAP p where p.MAP_ORGID=").Append(buyerid).Append(" and p.HIS_ORG_ID = '").Append(erpHisCode).Append("'");     
            DataTable senderdt = null;

            try
            {

                senderdt = base.DbFacade.SQLExecuteDataTable(sql.ToString());
                
            }
            catch (Exception e)
            {
                //throw e;
            }
            return senderdt;
        }

    }
}
