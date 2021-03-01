using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Xml;

using Emedchina.Commons.Data;
using Emedchina.Commons.Util;

using Emedchina.TradeAssistant.DAL.Sync.UploadCheck;
using Emedchina.Commons;

namespace Emedchina.TradeAssistant.DAL.Sync
{
    public class UploadDAO : OracleDAOBase
    {
        private UploadDAO()
            : base()
        { }

        private UploadDAO(string connectionName)
            : base(connectionName)
        { }

        public static UploadDAO GetInstance()
        {
            return new UploadDAO();
        }

        public static UploadDAO GetInstance(string connectionName)
        {
            return new UploadDAO(connectionName);
        }

        //#region 数据上传方法
        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="Upds">       待修改的数据</param>
        /// <param name="delTable"> 需删除的数据</param>
        /// <returns>               返回上传BOOL类型</returns>
        public bool UploadData(DataSet Upds, DataTable delTable, out List<string> InvalidList)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    List<string> InvalidListTemp = new List<string>();
                    foreach (DataTable dt in Upds.Tables)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            //进行单表更新
                            UploadTable(dt, transaction, out InvalidListTemp);
                        }
                    }
                    foreach (DataRow dr in delTable.Rows)
                    {
                        string strInvalid = "";
                        if (CheckDeleteData(dr, transaction, out strInvalid))
                        {
                            deleteData(dr, transaction);
                        }
                        if (!string.IsNullOrEmpty(strInvalid))
                        {
                            InvalidListTemp.Add(strInvalid);
                        }
                    }
                    base.DbFacade.CommitTransaction(transaction);
                    InvalidList = InvalidListTemp;
                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }

            ////通过订单明细校验订单
            //foreach (DataRow dr in Upds.Tables["GPO_ORDER"].Rows)
            //{
            //    OrderCheck.GetInstance().CheckOrderFromItem(dr["order_id"].ToString(), dr["purchase_id"].ToString());
            //}

            return true;
        }
        /// <summary>
        /// 单表更新
        /// </summary>
        /// <param name="dt">单表数据</param>
        /// <param name="tran">事务</param>
        public void UploadTable(DataTable dt, DbTransaction tran, out List<string> InvalidList)
        {
            try
            {
                string tableName = dt.TableName;
                string pk = dt.PrimaryKey[0].ColumnName;
                int pkIndex = dt.PrimaryKey[0].Ordinal;
                XmlNode node = UtilXml.GetNodeObject("Sync.xml", "sync/upload/" + tableName.ToUpper() + "/operator");
                string insertFlag = UtilXml.GetNodeValue(node, "insert");
                string updateFlag = UtilXml.GetNodeValue(node, "update");
                string deleteFlag = UtilXml.GetNodeValue(node, "delete");
                string insertTimeCol = "";
                string insertTimeValue = "";
                string updateTimeValue = "";

                if (insertFlag.Equals("1"))
                {
                    insertTimeCol = UtilXml.GetNodeObject("Sync.xml", "sync/upload/" + tableName.ToUpper() + "/operator/insertTimeCol").InnerText;
                    insertTimeValue = UtilXml.GetNodeObject("Sync.xml", "sync/upload/" + tableName.ToUpper() + "/operator/insertTimeValue").InnerText;
                }
                if (updateFlag.Equals("1"))
                {
                    updateTimeValue = UtilXml.GetNodeObject("Sync.xml", "sync/upload/" + tableName.ToUpper() + "/operator/updateTimeCol").InnerText;
                }


                StringBuilder insertSql = new StringBuilder();
                StringBuilder insertValueSql = new StringBuilder();
                StringBuilder updateSql = new StringBuilder();
                insertSql.AppendFormat("insert into {0}(", dt.TableName);
                updateSql.AppendFormat("update {0} set ", dt.TableName);
                int i = 0;
                int j = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    insertSql.AppendFormat(" {0},", dc.ColumnName);
                    if (dc.DataType == typeof(DateTime))
                    {
                        insertValueSql.Append("to_date('{" + i.ToString() + "}','YYYY-MM-DD HH24:MI:SS'),");
                    }
                    else
                    {
                        insertValueSql.Append("'{" + i.ToString().Trim() + "}',");
                    }
                    if (dc.ColumnName != pk)
                    {
                        if (dc.DataType == typeof(DateTime))
                        {
                            updateSql.Append(dc.ColumnName + "=to_date('{" + j.ToString() + "}','YYYY-MM-DD HH24:MI:SS'),");
                        }
                        else
                        {
                            updateSql.Append(dc.ColumnName + "='{" + j.ToString().Trim() + "}',");
                        }
                        j++;
                    }
                    i++;
                }
                insertSql.Append(insertTimeCol + ")values(" + insertValueSql.ToString() + insertTimeValue + ")");
                updateSql.Append(updateTimeValue);
                List<string> InvalidListTemp = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    string strInvalid = "";
                    string id = dr[pk].ToString();
                    if (CheckExist(tableName, pk, id, tran))
                    {
                        //进行数据修改前校验
                        if ("1".Equals(updateFlag) && CheckUpdateData(dr, tran, out strInvalid))
                        {
                            UpdateData(dr, updateSql.ToString(), tran);
                        }
                    }
                    else
                    {
                        //进行数据插入前校验
                        if ("1".Equals(insertFlag) && CheckInsertData(dr, tran, out strInvalid))
                        {
                            InsertData(dr, insertSql.ToString(), tran);
                        }
                    }
                    if (!string.IsNullOrEmpty(strInvalid))
                    {
                        InvalidListTemp.Add(strInvalid);
                    }
                }
                InvalidList = InvalidListTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pk">主键名</param>
        /// <param name="id">主键值</param>
        /// <param name="tran">事务</param>
        /// <returns>存在：true;不存在:false</returns>
        private bool CheckExist(string tableName, string pk, string id, DbTransaction tran)
        {

            string sql = "select count(*) from " + tableName + " where " + pk + "=:id";
            DbParameter para = this.DbFacade.CreateParameter();

            para.ParameterName = "id";
            para.DbType = DbType.AnsiString;
            para.Value = id;

            object o = DbFacade.SQLExecuteScalar(sql, tran, para);
            if (o != null && !o.ToString().Equals("0"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="insertSql"></param>
        /// <param name="tran"></param>
        private void InsertData(DataRow dr, string insertSql, DbTransaction tran)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendFormat(insertSql, dr.ItemArray);
                DbFacade.SQLExecuteNonQuery(sql.ToString(), tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="updateSql"></param>
        /// <param name="tran"></param>
        private void UpdateData(DataRow dr, string updateSql, DbTransaction tran)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                object[] values = dr.ItemArray;
                //dr.ItemArray.CopyTo(values, 0);
                string id = "";
                List<string> valuesL = new List<string>();
                for (int i = 0; i < values.Length; i++)
                {
                    if (i != dr.Table.PrimaryKey[0].Ordinal)
                    {
                        valuesL.Add(values[i].ToString().Trim());
                    }
                    else
                    {
                        id = values[i].ToString().Trim();
                    }
                }
                sql.AppendFormat(updateSql, valuesL.ToArray());
                sql.AppendFormat(" where " + dr.Table.PrimaryKey[0].ColumnName + "='{0}'", id);
                DbFacade.SQLExecuteNonQuery(sql.ToString(), tran);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="tran"></param>
        private void deleteData(DataRow dr, DbTransaction tran)
        {
            string sql = "delete from " + dr["Table_Name"].ToString() + " where " + dr["PK_NAME"].ToString() + "='" + dr["Id"].ToString() + "'";
            SaveDelLog(dr["Table_Name"].ToString(), dr["Id"].ToString(), dr["CREATE_USERID"].ToString(), tran);
            DbFacade.SQLExecuteNonQuery(sql.ToString(), tran);
        }
        /// <summary>
        /// 保存采购单信息至LOG表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="tran"></param>
        private void SaveDelLog(string tableName, string id, string userId, DbTransaction tran)
        {
            //PurchaseDAO dao = new PurchaseDAO();
            //switch (tableName.ToUpper())
            //{
            //    case "ORD_PURCHASE_ITEM":
            //        dao.ordPurchaseItemLogSaveForDel(id, userId, tran);
            //        break;
            //    case "ORD_PURCHASE":
            //        dao.ordPurchaseLogSave(id, userId, tran);
            //        break;
            //    default:
            //        break;
            //}
        }

        /// <summary>
        /// 更新数据的判断
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        private bool CheckUpdateData(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            bool flag = true;
            strInvalid = "";
            switch (dr.Table.TableName.ToUpper())
            {
                case "HC_ORD_PURCHASE":        //采购单表
                    flag = PurchaseCheck.GetInstance().CheckPurchaseForUpdate(dr, out strInvalid);
                    break;
                case "HC_ORD_PURCHASE_ITEM":   //采购明细表

                    flag = PurchaseCheck.GetInstance().CheckPurchaseItemForUpdate(dr, out strInvalid);
                    break;
                case "HC_ORD_ORDER":           //订单表
                    flag = OrderCheck.GetInstance().CheckOrderForUpdate(dr, out strInvalid);
                    break;
                case "HC_ORD_ORDER_ITEM":      //订单明细表
                    flag = OrderCheck.GetInstance().CheckOrderItemForUpdate(dr, out strInvalid);
                    break;
                default:
                    break;
            }
            return flag;
        }
        /// <summary>
        /// 新增数据的判断
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        private bool CheckInsertData(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            bool flag = true;
            strInvalid = "";
            switch (dr.Table.TableName.ToUpper())
            {
                case "HC_ORD_PURCHASE":     //订单明细状态表
                    flag = PurchaseCheck.GetInstance().CheckPurchaseForInsert(dr, out strInvalid);
                    break;

                case "HC_ORD_PURCHASE_ITEM": //产品匹配表

                    flag = PurchaseCheck.GetInstance().CheckPurchaseItemForInsert(dr, out strInvalid);
                    break;
                case "HC_ORD_ORDER": //订单表

                    flag = OrderCheck.GetInstance().CheckOrderForInsert(dr,  out strInvalid);
                    break;
                case "HC_ORD_ORDER_ITEM":      //订单明细表

                    flag = OrderCheck.GetInstance().CheckOrderItemForInsert(dr, out strInvalid);
                    break;
                default:
                    break;
            }
            return flag;
        }

        /// <summary>
        /// 删除数据的判断
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        private bool CheckDeleteData(DataRow dr, DbTransaction tran, out string strInvalid)
        {
            bool flag = true;
            strInvalid = "";
            switch (dr["Table_Name"].ToString().ToUpper())
            {
                case "HC_ORD_PURCHASE":
                    flag = PurchaseCheck.GetInstance().CheckPurchaseForDelete(dr, out strInvalid);
                    break;
                case "HC_ORD_PURCHASE_ITEM":
                    flag = PurchaseCheck.GetInstance().CheckPurchaseItemForDelete(dr, out strInvalid);
                    break;
            }
            return flag;
        }

    }
}
