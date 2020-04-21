using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.Message.Producer
{
   public class ProducerConfig
    {
        public static string BootstrapServers = "bootstrap.servers";
        public static string ServerUrl = "localhost:9092";
        public static string TopicName = "wheaterTopic";
    }
}
