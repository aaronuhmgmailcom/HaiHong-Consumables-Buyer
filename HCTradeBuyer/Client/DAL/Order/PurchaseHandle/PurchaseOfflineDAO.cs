//刘海超
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;
using Emedchina.TradeAssistant.Model.User;
namespace Emedchina.TradeAssistant.Client.DAL.Order.PurchaseHandle
{

    public class PurchaseOfflineDAO : SqlDAOBase
    {

        private PurchaseOfflineDAO()
            : base()
        { }

        private PurchaseOfflineDAO(string connectionName)
            : base(connectionName)
        { }

        public static PurchaseOfflineDAO GetInstance()
        {
            return new PurchaseOfflineDAO();
        }

        public static PurchaseOfflineDAO GetInstance(string connectionName)
        {
            return new PurchaseOfflineDAO(connectionName);
        }
        #region 复制采购单(离线)  CopyPurchaseOffline
        /// <summary>
        /// 复制采购单(离线)
        /// </summary>
        public PurchaseSaveModel CopyPurchaseOffline(PurchaseSaveModel input)
        {
            PurchaseSaveModel output = new PurchaseSaveModel();
            LogedInUser user = ClientSession.GetInstance().CurrentUser;
            //user = ClientSession.GetInstance().CurrentUser;

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {

                    DateTime currentDate = DateTime.Now;
                    string buyerID = user.UserInfo.Id;
                    String purchaseID = input.PurchaseId;
                    Int64 newPurchaseID = base.GetClientId(user.HighId);
                    String newPurchaseCode = base.GetClientCode(user.HighId);

                    StringBuilder mastersql = new StringBuilder();
                    mastersql.Append("INSERT INTO HC_ORD_PURCHASE ( ");
                    mastersql.Append("  ID,BUYER_ID,state, CODE, create_user_id, create_user_name,");
                    mastersql.Append("  create_date,");
                    mastersql.Append("  modify_user_id, modify_user_name,");
                    mastersql.Append("  modify_date,");
                    mastersql.Append("  PURCHASE_date,");
                    mastersql.Append("  TOTAL_SUM,");
                    mastersql.Append("  AUDIT_USER_ID,AUDIT_USER_NAME,");
                    mastersql.Append("  AUDIT_DATE,QUICKSEND_LEVEL,");
                    mastersql.Append("  TYPE,sync_state)");

                    mastersql.Append("  SELECT @purchaseid,BUYER_ID, '1', @purchase_code,@create_userid , @create_username,");
                    mastersql.Append("   '").Append(DateTime.Now).Append("',");
                    mastersql.Append("  @modify_userid,@modify_username,");
                    mastersql.Append("   '").Append(DateTime.Now).Append("',");
                    mastersql.Append("  null,");
                    mastersql.Append("  TOTAL_SUM,");
                    mastersql.Append("  0,'', ");
                    mastersql.Append("  null,'1',");
                    mastersql.Append("  TYPE,'0'");
                    mastersql.Append("  FROM HC_ORD_PURCHASE ");
                    mastersql.Append("  WHERE id = @id");

                    DbParameter[] paraPurchase = this.DbFacade.CreateParameterArray(7);

                    paraPurchase[0].ParameterName = "purchaseid";
                    paraPurchase[0].DbType = DbType.String;
                    paraPurchase[0].Value = newPurchaseID;

                    paraPurchase[1].ParameterName = "purchase_code";
                    paraPurchase[1].DbType = DbType.String;
                    paraPurchase[1].Value = newPurchaseCode;

                    paraPurchase[2].ParameterName = "create_userid";
                    paraPurchase[2].DbType = DbType.String;
                    paraPurchase[2].Value = input.UserID;

                    paraPurchase[3].ParameterName = "create_username";
                    paraPurchase[3].DbType = DbType.String;
                    paraPurchase[3].Value = input.UserName;

                    paraPurchase[4].ParameterName = "modify_userid";
                    paraPurchase[4].DbType = DbType.String;
                    paraPurchase[4].Value = input.UserID;

                    paraPurchase[5].ParameterName = "modify_username";
                    paraPurchase[5].DbType = DbType.String;
                    paraPurchase[5].Value = input.UserName;

                    paraPurchase[6].ParameterName = "id";
                    paraPurchase[6].DbType = DbType.String;
                    paraPurchase[6].Value = purchaseID;



                    //如果复制采购主单成功，并且有返回数据，则继续复制明细数据，否则将事务回滚
                    if (base.DbFacade.SQLExecuteNonQuery(mastersql.ToString(), transaction, paraPurchase) <= 0)
                    {
                        //回滚
                        base.DbFacade.RollbackTransaction(transaction);
                        return null;
                    }

                    string sql = "select id from HC_ORD_PURCHASE_ITEM where purchase_id =@purchaseID ";

                    DbParameter[] para1 = this.DbFacade.CreateParameterArray(1);

                    para1[0].ParameterName = "purchaseID";
                    para1[0].DbType = DbType.String;
                    para1[0].Value = purchaseID;

                    DataTable dt = base.DbFacade.SQLExecuteDataTable(sql, transaction, para1);

                    StringBuilder newsql = new StringBuilder();
                    newsql.Append("INSERT INTO HC_ORD_PURCHASE_ITEM ( ");
                    newsql.Append("  ID,PURCHASE_ID ,");
                    newsql.Append("  CREATE_DATE, MODIFY_DATE,");
                    newsql.Append("  PROJECT_PROD_ID,DATA_PRODUCT_ID,BUYER_ID,PROJECT_ID");
                    newsql.Append("  ,SALER_ID,SALER_NAME,SALER_NAME_ABBR,SENDER_ID,SENDER_NAME");
                    newsql.Append(" ,SENDER_NAME_ABBR,MANUFACTURE_ID,MANUFACTURE_NAME");
                    newsql.Append(" ,MANUFACTURE_NAME_ABBR,COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE");
                    newsql.Append("  ,SPEC_ID,MODEL_ID,SPEC,MODEL,BRAND,GOODS_NO,BARCODE");
                    newsql.Append("  ,STORE_ROOM_ID,STORE_ROOM_NAME,STORE_ROOM_ADDRESS,BASE_MEASURE");
                    newsql.Append(" ,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,SEND_MEASURE,SEND_MEASURE_EX");
                    newsql.Append("  ,RETAIL_PRICE,TRADE_PRICE,AMOUNT,OVER_AMOUNT,OVER_SUM,IS_QUICKSEND");
                    newsql.Append("  ,BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI,SUM");
                    newsql.Append(" ,CREATE_USER_ID,CREATE_USER_NAME, MODIFY_USER_ID");
                    newsql.Append("  ,MODIFY_USER_NAME, DESCRIPTIONS,SYNC_STATE)");

                    newsql.Append("  SELECT @id,@newPurchaseID,");
                    newsql.Append("   '").Append(DateTime.Now).Append("',");
                    newsql.Append("   '").Append(DateTime.Now).Append("',");
                    newsql.Append("  PROJECT_PROD_ID,DATA_PRODUCT_ID,BUYER_ID,PROJECT_ID");
                    newsql.Append("  ,SALER_ID,SALER_NAME,SALER_NAME_ABBR,SENDER_ID,SENDER_NAME");
                    newsql.Append(" ,SENDER_NAME_ABBR,MANUFACTURE_ID,MANUFACTURE_NAME");
                    newsql.Append(" ,MANUFACTURE_NAME_ABBR,COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE");
                    newsql.Append("  ,SPEC_ID,MODEL_ID,SPEC,MODEL,BRAND,GOODS_NO,BARCODE");
                    newsql.Append("  ,STORE_ROOM_ID,STORE_ROOM_NAME,STORE_ROOM_ADDRESS,BASE_MEASURE");
                    newsql.Append(" ,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,SEND_MEASURE,SEND_MEASURE_EX");
                    newsql.Append("  ,RETAIL_PRICE,TRADE_PRICE,AMOUNT,OVER_AMOUNT,OVER_SUM,IS_QUICKSEND");
                    newsql.Append("  ,BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI,SUM");
                    newsql.Append(" ,@create_userid,@create_username,@modify_userid");
                    newsql.Append("  ,@modify_username, DESCRIPTIONS,0");
                    newsql.Append("  FROM HC_ORD_PURCHASE_ITEM WHERE id = @purchaseitem_id ");
                    newsql.Append("  and purchase_id = @purchase_id");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DbParameter[] para2 = this.DbFacade.CreateParameterArray(8);

                        para2[0].ParameterName = "id";
                        para2[0].DbType = DbType.String;
                        para2[0].Value = base.GetClientId(user.HighId);

                        para2[1].ParameterName = "newPurchaseID";
                        para2[1].DbType = DbType.String;
                        para2[1].Value = newPurchaseID;

                        para2[2].ParameterName = "purchaseitem_id";
                        para2[2].DbType = DbType.String;
                        para2[2].Value = dt.DefaultView[i].Row["id"].ToString();

                        para2[3].ParameterName = "purchase_id";
                        para2[3].DbType = DbType.String;
                        para2[3].Value = purchaseID;

                        para2[4].ParameterName = "create_userid";
                        para2[4].DbType = DbType.String;
                        para2[4].Value = input.UserID;

                        para2[5].ParameterName = "create_username";
                        para2[5].DbType = DbType.String;
                        para2[5].Value = input.UserName;

                        para2[6].ParameterName = "modify_userid";
                        para2[6].DbType = DbType.String;
                        para2[6].Value = input.UserID;

                        para2[7].ParameterName = "modify_username";
                        para2[7].DbType = DbType.String;
                        para2[7].Value = input.UserName;


                        //如果复制采购明细单成功，并且有返回数据，则继续复制明细数据，否则将事务回滚
                        if (base.DbFacade.SQLExecuteNonQuery(newsql.ToString(), transaction, para2) <= 0)
                        {
                            //回滚
                            base.DbFacade.RollbackTransaction(transaction);
                            return null;
                        }
                    }

                    output.PurchaseId = newPurchaseID.ToString();
                    output.PurchaseCode = newPurchaseCode;
                    //提交
                    base.DbFacade.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    //回滚
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            return output;

        }
        #endregion
        #region 删除采购单及删除采购单明细
        /// <summary>
        /// 删除采购单及删除采购单明细
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool PurchaseDeleteLocal(string purchaseId, string userId)
        {
            bool flag = true;
            int rownum;
            StringBuilder sql = new StringBuilder();
            sql.Append(" Delete from HC_ORD_PURCHASE where id = @purchaseId ");
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    //首先删除采购单明细表数据信息 离线
                    if (!PurchaseItemDelete(purchaseId, userId, transaction))
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                        flag = false;
                        return flag;
                    }

                    DbParameter[] para = this.DbFacade.CreateParameterArray(1);

                    para[0].ParameterName = "purchaseId";
                    para[0].DbType = DbType.AnsiString;
                    para[0].Value = purchaseId;

