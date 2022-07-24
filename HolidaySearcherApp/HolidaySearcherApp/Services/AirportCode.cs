using HolidaySearcherApp.Models;
using Newtonsoft.Json.Linq;

namespace HolidaySearcherApp.Services
{
    public class AirportCode
    {
        public bool IsListedAirport(SearchString searchstring) =>
            AirportCodes.Codes.ContainsKey(searchstring.DepartingFrom.ToString());

        public SearchString Merge(SearchString search, string valueToCheck)
        {
            search.DepartingFrom = string.Empty;
            AirportCodes.Codes.Where(pair => pair.Key == valueToCheck).Select(pair => pair.Value)
                .ToList().ForEach(code => search.DepartingFrom += code + ",");
            return search;
        }
    }
}