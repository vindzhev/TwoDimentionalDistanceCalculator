using TwoDimentionalDistanceCalculator.Models;
using TwoDimentionalDistanceCalculator.Helpers;
using TwoDimentionalDistanceCalculator.Interfaces;

namespace TwoDimentionalDistanceCalculator.Tests.Helpers;

[CollectionDefinition(nameof(PointDistanceComparer))]
public class PointDistanceComparerTests
{
	private readonly IPointDistanceComparer _comparer;

	public PointDistanceComparerTests() => _comparer = new PointDistanceComparer();

	[Fact]
	public void Compare_ShouldComputeFarthestPoint_WhenThePointLiesOnTheCenter()
	{
		// Arrange
		Point point1 = new("Point1", 0, 0);

		// Act
		_comparer.Compare(point1);
		IEnumerable<Point> result = _comparer.FarthestPoints;

		// Assert
		result.Should().HaveCount(1);
	}

	[Fact]
	public void Compare_ShouldComputeFarthestPoints_WhenThereAreMultipleWithSameDistance()
	{
		// Arrange
		Point point1 = new("Point1", 3, 1);
		Point point2 = new("Point2", 0, 0);
		Point point3 = new("Point3", -3, -1);

		// Act
		_comparer.Compare(point1);
		_comparer.Compare(point2);
		_comparer.Compare(point3);
		IEnumerable<Point> result = _comparer.FarthestPoints;

		// Assert
		result.Should().HaveCount(2);
		result.Should().ContainEquivalentOf(point1);
		result.Should().ContainEquivalentOf(point3);
	}

	[Fact]
	public void Compare_ShouldReturnEmptyCollection_WhenItsNotEverCalled()
	{
		// Arrange & Act
		IEnumerable<Point> result = _comparer.FarthestPoints;

		// Assert
		result.Should().NotBeNull();
		result.Should().BeEmpty();
	}
}