namespace HolidaySearcherApp.Models
{
    public class AirportCodes
    {
        /* In a real app, I would retrieve this data from an API with maybe additional latitude and longitude 
           co-ordinates to determine airports within a given radius, but for now I am using this list of hardcoded airport codes */
        public static Dictionary<string, string> Codes = new()
        {
            { "STN", "London,Any" },
            { "LCY", "London,Any" },
            { "LTN", "London,Any" },
            { "SEN", "London,Any" },
            { "LGW", "London,Any" },
            { "LHR", "London,Any" },
            { "MAN", "Manchester,Any" },
            { "TFS", "Spain,Any" },
            { "AGP", "Spain,Any" },
            { "PMI", "Spain,Any" },
            { "LPA", "Spain,Any" },
        };
    }
}