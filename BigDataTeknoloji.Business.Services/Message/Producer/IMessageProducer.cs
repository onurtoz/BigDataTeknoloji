using BigDataTeknoloji.Business.Model.Model.Weather;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.Message.Producer
{
    public interface IMessageProducer
    {
         void  Producer(WeatherModel model, Dictionary<string, object> configuration , string topic);
    }
}
