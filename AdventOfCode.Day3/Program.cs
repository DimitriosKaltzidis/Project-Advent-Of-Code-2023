using AdventOfCode.Common;
using AdventOfCode.Day3;
using System.Text.RegularExpressions;

var engineScematicFileLines = FileUtils.ReadAllLinesFromFile("input1.txt");
var numbers = PartOne(engineScematicFileLines);

Console.WriteLine($"Part 1: {numbers.Where(x => x.HasCharacterAroundIt).Sum(x => x.Value)}");
Console.WriteLine($"Part 2: {PartTwo(numbers)}");

int PartTwo(List<Number> numbers)
{
	// Not very performant .... oh well
	int sum = 0;
	var numbersWithStarCharacterNearThem = numbers.Where(x => x.HasCharacterAroundIt && x.SurroundingCharacters.Any(x => x.Value == '*'));
	var points = numbersWithStarCharacterNearThem.SelectMany(x => x.SurroundingCharacters);
	Dictionary<(int row, int column), Point> distinctPoints = new Dictionary<(int row, int column), Point>();
	foreach (var point in points)
	{
		if(!distinctPoints.ContainsKey((point.Location.Row, point.Location.Column)))
		{
			distinctPoints.Add((point.Location.Row, point.Location.Column),point.Location);
		}
	}

	foreach (var point in distinctPoints.Values) {
		var possibleNumbers = numbersWithStarCharacterNearThem.Where(x => x.SurroundingCharacters.Any(y => y.Location.Column == point.Column && y.Location.Row == point.Row)).ToList();

		if(possibleNumbers.Count() == 2)
		{
			sum += possibleNumbers[0].Value * possibleNumbers[1].Value;
		}
	}

	return sum;
}

List<Number> PartOne(List<string> lines)
{
	var scematicHeigt = lines.Count;
	var scematicWidth = lines[0].Length;
	List<Number> numbers = new List<Number>();

	for (int i = 0; i < scematicHeigt; i++)
	{
		var line = lines[i];
		string pattern = @"\d+";
		var matches = Regex.Matches(line, pattern); // Find numbers

		foreach (Match match in matches)
		{
			var number = new Number() { Start = new Point(match.Index, i), End = new Point(match.Index + match.Length - 1, i), Row = i, Value = int.Parse(match.Value) };
			numbers.Add(EnhanceNumberWithDetectedSpecialCharacters(lines, number)); // Find if special charactes exist around a number
		}
	}

	return numbers;
}

Number EnhanceNumberWithDetectedSpecialCharacters(List<string> lines, Number number)
{
	var scematicHeigt = lines.Count;
	var scematicWidth = lines[0].Length;
	var specialChars = @"*@-+#%=/$&";
	var sourroundingPoints = new List<Point>();

	for (int j = number.Start.Row - 1; j <= number.Start.Row + 1; j++)
	{
		for (int i = number.Start.Column - 1; i <= number.End.Column + 1; i++)
		{
			var point = new Point(i, j);
			sourroundingPoints.Add(point);
		}
	}

	sourroundingPoints = sourroundingPoints.Where(x => (x.Row >= 0 && x.Row < scematicHeigt) && (x.Column >= 0 && x.Column < scematicWidth)).ToList();

	foreach (var point in sourroundingPoints)
	{
		if (specialChars.Contains(lines[point.Row][point.Column]))
		{
			number.SurroundingCharacters.Add(new Character() { Location = point, Value = lines[point.Row][point.Column] });
			number.HasCharacterAroundIt = true;
		}
	}

	return number;
}