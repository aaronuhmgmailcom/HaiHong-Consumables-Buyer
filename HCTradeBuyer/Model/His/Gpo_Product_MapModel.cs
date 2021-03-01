//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	Gpo_Product_MapModel.cs     
//	创 建 人:	yanbing
//	创建日期:	2007-9-26
//	功能描述:	对接产品对照表实体类
//	修 改 人: 
//	修改日期:   
//	主要修改内容:
//======================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using Emedchina.TradeAssistant.Model.User;
namespace Emedchina.TradeAssistant.Model.His
{
    public class Gpo_Product_MapModel
    {
        //ID
        private string iD;
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }

        //数据产品ID
        private string dataProductID;
        public string DataProductID
        {
            get { return dataProductID; }
            set { dataProductID = value; }
        }

        //海虹产品ID
        private string productID;
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        //对接机构海虹ID
        private string map_Orgid;
        public string Map_Orgid
        {
            get { return map_Orgid; }
            set { map_Orgid = value; }
        }

        //海虹经销企业ID
        private string saler_Id;
        public string Saler_Id
        {
            get { return saler_Id; }
            set { saler_Id = value; }
        }

        //海虹配送企业ID
        private string sender_Id;
        public string Sender_Id
        {
            get { return sender_Id; }
            set { sender_Id = value; }
        }

        //海虹生产企业ID
        private string factory_Id;
        public string Factory_Id
        {
            get { return factory_Id; }
            set { factory_Id = value; }
        }


        //药品名称
        private string medicaName;
        public string MedicaName
        {
            get { return medicaName; }
            set { medicaName = value; }
        }

        //商品名称
        private string commerceName;
        public string CommerceName
        {
            get { return commerceName; }
            set { commerceName = value; }
        }


        //处理状态
        private string processFlag;
        public string ProcessFlag
        {
            get { return processFlag; }
            set { processFlag = value; }
        }

        //生产企业
        private string factoryName;
        public string FactoryName
        {
            get { return factoryName; }
            set { factoryName = value; }
        }

        //生产企业code
        private string factoryCode;
        public string FactoryCode
        {
            get { return factoryCode; }
            set { factoryCode = value; }
        }


        //HIS产品编码
        private string productCode;
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        //药品编码
        private string medicalCode;
        public string MedicalCode
        {
            get { return medicalCode; }
            set { medicalCode = value; }
        }

        //匹配状态
        private string isMap;
        public string IsMap
        {
            get { return isMap; }
            set { isMap = value; }
        }

        //剂型ID
        private string mode_ID;
        public string Mode_ID
        {
            get { return mode_ID; }
            set { mode_ID = value; }
        }

        //HH剂型ID
        private string HH_mode_ID;
        public string HH_Mode_ID
        {
            get { return HH_mode_ID; }
            set { HH_mode_ID = value; }
        }

        //HHSPECID
        private string HH_spec_ID;
        public string HH_Spec_ID
        {
            get { return HH_spec_ID; }
            set { HH_spec_ID = value; }
        }


        //剂型名称
        private string mode_Name;
        public string Mode_Name
        {
            get { return mode_Name; }
            set { mode_Name = value; }
        }

        //产品名
        private string product_Name;
        public string Product_Name
        {
            get { return product_Name; }
            set { product_Name = value; }
        }

        //通用名
        private string commonName;
        public string CommonName
        {
            get { return commonName; }
            set { commonName = value; }
        }

        //包装转换比
        private string package_Rate;
        public string Package_Rate
        {
            get { return package_Rate; }
            set { package_Rate = value; }
        }

        //生产企业名称
        private string factory_Name;
        public string Factory_Name
        {
            get { return factory_Name; }
            set { factory_Name = value; }
        }

        //备注
        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        //规格ID
        private string medical_Spec_Id;
        public string Medical_Spec_Id
        {
            get { return medical_Spec_Id; }
            set { medical_Spec_Id = value; }
        }

