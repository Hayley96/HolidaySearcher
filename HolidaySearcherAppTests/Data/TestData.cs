using HolidaySearcherApp.Models;

namespace HolidaySearchAppTests.Data
{
    public static class TestData
    {
        public static string SearchCriteriaMANAirport()
        {
            return(@"{
              DepartingFrom: 'MAN',
              TravelingTo: 'AGP',
              DepartureDate: '2023/07/01',
              Duration: 7
            }");
        }

        public static string SearchCriteriaNoMatchingResults()
        {
            return (@"{
              DepartingFrom: 'MAN',
              TravelingTo: 'AGP',
              DepartureDate: '2042/07/01',
              Duration: 7
            }");
        }

        public static string SearchCriteriaInvalidJson()
        {
            return (@"{
              DepartingFrom: ''MAN',
              TravelingTo: 'AGP',
              DepartureDate: '2042/07/01'',
              Duration: 7
            }");
        }

        public static string SearchCriteriaAnyLondonAirport()
        {
            return (@"{
              DepartingFrom: 'London',
              TravelingTo: 'PMI',
              DepartureDate: '2023/06/15',
              Duration: 10
            }");
        }

        public static string SearchCriteriaAnyAirport()
        {
            return (@"{
              DepartingFrom: 'Any',
              TravelingTo: 'LPA',
              DepartureDate: '2022/11/10',
              Duration: 14
            }");
        }

        public static string SearchCriteriaNoMatchingAirport()
        {
            return (@"{
              DepartingFrom: 'ZZZZZ',
              TravelingTo: 'LPA',
              DepartureDate: '2022/11/10',
              Duration: 14
            }");
        }

        public static List<Flight> GetFlightInstances()
        {
            return new List<Flight>
            {
                new Flight()
                {
                    Id = 1,
                    Airline = "First Class Air",
                    DepartFrom =  "MAN",
                    TravelTo =  "TFS",
                    Price =  470,
                    DepartureDate = "2023-07-01"
                },
                new Flight()
                {
                    Id = 2,
                    Airline = "Oceanic Airlines",
                    DepartFrom =  "MAN",
                    TravelTo =  "AGP",
                    Price =  245,
                    DepartureDate = "2023-07-01"
                },
                new Flight()
                {
                    Id = 3,
                    Airline = "Trans American Airlines",
                    DepartFrom =  "MAN",
                    TravelTo =  "PMI",
                    Price =  170,
                    DepartureDate = "2023-06-15"
                },
                new Flight()
                {
                    Id = 4,
                    Airline = "Trans American Airlines",
                    DepartFrom =  "LTN",
                    TravelTo =  "PMI",
                    Price =  153,
                    DepartureDate = "2023-06-15"
                },
                new Flight()
                {
                    Id = 5,
                    Airline = "Fresh Airways",
                    DepartFrom =  "MAN",
                    TravelTo =  "PMI",
                    Price =  130,
                    DepartureDate = "2023-06-15"
                },
                new Flight()
                {
                    Id = 6,
                    Airline = "Fresh Airways",
                    DepartFrom =  "LGW",
                    TravelTo =  "PMI",
                    Price =  75,
                    DepartureDate = "2023-06-15"
                },
                new Flight()
                {
                    Id = 7,
                    Airline = "Trans American Airlines",
                    DepartFrom =  "MAN",
                    TravelTo =  "LPA",
                    Price =  125,
                    DepartureDate = "2022-11-10"
                },
                new Flight()
                {
                    Id = 8,
                    Airline = "Fresh Airways",
                    DepartFrom =  "MAN",
                    TravelTo =  "LPA",
                    Price =  175,
                    DepartureDate = "2023-11-10"
                },
                new Flight()
                {
                    Id = 9,
                    Airline = "Fresh Airways",
                    DepartFrom =  "MAN",
                    TravelTo =  "AGP",
                    Price =  140,
                    DepartureDate = "2023-04-11"
                },
                new Flight()
                {
                    Id = 10,
                    Airline = "Fresh Airways",
                    DepartFrom =  "LGW",
                    TravelTo =  "AGP",
                    Price =  225,
                    DepartureDate = "2023-07-01"
                },
                new Flight()
                {
                    Id = 11,
                    Airline = "First Class Air",
                    DepartFrom =  "LGW",
                    TravelTo =  "AGP",
                    Price =  155,
                    DepartureDate = "2023-07-01"
                },
                new Flight()
                {
                    Id = 12,
                    Airline = "Trans American Airlines",
                    DepartFrom =  "MAN",
                    TravelTo =  "AGP",
                    Price =  202,
                    DepartureDate = "2023-10-25"
                },

            };
        }

