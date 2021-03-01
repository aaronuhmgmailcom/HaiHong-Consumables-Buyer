#region Header
/*****************************************************************************
 * $Author: Sunhl $Revision: 1.0 $
 * $Date: 06-06-28 15:57 $ 
 ********************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.PurchaseHandle
{
   [Serializable]
   public class PurchaseOrderItemModel
    {
       //订单表ID
        private string orderId="0";
        //记录号
        private string recordId="0";
        //采购单ID
        private string purchaseId = "0";
        //采购单明细ID
        private string purchaseItemId="0";
        //中心产品ID
        private string dataproductId="0";
        //项目产品ID
        private string projectprodId="0";
        //经常采购目录ID
        private string hitCommId="0";
        //区域ID
        private string areaId="0";
        //医疗机构ID
        private string buyerOrgid="0";
        //医院名称
        private string bakBuyerName;
        //医院简称
        private string bakBuyerEasy;
        //单价
        private decimal unitPrice=0;
        //交易金额
        private decimal sum = 0;
        //备货状态
        private string readyFlag;
        //采购量
        private decimal requestQty=0;
        //合同ID
        private string conId;
        //合同明细ID
        private string conItemId;
        //项目标识
        private string projectId;
        //合同类型
        private string conType;
        //仓库ID
        private string repositoryId;
       //仓库名称
        private string storeroomname;
        //送货地址
        private string repositoryAddr;
        //买方备注
        private string buyerDesc;
        //卖方备注
        private string salerDesc;
        //订单紧急程度
        private string degreeFlag;
        //备注
        private string remark;
        //源订单明细ID
        private string originalItemId;
        //父订单明细ID
        private string parentItemId;
        //明细状态
        private string itemStatus;
        //省最高零售价
        private decimal maxPrice;
        //订单类型
        private string orderType="0";
        //创建人姓名
         private string createusername;
        //创建日期
        private DateTime createDate=Convert.ToDateTime(DateTime.Now);
        //修改人ID
        private string modifyUserid;
        //修改日期
        private DateTime modifyDate;
        //经销商ID
        private string salerId;
        //经销商
        private string salername;
        //经销商简称
        private string salernameeasy;
        //配送商ID
        private string senderId;
        //配送商
        private string sendername;
        //配送商简称
        private string sendernameeasy;
        //生产企业ID
        private string manufactureId;
        //生产企业
        private string manufacturename;
        //生产企业简称
        private string manufacturenameeasy;
        //通用名称
       private string commonname;
       //产品名称
       private string productname;
       //商品编码
       private string productcode;
       //规格ID
       private string specid;
       //型号ID
       private string modelid;
       //规格
       private string spec;
       //型号
       private string model;
       //品牌
       private string  brand;
       //货号
       private string  goodsno;
       //条码
       private string  barcode;
       //基础单位规格
       private string basemeasuerspec;
        //基础计量单位
       private string basemeasure;
        //配送计量单位
       private string sendmeasure;
        //配送转换率
       private string sendmeasureex;
        //基础单位包装材质
       private string basemeasuremater;
       //结算企业ID
       private string balanceid;
       //结算企业名称
       private string balancename;
       //结算企业简称
       private string balanceeasy;
       //结算企业拼音简称
       private string balancefast;
       //结算企业五笔简称
       private string balancewubi;
       //中大包装
       private decimal package = 0;
       public decimal Package
       {
           get { return package; }
           set { package = value; }
       } 
       public string Balanceid
       {
           get { return balanceid; }
           set { balanceid = value; }
       }
       public string Balancename
       {
           get { return balancename; }
           set { balancename = value; }
       }
       public string Balanceeasy
       {
           get { return balanceeasy; }
           set { balanceeasy = value; }
       }
       public string Balancefast
       {
           get { return balancefast; }
           set { balancefast = value; }
       }
       public string Balancewubi
       {
           get { return balancewubi; }
           set { balancewubi = value; }
       }

       public string Basemeasuerspec
        {
            get { return basemeasuerspec; }
            set { basemeasuerspec = value; }
        }
       public string Basemeasure
        {
            get { return basemeasure; }
            set { basemeasure = value; }
        }
       public string Sendmeasure
        {
            get { return sendmeasure; }
            set { sendmeasure = value; }
        }
       public string Sendmeasureex
        {
            get { return sendmeasureex; }
            set { sendmeasureex = value; }
        }
       public string Basemeasuremater
        {
            get { return basemeasuremater; }
            set { basemeasuremater = value; }
        }
       public string    CommonName
        {
            get { return commonname; }
            set { commonname = value; }
        }
       public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
       private string abbr_Py;
       public string Abbr_Py
       {
           get { return abbr_Py; }
           set { abbr_Py = value; }
       }
       private string abbr_Wb;
       public string Abbr_Wb
       {
           get { return abbr_Wb; }
           set { abbr_Wb = value; }
       }
       public string ProductCode
        {
            get { return productcode; }
            set { productcode = value; }
        }
       public string SpecId
        {
            get { return specid; }
            set { specid = value; }
        }
       public string ModelId
        {
            get { return modelid; }
            set { modelid = value; }
        }
       public string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
       public string Model
        {
            get { return model; }
            set { model = value; }
        }
       public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
       public string Goodsno
        {
            get { return goodsno; }
            set { goodsno = value; }
        }
       public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public DateTime ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }

        public string ModifyUserid
        {
            get { return modifyUserid; }
            set { modifyUserid = value; }
        }

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        public decimal MaxPrice
        {
            get { return maxPrice; }
            set { maxPrice = value; }
        } 

        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; }
        }

        public string ParentItemId
        {
            get { return parentItemId; }
            set { parentItemId = value; }
        }

        public string OriginalItemId
        {
            get { return originalItemId; }
            set { originalItemId = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string DegreeFlag
        {
            get { return degreeFlag; }
            set { degreeFlag = value; }
        }


        public string SalerDesc
        {
            get { return salerDesc; }
            set { salerDesc = value; }
        }

        public string BuyerDesc
        {
            get { return buyerDesc; }
            set { buyerDesc = value; }
        }

        public string RepositoryAddr
        {
            get { return repositoryAddr; }
            set { repositoryAddr = value; }
        }

        public string RepositoryId
        {
            get { return repositoryId; }
            set { repositoryId = value; }
        }

        public string ConType
        {
            get { return conType; }
            set { conType = value; }
        }

        public string ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public string ConItemId
        {
            get { return conItemId; }
            set { conItemId = value; }
        }

        public string ConId
        {
            get { return conId; }
            set { conId = value; }
        }

        public decimal RequestQty
        {
            get { return requestQty; }
            set { requestQty = value; }
        } 

        public string ReadyFlag
        {
            get { return readyFlag; }
            set { readyFlag = value; }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

       public decimal Sum
       {
           get { return sum; }
           set { sum = value; }
       } 

        public string BuyerOrgid
        {
            get { return buyerOrgid; }
            set { buyerOrgid = value; }
        }

        public string AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        public string HitCommId
        {
            get { return hitCommId; }
            set { hitCommId = value; }
        }

       public string PurchaseId
       {
           get { return purchaseId; }
           set { purchaseId = value; }
       }

        public string PurchaseItemId
        {
            get { return purchaseItemId; }
            set { purchaseItemId = value; }
        }

        public string RecordId
        {
            get { return recordId; }
            set { recordId = value; }
        }

        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
       public string DataproductId
       {
           get { return dataproductId; }
           set { dataproductId = value; }
       }
       public string ProjectprodId
       {
           get { return projectprodId; }
           set { projectprodId = value; }
       }
         public string BakBuyerEasy
        {
            get { return bakBuyerEasy; }
            set { bakBuyerEasy = value; }
        }

       public string BakBuyerName
       {
           get { return bakBuyerName; }
           set { bakBuyerName = value; }
       }
       public string SalerId
       {
           get { return salerId; }
           set { salerId = value; }
       }
       public string SalerName
       {
           get { return salername; }
           set { salername = value; }
       }
       public string SalerNameEasy
       {
           get { return salernameeasy; }
           set { salernameeasy = value; }
       }
       public string SenderId
       {
           get { return senderId; }
           set { senderId = value; }
       }
       public string SenderName
       {
           get { return sendername; }
           set { sendername = value; }
       }
       public string SenderNameEasy
       {
           get { return sendernameeasy; }
           set { sendernameeasy = value; }
       }
       
       public string ManufactureId
       {
           get { return manufactureId; }
           set { manufactureId = value; }
       }
       public string ManufactureName
       {
           get { return manufacturename; }
           set { manufacturename = value; }
       }
       public string ManufactureNameEasy  
       {
           get { return manufacturenameeasy; }
           set { manufacturenameeasy = value; }
       }
       public string Storeroomname
       {
           get { return storeroomname; }
           set { storeroomname = value; }
       }
       
         public string Createusername
       {
           get { return createusername ; }
           set { createusername = value; }
       }
       //数据
       private int amount = 0;
       public int Amount
       {
           get { return amount; }
           set { amount = value; }
       } 
    }

    [Serializable]
    public struct PurchaseOrderItemStruct
    {
        //订单表ID
        public string orderId;
        //记录号
        public string recordId;
        //采购单ID
        public string purchaseId;
        //采购单明细ID
        public string purchaseItemId;
        //经常采购目录ID
        public string hitCommId;
        //区域ID
        public string areaId;
        //医疗机构ID
        public string buyerOrgid;
        //医院名称
        public string bakBuyerName;
        //医院简称
        public string bakBuyerEasy;
        //单价
        public decimal unitPrice;
        //备货状态
        public string readyFlag;
        //采购量
        public decimal requestQty;
        //合同ID
        public string conId;
        //合同明细ID
        public string conItemId;
        //项目标识
        public string projectId;
        //合同类型
        public string conType;
        //仓库ID
        public string repositoryId;
        //送货地址
        public string repositoryAddr;
        //买方备注
        public string buyerDesc;
        //卖方备注
        public string salerDesc;
        //订单紧急程度
        public string degreeFlag;
        //备注
        public string remark;
        //源订单明细ID
        public string originalItemId;
        //父订单明细ID
        public string parentItemId;
        //明细状态
        public string itemStatus;
        //省最高零售价
        public decimal maxPrice;
        //交易金额
        public decimal sum;
        //订单类型
        public string orderType;
        //创建日期
        public DateTime createDate;
        //修改人ID
        public string modifyUserid;
        //修改日期
        public DateTime modifyDate;
        //中心产品ID
        public string dataproductId ;
        //项目产品ID
        public string projectprodId ;
        //经销商ID
        public string salerId;
        //经销商
        public string salername;
        //经销商简称
        public string salernameeasy;
        //配送商ID
        public string senderId;
        //配送商
        public string sendername;
        //配送商简称
        public string sendernameeasy;
        //生产企业ID
        public string manufactureId;
        //生产企业
        public string manufacturename;
        //生产企业简称
        public string manufacturenameeasy;
        //通用名称
        public string commonname;
        //产品名称
        public string productname;
        //商品编码
        public string productcode;
        //规格ID
        public string specid;
        //型号ID
        public string modelid;
        //规格
        public string spec;
        //型号
        public string model;
        //品牌
        public string brand;
        //货号
        public string goodsno;
        //条码
        public string barcode;
        //基础单位规格
        public string basemeasuerspec;
        //基础计量单位
        public string basemeasure;
        //配送计量单位
        public string sendmeasure;
        //配送转换率
        public string sendmeasureex;
        //基础单位包装材质
        public string basemeasuremater;
        //结算企业ID
        public string balanceid;
        //结算企业名称
        public string balancename;
        //结算企业简称
        public string balanceeasy;
        //结算企业拼音简称
        public string balancefast;
        //结算企业五笔简称
        public string balancewubi;
        //仓库名称
        public string storeroomname;
        //创建人姓名
        public string createusername;
    }

}
