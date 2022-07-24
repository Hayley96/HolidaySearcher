using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class AirportCode
    {
        public bool IsListedAirport(dynamic json) =>
            AirportCodes.Codes.ContainsKey(json.DepartingFrom.ToString());
    }
}