using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigDataTeknoloji.Business.Services.Services.Weather
{
    public interface IWeatherService
    {
        ServiceResponse<List<WeatherModel>> GetAllWheater();
        ServiceResponse<WeatherModel> GetWheaterByLocationName(string locationName);
        ServiceResponse<int> AddWheater(WeatherModel weatherModel);
    }
}
