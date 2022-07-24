using HolidaySearchAppTests.Data;
using HolidaySearcherApp.Models;
using HolidaySearcherApp.Services;

namespace HolidaySearcherAppTests.ServicesTests
{
    public class AirportCodeTests
    {
        private JsonParser _parser;
        private Queryer _queryer;
        private AirportCode _airportCode;
        private List<Flight> _flights;
        private List<Hotel> _hotels;

        [SetUp]
        public void Setup()
        {
            _parser = new();
            _queryer = new();
            _airportCode = new();
            _flights = TestData.GetFlightInstances();
            _hotels = TestData.GetHotelInstances();
        }

        [Test]
        public void IsListedAirport_Returns_True_If_Airport_Found_In_Dictionary()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyLondonAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            var result = _airportCode.IsListedAirport(searchCriteria);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsListedAirport_Returns_False_If_Airport_Not_Found_In_Dictionary()
        {
            //Arrange
            var search = TestData.SearchCriteriaNoMatchingAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            var result = _airportCode.IsListedAirport(searchCriteria);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.False);
        }
    }
}