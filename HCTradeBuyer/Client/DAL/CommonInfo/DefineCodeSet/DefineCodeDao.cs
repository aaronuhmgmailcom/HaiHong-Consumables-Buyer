//=====================================================================================
//	Copyright (c)  Emedchina
//
//	文 件 名:	DefineCodeDao.cs   
//	创 建 人:	罗澜涛
//	创建日期:	2007-10
//	功能描述:	自定义编码设置（数据访问类）
//	修 改 人: 
//	修改日期:
//=====================================================================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using Emedchina.Commons;
using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Client.BLL;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.CommInfo;

namespace Emedchina.TradeAssistant.Client.DAL.CommonInfo
{
    /// <summary>
    /// 自定义编码设置（数据访问类）
    /// </summary>
    class DefineCodeDao : SqlDAOBase
    {
        private DefineCodeDao()
        : base()
        { }

        private DefineCodeDao(string connectionName)
        : base(connectionName)
        { }

        public static DefineCodeDao GetInstance()
        {
            return new DefineCodeDao();
        }

        public static DefineCodeDao GetInstance(string connectionName)
        {
            return new DefineCodeDao(connectionName);
        }

        /// <summary>
        /// 获取自义定编码大包装信息列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDefineCodeDt(string ProjectID)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"Select 
                            ohc.ID As HIT_COMM_ID,
                            sdi.PRODUCT_MNEMONIC,
                            sdi.SELF_PACKAGE,
                            sdi.ALIAS,
                            sdi.ALIAS_PINYIN,
                            ohc.PROJECT_ID,
                            ohc.PRODUCT_NAME,
                            ohc.COMMERCE_NAME,
                            ohc.COMMON_NAME,
                            ohc.SPEC,
                            ohc.MODEL,
                            ohc.BRAND,
                            ohc.SENDER_ID,
                            org1.ORG_ABBR As SENDER_NAME_ABBR,
                            org1.ORG_NAME As SENDER_NAME,
                            org2.ORG_ABBR As MANU_NAME_ABBR,
                            org2.ORG_NAME As MANU_NAME,
                            ohc.PRICE
                            From (Select * From HC_ORD_HIT_COMM ohc Where ohc.PROJECT_ID=@PROJECT_ID) As ohc
                            Left join HC_ORG org1 On org1.ID=ohc.SENDER_ID
                            Left join HC_ORG org2 On org2.ID=ohc.MANU_ID
                            Left join hc_self_define_info sdi
                            On ohc.ID=sdi.HIT_COMM_ID");

            if (!string.IsNullOrEmpty(ProjectID))
            {
                DbParameter strProjectID = DbFacade.CreateParameter();
                strProjectID.ParameterName = "PROJECT_ID";
                strProjectID.DbType = DbType.String;
                strProjectID.Value = ProjectID;
                parameters.Add(strProjectID);
            }

            try
            {
                dt = base.DbFacade.SQLExecuteDataTable(strSql.ToString(), parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        #region 自定义编码及大包装操作

        /// <summary>
        /// 自定义编码及大包装操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void OperatorDefineInfoList(List<DefineInfoModel> Listmodel, LogedInUser logedinUser)
        {
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    foreach (DefineInfoModel model in Listmodel)
                    {
                        OperatorDefineInfo(model, logedinUser, transaction);
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
        /// 自定义编码及大包装操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void OperatorDefineInfo(DefineInfoModel model, LogedInUser logedinUser, DbTransaction transaction)
        {

            try
            {
                //判断该产品ID是否已添加 是则进入修改 否则进入新增方法
                if (!DefineCodeIsAddProductId(model, transaction))
                {
                    InsertDefineInfo(model, logedinUser, transaction);
                }
                else
                {
                    ModifyDefineInfo(model, logedinUser, transaction);
                }
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
        public void InsertDefineInfo(DefineInfoModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            int result = 0;
            //生成本地ID
            string strId = base.GetClientId(logedinUser.HighId).ToString();
            string strOrgId = logedinUser.UserOrg.Id;

            StringBuilder strSql = new StringBuilder();

            strSql.Append("Insert Into hc_self_define_info");
            strSql.Append(" (");
            strSql.Append("ID, ORGID, HIT_COMM_ID, PRODUCT_MNEMONIC, SELF_PACKAGE, ALIAS, ALIAS_PINYIN, MODIFY_USERID, MODIFY_DATE, SYNC_STATE");
            strSql.Append(")");
            strSql.Append(" Values");

            strSql.Append("(");
            strSql.AppendFormat("'{0}',", strId);
            strSql.AppendFormat("'{0}',", strOrgId);
            strSql.AppendFormat("'{0}',", model.Hit_Comm_Id);
            strSql.AppendFormat("'{0}',", model.ProductMnemonic);
            strSql.AppendFormat("'{0}',", model.SelfPackage);
            strSql.AppendFormat("'{0}',", model.Alias);
            strSql.AppendFormat("'{0}',", model.AliasPinyin);
            strSql.AppendFormat("'{0}',", logedinUser.UserInfo.Id);
            strSql.AppendFormat("'{0}',", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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


        /// <summary>
        /// 自定义编码及大包装修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void ModifyDefineInfo(DefineInfoModel model, LogedInUser logedinUser, DbTransaction transaction)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Update hc_self_define_info ");
            strSql.Append("Set ");
            strSql.Append(" SYNC_STATE='0'");
            strSql.AppendFormat(",PRODUCT_MNEMONIC='{0}'", model.ProductMnemonic);
            strSql.AppendFormat(",SELF_PACKAGE='{0}'", model.SelfPackage);
            strSql.AppendFormat(",ALIAS='{0}'", model.Alias);
            strSql.AppendFormat(",ALIAS_PINYIN='{0}'", model.AliasPinyin);
            strSql.AppendFormat(",MODIFY_USERID='{0}'", logedinUser.UserInfo.Id);
            strSql.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToShortDateString());
            strSql.AppendFormat(" Where HIT_COMM_ID='{0}'", model.Hit_Comm_Id);

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
        /// 判断自定义编码产品表中该产品是否已添加
        /// </summary>
        /// <param name="productcode"></param>
        /// <returns></returns>
        public bool DefineCodeIsAddProductId(DefineInfoModel model, DbTransaction transaction)
        {
            bool flag = false;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                Count(1) 
                                From hc_self_define_info 
                                Where HIT_COMM_ID='{0}'", model.Hit_Comm_Id);

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
        /// 判断自定义编码表中 编码是否已存在
        /// </summary>
        /// <param name="strProductMnemonic"></param>
        /// <param name="strHit_Comm_Id"></param>
        /// <returns></returns>
        public bool DefineCodeIsAddProductMnemonic(string strProductMnemonic,string strHit_Comm_Id)
        {
            bool flag = false;

            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(@"Select 
                                Count(1) 
                                From hc_self_define_info 
                                Where PRODUCT_MNEMONIC='{0}'", strProductMnemonic);

            if (!string.IsNullOrEmpty(strHit_Comm_Id))
            {
                strSql.AppendFormat("  And HIT_COMM_ID<>'{0}'",strHit_Comm_Id);
            }

            try
            {
                int Count = Convert.ToInt16(DbFacade.SQLExecuteScalar(strSql.ToString()).ToString());
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

        #endregion

    }
}
