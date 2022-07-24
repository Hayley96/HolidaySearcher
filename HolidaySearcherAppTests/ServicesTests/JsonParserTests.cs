using FluentAssertions;
using HolidaySearcherApp.Models;
using HolidaySearcherApp.Services;

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
            var result = _parser.ParseDeserializeList<Flight>(Json);

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
            var result = _parser.ParseDeserializeList<Hotel>(Json);

            //Assert
            result.Should().BeOfType(typeof(List<Hotel>));
            result.Count.Should().Be(13);
        }

        [Test]
        public void ParseDeserializeList_Returns_Empty_List_When_Type_T_Is_Flight_But_Json_String_Is_Empty()
        {
            //Act
            var result = _parser.ParseDeserializeList<Flight>("");

            //Assert
            result.Should().BeNullOrEmpty();
        }
    }
}
