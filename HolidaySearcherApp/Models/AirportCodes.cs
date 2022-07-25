namespace HolidaySearcherApp.Models
{
    public class AirportCodes
    {
        /* In a real app, I would retrieve this data from an API with maybe additional latitude and longitude 
           co-ordinates to determine airports within a given radius, but for now I am using this list of hardcoded airport codes */
        public static Dictionary<string, string> Codes = new()
        {
            { "STN,LCY,LTN,SEN,LGW,LHR,MAN,TFS,AGP,PMI,LPA", "Any" },
            { "STN", "London" },
            { "LCY", "London" },
            { "LTN", "London" },
            { "SEN", "London" },
            { "LGW", "London" },
            { "LHR", "London" },
            { "MAN", "Manchester" },
            { "TFS", "Spain" },
            { "AGP", "Spain" },
            { "PMI", "Spain" },
            { "LPA", "Spain" },
        };
    }
}