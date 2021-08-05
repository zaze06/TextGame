using System;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    class Game
    {
        static int lvl = 0;
        static int[,] map = Map.map(lvl);
        int mapSizeX = map.GetLength(0);
        int mapSizeY = map.GetLength(1);
        int playerX = 1;
        int playerY = 1;
        int renderDistend = 1;
        bool makeMap = false;
        ConsoleKey[] keyIcons = { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.H, ConsoleKey.D8};
        string[] icons = {"-", "|", "/", "\\", "¯", "_", " ", "*", "H", "-"};
        string mapIcons = "0='-':1='|':2='/':3='\\':4='¯':5='_':6=' ':7='*':H='H':8='-'(End point)";
        string commands = "C='clear'";

        static void Main(string[] args)
        {
            new Game().game(args);
        }
        void game(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Console.WriteLine("Game made by Zacharias\n©Zacharias 2021");
            //Console.WriteLine(now.Hour + ":" + now.Minute + ":" + now.Second);
            //clearMap();
            wait(3);
            Console.Clear();
            while (true)
            {
                writeMap();
                keyPress();
                if(wasOnSpecial) writeMap();
            }
        }

        private void clearMap()
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x, y] = 0;
                }
            }
        }

        private void keyPress()
        {
            Console.SetCursorPosition(0, mapSizeY + 2);
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
                    Console.Clear();
                    Console.Write("{");
                    for (int x = 0; x < mapSizeX; x++)
                    {
                        Console.Write("{");
                        for (int y = 0; y < mapSizeY; y++)
                        {
                            Console.Write(map[x, y] + (y < mapSizeY - 1 ? "," : ""));
                        }
                        Console.Write("}" + (x < mapSizeX - 1 ? ",\n" : ""));
                    }
                    Console.WriteLine("}");
                    Environment.Exit(0);
                }else if(key == ConsoleKey.Backspace)
                {
                    map[playerX, playerY] = 0;
                }
                for(int i = 0; i < keyIcons.Length; i++)
                {
                    if(key == keyIcons[i])
                    {
                        map[playerX, playerY] = i;
                    }
                }
                if(key == ConsoleKey.C)
                {
                    clearMap();
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
            if (isAllowed(map[playerX, playerY]))
            {
                return true;
            }
            return false;
        }

        private bool isAllowed(int v)
        {
            return (v == 0 || v == 8 || v == 9);
        }

        bool wasOnSpecial = false;

        private void writeMap()
        {
            Console.SetCursorPosition(0, 1);
            int tpX = -1;
            int tpY = -1;
            bool playerOnTp = false;
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    int num = map[x, y];
                    string icon = num.ToString();
                    if (x == playerX && y == playerY) {
                        if (num == 9 && !makeMap)
                        {
                            lvl++;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Level " + (lvl - 1) + " compleat. Curent lvl " + lvl);
                            map = Map.map(1);
                            writeMap();
                            return;
                        }
                    }
                    if(num == 8)
                    {
                        if (!wasOnSpecial && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX != -1 && tpY != -1)
                                {
                                    playerX = tpX;
                                    playerY = tpY;
                                    wasOnSpecial = true;
                                }
                                else
                                {
                                    playerOnTp = true;
                                }
                            }
                            else
                            {
                                tpX = x;
                                tpY = y;
                            }
                            if (playerOnTp)
                            {
                                if (tpX != -1 && tpY != -1)
                                {
                                    playerX = tpX;
                                    playerY = tpY;
                                    wasOnSpecial = true;
                                    
                                }
                            }
                        }
                        else
                        {
                            wasOnSpecial = false;
                        }
                    }
                    try
                    {
                        icon = this.icons[num];
                    }catch(Exception e) { e.ToString(); }
                    if (x == playerX && y == playerY)
                    {
                        icon = "&";
                    }
                    if(!((x <= playerX + renderDistend && x >= playerX - renderDistend) && (y <= playerY + renderDistend && y >= playerY - renderDistend)))
                    {
                        if (!makeMap) icon = " ";
                    }
                    Console.Write(icon);
                }
                Console.Write("\n");
            }
            if (makeMap)
            {
                Console.WriteLine("Curent pice: '" + this.icons[map[playerX, playerY]] + "'");
                Console.WriteLine(mapIcons);
                Console.WriteLine(commands);
            }
            else
            {
                
                for (int i = 0; i < 16; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\n");
                for (int i = 0; i < mapIcons.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\n");
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.Write(" ");
                }
            }
        }

        static string getSafeLocation()
        {
            int p = (int)Environment.OSVersion.Platform;
            if(p == 6)
            {
                return "~/Library/Application Support/Zacharias/TextGame";
            }else if(p == 4)
            {
                return "/var/Zacharias/TextGame";
            }else if(p == 2)
            {
                string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                Console.WriteLine(user);
                Console.WriteLine(user.Split('\\')[1]);
                return Path.Combine("C:", "Users", user.Split('\\')[1], "Documents","MyGames","Zacharias","TextGame");
            }
            else
            {
                return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/data";
            }
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            string loc = getSafeLocation();
            //Console.WriteLine(loc);
            //Console.WriteLine(Path.Combine(loc, "Test.txt"));
            if (!Directory.Exists(loc))
            {
                Directory.CreateDirectory(loc);
            }
            loc = Path.Combine(loc, "Test.txt");
            if (!File.Exists(loc))
            {
                File.Create(loc);
            }
            FileStream file = File.OpenWrite(loc);
            byte[] ext = Encoding.ASCII.GetBytes("You ended on lvl: " + lvl);
            file.Write(ext, 0, ext.Length);
            file.Flush();
            file.Close();
            Console.WriteLine(loc);
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
