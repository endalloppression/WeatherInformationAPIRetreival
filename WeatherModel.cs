using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformationAPIRetreival
{
    public class WeatherModel
    {
        public List<Audit> data { get; set; }
        public string city_name { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public string lat { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
    }
    
    public class Audit
    {
        public DateTime timestamp_utc { get; set; }
        public int snow { get; set; }
        public double temp { get; set; }
        public DateTime timestamp_local { get; set; }
        public int ts { get; set; }
        public int precip { get; set; }
    }


}
