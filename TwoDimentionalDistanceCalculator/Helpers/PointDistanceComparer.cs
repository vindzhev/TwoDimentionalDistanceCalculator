using TwoDimentionalDistanceCalculator.Common;
using TwoDimentionalDistanceCalculator.Models;
using TwoDimentionalDistanceCalculator.Interfaces;

namespace TwoDimentionalDistanceCalculator.Helpers;

public class PointDistanceComparer : IPointDistanceComparer
{
	private double _maxDistance;
	private readonly ICollection<Point> _farthestPoints;

	public PointDistanceComparer()
	{
		_maxDistance = double.MinValue;
		_farthestPoints = new List<Point>(Constants.INITIAL_COLLECTION_SIZE);
	}

	public void Compare(Point point)
	{
		if (point.DistanceFromCenter > _maxDistance)
		{
			_maxDistance = point.DistanceFromCenter;

			_farthestPoints.Clear();
			_farthestPoints.Add(point);
		}
		else if (point.DistanceFromCenter == _maxDistance)
			_farthestPoints.Add(point);
	}

	public IEnumerable<Point> FarthestPoints => _farthestPoints;
}
