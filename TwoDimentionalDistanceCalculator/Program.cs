using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using TwoDimentionalDistanceCalculator.Models;
using TwoDimentionalDistanceCalculator.Helpers;
using TwoDimentionalDistanceCalculator.Interfaces;

namespace TwoDimentionalDistanceCalculator;

[ExcludeFromCodeCoverage]
public class Program
{
	static async Task Main()
	{
		IServiceProvider services = new ServiceCollection()
			.AddTransient<IFileProcessor, FileProcessor>()
			.AddTransient<IPointDistanceComparer, PointDistanceComparer>()
			.BuildServiceProvider();

		IFileProcessor fileProcessor = services
			.GetRequiredService<IFileProcessor>();

		IEnumerable<Point> fatherstPoints = await fileProcessor.RunAsync();

		foreach (Point point in fatherstPoints)
			Console.WriteLine(point);
	}
}
