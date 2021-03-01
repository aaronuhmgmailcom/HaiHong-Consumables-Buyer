using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Sync.UploadCheck
{
    class RequestCheck : OracleDAOBase
    {
        private RequestCheck()
            : base()
        { }

        private RequestCheck(string connectionName)
            : base(connectionName)
        { }

        public static RequestCheck GetInstance()
        {
            return new RequestCheck();
        }

        public static RequestCheck GetInstance(string connectionName)
        {
            return new RequestCheck(connectionName);
        }

        #region 订单主表校验
        /// <summary>
        /// 订单主表更新校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckRequest(string requestID, out string strInvalid)
        {
            strInvalid = "";
            bool flag = false;
            string sql = "select REQUEST_STATE from GPO_REQUEST where ID = :ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "ID";
            para.DbType = DbType.AnsiString;
            para.Value = requestID;

            Object o = DbFacade.SQLExecuteScalar(sql, para);
            //判断 ord_order表订单状态 ORDER_STATE 为 3（完成）则不能修改
            if (o != null)
            {
                string state = o.ToString();
                if (state.Equals("8"))
                {
                    strInvalid = "table:GPO_REQUEST/ID:" + requestID + "/采购申请状态字段为8（作废），不能修改";
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            return flag;
        }
        #endregion

    }
}
