using Newtonsoft.Json;

namespace HolidaySearcherApp.Models
{
    [Serializable]
    public class Flight
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("airline")]
        public string Airline { get; set; } = string.Empty;

        [JsonProperty("from")]
        public string DepartFrom { get; set; } = string.Empty;

        [JsonProperty("to")]
        public string TravelTo { get; set; } = string.Empty;

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("departure_date")]
        public string DepartureDate { get; set; } = string.Empty;
    }
}
