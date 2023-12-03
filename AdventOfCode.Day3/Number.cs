namespace AdventOfCode.Day3
{
	class Number
	{
		public Point Start { get; set; }
		
		public Point End { get; set; }

		public int Value { get; set; }

		public int Row { get; set; }

		public bool HasCharacterAroundIt { get; set; }

		public List<Character> SurroundingCharacters { get; set; } = new List<Character>();
	}
}
