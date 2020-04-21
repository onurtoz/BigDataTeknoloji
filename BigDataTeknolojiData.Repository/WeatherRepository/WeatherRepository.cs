using BigDataTeknoloji.Data.Entity.Data;
using BigDataTeknoloji.Data.Entity.Entities;
using BigDataTeknolojiData.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigDataTeknolojiData.Repository.WeatherRepository
{
    public class WeatherRepository: GenericRepository<Location>, IWeatherRepository
    {

        public WeatherRepository(ApplicationDbContext dbContext) : base(dbContext){}

        public override int Add(Location t)
        {
            return base.Add(t);
        }

        public override IEnumerable<Location> FindAll(Expression<Func<Location, bool>> match)
        {
            return base.FindAll(match).ToList();
        }

        public override Location GetSingleProperties(Func<Location, bool> where, Expression<Func<Location, object>> navigationProperties)
        {
            return base.GetSingleProperties(where, navigationProperties);
        }

    }
}
