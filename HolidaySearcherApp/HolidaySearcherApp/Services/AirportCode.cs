using HolidaySearcherApp.Models;
using Newtonsoft.Json.Linq;

namespace HolidaySearcherApp.Services
{
    public class AirportCode
    {
        public bool IsListedAirport(dynamic json) =>
            AirportCodes.Codes.ContainsKey(json.DepartingFrom.ToString());

        public JObject Merge(dynamic json, string valueToCheck)
        {
            AirportCodes.Codes.Where(pair => pair.Key == valueToCheck).Select(pair => pair.Value)
                .ToList().ForEach(code => json.DepartingFrom += code + ",");
            return json;
        }
    }
}