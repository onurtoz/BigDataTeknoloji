using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BigDataTeknoloji.Business.Services.Message.Consumer
{
    public class ConsumerDeserialize<T> : IDeserializer<T>
    {
        public IEnumerable<KeyValuePair<string, object>>
             Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
                 => config;


        public T Deserialize(string topic, byte[] data)
        {
            if (data == null)
                return default(T);
            IFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                var obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        public void Dispose()
        {
           
            throw new NotImplementedException();
        }
    }
}
