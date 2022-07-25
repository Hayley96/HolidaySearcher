using FluentAssertions;
using HolidaySearchAppTests.Data;
using HolidaySearcherApp.Models;
using HolidaySearcherApp.Services;
using Newtonsoft.Json.Linq;

namespace HolidaySearcherAppTests.ServicesTests
{
    public class JsonParserTests
    {
        private JsonParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new();
        }

        [Test]
        public void ParseDeserializeList_Returns_A_List_Of_Flights_When_Type_T_Is_Flight()
        {
            //Arrange
            var file = FileLoader.Path("Flights.json");
            var Json = FileLoader.Load(file);

            //Act
            var result = _parser.ParseReturnInstanceList<Flight>(Json);

            //Assert
            result.Should().BeOfType(typeof(List<Flight>));
            result.Count.Should().Be(12);

        }

        [Test]
        public void ParseDeserializeList_Returns_A_List_Of_Hotels_When_Type_T_Is_Hotel()
        {
            //Arrange
            var file = FileLoader.Path("Hotels.json");
            var Json = FileLoader.Load(file);

            //Act
            var result = _parser.ParseReturnInstanceList<Hotel>(Json);

            //Assert
            result.Should().BeOfType(typeof(List<Hotel>));
            result.Count.Should().Be(13);
        }

        [Test]
        public void ParseDeserializeList_Returns_Empty_List_When_Type_T_Is_Flight_But_Json_String_Is_Empty()
        {
            //Act
            var result = _parser.ParseReturnInstanceList<Flight>("");

            //Assert
            result.Should().BeNullOrEmpty();
        }

        [Test]
        public void ParseDeserialize_Returns_Type_T_Json()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();

            //Act
            var result = _parser.ParseReturnInstanceSingle<dynamic>(search);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(JObject)));
            Assert.That(result, Has.Count.EqualTo(4));
            Assert.That(result.DepartingFrom == "MAN");
            Assert.That(result.TravelingTo == "AGP");
        }

        [Test]
        public void IsValidJson_Returns_True_If_Valid_Json_String_Passed()
        {
            //Arrange
            var search = TestData.SearchCriteriaMANAirport();

            //Act
            var result = _parser.IsValidJson(search);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void IsValidJson_Returns_False_If_InValid_Json_String_Passed()
        {
            //Arrange
            var search = TestData.SearchCriteriaInvalidJson();

            //Act
            var result = _parser.IsValidJson(search);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void IsValidJson_Returns_False_If_Empty_String_Passed()
        {
            //Arrange
            var search = string.Empty;

            //Act
            var result = _parser.IsValidJson(search);

            //Assert
            Assert.False(result);
        }
    }
}
