namespace AdventOfCode.Common
{
	public class FileUtils
	{
		public static List<string> ReadAllLinesFromFile(string path)
		{
			return File.ReadAllLines(path).ToList();
		}
	}
}