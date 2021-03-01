using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.Order.BuyerOrder;

namespace Emedchina.TradeAssistant.Client.DAL.Order.BuyerOrder
{
    class OrderOfflineDAO : SqlDAOBase
    {
        private OrderOfflineDAO()
            : base()
        { }

        private OrderOfflineDAO(string connectionName)
            : base(connectionName)
        { }

        public static OrderOfflineDAO GetInstance()
        {
            return new OrderOfflineDAO();
        }

        public static OrderOfflineDAO GetInstance(string connectionName)
        {
            return new OrderOfflineDAO(connectionName);
        }

        /// <summary>
        /// 取得按订单到货列表数据
        /// </summary>
        public DataSet GetBuyerOrderList(BuyerOrderModel input, out int rows)
        {
            DataSet ds = new DataSet();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select o.id as id ,o.state,o.sender_id ,PURCHASE_CODE,o.sender_name,o.sender_name_abbr,o.create_date,(case when  o.Total_sum is null then '-' else o.Total_sum end)  As Total_sum,(case when  o.over_sum is null then '-' else o.over_sum end)  As over_sum,");
                sql.Append("       (case when o.Create_User_name ='' or o.Create_User_name is null then '-' else o.Create_User_name end)  As Create_User_name ,o.order_code,");
                sql.Append("       (case o.STATE when '1' then '未阅读' when '2' then '已阅读' when '3' then '确认' when '4' then '处理中' when '5' then '完成' when '6' then '作废' end) As Order_State, ");
                sql.Append("       o.type As orderType, ");
                sql.Append("       (case o.type when '1' then '普通订单' when '2' then '发货流程' when '3' then '确认单（备货）'  end) As type, ");
                sql.Append("       (case o.QUICKSEND_LEVEL when '1' then '普通' when '2' then '部分紧急' when '3' then '紧急'  end) As QUICKSEND_LEVEL ,SALER_DESCRIPTIONS,BUYER_DESCRIPTIONS,SALER_APPROVER_NAME,SALER_APPROVER_DATE,MODIFY_USER_NAME,MODIFY_DATE");
                sql.Append("  from HC_ORD_ORDER o ");

                List<DbParameter> parameters = new List<DbParameter>();

                sql.Append(" where 1 = 1 ");
                
                input.Rows = base.GetRowCount(sql.ToString(), parameters.ToArray());
                rows = input.Rows;
                
                DataTable tb = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());
                ds.Tables.Add(tb);
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;

        }

