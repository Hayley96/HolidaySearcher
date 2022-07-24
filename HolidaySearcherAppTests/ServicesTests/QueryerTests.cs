using FluentAssertions;
using HolidaySearchAppTests.Data;
using HolidaySearcherApp.Models;
using HolidaySearcherApp.Services;

namespace HolidaySearcherAppTests.ServicesTests
{
    public class QueryerTests
    {
        private Queryer _queryer;
        private JsonParser _parser;
        private List<Flight> _flights;
        private List<Hotel> _hotels;

        [SetUp]
        public void Setup()
        {
            _queryer = new();
            _parser = new();
            _flights = TestData.GetFlightInstances();
            _hotels = TestData.GetHotelInstances();
        }

        [Test]
        public void QueryFlights_Returns_A_List_Of_Matching_Flights_For_SearchCriteria_MAN_Airport()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Flight> result = _queryer.QueryFlights(_flights, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(1);
            result.First().Id = 2;
        }

        [Test]
        public void QueryFlights_Returns_A_List_Of_Matching_Flights_For_SearchCriteria_ANY_LONDON_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyLondonAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Flight> result = _queryer.QueryFlights(_flights, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(2);
            result.First().Id = 6;
        }

        [Test]
        public void QueryFlights_Returns_A_List_Of_Matching_Flights_For_SearchCriteria_ANY_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Flight> result = _queryer.QueryFlights(_flights, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(1);
            result.First().Id = 7;
        }

        [Test]
        public void QueryFlights_Returns_Empty_List_If_No_Matching_Results_Found()
        {
            //Arrange
            var search = TestData.SearchCriteriaNoMatchingResults();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Flight> result = _queryer.QueryFlights(_flights, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(0);
        }      

        [Test]
        public void QueryHotels_Returns_A_List_Of_Matching_Hotels_For_SearchCriteria_MAN_Airport()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Hotel> result = _queryer.QueryHotels(_hotels, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Hotel>));
            result.Count.Should().Be(1);
            result.First().Id = 9;
        }

        [Test]
        public void QueryHotels_Returns_A_List_Of_Matching_Hotels_For_SearchCriteria_ANY_LONDON_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyLondonAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Hotel> result = _queryer.QueryHotels(_hotels, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Hotel>));
            result.Count.Should().Be(2);
            result.First().Id = 5;
        }

        [Test]
        public void QueryHotels_Returns_A_List_Of_Matching_Hotels_For_SearchCriteria_ANY_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Hotel> result = _queryer.QueryHotels(_hotels, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Hotel>));
            result.Count.Should().Be(1);
            result.First().Id = 6;
        }

        [Test]
        public void QueryHotels_Returns_Empty_List_If_No_Matching_Results_Found()
        {
            //Arrange
            var search = TestData.SearchCriteriaNoMatchingResults();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Hotel> result = _queryer.QueryHotels(_hotels, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Hotel>));
            result.Count.Should().Be(0);
        }

        [Test]
        public void QueryTotalCost_Returns_Integer_TotalCost()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;
            var flightobjects = TestData.GetFlightInstances();
            var hotelobjects = TestData.GetHotelInstances();
            var flights = _queryer.QueryFlights(flightobjects, searchCriteria);
            var hotels = _queryer.QueryHotels(hotelobjects, searchCriteria);

            //Act
            var result = _queryer.QueryTotalCost();

            //Assert
            result.Should().BeOfType(typeof(int));
            result.Should().Be(826);
        }
    }
}