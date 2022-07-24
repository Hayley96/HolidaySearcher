using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class HolidaySearch
    {
        private Queryer _queryer { get; set; }
        private AirportCode _airportCode { get; set; }
        private JsonParser _parser { get; set; }
        public (List<Flight> Flight, List<Hotel> Hotel, int TotalCost) Results { get; private set; } = new();
        public HolidaySearch(string searchCriteria)
        {
            _queryer = new();
            _airportCode = new();
            _parser = new();
            if (!string.IsNullOrEmpty(searchCriteria) && _parser.IsValidJson(searchCriteria))
                Search(searchCriteria);
            return;
        }

        public (List<Flight> Flight, List<Hotel> Hotel, int TotalCost) Search(string inputSearch)
        {
            dynamic searchCriteria;
            var flights = _parser.ParseDeserializeList<Flight>(FileLoader.Load(FileLoader.Path("Flights.json")));
            var hotels = _parser.ParseDeserializeList<Hotel>(FileLoader.Load(FileLoader.Path("Hotels.json")));
            var search = _parser.ParseDeserialize<dynamic>(inputSearch);

            searchCriteria = _airportCode.IsListedAirport(search) ?
                _airportCode.Merge(search, search.DepartingFrom.ToString()) : string.Empty;
            if (searchCriteria.Length == 0)
                return Results;

            List<Flight> matchingFlights = _queryer.QueryFlights(flights, searchCriteria);
            List<Hotel> matchingHotels = _queryer.QueryHotels(hotels, searchCriteria);
            int totalCost = _queryer.QueryTotalCost();

            return Results = (matchingFlights, matchingHotels, totalCost);
        }
    }
}
