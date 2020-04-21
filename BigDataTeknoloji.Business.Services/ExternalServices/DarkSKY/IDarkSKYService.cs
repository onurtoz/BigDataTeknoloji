using BigDataTeknoloji.Business.Model.ExternalModel.DarkSKY;
using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.ExternalServices.DarkSKY
{
    public interface IDarkSKYService
    {
        ServiceResponse<WeatherModel> GetTempatureofLocation(string locationName);
    }
}
