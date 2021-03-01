using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Emedchina.TradeAsst.EmedHisCommonLibrary
{

    public class uncTxt
    {
        public bool BeginInsert(string txtFileName)
        {
            try
            {
                this.swInsert = new StreamWriter(txtFileName, false, Encoding.Default, 0x200);
                this.alInsert = new ArrayList();
                return this.ReadExpContrast();
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("初始化导出文本文件", exception1);
                this.swInsert.Close();
                return false;
            }
        }

        private static DataSet CreateDestDataSet()
        {
            try
            {
                XmlElement element1 = (XmlElement)Config.Intance().EleDestination.SelectSingleNode("DestTable");
                DataSet set1 = new DataSet();
                DataTable table1 = new DataTable(element1.Attributes["TableName"].Value);
                set1.Tables.Add(table1);
                DataColumn column1 = null;
                string text1 = "";
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    column1 = new DataColumn();
                    column1.ColumnName = element1.ChildNodes[num1].Attributes["Name"].Value;
                    text1 = element1.ChildNodes[num1].Attributes["Type"].Value.ToLower();
                    column1.DataType = uncTxt.GetDataType(text1);
                    table1.Columns.Add(column1);
                }
                return set1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("创建导入内存数据集", exception1);
                return null;
            }
        }

        public bool EndInsert()
        {
            try
            {
                this.swInsert.Close();
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("关闭导出文本文件", exception1);
                return false;
            }
        }

        public bool ExecInsert(DataRow inDataRow, bool inCheck)
        {
            try
            {
                for (int num1 = 0; num1 < this.alInsert.Count; num1++)
                {
                    if ((this.alInsert[num1] as Contrast).SrcOp.Count == 1)
                    {
                        (this.alInsert[num1] as Contrast).DestOp.Value = inDataRow[((this.alInsert[num1] as Contrast).SrcOp[0] as Operand).Name].ToString();
                    }
                }
                if (inCheck)
                {
                    for (int num2 = 0; num2 < this.alInsert.Count; num2++)
                    {
                        if (uncTxt.TestDestDataType((this.alInsert[num2] as Contrast).DestOp.Value, (this.alInsert[num2] as Contrast).DestOp.DataType, (this.alInsert[num2] as Contrast).DestOp.Name) == -1)
                        {
                            return false;
                        }
                    }
                }
                string text1 = "";
                for (int num3 = 0; num3 < (this.alInsert.Count - 1); num3++)
                {
                    text1 = text1 + (this.alInsert[num3] as Contrast).DestOp.Value + this.strDelimited;
                }
                text1 = text1 + (this.alInsert[this.alInsert.Count - 1] as Contrast).DestOp.Value;
                this.swInsert.WriteLine(text1);
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("写入导出数据", exception1);
                this.swInsert.Close();
                return false;
            }
        }

        private static DataSet ExecReader(DataSet inDataSet, ArrayList inConList, string inFileName, string inDelimited)
        {
            if (File.Exists(inFileName))
            {
                StreamReader reader1 = new StreamReader(File.OpenRead(inFileName), Encoding.Default, false, 0x200);
                while (reader1.Peek() != -1)
                {
                    string text1 = reader1.ReadLine();
                    ArrayList list1 = uncTxt.ReadOneTxtLine(text1, inDelimited);
                    if (list1 == null)
                    {
                        return null;
                    }
                    DataRow row1 = uncTxt.ReadOneTxtLineToDataRow(inDataSet.Tables[0].NewRow(), inConList, list1);
                    if (row1 == null)
                    {
                        return null;
                    }
                    inDataSet.Tables[0].Rows.Add(row1);
                }
                return inDataSet;
            }
            uncTxt.SaveErrorToLog("文件" + inFileName + "不存在", "读取指定的文本数据到数据集");
            return null;
        }

        public static DataSet getDataSet(string txtFileName)
        {
            try
            {
                ArrayList list1 = null;
                DataSet set1 = uncTxt.CreateDestDataSet();
                if (set1 != null)
                {
                    list1 = uncTxt.ReadImpContrast();
                }
                if (list1 != null)
                {
                    string text1 = Config.Intance().EleContrast.GetAttribute("Delimited");
                    if (text1 == "")
                    {
                        uncTxt.SaveErrorToLog("没有设置文本分隔符", "读取文本文件");
                        return null;
                    }
                    return uncTxt.ExecReader(set1, list1, txtFileName, text1);
                }
                return null;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取文本文件至数据集", exception1);
                return null;
            }
        }

        public static Type GetDataType(string srcType)
        {
            srcType = srcType.ToLower();
            if (srcType.IndexOf("char") == -1)
            {
                if ((srcType.IndexOf("date") != -1) | (srcType.IndexOf("time") != -1))
                {
                    return Type.GetType("System.DateTime");
                }
                if (srcType.IndexOf("number") != -1)
                {
                    return Type.GetType("System.Double");
                }
                if (srcType.IndexOf("字符型") != -1)
                {
                    return Type.GetType("System.String");
                }
                if (srcType.IndexOf("整型") != -1)
                {
                    return Type.GetType("System.Int32");
                }
                if (srcType.IndexOf("日期型") != -1)
                {
                    return Type.GetType("System.DateTime");
                }
                if (srcType.IndexOf("浮点数") != -1)
                {
                    return Type.GetType("System.Double");
                }
            }
            return Type.GetType("System.String");
        }

        private static int IndexOf(XmlNodeList inList, string inStr)
        {
            try
            {
                int num1 = -1;
                for (int num2 = 0; num2 < inList.Count; num2++)
                {
                    if (inList[num2].Attributes["Name"].Value == inStr)
                    {
                        num1 = num2;
                        break;
                    }
                }
                return num1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("查找字段索引", exception1);
                return -1;
            }
        }

        private bool ReadExpContrast()
        {
            try
            {
                this.strDelimited = Config.Intance().EleContrast.Attributes["Delimited"].Value;
                this.alInsert.Clear();
                XmlNodeList list1 = Config.Intance().EleDestination.SelectSingleNode("DestTable").ChildNodes;
                for (int num1 = 0; num1 < list1.Count; num1++)
                {
                    Contrast contrast1 = new Contrast();
                    contrast1.SrcOp = new ArrayList();
                    contrast1.DestOp.Name = list1[num1].Attributes["Name"].Value;
                    contrast1.DestOp.Index = Convert.ToInt32(list1[num1].Attributes["Index"].Value);
                    contrast1.DestOp.DataType = uncTxt.GetDataType(list1[num1].Attributes["Type"].Value);
                    contrast1.DestOp.Value = list1[num1].Attributes["Default"].Value;
                    this.alInsert.Add(contrast1);
                }
                list1 = Config.Intance().EleContrast.ChildNodes;
                for (int num2 = 0; num2 < list1.Count; num2++)
                {
                    string text1 = list1[num2].Attributes["DestField"].Value;
                    for (int num3 = 0; num3 < this.alInsert.Count; num3++)
                    {
                        if (((this.alInsert[num3] as Contrast).DestOp.Name == text1) && (list1[num2].Attributes["SourceField"].Value != ""))
                        {
                            Operand operand1 = new Operand();
                            operand1.Name = list1[num2].Attributes["SourceField"].Value;
                            (this.alInsert[num3] as Contrast).SrcOp.Add(operand1);
                        }
                    }
                }
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取导出转换规则", exception1);
                return false;
            }
        }

        private static ArrayList ReadImpContrast()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                XmlNodeList list2 = Config.Intance().EleContrast.ChildNodes;
                for (int num1 = 0; num1 < list2.Count; num1++)
                {
                    if ((list2[num1].Attributes["SourceField"].Value != "") | (list2[num1].Attributes["Algorithm"].Value != ""))
                    {
                        Contrast contrast1;
                        if (uncTxt.ReadOneImpContrast((XmlElement)list2[num1], out contrast1))
                        {
                            list1.Add(contrast1);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                return list1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取导入文本匹配规则", exception1);
                return null;
            }
        }

        private static bool ReadOneImpContrast(XmlElement inCon, out Contrast outCon)
        {
            Contrast contrast1 = new Contrast();
            contrast1.SrcOp = new ArrayList();
            contrast1.DestOp = new Operand();
            try
            {
                if (inCon.Attributes["Algorithm"].Value != "")
                {
                    string text1 = inCon.Attributes["Algorithm"].Value;
                    while (text1 != "")
                    {
                        string text2;
                        int num1 = text1.IndexOf("+");
                        if (num1 == -1)
                        {
                            text2 = text1;
                        }
                        else
                        {
                            text2 = text1.Substring(0, num1).Trim();
                        }
                        Operand operand1 = new Operand();
                        int num2 = text2.IndexOf("'");
                        if (num2 == -1)
                        {
                            operand1.Index = uncTxt.IndexOf(((XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable")).ChildNodes, text2);
                            if (operand1.Index == -1)
                            {
                                uncTxt.SaveErrorToLog("字段" + text2 + "没有找到", "读导入转换规则");
                                outCon = contrast1;
                                return false;
                            }
                            operand1.Type = OperandType.Index;
                        }
                        else
                        {
                            int num3 = text2.LastIndexOf("'");
                            if (num2 < num3)
                            {
                                operand1.Value = text2.Substring(num2 + 1, (num3 - num2) - 1);
                                operand1.Type = OperandType.Value;
                            }
                            else
                            {
                                uncTxt.SaveErrorToLog("匹配规则中，单引号设置不正确", "读导入转换规则");
                                outCon = contrast1;
                                return false;
                            }
                        }
                        contrast1.SrcOp.Add(operand1);
                        if (num1 == -1)
                        {
                            text1 = "";
                        }
                        else
                        {
                            text1 = text1.Substring(num1 + 1, (text1.Length - num1) - 1);
                        }
                    }
                }
                else if (inCon.Attributes["SourceField"].Value != "")
                {
                    Operand operand2 = new Operand();
                    operand2.Index = uncTxt.IndexOf(((XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable")).ChildNodes, inCon.Attributes["SourceField"].Value);
                    if (operand2.Index == -1)
                    {
                        uncTxt.SaveErrorToLog("字段" + inCon.Attributes["SourceField"].Value + "没有找到", "读导入转换规则");
                        outCon = contrast1;
                        return false;
                    }
                    operand2.Type = OperandType.Index;
                    contrast1.SrcOp.Add(operand2);
                }
                contrast1.DestOp.Name = inCon.Attributes["DestField"].Value;
                contrast1.DestOp.Type = OperandType.Name;
                contrast1.DestOp.DataType = uncTxt.GetDataType(inCon.Attributes["DestDBType"].Value);
                outCon = contrast1;
                return true;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取一个文本文件导入匹配规则", exception1);
                outCon = contrast1;
                return false;
            }
        }

        private static ArrayList ReadOneTxtLine(string inStr, string inDelimited)
        {
            ArrayList list2;
            try
            {
                ArrayList list1 = new ArrayList();
                int num1 = -1;
                if (inStr != null)
                {
                    goto Label_006D;
                }
                return null;
            Label_000F:
                num1 = inStr.IndexOf(inDelimited);
                switch (num1)
                {
                    case -1:
                        list1.Add(inStr);
                        goto Label_007A;

                    case 0:
                        list1.Add("");
                        break;

                    default:
                        inStr.Substring(0, num1);
                        list1.Add(inStr.Substring(0, num1));
                        break;
                }
                inStr = inStr.Substring(num1 + inDelimited.Length, (inStr.Length - num1) - inDelimited.Length);
            Label_006D:
                if (inStr != "")
                {
                    goto Label_000F;
                }
            Label_007A:
                list2 = list1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("读取一行文本内容", exception1);
                list2 = null;
            }
            return list2;
        }

        private static DataRow ReadOneTxtLineToDataRow(DataRow inRow, ArrayList inConList, ArrayList inSrcList)
        {
            try
            {
                string text1 = "";
                for (int num1 = 0; num1 < inConList.Count; num1++)
                {
                    Contrast contrast1 = inConList[num1] as Contrast;
                    text1 = "";
                    if (contrast1.SrcOp.Count == 1)
                    {
                        if ((contrast1.SrcOp[0] as Operand).Type == OperandType.Value)
                        {
                            text1 = (contrast1.SrcOp[0] as Operand).Value;
                        }
                        if ((contrast1.SrcOp[0] as Operand).Type == OperandType.Index)
                        {
                            text1 = inSrcList[(contrast1.SrcOp[0] as Operand).Index] as string;
                        }
                        switch (uncTxt.TestDestDataType(text1, contrast1.DestOp.DataType, contrast1.DestOp.Name))
                        {
                            case 1:
                                inRow[contrast1.DestOp.Name] = text1;
                                break;

                            case -1:
                                return null;
                        }
                    }
                    else
                    {
                        for (int num3 = 0; num3 < contrast1.SrcOp.Count; num3++)
                        {
                            if ((contrast1.SrcOp[num3] as Operand).Type == OperandType.Value)
                            {
                                text1 = text1 + (contrast1.SrcOp[num3] as Operand).Value;
                            }
                            if ((contrast1.SrcOp[num3] as Operand).Type == OperandType.Index)
                            {
                                text1 = text1 + inSrcList[(contrast1.SrcOp[num3] as Operand).Index];
                            }
                        }
                        if (uncTxt.TestDestDataType(text1, contrast1.DestOp.DataType, contrast1.DestOp.Name) == 1)
                        {
                            inRow[contrast1.DestOp.Name] = text1;
                        }
                    }
                }
                return inRow;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("转换一行文本数据至DataRow", exception1);
                return null;
            }
        }

        private static void SaveErrorToLog(string inErrorLog, string inSQL)
        {
            string text1 = Application.StartupPath + @"\ErrorLog.txt";
            try
            {
                StreamWriter writer1 = new StreamWriter(text1, true);
                writer1.WriteLine(DateTime.Now.ToString() + ":");
                writer1.WriteLine(inErrorLog);
                writer1.WriteLine(inSQL);
                writer1.Close();
            }
            catch (Exception exception1)
            {
                string text2 = exception1.Message;
            }
        }

        private static int TestDestDataType(string inData, Type inType, string inDestName)
        {
            try
            {
                if (inType != Type.GetType("System.String"))
                {
                    if (inType == Type.GetType("System.Int32"))
                    {
                        if (inData == "")
                        {
                            return 0;
                        }
                        Convert.ToInt32(inData);
                    }
                    else if (inType == Type.GetType("System.Double"))
                    {
                        if (inData == "")
                        {
                            return 0;
                        }
                        Convert.ToDouble(inData);
                    }
                    else if (inType == Type.GetType("System.DateTime"))
                    {
                        if (inData == "")
                        {
                            return 0;
                        }
                        Convert.ToDateTime(inData);
                    }
                }
                return 1;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("字段 " + inDestName + " 数据 " + inData + " 不能转化为" + inType.FullName, exception1);
                return -1;
            }
        }


        private ArrayList alInsert;
        private string strDelimited;
        private StreamWriter swInsert;


        private class Contrast
        {
            public Contrast()
            {
                this.srcOp = new ArrayList();
                this.destOp = new uncTxt.Operand();
            }


            public uncTxt.Operand DestOp
            {
                get
                {
                    return this.destOp;
                }
                set
                {
                    this.destOp = value;
                }
            }

            public ArrayList SrcOp
            {
                get
                {
                    return this.srcOp;
                }
                set
                {
                    this.srcOp = value;
                }
            }


            private uncTxt.Operand destOp;
            private ArrayList srcOp;
        }

        private class Operand
        {
            public Operand()
            {
                this.index = 0;
                this.invalue = "";
                this.name = "";
            }


            public System.Type DataType
            {
                get
                {
                    return this.dataType;
                }
                set
                {
                    this.dataType = value;
                }
            }

            public int Index
            {
                get
                {
                    return this.index;
                }
                set
                {
                    this.index = value;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }

            public uncTxt.OperandType Type
            {
                get
                {
                    return this.type;
                }
                set
                {
                    this.type = value;
                }
            }

            public string Value
            {
                get
                {
                    return this.invalue;
                }
                set
                {
                    this.invalue = value;
                }
            }


            private System.Type dataType;
            private int index;
            private string invalue;
            private string name;
            private uncTxt.OperandType type;
        }

        private enum OperandType
        {
            Index,
            Value,
            Name
        }
    }
}

