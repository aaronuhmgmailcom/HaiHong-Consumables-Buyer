using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Common
{
    public class ParamCom : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        private ParamCom()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private ParamCom(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ParamCom GetInstance()
        {
            return new ParamCom();
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static ParamCom GetInstance(string connectionName)
        {
            return new ParamCom(connectionName);
        }
        public string getParamValue(string functionId, string locationID)
        {
            if (string.IsNullOrEmpty(locationID))
            {
                return getParamDefaultValue(functionId);
            }
            string result = null;
            string sql = "select result_id from par_set_result where rtrim(function_id)=:function_id and location_id=:location_id";
            DbParameter paramFun = base.DbFacade.CreateParameter();
            paramFun.ParameterName = "function_id";
            paramFun.DbType = DbType.String;
            paramFun.Value = functionId;
            DbParameter paramLoc = base.DbFacade.CreateParameter();
            paramLoc.ParameterName = "location_id";
            paramLoc.DbType = DbType.String;
            paramLoc.Value = locationID;
            try
            {
                object o = DbFacade.SQLExecuteScalar(sql,paramFun,paramLoc);
                if (o != null)
                    result = o.ToString();
                else
                    return getParamDefaultValue(functionId);

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;

        }
        public string getParamDefaultValue(string functionId)
        {
            string result = null;
            string sql = "select default_value from par_set_desc where rtrim(function_id) = :function_id";
            DbParameter param = base.DbFacade.CreateParameter();
            param.ParameterName = "function_id";
            param.DbType = DbType.String;
            param.Value = functionId;
            try
            {
                object o = DbFacade.SQLExecuteScalar(sql, param);
                if (o != null)
                    result = o.ToString();

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public string getParamValue(string functionId, string locationID, string location)
        {
            
            string result = null;
            string sql = @"select result_id from par_set_result where rtrim(function_id)=:function_id 
                            and location_id=:location_id
                            and USED_MODULE='1'
                            and LOCATION=:LOCATION";
            DbParameter paramFun = base.DbFacade.CreateParameter();
            paramFun.ParameterName = "function_id";
            paramFun.DbType = DbType.String;
            paramFun.Value = functionId;
            DbParameter paramLoc = base.DbFacade.CreateParameter();
            paramLoc.ParameterName = "location_id";
            paramLoc.DbType = DbType.String;
            paramLoc.Value = locationID;
            DbParameter paramLocation = base.DbFacade.CreateParameter();
            paramLocation.ParameterName = "LOCATION";
            paramLocation.DbType = DbType.String;
            paramLocation.Value = location;
            try
            {
                object o = DbFacade.SQLExecuteScalar(sql, paramFun, paramLoc, paramLocation);
                if (o != null)
                    result = o.ToString();
               

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;

        }


        public bool autoReceiveForBuyer(string receiveId,string type)
        {
            //这些数据都是系统启动之前由系统管理人员手工添加到par_set_desc表中，要和本段程序一致
            string function_id = "hc_10";//par_set_desc表中par_set_desc字段，全系统唯一的参数标识
            string used_module = "9";//url传递的子系统标识，比如订单、会员等
            string location = "1";//表示买方，卖方还是中介
            string result = null;
            string strsql = "";
            if (type.Equals("1"))
            {
                strsql = "select res.result_id  " +
                        "from par_set_result res," +
                        "(select ord.buyer_orgid " +
                        "from ord_order_item item, ord_order_receive receive, ord_order ord " +
                        "where ord.order_id = item.order_id and item.record_id = receive.order_item_id and receive.id = '" + receiveId + "') t " +
                        "where res.location = '" + location + "' and res.used_module = '" + used_module + "' and res.function_id = '" + function_id + "' and t.buyer_orgid = res.location_id";
            }
            else
            {
                strsql = "select res.result_id  " +
                                        "from par_set_result res," +
                                        "(select ord.buyer_orgid " +
                                        "from ord_order_item_non item, ord_order_receive_non receive, ord_order_non ord " +
                                        "where ord.order_id = item.order_id and item.record_id = receive.order_item_id and receive.id = '" + receiveId + "') t " +
                                        "where res.location = '" + location + "' and res.used_module = '" + used_module + "' and res.function_id = '" + function_id + "' and t.buyer_orgid = res.location_id";
            }
            //DbParameter paramId = base.DbFacade.CreateParameter();
            //paramId.ParameterName = "receive_id";
            //paramId.DbType = DbType.String;
            //paramId.Value = receiveId;
            
            try
            {
                object o = DbFacade.SQLExecuteScalar(strsql);
                if (o != null)
                    result = o.ToString();
                else
                    return getParamDefaultValue(function_id).Equals("1")?true:false;

            }
            catch (Exception e)
            {
                throw e;
            }
            return result.Equals("1") ? true : false;//1表示自动到货，2表示不自动到货

        }



    }
}
