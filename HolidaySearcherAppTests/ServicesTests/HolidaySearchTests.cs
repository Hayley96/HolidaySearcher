using HolidaySearchAppTests.Data;
using HolidaySearcherApp.Models;
using HolidaySearcherApp.Services;

namespace HolidaySearcherAppTests.ServicesTests
{
    public class HolidaySearchTests
    {
        private HolidaySearch? _holidaySearch;
        private JsonParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new();
        }

        [Test]
        public void HolidaySearch_Property_Results_Has_Expected_results_When_Program_SearchMethod_Completed_MAN_Airport()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();

            //Act
            _holidaySearch = new(search);

            //Assert
            Assert.That(_holidaySearch.Results, Is.TypeOf(typeof(ValueTuple<List<Flight>, List<Hotel>, int>)));
            Assert.That(_holidaySearch.Results.Flight.First().Id == 2);
            Assert.That(_holidaySearch.Results.Hotel.First().Id == 9);
            Assert.That(_holidaySearch.Results.TotalCost == 826);
            Assert.That(_holidaySearch.Results.Flight.First().Airline == "Oceanic Airlines");
            Assert.That(_holidaySearch.Results.Hotel.First().Name == "Nh Malaga");
        }

        [Test]
        public void Search_Returns_A_Tuple_Containing_Lists_Of_Flights_And_Hotels_Matching_The_SearchCriteria_MAN_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();

            //Act
            var result = _holidaySearch!.Search(search);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(ValueTuple<List<Flight>, List<Hotel>, int>)));
            Assert.That(result.Flight.First().Id == 2);
            Assert.That(result.Hotel.First().Id == 9);
            Assert.That(result.TotalCost == 826);
            Assert.That(result.Flight.First().Airline == "Oceanic Airlines");
            Assert.That(result.Hotel.First().Name == "Nh Malaga");
        }

        [Test]
        public void Search_Returns_A_Tuple_Containing_Lists_Of_Flights_And_Hotels_Matching_The_SearchCriteria_ANY_LONDON_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyLondonAirport();

            //Act
            var result = _holidaySearch!.Search(search);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(ValueTuple<List<Flight>, List<Hotel>, int>)));
            Assert.That(result.Flight.First().Id == 6);
            Assert.That(result.Hotel.First().Id == 5);
            Assert.That(result.TotalCost == 675);
            Assert.That(result.Flight.First().Airline == "Fresh Airways");
            Assert.That(result.Hotel.First().Name == "Sol Katmandu Park & Resort");
        }

        [Test]
        public void Search_Returns_A_Tuple_Containing_Lists_Of_Flights_And_Hotels_Matching_The_SearchCriteria_ANY_AIRPORT()
        {
            //Arrange
            var search = TestData.SearchCriteriaAnyAirport();

            //Act
            var result = _holidaySearch!.Search(search);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(ValueTuple<List<Flight>, List<Hotel>, int>)));
            Assert.That(result.Flight.First().Id == 7);
            Assert.That(result.Hotel.First().Id == 6);
            Assert.That(result.TotalCost == 1175);
            Assert.That(result.Flight.First().Airline == "Trans American Airlines");
            Assert.That(result.Hotel.First().Name == "Club Maspalomas Suites and Spa");
        }

        [Test]
        public void HolidaySearch_Returns_Empty_If_Invalid_Json_Detected()
        {
            //Arrange
            var search = TestData.SearchCriteriaInvalidJson();

            //Act
            var result = _holidaySearch = new(search);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(HolidaySearch)));
        }

        [Test]
        public void HolidaySearch_Returns_Empty_When_No_Value_Passed()
        {
            //Arrange
            var search = string.Empty;

            //Act
            var result = _holidaySearch = new(search);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(HolidaySearch)));
        }
    }
}