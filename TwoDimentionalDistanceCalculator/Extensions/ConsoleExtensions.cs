using System.Diagnostics.CodeAnalysis;

using TwoDimentionalDistanceCalculator.Common;

namespace TwoDimentionalDistanceCalculator.Extensions;

public static class ConsoleExtensions
{
	[return: NotNull]
	public static string ReadFilePath()
	{
		string? filePath;

		while (true)
		{
			Console.Write(Constants.USER_INPUT_PROMPT);
			filePath = Console.ReadLine()?.Trim();

			if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
				Console.WriteLine(Constants.ERROR_INVALID_FILE_PATH);
			else break;
		}

		return filePath;
	}
}