using Newtonsoft.Json;
using SimpleZipCode;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WeatherInformationAPIRetreival
{
    internal class Program
    {
        //Weatherbit.io
        // good endpoint to hit: https://api.weatherbit.io/v2.0/forecast/minutely?postal_code=74135&key=24d6f2a2e84849e2aaa77f8e372ba681&units=I
        private const string units = @"I";//default unit is Imperial/Farenheit
        private const string key = @"24d6f2a2e84849e2aaa77f8e372ba681";
        private const string baseURL = @"https://api.weatherbit.io/v2.0/forecast/";
       // string zipCode = @"74137";//replace this with a dynamic zipCode that's read in from the console!
        static void Main(string[] args)
        {
            var currentZip = Console.ReadLine();//check the type here for a zip <-- regex matching here works
            var tempZip = new List<ZipCode>();
            var zip = new ZipCode(currentZip, string.Empty, string.Empty, string.Empty, string.Empty, 0,0);
            tempZip.Add(zip);

            var isZipGood = new ZipCodeLookupService().IsZipGood(tempZip);
            //use a zipCode lookup service here!
            //zipCode = currentZip;
            var myURL = baseURL + "minutely?postal_code=" + currentZip + "&key=" + key + "&units=" + units;
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(myURL).Result;
            //now deserialize it!
             var weather = JsonConvert.DeserializeObject<WeatherModel>(response);
            //  Just use the first value in the data array
            var data = weather.data[0];
         //   for (var i = 0;i<weather.data.Count;i++)
           //     Console.WriteLine();
           
            //string query builder
            Console.WriteLine("Current Tempurature in " + currentZip.ToString() + " is " + data.temp + " farenheit.");
           
        }
    }
}
