using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day2
{
	class Cube
	{
		public CubeColor CubeColor { get; set; }
	}

	enum CubeColor
	{
		Red = 0,
		Green = 1,
		Blue = 2,
	}
}
