//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	StockListDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	常用可采购目录维护（数据访问类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 常用可采购目录维护（数据访问类）
    /// </summary>
    class StockListDao : SqlDAOBase
    {
        private StockListDao()
        : base()
        { }

        private StockListDao(string connectionName)
        : base(connectionName)
        { }

        public static StockListDao GetInstance()
        {
            return new StockListDao();
        }

        public static StockListDao GetInstance(string connectionName)
        {
            return new StockListDao(connectionName);
        }

        /// <summary>
        /// 获取经常可采购目录
        /// </summary>
        /// <param name="logedinUser"></param>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public DataTable GetStockList(LogedInUser logedinUser, string ProjectID, string strDataName)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select Ohc.*,
                            Sdi.PRODUCT_MNEMONIC,
                            Sdi.SELF_PACKAGE,
                            Sdi.ALIAS,
                            Sdi.ALIAS_PINYIN
                            From
                            (
                            Select
                            ohc.ID,
                            ohc.MANU_ID,
                            ohc.SALER_ID,
                            ohc.SENDER_ID,
                            pro.ID As PROJECT_ID,
                            pro.PROJECT_TYPE,
                            (case pro.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name,
                            ppcc.CLASS_ID,
                            op.ID As PROJECT_PRODUCT_ID,
                            op.DATA_PRODUCT_ID,
                            op.COMMERCE_NAME,
                            op.PRODUCT_NAME,
                            op.COMMON_NAME,
                            op.ABBR_PY,
                            op.ABBR_WB,
                            ohc.SPEC,
                            ohc.MODEL,
                            ohc.BRAND,
                            ohc.REG_NO,
                            ohc.REG_VALID_DATE,
                            org1.ORG_NAME As MANU_NAME,
                            org1.ORG_ABBR As MANU_NAME_ABBR,
                            org1.SPELL_ABBR As MANU_NAME_SPELL_ABBR,
                            org1.ORG_NAME_WB As MANU_NAME_WB,
                            org2.ORG_NAME As SALER_NAME,
                            org2.ORG_ABBR As SALER_NAME_ABBR,
                            org2.SPELL_ABBR As SALER_NAME_SPELL_ABBR,
                            org2.ORG_NAME_WB As SALER_NAME_WB,
                            org3.ORG_NAME As SENDER_NAME,
                            org3.ORG_ABBR As SENDER_NAME_ABBR,
                            org3.SPELL_ABBR As SENDER_NAME_SPELL_ABBR,
                            org3.ORG_NAME_WB As SENDER_NAME_WB,
                            ohc.DEFAULT_MEASURE,
                            ohc.PRICE,
                            op.STATE,
                            (case op.STATE when '0' then '不可用' when '1' then '可用' end) As StateName,
                            hbs.STORE_NAME As STORE_ROOM_NAME
                            From HC_ORD_HIT_COMM ohc,HC_ORD_PROJECT pro,HC_PROJECT_PROD_CLASS_CONTENT ppcc,HC_ORD_PRODUCT op,HC_ORG org1,HC_ORG org2,HC_ORG org3
                            ,HC_BUYER_STORE hbs
                            Where ohc.PROJECT_PROD_ID=op.Id And pro.Id = op.PROJECT_ID And  ppcc.PROJECT_ID=op.PROJECT_ID And ppcc.PRODUCT_ID=op.ID 
                            And ohc.MANU_ID=org1.ID And ohc.SALER_ID=org2.ID And ohc.SENDER_ID =org3.Id
                            And op.STATE='1'
                            And hbs.ID=ohc.STORE_ROOM_ID And op.PROJECT_ID=@PROJECT_ID
                            ) As ohc
                            Left Join HC_SELF_DEFINE_INFO Sdi on Ohc.ID=sdi.HIT_COMM_ID
                            ");

            DbParameter strProjectID = DbFacade.CreateParameter();
            strProjectID.ParameterName = "PROJECT_ID";
            strProjectID.DbType = DbType.String;
            strProjectID.Value = ProjectID;
            parameters.Add(strProjectID);

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), strDataName, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
            
        }

        /// <summary>
        /// 保存采购目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void SaveOrdHitCommListModel(List<OrdHitCommMode> Listmodel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (OrdHitCommMode model in Listmodel)
                    {
                        //不存在采购目录表中，并且该项目产品所属分类可允许发货流程
                        if (!OrdHitCommIsAdd(model, transaction) && IsOrdFlagByProductIDAndSalerID(model,transaction))
                        {
                            model.Id =  base.GetClientId(logedinUser.HighId).ToString();
                            //保存到经常采购目录表
                            SaveOrdHitCommModel(model, logedinUser, transaction);
                            //插入自定义编码设置表
                            InsertDefineInfo(model, logedinUser, transaction);
                        }
                    }

                    base.DbFacade.CommitTransaction(transaction);

                }
                catch (Exception ex)
                {
                    base.DbFacade.RollbackTransaction(transaction);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 保存采购目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void SaveOrdHitCommModel(OrdHitCommMode model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Insert Into HC_ORD_HIT_COMM(
                            ID,
                            PROJECT_ID,
                            PROJECT_PROD_ID,
                            DATA_PRODUCT_ID,
                            SPEC_ID,
                            MODEL_ID,
                            SPEC,
                            MODEL,
                            BASE_MEASURE,
                            MANU_NAME,
                            SALER_NAME,
                            COMMERCE_NAME,
                            COMMON_NAME,
                            PRODUCT_NAME,
                            ABBR_PY,
                            ABBR_WB,
                            BRAND,
                            PRICE,
                            CODE,
                            GOODS_NO,
                            BARCODE,
                            BASE_MEASURE_SPEC,
                            BASE_MEASURE_MATER,
                            MAX_PRICE,
                            MANU_ID,
                            SALER_ID,
                            SENDER_ID,
                            SENDER_NAME,
                            SENDER_NAME_ABBR,
                            STORE_ROOM_ID,
                            STORE_ROOM_NAME,
                            MANU_NAME_ABBR,
                            Buyer_Id,
                            SALER_NAME_ABBR,
                            DEFAULT_MEASURE,
                            DEFAULT_MEASURE_EX,
                            STATE,
                            INSTRU_CODE,
                            INSTRU_NAME,
                            CREATE_USER_ID,
                            CREATE_USER_NAME,
                            CREATE_DATE,
                            MODIFY_USER_ID,
                            MODIFY_USER_NAME,
                            MODIFY_DATE,
                            REG_NO,
                            REG_VALID_DATE,
                            SYNC_STATE
                            )");
            strSql.Append(" Values (");
            strSql.AppendFormat("{0},", model.Id);
            strSql.AppendFormat("{0},", model.Project_Id);
            strSql.AppendFormat("{0},", model.Project_Product_Id);
            strSql.AppendFormat("{0},", model.Data_Product_Id);
            strSql.AppendFormat("'{0}',", model.Spec_Id);
            strSql.AppendFormat("'{0}',", model.Model_Id);
            strSql.AppendFormat("'{0}',", model.Spec);
            strSql.AppendFormat("'{0}',", model.Model);
            strSql.AppendFormat("'{0}',", model.Measure);
            strSql.AppendFormat("'{0}',", model.ManuName);
            strSql.AppendFormat("'{0}',", model.SalerName);
            strSql.AppendFormat("'{0}',", model.Commerce_Name);
            strSql.AppendFormat("'{0}',", model.Common_Name);
            strSql.AppendFormat("'{0}',", model.Product_Name);
            strSql.AppendFormat("'{0}',", model.Abbr_py);
            strSql.AppendFormat("'{0}',", model.Abbr_wb);
            strSql.AppendFormat("'{0}',", model.Brand);
            strSql.AppendFormat("'{0}',", model.Price);
            strSql.AppendFormat("'{0}',", model.Code);
            strSql.AppendFormat("'{0}',", model.GoodsNo);
            strSql.AppendFormat("'{0}',", model.Barcode);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Spec);
            strSql.AppendFormat("'{0}',", model.Base_Measure_Mater);
            strSql.AppendFormat("'{0}',", model.Max_Price);
            strSql.AppendFormat("'{0}',", model.Manu_Id);
            strSql.AppendFormat("'{0}',", model.Saler_Id);
            strSql.AppendFormat("'{0}',", model.Sender_Id);
            strSql.AppendFormat("'{0}',", model.SenderName);
            strSql.AppendFormat("'{0}',", model.SenderNameAbbr);
            strSql.AppendFormat("'{0}',", model.Store_Room_Id);
            strSql.AppendFormat("'{0}',", model.StoreRoomName);
            strSql.AppendFormat("'{0}',", model.ManuNameAbbr);
            strSql.AppendFormat("'{0}',", logedinUser.UserOrg.Id);
            strSql.AppendFormat("'{0}',", model.SalerNameAbbr);
            strSql.AppendFormat("'{0}',", model.Measure);
            strSql.AppendFormat("{0},", model.DefaultMeasureEx);
            strSql.Append("'1',");
            strSql.AppendFormat("'{0}',", model.Instru_Code);
            strSql.AppendFormat("'{0}',", model.Instru_Name);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Name);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.AppendFormat("'{0}',", model.RegNo);
            strSql.AppendFormat("'{0}',", model.RegValidDate);
            strSql.Append("'0'");
            strSql.Append(")");

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 删除采购供应目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public void DelOrdHitCommModel(string strId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat("Delete From Hc_ORD_HIT_COMM Where ID='{0}'", strId);

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

#region 获取采购目录对象

        /// <summary>
        /// 获取采购目录对象
        /// </summary>
        /// <param name="HitCommID"></param>
        /// <returns></returns>
        public OrdHitCommMode GetOrdHitCommModel(string HitCommID)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"Select Ohc.*,
                            Sdi.PRODUCT_MNEMONIC,
                            Sdi.SELF_PACKAGE,Sdi.ALIAS,Sdi.ALIAS_PINYIN From 
                            (Select
                            h.PROJECT_ID,
                            h.ID,
                            p.PROJECT_TYPE, 
                            (case p.PROJECT_TYPE when '1' then '招投标' when '2' then '备案采购' when '3' then '竞价采购' when '4' then '浏览采购' end) As PROJECT_TYPE_Name, 
                            h.PROJECT_PROD_ID,
                            h.COMMERCE_NAME, 
                            h.COMMON_NAME, 
                            h.PRODUCT_NAME, 
                            h.SPEC, 
                            h.MODEL, 
                            h.BRAND, 
                            h.DEFAULT_MEASURE, 
                            h.DEFAULT_MEASURE_EX, 
                            h.PRICE, 
                            h.MANU_NAME, 
                            h.SALER_NAME, 
                            org1.ID As SENDER_ID,
                            org1.ORG_NAME As SENDER_NAME, 
                            h.STORE_ROOM_ID,
                            h.STORE_ROOM_NAME,
                            h.REG_NO,
                            h.REG_VALID_DATE,
                            ppc.CLASS_NAME
                            From HC_ORD_HIT_COMM h,HC_ORD_PROJECT p,HC_ORG org1,
                            HC_PROJECT_PROD_CLASS_CONTENT ppcc,HC_PROJECT_PRODUCT_CLASS ppc
                            Where h.PROJECT_ID= p.ID And org1.ID=h.SENDER_ID And h.ID=@HitCommID And ppcc.CLASS_ID=ppc.ID
                            And h.PROJECT_PROD_ID=ppcc.PRODUCT_ID
                            ) As Ohc
                            Left Join hc_self_define_info sdi on Ohc.ID=sdi.HIT_COMM_ID");

            if (!string.IsNullOrEmpty(HitCommID))
            {
                DbParameter strHitCommID = DbFacade.CreateParameter();
                strHitCommID.ParameterName = "HitCommID";
                strHitCommID.DbType = DbType.String;
                strHitCommID.Value = HitCommID;
                parameters.Add(strHitCommID);
            }
            else
            {
                return null;
            }

            OrdHitCommMode model = null;

            try
            {
                model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(HitCommModel), parameters.ToArray()) as OrdHitCommMode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;

        }

        /// <summary>
        /// 采购目录信息对象
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="row">The row number.</param>
        /// <returns></returns>
        private object HitCommModel(IDataReader reader,int row)
        {
            OrdHitCommMode model = new OrdHitCommMode();
            model.Project_Id = Convert.ToString(reader["PROJECT_ID"]);
            model.Id = Convert.ToString(reader["ID"]);
            model.Project_Product_Id = Convert.ToString(reader["PROJECT_PROD_ID"]);
            model.Product_Name = Convert.ToString(reader["PRODUCT_NAME"]);
            model.Class_Name = "";//Convert.ToString(reader["Class_Name"]);
            model.Spec = Convert.ToString(reader["SPEC"]);
            model.Model = Convert.ToString(reader["MODEL"]);
            model.Sender_Id = Convert.ToString(reader["SENDER_ID"]);
            model.SenderName = Convert.ToString(reader["SENDER_NAME"]);
            model.Measure = Convert.ToString(reader["DEFAULT_MEASURE"]);
            model.DefaultMeasureEx = Convert.ToString(reader["DEFAULT_MEASURE_EX"]);
            model.Store_Room_Id = Convert.ToString(reader["STORE_ROOM_ID"]);
            model.StoreRoomName = Convert.ToString(reader["STORE_ROOM_NAME"]);
            model.Price = Convert.ToString(reader["PRICE"]);
            model.SalerName = Convert.ToString(reader["SALER_NAME"]);
            model.ManuName = Convert.ToString(reader["MANU_NAME"]);
            model.RegNo = Convert.ToString(reader["REG_NO"]);
            model.RegValidDate = Convert.ToString(reader["REG_VALID_DATE"]);
            model.Class_Name = Convert.ToString(reader["CLASS_NAME"]);

            model.ProductMnemonic = Convert.ToString(reader["PRODUCT_MNEMONIC"]);
            model.SelfPackage = Convert.ToString(reader["SELF_PACKAGE"]);
            model.Alias = Convert.ToString(reader["ALIAS"]);
            model.AliasPinyin = Convert.ToString(reader["ALIAS_PINYIN"]);

            return model;
        }

