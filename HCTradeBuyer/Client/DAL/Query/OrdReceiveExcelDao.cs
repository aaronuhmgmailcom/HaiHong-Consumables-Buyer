//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	OrdReceiveExcelDao.cs      
//	创 建 人:	罗澜涛
//	创建日期:	2007-5-15
//	功能描述:	到货信息导出Excel文件
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Excel;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;
using Emedchina.TradeAsst.EmedHisCommonLibrary;
using System.Collections;
using Emedchina.Commons;

namespace Emedchina.TradeAssistant.Client.DAL.Query
{
    public class OrdReceiveExcelDao
    {
        private static ArrayList ArraySql;

        private static bool ExportData10(Config inConfig, System.Data.DataTable inDt)
        {
            bool flag2;
            try
            {
                bool flag1 = true;
                string text1 = "";
                ArraySql = new ArrayList();

                for (int i = 0; i < inDt.Rows.Count; i++)
                {
                    text1 = inConfig.EleSql.InnerText.ToString().Trim();
                    text1 = ReplaceSql(text1, inDt.Rows[i], inConfig);
                    ArraySql.Add(text1);
                }
                string[] textArray1 = new string[ArraySql.Count];
                ArraySql.CopyTo(textArray1);
                flag1 = EmedDB.Transaction(textArray1);
                flag2 = flag1;
            }
            catch (Exception exception1)
            {
                ComUtil.MsgBox("导出到货错误！");
                flag2 = false;
            }
            return flag2;
        }

        private static string GetExcelConStr(Config inConfig, string inPath)
        {
            string text2;
            try
            {
                if (inConfig != null)
                {
                    return ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + inPath + ";Extended Properties=Excel 8.0");
                }
                text2 = "";
            }
            catch (Exception exception1)
            {
                ComUtil.MsgBox("Excel数据连接出错！");
                text2 = "";
            }
            return text2;
        }

        //导出作业
        public static bool ExportReceive(System.Data.DataTable inDt, string inPath)
        {
            bool flag;
            try
            {
                Config config = Config.Intance();
                EmedDB.ConnectionString = GetExcelConStr(config, inPath);

                flag = ExportData10(config, inDt);
            }
            catch (Exception exception1)
            {
                ComUtil.MsgBox("导出到货错误！");
                flag = false;
            }
            return flag;
        }

        public static bool UpdateFirstDataRow(string inFileName)
        {
            bool flag1;
            _Application application1 = new ApplicationClass();
            try
            {
                if (File.Exists(inFileName))
                {

                    Workbook workbook1 = application1.Workbooks.Open(inFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                    if (workbook1.Worksheets.Count > 0)
                    {
                        for (int num1 = 1; num1 <= workbook1.Worksheets.Count; num1++)
                        {
                            Worksheet worksheet1 = (Worksheet)workbook1.Worksheets[num1];
                            if (num1 == 1)
                            {
                                string text1 = (Config.Intance().EleSource.SelectSingleNode("SourceTable") as XmlElement).GetAttribute("TableName").ToString();
                                worksheet1.Name = text1;
                            }
                            for (int num2 = 1; num2 <= 20; num2++)
                            {
                                Excel.Range range1 = (Excel.Range)application1.Cells[2, num2];
                                if (range1.Value2 != null)
                                {
                                    string text2 = range1.Value2.ToString();
                                    if ((text2.Length > 0) && (text2[0] != '\''))
                                    {
                                        text2 = "'" + text2;
                                    }
                                    application1.Cells[2, num2] = text2;
                                }
                                else
                                {
                                    application1.Cells[2, num2] = "' ";
                                }
                            }
                        }
                    }
                    application1.DisplayAlerts = false;
                    workbook1.SaveAs(inFileName, XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    application1.Quit();
                    return true;
                }
                ComUtil.MsgBox(@"文件\" + inFileName + "\"不存在！");

                flag1 = false;
            }
            catch (Exception exception1)
            {
                ErrorLog.SaveLog("更新Excel数据", exception1);
                application1.Quit();
                flag1 = false;
            }
            finally
            {
                GC.Collect();
            }
            return flag1;
        }

        private static string ReplaceSql(string inStrSql, DataRow inDr, Config inConfig)
        {
            string text3;
            try
            {
                inStrSql = inStrSql.ToLower();
                XmlElement element1 = inConfig.EleContrast;
                XmlElement element2 = (XmlElement)inConfig.EleDestination.SelectSingleNode("DestTable");
                for (int num1 = 0; num1 < element1.ChildNodes.Count; num1++)
                {
                    string text1 = element1.ChildNodes[num1].Attributes["SourceField"].Value.Trim().ToLower();
                    if (text1 != "")
                    {
                        inStrSql = inStrSql.Replace("@" + text1, "'" + inDr[text1].ToString() + "'");
                    }
                }
                XmlElement element3 = (XmlElement)Config.Intance().EleSource.SelectSingleNode("SourceTable");
                for (int num2 = 0; num2 < element3.ChildNodes.Count; num2++)
                {
                    string text2 = element3.ChildNodes[num2].Attributes["Name"].Value.Trim().ToLower();
                    inStrSql = inStrSql.Replace("@" + text2, "'" + inDr[text2].ToString() + "'");
                }
                text3 = inStrSql;
            }
            catch (Exception ex)
            {
                ErrorLog.SaveLog("替换sql错误！", ex);
                text3 = "";
            }
            return text3;
        }
    }


}
