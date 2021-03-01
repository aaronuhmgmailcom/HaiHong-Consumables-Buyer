using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Emedchina.Commons
{
    public class DataSerialization
    {
        /// <summary>
        /// 序列化ｄａｔａｓｅｔ
        /// </summary>
        /// <param name="ds"></param>
        public static byte[] SerializeData(DataSet ds)
        {
            ds.RemotingFormat = SerializationFormat.Binary;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, ds);
            byte[] e = ms.ToArray();
            return e;
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static DataSet UnSerializeData(byte[] e)
        {
            MemoryStream ms = new MemoryStream(e);
            IFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(ms);
            DataSet dsResult = (DataSet)obj;
            ms.Close();
            return dsResult;
        }
    }
}
