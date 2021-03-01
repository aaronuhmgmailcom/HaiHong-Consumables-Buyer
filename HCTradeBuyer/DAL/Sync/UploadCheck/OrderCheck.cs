using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Sync.UploadCheck
{
    class OrderCheck : OracleDAOBase
    {
        private OrderCheck()
            : base()
        { }

        private OrderCheck(string connectionName)
            : base(connectionName)
        { }

        public static OrderCheck GetInstance()
        {
            return new OrderCheck();
        }

        public static OrderCheck GetInstance(string connectionName)
        {
            return new OrderCheck(connectionName);
        }

        #region 订单主表校验
        /// <summary>
        /// 订单主表更新校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderForUpdate(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select state from hc_ord_Order where id = :order_id";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "order_id";
            para.DbType = DbType.UInt64;
            para.Value = dr["ID"];

            Object o = DbFacade.SQLExecuteScalar(sql, para);
            //判断 ord_order表订单状态 ORDER_STATE 为 5（完成）6(作废)则不能修改
            if (o != null)
            {
                string state = o.ToString();
                if (state.Equals("5") || state.Equals("6") )
                {
                    strInvalid = "table:hc_ord_Order/id:" + dr["id"] + "/订单状态字段为5（完成）或6（作废），不能修改";
                    flag = false;
                }
            }

            return flag;
        }

        /// <summary>
        /// 订单主表插入校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderForInsert(DataRow dr, out string strInvalid)
        {
            //strInvalid = "table:HC_ORD_ORDER_ITEM/ID:" + dr["id"] + "/状态字段为3（作废）或5（关闭），不能修改！";
            strInvalid = "";
            return true;
        }

        #endregion

        #region 订单明细表校验
        /// <summary>
        /// 订单明细表更新校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderItemForUpdate(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select state from HC_ORD_ORDER where ID = :RECORD_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "RECORD_ID";
            para.DbType = DbType.UInt64;
            para.Value = dr["ORDER_ID"]; 

            Object o = DbFacade.SQLExecuteScalar(sql, para);

            if (o != null)
            {
                string state = o.ToString();
                //1、判断订单明细标记状态字段为6（作废）或5（完成），不能修改
                if (state.Equals("6") || state.Equals("5"))
                {
                    strInvalid = "table:HC_ORD_ORDER/ID:" + dr["ORDER_ID"] + "/状态字段为6（作废）或5（完成），不能修改！";
                    flag = false;
                }
                ////2、订单明细表（GPO_ORDER_ITEM）状态字段（ITEM_STATUS）为3（已确认）时，不能将将状态（ITEM_STATUS）置为5（作废）
                //else if (state.Equals("3") && dr["ITEM_STATUS"].ToString().Equals("5"))
                //{
                //    strInvalid = "table:Gpo_Order_Item/RECORD_ID:" + dr["RECORD_ID"] + "/不能由3（卖方备货确认） 变为5（作废），不能修改！";
                //    flag = false;
                //}
                ////3、订单明细表（GPO_ORDER_ITEM）状态字段（ITEM_STATUS）为6（缺货）时，不能将将状态（ITEM_STATUS）置为4（到货中）或者7（完成）
                //else if (state.Equals("6") && (dr["ITEM_STATUS"].ToString().Equals("4") || dr["ORDER_ITEM_STATE"].ToString().Equals("7")))
                //{
                //    strInvalid = "table:Gpo_Order_Item/RECORD_ID:" + dr["RECORD_ID"] + "/不能由 6(缺货) 变为 4（到货中）或7（完成），不能修改！";
                //    flag = false;
                //}
            }

            return flag;
        }

        /// <summary>
        /// 订单明细表插入校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderItemForInsert(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select state from HC_ORD_ORDER where ID = :RECORD_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "RECORD_ID";
            para.DbType = DbType.UInt64;
            para.Value = dr["ORDER_ID"];

            Object o = DbFacade.SQLExecuteScalar(sql, para);

            if (o != null)
            {
                string state = o.ToString();
                //1、判断订单明细标记状态字段为6（作废）或5（完成），不能修改
                if (state.Equals("6") || state.Equals("5"))
                {
                    strInvalid = "table:HC_ORD_ORDER/ID:" + dr["ORDER_ID"] + "/状态字段为6（作废）或5（完成），不能插入订单明细！";
                    flag = false;
                }

            }

            return flag;
            //string hitCommState = "0";
            //OrdHitModel hitComm = new OrdHitModel();
            //PurchaseDAO purchaseDAO = new PurchaseDAO();
            //string purchaseId = "";

            ///*string sql = "select op.purchase_state,op.id as purchase_id from gpo_purchase op,gpo_purchase_item opi where opi.purchase_id = op.Id And opi.Id=:purchase_item_id";
            //DbParameter para = this.DbFacade.CreateParameter();
            //para.ParameterName = "purchase_item_id";
            //para.DbType = DbType.String;
            //para.Value = dr["purchase_item_id"];

            //DataTable dt = DbFacade.SQLExecuteDataTable(sql, para);
            //if (dt.Rows.Count > 0)
            //{
            //    //获取状态值
            //    string state = dt.Rows[0]["purchase_state"].ToString();
            //    purchaseId = dt.Rows[0]["purchase_id"].ToString();
            //    //1、对应采购单主表（GPO_PURCHASE）状态字段（PURCHASE_STATE）为2（完成）时不能新增
            //    //if (state.Equals("2"))
            //    //{
            //    //    strInvalid = "table:Gpo_order_item/RECORD_ID:" + dr["RECORD_ID"] + "/table:Gpo_purchase_item/id:" + dr["RECORD_ID"] + "/采购单状态字段为2（完成），不能新增";
            //    //    flag = false;
            //    //}
            //    //else
            //    //{
            //        flag = true;
            //    //}
            //}
            //else 
            //{
            //    flag = false;
            //}*/

            //string hitCommId = dr["HIT_COMM_ID"].ToString();
            //// 如果订单明细中的hit_comm_id还在ord_hit_comm中，则hitCommState为0，否则为1
            //hitCommState = "0";

            //try
            //{
            //    //获取采购目录记录对象
            //    hitComm = purchaseDAO.getOrHitInfo(hitCommId,tr);
            //}
            //catch (Exception)
            //{
            //    hitCommState = "1";
            //    flag = false;
            //}
            
            //if (hitComm == null || hitComm.Equals(""))
            //{
            //    hitCommState = "1";
            //    //2、判断对应采购单明细中的HIT_COMM_ID字段是否在GPO_HIT_COMM中，如果不在则不能新增
            //    strInvalid = "talbe:GPO_HIT_COMM表中不存在记录号为：" + hitCommId + "不能进行新增操作";
            //    flag = false;
            //}

            //if (hitCommState.Equals("0"))
            //{
            //    //3、判断对应GPO_HIT_COMM中的记录，如果商品供应截止时间（PROVIDE_END_DATE）为空，或者商品供应截止时间在当前时间以前，则不能新增
            //    if (string.IsNullOrEmpty(hitComm.Provide_end_date.ToString()) || DateTime.Compare(DateTime.Now, hitComm.Provide_end_date) > 0)
            //    {
            //        flag = false;
            //    }

            //    //4、判断对应GPO_HIT_COMM中的记录，如果禁止使用标志（ENABLE_FLAG）为空，或者禁止使用标志（ENABLE_FLAG）不为1（正常），则不能新增
            //    if (string.IsNullOrEmpty(hitComm.Enable_flag) || !hitComm.Enable_flag.Equals("1"))
            //    {
            //        flag = false;
            //    }

            //    //5、对应采购单明细表（GPO_PURCHASE_ITEM）的订单生成标识（ORDER_FLAG）为1时（生成订单）不能新增
            //    if (!hitComm.Enable_flag.Equals("1"))
            //    {
            //        flag = false;
            //    }

            //    //6、对应采购单明细表（GPO_PURCHASE_ITEM）的订单生成标识（ORDER_FLAG）为1时（生成订单）不能新增
            //    const decimal e = 0.0000000000001M;
            //    if (((Math.Abs(hitComm.Provide_price)) - Convert.ToDecimal(dr["UNIT_PRICE"].ToString())) > e)
            //    {
            //        flag = false;
            //    }

            //}


            return flag;
        }

        #endregion

        #region 订单到货表校验
        /// <summary>
        /// 订单到货表数据更新校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderReceiveForUpdate(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select state from HC_ORD_ORDER_ITEM where ID = :RECORD_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "RECORD_ID";
            para.DbType = DbType.UInt64;
            para.Value = dr["ORDER_ITEM_ID"];

            Object o = DbFacade.SQLExecuteScalar(sql, para);

            if (o != null)
            {
                string state = o.ToString();
                //1、判断订单明细标记状态字段为3（作废）或者5（完成），不能修改
                if (state.Equals("3") || state.Equals("5"))
                {
                    strInvalid = "table:HC_ORD_ORDER_ITEM/ID:" + dr["ORDER_ITEM_ID"] + "/状态字段为3（作废）或5（完成），不能更新订单到货表数据！";
                    flag = false;
                }

            }
            return flag;
        }

        /// <summary>
        /// 订单到货表数据插入校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderReceiveForInsert(DataRow dr, DbTransaction trans, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select state from HC_ORD_ORDER_ITEM where ID = :RECORD_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "RECORD_ID";
            para.DbType = DbType.AnsiString;
            para.Value = dr["ORDER_ITEM_ID"];

            Object o = DbFacade.SQLExecuteScalar(sql, para);

            if (o != null)
            {
                string state = o.ToString();
                //1、判断订单明细标记状态字段为3（作废）或者5（完成），不能新增
                if (state.Equals("5") || state.Equals("3"))
                {
                    strInvalid = "table:HC_ORD_ORDER_ITEM/ID:" + dr["ORDER_ITEM_ID"] + "/状态字段为3（作废）或5（完成），不能插入订单到货表数据！";
                    flag = false;
                }
                //2、GPO_ORDER_ITEM中订单明细状态ITEM_STATUS 为 7(完成) ，则不能新增
                //else if (state.Equals("7"))
                //{
                //    //修改原因：离线状态下，产生的GPO_ORDER_ITEM中订单明细状态ITEM_STATUS 为 7(完成)时，上传到服务器上的数据也为 7，导致不能插入订单到货表。
                //    //修改方法：增加一个判断，检查服务器上有没有对应的到货记录，如果没有则上传到货数据
                //    //修改时间：2007-05-22 10：08
                //    //修改人：  shejg
                //    if (CheckOrderReceiveForUpdate(dr, out strInvalid))
                //    {
                //        flag = true;
                //    }
                //    else
                //    {
                //        strInvalid = "table:GPO_ORDER_ITEM/RECORD_ID:" + dr["ORDER_ITEM_ID"] + "/状态字段为7（完成），不能新增";
                //        flag = false;
                //    }
                //    //strInvalid = "table:GPO_ORDER_ITEM/RECORD_ID:" + dr["ORDER_ITEM_ID"] + "/状态字段为7（缺货），不能新增";
                //    //flag = false;
                //}
                //else
                //{
                //    flag = true;
                //}
            }

            return flag;
        }

        #endregion


        #region 退货订单表
        /// <summary>
        /// 订单退货表数据更新校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderReturnForUpdate(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select return_state from Gpo_Order_Return where id = :id";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "id";
            para.DbType = DbType.AnsiString;
            para.Value = dr["id"];

            Object o = DbFacade.SQLExecuteScalar(sql, para);
            if (o != null)
            {
                string state = o.ToString();
                //判断 退货明细表ord_order_return中RETURN_STATE（退货状态）为3 （同意）时，不能进行修改
                if (state.Equals("3"))
                {
                    strInvalid = "table:Ord_Order_Return/id:" + dr["id"] + "/状态字段为3（同意），不能修改";
                    flag = false;
                }
            }

            return flag;
        }

        /// <summary>
        /// 订单退货表数据插入校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckOrderReturnForInsert(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select FACT_AMOUNT，RETURN_AMOUNT from HC_ORD_ORDER_RECEIVE where ID = :RECEIVE_ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "RECEIVE_ID";
            para.DbType = DbType.AnsiString;
            para.Value = dr["RECEIVE_ID"];

            DataTable dt = DbFacade.SQLExecuteDataTable(sql, para);
            if (dt.Rows.Count > 0)
            {
                //实际到货量
                Decimal ReceiveQty = Convert.ToDecimal(dt.Rows[0]["FACT_AMOUNT"].ToString());
                Decimal returnAmount = Convert.ToDecimal(dt.Rows[0]["RETURN_AMOUNT"].ToString());
                //退货数量
                Decimal ReturnQty = Convert.ToDecimal(dr["AMOUNT"].ToString());
                //退货数量不能大于实际到货量
                if (ReturnQty + returnAmount > ReceiveQty)
                {
                    strInvalid = "table:HC_ORD_ORDER_RECEIVE/id:" + dr["RECEIVE_ID"] + "/中到货数量不得小于新增退货数量，不能修改";
                    flag = false;
                }
            }

            return flag;
        }

        #endregion

    

        #region 通过订单明细校验订单
        /// <summary>
        ///  通过订单明细校验订单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="purchaseId">采购单ID</param>
        /// <returns></returns>
        public bool CheckOrderFromItem(string orderId, string purchaseId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update HC_ORD_ORDER");
            sb.Append(" Set Request_Total = Nvl((Select Sum(Unit_Price * Request_Qty) As Sum");
            sb.Append("							From Gpo_Order_Item");
            sb.Append("							Where Order_Id = :Order_Id), 0)");
            sb.Append(" Where Order_Id = :Order_Id");

            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "order_id";
            para.DbType = DbType.AnsiString;
            para.Value = orderId;

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("delete from Gpo_Order ");
            sb1.Append(" where order_id = :order_id");
            sb1.Append("    and (select count(record_id) as num");
            sb1.Append("          from gpo_order_item");
            sb1.Append("         where order_id = :order_id) = 0");

            DbParameter para1 = this.DbFacade.CreateParameter();
            para1.ParameterName = "order_id";
            para1.DbType = DbType.AnsiString;
            para1.Value = orderId;

            try
            {
                //订单明细更新订单总额
                base.DbFacade.SQLExecuteNonQuery(sb.ToString(), para);
                //删除无订单明细的订单
                int num = DbFacade.SQLExecuteNonQuery(sb1.ToString(), para1);

                if (num > 0)
                {
                    string sql2 = "Update Gpo_purchase set purchase_state = '0' where Id=:purchase_id";
                    DbParameter para2 = this.DbFacade.CreateParameter();
                    para2.ParameterName = "purchase_id";
                    para2.DbType = DbType.AnsiString;
                    para2.Value = purchaseId;
                    //更新采购单状态为“准备”
                    DbFacade.SQLExecuteNonQuery(sql2, para2);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
