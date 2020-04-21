using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Model.Model.Weather
{
    [Serializable]
    public class WeatherModel
    {
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double TodaysTempature { get; set; }
        public double LowestTempature { get; set; }
        public double HighestTempature { get; set; }
    }

}
