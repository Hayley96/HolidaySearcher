using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class Queryer
    {
        public IOrderedEnumerable<Flight> MatchingFlights { get; private set; } = null!;

        public List<Flight> QueryFlights(List<Flight> flights, dynamic searchCriteria)
        {
            if (flights?.Count > 0)
            {
                MatchingFlights = flights.Where(flight => flight.DepartFrom.Any(x => searchCriteria.DepartingFrom.ToString().Contains(x))
                && flight.TravelTo.Equals(searchCriteria.TravelingTo.ToString())
                && DateTime.Parse(flight.DepartureDate).Equals(DateTime.Parse(searchCriteria.DepartureDate.ToString())))
                .OrderBy(x => x.Price);
            }
            return MatchingFlights.ToList();
        }
    }
}