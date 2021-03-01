using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Sync.UploadCheck
{
    class PurchaseCheck : OracleDAOBase
    {
        private PurchaseCheck()
            : base()
        { }

        private PurchaseCheck(string connectionName)
            : base(connectionName)
        { }

        public static PurchaseCheck GetInstance()
        {
            return new PurchaseCheck();
        }

        public static PurchaseCheck GetInstance(string connectionName)
        {
            return new PurchaseCheck(connectionName);
        }

        #region 采购单记录更新校验

        //检查是否修改采购单记录
        public bool CheckPurchaseForUpdate(DataRow dr, out string strInvalid)
        {
            bool flag = true;
            string sql = "select state from hc_ord_purchase where id=:id";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "id";
            para.DbType = DbType.UInt64;
            para.Value = dr["id"];
            object o = DbFacade.SQLExecuteScalar(sql, para);
            strInvalid = "";
            if (o != null)
            {
                //获取状态标记
                string state = o.ToString();
                //if (state.Equals("2"))
                //{
                //    strInvalid = "table:hc_ord_purchase/id:" + dr["id"] + "/状态字段为2（送审）,不能进行修改操作";
                //    flag = false;
                //}
                if (state.Equals("4"))
                {
                    strInvalid = "table:hc_ord_purchase/id:" + dr["id"] + "/状态字段为4（发送）,不能进行修改操作";
                    flag = false;
                }
            }
            return flag;
        }

        //检查是否插入采购单记录
        public bool CheckPurchaseForInsert(DataRow dr, out string strInvalid)
        {
            bool flag = true;
            string sql = "select state from hc_ord_purchase where id=:id";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "id";
            para.DbType = DbType.UInt64;
            para.Value = dr["id"];
            object o = DbFacade.SQLExecuteScalar(sql, para);
            strInvalid = "";
            if (o != null)
            {
                //获取状态标记
                string state = o.ToString();
                if (state.Equals("4"))
                {
                    strInvalid = "table:hc_ord_purchase/id:" + dr["id"] + "/状态字段为4（发送）,不能进行新增操作";
                    flag = false;
                }
                //if (state.Equals("2"))
                //{
                //    strInvalid = "table:hc_ord_purchase/id:" + dr["id"] + "/状态字段为2（送审）,不能进行新增操作";
                //    flag = false;
                //}
            }
            return flag;
        }

        /// <summary>
        /// 判断是否可删除采购单记录
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckPurchaseForDelete(DataRow dr, out string strInvalid)
        {
            bool flag = true;
            string sql = "select state from hc_ord_purchase where id=:id";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "id";
            para.DbType = DbType.UInt64;
            para.Value = dr["id"];
            object o = DbFacade.SQLExecuteScalar(sql, para);
            strInvalid = "";
            if (o != null)
            {
                //获取状态标记
                string state = o.ToString();
                //if (state.Equals("2"))
                //{
                //    strInvalid = "table:hc_ord_purchase/id:" + dr["id"] + "/状态字段为2（送审）,不能进行删除操作";
                //    flag = false;
                //}
                if (state.Equals("4"))
                {
                    strInvalid = "table:hc_ord_purchase/id:" + dr["id"] + "/状态字段为4（发送）,不能进行删除操作";
                    flag = false;
                }
            }
            return flag;
        }

        #endregion

        #region 采购单明细记录更新校验
        //检查是否可修改采购单明细记录
        public bool CheckPurchaseItemForUpdate(DataRow dr, out string strInvalid)
        {
            bool flag = true;
            string sql = "select state from hc_ord_purchase where id=:PURCHASE_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "PURCHASE_ID";
            para.DbType = DbType.UInt64;
            para.Value = dr["PURCHASE_ID"];
            object o = DbFacade.SQLExecuteScalar(sql, para);
            strInvalid = "";
            if (o != null)
            {
                string state = o.ToString();
                
                //if (state.Equals("2"))
                //{
                //    strInvalid = "table:hc_ord_purchase/id:" + dr["PURCHASE_ID"] + "/采购单主表状态字段为2（送审）,不能进行修改操作";
                //    flag = false;
                //}
                if (state.Equals("4"))
                {
                    strInvalid = "table:hc_ord_purchase/id:" + dr["PURCHASE_ID"] + "/采购单主表状态字段为4（发送）,不能进行修改操作";
                    flag = false;
                }

            }
            return flag;

        }

        //检查是否可插入采购单明细记录
        public bool CheckPurchaseItemForInsert(DataRow dr, out string strInvalid)
        {
            bool flag = true;
            string sql = "select state from hc_ord_purchase where id=:PURCHASE_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "PURCHASE_ID";
            para.DbType = DbType.UInt64;
            para.Value = dr["PURCHASE_ID"];
            object o = DbFacade.SQLExecuteScalar(sql, para);
            strInvalid = "";
            if (o != null)
            {
                string state = o.ToString();
               
                //if (state.Equals("2"))
                //{
                //    strInvalid = "table:hc_ord_purchase/id:" + dr["PURCHASE_ID"] + "/采购单主表状态字段为2（送审）,不能进行新增操作";
                //    flag = false;
                //}
                if (state.Equals("4"))
                {
                    strInvalid = "table:hc_ord_purchase/id:" + dr["PURCHASE_ID"] + "/采购单主表状态字段为4（发送）,不能进行新增操作";
                    flag = false;
                }
            }
            return flag;

        }

        //检查是否可删除采购单明细记录
        public bool CheckPurchaseItemForDelete(DataRow dr, out string strInvalid)
        {
            bool flag = true;
            string sql = "select state from hc_ord_purchase hop, hc_ord_purchase_item hopi where hop.id = hopi.PURCHASE_ID and hopi.id=:ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "ID";
            para.DbType = DbType.UInt64;
            para.Value = dr["ID"];
            object o = DbFacade.SQLExecuteScalar(sql, para);
            strInvalid = "";
            if (o != null)
            {
                string state = o.ToString();
                
                //if (state.Equals("2"))
                //{
                //    strInvalid = "table:hc_ord_purchase/id:" + dr["PURCHASE_ID"] + "/采购单主表状态字段为2（送审）,不能进行删除操作";
                //    flag = false;
                //}
                if (state.Equals("4"))
                {
                    strInvalid = "table:hc_ord_purchase/id:" + dr["PURCHASE_ID"] + "/采购单主表状态字段为4（发送）,不能进行删除操作";
                    flag = false;
                }
            }
            return flag;
        }

        #endregion

        #region 经常采购目录记录更新校验

       

        /// <summary>
        /// 判断是否可新增经常采购目录记录
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckHitCommForInsert(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            bool flag = true;
            string sql = "select g.record_id from gpo_hit_comm g where g.buyer_id = :buyer_id and g.contract_item_id = :contract_item_id";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "buyer_id";
            para.DbType = DbType.UInt64;
            para.Value = dr["buyer_id"];

            DbParameter para1 = this.DbFacade.CreateParameter();
            para1.ParameterName = "contract_item_id";
            para1.DbType = DbType.UInt64;
            para1.Value = dr["contract_item_id"];
            object o = DbFacade.SQLExecuteScalar(sql,tran, para,para1);
            strInvalid = "";
            if (o != null)
            {
                flag = false;
                
            }
            return flag;
        }

        #endregion

    }
}
