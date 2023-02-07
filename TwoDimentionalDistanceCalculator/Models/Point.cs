using System.Text;

namespace TwoDimentionalDistanceCalculator.Models;

public record Point
{
	public Point(string name, double x, double y)
	{
		Name = name;
		X = x;
		Y = y;

		Quadrant = SetQuadrantLocation();
		DistanceFromCenter = CalculateDistanceFromCenter();
	}

	public string Name { get; init; }

	public double X { get; init; }

	public double Y { get; init; }

	public double DistanceFromCenter { get; init; }

	public Quadrants Quadrant { get; init; }

	private double CalculateDistanceFromCenter()
	{
		if (X == 0 || Y == 0)
			return Math.Max(Math.Abs(X), Math.Abs(Y));

		return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
	}

	private Quadrants SetQuadrantLocation()
	{
		if (X > 0 && Y > 0)
			return Quadrants.First;
		else if (X < 0 && Y > 0)
			return Quadrants.Second;
		else if (X < 0 && Y < 0)
			return Quadrants.Third;
		else if (X > 0 && Y < 0)
			return Quadrants.Fourth;
		else if (X == 0 && Y == 0)
			return Quadrants.Center;
		else return Quadrants.None;
	}

	public override string ToString()
	{
		StringBuilder output = new($"{Name}({X}, {Y}) is located ");

		switch (Quadrant)
		{
			case Quadrants.First:
			case Quadrants.Second:
			case Quadrants.Third:
			case Quadrants.Fourth:
				output.Append("in " + Quadrant + " quadrant.");
				break;
			case Quadrants.Center:
				output.Append("in the center of the grid.");
				break;
			case Quadrants.None:
				if (X == 0) output.Append("on the Y-axis");
				else output.Append("on the X-axis");
				break;
		}

		return output.ToString();
	}
}
