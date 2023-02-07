using System.Reflection;

namespace TwoDimentionalDistanceCalculator.Tests.Fixtures;

public class FileCreatonFixtures : IDisposable
{
	private readonly string _executionDirectory;

	public FileCreatonFixtures()
	{
		string? location = Assembly.GetEntryAssembly()?.Location;
		string? currentDirectory = Path.GetDirectoryName(location);

		if (currentDirectory is not null && !File.Exists($@"{_executionDirectory}\{Constants.DUMMY_TEST_FILENAME}"))
		{
			_executionDirectory = currentDirectory;
			File.Create($@"{_executionDirectory}\{Constants.DUMMY_TEST_FILENAME}").Close();
		}
	}

	public void Dispose()
	{
		if (File.Exists($@"{_executionDirectory}\{Constants.DUMMY_TEST_FILENAME}"))
			File.Delete($@"{_executionDirectory}\{Constants.DUMMY_TEST_FILENAME}");
	}
}
