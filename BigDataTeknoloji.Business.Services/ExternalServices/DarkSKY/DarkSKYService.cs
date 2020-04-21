using BigDataTeknoloji.Business.Model.ExternalModel.DarkSKY;
using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using BigDataTeknoloji.Business.Services.ExternalServices.LocationIQ;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Services.ExternalServices.DarkSKY
{
    public class DarkSKYService: IDarkSKYService
    {
        private RestClient client;
        private readonly ILocationService _locationService;
        private readonly DarkSKYConfig _config;
        private WeatherModel weatherModel = new WeatherModel();
        public DarkSKYService(IOptions<DarkSKYConfig> config, ILocationService locationService)
        {
            _config = config.Value;
            client = new RestClient(_config.ServiceUrl);
            _locationService = locationService; 
        }

        public ServiceResponse<WeatherModel> GetTempatureofLocation(string locationName)
        {
            double maximumtemp = 0, minumumtemp = 100;
        
            var responseService = new ServiceResponse<WeatherModel>();
            var request = new RestRequest();
            var responsefromlocationService = _locationService.GetLocation(locationName);
            if (responsefromlocationService != null)
            {
                request.AddParameter("latitude", responsefromlocationService.Entity.lat.ToString().Replace(',', '.'), ParameterType.UrlSegment);
                request.AddParameter("longitude", responsefromlocationService.Entity.lon.ToString().Replace(',', '.'), ParameterType.UrlSegment);
                request.AddParameter("secretKey", _config.Key, ParameterType.UrlSegment);
                request.Resource = "{secretKey}/{latitude},{longitude}";
                try
                {
                    IRestResponse responseclient = client.Execute<DarkSKYModel>(request);
                    if (responseclient.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = JsonConvert.DeserializeObject<DarkSKYModel>(responseclient.Content);
                        weatherModel.LocationName = responsefromlocationService.Entity.display_name.Substring(0, responsefromlocationService.Entity.display_name.IndexOf(","));
                        weatherModel.Latitude = content.Latitude;
                        weatherModel.Longitude = content.Longitude;
                        weatherModel.TodaysTempature = (double)content.Currently.ApparentTemperature;
                        foreach (var contentDaily in content.Daily.Data)
                        {
                            if (maximumtemp < contentDaily.ApparentTemperatureMax) { maximumtemp = (double)contentDaily.ApparentTemperatureMax; }
                            if (minumumtemp > contentDaily.ApparentTemperatureMin) { minumumtemp = (double)contentDaily.ApparentTemperatureMin; }
                        }

                        weatherModel.LowestTempature = minumumtemp;
                        weatherModel.HighestTempature = maximumtemp;
                        responseService.Entity = weatherModel;
                    }
                    else { responseService.ExceptionMessage = System.Net.HttpStatusCode.NotFound.ToString() + "Not Found"; }
                }
                catch (Exception ex)
                {

                    responseService.ExceptionMessage = ex.Message;
                }
            }
            
          
            return responseService;
        }
    }
}
