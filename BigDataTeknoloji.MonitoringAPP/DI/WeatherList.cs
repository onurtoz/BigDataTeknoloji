using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using BigDataTeknoloji.Business.Services.Message.Consumer;
using BigDataTeknoloji.Business.Services.Services.Weather;
using BigDataTeknoloji.Data.Entity.Data;
using BigDataTeknolojiData.Repository.WeatherRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;


namespace BigDataTeknoloji.MonitoringAPP.DI
{
    public class WeatherList
    {
        public static ServiceResponse<List<WeatherModel>> GetAllWheater()
        {
            var serviceProvider = new ServiceCollection()
             .AddSingleton<IWeatherService, WeatherService>()
             .AddSingleton<IWeatherRepository,WeatherRepository>()
             .AddDbContext<ApplicationDbContext>
              (options => options.UseSqlServer("Server=N108382;Database=BigDataDevDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
             .BuildServiceProvider();


            IWeatherService provider = serviceProvider.GetService<IWeatherService>();
            return provider.GetAllWheater();
        }
    }
}
