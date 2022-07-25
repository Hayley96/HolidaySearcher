using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class AirportCode
    {
        private const string DELIMITER = ",";
        public bool IsListedAirport(SearchString searchstring, string property) =>
            AirportCodes.Codes.ContainsKey(property) ||
                AirportCodes.Codes.Values.Where(v => v.Contains(property)).Count() > 0;

        public SearchString Merge(SearchString search, string valueToCheck)
        {
            var DepartingFrom = search.DepartingFrom;
            search.DepartingFrom = string.Empty;
            AirportCodes.Codes.Where(pair => pair.Key == valueToCheck).Select(pair => pair.Key)
                .ToList().ForEach(code => search.DepartingFrom += code + DELIMITER);
            if(search.DepartingFrom.Equals(string.Empty))
                AirportCodes.Codes.Where(pair => pair.Value.Split(DELIMITER).ToArray()!.Any(val => DepartingFrom.Contains(val)))
                    .Select(pair => pair.Key).ToList().ForEach(code => search.DepartingFrom += code + DELIMITER);
            return search;
        }
    }
}