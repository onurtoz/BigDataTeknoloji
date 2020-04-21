using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;


namespace BigDataTeknoloji.Business.Services.Services.Cache
{
    public class CacheManager:ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private WeatherModel weatherModel = new WeatherModel();
      
        public CacheManager(IMemoryCache memoryCache)
        {
           
            _memoryCache = memoryCache;
         
        }

        public ServiceResponse<WeatherModel> GetCacheWheaterByLocationName(string cacheKey)
        {
            var responseService = new ServiceResponse<WeatherModel>();

            if (_memoryCache.TryGetValue(cacheKey, out WeatherModel response))
            {
                weatherModel.LocationName = response.LocationName;
                weatherModel.Latitude = response.Latitude;
                weatherModel.Longitude = response.Longitude;
                weatherModel.TodaysTempature = response.TodaysTempature;
                weatherModel.LowestTempature = response.LowestTempature;
                weatherModel.HighestTempature = response.HighestTempature;
                responseService.Entity = weatherModel;
            }
      
            return responseService;
        }

        public bool SetCacheWheaterByLocationName(WeatherModel model, string cacheKey)
        {

            var cacheEntryOptions = new MemoryCacheEntryOptions()

                .SetSize(50)

                .SetSlidingExpiration(TimeSpan.FromHours(1));

            _memoryCache.Set(cacheKey, model, cacheEntryOptions);


            return true;
        }
    }
}
