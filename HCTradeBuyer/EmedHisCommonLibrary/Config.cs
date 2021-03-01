using System;
using System.IO;
using System.Xml;

namespace Emedchina.TradeAsst.EmedHisCommonLibrary
{

    public class Config
    {
        static Config()
        {
            Config._intance = null;
        }

        public Config()
        {
            this.version = "";
            this.currentCfgType = "";
            this.currentDBType = "";
            this.currentDBTypeDesc = "";
            this.currentCfgFile = "";
            this.currentDBConStr = "";
            this.currentFoxproTemplet = "";
            //add by yanbing 2007-06-13
            this.currentMDBTemplet = "";
            this.currentDBName = "";
            //end add
            this.currentFoxproDetailTemplet = "";
            this.currentTxtTemplet = "";
            this.currentExcelTemplet = "";
            this.isMulti = false;
            this.rootConfig = null;
            this.eleSource = null;
            this.eleDestination = null;
            this.eleContrast = null;
            this.eleBeginSql = null;
            this.eleSql = null;
            this.eleEndSql = null;
            this.eleDetail = null;
            this.eleDetailContrast = null;
            this.eleDetailBeginSql = null;
            this.eleDetailSql = null;
            this.eleDetailEndSql = null;
            //start add by gaoyuan 20070329
            this.destTable = null;
            //end add by gaoyuan 20070329
        }

        private static XmlElement GetEleConfig(XmlDocument inDoc, string inItemName)
        {
            try
            {
                return (XmlElement)inDoc.SelectSingleNode(inItemName);
            }
            catch
            {
                return null;
            }
        }

