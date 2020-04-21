using Confluent.Kafka.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BigDataTeknoloji.Business.Services.Message.Producer
{
    public class ProducerSerializer<T> : ISerializer<T> 
    {
        public IEnumerable<KeyValuePair<string, object>>
            Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
                => config;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize(string topic,T data)
        {
           
            MemoryStream ms = SerializeToStream(data);
            return ms.ToArray();
        }

        public static MemoryStream SerializeToStream(object o)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream;
        }
    }

}
