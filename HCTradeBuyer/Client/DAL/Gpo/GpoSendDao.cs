using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons.Data;
using System.Data;
using System.Data.Common;
using Emedchina.Commons;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Emedchina.TradeAssistant.Client.DAL.Gpo
{
    public class GpoSendDao :SqlDAOBase
    {
        private DataBaseFacade dbFacade = null;

        private GpoSendDao()            
        {
            dbFacade = DataBaseFacade.GetInstance();
        }

        private GpoSendDao(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                dbFacade = DataBaseFacade.GetInstance();
            else
                dbFacade = DataBaseFacade.GetInstance(connectionName);
        }

        public static GpoSendDao GetInstance()
        {
            return new GpoSendDao();
        }

        public static GpoSendDao GetInstance(string connectionName)
        {
            return new GpoSendDao(connectionName);
        }
        /// <summary>
        /// 获取到货导出信息id
        /// </summary>
        /// <returns></returns>
        public DataTable GetErpSend(string sql)
        {
            DataTable dt = new DataTable();
            OleDbConnection myConn = new OleDbConnection(ClientConfiguration.ConnectionString);
            myConn.Open();

            //打开数据链接，得到一个数据集
            OleDbDataAdapter myCommand = new OleDbDataAdapter(sql, myConn);

            try
            {
                //得到自己的DataSet对象
                myCommand.Fill(dt);
                //关闭此数据链接
                myConn.Close();
            }
            catch 
            {
                throw;
            }

            return dt;
        }

        /// <summary>
        /// 将DataTable数据插入到SQLServer表
        /// </summary>
        /// <param name="tableName">SQLServer表名</param>
        /// <param name="connString">连接字符串</param>
        /// <param name="dt">数据源</param>
        /// <returns>操作结果</returns>
        public static bool ExportErpToMSS(string tableName, string connString, DataTable dt)
        {
            bool flg = false;

            SqlConnection myConn = new SqlConnection();

            string strCom = "SELECT * FROM " + tableName;

            SqlDataAdapter myAdapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand myCommand = new SqlCommand(strCom, conn);
            myAdapter.SelectCommand = myCommand;

            //打开连接
            conn.Open();
            //开始事务
            SqlTransaction myTrans = conn.BeginTransaction();
            myCommand.Transaction = myTrans;

            try
            {
                DataSet myDataSet = new DataSet();

                ////打开数据链接，得到一个数据集
                //SqlDataAdapter myCommand = new SqlDataAdapter(strCom, myConn);

                //得到自己的DataSet对象
                myAdapter.Fill(myDataSet, tableName);

                DataRow row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = myDataSet.Tables[tableName].NewRow();
                    row.ItemArray = dr.ItemArray;
                    myDataSet.Tables[tableName].Rows.Add(row);
                }

                SqlCommandBuilder builder = new SqlCommandBuilder(myAdapter);
                myAdapter.InsertCommand = builder.GetInsertCommand();

                int rowCount = myAdapter.Update(myDataSet, tableName);
                if (rowCount > 0)
                {
                    myTrans.Commit();
                    flg = true;
                }
                else
                {
                    myTrans.Rollback();
                    flg = false;
                }

            }
            catch
            {
                myTrans.Rollback();
                flg = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return flg;
        }

        /// <summary>
        /// 将DataTable数据更新到SQLServer表 update by yanbing 2007-05-21
        /// </summary>
        /// <param name="tableName">SQLServer表名</param>
        /// <param name="connString">连接字符串</param>
        /// <param name="dt">数据源</param>
        /// <param name="keyName">SQLServer删除键</param>
        /// <returns>操作结果</returns>
        public static bool ExportErpToMSS(string tableName, string connString, DataTable dt, string keyName)
        {//导出到sqlserver,执行更新操作
            bool flg = false;

            SqlConnection myConn = new SqlConnection();
            string strCom = "SELECT * FROM " + tableName;
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand myCommand = new SqlCommand(strCom, conn);

            myAdapter.SelectCommand = myCommand;

            //打开连接
            conn.Open();
            //开始事务
            SqlTransaction myTrans = conn.BeginTransaction();
            myCommand.Transaction = myTrans;

            try
            {
                DataSet myDataSet = new DataSet();

                ////打开数据链接，得到一个数据集
                //SqlDataAdapter myCommand = new SqlDataAdapter(strCom, myConn);

                //得到自己的DataSet对象
                myAdapter.Fill(myDataSet, tableName);
                DataRow row;
                //将原有的存在行删除
                foreach (DataRow dr in dt.Rows)
                {
                    SqlCommand myDelCommand = new SqlCommand("DELETE  " + tableName + " WHERE " + keyName + " = @key", conn);
                    myDelCommand.Transaction = myTrans;
                    System.Data.IDataParameter iparam = new SqlParameter();
                    iparam.ParameterName = "@key";
                    iparam.DbType = GetDbType(myDataSet.Tables[tableName].Columns[keyName].DataType);
                    iparam.Value = dr[keyName];
                    myDelCommand.Parameters.Add(iparam);

                    myDelCommand.Connection = conn;
                    int rtn = myDelCommand.ExecuteNonQuery();

                }
                //插入现有行
                foreach (DataRow dr in dt.Rows)
                {
                    row = myDataSet.Tables[tableName].NewRow();
                    row.ItemArray = dr.ItemArray;
                    myDataSet.Tables[tableName].Rows.Add(row);
                }

                SqlCommandBuilder builder = new SqlCommandBuilder(myAdapter);
                myAdapter.InsertCommand = builder.GetInsertCommand();


                int rowCount = myAdapter.Update(myDataSet, tableName);
                if (rowCount > 0)
                {
                    myTrans.Commit();
                    flg = true;
                }
                else
                {
                    myTrans.Rollback();
                    flg = false;
                }

            }
            catch
            {
                myTrans.Rollback();
                flg = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return flg;
        }

        /// <summary>
        /// 获取药品匹配数据
        /// </summary>
        /// <param name="erpProductCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public string GetProductMapData(string erpProductCode, string orgId, out object num)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select product_id from gpo_product_map p ");
            sb.AppendFormat(" where p.map_orgid='{0}'", orgId);
            sb.AppendFormat(" and p.product_code ='{0}'",erpProductCode);
            sb.Append("and product_id is not null");

            string result = null;    
            try
            {
                object o = DbFacade.SQLExecuteScalar(sb.ToString());
                if (o != null)
                    result = o.ToString();
            }
            catch (Exception e)
            {
                //throw e;
            }
            StringBuilder sbNum = new StringBuilder();
            sbNum.Append("select count(1) from gpo_product_map p ");
            sbNum.AppendFormat(" where p.map_orgid='{0}'", orgId);
            sbNum.AppendFormat(" and p.product_code ='{0}'", erpProductCode);
            sbNum.Append("and product_id is not null");
            num = DbFacade.SQLExecuteScalar(sbNum.ToString());
            return result;
        }
        /// <summary>
        /// 获取买方匹配数据
        /// </summary>
        /// <param name="erpHisCode"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public string GetCorpMapData(string erpHisCode, string orgId, out object crpnum)
        {           
            StringBuilder sb = new StringBuilder();
            sb.Append("select org_id from gpo_corp_map p ");
            sb.AppendFormat(" where p.map_orgid ='{0}'",orgId);
            sb.AppendFormat(" and p.code ='{0}'",erpHisCode);            
            string result = null;     

            try
            {
                object o = DbFacade.SQLExecuteScalar(sb.ToString());
                if (o != null)
                    result = o.ToString();
            }
            catch (Exception e)
            {
                //throw e;
            }
            StringBuilder sbNum = new StringBuilder();
            sbNum.Append("select count(1) from gpo_corp_map p");
            sbNum.AppendFormat(" where p.map_orgid ='{0}'", orgId);
            sbNum.AppendFormat(" and p.code ='{0}'", erpHisCode);            
            crpnum = DbFacade.SQLExecuteScalar(sbNum.ToString());
            return result;
        }

        public DataTable GetErpProductByProcode(string erpProductCode, string orgId)
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from gpo_product_map");
            sql.AppendFormat(" where map_orgid='{0}' and product_code='{1}'", orgId, erpProductCode);
            dt = DbFacade.SQLExecuteDataTable(sql.ToString());
            return dt;
        }
        //add  by cjg
        /// <summary>
        /// 获取未匹ERP配药品表
        /// </summary>
        /// <param name="dtImport"></param>
        /// <returns></returns>
        public DataTable GetNotMapData(ref DataTable dtImport,string sOrgID)
        {
            DataTable dtProd = dbFacade.SQLExecuteDataTable("select product_code from gpo_product_map where ismap = '1' and map_orgid ='"+sOrgID+"'" );
            DataTable dtReturn = dtImport.Clone();
            DataTable dtTemp = dtImport.Copy();
            dtReturn.PrimaryKey = new DataColumn []{dtReturn.Columns["buyer_code"]};
            dtImport.Clear();
            foreach (DataRow dr in dtTemp.Rows)
            {
                if (dtProd.Select("product_code='" + dr["product_code"] + "'").Length == 0)
                 {
                     dtImport.ImportRow(dr);
                 }             
            }     

            DataTable dtCorp = dbFacade.SQLExecuteDataTable(" select code from gpo_corp_map where ismap = '1' and map_orgid ='"+sOrgID+"'");                  
            foreach (DataRow dr in dtTemp.Rows)
            {               
                 if (dtCorp.Select("code='" + dr["buyer_code"] + "'").Length == 0 && !dtReturn.Rows.Contains(dr["buyer_code"]))
                 {
                     dtReturn.ImportRow(dr);
                 }
            }
            return dtReturn;
        }

        #region DbType
        private static System.Data.DbType GetDbType(Type type)
        {
            DbType result = DbType.String;
            if (type.Equals(typeof(int)) || type.IsEnum)
                result = DbType.Int32;
            else if (type.Equals(typeof(long)))
                result = DbType.Int32;
            else if (type.Equals(typeof(double)) || type.Equals(typeof(Double)))
                result = DbType.Decimal;
            else if (type.Equals(typeof(DateTime)))
                result = DbType.DateTime;
            else if (type.Equals(typeof(bool)))
                result = DbType.Boolean;
            else if (type.Equals(typeof(string)))
                result = DbType.String;
            else if (type.Equals(typeof(decimal)))
                result = DbType.Decimal;
            else if (type.Equals(typeof(byte[])))
                result = DbType.Binary;
            else if (type.Equals(typeof(Guid)))
                result = DbType.Guid;

            return result;

        }

        #endregion

    }
}
