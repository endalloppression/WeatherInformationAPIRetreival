using Microsoft.Owin.BuilderProperties;
using Newtonsoft.Json;
using SimpleZipCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

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
     
            Console.WriteLine("Enter zip codes separated by spaces. Hit enter when done to begin processing minutely weather request(s)...");
            var zipCodesTemp = currentZip.Split(' '); ;//separates out all of the input elements
            var zipCodes = zipCodesTemp.ToList();
            string zipCodeValidationPattern = @"^\d{5}(?:[-\s]\d{4})?$";//US zip code validation pattern

            foreach (var element in zipCodesTemp)
            {
                if (!Regex.IsMatch(element, zipCodeValidationPattern))
                {
                    zipCodes.Remove(element);
                    Console.WriteLine(element + " is invalid zip input. Removing the invalid input from the list...");
                }
            }

            var httpClient = new HttpClient();
            var myURL = string.Empty;
            foreach(var element in zipCodes)
            {
                myURL = baseURL + "minutely?postal_code=" + element + "&key=" + key + "&units=" + units;
                Audit data;

                var response = httpClient.GetStringAsync(myURL).Result;
                //now deserialize it!
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
