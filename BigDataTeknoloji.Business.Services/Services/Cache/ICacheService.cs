using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigDataTeknoloji.Business.Services.Services.Cache
{
    public interface ICacheService
    {
        ServiceResponse<WeatherModel> GetCacheWheaterByLocationName(string locationName);

       bool SetCacheWheaterByLocationName(WeatherModel model,string locationName);
    }
}
