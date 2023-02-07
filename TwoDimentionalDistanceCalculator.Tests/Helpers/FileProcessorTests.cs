using TwoDimentionalDistanceCalculator.Models;
using TwoDimentionalDistanceCalculator.Helpers;
using TwoDimentionalDistanceCalculator.Interfaces;

namespace TwoDimentionalDistanceCalculator.Tests.Helpers;

[CollectionDefinition(nameof(FileProcessor))]
public class FileProcessorTests
{
	private readonly IFileProcessor _fileProcessor;
	private readonly Mock<IPointDistanceComparer> _mockDistanceComparer;

	private readonly string _filePath;
	private readonly string? _currentDirectory;

	public FileProcessorTests()
	{
		string? location = Assembly.GetEntryAssembly()?.Location;
		string? currentDirectory = Path.GetDirectoryName(location);

		if (currentDirectory is not null)
			_currentDirectory = currentDirectory;

		_filePath = $@"{_currentDirectory}\{Constants.DUMMY_TEST_FILENAME}";

		_mockDistanceComparer = new Mock<IPointDistanceComparer>();
		_fileProcessor = new FileProcessor(_mockDistanceComparer.Object);
	}

	[Fact]
	public async Task RunAsync_ShouldProcessAllLines_WhenTheyAreAllValidInput()
	{
		// Arrange
		Console.SetIn(new StringReader(_filePath));
		await File.WriteAllTextAsync(_filePath, string.Empty);
		await File.WriteAllTextAsync(_filePath, $"Point1(0, 0){Environment.NewLine}Point2(1, 0)");

		_mockDistanceComparer
			.Setup(x => x.FarthestPoints)
			.Returns(new[] { new Point("Point1", 0d, 0d) });

		// Act
		IEnumerable<Point> result = await _fileProcessor.RunAsync();

		// Assert
		_mockDistanceComparer.Verify(x => x.Compare(It.IsAny<Point>()), Times.Exactly(2));
		
		result.Should().NotBeNullOrEmpty();
		result.Should().HaveCount(1);
	}

	[Fact]
	public async Task RunAsync_ShouldProcessAllValidLines_WhenThereAreInvalidOnes()
	{
		// Arrange
		Console.SetIn(new StringReader(_filePath));
		await File.WriteAllTextAsync(_filePath, string.Empty);
		await File.WriteAllTextAsync(_filePath, $"Point1(0, 0){Environment.NewLine}{Environment.NewLine}Point3(5, -5.5){Environment.NewLine}{string.Empty}{Environment.NewLine}");

		_mockDistanceComparer
			.Setup(x => x.FarthestPoints)
			.Returns(new[] { new Point("Point3", 5d, -5.5d) });

		// Act
		IEnumerable<Point> result = await _fileProcessor.RunAsync();

		// Assert
		_mockDistanceComparer.Verify(x => x.Compare(It.IsAny<Point>()), Times.Exactly(2));

		result.Should().NotBeNullOrEmpty();
		result.Should().HaveCount(1);
	}

	[Fact]
	public async Task RunAsync_ShouldNotCallTheComparer_WhenTheInputFileIsEmpty()
	{
		// Arrange
		Console.SetIn(new StringReader(_filePath));
		await File.WriteAllTextAsync(_filePath, string.Empty);

		_mockDistanceComparer
			.Setup(x => x.FarthestPoints)
			.Returns(Array.Empty<Point>());

		// Act
		IEnumerable<Point> result = await _fileProcessor.RunAsync();

		// Assert
		_mockDistanceComparer.Verify(x => x.Compare(It.IsAny<Point>()), Times.Never);

		result.Should().NotBeNull();
		result.Should().BeEmpty();
	}
}