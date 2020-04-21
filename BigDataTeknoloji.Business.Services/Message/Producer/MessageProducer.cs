using System;
using System.Collections.Generic;
using System.Text;
using BigDataTeknoloji.Business.Model.Model.Weather;
using Confluent.Kafka;


namespace BigDataTeknoloji.Business.Services.Message.Producer
{
    public class MessageProducer : IMessageProducer
    {
        public void Producer(WeatherModel model, Dictionary<string, object> configuration, string topic)
        {
          using (var p = new Producer<Null, WeatherModel>(configuration, null, new ProducerSerializer<WeatherModel>()))
            {
                
               var t = p.ProduceAsync(topic, null, model);
                p.Flush(TimeSpan.FromMinutes(10));
                t.ContinueWith(task => {
                    if (task.IsCompleted)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
                
                    
            }

        }


    }
}
