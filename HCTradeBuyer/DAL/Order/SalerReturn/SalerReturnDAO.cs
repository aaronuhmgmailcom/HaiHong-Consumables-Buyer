#region Head
//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerReturnDAO.cs    
//	创 建 人:	高原
//	创建日期:	2006-12-26
//	功能描述:	企业退货处理数据访问层
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
#endregion
#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.DAL.Common;
using System.Collections;
using Emedchina.TradeAssistant.Model.Order.SalerReturn;
using System.Data.Common;
using Emedchina.TradeAssistant.DAL.Common;
using Emedchina.TradeAssistant.DAL.Plat;
#endregion
namespace Emedchina.TradeAssistant.DAL.Order.SalerReturn
{
    public class SalerReturnDAO : OracleDAOBase
    {
        #region 查询退货单列表
        /// <summary>
        /// 查询退货单列表
        /// </summary>
        /// <param name="plats">受管理的平台集合</param>
        /// <param name="input">页面输入参数</param>
        /// <param name="pageParam">分业参数</param>
        /// <param name="rows">数据行数</param>
        /// <returns></returns>
        public DataTable findDealList(string[] plats, SalerReturnModel input, PagedParameter pageParam, out int rows)
        {
            //组织所有的交易所平台ＩＤ
            rows = 0;
            DataTable dt = null;
            StringBuilder sqlPlat = new StringBuilder();
            for (int i = 0; i < plats.Length;i++)
            {
                // PltPlat p1 = (PltPlat)it.next();
                if (i == 0)
                    sqlPlat.Append("'" + plats[i] + "'");
                else
                    sqlPlat.Append(",'" + plats[i] + "'");
                i++;
            }
            if (sqlPlat.Length == 0)
                return null;
            //根据查询类别，组织查询条件
            StringBuilder sb = new StringBuilder();
            List<DbParameter> parameters = new List<DbParameter>();
            DbParameter param = null;
            if (input.StrType != null && !input.StrKeyValue.Equals(""))
            {
                if (input.StrType.Equals("1"))
                {
                    sb.Append(" and (item.bak_medical_name like :StrKeyValue");

                    sb.Append(" or item.bak_product_name like :StrKeyValue)");                    
                }
                else if (input.StrType.Equals("2"))
                {
                    sb.Append(" and (item.bak_medical_fast like :StrKeyValue");

                    sb.Append(" or item.bak_product_fast like :StrKeyValue)");
                }
                else if (input.StrType.Equals("3"))
                {
                    sb.Append(" and (item.bak_medical_wubi like :StrKeyValue");

                    sb.Append(" or item.bak_product_wubi like :StrKeyValue)");                   
                }
                else if (input.StrType.Equals("4"))
                {
                    sb.Append(" and (ord.bak_buyer_easy like :StrKeyValue");
                    
                    sb.Append(" or ord.bak_buyer_name like :StrKeyValue)");                    
                }
                else
                {
                    return null;
                }
                param = this.DbFacade.CreateParameter();
                param.ParameterName = "StrKeyValue";
                param.DbType = DbType.String;
                if (input.StrType.Equals("1") || input.StrType.Equals("4"))
                {
                    param.Value = CommonFunction.GetLike(input.StrKeyValue);
                }
                else
                {
                    param.Value = CommonFunction.GetLike(input.StrKeyValue.ToUpper());
                }
                parameters.Add(param);                
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select rownum, r.id receive_id, r.receive_qty receive_qty_pre, t.id,item.bak_medical_name,item.bak_product_name,item.BAK_MASS_ASSIGNMENT,item.bak_medical_mode,item.bak_product_spec"
                            + " ,ord.bak_buyer_easy,ord.bak_buyer_name "
                            + " ,item.unit_price,t.lot_no,w.warehouse_name,r.receive_date,r.receive_qty,t.return_qty,t.buyer_remark"
                            + " ,t.create_date,to_char(t.create_date,'yyyy-mm-dd') create_date_display,t.confirm_date,to_char(t.confirm_date,'yyyy-mm-dd') confirm_date_display,t.saler_remark Remark "
                            + ", ord.order_code, ord.create_date order_date, t.create_userid, item.unit_price * t.return_qty return_money"
                            + ", item.product_id"
                            + " from ord_order_receive r,ord_order ord,ord_order_item item, ord_warehouse w,ord_order_return t"
                            + " where t.order_receive_id=r.id and t.order_id=ord.order_id and t.order_item_id =item.record_id "
                            + " and r.order_item_id = item.record_id and ord.order_id=item.order_id and item.repository_id =w.warehouse_id(+)"
                            + "	and t.sender_orgid = :orgid"
                            + " and t.return_state = :returnState"
                            + " and t.create_date >= to_date(:startDate,'yyyy-mm-dd hh24:mi:ss')"
                            + " and t.create_date<= to_date(:endDate,'yyyy-mm-dd hh24:mi:ss') + 1"
                            + " and t.plat_id in ("
                            + sqlPlat.ToString()
                            + ")"
                            + sb.ToString());

            param = this.DbFacade.CreateParameter();
            param.ParameterName = "orgid";
            param.DbType = DbType.String;
            param.Value = input.CurOrgId;          
            parameters.Add(param);

            param = this.DbFacade.CreateParameter();
            param.ParameterName = "returnState";
            param.DbType = DbType.String;
            param.Value = input.ReturnState;
            parameters.Add(param);

            param = this.DbFacade.CreateParameter();
            param.ParameterName = "startDate";
            param.DbType = DbType.String;
            param.Value = input.StartDate;
            parameters.Add(param);

            param = this.DbFacade.CreateParameter();
            param.ParameterName = "endDate";
            param.DbType = DbType.String;
            param.Value = input.EndDate;
            parameters.Add(param);

            try
            {
                rows = base.GetRowCount(strSql.ToString(), parameters.ToArray());
                //该sql需要用户自己绑定:highRowNum(该页的最大记录行数)和:lowRowNum(该页的最小记录行数)参数.
                DbParameter highIndexPara = DbFacade.CreateParameter();
                highIndexPara.ParameterName = "highRowNum";
                highIndexPara.DbType = DbType.Int32;
                highIndexPara.Value = PageUtils.GetHighIndexOfPage(int.Parse(pageParam.PageNum), int.Parse(pageParam.PageSize));
                parameters.Add(highIndexPara);

                DbParameter lowIndexPara = DbFacade.CreateParameter();
                lowIndexPara.ParameterName = "lowRowNum";
                lowIndexPara.DbType = DbType.Int32;
                lowIndexPara.Value = PageUtils.GetLowIndexOfPage(int.Parse(pageParam.PageNum), int.Parse(pageParam.PageSize));
                parameters.Add(lowIndexPara);

                dt = DbFacade.SQLExecuteDataTable(GetPagedSql(strSql.ToString()), parameters.ToArray());
            }
            catch (Exception e)
            {

                throw e;
            }

            return dt;
        }
        #endregion

