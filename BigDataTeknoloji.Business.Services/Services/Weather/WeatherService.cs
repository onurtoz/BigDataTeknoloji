using System;
using System.Collections.Generic;
using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using BigDataTeknoloji.Data.Entity.Entities;
using BigDataTeknolojiData.Repository.WeatherRepository;

namespace BigDataTeknoloji.Business.Services.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        private List<WeatherModel> weatherModels = new List<WeatherModel>();
        private WeatherModel weatherModel = new WeatherModel();
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public ServiceResponse<List<WeatherModel>> GetAllWheater()
        {
            var responseService = new ServiceResponse<List<WeatherModel>>();
            var dateFrom = DateTime.ParseExact(currentDate.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var locations = _weatherRepository.FindAll(x=>x.Created.Equals(dateFrom));
            foreach (var location in locations)
            {
                weatherModels.Add(new WeatherModel
                {
                    LocationName = location.LocationName,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    TodaysTempature = location.TodaysTempature,
                    LowestTempature = location.LowestTempature,
                    HighestTempature = location.HighestTempature

                });
            }

            responseService.Entity = weatherModels;

            return  responseService;
        }

        public ServiceResponse<WeatherModel> GetWheaterByLocationName(string locationName)
        {
            var responseService = new ServiceResponse<WeatherModel>();
            var locations = _weatherRepository.GetSingleProperties(x => x.LocationName.Equals(locationName),null);
            if (locations != null)
            {
                weatherModel.LocationName = locations.LocationName;
                weatherModel.Latitude = locations.Latitude;
                weatherModel.Longitude = locations.Longitude;
                weatherModel.TodaysTempature = locations.TodaysTempature;
                weatherModel.LowestTempature = locations.LowestTempature;
                weatherModel.HighestTempature = locations.HighestTempature;
                responseService.Entity = weatherModel;
            }
            return responseService;
        }

       public ServiceResponse<int> AddWheater(WeatherModel weatherModel)
        {
            var response = new ServiceResponse<int>();
            var dateFrom = DateTime.ParseExact(currentDate.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            try
            {
                Location newlocation = new Location();
                newlocation.LocationName = weatherModel.LocationName;
                newlocation.Longitude = weatherModel.Longitude;
                newlocation.Latitude = weatherModel.Latitude;
                newlocation.LowestTempature = weatherModel.LowestTempature;
                newlocation.TodaysTempature = weatherModel.TodaysTempature;
                newlocation.HighestTempature = weatherModel.HighestTempature;
                newlocation.Created = dateFrom;
                newlocation.Modified = dateFrom;

                int process = _weatherRepository.Add(newlocation);
            }
            catch (Exception ex)
            {

                response.ExceptionMessage = ex.Message;
            }
          
            return response;
        }

     
    }
}
