using DocumentFormat.OpenXml.Drawing.Charts;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.Utils;

namespace WeatherInformationAPIRetreival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter zip codes separated by spaces. Hit enter when done to begin processing minutely weather request(s)...");
            var currentZip = Console.ReadLine();//check the type here for a zip <-- regex matching here works
            var zipCodes = ZipCodeLookupService.IsZipGood(currentZip);
            WeatherService.DisplayWeather(zipCodes);                    
        }
    }
}
