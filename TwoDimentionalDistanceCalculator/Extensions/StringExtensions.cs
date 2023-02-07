using System.Text.RegularExpressions;

using TwoDimentionalDistanceCalculator.Common;
using TwoDimentionalDistanceCalculator.Models;

namespace TwoDimentionalDistanceCalculator.Extensions;

public static partial class StringExtensions
{
	private static readonly Regex _regex = new(Constants.POINT_PARSE_REGEX, RegexOptions.Compiled);

	public static Point? ToPoint(this string value)
	{
		if (string.IsNullOrEmpty(value))
			return null;

		Match regexMatch = _regex.Match(value);

		if (!regexMatch.Success ||
			regexMatch.Groups.Count != Constants.NUMBER_OF_ALLOWED_INPUT_TOKENS ||
			!double.TryParse(regexMatch.Groups[2].Value, out double x) ||
			!double.TryParse(regexMatch.Groups[3].Value, out double y))
			return null;

		return new(regexMatch.Groups[1].Value, x, y);
	}
}
