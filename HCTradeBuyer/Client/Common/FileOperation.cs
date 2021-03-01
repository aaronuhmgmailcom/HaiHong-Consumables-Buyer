#region Header
//======================================================================================
//	Copyright (c)  Emedchina
//	�� �� ��:	FileOperation.cs    
//	�� �� ��:	��ԭ
//	��������:	2006-11-10
//	��������:	�����ļ��Ĳ�������
//	�� �� ��: 
//	�޸�����:
//	��Ҫ�޸�����:
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
        #region ��DataTable������Excel�ļ���
        /// <summary>
        /// ��DataTable������Excel�ļ���
        /// </summary>
        /// <param name="strTargetPath">�ļ���ַ</param>
        /// <param name="strFileName">�ļ���</param>
        /// <param name="dt">��������DataTable����</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt,string fileName)
        {
            bool flag = false;
            try
            {
                ////�жϲ�����Ч��
                //if (strFileName.Trim().CompareTo("") == 0 || dt == null || dt.Rows.Count == 0)
                //{
                //    return false;
                //}
                //�жϲ�����Ч��
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //����excel����
                Excel.Application excelMatching = new Excel.ApplicationClass();
                Excel._Workbook xBk = excelMatching.Workbooks.Add(true);//����excel������
                Excel._Worksheet xSt = (Excel.Worksheet)xBk.ActiveSheet;

                //excelMatching.Workbooks.Add(true);//����excel������

                //�����ݱ�ĸ�����Ϣ���뵽excel����
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
                //����
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

        #region ��DataTable������Excel�ļ���(����1)
        /// <summary>
        /// ��DataTable������Excel�ļ���(����1)
        /// </summary>
        /// <param name="strTargetPath">�ļ���ַ</param>
        /// <param name="strFileName">�ļ���</param>
        /// <param name="dt">��������DataTable����</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt,out string strOut)
        {
            strOut = "";
            bool flag = false;
            try
            {
                ////�жϲ�����Ч��
                //if (strFileName.Trim().CompareTo("") == 0 || dt == null || dt.Rows.Count == 0)
                //{
                //    return false;
                //}
                //�жϲ�����Ч��
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //����excel����
                Excel.Application excelMatching = new Excel.Application();
                excelMatching.Workbooks.Add(true);//����excel������

                //�����ݱ�ĸ�����Ϣ���뵽excel����
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
                //ʹexcel�ɼ�
                //excelMatching.Visible = true;                
                //excelMatching.Save(strTargetPath + "\\" + strFileName);
                //excelMatching.Save("data");                         
                //����
                //excelMatching.Workbooks[1].SaveCopyAs(strTargetPath + "\\" + strFileName);
                //excelMatching.Workbooks[1].Saved = false;
                //excelMatching.UserControl = false;                
                //string strSaveFileName = (string)excelMatching.GetSaveAsFilename("a", "Excel�ĵ�(*.xls)|*.xls", 0, "b", "c");                
                excelMatching.Workbooks[1].Saved = true;
                excelMatching.UserControl = false;
                strOut = (string)excelMatching.GetSaveAsFilename("�ƻ�����ʧ���б�", "excel (*.xls), *.xls", 0, "����", "����");
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

        #region ��DataTable������Excel�ļ���
        /// <summary>
        /// ��DataTable������Excel�ļ���
        /// </summary>
        /// <param name="strTargetPath">�ļ���ַ</param>
        /// <param name="strFileName">�ļ���</param>
        /// <param name="dt">��������DataTable����</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt, string fileName, string[] strarr)
        {
            bool flag = false;
            try
            {
                ////�жϲ�����Ч��
                //if (strFileName.Trim().CompareTo("") == 0 || dt == null || dt.Rows.Count == 0)
                //{
                //    return false;
                //}
                //�жϲ�����Ч��
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //����excel����
                Excel.Application excelMatching = new Excel.Application();
                excelMatching.Workbooks.Add(true);//����excel������

                //�����ݱ�ĸ�����Ϣ���뵽excel����
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
                //����
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
            //����һ�� DataSet����
            DataSet myDataSet = new DataSet();
            OdbcConnection myConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=C:\\Documents and Settings\\gaoyuan.EMEDCHINA\\����");
            //OdbcConnection myConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=D:\\");
            //������
            myConn.Open();

            //��ѯ
            strCom = "SELECT * FROM fg";
            //���������ӣ��õ�һ�����ݼ�
            OdbcDataAdapter myCommand = new OdbcDataAdapter(strCom, myConn);
            //������ݼ�
            //myCommand.Fill(myDataSet, strTableName);
            myCommand.Fill(myDataSet, "fg");
            myConn.Close();
            return myDataSet.Tables[0];
        }

        #region ��DataTable������.dbf�ļ���
        /// <summary>
        /// ��DataTable������.dbf�ļ���
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dIO">����--1\����--0</param>
        /// <returns></returns>
        public static bool ExportDBFFile(DataTable dt,int dIO,string strFileName)
        {
            bool flag = false;
            
            //�������ļ����ȡ����
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

            //�����ļ�
            //���Դ�ļ�·�����ļ���
            string strcon = ClientConfiguration.ConnectionStringEx;
            int index = strcon.IndexOf("SourceDB=");
            //string FileName1 = strcon.Substring(index + 9) + strTableName + ".dbf";
            string FileName1 = strcon.Substring(index + 9) + "ReceiveExportTemplete.dbf";
            //���Ŀ���ļ�·�����ļ���            
            index = strFileName.LastIndexOf("\\");
            //TargetPath = "D:\\";
            string TargetPath = strFileName.Substring(0, index + 1);
            int index2 = strFileName.ToLower().LastIndexOf(".dbf");
            string TargetFileName = strFileName.Substring(index + 1,index2 - index - 1);
            string FileName2 = TargetPath + TargetFileName + ".dbf";
            
            //���Դ�ļ������ڷ���false
            if (!File.Exists(FileName1))
            {
                return false;
            }
            //���Ŀ���ļ��Ѵ��ڣ���ɾ��
            if (File.Exists(FileName2))
            {
                File.Delete(FileName2);
            }
            
            //����
            File.Copy(FileName1, FileName2);
            
            //����µ������ַ���
            string newConn = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + TargetPath;

            string strCom = "";
            //����һ�� DataSet����
            DataSet myDataSet = new DataSet();

            OdbcConnection myConn = new OdbcConnection(newConn);
            //OdbcConnection myConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=C:\\Documents and Settings\\gaoyuan.EMEDCHINA\\����");

            try
            {
                //������
                myConn.Open();

                //ɾ��������
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

                //��ѯ
                strCom = "SELECT * FROM " + TargetFileName;
                //���������ӣ��õ�һ�����ݼ�
                OdbcDataAdapter myCommand = new OdbcDataAdapter(strCom, myConn);               

                //������ݼ�
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
                //myTran = myConn.BeginTransaction();//��������Ӻ��������
                //myComm.Transaction = myTran;//��ͼ�������ݿ�TestDB
                //myComm.CommandText = "CREATE database TestDB";
                //myComm.ExecuteNonQuery();//�ύ����
                //myTran.Commit();

               
                //�رմ���������
                myConn.Close();
                flag = true;
            }
            catch
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
                //���Ŀ���ļ��Ѵ��ڣ���ɾ��
                if (File.Exists(FileName2))
                {
                    File.Delete(FileName2);
                }
                return false;
            }
            return flag;
        }
        #endregion

        #region ��ýڵ����
        /// <summary>
        /// ��ýڵ����
        /// </summary>
        /// <param name="strFilePath">�ļ�·��</param>
        /// <param name="strNodePath">�ڵ�·��</param>
        /// <returns>�ڵ���󣬵��ڵ㲻���ڷ���null</returns>
        public static XmlNode GetNodeObject(string strFilePath, string strNodePath)
        {
            XmlNode xn = null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilePath);

                xn = xmlDoc.SelectSingleNode(strNodePath);
                XmlElement e = (XmlElement)xn;
                //�ж��Ƿ����ָ���ڵ�
                if (e == null)
                {
                    //��������ڷ���null
                    xn = null;
                }
            }
            catch
            {                
                throw;
            }
            
            //����
            return xn;
        }
        #endregion

        #region �޸Ľڵ�����ֵ
        /// <summary>
        /// �޸Ľڵ�����ֵ
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

                //��ȡstrPrarentNodePath�ڵ�������ӽڵ�
                XmlNodeList nodeList = xmlDoc.SelectSingleNode(strPrarentNodePath).ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    //�ж��Ƿ����ָ���ڵ�
                    if (xe == null)
                    {
                        //��������ڷ���null
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

        #region �޸Ľڵ�����ֵ(����1)
        /// <summary>
        /// �޸Ľڵ�����ֵ(����1)
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

                //��ȡstrPrarentNodePath�ڵ�������ӽڵ�
                XmlNode xn = xmlDoc.SelectSingleNode(strNodePath);
                XmlElement xe = (XmlElement)xn;
                //�ж��Ƿ����ָ���ڵ�
                if (xe == null)
                {
                    //��������ڷ���null
                    xn = null;
                }        
                //����ڵ�����
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

        #region ��ýڵ�����ֵ(����1)
        /// <summary>
        /// ��ýڵ����
        /// </summary>
        /// <param name="strFilePath">�ļ�·��</param>
        /// <param name="strPrarentNodePath">���ڵ�·��</param>
        /// <param name="strFlag">����������</param>
        /// <param name="strFlagValue">��������ֵ</param>
        /// <param name="strTarget">Ŀ��������</param>
        /// <returns>�ɹ���Ŀ������ֵ��ʧ�ܣ�null</returns>
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

                //��ȡstrPrarentNodePath�ڵ�������ӽڵ�
                XmlNodeList nodeList = xmlDoc.SelectSingleNode(strPrarentNodePath).ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    //�ж��Ƿ����ָ���ڵ�
                    if (xe == null)
                    {
                        //��������ڷ���null
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
            //����
            return strRtn;
        }
        #endregion

        #region ��ȡ�ɹ��ƻ������ļ���Ϣ
        /// <summary>
        /// ��ȡ�ɹ��ƻ������ļ���Ϣ
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <returns></returns>
        public static string GetHisPlanFile(string strFlagValue)
        {
            return GetNodeObject("data.xml", "ConfigInfo/HisPlan", "Item", strFlagValue, "Value");
        }
        #endregion

        #region ��ȡ������Ϣ�����ļ���Ϣ
        /// <summary>
        /// ��ȡ������Ϣ�����ļ���Ϣ
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <returns></returns>
        public static string GetOrderReceiveFile(string strFlagValue)
        {
            return GetNodeObject("data.xml", "ConfigInfo/OrderReceive", "Item", strFlagValue, "Value");
        }
        #endregion

        #region �޸Ĳɹ��ƻ������ļ���Ϣ
        /// <summary>
        /// �޸Ĳɹ��ƻ������ļ���Ϣ
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <param name="strTargetValue"></param>
        /// <returns></returns>
        public static bool ModifyHisPlanNode(string strFlagValue, string strTargetValue)
        {
            return ModifyNode("data.xml", "ConfigInfo/HisPlan", "Item", strFlagValue, "Value", strTargetValue);
        }
        #endregion

        #region �޸ĵ�����Ϣ�����ļ���Ϣ
        /// <summary>
        /// �޸ĵ�����Ϣ�����ļ���Ϣ
        /// </summary>
        /// <param name="strFlagValue"></param>
        /// <param name="strTargetValue"></param>
        /// <returns></returns>
        public static bool ModifyOrderReceiveNode(string strFlagValue,string strTargetValue)
        {
            return ModifyNode("data.xml", "ConfigInfo/OrderReceive", "Item", strFlagValue, "Value",strTargetValue);
        }
        #endregion

        #region ��ýڵ�����ֵ
        /// <summary>
        /// ��ýڵ�����ֵ
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="strAttrName"></param>
        /// <returns></returns>
        public static string GetNodeValue(XmlNode xn, string strAttrName)
        {
            string strNodeValue = null;
            try
            {
                //�������ڵ�Ϊnull,����null
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


        #region ��DataTable������Excel�ļ��� �����ֶ���Ŀ����Ŀ������Զ���
        /// <summary>
        /// ��DataTable������Excel�ļ���
        /// </summary>
        /// <param name="strTargetPath">�ļ���ַ</param>
        /// <param name="strFileName">�ļ���</param>
        /// <param name="dt">��������DataTable����</param>
        /// <returns>true:success/false:faile</returns>
        public static bool ExportExcelFile(DataTable dt, string fileName, string[] strarr,string [] strcolnameArr)
        {
            bool flag = false;
            try
            {
                //�жϲ�����Ч��
                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }
                //����excel����
                Excel.Application excelMatching = new Excel.Application();
                excelMatching.Workbooks.Add(true);//����excel������

                //�����ݱ�ĸ�����Ϣ���뵽excel����
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
                //����
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
