using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Business.Model.ExternalModel.DarkSKY
{
    public class DarkSKYModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeZone { get; set; }
        public DataPoint Currently { get; set; }
        public DataBlock Minutely { get; set; }
        public DataBlock Hourly { get; set; }
        public DataBlock Daily { get; set; }
      
    }

    public class DataBlock
    {
        public List<DataPoint> Data { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
    }
   
    public class DataPoint
    {
        public double? ApparentTemperature { get; set; }
        public double? ApparentTemperatureMax { get; set; }
        public int? ApparentTemperatureMaxTime { get; set; }
        public double? ApparentTemperatureMin { get; set; }
        public int? apparentTemperatureMinTime { get; set; }
        public double? CloudCover { get; set; }
        public double? DewPoint { get; set; }
        public double? Humidity { get; set; }
        public string Icon { get; set; }
        public string MoonPhase { get; set; }
        public double? NearestStormBearing { get; set; }
        public double? NearestStormDistance { get; set; }
        public double? Ozone { get; set; }
        public double? PrecipAccumulation { get; set; }
        public double? PrecipIntensity { get; set; }
        public double? PrecipIntensityMax { get; set; }
        public int? PrecipIntensityMaxTime { get; set; }
        public double? PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double? Pressure { get; set; }
        public string Summary { get; set; }
        public int? SunriseTime { get; set; }
        public int? SunsetTime { get; set; }
        public double? Temperature { get; set; }
        public double? TemperatureMax { get; set; }
        public int? TemperatureMaxTime { get; set; }
        public double? TemperatureMin { get; set; }
        public int? TemperatureMinTime { get; set; }
        public string Time { get; set; }
        public int? UVIndexTime { get; set; }
        public double? Visibility { get; set; }
        public double? WindBearing { get; set; }
        public double? WindGust { get; set; }
        public int? WindGustTime { get; set; }
        public double? WindSpeed { get; set; }
    }
}
