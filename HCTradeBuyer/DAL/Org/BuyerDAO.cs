#region Header
/*****************************************************************************
 * Copyright (c)  Emedchina 2006
 * $Header: /ZjTradeAssistant/DAL/Org/BuyerDAO.cs 2     06-09-01 16:38 Panyj $ 
 * $Author: Panyj $ <a href="mailto:sunhongliang@hotmail.com">ÀÔ∫È¡¡(sunhl)</a>
 * $Revision: 2 $
 * $Date: 06-09-01 16:38 $
 * $History: BuyerDAO.cs $
 * 
 * *****************  Version 2  *****************
 * User: Panyj        Date: 06-09-01   Time: 16:38
 * Updated in $/ZjTradeAssistant/DAL/Org
 * 
 * *****************  Version 1  *****************
 * User: Panyj        Date: 06-08-23   Time: 17:17
 * Created in $/ZjTradeAssistant/DAL/Org
 * 
 * *****************  Version 1  *****************
 * User: Sunhl        Date: 06-06-27   Time: 16:49
 * Created in $/TradeAssistant.root/TradeAssistant/DAL/Org
 ********************************************************************************/
#endregion

#region using
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Emedchina.Commons.Data;
using Emedchina.TradeAssistant.Model;
using Emedchina.TradeAssistant.Model.Org;
#endregion

