namespace AdventOfCode.Day2
{
	class Set
	{
		public List<Cube> Cubes { get; set; } = new List<Cube>();

		public void AddCube(Cube cube) { Cubes.Add(cube); }

		public int GetNumberOfCubes() { return Cubes.Count; }

		public int GetNumberOfCubesOfColor(CubeColor cubeColor) { return Cubes.Count(x => x.CubeColor == cubeColor); }
	}
}
