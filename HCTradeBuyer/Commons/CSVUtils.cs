using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Emedchina.Commons
{
    public class CSVUtils
    {
        /// <summary>
        /// To the CSV（Comma Separated Values）.传入IDataReader生成csv字串,csv中的字串类型通过'"'包围，不带标题行。
        /// </summary>
        /// <param name="iDr">The i dr.</param>
        /// <returns></returns>
        public static string ToCSV(IDataReader reader)
        {
            return ToCharacterSeparatedValues(reader, ",");
        }

        /// <summary>
        /// To the CSV.用指定的txtQuotationMark包围csv中的字串内容，不带标题行。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="txtQuotationMark">The TXT quotation mark.</param>
        /// <returns></returns>
        public static string ToCSV(IDataReader reader, string txtQuotationMark)
        {
            return ToCharacterSeparatedValues(reader, ",", txtQuotationMark);
        }

        /// <summary>
        /// Toes the CSV.csv中的字串类型通过'"'包围，是否带标题行通过withHeader控制。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="withHeader">if set to <c>true</c> [with header].</param>
        /// <returns></returns>
        public static string ToCSV(IDataReader reader, bool withHeader)
        {
            return ToCharacterSeparatedValues(reader, ",", "\"", withHeader);
        }

        /// <summary>
        /// Toes the CSV.csv中的字串类型的包围控制符通过txtQuotationMark控制（可以为空），是否带标题行通过withHeader控制。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="txtQuotationMark">The TXT quotation mark.</param>
        /// <param name="withHeader">if set to <c>true</c> [with header].</param>
        /// <returns></returns>
        public static string ToCSV(IDataReader reader, string txtQuotationMark, bool withHeader)
        {
            return ToCharacterSeparatedValues(reader, ",", txtQuotationMark, withHeader);
        }

        /// <summary>
        /// To the CSV（Comma Separated Values）.传入DataTable生成csv字串。
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        public static string ToCSV(DataTable table)
        {
            IDataReader reader = new DataTableReader(table);
            return ToCSV(reader);
        }

        /// <summary>
        /// To the CSV.传入dataset生成csv字串。
        /// </summary>
        /// <param name="ds">The DataSet.</param>
        /// <returns></returns>
        public static string ToCSV(DataSet dataSet)
        {
            DataTable[] tables = new DataTable[dataSet.Tables.Count];
            dataSet.Tables.CopyTo(tables, 0);
            IDataReader reader = new DataTableReader(tables);
            return ToCSV(reader);
        }

        /// <summary>
        /// To the character separated values.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="separater">The separater string.</param>
        /// <remarks>The default quotation mark is '"'</remarks>
        /// <returns>character separated values</returns>
        public static string ToCharacterSeparatedValues(IDataReader reader, string separater)
        {
            return ToCharacterSeparatedValues(reader, separater, "\"");
        }

        /// <summary>
        /// To the character separated values.不带标题头。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="separater">The separater string.</param>
        /// <param name="txtQuotationMark">
        /// The quotation mark."'" or '"' or string.empty or others,该参数标明对于reader中的文本类型的数据是使用单引号，双引号引用还是和普通数字类型一样不用不标志。
        /// 使用者可以
        /// </param>
        /// <returns>character separated values,不带标题头。</returns>
        public static string ToCharacterSeparatedValues(IDataReader reader, string separater, string txtQuotationMark)
        {
            return ToCharacterSeparatedValues(reader, separater, txtQuotationMark, false);
        }

        /// <summary>
        /// To the character separated values.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="separater">The separater string.</param>
        /// <param name="txtQuotationMark">
        /// The quotation mark."'" or '"' or string.empty or others,该参数标明对于reader中的文本类型的数据是使用单引号，双引号引用还是和普通数字类型一样不用不标志。
        /// 使用者可以
        /// </param>
        /// <returns>character separated values</returns>
        public static string ToCharacterSeparatedValues(IDataReader reader, string separater, string txtQuotationMark, bool withHeader)
        {
            StringBuilder sb = new StringBuilder();
            char quot = '"';

            if (reader.FieldCount != 0)
            {
                //生成表头行
                if (withHeader)
                {
                    CreateHeader(reader, sb, separater, quot);
                }

                //生成实际的csv内容
                while (reader.Read())
                {
                    CreateContextLine(reader, sb, separater, txtQuotationMark);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Creates the header.创建csv文件的表头，例如从数据库表的列名生成csv表头。
        /// 返回生成的表头，使用者可以传入一个已经构造好的StringBuilder，那么新生成的表头将被填加入传入的StringBuilder中。
        /// 如果不需要可以直接传入null。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sb">The sb.</param>
        /// <param name="quot">The quot.</param>
        /// <remarks>reader应该已经打开，并且光标移动到预定位置，该方法不会打开和关闭IDataReader，也不会对IDataReader进行read操作</remarks>
        /// <returns>生成的表头</returns>
        public static string CreateHeader(IDataReader reader, StringBuilder sb, string separater, char quot)
        {
            StringBuilder header = new StringBuilder(256);
            for (int i = 0; i <= reader.FieldCount - 1; i++)
            {

                if (i < reader.FieldCount - 1)
                {
                    header.Append(quot).Append(reader.GetName(i)).Append(quot).Append(separater);
                }
                else
                {
                    header.Append(quot).Append(reader.GetName(i)).Append(quot).AppendLine();
                }
            }


            if (sb != null)
                sb.Append(header);

            return header.ToString();
        }

        /// <summary>
        /// Creates the CSV header.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sb">The sb.</param>
        /// <param name="quot">The quot.</param>
        /// <returns></returns>
        public static string CreateCSVHeader(IDataReader reader, StringBuilder sb, char quot)
        {
            return CreateHeader(reader, sb, ",", quot);
        }

        /// <summary>
        /// Creates the CSV header.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static string CreateCSVHeader(IDataReader reader, StringBuilder sb)
        {
            return CreateHeader(reader, sb, ",", '"');
        }

        /// <summary>
        /// Creates the context line.创建csv文件的一行内容，例如从数据库表的某一行生成csv的一行内容。
        /// 返回生成的一行内容，使用者可以传入一个已经构造好的StringBuilder，那么新生成的表头将被填加入传入的StringBuilder中。
        /// 如果不需要可以直接传入null。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sb">The sb.</param>
        /// <param name="txtQuotationMark">The TXT quotation mark.</param>
        /// <remarks>
        /// reader应该已经打开，并且光标移动到预定位置，该方法不会打开和关闭IDataReader，也不会对IDataReader进行read操作。
        /// 对于较大的
        /// </remarks>
        /// <returns></returns>
        public static string CreateContextLine(IDataReader reader, StringBuilder sb, string separater, string txtQuotationMark)
        {
            StringBuilder line = new StringBuilder(256);
            for (int i = 0; i <= reader.FieldCount - 1; i++)
            {
                string txtQuot = getQuot(reader, i, txtQuotationMark);
                if (i < reader.FieldCount - 1)
                {
                    //if not the last column, append the column value and a separater
                    line.Append(txtQuot).Append(reader.GetValue(i)).Append(txtQuot).Append(separater);
                }
                else
                {
                    //append the last column value then append a carriage return and line feed
                    line.Append(txtQuot).Append(reader.GetValue(i)).Append(txtQuot).AppendLine();
                }
            }


            if (sb != null)
                sb.Append(line);

            return line.ToString();
        }

        /// <summary>
        /// Creates the CSV context line.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sb">The sb.</param>
        /// <param name="txtQuotationMark">The TXT quotation mark.</param>
        /// <returns></returns>
        public static string CreateCSVContextLine(IDataReader reader, StringBuilder sb, string txtQuotationMark)
        {
            return CreateContextLine(reader, sb, ",", txtQuotationMark);
        }

        /// <summary>
        /// Creates the CSV context line.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="sb">The sb.</param>
        /// <returns></returns>
        public static string CreateCSVContextLine(IDataReader reader, StringBuilder sb)
        {
            return CreateContextLine(reader, sb, ",", "\"");
        }

        /// <summary>
        /// Gets the quot.根据当前IDataReader当前光标下index处的数据类型和传入的txtQuotationMark判断应该插入csv中的QuotationMark。
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="index">The index.</param>
        /// <param name="txtQuotationMark">The TXT quotation mark.</param>
        /// <returns></returns>
        private static string getQuot(IDataReader reader, int index, string txtQuotationMark)
        {
            if (string.IsNullOrEmpty(txtQuotationMark)) return string.Empty;

            if (reader.IsDBNull(index)) return string.Empty;

            if (!isString(reader.GetFieldType(index))) return string.Empty;

            return txtQuotationMark;
        }

        /// <summary>
        /// Determines whether the specified t is string.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>
        /// 	<c>true</c> if the specified t is string; otherwise, <c>false</c>.
        /// </returns>
        private static bool isString(Type t)
        {
            return t.FullName.Equals("".GetType().FullName);
        }

        /// <summary>
        /// 从csv文件导入到access库
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbFileName"></param>
        public static void ImportFromCsv(string tableName, string dbFileName)
        {
            Microsoft.Office.Interop.Access.ApplicationClass oAccess = new Microsoft.Office.Interop.Access.ApplicationClass();
            oAccess.Visible = false;
            if (oAccess.AutomationSecurity != Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityLow)
                oAccess.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityLow;
            try
            {

                oAccess.OpenCurrentDatabase(AppDomain.CurrentDomain.BaseDirectory + "DB\\" + dbFileName, false, "emed");
                //oAccess.DoCmd.DeleteObject(Microsoft.Office.Interop.Access.AcObjectType.acTable, tableName);
                oAccess.DoCmd.TransferText(Microsoft.Office.Interop.Access.AcTextTransferType.acImportDelim, "", tableName, AppDomain.CurrentDomain.BaseDirectory + "DB\\" + tableName + ".csv", true, "", 0);
                oAccess.CloseCurrentDatabase();
                oAccess.DoCmd.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveNone);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oAccess);
                oAccess = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从csv文件导入到access库
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbFileName"></param>
        public static void ImportFromCsv(string tableName, string apptemppath, string path)
        {
            Microsoft.Office.Interop.Access.ApplicationClass oAccess = new Microsoft.Office.Interop.Access.ApplicationClass();
            oAccess.Visible = false;
            if (oAccess.AutomationSecurity != Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityLow)
                oAccess.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityLow;
            try
            {

                oAccess.OpenCurrentDatabase(apptemppath, false, "emed");
                //oAccess.DoCmd.DeleteObject(Microsoft.Office.Interop.Access.AcObjectType.acTable, tableName);
                oAccess.DoCmd.TransferText(Microsoft.Office.Interop.Access.AcTextTransferType.acImportDelim, "", tableName, path + tableName + ".csv", true, "", 0);
                oAccess.CloseCurrentDatabase();
                oAccess.DoCmd.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveNone);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oAccess);
                oAccess = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
