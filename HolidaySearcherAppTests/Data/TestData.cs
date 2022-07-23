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
    }
}