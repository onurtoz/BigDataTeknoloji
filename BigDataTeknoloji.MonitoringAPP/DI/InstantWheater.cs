using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using BigDataTeknoloji.Business.Services.Message.Consumer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigDataTeknoloji.MonitoringAPP.DI
{
    public class InstantWheater
    {
        public async static Task<WeatherModel> GetWheater()
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<IMessageConsumer, MesageConsumer>()
          
           .BuildServiceProvider();

            var config = new Dictionary<string, object> {

                            {"group.id",ConsumerConfig.GroupId},
                            {"bootstrap.servers",ConsumerConfig.BootstrapServers },
                            {"auto.offset.reset",ConsumerConfig.AutoOffsetReset}
                        };

            IMessageConsumer provider = serviceProvider.GetService<IMessageConsumer>();
            return await provider.Listen(config,ConsumerConfig.TopicName);
        }
       
    }
}
