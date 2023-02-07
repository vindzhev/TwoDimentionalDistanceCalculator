using TwoDimentionalDistanceCalculator.Models;

namespace TwoDimentionalDistanceCalculator.Interfaces;

public interface IPointDistanceComparer
{
	IEnumerable<Point> FarthestPoints { get; }

	void Compare(Point point);
}
