//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	Gpo_Hosptail_MapModel.cs     
//	创 建 人:	yanbing
//	创建日期:	2007-5-21
//	功能描述:	对接医院对照表实体类
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//======================================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Map
{
    [Serializable]
    public class Gpo_Hosptail_MapModel
    {
        //比对医院编码
        private string mapOrgId;
        //医院ID
        private string corpId;
        //海虹企业id
        private string data_org_id;
        //医院编码
        private string corpCode;
        //医院全称
        private string corpName;
        //医院简称
        private string corpAbbr;
        //处理状态
        private string process;
        //修改人ID
        private string modifyUserId;
        //是否比对
        private string isMap;

        public string IsMap
        {
            get { return isMap; }
            set { isMap = value; }
        }

        public string MapOrgId
        {
            get { return mapOrgId; }
            set { mapOrgId = value; }
        }

        public string CorpId
        {
            get { return corpId; }
            set { corpId = value; }
        }

        public string CorpCode
        {
            get { return corpCode; }
            set { corpCode = value; }
        }

        public string Data_org_id
        {
            get { return data_org_id; }
            set { data_org_id = value; }
        }

        public string CorpName
        {
            get { return corpName; }
            set { corpName = value; }
        }

        public string CorpAbbr
        {
            get { return corpAbbr; }
            set { corpAbbr = value; }
        }

        public string Process
        {
            get { return process; }
            set { process = value; }
        }

        public string ModifyUserId
        {
            get { return modifyUserId; }
            set { modifyUserId = value; }
        }

    }
}
