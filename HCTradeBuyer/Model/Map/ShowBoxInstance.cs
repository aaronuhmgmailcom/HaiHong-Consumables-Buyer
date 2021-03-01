using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Emedchina.TradeAssistant.Model.Map
{
   public class ShowBoxInstance
    {
        string medicalName;
        public string MedicalName
        {
            get { return this.medicalName; }
            set { this.medicalName = value; }
        }
        string productName;
        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }
        string spec;
        public string Spec
        {
            get { return this.spec; }
            set { this.spec = value; }
        }
        string producer;
        public string Producer
        {
            get { return this.producer; }
            set { this.producer = value; }
        }
        DataTable matchERPDT;
        public DataTable MatchERPDT
        {
            get
            {
                if (this.matchERPDT == null)
                    matchERPDT = new DataTable();
                return matchERPDT;
            }
            set
            {
                if (this.matchERPDT == null)
                    matchERPDT = new DataTable();
                this.matchERPDT = value;
            }
        }

        static ShowBoxInstance showbox;

        public static ShowBoxInstance GetShowBoxInstance()
        {
            if (showbox == null)
                showbox = new ShowBoxInstance();
            return showbox;
        }
    }
}