namespace Emedchina.TradeAssistant.DAL.Org
{
    /// <summary>
    /// 
    /// </summary>
    public class BuyerDAO : OracleDAOBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BuyerDAO"/> class.
        /// </summary>
        private BuyerDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BuyerDAO"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private BuyerDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static BuyerDAO GetInstance()
        {
            return new BuyerDAO();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static BuyerDAO GetInstance(string connectionName)
        {
            return new BuyerDAO(connectionName);
        }

        /// <summary>
        /// Gets the cat buyer by reg buyer id.
        /// </summary>
        /// <param name="regBuyerId">The reg buyer id.</param>
        /// <returns></returns>
        public CatBuyer GetCatBuyerByRegBuyerId(string regBuyerId)
        {
            return base.DbFacade.SQLQueryObjectById(GetCatBuyerByRegBuyerIdSql(), regBuyerId, new MapRow(MapCAT_BUYER)) as CatBuyer;
        }

        /// <summary>
        /// Gets the cat buyer by reg buyer id SQL.
        /// </summary>
        /// <returns></returns>
        private string GetCatBuyerByRegBuyerIdSql()
        {
            return
                @"select c.id, b.id plat_id,b.plat_name, b.plat_class,c.name org_name,a.org_type,a.org_kind,a.grade_no,a.enable_flag from cat_buyer a, plt_plat b, cat_org c where  a.plat_id = b.id and a.id = c.id  and a.id =:ID ";
        }

        /// <summary>
        /// Maps the CAT_BUYER.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapCAT_BUYER(IDataReader reader, int rowNumber)
        {
            CatBuyer _cat_buyer = new CatBuyer();
            _cat_buyer.Id = Convert.ToString(reader["ID"]);
            _cat_buyer.Plat_id = Convert.ToString(reader["PLAT_ID"]);
            _cat_buyer.Org_type = Convert.ToString(reader["ORG_TYPE"]);
            _cat_buyer.Org_kind = Convert.ToString(reader["ORG_KIND"]);
            _cat_buyer.Grade_no = Convert.ToString(reader["GRADE_NO"]);
            // _cat_buyer.Org_presider = Convert.ToString(reader["ORG_PRESIDER"]);
            // _cat_buyer.Tax_code = Convert.ToString(reader["TAX_CODE"]);
            // _cat_buyer.Org_account_name = Convert.ToString(reader["ORG_ACCOUNT_NAME"]);
            // _cat_buyer.Org_bank = Convert.ToString(reader["ORG_BANK"]);
            // _cat_buyer.Org_account = Convert.ToString(reader["ORG_ACCOUNT"]);
            // _cat_buyer.Org_address = Convert.ToString(reader["ORG_ADDRESS"]);
            // _cat_buyer.Post_code = Convert.ToString(reader["POST_CODE"]);
            // _cat_buyer.Org_phone = Convert.ToString(reader["ORG_PHONE"]);
            // _cat_buyer.Org_faxe = Convert.ToString(reader["ORG_FAXE"]);
            // _cat_buyer.Org_url = Convert.ToString(reader["ORG_URL"]);
            // _cat_buyer.Province_id = Convert.ToString(reader["PROVINCE_ID"]);
            // _cat_buyer.City_id = Convert.ToString(reader["CITY_ID"]);
            // _cat_buyer.Org_desc = Convert.ToString(reader["ORG_DESC"]);
            // _cat_buyer.Link_person = Convert.ToString(reader["LINK_PERSON"]);
            // _cat_buyer.Link_phone = Convert.ToString(reader["LINK_PHONE"]);
            // _cat_buyer.Create_date = reader["CREATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CREATE_DATE"]);
            // _cat_buyer.Create_plat = Convert.ToString(reader["CREATE_PLAT"]);
            // _cat_buyer.Create_org = Convert.ToString(reader["CREATE_ORG"]);
            // _cat_buyer.Last_update_user = Convert.ToString(reader["LAST_UPDATE_USER"]);
            // _cat_buyer.Last_update_date = reader["LAST_UPDATE_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["LAST_UPDATE_DATE"]);
            // _cat_buyer.Last_update_plat = Convert.ToString(reader["LAST_UPDATE_PLAT"]);
            // _cat_buyer.Last_update_org = Convert.ToString(reader["LAST_UPDATE_ORG"]);
            // _cat_buyer.Synchronized_date = reader["SYNCHRONIZED_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["SYNCHRONIZED_DATE"]);
            //_cat_buyer.Clean_date = reader["CLEAN_DATE"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["CLEAN_DATE"]);
            //_cat_buyer.Description = Convert.ToString(reader["DESCRIPTION"]);
            //_cat_buyer.Link_email = Convert.ToString(reader["LINK_EMAIL"]);
            // _cat_buyer.Create_user = Convert.ToString(reader["CREATE_USER"]);
            _cat_buyer.Enable_flag = Convert.ToString(reader["ENABLE_FLAG"]);
            // _cat_buyer.County_id = Convert.ToString(reader["COUNTY_ID"]);
            // _cat_buyer.Sync_state = Convert.ToString(reader["SYNC_STATE"]);
            //_cat_buyer.Buyer_kind = Convert.ToString(reader["BUYER_KIND"]);
            //_cat_buyer.Subject_flag = Convert.ToString(reader["SUBJECT_FLAG"]);
            // _cat_buyer.Medicare_flag = Convert.ToString(reader["MEDICARE_FLAG"]);
            //_cat_buyer.Bed_number = Convert.ToDecimal(reader["BED_NUMBER"]);
            // _cat_buyer.Proprietorship = Convert.ToString(reader["PROPRIETORSHIP"]);
            //_cat_buyer.Outpatient_per_day = Convert.ToDecimal(reader["OUTPATIENT_PER_DAY"]);
            //_cat_buyer.Sum_per_person = Convert.ToDecimal(reader["SUM_PER_PERSON"]);
            //_cat_buyer.Salesum_per_year = Convert.ToDecimal(reader["SALESUM_PER_YEAR"]);
            // _cat_buyer.Feature_clinic = Convert.ToString(reader["FEATURE_CLINIC"]);
            //_cat_buyer.Doctor_num = Convert.ToDecimal(reader["DOCTOR_NUM"]);
            //_cat_buyer.Clinic_medical_money = Convert.ToDecimal(reader["CLINIC_MEDICAL_MONEY"]);
            //_cat_buyer.Inpatient_num = Convert.ToDecimal(reader["INPATIENT_NUM"]);
            return _cat_buyer;
        }





    }
}
