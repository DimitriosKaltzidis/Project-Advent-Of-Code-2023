using AdventOfCode.Common;
using System.Text.RegularExpressions;

var lines = FileUtils.ReadAllLinesFromFile("input1.txt");

Console.WriteLine($"Part 1: {GetPartOne(lines)}");
Console.WriteLine($"Part 2: {GetPartTwo(lines)}");

static int GetPartOne(List<string> lines)
{
	var sum = 0;

	foreach (var line in lines)
	{
		var matches = Regex.Matches(line, @"\d+");
		var firstNumber = matches[0].Value;
		var lastNumber = matches[matches.Count - 1].Value;
		int.TryParse($"{firstNumber[0]}{lastNumber[lastNumber.Length - 1]}", out var number);
		sum += number;
	}

	return sum;
}

static int GetPartTwo(List<string> lines)
{
	var calibrationValues = new List<string>();

	foreach (string line in lines)
	{
		var pattern = @"(\d|one|two|three|four|five|six|seven|eight|nine)";
		var first = Regex.Match(line, pattern).ToString();
		var last = Regex.Match(line, pattern, RegexOptions.RightToLeft).ToString();

		if (first.Length > 1) first = ConvertWordToDigit(first);
		if (last.Length > 1) last = ConvertWordToDigit(last);
		if (first.Length > 0) calibrationValues.Add(first + last);
	}

	return calibrationValues.Sum(x => int.Parse(x));
}

static string ConvertWordToDigit(string text)
{
	switch (text)
	{
		case "one": { return "1"; };
		case "two": { return "2"; };
		case "three": { return "3"; };
		case "four": { return "4"; };
		case "five": { return "5"; };
		case "six": { return "6"; };
		case "seven": { return "7"; };
		case "eight": { return "8"; };
		case "nine": { return "9"; };
		default: { return text; };
	};
}