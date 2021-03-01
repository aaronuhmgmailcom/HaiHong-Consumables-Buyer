#region Header
//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	FileOperation.cs    
//	创 建 人:	高原
//	创建日期:	2006-11-10
//	功能描述:	常用文件的操作方法
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
#endregion
#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.OleDb;
using System.Data;
using Emedchina.TradeAssistant.Client;
using System.Data.Odbc;
using System.IO;
#endregion

namespace Emedchina.TradeAssistant.Client.Common
{
    public class FileOperation
    {
        #region 将DataTable到出到Excel文件中
        /// <summary>
        /// 将DataTable到出到Excel文件中
        /// </summary>
        /// <param name="strTargetPath">文件地址</param>
        /// <param name="strFileName">文件明</param>
        /// <param name="dt">待导出的DataTable对象</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt,string fileName)
        {
            bool flag = false;
            try
            {
                ////判断参数有效性
                //if (strFileName.Trim().CompareTo("") == 0 || dt == null || dt.Rows.Count == 0)
                //{
                //    return false;
                //}
                //判断参数有效性
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //创建excel对象
                Excel.Application excelMatching = new Excel.ApplicationClass();
                Excel._Workbook xBk = excelMatching.Workbooks.Add(true);//创建excel工作薄
                Excel._Worksheet xSt = (Excel.Worksheet)xBk.ActiveSheet;

                //excelMatching.Workbooks.Add(true);//创建excel工作薄

                //把数据表的各个信息输入到excel表中
                for (int i = 0; i < dt.Rows.Count + 1; i++)
                {                    
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        int temp = j + 1;
                        if (i == 0)
                        {
                            if (dt.Columns[j].ColumnName.ToString() == ("F" + temp.ToString()) )
                            {
                                continue;
                            }
                            excelMatching.Cells[i + 1, j + 1] = dt.Columns[j].ColumnName.ToString().ToLower();
                        }
                        else
                        {
                            if (dt.Columns[j].ColumnName.ToString() == ("F" + temp.ToString()))
                            {
                                continue;
                            }
                            //xSt.get_Range(excelMatching.Cells[i + 1, j + 1], excelMatching.Cells[i + 1, j + 1]).HorizontalAlignment = Excel.XlVAlign.xlVAlignBottom;
                            xSt.get_Range(excelMatching.Cells[i + 1, j + 1], excelMatching.Cells[i + 1, j + 1]).NumberFormat = "@"; 
                            excelMatching.Cells[i + 1, j + 1] = dt.Rows[i - 1][j].ToString();                           
                        }                        
                    }
                }                                
                //保存
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                excelMatching.Workbooks[1].Saved = true;
                excelMatching.UserControl = false;
                excelMatching.Workbooks[1].SaveCopyAs(fileName);
                excelMatching.Quit();

                flag = true;
            }
            catch
            {                
                throw;
            }
            return flag;
        }
        #endregion

