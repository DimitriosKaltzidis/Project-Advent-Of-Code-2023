using AdventOfCode.Common;
using AdventOfCode.Day4;

var cardLines = FileUtils.ReadAllLinesFromFile("input1.txt");

var deck = CreateCardDeck(cardLines);

Console.WriteLine($"Part 1: {deck.GetDeckWorth()}");
Console.WriteLine($"Part 2: {deck.GetTotalCards()}");

CardDeck CreateCardDeck(List<string> cardLines)
{
	var cards = new List<Card>();

	foreach (var cardLine in cardLines)
	{
		cards.Add(new Card()
		{
			WinningNumbers = cardLine.Split(':')[1].Split('|')[0].Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x.Trim())).ToList(),
			PlayedNumbers = cardLine.Split(':')[1].Split('|')[1].Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x.Trim())).ToList(),
		});
	}

	return new CardDeck()
	{
		Cards = cards
	};
}