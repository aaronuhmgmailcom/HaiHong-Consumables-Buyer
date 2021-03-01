//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	OutOrderReceiveDao.cs      
//	创 建 人:	罗澜涛
//	创建日期:	2007-5-15
//	功能描述:	到货信息导出
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using Emedchina.Commons;
using Emedchina.Commons.Data;
using System.Data.Common;
using Emedchina.TradeAsst.EmedHisCommonLibrary;
using System.Collections;
using Emedchina.TradeAssistant.Model.Order.ApplyerProcess;
using DevExpress.XtraEditors;


namespace Emedchina.TradeAssistant.Client.DAL.Query
{
    public class OutOrderReceiveDao : SqlDAOBase
    {
        private Config _Config;

        private OutOrderReceiveDao()
            : base()
        { }

        private OutOrderReceiveDao(string connectionName)
            : base(connectionName)
        { }

        public static OutOrderReceiveDao GetInstance()
        {
            return new OutOrderReceiveDao();
        }

        public static OutOrderReceiveDao GetInstance(string connectionName)
        {
            return new OutOrderReceiveDao(connectionName);
        }

        #region 导出到Excel文件中
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="inDestFilePath">目标文件路径</param>
        /// <param name="inDataTable">导出数据集</param>
        /// <returns></returns>
        public bool ExportReceive(string inDestFilePath, DataTable inDataTable)
        {
            bool flag = true;

            Config.Intance().InitCfgData(EmedFunc.GetLocalPersonCfgPath() + @"\HisOrderReceive.xml");
            this._Config = Config.Intance();
            XmlElement element1 = (XmlElement)this._Config.EleDestination.SelectSingleNode("DestTable");
            //获前当前程序路径
            string AppPath = EmedFunc.GetLocalPersonCfgPath();// AppDomain.CurrentDomain.BaseDirectory;
            //获取当前导出数据类型对象
            string DbType = this._Config.EleDestination.GetAttribute("DBType").ToString().Trim();


            switch (DbType)
            {
                case "EXCEL":
                    if (!inDestFilePath.ToString().Contains("xls"))
                    {
                        
                        XtraMessageBox.Show("请选择有效的EXCEL文件(*.xls)！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!this.CopyStandardTempFile(AppPath + @"\SendReceiveBak.xls", inDestFilePath, DbType))
                    {
                        XtraMessageBox.Show("导出到货SendReceiveBak.xls模板复制失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    flag = OrdReceiveExcelDao.ExportReceive(inDataTable, inDestFilePath);

                    break;
                default:
                    break;
            }

            return flag;
        }
        /// <summary>
        /// 拷贝模板文件
        /// </summary>
        /// <param name="inSourceFilePath">源文件路径</param>
        /// <param name="inDesFilePath">目标文件路径</param>
        /// <returns></returns>
        public bool CopyStandardTempFile(string inSourceFilePath, string inDesFilePath, string DbType)
        {
            bool flag = true; ;
            try
            {
                if (File.Exists(inSourceFilePath))
                {
                    if (File.Exists(inDesFilePath))
                    {
                        File.Delete(inDesFilePath);
                    }
                    File.Copy(inSourceFilePath, inDesFilePath, true);
                    File.SetAttributes(inDesFilePath, FileAttributes.Normal);
                    return true;
                }

                switch (DbType)
                {
                    case "EXCEL":
                        XtraMessageBox.Show("导出到货模板EXCEL文件不存在，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        flag = false;
                        break;
                    case "TXT":
                        XtraMessageBox.Show("导出到货模板TXT文件不存在，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        flag = false;
                        break;
                    case "FOXPRO":
                        XtraMessageBox.Show("导出到货模板FOXPRO文件不存在，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        flag = false;
                        break;
                    default:

                        break;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("复制导出到货模板文件到指定目录出错！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            }
            return flag;
        }

        #endregion

        #region 获取到货信息
        /// <summary>
        /// 获取到货信息
        /// </summary>
        /// <param name="ui">用户对象</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public DataTable GetOrderReceive(UserInfo user, string startDate, string endDate, string medicalName, string salerName)
        {
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();

            sql.Append("Select '1' AS TYPE,gp.CODE As PURCHASE_CODE,rec.id,oi.TRADE_PRICE As num_unit_price,");
            sql.Append("rec.PROJECT_PRODUCT_ID as product_id,");                      //产品ID
            sql.Append(" oi.SPEC_ID,");
            sql.Append(" oi.MODEL_ID,");
            sql.Append(" oi.SPEC,");
            sql.Append(" oi.MODEL,");

            sql.Append("o.Order_Code,");                        //订单编号
            sql.Append("p.COMMON_NAME As cpmc2,");     //通用名
            sql.Append("oi.PRODUCT_NAME As product_name,");      //商品名
            sql.Append("oi.SENDER_ID,");                        //卖方ID

          
            sql.Append("oi.MANUFACTURE_NAME_ABBR As producer_shortname,");    //生产企业简称
            //sql.Append("hit.producer_fullname As producer_fullname,");      //生产企业全称
            //sql.Append("hit.dealer_shortname As dealer_shortname,");        //经销企业简称
            //sql.Append("hit.dealer_fullname As dealer_fullname,");          //经销企业全称

            //sql.Append("o.bak_buyer_easy As buyer_shortname,");             //买方企业简称
            //sql.Append("o.bak_buyer_name As buyer_fullname,");              //买方企业全称
            sql.Append("oi.SENDER_NAME As seller_name,");
            sql.Append("oi.SENDER_NAME_ABBR As seller_shortname,");                //卖方企业简称
            //sql.Append("o.saler_name As seller_fullname,");                 //卖方企业全称

            sql.Append(" oi.TRADE_PRICE As Unit_Price,"); //单价
            sql.Append("rec.FACT_AMOUNT AS receive_qty,");                  //到货数量

            //sql.Append("oi.request_qty AS request_qty,");                   //订购数量
            sql.Append("(case when rec.FACT_SUM is null then '-' else rec.FACT_SUM end) As rec_amount,");//到货金额
            //sql.Append("Format(iif(hit.temp_price Is Null,hit.province_max_price,hit.temp_price),'Standard') As retail_price,");//零售价

            //sql.Append("rec.receive_date As receive_date,");                //到货时间
            sql.Append("convert(varchar(10),ARRIVE_DATE,120)  As receive_date_short,");//到货时间

            //sql.Append("rec.invoice_no AS invoice_no,");                    //发票号

            sql.Append("rec.INSTORE_BATCH_NO AS lot_no,");                            //批号
            //sql.Append("rec.retail_price AS invoice_retail_price,");        //零售价
            //sql.Append("rec.discount AS invoice_discount,");                //扣率
            //sql.Append("rec.invoice_date AS invoice_date,");                //开票日期
            //sql.Append("format(rec.invoice_date, 'yyyy-mm-dd') As invoice_date_short,");//开票日期
            //sql.Append("rec.invoice_expire_date AS invoice_expire_date,");  //发票有效期
            //sql.Append("rec.RECEIVE_REMARK AS receive_remark, ");            //到货接收备注

            sql.Append("'0' As zbj,");                                       //中标价
            sql.Append("oi.trade_price As gjj,");                          //批发价
            sql.Append("(case when oi.retail_price is null then '-' else oi.retail_price end) As lsj,");                         //零售价
            sql.Append("oi.AMOUNT AS gmsl,");                         //购买数量

            sql.Append(" convert(varchar(10),ARRIVE_DATE,120)  As receive_date,");  //到货时间
            //sql.Append("rec.invoice_no AS fphm,");                          //发票号码
            //sql.Append("rec.invoice_total As fpzje,");                      //发票总金额
            //sql.Append("iif(rec.amount is null,'-',rec.amount) As fpje,");                              //发票金额
            //sql.Append("iif(rec.invoice_date is null,'-',rec.invoice_date) AS fprq,");                        //开票日期
            sql.Append("rec.FACT_AMOUNT AS dhsl,");                         //到货数量
            sql.Append("rec.INSTORE_BATCH_NO as ypph,");                               //产品批号
            //sql.Append("rec.invoice_expire_date as ypxq,");                   //产品效期
            sql.Append("rec.DESCRIPTIONS as dhbz,");                        //到货备注
            sql.Append("rec.ID as hhdhid ");                                  //海虹到货ID

            sql.Append("From HC_ORD_ORDER_RECEIVE rec, HC_ORD_ORDER o, HC_ORD_ORDER_ITEM oi, HC_ORD_PRODUCT p,HC_ORD_PURCHASE gp ");
            sql.Append("Where o.id = oi.order_id ");
            sql.Append("AND oi.PROJECT_PROD_ID = p.id ");
            sql.Append("AND rec.order_id = oi.order_id ");
            sql.Append("AND rec.order_item_id = oi.id ");
            sql.Append("AND gp.Id=o.PURCHASE_ID");

       
            //sql.AppendFormat(" AND o.BUYER_ORGID='{0}'", user.OrgId);

            //if (!string.IsNullOrEmpty(startDate))
            //{
            //    sql.AppendFormat(" AND FORMAT(rec.RECEIVE_DATE,'YYYY/MM/DD')>='{0}'", startDate);
            //}
            //if (!string.IsNullOrEmpty(endDate))
            //{
            //    sql.AppendFormat(" AND FORMAT(rec.RECEIVE_DATE,'YYYY/MM/DD')<='{0}'", endDate);
            //}

            if (!string.IsNullOrEmpty(startDate))
            {
                sql.AppendFormat(" AND rec.ARRIVE_DATE >= '{0}'", startDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(endDate))
            {
                sql.AppendFormat(" AND rec.ARRIVE_DATE <= '{0}'", endDate + " 23:59:59");
            }


            //品名
            if (!string.IsNullOrEmpty(medicalName))
            {
                sql.AppendFormat(" AND (p.PRODUCT_NAME Like '%{0}%' or p.COMMERCE_NAME Like '%{0}%' or p.COMMON_NAME Like '%{0}%' or p.CODE Like '%{0}%' or p.ABBR_PY Like '%{0}%' or p.ABBR_WB Like '%{0}%') ", medicalName);
            }

            //卖方企业
            if (!string.IsNullOrEmpty(salerName))
            {
                sql.AppendFormat(" AND (oi.SALER_NAME Like '%{0}%' or  oi.SALER_NAME_ABBR Like '%{0}%')", salerName);
            }

           

          

       
            try
            {
                DataTable dttemp = DbFacade.SQLExecuteDataTable(sql.ToString());

                dt = SetOrderReceiveDT(user, dttemp);
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }
     
        public DataTable GetOrderReceive(UserInfo user)
        {
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();

            sql.Append("Select '1' AS TYPE,gp.CODE As PURCHASE_CODE,rec.id,oi.TRADE_PRICE As num_unit_price,");
            sql.Append("rec.PROJECT_PRODUCT_ID as product_id,");                      //产品ID
            sql.Append(" oi.SPEC_ID,");
            sql.Append(" oi.MODEL_ID,");
            sql.Append(" oi.SPEC,");
            sql.Append(" oi.MODEL,");
            sql.Append("o.Order_Code,");                        //订单编号
            sql.Append("p.COMMON_NAME As cpmc2,");     //通用名
            sql.Append("oi.PRODUCT_NAME As product_name,");      //商品名
            sql.Append("oi.SENDER_ID,");                        //卖方ID
            sql.Append("oi.MANUFACTURE_NAME_ABBR As producer_shortname,");    //生产企业简称
            sql.Append("oi.SENDER_NAME As seller_name,");
            sql.Append("oi.SENDER_NAME_ABBR As seller_shortname,");                //卖方企业简称
            sql.Append(" oi.TRADE_PRICE As Unit_Price,"); //单价
            sql.Append("rec.FACT_AMOUNT AS receive_qty,");                  //到货数量
            sql.Append("(case when rec.FACT_SUM is null then '-' else rec.FACT_SUM end) As rec_amount,");//到货金额
            sql.Append(" ARRIVE_DATE  As receive_date_short,");//到货时间
            sql.Append("rec.INSTORE_BATCH_NO AS lot_no,");                            //批号
            sql.Append("'0' As zbj,");                                       //中标价
            sql.Append("oi.trade_price As gjj,");                          //批发价
            sql.Append("(case when oi.retail_price is null then '-' else oi.retail_price end) As lsj,");                         //零售价
            sql.Append("oi.AMOUNT AS gmsl,");                         //购买数量
            sql.Append(" convert(varchar(10),ARRIVE_DATE,120)  As receive_date,");  //到货时间
            sql.Append("rec.FACT_AMOUNT AS dhsl,");                         //到货数量
            sql.Append("rec.INSTORE_BATCH_NO as ypph,");                               //产品批号
            sql.Append("rec.DESCRIPTIONS as dhbz,");                        //到货备注
            sql.Append("rec.ID as hhdhid ");                                  //海虹到货ID

            sql.Append("From HC_ORD_ORDER_RECEIVE rec, HC_ORD_ORDER o, HC_ORD_ORDER_ITEM oi, HC_ORD_PRODUCT p,HC_ORD_PURCHASE gp ");
            sql.Append("Where o.id = oi.order_id ");
            sql.Append("AND oi.PROJECT_PROD_ID = p.id ");
            sql.Append("AND rec.order_id = oi.order_id ");
            sql.Append("AND rec.order_item_id = oi.id ");
            sql.Append("AND gp.Id=o.PURCHASE_ID");

            try
            {
                DataTable dttemp = DbFacade.SQLExecuteDataTable(sql.ToString());

                dt = SetOrderReceiveDT(user, dttemp);
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return dt;
        }



        public DataTable SetOrderReceiveDT(UserInfo user, DataTable dt)
        {
            dt.Columns.Add("product_code");
            dt.Columns.Add("common_name");
            dt.Columns.Add("cpmc");
            dt.Columns.Add("mode_name");
            dt.Columns.Add("medicalspec");
            dt.Columns.Add("BASE_MEASURE");
            dt.Columns.Add("BASEMEASURESPEC");
            dt.Columns.Add("stand_rate");
            dt.Columns.Add("factory_code");
            dt.Columns.Add("factory_name");
            dt.Columns.Add("stock_id");
            dt.Columns.Add("stock_name");

            dt.Columns.Add("psqybm");
            dt.Columns.Add("psqymc");

            StringBuilder sql = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                string product_id = Convert.ToString(dr["product_id"]);
                string spec_id = Convert.ToString(dr["SPEC_ID"]);
                string model_id = Convert.ToString(dr["MODEL_ID"]);

                string Saler_ID = Convert.ToString(dr["SENDER_ID"]);

                GpoOutReceiveModel OutReceiveModel1 = GetCorp_MapByProductID(user, Saler_ID);

                if (OutReceiveModel1 != null)
                {
                    dr["psqybm"] = OutReceiveModel1.Psqybm;
                    dr["psqymc"] = OutReceiveModel1.Psqymc;
                }

                GpoOutReceiveModel OutReceiveModel2 = GetProductMapByProductID(user, product_id,spec_id,model_id);

                if (OutReceiveModel2 != null)
                {
                    dr["product_code"] = OutReceiveModel2.Ypbm;
                    dr["common_name"] = OutReceiveModel2.Ypmc;
                    dr["cpmc"] = OutReceiveModel2.Cpmc;
                    dr["mode_name"] = OutReceiveModel2.Jxmc;
                    dr["medicalspec"] = OutReceiveModel2.Ggmc;
                    dr["BASE_MEASURE"] = OutReceiveModel2.Bzdw;
                    dr["BASEMEASURESPEC"] = OutReceiveModel2.Zxsydw;
                    dr["stand_rate"] = OutReceiveModel2.Zhb;
                    dr["factory_code"] = OutReceiveModel2.Scqybm;
                    dr["factory_name"] = OutReceiveModel2.Scqymc;
                    dr["stock_id"] = OutReceiveModel2.Ykbm;
                    dr["stock_name"] = OutReceiveModel2.Ykmc;
                }

            }

            return dt;

        }

        /// <summary>
        /// 获取对接产品对照信息
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private GpoOutReceiveModel GetProductMapByProductID(UserInfo user, string ProductID,string specid,string modelid)
        {
            GpoOutReceiveModel Model = new GpoOutReceiveModel();
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();

            sql.Append("Select");
            sql.Append(" p.HIS_PRODUCT_ID as product_code,");
            sql.Append(" p.common_name as common_name,");
            sql.Append(" p.product_name as product_name,");
            sql.Append(" p.mode_name as mode_name,");
            sql.Append(" p.spec as medicalspec,");
            sql.Append(" p.BASE_MEASURE as BASE_MEASURE,");
            sql.Append(" p.BASE_MEASURE_SPEC as BASEMEASURESPEC,");
            sql.Append(" (case when p.stand_rate Is Null then '0' else p.stand_rate end) as stand_rate,");
            sql.Append(" (case when p.factory_code Is Null then ' ' else p.factory_code end) as factory_code,");
            sql.Append(" p.factory_name as factory_name,");
            sql.Append(" p.stock_id as stock_id,");
            sql.Append(" p.stock_name as stock_name");
            sql.Append(" From HC_PRODUCT_MAP p ");

            string sql1 = string.Format(" Where PROJECT_PROD_ID = {0}  And hh_SPEC_ID = {1} And hh_MODE_ID = {2}", ProductID, specid, modelid);

            //string sql2 = string.Format(",GPO_REG_PRODUCT_PUBLIC grpp Where p.DATA_PRODUCT_ID = grpp.DATA_PRODUCT_ID and  grpp.ID = '{0}' And p.MAP_ORGID = '{1}' ", ProductID, user.OrgId);

            try
            {
                dt = DbFacade.SQLExecuteDataTable(sql + sql1.ToString());

                //if (dt == null || dt.Rows.Count == 0)
                //{
                //    dt = DbFacade.SQLExecuteDataTable(sql + sql2.ToString());
                //}

                if (dt != null && dt.Rows.Count > 0)
                {
                    Model = GetGpoProductMapModelByRow(dt.Rows[0]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return Model;
        }

        /// <summary>
        /// 获取对接产品对照表实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected GpoOutReceiveModel GetGpoProductMapModelByRow(DataRow row)
        {
            GpoOutReceiveModel Model = new GpoOutReceiveModel();
            if (row == null)
            { return null; }

            Model.Ypbm = ComUtil.getStringValue(row, "product_code", "");
            Model.Ypmc = ComUtil.getStringValue(row, "common_name", "");
            Model.Cpmc = ComUtil.getStringValue(row, "product_name", "");
            Model.Jxmc = ComUtil.getStringValue(row, "mode_name", "");
            Model.Ggmc = ComUtil.getStringValue(row, "medicalspec", "");
            Model.Bzdw = ComUtil.getStringValue(row, "BASE_MEASURE", "");
            Model.Zxsydw = ComUtil.getStringValue(row, "BASEMEASURESPEC", "");
            Model.Zhb = ComUtil.getStringValue(row, "stand_rate", "");
            Model.Scqybm = ComUtil.getStringValue(row, "factory_code", "");
            Model.Scqymc = ComUtil.getStringValue(row, "factory_name", "");
            Model.Ykbm = ComUtil.getStringValue(row, "stock_id", "");
            Model.Ykmc = ComUtil.getStringValue(row, "stock_name", "");

            return Model;

        }

        /// <summary>
        /// 对接企业对照表信息
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private GpoOutReceiveModel GetCorp_MapByProductID(UserInfo user, string SalerID)
        {
            GpoOutReceiveModel Model = new GpoOutReceiveModel();
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();

            sql.Append("Select");
            sql.Append(" c.HIS_ORG_ID as psqybm,");
            sql.Append(" c.EASY_NAME as psqymc");

            sql.Append(" From HC_CORP_MAP c ");

            string sql1 = string.Format(" Where c.ORG_ID = '{0}'", SalerID);

            //string sql2 = string.Format(",GPO_REG_BUYER grb Where c.DATA_ORG_ID = grb.DATA_BUYER_ID and  grb.ID = '{0}'", SalerID);

            try
            {
                dt = DbFacade.SQLExecuteDataTable((sql + sql1).ToString());

                //if (dt == null || dt.Rows.Count == 0)
                //{
                //    dt = DbFacade.SQLExecuteDataTable((sql + sql2).ToString());
                //}

                if (dt != null && dt.Rows.Count > 0)
                {
                    Model = GetGpoCorp_MapModelByRow(dt.Rows[0]);
                }

            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }

            return Model;
        }

        /// <summary>
        /// 获取对接产品对照表实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected GpoOutReceiveModel GetGpoCorp_MapModelByRow(DataRow row)
        {
            GpoOutReceiveModel Model = new GpoOutReceiveModel();
            if (row == null)
            { return null; }

            Model.Psqybm = ComUtil.getStringValue(row, "psqybm", "");
            Model.Psqymc = ComUtil.getStringValue(row, "psqymc", "");

            return Model;
        }

        #endregion


        #region 更新到货表导出标志位
        /// <summary>
        /// 更新到货表导出标志位
        /// </summary>
        /// <returns></returns>
        public bool UpdateOrderReceive(string receiveIdstr, string receiveHisIdstr)
        {
            if (!string.IsNullOrEmpty(receiveIdstr))
            {
                receiveIdstr.Remove(receiveIdstr.Length - 1);
            }

            if (!string.IsNullOrEmpty(receiveHisIdstr))
            {
                receiveHisIdstr.Remove(receiveHisIdstr.Length - 1);
            }

            string sql = "UPDATE GPO_ORDER_RECEIVE SET OUT_FLAG = '1' WHERE ID IN (" + receiveIdstr + ")";
            string sqlHis = "UPDATE GPO_ORDER_RECEIVE_HIS SET OUT_FLAG = '1' WHERE ID IN (" + receiveHisIdstr + ")";
            bool flg = false;

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    int result = 0;
                    if (!string.IsNullOrEmpty(receiveIdstr))
                    {
                        result = base.DbFacade.SQLExecuteNonQuery(sql, transaction);
                    }
                    if (!string.IsNullOrEmpty(receiveHisIdstr))
                    {
                        result = result + base.DbFacade.SQLExecuteNonQuery(sqlHis, transaction);
                    }
                    if (result > 0)
                    {
                        flg = true;
                    }
                    else
                    {
                        flg = false;
                        base.DbFacade.RollbackTransaction(transaction);
                    }

                    base.DbFacade.CommitTransaction(transaction);
                }
                catch (DbException e)
                {
                    base.DbFacade.RollbackTransaction(transaction);

                }
            }
            return flg;

        }
        #endregion

        /// <summary>
        /// 废弃
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable SetOrderReceiveDTColoum(DataTable dt)
        {
            Config.Intance().InitCfgData(EmedFunc.GetLocalPersonCfgPath() + @"\HisOrderReceive.xml");
            Config config = Config.Intance();
            DataTable outTable = new DataTable();
            outTable = dt.Copy();
            bool Ifhas = false;
            ArrayList al = new ArrayList();
            foreach (DataColumn dc in outTable.Columns)
            {
                XmlElement element1 = config.EleContrast;
                XmlElement element2 = (XmlElement)config.EleDestination.SelectSingleNode("DestTable");
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    string text1 = element1.ChildNodes[num1].Attributes["SourceField"].Value.Trim().ToLower();
                    string text2 = element1.ChildNodes[num1].Attributes["DestField"].Value.Trim().ToLower();

                    if (text1.ToLower() == dc.Caption.ToLower())
                    {
                        dc.ColumnName = text2;
                        Ifhas = true;
                    }
                }
                if (Ifhas == false)
                {
                    al.Add(dc);
                }
                Ifhas = false;
            }

            for (int i = 0; i < al.Count; i++)
            {
                outTable.Columns.Remove((DataColumn)al[i]);
            }
            //修改DataTable列的顺序
            //DataTable dtout = changeOrder(outTable, config);
            return outTable;
        }

        /// <summary>
        /// 修改DataTable列的顺序(废弃)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        //private DataTable changeOrder(DataTable dt, Config config)
        //{
        //DataTable dtChanged = new DataTable();
        //dtChanged=dt.Copy();
        //int count=dtChanged.Columns.Count;
        //for (int i = 1; i < count; i++)
        //{
        //    dtChanged.Columns.RemoveAt(1);
        //}

        //XmlElement element1 = config.EleContrast;
        //for (int num1 = 1; num1 < element1.ChildNodes.Count; num1++)
        //{
        //    string text2 = element1.ChildNodes[num1].Attributes["DestField"].Value.Trim().ToLower();
        //    dtChanged.Columns.Add(text2);
        //    foreach (DataRow dr in dtChanged.Rows)
        //    {
        //        for(int i=0;i<dt.Rows.Count;i++)
        //        {
        //            dr[text2]=dt.Columns[
        //        }
        //    }
        //}

        //return dtChanged;
        //}


    }
}
