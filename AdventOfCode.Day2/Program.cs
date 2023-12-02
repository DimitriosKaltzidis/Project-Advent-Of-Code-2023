// Read and parse data
using AdventOfCode.Common;
using AdventOfCode.Day2;
using System.Text.RegularExpressions;

var lines = FileUtils.ReadAllLinesFromFile("input1.txt");
var games = ParseGamesPlayed(lines);
var part1 = GetPartOne(games);
var part2 = GetPartTwo(games);

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

int GetPartOne(List<Game> games)
{
	var part1 = 0;
	var part1Restraints = new Dictionary<CubeColor, int>() { { CubeColor.Red, 12 }, { CubeColor.Green, 13 }, { CubeColor.Blue, 14 } };

	foreach (var game in games)
	{
		if (game.IsGamePossibleFor(part1Restraints))
		{
			part1 += game.Id;
		}
	}

	return part1;
}

int GetPartTwo(List<Game> games)
{
	var part2 = 0;

	foreach (var game in games)
		part2 += game.GetGamePower();

	return part2;
}

List<Game> ParseGamesPlayed(List<string> inputLines)
{
	var gamesList = new List<Game>();

	foreach (var line in inputLines)
	{
		var gameDataParts = line.Split(':');
		var gameId = GetIntFromString(gameDataParts[0]);
		var game = new Game()
		{
			Id = gameId,
		};
		var sets = gameDataParts[1].Split(";");

		foreach (var set in sets)
		{
			var setObeject = new Set();
			var cubes = set.Split(",");
			foreach (var cube in cubes)
			{
				var cubeDetails = cube.Trim().Split(" ");
				var cubeNumber = GetIntFromString(cubeDetails[0]);
				var cubeColor = GetCubeColorFromString(cubeDetails[1]);
				for (int i = 0; i < cubeNumber; i++)
					setObeject.AddCube(new Cube() { CubeColor = cubeColor });
			}
			game.AddSet(setObeject);
		}
		gamesList.Add(game);
	}

	return gamesList;
}

int GetIntFromString(string input)
{
	var matches = Regex.Matches(input, @"\d+");

	if (matches.Count > 0)
		return int.Parse(matches[0].Value);
	else
		throw new Exception("No numbers found in the string.");
}

CubeColor GetCubeColorFromString(string colorString)
{
	switch (colorString)
	{
		case "red":
			return CubeColor.Red;
		case "blue":
			return CubeColor.Blue;
		case "green":
			return CubeColor.Green;
		default: throw new Exception();
	}
}