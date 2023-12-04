namespace AdventOfCode.Day4
{
	class CardDeck
	{
		public List<Card> Cards { get; set; } = new List<Card>();

		public double GetDeckWorth()
		{
			return Cards.Sum(x => x.GetCardWorth());
		}

		public int GetTotalCards()
		{
			var cardCount = Enumerable.Repeat(1, Cards.Count).ToArray();

			for (var i = 0; i < Cards.Count; i++)
			{
				var matches = Cards[i].GetCorrectlyGuessedItems();
				for (var j = 0; j < matches.Count; j++)
				{
					cardCount[i + 1 + j] += cardCount[i];
				}
			}

			return cardCount.Sum();
		}
	}
}
