//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	GpoProductMapModel.cs     
//	创 建 人:	yb
//	创建日期:	2007-10-24
//	功能描述:	对接产品对照表实体类
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//======================================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Order.ApplyerProcess
{
    public class GpoOutReceiveModel
    {
        //药品编码
        private string ypbm;
        public string Ypbm
        {
            get { return ypbm; }
            set { ypbm = value; }
        }

        //药品名称
        private string ypmc;
        public string Ypmc
        {
            get { return ypmc; }
            set { ypmc = value; }
        }

        //品名称
        private string cpmc;
        public string Cpmc
        {
            get { return cpmc; }
            set { cpmc = value; }
        }

        //剂型名称
        private string jxmc;
        public string Jxmc
        {
            get { return jxmc; }
            set { jxmc = value; }
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

    }
}
