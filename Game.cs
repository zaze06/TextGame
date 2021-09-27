using System;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TextGame
{
    class Game
    {
        //public static GetMaps maps = new GetMaps();
        public static int lvl = 0;
        public static Map map3 = new Map();
        public int[,] map = Util.convertMapToIntArray(map3.map);
        public int endX = 18;
        public int endY = 18;
        public int mapSizeX = 0;
        public int mapSizeY = 0;
        public int lifes = 5;
        public static int playerX = map3.startPosition[0];
        public static int playerY = map3.startPosition[1];
        public int renderDistend = 1;
        public bool makeMap = false;
        public bool playerWasOnTp = false;
        public int[] walkibles = {0, 8, 9, 10, 15, 16, 17};
        public ConsoleKey[] keyIcons = { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6,
            ConsoleKey.D7, ConsoleKey.H, ConsoleKey.D8, ConsoleKey.L, ConsoleKey.D9, ConsoleKey.O, ConsoleKey.U, ConsoleKey.I, ConsoleKey.Y, ConsoleKey.R,
            ConsoleKey.G, ConsoleKey.D};
        public ConsoleColor[] colors = Util.convertIntArrayToColor(Util.convertListToIntArray(map3.color));
        public string[] icons = {"-", "|", "/", "\\", "¯", "_", " ", "*", "H", "E", "L", "<", ">", "v", "^", " ", "=", "|", "#"};
        public string[] devIcons = {"-", "|", "/", "\\", "¯", "_", "+", "*", "H", "E", "L", "<", ">", "v", "^", "%", "=", "|", "#"};
        public string mapIcons = "0='-' : 1='|' : 2='/' : 3='\\' : 4='¯' : 5='_' : 6=' ' : 7='*' : H='H'(Teleport must have 2 to work no more no less) : " +
            "8='E'(End point) : L='-'(Same as 'H' but difrent) : <='<'(a one way door can go thru the big end) : " +
            "O='>'(a one way door can go thru the big end) : U='v'(a one way door can go thru the big end) : " +
            "I='^'(a one way door can go thru the big end) : Y=' '(same as 6 but walkible) :" +
            " R='='(a walk way that only posible to walk anong side cant go up or down on it) : "+
            "G='|'(a walk way thay only posible to walk along side cant go left or right on it) : "+
            "D='#'(a point that you tack one dmg when you walk on it)";
        public string commands = "C='clear' : F1='export map'";
        private int lastTile = 0;

        static void Main(string[] args)
        {
            new Game();
        }
        public Game()
        {
            //new GetMaps();
            //maps = new GetMaps();
            //map3 = GetMaps.getMap(lvl);
            map = GetMaps.getMap(lvl);
            colors = ColorMaps.colorMap(lvl);
            playerX = 1;
            playerY = 1;
            mapSizeX = map.GetLength(0);
            mapSizeY = map.GetLength(1);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Console.WriteLine("Text game made by Zacharias\n©Zacharias 2021");
            //Console.WriteLine(now.Hour + ":" + now.Minute + ":" + now.Second);
            //clearMap();
            wait(3);
            Console.Clear();
            for(int i = 0; i < mapSizeY+2; i++){
                Console.WriteLine("");
            }
            Console.Write("W="+mapSizeX+" H="+mapSizeY+"\n");
            //Environment.Exit(0);
            while (true)
            {
                writeMap();
                if(wasOnSpecial) writeMap();
                keyPress();
                if(playerWasOnTp) writeMap();
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
            ConsoleKeyInfo rawKey = Console.ReadKey();
            ConsoleKey key = rawKey.Key;
            if (key == ConsoleKey.UpArrow && playerX > 0)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 16) && !makeMap)
                {
                    playerX++;
                }
                playerX--;
                if (!canDoMove())
                {
                    if (map[playerX, playerY] == 14)
                    {
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerX--;
                    }
                    else
                    {
                        playerX++;
                    }
                }
            }else if (key == ConsoleKey.DownArrow && playerX < mapSizeX - 1)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 16) && !makeMap)
                {
                    playerX--;
                }
                playerX++;
                if (!canDoMove())
                {
                    
                    if (map[playerX, playerY] == 13)
                    {
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerX++;
                    }
                    else
                    {
                        playerX--;
                    }
                }
            }
            else if (key == ConsoleKey.LeftArrow && playerY > 0)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 17) && !makeMap)
                {
                    playerY++;
                }
                playerY--;
                if (!canDoMove())
                {
                    if (map[playerX, playerY] != 11)
                    {

                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerY++;
                    }
                    else
                    {
                        playerY--;
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("<<<"+map[playerX,playerY]+">>>");
                    }
                }
            }
            else if (key == ConsoleKey.RightArrow && playerY < mapSizeY - 1)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 17) && !makeMap)
                {
                    playerY--;
                }
                playerY++;
                if (!canDoMove())
                {
                    if (map[playerX, playerY] == 12)
                    {

                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerY++;
                    }
                    else
                    {
                        playerY--;
                    }

                }
            }
            else if (key == ConsoleKey.Enter)
            {
                makeMap = !makeMap;
            }/*else if(key == ConsoleKey.OemMinus)
            {
                typeMode = !typeMode;
            }*/else if (makeMap)
            {
                if (key == ConsoleKey.F1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                    Console.Write("case " + lvl + ": return new int[20,20]\n");
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
                    Console.WriteLine("};");
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    map[playerX, playerY] = 0;
                }
                else if (key == ConsoleKey.C)
                {
                    clearMap();
                }
                else if (key == ConsoleKey.M)
                {
                    Console.SetCursorPosition(0, mapSizeY + 1);
                    Console.Write(" ");
                    Console.SetCursorPosition(0, mapSizeY + 2);
                    loadMap(int.Parse(Console.ReadKey().KeyChar + ""));
                    Console.BackgroundColor = colors[1];
                }
                else if (key == ConsoleKey.NumPad0)
                {
                    map[playerX, playerY] = lastTile;
                }
                else
                {
                    for (int i = 0; i < keyIcons.Length; i++)
                    {
                        if (key == keyIcons[i])
                        {
                            map[playerX, playerY] = i;
                        }
                    }
                }
            }/*else if (typeMode)
            {
                map[playerX, playerY] = asciiToInt(rawKey.KeyChar);
            }*/
            else if (key == ConsoleKey.Escape)
            {
                if (!mapEqual(/*Util.convertMapToIntArray(GetMaps.getMap(lvl).map)*/GetMaps.getMap(lvl), map))
                {
                    ConsoleColor forgrund = Console.ForegroundColor;
                    ConsoleColor backgrund = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, mapSizeY + 1);
                    Console.Write("OPS: Do you whana exit and discard chages? press esc again to conferm");
                    Console.SetCursorPosition(0, mapSizeY + 2);
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = backgrund;
                        Console.ForegroundColor = forgrund;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.SetCursorPosition(0, mapSizeY + 4);
                //Console.Write(key.ToString());
            }
            Console.SetCursorPosition(0, mapSizeY + 1);
            Console.Write(" ");
        }

        private bool mapEqual(int[,] map1, int[,] map2)
        {
            int mapSizeX = map1.GetLength(0);
            int mapSizeY = map1.GetLength(1);
            if ((mapSizeX != map2.GetLength(0)) || (mapSizeY != map2.GetLength(1))) return false;
            //Console.SetCursorPosition(0, 0);
            //Console.Write("same size");
            for(int x = 0; x < mapSizeX; x++)
            {
                for(int y = 0; y < mapSizeY; y++)
                {
                    if(map1[x,y] != map2[x, y])
                    {
                        return false;
                    }
                }
            }
            //Console.SetCursorPosition(0, 0);
            //Console.Write("same blocks");
            return true;
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
            for(int i = 0; i < walkibles.Length; i++)
            {
                if(v == walkibles[i])
                {
                    return true;
                }
            }
            return false;
        }

        bool wasOnSpecial = false;
        bool wasOnDmg = false;
        
        private void writeMap()
        {
            Console.SetCursorPosition(0, 1);
            int[] tpX = {-1, -1};
            int[] tpY = {-1, -1};
            bool playerOnTp = false;
            if(lifes == 0){
                lifes = 5;
                loadMap(0);
                lvl = 0;
                Console.SetCursorPosition(0, 0);
                Console.Write("Level " + (lvl - 1) + " compleat. Curent lvl " + lvl);
                playerX = 1;
                playerY = 1;
                writeMap();
                return;
            }
            Console.Write("You have "+lifes+" lifes left\n");
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    int num = map[x, y];
                    string icon = num.ToString();
                    if (x == playerX && y == playerY) {
                        if (num == 9 && !makeMap)
                        {
                            /*if (!mapEqual(/*Util.convertMapToIntArray(GetMaps.getMap(lvl).map)*//*GetMaps.getMap(lvl), map))
                            {
                                ConsoleColor forgrund = Console.ForegroundColor;
                                ConsoleColor backgrund = Console.BackgroundColor;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(0, mapSizeY + 1);
                                Console.Write("OPS: Do you whana exit and discard chages? press esc again to conferm");
                                Console.SetCursorPosition(0, mapSizeY + 2);
                                if (Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = backgrund;
                                    Console.ForegroundColor = forgrund;
                                }
                            }*/
                            lvl++;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Level " + (lvl - 1) + " compleat. Curent lvl " + lvl);
                            loadMap(lvl);
                            writeMap();
                            return;
                        }
                        if(num == 18 && !makeMap && !wasOnDmg){
                            wasOnDmg = true;
                            lifes--;
                        }else{
                            wasOnDmg = false;
                        }
                    }
                    if(num == 9){
                        endX = x;
                        endY = y;
                        wasOnSpecial = true;
                    }
                    else if(num == 8)
                    {
                        if (!playerWasOnTp && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX[0] != -1 && tpY[0] != -1)
                                {
                                    playerX = tpX[0];
                                    playerY = tpY[0];
                                    playerWasOnTp = true;
                                }
                                else
                                {
                                    playerOnTp = true;
                                }
                            }
                            else
                            {
                                tpX[0] = x;
                                tpY[0] = y;
                            }
                            if (playerOnTp)
                            {
                                if (tpX[0] != -1 && tpY[0] != -1)
                                {
                                    playerX = tpX[0];
                                    playerY = tpY[0];
                                    playerWasOnTp = true;
                                }
                            }
                        }else{
                            playerWasOnTp = false;
                        }
                        /*int[] tmp = tp(tpX[0], tpY[0], x, y, playerOnTp);
                        tpX[0] = tmp[0];
                        tpY[0] = tmp[1];
                        playerOnTp = tmp[2]==1;*/
                    }
                    else if(num == 10)
                    {
                        if (!playerWasOnTp && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX[1] != -1 && tpY[1] != -1)
                                {
                                    playerX = tpX[1];
                                    playerY = tpY[1];
                                    playerWasOnTp = true;
                                }
                                else
                                {
                                    playerOnTp = true;
                                }
                            }
                            else
                            {
                                tpX[1] = x;
                                tpY[1] = y;
                            }
                            if (playerOnTp)
                            {
                                if (tpX[1] != -1 && tpY[1] != -1)
                                {
                                    playerX = tpX[1];
                                    playerY = tpY[1];
                                    playerWasOnTp = true;
                                }
                            }
                        }else{
                            playerWasOnTp = false;
                        }
                        /*int[] tmp = tp(tpX[1], tpY[1], x, y, playerOnTp);
                        tpX[1] = tmp[0];
                        tpY[1] = tmp[1];
                        playerOnTp = tmp[2]==1;*/
                    }
                    try
                    {
                        Console.ForegroundColor = colors[num + 2];
                        if (num == 6 || num == 15)
                        {
                            Console.ForegroundColor = colors[2];
                        }
                    }
                    catch (Exception e) { 
                        e.ToString();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    try
                    {
                        if (makeMap)
                        {
                            icon = this.devIcons[num];
                        }
                        else
                        {
                            icon = this.icons[num];
                        }
                    }catch(Exception e) { e.ToString(); }
                    if (x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = colors[0];
                        icon = "&";
                    }
                    if(!(((  x <= playerX + renderDistend && x >= playerX - renderDistend) && 
                            (y <= playerY + renderDistend && y >= playerY - renderDistend)) || 

                            ((x <= endX + renderDistend && x >= endX - renderDistend) && 
                            (y <= endY + renderDistend && y >= endY - renderDistend))))
                    {
                        if (!makeMap) icon = " ";
                    }
                    else if((map[playerX, playerY] == 16) && (map[x, y] != 16) && (!makeMap))
                    {
                        icon = " ";
                        if ((y > playerY || y < playerY) && !(x < playerX || x > playerX)) icon = this.icons[num];
                        
                    }else if ((map[playerX, playerY] == 16) && (x > playerX || x < playerX) && !makeMap) icon = " ";
                    Console.Write(icon);
                }
                Console.Write("\n");
            }
            if (makeMap)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Curent pice: '" + this.icons[map[playerX, playerY]] + "' id: " + map[playerX, playerY]+ "  ");
                Console.WriteLine(mapIcons);
                Console.WriteLine(commands);
            }
            else
            {
                
                for (int i = 0; i < 25; i++)
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
                //Console.WriteLine("\nX[0] = "+tpX[0]+": Y[0] = "+tpY[0]);
                //Console.WriteLine("X[1] = "+tpX[1]+": Y[1] = "+tpY[1]);
            }
        }

        private void loadMap(int lvl1){
            //Map map = GetMaps.getMap(lvl1);
            map = GetMaps.getMap(lvl1);
            playerX = playerX;//map.startPosition[0];
            playerY = playerY;//map.startPosition[1];
            colors = ColorMaps.colorMap(lvl1);//Util.convertIntArrayToColor(Util.convertListToIntArray(map.color));
            //colors = ColorMaps.colorMap(lvl);
            lvl = lvl1;
            //mapSizeX = map.GetLength(0);
            //mapSizeY = map.GetLength(1);
        }

        private int[] tp(int tpX, int tpY, int x, int y, bool playerOnTp){
            if (!playerWasOnTp && !makeMap)
            {
                if(x == playerX && y == playerY)
                {
                    if(tpX != -1 && tpY != -1)
                    {
                        playerX = tpX;
                        playerY = tpY;
                        playerWasOnTp = true;
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
                        playerWasOnTp = true;
                    }
                }
            }else{
                playerWasOnTp = false;
            }
            return new int[]{tpX, tpY, (playerOnTp?1:0)}; 
        }

        static string getSafeLocation()
        {
            PlatformID p = Environment.OSVersion.Platform;
            Console.WriteLine(p);
            Console.WriteLine(p);
            if(p == PlatformID.MacOSX)
            {
                return "~/Library/Application\\ Support/Zacharias/TextGame";
            }else if(p == PlatformID.Win32NT)
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
            Console.WriteLine(loc);
            Console.WriteLine(Path.Combine(loc, "Test.txt"));
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