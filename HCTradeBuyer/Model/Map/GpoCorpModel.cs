using System;
using System.Collections.Generic;
using System.Text;

namespace Emedchina.TradeAssistant.Model.Map
{
    [Serializable]
    public class GpoCorpModel
    {
        String orgId;
        public String OrgId
        {
            get { return orgId; }
            set { orgId = value; }
        }
        // 采购单明细记录ID
        String itemId;
        public String ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        //开始页索引
        private int start;

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        // 结束页索引
        private int end;

        public int End
        {
            get { return end; }
            set { end = value; }
        }

        // 记录总数
        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        // 总行数
        private int totalRows;

        public int TotalRows
        {
            get { return totalRows; }
            set { totalRows = value; }
        }
        //匹配状态
        private string corpstate;
        public string CorpState
        {
            get { return corpstate; }
            set { this.corpstate = value; }
        }

        //处理状态
        private string dealstate;
        public string DealState
        {
            get { return this.dealstate; }
            set { this.dealstate = value; }
        }
        //海虹医院
        private string emedhos;
        public string EmedHos
        {
            get { return this.emedhos; }
            set { this.emedhos = value; }
        }
        //ERP医院
        private string hishos;
        public string ERPHos
        {
            get { return this.hishos; }
            set { this.hishos = value; }
        }
        //对照关系
        private string compares;
        public string Compares
        {
            get { return compares; }
            set { compares = value; }
        }

        //比对企业编码
        private string mapOrgId;
        //企业ID
        private string corpId;
        //企业编码
        private string corpCode;
        //企业全称
        private string corpName;
        //企业简称
        private string corpAbbr;
        //处理状态
        private string process;
        //修改人ID
        private string modifyUserId;

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
