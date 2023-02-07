using TwoDimentionalDistanceCalculator.Models;
using TwoDimentionalDistanceCalculator.Extensions;

namespace TwoDimentionalDistanceCalculator.Tests.Extensions;

public class StringExtensionsTests
{
	[Fact]
	public void ToPoint_ShouldRetrunNewObject_WhenValidDataIsProvided()
	{
		// Arrange
		string input = "Point1(-1, 5)";
		Point expectedResult = new("Point1", -1d, 5d);

		// Act
		Point? result = input.ToPoint();

		// Assert
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(expectedResult);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("RANDOM_INVALID_TEST")]
	[InlineData("POINT0(0,X)")]
	[InlineData("Point-1(0,1)")]
	[InlineData("Point1(0,X)")]
	[InlineData("Point1(1.7+10^308, 1)")]
	public void ToPoint_ShouldRetrunNull_WhenInvalidDataIsProvided(string input)
	{
		// Arrange
		StringWriter consoleOutput = new();
		Console.SetOut(consoleOutput);

		// Act
		Point? result = input.ToPoint();

		// Assert
		result.Should().BeNull();
	}
}
