using TwoDimentionalDistanceCalculator.Models;
using TwoDimentionalDistanceCalculator.Interfaces;
using TwoDimentionalDistanceCalculator.Extensions;

namespace TwoDimentionalDistanceCalculator.Helpers;

public class FileProcessor : IFileProcessor
{
	private readonly IPointDistanceComparer _distanceComparer;

	public FileProcessor(IPointDistanceComparer distanceComparer) => _distanceComparer = distanceComparer;

	public async Task<IEnumerable<Point>> RunAsync()
	{
		string filePath = ConsoleExtensions.ReadFilePath();

		using FileStream fileStream = File.OpenRead(filePath);
		using StreamReader streamReader = new(fileStream);

		while (!streamReader.EndOfStream)
		{
			string? pointDetails = await streamReader.ReadLineAsync();
			Point? currentPoint = pointDetails.ToPoint();

			if (currentPoint is null)
				continue;

			_distanceComparer.Compare(currentPoint);
		}

		return _distanceComparer.FarthestPoints;
	}
}
