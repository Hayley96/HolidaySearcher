using FluentAssertions;
using HolidaySearcherApp.Services;

namespace HolidaySearcherAppTests.ServicesTests
{
    public class FileLoaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Path_Returns_Path_To_Data_File()
        {
            //Arrange
            var expectedresult = "Flights.json";

            //Act
            var result = FileLoader.Path("Flights.json");

            //Assert
            result.Should().Contain(expectedresult);
        }

        [Test]
        public void Path_Returns_Empty_String_If_File_Not_Found()
        {
            //Arrange
            var expectedresult = string.Empty;

            //Act
            var result = FileLoader.Path("Flhts.json");

            //Assert
            result.Should().Be(string.Empty);
        }

        [Test]
        public void Load_Returns_String_Of_Data_From_File()
        {
            //Arrange
            var expectedresult1 = "Oceanic Airlines";
            var expectedresult2 = "Fresh Airways";
            var file = FileLoader.Path("Flights.json");

            //Act
            var result = FileLoader.Load(file);

            //Assert
            result.Should().Contain(expectedresult1);
            result.Should().Contain(expectedresult2);
        }
    }
}