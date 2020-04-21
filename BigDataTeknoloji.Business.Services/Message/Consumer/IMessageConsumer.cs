using BigDataTeknoloji.Business.Model.Model.Weather;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigDataTeknoloji.Business.Services.Message.Consumer
{
    public interface IMessageConsumer
    {

        Task<WeatherModel> Listen(Dictionary<string, object> configuration, string topic);
    }
}
