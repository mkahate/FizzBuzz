using FizzBuzzApp.Services;
using Xunit;

namespace FizzBuzzTests
{
    public class FizzBuzzServiceTests
    {
        private readonly FizzBuzzService _fizzBuzzService;

        public FizzBuzzServiceTests()
        {
            _fizzBuzzService = new FizzBuzzService();
        }

        [Theory]
        [InlineData(1, "Divided 1 by 3")]
        [InlineData(1, "Divided 1 by 5")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData("A", "Invalid item")]
        public void Process_ValidInputs_ReturnsCorrectResults(object value, string expectedResult)
        {
            // Act
            var result = _fizzBuzzService.Process([value]);

            // Assert
            Assert.Contains(expectedResult, result);
        }

        [Fact]
        public void Process_EmptyArray_ReturnsEmptyList()
        {
            // Arrange
            object[] values = { };

            // Act
            var results = _fizzBuzzService.Process(values);

            // Assert
            Assert.Empty(results);
        }
    }
}
