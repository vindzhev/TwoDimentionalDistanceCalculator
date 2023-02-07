namespace TwoDimentionalDistanceCalculator.Tests;

public static class Constants
{
	public const string DUMMY_TEST_FILENAME = "dummy_test_file.txt";

	public const string NON_EXISTANT_FILE_PATH = $@"c:\temp\points2.txt";
	public const string EMPTY_FILE_PATH = null;
	public const string NO_FILE_EXTENSION_FILE_PATH = $@"c:\temp\points2";
	public const string RANDOM_TEXT_AS_PATH = $@"INVALID_INPUT";
	public const string FILE_PATH_WITH_EMPTY_SPACES = $@"c:\random folder\tests.txt";
	public const string FILE_PATH_WITH_LEADING_EMPTY_SPACES = $@" c:\random folder\tests.txt";
	public const string FILE_PATH_WITH_TRAILING_EMPTY_SPACES = $@"c:\random folder\tests.txt ";
}
