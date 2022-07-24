namespace HolidaySearcherApp.Models
{
    [Serializable]
    public class SearchString
    {
        public string DepartingFrom { get; set; } = string.Empty;
        public string TravelingTo { get; set; } = string.Empty;
        public string DepartureDate { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}