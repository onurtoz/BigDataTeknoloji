using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using BigDataTeknoloji.Business.Services.ExternalServices.DarkSKY;
using BigDataTeknoloji.Business.Services.Message.Producer;
using BigDataTeknoloji.Business.Services.Services;
using BigDataTeknoloji.Business.Services.Services.Cache;
using BigDataTeknoloji.Business.Services.Services.Weather;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.WeatherDTO
{
    public class WeatherDTO : IWeatherDTO
    {
        private readonly ICacheService _redisService;
        private readonly IWeatherService _weatherService;
        private readonly IDarkSKYService _darkSKYService;
        private readonly IMessageProducer _messageProducer;

        public WeatherDTO(ICacheService redisService, IWeatherService weaterService, IDarkSKYService darkSKYService, IMessageProducer mesageProducer)
        {
            _darkSKYService = darkSKYService;
            _redisService = redisService;
            _weatherService = weaterService;
            _messageProducer = mesageProducer;
        }

        public WeatherModel AddWheater(WeatherModel weatherModel, string Keys, bool flag)
        {


            if (flag) { var database_result = _weatherService.AddWheater(weatherModel); }
            var result = _redisService.SetCacheWheaterByLocationName(weatherModel, Keys);
            if (result)
            {
                try
                {
                    var config = new Dictionary<string, object> {

                            {ProducerConfig.BootstrapServers,ProducerConfig.ServerUrl}
                        };
                    _messageProducer.Producer(weatherModel, config, ProducerConfig.TopicName);
                }
                catch (Exception ex)
                {
                    return weatherModel;
                }
                

            }
            return weatherModel;
        }

        public ServiceResponse<WeatherModel> GetWheaterByLocationName(string locationName)
        {
            var cachedItem = _redisService.GetCacheWheaterByLocationName(locationName);

            if (cachedItem.Entity == null)
            {
                var databaseItem = _weatherService.GetWheaterByLocationName(locationName).Entity;

                try
                {
                    WeatherModel cacheEntry = (databaseItem != null) ?
                    this.AddWheater(databaseItem, locationName, false) : this.AddWheater(_darkSKYService.GetTempatureofLocation(locationName).Entity, locationName, true);
                    cachedItem.Entity = cacheEntry;
                }
                catch (Exception ex)
                {
                    cachedItem.ExceptionMessage = ex.Message;
                }

            }

            return cachedItem;

        }
    }
}
