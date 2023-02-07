using TwoDimentionalDistanceCalculator.Models;

namespace TwoDimentionalDistanceCalculator.Interfaces;

public interface IFileProcessor
{
	Task<IEnumerable<Point>> RunAsync();
}
