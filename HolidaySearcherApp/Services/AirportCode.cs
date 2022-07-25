using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class AirportCode
    {
        private const string DELIMITER = ",";
        public bool IsListedAirport(SearchString searchstring) =>
            AirportCodes.Codes.ContainsKey(searchstring.DepartingFrom.ToString()) ||
                AirportCodes.Codes.Values.Where(v => v.Contains(searchstring.DepartingFrom)).Count() > 0;

        public SearchString Merge(SearchString search, string valueToCheck)
        {
            AirportCodes.Codes.Where(pair => pair.Value.Split(DELIMITER).ToString()!.Any(val => search.DepartingFrom.Contains(val)))
                .Select(pair => pair.Key).ToList().ForEach(code => search.DepartingFrom += DELIMITER + code);
            if (string.IsNullOrEmpty(search.DepartingFrom))
                AirportCodes.Codes.Where(pair => pair.Key == valueToCheck).Select(pair => pair.Key)
                    .ToList().ForEach(code => search.DepartingFrom += DELIMITER + code);
            return search;
        }
    }
}