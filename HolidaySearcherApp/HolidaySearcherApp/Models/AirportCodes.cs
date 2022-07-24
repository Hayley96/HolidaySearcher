namespace HolidaySearcherApp.Models
{
    public class AirportCodes
    {
        /* In a real app, I would retrieve this data from an API with maybe additional latitude and longitude 
           co-ordinates to determine airports within a given radius, but for now I am using this list of hardcoded airport codes */
        public static Dictionary<string, string> Codes = new()
        {
            { "London", "STN,LCY,LTN,SEN,LGW,LHR" },
            { "Any", "STN,LCY,LTN,SEN,LGW,LHR,MAN,TFS,AGP,PMI,LPA" },
            { "STN", "STN" },
            { "LCY", "LCY" },
            { "LTN", "LTN" },
            { "SEN", "SEN" },
            { "LGW", "LGW" },
            { "LHR", "LHR" },
            { "MAN", "MAN" },
            { "TFS", "TFS" },
            { "AGP", "AGP" },
            { "PMI", "PMI" },
            { "LPA", "LPA" },
        };
    }
}