using System.Diagnostics.CodeAnalysis;

namespace TwoDimentionalDistanceCalculator.Common
{
	[ExcludeFromCodeCoverage]
	public static class Constants
	{
		public const string USER_INPUT_PROMPT = "Please enter valid path to input file: ";
		public const string ERROR_INVALID_FILE_PATH = "Invalid input. Please try again.";
		public static readonly char[] POINT_DETAILS_SEPARATORS = new[] { '(', ')', ',' };
		public const int NUMBER_OF_ALLOWED_INPUT_TOKENS = 4;
		public const string INPUT_NUMBER_VALUE_OVERFLOWN = "{0}'s coordinates exceed allowed range. Calculations will be skipped.";
		public const int INITIAL_COLLECTION_SIZE = 32;
		public const string POINT_PARSE_REGEX = @"(Point\w+)\((-?\d+(?:\.\d+)?(?:E[+-]\d+)?),\s*(-?\d+(?:\.\d+)?(?:E[+-]\d+)?)\)";
	}
}
