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

        [Test]
        public void Merge_Returns_Expected_AirportCodes_If_CityName_Is_ANY_LONDON_AIRPORT_Is_Selected()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyLondonAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            var result = _airportCode.Merge(searchCriteria, searchCriteria.DepartingFrom.ToString());

            //Assert
            Assert.That(result, Is.Not.Null);
            if (result.DepartingFrom == "STN,LCY,LTN,SEN,LGW,LHR")
                Assert.True(true);
            else
                Assert.False(false);
        }

        [Test]
        public void Merge_Returns_Expected_AirportCodes_When_ANY_AIRPORT_Is_Selected()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyAirport();
            var searchCriteria = _parser.ParseDeserialize<dynamic>(search)!;

            //Act
            var result = _airportCode.Merge(searchCriteria, searchCriteria.DepartingFrom.ToString());

            //Assert
            Assert.That(result, Is.Not.Null);
            if (result.DepartingFrom == "STN,LCY,LTN,SEN,LGW,LHR,MAN,TFS,AGP,PMI,LPA")
                Assert.True(true);
            else
                Assert.False(false);
        }
    }
}