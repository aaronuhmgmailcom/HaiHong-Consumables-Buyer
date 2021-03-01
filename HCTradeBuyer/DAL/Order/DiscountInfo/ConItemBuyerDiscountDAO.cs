using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Emedchina.TradeAssistant.Model.Order.DiscountInfo;
using Emedchina.Commons.Data;

namespace Emedchina.TradeAssistant.DAL.Order.DiscountInfo
{
    public class ConItemBuyerDiscountDAO : OracleDAOBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        private ConItemBuyerDiscountDAO()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UserDAL"/> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        private ConItemBuyerDiscountDAO(string connectionName)
            : base(connectionName)
        { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ConItemBuyerDiscountDAO GetInstance()
        {
            return new ConItemBuyerDiscountDAO();
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static ConItemBuyerDiscountDAO GetInstance(string connectionName)
        {
            return new ConItemBuyerDiscountDAO(connectionName);
        }

        public ConItemBuyerDiscountModel getDiscountInfo(string buyerId, string platId, string conItemId)
        {
            StringBuilder sql = new StringBuilder();
            ConItemBuyerDiscountModel model = null;
            sql.Append(" select c.discount_batch,");
            sql.Append(" c.discount_payment,");
            sql.Append(" c.discount_payatonce,");
            sql.Append(" c.discount_thirtyday ");
            sql.Append(" from con_item_buyer_discount c ");

            sql.Append(" where c.buyer_id = :buyer_id ");
            sql.Append(" and c.source_id = :source_id ");
            sql.Append(" and c.create_plat = :plat_id ");

            DbParameter paramBuyer = base.DbFacade.CreateParameter();
            paramBuyer.ParameterName = "buyer_id";
            paramBuyer.DbType = DbType.String;
            paramBuyer.Value = buyerId;
            DbParameter paramPlat = base.DbFacade.CreateParameter();
            paramPlat.ParameterName = "plat_id";
            paramPlat.DbType = DbType.String;
            paramPlat.Value = platId;
            DbParameter paramCon = base.DbFacade.CreateParameter();
            paramCon.ParameterName = "source_id";
            paramCon.DbType = DbType.String;
            paramCon.Value = conItemId;
            try
            {

                model = DbFacade.SQLExecuteObject(sql.ToString(), new MapRow(MapDiscountModel), paramBuyer, paramPlat, paramCon) as ConItemBuyerDiscountModel;
            }
            catch (Exception e)
            {
                throw e;
            }
            return model;

        }

        /// <summary>
        /// Maps DiscountModel table
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        private object MapDiscountModel(IDataReader reader, int row)
        {
            ConItemBuyerDiscountModel model = new ConItemBuyerDiscountModel();
            model.DiscountBatchValue = Convert.ToString(reader["discount_batch"]);
            model.DiscountPayatonceValue = Convert.ToString(reader["discount_payatonce"]);
            model.DiscountPaymentValue = Convert.ToString(reader["discount_payment"]);
            model.DiscountThirtydayValue = Convert.ToString(reader["discount_thirtyday"]);

            return model;
        }
    }
}
