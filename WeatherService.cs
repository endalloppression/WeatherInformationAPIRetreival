using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformationAPIRetreival
{
    public static class WeatherService
    {
        private const string units = @"I";//default unit is Imperial/Farenheit
        private const string key = @"24d6f2a2e84849e2aaa77f8e372ba681";
        private const string baseURL = @"https://api.weatherbit.io/v2.0/forecast/";
        public static void DisplayWeather(IList<String> zipCodes)
        {
            var httpClient = new HttpClient();
            var myURL = string.Empty;
            foreach (var element in zipCodes)
            {
                myURL = baseURL + "minutely?postal_code=" + element + "&key=" + key + "&units=" + units;
                Audit data;
                string response = string.Empty;
                try
                {
                    response = httpClient.GetStringAsync(myURL).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var weather = JsonConvert.DeserializeObject<WeatherModel>(response);
                //  Just use the first value in the data array
                if (weather != null)
                {
                    data = weather?.data[0];
                    Console.WriteLine("Current Tempurature in " + element.ToString() + " is " + data?.temp + " farenheit.");
                }
            }
        }
    }
}
