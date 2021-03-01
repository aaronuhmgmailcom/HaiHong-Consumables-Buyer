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
        // �ɹ�����ϸ��¼ID
        String itemId;
        public String ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        //��ʼҳ����
        private int start;

        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        // ����ҳ����
        private int end;

        public int End
        {
            get { return end; }
            set { end = value; }
        }

        // ��¼����
        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        // ������
        private int totalRows;

        public int TotalRows
        {
            get { return totalRows; }
            set { totalRows = value; }
        }
        //ƥ��״̬
        private string corpstate;
        public string CorpState
        {
            get { return corpstate; }
            set { this.corpstate = value; }
        }

        //����״̬
        private string dealstate;
        public string DealState
        {
            get { return this.dealstate; }
            set { this.dealstate = value; }
        }
        //����ҽԺ
        private string emedhos;
        public string EmedHos
        {
            get { return this.emedhos; }
            set { this.emedhos = value; }
        }
        //ERPҽԺ
        private string hishos;
        public string ERPHos
        {
            get { return this.hishos; }
            set { this.hishos = value; }
        }
        //���չ�ϵ
        private string compares;
        public string Compares
        {
            get { return compares; }
            set { compares = value; }
        }

        //�ȶ���ҵ����
        private string mapOrgId;
        //��ҵID
        private string corpId;
        //��ҵ����
        private string corpCode;
        //��ҵȫ��
        private string corpName;
        //��ҵ���
        private string corpAbbr;
        //����״̬
        private string process;
        //�޸���ID
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
