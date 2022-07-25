using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class AirportCode
    {
        public bool IsListedAirport(SearchString searchstring) =>
            AirportCodes.Codes.ContainsKey(searchstring.DepartingFrom.ToString()) ||
                AirportCodes.Codes.ContainsValue(searchstring.DepartingFrom.ToString());

        public SearchString Merge(SearchString search, string valueToCheck)
        {
            search.DepartingFrom = string.Empty;
            AirportCodes.Codes.Where(pair => pair.Value == valueToCheck).Select(pair => pair.Key)
                .ToList().ForEach(code => search.DepartingFrom += code + ",");
            if(string.IsNullOrEmpty(search.DepartingFrom))
                AirportCodes.Codes.Where(pair => pair.Key == valueToCheck).Select(pair => pair.Key)
                    .ToList().ForEach(code => search.DepartingFrom += code + ",");
            return search;
        }
    }
}