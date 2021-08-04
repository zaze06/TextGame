using System;

namespace Game
{
    class Game
    {
        static int[,] map = new int[20,20];
        int mapSizeX = map.GetLength(0);
        int mapSizeY = map.GetLength(1);
        int playerX = 0;
        int playerY = 0;
        bool makeMap = false;
        string[] icon = {"-", "|", "/", "\\", "¯", "_", " "};
        string mapIcons = "0='-':1='|':2='/':3='\\':4='¯':5='_':6=' '";

        static void Main(string[] args)
        {
            new Game().game(args);
        }
        void game(string[] args)
        {
            Console.WriteLine("Game made by Zacharias\n©Zacharias 2021");
            //Console.WriteLine(now.Hour + ":" + now.Minute + ":" + now.Second);
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x, y] = 0;
                }
            }
            wait(3);
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition(0,0);
                writeMap();
                Console.SetCursorPosition(0, mapSizeY + 1);
                keyPress();
            }
        }

        private void keyPress()
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow && playerX > 0)
            {
                playerX--;
                if (!canDoMove())
                {
                    playerX++;
                }
            }else if(key == ConsoleKey.DownArrow && playerX < mapSizeX - 1)
            {
                playerX++;
                if (!canDoMove())
                {
                    playerX--;
                }
            }
            else if(key == ConsoleKey.LeftArrow && playerY > 0)
            {
                playerY--;
                if (!canDoMove())
                {
                    playerY++;
                }
            }
            else if(key == ConsoleKey.RightArrow && playerY < mapSizeY - 1)
            {
                playerY++;
                if (!canDoMove())
                {
                    playerY--;
                }
            }else if(key == ConsoleKey.Enter)
            {
                makeMap = !makeMap;
            }else if (makeMap)
            {
                if(key == ConsoleKey.Home)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write("{");
                    for (int x = 0; x < mapSizeX; x++)
                    {
                        Console.Write("{");
                        for (int y = 0; y < mapSizeY; y++)
                        {
                            Console.Write(map[x, y]);
                        }
                        Console.Write("},");
                    }
                    Console.WriteLine("}");
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.D0)
                {
                    map[playerX, playerY] = 0;
                }
                else if (key == ConsoleKey.D1)
                {
                    map[playerX, playerY] = 1;
                }
                else if (key == ConsoleKey.D2)
                {
                    map[playerX, playerY] = 2;
                }
                else if (key == ConsoleKey.D3)
                {
                    map[playerX, playerY] = 3;
                }
                else if (key == ConsoleKey.D3)
                {
                    map[playerX, playerY] = 3;
                }
                else if (key == ConsoleKey.D4)
                {
                    map[playerX, playerY] = 4;
                }
                else if (key == ConsoleKey.D5)
                {
                    map[playerX, playerY] = 5;
                }
                else if (key == ConsoleKey.D6)
                {
                    map[playerX, playerY] = 6;
                }
            }
            Console.SetCursorPosition(0, mapSizeY + 1);
            Console.Write(" ");
        }

        private bool canDoMove()
        {
            if (makeMap)
            {
                return true;
            }
            if (map[playerX, playerY] == 0)
            {
                return true;
            }
            return false;
        }

        private void writeMap()
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    int num = map[x, y];
                    string icon = num.ToString();
                    try
                    {
                        icon = this.icon[num];
                    }catch(Exception e) { e.ToString(); }
                    if (x == playerX && y == playerY)
                    {
                        icon = "&";
                    }
                    Console.Write(icon);
                }
                Console.Write("\n");
            }
            if (makeMap)
            {
                Console.WriteLine(mapIcons);
            }
            else
            {
                for (int i = 0; i < mapIcons.Length; i++)
                {
                    Console.Write(" ");
                };
            }
        }

        private void wait(int time)
        {
            DateTime timeToEnd = DateTime.Now.AddSeconds(time);
            //timeToEnd = timeToEnd.AddSeconds(time);
            DateTime now = DateTime.Now;
            while (timeToSring(now.Hour, now.Minute, now.Second) != timeToSring(timeToEnd.Hour, timeToEnd.Minute, timeToEnd.Second)) {
                now = DateTime.Now;
            }
        }
        private string timeToSring(int H, int M, int S)
        {
            return H + ":" + M + ":" + S;
        }
    }
}
