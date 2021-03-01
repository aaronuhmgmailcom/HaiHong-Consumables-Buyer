
//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	GpoProductMapModel.cs     
//	创 建 人:	刘海超
//	创建日期:	2007-10-28
//	功能描述:	导入采购单产品对照表实体类
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//======================================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.PurchaseHandle
{
    public class ImputPurchaseModel
    {
        //耗材编码
        private string hcbm;
        public string Hcbm
        {
            get { return hcbm; }
            set { hcbm = value; }
        }

        //耗材名称
        private string hcmc;
        public string Hcmc
        {
            get { return hcmc; }
            set { hcmc = value; }
        }

        //品名称
        private string cpmc;
        public string Cpmc
        {
            get { return cpmc; }
            set { cpmc = value; }
        }

        //型号名称
        private string xhmc;
        public string Xhmc
        {
            get { return xhmc; }
            set { xhmc = value; }
        }

        //规格名称
        private string ggmc;
        public string Ggmc
        {
            get { return ggmc; }
            set { ggmc = value; }
        }

        //包装单位
        private string bzdw;
        public string Bzdw
        {
            get { return bzdw; }
            set { bzdw = value; }
        }

        //最小使用单位
        private string zxsydw;
        public string Zxsydw
        {
            get { return zxsydw; }
            set { zxsydw = value; }
        }

        //转换比
        private string zhb;
        public string Zhb
        {
            get { return zhb; }
            set { zhb = value; }
        }

        //生产企业编码
        private string scqybm;
        public string Scqybm
        {
            get { return scqybm; }
            set { scqybm = value; }
        }

        //生产企业名称
        private string scqymc;
        public string Scqymc
        {
            get { return scqymc; }
            set { scqymc = value; }
        }
        //生产企业j简称
        private string scqyjc;
        public string Scqyjc
        {
            get { return scqyjc; }
            set { scqyjc = value; }
        }
        //药库编码
        private string ykbm;
        public string Ykbm
        {
            get { return ykbm; }
            set { ykbm = value; }
        }
        //药库名称
        private string ykmc;
        public string Ykmc
        {
            get { return ykmc; }
            set { ykmc = value; }
        }
        //卖方企业编码
        private string psqybm;
        public string Psqybm
        {
            get { return psqybm; }
            set { psqybm = value; }
        }
        //卖方企业名称
        private string psqymc;
        public string Psqymc
        {
            get { return psqymc; }
            set { psqymc = value; }
        }
        //卖方企业简称
        private string psqyjc;
        public string Psqyjc
        {
            get { return psqyjc; }
            set { psqyjc = value; }
        }
        //采购数量
        private string cgsl;
        public string Cgsl
        {
            get { return cgsl; }
            set { cgsl = value; }
        }
        //匹配类型
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        //海虹项目产品id
        private string emedProductId;
        public string EmedProductId
        {
            get { return emedProductId; }
            set { emedProductId = value; }
        }
        //海虹规格id
        private string emedSpecId;
        public string EmedSpecId
        {
            get { return emedSpecId; }
            set { emedSpecId = value; }
        }
        //海虹型号id
        private string emedModelId;
        public string EmedModelId
        {
            get { return emedModelId; }
            set { emedModelId = value; }
        }
        //海虹配送id
        private string emedSenderId;
        public string EmedSenderId
        {
            get { return emedSenderId; }
            set { emedSenderId = value; }
        }
        //价格
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }
        }//
        //中大包装
        private string zdbz;
        public string Zdbz
        {
            get { return zdbz; }
            set { zdbz = value; }
        }
        //品牌
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

    }
}
