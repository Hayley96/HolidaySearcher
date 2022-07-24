using Newtonsoft.Json;

namespace HolidaySearcherApp.Models
{
    [Serializable]
    public class Hotel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("arrival_date")]
        public string ArrivalDate { get; set; } = string.Empty;

        [JsonProperty("price_per_night")]
        public int CostPerNight { get; set; }

        [JsonProperty("local_airports")]
        public List<string> LocalAirports { get; set; } = new();

        [JsonProperty("nights")]
        public int Duration { get; set; }
    }
}