        #region 将DataTable到出到Excel文件中(重载1)
        /// <summary>
        /// 将DataTable到出到Excel文件中(重载1)
        /// </summary>
        /// <param name="strTargetPath">文件地址</param>
        /// <param name="strFileName">文件明</param>
        /// <param name="dt">待导出的DataTable对象</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt,out string strOut)
        {
            strOut = "";
            bool flag = false;
            try
            {
                ////判断参数有效性
                //if (strFileName.Trim().CompareTo("") == 0 || dt == null || dt.Rows.Count == 0)
                //{
                //    return false;
                //}
                //判断参数有效性
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //创建excel对象
                Excel.Application excelMatching = new Excel.Application();
                excelMatching.Workbooks.Add(true);//创建excel工作薄

                //把数据表的各个信息输入到excel表中
                for (int i = 0; i < dt.Rows.Count + 1; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        int temp = j + 1;
                        if (i == 0)
                        {
                            if (dt.Columns[j].ColumnName.ToString() == ("F" + temp.ToString()))
                            {
                                continue;
                            }
                            excelMatching.Cells[i + 1, j + 1] = dt.Columns[j].ColumnName.ToString();
                        }
                        else
                        {
                            if (dt.Columns[j].ColumnName.ToString() == ("F" + temp.ToString()))
                            {
                                continue;
                            }
                            excelMatching.Cells[i + 1, j + 1] = dt.Rows[i - 1][j].ToString();
                        }
                    }
                }
                //使excel可见
                //excelMatching.Visible = true;                
                //excelMatching.Save(strTargetPath + "\\" + strFileName);
                //excelMatching.Save("data");                         
                //保存
                //excelMatching.Workbooks[1].SaveCopyAs(strTargetPath + "\\" + strFileName);
                //excelMatching.Workbooks[1].Saved = false;
                //excelMatching.UserControl = false;                
                //string strSaveFileName = (string)excelMatching.GetSaveAsFilename("a", "Excel文档(*.xls)|*.xls", 0, "b", "c");                
                excelMatching.Workbooks[1].Saved = true;
                excelMatching.UserControl = false;
                strOut = (string)excelMatching.GetSaveAsFilename("计划导入失败列表", "excel (*.xls), *.xls", 0, "保存", "保存");
                //excelMatching.Save(strOut);
                excelMatching.Workbooks[1].SaveCopyAs(strOut);
                excelMatching.Quit();

                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }
        #endregion

        #region 将DataTable到出到Excel文件中
        /// <summary>
        /// 将DataTable到出到Excel文件中
        /// </summary>
        /// <param name="strTargetPath">文件地址</param>
        /// <param name="strFileName">文件明</param>
        /// <param name="dt">待导出的DataTable对象</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt, string fileName, string[] strarr)
        {
            bool flag = false;
            try
            {
                ////判断参数有效性
                //if (strFileName.Trim().CompareTo("") == 0 || dt == null || dt.Rows.Count == 0)
                //{
                //    return false;
                //}
                //判断参数有效性
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //创建excel对象
                Excel.Application excelMatching = new Excel.Application();
                excelMatching.Workbooks.Add(true);//创建excel工作薄

                //把数据表的各个信息输入到excel表中
                for (int i = 0; i < dt.Rows.Count + 1; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        int temp = j + 1;
                        if (i == 0)
                        {
                            if (dt.Columns[j].ColumnName.ToString() == ("F" + temp.ToString()))
                            {
                                continue;
                            }
                            excelMatching.Cells[i + 1, j + 1] = strarr[j];
                        }
                        else
                        {
                            if (dt.Columns[j].ColumnName.ToString() == ("F" + temp.ToString()))
                            {
                                continue;
                            }
                            excelMatching.Cells[i + 1, j + 1] = dt.Rows[i - 1][j].ToString();
                        }
                    }
                }
                //保存
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                excelMatching.Workbooks[1].Saved = true;
                excelMatching.UserControl = false;
                excelMatching.Workbooks[1].SaveCopyAs(fileName);
                excelMatching.Quit();

                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }
        #endregion

        public static DataTable Read()
        {
            string strCom = "";
            //创建一个 DataSet对象
            DataSet myDataSet = new DataSet();
            OdbcConnection myConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=C:\\Documents and Settings\\gaoyuan.EMEDCHINA\\桌面");
            //OdbcConnection myConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=D:\\");
            //打开连接
            myConn.Open();

            //查询
            strCom = "SELECT * FROM fg";
            //打开数据链接，得到一个数据集
            OdbcDataAdapter myCommand = new OdbcDataAdapter(strCom, myConn);
            //填充数据集
            //myCommand.Fill(myDataSet, strTableName);
            myCommand.Fill(myDataSet, "fg");
            myConn.Close();
            return myDataSet.Tables[0];
        }

