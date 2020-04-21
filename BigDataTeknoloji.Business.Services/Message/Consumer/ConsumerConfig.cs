using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.Message.Consumer
{
   public class ConsumerConfig
    {
        public static string GroupId = "wheatermessage-consumer-group";
        public static string BootstrapServers = "localhost:9092";
        public static string AutoOffsetReset = "latest";
        public static string TopicName = "wheaterTopic";

    }
}
