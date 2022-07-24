using HolidaySearcherApp.Models;

namespace HolidaySearcherApp.Services
{
    public class Queryer
    {
        public IOrderedEnumerable<Flight> MatchingFlights { get; private set; } = null!;
        public IOrderedEnumerable<Hotel> MatchingHotels { get; private set; } = null!;

        public List<Flight> QueryFlights(List<Flight> flights, SearchString searchCriteria)
        {
            if (flights?.Count > 0)
            {
                MatchingFlights = flights.Where(flight => flight.DepartFrom.Any(x => searchCriteria.DepartingFrom.Contains(x))
                && flight.TravelTo.Equals(searchCriteria.TravelingTo)
                && DateTime.Parse(flight.DepartureDate).Equals(DateTime.Parse(searchCriteria.DepartureDate)))
                .OrderBy(x => x.Price);
            }
            return MatchingFlights.ToList();
        }

        public List<Hotel> QueryHotels(List<Hotel> hotels, SearchString searchCriteria)
        {
            if (hotels?.Count > 0)
            {
                MatchingHotels = hotels.Where(hotel => hotel.Duration.ToString().Equals(searchCriteria.Duration.ToString())
                && hotel.LocalAirports.Contains(searchCriteria.TravelingTo)
                && DateTime.Parse(hotel.ArrivalDate).Equals(DateTime.Parse(searchCriteria.DepartureDate)))
                .OrderBy(x => x.CostPerNight);
            }
            return MatchingHotels.ToList();
        }

        public int QueryTotalCost() =>
            MatchingFlights.First().Price + (MatchingHotels.First().CostPerNight * MatchingHotels.First().Duration);
    }
}