        /// <summary>
        /// 取得按企业到货列表数据
        /// </summary>
        public DataSet GetBuyerOrderByOrgList(BuyerOrderModel input, out int rows)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            try
            {
                //sql.Append("select distinct o.saler_id,");
                //sql.Append(" o.saler_name as saler_name,");
                //sql.Append(" o.saler_easy as saler_easy,");
                //sql.Append(" count(1) as order_num, ");
                //sql.Append(" Trim(Format(Sum(o.Request_Total), 'Standard')) As request_total, ");
                //sql.Append(" Sum(o.Request_Total) As request_total_num ");
                //sql.Append(" from gpo_order o");

                sql.Append("Select a.*,b.Org_Name As Saler_Name, b.Org_Easy As Saler_Easy");
                sql.Append(" From");
                sql.Append(" (");
                sql.Append(" Select Distinct o.Saler_Id, Count(1) As Order_Num");
                sql.Append(" ,Trim(Format(Sum(o.Request_Total), 'Standard')) As Request_Total,");
                sql.Append(" Sum(o.Request_Total) As Request_Total_Num");
                sql.Append(" From Gpo_Order o");

                List<DbParameter> parameters = new List<DbParameter>();
                sql.Append(" where 1=1 ");
                //sql.Append(" and o.order_state = '2' ");
                sql.Append(" and o.area_id = :areaId");
                DbParameter areaIdPara = this.DbFacade.CreateParameter();
                areaIdPara.ParameterName = "areaId";
                areaIdPara.DbType = DbType.String;
                areaIdPara.Value = input.AreaId;
                parameters.Add(areaIdPara);

                sql.Append(" and o.buyer_orgid = :orgId");
                DbParameter orgIdPara = this.DbFacade.CreateParameter();
                orgIdPara.ParameterName = "orgId";
                orgIdPara.DbType = DbType.String;
                orgIdPara.Value = input.OrgId;
                parameters.Add(orgIdPara);

                //查询条件:订单状态
                if (!String.IsNullOrEmpty(input.OrderState))
                {
                    sql.Append(" and o.order_state = :state");
                    DbParameter statePara = this.DbFacade.CreateParameter();
                    statePara.ParameterName = "state";
                    statePara.DbType = DbType.String;
                    statePara.Value = input.OrderState;
                    parameters.Add(statePara);

                }


                //查询条件:发送时间开始
                if (!String.IsNullOrEmpty(input.StartDate))
                {
                    sql.Append(" and o.create_date>=CDate(:startDate) ");
                    //sql.Append(" and o.create_date>=CDate(:startDate,'yyyy-mm-dd hh24:mi:ss') ");
                    //sql.Append(input.StartDate);
                    //sql.Append("','yyyy-mm-dd hh24:mi:ss') ");
                    DbParameter startDatePara = this.DbFacade.CreateParameter();
                    startDatePara.ParameterName = "startDate";
                    startDatePara.DbType = DbType.String;
                    startDatePara.Value = ComUtil.formatDate(input.StartDate);
                    parameters.Add(startDatePara);
                }

                //查询条件:发送时间开始
                if (!String.IsNullOrEmpty(input.EndDate))
                {
                    sql.Append(" and o.create_date<=CDate(:EndDate) ");
                    DbParameter EndDatePara = this.DbFacade.CreateParameter();
                    EndDatePara.ParameterName = "EndDate";
                    EndDatePara.DbType = DbType.String;
                    EndDatePara.Value = ComUtil.formatDate(input.EndDate);
                    parameters.Add(EndDatePara);
                }

                ////查询条件:发送时间结束
                //if (!String.IsNullOrEmpty(input.EndDate))
                //{
                //    sql.Append(" and o.create_date<=CDate(':endDate') ");
                //    //sql.Append(" and o.create_date<=to_date(:endDate,'yyyy-mm-dd hh24:mi:ss') ");
                //    //sql.Append(input.EndDate);
                //    //sql.Append("','yyyy-mm-dd hh24:mi:ss') ");
                //    DbParameter endDatePara = this.DbFacade.CreateParameter();
                //    endDatePara.ParameterName = "endDate";
                //    endDatePara.DbType = DbType.String;
                //    endDatePara.Value = ComUtil.formatDate(input.EndDate);
                //    parameters.Add(endDatePara);

                //}

                //查询条件:创建人
                if (!String.IsNullOrEmpty(input.Creater))
                {
                    sql.Append(" and UCase(o.create_username) like :creater");
                    DbParameter createrPara = this.DbFacade.CreateParameter();
                    createrPara.ParameterName = "creater";
                    createrPara.DbType = DbType.String;
                    createrPara.Value = ComUtil.GetLike(input.Creater.ToUpper());
                    parameters.Add(createrPara);

                }

                //查询条件：1卖方企业或2订单号
                if ("1".Equals(input.SearchField))
                {
                    if (!String.IsNullOrEmpty(input.SearchKey))
                    {
                        sql.Append("   and UCase(o.SALER_NAME & o.SALER_EASY & o.SALER_FAST & o.SALER_WUBI) like :org ");
                        DbParameter orgPara = this.DbFacade.CreateParameter();
                        orgPara.ParameterName = "org";
                        orgPara.DbType = DbType.String;
                        orgPara.Value = ComUtil.GetLike(input.SearchKey.ToUpper());
                        parameters.Add(orgPara);
                    }
                }
                if ("2".Equals(input.SearchField))
                {
                    if (!String.IsNullOrEmpty(input.SearchKey))
                    {
                        sql.Append(" and UCase(o.order_code) like :code ");
                        DbParameter codePara = this.DbFacade.CreateParameter();
                        codePara.ParameterName = "code";
                        codePara.DbType = DbType.String;
                        codePara.Value = ComUtil.GetLike(input.SearchKey.ToUpper());
                        parameters.Add(codePara);
                    }
                }
                sql.Append(" Group by o.saler_id");
                sql.Append(" ) a,(Select Distinct b.org_id,b.Org_Name,b.Org_Easy From cont_org b) b");
                sql.Append(" Where a.Saler_Id=b.Org_id");

                input.Rows = base.GetRowCount(sql.ToString(), parameters.ToArray());
                rows = input.Rows;

                //DbParameter highIndexPara = DbFacade.CreateParameter();
                //highIndexPara.ParameterName = "highRowNum";
                //highIndexPara.DbType = DbType.Int32;
                //highIndexPara.Value = input.End;
                //parameters.Add(highIndexPara);

                //DbParameter lowIndexPara = DbFacade.CreateParameter();
                //lowIndexPara.ParameterName = "lowRowNum";
                //lowIndexPara.DbType = DbType.Int32;
                //lowIndexPara.Value = input.Start;
                //parameters.Add(lowIndexPara);

                DataTable tb = base.DbFacade.SQLExecuteDataTable(sql.ToString(), parameters.ToArray());

                ds.Tables.Add(tb);
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }




    }
}
