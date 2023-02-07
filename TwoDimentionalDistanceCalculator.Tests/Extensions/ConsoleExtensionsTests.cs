using FluentAssertions;

using System.Reflection;
using System.Text.RegularExpressions;

using TwoDimentionalDistanceCalculator.Extensions;
using TwoDimentionalDistanceCalculator.Tests.Fixtures;

namespace TwoDimentionalDistanceCalculator.Tests.Extensions;

public class ConsoleExtensionsTests : IClassFixture<FileCreatonFixtures>
{
	private readonly string? _currentDirectory;

	public ConsoleExtensionsTests()
	{
		string? location = Assembly.GetEntryAssembly()?.Location;
		string? currentDirectory = Path.GetDirectoryName(location);

		if (currentDirectory is not null)
			_currentDirectory = currentDirectory;
	}

	[Fact]
	public void ReadFilePath_ShouldReturnSuccessfullResult_WhenGivenValidInput()
	{
		// Arrange
		StringReader existingFilePath = new ($@"{_currentDirectory}\{Constants.DUMMY_TEST_FILENAME}");
		Console.SetIn(existingFilePath);

		// Act
		string result = ConsoleExtensions.ReadFilePath();

		// Assert
		result.Should().EndWith(Constants.DUMMY_TEST_FILENAME);
	}

	[Theory]
	[InlineData(Constants.EMPTY_FILE_PATH)]
	[InlineData(Constants.RANDOM_TEXT_AS_PATH)]
	[InlineData(Constants.NON_EXISTANT_FILE_PATH)]
	[InlineData(Constants.NO_FILE_EXTENSION_FILE_PATH)]
	[InlineData(Constants.FILE_PATH_WITH_EMPTY_SPACES)]
	public void ReadFilePath_ShouldPickValidPath_WhenMixedInputIsProvided(string invalidPath)
	{
		// Arrange
		Regex regex = new(Common.Constants.ERROR_INVALID_FILE_PATH);
		StringWriter consoleOutput = new();
		StringReader existingFilePath = new(
			 $"{invalidPath}{Environment.NewLine}" +
			$@"{_currentDirectory}\{Constants.DUMMY_TEST_FILENAME}{Environment.NewLine}");
		
		Console.SetIn(existingFilePath);
		Console.SetOut(consoleOutput);

		// Act
		string result = ConsoleExtensions.ReadFilePath();

		// Assert
		regex.Count(consoleOutput.ToString()).Should().Be(1);
		result.Should().EndWith(Constants.DUMMY_TEST_FILENAME);
	}

	[Fact]
	public void ReadFilePath_ShouldPickTheValidPath_WhenThereAreLeadingEmptySpaces()
	{
		// Arrange
		Regex regex = new(Common.Constants.ERROR_INVALID_FILE_PATH);
		StringWriter consoleOutput = new();
		StringReader existingFilePath = new($@"  {_currentDirectory}\{Constants.DUMMY_TEST_FILENAME}{Environment.NewLine}");

		Console.SetIn(existingFilePath);
		Console.SetOut(consoleOutput);

		// Act
		string result = ConsoleExtensions.ReadFilePath();

		// Assert
		regex.Count(consoleOutput.ToString()).Should().Be(0);
		result.Should().EndWith(Constants.DUMMY_TEST_FILENAME);
	}

	[Fact]
	public void ReadFilePath_ShouldPickTheValidPath_WhenThereAreTrailingEmptySpaces()
	{
		// Arrange
		Regex regex = new(Common.Constants.ERROR_INVALID_FILE_PATH);
		StringWriter consoleOutput = new();
		StringReader existingFilePath = new($@"{_currentDirectory}\{Constants.DUMMY_TEST_FILENAME}   {Environment.NewLine}");

		Console.SetIn(existingFilePath);
		Console.SetOut(consoleOutput);

		// Act
		string result = ConsoleExtensions.ReadFilePath();

		// Assert
		regex.Count(consoleOutput.ToString()).Should().Be(0);
		result.Should().EndWith(Constants.DUMMY_TEST_FILENAME);
	}
}
