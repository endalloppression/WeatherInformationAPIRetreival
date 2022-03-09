using SimpleZipCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformationAPIRetreival
{
    public class ZipCodeLookupService
    {

        public bool IsZipGood(List<ZipCode> zipCodes)
        {
            //use lookup service here...consider making this static as that's how it'll be used!
            var client = new SimpleZipCode.Repos.ZipCodeRepo(zipCodes);
            foreach (var zipCode in zipCodes)
            {
                if (client.RadiusSearch(zipCode, 1).Any())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
