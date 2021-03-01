//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	WarehouseMgrDAO.cs    
//	创 建 人:	yanbing
//	创建日期:	2007-9-28
//	功能描述:	库房信息（数据访问类）
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Model.DataMaintenance;
using Emedchina.TradeAssistant.Model.CommInfo;
using Emedchina.Commons;

namespace Emedchina.TradeAssistant.Client.DAL.DataMaintenance
{
    /// <summary>
    /// 库房信息（数据访问类）
    /// </summary>
    class WarehouseMgrDAO : SqlDAOBase
    {
        private WarehouseMgrDAO()
            : base()
        { }

        private WarehouseMgrDAO(string connectionName)
            : base(connectionName)
        { }

        public static WarehouseMgrDAO GetInstance()
        {
            return new WarehouseMgrDAO();
        }

        public static WarehouseMgrDAO GetInstance(string connectionName)
        {
            return new WarehouseMgrDAO(connectionName);
        }

        /// <summary>
        /// 获取库房信息数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetWarehouseInfoDt(LogedInUser logedinUser)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            DataTable dt = null;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select ID,STORE_NAME,STORE_ADDRESS,LINKMAN,CREATE_USER_NAME,CREATE_USER_ID");
            strSql.Append(" CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,ORG_ID,ENABLE_FLAG,(case ENABLE_FLAG when '0' then '不可用' when '1' then '可用' end) as state,TEL, ");
            strSql.Append(" type,(case type when '1' then '普通' when '2' then '其它' end) as  RoomType,sync_state from HC_BUYER_STORE where 1=1");

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

        /// <summary>
        /// 获取库房信息对象
        /// </summary>
        /// <param name="Hc_Id"></param>
        /// <returns></returns>
        //public WarehouseModel GetWarehouseInfoModel(string Hc_Id)
        //{
        //    List<DbParameter> parameters = new List<DbParameter>();

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("Select");
        //    strSql.Append(" bi.ID,");
        //    strSql.Append(" bi.Title,");
        //    strSql.Append(" bi.CONTENT,");
        //    strSql.Append(" br.IS_READ,");
        //    strSql.Append(" (case br.IS_READ when '0' then '已阅读' when '1' then '未阅读' end) As ReadName,");
        //    strSql.Append(" bi.ISSUER_ID,");
        //    strSql.Append(" bi.ISSUER_NAME,");
        //    strSql.Append(" bi.ISSUE_DATE");
        //    strSql.Append(" From HC_BULLETIN_INFO bi,HC_BULLETIN_RECEIVER br");
        //    strSql.Append(" Where bi.ID=br.HC_ID");

        //    if (!string.IsNullOrEmpty(Hc_Id))
        //    {
        //        strSql.Append(" and bi.ID=:hc_id");
        //        DbParameter strhc_id = DbFacade.CreateParameter();
        //        strhc_id.ParameterName = "hc_id";
        //        strhc_id.DbType = DbType.String;
        //        strhc_id.Value = Hc_Id;
        //        parameters.Add(strhc_id);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    BulletinInfoModel model = null;

        //    model = base.DbFacade.SQLExecuteObject(strSql.ToString(), new MapRow(GetBulletinInfoModel), parameters.ToArray()) as BulletinInfoModel;

        //    return model;
        //}

        /// <summary>
        /// 采购目录信息对象
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object GetBulletinInfoModel(IDataReader reader, int row)
        {
            BulletinInfoModel model = new BulletinInfoModel();
            model.Id = Convert.ToString(reader["ID"]);
            model.Title = Convert.ToString(reader["Title"]);
            model.Content = Convert.ToString(reader["Content"]);
            model.IsRead = Convert.ToString(reader["IS_READ"]);
            model.ReadName = Convert.ToString(reader["ReadName"]);
            model.IsSuerId = Convert.ToString(reader["ISSUER_ID"]);
            model.IsSuerName = Convert.ToString(reader["ISSUER_NAME"]);
            model.IsSuerDate = Convert.ToString(reader["ISSUE_DATE"]);

            return model;
        }

        /// <summary>
        /// 判断库房名称函数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int JudgeCode(string code)
        {
            return int.Parse(base.DbFacade.SQLExecuteScalar(judgeCode(code)).ToString());
        }
        
        /// <summary>
        /// 判断库房名称函数--来至修改
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int ModiJudgeCode(string code)
        {
            return int.Parse(base.DbFacade.SQLExecuteScalar(modiJudgeCode(code)).ToString());
        }
        

        /// <summary>
        /// 判断库房enable_flag函数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int JudgeCanUse(string code)
        {
            return int.Parse(base.DbFacade.SQLExecuteScalar(JudgeIsCanUse(code)).ToString());
        }
        

        /// <summary>
        /// 判断库房名称函数sql
        /// </summary>
        /// <param name="code"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        private string judgeCode(string code)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(STORE_NAME) from HC_BUYER_STORE");
            sqlstr.AppendFormat(" where STORE_NAME='{0}'", code);

            return sqlstr.ToString();
        }

        /// <summary>
        /// 判断库房名称函数sql--来至修改
        /// </summary>
        /// <param name="code"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        private string modiJudgeCode(string code)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(STORE_NAME) from HC_BUYER_STORE");
            sqlstr.AppendFormat(" where STORE_NAME='{0}'", code);

