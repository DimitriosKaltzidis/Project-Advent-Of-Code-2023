namespace AdventOfCode.Day3
{
	class Point
	{
		public int Column { get; set; } // Width
		public int Row { get; set; } // Height

		public Point(int column, int row)
		{
			Column = column;
			Row = row;
		}
	}
}
