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
    class OrderTempOfflineDao : SqlDAOBase
    {
        private OrderTempOfflineDao()
            : base()
        { }

        private OrderTempOfflineDao(string connectionName)
            : base(connectionName)
        { }

        public static OrderTempOfflineDao GetInstance()
        {
            return new OrderTempOfflineDao();
        }

        public static OrderTempOfflineDao GetInstance(string connectionName)
        {
            return new OrderTempOfflineDao(connectionName);
        }

        //已到货列表的检索
        public DataSet getArrivedList(UserInfo ui, string type, string id, BuyerOrderModel input)
        {
            StringBuilder sql = new StringBuilder();
            
            //sql.Append(" SELECT ");
            //sql.Append(" H.MEDICAL_NAME, ");		//--通用名
            //sql.Append(" H.TRADE_NAME, ");			//--商品名
            //sql.Append(" H.MEDICAL_WUBI, ");			//--商品名
            //sql.Append(" H.MEDICAL_PINYIN, ");			//--商品名
            //sql.Append(" H.SPELL_ABBR, ");			//--商品名
            //sql.Append(" H.NAME_WB, ");			//--商品名

            //sql.Append(" iif(h.Spec is null,'-',h.spec) & '×' &  iif(h.Stand_Rate Is Null, '-',h.Stand_Rate) & iif(h.Use_Unit Is Null, '',h.Use_Unit) & '/' & iif(h.Spec_Unit Is Null, '',h.Spec_Unit) & Switch(h.Wrap_Name Is Null, '', h.Wrap_Name='空', '',True,'(' & h.Wrap_Name & ')') As Ggbz,");//规格包装
            //sql.Append(" H.DOSEAGE_FORM, ");
            //sql.Append(" Switch(h.Province_Max_Price Is Null,'-',True,Trim(Format(h.Province_Max_Price, 'Standard'))) As Province_Max_Price,");
            //sql.Append(" Switch(h.Province_Insurance_Flag='0','非国家基本医疗保险产品',h.Province_Insurance_Flag='1', '甲类', h.Province_Insurance_Flag='2', '乙类', h.Province_Insurance_Flag='3', '民族药') As Province_Insurance_Flag,");
            //sql.Append(" H.DEALER_FULLNAME, ");		//--经销企业
            //sql.Append(" L.NAME, ");				//--合同名称
            //sql.Append(" H.LAST_ORDER_DATE, ");		//--最后制单日期
            //sql.Append(" CInt(H.LAST_ORDER_QTY) as LAST_ORDER_QTY, ");		//--最后制单数量
            //sql.Append(" Switch(Oi.Con_Type='1', '招标', Oi.Con_Type='2', '竞价', Oi.Con_Type='3', '询价', Oi.Con_Type='4', '备案', Oi.Con_Type='7', '浏览', Oi.Con_Type='9', '临时', Oi.Con_Type='c','GPO直销', Oi.Con_Type='d', 'GPO自主合同') as Con_Type,");//--合同类型
            //sql.Append(" format(OI.UNIT_PRICE,'Standard') As UNIT_PRICE, ");//单价
            //sql.Append(" CInt(OI.REQUEST_QTY) as REQUEST_QTY, ");		//--定购量
            //sql.Append(" '完成' AS STATUS, ");		//--状态
            //sql.Append(" iif(REC.LOT_NO is null,'-',REC.LOT_NO) AS LOT_NO, ");			//--批号
            //sql.Append(" CInt(REC.RECEIVE_QTY) as RECEIVE_QTY, ");		//--确认到货量
            //sql.Append(" OI.REMARK, ");				//--备注
            //sql.Append(" OI.BUYER_DESC, ");         //--买方备注
            //sql.Append(" REC.RECEIVE_REMARK, ");	//--到货接收备注
            //sql.Append(" REC.INVOICE_NO, ");		//--发票号
            //sql.Append(" REC.AMOUNT, ");			//--发票金额
            //sql.Append(" format(REC.TRADE_PRICE,'Standard') As TRADE_PRICE,");//--批发价
            //sql.Append(" format(REC.RETAIL_PRICE,'Standard') As RETAIL_PRICE,");//--零售价
            //sql.Append(" REC.DISCOUNT, ");			//--扣率
            //sql.Append(" format(REC.INVOICE_DATE,'yyyy-mm-dd') As INVOICE_DATE,");//--开票日期
            //sql.Append(" format(REC.INVOICE_EXPIRE_DATE,'yyyy-mm-dd') As INVOICE_EXPIRE_DATE ");//--有效期		

          
            //sql.Append(" FROM GPO_ORDER_RECEIVE REC, GPO_ORDER_ITEM OI, GPO_HIT_COMM H ,CONT_LIST L ");
            //sql.Append(" WHERE REC.ORDER_ITEM_ID = OI.RECORD_ID ");
            //sql.Append(" AND OI.HIT_COMM_ID = H.RECORD_ID ");
            //sql.Append(" AND H.CONTRACT_ID = L.ID ");
            //sql.Append(" AND REC.ORDER_ID = :ID");

            

            sql.Append(" SELECT  h.id as Product_Id,h.MANU_NAME,h.MANU_NAME_ABBR, h.COMMERCE_NAME as ");
            sql.Append(" Trade_Name,h.product_name ,h.CODE, h.common_name,h.ABBR_PY,h.ABBR_WB,");
            sql.Append(" OI.model,(case when OI.Spec is null then '-' else OI.spec end) as Spec ,");
            sql.Append(" oi.Id, oi.Order_Id, ");
            sql.Append(" (case when oi.trade_Price Is Null then '-' else oi.trade_Price end) As ");
            sql.Append(" trade_Price,oi.sender_Name,oi.sender_Name_Abbr,");
            sql.Append(" (case oi.STATE when '1' then '发送' when  '2' then '已阅读' when '3' then '作废' when '4' then '已确认' when '5' then '完成' end) As status, ");
            sql.Append("  (case when oi.RETAIL_PRICE Is Null then '-' else oi.RETAIL_PRICE end) ");
            sql.Append(" As RETAIL_PRICE,oi.SUM AS total,");
            sql.Append(" cast(oi.AMOUNT as int) As Request_Qty, oi.SALER_DESCRIPTIONS as Saler_Desc,");
            sql.Append(" oi.BUYER_DESCRIPTIONS as Buyer_Desc, '已送货' As Status,");
            sql.Append(" cast(oi.OVER_AMOUNT as int) as OVER_AMOUNT,");
            sql.Append(" cast(oi.OVER_SUM as int) as OVER_SUM,(case when oi.Send_measure is null then '-' else oi.Send_measure end ) as Send_measure,");
            sql.Append(" (case when REC.INSTORE_BATCH_NO is null then '-' else REC.INSTORE_BATCH_NO end) ");
            sql.Append(" AS LOT_NO,  ");
            sql.Append(" cast(REC.FACT_AMOUNT as int) as RECEIVE_QTY,  ");
            sql.Append(" REC.DESCRIPTIONS,  ");
            sql.Append(" REC.INVOICE_ID, ");
            sql.Append(" REC.PRICE As TRADE_PRICE");
            sql.Append(" FROM HC_ORD_ORDER_RECEIVE REC, HC_ORD_ORDER_ITEM OI, HC_ORD_PRODUCT H   ");
            sql.Append(" WHERE REC.ORDER_ITEM_ID = OI.ID  AND OI.PROJECT_PROD_ID = H.ID  ");
            sql.Append(" AND REC.ORDER_ID = @ID  and OI.state <> '3'");
         

            List<DbParameter> parameters = new List<DbParameter>();

            DbParameter idPara = DbFacade.CreateParameter();
            idPara.ParameterName = "ID";
            idPara.DbType = DbType.String;
            idPara.Value = id;
            parameters.Add(idPara);

        
            DataSet ds = new DataSet();
           
            DataTable newsTable = DbFacade.SQLExecuteDataTable(sql.ToString(), "ARRIVESALER", idPara);
            ds.Tables.Add(newsTable);
        
          

            return ds;
        }


    }
}
