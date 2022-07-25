using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class HolidaySearch
    {
        public (List<Flight> Flight, List<Hotel> Hotel, int TotalCost) Results { get; private set; } = new();
        private Queryer _queryer; AirportCode _airportCode; JsonParser _parser;

        public HolidaySearch(string searchCriteria, Queryer queryer, AirportCode airportCode, JsonParser parser)
        {
            _queryer = queryer;
            _airportCode = airportCode;
            _parser = parser;
            if (!string.IsNullOrEmpty(searchCriteria) && _parser.IsValidJson(searchCriteria))
                Run(searchCriteria);
            return;
        }

        public (List<Flight> Flight, List<Hotel> Hotel, int TotalCost) Run(string inputSearch)
        {
            var _flights = _parser.ParseDeserializeList<Flight>(FileLoader.Load(FileLoader.Path("Flights.json")));
            var _hotels = _parser.ParseDeserializeList<Hotel>(FileLoader.Load(FileLoader.Path("Hotels.json")));
            var _searchString = _parser.ParseDeserialize<SearchString>(inputSearch);

            SearchString searchCriteria = _airportCode.IsListedAirport(_searchString, _searchString.DepartingFrom) ?
                _airportCode.IsListedAirport(_searchString, _searchString.TravelingTo) ?
                _airportCode.Merge(_searchString, _searchString.DepartingFrom) : null! : null!;
            if (searchCriteria is null) { return Results; }

            var _matchingFlights = _queryer.QueryFlights(_flights, searchCriteria);
            var _matchingHotels = _queryer.QueryHotels(_hotels, searchCriteria);
            var _totalcost = _queryer.QueryTotalCost();

            return Results = (_matchingFlights, _matchingHotels, _totalcost);
        }
    }
}