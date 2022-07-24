using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class HolidaySearch
    {
        public (List<Flight> Flight, List<Hotel> Hotel, int TotalCost) Results { get; private set; } = new();
        private Queryer _queryer; AirportCode _airportCode; JsonParser _parser;
        private List<Flight> _flights = new(), _matchingFlights = new();
        private List<Hotel> _hotels = new(), _matchingHotels = new();
        private dynamic _search = null!;
        private int _totalcost;

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
            RunParsers(inputSearch);
            var searchCriteria = RunAirportCodes(_search);
            if (searchCriteria.Length == 0)
                return Results;
            RunQueries(searchCriteria);
            return Results = (_matchingFlights, _matchingHotels, _totalcost);
        }

        private void RunParsers(string inputSearch)
        {
            _flights = _parser.ParseDeserializeList<Flight>(FileLoader.Load(FileLoader.Path("Flights.json")));
            _hotels = _parser.ParseDeserializeList<Hotel>(FileLoader.Load(FileLoader.Path("Hotels.json")));
            _search = _parser.ParseDeserialize<dynamic>(inputSearch);
        }

        private dynamic RunAirportCodes(dynamic search) =>
            _airportCode.IsListedAirport(search) ?
                _airportCode.Merge(search, search.DepartingFrom.ToString()) : string.Empty;

        private void RunQueries(dynamic searchCriteria)
        {
            _matchingFlights = _queryer.QueryFlights(_flights, searchCriteria);
            _matchingHotels = _queryer.QueryHotels(_hotels, searchCriteria);
            _totalcost = _queryer.QueryTotalCost();
        }
    }
}