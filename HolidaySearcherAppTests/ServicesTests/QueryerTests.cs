using FluentAssertions;
using HolidaySearchAppTests.Data;
using HolidaySearcherApp.Models;
using HolidaySearcherApp.Services;

namespace HolidaySearcherAppTests.ServicesTests
{
    public class QueryerTests
    {
        private Queryer _searcher;
        private JsonParser _parser;
        private List<Flight> _flights;
        private List<Hotel> _hotels;

        [SetUp]
        public void Setup()
        {
            _searcher = new();
            _parser = new();
            _flights = TestData.GetFlightInstances();
            _hotels = TestData.GetHotelInstances();
        }

        [Test]
        public void SearchFlights_Returns_A_List_Of_Matching_Flights_For_SearchCriteria_MAN_Airport()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Flight> result = _searcher.QueryFlights(_flights, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(1);
            result.First().Id = 2;
        }

        [Test]
        public void SearchFlights_Returns_Empty_List_If_No_Matching_Results_Found()
        {
            //Arrange
            var search = TestData.SearchCriteriaNoMatchingResults();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            List<Flight> result = _searcher.QueryFlights(_flights, searchCriteria);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(0);
        }
    }
}