#endregion


        /// <summary>
        /// 判断该项目中产品是否已添加到常用采购目录中
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <returns></returns>
        public bool OrdHitCommIsAdd(OrdHitCommMode model, DbTransaction transaction)
        {
            bool flag = false;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                Count(1) 
                                From HC_ORD_HIT_COMM 
                                Where PROJECT_PROD_ID='{0}' And SPEC_ID='{1}' And MODEL_ID='{2}'", model.Project_Product_Id, model.Spec_Id, model.Model_Id);

            try
            {
                int Count = Convert.ToInt16(DbFacade.SQLExecuteScalar(strSql.ToString(), transaction).ToString());
                if (Count > 0)
                {
                    //已添加
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        /// <summary>
        /// 判断该项目中产品分类是否 允许订单流程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logedinUser"></param>
        /// <returns></returns>
        public bool IsOrdFlagByProductIDAndSalerID(OrdHitCommMode model, DbTransaction transaction)
        {
            bool flag = false;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                  COUNT(1) 
                                  From HC_PROJECT_PROD_CLASS_CONTENT ppcc,HC_PROJECT_PROD_CLASS_CONFIG pcc
                                  Where ppcc.CLASS_ID=pcc.CLASS_ID And pcc.ORDER_FLAG='1' 
                                  And ppcc.PRODUCT_ID='{0}' And pcc.SALER_ID='{1}'",model.Project_Product_Id,model.Saler_Id);

            try
            {
                int Count = Convert.ToInt16(DbFacade.SQLExecuteScalar(strSql.ToString(), transaction).ToString());
                if (Count > 0)
                {
                    //允许订单流程
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        /// <summary>
        /// 保存采购目录信息（库房、配送商）
        /// </summary>
        /// <param name="model"></param>
        public void PostOrdHitCommInfo(OrdHitCommMode model, LogedInUser logedinUser)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Update 
                                HC_ORD_HIT_COMM
                                Set STORE_ROOM_ID={0},
                                STORE_ROOM_NAME='{1}',
                                SENDER_ID={2},
                                SENDER_NAME='{3}',
                                MODIFY_USER_ID={4},
                                MODIFY_USER_NAME='{5}',
                                MODIFY_DATE='{6}'
                                Where ID={7}", 
                                model.Store_Room_Id, 
                                model.StoreRoomName, 
                                model.Sender_Id, 
                                model.SenderName,
                                logedinUser.UserInfo.Id,
                                logedinUser.UserInfo.Name,
                                DateTime.Now.ToString(),
                                model.Id
                                );

            try
            {
                base.DbFacade.SQLExecuteNonQuery(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 自定义编码及大包装保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void InsertDefineInfo(OrdHitCommMode model, LogedInUser logedinUser, DbTransaction transaction)
        {
            int result = 0;
            //生成本地ID
            string strId = base.GetClientId(logedinUser.HighId).ToString();
            string strOrgId = logedinUser.UserOrg.Id;
            //大包装默认为1
            if (string.IsNullOrEmpty(model.SelfPackage))
                model.SelfPackage = "1";

            StringBuilder strSql = new StringBuilder();

            strSql.Append("Insert Into hc_self_define_info");
            strSql.Append(" (");
            strSql.Append("ID, ORGID, HIT_COMM_ID, PRODUCT_MNEMONIC, SELF_PACKAGE, ALIAS, ALIAS_PINYIN, MODIFY_USERID, MODIFY_DATE, SYNC_STATE");
            strSql.Append(")");
            strSql.Append(" Values");

            strSql.Append("(");
            strSql.AppendFormat("'{0}',", strId);
            strSql.AppendFormat("'{0}',", strOrgId);
            strSql.AppendFormat("'{0}',", model.Id);
            strSql.AppendFormat("'{0}',", model.ProductMnemonic);
            strSql.AppendFormat("'{0}',", model.SelfPackage);
            strSql.AppendFormat("'{0}',", model.Alias);
            strSql.AppendFormat("'{0}',", model.AliasPinyin);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString());
            strSql.Append("'0'");
            strSql.Append(")");

            try
            {
                result = base.DbFacade.SQLExecuteNonQuery(strSql.ToString(), transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