        #region 将DataTable导出到.dbf文件中
        /// <summary>
        /// 将DataTable导出到.dbf文件中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dIO">导出--1\导入--0</param>
        /// <returns></returns>
        public static bool ExportDBFFile(DataTable dt,int dIO,string strFileName)
        {
            bool flag = false;
            
            //从配置文件里读取表名
            string strTableName = "";
            if (dIO == 0)
            {
                strTableName = GetNodeValue(GetNodeObject("ConfigInfo.xml", "config/dbType/fxp"), "tablename");
            }
            else if (dIO == 1)
            {
                strTableName = GetNodeValue(GetNodeObject("ConfigInfo.xml", "config/dbType/fxp"), "tablenameEx");
            }
            
            if (strTableName == "" || strTableName == null)
            {
                return false;
            }

            //拷贝文件
            //获得源文件路径及文件名
            string strcon = ClientConfiguration.ConnectionStringEx;
            int index = strcon.IndexOf("SourceDB=");
            //string FileName1 = strcon.Substring(index + 9) + strTableName + ".dbf";
            string FileName1 = strcon.Substring(index + 9) + "ReceiveExportTemplete.dbf";
            //获得目标文件路径及文件名            
            index = strFileName.LastIndexOf("\\");
            //TargetPath = "D:\\";
            string TargetPath = strFileName.Substring(0, index + 1);
            int index2 = strFileName.ToLower().LastIndexOf(".dbf");
            string TargetFileName = strFileName.Substring(index + 1,index2 - index - 1);
            string FileName2 = TargetPath + TargetFileName + ".dbf";
            
            //如果源文件不存在返回false
            if (!File.Exists(FileName1))
            {
                return false;
            }
            //如果目标文件已存在，先删除
            if (File.Exists(FileName2))
            {
                File.Delete(FileName2);
            }
            
            //拷贝
            File.Copy(FileName1, FileName2);
            
            //获得新的联接字符串
            string newConn = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + TargetPath;

            string strCom = "";
            //创建一个 DataSet对象
            DataSet myDataSet = new DataSet();

            OdbcConnection myConn = new OdbcConnection(newConn);
            //OdbcConnection myConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=C:\\Documents and Settings\\gaoyuan.EMEDCHINA\\桌面");

            try
            {
                //打开连接
                myConn.Open();

                //删除所有列
                //OdbcCommand cmd = new OdbcCommand();
                //cmd.Connection = myConn;
                //string sql = "delete from " + strTableName;
                //cmd.CommandText = sql;
                //cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();

                //OdbcCommand odbcComm = new OdbcCommand(sql, myConn);
                //odbcComm.Connection.Open();
                //odbcComm.ExecuteNonQuery();
                //odbcComm.Transaction.Commit();

                //查询
                strCom = "SELECT * FROM " + TargetFileName;
                //打开数据链接，得到一个数据集
                OdbcDataAdapter myCommand = new OdbcDataAdapter(strCom, myConn);               

                //填充数据集
                //myCommand.Fill(myDataSet, TargetFileName);
                myCommand.Fill(myDataSet, TargetFileName);

                DataRow row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = myDataSet.Tables[TargetFileName].NewRow();
                    row.ItemArray = dr.ItemArray;
                    myDataSet.Tables[TargetFileName].Rows.Add(row);
                }

                OdbcCommandBuilder builder = new OdbcCommandBuilder(myCommand);
                myCommand.InsertCommand = builder.GetInsertCommand();

                myCommand.Update(myDataSet, TargetFileName);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    StringBuilder sqlInsert = new StringBuilder();
                //    sqlInsert.Append(" Insert Into ");
                //    sqlInsert.Append(TargetFileName);
                //    sqlInsert.Append(" ( ");
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {

                //    }
                //    sqlInsert.Append(myDataSet.Tables[0].Columns[i].ColumnName.ToString());
                //    //"Insert Into table1(DateFrom, Num) Values({^2005-09-10},10)";
                //}

                //string sqlInsert = "Insert Into table1(DateFrom, Num) Values({^2005-09-10},10)";
                //OdbcCommand odbcComm = new OdbcCommand(sqlInsert, myConn);
                //odbcComm.Connection.Open();
                //odbcComm.ExecuteNonQuery();

                //SqlConnection myConn = GetConn();
                //myConn.Open();
                //OdbcCommand myComm = new OdbcCommand();
                //OdbcTransaction myTran;
                //myTran = myConn.BeginTransaction();//下面绑定连接和事务对象
                //myComm.Transaction = myTran;//试图创建数据库TestDB
                //myComm.CommandText = "CREATE database TestDB";
                //myComm.ExecuteNonQuery();//提交事务
                //myTran.Commit();

               
                //关闭此数据链接
                myConn.Close();
                flag = true;
            }
            catch
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
                //如果目标文件已存在，先删除
                if (File.Exists(FileName2))
                {
                    File.Delete(FileName2);
                }
                return false;
            }
            return flag;
        }
        #endregion

        #region 获得节点对象
        /// <summary>
        /// 获得节点对象
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="strNodePath">节点路径</param>
        /// <returns>节点对象，当节点不存在返回null</returns>
        public static XmlNode GetNodeObject(string strFilePath, string strNodePath)
        {
            XmlNode xn = null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);

                xn = xmlDoc.SelectSingleNode(strNodePath);
                XmlElement e = (XmlElement)xn;
                //判断是否存在指定节点
                if (e == null)
                {
                    //如果不存在返回null
                    xn = null;
                }
            }
            catch
            {                
                throw;
            }
            
            //返回
            return xn;
        }
        #endregion

        #region 修改节点属性值
        /// <summary>
        /// 修改节点属性值
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strPrarentNodePath"></param>
        /// <param name="strFlag"></param>
        /// <param name="strFlagValue"></param>
        /// <param name="strTarget"></param>
        /// <param name="strTargetValue"></param>
        /// <returns></returns>
        public static bool ModifyNode(string strFilePath, string strPrarentNodePath, string strFlag, string strFlagValue, string strTarget,string strTargetValue)
        {
            bool sof = false;
            if (strFilePath == "" || strPrarentNodePath == "" || strFlag == "" || strFlagValue == "" || strTarget == "")
            {
                return false;
            }
            //string strRtn = null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);

                //获取strPrarentNodePath节点的所有子节点
                XmlNodeList nodeList = xmlDoc.SelectSingleNode(strPrarentNodePath).ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    //判断是否存在指定节点
                    if (xe == null)
                    {
                        //如果不存在返回null
                        return false;
                    }
                    if (xe.GetAttribute(strFlag) == strFlagValue)
                    {
                        xe.SetAttribute(strTarget, strTargetValue);                                               
                    }
                }
                xmlDoc.Save(strFilePath);
                sof = true;
            }
            catch
            {
                throw;
            }
            return sof;
        }
        #endregion

        #region 修改节点属性值(重载1)
        /// <summary>
        /// 修改节点属性值(重载1)
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strNodePath"></param>
        /// <param name="strTarget"></param>
        /// <param name="strTargetValue"></param>
        /// <returns></returns>
        public static bool ModifyNode(string strFilePath, string strNodePath, string strTarget, string strTargetValue)
        {
            bool sof = false;
            if (strFilePath == "" || strNodePath == "" || strTarget == "")
            {
                return false;
            }
            //string strRtn = null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);

                //获取strPrarentNodePath节点的所有子节点
                XmlNode xn = xmlDoc.SelectSingleNode(strNodePath);
                XmlElement xe = (XmlElement)xn;
                //判断是否存在指定节点
                if (xe == null)
                {
                    //如果不存在返回null
                    xn = null;
                }        
                //变更节点属性
                xe.SetAttribute(strTarget, strTargetValue);                
                xmlDoc.Save(strFilePath);
                sof = true;
            }
            catch
            {
                throw;
            }
            return sof;
        }
        #endregion

        #region 获得节点属性值(重载1)
        /// <summary>
        /// 获得节点对象
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        /// <param name="strPrarentNodePath">父节点路径</param>
        /// <param name="strFlag">参照属性名</param>
        /// <param name="strFlagValue">参照属性值</param>
        /// <param name="strTarget">目标属性名</param>
        /// <returns>成功：目标属性值，失败：null</returns>
        public static string GetNodeObject(string strFilePath, string strPrarentNodePath,string strFlag,string strFlagValue,string strTarget)
        {
            if (strFilePath == "" || strPrarentNodePath == "" || strFlag == "" || strFlagValue == "" || strTarget == "")
            {
                return null;
            }
            string strRtn = null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);

                //获取strPrarentNodePath节点的所有子节点
                XmlNodeList nodeList = xmlDoc.SelectSingleNode(strPrarentNodePath).ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    //判断是否存在指定节点
                    if (xe == null)
                    {
                        //如果不存在返回null
                        return null;
                    }
                    if (xe.GetAttribute(strFlag) == strFlagValue)
                    {
                        strRtn = xe.GetAttribute(strTarget);
                        return strRtn;
                    }
                }                
            }
            catch
            {                
                throw;
            }            
            //返回
            return strRtn;
        }
        #endregion

        #region 获取采购计划配置文件信息
        /// <summary>
        /// 获取采购计划配置文件信息
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <returns></returns>
        public static string GetHisPlanFile(string strFlagValue)
        {
            return GetNodeObject("data.xml", "ConfigInfo/HisPlan", "Item", strFlagValue, "Value");
        }
        #endregion

        #region 获取到货信息配置文件信息
        /// <summary>
        /// 获取到货信息配置文件信息
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <returns></returns>
        public static string GetOrderReceiveFile(string strFlagValue)
        {
            return GetNodeObject("data.xml", "ConfigInfo/OrderReceive", "Item", strFlagValue, "Value");
        }
        #endregion

        #region 修改采购计划配置文件信息
        /// <summary>
        /// 修改采购计划配置文件信息
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <param name="strTargetValue"></param>
        /// <returns></returns>
        public static bool ModifyHisPlanNode(string strFlagValue, string strTargetValue)
        {
            return ModifyNode("data.xml", "ConfigInfo/HisPlan", "Item", strFlagValue, "Value", strTargetValue);
        }
        #endregion

        #region 修改到货信息配置文件信息
        /// <summary>
        /// 修改到货信息配置文件信息
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <param name="strTargetValue"></param>
        /// <returns></returns>
        public static bool ModifyOrderReceiveNode(string strFlagValue,string strTargetValue)
        {
            return ModifyNode("data.xml", "ConfigInfo/OrderReceive", "Item", strFlagValue, "Value",strTargetValue);
        }
        #endregion

        #region 获得节点属性值
        /// <summary>
        /// 获得节点属性值
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="strAttrName"></param>
        /// <returns></returns>
        public static string GetNodeValue(XmlNode xn, string strAttrName)
        {
            string strNodeValue = null;
            try
            {
                //如果传入节点为null,返回null
                if (xn == null)
                {
                    return null;
                }
                XmlElement xe = (XmlElement)xn;
                strNodeValue = xe.GetAttribute(strAttrName);
            }
            catch
            {                
                throw;
            }
            
            return strNodeValue;
        }
        #endregion


        #region 将DataTable到出到Excel文件中 导出字段项目和项目标题可自定义
        /// <summary>
        /// 将DataTable到出到Excel文件中
        /// </summary>
        /// <param name="strTargetPath">文件地址</param>
        /// <param name="strFileName">文件明</param>
        /// <param name="dt">待导出的DataTable对象</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt, string fileName, string[] strarr,string [] strcolnameArr)
        {
            bool flag = false;
            try
            {
                //判断参数有效性
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //创建excel对象
                Excel.Application excelMatching = new Excel.Application();
                excelMatching.Workbooks.Add(true);//创建excel工作薄

                //把数据表的各个信息输入到excel表中
                for (int i = 0; i < dt.Rows.Count + 1; i++)
                {
                    for (int j = 0; j < strcolnameArr.Length; j++)
                    {
                        if (i == 0)
                        {
                            excelMatching.Cells[i + 1, j + 1] = strarr[j];
                        }
                        else
                        {
                            excelMatching.Cells[i + 1, j + 1] = dt.Rows[i - 1][strcolnameArr[j].ToString()].ToString();
                        }
                    }
                }
                //保存
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                excelMatching.Workbooks[1].Saved = true;
                excelMatching.UserControl = false;
                excelMatching.Workbooks[1].SaveCopyAs(fileName);
                excelMatching.Quit();

                flag = true;
            }
            catch
            {
                throw;
            }
            return flag;
        }
        #endregion

    }
}
