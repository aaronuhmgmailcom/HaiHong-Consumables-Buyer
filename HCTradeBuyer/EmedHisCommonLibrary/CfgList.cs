using System;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Emedchina.Commons;

namespace Emedchina.TradeAsst.EmedHisCommonLibrary
{

    public class CfgList
    {
        public CfgList()
        {
       
            this.CfgFileName =  "HisProConfigList.xml";
        }

        public bool ReadConfig()
        {
            XmlDocument document1 = null;
            int num;
            bool flag1;
            string clientType = "0";
            string text1 = EmedFunc.GetLocalPersonCfgPath() + @"\" + this.CfgFileName;
            string userConfig = EmedFunc.GetLocalPersonCfgPath() + @"\UserConfig.xml";
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(text1))
                {
                    return false;
                }

                //�ж��Ƿ񸣽���Ŀ��2007-6-27
                if (File.Exists(userConfig))
                {
                    XmlDocument userDoc = new XmlDocument();
                    userDoc.Load(userConfig);
                    XmlElement elementUser = (XmlElement)userDoc.SelectSingleNode("UserConfig/ClientType");
                    if (elementUser != null)
                    {
                        clientType = elementUser.GetAttribute("type").Trim().ToUpper();
                    }
                }
                document1.Load(text1);
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/CfgList");
                this.Cfgs = new CfgList[element1.ChildNodes.Count];
                num = 0;
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    //�ж��Ƿ񸣽���Ŀ��2007-6-27
                    if ("1".Equals(clientType) && (element1.ChildNodes[num1].Attributes["Name"].Value.Equals("�ɹ����뵼��") || element1.ChildNodes[num1].Attributes["Name"].Value.Equals("�ɹ����뷢������") || element1.ChildNodes[num1].Attributes["Name"].Value.Equals("����ҽԺ����Ϣ")))
                    {
                        continue;
                    }
                    
                    this.Cfgs[num] = new CfgList();
                    this.Cfgs[num].Name = element1.ChildNodes[num1].Attributes["Name"].Value;
                    this.Cfgs[num].Type = element1.ChildNodes[num1].Attributes["Type"].Value;
                    this.Cfgs[num].DllName = element1.ChildNodes[num1].Attributes["DllName"].Value;
                    this.Cfgs[num].CfgName = element1.ChildNodes[num1].Attributes["CfgName"].Value;
                    this.Cfgs[num].CfgTemplet = element1.ChildNodes[num1].Attributes["CfgTemplet"].Value;
                    if (this.Cfgs[num].Type == "0")
                    {
                        this.Cfgs[num].TypeCn = "����";
                    }
                    else
                    {
                        this.Cfgs[num].TypeCn = "����";
                    }
                    if (element1.ChildNodes[num1].Attributes["IsMulti"] == null)
                    {
                        this.Cfgs[num].IsMulti = false;
                    }
                    else
                    {
                        this.Cfgs[num].IsMulti = element1.ChildNodes[num1].Attributes["CfgTemplet"].Value == "1";
                    }
                    this.Cfgs[num].FoxTemplet = element1.ChildNodes[num1].SelectSingleNode("FoxTemplet").InnerText;
                    //this.Cfgs[num1].MDBTemplet = element1.ChildNodes[num1].SelectSingleNode("MDBTemplet").InnerText;
                    //this.Cfgs[num1].DBName = element1.ChildNodes[num1].SelectSingleNode("DBName").InnerText;
                    this.Cfgs[num].FoxDetailTemplet = element1.ChildNodes[num1].SelectSingleNode("FoxDetailTemplet").InnerText;
                    this.Cfgs[num].TxtTemplet = element1.ChildNodes[num1].SelectSingleNode("TxtTemplet").InnerText;
                    this.Cfgs[num].ExcelTemplet = element1.ChildNodes[num1].SelectSingleNode("ExcelTemplet").InnerText;
                    ++num;
                }
                flag1 = true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("��ȡ�����ļ�����", exception1);
                flag1 = false;
            }
            finally
            {
                document1 = null;
            }
            return flag1;
        }


        private string CfgFileName;
        public string CfgName;
        public CfgList[] Cfgs;
        public string CfgTemplet;
        public string DllName;
        public string MDBTemplet;
        public string DBName;
        public string ExcelTemplet;
        public string FoxDetailTemplet;
        public string FoxTemplet;
        public bool IsMulti;
        public string Name;
        public string TxtTemplet;
        public string Type;
        public string TypeCn;
    }
}

