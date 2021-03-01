#region Header
/*****************************************************************************
 * $Header: /TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data/DataFormatter.cs 1     06-09-04 10:00 Sunhl $
 * $Author: Sunhl $
 * $Revision: 1 $
 * $Date: 06-09-04 10:00 $
 * $History: DataFormatter.cs $
 * 
 * *****************  Version 1  *****************
 * User: Sunhl        Date: 06-09-04   Time: 10:00
 * Created in $/TradeAssistantSaler.root/TradeAssistantSaler/Commons/Data
 * 新添加,dataSet和dataTable的序列化与反序列化
 ********************************************************************************/
#endregion

#region using
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
#endregion

namespace Emedchina.Commons.Data
{
    /// <summary>
    /// 用二进制格式序列化和反序列化DataSet和DataTable
    /// </summary>
    public class DataFormatter
    {
        private DataFormatter() { }

        /// <summary>
        /// Serialize the Data of dataSet to binary format
        /// </summary>
        /// <param name="dsOriginal"></param>
        /// <returns></returns>
        static public byte[] GetBinaryFormatData(DataSet dsOriginal)
        {
            byte[] binaryDataResult = null;
            MemoryStream memStream = new MemoryStream();
            IFormatter brFormatter = new BinaryFormatter();
            dsOriginal.RemotingFormat = SerializationFormat.Binary;

            brFormatter.Serialize(memStream, dsOriginal);
            binaryDataResult = memStream.ToArray();
            memStream.Close();
            memStream.Dispose();
            return binaryDataResult;
        }

        /// <summary>
        /// Retrieve dataSet from data of binary format
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        static public DataSet RetrieveDataSet(byte[] binaryData)
        {
            DataSet dataSetResult = null;
            MemoryStream memStream = new MemoryStream(binaryData);
            IFormatter brFormatter = new BinaryFormatter();

            object obj = brFormatter.Deserialize(memStream);
            dataSetResult = (DataSet)obj;
            return dataSetResult;
        }

        /// <summary>
        /// Serialize the Data of dataTable to binary format
        /// </summary>
        /// <param name="dtOriginal"></param>
        /// <returns></returns>
        static public byte[] GetBinaryFormatData(DataTable dtOriginal)
        {
            byte[] binaryDataResult = null;
            MemoryStream memStream = new MemoryStream();
            IFormatter brFormatter = new BinaryFormatter();
            dtOriginal.RemotingFormat = SerializationFormat.Binary;

            brFormatter.Serialize(memStream, dtOriginal);
            binaryDataResult = memStream.ToArray();
            memStream.Close();
            memStream.Dispose();
            return binaryDataResult;
        }

        /// <summary>
        /// Retrieve DataTable from data of binary format
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        static public DataTable RetrieveDataTable(byte[] binaryData)
        {
            DataTable dataTableResult = null;
            MemoryStream memStream = new MemoryStream(binaryData);
            IFormatter brFormatter = new BinaryFormatter();

            object obj = brFormatter.Deserialize(memStream);
            dataTableResult = (DataTable)obj;
            return dataTableResult;
        }

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <param name="dtOriginal">The dt original.</param>
        /// <param name="file">The file.</param>
        static public void SerializeToFile(DataSet dsOriginal, string file)
        {
            IFormatter brFormatter = new BinaryFormatter();
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            brFormatter.Serialize(fs, dsOriginal);
            fs.Close();
            fs.Dispose();
        }

        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static DataSet DeSerializeDataSet(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            IFormatter brFormatter = new BinaryFormatter();

            object obj = brFormatter.Deserialize(fs);
            DataSet dataSetResult = (DataSet)obj;

            return dataSetResult;
        }

        /// <summary>
        /// Serializes to file.
        /// </summary>
        /// <param name="dtOriginal">The dt original.</param>
        /// <param name="file">The file.</param>
        static public void SerializeToFile(DataTable dtOriginal, string file)
        {
            IFormatter brFormatter = new BinaryFormatter();
            dtOriginal.RemotingFormat = SerializationFormat.Binary;
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            brFormatter.Serialize(fs, dtOriginal);
            fs.Close();
            fs.Dispose();

        }

        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static DataTable DeSerializeDataTable(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            IFormatter brFormatter = new BinaryFormatter();

            object obj = brFormatter.Deserialize(fs);
            DataTable dataTableResult = (DataTable)obj;

            return dataTableResult;
        }

        #region 还在调试中,不要使用
        /// <summary>
        /// Serialize the Data of dataTable to binary format
        /// 还在调试中,不要使用
        /// </summary>
        /// <param name="dtOriginal"></param>
        /// <returns></returns>
        static public byte[] GetBinaryFormatDataZip(DataTable dtOriginal)
        {
            byte[] binaryDataResult = null;
            MemoryStream memStream = new MemoryStream();
            IFormatter brFormatter = new BinaryFormatter();
            dtOriginal.RemotingFormat = SerializationFormat.Binary;
            GZipStream zip = new GZipStream(memStream, CompressionMode.Compress);

            brFormatter.Serialize(zip, dtOriginal);
            binaryDataResult = memStream.ToArray();
            memStream.Close();
            memStream.Dispose();
            return binaryDataResult;
        }

        /// <summary>
        /// Retrieve DataTable from data of binary format
        /// 还在调试中,不要使用
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        static public DataTable RetrieveDataTableZip(byte[] binaryData)
        {
            DataTable dataTableResult = null;

            IFormatter brFormatter = new BinaryFormatter();
            MemoryStream zipMemStream = new MemoryStream(binaryData);
            GZipStream zipStream = new GZipStream(zipMemStream, CompressionMode.Decompress);
            int zipCount = binaryData.Length;
            byte[] decompressedBuffer = new byte[zipCount * 3];
            // Use the ReadAllBytesFromStream to read the stream.
            int totalCount = DataFormatter.ReadAllBytesFromStream(zipStream, decompressedBuffer);
            MemoryStream memStream = new MemoryStream(decompressedBuffer);
            Console.WriteLine("size:{0}--{1}", zipCount, totalCount);

            object obj = brFormatter.Deserialize(memStream);
            dataTableResult = (DataTable)obj;
            return dataTableResult;
        }
        #endregion

        /// <summary>
        /// Reads all bytes from stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">The buffer.</param>
        /// <returns></returns>
        public static int ReadAllBytesFromStream(Stream stream, byte[] buffer)
        {
            // Use this method is used to read all bytes from a stream.
            int offset = 0;
            int totalCount = 0;
            while (true)
            {
                int bytesRead = stream.Read(buffer, offset, 100);
                if (bytesRead == 0)
                {
                    break;
                }
                offset += bytesRead;
                totalCount += bytesRead;
            }
            return totalCount;
        }

    }
}
