using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using C1.C1Zip;
using System.Runtime.Serialization.Formatters.Binary;

namespace Emedchina.Commons
{
    public class CompressUtil
    {
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public static void CompressFile(string sourceFile)
        {
            try
            {
                using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] buffer = new byte[sourceStream.Length];
                    int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);

                    using (FileStream destinationStream = new FileStream(sourceFile + ".cps", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (GZipStream compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true))
                        {
                            compressedStream.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public static void DecompressFile(string sourceFile, string destinationFile)
        {
            try
            {
                using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open))
                {
                    byte[] quartetBuffer = new byte[4];
                    int position = (int)sourceStream.Length - 4;
                    sourceStream.Position = position;
                    sourceStream.Read(quartetBuffer, 0, 4);
                    sourceStream.Position = 0;
                    int checkLength = BitConverter.ToInt32(quartetBuffer, 0);
                    byte[] buffer = new byte[checkLength + 100];
                    using (GZipStream decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true))
                    {
                        int total = 0;
                        for (int offset = 0; ; )
                        {
                            int bytesRead = decompressedStream.Read(buffer, offset, 100);
                            if (bytesRead == 0) break;
                            offset += bytesRead;
                            total += bytesRead;
                        }
                        using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create))
                        {
                            destinationStream.Write(buffer, 0, total);
                            destinationStream.Flush();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        /// 压缩对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object CompressData(object data)
        {
            C1ZStreamWriter zipStream = null;
            byte[] buffer = null;

            MemoryStream memStream = new MemoryStream();
            try
            {
                if (data != null)
                {
                    zipStream = new C1ZStreamWriter(memStream, CompressionLevelEnum.BestCompression);
                    new BinaryFormatter().Serialize(zipStream, data);
                    buffer = new byte[memStream.Length];
                    buffer = memStream.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (zipStream != null)
                {
                    zipStream.Close();
                }
                if (memStream != null)
                {
                    memStream.Close();
                }
            }
            return buffer;
        }


        /// <summary>
        /// 解压缩对象
        /// </summary>
        /// <returns></returns>
        public static object Decompression(object data)
        {
            object obj = null;
            C1ZStreamReader zipStream = null;
            MemoryStream memStream = null;
            try
            {
                if (data != null)
                {
                    memStream = new MemoryStream((byte[])data);
                    zipStream = new C1ZStreamReader(memStream);
                    obj = new BinaryFormatter().Deserialize(zipStream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (zipStream != null)
                {
                    zipStream.Close();
                }
                if (memStream != null)
                {
                    memStream.Close();
                }
            }
            return obj;
        }
    }
}
