using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.WeatherDTO
{
    public interface IWeatherDTO
    {
        ServiceResponse<WeatherModel> GetWheaterByLocationName(string locationName);
        WeatherModel AddWheater(WeatherModel weatherModel,string Keys,bool flag);
    }
}
