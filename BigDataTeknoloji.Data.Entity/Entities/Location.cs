using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Data.Entity.Entities
{
    public class Location:BaseEntity
    {
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double TodaysTempature { get; set; }
        public double LowestTempature { get; set; }
        public double HighestTempature { get; set; }
    }
}