        public static List<Hotel> GetHotelInstances()
        {
            return new List<Hotel>
            {
                new Hotel()
                {
                    Id = 1,
                    Name = "Iberostar Grand Portals Nous",
                    ArrivalDate = "2022-11-05",
                    CostPerNight = 100,
                    LocalAirports = {"TFS"},
                    Duration = 7
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Laguna Park 2",
                    ArrivalDate = "2022-11-05",
                    CostPerNight = 50,
                    LocalAirports = {"TFS"},
                    Duration = 7
                },
                new Hotel()
                {
                    Id = 3,
                    Name = "Sol Katmandu Park & Resort",
                    ArrivalDate = "2023-06-15",
                    CostPerNight = 59,
                    LocalAirports = {"PMI"},
                    Duration = 14
                },
                new Hotel()
                {
                    Id = 4,
                    Name = "Sol Katmandu Park & Resort",
                    ArrivalDate = "2023-06-15",
                    CostPerNight = 59,
                    LocalAirports = {"PMI"},
                    Duration = 14
                },
                new Hotel()
                {
                    Id = 5,
                    Name = "Sol Katmandu Park & Resort",
                    ArrivalDate = "2023-06-15",
                    CostPerNight = 60,
                    LocalAirports = {"PMI"},
                    Duration = 10
                },
                new Hotel()
                {
                    Id = 6,
                    Name = "Club Maspalomas Suites and Spa",
                    ArrivalDate = "2022-11-10",
                    CostPerNight = 75,
                    LocalAirports = {"LPA"},
                    Duration = 14
                },
                new Hotel()
                {
                    Id = 7,
                    Name = "Club Maspalomas Suites and Spa",
                    ArrivalDate = "2022-09-10",
                    CostPerNight = 76,
                    LocalAirports = {"LPA"},
                    Duration = 14
                },
                new Hotel()
                {
                    Id = 8,
                    Name = "Boutique Hotel Cordial La Peregrina",
                    ArrivalDate = "2022-10-10",
                    CostPerNight = 45,
                    LocalAirports = {"LPA"},
                    Duration = 7
                },
                new Hotel()
                {
                    Id = 9,
                    Name = "Nh Malaga",
                    ArrivalDate = "2023-07-01",
                    CostPerNight = 83,
                    LocalAirports = {"AGP"},
                    Duration = 7
                },
                new Hotel()
                {
                    Id = 10,
                    Name = "Barcelo Malaga",
                    ArrivalDate = "2023-07-05",
                    CostPerNight = 45,
                    LocalAirports = {"AGP"},
                    Duration = 10
                },
                new Hotel()
                {
                    Id = 11,
                    Name = "Parador De Malaga Gibralfaro",
                    ArrivalDate = "2023-10-16",
                    CostPerNight = 100,
                    LocalAirports = {"AGP"},
                    Duration = 7
                },
                new Hotel()
                {
                    Id = 12,
                    Name = "MS Maestranza Hotel",
                    ArrivalDate = "2023-07-01",
                    CostPerNight = 45,
                    LocalAirports = {"AGP"},
                    Duration = 14
                },
                new Hotel()
                {
                    Id = 13,
                    Name = "Jumeirah Port Soller",
                    ArrivalDate = "2023-06-15",
                    CostPerNight = 295,
                    LocalAirports = {"PMI"},
                    Duration = 10
                }
            };
        }
    }
}