            return sqlstr.ToString();
        }

        /// <summary>
        /// 判断库房enable_flag函数sql
        /// </summary>
        /// <param name="code"></param>
        /// <param name="MapOrgId"></param>
        /// <returns></returns>
        private string JudgeIsCanUse(string code)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("select count(STORE_NAME) from HC_BUYER_STORE");
            sqlstr.AppendFormat(" where id= {0} and ENABLE_FLAG ='1'", code);

            return sqlstr.ToString();
        }


        public string DeleteSQL(string strWarehouseId, LogedInUser CurrentUser)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("delete from HC_BUYER_STORE");
            //sb.AppendFormat(" where id='{0}'", strWarehouseId);

            sb.Append("update HC_BUYER_STORE");
            sb.Append(" set ENABLE_FLAG='0'");
           
            sb.AppendFormat(",MODIFY_USER_ID='{0}'", CurrentUser.HighId);
            sb.AppendFormat(",MODIFY_USER_NAME='{0}'", CurrentUser.UserInfo.Name);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            sb.Append(",SYNC_STATE='0'");

            sb.AppendFormat(" where id='{0}'", strWarehouseId);

            return sb.ToString();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mapId"></param>
        public void Delete(string strWarehouseId, LogedInUser logedinUser)
        {
           
            int rownum;
            string sql = DeleteSQL(strWarehouseId, logedinUser);

            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    rownum = base.DbFacade.SQLExecuteNonQuery(sql, transaction);
                    if (rownum > 0)
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
            
        }

        /// <summary>
        /// 增加库房信息
        /// </summary>
        /// <returns></returns>
        public void InsertWarehouseInfo(WarehouseModel input, LogedInUser CurrentUser)
        {
            int result;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result = base.DbFacade.SQLExecuteNonQuery(InsertWarehouseSQL(input,CurrentUser), transaction);
                    if (result > 0)
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

        }

        /// <summary>
        /// 增加库房信息SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string InsertWarehouseSQL(WarehouseModel input, LogedInUser CurrentUser)
        {
            StringBuilder sb = new StringBuilder();
            Int64 id = base.GetClientId(CurrentUser.HighId);//IdUtil.GetClientId(CurrentUser.HighId);
            sb.Append("insert  HC_BUYER_STORE( \r\n\t\t\t\t\t");
            sb.Append("ID,ORG_ID,STORE_NAME,STORE_ADDRESS,LINKMAN,CREATE_USER_ID,CREATE_USER_NAME,CREATE_DATE,MODIFY_USER_ID,MODIFY_USER_NAME,MODIFY_DATE,TEL,type,sync_state,ENABLE_FLAG\r\n");
            sb.Append(" ) values \r\n");
            sb.Append("(").Append(id).Append(",");

            sb.Append("").Append(CurrentUser.UserOrg.Id).Append(",");
            sb.Append("'").Append(input.StoneName).Append("',");
            sb.Append("'").Append(input.Stone_address).Append("',");
            sb.Append("'").Append(input.Linman).Append("',");
            sb.Append("").Append(CurrentUser.HighId).Append(",");
            sb.Append("'").Append(CurrentUser.UserInfo.Name).Append("',");


            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");

            sb.Append("").Append(CurrentUser.HighId).Append(",");
            sb.Append("'").Append(CurrentUser.UserInfo.Name).Append("',");


            sb.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',");
            sb.Append("'").Append(input.Linktel).Append("',");
            sb.Append("'").Append(input.Type).Append("',");
            sb.Append("'0','1')");
        
            return sb.ToString();

        }

        
        /// <summary>
        /// 修改库房信息
        /// </summary>
        /// <returns></returns>
        public void UpdateWarehouseInfo(WarehouseModel input, LogedInUser CurrentUser)
        {
            int result;
            using (DbTransaction transaction = base.DbFacade.BeginTransaction(base.DbFacade.OpenConnection()))
            {
                try
                {
                    result = base.DbFacade.SQLExecuteNonQuery(UpdateWarehouseInfoSQL(input, CurrentUser), transaction);
                    if (result > 0)
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

        }


        /// <summary>
        /// 修改库房信息SQL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string UpdateWarehouseInfoSQL(WarehouseModel input, LogedInUser CurrentUser)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update HC_BUYER_STORE");
           
            sb.AppendFormat(" set ORG_ID='{0}'", CurrentUser.UserOrg.Id);
            sb.AppendFormat(",STORE_NAME='{0}'", input.StoneName);
            sb.AppendFormat(",STORE_ADDRESS='{0}'", input.Stone_address);
            sb.AppendFormat(",LINKMAN='{0}'", input.Linman);
            sb.AppendFormat(",TEL='{0}'", input.Linktel);
            sb.AppendFormat(",type={0}", input.Type);
            sb.AppendFormat(",ENABLE_FLAG='{0}'", input.Enalbe_flag);
            sb.AppendFormat(",CREATE_USER_ID='{0}'", CurrentUser.HighId);
            sb.AppendFormat(",CREATE_USER_NAME='{0}'", CurrentUser.UserInfo.Name);
            sb.AppendFormat(",CREATE_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            sb.AppendFormat(",MODIFY_USER_ID='{0}'", CurrentUser.HighId);
            sb.AppendFormat(",MODIFY_USER_NAME='{0}'",  CurrentUser.UserInfo.Name);
            sb.AppendFormat(",MODIFY_DATE='{0}'", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
          
            sb.Append(",SYNC_STATE='0'");
           
            sb.AppendFormat(" where id='{0}'", input.Id);
            
            return sb.ToString();

        }
        
    }
}
