using System;

namespace TextGame{
	public class ColorMaps
	{
		public ColorMaps()
		{
		}

		public static ConsoleColor[] colorMap(int lvl)
		{
			switch (lvl)
			{
				default:
					return new ConsoleColor[21] {ConsoleColor.DarkCyan, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.DarkGray, ConsoleColor.DarkGray,
						ConsoleColor.DarkGray, ConsoleColor.DarkGray, ConsoleColor.DarkGray, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.DarkMagenta,
						ConsoleColor.White, ConsoleColor.DarkMagenta, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.Cyan,
						ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.DarkRed};
			}
		}
	}
}