                    rownum = base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, para);
                    bool insertflg = base.addDelLog("HC_ORD_PURCHASE", purchaseId, "ID", userId, "1", transaction);
                    if (rownum > 0 && insertflg)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                        flag = false;
                    }
                }
                catch (Exception e)
                {                    
                    base.DbFacade.RollbackTransaction(transaction);
                    flag = false;
                    throw e;
                }
            }
            return flag;
        }
        #endregion
        #region 删除采购单明细方法(离线),为删除采购单方法调用,根据采购单ｉｄ
        /// <summary>
        /// 删除采购单明细方法(离线)
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool PurchaseItemDelete(string purchaseId, string userId, DbTransaction transaction)
        {
            bool fla = false;

            StringBuilder sql = new StringBuilder();
            sql.Append(" delete from  HC_ORD_PURCHASE_ITEM  where purchase_id = @purchaseId ");

            DbParameter[] para = this.DbFacade.CreateParameterArray(1);
            para[0].ParameterName = "purchaseId";
            para[0].DbType = DbType.AnsiString;
            para[0].Value = purchaseId;

            //新增DEL_LOG
            string sqlLog = "select gpi.ID from HC_ORD_PURCHASE_ITEM gpi where purchase_id = " + purchaseId + "";
            IList<string> itemIDList = (IList<string>)base.DbFacade.SQLExecuteList<string>(sqlLog, transaction, new MapRow<string>(MapGetId));

            bool insertflg = false;
            foreach (string itemID in itemIDList)
            {
                insertflg = base.addDelLog("HC_ORD_PURCHASE_ITEM", itemID, "ID", userId, "2", transaction);
                if (!insertflg)
                {
                    return false;
                }
            }

            //删除
            int row = base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, para);

            if (row >= 0)
            {
                fla = true;
            }

            return fla;
        }
        #endregion
        #region   MapGetId
        /// <summary> MapGetId
        /// GetID
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private string MapGetId(IDataReader reader, int rowNumber)
        {
            return Convert.ToString(reader["ID"]);
        }
        #endregion

        #region 送审采购单
        /// <summary>
        /// 送审采购单
        /// </summary>
        /// <param name="purchaseId">采购单ID</param>
        /// <returns></returns>
        public bool putCheckPurchaseOffline(string purchaseId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE HC_ORD_PURCHASE ");
            sql.Append(" SET STATE = '2',SYNC_STATE='0' WHERE id =");
            sql.Append(purchaseId);
            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region 审核拒绝
        /// <summary>
        /// 审核拒绝
        /// </summary>
        /// <param name="purchaseId">采购单ID</param>
        /// <returns></returns>
        public bool Checkno(string purchaseId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE HC_ORD_PURCHASE ");
            sql.Append(" SET STATE = '3',SYNC_STATE='0'WHERE id =");
            sql.Append(purchaseId);
            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        //以下是发送离线功能的实现
        #region 审批采购单并发出，即拆单　　离线
        /// <summary>
        /// 审批采购单并发出，即拆单　　离线
        /// </summary>
        /// <param name="purchaseId">采购单ID</param>
        /// <returns></returns>
        public String getCheckPurchaseOffline(string purchaseId, UserInfoModel usInfo)
        {
            bool flag = true;
            string mes = null;
            DataSet ds = new DataSet();
            //实例化订单明细实体层
            PurchaseOrderItemModel Item = new PurchaseOrderItemModel();
            //实例化订单实体层
            PurchaseOrderModel Order = new PurchaseOrderModel();
            ItemStatusModel ItemStatus = new ItemStatusModel();
            //实例化采购单明细实体层
            PurchaseItemModel PurchaseItem = new PurchaseItemModel();     
            //实例化采购单实体层
            PurchaseCreateModel Purchase = new PurchaseCreateModel();
           // LogedInUser user = ClientSession.GetInstance().CurrentUser;

            string strSenderID = "";
            string strOrderID = "0";
            string strOrderItemID = null;

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {

                ds = PurchaselistOffline(purchaseId, transaction);
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                DataRow dr;
                List<string> list = new List<string>();
                try
                {

                    #region for
                    for (int i = 0; i < rowcount; i++)
                    {
                        dr = dt.Rows[i];
                        string purchaseItemId = dr["purchase_item_id"].ToString();
                            ////库房id
                            //string warehouseId = dr["STORE_ROOM_ID"].ToString();
                            //if (!string.IsNullOrEmpty(warehouseId))
                            //{
                            //    strWareHouseTmp = dr["STORE_ROOM_ID"].ToString();
                            //}
                            //if (!strWareHouseID.Equals(strWareHouseTmp) || !strSenderID.Equals(dr["senderr_id"].ToString()))
                            if (!strSenderID.Equals(dr["sender_id"].ToString()))
                            {
                                strOrderID = base.GetClientId(usInfo.HighID).ToString();
                                list.Add(strOrderID);
                                Order.OrderId = strOrderID;
                                Order.PurchaseId = purchaseId;
                                // 订单编码
                                string OrderCode = base.GetClientCode(usInfo.HighID).ToString();
                                Order.OrderCode = OrderCode;
                                // 订单状态 0: 准备 1:已阅读 2:交易中 3:完成
                                Order.OrderState = "0";
                                // 订单紧急程度 0:普通 1:部分紧急 2:全部紧急
                                Order.DegreeFlag = "0";
                                // 买方ID
                                Order.BuyerOrgid = usInfo.OrgId;
                                // 仓库ID
                                Order.RepositoryId = dr["STORE_ROOM_ID"].ToString();
                                Order.BakBuyerEasy = usInfo.OrgAddr;
                                Order.BakBuyerName = usInfo.OrgName;
                                Order.SenderEasy = dr["SENDER_NAME_ABBR"].ToString();
                                Order.SenderName = dr["Sender_Name"].ToString();
                                Order.SenderId = dr["Sender_Id"].ToString();
                                Order.PurchaseCode = dr["purchase_code"].ToString();
                                Order.RepositoryAddr = dr["STORE_ROOM_ADDRESS"].ToString();
                                Order.OrderState = dr["TYPE"].ToString();
                                Order.CreateDate = Convert.ToDateTime(DateTime.Now);
                                Order.CreateUserid = usInfo.Id;//以后要改
                                Order.CreateUsername = usInfo.Name;//以后要改
                                Order.ModifyDate = Convert.ToDateTime(DateTime.Now);
                                Order.ModifyUserid = usInfo.Id; //以后要改
                                Order.BuyerDescriptions = "";//dr["DESCRIPTIONS"].ToString();//买方描述
                                //保存订单操作
                                if (!this.OrderSaveOffline(Order, transaction))
                                {
                                    mes = "订单主记录保存失败！";
                                    return mes;
                                }
                            }

                            //订单明细表的拆单过程
                            strOrderItemID = base.GetClientId(usInfo.HighID).ToString();
                            Item.RecordId = strOrderItemID;
                            Item.PurchaseId = dr["PURCHASE_ID"].ToString();
                            Item.DataproductId = dr["DATA_PRODUCT_ID"].ToString();
                            Item.ProjectprodId = dr["PROJECT_PROD_ID"].ToString();
                            Item.SpecId = dr["SPEC_ID"].ToString();
                            Item.ModelId = dr["MODEL_ID"].ToString();
                            Item.Spec = dr["SPEC"].ToString();
                            Item.Model = dr["Model"].ToString();
                            Item.PurchaseItemId = purchaseItemId;
                            Item.OrderId = strOrderID;
                            Item.BuyerOrgid = dr["BUYER_ID"].ToString();
                            Item.BakBuyerName = usInfo.OrgName;
                            Item.BakBuyerEasy = usInfo.OrgAddr;
                            Item.UnitPrice = Convert.ToDecimal(dr["TRADE_PRICE"].ToString());
                            Item.ReadyFlag = "0";
                            Item.RequestQty = Convert.ToDecimal(dr["AMOUNT"].ToString());
                            Item.ProjectId = dr["project_id"].ToString();
                            Item.RepositoryId = dr["STORE_ROOM_ID"].ToString();
                            Item.Storeroomname = dr["STORE_ROOM_NAME"].ToString();
                            Item.RepositoryAddr = dr["STORE_ROOM_ADDRESS"].ToString();
                            Item.PurchaseItemId = dr["PURCHASE_ITEM_ID"].ToString();
                            Item.ProductName = dr["PRODUCT_NAME"].ToString();
                            Item.CommonName = dr["COMMON_NAME"].ToString();
                            Item.SalerId = dr["SALER_ID"].ToString();
                            Item.SalerName = dr["SALER_NAME"].ToString();
                            Item.SalerNameEasy = dr["SALER_NAME_ABBR"].ToString();
                            Item.SenderId = dr["Sender_Id"].ToString();
                            Item.SenderName = dr["SENDER_NAME"].ToString();
                            Item.ProductCode = dr["PRODUCT_CODE"].ToString();
                            Item.Basemeasure = dr["BASE_MEASURE"].ToString();
                            Item.MaxPrice = Convert.ToDecimal(dr["RETAIL_PRICE"].ToString());

                            Item.SenderNameEasy = dr["SENDER_NAME_ABBR"].ToString();
                            Item.SenderId = dr["SENDER_ID"].ToString();
                            Item.ManufactureId = dr["MANUFACTURE_ID"].ToString();
                            Item.ManufactureName = dr["MANUFACTURE_NAME"].ToString();
                            Item.ManufactureNameEasy = dr["MANUFACTURE_NAME_ABBR"].ToString();
                            Item.Balanceid = dr["BALANCE_ID"].ToString();
                            Item.Balancename = dr["BALANCE_NAME"].ToString();
                            Item.Balanceeasy = dr["BALANCE_EASY"].ToString();
                            Item.Balancefast = dr["BALANCE_FAST"].ToString();
                            Item.Balancewubi = dr["BALANCE_WUBI"].ToString();
                            Item.Goodsno = dr["GOODS_NO"].ToString();
                            Item.Brand = dr["BRAND"].ToString();
                            Item.Barcode = dr["BARCODE"].ToString();
                            Item.Basemeasuerspec = dr["BASE_MEASURE_SPEC"].ToString();
                            Item.Basemeasuremater = dr["BASE_MEASURE_MATER"].ToString();
                            Item.Sendmeasure = dr["SEND_MEASURE"].ToString();
                            Item.Sendmeasureex = dr["SEND_MEASURE_EX"].ToString();
                            Item.Sum = Convert.ToDecimal(dr["SUM"].ToString());
                            Item.Createusername = usInfo.Name;
                            Item.BuyerDesc = dr["DESCRIPTIONS"].ToString();
                            Item.DegreeFlag = dr["IS_QUICKSEND"].ToString();
                            //Item.Remark = dr["remark"].ToString();
                            Item.OriginalItemId = strOrderItemID;
                            Item.ParentItemId = strOrderItemID;
                            Item.ItemStatus = "1";
                            Item.OrderType = "0";
                            Item.CreateDate = Convert.ToDateTime(DateTime.Now);
                            Item.ModifyUserid = usInfo.Id; //以后要改
                            Item.ModifyDate = Convert.ToDateTime(DateTime.Now);
                            //保存订单明细表操作
                            if (!this.orderItemSaveOffline(Item, transaction))
                            {
                                mes = "订单明细表记录保存失败！";
                                return mes;
                            }

                            //更新经常采购目录 最后制单日期和最后制单数量
                            if (!this.HitCommUpdataOffline(Item, transaction))
                            {
                                mes = "更新经常采购目录 最后制单日期和最后制单数量失败！";
                                return mes;
                            }

                            if (string.IsNullOrEmpty(dr["sender_id"].ToString()))
                            {
                                strSenderID = "";
                            }
                            else
                            {
                                strSenderID = dr["sender_id"].ToString();
                            }

                      
                    }

                    #endregion

                    // 将采购单的状态修改为完成(2)，并写入审核信息
                    Purchase.ApproveDate = Convert.ToDateTime(DateTime.Now);
                    Purchase.ApproveUserid = usInfo.Id;//以后要改
                    Purchase.ApproveUsername = usInfo.Name;//以后要改
                    Purchase.PurchaseState = "4";


                    //更新采购单操作传入purchaseId
                    if (this.PurchaseUpdateOffline(Purchase, purchaseId, transaction))
                    {
                        // 调用刷新订单金额，放入同一个事务中
                        flag = this.updataPriceOffline(list, transaction);
                        if (flag)
                        {
                            //提交
                            base.DbFacade.CommitTransaction(transaction);
                        }
                        else
                        {
                            //回滚
                            base.DbFacade.RollbackTransaction(transaction);
                        }
                    }
                    else
                    {
                        flag = false;
                        mes = "更新采购单状态失败！";
                        return mes;
                    }

                    return mes;
                }
                catch (Exception e)
                {
                    //回滚
                    base.DbFacade.RollbackTransaction(transaction);
                    throw;
                }
            }
            return mes;
        }
        #endregion
        

        #region 审批采购单并发出，即拆单中的记录数  离线 为getCheckPurchaseOffline调用
        /// <summary>
        /// 审批采购单并发出，即拆单中的记录数　离线
        /// </summary>
        /// <returns></returns>

        public DataSet PurchaselistOffline(string purchaseId, DbTransaction tran)
        {

            DataSet ds = new DataSet();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT p.id,p.BUYER_ID,pi.ID as PURCHASE_ITEM_ID,pi.PROJECT_ID,pi.PURCHASE_ID,p.CODE as purchase_code,p.type,pi.PROJECT_PROD_ID ");
            sql.Append(" ,pi.DATA_PRODUCT_ID,pi.SALER_ID,pi.SALER_NAME,pi.SALER_NAME_ABBR,pi.SENDER_ID,pi.SENDER_NAME,pi.SENDER_NAME_ABBR ");
            sql.Append(" ,pi.MANUFACTURE_ID,pi.MANUFACTURE_NAME,pi.MANUFACTURE_NAME_ABBR,pi.COMMON_NAME,pi.PRODUCT_NAME,pi.PRODUCT_CODE,pi.SPEC_ID   ");
            sql.Append(" ,pi.MODEL_ID,pi.SPEC,pi.MODEL,pi.BRAND,pi.GOODS_NO,pi.BARCODE,pi.STORE_ROOM_ID ,pi.STORE_ROOM_NAME,pi.STORE_ROOM_ADDRESS");
            sql.Append(" ,pi.BASE_MEASURE,pi.BASE_MEASURE_SPEC,pi.BASE_MEASURE_MATER,pi.SEND_MEASURE,pi.SEND_MEASURE_EX,pi.RETAIL_PRICE");
            sql.Append(" ,pi.TRADE_PRICE,pi.AMOUNT,pi.OVER_AMOUNT,pi.TRADE_PRICE*pi.AMOUNT as sum,pi.OVER_SUM,pi.IS_QUICKSEND,pi.BALANCE_ID,pi.BALANCE_NAME,pi.BALANCE_EASY  ");
            sql.Append(",pi.BALANCE_FAST,pi.BALANCE_WUBI,pi.CREATE_USER_ID,pi.CREATE_USER_NAME,pi.CREATE_DATE,pi.MODIFY_USER_ID  ");
            sql.Append(" ,pi.MODIFY_USER_NAME,pi.MODIFY_DATE,pi.DESCRIPTIONS ");
            sql.Append(" FROM (HC_ORD_PURCHASE AS p INNER JOIN HC_ORD_PURCHASE_ITEM AS pi ON p.ID = pi.PURCHASE_ID) ");
            sql.Append(" WHERE p.id = @ID");
            sql.Append(" order by pi.SENDER_ID");

            //try
            //{
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "ID";
            para.DbType = DbType.String;
            para.Value = purchaseId;

            DataTable newsTable = base.DbFacade.SQLExecuteDataTable(sql.ToString(), tran, para);
            ds.Tables.Add(newsTable);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            return ds;
        }

        #endregion


        #region 保存订单主记录表操作  离线
        /// <summary>
        /// 保存订单主记录表操作　离线
        /// </summary>
        /// <param name="Order"></param>
        private bool OrderSaveOffline(PurchaseOrderModel order, DbTransaction tran)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO HC_ORD_ORDER ");
            sql.Append(" (ID,ORDER_CODE,PURCHASE_ID,BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,SENDER_ID");
            sql.Append("  ,SENDER_NAME,SENDER_NAME_ABBR,TOTAL_SUM,over_sum,STATE,TYPE,QUICKSEND_LEVEL");
            sql.Append(" ,BUYER_DESCRIPTIONS,CREATE_USER_ID,CREATE_USER_NAME,MODIFY_USER_ID,MODIFY_USER_NAME");
            sql.Append(",CREATE_DATE,PURCHASE_DATE,MODIFY_DATE");
            sql.Append(" ,PURCHASE_CODE,SYNC_STATE)");
            sql.Append(" values (");
            sql.Append(" @order_id,@order_code,@purchase_id,@buyer_orgid,@bak_buyer_name,@bak_buyer_easy,@sender_id,");
            sql.Append(" @sender_name,@sender_easy,@request_total,0,1,@order_state,1,");
            sql.Append(" @Buyer_Descriptions,@create_userid,@create_username,@modify_userid,@create_username,");
            sql.Append("   '").Append(DateTime.Now).Append("',");
            sql.Append("   '").Append(DateTime.Now).Append("',");
            sql.Append("   '").Append(DateTime.Now).Append("',");
            sql.Append(" @purchasecode,'0')");

            StringBuilder logsql = new StringBuilder();
            logsql.Append(" INSERT INTO HC_ORD_ORDER_LOG ");
            logsql.Append(" (ID,ORDER_CODE,PURCHASE_ID,BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,SENDER_ID");
            logsql.Append("  ,SENDER_NAME,SENDER_NAME_ABBR,TOTAL_SUM,over_sum,STATE,TYPE,QUICKSEND_LEVEL");
            logsql.Append(" ,BUYER_DESCRIPTIONS,CREATE_USER_ID,CREATE_USER_NAME,MODIFY_USER_ID,MODIFY_USER_NAME");
            logsql.Append(",CREATE_DATE,PURCHASE_DATE,MODIFY_DATE,OPERATOR_DATE");
            logsql.Append(" ,PURCHASE_CODE,SYNC_STATE,OPERATOR_USER_ID,OPERATOR_USER_NAME)");
            logsql.Append(" values (");
            logsql.Append(" @order_id,@order_code,@purchase_id,@buyer_orgid,@bak_buyer_name,@bak_buyer_easy,@sender_id,");
            logsql.Append(" @sender_name,@sender_easy,@request_total,0,1,@order_state,1,");
            logsql.Append(" @Buyer_Descriptions,@create_userid,@create_username,@modify_userid,@create_username,");
            logsql.Append("   '").Append(DateTime.Now).Append("',");
            logsql.Append("   '").Append(DateTime.Now).Append("',");
            logsql.Append("   '").Append(DateTime.Now).Append("',");
            logsql.Append("   '").Append(DateTime.Now).Append("',");
            logsql.Append(" @purchasecode,'0',@create_userid,@create_username)");
            

            //using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            //{
            //try
            //{
            DbParameter[] para = this.DbFacade.CreateParameterArray(16);
            para[0].ParameterName = "order_id";//
            para[0].DbType = DbType.String;
            para[0].Value = order.OrderId;

            para[1].ParameterName = "purchase_id";//
            para[1].DbType = DbType.String;
            para[1].Value = order.PurchaseId;

            para[2].ParameterName = "order_code";//
            para[2].DbType = DbType.String;
            para[2].Value = order.OrderCode;

            para[3].ParameterName = "order_state";//
            para[3].DbType = DbType.String;
            para[3].Value = order.OrderState;

            para[4].ParameterName = "modify_userid";//
            para[4].DbType = DbType.String;
            para[4].Value = order.ModifyUserid;

            //买方描述
            para[5].ParameterName = "Buyer_Descriptions";//
            para[5].DbType = DbType.String;
            para[5].Value = order.BuyerDescriptions;

            para[6].ParameterName = "buyer_orgid";//
            para[6].DbType = DbType.String;
            para[6].Value = order.BuyerOrgid;

            para[7].ParameterName = "create_username";//
            para[7].DbType = DbType.String;
            para[7].Value = order.CreateUsername;

            para[8].ParameterName = "create_userid";//
            para[8].DbType = DbType.String;
            para[8].Value = order.CreateUserid;

            para[9].ParameterName = "request_total";//
            para[9].DbType = DbType.Decimal;
            para[9].Value = order.RequestTotal;

            para[10].ParameterName = "bak_buyer_name";//
            para[10].DbType = DbType.String;
            para[10].Value = order.BakBuyerName;

            para[11].ParameterName = "bak_buyer_easy";//
            para[11].DbType = DbType.String;
            para[11].Value = order.BakBuyerEasy;

            para[12].ParameterName = "sender_id";//
            para[12].DbType = DbType.String;
            para[12].Value = order.SenderId;

            para[13].ParameterName = "sender_name";//
            para[13].DbType = DbType.String;
            para[13].Value = order.SenderName;

            para[14].ParameterName = "sender_easy";//
            para[14].DbType = DbType.String;
            para[14].Value = order.SenderEasy;

            para[15].ParameterName = "purchasecode";//
            para[15].DbType = DbType.String;
            para[15].Value = order.PurchaseCode;

            

           
           

            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), tran, para) > 0)
            {
                //插入log表
                int a=base.DbFacade.SQLExecuteNonQuery(logsql.ToString(), tran, para);
                return true;
            }
            else
            {
                return false;
            }
            //base.DbFacade.CommitTransaction(transaction);
            //}
            //catch (Exception)
            //{
            //    //base.DbFacade.RollbackTransaction(transaction);
            //    return false;
            //    //throw;
            //}
            //}

        }
        #endregion

        #region 保存订单明细表操作  离线
        /// <summary>
        /// 保存订单明细表操作　离线
        /// </summary>
        private bool orderItemSaveOffline(PurchaseOrderItemModel item, DbTransaction tran)
        {

            StringBuilder sql = new StringBuilder("insert into HC_ORD_ORDER_ITEM");
            sql.Append("(ID,PROJECT_ID,ORDER_ID,PURCHASE_ID,DATA_PRODUCT_ID,PROJECT_PROD_ID,BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,SALER_ID,SALER_NAME");
            sql.Append(" ,SALER_NAME_ABBR,SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR");
            sql.Append(",COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE,SPEC_ID,MODEL_ID,SPEC,MODEL,BRAND,GOODS_NO,BARCODE,STORE_ROOM_ID,STORE_ROOM_NAME,OVER_AMOUNT,OVER_SUM");
            sql.Append(" ,STORE_ROOM_ADDRESS,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,BASE_MEASURE,SEND_MEASURE,SEND_MEASURE_EX,RETAIL_PRICE,TRADE_PRICE,SUM,AMOUNT");
            sql.Append(" ,IS_QUICKSEND,ORDER_TYPE,STATE,BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI,ORIGINAL_ITEM_ID,PARENT_ITEM_ID,PURCHASE_ITEM_ID");
            sql.Append(" ,BUYER_DESCRIPTIONS,CREATE_USER_ID,CREATE_USER_NAME,MODIFY_USER_ID,MODIFY_USER_NAME,SYNC_STATE");
            sql.Append(" ,CREATE_DATE,MODIFY_DATE)");
            sql.Append(" values (");
            sql.Append(" @record_id,@project_id,@order_id,@purchase_id,@DATA_PRODUCT_ID,@PROJECT_PROD_ID,@buyer_orgid,@BUYER_NAME,@BUYER_NAME_ABBR,@SALER_ID,@SALER_NAME");
            sql.Append(" ,@SALER_NAME_ABBR,@SENDER_ID,@SENDER_NAME,@SENDER_NAME_ABBR,@MANUFACTURE_ID,@MANUFACTURE_NAME,@MANUFACTURE_NAME_ABBR");
            sql.Append(" ,@COMMON_NAME,@PRODUCT_NAME,@PRODUCT_CODE,@SPEC_ID,@MODEL_ID,@SPEC,@MODEL,@BRAND,@GOODS_NO,@BARCODE,@repository_id,@STORE_ROOM_NAME,0,0");
            sql.Append(" ,@STORE_ROOM_ADDRESS,@BASE_MEASURE_SPEC,@BASE_MEASURE_MATER,@BASE_MEASURE,@SEND_MEASURE,@SEND_MEASURE_EX,@max_price,@unit_price,@sum,@request_qty,");
            sql.Append(" @degree_flag,@order_type,'1',case when @BALANCE_ID='' then null else @BALANCE_ID end ,@BALANCE_NAME,@BALANCE_EASY,@BALANCE_FAST,@BALANCE_WUBI,@ORIGINAL_ITEM_ID,@PARENT_ITEM_ID,@purchase_item_id");
            sql.Append(" ,@buyer_desc,@modify_userid,@CREATE_USER_NAME,@modify_userid,@CREATE_USER_NAME,'0',");
            sql.Append("   '").Append(DateTime.Now).Append("',");
            sql.Append("   '").Append(DateTime.Now).Append("')");


            StringBuilder logsql = new StringBuilder("insert into HC_ORD_ORDER_ITEM_LOG");
            logsql.Append("(ID,PROJECT_ID,ORDER_ID,PURCHASE_ID,DATA_PRODUCT_ID,PROJECT_PROD_ID,BUYER_ID,BUYER_NAME,BUYER_NAME_ABBR,SALER_ID,SALER_NAME");
            logsql.Append(" ,SALER_NAME_ABBR,SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR");
            logsql.Append(",COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE,SPEC_ID,MODEL_ID,SPEC,MODEL,BRAND,GOODS_NO,BARCODE,STORE_ROOM_ID,STORE_ROOM_NAME,OVER_AMOUNT,OVER_SUM");
            logsql.Append(" ,STORE_ROOM_ADDRESS,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,BASE_MEASURE,SEND_MEASURE,SEND_MEASURE_EX,RETAIL_PRICE,TRADE_PRICE,SUM,AMOUNT");
            logsql.Append(" ,IS_QUICKSEND,ORDER_TYPE,STATE,BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI,ORIGINAL_ITEM_ID,PARENT_ITEM_ID,PURCHASE_ITEM_ID");
            logsql.Append(" ,BUYER_DESCRIPTIONS,CREATE_USER_ID,CREATE_USER_NAME,MODIFY_USER_ID,MODIFY_USER_NAME,SYNC_STATE,OPERATOR_USER_ID,OPERATOR_USER_NAME");
            logsql.Append(" ,CREATE_DATE,MODIFY_DATE,OPERATOR_DATE)");
            logsql.Append(" values (");
            logsql.Append(" @record_id,@project_id,@order_id,@purchase_id,@DATA_PRODUCT_ID,@PROJECT_PROD_ID,@buyer_orgid,@BUYER_NAME,@BUYER_NAME_ABBR,@SALER_ID,@SALER_NAME");
            logsql.Append(" ,@SALER_NAME_ABBR,@SENDER_ID,@SENDER_NAME,@SENDER_NAME_ABBR,@MANUFACTURE_ID,@MANUFACTURE_NAME,@MANUFACTURE_NAME_ABBR");
            logsql.Append(" ,@COMMON_NAME,@PRODUCT_NAME,@PRODUCT_CODE,@SPEC_ID,@MODEL_ID,@SPEC,@MODEL,@BRAND,@GOODS_NO,@BARCODE,@repository_id,@STORE_ROOM_NAME,0,0");
            logsql.Append(" ,@STORE_ROOM_ADDRESS,@BASE_MEASURE_SPEC,@BASE_MEASURE_MATER,@BASE_MEASURE,@SEND_MEASURE,@SEND_MEASURE_EX,@max_price,@unit_price,@sum,@request_qty,");
            logsql.Append(" @degree_flag,@order_type,'1',case when @BALANCE_ID='' then null else @BALANCE_ID end ,@BALANCE_NAME,@BALANCE_EASY,@BALANCE_FAST,@BALANCE_WUBI,@ORIGINAL_ITEM_ID,@PARENT_ITEM_ID,@purchase_item_id");
            logsql.Append(" ,@buyer_desc,@modify_userid,@CREATE_USER_NAME,@modify_userid,@CREATE_USER_NAME,'0',@modify_userid,@CREATE_USER_NAME,");
            logsql.Append("   '").Append(DateTime.Now).Append("',");
            logsql.Append("   '").Append(DateTime.Now).Append("',");
            logsql.Append("   '").Append(DateTime.Now).Append("')");

            DbParameter[] para = this.DbFacade.CreateParameterArray(54);
            para[0].ParameterName = "record_id";
            para[0].DbType = DbType.String;
            para[0].Value = item.RecordId;

            para[1].ParameterName = "purchase_item_id";
            para[1].DbType = DbType.String;
            para[1].Value = item.PurchaseItemId;
            //中心产品ID
            para[2].ParameterName = "DATA_PRODUCT_ID";
            para[2].DbType = DbType.String;
            para[2].Value = item.DataproductId;

            para[3].ParameterName = "order_id";
            para[3].DbType = DbType.String;
            para[3].Value = item.OrderId;
            //项目产品ID
            para[4].ParameterName = "PROJECT_PROD_ID";
            para[4].DbType = DbType.String;
            para[4].Value = item.ProjectprodId;

            para[5].ParameterName = "buyer_orgid";
            para[5].DbType = DbType.String;
            para[5].Value = item.BuyerOrgid;

            para[6].ParameterName = "unit_price";
            para[6].DbType = DbType.Decimal;
            para[6].Value = item.UnitPrice;

            para[7].ParameterName = "PRODUCT_NAME";
            para[7].DbType = DbType.String;
            para[7].Value = item.ProductName;

            para[8].ParameterName = "request_qty";
            para[8].DbType = DbType.Decimal;
            para[8].Value = item.RequestQty;

            para[9].ParameterName = "purchase_id";
            para[9].DbType = DbType.String;
            para[9].Value = item.PurchaseId;

            para[10].ParameterName = "BUYER_NAME";
            para[10].DbType = DbType.String;
            para[10].Value = item.BakBuyerName;

            para[11].ParameterName = "project_id";
            para[11].DbType = DbType.String;
            para[11].Value = item.ProjectId;

            para[12].ParameterName = "COMMON_NAME";
            para[12].DbType = DbType.String;
            para[12].Value = item.CommonName;
            //仓库id
            para[13].ParameterName = "repository_id";
            para[13].DbType = DbType.String;
            para[13].Value = item.RepositoryId;

            para[14].ParameterName = "BUYER_NAME_ABBR";
            para[14].DbType = DbType.String;
            para[14].Value = item.BakBuyerEasy;
            //买方备注
            para[15].ParameterName = "buyer_desc";
            para[15].DbType = DbType.String;
            para[15].Value = item.BuyerDesc;
           
            para[16].ParameterName = "SALER_ID";
            para[16].DbType = DbType.String;
            para[16].Value = item.SalerId;

            //紧急程度
            para[17].ParameterName = "degree_flag";
            para[17].DbType = DbType.String;
            para[17].Value = item.DegreeFlag;

            para[18].ParameterName = "BASE_MEASURE_SPEC";
            para[18].DbType = DbType.String;
            para[18].Value = item.Basemeasuerspec;

            para[19].ParameterName = "SALER_NAME";
            para[19].DbType = DbType.String;
            para[19].Value = item.SalerName;

            para[20].ParameterName = "SALER_NAME_ABBR";
            para[20].DbType = DbType.String;
            para[20].Value = item.SalerNameEasy;

            para[21].ParameterName = "item_status";
            para[21].DbType = DbType.String;
            para[21].Value = item.ItemStatus;

            para[22].ParameterName = "max_price";
            para[22].DbType = DbType.Decimal;
            para[22].Value = item.MaxPrice;
            //订单类型
            para[23].ParameterName = "order_type";
            para[23].DbType = DbType.String;
            para[23].Value = item.OrderType;

            para[24].ParameterName = "modify_userid";
            para[24].DbType = DbType.String;
            para[24].Value = item.ModifyUserid;

            para[25].ParameterName = "SENDER_ID";
            para[25].DbType = DbType.String;
            para[25].Value = item.SenderId;

            para[26].ParameterName = "SENDER_NAME";
            para[26].DbType = DbType.String;
            para[26].Value = item.SenderName;

            para[27].ParameterName = "SENDER_NAME_ABBR";
            para[27].DbType = DbType.String;
            para[27].Value = item.SenderNameEasy;

            para[28].ParameterName = "MANUFACTURE_ID";
            para[28].DbType = DbType.String;
            para[28].Value = item.ManufactureId;

            para[29].ParameterName = "MANUFACTURE_NAME";
            para[29].DbType = DbType.String;
            para[29].Value = item.ManufactureName;

            para[30].ParameterName = "MANUFACTURE_NAME_ABBR";
            para[30].DbType = DbType.String;
            para[30].Value = item.ManufactureNameEasy;

            para[31].ParameterName = "BALANCE_ID";
            para[31].DbType = DbType.String;
            para[31].Value = item.Balanceid;

            para[32].ParameterName = "BALANCE_NAME";
            para[32].DbType = DbType.String;
            para[32].Value = item.Balancename;

            para[33].ParameterName = "BALANCE_EASY";
            para[33].DbType = DbType.String;
            para[33].Value = item.Balanceeasy;

            para[34].ParameterName = "BALANCE_FAST";
            para[34].DbType = DbType.String;
            para[34].Value = item.Balancefast;

            para[35].ParameterName = "BALANCE_WUBI";
            para[35].DbType = DbType.String;
            para[35].Value = item.Balancewubi;

            para[36].ParameterName = "PRODUCT_CODE";
            para[36].DbType = DbType.String;
            para[36].Value = item.ProductCode;

            para[37].ParameterName = "PARENT_ITEM_ID";
            para[37].DbType = DbType.String;
            para[37].Value = item.ParentItemId;


            para[38].ParameterName = "GOODS_NO";
            para[38].DbType = DbType.String;
            para[38].Value = item.Goodsno;

            para[39].ParameterName = "BRAND";
            para[39].DbType = DbType.String;
            para[39].Value = item.Brand;

            para[40].ParameterName = "SPEC_ID";
            para[40].DbType = DbType.String;
            para[40].Value = item.SpecId;

            para[41].ParameterName = "MODEL_ID";
            para[41].DbType = DbType.String;
            para[41].Value = item.ModelId;

            para[42].ParameterName = "SPEC";
            para[42].DbType = DbType.String;
            para[42].Value = item.Spec;

            para[43].ParameterName = "MODEL";
            para[43].DbType = DbType.String;
            para[43].Value = item.Model;

            para[44].ParameterName = "BARCODE";
            para[44].DbType = DbType.String;
            para[44].Value = item.Barcode;
            //仓库名称
            para[45].ParameterName = "STORE_ROOM_NAME";
            para[45].DbType = DbType.String;
            para[45].Value = item.Storeroomname;
            //仓库地址
            para[46].ParameterName = "STORE_ROOM_ADDRESS";
            para[46].DbType = DbType.String;
            para[46].Value = item.RepositoryAddr;

            para[47].ParameterName = "BASE_MEASURE_MATER";
            para[47].DbType = DbType.String;
            para[47].Value = item.Basemeasuremater;

            para[48].ParameterName = "BASE_MEASURE";
            para[48].DbType = DbType.String;
            para[48].Value = item.Basemeasure;

            para[49].ParameterName = "SEND_MEASURE";
            para[49].DbType = DbType.String;
            para[49].Value = item.Sendmeasure;
     
            para[50].ParameterName = "SEND_MEASURE_EX";
            para[50].DbType = DbType.String;
            para[50].Value = item.Sendmeasureex;

            para[51].ParameterName = "SUM";
            para[51].DbType = DbType.Decimal;
            para[51].Value = item.Sum;

            para[52].ParameterName = "CREATE_USER_NAME";
            para[52].DbType = DbType.String;
            para[52].Value = item.Createusername;

            para[53].ParameterName = "ORIGINAL_ITEM_ID";
            para[53].DbType = DbType.String;
            para[53].Value = item.OriginalItemId;


            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), tran, para) > 0)
            {
                int a = base.DbFacade.SQLExecuteNonQuery(logsql.ToString(), tran, para);
                return true;
            }
            else
            {
                return false;
            }

            //base.DbFacade.CommitTransaction(transaction);
            //}
            //catch (Exception)
            //{
            //    //base.DbFacade.RollbackTransaction(transaction);
            //    return false;
            //    //throw;
            //}
            //}
        }
        #endregion

        #region 保存明细状态表操作　离线  增加表GPO_ITEM_STATUS
        /// <summary>
        ///  //保存明细状态表操作　离线
        /// </summary>
        /// <param name="ItemStatus"></param>
        private bool ItemStatusSaveOffline(ItemStatusModel itemStatus, DbTransaction tran)
        {
            StringBuilder sql = new StringBuilder("insert into GPO_ITEM_STATUS ");
            string ItemStatusID = base.GetGlobalId();
            sql.Append("(id,");
            sql.Append(" record_id,");
            sql.Append(" order_item_state,");
            sql.Append(" modify_userid,");
            sql.Append(" modify_date,");
            sql.Append(" modify_username,");
            sql.Append(" sync_state)");
            sql.Append(" values (");
            sql.Append(" :Id,");
            sql.Append(" :recordId,");
            sql.Append(" :orderItemState,");
            sql.Append(" :modifyUserid,");
            sql.Append("  '").Append(DateTime.Now).Append("',");
            sql.Append(" :modifyUsername,");
            sql.Append(" '0')");

            DbParameter[] para = this.DbFacade.CreateParameterArray(5);
            para[0].ParameterName = "Id";
            para[0].DbType = DbType.String;
            para[0].Value = ItemStatusID;

            para[1].ParameterName = "recordId";
            para[1].DbType = DbType.String;
            para[1].Value = itemStatus.RecordId;

            para[2].ParameterName = "orderItemState";
            para[2].DbType = DbType.String;
            para[2].Value = itemStatus.OrderItemState;

            para[3].ParameterName = "modifyUserid";
            para[3].DbType = DbType.String;
            para[3].Value = itemStatus.ModifyUserid;

            para[4].ParameterName = "modifyUsername";
            para[4].DbType = DbType.String;
            para[4].Value = itemStatus.ModifyUsername;


            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), tran, para) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //base.DbFacade.CommitTransaction(transaction);
            //}
            //catch (Exception e)
            //{
            //    //base.DbFacade.RollbackTransaction(transaction);
            //    return false;
            //    //throw;
            //}
            //}

        }
        #endregion

        #region 更新采购单明细的订单生成状态  离线　　增加字段order_flag
        /// <summary>
        /// // 更新采购单明细的订单生成状态　离线
        /// </summary>
        /// <param name="purchaseItemId">采购单ID</param>
        private bool purchaseItemUpdataOffline(string purchaseItemId, DbTransaction tran)
        {

            string sql = " update HC_ORD_PURCHASE_ITEM set  sync_state = '0' where id =@purchaseItemId ";

            DbParameter[] para = this.DbFacade.CreateParameterArray(1);
            para[0].ParameterName = "purchaseItemId";
            para[0].DbType = DbType.String;
            para[0].Value = purchaseItemId;

            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), tran, para) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //base.DbFacade.CommitTransaction(transaction);
            //}
            //catch (Exception)
            //{
            //    //base.DbFacade.RollbackTransaction(transaction);
            //    return false;
            //    //throw;
            //}
            //}
        }

        #endregion

        #region  更新经常采购目录 最后制单日期和最后制单数量　离线
        /// <summary>
        /// // 更新经常采购目录 最后制单日期和最后制单数量　离线
        /// </summary>
        /// <param name="hitComm"></param>
        /// <param name="hitCommId"></param>
        private bool HitCommUpdataOffline(PurchaseOrderItemModel Item,  DbTransaction tran)
        {

            string sql = " update HC_ORD_HIT_COMM  set LAST_DATE=@LAST_DATE,LAST_AMOUNT=@LAST_AMOUNT,LAST_SUM=@LAST_SUM,ALL_AMOUNT=ALL_AMOUNT+@LAST_AMOUNT,ALL_SUM=ALL_SUM+@LAST_SUM,sync_state = '0' where PROJECT_PROD_ID=@PROJECT_PROD_ID and MODEL_ID=@MODEL_ID and SPEC_ID=@SPEC_ID";

            DbParameter[] para = this.DbFacade.CreateParameterArray(6);
            para[0].ParameterName = "LAST_DATE";
            para[0].DbType = DbType.AnsiString;
            para[0].Value = Item.CreateDate;

            para[1].ParameterName = "LAST_AMOUNT";
            para[1].DbType = DbType.Decimal;
            para[1].Value = Item.RequestQty;

            para[2].ParameterName = "LAST_SUM";
            para[2].DbType = DbType.String;
            para[2].Value = Item.Sum;

            para[3].ParameterName = "PROJECT_PROD_ID";
            para[3].DbType = DbType.String;
            para[3].Value = Item.ProjectprodId;

            para[4].ParameterName = "MODEL_ID";
            para[4].DbType = DbType.String;
            para[4].Value = Item.ModelId;

            para[5].ParameterName = "SPEC_ID";
            para[5].DbType = DbType.String;
            para[5].Value = Item.SpecId;

            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), tran, para) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //base.DbFacade.CommitTransaction(transaction);
            //}
            //catch (Exception)
            //{
            //    //base.DbFacade.RollbackTransaction(transaction);
            //    return false;
            //    //throw;
            //}
            //}
        }
        #endregion

      

        #region  刷新订单金额 离线
        /// <summary>
        /// 刷新订单金额　离线
        /// </summary>
        /// <param name="list"></param>
        private bool updataPriceOffline(List<string> list, DbTransaction trans)
        {
            bool flag = true;
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE HC_ORD_ORDER ");
            sql.Append(" SET TOTAL_SUM = @total,QUICKSEND_LEVEL=@quicksend_level,SYNC_STATE='0'");
            sql.Append(" WHERE id =@ID");
            StringBuilder logsql = new StringBuilder();
            logsql.Append("UPDATE HC_ORD_ORDER_LOG ");
            logsql.Append(" SET TOTAL_SUM = @total,QUICKSEND_LEVEL=@quicksend_level,SYNC_STATE='0'");
            logsql.Append(" WHERE id =@ID");
            for (int i = 0; i < list.Count; i++)
            {
                string OrderID = list[i].ToString();

                StringBuilder sql_tmp = new StringBuilder();
                sql_tmp.Append(" SELECT  ");
                sql_tmp.Append(" SUM((case when AMOUNT  is null then 0 else AMOUNT end) * (case when TRADE_PRICE is null  then 0 else TRADE_PRICE end)) as total   ");
                sql_tmp.Append(" FROM HC_ORD_ORDER_ITEM ");
                sql_tmp.Append(" WHERE order_id =@ID");

                DbParameter[] paras = this.DbFacade.CreateParameterArray(1);
                paras[0].ParameterName = "ID";
                paras[0].DbType = DbType.String;
                paras[0].Value = OrderID;

                string tal;
                tal = base.DbFacade.SQLExecuteScalar(sql_tmp.ToString(), trans, paras).ToString();
                if (tal.Equals(null)) { tal = "0"; }
                if (tal.Equals("")) { tal = "0"; }
                StringBuilder sql_quick = new StringBuilder("select ");
                sql_quick.Append(" case when count(1)=(select count(1) from HC_ORD_ORDER_ITEM where ORDER_ID =@ID and IS_QUICKSEND='1') then 3 when count(1)=  ");
                sql_quick.Append(" (select count(1) from HC_ORD_ORDER_ITEM where ORDER_ID =@ID and IS_QUICKSEND='0') then 1 else 2 end  from HC_ORD_ORDER_ITEM ");
                sql_quick.Append(" where  ORDER_ID =@ID");

                string quicksend = base.DbFacade.SQLExecuteScalar(sql_quick.ToString(), trans, paras).ToString();

                DbParameter[] parastotal = this.DbFacade.CreateParameterArray(3);
                parastotal[0].ParameterName = "total";
                parastotal[0].DbType = DbType.Decimal;
                parastotal[0].Value = tal;

                parastotal[1].ParameterName = "ID";
                parastotal[1].DbType = DbType.String;
                parastotal[1].Value = OrderID;

                parastotal[2].ParameterName = "quicksend_level";
                parastotal[2].DbType = DbType.String;
                parastotal[2].Value = quicksend;

                if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), trans, parastotal) <= 0)
                {
                    //修改log表
                    int a = base.DbFacade.SQLExecuteNonQuery(logsql.ToString(), trans, parastotal);
                    flag = false;
                }

                //    base.DbFacade.CommitTransaction(transaction);
                //}
                //catch (Exception)
                //{
                //    base.DbFacade.RollbackTransaction(transaction);
                //    throw;
                //}
                //}
            }
            return flag;
        }
        #endregion

        #region 将采购单的状态修改为完成(2)，并写入审核信息 离线
        /// <summary>
        /// // 将采购单的状态修改为完成(2)，并写入审核信息　离线
        /// </summary>
        /// <param name="purchase"></param>
        /// <param name="purchaseId"></param>
        private bool PurchaseUpdateOffline(PurchaseCreateModel purchase, string purchaseId, DbTransaction transaction)
        {

            string sql = " update HC_ORD_PURCHASE set AUDIT_USER_ID=@approve_userid,AUDIT_USER_NAME=@approve_username,AUDIT_DATE=@approve_date,"
                         + " PURCHASE_DATE=@approve_date,MODIFY_DATE=@modify_date,state=@purchase_state,sync_state = '0'  where id=@id ";

            DbParameter[] para = this.DbFacade.CreateParameterArray(6);

      
            para[0].ParameterName = "approve_userid";
            para[0].DbType = DbType.String;
            para[0].Value = purchase.ApproveUserid;

            para[1].ParameterName = "approve_username";
            para[1].DbType = DbType.String;
            para[1].Value = purchase.ApproveUsername;

            para[2].ParameterName = "approve_date";
            para[2].DbType = DbType.AnsiString;
            para[2].Value = purchase.ApproveDate.ToString();

            para[3].ParameterName = "purchase_state";
            para[3].DbType = DbType.String;
            para[3].Value = purchase.PurchaseState;

            para[4].ParameterName = "modify_date";
            para[4].DbType = DbType.AnsiString;
            para[4].Value = Convert.ToString(DateTime.Now);

            para[5].ParameterName = "id";
            para[5].DbType = DbType.String;
            para[5].Value = purchaseId;


            if (base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, para) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //base.DbFacade.CommitTransaction(transaction);
            //}
            //catch (Exception)
            //{
            //    //base.DbFacade.RollbackTransaction(transaction);
            //    return false;
            //    //throw;
            //}
            //}
        }

        #endregion

       
        //以下是保存采购单离线功能的实现

        //明细相关

        #region 保存 采购单明细 离线 SavePurchaseItemOffline
        /// <summary> 
        /// 保存 采购单明细 离线
        /// </summary>
        public bool SavePurchaseItemOffline(PurchaseItemSaveModel input, DbTransaction transaction, string userid)
        {
            bool flag = false;
            int result;
            ///添加经常采购目录
            if (OrdHitCommIsAdd(input,transaction))
            {
                GetInsertHitcommSqlOffline(input,transaction);

            }
            //新增采购明细
            if (input.RowState.Equals("0"))
            {
                try
                {
                DbParameter[] paraPurchaseItem = this.DbFacade.CreateParameterArray(19);

                paraPurchaseItem[0].ParameterName = "id";
                paraPurchaseItem[0].DbType = DbType.String;
                paraPurchaseItem[0].Value = base. GetClientId(input.HighID).ToString();

                paraPurchaseItem[1].ParameterName = "request_qty";
                paraPurchaseItem[1].DbType = DbType.String;
                paraPurchaseItem[1].Value = decimal.Parse(input.RequestQty);

                paraPurchaseItem[2].ParameterName = "STORE_ROOM_ID";
                paraPurchaseItem[2].DbType = DbType.String;
                paraPurchaseItem[2].Value = input.Storeroomid;

                paraPurchaseItem[3].ParameterName = "modify_userId";
                paraPurchaseItem[3].DbType = DbType.String;
                paraPurchaseItem[3].Value = input.Createid;

                
                paraPurchaseItem[4].ParameterName = "sender_id";
                paraPurchaseItem[4].DbType = DbType.String;
                paraPurchaseItem[4].Value = input.SenderId;

               
                paraPurchaseItem[5].ParameterName = "MODIFY_USER_NAME";
                paraPurchaseItem[5].DbType = DbType.String;
                paraPurchaseItem[5].Value = input.Createname;

                paraPurchaseItem[6].ParameterName = "TRADE_PRICE";
                paraPurchaseItem[6].DbType = DbType.String;
                paraPurchaseItem[6].Value = decimal.Parse(input.UnitPrice);

                paraPurchaseItem[7].ParameterName = "SPEC_ID";
                paraPurchaseItem[7].DbType = DbType.String;
                paraPurchaseItem[7].Value = input.SpecId;

                paraPurchaseItem[8].ParameterName = "MODEL_ID";
                paraPurchaseItem[8].DbType = DbType.String;
                paraPurchaseItem[8].Value = input.ModelId;

                paraPurchaseItem[9].ParameterName = "purchase_id";
                paraPurchaseItem[9].DbType = DbType.String;
                paraPurchaseItem[9].Value = input.PurchaseId;

                paraPurchaseItem[10].ParameterName = "BUYER_ID";
                paraPurchaseItem[10].DbType = DbType.String;
                paraPurchaseItem[10].Value = input.UserOrgID;

                paraPurchaseItem[11].ParameterName = "IS_QUICKSEND";
                paraPurchaseItem[11].DbType = DbType.String;
                paraPurchaseItem[11].Value = input.Isquicsend;

                paraPurchaseItem[12].ParameterName = "CREATE_USER_ID";
                paraPurchaseItem[12].DbType = DbType.String;
                paraPurchaseItem[12].Value = input.Createid;

                paraPurchaseItem[13].ParameterName = "CREATE_USER_NAME";
                paraPurchaseItem[13].DbType = DbType.String;
                paraPurchaseItem[13].Value = input.Createname;
              
                paraPurchaseItem[14].ParameterName = "PROJECT_PROD_ID";
                paraPurchaseItem[14].DbType = DbType.String;
                paraPurchaseItem[14].Value = input.Projectprodid;

                paraPurchaseItem[15].ParameterName = "DESCRIPTIONS";
                paraPurchaseItem[15].DbType = DbType.String;
                paraPurchaseItem[15].Value = input.Descriptions;

                paraPurchaseItem[16].ParameterName = "STORE_ROOM_NAME";
                paraPurchaseItem[16].DbType = DbType.String;
                paraPurchaseItem[16].Value = input.Storeroomname;

                paraPurchaseItem[17].ParameterName = "SPEC";
                paraPurchaseItem[17].DbType = DbType.String;
                paraPurchaseItem[17].Value = input.Spec;

                paraPurchaseItem[18].ParameterName = "MODEL";
                paraPurchaseItem[18].DbType = DbType.String;
                paraPurchaseItem[18].Value = input.Model;
               
                result = DbFacade.SQLExecuteNonQuery(GetAddPurchaseItemSqlOffline(), transaction, paraPurchaseItem);
            }
            catch (Exception e)
            {
                base.DbFacade.RollbackTransaction(transaction);
                throw e;
            }
                if (result > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    //base.DbFacade.RollbackTransaction(transaction);
                }

            }
            //修改采购明细
            else if (input.RowState.Equals("1"))
            {
                StringBuilder sql = new StringBuilder("");
                sql.Append("update HC_ORD_PURCHASE_ITEM  set AMOUNT = @request_qty,STORE_ROOM_ID = @STORE_ROOM_ID,STORE_ROOM_NAME=@STORE_ROOM_NAME,");
                sql.Append(" MODIFY_USER_ID = @modify_userId,MODIFY_USER_NAME=@MODIFY_USER_NAME,IS_QUICKSEND=@IS_QUICKSEND,SUM=convert(decimal(10,2),@request_qty)*convert(decimal(10,2),@TRADE_PRICE), modify_date ='").Append(DateTime.Now);
                sql.Append("',TRADE_PRICE=@TRADE_PRICE,SPEC_ID=@SPEC_ID,SPEC=@SPEC,MODEL_ID=@MODEL_ID,MODEL=@MODEL");
                sql.Append(" ,SENDER_ID=@sender_id,SENDER_NAME=(select distinct SENDER_NAME from HC_ORD_BUYER_SENDER where SENDER_ID=@sender_id and ENABLE_FLAG='1'),SENDER_NAME_ABBR=(select distinct SENDER_ABBR from HC_ORD_BUYER_SENDER where SENDER_ID=@sender_id and ENABLE_FLAG='1'),SYNC_STATE='0',DESCRIPTIONS=@DESCRIPTIONS where Id = @id"); 
                DbParameter[] paraupt = this.DbFacade.CreateParameterArray(16);

                paraupt[0].ParameterName = "request_qty";
                paraupt[0].DbType = DbType.String;
                paraupt[0].Value =input.RequestQty;

                paraupt[1].ParameterName = "STORE_ROOM_ID";
                paraupt[1].DbType = DbType.String;
                paraupt[1].Value = input.Storeroomid;

                paraupt[2].ParameterName = "modify_userId";
                paraupt[2].DbType = DbType.String;
                paraupt[2].Value = input.Createid;

                paraupt[3].ParameterName = "sender_id";
                paraupt[3].DbType = DbType.String;
                paraupt[3].Value = input.SenderId;
               
                paraupt[4].ParameterName = "id";
                paraupt[4].DbType = DbType.String;
                paraupt[4].Value = input.PurchaseItemId;
              
                paraupt[5].ParameterName = "MODIFY_USER_NAME";
                paraupt[5].DbType = DbType.String;
                paraupt[5].Value = input.Createname;

                paraupt[6].ParameterName = "TRADE_PRICE";
                paraupt[6].DbType = DbType.String;
                paraupt[6].Value =input.UnitPrice;

                paraupt[7].ParameterName = "SPEC_ID";
                paraupt[7].DbType = DbType.String;
                paraupt[7].Value = input.SpecId;               

                paraupt[8].ParameterName = "MODEL_ID";
                paraupt[8].DbType = DbType.String;
                paraupt[8].Value = input.ModelId;

                paraupt[9].ParameterName = "PROJECT_PROD_ID";
                paraupt[9].DbType = DbType.String;
                paraupt[9].Value = input.Projectprodid;

                paraupt[10].ParameterName = "IS_QUICKSEND";
                paraupt[10].DbType = DbType.String;
                paraupt[10].Value = input.Isquicsend;

                paraupt[11].ParameterName = "BUYER_ID";
                paraupt[11].DbType = DbType.String;
                paraupt[11].Value = input.UserOrgID;

                paraupt[12].ParameterName = "DESCRIPTIONS";
                paraupt[12].DbType = DbType.String;
                paraupt[12].Value = input.Descriptions;

                paraupt[13].ParameterName = "STORE_ROOM_NAME";
                paraupt[13].DbType = DbType.String;
                paraupt[13].Value = input.Storeroomname;

                paraupt[14].ParameterName = "SPEC";
                paraupt[14].DbType = DbType.String;
                paraupt[14].Value = input.Spec;

                paraupt[15].ParameterName = "MODEL";
                paraupt[15].DbType = DbType.String;
                paraupt[15].Value = input.Model;

                //更新采购单明细
                int itemCount = base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, paraupt);
                if (itemCount > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            //删除采购单

            else if (input.RowState.Equals("2"))
            {
                flag = DelPurchaseItemOffline(input.PurchaseItemId, transaction, userid);
            }

           
            //}
            return flag;

        }
        #endregion  

       
        #region 添加经常采购目录sql
        /// <summary>
        /// 添加经常采购目录sql
        /// </summary>
        /// <returns>DataTable</returns>
        private void GetInsertHitcommSqlOffline(PurchaseItemSaveModel model, DbTransaction transaction)
        {
            StringBuilder sql = new StringBuilder("");
            sql.Append(" INSERT INTO HC_ORD_HIT_COMM");
            sql.Append("  (ID,PROJECT_ID,DATA_PRODUCT_ID,PROJECT_PROD_ID,CONT_PRODUCT_ID,PRODUCT_NAME,COMMERCE_NAME,COMMON_NAME,CODE,ABBR_PY,ABBR_WB ");
            sql.Append(" ,BRAND,MODEL_ID,SPEC_ID,MODEL,SPEC,GOODS_NO,BARCODE,BASE_MEASURE,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,MAX_PRICE,HISTORY_PIRCE");
            sql.Append(",PRICE,MANU_ID,MANU_NAME,MANU_NAME_ABBR,SALER_ID,SALER_NAME,BUYER_ID,BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI ");
            sql.Append(" ,SALER_NAME_ABBR,DEFAULT_MEASURE,DEFAULT_MEASURE_EX,BAK_MEASURE_ONE,BAK_MEASURE_ONE_EX,BAK_MEASURE_TWO,BAK_MEASURE_TWO_EX");
            sql.Append(",PRICE_DESCRIPTION,PERFORMANCE,PRE_PURCHASE,STATE_CHANGE_REASON,REG_NO,REG_VALID_DATE,DESCRIPTIONS ");
            sql.Append(" ,ALL_AMOUNT,ALL_SUM,STORE_ROOM_ID,STORE_ROOM_NAME,SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,STATE,CREATE_USER_ID,CREATE_USER_NAME ");
            sql.Append(" ,CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,INSTRU_CODE,INSTRU_NAME,SYNC_STATE)");

            sql.Append(" select @id,PROJECT_ID,DATA_PRODUCT_ID,ID,CONT_PRODUCT_ID,PRODUCT_NAME,COMMERCE_NAME,COMMON_NAME,CODE,ABBR_PY,ABBR_WB");
            sql.Append("  ,case when BRAND is null then '-' else BRAND end as BRAND,@MODEL_ID,@SPEC_ID,(select MODEL_NAME from HC_ORD_PRODUCT_MODEL where id=@MODEL_ID),(select SPEC_NAME from HC_ORD_PRODUCT_SPEC where id=@SPEC_ID),GOODS_NO,BARCODE,BASE_MEASURE,BASE_MEASURE_SPEC,BASE_MEASURE_MATER,MAX_PRICE,HISTORY_PIRCE");
            sql.Append(",PRICE,MANU_ID,MANU_NAME,MANU_NAME_ABBR,SALER_ID,SALER_NAME,@BUYER_ID,BALANCE_ID,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI ");
            sql.Append(" ,SALER_NAME_ABBR,DEFAULT_MEASURE,DEFAULT_MEASURE_EX,BAK_MEASURE_ONE,BAK_MEASURE_ONE_EX,BAK_MEASURE_TWO,BAK_MEASURE_TWO_EX");
            sql.Append(",PRICE_DESCRIPTION,PERFORMANCE,PRE_PURCHASE,STATE_CHANGE_REASON,REG_NO,REG_VALID_DATE,'' ");
            sql.Append(" ,0,0,@STORE_ROOM_ID,(select STORE_NAME from HC_BUYER_STORE where id=@STORE_ROOM_ID and ORG_ID=@BUYER_ID),@SENDER_ID,(select distinct SENDER_NAME from HC_ORD_BUYER_SENDER where SENDER_ID=@sender_id and ENABLE_FLAG='1'),(select distinct SENDER_ABBR from HC_ORD_BUYER_SENDER where SENDER_ID=@sender_id and ENABLE_FLAG='1'),'1',@CREATE_USER_ID,@CREATE_USER_NAME,' ");
            sql.Append(DateTime.Now).Append("',@CREATE_USER_ID,@CREATE_USER_NAME,'").Append(DateTime.Now).Append("',INSTRU_CODE,INSTRU_NAME,'0'");
            sql.Append("  from HC_ORD_PRODUCT where ID=@PROJECT_PROD_ID ");
    

            DbParameter[] paraHitcommItem = this.DbFacade.CreateParameterArray(9);

            paraHitcommItem[0].ParameterName = "id";
            paraHitcommItem[0].DbType = DbType.String;
            paraHitcommItem[0].Value = base.GetClientId(model.HighID).ToString();

            paraHitcommItem[1].ParameterName = "sender_id";
            paraHitcommItem[1].DbType = DbType.String;
            paraHitcommItem[1].Value = model.SenderId;

            paraHitcommItem[2].ParameterName = "STORE_ROOM_ID";
            paraHitcommItem[2].DbType = DbType.String;
            paraHitcommItem[2].Value = model.Storeroomid;


            paraHitcommItem[3].ParameterName = "SPEC_ID";
            paraHitcommItem[3].DbType = DbType.String;
            paraHitcommItem[3].Value = model.SpecId;


            paraHitcommItem[4].ParameterName = "MODEL_ID";
            paraHitcommItem[4].DbType = DbType.String;
            paraHitcommItem[4].Value = model.ModelId;


            paraHitcommItem[5].ParameterName = "PROJECT_PROD_ID";
            paraHitcommItem[5].DbType = DbType.String;
            paraHitcommItem[5].Value = model.Projectprodid;

            paraHitcommItem[6].ParameterName = "CREATE_USER_ID";
            paraHitcommItem[6].DbType = DbType.String;
            paraHitcommItem[6].Value = model.Createid;

            paraHitcommItem[7].ParameterName = "CREATE_USER_NAME";
            paraHitcommItem[7].DbType = DbType.String;
            paraHitcommItem[7].Value = model.Createname;

            paraHitcommItem[8].ParameterName = "BUYER_ID";
            paraHitcommItem[8].DbType = DbType.String;
            paraHitcommItem[8].Value = model.UserOrgID;

           int result = base.DbFacade.SQLExecuteNonQuery(sql.ToString(), transaction, paraHitcommItem);
      

        }
        #endregion
       

        #region 新增采购单明细SQL 离线 GetAddPurchaseItemSqlOffline
        /// <summary>
        /// 新增采购单明细SQL　离线
        /// </summary>
        public String GetAddPurchaseItemSqlOffline()
        {
            StringBuilder sql = new StringBuilder("");

            sql.Append("INSERT INTO HC_ORD_PURCHASE_ITEM");
            sql.Append("   (ID,PROJECT_ID,PURCHASE_ID,PROJECT_PROD_ID,DATA_PRODUCT_ID,BUYER_ID,SALER_ID,SALER_NAME,SALER_NAME_ABBR");
            sql.Append("   ,SENDER_ID,SENDER_NAME,SENDER_NAME_ABBR,MANUFACTURE_ID,MANUFACTURE_NAME,MANUFACTURE_NAME_ABBR,COMMON_NAME,PRODUCT_NAME,PRODUCT_CODE,SPEC_ID,SPEC");
            sql.Append("  ,MODEL_ID,MODEL,BRAND,GOODS_NO,BARCODE,STORE_ROOM_ID,STORE_ROOM_NAME,STORE_ROOM_ADDRESS,BASE_MEASURE,BASE_MEASURE_SPEC");
            sql.Append("  ,BASE_MEASURE_MATER,SEND_MEASURE,SEND_MEASURE_EX,RETAIL_PRICE,TRADE_PRICE,AMOUNT,OVER_AMOUNT,OVER_SUM,IS_QUICKSEND,BALANCE_ID,SUM");
            sql.Append("   ,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI,CREATE_USER_ID,CREATE_USER_NAME,CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME");
            sql.Append("  ,MODIFY_DATE,DESCRIPTIONS,SYNC_STATE)");

            sql.Append("  select @id,PROJECT_ID,@purchase_id,PROJECT_PROD_ID,DATA_PRODUCT_ID,@BUYER_ID,SALER_ID,SALER_NAME,SALER_NAME_ABBR,");
            sql.Append("  @sender_id,(select distinct SENDER_NAME from HC_ORD_BUYER_SENDER where SENDER_ID=@sender_id and ENABLE_FLAG='1'),(select distinct SENDER_ABBR from HC_ORD_BUYER_SENDER where SENDER_ID=@sender_id and ENABLE_FLAG='1'),MANU_ID,MANU_NAME,MANU_NAME_ABBR,COMMON_NAME,PRODUCT_NAME,CODE,@SPEC_ID,@SPEC  ,");
            sql.Append("  @MODEL_ID,@MODEL,BRAND,GOODS_NO,BARCODE,@STORE_ROOM_ID,@STORE_ROOM_NAME,(select STORE_ADDRESS from HC_BUYER_STORE where id=@STORE_ROOM_ID and ORG_ID=@BUYER_ID),BASE_MEASURE,BASE_MEASURE_SPEC");
            sql.Append(" ,BASE_MEASURE_MATER,BASE_MEASURE,1,MAX_PRICE,@TRADE_PRICE,@request_qty,0,0,@IS_QUICKSEND,BALANCE_ID,convert(decimal(10,2),@request_qty)*convert(decimal(10,2),@TRADE_PRICE)");
            sql.Append("  ,BALANCE_NAME,BALANCE_EASY,BALANCE_FAST,BALANCE_WUBI,@CREATE_USER_ID,@CREATE_USER_NAME,'").Append(DateTime.Now).Append("',@CREATE_USER_ID,@CREATE_USER_NAME,'");
            sql.Append(DateTime.Now).Append("',@DESCRIPTIONS,'0'");
            sql.Append(" from HC_ORD_HIT_COMM   where PROJECT_PROD_ID = @PROJECT_PROD_ID and MODEL_ID=@MODEL_ID and SPEC_ID=@SPEC_ID  ");

            return sql.ToString();

        }
        #endregion

        #region 删除采购单明细 离线  DelPurchaseItemOffline
        /// <summary>
        /// 删除采购单明细 　离线
        /// </summary>
        public bool DelPurchaseItemOffline(String id, DbTransaction transaction, string userid)
        {
            bool fla = false;
            //using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            //{
            //try
            //{
            String sql = "delete from HC_ORD_PURCHASE_ITEM  where id = @id ";
            DbParameter para = this.DbFacade.CreateParameter();
            para.ParameterName = "id";
            para.DbType = DbType.String;
            para.Value = id;

            if (base.DbFacade.SQLExecuteNonQuery(sql, transaction, para) > 0)
            {
                fla = base.addDelLog("HC_ORD_PURCHASE_ITEM", id, "ID", userid, "2", transaction);
            }
            //}
            //catch (Exception)
            //{
            //    base.DbFacade.RollbackTransaction(transaction);
            //    throw;
            //}
            //}

            return fla;

        }
        #endregion

        //主记录相关

        #region 保存采购单/批量采购单明细　离线SavePurchaseOffline
        /// <summary>
        /// 保存采购单/批量采购单明细 离线
        /// </summary>
        /// <param name="list">采购单保存模型数组</param>
        /// <returns>执行结果</returns>
        public PurchaseSaveModel SavePurchaseOffline(PurchaseSaveModel input, string userid)
        {
            PurchaseSaveModel outInput = null;
            // 采购单id
            String purchaseId = "";
            bool flag = true;
            //newHitCommId = new List<string>();
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {

                    //-------------------------新增保存------------------------------------------
                    if (String.IsNullOrEmpty(input.PurchaseId))
                    {
                        purchaseId = AddSavePurchaseOffline(input, transaction);
                        //保存采购单
                        if (!string.IsNullOrEmpty(purchaseId))
                        {
                            for (int i = 0; i < input.List.Count; i++)
                            {
                                //保存采购单明细
                                string hitCommId = "";
                                PurchaseItemSaveModel itemInput = input.List[i];
                                itemInput.PurchaseId = purchaseId;
                                itemInput.HighID = input.HighID;
                                itemInput.UserOrgID = input.BuyerOrgid;
                                itemInput.Createid = input.CreateUserid;
                                itemInput.Createname = input.CreateUsername;
                                flag = SavePurchaseItemOffline(itemInput, transaction, userid);
                                //if (!"".Equals(hitCommId))
                                //{
                                //    newHitCommId.Add(hitCommId);
                                //}
                            }
                        }
                    }
                    //-------------------------修改保存------------------------------------------
                    else
                    {
                        //add by yanbing 2007-07-09 保存备注,联系电话,采购单名称
                        //updateDetail(input, transaction);
                        //end add
                        purchaseId = input.PurchaseId;
                        for (int i = 0; i < input.List.Count; i++)
                        {
                            //保存采购单明细
                            string hitCommId = "";
                            PurchaseItemSaveModel itemInput = input.List[i];
                            itemInput.PurchaseId = purchaseId;
                            itemInput.HighID = input.HighID;
                            itemInput.UserOrgID = input.BuyerOrgid;
                            itemInput.Createid = input.CreateUserid;
                            itemInput.Createname = input.CreateUsername;
                            itemInput.ModifyUserid= input.ModifyUserid;
                            itemInput.ModifyUsername = input.ModifyUsername;
                            flag = SavePurchaseItemOffline(itemInput, transaction, userid); ;
                        }
                    }

                    //-------------------------同步采购单计划采购金额----------------------------
                    outInput = EditSavePurchaseOffline(input, transaction);

                    //-------------------------同一提交事务，根据更新明细返回的flag结构----------
                    if (flag)
                    {
                        base.DbFacade.CommitTransaction(transaction);
                    }
                    else
                    {
                        base.DbFacade.RollbackTransaction(transaction);
                    }

                }
                catch (Exception e)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw e;
                }
            }
            return outInput;

        }
        #endregion
        //add by yanbing 2007-07-09 保存采购单名称,电话,备注
        //public void updateDetail(PurchaseSaveModel input, DbTransaction transaction)
        //{
        //    DbParameter[] paras = this.DbFacade.CreateParameterArray(3);


        //    paras[0].ParameterName = "purchase_name";
        //    paras[0].DbType = DbType.String;
        //    paras[0].Value = input.PurchaseName;

        //    paras[1].ParameterName = "buyer_link_tel";
        //    paras[1].DbType = DbType.String;
        //    paras[1].Value = (input.BuyerLinkTel == null ? "" : input.BuyerLinkTel);

        //    paras[2].ParameterName = "id";
        //    paras[2].DbType = DbType.String;
        //    paras[2].Value = input.PurchaseId;

        //    base.DbFacade.SQLExecuteNonQuery(GetEditDetailPurchaseSqlOffline(), transaction, paras);
        //}
        //end add

        #region 新增保存采购单 离线　AddSavePurchaseOffline
        /// <summary>
        /// 新增保存采购单　离线
        /// </summary>
        /// <param name="input">PurchaseSaveModel</param>
        /// <returns>返回采购单ID</returns>
        public String AddSavePurchaseOffline(PurchaseSaveModel input, DbTransaction transaction)
        {
            String puchaseId = "";
            int result;
            //using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            //{
            //try
            //{
            //-------------------------新增保存------------------------------------------
            if (1 == 1)
            {
                input.PurchaseId = base.GetClientId(input.HighID).ToString();
                input.PurchaseCode = base.GetClientCode(input.HighID);

                DbParameter[] paraPurchase = this.DbFacade.CreateParameterArray(5);

                paraPurchase[0].ParameterName = "id";
                paraPurchase[0].DbType = DbType.String;
                paraPurchase[0].Value = input.PurchaseId;

                paraPurchase[1].ParameterName = "purchase_code";
                paraPurchase[1].DbType = DbType.String;
                paraPurchase[1].Value = input.PurchaseCode;

                paraPurchase[2].ParameterName = "buyer_orgid";
                paraPurchase[2].DbType = DbType.String;
                paraPurchase[2].Value = input.BuyerOrgid;

                paraPurchase[3].ParameterName = "create_userid";
                paraPurchase[3].DbType = DbType.String;
                paraPurchase[3].Value = input.CreateUserid;

                paraPurchase[4].ParameterName = "create_username";
                paraPurchase[4].DbType = DbType.String;
                paraPurchase[4].Value = input.CreateUsername;

                //paraPurchase[5].ParameterName = "purchase_remark";
                //paraPurchase[5].DbType = DbType.String;
                //paraPurchase[5].Value = input.PurchaseRemark;


                result = DbFacade.SQLExecuteNonQuery(GetAddPurchaseSqlOffline(), transaction, paraPurchase);


            //}
            //catch (Exception e)
            //{
            //    base.DbFacade.RollbackTransaction(transaction);
            //    throw e;
            //}


                if (result > 0)
                {
                    puchaseId = input.PurchaseId;
                }
                else
                {
                    puchaseId = "";
                    //base.DbFacade.RollbackTransaction(transaction);
                }
            }
            return puchaseId;

        }
        #endregion

        //public String GetEditDetailPurchaseSqlOffline()
        //{
        //    String sqlupt = "update gpo_purchase gp set purchase_name=:purchase_name,buyer_link_tel=:buyer_link_tel where gp.Id = :id ";
        //    return sqlupt;

        //}


        #region 新增采购单SQL 离线　GetAddPurchaseSqlOffline
        /// <summary>
        /// 新增采购单SQL
        /// </summary>
        /// <param name="input">PurchaseSaveModel</param>
        /// <returns>返回SQL</returns>
        public String GetAddPurchaseSqlOffline()
        {
            StringBuilder sql = new StringBuilder("");
            sql.Append("INSERT INTO HC_ORD_PURCHASE ( ");
            sql.Append("  ID,BUYER_ID,CODE,TYPE,TOTAL_SUM,CREATE_USER_ID");
            sql.Append(" ,CREATE_USER_NAME,STATE,QUICKSEND_LEVEL,CREATE_DATE,");
            sql.Append("  MODIFY_USER_ID,MODIFY_USER_NAME,SYNC_STATE,MODIFY_DATE)");
            sql.Append(" values ");
            sql.Append("( @id,@buyer_orgid,@purchase_code,'1',0,@create_userid,");
            sql.Append("  @create_username,'1','1','").Append(DateTime.Now);
            sql.Append(" ',@create_userid,@create_username,'0','").Append(DateTime.Now).Append("')");
            return sql.ToString();

        }
        #endregion

        #region 更新保存采购单 离线　EditSavePurchaseOffline  同步采购单计划采购金额
        /// <summary>
        /// 更新保存采购单 离线
        /// </summary>
        /// <param name="input">PurchaseSaveModel</param>
        /// <returns>返回处理结果</returns>
        public PurchaseSaveModel EditSavePurchaseOffline(PurchaseSaveModel input, DbTransaction trans)
        {
            PurchaseSaveModel outinput = new PurchaseSaveModel();
            //using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            //{
            //try
            //{
            String _reqestTotal = GetTotalRequestQtyOffline(input.PurchaseId, trans);
            String _quickend = GetQuickendOffline(input.PurchaseId, trans);

            DbParameter[] paras = this.DbFacade.CreateParameterArray(7);


            paras[0].ParameterName = "request_total";
            paras[0].DbType = DbType.Decimal;
            paras[0].Value = _reqestTotal;

            paras[1].ParameterName = "id";
            paras[1].DbType = DbType.String;
            paras[1].Value = input.PurchaseId;
          
            paras[2].ParameterName = "modify_userId";
            paras[2].DbType = DbType.String;
            paras[2].Value = (input.ModifyUserid == null ? input.CreateUserid : input.ModifyUserid);

            paras[3].ParameterName = "modify_date";
            paras[3].DbType = DbType.AnsiString;
            paras[3].Value = Convert.ToString(DateTime.Now);

            paras[4].ParameterName = "modify_username";
            paras[4].DbType = DbType.String;
            paras[4].Value = (input.ModifyUsername == null ? input.CreateUsername : input.ModifyUsername);

            paras[5].ParameterName = "quicksend_level";
            paras[5].DbType = DbType.Decimal;
            paras[5].Value = _quickend;

            paras[6].ParameterName = "STATE";
            paras[6].DbType = DbType.String;
            paras[6].Value = input.State;

           

            base.DbFacade.SQLExecuteNonQuery(GetEditPurchaseSqlOffline(), trans, paras);
            outinput.PurchaseId = input.PurchaseId;
            outinput.PurchaseRemark = input.PurchaseRemark;
            outinput.BuyerLinkTel = input.BuyerLinkTel;
            outinput.PurchaseCode = input.PurchaseCode;
            outinput.RequestTotal = _reqestTotal;
            outinput.CreateDate = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            outinput.CreateUsername = input.CreateUsername;
            outinput.ModifyUserid = input.ModifyUserid;
            outinput.ModifyUsername = input.ModifyUsername;
            outinput.ModifyDate = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();

            //base.DbFacade.CommitTransaction(transaction);

            //}
            //catch (Exception)
            //{
            //    base.DbFacade.RollbackTransaction(trans);
            //    throw;
            //}
            //}

            return outinput;

        }
        #endregion
        #region 修改采购单SQL  离线 GetEditPurchaseSqlOffline
        /// <summary>
        /// 修改采购单SQL　离线
        /// </summary>
        /// <param name="input">PurchaseSaveModel</param>
        /// <returns>返回SQL</returns>
        public String GetEditPurchaseSqlOffline()
        {
            String sqlupt = "update HC_ORD_PURCHASE  set TOTAL_SUM = @request_total  ,MODIFY_USER_ID = @modify_userId,STATE = @STATE,"
                           + " MODIFY_DATE =@modify_date ,MODIFY_USER_NAME =@modify_username ,sync_state = '0',QUICKSEND_LEVEL=@quicksend_level where Id = @id ";
            return sqlupt;

        }
          #endregion


        #region 采购单累计计划采购金额　离线　 GetTotalRequestQtyOffline
        /// <summary>
        /// 采购单累计计划采购金额　离线

        /// </summary>
        public String GetTotalRequestQtyOffline(String purchaseId, DbTransaction transaction)
        {
            string t;
            DbParameter[] paras = this.DbFacade.CreateParameterArray(1);
            paras[0].ParameterName = "purchaseId";
            paras[0].DbType = DbType.String;
            paras[0].Value = purchaseId;

            StringBuilder sql = new StringBuilder("select ");
            sql.Append(" SUM((case when AMOUNT  is null then 0 else AMOUNT end) * (case when TRADE_PRICE is null  then 0 else TRADE_PRICE end)) as total ");
            sql.Append("  from HC_ORD_PURCHASE_ITEM ");
            sql.Append(" where  purchase_id =@purchaseId");

            t= base.DbFacade.SQLExecuteScalar(sql.ToString(), transaction, paras).ToString();

            if (string.IsNullOrEmpty(t))
            {
                t="0";
             }

             return t;
                

        }
        #endregion
        #region 获取紧急程度　离线　 GetQuickendOffline
        /// <summary>
        /// 获取紧急程度　离线

        /// </summary>
        public String GetQuickendOffline(String purchaseId, DbTransaction transaction)
        {
            string t;
            DbParameter[] paras = this.DbFacade.CreateParameterArray(1);
            paras[0].ParameterName = "purchaseId";
            paras[0].DbType = DbType.String;
            paras[0].Value = purchaseId;

            StringBuilder sql = new StringBuilder("select ");
            sql.Append(" case when count(1)=(select count(1) from HC_ORD_PURCHASE_ITEM where purchase_id =@purchaseId and IS_QUICKSEND='1') then 3 when count(1)=  ");
            sql.Append(" (select count(1) from HC_ORD_PURCHASE_ITEM where purchase_id =@purchaseId and IS_QUICKSEND='0') then 1 else 2 end  from HC_ORD_PURCHASE_ITEM ");
            sql.Append(" where  purchase_id =@purchaseId");

            t = base.DbFacade.SQLExecuteScalar(sql.ToString(), transaction, paras).ToString();

            return t;


        }
        #endregion



        /// <summary>
        /// 判断该项目中产品是否已添加到常用采购目录中
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <returns></returns>
        public bool OrdHitCommIsAdd(PurchaseItemSaveModel model,DbTransaction transaction)
        {
            bool flag = true;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                Count(1) 
                                From HC_ORD_HIT_COMM 
                                Where PROJECT_PROD_ID='{0}' And SPEC_ID='{1}' And MODEL_ID='{2}'", model.Projectprodid, model.SpecId, model.ModelId);

            try
            {
                int Count = Convert.ToInt16(DbFacade.SQLExecuteScalar(strSql.ToString(),transaction).ToString());
                if (Count > 0)
                {
                    //已添加
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;

        }







    }
}

