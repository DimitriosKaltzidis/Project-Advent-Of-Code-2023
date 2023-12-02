namespace AdventOfCode.Day2
{
	class Game
	{
		public int Id { get; set; }

		public List<Set> Sets { get; set; } = new List<Set>();

		public void AddSet(Set turn) { Sets.Add(turn); }

		public int GetTotalCubeNumberOfColorDrawn(CubeColor cubeColor) { return Sets.Sum(x => x.GetNumberOfCubesOfColor(cubeColor)); }

		public int GetTotalCubeNumberDrawn() { return Sets.Sum(x => x.GetNumberOfCubes()); }

		public int GetMaxNumberOfDrawnCubesOfColor(CubeColor cubeColor) { return Sets.Select(x => x.GetNumberOfCubesOfColor(cubeColor)).Max(); }

		public int GetMinNumberOfDrawnCubesOfColor(CubeColor cubeColor) { return Sets.Select(x => x.GetNumberOfCubesOfColor(cubeColor)).Min(); }

		public bool IsGamePossibleFor(Dictionary<CubeColor, int> restrains)
		{
			foreach (var restrain in restrains)
			{
				var max = GetMaxNumberOfDrawnCubesOfColor(restrain.Key);
				var min = GetMinNumberOfDrawnCubesOfColor(restrain.Key);

				if (max > restrain.Value)
					return false;
			}

			return true;
		}

		public int GetGamePower()
		{
			var power = 1;
			foreach (CubeColor color in Enum.GetValues(typeof(CubeColor)))
			{
				var max = GetMaxNumberOfDrawnCubesOfColor(color);
				power *= max;
			}

			return power;
		}
	}
}
