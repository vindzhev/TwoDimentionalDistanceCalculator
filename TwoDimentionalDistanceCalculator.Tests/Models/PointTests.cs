using TwoDimentionalDistanceCalculator.Models;

namespace TwoDimentionalDistanceCalculator.Tests.Models;

public class PointTests
{
	[Theory]
	[InlineData("Point1", 0d, 0d, 0d, Quadrants.Center)]
	[InlineData("Point1", 1d, 0d, 1d, Quadrants.None)]
	[InlineData("Point1", 0d, 1d, 1d, Quadrants.None)]
	[InlineData("Point1", 3d, 4d, 5d, Quadrants.First)]
	[InlineData("Point1", -3d, 4d, 5d, Quadrants.Second)]
	[InlineData("Point1", -3d, -4d, 5d, Quadrants.Third)]
	[InlineData("Point1", 3d, -4d, 5d, Quadrants.Fourth)]
	public void Point_ShouldCalculateDistanceCorrectly_AndReturnProperQuadrantInfo(string pointName, double x, double y, double expectedDistance, Quadrants expectedQuadrant)
	{
		// Arrange & Act
		Point point = new(pointName, x, y);

		// Assert
		point.Should().NotBeNull();
		point.DistanceFromCenter.Should().Be(expectedDistance);
		point.Quadrant.Should().Be(expectedQuadrant);
	}

	[Theory]
	[InlineData("Point1", 0d, 0d, "Point1(0, 0) is located in the center of the grid.")]
	[InlineData("Point1", 1d, 0d, "Point1(1, 0) is located on the X-axis")]
	[InlineData("Point1", 0d, 1d, "Point1(0, 1) is located on the Y-axis")]
	[InlineData("Point1", 3d, 4d, "Point1(3, 4) is located in First quadrant.")]
	[InlineData("Point1", -3d, 4d, "Point1(-3, 4) is located in Second quadrant.")]
	[InlineData("Point1", -3d, -4d, "Point1(-3, -4) is located in Third quadrant.")]
	[InlineData("Point1", 3d, -4d, "Point1(3, -4) is located in Fourth quadrant.")]
	public void Point_ShouldReturnCorrectlyFormattedMessage(string pointName, double x, double y, string expectedMessage)
	{
		// Arrange
		Point point = new(pointName, x, y);

		// Act
		string result = point.ToString();

		// Assert
		result.Should().NotBeNullOrEmpty();
		result.Should().Be(expectedMessage);
	}
}
