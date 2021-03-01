using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;


using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Sync.UploadCheck
{
    class ItemStatusCheck : OracleDAOBase
    {
        private ItemStatusCheck()
            : base()
        { }

        private ItemStatusCheck(string connectionName)
            : base(connectionName)
        { }

        public static ItemStatusCheck GetInstance()
        {
            return new ItemStatusCheck();
        }

        public static ItemStatusCheck GetInstance(string connectionName)
        {
            return new ItemStatusCheck(connectionName);
        }

        #region 订单明细状态表校验
        /// <summary>
        /// 订单明细状态表数据更新校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckItemStatusForUpdate(DataRow dr, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            string sql = "select Order_Item_State from GPO_ITEM_STATUS where id = :ID";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "Id";
            para.DbType = DbType.AnsiString;
            para.Value = dr["Id"];

            Object o = DbFacade.SQLExecuteScalar(sql, para);

            if (o != null)
            {
                string state = o.ToString();
                //1、判断Gpo_Order_Item中订单明细标记状态字段（Order_Item_State）为5（作废）或者7（完成），不能修改
                if (state.Equals("5") || state.Equals("7"))
                {
                    strInvalid = "table:GPO_ITEM_STATUS/ID:" + dr["id"] + "/状态字段为3（已确认）或5（关闭）或7（完成），不能修改！";
                    flag = false;
                }
                //2、订单明细状态表（ORDER_ITEM_STATE）状态字段（Order_Item_State）为3（已确认）时，不能将将状态（ITEM_STATUS）置为5（作废）
                else if (state.Equals("3") && dr["Order_Item_State"].ToString().Equals("5"))
                {
                    strInvalid = "table:GPO_ITEM_STATUS/ID:" + dr["id"] + "/不能由3（卖方备货确认） 变为5（作废），不能修改！";
                    flag = false;
                }
                //3、订单明细状态表（ORDER_ITEM_STATE）状态字段（Order_Item_State）为6（缺货）时，不能将将状态（ITEM_STATUS）置为4（到货中）或者7（完成）
                else if (state.Equals("6") && (dr["Order_Item_State"].ToString().Equals("4") || dr["ORDER_ITEM_STATE"].ToString().Equals("7")))
                {
                    strInvalid = "table:GPO_ITEM_STATUS/ID:" + dr["id"] + "/不能由 6(缺货) 变为 4（到货中）或7（完成），不能修改！";
                    flag = false;
                }
            }

            return flag;
        }

        /// <summary>
        /// 订单明细状态表数据插入校验
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strInvalid"></param>
        /// <returns></returns>
        public bool CheckItemStatusForInsert(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            strInvalid = "";
            bool flag = true;
            //string hitCommState = "0";
            //OrdHitModel hitComm = new OrdHitModel();
            //PurchaseDAO purchaseDAO = new PurchaseDAO();
            //string purchaseId = "";

            ///*string sql = "select op.purchase_state,op.id from gpo_purchase op,gpo_purchase_item opi where opi.purchase_id = op.Id And opi.Id=:purchase_item_id";
            //DbParameter para = this.DbFacade.CreateParameter();
            //para.ParameterName = "purchase_item_id";
            //para.DbType = DbType.AnsiString;
            //para.Value = dr["RECORD_ID"];

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
            //    return false;
            //}*/

            //string hitCommId = string.Empty;

            //string sql1 = "Select goi.HIT_COMM_ID From GPO_ORDER_ITEM goi Where goi.RECORD_ID=:Id";
            //DbParameter para1 = this.DbFacade.CreateParameter();
            //para1.ParameterName = "id";
            //para1.DbType = DbType.AnsiString;
            //para1.Value = dr["RECORD_ID"];

            //DataTable dt1 = DbFacade.SQLExecuteDataTable(sql1,tran, para1);
            //if (dt1.Rows.Count > 0)
            //{
            //    hitCommId = dt1.Rows[0]["HIT_COMM_ID"].ToString();
            //}
            //else
            //{
            //    return false;
            //}
            //// 如果订单明细中的hit_comm_id还在ord_hit_comm中，则hitCommState为0，否则为1
            //hitCommState = "0";

            //try
            //{
            //    //获取采购目录记录对象
            //    hitComm = purchaseDAO.getOrHitInfo(hitCommId, tran);
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

            //    ////6、对应采购单明细表（GPO_PURCHASE_ITEM）的订单生成标识（ORDER_FLAG）为1时（生成订单）不能新增
            //    //const decimal e = 0.0000000000001M;
            //    //if (((Math.Abs(hitComm.Provide_price)) - Convert.ToDecimal(dr["UNIT_PRICE"].ToString())) > e)
            //    //{
            //    //    flag = false;
            //    //}

            //}


            return flag;
        }

        #endregion

    }
}
