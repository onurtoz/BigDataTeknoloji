using BigDataTeknoloji.Data.Entity.Entities;
using BigDataTeknolojiData.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknolojiData.Repository.WeatherRepository
{
    public interface IWeatherRepository: IGenericRepository<Location>
    {
    }
}