        public void InitCfgData(string inCfgFile)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgFile))
                {
                    return;
                }
                document1.Load(inCfgFile);
                Config._intance.RootConfig = Config.GetEleConfig(document1, "Config");
                Config._intance.EleSource = Config.GetEleConfig(document1, "Config/SourceDB");
                Config._intance.EleDestination = Config.GetEleConfig(document1, "Config/DestDB");
                Config._intance.EleContrast = Config.GetEleConfig(document1, "Config/ContrastList");
                Config._intance.EleBeginSql = Config.GetEleConfig(document1, "Config/BeginSql");
                Config._intance.EleSql = Config.GetEleConfig(document1, "Config/Sqls");
                Config._intance.MSql = Config.GetEleConfig(document1, "Config/MSqls");
                Config._intance.ASql = Config.GetEleConfig(document1, "Config/ASqls");
                Config._intance.DelSql = Config.GetEleConfig(document1, "Config/DelSqls");
                Config._intance.EleEndSql = Config.GetEleConfig(document1, "Config/EndSql");
                Config._intance.Version = Config._intance.RootConfig.Attributes["Ver"].Value;
                Config._intance.EleDetail = Config.GetEleConfig(document1, "Config/Detail");
                Config._intance.EleDetailContrast = Config.GetEleConfig(document1, "Config/Detail/ContrastList");
                Config._intance.EleDetailBeginSql = Config.GetEleConfig(document1, "Config/Detail/BeginSql");
                Config._intance.EleDetailSql = Config.GetEleConfig(document1, "Config/Detail/Sqls");
                Config._intance.EleDetailEndSql = Config.GetEleConfig(document1, "Config/Detail/EndSql");
                //start add by gaoyuan 20070329
                Config._intance.DestTable = Config.GetEleConfig(document1, "Config/DestDB/DestTable");
                //end add by gaoyuan 20070329
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取配置文件出错", exception1);
                return;
            }
            document1 = null;
        }

        public static Config Intance()
        {
            if (Config._intance == null)
            {
                Config._intance = new Config();
            }
            return Config._intance;
        }

        public bool SaveBeforeSQL(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/BeginSql");
                element1.RemoveAll();
                for (int num1 = 0; num1 < inEle.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("Sql");
                    XmlAttribute attribute1 = document1.CreateAttribute("Pattern");
                    attribute1.Value = "0";
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("ExecSort");
                    attribute1.Value = (num1 + 1).ToString();
                    element2.Attributes.Append(attribute1);
                    element2.InnerText = inEle.ChildNodes[num1].InnerText;
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch (Exception exception1)
            {
                document1 = null;
                ErrorLog.SaveLog("保存前置SQL至配置文件", exception1);
                return false;
            }
        }

        public bool SaveBeforeSQL(string inCfgPath, XmlElement inEle, bool inIsDetail)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1;
                if (inIsDetail)
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Detail/BeginSql");
                }
                else
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/BeginSql");
                }
                element1.RemoveAll();
                for (int num1 = 0; num1 < inEle.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("Sql");
                    XmlAttribute attribute1 = document1.CreateAttribute("Pattern");
                    attribute1.Value = "0";
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("ExecSort");
                    attribute1.Value = (num1 + 1).ToString();
                    element2.Attributes.Append(attribute1);
                    element2.InnerText = inEle.ChildNodes[num1].InnerText;
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch (Exception exception1)
            {
                document1 = null;
                ErrorLog.SaveLog("保存前置SQL至配置文件", exception1);
                return false;
            }
        }

        public bool SaveConstrast(string inCfgPath, XmlElement inFile)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/ContrastList");
                element1.RemoveAll();
                element1.SetAttribute("Delimited", inFile.GetAttribute("Delimited"));
                for (int num1 = 0; num1 < inFile.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("Contrast");
                    XmlAttribute attribute1 = document1.CreateAttribute("SourceField");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["SourceField"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("DestField");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["DestField"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Algorithm");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Algorithm"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("IsNew");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["IsNew"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("DestDBType");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["DestDBType"].Value;
                    element2.Attributes.Append(attribute1);
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveConstrast(string inCfgPath, XmlElement inFile, bool inIsDetail)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1;
                if (inIsDetail)
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Detail/ContrastList");
                }
                else
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/ContrastList");
                }
                element1.RemoveAll();
                element1.SetAttribute("Delimited", inFile.GetAttribute("Delimited"));
                for (int num1 = 0; num1 < inFile.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("Contrast");
                    XmlAttribute attribute1 = document1.CreateAttribute("SourceField");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["SourceField"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("DestField");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["DestField"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Algorithm");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Algorithm"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("IsNew");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["IsNew"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("DestDBType");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["DestDBType"].Value;
                    element2.Attributes.Append(attribute1);
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveDestDB(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/DestDB");
                element1.SetAttribute("DBType", inEle.GetAttribute("DBType"));
                element1.SetAttribute("ServerName", inEle.GetAttribute("ServerName"));
                element1.SetAttribute("DataBase", inEle.GetAttribute("DataBase"));
                element1.SetAttribute("User", inEle.GetAttribute("User"));
                element1.SetAttribute("Password", inEle.GetAttribute("Password"));
                element1.SetAttribute("DBPath", inEle.GetAttribute("DBPath"));
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveDestTable(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/DestDB/DestTable ");
                XmlElement element2 = (XmlElement)inEle.SelectSingleNode("DestDB/DestTable");
                element1.SetAttribute("TableName", element2.GetAttribute("TableName"));
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveDestTableField(string inCfgPath, XmlElement inFile)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/DestDB/DestTable");
                element1.RemoveAll();
                element1.SetAttribute("TableName", inFile.GetAttribute("TableName"));
                for (int num1 = 0; num1 < inFile.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("DestField");
                    XmlAttribute attribute1 = document1.CreateAttribute("Index");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Index"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Name");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Name"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Type");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Type"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Length");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Length"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Default");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Default"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Desc");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Desc"].Value;
                    element2.Attributes.Append(attribute1);
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveDestTableField(string inCfgPath, XmlElement inFile, bool inIsDetail)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1;
                if (inIsDetail)
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Detail/DestTable");
                }
                else
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/DestDB/DestTable");
                }
                element1.RemoveAll();
                element1.SetAttribute("TableName", inFile.GetAttribute("TableName"));
                for (int num1 = 0; num1 < inFile.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("DestField");
                    XmlAttribute attribute1 = document1.CreateAttribute("Index");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Index"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Name");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Name"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Type");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Type"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Length");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Length"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Default");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Default"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Desc");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Desc"].Value;
                    element2.Attributes.Append(attribute1);
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveEndSQL(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/EndSql");
                element1.RemoveAll();
                for (int num1 = 0; num1 < inEle.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("Sql");
                    XmlAttribute attribute1 = document1.CreateAttribute("Pattern");
                    attribute1.Value = "0";
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("ExecSort");
                    attribute1.Value = (num1 + 1).ToString();
                    element2.Attributes.Append(attribute1);
                    element2.InnerText = inEle.ChildNodes[num1].InnerText;
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch (Exception exception1)
            {
                document1 = null;
                ErrorLog.SaveLog("保存后置SQL至配置文件", exception1);
                return false;
            }
        }

        public bool SaveEndSQL(string inCfgPath, XmlElement inEle, bool inIsDetail)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1;
                if (inIsDetail)
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Detail/EndSql");
                }
                else
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/EndSql");
                }
                element1.RemoveAll();
                for (int num1 = 0; num1 < inEle.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("Sql");
                    XmlAttribute attribute1 = document1.CreateAttribute("Pattern");
                    attribute1.Value = "0";
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("ExecSort");
                    attribute1.Value = (num1 + 1).ToString();
                    element2.Attributes.Append(attribute1);
                    element2.InnerText = inEle.ChildNodes[num1].InnerText;
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch (Exception exception1)
            {
                document1 = null;
                ErrorLog.SaveLog("保存后置SQL至配置文件", exception1);
                return false;
            }
        }

        public bool SaveSourceDB(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/SourceDB");
                element1.SetAttribute("DBType", inEle.GetAttribute("DBType"));
                element1.SetAttribute("ServerName", inEle.GetAttribute("ServerName"));
                element1.SetAttribute("DataBase", inEle.GetAttribute("DataBase"));
                element1.SetAttribute("User", inEle.GetAttribute("User"));
                element1.SetAttribute("Password", inEle.GetAttribute("Password"));
                element1.SetAttribute("DBPath", inEle.GetAttribute("DBPath"));
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveSourceTable(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                ((XmlElement)document1.SelectSingleNode("Config/SourceDB/SourceTable")).SetAttribute("TableName", inEle.GetAttribute("TableName"));
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveSourceTableField(string inCfgPath, XmlElement inFile)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/SourceDB/SourceTable");
                element1.RemoveAll();
                element1.SetAttribute("TableName", inFile.GetAttribute("TableName"));
                for (int num1 = 0; num1 < inFile.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("SourceField");
                    XmlAttribute attribute1 = document1.CreateAttribute("Index");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Index"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Name");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Name"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Type");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Type"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Length");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Length"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Default");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Default"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Desc");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Desc"].Value;
                    element2.Attributes.Append(attribute1);
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch (Exception exception1)
            {
                document1 = null;
                ErrorLog.SaveLog("写源字段定义至配置文件", exception1);
                return false;
            }
        }

        public bool SaveSourceTableField(string inCfgPath, XmlElement inFile, bool inIsDetail)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1;
                if (inIsDetail)
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Detail/SourceTable");
                }
                else
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/SourceDB/SourceTable");
                }
                element1.RemoveAll();
                element1.SetAttribute("TableName", inFile.GetAttribute("TableName"));
                for (int num1 = 0; num1 < inFile.ChildNodes.Count; num1++)
                {
                    XmlElement element2 = document1.CreateElement("SourceField");
                    XmlAttribute attribute1 = document1.CreateAttribute("Index");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Index"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Name");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Name"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Type");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Type"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Length");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Length"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Default");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Default"].Value;
                    element2.Attributes.Append(attribute1);
                    attribute1 = document1.CreateAttribute("Desc");
                    attribute1.Value = inFile.ChildNodes[num1].Attributes["Desc"].Value;
                    element2.Attributes.Append(attribute1);
                    element1.AppendChild(element2);
                }
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch (Exception exception1)
            {
                document1 = null;
                ErrorLog.SaveLog("写源字段定义至配置文件", exception1);
                return false;
            }
        }

        public bool SaveSQL(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/Sqls").ChildNodes[0];
                element1.Attributes["Pattern"].Value = inEle.GetAttribute("Pattern");
                element1.Attributes["ExecSort"].Value = inEle.GetAttribute("ExecSort");
                element1.InnerText = inEle.InnerText.ToString().Trim();
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }
        //保存sqlserver的语句
        public bool SaveMSQL(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/MSqls").ChildNodes[0];
                element1.Attributes["Pattern"].Value = inEle.GetAttribute("Pattern");
                element1.Attributes["ExecSort"].Value = inEle.GetAttribute("ExecSort");
                element1.InnerText = inEle.InnerText.ToString().Trim();
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }
        //保存access的sql语句
        public bool SaveASQL(string inCfgPath, XmlElement inEle)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1 = (XmlElement)document1.SelectSingleNode("Config/ASqls").ChildNodes[0];
                element1.Attributes["Pattern"].Value = inEle.GetAttribute("Pattern");
                element1.Attributes["ExecSort"].Value = inEle.GetAttribute("ExecSort");
                element1.InnerText = inEle.InnerText.ToString().Trim();
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }

        public bool SaveSQL(string inCfgPath, XmlElement inEle, bool inIsDetail)
        {
            XmlDocument document1 = null;
            try
            {
                document1 = new XmlDocument();
                if (!File.Exists(inCfgPath))
                {
                    return false;
                }
                document1.Load(inCfgPath);
            }
            catch
            {
                return false;
            }
            try
            {
                XmlElement element1;
                if (inIsDetail)
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Detail/Sqls").ChildNodes[0];
                }
                else
                {
                    element1 = (XmlElement)document1.SelectSingleNode("Config/Sqls").ChildNodes[0];
                }
                element1.Attributes["Pattern"].Value = inEle.GetAttribute("Pattern");
                element1.Attributes["ExecSort"].Value = inEle.GetAttribute("ExecSort");
                element1.InnerText = inEle.InnerText.ToString().Trim();
                document1.Save(inCfgPath);
                document1 = null;
                return true;
            }
            catch
            {
                document1 = null;
                return false;
            }
        }


        public string CurrentCfgFile
        {
            get
            {
                return this.currentCfgFile;
            }
            set
            {
                this.currentCfgFile = value;
            }
        }

        public string CurrentCfgType
        {
            get
            {
                return this.currentCfgType;
            }
            set
            {
                this.currentCfgType = value;
            }
        }

        public string CurrentDBConStr
        {
            get
            {
                return this.currentDBConStr;
            }
            set
            {
                this.currentDBConStr = value;
            }
        }

        public string CurrentDBType
        {
            get
            {
                return this.currentDBType;
            }
            set
            {
                this.currentDBType = value;
            }
        }

        public string CurrentDBTypeDesc
        {
            get
            {
                return this.currentDBTypeDesc;
            }
            set
            {
                this.currentDBTypeDesc = value;
            }
        }

        public string CurrentExcelTemplet
        {
            get
            {
                return this.currentExcelTemplet;
            }
            set
            {
                this.currentExcelTemplet = value;
            }
        }

        public string CurrentFoxproDetailTemplet
        {
            get
            {
                return this.currentFoxproDetailTemplet;
            }
            set
            {
                this.currentFoxproDetailTemplet = value;
            }
        }

        public string CurrentMDBTemplet
        {
            get
            {
                return this.currentMDBTemplet;
            }
            set
            {
                this.currentMDBTemplet = value;
            }
        }

        public string CurrentDBName
        {
            get
            {
                return this.currentDBName;
            }
            set
            {
                this.currentDBName = value;
            }
        }
        
        public string CurrentFoxproTemplet
        {
            get
            {
                return this.currentFoxproTemplet;
            }
            set
            {
                this.currentFoxproTemplet = value;
            }
        }

        public string CurrentTxtTemplet
        {
            get
            {
                return this.currentTxtTemplet;
            }
            set
            {
                this.currentTxtTemplet = value;
            }
        }

        public XmlElement EleBeginSql
        {
            get
            {
                return this.eleBeginSql;
            }
            set
            {
                this.eleBeginSql = value;
            }
        }

        public XmlElement EleContrast
        {
            get
            {
                return this.eleContrast;
            }
            set
            {
                this.eleContrast = value;
            }
        }

        public XmlElement EleDestination
        {
            get
            {
                return this.eleDestination;
            }
            set
            {
                this.eleDestination = value;
            }
        }

        public XmlElement EleDetail
        {
            get
            {
                return this.eleDetail;
            }
            set
            {
                this.eleDetail = value;
            }
        }

        public XmlElement EleDetailBeginSql
        {
            get
            {
                return this.eleDetailBeginSql;
            }
            set
            {
                this.eleDetailBeginSql = value;
            }
        }

        public XmlElement EleDetailContrast
        {
            get
            {
                return this.eleDetailContrast;
            }
            set
            {
                this.eleDetailContrast = value;
            }
        }

        public XmlElement EleDetailEndSql
        {
            get
            {
                return this.eleDetailEndSql;
            }
            set
            {
                this.eleDetailEndSql = value;
            }
        }

        public XmlElement EleDetailSql
        {
            get
            {
                return this.eleDetailSql;
            }
            set
            {
                this.eleDetailSql = value;
            }
        }

        public XmlElement EleEndSql
        {
            get
            {
                return this.eleEndSql;
            }
            set
            {
                this.eleEndSql = value;
            }
        }

        public XmlElement EleSource
        {
            get
            {
                return this.eleSource;
            }
            set
            {
                this.eleSource = value;
            }
        }

        public XmlElement EleSql
        {
            get
            {
                return this.eleSql;
            }
            set
            {
                this.eleSql = value;
            }
        }

        public XmlElement ASql
        {
            get
            {
                return this.aSql;
            }
            set
            {
                this.aSql = value;
            }
        }

        public XmlElement MSql
        {
            get
            {
                return this.mSql;
            }
            set
            {
                this.mSql = value;
            }
        }

        public XmlElement DelSql
        {
            get
            {
                return this.delSql;
            }
            set
            {
                this.delSql = value;
            }
        }

        public bool IsMulti
        {
            get
            {
                return this.isMulti;
            }
            set
            {
                this.isMulti = value;
            }
        }

        public XmlElement RootConfig
        {
            get
            {
                return this.rootConfig;
            }
            set
            {
                this.rootConfig = value;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        //start add by gaoyuan 20070329
        public XmlElement DestTable
        {
            get
            {
                return this.destTable;
            }
            set
            {
                this.destTable = value;
            }
        }
        //end add by gaoyuan 20070329


        private static Config _intance;
        private string currentCfgFile;
        private string currentCfgType;
        private string currentDBConStr;
        private string currentDBType;
        private string currentDBTypeDesc;
        private string currentExcelTemplet;
        private string currentFoxproDetailTemplet;
        private string currentFoxproTemplet;
        private string currentMDBTemplet;
        private string currentDBName;
        private string currentTxtTemplet;
        private XmlElement eleBeginSql;
        private XmlElement eleContrast;
        private XmlElement eleDestination;
        private XmlElement eleDetail;
        private XmlElement eleDetailBeginSql;
        private XmlElement eleDetailContrast;
        private XmlElement eleDetailEndSql;
        private XmlElement eleDetailSql;
        private XmlElement eleEndSql;
        private XmlElement eleSource;
        private XmlElement eleSql;
        private XmlElement mSql;
        private XmlElement aSql;
        private XmlElement delSql;
        private bool isMulti;
        private XmlElement rootConfig;
        private string version;
        //start add by gaoyuan 20070329
        private XmlElement destTable;
        //end add by gaoyuan 20070329
    }
}

