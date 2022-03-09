using SimpleZipCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherInformationAPIRetreival
{
    public static class ZipCodeLookupService
    {

        public static List<string> IsZipGood(string input)
        {
            var zipCodesTemp = input.Split(' '); ;//separates out all of the input elements
            var zipCodes = zipCodesTemp.ToList();
            string zipCodeValidationPattern = @"^\d{5}(?:[-\s]\d{4})?$";//US zip code validation pattern
            foreach (var element in from element in zipCodesTemp
                                    where !Regex.IsMatch(element, zipCodeValidationPattern)
                                    select element)
            {
                zipCodes.Remove(element);
                //throw new Exception("Invalid Zip Code!");//This is what the ask was but it could be improved here, so i made it function
                Console.WriteLine(element + " is invalid zip input. Removing the invalid input from the list...");
            }

            return zipCodes;
        }
    }
}