        #region 查询4级平台ID
        /// <summary>
        /// 查询4级平台ID
        /// </summary>
        /// <param name="handlerId"></param>
        /// <param name="operate"></param>
        /// <param name="ui"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public string[] getClass4PlatsList(string handlerId, string operate, UserInfo ui, bool flag)
        {
            List<string> Class4PlatsList = PlatDao.GetInstance().getClass4PlatsList(handlerId, operate, ui, flag);
            string[] strPlat4Array = new string[Class4PlatsList.Count];
            int i = 0;
            foreach (string platID in Class4PlatsList)
            {
                strPlat4Array[i] = platID;
                i++;
            }
            return strPlat4Array;
        }
        #endregion

        #region 更新退货明细表
        /// <summary>
        /// 更新退货明细表
        /// </summary>
        /// <param name="Keys"></param>
        /// <param name="ui"></param>
        /// <param name="status">1--同意/0--拒绝/other--错误</param>
        /// <returns></returns>
        public bool UpdateReturnStatus(SalerReturnModel[] Keys, UserInfo ui, string status)
        {
            bool flg = false;
            int result;
            int result1 = 1;
            string sql;
            string sql1;
            if (status.Equals("1"))
            {
                sql = "UPDATE ORD_ORDER_RETURN SET RETURN_STATE = '3',SALER_REMARK = :REMARK ,MODIFY_USERID = :USERID,MODIFY_DATE = SYSDATE WHERE ID = :ID";                
            }
            else if (status.Equals("0"))
            {
                sql = "UPDATE ORD_ORDER_RETURN SET RETURN_STATE = '4',SALER_REMARK = :REMARK ,MODIFY_USERID = :USERID,MODIFY_DATE = SYSDATE WHERE ID = :ID";
            }
            else
            {
                return false;
            }
            DbParameter paraUserID = this.DbFacade.CreateParameter();
            paraUserID.ParameterName = "USERID";
            paraUserID.DbType = DbType.String;
            paraUserID.Value = ui.UserId;
            
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    for (int i = 0; i < Keys.Length; i++)
                    {
                        DbParameter paraRemark = this.DbFacade.CreateParameter();
                        paraRemark.ParameterName = "REMARK";
                        paraRemark.DbType = DbType.String;
                        paraRemark.Value = Keys[i].Remark;

                        DbParameter paraID = this.DbFacade.CreateParameter();
                        paraID.ParameterName = "ID";
                        paraID.DbType = DbType.String;
                        paraID.Value = Keys[i].Id;

                        result = DbFacade.SQLExecuteNonQuery(sql, transaction, paraRemark, paraUserID, paraID);
                        if (status.Equals("1"))
                        {
                            //sql1 = "UPDATE ORD_ORDER_RECEIVE SET RECEIVE_QTY = :RECEIVE_QTY WHERE ID = :RECEIVE_ID";
                            sql1 = "UPDATE ORD_ORDER_RECEIVE SET RECEIVE_QTY = " + Keys[i].StrReceiveQty.ToString() + " WHERE ID = '" + Keys[i].StrReceiveID + "'";

                            //DbParameter paraReceiveID = this.DbFacade.CreateParameter();
                            //paraReceiveID.ParameterName = "RECEIVE_ID";
                            //paraReceiveID.DbType = DbType.String;
                            //paraReceiveID.Value = Keys[i].StrReceiveID;

                            //DbParameter paraReceiveQty = this.DbFacade.CreateParameter();
                            //paraReceiveQty.ParameterName = "RECEIVE_QTY";
                            //paraReceiveQty.DbType = DbType.Double;
                            //paraReceiveQty.Value = Keys[i].StrReceiveQty;

                            //result1 = DbFacade.SQLExecuteNonQuery(sql1, transaction, paraReceiveQty, paraReceiveID);
                            result1 = DbFacade.SQLExecuteNonQuery(sql1, transaction);
                        }
                        if (result > 0 && result1 > 0) 
                        {
                            flg = true;
                        }
                        else
                        {
                            flg = false;
                            base.DbFacade.RollbackTransaction(transaction);
                            break;
                        }
                    }
                    DbFacade.CommitTransaction(transaction);
                }
                catch
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw;
                }
            }
            return flg;
        }
        #endregion
    }
}
