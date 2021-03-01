using System;
using System.Collections;

namespace Emedchina.TradeAsst.EmedHisCommonLibrary
{

    public class DataBaseType
    {
        public DataBaseType()
        {
            this._type = "";
            this._typeDesc = "";
        }

        private DataBaseType(string inType, string inTypeDesc)
        {
            this._type = "";
            this._typeDesc = "";
            this._type = inType;
            this._typeDesc = inTypeDesc;
        }

        public static ArrayList Intance()
        {
            ArrayList list1 = new ArrayList();
            list1.Add(new DataBaseType("SQLSERVER", "����SQL Server�����ݿ�����"));
            list1.Add(new DataBaseType("ACCESS", "����Access�����ݿ�����"));
            return list1;
        }


        public string Type
        {
            get
            {
                return this._type;
            }
        }

        public string TypeDesc
        {
            get
            {
                return this._typeDesc;
            }
        }


        private string _type;
        private string _typeDesc;
    }
}
