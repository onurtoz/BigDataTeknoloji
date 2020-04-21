using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BigDataTeknoloji.Business.Model.Model.Weather;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace BigDataTeknoloji.Business.Services.Message.Consumer
{
    public class MesageConsumer : IMessageConsumer
    {
        public Task<WeatherModel> Listen(Dictionary<string, object> configuration, string topic)
        {
            WeatherModel weatherModel = new WeatherModel();

            using (var consumer = new Consumer<Ignore, WeatherModel>(configuration, null, new ConsumerDeserialize<WeatherModel>()))
            {
                consumer.Subscribe(topic);
                consumer.OnMessage += (_, message) =>
                {
                    weatherModel = message.Value;


                };
                while (true)
                {
                   
                    consumer.Poll(10000);
                }

            }

           
        }
    }
}
