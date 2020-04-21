using BigDataTeknoloji.Business.Services.Services.Weather;
using BigDataTeknoloji.Data.Entity.Data;
using BigDataTeknoloji.Data.Entity.Entities;
using BigDataTeknoloji.MonitoringAPP.DI;
using BigDataTeknolojiData.Repository.WeatherRepository;
using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BigDataTeknoloji.MonitoringAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var response = WeatherList.GetAllWheater();
           
            var tableLocation = new ConsoleTable("LocationName", "Latitude", "Longitude", "TodaysTempature", "LowestTempature", "HighestTempature");
            foreach (var location in response.Entity)
            {
                tableLocation.AddRow(location.LocationName, location.Latitude,location.Longitude,location.TodaysTempature,location.LowestTempature,location.HighestTempature);
            }

             Console.WriteLine(tableLocation);
            var result = InstantWheater.GetWheater();
            if (result.IsCompleted)
            {
                tableLocation.AddRow(result.Result.LocationName, result.Result.Latitude, result.Result.Longitude, result.Result.TodaysTempature, result.Result.LowestTempature, result.Result.HighestTempature);
                Console.WriteLine(tableLocation);
            }

            
            Console.ReadLine();


        }
    }
}
