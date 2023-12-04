namespace AdventOfCode.Day4
{
	class Card
	{
		public List<int> WinningNumbers { get; set; } = new List<int>();

		public List<int> PlayedNumbers { get; set; } = new List<int>();

		public double GetCardWorth()
		{
			var commonItems = WinningNumbers.Intersect(PlayedNumbers).ToList();

			if(commonItems.Count > 0)
			{
				return Math.Pow(2, (commonItems.Count - 1));
			}

			return 0d;
		}

		public List<int> GetCorrectlyGuessedItems()
		{
			return WinningNumbers.Intersect(PlayedNumbers).ToList();
		}
	}
}
