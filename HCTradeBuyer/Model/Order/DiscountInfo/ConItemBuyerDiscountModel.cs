using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.DiscountInfo
{
    public class ConItemBuyerDiscountModel
    {
        //	规模折扣
        private String discountBatchValue;
        //回款折扣
        private String discountPaymentValue;
        //现款折扣
        private String discountPayatonceValue;
        //付款折扣
        private String discountThirtydayValue;
        # region discountBatchValue
        public String DiscountBatchValue
        {
            get { return discountBatchValue; }
            set { discountBatchValue = value; }
        }
        #endregion

        # region discountPaymentValue
        public String DiscountPaymentValue
        {
            get { return discountPaymentValue; }
            set { discountPaymentValue = value; }
        }
        #endregion

        # region discountPayatonceValue
        public String DiscountPayatonceValue
        {
            get { return discountPayatonceValue; }
            set { discountPayatonceValue = value; }
        }
        #endregion

        # region discountThirtydayValue
        public String DiscountThirtydayValue
        {
            get { return discountThirtydayValue; }
            set { discountThirtydayValue = value; }
        }
        #endregion


    }
}