        //规格名称
        private string medical_Spec;
        public string Medical_Spec
        {
            get { return medical_Spec; }
            set { medical_Spec = value; }
        }

        //包装单位
        private string spec_Unit;
        public string Spec_Unit
        {
            get { return spec_Unit; }
            set { spec_Unit = value; }
        }

        //包装单位ID
        private string spec_Unit_Id;
        public string Spec_Unit_Id
        {
            get { return spec_Unit_Id; }
            set { spec_Unit_Id = value; }
        }

        //STAND_RATE
        private string stand_Rate;
        public string Stand_Rate
        {
            get { return stand_Rate; }
            set { stand_Rate = value; }
        }

        //USE_UNIT
        private string use_Unit;
        public string Use_Unit
        {
            get { return use_Unit; }
            set { use_Unit = value; }
        }

        //FACTORY_CODE
        private string factory_Code;
        public string Factory_Code
        {
            get { return factory_Code; }
            set { factory_Code = value; }
        }

        //useUnitCode
        private string useUnitCode;
        public string UseUnitCode
        {
            get { return useUnitCode; }
            set { useUnitCode = value; }
        }

        //批号
        private string permit_No;
        public string Permit_No
        {
            get { return permit_No; }
            set { permit_No = value; }
        }

        //经销企业ID
        private string saler_Code;
        public string Saler_Code
        {
            get { return saler_Code; }
            set { saler_Code = value; }
        }

        //经销企业名称
        private string saler_Name;
        public string Saler_Name
        {
            get { return saler_Name; }
            set { saler_Name = value; }
        }

        //配送企业ID
        private string sender_Code;
        public string Sender_Code
        {
            get { return sender_Code; }
            set { sender_Code = value; }
        }

        //配送企业名称
        private string sender_Name;
        public string Sender_Name
        {
            get { return sender_Name; }
            set { sender_Name = value; }
        }

        //药品分类ID
        private string category_Id;
        public string Category_Id
        {
            get { return category_Id; }
            set { category_Id = value; }
        }

        //药品分类名称
        private string category_Name;
        public string Category_Name
        {
            get { return category_Name; }
            set { category_Name = value; }
        }

        //药库ID
        private string stock_Id;
        public string Stock_Id
        {
            get { return stock_Id; }
            set { stock_Id = value; }
        }

        //药库名称
        private string stock_Name;
        public string Stock_Name
        {
            get { return stock_Name; }
            set { stock_Name = value; }
        }

        //材料品名一
        private string mtsr1;
        public string Mtsr1
        {
            get { return mtsr1; }
            set { mtsr1 = value; }
        }

        //材料品名2
        private string mtsr2;
        public string Mtsr2
        {
            get { return mtsr2; }
            set { mtsr2 = value; }
        }

        //材料品名3
        private string mtsr3;
        public string Mtsr3
        {
            get { return mtsr3; }
            set { mtsr3 = value; }
        }

        //订购厂商名称1
        private string ordVndNm;
        public string OrdVndNm
        {
            get { return ordVndNm; }
            set { ordVndNm = value; }
        }

        //订购厂商名称二
        private string ordVndNm2;
        public string OrdVndNm2
        {
            get { return ordVndNm2; }
            set { ordVndNm2 = value; }
        }

        //订购厂商简称
        private string ordVndAbr;
        public string OrdVndAbr
        {
            get { return ordVndAbr; }
            set { ordVndAbr = value; }
        }

        //商标
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private string base_measure;
        public string Base_measure
        {
            get { return base_measure; }
            set { base_measure = value; }
        }



        private string base_measure_spec;
        public string Base_measure_spec
        {
            get { return base_measure_spec; }
            set { base_measure_spec = value; }
        }

        private string base_measure_mate;
        public string Base_measure_mate
        {
            get { return base_measure_mate; }
            set { base_measure_mate = value; }
        }

        private LogedInUser user;

        public LogedInUser User
        {
            get { return user; }
            set { user = value; }
        }

     
     
    }
}
