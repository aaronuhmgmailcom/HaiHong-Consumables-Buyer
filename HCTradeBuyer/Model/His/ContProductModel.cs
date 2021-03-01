//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	Gpo_Product_MapModel.cs     
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
//	功能描述:	合同采购目录实体类
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//======================================================================================

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.His
{
    public class ContProductModel
    {
        //ProductID 
        private string productID;
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }         

        //通用名 
        private string medicalName;
        public string MedicalName
        {
            get { return medicalName; }
            set { medicalName = value; }
        }

        //型
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        //规格包装
        private string uncSpec;
        public string UncSpec
        {
            get { return uncSpec; }
            set { uncSpec = value; }
        }

        //生产企业
        private string factoryName;
        public string FactoryName
        {
            get { return factoryName; }
            set { factoryName = value; }
        }

        //商品名
        private string tradeName;
        public string TradeName
        {
            get { return tradeName; }
            set { tradeName = value; }
        }

        DataTable matchHisDT;
        public DataTable MatchHisDT
        {
            get
            {
                if (this.matchHisDT == null)
                    matchHisDT = new DataTable();
                return matchHisDT;
            }
            set
            {
                if (this.matchHisDT == null)
                    matchHisDT = new DataTable();
                this.matchHisDT = value;
            }
        }

    }
}
